Public Class Frtb_jlqc

    Private Sub Frtb_jlqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.tb_k306c_qcsh.SelectedIndex = 1
        GS_qhjd(Me) '�س����л����㣬��ע����
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''''''''''''''''''''''''''''''''''''''''''
        '�����ѳ�ARA����(��)/���������(mgKOH/g)/��������ppm�����Բ���д
        'If GF_YZSJ(Me, "tb_k306c_r591j,tb_k306c_f133x,tb_k306c_p508h,tb_k306c_w798p") = False Then '��֤�ؼ�
        '    MsgBox("�����ѳ�ARA����(��)/���������(mgKOH/g)/��������ppm��/���ܣ�ppm�����Բ���д") : Exit Sub
        'End If
        '''''''''''''''
        ''''''''''''''''''''
        If GF_storelog2("��Ӿ���QC��" & tb_k306c_num.Text.Trim, "���QC") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("����������Ŀ������")
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '���²����˹���
        Me.Close()
    End Sub

End Class