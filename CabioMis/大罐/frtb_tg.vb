Public Class Frtb_tg
    Public _ylnamc, _ylgnamc As String 'ԭ�����ơ�ԭ�Ϲ�����

    '����ԭ�Ϲ޵��޸�ֻ�Ǳ�ʾ�Ƿ����꣬��Ϊ������Ӻ�᲻�ܲ��
    Private Sub frtb_tg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showph()
    End Sub
    '��ʾ������
    Private Sub showph()
        Dim qztemp As String = ClassPhgn.ClassPhgn_Get(_ylgnamc, "-") '�õ���ǰ����+1������
        If qztemp = "" Then
            MsgBox("�����趨����ȷ") : Exit Sub
        End If
        tb_tg_num.Text = qztemp
    End Sub
    Private Sub modfikucun() '���¿��
        '''''''''''''''''''''''''''''''''''�۳�ԭ��
        GS_kcylkc(tb_tg_ph, Me) '����ԭ�Ͽ��
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        'If GF_storelog1("���ԭ�Ϲ�") = False Then
        '    Exit Sub
        'End If ' �ж��Ƿ���Ȩ��

        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If

        If tb_tg_num.Text.trim  ="" Then
            MsgBox("���Ų���Ϊ�գ�")
            Return
        End If

        Dim sql As String = "select * from tb_tg where tb_tg_num='" & tb_tg_num.Text & "'"
        If Cl_DataMag.GF_CreateDataSource(sql).Rows.Count > 0 Then
            MsgBox("������ͬ�����ţ�")
            Return
        End If

        '''''''''�жϱ���''''''''''''

        If GF_YZSJ(Me, "") = False Then '��֤�ؼ�
            Exit Sub
        End If

        ''''''''''''''''''''�ϼƻ���
        GS_hjkcylkc(tb_tg_ph, tb_tg_zl, Me)
        ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
        Dim ylstr As String = Gf_pdylkc(tb_tg_ph, Me)
        If ylstr <> "" Then '
            MsgBox(ylstr) : Exit Sub
        End If
        ''''''''''''''''''''
        Dim tj As Double = tb_tg_tj.Text '���
        Dim hsgx As Double = tb_tg_zl.Text / tj '�õ������ϵ
        tb_tg_hsgx.Text = hsgx
        Dim jj As String = GF_addsj(Labeltb.Text, Me)   '�������
        If jj = "" Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If
        GS_kcylkc(tb_tg_ph, Me) '����ԭ�Ͽ��
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
        GS_storelog3("���ԭ�Ϲޣ�" & tb_tg_num.Text.Trim, "���ԭ�Ϲ�") '���浽��־
        MsgBox("���")
        ClassPhgn.ClassPhgn_SetDqz2(_ylgnamc) 'ʹ��ǰ����+1
        showph() '��ʾ������
        showsearch()
        ''''''''''''''''''
    End Sub

    Private Sub tb_tg_ph_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_tg_ph.MouseDoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
        Dim yllb As String = tb_tg_yldm.Text
        yllb = DeepCode.DeepDoStr.GF_zhzfccx(yllb)
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a in(" & yllb & ")")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, _ylnamc)
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub BTN_SEARCH_Click(sender As System.Object, e As System.EventArgs) Handles BTN_SEARCH.Click

        showsearch()
    End Sub
    Private Sub showsearch()
        Dim tt1, tt2 As String
        tt1 = DateTimePicker1.Text
        tt2 = DateTimePicker2.Text
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Dim _yldm As String = tb_tg_yldm.Text 'ԭ�ϴ���
        Dim sql As String = "select * from tb_tg where tb_tg_yldm in ('" & _yldm & "') and tb_tg_rq between '" & tt1 & "' and '" & tt2 & "' " '������0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(listview1, dt, "0", True, True)
        GroupBox1.Text = dt.Rows.Count & "������,˫���޸��������δ����"
    End Sub
    Private Sub listview1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listview1.MouseDoubleClick
        With listview1
            If .SelectedRows.Count = 0 Then
                Exit Sub
            End If
            Dim czid As Integer = .SelectedRows(0).Cells("tb_tg_ID").Value
            Dim ph As String = .SelectedRows(0).Cells("tb_tg_num").Value
            Dim oldyw As String = DeepCode.DeepDoStr.Null2String(.SelectedRows(0).Cells("tb_tg_yw").Value) 'ԭ���Ƿ�����
            Dim yw As String = "��"
            If oldyw = "��" Then
                yw = "��"
            End If
            If MsgBox("����" & ph & "����״̬Ϊ��" & yw & "����", 1, "��ʾ") <> MsgBoxResult.Ok Then Return
            GS_upztxx(G_cnnstr, "update tb_tg set tb_tg_yw='" & yw & "' where tb_tg_id=" & czid)
            GS_storelog3("����" & ph & "����״̬Ϊ��" & yw & "��", "����ԭ�Ϲ�") '���浽��־
            MsgBox("���")
            showsearch()
        End With

    End Sub

    Private Sub BTN_EXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EXCEL.Click
        GS_toexcel(listview1, Me.Text, Me)
    End Sub
End Class