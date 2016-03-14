Public Class Frfhwc
    Public id As String = "" : Public jm As String = ""
    Public ddh As String = ""
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If GF_modsj("tb_dd", Me, id) = False Then '修改数据
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        Dim sql As String = "update tb_dd set tb_dd_sjdhrq='" & tb_dd_sjdhrq.Text & "',tb_dd_jfwc='" & tb_dd_jfwc.Text & "' where tb_dd_ddh='" & ddh & "'"
        GS_upztxx(G_cnnstr, sql)
      ’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim nform As Frddlist = Me.Owner
        nform.xxsj(jm)
        Me.Close()
    End Sub

    Private Sub Frfhwc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub
End Class