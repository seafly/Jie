Public Class Frfgadd
    Private Sub Frfgadd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj("tb_x825p", Me, Labelid.Text)
        Else
            '设定放罐批号就等于选中的大罐批号
   
            tb_x825p_num3.Text = tb_x825p_num2.Text
        End If


    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        'Try
        '    Dim tj As Double = tb_x825p_l349d.Text.Trim
        '    Dim zq As Double = tb_x825p_d42v.Text.Trim
        '    Dim ph As String = tb_x825p_num3.Text
        '    Dim sj As String = tb_x825p_jgrq2.Text
        '    Dim sql As String = "insert into (tb_x825p_num3,tb_x825p_jgrq2,tb_x825p_fgczrgh)values('" & ph & "','" & sj & "'," & zq & "," & tj & ",'" & G_dlrgh & "')"
        '    sql
        '    GS_upztxx(G_cnnstr, sql)
        '    Me.Close()
        'Catch ex As Exception
        '    MsgBox("数据填写不正确不正确")
        'End Try
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        If GF_YZSJ(Me, "") = False Then '验证控件
            Exit Sub
        End If
        If Labelid.Text <> "" Then
            If GF_storelog1("修改放罐") = False Then
                Exit Sub
            End If ' 判断是否有权限
            ''''''''''''''''''''
            If GF_modsj("tb_x825p", Me, Labelid.Text) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj("tb_x825p", "tb_x825p_fgczrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改放罐：" & tb_x825p_num3.Text.Trim, "修改放罐") '储存到日志
        Else
            If GF_storelog1("添加放罐") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj("tb_x825p", Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_gengsb("tb_i234a", Labelid2.Text, "tb_x825p", jj)
            GS_modczsj("tb_x825p", "tb_x825p_fgczrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加放罐：" & tb_x825p_num3.Text.Trim, "添加放罐") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class