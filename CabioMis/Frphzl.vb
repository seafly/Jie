Public Class Frphzl
    Public m_gzkj As string=""
    Private Sub Frphzl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.Owner.Controls("zl").Text = "" : Me.Owner.Controls("ph").Text = ""

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
            MsgBox("Ӧ����д����") : e.CancelEdit = True : Exit Sub
        End If

        If zl < 0 Then
            MsgBox("Ӧ����д���ڵ���0�����֡�") : e.CancelEdit = True : Exit Sub
        End If

        Dim a As String = ""
        For i As Integer = 0 To ListView1.Items.Count - 1
            a = a & ListView1.Items(i).SubItems(1).Text & ","
        Next
        Dim yl As String = ""

        Try
            If Me.Owner.Text = "����/�����ƻ�" Then
                yl = GF_max2(GF_removedh(a))
            ElseIf Me.Owner.Text = "��Ʒ��" Then
                Dim jj As String = ListView1.Columns(1).Text
                If InStr(jj, "������") > 0 Then
                    yl = GF_max(GF_removedh(a)) '������ԭ��������
                Else '��������ͷ
                    yl = GF_max3(GF_removedh(a))
                End If

            Else

                yl = GF_max(GF_removedh(a))
            End If
            If yl <> ListView1.Items(e.Item).SubItems(1).Text Then
                If MsgBox("��ǰһ��ԭ��" & yl & "��δ���꣬ȷ����ȡ��ǰ��ԭ����", 1, "��ʾ") <> 1 Then
                    e.CancelEdit = True
                    Exit Sub
                End If
            End If

            Dim zsl As Double = ListView1.Items(e.Item).SubItems(2).Text
            If zl > zsl Then
                MsgBox("Ӧ����д������ȡ���ܴ��ڱ�������" & zsl & "Kg��") : e.CancelEdit = True : Exit Sub
            End If
        Catch ex As Exception

        End Try

        '  ListView1.Items(e.Item).SubItems(3).Text = xyjg
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = "" : Dim zl As String = ""
        Dim douZl As Double = 0
        For i As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(i).SubItems(0).Text > 0 Then
                zl = zl & ListView1.Items(i).SubItems(0).Text & ","
                ph = ph & ListView1.Items(i).SubItems(1).Text & ","
                douZl += ListView1.Items(i).SubItems(0).Text * ListView1.Items(i).SubItems(4).Text
            End If
        Next
        zl = GF_removedh(zl) : ph = GF_removedh(ph)
        Me.Owner.Controls("zl").Text = zl : Me.Owner.Controls("ph").Text = ph
        Try
            Me.Owner.Controls(m_gzkj).Text = douZl
        Catch
        End Try
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class