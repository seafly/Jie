Public Class Frmodjch

    Dim oldjchsl As Double '������¼��ԭʼ��������
    Dim oldyt As String '������¼��ԭʼ��;
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        If Labelid.Text <> "" Then
            If tb_jch_xgsm.Text.Trim = "" Then
                MsgBox("������д�޸�˵��") : Exit Sub
            End If
            '''''''''''''''''''''''''''''
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim lbtb As DataTable = getjchlbb() '�õ�����������Ӧ�ı�
            Dim bm As String = DeepCode.DeepDoDataTable.GF_cnwithen(lbtb, "t1='" & tb_jch_cplb.Text & "'", 2)
            If bm = "" Then '�õ�������
                MsgBox("δ���ҵ����������") : Exit Sub
            End If
            lbtb = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select " & bm & "_id from " & bm & " where " & bm & "_num='" & tb_jch_num.Text & "'and " & bm & "_mingc='" & tb_jch_mingc.Text & "'and " & bm & "_jiagdm='" & tb_jch_jiagdm.Text & "'")
            If lbtb.Rows.Count = 0 Then
                MsgBox("δ���ҵ�����������") : Exit Sub
            End If
            Dim bmid As String = lbtb.Rows(0)(0) '�õ�������ID
            hyoldsl(bm, bmid)  '��ԭ������
            newcz(bm, bmid) '���¿�����
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸Ľ�����", "�޸Ľ�������" & tb_jch_num.Text & "��ԭ��" & tb_jch_xgsm.Text.Trim) '���浽��־



            MsgBox("�����ɹ�����������Ҫˢ�²�ѯ���ָ���")
        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("���ƫ��̨��") = False Then
            '    Exit Sub
            'End If ' �ж��Ƿ���Ȩ��
            'Dim jj As String = GF_addsj(Labeltb.Text, Me)
            'If jj = "" Then
            '    MsgBox("����������Ŀ������") : Exit Sub
            'End If
            'GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            'GS_storelog3("��ӽ�����", "��ӽ�����") '���浽��־
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("��ȷ��ɾ��������¼��?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''��־Ȩ���ж�
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("ɾ��������", "ɾ����������" & tb_jch_num.Text & "��ԭ��" & tb_jch_xgsm.Text.Trim) '���浽��־
            MsgBox("�����ɹ�����������Ҫˢ�²�ѯ���ָ���")
            Me.Close()

        End If
    End Sub

    Private Sub Frmodjch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Call GS_wlbktlr2(tb_jch_yt, kk, 1, "")

        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            'Button3.Visible = True
        End If
        ''''''''''''''''''' '�޸�ʱ�� = ϵͳʱ��
        Dim StrXg As String = Now.Date & " " & Now.TimeOfDay.ToString
        Dim IntXg As Integer = InStrRev(StrXg, ".")
        tb_jch_xgrq.Text = Microsoft.VisualBasic.Left(StrXg, IntXg - 1)
        ''''''''''''''
        oldjchsl = tb_jch_sl.Text.Trim '������¼��ԭʼ��������
        oldyt = tb_jch_yt.Text '������¼��ԭʼ��;
        GS_qhjd(Me) '�س����л����㣬��ע����
    End Sub
    '�޸Ľ������Ĺ�������㷨

    Private Sub hyoldsl(ByVal strbiao As String, ByVal strbiaoid As String)  '��ԭ������
        Dim zd1 As String = strbiao & "_ckcl" '�ֿ�����ֶ�
        Dim zd2 As String = strbiao & "_sykczl" 'ʣ�����ֶ�
        Dim zd3 As String = strbiao & "_kczl" '�������
        Dim sql As String = "update " & strbiao & " set "
        Select Case tb_jch_cz.Text
            Case "��" '����κ���;����ͬʱ�۳���������ֶ�
                sql &= zd1 & "=" & zd1 & "-" & oldjchsl
                sql &= "," & zd2 & "=" & zd2 & "-" & oldjchsl
                sql &= "," & zd3 & "=" & zd3 & "-" & oldjchsl
            Case "��"
                Select Case oldyt
                    Case "��������"
                        sql &= zd1 & "=" & zd1 & "+" & oldjchsl
                    Case "����"
                        sql &= zd2 & "=" & zd2 & "+" & oldjchsl
                    Case Else
                        sql &= zd1 & "=" & zd1 & "+" & oldjchsl
                        sql &= "," & zd2 & "=" & zd2 & "+" & oldjchsl
                End Select
        End Select
        sql &= " where " & strbiao & "_id=" & strbiaoid
        Call GS_upztxx(G_cnnstr, sql)
    End Sub

    Private Sub newcz(ByVal strbiao As String, ByVal strbiaoid As String) '�޸ĺ����
        Dim xghsl As Double = tb_jch_sl.Text.Trim '�޸ĺ������
        Dim zd1 As String = strbiao & "_ckcl" '�ֿ�����ֶ�
        Dim zd2 As String = strbiao & "_sykczl" 'ʣ�����ֶ�
        Dim zd3 As String = strbiao & "_kczl" '�������
        Dim sql As String = "update " & strbiao & " set "
        Select Case tb_jch_cz.Text
            Case "��" '����κ���;����ͬʱ������������ֶ�
                sql &= zd1 & "=" & zd1 & "+" & xghsl
                sql &= "," & zd2 & "=" & zd2 & "+" & xghsl
                sql &= "," & zd3 & "=" & zd3 & "+" & xghsl
            Case "��"
                Select Case tb_jch_yt.Text
                    Case "��������"
                        sql &= zd1 & "=" & zd1 & "-" & xghsl
                    Case "����"
                        sql &= zd2 & "=" & zd2 & "-" & xghsl
                    Case Else
                        sql &= zd1 & "=" & zd1 & "-" & xghsl
                        sql &= "," & zd2 & "=" & zd2 & "-" & xghsl
                End Select
        End Select
        sql &= " where " & strbiao & "_id=" & strbiaoid
        Call GS_upztxx(G_cnnstr, sql)
    End Sub
    '�õ�����������Ӧ�ı�
    Private Function getjchlbb() As DataTable
        Dim a As New DataTable
        a.Columns.Add("t1", GetType(String)) : a.Columns.Add("t2", GetType(String)) : a.Columns.Add("t3", GetType(String))
        Dim d As DataRow = a.NewRow
        d(0) = "AOG40" : d(1) = "��Ʒ��" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "������" : d(1) = "��Ʒ��" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOG40 HB" : d(1) = "��Ʒ��" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOGC" : d(1) = "ë��" : d(2) = "tb_x825pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APG10" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APG15" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APGK" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APG10B" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOG40A" : d(1) = "��Ʒ��" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOGF" : d(1) = "��Ʒ��" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APGE" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APGT" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "DOGK" : d(1) = "��Ʒ��" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        Return a
    End Function
End Class