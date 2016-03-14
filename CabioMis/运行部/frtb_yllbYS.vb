Public Class frtb_yllbYS
    Public actionType As Integer '标识动作类型：0=添加；1=修改
    Public recordId As Int64 '记录ID

    Private Sub frtb_yllbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As New Data.DataTable
        dt = GF_CreateDataSource(G_cnnstr, "select tb_yllb_lb from tb_yllb group by tb_yllb_lb")
        GS_wlbktlr2(Me.tb_yllb_lb, dt, 0, "")
        Me.tb_yllb_yxx.Items.Add("有效")
        Me.tb_yllb_yxx.Items.Add("无效")
        If actionType = 1 Then
            Gs_showsj("tb_yllb", Me, recordId)
            Me.butAction.Text = "修改"
        Else
            Me.butAction.Text = "添加"
        End If
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    Private Sub butAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAction.Click
        If actionType = 1 Then
            GF_modsj("tb_yllb", Me, recordId)
        Else
            If GF_cxph("tb_yllb_dm", tb_yllb_dm.Text.Trim) = True Then
                MsgBox("数据库内已经存在该代码，请重新输入！") : Exit Sub
            End If
            '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
            If GF_storelog2("添加原料类别：" & tb_yllb_dm.Text, "添加原料类别") = False Then
                Exit Sub
            End If
            ''''''''''''''''''''
            GF_addsj("tb_yllb", Me)
        End If
        Me.Close()

    End Sub
End Class