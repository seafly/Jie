Imports DeepCode.DeepDoDataTable
Public Class Frtb_bcQC

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", MsgBoxStyle.OkCancel, "��ʾ") <> 1 Then
            Exit Sub
        End If


        Dim ph As String = tb_bcQC_num.Text
        If Labelid.Text <> "" Then

            '''''''''''''''''''''''''''''
            If GF_storelog1("�޸�QC") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸İ���QC��" & ph, "�޸�QC") '���浽��־
        Else
            '''''''''''''''''''''''''''''

            If GF_storelog1("���QC") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("��Ӱ���QC��" & ph, "���QC") '���浽��־
        End If
        Dim sql As String = "update tb_i259b set tb_i259b_qcsh='" & tb_bcQC_qcsh.Text & "' ,tb_i259b_qcrq='" & tb_bcQC_qcrq.Text & "' where tb_i259b_num='" & tb_bcQC_num.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        MessageBox.Show("��ӳɹ���")
        Me.Close()

    End Sub

    Private Sub Frtb_bcQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        GS_qhjd(Me) '�س����л����㣬��ע����

        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        End If
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        If biaoid = "" Then
            Exit Sub
        End If

        Dim r As Integer = MsgBox("ȷ��ɾ����", MsgBoxStyle.OkCancel, "����")
        If r <> 1 Then
            Exit Sub
        End If
        Dim ph As String = tb_bcQC_num.Text
        ''''''''''''''''''''��־Ȩ���ж�
        If GF_storelog2("ɾ������QC��" & ph, "ɾ��QC") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update tb_i259b set tb_i259b_qcsh='��' where tb_i259b_num='" & ph & "'"
        sql = sql & vbCrLf & "delete from tb_bcQC where tb_bcQC_id=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        Me.Close()
    End Sub


End Class