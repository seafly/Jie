Module Md_Yw4
    ''''''''''''''''''''''''''''''����3��������Ҫ��֤���Ų���������ı���ѯ
    Public Sub GS_FaceSearch(ByVal ComboBoxName As ComboBox, ByVal tbname As String, ByVal dowhat As Integer,Optional ByVal pDefaultText As string="")
        Dim db As DataTable = GF_GetFieldByTbName(tbname, dowhat)
        GS_wlbktlr2(ComboBoxName, db, 4, pDefaultText) '��ʾ�ֶ�������
        ComboBoxName.Tag = db '�󶨵����������ȥ
    End Sub
    '���ݱ����Ƶõ�������͵��ֶε�DB
    Public Function GF_GetFieldByTbName(ByVal tbname As String, ByVal dowhat As Integer) As DataTable
        '�õ����������ֶ�\
        Dim sql As String = ""
        Select Case dowhat
            Case 0 '�������������ֶ�
                sql = " and tb_biaozdinf_lx in('tinyint','int','money','smallint')"
            Case 1 '���������ı��ֶ�
                sql = " and tb_biaozdinf_lx in('varchar(8000)')"
            Case 2 '������������ʱ���ֶ�
                sql = " and tb_biaozdinf_lx in('datetime','smalldatetime')"
            Case 3 '��������
            Case 4
            Case 2 '������������ʱ���ֶ�
                sql = " and tb_biaozdinf_lx in('tinyint','int','money','smallint','varchar(8000)')"
        End Select
        Dim db As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(_D.G_zdinf, "tb_biaozdinf_biao='" & tbname & "'" & sql)
        Return db
    End Function
    'Datatable ��׺����
    Public Function GF_FaceSearchBDS(ByVal ComboBoxName As ComboBox, ByVal TextboxName As TextBox) As String
        Dim cxkr As String = TextboxName.Text.Trim
        If cxkr = "" Then
            Return ""
        End If
        cxkr = Replace(cxkr, "��", "'")
        Dim zdzw As String = ComboBoxName.Text
        If zdzw = "" Then
            Return ""
        End If
        Dim db As DataTable = CType(ComboBoxName.Tag, DataTable)
        '�õ�Ӣ���ֶ���
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like '%" & cxkr & "%'"
        Return sql
    End Function
   
    '����3��������Ҫ��֤���Ų���������ı���ѯ
    Public Sub GS_ysgx(ByVal str As DataGridView) 'DataGridVie���һ����ɫ����

        With str
            Dim n As Integer = .Rows.Count
            If n > 0 Then
                For i As Integer = 0 To .Columns.Count - 1
                    .Rows(n - 1).Cells(i).Style.BackColor = Color.GreenYellow
                Next
            End If

        End With

    End Sub
    'ȷ��ʱ���ѡ���Ƿ���ȷ
    Public Function GF_qdsjdx(ByVal sj1 As String, ByVal sj2 As String) As Boolean
        Dim tt1, tt2 As DateTime
        tt1 = sj1 : tt2 = sj2
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("��ʱ��Ӧ��С�ڵ���ֹʱ��") : Return False
        Else
            Return True
        End If
    End Function
    '���ֱ���޸�ֻ�в����˺͹���Ա��Ȩ�޵��ж�
    Public Function GF_qdxgjsqx(ByVal sjid As String, ByVal sjbm As String, ByVal sjjs As String, ByVal sjgh As String) As Boolean
        If sjjs = "����Ա" Then
            Return True
        Else
            Dim zd As String = sjbm & "_czrgh"
            Dim sql As String = "select " & zd & " from " & sjbm & " where " & sjbm & "_id=" & sjid '�õ����ݵĹ���
            Dim dttemp As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            Dim cxgh As String = dttemp.Rows(0)(0)
            If cxgh <> sjgh Then
                MsgBox("��û���޸ĵ�Ȩ��") : Return False
            Else
                Return True
            End If
        End If

    End Function
End Module
