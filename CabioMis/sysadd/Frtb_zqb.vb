Public Class Frtb_zqb

    Private Sub Frtb_zqb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        ''''''''''''''''''''''''''''']填充填表人和审核人
        Dim yg As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_yg order by tb_yg_w779o desc")
        Dim dt As DataTable = GF_czmctb(yg, "tb_yg_v753n='设备动力部' and tb_yg_yx='有效'")
        'GS_wlbktlr2(tb_zls_tby, dt, 3, "")
        tb_zqb_tbr.Items.Add("刘琨")
        tb_zqb_tbr.Items.Add("夏鸿")
        tb_zqb_tbr.Items.Add("罗胜军")
        tb_zqb_tbr.SelectedIndex = 0
        'GS_wlbktlr2(tb_zqb_shr, dt, 3, "")
        '''''''''''''''''''''''''''''''
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
            '以下填充换表勾选
            Dim zqsj() As String = Split(tb_zqb_hb.Text, ",")
            For i As Integer = 0 To hblv.Items.Count - 1
                For j As Integer = 0 To zqsj.Length - 1
                    If hblv.Items.Item(i).ToString = zqsj(j) Then
                        hblv.SetItemChecked(i, True)
                    End If
                Next
            Next
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

        ''''''''''''''''''''''''''''''''''''''''''
        'If GF_YZSJ(Me, "tb_zqb_shr") = False Then '验证控件
        '    Exit Sub
        'End If
        ''''''''''''''''''''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改蒸汽、柴油") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改蒸汽、柴油", "修改蒸汽、柴油") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加蒸汽、柴油") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加蒸汽、柴油", "添加蒸汽、柴油") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除蒸汽、柴油", "删除蒸汽、柴油") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub

    Private Sub hblv_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles hblv.MouseUp
        Dim zz As String = ""
        For i As Integer = 0 To hblv.CheckedItems.Count - 1
            zz = zz & hblv.CheckedItems.Item(i).ToString & ","
        Next
        tb_zqb_hb.Text = GF_removedh(zz)
    End Sub
End Class