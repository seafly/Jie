Public Class Frphzl2


    Private Sub Frphzl2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.Owner.Controls("zl").Text = "" : Me.Owner.Controls("ph").Text = ""
        Me.Owner.Controls("id").Text = ""
    End Sub

    Sub ListView1_BeforeLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.BeforeLabelEdit
        'xyfj_temp = ListView1.Items(e.Item).SubItems(3).Text
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

        Dim a As String = ""
        For i As Integer = 0 To ListView1.Items.Count - 1
            a = a & ListView1.Items(i).SubItems(1).Text & ","
        Next
        Dim yl As String = ""
        If Me.Owner.Text = "混批/返工计划" Then
            yl = GF_max2(GF_removedh(a))
        ElseIf Me.Owner.Text = "成品粉" Then
            Dim jj As String = ListView1.Columns(1).Text
            If InStr(jj, "铝箔袋") > 0 Then
                yl = GF_max(GF_removedh(a)) '表名是原料铝箔袋
            Else '表名是零头
                yl = GF_max3(GF_removedh(a))
            End If

        Else

            yl = GF_max(GF_removedh(a))
        End If

        'If yl <> ListView1.Items(e.Item).SubItems(1).Text Then
        '    If MsgBox("最前一批原料" & yl & "尚未用完，确定提取当前批原料吗？", 1, "提示") <> 1 Then
        '        e.CancelEdit = True
        '        Exit Sub
        '    End If
        'End If

        Dim zsl As Double = ListView1.Items(e.Item).SubItems(2).Text
        If zl > zsl Then
            MsgBox("应该填写提取重量不能大于本身重量" & zsl & "Kg。") : e.CancelEdit = True : Exit Sub
        End If
        '  ListView1.Items(e.Item).SubItems(3).Text = xyjg
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = "" : Dim zl As String = "" : Dim id As String = ""
        For i As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(i).SubItems(0).Text > 0 Then
                zl = zl & ListView1.Items(i).SubItems(0).Text & ","
                ph = ph & ListView1.Items(i).SubItems(1).Text & ","
                id = id & ListView1.Items(i).SubItems(3).Text & ","
            End If
        Next
        zl = GF_removedh(zl) : ph = GF_removedh(ph) : id = GF_removedh(id)
        Me.Owner.Controls("zl").Text = zl : Me.Owner.Controls("ph").Text = ph : Me.Owner.Controls("id").Text = id

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class