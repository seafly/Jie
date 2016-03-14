Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frtjxg
   
    Public id As Integer = 0
    Private Sub Frtjxg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_wlbktlr3(tb_wp_wllb, New String() {"A", "B", "C", "X", "Y", "Z"}, "A")
        GS_wlbktlr3(tb_wp_wpfl, GetType(en_wpfl).YanEnToTb().YanDtToStr("name").Split(","), en_wpfl.原料.ToString)
        tb_wp_gsmc.SelectedIndex = 0
        tb_wp_wpfl.SelectedIndex = 0
        tb_wp_sfyx.SelectedIndex = 0
        tb_wp_isQc.Text = "否"
        tb_wp_isQa.Text = "否"

        AddHandler tb_wp_wpfl.SelectedIndexChanged, Sub()
                                                        tb_wp_isQc.Text = "否"
                                                        tb_wp_isQa.Text = "否"
                                                        If tb_wp_wpfl.Text = en_wpfl.过程品.ToString Then
                                                            tb_wp_isQc.Text = "是"
                                                        End If
                                                        If tb_wp_wpfl.Text = en_wpfl.成品.ToString Then
                                                            tb_wp_isQc.Text = "是"
                                                            tb_wp_isQa.Text = "是"
                                                        End If
                                                    End Sub

        Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_wp_sybm.Items.Add(dt.Rows(i)(0))
        Next
        If id > 0 Then
            Gs_showsj("tb_wp", Me, id)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
     
        If GF_YZSJ(Me, "tb_wp_ggxh,tb_wp_sybm,tb_wp_bz,tb_wp_njzq") = False Then '验证控件
            Exit Sub
        End If
        If id = 0 Then
            Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_wp where tb_wp_dm = '" & tb_wp_dm.Text & "' ")
            If dt2.Rows.Count > 0 Then
                MsgBox("物品代码重复") : Exit Sub
            End If
        End If
        If id > 0 Then
            Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_wp where tb_wp_ID<>" & id & " and  tb_wp_dm = '" & tb_wp_dm.Text & "' ")
            If dt2.Rows.Count > 0 Then
                MsgBox("物品代码重复") : Exit Sub
            End If
            If GF_storelog1("修改基础表") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_modsj("tb_wp", Me, id) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If

            GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_gsmc='" & tb_wp_gsmc.Text & "',tb_qgcg_ggxh='" & tb_wp_ggxh.Text & "',tb_qgcg_dw='" & tb_wp_dw.Text & "',tb_qgcg_wllb='" & tb_wp_wllb.Text & "' ,tb_qgcg_wpbz='" & tb_wp_bz.Text & "',tb_qgcg_wpfl='" & tb_wp_wpfl.Text & "' where tb_qgcg_dm='" & tb_wp_dm.Text & "' ")
            GS_upztxx(G_cnnstr, "update tb_cg set tb_cg_gsmc='" & tb_wp_gsmc.Text & "',tb_cg_ggxh='" & tb_wp_ggxh.Text & "',tb_cg_dw='" & tb_wp_dw.Text & "',tb_cg_wllb='" & tb_wp_wllb.Text & "' , tb_cg_wpbz='" & tb_wp_bz.Text & "',tb_cg_wpfl='" & tb_wp_wpfl.Text & "' where tb_cg_dm='" & tb_wp_dm.Text & "' ")
            GS_upztxx(G_cnnstr, "update tb_dhgz set tb_dhgz_gsmc='" & tb_wp_gsmc.Text & "',tb_dhgz_ggxh='" & tb_wp_ggxh.Text & "',tb_dhgz_dw='" & tb_wp_dw.Text & "',tb_dhgz_wllb='" & tb_wp_wllb.Text & "',tb_dhgz_wpbz='" & tb_wp_bz.Text & "',tb_dhgz_wpfl='" & tb_wp_wpfl.Text & "' where tb_dhgz_dm='" & tb_wp_dm.Text & "'")
            GS_upztxx(G_cnnstr, "update tb_warning set tb_warning_gg='" & tb_wp_ggxh.Text & "',tb_warning_dw='" & tb_wp_dw.Text & "',tb_warning_lb='" & tb_wp_wllb.Text & "',tb_warning_bz='" & tb_wp_bz.Text & "',tb_warning_wpfl='" & tb_wp_wpfl.Text & "',tb_warning_name='" & tb_wp_pm.Text & "',tb_warning_chzq='" & tb_wp_cgzq.Text & "',tb_warning_njzq='" & tb_wp_njzq.Text & "' where tb_warning_dm='" & tb_wp_dm.Text & "'")

            GS_storelog3("修改基础表： " & tb_wp_dm.Text & " ", "修改基础表") '储存到日志
        Else
            If GF_storelog1("添加基础表") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj("tb_wp", Me)
            If jj = "" Then
                MsgBox("添加数据出错") : Exit Sub
            End If
            GS_storelog3("添加基础表 " & tb_wp_dm.Text & "", "添加基础表") '储存到日志
        End If
        Try
            If Me.Owner.GetType.Name = "Frjh" Then
                Dim nform As Frjh = Me.Owner
                nform.xssj()
            End If
        Catch
        End Try
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub tb_wp_wpfl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tb_wp_wpfl.SelectedIndexChanged
        If sender.text = "原料" Or sender.text = "包材" Then
            tb_wp_ggxh.Text = ""
            tb_wp_ggxh.Enabled = False
        Else
            tb_wp_ggxh.Enabled = True
        End If
    End Sub
End Class