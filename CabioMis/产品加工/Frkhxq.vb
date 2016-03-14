Public Class Frkhxq
    Public id As String = ""

    Private Sub Frkhxq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        If id <> "" Then
            Gs_showsj("tb_khyqqkyrb", Me, id)

        End If

        If tb_khyqqkyrb_yxx.Text = "无效" Or tb_khyqqkyrb_yxx.Text = "冻结" Then
            Button1.Enabled = False
        End If


        Dim sj As String = GF_getstringsql(G_cnnstr, "select  DATEPART(year, GETDATE()) , DATEPART(month, GETDATE()) , DATEPART(day, GETDATE()) ", "-")
        sj = GF_gettrqsj(sj) '得到操作时间
        tb_khyqqkyrb_gxrq.Text = sj
        tb_khyqqkyrb_czr.Text = G_dlr & "|" & G_dlrgh
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If id <> "" Then

            If GF_modsj("tb_khyqqkyrb", Me, id, G_cnnstr) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_storelog3("修改客户名称：" & tb_khyqqkyrb_khmc.Text.Trim, "产品加工") '储存到日志
        Else

            Dim jj As String = GF_addsj("tb_khyqqkyrb", Me, G_cnnstr)
            If jj = "" Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_storelog3("添加客户名称：" & tb_khyqqkyrb_khmc.Text.Trim, "产品加工") '储存到日志

        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class