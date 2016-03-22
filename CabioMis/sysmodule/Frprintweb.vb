Public Class Frprintweb
    Private Sub Frprintweb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
    End Sub
    Private Sub ToolStripDropDownButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton5.Click
        WebBrowser1.ShowPrintPreviewDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        WebBrowser1.ShowPageSetupDialog()
    End Sub

    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        WebBrowser1.ShowPrintDialog()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
    

    '通过DataGridView构成打印主体内容
    Public Shared Function GF_DbToPrintWeb(ByVal lst As DataGridView) As String
        Try
            Dim tbhead As String = "<tr>"
            For i As Integer = 0 To lst.Columns.Count - 1
                tbhead = tbhead & "<td>" & lst.Columns(i).HeaderText & "</td>" & vbCrLf
            Next
            tbhead = tbhead & "</tr>" & vbCrLf
            Dim tbbody As String = ""
            For j As Integer = 0 To lst.Rows.Count - 1
                tbbody = tbbody & "<tr>"
                For i As Integer = 0 To lst.Columns.Count - 1
                    If lst.Rows(j).Cells(i) Is DBNull.Value Then
                        tbbody = tbbody & "<td>&nbsp;</td>" & vbCrLf
                    Else
                        tbbody = tbbody & "<td>" & lst.Rows(j).Cells(i).Value & "</td>" & vbCrLf
                    End If
                Next
                tbbody = tbbody & "</tr>" & vbCrLf
            Next
            Dim tbhtml As String = "<table width='95%'  id='table2' border='1' align='center'  style='font-size: 10pt'>" & tbhead & tbbody & "</table>"
            GF_DbToPrintWeb = tbhtml
        Catch ex As Exception
            GF_DbToPrintWeb = ""
        End Try
    End Function
    '通过ListView构成打印主体内容
    Public Shared Function GF_DbToPrintWeb(ByVal lst As ListView) As String
        Try
            Dim tbhead As String = "<tr>"
            For i As Integer = 0 To lst.Columns.Count - 1
                tbhead = tbhead & "<td>" & lst.Columns(i).Text & "</td>" & vbCrLf
            Next
            tbhead = tbhead & "</tr>" & vbCrLf
            Dim tbbody As String = ""
            For j As Integer = 0 To lst.Items.Count - 1
                tbbody = tbbody & "<tr>"
                For i As Integer = 0 To lst.Columns.Count - 1
                    If lst.Items(j).SubItems(i).Text Is DBNull.Value Then
                        tbbody = tbbody & "<td>&nbsp;</td>" & vbCrLf
                    Else
                        tbbody = tbbody & "<td>" & lst.Items(j).SubItems(i).Text & "</td>" & vbCrLf
                    End If
                Next
                tbbody = tbbody & "</tr>" & vbCrLf
            Next
            Dim tbhtml As String = "<table width='95%'  id='table2' border='1' align='center'  style='font-size: 10pt'>" & tbhead & tbbody & "</table>"
            GF_DbToPrintWeb = tbhtml
        Catch ex As Exception
            GF_DbToPrintWeb = ""
        End Try
    End Function
    '通过DB构成打印主体内容
    Public Shared Function GF_DbToPrintWeb2(ByVal strdb As DataTable) As String
        Try
            Dim tbhead As String = "<tr>"
            For i As Integer = 0 To strdb.Columns.Count - 1
                tbhead = tbhead & "<td>" & strdb.Columns(i).Caption & "</td>" & vbCrLf
            Next
            tbhead = tbhead & "</tr>" & vbCrLf
            Dim tbbody As String = ""
            For j As Integer = 0 To strdb.Rows.Count - 1
                tbbody = tbbody & "<tr>"
                For i As Integer = 0 To strdb.Columns.Count - 1
                    If strdb.Rows(j)(i) Is DBNull.Value Then
                        tbbody = tbbody & "<td>&nbsp;</td>" & vbCrLf
                    Else
                        tbbody = tbbody & "<td>" & strdb.Rows(j)(i).ToString & "</td>" & vbCrLf
                    End If
                Next
                tbbody = tbbody & "</tr>" & vbCrLf
            Next
            Dim tbhtml As String = "<table width='95%'  id='table2' border='1' align='center'  style='font-size: 10pt'>" & tbhead & tbbody & "</table>"
            Return tbhtml
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class