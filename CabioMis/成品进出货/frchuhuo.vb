Public Class frchuhuo
    Private g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='��Ч' order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ")
    Private Sub frchuhuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Case "tb_h195zkc"
                tb_x825p_yg.Text = "��������"
            Case "tb_x832pkc"
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

        GS_upztxx(G_cnnstr, sql)

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
            If ReturnTbname(Labelid.Text, Labeltb.Text, StorageOne.Text, StorageOne.Tag) = False Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        ''''''''''''''''''''''''''���������Ӳ���
        sql = "Insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_yt,tb_jch_chts,tb_jch_czrgh,tb_jch_jiagdmsm) values"
        sql &= "('" & cpnb & "','" & cpdm.Text & "','" & jgdm.Text & "','" & ph.Text & "','��'," & bfs & ",'" & sj.Text & "','" & tb_x825p_rkbz.Text & "','" & tb_x825p_yg.Text & "'," & rkts & ",'" & G_dlrgh & "','" & jiagdmsm & "')"
        Dim StrId As String = GF_upztxx2(G_cnnstr, sql, "tb_jch")
        Try
            Dim b As String = Gf_ZdNew(Labeltb.Text, "tb_jch", StorageOne)
            UpdateTbname(StrId, "tb_jch", StorageOne.Text, b)
        Catch ex As Exception
        End Try
        ''''''''''''''''''''''''''''

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