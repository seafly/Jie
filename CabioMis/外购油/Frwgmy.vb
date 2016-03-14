Public Class Frwgmy

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填'''''''''
        If GF_YZSJ(Me, "tb_x825p_bz") = False Then '验证控件
            Exit Sub
        End If
        Dim sn As Double = 0
        '浸出收率（自动计算=浸出毛油重量*10000/(菌体重量*总油)
        Try
            sn = FormatNumber(tb_x825p_s640k.Text * 10000 / (tb_x825p_r583j.Text * tb_x825p_gjtzy.Text), 2)
        Catch ex As Exception
            sn = 0
        End Try
        tb_x825p_sn.Text = sn
        ''‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’20100326增加干菌体NET AA=干菌体重量*干菌体总油
        'Dim gjtaa As Double = 0
        'Try
        '    gjtaa = tb_x825p_r583j.Text * tb_x825p_gjtzy.Text
        'Catch ex As Exception
        '    gjtaa = 0
        'End Try
        'tb_x825p_d68w.Text = gjtaa
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        '自动将大罐批号赋值，等于外购毛油批号
        tb_x825p_num2.Text = tb_x825p_wgbh.Text
        If Labelid.Text <> "" Then
            ''''''''''''''''''''
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改外购毛油") = False Then
                Exit Sub
            End If ' 判断是否有权限

            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If

            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改外购毛油：" & tb_x825p_num.Text.Trim, "修改外购毛油") '储存到日志
        Else
            '''''''''''''''''''''''''''''

            If GF_storelog1("添加外购毛油") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_cxph("tb_x825p_num", tb_x825p_num.Text.Trim) = True Then
                MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
            End If

            '''''''''''''''''''''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            Dim sql As String = "update tb_x825p set tb_x825p_d42v=null,tb_x825p_l349d=null,tb_x825p_k317c=null where tb_x825p_id=" & jj
            Call GS_upztxx(G_cnnstr, sql) '外购毛油的发酵周期、放罐体积、放罐NETAA保存时置为空
            GS_storelog3("添加外购毛油：" & tb_x825p_num.Text.Trim, "添加外购毛油") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Frwgmy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If Labelid.Text <> "" Then '显示默认数据
            Call Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        End If
    End Sub
End Class