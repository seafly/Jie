Public Class frspaqwswc

    Private Sub frspaqwswc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub
    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        showGrid(nian.Text)
    End Sub
    Private Sub showGrid(ByVal str As Integer)
        Dim sj() As String = Split(GF_yuefen(str), ",")
        Dim db1 As DataTable = New DataTable
        Dim db2 As DataTable = New DataTable
        Dim db_temp As DataTable = New DataTable
        Dim aaRow As DataRow
        '�ƻ������
        For i As Integer = 0 To sj.Length - 1 Step 2
            db_temp = yiyue(sj(i), sj(i + 1), "�ƻ������")
            If i = 0 Then
                db1 = db_temp.Clone
            End If
            aaRow = db1.NewRow()
            For j As Integer = 0 To db_temp.Columns.Count - 1
                aaRow(j) = db_temp.Rows(0)(j)
            Next
            db1.Rows.Add(aaRow)
        Next
        'ʵ�������
        For i As Integer = 0 To sj.Length - 1 Step 2
            db_temp = yiyue(sj(i), sj(i + 1), "ʵ�������")
            If i = 0 Then
                db2 = db_temp.Clone
            End If
            aaRow = db2.NewRow()
            For j As Integer = 0 To db_temp.Columns.Count - 1
                aaRow(j) = db_temp.Rows(0)(j)
            Next
            db2.Rows.Add(aaRow)
        Next

        '����db3�����ںϲ�db1��db2��
        Dim db3 As DataTable = New DataTable
        db3.Columns.Add("������", Type.GetType("System.String"))
        For i As Integer = 0 To 11
            db3.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM") & "����", Type.GetType("System.String"))
            db3.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM") & "����", Type.GetType("System.String"))
        Next
        ''�����е�Ĭ��ֵΪ0
        'For i As Integer = 1 To db3.Columns.Count - 1
        '    db3.Columns(i).DefaultValue = "0"
        'Next

        '�������db1�е�����
        'Dim aaRow As DataRow
        aaRow = db3.NewRow()
        aaRow(0) = "�ƻ������"
        For n As Integer = 0 To db1.Rows.Count - 1
            For m As Integer = 1 To db3.Columns.Count - 1 Step 2
                If CDate(Microsoft.VisualBasic.Left(db3.Columns(m).Caption, 7)) = CDate(db1.Rows(n)(0)) Then
                    aaRow(m) = db1.Rows(n)(1) '����ƻ������
                    aaRow(m + 1) = db1.Rows(n)(2) '����ƻ������
                    GoTo xx
                End If
            Next
xx:
        Next
        db3.Rows.Add(aaRow)
        '�������db2�е�����
        aaRow = db3.NewRow()
        aaRow(0) = "ʵ�������"
        For n As Integer = 0 To db2.Rows.Count - 1
            For m As Integer = 1 To db3.Columns.Count - 1 Step 2
                If CDate(Microsoft.VisualBasic.Left(db3.Columns(m).Caption, 7)) = CDate(db2.Rows(n)(0)) Then
                    aaRow(m) = db2.Rows(n)(1) '����ʵ�������
                    aaRow(m + 1) = db2.Rows(n)(2) '����ʵ�������
                    GoTo xx2
                End If
            Next
xx2:
        Next
        db3.Rows.Add(aaRow)
        ''�����е�Ĭ��ֵΪ0
        For i As Integer = 1 To db3.Columns.Count - 1
            db3.Columns(i).DefaultValue = "0"
        Next
        '��ӡ�����ʡ���
        aaRow = db3.NewRow()
        aaRow(0) = "�����(%)"
        For ii As Integer = 1 To db3.Columns.Count - 1
            If db3.Rows(0)(ii) > 0 Then
                aaRow(ii) = Format(db3.Rows(1)(ii) / db3.Rows(0)(ii), "0.00%")
            End If
        Next
        db3.Rows.Add(aaRow)
        '��ӡ������(�ϼ�)����
        aaRow = db3.NewRow()
        aaRow(0) = "����ʺϼ�(%)"
        For ii As Integer = 1 To db3.Columns.Count - 1 Step 2
            If db3.Rows(0)(ii) + db3.Rows(0)(ii + 1) > 0 Then
                aaRow(ii) = Format(db3.Rows(1)(ii) + db3.Rows(1)(ii + 1) / db3.Rows(0)(ii) + db3.Rows(0)(ii + 1), "0.00%")
            Else
                aaRow(ii) = 0
            End If

            aaRow(ii + 1) = aaRow(ii)
        Next
        db3.Rows.Add(aaRow)
        '��
        Call GS_useviewbydb2(ListView1, db3, -1, 90)
        '�����и�
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '�ֱ��ǿ�͸�
        ListView1.SmallImageList = imgList '��������listView��SmallImageList ,��imgList����Ŵ�

    End Sub
    Private Function yiyue(ByVal str1 As Date, ByVal str2 As Date, ByVal fx As String) As DataTable
        Dim sql As String = ""
        Dim cc As String
        Dim db0 As DataTable
        If fx = "�ƻ������" Then
            '����Ϊ���ƻ�����DataTable��db1
            sql = "select '" & Format(str2, "yyyy-MM") & "' AS '�·�',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='����' THEN tb_spaqnwsh_nsljjhwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '����ƻ������',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='����' THEN tb_spaqnwsh_nsljjhwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '����ƻ������' "
            sql = sql & "from tb_spaqnwsh "
            sql = sql & "where tb_spaqnwsh_rq between '" & str1 & "' and '" & str2 & "'"
        ElseIf fx = "ʵ�������" Then
            '����Ϊ��ʵ������DataTable��db2
            sql = "select '" & Format(str2, "yyyy-MM") & "' AS '�·�',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='����' THEN tb_spaqnwsh_nsljsjwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '����ʵ�������',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='����' THEN tb_spaqnwsh_nsljsjwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '����ʵ�������' "
            sql = sql & "from tb_spaqnwsh "
            sql = sql & "where tb_spaqnwsh_rq between '" & str1 & "' and '" & str2 & "'"
        End If
        db0 = GF_CreateDataSource(G_cnnstr, sql)
        yiyue = db0
    End Function
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "��ʳƷ��ȫ������FSQ����˸Ľ����ͳ�Ʊ�", Me)
    End Sub
End Class