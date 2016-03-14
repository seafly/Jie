Public Class Frtb_spaqnwsh
    Private Sub Frtb_spaqnwsh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_spaqnwsh_nsshlb.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
        End If
        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If tb_spaqnwsh_nsljfxx.Text.Trim = "" Or tb_spaqnwsh_nsljjhwcx.Text.Trim = "" Or tb_spaqnwsh_nsljsjwcx.Text.Trim = "" Then
            MsgBox("请填写累计发现项、累计计划完成项、累计实际完成项") : Exit Sub
        End If
        Dim jhwcn As Double
        Try
            jhwcn = tb_spaqnwsh_nsljsjwcx.Text.Trim / tb_spaqnwsh_nsljjhwcx.Text.Trim
        Catch ex As Exception
            MsgBox("请检查累计计划完成项、累计实际完成项数据") : Exit Sub
        End Try
        tb_spaqnwsh_nsjhxwcl.Text = jhwcn
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改食品安全质量（FSQ）审核改进情况统计表") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改食品安全质量（FSQ）审核改进情况统计表", "修改食品安全质量（FSQ）审核改进情况统计表") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加食品安全质量（FSQ）审核改进情况统计表") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加食品安全质量（FSQ）审核改进情况统计表", "添加食品安全质量（FSQ）审核改进情况统计表") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除食品安全质量（FSQ）审核改进情况统计表", "删除食品安全质量（FSQ）审核改进情况统计表") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
End Class