Public Class Frfjxp_qa

    Private Sub Frfjxp_qa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showsj()
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            Dim nform As New Form4
            nform.Labelid.Text = ListView1.SelectedItems(0).SubItems(0).Text
            nform.ShowDialog()
        End If
        showsj()
    End Sub

    Private Sub showsj()
        If Labeltb.Text <> "" Then
            Dim sql As String = "select * from " & Labeltb.Text & " where " & Labeltb.Text & "_glid in(" & Labelid.Text & ") "
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_useviewbydb2(ListView1, dt, 0, 150)
        End If
    End Sub
End Class