Public Class Frtb_xtwjqd

    Private Sub frxxxx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button3.Visible = True
        End If

        GS_qhjd(Me) '�س����л����㣬��ע����
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''��ע���Բ���д
        If tb_xtwjqd_wjmc.Text.Trim = "" Or tb_xtwjqd_bm.Text.Trim = "" Or tb_xtwjqd_zxbc.Text.Trim = "" Then '��֤�ؼ�
            MsgBox("���ơ����롢���°�α�����д")
            Exit Sub
        End If
        '������������������������������������������������������������
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("�޸��ļ��嵥") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸��ļ��嵥", "�޸��ļ��嵥��" & tb_xtwjqd_wjmc.Text.Trim) '���浽��־
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("����ļ��嵥") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("����ļ��嵥", "����ļ��嵥��" & tb_xtwjqd_wjmc.Text.Trim) '���浽��־
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("��ȷ��ɾ��������¼��?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''
            If GF_storelog1("ɾ���ļ��嵥") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("ɾ���ļ��嵥", "ɾ���ļ��嵥���ļ�����" & tb_xtwjqd_wjmc.Text) '���浽��־
            Me.Close()
        End If
    End Sub
End Class