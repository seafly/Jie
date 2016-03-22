Public Class Frwgcpy

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click


        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填'''''''''
        If GF_YZSJ(Me, "tb_h195z_bz") = False Then '验证控件
            Exit Sub
        End If

        tb_h195z_qarq.Text = tb_h195z_jgrq.Text
        tb_h195z_qcrq.Text = tb_h195z_jgrq.Text

        If Labelid.Text <> "" Then
            ''''''''''''''''''''
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改外购成品油") = False Then
                Exit Sub
            End If ' 判断是否有权限
       
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
          
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改外购成品油：" & tb_h195z_num.Text.Trim, "修改外购成品油") '储存到日志
        Else
            '''''''''''''''''''''''''''''
         
            If GF_storelog1("添加外购成品油") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_cxph("tb_h195z_num", tb_h195z_num.Text.Trim) = True Then
                MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
            End If
         
            '''''''''''''''''''''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加外购成品油：" & tb_h195z_num.Text.Trim, "添加外购成品油") '储存到日志
        End If
        Me.Close()
    End Sub
    '默认外购批号等同于外购成品油批号
    Private Sub tb_h195z_num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_num.Leave
        tb_h195z_wgbh.Text = tb_h195z_num.Text
    End Sub

    Private Sub Frwgcpy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If Labelid.Text <> "" Then '显示默认数据
            Call Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        End If

        ''''''''''''2010.5.14 lili  将外购成品油的QA 和 QC屏蔽
        With tb_h195z_qaspjg
            .Items.Add("待定")
            .Items.Add("合格")
            .Items.Add("返工")
            .Items.Add("报废")
            .Items.Add("不合格")
            .Items.Add("冻结")
        End With
        tb_h195z_qaspjg.SelectedIndex = 0
        tb_h195z_qcczrgh.Text = G_dlrgh
        tb_h195z_qaczrgh.Text = G_dlrgh
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
End Class