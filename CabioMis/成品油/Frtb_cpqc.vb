Public Class Frtb_cpqc

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_cpqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        Me.tb_h195z_qcsh.SelectedIndex = 1
        Dim czid As String = Labelid.Text
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''2008��10��22���޸�
        'If CInt(tb_h195z_c6u.Text) <= 0 Then
        '    MsgBox("����������Ŀ������")
        '    tb_h195z_c6u.Focus()
        '    Exit Sub
        'End If
        'If tb_h195z_qcrq.Text = "" Or tb_h195z_c28u.Text = "" Then
        '    MsgBox("������ֵ��ʱ�������д") : Exit Sub
        'End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("���QC") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        ''''''''''''''''''''''''''���㿪ʼyangshuai''''''''''''''''''

        '��Ʒ��Net(AA = ��Ʒ������ * (QC����ĳ�Ʒ��AA����)/100)
        '��Ʒ������(W) = (��Ʒ������-��������-�������ͣ�* 100 / ë��Ͷ����lili
        '��Ʒ�����ʣ�AA��=��Ʒ��Net AA/ë��Net AA
        '09/11/24��Ʒ�����ʼ��㹫ʽ�б䣬Ӧ������Weight=��Ʒ������*100/(ë��Ͷ������+����������+��������)
        'If tb_h195z_c6u.Text <> "" Then
        '    Dim cpyNetAA As Decimal = 0
        '    Dim cpyslw As Decimal = 0
        '    Dim cpyslAA As Decimal = 0
        '    '��ѯ��Ʒ��������Kg����ë��Ͷ����/ÿ��Ʒ����Kg����Ͷ��ë��Net AA��Kg����������������Kg������������(Kg)
        '    Dim tmpDt As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select tb_h195z_m408e,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_e95w,tb_h195z_tpyy from vw_h195z where tb_h195z_ID=" & Labelid.Text)
        '    'FormatNumber(str / 1024, 2)
        '    If tmpDt.Rows.Count > 0 Then
        '        Try
        '            cpyNetAA = FormatNumber(tmpDt.Rows(0)(0) * tb_h195z_c6u.Text / 100, 2)
        '            cpyslw = FormatNumber(tmpDt.Rows(0)(0) * 100 / (tmpDt.Rows(0)(1) + tmpDt.Rows(0)(3) + tmpDt.Rows(0)(4)), 2)
        '            cpyslAA = FormatNumber(cpyNetAA * 100 / tmpDt.Rows(0)(2), 2)
        '        Catch ex As Exception

        '        End Try

        '        Me.tb_h195z_t673l.Text = cpyNetAA
        '        Me.tb_h195z_u704m.Text = cpyslw
        '        Me.tb_h195z_q554i.Text = cpyslAA
        '    End If
        'End If
        '''''''''''''��ϸ��Ʒ�Ϳ����Ϣ
        Dim sql As String = "select * from tb_h195zkc  where  tb_h195zkc_num = '" & tb_h195z_num.Text.Trim & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim sql1 As String = "update tb_h195zkc set tb_h195zkc_qcrq= '" & tb_h195z_qcrq.Text & "',tb_h195zkc_y855q= '" & tb_h195z_y855q.Text & "',tb_h195zkc_c6u= " & tb_h195z_c6u.Text & ",tb_h195zkc_c28u= " & tb_h195z_c28u.Text & ", "
            sql1 &= "tb_h195zkc_m403e= " & tb_h195z_m403e.Text & ",tb_h195zkc_b991u= " & tb_h195z_b991u.Text & ",tb_h195zkc_k309c= " & tb_h195z_k309c.Text & ",tb_h195zkc_a948s= " & tb_h195z_a948s.Text & ", "
            sql1 &= "tb_h195zkc_l356d= " & tb_h195z_l356d.Text & ",tb_h195zkc_j268b= " & tb_h195z_j268b.Text & ",tb_h195zkc_o485g= '" & tb_h195z_o485g.Text & "',tb_h195zkc_d36v= '" & tb_h195z_d36v.Text & "', "
            sql1 &= "tb_h195zkc_h192z= " & tb_h195z_h192z.Text & ",tb_h195zkc_g158y= " & tb_h195z_g158y.Text & ",tb_h195zkc_qcsh= '" & tb_h195z_qcsh.Text & "', "
            sql1 &= "tb_h195zkc_u704m= " & tb_h195z_u704m.Text & ",tb_h195zkc_q554i= " & tb_h195z_q554i.Text & ",tb_h195zkc_t673l= " & tb_h195z_t673l.Text & " where tb_h195zkc_num= '" & tb_h195z_num.Text.Trim & "' "
            GS_upztxx(G_cnnstr, sql1)
        End If
        '''''''''''''''''''''''

        ''''''''''''''''''''''''''���㿪ʼyangshuai''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '���²����˹���
        GS_storelog3("��ӳ�Ʒ��QC��" & tb_h195z_num.Text.Trim, "���QC") '���浽��־
        Me.Close()
    End Sub

  
End Class