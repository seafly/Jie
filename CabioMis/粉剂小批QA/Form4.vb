Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim sql As String = "update tb_n441f set tb_n441f_qaspjg='" & ComboBox1.Text & "' where tb_n441f_ID=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        MsgBox("QA结果已经修改成" & ComboBox1.Text)
        Me.Close()
    End Sub
End Class