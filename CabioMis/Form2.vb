Public Class Form2

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(listview1, Me.Text, Me)
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GS_DataGridViewbyDb(listview1, _D.G_zdinf, "0", True, False)
    End Sub
End Class