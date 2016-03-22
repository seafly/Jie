Imports DeepCode.DeepDoDataTable
Public Class Frtb_t676l

    Private Sub Frtb_t676l_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)

        End If
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If tb_t676l_qcrq.Text = "" Then
            MsgBox("开始检测时间没有输入") : Exit Sub
        End If
        Dim ph As String = tb_t676l_num.Text
        If Labelid.Text <> "" Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("修改原料QC：" & ph, "修改QC") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
        Else
            ''''''''''''''''''''日志权限判断

            If GF_storelog2("添加原料QC：" & ph, "添加QC") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        End If
        Dim sql As String = "update tb_i259b set tb_i259b_qcsh='" & tb_t676l_qcsh.Text & "',tb_i259b_qcrq='" & tb_t676l_qcrq.Text & "' where tb_i259b_num='" & tb_t676l_num.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        MessageBox.Show("添加成功!")

        Me.Close()
    End Sub


    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        If biaoid = "" Then
            Exit Sub
        End If

        Dim r As Integer = MsgBox("确定删除吗？", 1, "警告")
        If r <> 1 Then
            Exit Sub
        End If
        Dim ph As String = tb_t676l_num.Text
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("删除原料QC：" & ph, "删除QC") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update tb_i259b set tb_i259b_qcsh='否' where tb_i259b_num='" & ph & "'"
        sql = sql & vbCrLf & "delete from tb_t676l where tb_t676l_id=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        Me.Close()
    End Sub
End Class