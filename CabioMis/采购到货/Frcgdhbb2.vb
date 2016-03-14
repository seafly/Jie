Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frcgdhbb2

    Private Sub Frcgdhbb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
        showsj()

    End Sub
    Private Sub wz()
        show1.Width = Me.Width - 10
        show1.Height = Me.Height - show1.Top - 50
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub showsj()
        Dim sql As String = "select tb_dhgz_wpfl, tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_dj,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,sum(tb_dhgz_yshgl) as '总合格量',tb_dhgz_yszq,tb_dhgz_yssx2,tb_dhgz_ysr from tb_dhgz "
        Dim sql0 As String = "where tb_dhgz_wpfl='原料' or tb_dhgz_wpfl='包材' group by  tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,tb_dhgz_yssx2,tb_dhgz_ysr,tb_dhgz_yszq,tb_dhgz_dj"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql & sql0) '验收的数据
        Dim sqlqg As String = "select tb_qgcg_wpfl,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_qgrq,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_dw,tb_qgcg_qgsl,tb_qgcg_yqyt,tb_qgcg_qgzt,tb_qgcg_qgdsfsx from tb_qgcg where tb_qgcg_wpfl='原料' or tb_qgcg_wpfl='包材' and tb_qgcg_xbid is null"
        Dim dtqg As DataTable = GF_CreateDataSource(G_cnnstr, sqlqg) '请购中数据
        Dim sqlcg As String = "select tb_cg_wpfl,tb_cg_qgbm,tb_cg_qgr,tb_cg_qgrq,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_qgsl,tb_cg_yqyt,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_dj,tb_cg_cgdh,tb_cg_rq,tb_cg_fzr,tb_cg_dgzl,tb_cg_ysbm,tb_cg_fqcs,tb_cg_sfbh from tb_cg where tb_cg_wpfl='原料' or tb_cg_wpfl='包材' and tb_cg_xbid is null"
        Dim dtcg As DataTable = GF_CreateDataSource(G_cnnstr, sqlcg) '采购的数据
        Dim dr0 As DataRow '采购表中显示的只是此报表中的前十九列，因为其他列要经过到货跟踪验收来填充才有数据
        For j As Integer = 0 To dtcg.Rows.Count - 1
            dr0 = dt.NewRow() '一行一行循环填充

            For i As Integer = 0 To dtcg.Columns.Count - 1
                dr0(i) = dtcg.Rows(j)(i)


            Next

            dt.Rows.Add(dr0) '合并两个datatable前十九列
        Next
        Dim dr As DataRow '请购表中显示的只是此报表中的前十一列，因为其他列要经过采购和到货跟踪验收来填充才有数据

        For j As Integer = 0 To dtqg.Rows.Count - 1
            dr = dt.NewRow() '一行一行循环填充

            For i As Integer = 0 To dtqg.Columns.Count - 1
                dr(i) = dtqg.Rows(j)(i)


            Next

            dt.Rows.Add(dr) '合并两个datatable前十一列
        Next

        GS_DataGridViewbyDb(show1, dt, True, True)
        For i As Integer = 0 To show1.Rows.Count - 1
            Try
                If show1.Rows(i).Cells("tb_dhgz_yssx2").Value < Now().Date And show1.Rows(i).Cells("tb_dhgz_ysr").Value.ToString = "" Then
                    show1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow '变色
                    Dim cgdh As String = show1.Rows(i).Cells("tb_dhgz_cgdh").Value
                    For j As Integer = 0 To show1.Rows.Count - 1 '请购单相同的变色
                        If show1.Rows(j).Cells("tb_dhgz_cgdh").Value = cgdh Then
                            show1.Rows(j).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                    Next
                End If

            Catch ex As Exception

            End Try
        Next
        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4)
            'Dim bm As String = frdzxf.ddbm(dt.Columns(i).Caption) '得到表名
            Dim bm As String = ddbm(dt.Columns(i).Caption) '得到表名
            Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '得到表中文名称
            zwmz = bmcn & ":" & zwmz
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(zwmz)
                Case "System.DateTime" : ComboBox1.Items.Add(zwmz)

            End Select
        Next



    End Sub

    Private Sub Frcgdhbb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        dt1 = DeepCode.DeepDoGridView.ToDataTable(show1)
        Dim bds As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) '时间字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '文本字段
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then
                Return
            End If
            bds &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
        'Dim cxzd3 As String = gettruezdm(ComboBox3.Text) '数字字段
        'If cxzd3 <> "" And TextBox2.Text.Trim <> "" Then
        '    cxzd3 = "[" & cxzd3 & "]"
        '    Dim sz As String = TextBox2.Text.Trim
        '    sz = Replace(sz, "，", ",") '怕出现中文逗号
        '    'Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
        '    'If nnn <> "" Then
        '    '    bds &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
        '    'End If
        'End If
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB

        'If kk <> "" Then '下面自动完成求和汇总
        '    dt2 = dbqh(dt2, kk) '求和并附加到最后一行
        'End If
        show1.Columns.Clear() '避免头部消失
        show1.DataSource = dt2
        'If kk <> "" Then
        '    GS_ysgx(show1) '求和最后一行颜色更新
        'End If

        GS_TranEtoC(show1) '将DataGridView列字段翻译成为中文描叙
    End Sub
    Private Function gettruezdm(ByVal str As String) As String '得到真正英文字段名称
        Dim bmcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "left")
        Dim zdcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "right")
        If bmcn = "" Then
            Return zdcn
        End If
        Dim bm As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_biaoinf, "tb_biaoinf_mx='" & bmcn & "'", 1) '得到表英文名称
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_zdinf, "tb_biaozdinf_biao='" & bm & "' and tb_biaozdinf_mx='" & zdcn & "'", 1) '得到英文字段名称
        Return zd
    End Function

    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        Dim nform As New Frcgxx
        Me.AddOwnedForm(nform)
        Dim id As String = ""
        id = show1.SelectedRows(0).Cells("tb_dhgz_cgdh").Value.ToString
        If id <> "" Then
            nform.sql = "select tb_dhgz_wpfl,tb_dhgz_cgdh,tb_dhgz_yjdhrq,tb_dhgz_yjdhl,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_yssx2,tb_dhgz_ysr,tb_dhgz_ysrq,tb_dhgz_yshgl,tb_dhgz_bhgl,tb_dhgz_pccl from tb_dhgz"
            nform.sql &= " where tb_dhgz_cgdh='" & id & "'"
            nform.dt = GF_CreateDataSource(G_cnnstr, nform.sql)
            If nform.dt.Rows.Count = 0 Then
                MsgBox("还未验收！")
                Exit Sub
            End If
            nform.ShowDialog()
        Else
            MsgBox("请购单未生效或已退单！")
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        showsj()
    End Sub
    Public Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
End Class