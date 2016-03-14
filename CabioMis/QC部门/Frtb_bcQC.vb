Imports DeepCode.DeepDoDataTable
Public Class Frtb_bcQC

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", MsgBoxStyle.OkCancel, "提示") <> 1 Then
            Exit Sub
        End If


        Dim ph As String = tb_bcQC_num.Text
        If Labelid.Text <> "" Then

            '''''''''''''''''''''''''''''
            If GF_storelog1("修改QC") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改包材QC：" & ph, "修改QC") '储存到日志
        Else
            '''''''''''''''''''''''''''''

            If GF_storelog1("添加QC") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加包材QC：" & ph, "添加QC") '储存到日志
        End If
        Dim sql As String = "update tb_i259b set tb_i259b_qcsh='" & tb_bcQC_qcsh.Text & "' ,tb_i259b_qcrq='" & tb_bcQC_qcrq.Text & "' where tb_i259b_num='" & tb_bcQC_num.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        MessageBox.Show("添加成功！")
        Me.Close()

    End Sub

    Private Sub Frtb_bcQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        If biaoid = "" Then
            Exit Sub
        End If

        Dim r As Integer = MsgBox("确定删除吗？", MsgBoxStyle.OkCancel, "警告")
        If r <> 1 Then
            Exit Sub
        End If
        Dim ph As String = tb_bcQC_num.Text
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("删除包材QC：" & ph, "删除QC") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update tb_i259b set tb_i259b_qcsh='否' where tb_i259b_num='" & ph & "'"
        sql = sql & vbCrLf & "delete from tb_bcQC where tb_bcQC_id=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        Me.Close()
    End Sub


End Class