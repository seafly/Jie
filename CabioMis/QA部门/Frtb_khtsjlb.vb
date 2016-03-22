Public Class Frtb_khtsjlb
    Private Sub Frtb_khtsjl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim sz1 As String() = {"质量控制类", "食品安全类", "包装标识类", "仓储运输类"}
        GS_wlbktlr3(tb_khtsjlb_tslb, sz1, "")
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim czid As String = Labelid.Text
        '’‘’‘’‘’‘’‘’‘’‘
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
        ''''''''''''''''''''''''''''''''''''''''''备注可以不填写“接收人”和“整改措施”也为非必填
        If GF_YZSJ(Me, "tb_khtsjlb_bz,tb_khtsjlb_zgcs,tb_khtsjlb_jsr") = False Then '验证控件
            Exit Sub
        End If
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''
            If GF_storelog1("修改客户投诉记录") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改客户投诉记录", "修改客户投诉记录:客户" & tb_khtsjlb_kh.Text.Trim) '储存到日志
        Else
            ''''''''''''''''''''''''''''
            If GF_storelog1("添加客户投诉记录") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加客户投诉记录", "添加客户投诉记录:客户" & tb_khtsjlb_kh.Text.Trim) '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            '''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''
            If GF_storelog1("删除客户投诉记录") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("删除客户投诉记录", "删除客户投诉记录，客户" & tb_khtsjlb_kh.Text.Trim) '储存到日志
            Me.Close()
        End If
    End Sub

End Class