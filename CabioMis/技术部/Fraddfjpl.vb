Public Class Fraddfjpl

    Private Sub Fraddfjpl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        Dim sqlwc As String = "select tb_x823p_wcyp from tb_x823p where tb_x823p_id=" & Labelid.Text
        Dim dtwc As DataTable = GF_CreateDataSource(G_cnnstr, sqlwc)
        If Labelid.Text <> "" And dtwc.Rows(0)(0) = "是" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'me.Hide
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim dt As DataTable = ("select * from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text).YanGetDb
        dt.TableName = Labeltb.Text
        If (_D.Gs_updasj(Me, dt, True)) = 0 Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        'If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
        '    MsgBox("请检查输入项目及数据") : Exit Sub
        'End If

        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号

        GS_storelog3("添加粉剂配料", "添加粉剂配料") '储存到日志


        Dim sql As String
        sql = ""


        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class