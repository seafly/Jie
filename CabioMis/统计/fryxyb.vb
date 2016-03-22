Public Class fryxyb

    Private Sub frgcyxyb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub showGrid(ByVal str As Integer)
        '����dbTol�����ںϲ�db1��db2����
        Dim dbTol As DataTable = New DataTable
        dbTol.Columns.Add("", Type.GetType("System.String"))
        For i As Integer = 0 To 11
            dbTol.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM"), Type.GetType("System.String"))
        Next
        dbTol.Columns.Add("YTD", Type.GetType("System.String"))

        Dim yuefen As String = GF_yuefen(str) 'ѡ������·��ַ���
        Dim dt_temp As DataTable
        '************Production************

        'Fermentation���͹���
        Dim aaRow As DataRow
        aaRow = dbTol.NewRow() : aaRow(0) = "Production" : dbTol.Rows.Add(aaRow)
        aaRow = dbTol.NewRow() : aaRow(0) = "Fermentation" : dbTol.Rows.Add(aaRow)
        dt_temp = getYJSCZBdatatable(yuefen)  '�ͼ�
        dt_temp.Columns.Remove("ͳ������")
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)


        'Powder Production�ۼ�����
        aaRow = dbTol.NewRow() : aaRow(0) = "Powder Production" : dbTol.Rows.Add(aaRow)
        dt_temp = getFJSCZBdatatable(yuefen)  '�ۼ�
        dt_temp.Columns.Remove("ͳ������")
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '************Inventory & Delivery************
        aaRow = dbTol.NewRow() : aaRow(0) = "Inventory & Delivery" : dbTol.Rows.Add(aaRow)
        'Inventory��Ʒ���
        aaRow = dbTol.NewRow() : aaRow(0) = "Inventory" : dbTol.Rows.Add(aaRow)
        dt_temp = getCPKCdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Delivery���в�����
        aaRow = dbTol.NewRow() : aaRow(0) = " Delivery" : dbTol.Rows.Add(aaRow)
        dt_temp = getFHdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '************Energy Consumption************
        aaRow = dbTol.NewRow() : aaRow(0) = "Energy Consumption" : dbTol.Rows.Add(aaRow)
        dt_temp = getNHdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Unit  Consumption
        dt_temp = getNHPrice(str)
        Call hbDT(dt_temp, dbTol)
        '************EHS ************
        aaRow = dbTol.NewRow() : aaRow(0) = "EHS" : dbTol.Rows.Add(aaRow)
        dt_temp = getEHSdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Quality and Food Safety
        aaRow = dbTol.NewRow() : aaRow(0) = "Quality and Food Safety" : dbTol.Rows.Add(aaRow)
        'Customer complaints
        Dim Sql As String = "select CONVERT(varchar(7),tb_QAcc_rq,120),tb_QAcc_zs as 'Customer complaints',tb_QAcc_df as 'FSQ score' from tb_QAcc where YEAR(tb_QAcc_rq) ='" & str & "'"
        dt_temp = GF_CreateDataSource(G_cnnstr, Sql)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Deviation  (Quality)ƫ��·�����
        dt_temp = getPCFXdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Plant Management
        aaRow = dbTol.NewRow() : aaRow(0) = "Plant Management" : dbTol.Rows.Add(aaRow)
        '5S completion score  5S�÷ֱ�
        dt_temp = get5SDFdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Safety completion rateʳƷ��ȫ���������ͳ���������
        dt_temp = getSPAQdatatable(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        'Food safety completion rate��ȫ����������ͳ�����¶Ⱥϼ������
        'dt_temp = getAQJCdatatable(yuefen)
        'dt_temp = GF_DataTableChange(dt_temp)
        'Call hbDT(dt_temp, dbTol)

        '����ϼ�
        Dim zs As Integer = dbTol.Columns.Count
        For i As Integer = 0 To dbTol.Rows.Count - 1
            Select Case i
                Case 4, 5, 7, 8, 12, 17, 18, 19, 20, 21, 22, 40, 42, 43, 55, 59, 72, 73
                    dbTol.Rows(i)(13) = GF_jsRowAvg(dbTol, i, 1, 12)
                Case 2, 3, 6, 10, 11, 14, 15, 25, 26, 27, 28, 29, 30, 31, 32, 35, 36, 37, 38, 47, 48, 49, 50, 51, 52, 53, 54, 58, 61, 65, 68, 69, 70
                    dbTol.Rows(i)(13) = GF_jsRowTotal(dbTol, i, 1, 12)
                Case Else
                    dbTol.Rows(i)(13) = ""
            End Select
        Next


        Call GS_useviewbydb2(ListView1, dbTol, -1, 75)

        Dim font0 As New Font("����", 16, FontStyle.Bold, GraphicsUnit.Pixel) '�Ӵ�
        ListView1.Columns(0).Width = 240
        '����Ϊ�Ӵ֡�������ɫ
        With ListView1.Items(0)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(13)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(23)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(34)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(44)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(56)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(67)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With
        With ListView1.Items(71)
            .UseItemStyleForSubItems = False : .SubItems(0).BackColor = Color.LightSkyBlue : .SubItems(0).Font = font0 : .SubItems(0).ForeColor = Color.Azure
        End With

        '''''''''''''''''''''''''''''''''''''''''
        '�˴����2�У�2010-2-2��,lili,Natural gas (M3) �� Steam of Boiler(Yuan/mt)
        With ListView1

            ''�����39��
            Dim item As New ListViewItem
            item.Text = "Natural gas (M3)"
            Dim sum As Double = 0
            For i As Integer = 1 To 12
                Dim sj As String = GF_yuefen1(Microsoft.VisualBasic.Left(.Columns(i).Text, 4))
                Dim yuefen1() As String
                yuefen1 = Split(sj, ",")
                Sql = " tb_zqb_trqzb<>0 and tb_zqb_rq between '" & yuefen1((Mid(.Columns(i).Text, 6, 2) - 1) * 2) & "' and '" & yuefen1((Mid(.Columns(i).Text, 6, 2) - 1) * 2 + 1) & "' order by tb_zqb_rq"
                Sql = "select tb_zqb_trqzb from tb_zqb where " & Sql
                Dim natural As Data.DataTable = GF_CreateDataSource(G_cnnstr, Sql)
                Try '��Ȼ���㷨�����½�ֹ25�Ŷ���ֵ��ȥ����25�Ŷ���ֵ��Ϊ������Ȼ������
                    item.SubItems.Add(natural.Rows(natural.Rows.Count - 1)(0) - natural.Rows(0)(0))
                    sum = sum + natural.Rows(natural.Rows.Count - 1)(0) - natural.Rows(0)(0)
                Catch ex As Exception
                    item.SubItems.Add(0)
                End Try

            Next
            item.SubItems.Add(sum)
            .Items.Insert(39, item)
            .Refresh()

            ''�����45��
            Dim item1 As New ListViewItem
            sum = 0
            item1.Text = "Steam of Boiler(Yuan/mt)"
            Dim boiler As DataTable = getNHBoiled(str)
            For i As Integer = 0 To 11
                item1.SubItems.Add(boiler.Rows(i)(0))
                sum = sum + boiler.Rows(i)(0)
            Next
            item1.SubItems.Add(sum)
            .Items.Insert(45, item1)
            .Refresh()

        End With

        '''''''''''''''''''''''''''''''''''''''''
        showfjsj()
        showyjsj()
        '''''''''''''''''''''''''''''''''''''''''

        ''�����и�
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '�ֱ��ǿ�͸�
        ListView1.SmallImageList = imgList '��������listView��SmallImageList ,��imgList����Ŵ�

    End Sub

    '*�������ƣ�getYJSCZBdatatable
    '*��    �ܣ������ͼ������±����ݵ�datatable
    '*��    �룺monthStr as string :�·��ַ��������Ÿ���
    '*��    �����ͼ������±����ݵ�datatable
    Private Function getYJSCZBdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        'Dim monthArr() As String  '�ֽ��·��ַ���������
        'Dim tmpMonthLow As String '��ʱ��λ����
        'Dim tmpMonthhigh As String '��ʱ��λ����
        Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
        Dim myread As New Data.OleDb.OleDbCommand()
        Dim rs As Data.OleDb.OleDbDataReader
        '���datatable�п�ʼ
        dt.Columns.Add("ͳ������", Type.GetType("System.String"))
        dt.Columns.Add("ͳ����ֹ", Type.GetType("System.String"))
        dt.Columns.Add("Total Harvest", Type.GetType("System.String"))
        dt.Columns.Add("Contamination (Finished fermentor)", Type.GetType("System.String"))
        dt.Columns.Add("Net AA kg/Batch", Type.GetType("System.String"))
        dt.Columns.Add("Contamination Rate(%)", Type.GetType("System.String"))
        dt.Columns.Add("Total Crude Oil (kg)", Type.GetType("System.String"))
        dt.Columns.Add("Crude Oil kg/Batch", Type.GetType("System.String"))
        dt.Columns.Add("Extraction yield (%)", Type.GetType("System.String"))
        '����Ϊ���͹���
        dt.Columns.Add("Oil Production", Type.GetType("System.String"))
        '��������Ϊ�ͼ�����
        dt.Columns.Add("Grude Oil Input (kg)", Type.GetType("System.String")) '9
        dt.Columns.Add("Total finished oil (kg)", Type.GetType("System.String"))
        dt.Columns.Add("Refinery yield (%)", Type.GetType("System.String")) '12
        '���datatable�н���
        cnn.Open()
        myread.Connection = cnn
        For i As Integer = nian.Text & "0001" To nian.Text & "0012"
            Dim dataRow As Data.DataRow
            Dim index As Integer = 0
            dataRow = dt.NewRow()
            dataRow(0) = i
            dataRow(1) = i
            myread.CommandText = "select tb_zyjbb_c999u, tb_zyjbb_o488g,tb_zyjbb_u688m,tb_zyjbb_d41v,tb_zyjbb_r606k,tb_zyjbb_o469g,tb_zyjbb_f115x,tb_zyjbb_h200z,tb_zyjbb_z909r,tb_zyjbb_w771o from tb_zyjbb where tb_zyjbb_tjq=" & i
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow(2) = rs(0)
                dataRow(3) = rs(1)
                dataRow(4) = rs(2)
                dataRow(5) = rs(3)
                dataRow(6) = rs(4)
                dataRow(7) = rs(5)
                dataRow(8) = rs(6)
                dataRow(10) = rs(7)
                dataRow(11) = rs(8)
                dataRow(12) = rs(9)
            End If
            rs.Close()
            dt.Rows.Add(dataRow)
        Next
        getYJSCZBdatatable = dt
    End Function
    '�ۼ������±����ݵ�datatable
    Private Function getFJSCZBdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        'Dim monthArr() As String  '�ֽ��·��ַ���������
        'Dim tmpMonthLow As String '��ʱ��λ����
        'Dim tmpMonthhigh As String '��ʱ��λ����
        Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
        Dim myread As New Data.OleDb.OleDbCommand()
        Dim rs As Data.OleDb.OleDbDataReader
        '���datatable�п�ʼ
        dt.Columns.Add("ͳ������", Type.GetType("System.String"))
        dt.Columns.Add("ͳ����ֹ", Type.GetType("System.String")) 'ʱ��ֹ
        dt.Columns.Add("Total finished Powder (kg)", Type.GetType("System.String"))
        dt.Columns.Add("  Plant ��(Dryer 1#)", Type.GetType("System.String"))
        dt.Columns.Add("  Plant ��(Dryer 3/4#)", Type.GetType("System.String"))
        dt.Columns.Add("Total Powder Yield (%)", Type.GetType("System.String"))
        dt.Columns.Add("  Plant ��(Dryer 1#) ", Type.GetType("System.String"))
        dt.Columns.Add("  Plant ��(Dryer 3/4#) ", Type.GetType("System.String"))
        dt.Columns.Add("Total Powder Rejection(%)", Type.GetType("System.String"))
        dt.Columns.Add("  Plant ��(Dryer 1#)  ", Type.GetType("System.String"))
        dt.Columns.Add("  Plant ��(Dryer 3/4#)  ", Type.GetType("System.String"))
        '���datatable�н���
        cnn.Open()
        myread.Connection = cnn
        'monthArr = Split(monthStr, ",")
        For i As Integer = nian.Text & "0001" To nian.Text & "0012"
            Dim dataRow As Data.DataRow
            Dim index As Integer = 0
            dataRow = dt.NewRow()
            dataRow(0) = i
            dataRow(1) = i
            myread.CommandText = "select tb_zfjbb_a935s, tb_zfjbb_n455g,tb_zfjbb_g159y,tb_zfjbb_g186z,tb_zfjbb_v741n,tb_zfjbb_m382e,tb_zfjbb_l349d,tb_zfjbb_l342d from tb_zfjbb where tb_zfjbb_tjq=" & i
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow(2) = rs(0) + rs(1)
                dataRow(3) = rs(0)
                dataRow(4) = rs(1)
                dataRow(5) = rs(6)
                dataRow(6) = rs(2)
                dataRow(7) = rs(3)
                dataRow(8) = FormatNumber((rs(7) * 100) / (Double.Parse(rs(0)) + Double.Parse(rs(1))), 2)
                dataRow(9) = rs(4)
                dataRow(10) = rs(5)
            End If
            rs.Close()
            dt.Rows.Add(dataRow)
        Next
        getFJSCZBdatatable = dt
    End Function
    'EHS
    Private Function getEHSdatatable(ByVal monthStr As String) As Data.DataTable
        Dim ehsString As String = "tb_b962t_d38v,tb_b962t_c12u,tb_b962t_o493h,tb_b962t_k339d,tb_b962t_b977t,tb_b962t_e90w,tb_b962t_h198z,tb_b962t_y852q,tb_b962t_p506h,tb_b962t_b981t,tb_b962t_z889r,tb_b962t_k315c,tb_b962t_Solid_waste,tb_b962t_u701m,tb_b962t_q555i,tb_b962t_m399e,tb_b962t_s611k,tb_b962t_x839q,tb_b962t_g156y,tb_b962t_e92w"
        Dim zdArr() As String = Split(ehsString, ",")
        Dim ccc As String = ""
        For n As Integer = 0 To zdArr.Length - 1
            If n = 0 Then
                ccc = ccc & "'' AS 'Safety & Health',"
            ElseIf zdArr(n) = "tb_b962t_z889r" Then
                ccc = ccc & "'' AS 'Environment',"
            End If
            ccc = ccc & "SUM(" & zdArr(n) & ") AS '" & GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & zdArr(n) & "'", 4) & "',"
        Next
        ccc = GF_removedh(ccc)

        Dim dt As New Data.DataTable()
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String

        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1) & " 23:59:59"
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "' AS ' ',"
            sql = sql & ccc
            sql = sql & "from tb_b962t "
            sql = sql & "where tb_b962t_rq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            If i = 2 Then
                dt = db0.Copy
            Else
                dt.Rows.Add(db0.Rows(0).ItemArray)
            End If
        Next
        getEHSdatatable = dt
    End Function

    'ƫ��·�����
    Private Function getPCFXdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String

        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            'tmpMonthhigh = monthArr(i - 1) & " 23:59:59"
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "' AS ' ',"
            sql = sql & "count(*) AS 'Deviation(Quality)' "
            sql = sql & "from tb_pctz "
            sql = sql & "where tb_pctz_rq between '" & tmpMonthLow & "' AND '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            If i = 2 Then
                dt = db0.Copy
            Else
                dt.Rows.Add(db0.Rows(0).ItemArray)
            End If
        Next
        getPCFXdatatable = dt
    End Function
    '5S�÷ֱ�
    Private Function get5SDFdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String

        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1) & " 23:59:59"
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "' AS ' ',"
            sql = sql & "sum(tb_k3cpykc_zf) AS '5S completion score' "
            sql = sql & "from tb_k3cpykc "
            sql = sql & "where tb_k3cpykc_rq between '" & tmpMonthLow & "' AND '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            If i = 2 Then
                dt = db0.Copy
            Else
                If db0.Rows.Count > 0 Then
                    dt.Rows.Add(db0.Rows(0).ItemArray)
                End If
            End If
        Next
        get5SDFdatatable = dt
    End Function
    'ʳƷ��ȫ���������ͳ���������
    Private Function getSPAQdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Safety completion rate", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "' AS ' ',"
            sql = sql & "SUM(tb_spaqnwsh_nsljjhwcx),SUM(tb_spaqnwsh_nsljsjwcx) "
            sql = sql & "from tb_spaqnwsh "
            sql = sql & "where tb_spaqnwsh_rq between '" & tmpMonthLow & "' AND '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            aaRow = dt.NewRow()

            If db0.Rows.Count = 1 Then
                aaRow(0) = db0.Rows(0)(0)
                If db0.Rows(0)(1) Is DBNull.Value = False Then
                    If db0.Rows(0)(1) > 0 Then
                        aaRow(1) = Format(db0.Rows(0)(2) / db0.Rows(0)(1), "0.00%")
                    End If
                Else
                    aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM")
                    aaRow(1) = "0.00%"
                End If
            Else
                aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM")
                aaRow(1) = "0.00%"
            End If
            dt.Rows.Add(aaRow)
        Next
        getSPAQdatatable = dt
    End Function
    'Food safety completion rate��ȫ����������ͳ�����¶Ⱥϼ������
    Private Function getAQJCdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("safety completion rate", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "',"
            sql = sql & "SUM(CASE WHEN tb_jcfxx_jcxm='EHS' THEN 1 ELSE 0 END) "
            sql = sql & "SUM(CASE WHEN tb_jcfxx_wancheng='���' THEN 1 ELSE 0 END) "
            sql = sql & "from tb_jcfxx "
            sql = sql & "where tb_jcfxx_rq between '" & tmpMonthLow & "' AND '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            aaRow = dt.NewRow()

            If db0.Rows.Count = 1 Then
                aaRow(0) = db0.Rows(0)(0)
                If db0.Rows(0)(1) Is DBNull.Value = False Then
                    If db0.Rows(0)(1) > 0 Then
                        aaRow(1) = Format(db0.Rows(0)(2) / db0.Rows(0)(1), "0.00%")
                    End If
                Else
                    aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM")
                    aaRow(1) = "0.00%"
                End If
            Else
                aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM")
                aaRow(1) = "0.00%"
            End If
            dt.Rows.Add(aaRow)
        Next
        getAQJCdatatable = dt
    End Function
    Private Function getFHdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Food safety completion rate", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String
        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "',"
            sql = sql & "SUM(tb_fhyb_y872q +tb_fhyb_o474g) AS 'ARA Oil(Kg)',"
            sql = sql & "SUM(tb_fhyb_l358d) AS 'Powder (kg) ',"
            sql = sql & "SUM(tb_fhyb_w763o) AS 'Gold-AA(Kg)' "

            sql = sql & "from tb_fhyb "
            sql = sql & "where tb_fhyb_rq between '" & tmpMonthLow & "' AND '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            If i = 2 Then
                dt = db0.Copy
            Else
                dt.Rows.Add(db0.Rows(0).ItemArray)
            End If
        Next
        getFHdatatable = dt
    End Function
    '��Ʒ����ܱ�
    Private Function getCPKCdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim sql As String
        For i As Integer = 2 To monthArr.Length Step 2
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1) & " 23:59:59"
            sql = "select '" & Format(CDate(tmpMonthhigh), "yyyy-MM") & "',"
            sql = sql & "tb_k3cpykc_c19u AS 'Crude oil (kg)',"
            sql = sql & "tb_k3cpykc_d36v AS 'Finished oil (kg)',"
            sql = sql & "tb_k3cpykc_y869q AS 'Powder (kg)', "
            sql = sql & "tb_k3cpykc_n452g AS 'Gold-AA (kg)', "
            sql = sql & "tb_k3cpykc_k326c AS 'Total (Equivalent as 40% ARA)' "
            sql = sql & " from tb_k3cpykc "
            sql = sql & "where tb_k3cpykc_rq between '" & tmpMonthLow & "' AND '" & tmpMonthhigh & "'"
            db0 = GF_CreateDataSource(G_cnnstr, sql)
            If i = 2 Then
                dt = db0.Copy
            Else
                If db0.Rows.Count > 0 Then
                    dt.Rows.Add(db0.Rows(0).ItemArray)
                End If
            End If
        Next
        getCPKCdatatable = dt
    End Function

    '�ܺ�
    Private Function getNHdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Water (Ton)", Type.GetType("System.String"))
        dt.Columns.Add("Electricity (KWh)", Type.GetType("System.String"))
        dt.Columns.Add("Steam (Ton)", Type.GetType("System.String"))
        dt.Columns.Add("Diesel (L)", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM")
            db0 = get23(tmpMonthLow, tmpMonthhigh, "ˮ")
            aaRow(1) = db0.Rows(0)(0)
            db0 = get23(tmpMonthLow, tmpMonthhigh, "��")
            aaRow(2) = db0.Rows(0)(0)
            db0 = get23(tmpMonthLow, tmpMonthhigh, "����")
            aaRow(3) = db0.Rows(0)(0)
            aaRow(4) = db0.Rows(0)(5)
            dt.Rows.Add(aaRow)
        Next
        getNHdatatable = dt
    End Function

    Private Function getNHBoiled(ByVal nian1 As String) As Data.DataTable
        'ͳ��ʱ����ַ���
        Dim sj1 As String = nian1 - 1 & "-12-26"
        Dim sj11 As String = nian1 - 1 & "-12-25"
        Dim sj2 As String = nian1 & "-12-25"
        Dim yuefen As String = ""
        Dim n As Integer
        n = DateDiff("m", CDate(sj1), CDate(sj2))
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i, CDate(sj1))
            Dim jssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj11))
            yuefen = yuefen & Format(kssj, "yyyy-MM-dd") & "," & Format(jssj, "yyyy-MM-dd") & ","
        Next

        '����dbTol�����ںϲ�db1��db2����
        Dim dbTol As DataTable = New DataTable
        dbTol.Columns.Add("�ܺ�����", Type.GetType("System.String"))
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj1))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "��������", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "����������", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "��̯", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "�¹�¯��̯��", Type.GetType("System.String"))
        Next

        Dim dt_temp As DataTable
        Dim aaRow As DataRow
        '************����ͨ�����ݿ�õ���������************
        'ˮ-��������
        dt_temp = getNHSui(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '��-��������
        dt_temp = getNHDian(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '����-��������
        dt_temp = getNHQi(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '************����ͨ������õ���������************
        Dim NHFT As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_nhft") '�ܺķ�̯

        With dbTol
            '��̯��
            For j As Integer = 3 To .Columns.Count - 1 Step 4
                Dim JYQ As Double = GF_jsColumnTotal(dbTol, j - 2, 14, 16) '���������С�QC�õ���֮��
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(j - 1).Caption, 7) & "-25" & "'"

                Dim FTXS As Double
                Try
                    FTXS = GF_cnwithen(NHFT, sj, 4)
                    .Rows(8)(j) = .Rows(13)(j - 2) + JYQ * FTXS  '���ͷ�̯��=�豸+�����������С�QC�õ���֮�ͣ�*��̯ϵ��
                    .Rows(8)(j) = FormatNumber(.Rows(8)(j), 2) '2λС��
                Catch ex As Exception
                    FTXS = 0
                    .Rows(8)(j) = 0
                End Try
                Try
                    .Rows(9)(j) = JYQ * GF_cnwithen(NHFT, sj, 7)  '������̯��=�����������С�QC�õ���֮�ͣ�*��̯ϵ��
                    .Rows(10)(j) = JYQ * GF_cnwithen(NHFT, sj, 10)
                    .Rows(11)(j) = JYQ * GF_cnwithen(NHFT, sj, 13)
                    .Rows(9)(j) = FormatNumber(.Rows(9)(j), 2) '2λС��
                    .Rows(10)(j) = FormatNumber(.Rows(10)(j), 2) '2λС��
                    .Rows(11)(j) = FormatNumber(.Rows(11)(j), 2) '2λС��
                Catch ex As Exception
                    .Rows(9)(j) = 0 : .Rows(10)(j) = 0 : .Rows(11)(j) = 0
                End Try
                .Rows(7)(j) = GF_jsColumnTotal(dbTol, j, 8, 11)
            Next

            '����������
            For j As Integer = 2 To .Columns.Count - 1 Step 4
                Dim SuiYS, QiYS As Double
                Try
                    SuiYS = (.Rows(0)(j - 1) - .Rows(5)(j - 1)) / GF_jsColumnTotal(dbTol, j - 1, 1, 4) '��ˮ����/�����ż�������֮��
                Catch ex As Exception
                    SuiYS = 0
                End Try
                Try
                    QiYS = GF_jsColumnTotal(dbTol, j - 1, 19, 22) / .Rows(18)(j - 1) '�����ż�������֮��/��������;(SUM(C20:C23)/C19)
                Catch ex As Exception
                    QiYS = 0
                End Try
                'ˮ
                .Rows(1)(j) = FormatNumber(Null2zero(.Rows(1)(j - 1)) * SuiYS, 2)
                .Rows(2)(j) = FormatNumber(Null2zero(.Rows(2)(j - 1)) * SuiYS, 2)
                .Rows(3)(j) = FormatNumber(Null2zero(.Rows(3)(j - 1)) * SuiYS, 2)
                .Rows(4)(j) = FormatNumber(Null2zero(.Rows(4)(j - 1)) * SuiYS, 2)
                .Rows(5)(j) = .Rows(5)(j - 1)

                '����
                Try
                    .Rows(21)(j) = FormatNumber(.Rows(21)(j - 1) / QiYS, 2)
                    .Rows(22)(j) = FormatNumber(.Rows(22)(j - 1) / QiYS, 2)
                    .Rows(19)(j) = FormatNumber(.Rows(19)(j - 1) / QiYS, 2)
                    .Rows(20)(j) = FormatNumber(.Rows(20)(j - 1) / QiYS, 2)
                Catch ex As Exception
                    .Rows(21)(j) = 0
                    .Rows(22)(j) = 0
                    .Rows(19)(j) = 0
                    .Rows(20)(j) = 0
                End Try
                '��
                .Rows(8)(j) = FormatNumber(CDbl(.Rows(8)(j - 1)) + CDbl(.Rows(8)(j + 1)), 2)
                .Rows(9)(j) = FormatNumber(CDbl(.Rows(9)(j - 1)) + CDbl(.Rows(9)(j + 1)), 2)
                .Rows(10)(j) = FormatNumber(CDbl(.Rows(10)(j - 1)) + CDbl(.Rows(10)(j + 1)), 2)
                .Rows(11)(j) = FormatNumber(CDbl(.Rows(11)(j - 1)) + CDbl(.Rows(11)(j + 1)), 2)
                .Rows(12)(j) = .Rows(12)(j - 1)
            Next

        End With
        'Unit  Consumption
        Dim NHPrice As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_nhjg") '�ܺļ۸�
        Dim sui, dian, qi, you, trq As Double
        Try
            sui = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian1 & " and tb_nhjg_lb='ˮ'", 1)
            dian = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian1 & " and tb_nhjg_lb='��'", 1)
            qi = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian1 & " and tb_nhjg_lb='��'", 1)
            you = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian1 & " and tb_nhjg_lb='��'", 1)
            trq = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian1 & " and tb_nhjg_lb='��Ȼ��'", 1)
        Catch ex As Exception
            MsgBox("�Բ�����Ϊû����д��ѡ����ܺĵ��ۣ��ʲ������ͳ�ƣ�") : Return Nothing
        End Try
        'aaRow = dbTol.NewRow() : aaRow(0) = "Unit  Consumption" : dbTol.Rows.Add(aaRow)
        With dbTol
            '''''''''''''''''''''''''''''''''''''''''''"Total Diesel (L)"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Diesel (L)"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i) = FormatNumber(.Rows(24)(i) * 1 + .Rows(25)(i) * 1, 0)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''''"Crude Oil"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Crude Oil"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(19)(i + 1) / .Rows(18)(i)) * .Rows(25)(i) + .Rows(24)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''"Oil"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Oil"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(20)(i + 1) / .Rows(18)(i)) * .Rows(25)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''"Powder ��"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(21)(i + 1) / .Rows(18)(i)) * .Rows(25)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''' "Powder ��"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(22)(i + 1) / .Rows(18)(i)) * .Rows(25)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''"Natural gas (M3)"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Natural gas (M3)"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = GF_yuefen1(Microsoft.VisualBasic.Left(.Columns(i).Caption, 4))
                Dim yuefen1() As String
                yuefen1 = Split(sj, ",")
                Dim sql As String = "tb_zqb_rq between '" & yuefen1((Mid(.Columns(i).Caption, 6, 2) - 1) * 2) & "' and '" & yuefen1((Mid(.Columns(i).Caption, 6, 2) - 1) * 2 + 1) & "' order by tb_zqb_rq"
                sql = "select tb_zqb_trqzb from tb_zqb where " & sql
                Dim natural As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
                Try
                    aaRow(i) = natural.Rows(natural.Rows.Count - 1)(0) - natural.Rows(0)(0)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''' "Crude Oil"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Crude Oil"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(19)(i + 1) / .Rows(18)(i)) * .Rows(31)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''"Oil"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Oil"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(20)(i + 1) / .Rows(18)(i)) * .Rows(31)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''"Powder ��"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(21)(i + 1) / .Rows(18)(i)) * .Rows(31)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''' "Powder ��"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(22)(i + 1) / .Rows(18)(i)) * .Rows(31)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''��¯��̯��''''''''''''''''''''''''''''
            For j As Integer = 2 To .Columns.Count - 1 Step 4
                ''''''ˮ
                .Rows(1)(j + 2) = FormatNumber(Null2zero((.Rows(19)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(1)(j)), 2)
                .Rows(2)(j + 2) = FormatNumber(Null2zero((.Rows(20)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(2)(j)), 2)
                .Rows(3)(j + 2) = FormatNumber(Null2zero((.Rows(21)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(3)(j)), 2)
                .Rows(4)(j + 2) = FormatNumber(Null2zero((.Rows(22)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(4)(j)), 2)
                ''''''��
                .Rows(8)(j + 2) = FormatNumber(Null2zero((.Rows(19)(j) / .Rows(18)(j - 1)) * .Rows(12)(j - 1) + .Rows(8)(j)), 2)
                .Rows(9)(j + 2) = FormatNumber(Null2zero((.Rows(20)(j) / .Rows(18)(j - 1)) * .Rows(12)(j - 1) + .Rows(9)(j)), 2)
                .Rows(10)(j + 2) = FormatNumber(Null2zero((.Rows(21)(j) / .Rows(18)(j - 1)) * .Rows(12)(j - 1) + .Rows(10)(j)), 2)
                .Rows(11)(j + 2) = FormatNumber(Null2zero((.Rows(22)(j) / .Rows(18)(j - 1)) * .Rows(12)(j - 1) + .Rows(11)(j)), 2)
            Next



            aaRow = dbTol.NewRow() : aaRow(0) = "Unit  Consumption" : dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''
            aaRow = dbTol.NewRow()
            aaRow(0) = "Crude oil (Yuan/kg)"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    Dim sum11, sum12 As Double
                    sum11 = .Rows(1)(i + 1) * sui + .Rows(8)(i + 1) * dian + .Rows(19)(i + 1) * qi + .Rows(24)(i) * you
                    sum12 = .Rows(1)(i + 3) * sui + .Rows(8)(i + 3) * dian + .Rows(27)(i + 3) * you + .Rows(32)(i + 3) * trq
                    aaRow(i + 1) = FormatNumber(sum11 / GF_cnwithen(NHFT, sj, 3), 2)
                    aaRow(i + 3) = FormatNumber(sum12 / GF_cnwithen(NHFT, sj, 3), 2)
                Catch ex As Exception
                    aaRow(i + 1) = "0"
                    aaRow(i + 3) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)

            ''''''''''''''''''''''''''''''''''''''''''''Oil (Yuan/kg)
            aaRow = dbTol.NewRow()
            aaRow(0) = "Oil (Yuan/kg)"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    aaRow(i + 1) = FormatNumber((.Rows(2)(i + 1) * sui + .Rows(9)(i + 1) * dian + .Rows(20)(i + 1) * qi) / GF_cnwithen(NHFT, sj, 6), 2)
                    aaRow(i + 3) = FormatNumber((.Rows(2)(i + 3) * sui + .Rows(9)(i + 3) * dian + .Rows(28)(i + 3) * you + .Rows(33)(i + 3) * trq) / GF_cnwithen(NHFT, sj, 6), 2)
                Catch ex As Exception
                    aaRow(i + 1) = "0"
                    aaRow(i + 3) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''''''"Powder (Yuan/kg) ��
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder (Yuan/kg) ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    aaRow(i + 1) = FormatNumber((.Rows(3)(i + 1) * sui + .Rows(10)(i + 1) * dian + .Rows(21)(i + 1) * qi) / GF_cnwithen(NHFT, sj, 9), 2)
                    aaRow(i + 3) = FormatNumber((.Rows(3)(i + 3) * sui + .Rows(10)(i + 3) * dian + .Rows(29)(i + 3) * you + .Rows(34)(i + 3) * trq) / GF_cnwithen(NHFT, sj, 9), 2)
                Catch ex As Exception
                    aaRow(i + 1) = "0"
                    aaRow(i + 3) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''''''Powder (Yuan/kg) ��
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder (Yuan/kg) ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    aaRow(i + 1) = FormatNumber((.Rows(4)(i + 1) * sui + .Rows(11)(i + 1) * dian + .Rows(22)(i + 1) * qi) / GF_cnwithen(NHFT, sj, 12), 2)
                    aaRow(i + 3) = FormatNumber((.Rows(4)(i + 3) * sui + .Rows(11)(i + 3) * dian + .Rows(30)(i + 3) * you + .Rows(35)(i + 3) * trq) / GF_cnwithen(NHFT, sj, 12), 2)
                Catch ex As Exception
                    aaRow(i + 1) = "0"
                    aaRow(i + 3) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''Steam of Boiler(Yuan/mt)
            aaRow = dbTol.NewRow()
            aaRow(0) = "Steam of Boiler(Yuan/mt)"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(5)(i) * sui + .Rows(12)(i) * dian + .Rows(25)(i) * you + .Rows(31)(i) * trq) / .Rows(18)(i), 2)
                Catch ex As Exception
                    aaRow(i + 3) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''
        End With


        Dim cccc As DataTable = New DataTable
        For i As Integer = 0 To 12
            cccc.Columns.Add(i, Type.GetType("System.String"))
        Next

        Dim hs As Integer = dbTol.Rows.Count - 1
        With cccc
            For i As Integer = 1 To 12
                aaRow = cccc.NewRow()
                aaRow(0) = Null2zero(dbTol.Rows(hs)(i * 4))
                cccc.Rows.Add(aaRow)
            Next

        End With
        getNHBoiled = cccc
    End Function
    '���¸��Ƶ����ܺ��±���Դ���루��

    'Unit  Consumption���ⲿ�����ܺ��±�����������иĶ���
    Private Function getNHPrice(ByVal tjyear As String) As Data.DataTable

        'ͳ��ʱ����ַ���
        Dim sj1 As String = Today.Year - 1 & "-12-26"
        Dim sj11 As String = Today.Year - 1 & "-12-25"
        Dim sj2 As String = Today.Year & "-12-25"
        'Dim nianyue1 As String = nian1.Text & "-" & yue1.Text
        'Dim nianyue2 As String = nian2.Text & "-" & yue2.Text
        Dim yuefen As String = ""
        Dim n As Integer
        n = DateDiff("m", CDate(sj1), CDate(sj2))
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i, CDate(sj1))
            Dim jssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj11))
            yuefen = yuefen & Format(kssj, "yyyy-MM-dd") & "," & Format(jssj, "yyyy-MM-dd") & ","
        Next
        '����dbTol�����ںϲ�db1��db2����
        Dim dbTol As DataTable = New DataTable
        dbTol.Columns.Add("�ܺ�����", Type.GetType("System.String"))
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj1))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "��������", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "����������", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "��̯", Type.GetType("System.String"))
        Next
        ' dbTol.Columns.Add("YTD", Type.GetType("System.String"))
        '�����е�Ĭ��ֵΪ0
        'For i As Integer = 1 To dbTol.Columns.Count - 1
        '    dbTol.Columns(i).DefaultValue = 0
        'Next
        'MsgBox(yuefen & vbCrLf & vbCrLf & vbCrLf & GF_yuefen(str))

        'Dim yuefen As String = GF_yuefen(str) 'ѡ������·��ַ���
        Dim dt_temp As DataTable
        Dim aaRow As DataRow
        '************����ͨ�����ݿ�õ���������************
        'ˮ-��������
        dt_temp = getNHSui(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '��-��������
        dt_temp = getNHDian(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '����-��������
        dt_temp = getNHQi(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '************����ͨ������õ���������************
        Dim NHFT As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_nhft") '�ܺķ�̯

        With dbTol
            '��̯��
            For j As Integer = 3 To .Columns.Count - 1 Step 3
                Dim JYQ As Double = GF_jsColumnTotal(dbTol, j - 2, 12, 14) '���������С�QC�õ���֮��
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(j - 1).Caption, 7) & "-25" & "'"

                Dim FTXS As Double
                Try
                    FTXS = GF_cnwithen(NHFT, sj, 4)
                    .Rows(7)(j) = .Rows(11)(j - 2) + JYQ * FTXS  '���ͷ�̯��=�豸+�����������С�QC�õ���֮�ͣ�*��̯ϵ��
                    .Rows(7)(j) = FormatNumber(.Rows(7)(j), 2) '2λС��
                Catch ex As Exception
                    FTXS = 0
                    .Rows(7)(j) = 0
                End Try
                Try
                    .Rows(8)(j) = JYQ * GF_cnwithen(NHFT, sj, 7)  '������̯��=�����������С�QC�õ���֮�ͣ�*��̯ϵ��
                    .Rows(9)(j) = JYQ * GF_cnwithen(NHFT, sj, 10)
                    .Rows(10)(j) = JYQ * GF_cnwithen(NHFT, sj, 13)
                    .Rows(8)(j) = FormatNumber(.Rows(8)(j), 2) '2λС��
                    .Rows(9)(j) = FormatNumber(.Rows(9)(j), 2) '2λС��
                    .Rows(10)(j) = FormatNumber(.Rows(10)(j), 2) '2λС��
                Catch ex As Exception
                    .Rows(8)(j) = 0 : .Rows(9)(j) = 0 : .Rows(10)(j) = 0
                End Try
                .Rows(6)(j) = GF_jsColumnTotal(dbTol, j, 7, 10)
            Next
            '����������
            For j As Integer = 2 To .Columns.Count - 1 Step 3
                Dim SuiYS, QiYS As Double
                Try
                    SuiYS = .Rows(0)(j - 1) / GF_jsColumnTotal(dbTol, j - 1, 1, 4) '��ˮ����/�����ż�������֮��
                Catch ex As Exception
                    SuiYS = 0
                End Try
                Try
                    QiYS = GF_jsColumnTotal(dbTol, j - 1, 17, 20) / .Rows(16)(j - 1) '�����ż�������֮��/��������;(SUM(C20:C23)/C19)
                Catch ex As Exception
                    QiYS = 0
                End Try
                'ˮ
                .Rows(1)(j) = FormatNumber(Null2zero(.Rows(1)(j - 1)) * SuiYS, 2)
                .Rows(2)(j) = FormatNumber(Null2zero(.Rows(2)(j - 1)) * SuiYS, 2)
                .Rows(3)(j) = FormatNumber(Null2zero(.Rows(3)(j - 1)) * SuiYS, 2)
                .Rows(4)(j) = FormatNumber(Null2zero(.Rows(4)(j - 1)) * SuiYS, 2)

                '����
                Try
                    .Rows(17)(j) = FormatNumber(.Rows(17)(j - 1) / QiYS, 2)
                    .Rows(18)(j) = FormatNumber(.Rows(18)(j - 1) / QiYS, 2)
                    .Rows(19)(j) = FormatNumber(.Rows(19)(j - 1) / QiYS, 2)
                    .Rows(20)(j) = FormatNumber(.Rows(20)(j - 1) / QiYS, 2)
                Catch ex As Exception
                    .Rows(17)(j) = 0
                    .Rows(18)(j) = 0
                    .Rows(19)(j) = 0
                    .Rows(20)(j) = 0
                End Try
                '��
                .Rows(7)(j) = FormatNumber(CDbl(.Rows(7)(j - 1)) + CDbl(.Rows(7)(j + 1)), 2)
                .Rows(8)(j) = FormatNumber(CDbl(.Rows(8)(j - 1)) + CDbl(.Rows(8)(j + 1)), 2)
                .Rows(9)(j) = FormatNumber(CDbl(.Rows(9)(j - 1)) + CDbl(.Rows(9)(j + 1)), 2)
                .Rows(10)(j) = FormatNumber(CDbl(.Rows(10)(j - 1)) + CDbl(.Rows(10)(j + 1)), 2)
                ' .Rows(6)(j) = GF_jsColumnTotal(dbTol, j, 7, 10)'����7��10��֮��
            Next
        End With
        ''Unit  Consumption
        Dim NHPrice As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_nhjg") '�ܺļ۸�
        Dim sui, dian, qi, you As Double
        Try
            sui = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & tjyear & " and tb_nhjg_lb='ˮ'", 1)
            dian = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & tjyear & " and tb_nhjg_lb='��'", 1)
            qi = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & tjyear & " and tb_nhjg_lb='��'", 1)
            you = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & tjyear & " and tb_nhjg_lb='��'", 1)
        Catch ex As Exception
            MsgBox("�Բ�����Ϊû����д��ѡ����ܺĵ��ۣ��ʲ������ͳ�ƣ�")
            Return Nothing
        End Try
        ''����dbTol
        'Dim dbTol As DataTable = New DataTable
        'dbTol.Columns.Add(" ", Type.GetType("System.String"))
        'For i As Integer = 0 To 11
        '    dbTol.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & tjyear)), "yyyy-MM"), Type.GetType("System.String"))
        'Next
        'Dim aaRow As DataRow
        aaRow = dbTol.NewRow() : aaRow(0) = "Unit  Consumption" : dbTol.Rows.Add(aaRow)
        With dbTol
            aaRow = dbTol.NewRow()
            aaRow(0) = "Crude oil (Yuan/kg)"
            For i As Integer = 1 To .Columns.Count - 1 Step 3
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try

                    aaRow(i) = FormatNumber((.Rows(1)(i + 1) * sui + .Rows(7)(i + 1) * dian + .Rows(17)(i + 1) * qi + .Rows(22)(i) * you) / GF_cnwithen(NHFT, sj, 3), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            aaRow = dbTol.NewRow()
            aaRow(0) = "Oil (Yuan/kg)"
            For i As Integer = 1 To .Columns.Count - 1 Step 3
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    'MsgBox(GF_cnwithen(NHFT, sj, 6))
                    aaRow(i) = FormatNumber((.Rows(2)(i + 1) * sui + .Rows(8)(i + 1) * dian + .Rows(18)(i + 1) * qi) / GF_cnwithen(NHFT, sj, 6), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder (Yuan/kg) ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 3
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    aaRow(i) = FormatNumber((.Rows(3)(i + 1) * sui + .Rows(9)(i + 1) * dian + .Rows(19)(i + 1) * qi) / GF_cnwithen(NHFT, sj, 9), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder (Yuan/kg) ��"
            For i As Integer = 1 To .Columns.Count - 1 Step 3
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(i).Caption, 7) & "-25" & "'"
                Try
                    aaRow(i) = FormatNumber((.Rows(4)(i + 1) * sui + .Rows(10)(i + 1) * dian + .Rows(20)(i + 1) * qi) / GF_cnwithen(NHFT, sj, 12), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
        End With
        '''''
        Dim hs As Integer = dbTol.Rows.Count - 1
        Dim cccc As DataTable = New DataTable
        cccc.Columns.Add(" ", Type.GetType("System.String"))
        For i As Integer = 0 To 11
            cccc.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & tjyear)), "yyyy-MM"), Type.GetType("System.String"))
        Next
        'Dim aaRow As DataRow
        aaRow = cccc.NewRow() : aaRow(0) = "Unit Consumption" : cccc.Rows.Add(aaRow)
        With cccc
            aaRow = cccc.NewRow()
            aaRow(0) = "Crude oil (Yuan/kg)"
            For i As Integer = 1 To .Columns.Count - 1
                aaRow(i) = dbTol.Rows(hs - 3)(i * 3 - 2)
            Next
            cccc.Rows.Add(aaRow)
            aaRow = cccc.NewRow()
            aaRow(0) = "Oil (Yuan/kg)"
            For i As Integer = 1 To .Columns.Count - 1
                aaRow(i) = dbTol.Rows(hs - 2)(i * 3 - 2)
            Next
            cccc.Rows.Add(aaRow)
            aaRow = cccc.NewRow()
            aaRow(0) = "Powder (Yuan/kg) ��"
            For i As Integer = 1 To .Columns.Count - 1
                aaRow(i) = dbTol.Rows(hs - 1)(i * 3 - 2)
            Next
            cccc.Rows.Add(aaRow)
            aaRow = cccc.NewRow()
            aaRow(0) = "Powder (Yuan/kg) ��"
            For i As Integer = 1 To .Columns.Count - 1
                aaRow(i) = dbTol.Rows(hs - 0)(i * 3 - 2)
            Next
            cccc.Rows.Add(aaRow)
        End With
        getNHPrice = cccc

    End Function
    '�ܺĵ�
    Private Function getNHDian(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Electricity (KWh) Total", Type.GetType("System.String"))
        dt.Columns.Add("Fermentation", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String")) '5
        dt.Columns.Add("���õ�:�豸������", Type.GetType("System.String"))
        dt.Columns.Add("������", Type.GetType("System.String"))
        dt.Columns.Add("���в�", Type.GetType("System.String"))
        dt.Columns.Add("QC", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "��������"
            db0 = get2(tmpMonthLow, tmpMonthhigh, "��")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(5)
            aaRow(7) = db0.Rows(0)(6)
            aaRow(8) = db0.Rows(0)(7)
            aaRow(9) = db0.Rows(0)(8)
            aaRow(10) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4) - db0.Rows(0)(5) - db0.Rows(0)(6) - db0.Rows(0)(7) - db0.Rows(0)(8) 'ullage���
            dt.Rows.Add(aaRow)
        Next
        getNHDian = dt
    End Function
    '�ܺ�ˮ
    Private Function getNHSui(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Water(Ton) Total", Type.GetType("System.String"))
        dt.Columns.Add("Fermentation", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "��������"
            db0 = get2(tmpMonthLow, tmpMonthhigh, "ˮ")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4) 'ullage(���/����
            dt.Rows.Add(aaRow)
        Next
        getNHSui = dt
    End Function
    '�ܺ�����
    Private Function getNHQi(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Steam (Ton) Total", Type.GetType("System.String"))
        dt.Columns.Add("Crude Oil", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        dt.Columns.Add("Diesel (L) Total", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "��������"
            db0 = get2(tmpMonthLow, tmpMonthhigh, "����")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4)  'ullage(���/����
            aaRow(7) = db0.Rows(0)(5) '����
            dt.Rows.Add(aaRow)
        Next
        getNHQi = dt
    End Function
    Private Function getsui1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4 '��ˮ������ˮ���ͼ�ˮ���ۼ�һˮ���ۼ���ˮ
        zs = "tb_zls_zlszb"
        s1 = "tb_zls_hg + tb_zls_fx + tb_zls_pl + tb_zls_tca + tb_zls_tcb"
        s2 = "tb_zls_tc "
        s3 = "tb_zls_lfj"
        s4 = "tb_zls_js + tb_zls_cs + tb_zls_jx"
        's5 = "tb_zls_hg+tb_zls_fx+tb_zls_pl+tb_zls_pk+tb_zls_lst+tb_zls_wc+tb_zls_tc +tb_zls_tca+tb_zls_tcb+tb_zls_lfj+tb_zls_js+tb_zls_cs+tb_zls_jx" '�ֱ�֮�ͣ���13���ֱ�
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4
        Dim sql As String = "select top 1 " & szfc & " from tb_zls where tb_zls_rq< '" & str1 & "' order by  tb_zls_rq desc "
        ''''
        If str2 <> "" Then
            sql = clsql(sql, "select tb_zls_hb from tb_zls where tb_zls_rq< '" & str2 & "' and  tb_zls_rq> '" & str1 & "' order by tb_zls_rq desc ")
        End If
        ''''
        getsui1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getdian1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5, s6, s7, s8 '�ܵ磬���͵�,�ͼ���,�ۼ�һ��,�ۼ����磬�豸���������������У�qc
        zs = "tb_dian_zjlg"
        s1 = "tb_dian_fxdlzb-tb_dian_sbdlwxj-tb_dian_yxsys+tb_dian_qcdl+tb_dian_zcyfx-tb_dian_zczm-tb_dian_pka-tb_dian_pkb-tb_dian_pkc-tb_dian_wlzm"
        's1 = "tb_dian_zjlg + tb_dian_qcdl - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zczm - tb_dian_yxsys - tb_dian_zcdlzb - tb_dian_wlzm - tb_dian_pka - tb_dian_pkb - tb_dian_pkc - tb_dian_xfjdl"
        s2 = "tb_dian_tcdl + tb_dian_jldl + tb_dian_zczm * 0.5"
        s3 = "tb_dian_zcdlzb - tb_dian_yfdl - tb_dian_tcdl - tb_dian_qcdl - tb_dian_jldl + tb_dian_zczm * 0.5"
        s4 = "tb_dian_xfjdl"
        s5 = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl + tb_dian_sbdlzm" '�豸����
        s6 = "tb_dian_yxsys + tb_dian_yfdl" '����
        s7 = "tb_dian_wszdlyzm + tb_dian_zzm - tb_dian_sbdlzm + tb_dian_wlzm" '����
        s8 = "tb_dian_pka + tb_dian_pkb + tb_dian_pkc" 'qc
        's9 = "tb_dian_wszdlyzm+tb_dian_zzm+tb_dian_sbdlzm+tb_dian_mfzm+tb_dian_zcyfx+tb_dian_zczm+tb_dian_fxdlzb+tb_dian_zca+tb_dian_zcb+tb_dian_sbdlwxj+tb_dian_yxsys+tb_dian_zcdlzb+tb_dian_yfdl+tb_dian_tcdl+tb_dian_qcdl+tb_dian_jldl+tb_dian_wlzm+tb_dian_pka+tb_dian_pkb+tb_dian_pkc+tb_dian_xfjdl"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5 & "," & s6 & "," & s7 & "," & s8
        Dim sql As String = "select top 1 " & szfc & " from tb_dian where tb_dian_rq< '" & str1 & "' order by tb_dian_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select tb_dian_hb from tb_dian where tb_dian_rq< '" & str2 & "' and tb_dian_rq> '" & str1 & "' order by tb_dian_rq desc ")
        End If
        getdian1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getzqb1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4 '����������������,�ͼ�����,�ۼ�һ����,�ۼ�������,�ܲ���
        zs = "tb_zqb_zqzb+tb_zqb_zqzb2+tb_zqb_zqzb3"
        s1 = "tb_zqb_zxg + tb_zqb_jsdg + tb_zqb_xtg + tb_zqb_hg + tb_zqb_xsdg + tb_zqb_plj + tb_zqb_qc"
        s2 = "tb_zqb_tca + tb_zqb_tcb + tb_zqb_tcc + tb_zqb_jl"
        s3 = "tb_zqb_fj"
        's4 = "tb_zqb_zqzb - (" & s1 & "+" & s2 & "+" & s3 & ") /1000" '
        s4 = "tb_zqb_zqzb3 /1000" '�������ܱ�3������,�����2010.4.28��13ʱ�޸�
        ' s5 = "tb_zqb_cyzb"
        's6 = "tb_zqb_zxg+tb_zqb_jsdg+tb_zqb_xtg+tb_zqb_hg+tb_zqb_xsdg+tb_zqb_plj+tb_zqb_qc+tb_zqb_tca+tb_zqb_tcb+tb_zqb_tcc+tb_zqb_fj+tb_zqb_jl"
        Dim szfc As String = zs & ",(" & s1 & ")/1000,(" & s2 & ")/1000,(" & s3 & ")/1000," & s4 & ",'0'"
        Dim sql As String = "select top 1 " & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "' order by tb_zqb_rq desc ")
        End If
        getzqb1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getCaiYou(ByVal str1 As String, ByVal str2 As String) As Integer ''�����ܱ�,ʱ���������֮��
        Dim sql As String = "select tb_zqb_cyzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "') and (tb_zqb_hb not Like '%�����ܱ�%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + cy.Rows(j)(0)
        Next
        getCaiYou = zcy
    End Function
    '���ڡ��������ܵ�ʵ��
    '��sql�����д����������ֶα�Ϊ����0
    Private Function clsql(ByVal sql As String, ByVal sql2 As String) As String 'sqlΪ������sql�ַ�����sql2Ϊ��ѯ�����¼sql�ַ���
        Dim hbdb As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        Dim ccc As String = ""
        For i As Integer = 0 To hbdb.Rows.Count - 1
            If hbdb.Rows(i)(0).GetType Is Type.GetType("System.String") Then
                ccc = ccc & hbdb.Rows(i)(0) & ","
            End If
        Next
        ccc = GF_removedh(ccc)
        Dim ctableName As String = GF_zhzfccx(ccc) '��ѯֹʱ��������¼�ġ������ֶ�����
        hbdb = GF_CreateDataSource(G_cnnstr, "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_mx in(" & ctableName & ")") '�������ֶ����ݶ�ӦӢ���ֶ�����DATATABLE

        For i As Integer = 0 To hbdb.Rows.Count - 1
            If hbdb.Rows(i)(0) = "tb_zls_tc" Then
                hbdb.Rows(i)(0) = "tb_zls_tc "
            End If
            sql = Replace(sql, hbdb.Rows(i)(0), "0") 'hbdb.Rows(i)(0)�ǡ������ֶ����ݶ�ӦӢ���ֶ�����
        Next
        clsql = sql
    End Function
    Private Function get2(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As DataTable
        Dim k1, k2 As New DataTable
        str2 = str2 & " 23:59:59"
        If str3 = "ˮ" Then
            k1 = getsui1(str1, str2)
            k2 = getsui1(str2, "")

        ElseIf str3 = "��" Then
            k1 = getdian1(str1, str2)
            k2 = getdian1(str2, "")
        ElseIf str3 = "����" Then
            k1 = getzqb1(str1, str2)
            k2 = getzqb1(str2, "")
        End If
        Dim kk As DataTable = k1.Clone
        Dim row As DataRow = kk.NewRow()
        For i As Integer = 0 To k1.Columns.Count - 1
            row(i) = k2.Rows(0)(i) - k1.Rows(0)(i)
            If str3 = "����" And i = 5 Then
                'row(5) = k2.Rows(0)(5) '�����ܱ�ֹʱ������֣����ü���
                row(5) = getCaiYou(str1, str2) '�����ܱ�,ʱ���������֮��
            End If
        Next
        kk.Rows.Add(row)
        get2 = kk
    End Function
    '''
    '''���ϸ��Ƶ����ܺ��±���Դ���루ֹ��
    ''' 
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "�깤�������±�", Me)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False : Button2.Text = "ͳ���У����Ժ�"
        Call showGrid(nian.Text)
        Button2.Enabled = True : Button2.Text = "��ѯ"
    End Sub

    Private Sub showfjsj() '�ۼ�����
        With ListView1
            Dim dt As DataTable
            Dim n As Integer
            For i As Integer = nian.Text & "0001" To nian.Text & "0012"
                dt = GF_CreateDataSource(G_cnnstr, "select tb_zfjbb_a935s, tb_zfjbb_n455g,tb_zfjbb_g159y,tb_zfjbb_g186z,tb_zfjbb_v741n,tb_zfjbb_m382e,tb_zfjbb_l349d,tb_zfjbb_l342d from tb_zfjbb where tb_zfjbb_tjq=" & i)
                If dt.Rows.Count > 0 Then
                    If i > nian.Text & "0009" Then
                        n = Microsoft.VisualBasic.Right(i, 2)
                    Else
                        n = Microsoft.VisualBasic.Right(i, 1)
                    End If

                    .Items(14).SubItems(n).Text = Double.Parse(dt.Rows(0)(0)) + Double.Parse(dt.Rows(0)(1))
                    .Items(15).SubItems(n).Text = dt.Rows(0)(0)
                    .Items(16).SubItems(n).Text = dt.Rows(0)(1)
                    .Items(17).SubItems(n).Text = dt.Rows(0)(6)
                    .Items(18).SubItems(n).Text = dt.Rows(0)(2)
                    .Items(19).SubItems(n).Text = dt.Rows(0)(3)

                    .Items(20).SubItems(n).Text = FormatNumber((dt.Rows(0)(7) * 100) / (Double.Parse(dt.Rows(0)(0)) + Double.Parse(dt.Rows(0)(1))), 2)
                    .Items(21).SubItems(n).Text = FormatNumber((dt.Rows(0)(4) * 100) / Double.Parse(dt.Rows(0)(0)), 2)
                    .Items(22).SubItems(n).Text = FormatNumber((dt.Rows(0)(5) * 100) / Double.Parse(dt.Rows(0)(1)), 2)
                End If
            Next
        End With
    End Sub

    Private Sub showyjsj() '�ͼ�����
        With ListView1
            With ListView1
                Dim dt As DataTable
                Dim n As Integer
                For i As Integer = nian.Text & "0001" To nian.Text & "0012"
                    dt = GF_CreateDataSource(G_cnnstr, "select tb_zyjbb_c999u, tb_zyjbb_o488g,tb_zyjbb_u688m,tb_zyjbb_d41v,tb_zyjbb_r606k,tb_zyjbb_o469g,tb_zyjbb_f115x,tb_zyjbb_h200z,tb_zyjbb_z909r,tb_zyjbb_w771o from tb_zyjbb where tb_zyjbb_tjq=" & i)
                    If dt.Rows.Count > 0 Then
                        If i > nian.Text & "0009" Then
                            n = Microsoft.VisualBasic.Right(i, 2)
                        Else
                            n = Microsoft.VisualBasic.Right(i, 1)
                        End If

                        .Items(2).SubItems(n).Text = dt.Rows(0)(0)
                        .Items(3).SubItems(n).Text = dt.Rows(0)(1)
                        .Items(4).SubItems(n).Text = dt.Rows(0)(2)
                        .Items(5).SubItems(n).Text = dt.Rows(0)(3)
                        .Items(6).SubItems(n).Text = dt.Rows(0)(4)
                        .Items(7).SubItems(n).Text = dt.Rows(0)(5)
                        .Items(8).SubItems(n).Text = dt.Rows(0)(6)
                        .Items(10).SubItems(n).Text = dt.Rows(0)(7)
                        .Items(11).SubItems(n).Text = dt.Rows(0)(8)
                        .Items(12).SubItems(n).Text = dt.Rows(0)(9)
                    End If
                Next
            End With
        End With
    End Sub

    '�ܺĵ�
    Private Function getNHDian3(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Electricity (KWh) Total", Type.GetType("System.String"))
        dt.Columns.Add("Fermentation", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String")) '5
        dt.Columns.Add(" Boiler", Type.GetType("System.String"))
        dt.Columns.Add("���õ�:�豸������", Type.GetType("System.String"))
        dt.Columns.Add("������", Type.GetType("System.String"))
        dt.Columns.Add("���в�", Type.GetType("System.String"))
        dt.Columns.Add("QC", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "��������"
            db0 = get23(tmpMonthLow, tmpMonthhigh, "��")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(9)
            aaRow(7) = db0.Rows(0)(5)
            aaRow(8) = db0.Rows(0)(6)
            aaRow(9) = db0.Rows(0)(7)
            aaRow(10) = db0.Rows(0)(8)
            aaRow(11) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4) - db0.Rows(0)(5) - db0.Rows(0)(6) - db0.Rows(0)(7) - db0.Rows(0)(8) - db0.Rows(0)(9)  'ullage���
            dt.Rows.Add(aaRow)
        Next
        getNHDian3 = dt
    End Function
    '�ܺ�ˮ
    Private Function getNHSui3(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Water(Ton) Total", Type.GetType("System.String"))
        dt.Columns.Add("Fermentation", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Boiler", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "��������"
            db0 = get23(tmpMonthLow, tmpMonthhigh, "ˮ")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(5)
            aaRow(7) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4) - db0.Rows(0)(5) 'ullage(���/����
            dt.Rows.Add(aaRow)
        Next
        getNHSui3 = dt
    End Function
    '�ܺ�����
    Private Function getNHQi3(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Steam (Ton) Total", Type.GetType("System.String"))
        dt.Columns.Add("Crude Oil", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Powder ��", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        dt.Columns.Add("Air compressor Diesel(L)", Type.GetType("System.String"))
        dt.Columns.Add("Boiler Diesel (L) ", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "��������"
            db0 = get23(tmpMonthLow, tmpMonthhigh, "����")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4)  'ullage(���/����
            aaRow(7) = db0.Rows(0)(5) '����������
            aaRow(8) = db0.Rows(0)(6) '��¯������
            dt.Rows.Add(aaRow)
        Next
        getNHQi3 = dt
    End Function

    Private Function getsui13(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5 '��ˮ������ˮ���ͼ�ˮ���ۼ�һˮ���ۼ���ˮ
        zs = "tb_zls_zlszb"
        s1 = "tb_zls_hg + tb_zls_fx + tb_zls_pl + tb_zls_tca + tb_zls_tcb"
        s2 = "tb_zls_tc "
        s3 = "tb_zls_lfj"
        s4 = "tb_zls_js + tb_zls_cs + tb_zls_jx"
        s5 = "tb_zls_glf"
        's5 = "tb_zls_hg+tb_zls_fx+tb_zls_pl+tb_zls_pk+tb_zls_lst+tb_zls_wc+tb_zls_tc +tb_zls_tca+tb_zls_tcb+tb_zls_lfj+tb_zls_js+tb_zls_cs+tb_zls_jx" '�ֱ�֮�ͣ���13���ֱ�
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5
        Dim sql As String = "select top 1 " & szfc & " from tb_zls where tb_zls_rq< '" & str1 & "' order by  tb_zls_rq desc "
        ''''
        If str2 <> "" Then
            sql = clsql3(sql, "select tb_zls_hb from tb_zls where tb_zls_rq< '" & str2 & "' and  tb_zls_rq> '" & str1 & "' order by tb_zls_rq desc ")
        End If
        ''''
        getsui13 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getdian13(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5, s6, s7, s8, s9 '�ܵ磬���͵�,�ͼ���,�ۼ�һ��,�ۼ����磬�豸���������������У�qc,��¯��
        zs = "tb_dian_zjlg"
        s1 = "tb_dian_fxdlzb-tb_dian_sbdlwxj-tb_dian_yxsys+tb_dian_qcdl+tb_dian_zcyfx-tb_dian_zczm-tb_dian_pka-tb_dian_pkb-tb_dian_pkc-tb_dian_wlzm"
        's1 = "tb_dian_zjlg + tb_dian_qcdl - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zczm - tb_dian_yxsys - tb_dian_zcdlzb - tb_dian_wlzm - tb_dian_pka - tb_dian_pkb - tb_dian_pkc - tb_dian_xfjdl"
        s2 = "tb_dian_tcdl + tb_dian_jldl + tb_dian_zczm * 0.5"
        s3 = "tb_dian_zcdlzb - tb_dian_yfdl - tb_dian_tcdl - tb_dian_qcdl - tb_dian_jldl + tb_dian_zczm * 0.5"
        s4 = "tb_dian_xfjdl"
        s5 = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm  - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl + tb_dian_sbdlzm - tb_dian_glf" '�豸����
        's5 = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl + tb_dian_sbdlzm" '�豸����
        s6 = "tb_dian_yxsys + tb_dian_yfdl" '����
        s7 = "tb_dian_wszdlyzm + tb_dian_zzm - tb_dian_sbdlzm + tb_dian_wlzm" '����
        s8 = "tb_dian_pka + tb_dian_pkb + tb_dian_pkc" 'qc
        s9 = "tb_dian_glf"
        's9 = "tb_dian_wszdlyzm+tb_dian_zzm+tb_dian_sbdlzm+tb_dian_mfzm+tb_dian_zcyfx+tb_dian_zczm+tb_dian_fxdlzb+tb_dian_zca+tb_dian_zcb+tb_dian_sbdlwxj+tb_dian_yxsys+tb_dian_zcdlzb+tb_dian_yfdl+tb_dian_tcdl+tb_dian_qcdl+tb_dian_jldl+tb_dian_wlzm+tb_dian_pka+tb_dian_pkb+tb_dian_pkc+tb_dian_xfjdl"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5 & "," & s6 & "," & s7 & "," & s8 & "," & s9
        Dim sql As String = "select top 1 " & szfc & " from tb_dian where tb_dian_rq< '" & str1 & "' order by tb_dian_rq desc "
        If str2 <> "" Then
            sql = clsql3(sql, "select tb_dian_hb from tb_dian where tb_dian_rq< '" & str2 & "' and tb_dian_rq> '" & str1 & "' order by tb_dian_rq desc ")
        End If
        getdian13 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getzqb13(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5 '����������������,�ͼ�����,�ۼ�һ����,�ۼ�������,�ܲ���,��¯����
        zs = "tb_zqb_zqzb+tb_zqb_zqzb2+tb_zqb_zqzb3" '�����ܱ�1+�����ܱ�2+�ۼ�������
        s1 = "tb_zqb_zxg + tb_zqb_jsdg + tb_zqb_xtg + tb_zqb_hg + tb_zqb_xsdg + tb_zqb_plj + tb_zqb_qc"
        s2 = "tb_zqb_tca + tb_zqb_tcb + tb_zqb_tcc + tb_zqb_jl"
        s3 = "tb_zqb_fj"
        's4 = "tb_zqb_zqzb - (" & s1 & "+" & s2 & "+" & s3 & ") /1000"
        s4 = "tb_zqb_zqzb3 /1000" '�������ܱ�3������,�����2010.4.28��13ʱ�޸�
        s5 = "tb_zqb_glcy/1000"
        ' s5 = "tb_zqb_cyzb"
        's6 = "tb_zqb_zxg+tb_zqb_jsdg+tb_zqb_xtg+tb_zqb_hg+tb_zqb_xsdg+tb_zqb_plj+tb_zqb_qc+tb_zqb_tca+tb_zqb_tcb+tb_zqb_tcc+tb_zqb_fj+tb_zqb_jl"
        Dim szfc As String = zs & ",(" & s1 & ")/1000,(" & s2 & ")/1000,(" & s3 & ")/1000," & s4 & "," & s5 & ",'0'"
        Dim sql As String = "select top 1 " & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql3(sql, "select tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "' order by tb_zqb_rq desc ")
        End If
        getzqb13 = GF_CreateDataSource(G_cnnstr, sql)
    End Function

    Private Function getZQ3(ByVal str1 As String, ByVal str2 As String) As DataTable '��Ȼ���ܱ�
        Dim zs '����Ȼ��
        zs = "tb_zqb_trqzb" '��Ȼ���ܱ�
        Dim szfc As String = zs
        Dim sql As String = "select top 1" & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql3(sql, "select top 1 tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' order by tb_zqb_rq desc ")
        End If
        'Dim sql As String = "select tb_zqb_trqzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "') and (tb_zqb_hb not Like '%��Ȼ���ܱ�%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        getZQ3 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getgas3(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs
        zs = "tb_zqb_trqzb"
        Dim szfc As String = zs
        Dim sql As String = "select top 1 " & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql3(sql, "select tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "' order by tb_zqb_rq desc ")
        End If
        getgas3 = GF_CreateDataSource(G_cnnstr, sql)
    End Function

    Private Function getCaiYou3(ByVal str1 As String, ByVal str2 As String) As Integer ''��ѹ����������,ʱ���������֮��
        Dim sql As String = "select tb_zqb_cyzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%��ѹ����������%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + cy.Rows(j)(0)
        Next
        getCaiYou3 = zcy
    End Function
    Private Function getCaiYou23(ByVal str1 As String, ByVal str2 As String) As Integer ''��¯��������,ʱ���������֮��
        Dim sql As String = "select tb_zqb_glcy from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%��¯��������%'or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        '��¯��������
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + cy.Rows(j)(0)
        Next
        getCaiYou23 = zcy
    End Function
    '���ڡ��������ܵ�ʵ��
    '��sql�����д����������ֶα�Ϊ����0
    Private Function clsql3(ByVal sql As String, ByVal sql2 As String) As String 'sqlΪ������sql�ַ�����sql2Ϊ��ѯ�����¼sql�ַ���
        Dim hbdb As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        Dim ccc As String = ""
        For i As Integer = 0 To hbdb.Rows.Count - 1
            If hbdb.Rows(i)(0).GetType Is Type.GetType("System.String") Then
                ccc = ccc & hbdb.Rows(i)(0) & ","
            End If
        Next
        ccc = GF_removedh(ccc)
        Dim ctableName As String = GF_zhzfccx(ccc) '��ѯֹʱ��������¼�ġ������ֶ�����
        hbdb = GF_CreateDataSource(G_cnnstr, "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_mx in(" & ctableName & ")") '�������ֶ����ݶ�ӦӢ���ֶ�����DATATABLE

        For i As Integer = 0 To hbdb.Rows.Count - 1
            If hbdb.Rows(i)(0) = "tb_zls_tc" Then
                hbdb.Rows(i)(0) = "tb_zls_tc "
            End If
            sql = Replace(sql, hbdb.Rows(i)(0), "0") 'hbdb.Rows(i)(0)�ǡ������ֶ����ݶ�ӦӢ���ֶ�����
        Next
        clsql3 = sql
    End Function
    Private Function get23(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As DataTable
        Dim k1, k2 As New DataTable
        str2 = str2 & " 23:59:59"
        If str3 = "ˮ" Then
            k1 = getsui13(str1, str2)
            k2 = getsui13(str2, "")

        ElseIf str3 = "��" Then
            k1 = getdian13(str1, str2)
            k2 = getdian13(str2, "")
        ElseIf str3 = "����" Then
            k1 = getzqb13(str1, str2)
            k2 = getzqb13(str2, "")
        ElseIf str3 = "��Ȼ��" Then
            k1 = getZQ3(str1, str2)
            k2 = getZQ3(str2, "")
        End If
        Dim kk As DataTable = k1.Clone
        Dim row As DataRow = kk.NewRow()
        For i As Integer = 0 To k1.Columns.Count - 1
            row(i) = k2.Rows(0)(i) - k1.Rows(0)(i)
            If str3 = "����" And i = 6 Then
                row(5) = getCaiYou3(str1, str2) '�����ܱ�,ʱ���������֮��
            End If
            If str3 = "����" And i = 6 Then
                row(6) = getCaiYou23(str1, str2)
            End If
        Next
        kk.Rows.Add(row)
        get23 = kk
    End Function
End Class