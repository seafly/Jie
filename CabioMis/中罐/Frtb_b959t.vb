Public Class Frtb_b959t
    Dim dt As DataTable
    Public old(11, 1) As String
    Public old2(2, 1) As String '���ﶨ�����ԭ�Ϲ�
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_b959t_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        Dim czid As String = Labelid.Text

        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            gh.Visible = False : tb_b959t_gh.Visible = False
        End If
        '   Gs_showsj2(Labeltb.Text, Me, "tb_b959t_num2") '��ʾ���һ����¼����ϸ
        GS_wlbktlr(tb_b959t_gh, 1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        dt = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
        ''''''''''''''''''''''''''''''''''''''''''������Ϊ���޸Ķ������ԭʼֵ

        setvalue("tb_b959t_v730n", 0)
        setvalue("tb_b959t_f119x", 1)
        setvalue("tb_b959t_j286b", 2)
        setvalue("tb_b959t_gasnph", 3)
        setvalue("tb_b959t_lseqjph", 4)
        setvalue("tb_b959t_lsmph", 5)
        setvalue("tb_b959t_nhgph", 6)
        setvalue("tb_b959t_tsqnph", 7)
        setvalue("tb_b959t_lsnph", 8)
        setvalue("tb_b959t_t665l", 9)
        setvalue("tb_b959t_mph", 10)
        setvalue("tb_b959t_vph", 11)
    End Sub
    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '���¿��
        '''''''''''''''''''''''''''''''''''�۳�ԭ��
        GS_kcylkc(tb_b959t_v730n, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_f119x, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_j286b, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_gasnph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_lseqjph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_lsmph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_nhgph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_tsqnph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_lsnph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_t665l, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_mph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_b959t_vph, Me) '����ԭ�Ͽ��
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        '''''''''�жϱ���''''''''''''��ע�����ݼ����š����ݼ������ɲ���д

        'If GF_YZSJ(Me, "tb_b959t_bz,tb_b959t_f119x,tb_b959t_f119xt,tb_b959t_mph,tb_b959t_mpht,tb_b959t_vph,tb_b959t_vpht") = False Then '��֤�ؼ�
        '    Exit Sub
        'End If
        ''''''''''''''''''''�ϼƻ���
        GS_hjkcylkc(tb_b959t_t665l, tb_b959t_z898r, Me)
        GS_hjkcylkc(tb_b959t_v730n, tb_b959t_k334c, Me)
        GS_hjkcylkc(tb_b959t_f119x, tb_b959t_g176y, Me)
        GS_hjkcylkc(tb_b959t_j286b, tb_b959t_a948s, Me)
        GS_hjkcylkc(tb_b959t_gasnph, tb_b959t_gasnphzl, Me)
        GS_hjkcylkc(tb_b959t_lseqjph, tb_b959t_lseqjphzl, Me)
        GS_hjkcylkc(tb_b959t_lsmph, tb_b959t_lsmphzl, Me)
        GS_hjkcylkc(tb_b959t_nhgph, tb_b959t_nhgphzl, Me)
        GS_hjkcylkc(tb_b959t_tsqnph, tb_b959t_tsqnphzl, Me)
        GS_hjkcylkc(tb_b959t_lsnph, tb_b959t_lsnphzl, Me)
        GS_hjkcylkc(tb_b959t_mph, tb_b959t_mphzl, Me)
        GS_hjkcylkc(tb_b959t_vph, tb_b959t_vphzl, Me)
        ''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("�޸Ķ�����") = False Then
            '    Exit Sub
            'End If ' �ж��Ƿ���Ȩ��

            ''''''''''''''''''''
            GS_sancusql(old) ''''��ԭԭ��
            ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
            Dim ylstr As String = Gf_pdylkc(tb_b959t_t665l, Me) & Gf_pdylkc(tb_b959t_v730n, Me)
            ylstr &= Gf_pdylkc(tb_b959t_f119x, Me) & Gf_pdylkc(tb_b959t_j286b, Me)
            ylstr &= Gf_pdylkc(tb_b959t_gasnph, Me) & Gf_pdylkc(tb_b959t_lseqjph, Me)
            ylstr &= Gf_pdylkc(tb_b959t_lsmph, Me) & Gf_pdylkc(tb_b959t_nhgph, Me)
            ylstr &= Gf_pdylkc(tb_b959t_tsqnph, Me) & Gf_pdylkc(tb_b959t_lsnph, Me)
            ylstr &= Gf_pdylkc(tb_b959t_mph, Me) & Gf_pdylkc(tb_b959t_vph, Me)
            If ylstr <> "" Then
                GS_hycusql(old) '����ԭԭ��
                GS_hycusql2(old2) '����ԭԭ�Ϲ�
                MsgBox(ylstr) : Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '�޸�����
                GS_hycusql(old) '����ԭԭ��
                MsgBox("����������Ŀ������")
                Exit Sub
            Else
                modfikucun() '���¿��
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
                GS_storelog3("�޸Ķ����ޣ�" & tb_b959t_num.Text.Trim, "�޸Ķ�����") '���浽��־
            End If
        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("��Ӷ�����") = False Then
            '    Exit Sub
            'End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            Else
                modfikucun() '���¿��
                Dim ta As String = "������" & tb_b959t_gh.Text
                ClassPhgn.ClassPhgn_SetDqz2(ta) 'ʹ��ǰ����+1
                GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
                GS_storelog3("��Ӷ����ޣ�" & tb_b959t_num.Text.Trim, "��Ӷ�����") '���浽��־
            End If
        End If
        Me.Close()
    End Sub
#Region "ԭ�����"
    Private Sub tb_b959t_tsqnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_tsqnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "̼������")
    End Sub

    Private Sub tb_b959t_lsnph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b959t_lsnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.011'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "������")
    End Sub


    Private Sub tb_b959t_gasnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_gasnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�Ȱ�����")
    End Sub

    Private Sub tb_b959t_lseqjph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b959t_lseqjph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��������")
    End Sub

    Private Sub tb_b959t_lsmph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_lsmph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����þ")
    End Sub

    Private Sub tb_b959t_nhgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_nhgph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.008'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�Ȼ���")
    End Sub

    Private Sub tb_b959t_j286b_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_j286b.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�Ȼ���")
    End Sub
    Private Sub tb_b959t_v730n_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_v730n.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��ĸ����")
    End Sub

    Private Sub tb_b959t_f119x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_f119x.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.022'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "���ݼ�")
    End Sub
    Private Sub tb_b959t_t665l_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_t665l.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.001'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "�ǹ�")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�ǹ�")
    End Sub
    Private Sub tb_b959t_mph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_mph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.012,2.07.013,2.07.014,2.07.015,2.07.017,2.07.018,2.07.019'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "M��΢��������Һ��")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.001'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "M��Һ")
    End Sub

    Private Sub tb_b959t_vph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_vph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.010,2.07.016,2.07.020,2.07.016,2.07.021'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "V��΢��ά������Һ��")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "M��Һ")
    End Sub
#End Region




    Private Sub tb_b959t_gh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b959t_gh.SelectedIndexChanged
        If Labelid.Text = "" Then '�޸�ʱ�����Ų����޸�
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("������" & tb_b959t_gh.Text, "-") '�õ���ǰ����+1������
            If qztemp = "" Then
                MsgBox("�����趨����ȷ") : Exit Sub
            End If
            tb_b959t_num.Text = qztemp
        End If
    End Sub
  
End Class