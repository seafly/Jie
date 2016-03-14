Public Class Frjhxg
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As TextBox = Me.Owner.Controls("tb_dhgz_pccl")
        a.Text = TextBox2.Text
        Me.Close()
    End Sub

    Private Sub Frjhxg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub
End Class