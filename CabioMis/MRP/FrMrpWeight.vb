Public Class FrMrpWeight

    Private Sub FrMrpWeight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        showsj()
    End Sub
    Private Function showsj() As Boolean
        Dim SaveDate As String = DateTimePicker1.Text & "-" & DateTimePicker2.Text
        Dim sql As String = "select * from tb_mrpweight  where 1=1  "
        'sql &= " and tb_mrpweight_rq ='" & SaveDate & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        Return True
    End Function

    Private Sub FrMrpWeight_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub wz()
        GroupBox2.Width = Me.Width - 30
        GroupBox2.Height = Me.Height - GroupBox2.Top - 50
    End Sub
End Class