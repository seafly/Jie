Public Class Frtb_QAcc

    Private Sub frQAcc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '显示上月的月份
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        If tb_QAcc_zs.Text = "" Then
            MsgBox("请填写数据！") : Exit Sub
        End If
        '
        Dim sj As Date
        If nian1.Text = "" Or yue1.Text = "" Then
            Exit Sub
        End If
        sj = nian1.Text & "-" & yue1.Text & "-25" '时间
        '
        If tb_ID.Text <> "" Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("修改Customer complaints", "修改Customer complaints") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            sql = "update tb_QAcc set tb_QAcc_zs=" & tb_QAcc_zs.Text & ",tb_QAcc_df=" & tb_QAcc_df.Text & " where tb_QAcc_rq='" & sj & "'"
        Else
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("添加Customer complaints", "添加Customer complaints") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            sql = "Insert into tb_QAcc(tb_QAcc_zs,tb_QAcc_df,tb_QAcc_rq) values(" & tb_QAcc_zs.Text & "," & tb_QAcc_df.Text & ",'" & sj & "')"
        End If
        Call GS_upztxx(G_cnnstr, sql)
        MsgBox("操作成功！")
        Me.Close()
    End Sub
    Private Sub nian1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian1.SelectedValueChanged, yue1.SelectedValueChanged
        Dim sj As Date
        If nian1.Text = "" Or yue1.Text = "" Then
            Exit Sub
        End If
        sj = nian1.Text & "-" & yue1.Text & "-25" '时间
        Dim sql As String = "select * from tb_QAcc where tb_QAcc_rq='" & sj & "'"
        Dim nhb As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If nhb.Rows.Count > 0 Then
            tb_ID.Text = nhb.Rows(0)(0)
            tb_QAcc_zs.Text = nhb.Rows(0)(2)
        Else
            tb_ID.Text = ""
            tb_QAcc_zs.Text = "0"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class