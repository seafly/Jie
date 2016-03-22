Public Class Frfscylsy
    Public frname As String = ""
    Public m_strWldm = "" '选择的物料代码
    Public m_wlbs = "" '选择的物料代码
    Private Sub Frfscylsy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_jch_cz.SelectedIndex = 0
        tb_jch_yfcllygd.SelectedIndex = 0
        '''''''
        GS_FaceSearch(ComboBoxserchtext, "tb_jch", 1) '文本查询函数：关联表的文本字段的显示
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        xs()
    End Sub
    Private Sub xs()
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim Sql As String = "select tb_jch_ID,tb_jch_num ,tb_jch_cplb ,tb_jch_cz,tb_jch_yfcllygd,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_czrgh from tb_jch where tb_jch_cz not in('出','进') and tb_jch_rq between '" & tt1 & "' and '" & tt2 & "' "
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        Sql &= sqlbdssep
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, Sql)

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim bh As String = dt.Rows(i)(1) '得到标号
            Dim cc As String = "select tb_i259b_c24u from tb_i259b where tb_i259b_num='" & bh & "'"
            Dim ccdb As DataTable = GF_CreateDataSource(G_cnnstr, cc)
            If ccdb.Rows.Count > 0 Then
                dt.Rows(i)(2) = ccdb.Rows(0)(0)
            End If
        Next
        GS_DataGridViewbyDb(showl, dt, "0", True, True)
        GroupBox1.Text = "查询结果" & dt.Rows.Count & "条记录"
    End Sub
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, DateTimePicker1.Text & "至" & DateTimePicker2.Text, Me)
    End Sub

    Private Sub SSSQD_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If m_strWldm <> "罐" Then
            updateYl()
        Else
            updataGuan()
        End If

    End Sub

    '更新罐
    Private Sub updataGuan()
        MsgBox("更新罐")
    End Sub
    '更新原料
    Private Sub updateYl()
        Dim ph As String = tb_jch_num.Text.Trim '得到批号
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_i259b_c24u from tb_i259b where tb_i259b_ID='" & m_wlbs & "' and tb_i259b_num='" & ph & "'")
        tb_jch_cplb.Text = dt1.Rows(0)("tb_i259b_c24u") '得到产品名称,并给隐藏的产品类别赋值
        '''''''''判断必填''''''''''''备注可不填写

        If GF_YZSJ(Me, "tb_jch_bz") = False Then '验证控件
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''
        If GF_storelog1("添加非生产原料使用") = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''''

        Dim jj As String = GF_addsj("tb_jch", Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        Else
            '''''''''''''''''''''''''''''''''''扣除原料

            GS_modczsj("tb_jch", "tb_jch_czrgh", jj, G_dlrgh) '更新操作人工号
            Dim sl As Double = tb_jch_sl.Text '下面扣除原料重量
            Dim sql As String = "update tb_i259b set tb_i259b_p518h=tb_i259b_p518h-" & sl & " where tb_i259b_ID='" &
                m_wlbs & "' and tb_i259b_num='" & tb_jch_num.Text.Trim & "'"
            GS_upztxx(G_cnnstr, sql)
            ''''''''''''''''''''储存到日志
            GS_storelog3("添加非生产原料使用：" & ph & "，数量：" & tb_jch_sl.Text, "添加非生产原料使用")
            '''''''''''''''''''''
            MsgBox("更新数据完成")

            Me.tb_jch_sl.Text = ""
            tb_jch_bz.Text = ""
            tb_jch_num.Text = ""
            xs()

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If showl.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("删除数据将还原对应的原料库存，您确定吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("删除非生产原料使用") = False Then
            Exit Sub
        End If ' 判断是否有权限
        With showl
            Dim djsy As Integer = .SelectedRows(0).Index '删除索引
            Dim scid As String = .SelectedRows(0).Cells(0).Value '删除ID
            Dim hyph As String = .SelectedRows(0).Cells(1).Value '还原原料的批号
            Dim hysl As String = .SelectedRows(0).Cells(5).Value '还原原料的数量
            Dim sql As String = "delete from tb_jch where tb_jch_id=" & scid & vbCrLf
            sql &= "update tb_i259b set tb_i259b_p518h=tb_i259b_p518h+" & hysl & " where tb_i259b_num='" & hyph & "'"
            GS_upztxx(G_cnnstr, sql)
            .Rows.RemoveAt(djsy)
            GS_storelog3("删除非生产原料使用：" & hyph & "，数量：" & hysl, "删除非生产原料使用")
        End With

    End Sub

    Private Sub tb_jch_num_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_jch_num.MouseDoubleClick
        Dim aa As New Frfscylsy2
        aa.frname = Me.frname
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
    End Sub

    Private Sub SSSQX_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class