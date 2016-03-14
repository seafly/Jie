Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frqg0
    '*********************************************************************************************************************
    ' 此模块为请购的添加界面，由计划界面点击请购添加进入该界面，上表为基础表信息 ，下表为选择的请购信息
    '使用方法： 填写文本框中信息，点击确定，然后上表会显示基础信息，双击弹出请购的每条信息的添加界面确定后显示到下表，最后点提交，则完成全部请购过程
    '*********************************************************************************************************************
    Dim dt As DataTable '用于重置上表
    Dim dt2 As DataTable '用于改变计划的下面表
    Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
    Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    Private Sub wz()
        GroupBox3.Width = Me.Width - GroupBox1.Left - 20
        GroupBox1.Top = GroupBox3.Bottom + 10
        GroupBox1.Height = Me.Height - GroupBox1.Top - 40
        GroupBox1.Width = Me.Width - GroupBox1.Left - 20
        show2.Width = GroupBox1.Width - 10

    End Sub

    Private Sub Frqg0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wz()
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘请购单号的lable提示
        ComboBox1.SelectedIndex = 0

        Try
            Dim sql As String = "select  tb_qgcg_id,tb_qgcg_jhdh from tb_qgcg where tb_qgcg_wpfl='备品备件' order by tb_qgcg_id desc"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Label20.Text &= dt.Rows(0)(0) & ","
            sql = "select top 1  tb_qgcg_jhdh from tb_qgcg where tb_qgcg_wpfl<>'备品备件' order by tb_qgcg_id desc"
            dt = GF_CreateDataSource(G_cnnstr, sql)
            Label20.Text &= dt.Rows(0)(0)
        Catch ex As Exception

        End Try

        '‘’‘’‘’‘’‘’‘’‘''''''''''''''''’部门
        For i As Integer = 0 To dt1.Rows.Count - 1
            tb_qgcg_qgbm.Items.Add(dt1.Rows(i)(0))
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''默认值
        'Dim sql11 As String = "select top 1 tb_qgcg_qgrq from tb_qgcg order by tb_qgcg_id desc "
        'Dim dt11 As DataTable = GF_CreateDataSource(G_cnnstr, sql11)
        'tb_qgcg_qgrq.Text = Null2String(dt11.Rows(0)(0))
    End Sub

    Private Sub Frqg0_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tb_qgcg_qgr.Text = "" Or tb_qgcg_qgbm.Text = "" Or tb_qgcg_jhdh.Text = "" Then
            MsgBox("请将数据填写完整！") : Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''判断部门是否存在
        Dim bmcn As String = GF_cnwithen(dt1, "tb_bm_p512h='" & tb_qgcg_qgbm.Text & "'", 0) '得到表中文名称
        If bmcn = "" Then
            MsgBox("请输入正确的请购部门！")
            Exit Sub
        End If
        ''’‘’‘’‘’‘’‘’‘ 判定请购单号是否为10位
        'Dim sr As String = tb_qgcg_jhdh.Text
        'Dim zf() As Char = sr.ToCharArray()
        'If zf.Length <> 11 Then
        '    MsgBox("批号必须为11位数！") : Exit Sub
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''上表的显示
        Dim nform As Frjh = Me.Owner
        Dim dtgrid1 As DataGridView = nform.show1
        dt = dtgrid1.DataSource
        If tb_qgcg_jhdh.Text.Contains("BJ") = True Then
            dt = DeepCode.DeepDoDataTable.GF_czmctb(dt, "tb_wp_wpfl='备品备件'")
            GS_DataGridViewbyDb(show1, dt, True, True)
        ElseIf tb_qgcg_jhdh.Text.Contains("YL") = True Then
            dt = DeepCode.DeepDoDataTable.GF_czmctb(dt, "tb_wp_wpfl<>'备品备件'")
            GS_DataGridViewbyDb(show1, dt, True, True)
        Else
            MsgBox("您输入的请购单号有误请重新输入") : Exit Sub
        End If
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''下表显示
        dtgrid1 = nform.show2
        dt2 = dtgrid1.DataSource
        Dim dt22 As DataTable = dt2.Clone '得到表架构
        GS_DataGridViewbyDb(show2, dt22, True, True)
        show2.Columns(0).Visible = False '''''''隐藏主键显示
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''筛选框的填充
        ComboBox3.Items.Clear()
        For i As Integer = 1 To dt.Columns.Count - 1 ' 0是主键
            If dt.Columns(i).DataType.ToString = "System.String" Then

                ComboBox3.Items.Add(show1.Columns(i).HeaderText)
            End If
        Next
        tb_qgcg_jhdh.ReadOnly = True : tb_qgcg_qgbm.Enabled = False : tb_qgcg_qgr.Enabled = False : Button1.Enabled = False : tb_qgcg_qgrq.Enabled = False : ComboBox1.Enabled = False
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        show1.DataSource = dt
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click '''''''''''''筛选
        Dim cxzd As String = ""
        For i As Integer = 1 To show1.Columns.Count - 1
            If show1.Columns(i).HeaderText = ComboBox3.Text Then
                cxzd = show1.Columns(i).Name
                Exit For
            End If
        Next
        Dim cxzfc As String = "1=1 "
        cxzfc &= "and " & cxzd & " like '%" & TextBox2.Text.Trim & "%'"
        Dim dtsx As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt, cxzfc)
        GS_DataGridViewbyDb(show1, dtsx, True, True)
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
    End Sub

    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        If show1.RowCount = 0 Then
            Return
        End If
        Dim nform As New Frqg
        Me.AddOwnedForm(nform)
        Dim i As String = show1.SelectedRows(0).Cells(0).Value
        nform.id = i
        nform.tb_qgcg_gsmc.Text = show1.SelectedRows(0).Cells("tb_wp_gsmc").Value
        nform.tb_qgcg_dm.Text = show1.SelectedRows(0).Cells("tb_wp_dm").Value
        
        nform.tb_qgcg_pm.Text = show1.SelectedRows(0).Cells("tb_wp_pm").Value
        nform.tb_qgcg_ggxh.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_ggxh").Value)
        nform.tb_qgcg_dw.Text = show1.SelectedRows(0).Cells("tb_wp_dw").Value
        nform.tb_qgcg_wpbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_bz").Value)
        nform.tb_qgcg_wllb.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_wllb").Value)
        nform.tb_qgcg_wpfl.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_wpfl").Value) '物品分类
        nform.tb_qgcg_qgbm.Text = tb_qgcg_qgbm.Text
        nform.tb_qgcg_jhdh.Text = tb_qgcg_jhdh.Text

        nform.tb_qgcg_qgr.Text = tb_qgcg_qgr.Text
        nform.tb_qgcg_qgrq.Text = tb_qgcg_qgrq.Text

        nform.Label21.Visible = False
        nform.tb_qgcg_cgbz.Visible = False
        nform.Label29.Visible = False
        nform.Label30.Visible = False
        nform.Label15.Visible = False
        nform.tb_qgcg_qgdsfsx.Visible = False
        nform.tb_qgcg_qgdsxrq.Visible = False
        nform.tb_qgcg_ysbm.Visible = False
        nform.Label18.Visible = False
        nform.tb_qgcg_tdbz.Visible = False
        nform.Label14.Visible = False
        nform.tb_qgcg_qgzt.Visible = False
        nform.id = ""
        nform.tb_qgcg_qgzt.Visible = False
        nform.Label14.Visible = False
        nform.ShowDialog()
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click '提交
        If Me.show2.Rows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ccrsdb(Me.show2, "tb_qgcg", dt2)
        Select Case ComboBox1.SelectedIndex
            Case 0
                ClassPhgn.ClassPhgn_SetDqz2("备品备件请购单号") '使当前批号+1
            Case 1
               ClassPhgn.ClassPhgn_SetDqz2("原料包材请购单号") '使当前批号+1
        End Select

        Me.Close()
    End Sub
    Public Sub ccrsdb(ByVal list1 As Control, ByVal strtb2 As String, ByRef dt As DataTable) 'list1表示要提交的控件名  strtb2 代表目标数据库中的表名 dt 表要改变的datagridview的datasource（注意是byref）
        Dim dtr As DataRow
        Try
            Dim lt As DataGridView = list1
            For k As Integer = 0 To lt.Rows.Count - 1
                dtr = dt.NewRow
                Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
                cnn.ConnectionString = G_cnnstr
                cnn.Open()
                Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
                RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                RS.addnew()
                Dim dtsj As DataTable = show2.DataSource
                For j As Integer = 0 To dtsj.Columns.Count - 1 '主键让系统自动生成，show2中数据的主键全部被设置为0
                    If dtsj.Columns(j).ColumnName <> "tb_qgcg_ID" Then
                        RS(dtsj.Columns(j).ColumnName).value = lt.Rows(k).Cells(dtsj.Columns(j).ColumnName).Value
                        dtr(dtsj.Columns(j).ColumnName) = lt.Rows(k).Cells(dtsj.Columns(j).ColumnName).Value
                    End If
                Next
                RS.update()
                dtr("tb_qgcg_id") = RS("tb_qgcg_id").value

                If RS("tb_qgcg_wpfl").value = "备品备件" Then
                    Dim sql As String = " insert into tb_dhgz (tb_dhgz_qgrq,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_gsmc,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw"
                    sql &= ",tb_dhgz_wllb,tb_dhgz_qgbz,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_qgsl,tb_dhgz_wpfl,tb_dhgz_jhdh,tb_dhgz_sbid,tb_dhgz_sfys,tb_dhgz_dhsl)"
                    sql &= " select tb_qgcg_qgrq,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_gsmc,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_dw"
                    sql &= " , tb_qgcg_wllb,'根据采购部要求取消采购审核功能',tb_qgcg_qgzt,'是',cast(tb_qgcg_qgsl as varchar),tb_qgcg_wpfl,tb_qgcg_jhdh,'" & RS("tb_qgcg_id").value & "',null,tb_qgcg_qgsl  "
                    sql &= " from tb_qgcg where tb_qgcg_id='" & RS("tb_qgcg_id").value & "' "
                    Dim StrId As String = GF_upztxx2(G_cnnstr, sql, "tb_dhgz")
                    Dim sql0 As String = "update tb_qgcg set tb_qgcg_qgdsfsx='是',tb_qgcg_xbid=" & StrId & "  where tb_qgcg_id='" & RS("tb_qgcg_id").value & "' "
                    GS_upztxx(G_cnnstr, sql0)
                    dtr("tb_qgcg_qgdsfsx") = "是"
                End If
                dt.Rows.Add(dtr)
                RS.close()
                RS = Nothing
                cnn.close()
                cnn = Nothing

            Next
            MsgBox("提交成功")
        Catch ex As Exception
            MsgBox("数据储存出错")
        End Try
    End Sub

    Private Sub show2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show2.DoubleClick
        show2.Rows.RemoveAt(show2.SelectedRows(0).Index)
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                Dim qztemp As String = ClassPhgn.ClassPhgn_Get("备品备件请购单号", "-") '得到当前批号+1的批号
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                tb_qgcg_jhdh.Text = qztemp
            Case 1
                Dim qztemp As String = ClassPhgn.ClassPhgn_Get("原料包材请购单号", "-") '得到当前批号+1的批号
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                tb_qgcg_jhdh.Text = qztemp
        End Select
    End Sub
    Private Function pd(ByVal dm As String) As Boolean '发货主管仅可选择此三种物料
        Dim dm0 As String = "3.09.001,3.09.007,3.07.014"
        dm0 = "'" & Replace(dm0, ",", "','") & "'"
        dm = "'" & dm & "'"
        If InStr(dm0, dm) = 0 Then
           Return False
        End If
        Return True
    End Function
End Class