Public Class Frtb_yxjh

    Private Sub Frtb_yxjh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d")
        Call GS_wlbktlr2(tb_yxjh_y846q, kk, 1, "")
        Dim czid As String = Labelid.Text

        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
            tb_yxjh_tjq.ReadOnly = True '统计期不能修改
        End If
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
   
        If Labelid.Text <> "" Then
            '''''''''判断必填''''''''''''备注、止批号可不填写

            If GF_YZSJ(Me, "tb_yxjh_bz,tb_yxjh_o476g") = False Then '验证控件
                Exit Sub
            End If
            ''''''''''''''''''''日志
            If GF_storelog1("修改运行计划") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_storelog2("修改运行计划", "修改运行计划") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改运行计划，工序" & tb_yxjh_y846q.Text & "，统计期：" & tb_yxjh_tjq.Text, "修改运行计划") '储存到日志
        Else
            '''''''''判断必填''''''''''''添加时备注、实际止批号可不填写

            If GF_YZSJ(Me, "tb_yxjh_bz,tb_yxjh_sjzph") = False Then '验证控件
                Exit Sub
            End If
            ''''''''''''''''''''日志
            If GF_storelog1("添加运行计划") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加运行计划，工序" & tb_yxjh_y846q.Text & "，统计期：" & tb_yxjh_tjq.Text, "添加运行计划") '储存到日志
        End If
        Me.Close()
    End Sub



    Private Function tjqcf(ByVal str1 As String, ByVal str2 As Integer) As Boolean '判断某工序的统计期是否已经输入过
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_yxjh_id from tb_yxjh where tb_yxjh_y846q='" & str1 & "' and tb_yxjh_tjq=" & str2 & "")
        If dt.Rows.Count > 0 Then
            tjqcf = True
        Else
            tjqcf = False
        End If
    End Function


    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除运行计划，工序" & tb_yxjh_y846q.Text & "，统计期：" & tb_yxjh_tjq.Text, "删除运行计划") = False Then
                Exit Sub
            End If
            ''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            Me.Close()
        End If
    End Sub

    Private Sub tb_yxjh_y846q_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_yxjh_y846q.SelectedIndexChanged
        If Labelid.Text = "" Then
            Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d")
            Dim ss As String = GF_cnwithen(kk, "tb_l358d_zd='" & tb_yxjh_y846q.Text & "'", 2)
            tb_yxjh_t685m.Text = ss
            tb_yxjh_o476g.Text = ss
            '’‘’‘’‘’‘’‘’‘’‘’‘’上面得到批号规律
            kk = GF_CreateDataSource(G_cnnstr, "select top 1 * from tb_yxjh where  tb_yxjh_y846q='" & tb_yxjh_y846q.Text & "' order by    tb_yxjh_tjq desc ")
            If kk.Rows.Count = 0 Then
                tb_yxjh_tjq.Text = "20090001"
                Label11.Text = "上期无止批号"
            Else
                tb_yxjh_tjq.Text = Int(kk.Rows(0)("tb_yxjh_tjq")) + 1 '自动给统计期加1
                Label11.Text = "上期止批号为：" & kk.Rows(0)("tb_yxjh_sjzph") '自动将上次的截止批号显示出来

            End If
        End If

    End Sub
End Class