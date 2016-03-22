Public Class Frhzycl
    Public id As Integer = 0
    Private Sub Frycl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        If id <> 0 Then
            Gs_showsj("tb_cpdmhz", Me, id)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If GF_modsj("tb_cpdmhz", Me, id, G_cnnstrWH) = True And GF_modsj("tb_cpdmhz", Me, id, G_cnnstr) = True Then
            MsgBox("原材料标准用量添加成功！")
        Else
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        Me.Close()
      End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class