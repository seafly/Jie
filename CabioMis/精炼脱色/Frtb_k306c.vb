
Public Class Frtb_k306c
    Public old(4, 1) As String
    Dim dt As DataTable
    Private Sub Frtb_k306c_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)

        'Ĭ�Ͻ���ʱ�䣬����Ƶ�ʣ�����ʱ�䣴������
        If tb_k306c_v744n.Text = 0 Then '
            tb_k306c_v744n.Text = 45
        End If
        If tb_k306c_y860q.Text = 0 Then '
            tb_k306c_y860q.Text = 50
        End If
        If tb_k306c_z902r.Text = 0 Then '
            tb_k306c_z902r.Text = 240
        End If
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        dt = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
        old(0, 0) = tb_k306c_u716m.Text : old(0, 1) = tb_k306c_u716mt.Text
        old(1, 0) = tb_k306c_c27u.Text : old(1, 1) = tb_k306c_c27ut.Text
        old(2, 0) = tb_k306c_s626k.Text : old(2, 1) = tb_k306c_s626kt.Text
        old(3, 0) = tb_k306c_t653l.Text : old(3, 1) = tb_k306c_t653lt.Text
        old(4, 0) = tb_k306c_h217z.Text : old(4, 1) = tb_k306c_h217zt.Text
    End Sub
    Private Sub tb_k306c_c27u_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_c27u.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.005'or tb_i259b_i231a='2.06.010'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�������裨�ɽ���")
    End Sub

    Private Sub tb_k306c_h217z_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_k306c_h217z.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��������")
    End Sub

    Private Sub tb_k306c_s626k_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_s626k.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����̿")
    End Sub

    Private Sub tb_k306c_u716m_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_u716m.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "(tb_i259b_i231a='2.06.002'  or tb_i259b_i231a ='2.07.045' ) ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "������")
    End Sub
    Private Sub tb_k306c_t653l_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_t653l.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.06.003' or  tb_i259b_i231a='2.07.038')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "���԰���")
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("�޸ľ���") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        '''''''''�жϱ���''''''''''''��ע,�����ɲ���д

        If GF_YZSJ(Me, "tb_k306c_bz,tb_k306c_s626k,tb_k306c_s626kt,tb_k306c_t653l,tb_k306c_t653lt") = False Then '��֤�ؼ�
            Exit Sub
        End If

        ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
        Dim ylstr As String = Gf_pdylkc(tb_k306c_u716m, Me) & Gf_pdylkc(tb_k306c_c27u, Me)
        ylstr = ylstr & Gf_pdylkc(tb_k306c_s626k, Me) & Gf_pdylkc(tb_k306c_t653l, Me)
        ylstr = ylstr & Gf_pdylkc(tb_k306c_h217z, Me)
        If ylstr <> "" Then
            MsgBox(ylstr) : Exit Sub
        End If
        ''''''''''''''''''''�ϼƻ���
        GS_hjkcylkc(tb_k306c_u716m, tb_k306c_m398e, Me)
        GS_hjkcylkc(tb_k306c_c27u, tb_k306c_d39v, Me)
        GS_hjkcylkc(tb_k306c_s626k, tb_k306c_j299c, Me)
        GS_hjkcylkc(tb_k306c_t653l, tb_k306c_r574j, Me)
        GS_hjkcylkc(tb_k306c_h217z, tb_k306c_z903r, Me)

        '������������������������������

        If tb_k306c_m383e.Text = "" Then
            MsgBox("���Ż�ë��Ͷ����/ÿ����������Ϊ��")
            Exit Sub
        End If
        Dim ymympc As Double = tb_k306c_m383e.Text 'ԭ��ë�;�����������

        ''''''''''''''''''''
        Dim jlpc As String = GF_searchchar(Label2.Text, "�������Σ�", "right") '�õ���������
        '''''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '�޸�����
            MsgBox("����������Ŀ������") : Exit Sub
        Else
            GS_kcylkc(tb_k306c_u716m, Me) '����ԭ�Ͽ��
            GS_kcylkc(tb_k306c_c27u, Me) '����ԭ�Ͽ��
            GS_kcylkc(tb_k306c_s626k, Me) '����ԭ�Ͽ��
            GS_kcylkc(tb_k306c_t653l, Me) '����ԭ�Ͽ��
            GS_kcylkc(tb_k306c_h217z, Me) '����ԭ�Ͽ��
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸ľ�����" & jlpc, "�޸ľ���") '���浽��־
        End If

        Me.Close()
    End Sub

End Class