Public Class frxmsg

    Private Sub frxmsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub
    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        showGrid(nian.Text)
    End Sub
    Private Sub showGrid(ByVal str As Integer)
        Dim sql As String
       
        '����Ϊ�ϱ���DataTable��db1
        sql = "select CONVERT(char(7), tb_xmsgbgzzxt_rq, 120) as �·�,"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ͼ�������' THEN 1 ELSE 0 END)AS '�ͼ��������ϱ���',"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ۼ�������' THEN 1 ELSE 0 END)AS '�ۼ��������ϱ���',"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ɹ���' THEN 1 ELSE 0 END)AS �ɹ����ϱ���,"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�豸������' THEN 1 ELSE 0 END)AS '�豸�������ϱ���',"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='QC' THEN 1 ELSE 0 END)AS QC�ϱ���,"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='������' THEN 1 ELSE 0 END)AS '�������ϱ���',"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='QA' THEN 1 ELSE 0 END)AS QA�ϱ���,"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='���в�' THEN 1 ELSE 0 END)AS ���в��ϱ���,"
        'sql = sql & "SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='EHS' THEN 1 ELSE 0 END)AS EHS�ϱ���,"
        sql = sql & gzsql("�ϱ���") & "SUM(1)AS '�ϱ����¶Ⱥϼ�' "
        sql = sql & "from tb_xmsgbgzzxt "
        sql = sql & "where DATEPART(yyyy,tb_xmsgbgzzxt_rq)=" & str & " "
        sql = sql & "GROUP BY CONVERT(char(7), tb_xmsgbgzzxt_rq, 120)"

        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim aaRow As DataRow = db1.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 1 To db1.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(db1, i, 0, db1.Rows.Count - 1)
        Next
        db1.Rows.Add(aaRow)
        db1 = GF_DataTableChange(db1)
        '����Ϊ�����DataTable��db2
        sql = "select CONVERT(char(7), tb_xmsgbgzzxt_wcrq, 120) as �·�,"
        sql = sql & gzsql("���������") & "SUM(1)AS '����������¶Ⱥϼ�' "
        sql = sql & "from tb_xmsgbgzzxt "
        sql = sql & "where DATEPART(yyyy,tb_xmsgbgzzxt_wcrq)=" & str & " and tb_xmsgbgzzxt_wancheng='���' "
        sql = sql & "GROUP BY CONVERT(char(7), tb_xmsgbgzzxt_wcrq, 120)"

        Dim db2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        aaRow = db2.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 1 To db2.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(db2, i, 0, db2.Rows.Count - 1)
        Next
        db2.Rows.Add(aaRow)
        db2 = GF_DataTableChange(db2)
        '����db3�����ںϲ�db1��db2��
        Dim db3 As DataTable = New DataTable
        db3.Columns.Add("����/������", Type.GetType("System.String"))
        For i As Integer = 0 To 11
            db3.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM"), Type.GetType("System.String"))
        Next
        db3.Columns.Add("Total", Type.GetType("System.String"))
        '�����е�Ĭ��ֵΪ0
        For i As Integer = 1 To db3.Columns.Count - 1
            db3.Columns(i).DefaultValue = 0
        Next

        For n As Integer = 0 To db1.Rows.Count - 1
            '�������һ��db1�е�����
            aaRow = db3.NewRow()
            aaRow(0) = db1.Rows(n)(0)
            For ii As Integer = 1 To db3.Columns.Count - 1
                For m As Integer = 1 To db1.Columns.Count - 1
                    If db3.Columns(ii).Caption = db1.Columns(m).Caption Then
                        aaRow(ii) = db1.Rows(n)(m)
                        GoTo ss
                    End If
                Next
ss:
            Next
            db3.Rows.Add(aaRow)
            '�������һ��db2�е�����
            aaRow = db3.NewRow()
            aaRow(0) = db2.Rows(n)(0)
            For ii As Integer = 1 To db3.Columns.Count - 1
                For m As Integer = 1 To db2.Columns.Count - 1
                    If db3.Columns(ii).Caption = db2.Columns(m).Caption Then
                        aaRow(ii) = db2.Rows(n)(m)
                        GoTo ss2
                    End If
                Next
ss2:
            Next
            db3.Rows.Add(aaRow)
        Next
        '��ӡ�������ʡ���
        Dim hs As Integer = db3.Rows.Count
        aaRow = db3.NewRow()
        aaRow(0) = "�������(%)"
        For ii As Integer = 1 To db3.Columns.Count - 1
            If db3.Rows(hs - 1)(ii) > 0 Then
                aaRow(ii) = (db3.Rows(hs - 1)(ii) * 100) / db3.Rows(hs - 2)(ii)
            End If

        Next
        db3.Rows.Add(aaRow)
        '��
        Call GS_useviewbydb2(ListView1, db3, -1, 80)
        ListView1.Columns(0).Width = 200
        '���ñ���ɫ
        With ListView1.Items
            For i As Integer = 0 To 18 Step 4
                .Item(i).SubItems(0).BackColor = Color.LightSkyBlue
                .Item(i + 1).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
            Next
            .Item(19).SubItems(0).BackColor = Color.LightGreen
            .Item(20).SubItems(0).BackColor = .Item(19).SubItems(0).BackColor
            .Item(18).SubItems(0).BackColor = .Item(19).SubItems(0).BackColor
        End With



    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "�������¹�ͳ��", Me)
    End Sub
    Private Function gzsql(ByVal str As String) As String
        ' Dim gd As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd")'����
        Dim Sql1 As String = ""
        For i As Integer = 0 To G_bm.Rows.Count - 1
            If G_bm.Rows(i)(1) = "���ܾ���" Or G_bm.Rows(i)(1) = "�ܾ���" Or G_bm.Rows(i)(1) = "��Ŀ��" Or G_bm.Rows(i)(1) = "����" Or G_bm.Rows(i)(1) = "������Ӫ��" Or G_bm.Rows(i)(1) = "�г�Ӫ����" Then
                GoTo xxxx
            End If
            If G_bm.Rows(i)(1) = "�ۼ�������" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ۼ�������' and tb_xmsgbgzzxt_gd='�ۼ�һ����' THEN 1 ELSE 0 END)AS '�ۼ�������/�ۼ�һ���� " & str & "',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ۼ�������' and tb_xmsgbgzzxt_gd='�ۼ�������' THEN 1 ELSE 0 END)AS '�ۼ�������/�ۼ������� " & str & "',"
            ElseIf G_bm.Rows(i)(1) = "�ͼ�������" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ͼ�������' and tb_xmsgbgzzxt_gd='Ԥ������' THEN 1 ELSE 0 END)AS '�ͼ�������/Ԥ������ " & str & "',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ͼ�������' and tb_xmsgbgzzxt_gd='�ͼ�����' THEN 1 ELSE 0 END)AS '�ͼ�������/�ͼ����� " & str & "',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='�ͼ�������' and tb_xmsgbgzzxt_gd='���͹���' THEN 1 ELSE 0 END)AS '�ͼ�������/���͹��� " & str & "',"
            Else
                Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & str & " '" & ","
            End If
xxxx:
        Next
        gzsql = Sql1
    End Function
    'Private Function gzsql(ByVal str As String) As String
    '    Dim Sql1 As String = ""
    '    For i As Integer = 0 To G_bm.Rows.Count - 1
    '        Sql1 = Sql1 & " SUM(CASE WHEN tb_xmsgbgzzxt_sgbm='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & str & " '" & ","
    '    Next
    '    gzsql = Sql1
    'End Function
End Class