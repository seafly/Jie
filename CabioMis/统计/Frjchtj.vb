Public Class Frjchtj


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("��ʱ��Ӧ��С�ڵ���ֹʱ��") : Return
        End If
        '''''''''''''''
        Dim sql As String = "select * from tb_ckyt"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Dim dt0 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select top 1 tb_cpycrktj_tjq, tb_cpycrktj_cplb,tb_cpycrktj_mingc,tb_cpycrktj_jiagdm,tb_cpycrktj_qcl,tb_cpycrktj_rkzl,tb_cpycrktj_ckzl,tb_cpycrktj_qmkc,tb_cpycrktj_sckc,tb_cpycrktj_xskc,tb_cpycrktj_sykc,tb_cpycrktj_kcqy,tb_cpycrktj_xhkc,tb_cpycrktj_wjgkc,tb_cpycrktj_fgkc,tb_cpycrktj_zpfgkc,tb_cpycrktj_bfpsykc,tb_cpycrktj_scllkc,tb_cpycrktj_sdkc,tb_cpycrktj_sjqykc,tb_cpycrktj_khykc,tb_cpycrktj_bzshkc,tb_cpycrktj_whgckc from tb_cpycrktj")
        dt0.Clear()
        '' ''Dim dt0 As New DataTable
        '' ''With dt0
        '' ''    .Columns.Add("ͳ����", GetType(String))
        '' ''    .Columns.Add("��Ʒ����", GetType(String))
        '' ''    .Columns.Add("��Ʒ����", GetType(String))
        '' ''    .Columns.Add("�ӹ�����", GetType(String))
        '' ''    .Columns.Add("�ڳ���", GetType(Double))
        '' ''    .Columns.Add("�������", GetType(Double))
        '' ''    .Columns.Add("��������", GetType(Double))
        '' ''    .Columns.Add("��ĩ���", GetType(Double))
        '' ''    .Columns.Add("��������", GetType(Double))
        '' ''    .Columns.Add("���۳���", GetType(Double))
        '' ''    .Columns.Add("ʵ�����", GetType(Double))
        '' ''    .Columns.Add("���ȡ������", GetType(Double))
        '' ''    .Columns.Add("���ٳ���", GetType(Double))
        '' ''    .Columns.Add("��ӹ�����", GetType(Double))
        '' ''    .Columns.Add("��������(����������)", GetType(Double))
        '' ''    .Columns.Add("������������", GetType(Double))
        '' ''    .Columns.Add("����Ʒʵ�����", GetType(Double))
        '' ''    .Columns.Add("�������ϳ���", GetType(Double))
        '' ''    .Columns.Add("��������", GetType(Double))
        '' ''    .Columns.Add("�̼�ȡ������", GetType(Double))
        '' ''    .Columns.Add("�ͻ�������", GetType(Double))
        '' ''    .Columns.Add("��װ��ĳ���", GetType(Double))
        '' ''    .Columns.Add("�人��������", GetType(Double))
        '' ''    '.Columns.Add("��Ӧ������ID", GetType(String))

        '' ''End With
        'Dim zz As String = GF_getstringsql(G_cnnstr, "select tb_jch_cplb from tb_jch where tb_jch_cz ='��' and tb_jch_rq between '" & tt1 & "' and '" & tt2 & "'  group by tb_jch_cplb ", "")
        ''If zz = "" Then
        ''    'GS_DataGridViewbyDb(showl, dt0, False, True)
        ''    'Return
        ''End If
        ''Dim l() As String = {"APG10", "APG15", "APGK", "AOG40", "AOGC", "������"}
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='��Ч'and tb_cpdmhz_cplx  not in ('���͹�' ,'������','һ����','���ӹ�')  ")
       

        For Q As Integer = 0 To dt1.Rows.Count - 1
            '������������������������������������������������������������
            Dim m As DataRow = dt0.NewRow
            ''''''''''''''''''''''''''''''
            Dim dd As DateTime = DateTimePicker1.Text
            Dim dd2 As DateTime = DateTimePicker2.Text 'ͳ����ֹ
            Dim tjq As DateTime = DateAdd(DateInterval.Day, -1, dd) 'ͳ�������㷨ΪDateTimePicker1����ֵ-1
            m(0) = Replace(DateAdd(DateInterval.Day, -1, dd), "-", "0") & "-" & Replace(dd2, "-", "0") '��Ϊ�������ݿ��ͳ����
           
            '''''''''''''''''''''''''''''

            m(1) = dt1.Rows(Q)(1) '��Ʒ����
            m(2) = dt1.Rows(Q)(2) '��Ʒ����
            m(3) = dt1.Rows(Q)(3) '�ӹ�����
            '''''''''''''''''''''''
            Dim jjj As String = "" 'ͨ����Ʒ��������ڳ���
          
            jjj = "select tb_sjbf_ckcl from tb_sjbf where (1=1)    and tb_sjbf_rq= '" & tjq & "' and tb_sjbf_cplb='" & dt1.Rows(Q)(1) & "' and tb_sjbf_mingc ='" & dt1.Rows(Q)(2) & "' and tb_sjbf_jiagdm ='" & dt1.Rows(Q)(3) & "' "
            '''''''''''''''�����tb_sjbf����û������Ϊͳ�������������ݣ�˵�����ձ���ʱ����Ӧ���ݵĴ���Ϊ��
            Try
                Dim jjjj As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, jjj)
                m(4) = DeepCode.DeepDoStr.Null2String(jjjj.Rows(0)(0))
            Catch ex As Exception
                m(4) = DBNull.Value
            End Try


            '''''''''''''''''''''''
            sql = "select sum(tb_jch_sl) from tb_jch  where tb_jch_rq between '" & tt1 & "' and '" & tt2 & "'and  "
            sql &= "tb_jch_cz='��' and tb_jch_cplb='" & dt1.Rows(Q)(1) & "' and tb_jch_mingc ='" & dt1.Rows(Q)(2) & "' and tb_jch_jiagdm ='" & dt1.Rows(Q)(3) & "' "

            Dim dt11 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            m(5) = DeepCode.DeepDoStr.Null2zero(dt11.Rows(0)(0))
            '''''''''''''''''''''''''''''''''''''''''
            sql = "select sum(tb_jch_sl) from tb_jch  where tb_jch_rq between '" & tt1 & "' and '" & tt2 & "'and  "
            sql &= "tb_jch_cz='��'and tb_jch_cplb='" & dt1.Rows(Q)(1) & "' and tb_jch_mingc ='" & dt1.Rows(Q)(2) & "' and tb_jch_jiagdm ='" & dt1.Rows(Q)(3) & "'" '���з�������;֮�;��ǳ�������

            dt11 = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            m(6) = DeepCode.DeepDoStr.Null2zero(dt11.Rows(0)(0))
          
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

            For I As Integer = 0 To dt.Rows.Count - 1
                Dim jj2 As String = dt.Rows(I)("tb_ckyt_mc")
                sql = "select sum(tb_jch_sl) from tb_jch  where tb_jch_rq between '" & tt1 & "' and '" & tt2 & "'and  "
                sql &= "tb_jch_cz='��' and tb_jch_cplb='" & dt1.Rows(Q)(1) & "' and tb_jch_mingc ='" & dt1.Rows(Q)(2) & "' and tb_jch_jiagdm ='" & dt1.Rows(Q)(3) & "' and tb_jch_yt='" & jj2 & "'"
                dt11 = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                'MsgBox(DeepCode.DeepDoStr .Null2String () dt11.Rows(0)(0))
                m(8 + I) = DeepCode.DeepDoStr.Null2zero(dt11.Rows(0)(0))

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            If m(4) Is DBNull.Value Then   '����ڳ���Ϊ�� ����ĩ�����ʾΪ��
                m(7) = DBNull.Value
            Else
                Dim ii As Double = Null2zero2(m(4)) + m(5) - m(6)

                m(7) = ii - m(6) '��ĩ���=�ڳ�+���-����-��������
            End If


            '''''''''''''''''''''''''''''''''''''''''''
            Dim js As Integer = 0 ''''�ж�����������ݵ����в�ѯ��������ֵ��Ϊ0 ����ʾ����
            For pd As Integer = 4 To 8 + dt.Rows.Count - 1
                If Null2zero2(m(pd)) <> 0 Then
                    dt0.Rows.Add(m)
                    Exit For
                End If
            Next


           


        Next
        'If dt0.Rows.Count = 0 Then
        '    MsgBox("���κμ�¼")
        '    Return
        'End If
        '����Ӧ�úϼƹ�ʽ�ϼ�=AOGC*0.92*0.94*0.98+AOG40*0.94*0.98+APGK/4+APG15/4+APG10/4+������*0.94*0.98
        'With dt0
        '    Dim m2 As DataRow = .NewRow
        '    '''''''''''''''''''''''''''''''''''''
        '    m2(0) = "Total (Equivalent as 40% ARA )"
        '    Dim l1h As Double = 0
        '    For i As Integer = 1 To .Columns.Count - 1
        '        l1h = .Rows(0)(i) / 4 + .Rows(1)(i) / 4 + .Rows(2)(i) / 4 + .Rows(3)(i) * 0.94 * 0.98 + .Rows(4)(i) * 0.94 * 0.98 * 0.92 + .Rows(5)(i) * 0.94 * 0.98
        '        m2(i) = FormatNumber(l1h, 2)
        '    Next
        '    '''''''''''''''''''''''''''''''''''''''''''
        '    dt0.Rows.Add(m2)

        'End With

        '��������������������������������������������������������������������������������������������
        GS_DataGridViewbyDb(showl, dt0, True, True)
        showl.Columns(0).Width = 200
        Button3.Enabled = True
        'GS_ysgx(showl) '������һ����ɫ����
    End Sub

    Private Sub wz()
        With showl
            .Width = Me.Width - .Left - 20
            .Height = Me.Height - .Top - 30
        End With
    End Sub
    Private Sub Frjchtj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        DateTimePicker1.Text = tjqq(Now)
        Try '���
            nian1.Items.Clear()
            Dim sqi As String = "select tb_cpycrktj_bz from tb_cpycrktj group by tb_cpycrktj_bz"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqi)
            For i As Integer = 0 To dt.Rows.Count - 1
                nian1.Items.Add(dt.Rows(i)(0))
            Next
            nian1.SelectedIndex = 0
            Button3.Enabled = False
        Catch ex As Exception

        End Try
        wz()

    End Sub

    Private Sub jchtj_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, DateTimePicker1.Text & "��" & DateTimePicker2.Text & Me.Text, Me)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sql As String = "select  tb_cpycrktj_tjq, tb_cpycrktj_cplb,tb_cpycrktj_mingc,tb_cpycrktj_jiagdm,tb_cpycrktj_qcl,tb_cpycrktj_rkzl,tb_cpycrktj_ckzl,tb_cpycrktj_qmkc,tb_cpycrktj_sckc,tb_cpycrktj_xskc,tb_cpycrktj_sykc,tb_cpycrktj_kcqy,tb_cpycrktj_xhkc,tb_cpycrktj_wjgkc,tb_cpycrktj_fgkc,tb_cpycrktj_zpfgkc,tb_cpycrktj_bfpsykc,tb_cpycrktj_scllkc,tb_cpycrktj_sdkc,tb_cpycrktj_sjqykc,tb_cpycrktj_khykc,tb_cpycrktj_bzshkc,tb_cpycrktj_whgckc from tb_cpycrktj where tb_cpycrktj_bz= '" & nian1.Text & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt, True, True)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.showl.Rows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("���汨��������صļ�¼����ȷ����", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        Dim n As Integer = Me.showl.Columns.Count
        If ccrsdb(Me.showl, "tb_cpycrktj") = True Then
            'Call GS_sd("tb_x832p", Me.showl.Rows(0).Cells(n - 2).Value, G_dlrgh)
            MsgBox("��ɱ������ݱ���")
            Button3.Enabled = False
        End If
        Try '���
            nian1.Items.Clear()
            Dim sqi As String = "select tb_cpycrktj_bz from tb_cpycrktj group by tb_cpycrktj_bz"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqi)
            For i As Integer = 0 To dt.Rows.Count - 1
                nian1.Items.Add(dt.Rows(i)(0))
            Next
            nian1.SelectedIndex = 0
            Button3.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    'strtb2�����������ID����
    Public Function ccrsdb(ByVal list1 As Control, ByVal strtb2 As String) As Boolean
        ccrsdb = False
        Try
            Dim dd As DateTime = DateTimePicker1.Text
            Dim dd2 As DateTime = DateTimePicker2.Text 'ͳ����ֹ
            Dim bz As Object = InputBox("������", "��ʾ", Replace(DateAdd(DateInterval.Day, -1, dd), "-", "0") & "-" & Replace(dd2, "-", "0"))
            If bz Is "" Then
                Exit Function
            End If
            Dim lt As DataGridView = list1
            For k As Integer = 0 To lt.Rows.Count - 1
                Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
                cnn.ConnectionString = G_cnnstr
                cnn.Open()
                Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
                RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                RS.addnew()
                Dim dtsj As DataTable = showl.DataSource
                For j As Integer = 0 To dtsj.Columns.Count - 1
                    RS(dtsj.Columns(j).ColumnName).value = lt.Rows(k).Cells(dtsj.Columns(j).ColumnName).Value
                Next
                RS("tb_cpycrktj_bz").value = bz
                RS.update()
                RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

            Next

            ccrsdb = True
        Catch ex As Exception
            MsgBox("���ݴ������") : ccrsdb = False : Exit Function
        End Try
    End Function
    Function sz(ByVal strysj As String, ByVal strlb As String)
        If strysj = "" Then
            Return strlb
        End If
        If InStr("," & strysj & ",", "," & strlb & ",") = 0 Then
            strysj &= "," & strlb
        End If
        Return strysj
    End Function
    Private Function tjqq(ByVal rq As DateTime) As DateTime '�õ��������ڵ�����������
        rq = GF_gettrqsj(Now)
        tjqq = DateAdd(DateInterval.Day, -Weekday(Now), Now)
    End Function
End Class