Public Class Frtb_jcdftj

    Private Sub Frtb_jcdftj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_bm")
        GS_wlbktlr2(tb_jcdftj_bm, dt, 1, "")
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
        End If
        GS_qhjd(Me) '回车键切换焦点，备注除外
        dt = GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd")
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_jcdftj_gd.Items.Add(dt.Rows(i)(1))
        Next
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        If GF_YZSJ(Me, "tb_jcdftj_bz") = False Then '验证控件
            Exit Sub
        End If
        '''''''''''''''
        Dim hj As Double
        Try
            hj = (Double.Parse(tb_jcdftj_zl.Text.Trim) + Double.Parse(tb_jcdftj_zd.Text.Trim) + Double.Parse(tb_jcdftj_qs.Text.Trim) + Double.Parse(tb_jcdftj_sy.Text.Trim)) / 4
        Catch ex As Exception
            MsgBox("请将数据填写完整！") : Exit Sub
        End Try
        tb_jcdftj_hj.Text = hj
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改5S检查得分统计") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改5S检查得分统计", "修改5S检查得分统计") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加5S检查得分统计") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加5S检查得分统计", "添加5S检查得分统计") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除5S检查得分统计", "删除5S检查得分统计") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
End Class