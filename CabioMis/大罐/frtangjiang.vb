Public Class frtangjiang

    Private Sub frtangjiang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.Owner.Controls("zl").Text = "" : Me.Owner.Controls("ph").Text = "" : Me.Owner.Controls("guanph").Text = ""
    End Sub
    'Sub ListView1_BeforeLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.BeforeLabelEdit
    '    'xyfj_temp = ListView1.Items(e.Item).SubItems(3).Text
    'End Sub
    'Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
    '    If e.Label = Nothing Then
    '        Exit Sub
    '    End If
    '    Dim zl As String = e.Label.ToString
    '    If IsNumeric(zl) = False Then
    '        MsgBox("应该填写数字") : e.CancelEdit = True : Exit Sub
    '    End If
    '    If zl < 0 Then
    '        MsgBox("应该填写大于等于0的数字。") : e.CancelEdit = True : Exit Sub
    '    End If
    '    Dim zsl As Integer = ListView1.Items(e.Item).SubItems(3).Text
    '    If zl > zsl Then
    '        MsgBox("应该填写提取重量不能大于本身重量" & zsl & "Kg。") : e.CancelEdit = True : Exit Sub
    '    End If
    '    '  ListView1.Items(e.Item).SubItems(3).Text = xyjg
    'End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = "" : Dim zl As String = ""
        Dim guanph As String = ""
        For i As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(i).Checked = True Then
                'zl = zl & ListView1.Items(i).SubItems(2).Text & ","
                zl = ListView1.Items(i).SubItems(2).Text
                ph = ph & ListView1.Items(i).SubItems(1).Text & ","
                guanph = guanph & ListView1.Items(i).SubItems(0).Text & ","
            End If
        Next
        ph = GF_removedh(ph) : guanph = GF_removedh(guanph)
        Me.Owner.Controls("zl").Text = zl : Me.Owner.Controls("ph").Text = ph : Me.Owner.Controls("guanph").Text = guanph
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class