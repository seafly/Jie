Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frwplb

    Private Sub Frwplb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ComboBox3.SelectedIndex = 0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_wp")
        Call GS_useviewbydb2(ListView2, dt, -1, 90)
    End Sub

    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        Dim dm As String = ""
        Dim pm As String = ""
        Dim gg As String = ""
        MsgBox("你确定修改吗？", MsgBoxStyle.OkCancel, "提示")
        If MsgBoxResult.Ok Then
            dm = ListView2.SelectedItems(0).SubItems(1).Text
            pm = ListView2.SelectedItems(0).SubItems(2).Text
            gg = ListView2.SelectedItems(0).SubItems(3).Text
            Me.Owner.Controls("tb_jh_pm").Text = dm
            Me.Owner.Controls("tb_jh_dm").Text = pm
            Me.Owner.Controls("tb_jh_gg").Text = gg
        Else
            Return
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Try
        Dim ss As String = TextBox2.Text.Trim
        Dim lm As String = ""
        Select Case ComboBox3.SelectedIndex
            Case 0
                lm = "tb_wp_pm"
            Case 1
                lm = "tb_wp_dm"
            Case 2
                lm = "tb_wp_gg"
        End Select
        If ListView2.Items.Count = 0 Then
            Return
        End If
        Dim sql As String = "select * from tb_wp where " & lm & " like '%" & ss & "%'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView2, dt, -1, 90)
        'Catch ex As Exception
        'End Try
    End Sub
End Class