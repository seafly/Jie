Public Class Frtb_h195z
    Dim dt As DataTable
    Public old(4, 1) As String
    Private Sub Frtb_h195z_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����

        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='��Ʒ��' and tb_cpdmhz_cplx='DOGF'")
        GS_bcfbd(dt2, 2, tb_h195z_mingc)

        Dim czid As String = Labelid.Text

        If czid <> "" Then '�޸�ʱ�����Ų����޸�
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        Else
            tb_h195z_num.Text = ClassPhgn.ClassPhgn_Get("��Ʒ��", "-") '�õ���ǰ����+1������
            AddHandler tb_h195z_num.DoubleClick,
                Sub()
                    ClassPhgn.ClassPhgn_SetDqz2("��Ʒ��") 'ʹ��ǰ����+1
                    tb_h195z_num.Text = ClassPhgn.ClassPhgn_Get("��Ʒ��", "-") '�õ���ǰ����+1������
                End Sub
        End If

        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        dt = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
        ''''''''''''''''''''''''''''''''''''''''''������Ϊ���޸Ķ������ԭʼֵ

        setvalue("tb_h195z_y878r", 0)
        setvalue("tb_h195z_o460g", 1)
        setvalue("tb_h195z_g179y", 2)
        setvalue("tb_h195z_llzph", 3)
        setvalue("tb_h195z_swcsph", 4)

        tb_h195z_jgrq.BringToFront

        AddHandler tb_h195z_fgfph.DoubleClick, AddressOf addFangongfen
    End Sub
    Private Sub addFangongfen(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select 0 as ʹ������,tb_h195zkc_num,tb_h195zkc_cjcl,tb_h195zkc_jgrq,'KG' as ��λ,tb_h195zkc_ID,tb_h195zkc_cplb,tb_h195zkc_mingc from tb_h195zkc where " &
         "tb_h195zkc_cjcl>0 and tb_h195zkc_qaytjy='����'"
        Dim dt As DataTable = sql.YanGetDb

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "������"
        objClpam.bsName = "tb_h195z_fgfbs"
        objClpam.phName = "tb_h195z_fgfph"
        objClpam.callbackFn = Function(pTb As DataTable, pfr As frYanPhzl) As Boolean
                                  pfr.setOwnerVa()
                                  If tb_h195z_sbtb.Text = "tb_h195zkc" Then
                                      Me.tb_h195z_sbid.Text = pfr.m_rvBs
                                  End If
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_mingc.SelectedIndexChanged
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='��Ʒ��' and tb_cpdmhz_cplx='DOGF' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt2, 3, tb_h195z_jiagdm)
    End Sub

    Private Sub setvalue(ByVal ylph As String, ByVal wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '���¿��
        '''''''''''''''''''''''''''''''''''�۳�ԭ��
        GS_kcylkc(tb_h195z_y878r, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_h195z_o460g, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_h195z_g179y, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_h195z_llzph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_h195z_swcsph, Me) '����ԭ�Ͽ��
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        tb_h195z_hblsrkzl.Text = tb_h195z_m408e.Text
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ' '''''''''�жϱ���''''''''''''
        If tb_h195z_num2.Text = "" And tb_h195z_fgfph.Text = "" Then
            MsgBox("û��ѡ�����ε�����·����Ͳ���Ϊ�գ�", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If GF_YZSJ3(Me, "tb_h195z_num,tb_h195z_m408e") = False Then
            Return
        End If

        ''''''''''''''''''''�ϼƻ���
        GS_hjkcylkc(tb_h195z_o460g, tb_h195z_p495h, Me)
        GS_hjkcylkc(tb_h195z_y878r, tb_h195z_c998u, Me)
        GS_hjkcylkc(tb_h195z_g179y, tb_h195z_b989t, Me)
        GS_hjkcylkc(tb_h195z_llzph, tb_h195z_llzzl, Me)

        GS_hjkcylkc(tb_h195z_swcsph, tb_h195z_swcsphzl, Me)


        If Labelid.Text <> "" Then
            ''''''''''''''''''''
            '''''''''''''''''''''''''''''
            'If GF_storelog1("�޸ĳ�Ʒ��") = False Then
            '    Exit Sub
            'End If ' �ж��Ƿ���Ȩ��
            GS_sancusql(old) ''''��ԭԭ��
            ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
            Dim ylstr As String = Gf_pdylkc(tb_h195z_o460g, Me) & Gf_pdylkc(tb_h195z_y878r, Me) & Gf_pdylkc(tb_h195z_g179y, Me) & Gf_pdylkc(tb_h195z_llzph, Me)
            ylstr &= Gf_pdylkc(tb_h195z_swcsph, Me)
            If ylstr <> "" Then
                GS_hycusql(old) ''''����ԭԭ��
                MsgBox(ylstr) : Exit Sub
            End If
            '''''''''''''''''''''
            '09/11/24��Ʒ�����ʼ��㹫ʽ�б䣬Ӧ������Weight=��Ʒ������*100/(ë��Ͷ������+����������+��������)
            'tb_h195z_u704m.Text = FormatNumber(Null2zero2(tb_h195z_m408e.Text) * 100 / (Null2zero2(tb_h195z_n426f.Text) + Null2zero2(tb_h195z_e95w.Text) + Null2zero2(tb_h195z_tpyy.Text)), 2)
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '�޸�����
                GS_hycusql(old) '����ԭԭ��
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            modfikucun()

            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸ĳ�Ʒ�ͣ�" & tb_h195z_num.Text.Trim, "�޸ĳ�Ʒ��") '���浽��־
        Else
            ''''''''''''''''��ӳ�Ʒ��'''''''''''''
            If GF_cxph("tb_h195z_num", tb_h195z_num.Text.Trim) = True Then
                MsgBox("���ݿ����Ѿ����ڸ����ţ����������룡") : Exit Sub
            End If

            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            '����ԭ�Ͽ��
            modfikucun()
            '���·����Ϳ��
            GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_h195z_fgfbs, tb_h195z_fgfpht, pBszd:="id")
            ClassPhgn.ClassPhgn_SetDqz2("��Ʒ��") 'ʹ��ǰ����+1
            If Labeltb2.Text <> "tb_jch" Then
                GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)   '�����ϲ�����
            Else
                Dim sql As String = "update tb_jch set tb_jch_fgyph='" & tb_h195z_num.Text.Trim & "' where tb_jch_ID='" & Labelid2.Text & "'"
                Cl_DataMag.GS_upztxx(sql)
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("��ӳ�Ʒ�ͣ�" & tb_h195z_num.Text.Trim, "��ӳ�Ʒ��") '���浽��־
        End If
        Me.DialogResult = DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub tb_h195z_o460g_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_o460g.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.028' or tb_i259b_i231a='2.07.037'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��������")
    End Sub

    Private Sub tb_h195z_g179y_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_g179y.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.07.035' or tb_i259b_i231a='2.07.047' )")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����Ѫ��������� ")
    End Sub

    Private Sub tb_h195z_y878r_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_y878r.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.036'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "ά����E")
    End Sub

    Private Sub tb_h195z_llzph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_llzph.DoubleClick

        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.011' or tb_i259b_i231a='2.07.042'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����֬")
    End Sub

    Private Sub tb_h195z_swcsph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_swcsph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.043'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��ʧ����ȡ��")
    End Sub

    'Private Sub tb_h195z_ybd5kgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_ybd5kgph.DoubleClick
    '    Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='3.08.001'")
    '    GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�ͼ�������")
    'End Sub

    'Private Sub tb_h195z_ypybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_ypybdph.DoubleClick
    '    Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='3.08.003'")
    '    GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "1KG�ۼ�������")
    'End Sub


    Private Sub tb_h195z_fgyph_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_y876r.LostFocus
        '�ж�����ķ����������Ƿ���ȷ
        If tb_h195z_y876r.Text = "" Then
            Return
        End If
        For i As Integer = 0 To tb_h195z_y876r.Text.Split(",").Length - 1
            Dim sql As String = "select * from tb_jch where tb_jch_cz='��' and tb_jch_num='" & tb_h195z_y876r.Text.Split(",")(i) & "' and tb_jch_yt='����(����������)'"
            Dim dt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
            If dt.Rows.Count = 0 Then
                MsgBox("û�з���Ҫ��ĳ�Ʒ�ͣ�")
                tb_h195z_e95w.Text=""
                tb_h195z_y876r.Text=""
                Return
            End If
            tb_h195z_e95w.Text &= dt.Rows(0)("tb_jch_sl") & ","

        Next
        tb_h195z_e95w.Text = DeepCode.DeepDoStr.GF_removedh(tb_h195z_e95w.Text)
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub
End Class