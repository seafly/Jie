Public Class frMOCss

    Private Sub frMOCss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub
    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        showGrid(nian.Text)
    End Sub
    Private Sub showGrid(ByVal str As Integer)

        Dim sj() As String = Split(GF_yuefen(str), ",")
        Dim MOCdb As DataTable = New DataTable
        Dim db2 As DataTable
        Dim aaRow As DataRow
        For i As Integer = 0 To sj.Length - 1 Step 2
            db2 = yiyue(sj(i), sj(i + 1))
            If i = 0 Then
                MOCdb = db2.Clone
                '�����е�Ĭ��ֵΪ0
                For ii As Integer = 1 To MOCdb.Columns.Count - 1
                    MOCdb.Columns(ii).DefaultValue = 0
                Next
            End If
            aaRow = MOCdb.NewRow()
            For j As Integer = 0 To db2.Columns.Count - 1
                If db2.Rows(0)(j) Is DBNull.Value Then
                    aaRow(j) = 0
                Else
                    aaRow(j) = db2.Rows(0)(j)
                End If
            Next
            MOCdb.Rows.Add(aaRow)
        Next
        MOCdb = GF_DataTableChange(MOCdb)
        aaRow = MOCdb.NewRow()
        aaRow(0) = "�¶Ⱥϼ�"
        For i As Integer = 1 To MOCdb.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(MOCdb, i, 0, MOCdb.Rows.Count - 1)
        Next
        MOCdb.Rows.Add(aaRow)

        Call GS_useviewbydb2(ListView1, MOCdb, -1, 70)
        ListView1.Columns(0).Width = 100
        '�����и�
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '�ֱ��ǿ�͸�
        ListView1.SmallImageList = imgList '��������listView��SmallImageList ,��imgList����Ŵ�
    End Sub
    Private Function yiyue(ByVal str1 As Date, ByVal str2 As Date) As DataTable
        Dim sql As String
        Dim db0 As DataTable
        sql = "select '" & Format(str2, "yyyy-MM") & "' AS '�·�',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='�ۼ�1' THEN 1 ELSE 0 END)AS '�ۼ�1 1st powder plant',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='�ۼ�2' THEN 1 ELSE 0 END)AS '�ۼ�2 2nd powder plant',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='Ԥ����' THEN 1 ELSE 0 END)AS 'Ԥ����Biomass drying and extraction',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='�ͼ�' THEN 1 ELSE 0 END)AS '�ͼ�Oil workshop',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='����' THEN 1 ELSE 0 END)AS ����,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='����' THEN 1 ELSE 0 END)AS '����Fermentation',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='�ɹ���' THEN 1 ELSE 0 END)AS '�ɹ���Purshasing Dept.',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='�豸������' THEN 1 ELSE 0 END)AS '�豸������Maintenance Department',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='QC' THEN 1 ELSE 0 END)AS QC,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='QA' THEN 1 ELSE 0 END)AS QA,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='EHS' THEN 1 ELSE 0 END)AS EHS,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='���в�' THEN 1 ELSE 0 END)AS '���в�Operation Dept.',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='���۲�' THEN 1 ELSE 0 END)AS '���۲�Sale Dept.' "
        sql = sql & gzsql() & " from tb_tz "
        sql = sql & "where tb_tz_rq between '" & str1 & "' and '" & str2 & "'"

        db0 = GF_CreateDataSource(G_cnnstr, sql)
        yiyue = db0
    End Function
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "��MOCʵʩͳ��", Me)
    End Sub
    Private Function gzsql() As String
        ' Dim gd As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd")'����
        Dim Sql1 As String = ""
        For i As Integer = 0 To G_bm.Rows.Count - 1
            If G_bm.Rows(i)(1) = "���ܾ���" Or G_bm.Rows(i)(1) = "�ܾ���" Or G_bm.Rows(i)(1) = "��Ŀ��" Or G_bm.Rows(i)(1) = "����" Or G_bm.Rows(i)(1) = "������Ӫ��" Or G_bm.Rows(i)(1) = "�г�Ӫ����" Then
                GoTo xxxx
            End If
            If G_bm.Rows(i)(1) = "�ۼ�������" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='�ۼ�������' and tb_tz_gd='�ۼ�һ����' THEN 1 ELSE 0 END)AS '�ۼ�������/�ۼ�һ����',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='�ۼ�������' and tb_tz_gd='�ۼ�������' THEN 1 ELSE 0 END)AS '�ۼ�������/�ۼ�������',"
            ElseIf G_bm.Rows(i)(1) = "�ͼ�������" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='�ͼ�������' and tb_tz_gd='Ԥ������' THEN 1 ELSE 0 END)AS '�ͼ�������/Ԥ������',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='�ͼ�������' and tb_tz_gd='�ͼ�����' THEN 1 ELSE 0 END)AS '�ͼ�������/�ͼ�����',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='�ͼ�������' and tb_tz_gd='���͹���' THEN 1 ELSE 0 END)AS '�ͼ�������/���͹���',"
            Else
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & "',"
            End If
xxxx:
        Next
        Sql1 = GF_removedh(Sql1)
        gzsql = Sql1
    End Function
    'Private Function gzsql() As String
    '    Dim Sql1 As String = ""
    '    For i As Integer = 0 To G_bm.Rows.Count - 1
    '        Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & " '" & ","
    '    Next
    '    Sql1 = GF_removedh(Sql1)
    '    gzsql = Sql1
    'End Function
End Class