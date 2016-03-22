Public Class Frtb_2009nwbshqktj

    Private Sub Frtb_2009nwbshqktj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim czid As String = Labelid.Text
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        GS_wlbktlr(tb_2009nwbshqktj_sftg, Date.Today.Month, 1, 12)
        Dim l() As String = {"Customer audit", "Government audit", "Other audit(The Food Safety&QA systems)"}
        GS_wlbktlr3(tb_2009nwbshqktj_shlb, l, "")
        Dim LB As String() = {"HuBei", "WuHan"}
        GS_wlbktlr3(tb_2009nwbshqktj_shdx, LB, "")
        Dim LB2 As String() = {"Y", "N"}
        GS_wlbktlr3(tb_2009nwbshqktj_sftg, LB2, "")
        '''''''''''''''''''''''''''''''''''''''''''''
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            SSSDEL.Visible = True
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", MsgBoxStyle.OkCancel, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''完成率=完成项/确定项
        Dim WCN As Double = 0
        Try
            WCN = FormatNumber(tb_2009nwbshqktj_wcx.Text * 100 / tb_2009nwbshqktj_qdx.Text, 2)
            tb_2009nwbshqktj_wcn.Text = WCN
        Catch ex As Exception

        End Try
        '''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改外部审核情况") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            ''''''''''''''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改外部审核情况", "修改外部审核情况，审核方：" & tb_2009nwbshqktj_shf.Text.Trim) '储存到日志
        Else
            ''''''''''''''''''''''''''''
            If GF_storelog1("添加外部审核情况") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加外部审核情况", "添加FSQ，审核方：" & tb_2009nwbshqktj_shf.Text.Trim) '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub SSSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSDEL.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog1("删除外部审核情况") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("删除外部审核情况", "删除FSQ，审核方：" & tb_2009nwbshqktj_shf.Text.Trim) '储存到日志
            Me.Close()
        End If
    End Sub
End Class