Public Class Frdxxfdate

    Private Sub Frdxxfdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If Me.Owner.Controls("combobox1").Text <> "之间" Then
            DateTimePicker1.Visible = False
            Label2.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tt1, tt2 As String
        tt1 = DateTimePicker1.Text
        tt2 = DateTimePicker2.Text
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Select Case Me.Owner.Controls("combobox1").Text
            Case "之间"
                Me.Owner.Controls("textbox1").Text = tt1 & "," & tt2
                'me.Owner.Controls("
            Case "大于"
                Me.Owner.Controls("textbox1").Text = tt2
            Case "小于"
                Me.Owner.Controls("textbox1").Text = tt1
        End Select
     
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class