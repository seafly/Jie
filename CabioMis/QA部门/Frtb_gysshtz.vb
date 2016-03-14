Public Class Frtb_gysshtz

    Private Sub qd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qd.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''备注可以不填写联系人和联系方法为非必填
        If GF_YZSJ(Me, "tb_gysshtz_bz,tb_gysshtz_qalxr,tb_gysshtz_lxfs") = False Then '验证控件
            Exit Sub
        End If
        '''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改供应商现场审核台账") = False Then
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
            GS_storelog3("修改供应商现场审核台账", "修改供应商现场审核台账，原料：" & tb_gysshtz_ylmc.Text.Trim & ",供应商：" & tb_gysshtz_gys.Text.Trim) '储存到日志
        Else
            ''''''''''''''''''''''''''''
            If GF_storelog1("添加供应商现场审核台账") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加供应商现场审核台账", "添加供应商现场审核台账，原料：" & tb_gysshtz_ylmc.Text.Trim & ",供应商：" & tb_gysshtz_gys.Text.Trim) '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Frtb_gysshtz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim sz1 As String() = {"当前供应商", "新开发供应商"}
        GS_wlbktlr3(tb_gysshtz_nb, sz1, "")
        Dim sz2 As String() = {"不合格", "合格"}
        GS_wlbktlr3(tb_gysshtz_shjg, sz2, "")
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
        End If

        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub qx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qx.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog1("删除供应商现场审核台账") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''''''''''
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("删除供应商现场审核台账", "删除供应商现场审核台账，原料名称" & tb_gysshtz_ylmc.Text) '储存到日志
            Me.Close()
        End If
    End Sub
End Class