Public Class Frtb_khtsjlb
    Private Sub Frtb_khtsjl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        '������������������������������������������
        Dim sz1 As String() = {"����������", "ʳƷ��ȫ��", "��װ��ʶ��", "�ִ�������"}
        GS_wlbktlr3(tb_khtsjlb_tslb, sz1, "")
        '������������������������������������������
        Dim czid As String = Labelid.Text
        '����������������������������
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
        ''''''''''''''''''''''''''''''''''''''''''��ע���Բ���д�������ˡ��͡����Ĵ�ʩ��ҲΪ�Ǳ���
        If GF_YZSJ(Me, "tb_khtsjlb_bz,tb_khtsjlb_zgcs,tb_khtsjlb_jsr") = False Then '��֤�ؼ�
            Exit Sub
        End If
        '������������������������������������������������������������
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''
            If GF_storelog1("�޸Ŀͻ�Ͷ�߼�¼") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸Ŀͻ�Ͷ�߼�¼", "�޸Ŀͻ�Ͷ�߼�¼:�ͻ�" & tb_khtsjlb_kh.Text.Trim) '���浽��־
        Else
            ''''''''''''''''''''''''''''
            If GF_storelog1("��ӿͻ�Ͷ�߼�¼") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("��ӿͻ�Ͷ�߼�¼", "��ӿͻ�Ͷ�߼�¼:�ͻ�" & tb_khtsjlb_kh.Text.Trim) '���浽��־
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("��ȷ��ɾ��������¼��?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''��־Ȩ���ж�
            '''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''
            If GF_storelog1("ɾ���ͻ�Ͷ�߼�¼") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("ɾ���ͻ�Ͷ�߼�¼", "ɾ���ͻ�Ͷ�߼�¼���ͻ�" & tb_khtsjlb_kh.Text.Trim) '���浽��־
            Me.Close()
        End If
    End Sub

End Class