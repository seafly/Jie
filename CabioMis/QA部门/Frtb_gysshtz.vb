Public Class Frtb_gysshtz

    Private Sub qd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qd.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''��ע���Բ���д��ϵ�˺���ϵ����Ϊ�Ǳ���
        If GF_YZSJ(Me, "tb_gysshtz_bz,tb_gysshtz_qalxr,tb_gysshtz_lxfs") = False Then '��֤�ؼ�
            Exit Sub
        End If
        '''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("�޸Ĺ�Ӧ���ֳ����̨��") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            ''''''''''''''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸Ĺ�Ӧ���ֳ����̨��", "�޸Ĺ�Ӧ���ֳ����̨�ˣ�ԭ�ϣ�" & tb_gysshtz_ylmc.Text.Trim & ",��Ӧ�̣�" & tb_gysshtz_gys.Text.Trim) '���浽��־
        Else
            ''''''''''''''''''''''''''''
            If GF_storelog1("��ӹ�Ӧ���ֳ����̨��") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("��ӹ�Ӧ���ֳ����̨��", "��ӹ�Ӧ���ֳ����̨�ˣ�ԭ�ϣ�" & tb_gysshtz_ylmc.Text.Trim & ",��Ӧ�̣�" & tb_gysshtz_gys.Text.Trim) '���浽��־
        End If
        Me.Close()
    End Sub

    Private Sub Frtb_gysshtz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        '������������������������������������������
        Dim sz1 As String() = {"��ǰ��Ӧ��", "�¿�����Ӧ��"}
        GS_wlbktlr3(tb_gysshtz_nb, sz1, "")
        Dim sz2 As String() = {"���ϸ�", "�ϸ�"}
        GS_wlbktlr3(tb_gysshtz_shjg, sz2, "")
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
        End If

        GS_qhjd(Me) '�س����л����㣬��ע����
    End Sub

    Private Sub qx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qx.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("��ȷ��ɾ��������¼��?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''��־Ȩ���ж�
            If GF_storelog1("ɾ����Ӧ���ֳ����̨��") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''''''''''
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("ɾ����Ӧ���ֳ����̨��", "ɾ����Ӧ���ֳ����̨�ˣ�ԭ������" & tb_gysshtz_ylmc.Text) '���浽��־
            Me.Close()
        End If
    End Sub
End Class