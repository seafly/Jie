Public Class frtb_yllbYS
    Public actionType As Integer '��ʶ�������ͣ�0=��ӣ�1=�޸�
    Public recordId As Int64 '��¼ID

    Private Sub frtb_yllbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As New Data.DataTable
        dt = GF_CreateDataSource(G_cnnstr, "select tb_yllb_lb from tb_yllb group by tb_yllb_lb")
        GS_wlbktlr2(Me.tb_yllb_lb, dt, 0, "")
        Me.tb_yllb_yxx.Items.Add("��Ч")
        Me.tb_yllb_yxx.Items.Add("��Ч")
        If actionType = 1 Then
            Gs_showsj("tb_yllb", Me, recordId)
            Me.butAction.Text = "�޸�"
        Else
            Me.butAction.Text = "���"
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
                MsgBox("���ݿ����Ѿ����ڸô��룬���������룡") : Exit Sub
            End If
            '������������������������������־��Ȩ���ж�
            If GF_storelog2("���ԭ�����" & tb_yllb_dm.Text, "���ԭ�����") = False Then
                Exit Sub
            End If
            ''''''''''''''''''''
            GF_addsj("tb_yllb", Me)
        End If
        Me.Close()

    End Sub
End Class