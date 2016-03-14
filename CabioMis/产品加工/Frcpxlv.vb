
Public Class Frcpxlv
    Public id As Integer = 0
    Public kj As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim aa As Double
        Dim sql As String = "select tb_cpdmhz_cplx from tb_cpdmhz where tb_cpdmhz_ID = " & id & " "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Select Case dt.Rows(0)(0)
            Case "AOGC", "DOGC"
                aa = TextBox1.Text * TextBox2.Text
            Case "AOGF", "DOGF"
                aa = TextBox3.Text
            Case "APGT", "DPGE"
                aa = TextBox4.Text / TextBox5.Text * TextBox6.Text
            Case "APGE"
             aa = TextBox4.Text / TextBox5.Text * TextBox6.Text
            Case "APGK"
          aa = TextBox7.Text
        End Select
        Dim txt As TextBox = Me.Owner.Controls(kj)
        txt.Text = FormatNumber(aa, 2)
        Me.Close()
    End Sub

    Private Sub Frcpxlv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select tb_cpdmhz_cplx from tb_cpdmhz where tb_cpdmhz_ID = " & id & " "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Select Case dt.Rows(0)(0)
            Case "AOGC", "DOGC"
                Label1.Visible = True
                Label2.Visible = True
                TextBox1.Visible = True
                TextBox2.Visible = True
            Case "AOGF", "DOGF"
                Label3.Visible = True
                TextBox3.Visible = True
            Case "APGT", "DPGE"
                Label4.Visible = True
                Label5.Visible = True
                Label6.Visible = True
                TextBox4.Visible = True
                TextBox5.Visible = True
                TextBox6.Visible = True
            Case "APGE"
                Label4.Visible = True
                Label5.Visible = True
                Label6.Visible = True
                TextBox4.Visible = True
                TextBox5.Visible = True
                TextBox6.Visible = True
            Case "APGK"
                Label7.Visible = True
                TextBox7.Visible = True
        End Select
    End Sub
End Class