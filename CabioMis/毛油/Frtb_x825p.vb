Public Class Frtb_x825p
    Dim dt As DataTable
    Public old(2, 1) As String
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_i234a_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='ë��' and tb_cpdmhz_cplx='DOGC'")
        GS_bcfbd(dt2, 2, tb_x825p_mingc)

        GS_qhjd(Me) '�س����л����㣬��ע����
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj("tb_x825p", Me, Labelid.Text)
        Else
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("ë��", "-") '�õ���ǰ����+1������
            If qztemp = "" Then
                MsgBox("�����趨����ȷ") : Exit Sub
            End If

            tb_x825p_num.Text = qztemp
        End If
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        dt = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
        ''''''''''''''''''''''''''''''''''''''''''������Ϊ���޸Ķ������ԭʼֵ
        setvalue("tb_x825p_jwph", 0)
        setvalue("tb_x825p_ycph", 1)
        setvalue("tb_x825p_nhnph", 2)
    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x825p_mingc.SelectedIndexChanged
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='ë��' and tb_cpdmhz_cplx='DOGC' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt2, 3, tb_x825p_jiagdm)
    End Sub



    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '���¿��
        '''''''''''''''''''''''''''''''''''�۳�ԭ��
        GS_kcylkc(tb_x825p_jwph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_x825p_ycph, Me) '����ԭ�Ͽ��
        GS_kcylkc(tb_x825p_nhnph, Me) '����ԭ�Ͽ��
  
    End Sub
#Region "ԭ��"

    Private Sub tb_x825p_ycph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x825p_ycph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.032'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�Ҵ�")
    End Sub



    Private Sub tb_x825p_nhnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x825p_nhnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�Ȼ���")
    End Sub

    Private Sub tb_x825p_jwph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x825p_jwph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.024'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����")
    End Sub



#End Region
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        'TODO:
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        Dim nofillcontrol As String = "" '����Ҫ��Ŀؼ�
        nofillcontrol = "tb_i234a_bz,tb_x825p_ycph,tb_x825p_ycpht"
        'If GF_YZSJ(Me, nofillcontrol) = False Then '��֤�ؼ�
        '    Exit Sub
        'End If
        '''''''''''''''
        ''''''''''''''''''''�ϼƻ���

        GS_hjkcylkc(tb_x825p_jwph, tb_x825p_jwphzl, Me)
        GS_hjkcylkc(tb_x825p_ycph, tb_x825p_ycphzl, Me)
        GS_hjkcylkc(tb_x825p_nhnph, tb_x825p_nhnphzl, Me)
        ''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            If GF_storelog1("�޸�ë��") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            ''''''''''''''''''''
            GS_sancusql(old) ''''��ԭԭ��
            ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
            Dim ylstr As String = Gf_pdylkc(tb_x825p_jwph, Me) & Gf_pdylkc(tb_x825p_ycph, Me)
            ylstr = ylstr & Gf_pdylkc(tb_x825p_nhnph, Me)

            If ylstr <> "" Then
                GS_hycusql(old) '����ԭԭ��
                MsgBox(ylstr) : Exit Sub
            End If
            ''''''''''''''''''''
            If GF_modsj("tb_x825p", Me, Labelid.Text) = False Then '�޸�����
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            modfikucun() '���¿��
            GS_modczsj("tb_x825p", "tb_x825p_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸�ë�ͣ�" & tb_x825p_num.Text.Trim, "�޸�ë��") '���浽��־
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("���ë��") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��

            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If

            modfikucun() '���¿��
            ''''''''''''''
            GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)
            Dim ta As String = "ë��"
            ClassPhgn.ClassPhgn_SetDqz2(ta) 'ʹ��ǰ����+1
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            'ywtjg() '�ı��Ǽ�޵�״̬
            GS_storelog3("���ë�ͣ�" & tb_x825p_num.Text.Trim, "���ë��") '���浽��־
        End If

        Me.Close()
    End Sub

    Private Sub tb_x825p_s640k_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x825p_s640k.TextChanged
        Try
            Dim sl As Double = Double.Parse(tb_x825p_s640k.Text)
            tb_x825p_hblsrkzl.Text = sl
        Catch ex As Exception
            MessageBox.Show("���������֣�")
        End Try
    End Sub
End Class