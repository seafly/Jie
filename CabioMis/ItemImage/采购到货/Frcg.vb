Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frcg
    Public id As String = ""
    Private v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
    Private Sub Frcg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_cg_fqcs.SelectedIndex = 0
        tb_cg_qyfy.Text = 0
        tb_cg_fzr.SelectedIndex = 0
        tb_cg_yszq1.Text = 3
        tb_cg_yszq2.Text = 3
        tb_cg_yszq3.Text = 3
        Dim sql As String = ""
        If tb_cg_wpfl.Text = "备品备件" Then
            sql = "select tb_gys_gys from tb_gys where tb_gys_fl='备品备件'"
        Else
            sql = "select tb_gys_gys from tb_gys where tb_gys_fl<>'备品备件'"
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_cg_gysmc.Items.Add(dt.Rows(i)(0))
            v.Add(dt.Rows(i)(0))
            tb_cg_gysmc.AutoCompleteCustomSource = v
        Next
        If id <> "" Then
            Gs_showsj("tb_cg", Me, id)
        Else
            Try
                Dim sql1 As String = "select top 1 tb_cg_dj,tb_cg_rq,tb_cg_gysmc,tb_cg_qyfy,tb_cg_zj,tb_cg_fzr from tb_cg order by tb_cg_id desc"
                Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
                tb_cg_dj.Text = dt1.Rows(0)(0)
                tb_cg_rq.Text = dt1.Rows(0)(1)
                tb_cg_gysmc.Text = dt1.Rows(0)(2)
                'tb_cg_dgzl.Text = dt1.Rows(0)(3)
                tb_cg_qyfy.Text = dt1.Rows(0)(3)
                tb_cg_zj.Text = dt1.Rows(0)(4)
                tb_cg_fzr.Text = dt1.Rows(0)(5)
                tb_cg_dgzl.Text = tb_cg_dgzl.Text
            Catch ex As Exception

            End Try

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
        If GF_YZSJ(Me, "tb_cg_ggxh,tb_cg_yjdhl2,tb_cg_yjdhl3,tb_cg_yjdhrq2,tb_cg_yjdhrq3,tb_cg_yszq2,tb_cg_yszq3,tb_cg_dhdh,tb_cg_sfbh,tb_cg_wpbz,tb_cg_qgbz") = False Then '验证控件
            Exit Sub
        End If

        Dim g As String = tb_cg_gysmc.Text
        Dim h As String = tb_cg_wpfl.Text
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_gys_gys from tb_gys where 1=1 and  tb_gys_gys='" & g & "' and tb_gys_fl='" & h & "'")

        If dt.Rows.Count = 0 Then
            GS_upztxx(G_cnnstr, "insert into tb_gys(tb_gys_gys,tb_gys_fl) values ('" & g & "','" & h & "')")
        End If

        If id <> "" Then


            If GF_modsj("tb_cg", Me, id) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If

            'GS_upztxx(G_cnnstr, "update tb_dhgz  set tb_dhgz_yjdhrq ='" & GF_gettrqsj(tb_cg_yjdhrq1.Text) & "',tb_dhgz_yjdhl=" & tb_cg_yjdhl1.Text & "  where tb_dhgz_ID= '" & id & "'")
            Dim f As Frjh = Me.Owner
            Dim datagrid As DataGridView = f.show2
            Dim dt1 As DataTable = datagrid.DataSource
            Frjh.ChangeData(Me, dt1, id)

        Else
            dhgz()

            'GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & tb_cg_sbid.Text & "' where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'")
            ClassPhgn.ClassPhgn_SetDqz2("采购单号") '使当前批号+1
            If tb_cg_sfbh.Text <> "补货" Then
                Dim f As Frjh = Me.Owner
                Dim dtgr As DataGridView = f.show1
                Dim dtx As DataTable = dtgr.DataSource
                Frjh.DelRow(dtx, dtgr.SelectedRows(0).Cells(0).Value) '数据变化，少显示一行
            End If

            '''''''''''''''''''''''''''''''''''''
        End If
        Try
            Me.Close()
            Dim nform As Frys = Me.Owner
            nform.Close()
        Catch ex As Exception

        End Try


    End Sub
    Private Function dhdh(ByVal i As Integer) As String '单号尾数判断
        Dim h As String = ""
        Select Case i
            Case 1
                Dim dth As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cg_ID from tb_cg where tb_cg_cgdh ='" & tb_cg_cgdh.Text & "'")

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
            Dim sqlq As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh)"
            sqlq &= "values('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & dhdh(1) & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & GF_gettrqsj(tb_cg_yjdhrq1.Text) & "'," & tb_cg_yjdhl1.Text & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & tb_cg_yszq1.Text & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "')"
            Dim idstring As String = GF_upztxx2(G_cnnstr, sqlq, "tb_cg")
            GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & idstring & "' where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'")

            'Dim f As Frjh = Me.Owner
            'Dim dtgr As DataGridView = f.show2
            'Dim dt As DataTable = dtgr.DataSource
            'Frjh.ChangeAddData(Me, dt, idstring) '添加数据
        Else
            '拆分
            If tb_cg_fqcs.SelectedIndex = 0 Then '一批拆分
                Dim sql1 As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh)"
                sql1 &= " values ('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & GF_gettrqsj(tb_cg_yjdhrq1.Text) & "'," & tb_cg_yjdhl1.Text & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & tb_cg_yszq1.Text & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "')"
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
                    Dim sql1 As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh)"
                    sql1 &= "values('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & dhdh(i) & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & q(i - 1) & "'," & l(i - 1) & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & zq(i - 1) & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "')"
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


End Class