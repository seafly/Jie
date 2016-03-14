Public Class Frstorage
    Public Num As String
    Public Conkc As Control
    Private Sub Frstorage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Label1.Text = "总量：" & Conkc.Text
 End Sub
  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sl As String = ""
            Dim zdm As String = ""
            Dim hj As Double = 0 '合计
            With ListView1
                If .Items.Count > 0 Then

                    For i As Integer = 0 To .Items.Count - 1
                        sl &= .Items(i).SubItems(0).Text & ","
                        hj += .Items(i).SubItems(0).Text
                        zdm &= .Items(i).SubItems(.Columns.Count - 1).Text & ","
                    Next
                End If
            End With

            If hj <> Conkc.Text Then
                MessageBox.Show("输入重量合计不等于总库数！")
                Exit Sub
            End If

            sl = GF_removedh(sl)
            zdm = GF_removedh(zdm)
            Me.Owner.Controls("Storage" & Num).Text = sl
            Me.Owner.Controls("Storage" & Num).Tag = zdm
            Me.Owner.Controls(Conkc.Name).Enabled = False
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        If e.Label = Nothing Then
            Exit Sub
        End If
        Dim zl As String = e.Label.ToString

        If IsNumeric(zl) = False Then
            MsgBox("应该填写数字") : e.CancelEdit = True : Exit Sub
        End If

        If zl < 0 Then
            MsgBox("应该填写大于等于0的数字。") : e.CancelEdit = True : Exit Sub
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class