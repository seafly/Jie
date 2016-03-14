Public Class Frtb_yllb

    Private Sub Frtb_yllb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim k1, k2, k3
        k1 = tb_yllb_lb.Text.Trim
        k2 = tb_yllb_dm.Text.Trim
        k3 = tb_yllb_mc.Text.Trim
        If k1 = "" Or k2 = "" Or k3 = "" Then
            MsgBox("请将数据填写完整") : Exit Sub
        End If
        If GF_cxph("tb_yllb_dm", k2) = True Then
            MsgBox("数据库内已经存在该代码，请重新输入！") : Exit Sub
        End If
        GF_addsj(Labeltb.Text, Me)
        Me.Close()
    End Sub
End Class