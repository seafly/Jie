Public Class Frtb_WarningAdd
    Public id As Integer = 0
    Public dm As String = ""
    Private Sub Frtb_WarningAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If id <> 0 Then
            Gs_showsj("tb_warning", Me, id.ToString())
            tb_warning_dm.Text = dm
            tb_warning_chzq.ReadOnly = True
            tb_warning_njzq.ReadOnly = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dim jj As String=""
        If id = 0 Then
            jj = GF_addsj("tb_warning", Me, G_cnnstr)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_storelog3("对物料代码:" & tb_warning_dm.Text & "添加预警时间", "预警时间") '储存到日志
        Else
            If GF_modsj("tb_warning", Me, id.ToString(), G_cnnstr) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            jj = id
            GS_storelog3("对物料代码:" & tb_warning_dm.Text & "修改预警时间", "预警时间") '储存到日志
        End If
        Dim sql As String = "update tb_i259b set tb_i259b_endrq=DATEADD(dd," & tb_warning_keepdays.Text & ",tb_i259b_scrq) where tb_i259b_i231a='" & tb_warning_dm.Text & "'"
        sql.YanDbExe()
        MessageBox.Show("更新成功！")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub tb_warning_wpfl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_warning_wpfl.SelectedIndexChanged
        Dim ArrayCode() As String = {"APG10", "APG15", "AOGC", "APGT", "APGE", "AOG40", "APGK", "AOGF", "干菌体"}
        Select Case tb_warning_wpfl.Text
            Case "包材", "原料", "油剂"
                tb_warning_dm.Items.Clear()
                tb_warning_dm.Text = ""
                Label7.Visible = True : tb_warning_chzq.Visible = True '采购周期
                Label8.Visible = True : tb_warning_njzq.Visible = True  '内检周期
                Label11.Visible = True : tb_warning_keepdays.Visible = True '产品保质期
            Case "成品油", "成品粉", "毛油", "干菌体"
                tb_warning_dm.Items.Clear()
                GS_wlbktlr4(tb_warning_dm, ArrayCode)
                tb_warning_dm.SelectedIndex = 0
                Label7.Visible = False : tb_warning_chzq.Visible = False '采购周期
                Label8.Visible = False : tb_warning_njzq.Visible = False '内检周期
                Label11.Visible = False : tb_warning_keepdays.Visible = False '产品保质期
        End Select
    End Sub
    Private Sub tb_warning_dm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_warning_dm.LostFocus
        Dim sql As String = "' "
        Select Case tb_warning_wpfl.Text
            Case "包材", "原料", "油剂"
                sql = " select  tb_wp_pm, tb_wp_ggxh, tb_wp_dw, tb_wp_wllb,tb_wp_njzq,tb_wp_cgzq from  tb_wp where tb_wp_dm ='" & tb_warning_dm.Text & "' "
                Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                If dt.Rows.Count > 0 Then
                    tb_warning_name.Text = dt.Rows(0)("tb_wp_pm").ToString()
                    tb_warning_chzq.Text = dt.Rows(0)("tb_wp_cgzq").ToString()
                    tb_warning_njzq.Text = dt.Rows(0)("tb_wp_njzq").ToString()
                    tb_warning_lb.Text = dt.Rows(0)("tb_wp_wllb").ToString()
                    tb_warning_gg.Text = dt.Rows(0)("tb_wp_ggxh").ToString()
                    tb_warning_dw.Text = dt.Rows(0)("tb_wp_dw").ToString()
                End If
        End Select
    End Sub

End Class