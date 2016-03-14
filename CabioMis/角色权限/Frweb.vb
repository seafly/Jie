Public Class Frweb

    Private Sub Frweb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yhm, mm, sjk, fwq, port As String

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_yg_pass from tb_yg where tb_yg_n430f=" & G_dlrgh & " And tb_yg_yx = '有效'")


        Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
            yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = sr.ReadLine() : fwq = sr.ReadLine() : port = sr.ReadLine() : sr.Close()
        End Using
        If fwq = "(local)" Then
            fwq = "127.0.0.1"
        End If
        If port = "" Then
            port = ":80"
        Else
            port = ":" & port
        End If
        'Me.WebBrowser1.Url = New System.Uri("http://" & fwq & port & "/cabiojs", System.UriKind.Absolute)
        Me.WebBrowser1.Url = New System.Uri("http://" & fwq & port & "/cabiojs/default.asp?password=" & dt.Rows(0)(0) & " &czrgh=" & G_dlrgh, System.UriKind.Absolute)
    End Sub
End Class