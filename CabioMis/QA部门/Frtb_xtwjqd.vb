Public Class Frtb_xtwjqd

    Private Sub frxxxx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button3.Visible = True
        End If

        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''备注可以不填写
        If tb_xtwjqd_wjmc.Text.Trim = "" Or tb_xtwjqd_bm.Text.Trim = "" Or tb_xtwjqd_zxbc.Text.Trim = "" Then '验证控件
            MsgBox("名称、编码、最新版次必须填写")
            Exit Sub
        End If
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改文件清单") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改文件清单", "修改文件清单：" & tb_xtwjqd_wjmc.Text.Trim) '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加文件清单") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加文件清单", "添加文件清单：" & tb_xtwjqd_wjmc.Text.Trim) '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''
            If GF_storelog1("删除文件清单") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("删除文件清单", "删除文件清单，文件名称" & tb_xtwjqd_wjmc.Text) '储存到日志
            Me.Close()
        End If
    End Sub
End Class