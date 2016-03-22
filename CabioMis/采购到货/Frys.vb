Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frys
    Public id As String = ""
    Private Sub Frys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        xg()
    End Sub

    Private Sub tb_dhgz_sfbh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dhgz_sfbh.SelectedIndexChanged

        For i As Integer = 0 To Me.Controls.Count - 1
            Select Case Me.Controls(i).GetType.Name
                Case "TextBox"
                    If Me.Controls(i).Text = "" And CType(Me.Controls(i), TextBox).ReadOnly = False Then
                        MsgBox(DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & Me.Controls(i).Name & "'", 4) & "不能为空！")
                        Return
                    End If
                Case Else
            End Select
        Next

        Select Case tb_dhgz_sfbh.Text
            Case "补货"
                If GF_YZSJ(Me, "tb_dhgz_ggxh,tb_dhgz_pccl,tb_dhgz_wpbz,tb_dhgz_qgbz") = False Then '验证控件
                    Exit Sub
                End If
                Call combox1()
                Call xg()
        End Select
      End Sub
    Private Sub combox1() '向采购界面传值
        'Try
        If MsgBox("是否选择补货？", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim nform As New Frcg

        nform.tb_cg_qgbm.Text = tb_dhgz_qgbm.Text
        nform.tb_cg_qgr.Text = tb_dhgz_qgr.Text
        nform.tb_cg_gsmc.Text = tb_dhgz_gsmc.Text
        nform.tb_cg_dm.Text = tb_dhgz_dm.Text
        nform.tb_cg_pm.Text = tb_dhgz_pm.Text
        nform.tb_cg_ggxh.Text = tb_dhgz_ggxh.Text
        nform.tb_cg_dw.Text = tb_dhgz_dw.Text
        nform.tb_cg_wllb.Text = tb_dhgz_wllb.Text

        nform.tb_cg_ysbm.Text = tb_dhgz_ysbm.Text
        Dim sql As String = "select tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_yqdhrq,tb_cg_qgdsxrq,tb_cg_gysmc,tb_cg_qgbz,tb_cg_wpbz ,tb_cg_yszq1,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_dj,tb_cg_gysmc, tb_cg_dgzl ,tb_cg_qyfy ,tb_cg_zj ,tb_cg_fzr, tb_cg_yjdhl1, tb_cg_yjdhrq1,tb_cg_cgdh,tb_cg_wpfl,tb_cg_jhdh,tb_cg_cgbz,tb_cg_scs from tb_cg where tb_cg_cgdh ='" & tb_dhgz_cgdh.Text & "' and tb_cg_dm='" & tb_dhgz_dm.Text & "' and tb_cg_jhdh='" & tb_dhgz_jhdh.Text & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        nform.tb_cg_jhdh.Text = dt.Rows(0)("tb_cg_jhdh") '计划单号
        nform.tb_cg_cgdh.Text = dt.Rows(0)("tb_cg_cgdh")
        nform.tb_cg_qgsl.Text = dt.Rows(0)("tb_cg_qgsl")
        nform.tb_cg_ysje.Text = dt.Rows(0)("tb_cg_ysje")
        nform.tb_cg_yqyt.Text = dt.Rows(0)("tb_cg_yqyt")
        nform.tb_cg_qgdsxrq.Text = dt.Rows(0)("tb_cg_qgdsxrq")
        nform.tb_cg_yqdhrq.Text = dt.Rows(0)("tb_cg_yqdhrq")
        nform.tb_cg_gysmc.Text = Null2String(dt.Rows(0)("tb_cg_gysmc"))
        nform.tb_cg_wpbz.Text = Null2String(dt.Rows(0)("tb_cg_wpbz"))
        nform.tb_cg_qgbz.Text = Null2String(dt.Rows(0)("tb_cg_qgbz"))
        nform.tb_cg_yszq1.Text = dt.Rows(0)("tb_cg_yszq1")
        nform.tb_cg_qgrq.Text = dt.Rows(0)("tb_cg_qgrq")
        nform.tb_cg_qgzt.Text = dt.Rows(0)("tb_cg_qgzt")
        nform.tb_cg_qgdsfsx.Text = dt.Rows(0)("tb_cg_qgdsfsx")
        nform.tb_cg_dj.Text = dt.Rows(0)("tb_cg_dj")
        nform.tb_cg_gysmc.Text = dt.Rows(0)("tb_cg_gysmc")
        nform.tb_cg_dgzl.Text = tb_dhgz_yjdhl.Text
        nform.tb_cg_qyfy.Text = dt.Rows(0)("tb_cg_qyfy")
        nform.tb_cg_zj.Text = dt.Rows(0)("tb_cg_zj")
        nform.tb_cg_fzr.Text = dt.Rows(0)("tb_cg_fzr")
        nform.tb_cg_yjdhl1.Text = dt.Rows(0)("tb_cg_yjdhl1")
        nform.tb_cg_yjdhrq1.Value = dt.Rows(0)("tb_cg_yjdhrq1")
        nform.tb_cg_wpfl.Text = Null2String(dt.Rows(0)("tb_cg_wpfl"))
        nform.tb_cg_cgbz.Text = Null2String(dt.Rows(0)("tb_cg_cgbz"))
        nform.tb_cg_scs.Text = Null2String(dt.Rows(0)("tb_cg_scs"))
        nform.tb_cg_rq.Value = Now.Date
        nform.tb_cg_rq.Enabled = False
        nform.tb_cg_dgzl.ReadOnly = True
        nform.tb_cg_zj.ReadOnly = True
        nform.tb_cg_fzr.Enabled = False
        nform.tb_cg_yszq1.ReadOnly = True
        nform.tb_cg_yjdhrq1.Visible = True
        nform.tb_cg_yjdhl1.Visible = True
        nform.tb_cg_yjdhrq2.Visible = False
        nform.tb_cg_yjdhl2.Visible = False
        nform.tb_cg_yjdhrq3.Visible = False
        nform.tb_cg_yjdhl3.Visible = False
        nform.tb_cg_yszq1.Visible = True
        nform.tb_cg_yszq2.Visible = False
        nform.tb_cg_yszq3.Visible = False
        nform.Label13.Visible = True
        nform.Label14.Visible = False
        nform.Label16.Visible = True
        nform.Label17.Visible = False
        nform.Label15.Visible = False
        nform.Label18.Visible = False
        nform.Label33.Visible = False
        nform.Label32.Visible = True
        nform.Label34.Visible = False
        nform.Button2.Enabled = False
        nform.tb_cg_cgdh.ReadOnly = True
        nform.tb_cg_fqcs.Enabled = False
        nform.tb_cg_sfbh.Text = "补货"

        nform.id = ""
        'nform.ShowDialog()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' '
        nform.tb_cg_fqcs.SelectedIndex = 0
        nform.tb_cg_qyfy.Text = 0
        nform.tb_cg_fzr.SelectedIndex = 0
        nform.tb_cg_yszq1.Text = 3
        nform.tb_cg_yszq2.Text = 3
        nform.tb_cg_yszq3.Text = 3
   
        Dim h As String = ""
        Dim dth As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cg_ID from tb_cg where tb_cg_cgdh ='" & nform.tb_cg_cgdh.Text & "' and tb_cg_dm='" & nform.tb_cg_dm.Text & "'")
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
        Dim sqlq As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz)"
        sqlq &= "values('" & nform.tb_cg_qgbm.Text & "','" & nform.tb_cg_qgr.Text & "','" & nform.tb_cg_cgdh.Text & "','" & nform.tb_cg_cgdh.Text & h & "','" & nform.tb_cg_gsmc.Text & "','" & nform.tb_cg_dm.Text & "','" & nform.tb_cg_pm.Text & "','" & nform.tb_cg_ggxh.Text & "','" & nform.tb_cg_dw.Text & "','" & nform.tb_cg_wllb.Text & "','" & GF_gettrqsj(nform.tb_cg_yjdhrq1.Value) & "'," & nform.tb_cg_yjdhl1.Text & "," & nform.tb_cg_qgsl.Text & ",'" & nform.tb_cg_yqyt.Text & "'," & nform.tb_cg_ysje.Text & ",'" & GF_gettrqsj(nform.tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(nform.tb_cg_yqdhrq.Text) & "','" & nform.tb_cg_fzr.Text & "','" & GF_gettrqsj(nform.tb_cg_rq.Value) & "','" & nform.tb_cg_gysmc.Text & "'," & nform.tb_cg_dgzl.Text & "," & nform.tb_cg_dj.Text & "," & nform.tb_cg_qyfy.Text & "," & nform.tb_cg_zj.Text & ",'" & nform.tb_cg_fqcs.Text & "','" & nform.tb_cg_ysbm.Text & "','" & nform.tb_cg_sfbh.Text & "','" & nform.tb_cg_yszq1.Text & "','" & nform.tb_cg_qgbz.Text & "','" & nform.tb_cg_wpbz.Text & "','" & nform.tb_cg_qgrq.Text & "','" & nform.tb_cg_qgzt.Text & "','" & nform.tb_cg_qgdsfsx.Text & "','" & nform.tb_cg_wpfl.Text & "','" & nform.tb_cg_sbid.Text & "','" & nform.tb_cg_jhdh.Text & "','" & nform.tb_cg_cgbz.Text & "')"
        Dim idstring As String = GF_upztxx2(G_cnnstr, sqlq, "tb_cg")

        'GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & idstring & "' where tb_qgcg_ID= '" & nform.tb_cg_sbid.Text & "'")

        'Me.Close()
        Me.Close()
        'Catch ex As Exception

        'End Try

    End Sub

    '验收实效 = 验收日期 - （ 到货日期+ 验收周期 ）
    Private Sub tb_dhgz_ysrq_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dhgz_ysrq.ValueChanged
        Try
            Dim YS As DateTime = GF_gettrqsj(tb_dhgz_ysrq.Text) '验收日期
            Dim dh As DateTime = GF_gettrqsj(tb_dhgz_dhrq.Text) '到货日期

            Dim yszq As Integer = tb_dhgz_yszq.Text '验收周期
            Dim i As DateTime = DateAdd(DateInterval.Day, yszq, dh)
            Dim sx As Integer = DateDiff(DateInterval.Day, i, YS)
            tb_dhgz_yssx.Text = sx
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tb_dhgz_pccl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dhgz_pccl.DoubleClick
        Dim nform As New Frjhxg
        Me.AddOwnedForm(nform)
        nform.ShowDialog()
    End Sub

    Private Sub xg()
        If tb_dhgz_dhsl.Text <> tb_dhgz_yshgl.Text And tb_dhgz_sfbh.Text <> "补货" Then
            If MsgBox("您确定不补货吗？", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If tb_dhgz_bhgl.Text = "0" And tb_dhgz_yshgl.Text = "0" Then
            MsgBox("合格量和不合格量不能同时为0！")
            Exit Sub
        End If
     
        If id <> "" Then
            If GF_modsj("tb_dhgz", Me, id) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_upztxx(G_cnnstr, "update tb_dhgz set tb_dhgz_sfys='是' where tb_dhgz_ID= '" & id & "'") '修改上步表的id

        End If

        Dim f As Frjh = Me.Owner
        Dim dtgrid1 As DataGridView = f.show1
        Dim dt1 As DataTable = dtgrid1.DataSource
        Dim dr() As DataRow = dt1.Select("tb_dhgz_id= '" & id & "'")
        Dim n1 As DataTable = dt1.Clone
        For kk As Integer = 0 To dr.Length - 1
            n1.ImportRow(dr(kk))
        Next
        If n1.Rows.Count = 0 Then
            Dim dtgrid As DataGridView = f.show2
            Dim dt As DataTable = dtgrid.DataSource
            Frjh.ChangeData(Me, dt, id) '修改
        Else
            Dim dtgrid2 As DataGridView = f.show2
            Dim dt2 As DataTable = dtgrid2.DataSource
            Frjh.ChangeAddData(Me, dt2, id)
            Frjh.DelRow(dt1, id)
        End If
        'Dim nform As Frjh = Me.Owner
        'nform.xssj()
        Me.Close()

    End Sub

    Private Sub TextChanged1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dhgz_bhgl.TextChanged
        Dim a As String = Null2zero2(tb_dhgz_yshgl.Text)
        tb_dhgz_yshgl.Text = tb_dhgz_dhsl.Text - Null2zero2(tb_dhgz_bhgl.Text)
        If tb_dhgz_yshgl.Text < 0 Then
            MsgBox("数值小于0")
            tb_dhgz_yshgl.Text = a
        End If
        'tb_dhgz_bhgl.Text = tb_dhgz_dhsl.Text - tb_dhgz_yshgl.Text
    End Sub
    Private Sub TextChanged2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dhgz_yshgl.TextChanged
        Dim b As String = tb_dhgz_bhgl.Text
        tb_dhgz_bhgl.Text = tb_dhgz_dhsl.Text - tb_dhgz_yshgl.Text
        If tb_dhgz_bhgl.Text < 0 Then
            MsgBox("数值小于0")
            tb_dhgz_bhgl.Text = b
        End If
    End Sub
End Class