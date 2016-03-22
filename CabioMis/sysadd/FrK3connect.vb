Public Class FrK3connect

    Private Sub Frsjkconnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        '从文本读取数据()
        Try
            Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\K3connet.ini")
                Text3.Text = sr.ReadLine()
                Text4.Text = sr.ReadLine()
                Text5.Text = sr.ReadLine()
                Text1.Text = sr.ReadLine()
                sr.Close()
            End Using
        Catch ww As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim yhm, mm, sjk, fwq As String
        yhm = Trim(Text3.Text) : sjk = Trim(Text4.Text) : mm = Trim(Text5.Text) : fwq = Trim(Text1.Text)

        '写入文本
        Using sw As IO.StreamWriter = New IO.StreamWriter(Application.StartupPath() & "\K3connet.ini")
            sw.WriteLine(yhm)
            sw.WriteLine(sjk)
            sw.WriteLine(mm)
            sw.WriteLine(fwq)
            sw.Close()
        End Using

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim yhm, mm, sjk, fwq As String
        yhm = Trim(Text3.Text) : sjk = Trim(Text4.Text) : mm = Trim(Text5.Text) : fwq = Trim(Text1.Text)
        Dim G_cnnstr_K3 As String = "Provider=sqloledb; User ID=" & yhm & "; Password=" & mm & "; Initial Catalog=" & sjk & "; Data Source=" & fwq

        Dim cnn1 As New OleDb.OleDbConnection(G_cnnstr_K3)
        Dim myread As New OleDb.OleDbCommand
        myread.Connection = cnn1
        Try
            cnn1.Open()
        Catch ex As Exception
            MsgBox("K3数据库连接失败")
        End Try

        cnn1.Close() : myread = Nothing : cnn1 = Nothing
    End Sub
End Class