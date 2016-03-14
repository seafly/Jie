Public Class Frtb_dgqc

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_qc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        ComboBox1.SelectedIndex = 0
        tb_q546i_a941s.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then '修改时候批号/罐号不能修改
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Buttdel.Visible = True
            ComboBox1.Visible = False
        End If
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If tb_q546i_qcrq.Text = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        If Labelid.Text <> "" Then
            ''''''''''''''''''''日志与权限判断
            If GF_storelog1("修改QC") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号

            GS_storelog3("修改发酵罐QC：" & tb_q546i_num.Text.Trim, "修改QC") '储存到日志
        Else
            ''''''''''''''''''''
            If GF_storelog1("添加QC") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            If ComboBox1.SelectedIndex = 1 Then
                Dim sql As String = "update tb_i234a set tb_i234a_qcsh='是' where tb_i234a_num='" & tb_q546i_num.Text & "'"
                GS_upztxx(G_cnnstr, sql)
            End If
            GS_storelog3("添加发酵罐QC：" & tb_q546i_num.Text.Trim, "添加QC") '储存到日志
        End If
     
        Me.Close()
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttdel.Click
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        If biaoid = "" Then
            Exit Sub
        End If
        Dim r As Integer = MsgBox("确定删除吗？", 1, "警告")
        If r <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''日志与权限判断
        If GF_storelog1("删除QC") = False Then
            Exit Sub
        End If ' 判断是否有权限
        '''''''''''''''''''''
        Dim sql As String = "delete from " & biao & " where " & biao & "_ID=" & Labelid.Text
        sql = sql & vbCrLf & "update tb_i234a set tb_i234a_qcsh='否' where tb_i234a_num='" & tb_q546i_num.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("删除发酵罐QC：" & tb_q546i_num.Text.Trim, "删除QC") '储存到日志
        Me.Close()
    End Sub

  

End Class