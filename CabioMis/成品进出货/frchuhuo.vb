Imports System.Linq
''' <summary>
''' ��Ʒ������
''' </summary>
Public Class frchuhuo
    Private m_frOpen As frzchuo = CType(Application.OpenForms.Item("frzchuo"), frzchuo)
    private m_lv2Dt As DataTable=ListviewToDatatable(m_frOpen.ListView2)
    Private m_ltCk As List(Of String) = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",").ToList
    Private g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='��Ч' order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ")
    Private Sub frchuhuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_ltCk.Remove(GetType(en_cklist).YanGetEnText(en_cklist.��ɽ���))
        m_ltCk.Remove(GetType(en_cklist).YanGetEnText(en_cklist.�������))
        '��¶����2012��3��31��  ��Ӹ��� �ֿ���⹦��
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Dim bm As String = Labeltb.Text '' ����
        tb_x825p_yg.Items.Clear()
        If kk.Rows.Count > 0 Then
            For i As Integer = 0 To kk.Rows.Count - 1
                tb_x825p_yg.Items.Add(kk.Rows(i)(1))
            Next
        End If
        Select Case bm
            Case "tb_h195zkc"  '��Ʒ��
                tb_x825p_yg.Text = "��������"
                tb_x825p_yg.Items.Add("��������")
            Case "tb_x825pkc" 'ë��
                tb_x825p_yg.Items.Add("��������")
            Case "tb_x832pkc"   '��Ʒ��
                tb_x825p_yg.Text = "����"
        End Select


        Dim bmid As String = Labelid.Text
        Dim sql As String = "select " & bm & "_qaspjg," & bm & "_qajgsm," & bm & "_cplb," & bm & "_mingc," & bm & "_jiagdm, " & bm & "_ckcl," & bm & "_sykczl," & bm & "_bf from " & bm & " where " & bm & "_id=" & bmid
        kk = GF_CreateDataSource(G_cnnstr, sql)
        Labelsykc.Text = kk.Rows(0)(bm & "_sykczl") 'ʣ��������
        Label11.Text = kk.Rows(0)(bm & "_bf") '��������
        Label13.Text = kk.Rows(0)(bm & "_ckcl") '�ֿ���� 
        Label2.Text = "QA���:" & kk.Rows(0)(0)
        Label3.Text = "QA���˵��:" & Null2String(kk.Rows(0)(1))
        ComboBox1.Text = Null2String(kk.Rows(0)(bm & "_cplb")) '��Ʒ����
        cpdm.Text = Null2String(kk.Rows(0)(bm & "_mingc")) '��Ʒ����
        jgdm.Text = Null2String(kk.Rows(0)(bm & "_jiagdm")) '�ӹ�����
        jgdm.Tag = Null2String(kk.Rows(0)(bm & "_jiagdm"))
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpdm='" & cpdm.Text & "'")

        GS_qhjd(Me) '�س����л����㣬��ע����
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If InStr(Label2.Text, "����") Then
            MessageBox.Show("��Ʒ�Ѿ����ᣬ�޷�����!")
            Exit Sub
        End If
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        If tb_x825p_yg.Text = "" Then
            MessageBox.Show("��;Ϊ��")
            Exit Sub
        End If
        Dim kcc, rkts As Double
        If chts.Text.Trim = "" Then
            rkts = 0
        End If
        Try
            kcc = kc.Text
        Catch ex As Exception
            MsgBox("����ȷ��д����") : Exit Sub
        End Try

        '''''''''''''''''''''''''''''''����ж�
        If StorageOne.Text = "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("û��������ص������Ϣ!��ȷ���᣿", "�������", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        If tb_x825p_yg.Text = "����" And InStr(Label2.Text, "�ϸ�") = 0 Then
            MsgBox("������; Ϊ����ʱ��QA ��������Ǻϸ�") : Exit Sub
        End If
        Dim bfs As Double = kc.Text '��������
        If CDbl(Labelsykc.Text) < CDbl(kc.Text) And (tb_x825p_yg.Text <> "����" And tb_x825p_yg.Text <> "����Ʒʵ��" And tb_x825p_yg.Text <> "��������") Then
            MsgBox("��������ĳ���������ʣ�������������������룡") : Exit Sub
        End If
        Dim fn As String = Labeltb.Text
        Dim cwzd As String = ""

        cwzd = fn & "_cw='" & cw.Text & "'"

        ''''''''''''''''''
        If GF_storelog2("������" & ph.Text, "����") = False Then
            Exit Sub
        End If
        ''''''''''''''''' 
        '*���¡�ʣ����������=ʣ��������-������
        '*���� ���ٻ��߱���Ʒ������=��������-��������Ĭ�ϵĳ�����Ϊ���ٻ��߱���Ʒ����������
        Dim sql As String = ""
        Dim sykczl As Double = CDbl(Labelsykc.Text) - CDbl(kc.Text)
        Dim aaa As Double = CDbl(kc.Text)
        If tb_x825p_yg.Text = "��������" And sykczl <> 0 Then
            MsgBox("������; ��������ʱ�����ֵӦ�õ���ʣ�������������������룡") : Exit Sub
        End If

        Select Case tb_x825p_yg.Text
            Case "����", "����", "��������", "����������"
                Dim dtas As DataTable = GF_CreateDataSource(G_cnnstr, "select " & fn & "_qaspjg from " & fn & " where " & fn & "_ID=" & Labelid.Text)
                If dtas.Rows(0)(0) = "����" Then
                    MsgBox("������QA�������Ϊ���ϣ����ܳ��⣡")
                    Exit Sub
                ElseIf dtas.Rows(0)(0) = "���ϸ�" Then
                    MsgBox("������QA�������Ϊ���ϸ񣬲��ܳ��⣡")
                End If
            Case "��ӹ�", "��������ӹ�"
                Dim dtas As DataTable = GF_CreateDataSource(G_cnnstr, "select " & fn & "_qaspjg from " & fn & " where " & fn & "_ID=" & Labelid.Text)
                If dtas.Rows(0)(0) = "���ϸ�" Then
                    MsgBox("������QA�������Ϊ���ϸ񣬲��ܳ��⣡")
                    Exit Sub
                End If
        End Select

        '�����;Ϊ������ë�͡���Ʒ�͡���Ʒ�ۣ��������ԡ����ۡ�����������+���ۡ���ӹ�����ӹ�+��������;����
        Select Case tb_x825p_yg.Text
            Case "����", "����", "��������", "����������", "��ӹ�", "��������ӹ�"
                Dim dtas As DataTable = GF_CreateDataSource(G_cnnstr, "select " & fn & "_yg from " & fn & " where " & fn & "_ID=" & Labelid.Text)
                If dtas.Rows(0)(0) = "����" Then
                    MsgBox("���������;Ϊ���������ܳ��⣡")
                    Exit Sub
                End If
        End Select

        Using yMt As New _D.myTransaction
            '����Ŀ�����ݿ⣨������
            If tb_x825p_yg.Text = "��������" Then
                Dim dic As Dictionary(Of String, String)
                Dim sqlMt As String = ""
                Dim dtMt As DataTable = Nothing
                Dim dtBind As DataTable = Nothing
                Dim f As Frzk
                Select Case Labeltb.Text
                    Case "tb_h195zkc" '��Ʒ��ת��
                        'ת�⵽������������ôֱ�ӵ����������Ľ���
                        f = New Frzk("��Ʒ��")
                        f.zkzl.Text = kcc
                        f.zkzl.Tag = kcc
                        f.m_strTb = "tb_h195zkc"
                        f.m_strPh = ph.Text
                        f.cplb.Text = m_lv2Dt.YanDtValue2("tb_h195zkc_cplb", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.mingc.Text = m_lv2Dt.YanDtValue2("tb_h195zkc_mingc", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.jiagdm.Text = m_lv2Dt.YanDtValue2("tb_h195zkc_jiagdm", m_frOpen.ListView2.SelectedItems(0).Index)
                        If f.ShowDialog <> DialogResult.OK Then
                            Return
                        End If
                        '�õ��������ʼ����������
                        Dim dtRv As DataTable = f.YanDaTaGridView1.DataSource
                        dtRv.Columns.Remove("rowBs")
                        For Each tDr As DataRow In dtRv.Rows
                            sqlMt = "select * from hbcabiodb..tb_h195zkc where tb_h195zkc_num='" & ph.Text &
                            "' and tb_h195zkc_cplb='" & tDr("tb_h195zkc_cplb") &
                            "' and tb_h195zkc_mingc='" & tDr("tb_h195zkc_mingc") &
                            "' and tb_h195zkc_jiagdm='" & tDr("tb_h195zkc_jiagdm") & "'"
                            dtMt = yMt.getDb(sqlMt)
                            If dtMt.Rows.Count > 0 Then
                                '��Ʒ���У����Ŵ��붼һ����ô���¿��
                                dic = New Dictionary(Of String, String)
                                dic("tb_h195zkc_sykczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_sykczl"))) + CDbl(tDr("tb_h195zkc_kczl"))
                                dic("tb_h195zkc_ckcl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_ckcl"))) + CDbl(tDr("tb_h195zkc_kczl"))
                                dic("tb_h195zkc_kczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_kczl"))) + CDbl(tDr("tb_h195zkc_kczl"))
                                dic("tb_h195zkc_bz") = dtMt.YanDtValue2("tb_h195zkc_bz") & "," & DateTime.Now & ":" & "�ɺ����������" & tDr("tb_h195zkc_kczl")
                                For Each s As String In m_ltCk
                                    dic("tb_h195zkc_" & s) = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_" & s))) + CDbl(tDr("tb_h195zkc_" & s))
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_h195zkc", dic, "tb_h195zkc_ID=" & dtMt.YanDtValue2("tb_h195zkc_ID"))
                                yMt.dbExe(sqlMt)
                            Else
                                'û��һ���ģ���ô��д����
                                sqlMt = "Insert into hbcabiodb..tb_h195zkc(tb_h195zkc_num2,tb_h195zkc_num,tb_h195zkc_cplb,tb_h195zkc_jgrq,tb_h195zkc_bz,tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u,tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v,tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_qcsh,tb_h195zkc_pf,tb_h195zkc_cw,tb_h195zkc_mingc,tb_h195zkc_jiagdm) "
                                sqlMt &= " select tb_h195zkc_num2,tb_h195zkc_num,'AOGF',tb_h195zkc_jgrq,'���人�������',   tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u,tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v,tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_qcsh,tb_h195zkc_pf,tb_h195zkc_cw,tb_h195zkc_mingc,tb_h195zkc_jiagdm"
                                sqlMt &= " from tb_h195zkc where tb_h195zkc_ID=" & Labelid.Text & ""
                                Dim iId As Integer = yMt.dbExe(sqlMt, 1)
                                dic = New Dictionary(Of String, String)
                                dic("tb_h195zkc_cplb") = tDr("tb_h195zkc_cplb")
                                dic("tb_h195zkc_mingc") = tDr("tb_h195zkc_mingc")
                                dic("tb_h195zkc_jiagdm") = tDr("tb_h195zkc_jiagdm")
                                dic("tb_h195zkc_sykczl") = tDr("tb_h195zkc_kczl")
                                dic("tb_h195zkc_ckcl") = tDr("tb_h195zkc_kczl")
                                dic("tb_h195zkc_kczl") = tDr("tb_h195zkc_kczl")
                                dic("tb_h195zkc_bz") = DateTime.Now & ":" & "���人�������" & tDr("tb_h195zkc_kczl")
                                For Each s As String In m_ltCk
                                    dic("tb_h195zkc_" & s) = tDr("tb_h195zkc_" & s)
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_h195zkc", dic, "tb_h195zkc_ID=" & iId)
                                yMt.dbExe(sqlMt)
                            End If
                            'д�����������
                            dic = New Dictionary(Of String, String)
                            dic("tb_jch_cplb") = tDr("tb_h195zkc_cplb")
                            dic("tb_jch_num") = ph.Text
                            dic("tb_jch_cz") = "��"
                            dic("tb_jch_sl") = tDr("tb_h195zkc_kczl")
                            dic("tb_jch_rq") = DateTime.Now
                            dic("tb_jch_yt") = "��������"
                            dic("tb_jch_bz") = tb_x825p_rkbz.Text
                            dic("tb_jch_czrgh") = G_dlrgh
                            dic("tb_jch_mingc") = tDr("tb_h195zkc_mingc")
                            dic("tb_jch_jiagdm") = tDr("tb_h195zkc_jiagdm")
                            dic("tb_jch_jiagdmsm") = jgdm.Text
                            yMt.insert("hbcabiodb..tb_jch", dic)
                        Next
                        'sqlMt = "select tb_h195z_id from hbcabiodb..tb_h195z where tb_h195z_num='" & ph.Text & "' and tb_h195z_jiagdm='" &
                        '                                            jgdm.Text & "' and tb_h195z_mingc='" & cpdm.Text & "'"
                        'dtMt = yMt.getDb(sqlMt)
                        'If dtMt.Rows.Count > 0 Then   '��Ʒ���У����Ŵ��붼һ����ô���¿��
                        '    '�ж��Ƿ��Ѿ�������ˣ������²�ID
                        '    If dtMt.YanDtValue2("tb_h195z_glid") <> "" Then
                        '        '�����һ���ĳ�Ʒ����������ˣ���ô������Ӧ�Ŀ��ѡ�����
                        '        sqlMt = "select tb_h195zkc_num, from hbcabiodb..tb_h195zkc where tb_h195zkc_sbtb='tb_h195z' and tb_h195zkc_sbid=" & dtMt.YanDtValue2("tb_h195z_glid")
                        '        dtBind = yMt.getDb(sqlMt)
                        '        dtBind.YanDataBind(f.YanDaTaGridView1)
                        '    Else
                        '        '��һ���ļ�¼������û����⣬��ô���¿��
                        '        MsgBox("�Ѿ������ţ����붼��ͬ�ĳ�Ʒ���ڣ����ں������������ڽ��в�����")
                        '        Return
                        '        'sqlMt = "update hbcabiodb..tb_h195z set tb_h195z_cw='" & cw.Text & "',tb_h195z_m408e=tb_h195z_m408e+ " & kcc &
                        '        '    "  where tb_h195z_id='" & dtMt.YanDtValue2("tb_h195z_id") & "' "
                        '        'yMt.dbExe(sqlMt)
                        '    End If
                        'Else    'û��һ���ļ�¼����ôֱ����⣨�����¼��
                        '    sqlMt = "Insert into hbcabiodb..tb_h195z(tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c,tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_qcsh,tb_h195z_pf,tb_h195z_cw,tb_h195z_mingc,tb_h195z_jiagdm) "
                        '    sqlMt &= " select tb_h195zkc_num2,tb_h195zkc_num,'AOGF',tb_h195zkc_jgrq,'���¹������',   tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u,tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v,tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_qcsh,tb_h195zkc_pf,tb_h195zkc_cw,tb_h195zkc_mingc,tb_h195zkc_jiagdm"
                        '    sqlMt &= " from tb_h195zkc where tb_h195zkc_ID=" & Labelid.Text & ""
                        '    yMt.dbExe(sqlMt)
                        '    '����,
                        'End If
                    Case "tb_x825pkc" 'ë��ת��    
                        'ת�⵽������������ôֱ�ӵ����������Ľ���
                        f = New Frzk("ë��")
                        f.zkzl.Text = kcc
                        f.zkzl.Tag = kcc
                        f.m_strTb = "tb_x825pkc"
                        f.m_strPh = ph.Text
                        f.cplb.Text = m_lv2Dt.YanDtValue2("tb_x825pkc_cplb", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.mingc.Text = m_lv2Dt.YanDtValue2("tb_x825pkc_mingc", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.jiagdm.Text = m_lv2Dt.YanDtValue2("tb_x825pkc_jiagdm", m_frOpen.ListView2.SelectedItems(0).Index)
                        If f.ShowDialog <> DialogResult.OK Then
                            Return
                        End If
                        '�õ��������ʼ����������
                        Dim dtRv As DataTable = f.YanDaTaGridView1.DataSource
                        dtRv.Columns.Remove("rowBs")
                        For Each tDr As DataRow In dtRv.Rows
                            sqlMt = "select * from hbcabiodb..tb_mykc where tb_mykc_num='" & ph.Text &
                            "' and tb_mykc_cplb='" & tDr("tb_x825pkc_cplb") &
                            "' and tb_mykc_mingc='" & tDr("tb_x825pkc_mingc") &
                            "' and tb_mykc_jiagdm='" & tDr("tb_x825pkc_jiagdm") & "'"
                            dtMt = yMt.getDb(sqlMt)
                            If dtMt.Rows.Count > 0 Then
                                '��Ʒ���У����Ŵ��붼һ����ô���¿��
                                dic = New Dictionary(Of String, String)
                                dic("tb_mykc_sykczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_sykczl"))) + CDbl(tDr("tb_x825pkc_kczl"))
                                dic("tb_mykc_ckcl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_ckcl"))) + CDbl(tDr("tb_x825pkc_kczl"))
                                dic("tb_mykc_kczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_kczl"))) + CDbl(tDr("tb_x825pkc_kczl"))
                                dic("tb_mykc_bz") = dtMt.YanDtValue2("tb_mykc_bz") & "," & DateTime.Now & ":" & "���人�������" & tDr("tb_x825pkc_kczl")
                                For Each s As String In m_ltCk
                                    dic("tb_mykc_" & s) = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_" & s))) + CDbl(tDr("tb_x825pkc_" & s))
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_mykc", dic, "tb_mykc_ID=" & dtMt.YanDtValue2("tb_mykc_ID"))
                                yMt.dbExe(sqlMt)
                            Else
                                'û��һ���ģ���ô��д����
                                sqlMt = "Insert into hbcabiodb..tb_mykc(tb_mykc_num2,tb_mykc_num,tb_mykc_jgrq,tb_mykc_qarq,tb_mykc_qaspjg,tb_mykc_qajgsm," &
                                    "tb_mykc_qaczrgh,tb_mykc_qcrq,tb_mykc_qcsh,tb_mykc_qcczrgh,tb_mykc_m387e,tb_mykc_sn, tb_mykc_bzxs,tb_mykc_bf,tb_mykc_yg," &
                                    "tb_mykc_cfdd,tb_mykc_bfmx,tb_mykc_cplb,tb_mykc_kdlk,tb_mykc_cw,tb_mykc_mingc,tb_mykc_jiagdm,tb_mykc_wjbgrq ,tb_mykc_sykcsm," &
                                    "tb_mykc_mynetaa,tb_mykc_r602j,tb_mykc_rkbz,tb_mykc_kczl, tb_mykc_rkts,tb_mykc_sykczl,tb_mykc_t686m,tb_mykc_bz," &
                                    "tb_mykc_czrgh, tb_mykc_gjtzzl,tb_mykc_sjmycc,tb_mykc_v744n)"
                                sqlMt &= " select tb_x825pkc_num2,tb_x825pkc_num,tb_x825pkc_jgrq,tb_x825pkc_qarq,tb_x825pkc_qaspjg,tb_x825pkc_qajgsm,tb_x825pkc_qaczrgh," &
                                    "tb_x825pkc_qcrq,tb_x825pkc_qcsh,tb_x825pkc_qcczrgh,tb_x825pkc_m387e,tb_x825pkc_sn,tb_x825pkc_bzxs,tb_x825pkc_bf,tb_x825pkc_yg,tb_x825pkc_cfdd," &
                                    "tb_x825pkc_bfmx,tb_x825pkc_cplb,tb_x825pkc_kdlk,tb_x825pkc_cw,tb_x825pkc_mingc,tb_x825pkc_jiagdm,tb_x825pkc_wjbgrq,tb_x825pkc_sykcsm ," &
                                    "tb_x825pkc_mynetaa,tb_x825pkc_r602j,tb_x825pkc_rkbz,tb_x825pkc_kczl,tb_x825pkc_rkts,tb_x825pkc_sykczl,tb_x825pkc_t686m,tb_x825pkc_bz," &
                                    "tb_x825pkc_czrgh, tb_x825pkc_r583j,tb_x825pkc_s640k,tb_x825pkc_gjtzy"
                                sqlMt &= " from tb_x825pkc where tb_x825pkc_id=" & Labelid.Text & ""
                                Dim iId As Integer = yMt.dbExe(sqlMt, 1)
                                dic = New Dictionary(Of String, String)
                                dic("tb_mykc_cplb") = tDr("tb_x825pkc_cplb")
                                dic("tb_mykc_mingc") = tDr("tb_x825pkc_mingc")
                                dic("tb_mykc_jiagdm") = tDr("tb_x825pkc_jiagdm")
                                dic("tb_mykc_sykczl") = tDr("tb_x825pkc_kczl")
                                dic("tb_mykc_ckcl") = tDr("tb_x825pkc_kczl")
                                dic("tb_mykc_kczl") = tDr("tb_x825pkc_kczl")
                                dic("#tb_mykc_bz") = "dbo.YanNullToEmpty(tb_mykc_bz,0)+'" & DateTime.Now & ":" & "���人�������" & tDr("tb_x825pkc_kczl") & "'"
                                For Each s As String In m_ltCk
                                    dic("tb_mykc_" & s) = tDr("tb_x825pkc_" & s)
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_mykc", dic, "tb_mykc_ID=" & iId, "#")
                                yMt.dbExe(sqlMt)
                            End If
                            'д�����������
                            dic = New Dictionary(Of String, String)
                            dic("tb_jch_cplb") = tDr("tb_x825pkc_cplb")
                            dic("tb_jch_num") = ph.Text
                            dic("tb_jch_cz") = "��"
                            dic("tb_jch_sl") = tDr("tb_x825pkc_kczl")
                            dic("tb_jch_rq") = DateTime.Now
                            dic("tb_jch_yt") = "��������"
                            dic("tb_jch_bz") = tb_x825p_rkbz.Text
                            dic("tb_jch_czrgh") = G_dlrgh
                            dic("tb_jch_mingc") = tDr("tb_x825pkc_mingc")
                            dic("tb_jch_jiagdm") = tDr("tb_x825pkc_jiagdm")
                            dic("tb_jch_jiagdmsm") = jgdm.Text
                            yMt.insert("hbcabiodb..tb_jch", dic)
                        Next

                        'sqlMt = "select tb_x825p_id from hbcabiodb..tb_x825p where tb_x825p_num='" & ph.Text &
                        '        "' and tb_x825p_jiagdm='" & jgdm.Text & "' and tb_x825p_mingc='" & cpdm.Text & "'"
                        'dtMt = yMt.getDb(sqlMt)
                        'If dtMt.Rows.Count > 0 Then   'ë���У����Ŵ��붼һ����ô���¿��
                        '    '�ж��Ƿ��Ѿ�������ˣ������²�ID
                        '    If dtMt.YanDtValue2("tb_x825p_glid") <> "" Then
                        '        '�����һ����ë�ͣ���������ˣ���ô������Ӧ�Ŀ��ѡ�����
                        '    Else
                        '        '��һ���ļ�¼������û����⣬��ô���¿��
                        '        sqlMt = "update hbcabiodb..tb_x825p set tb_x825p_cw='" & cw.Text & "',tb_x825p_hblsrkzl=tb_x825p_hblsrkzl+ " & kcc &
                        '            " where tb_x825p_id ='" & dtMt.YanDtValue2("tb_x825p_id") & "' "
                        '        yMt.dbExe(sqlMt)
                        '    End If
                        'Else    'û��һ���ļ�¼����ôֱ����⣨�����¼��
                        '    sqlMt = "Insert into cabiodb..tb_x825p(tb_x825p_num2,tb_x825p_num,tb_x825p_jgrq,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_qaczrgh,tb_x825p_qcrq,tb_x825p_qcsh,tb_x825p_qcczrgh,tb_x825p_m387e,tb_x825p_sn,tb_x825p_bzxs,tb_x825p_bf,tb_x825p_yg,tb_x825p_cfdd,tb_x825p_bfmx,tb_x825p_cplb,tb_x825p_kdlk,tb_x825p_cw,tb_x825p_mingc,tb_x825p_jiagdm,tb_x825p_wjbgrq,tb_x825p_sykcsm ,tb_x825p_mynetaa,tb_x825p_r602j,tb_x825p_rkbz,tb_x825p_kczl,tb_x825p_rkts,tb_x825p_sykczl,tb_x825p_t686m,tb_x825p_bz,tb_x825p_czrgh, tb_x825p_r583j,tb_x825p_s640k,tb_x825p_gjtzy,tb_x825p_hblsrkzl) "
                        '    sqlMt &= " select tb_mykc_num2,tb_mykc_num,tb_mykc_jgrq,tb_mykc_qarq,tb_mykc_qaspjg,tb_mykc_qajgsm,tb_mykc_qaczrgh,tb_mykc_qcrq,tb_mykc_qcsh,tb_mykc_qcczrgh,tb_mykc_m387e,tb_mykc_sn, tb_mykc_bzxs,tb_mykc_bf,tb_mykc_yg,tb_mykc_cfdd,tb_mykc_bfmx,tb_mykc_cplb,tb_mykc_kdlk,tb_mykc_cw,tb_mykc_mingc,tb_mykc_jiagdm,tb_mykc_wjbgrq ,tb_mykc_sykcsm ,tb_mykc_mynetaa,tb_mykc_r602j,tb_mykc_rkbz,tb_mykc_kczl, tb_mykc_rkts,tb_mykc_sykczl,tb_mykc_t686m,'���¹������',tb_mykc_czrgh, tb_mykc_gjtzzl,tb_mykc_sjmycc,tb_mykc_v744n, " & kcc & "  "
                        '    sqlMt &= " from tb_mykc where tb_mykc_ID=" & Labelid.Text & ""
                        '    yMt.dbExe(sqlMt)
                        'End If
                End Select
            End If

            Select Case tb_x825p_yg.Text
                Case "����", "����Ʒʵ��"

                    Label11.Text = CDbl(Label11.Text) - CDbl(kc.Text)
                    sykczl = CDbl(Label11.Text)

                    If sykczl < 0 Then
                        MsgBox("�����������ܴ��ڱ��Ͽ�棡")
                        Exit Sub
                    End If
                    sql = "update " & fn & " set " & cwzd & "," & fn & "_bf=" & fn & "_bf-" & kc.Text & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
                Case "��������"
                    '��������ֻ���²ֿ����
                    sql = "update " & fn & " set  " & cwzd & ", " & fn & "_ckcl=" & fn & "_ckcl-" & aaa & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
                Case "����"
                    '����ֻ���¿�������
                    sql = "update " & fn & " set  " & cwzd & "," & fn & "_sykczl=" & sykczl & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
                Case Else
                    'ͬʱ���¿��������Ͳֿ����
                    sql = "update " & fn & " set  " & cwzd & "," & fn & "_ckcl=" & fn & "_ckcl-" & aaa & "," & fn & "_sykczl=" & sykczl & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
            End Select

            yMt.dbExe(sql)

            '���½�������
            ''''''''''
            Dim jiagdmsm As String = ""
            If jgdm.Tag = jgdm.Text Then
                jiagdmsm = ""
            Else
                jiagdmsm = jgdm.Tag
            End If
            '''''''''''''''''
            Dim cpnb As String = ComboBox1.Text '��Ʒ���
            Dim slnum As Double = 0 '����
            If bfs > 0 And (tb_x825p_yg.Text = "����" Or tb_x825p_yg.Text = "����Ʒʵ��") Then '���Ǳ��ϳ�����ʱ�������Ǳ���ֵ
                slnum = bfs
            Else
                slnum = kc.Text
            End If

            '''''''''''''''''''''''' ������������
            Try
                If ReturnTbname(Labelid.Text, Labeltb.Text, StorageOne.Text, StorageOne.Tag, yMt) = False Then
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            ''''''''''''''''''''''''''���������Ӳ���
            sql = "Insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_yt,tb_jch_chts,tb_jch_czrgh,tb_jch_jiagdmsm) values"
            sql &= "('" & cpnb & "','" & cpdm.Text & "','" & jgdm.Text & "','" & ph.Text & "','��'," & bfs & ",'" & sj.Text & "','" & tb_x825p_rkbz.Text & "','" & tb_x825p_yg.Text & "'," & rkts & ",'" & G_dlrgh & "','" & jiagdmsm & "')"
            Dim StrId As String = yMt.dbExe(sql, 1)
            Try
                Dim b As String = Gf_ZdNew(Labeltb.Text, "tb_jch", StorageOne)
                UpdateTbname(StrId, "tb_jch", StorageOne.Text, b, yMt)
            Catch ex As Exception
            End Try
            ''''''''''''''''''''''''''''
            yMt.Commit()
        End Using
        MsgBox("���³ɹ���")

        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub tb_x825p_yg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x825p_yg.SelectedIndexChanged
        If tb_x825p_yg.Text = "����" Or tb_x825p_yg.Text = "����Ʒʵ��" Then

            chts.Text = 0
        End If
    End Sub

    '���
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOne.Click

        If StorageOne.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("�Ѿ�������ص������Ϣ����Ҫ��������ô��", "�������", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        GS_Storage(Me, ButtonOne.Name.Substring(6), kc, Labeltb.Text, Labelid.Text)
    End Sub
End Class