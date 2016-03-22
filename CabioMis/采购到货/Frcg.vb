Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frcg
    Public id As String = ""
    Private v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
    Dim dgzl As String = Nothing
    Private Sub Frcg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_cg_fqcs.SelectedIndex = 0
        tb_cg_qyfy.Text = 0
        tb_cg_fzr.SelectedIndex = 0
        tb_cg_yszq1.Text = 3
        tb_cg_yszq2.Text = 3
        tb_cg_yszq3.Text = 3
 

        If id <> "" Then
            Gs_showsj("tb_cg", Me, id)
            dgzl = tb_cg_dgzl.Text
        End If


    End Sub

    Private Sub tb_cg_fqcs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cg_fqcs.SelectedIndexChanged
        cf()
    End Sub
    Private Sub cf()
        '不同拆分批次  日期数量的不同显示
        Select Case tb_cg_fqcs.SelectedIndex
            Case 0
                tb_cg_yjdhrq1.Enabled = True
                tb_cg_yjdhl1.Enabled = True
                tb_cg_yjdhrq2.Enabled = False
                tb_cg_yjdhl2.Enabled = False
                tb_cg_yjdhrq3.Enabled = False
                tb_cg_yjdhl3.Enabled = False
                tb_cg_yszq1.Enabled = True
                tb_cg_yszq2.Enabled = False
                tb_cg_yszq3.Enabled = False

            Case 1
                tb_cg_yjdhrq1.Enabled = True
                tb_cg_yjdhl1.Enabled = True
                tb_cg_yjdhrq2.Enabled = True
                tb_cg_yjdhl2.Enabled = True

                tb_cg_yjdhrq3.Enabled = False
                tb_cg_yjdhl3.Enabled = False
                tb_cg_yszq1.Enabled = True
                tb_cg_yszq2.Enabled = True
                tb_cg_yszq3.Enabled = False

            Case 2
                tb_cg_yjdhrq1.Enabled = True
                tb_cg_yjdhl1.Enabled = True
                tb_cg_yjdhrq2.Enabled = True
                tb_cg_yjdhl2.Enabled = True
                tb_cg_yjdhrq3.Enabled = True
                tb_cg_yjdhl3.Enabled = True
                tb_cg_yszq1.Enabled = True
                tb_cg_yszq2.Enabled = True
                tb_cg_yszq3.Enabled = True

        End Select

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定" & tb_cg_fqcs.Text, 1, "提示") <> 1 Then
            Exit Sub
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If GF_storelog1("采购及请购单生效及偏差") = False Then '
            Exit Sub
        End If ' 判断是否有权限
        If CDbl(tb_cg_dgzl.Text) * 1 = 0 Then
            Dim dResult As DialogResult = MessageBox.Show("如果订购总量为0，则请购数量也同时为0,您确定完成此操作吗？", "系统提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            Dim bz As String = ""
            If dResult <> Windows.Forms.DialogResult.Yes Then
                tb_cg_dgzl.Text = dgzl
                Exit Sub
            Else
                bz = InputBox("请输入原因！", "系统提示：")
                If bz = "" Then
                    MsgBox("请填写备注！")
                    tb_cg_dgzl.Text = dgzl
                    Exit Sub
                Else
                    tb_cg_qgsl.Text = "0"
                End If
            End If
            tb_cg_cgbz.Text = bz & vbCrLf & tb_cg_cgbz.Text
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''如果数据库中没有 填写的 生产商 或者 供应商 ，则存入 该条 生产商 或者 供应商到数据库中
        'Dim g As String = tb_cg_gysmc.Text
        'Dim h As String = tb_cg_wpfl.Text
        'Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_gys_gys from tb_gys where 1=1 and  tb_gys_gys='" & g & "' and tb_gys_fl='" & h & "' and tb_gys_fl2='供应商'")

        'If dt.Rows.Count = 0 Then
        '    GS_upztxx(G_cnnstr, "insert into tb_gys(tb_gys_gys,tb_gys_fl,tb_gys_fl2) values ('" & g & "','" & h & "','供应商')")
        'End If
        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim s As String = tb_cg_scs.Text
        'dt = GF_CreateDataSource(G_cnnstr, "select tb_gys_gys from tb_gys where 1=1 and  tb_gys_gys='" & s & "' and tb_gys_fl2='生产商'")

        'If dt.Rows.Count = 0 Then
        '    GS_upztxx(G_cnnstr, "insert into tb_gys(tb_gys_gys,tb_gys_fl,tb_gys_fl2) values ('" & s & "',null,'生产商')")
        'End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If id <> "" Then
            If GF_modsj("tb_cg", Me, id) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_storelog3("采购及请购单生效及偏差：采购修改 id " & id & "", "采购及请购单生效及偏差") '储存到日志


            Dim f As Frjh = Me.Owner
            Dim datagrid As DataGridView = f.show2
            Dim dt1 As DataTable = datagrid.DataSource
            Frjh.ChangeData(Me, dt1, id)

        Else
            If tb_cg_yjdhl2.Enabled = True And tb_cg_yjdhl2.Text = "" Then
                MsgBox("第二批的重量不能为空！", MsgBoxStyle.Exclamation)
                tb_cg_yjdhl2.Focus
                Return
            End If
            If tb_cg_yjdhl3.Enabled = True And tb_cg_yjdhl3.Text = "" Then
                MsgBox("第三批的重量不能为空！", MsgBoxStyle.Exclamation)
                tb_cg_yjdhl3.Focus()
                Return
            End If
            dhgz()
            If tb_cg_wpfl.Text <> "备品备件" Then
                ClassPhgn.ClassPhgn_SetDqz2("采购单号") '使当前批号+1
            End If

            If tb_cg_sfbh.Text <> "补货" Then
                Dim f As Frjh = Me.Owner
                Dim dtgr As DataGridView = f.show1
                Dim dtx As DataTable = dtgr.DataSource
                Frjh.DelRow(dtx, dtgr.SelectedRows(0).Cells(0).Value) '数据变化，少显示一行
            End If

            '''''''''''''''''''''''''''''''''''''
        End If
        Me.Close()


    End Sub
    Private Function dhdh(ByVal i As Integer) As String '单号尾数判断
        Dim h As String = ""
        Select Case i
            Case 1
                Dim dth As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cg_ID from tb_cg where tb_cg_cgdh ='" & tb_cg_cgdh.Text & "' and tb_cg_dm='" & tb_cg_dm.Text & "'")
                Select Case dth.Rows.Count + 1
                    Case 1
                        h = "-Ⅰ"
                    Case 2
                        h = "-Ⅱ"
                    Case 3
                        h = "-Ⅲ"
                    Case 4
                        h = "-Ⅳ"
                    Case 5
                        h = "-Ⅴ"
                    Case 6
                        h = "-Ⅵ"
                End Select
            Case 2
                h = "-Ⅱ"
            Case 3
                h = "-Ⅲ"
        End Select
        dhdh = h
    End Function
    Private Sub dhgz()
        If tb_cg_sfbh.Text = "补货" Then
            Dim sqlq As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz,tb_cg_scs,tb_cg_xh,tb_cg_wbz,tb_cg_gysbs)"
            sqlq &= "values('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & dhdh(1) & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "', "
            sqlq &= "  '" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & GF_gettrqsj(tb_cg_yjdhrq1.Text) & "'," & tb_cg_yjdhl1.Text & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "' , "
            sqlq &= "  " & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "',"
            sqlq &= "  " & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & tb_cg_yszq1.Text & "',"
            sqlq &= "  '" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "', '" & tb_cg_jhdh.Text & "','" & tb_cg_cgbz.Text & "','" & tb_cg_scs.Text & "','" & tb_cg_xh.Text & "','" & tb_cg_wbz.Text & "','"& tb_cg_gysbs.Text &"')"
            Dim idstring As String = GF_upztxx2(G_cnnstr, sqlq, "tb_cg")
            GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & idstring & "' where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'")

        Else
            '拆分
            If tb_cg_fqcs.SelectedIndex = 0 Then '一批拆分
                Dim sql1 As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz,tb_cg_scs,tb_cg_xh,tb_cg_wbz,tb_cg_gysbs)"
                sql1 &= " values ('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & GF_gettrqsj(tb_cg_yjdhrq1.Text) & "'," & tb_cg_yjdhl1.Text & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & tb_cg_yszq1.Text & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "','" & tb_cg_cgbz.Text & "','" & tb_cg_scs.Text & "','" & tb_cg_xh.Text & "','" & tb_cg_wbz.Text & "','"& tb_cg_gysbs.Text &"')"
                Dim idstring As String = GF_upztxx2(G_cnnstr, sql1, "tb_cg")
                GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & idstring & "' where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'")
                Dim f As Frjh = Me.Owner
                Dim dtgr As DataGridView = f.show2
                Dim dt As DataTable = dtgr.DataSource
                Frjh.ChangeAddData(Me, dt, idstring) '添加数据
            Else

                '多批拆分
                Dim sb As String = "" '上部id获取
                For i As Integer = 1 To tb_cg_fqcs.SelectedIndex + 1
                    Dim q() As String = {GF_gettrqsj(tb_cg_yjdhrq1.Text), GF_gettrqsj(tb_cg_yjdhrq2.Text), GF_gettrqsj(tb_cg_yjdhrq3.Text)}
                    Dim l() As String = {tb_cg_yjdhl1.Text, tb_cg_yjdhl2.Text, tb_cg_yjdhl3.Text}
                    Dim zq() As String = {tb_cg_yszq1.Text, tb_cg_yszq2.Text, tb_cg_yszq3.Text}
                    Dim sql1 As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz,tb_cg_scs,tb_cg_xh,tb_cg_wbz,tb_cg_gysbs)"
                    sql1 &= "values('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & dhdh(i) & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & q(i - 1) & "'," & l(i - 1) & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & zq(i - 1) & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "','" & tb_cg_cgbz.Text & "','" & tb_cg_scs.Text & "','" & tb_cg_xh.Text & "','" & tb_cg_wbz.Text & "','"& tb_cg_gysbs.Text &"')"
                    Dim idstring As String = GF_upztxx2(G_cnnstr, sql1, "tb_cg")
                    sb = sb & idstring & ","
                    Dim f As Frjh = Me.Owner
                    Dim dtgr As DataGridView = f.show2
                    Dim dt As DataTable = dtgr.DataSource
                    Frjh.ChangeAddData(Me, dt, idstring) '添加数据
                Next
                sb = GF_removedh(sb)
                GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & sb & "' where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'")

            End If
        End If

    End Sub

    Private Sub jszj(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cg_qyfy.TextChanged, tb_cg_dj.TextChanged, tb_cg_dgzl.TextChanged, tb_cg_yszq3.TextChanged, tb_cg_yszq2.TextChanged, tb_cg_yszq1.TextChanged
        Try
            Dim sz1 As String = tb_cg_qyfy.Text
            If sz1 = "" Then
                sz1 = 0
            End If
            Dim sz2 As String = tb_cg_dgzl.Text
            If sz2 = "" Then
                sz2 = 1
            End If
            Dim f As Double = tb_cg_dj.Text * sz2 + sz1
            tb_cg_zj.Text = f '单价*数量+其余费用
        Catch ex As Exception

        End Try


    End Sub

    Private Sub tb_cg_gysmc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cg_gysmc.DoubleClick
        Dim aa As New FrgetGysmc
        Me.AddOwnedForm(aa)
        aa.dm = tb_cg_dm.Text
        aa.ShowDialog()
    End Sub
End Class