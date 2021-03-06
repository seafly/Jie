Public Class frnhyb

    Private Sub frnhyb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1) : Call GS_niansl(nian2)
        yue1.Text = "01" : yue2.Text = Format(Now, "MM") '将月份显示为带前导零的数字
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False : Button1.Text = "统计中，请稍候……"
        Call showGrid(nian1.Text)
        Button1.Enabled = True : Button1.Text = "查询"
    End Sub
    Private Sub showGrid(ByVal str As Integer)
        '统计时间段字符串
        Dim sj1 As String = nian1.Text & "-" & yue1.Text & "-26"
        Dim sj11 As String = nian1.Text & "-" & yue1.Text & "-25"
        Dim sj2 As String = nian2.Text & "-" & yue2.Text & "-25"
        Dim nianyue1 As String = nian1.Text & "-" & yue1.Text
        Dim nianyue2 As String = nian2.Text & "-" & yue2.Text
        Dim yuefen As String = ""
        Dim n As Integer
        n = DateDiff("m", CDate(sj1), CDate(sj2))
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i, CDate(sj1))
            Dim jssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj11))
            yuefen = yuefen & Format(kssj, "yyyy-MM-dd") & "," & Format(jssj, "yyyy-MM-dd") & ","
        Next

        '创建dbTol，用于合并db1、db2……
        Dim dbTol As DataTable = New DataTable
        dbTol.Columns.Add("能耗数据", Type.GetType("System.String"))
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj1))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "计量用量", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "调整后用量", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "分摊", Type.GetType("System.String"))
            dbTol.Columns.Add(Format(kssj, "yyyy-MM") & "新锅炉分摊后", Type.GetType("System.String"))
        Next

        Dim dt_temp As DataTable
        Dim aaRow As DataRow
        '************以下通过数据库得到计量用量************
        '水-计量用量
        dt_temp = getNHSui(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '电-计量用量
        dt_temp = getNHDian(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '蒸汽-计量用量
        dt_temp = getNHQi(yuefen)
        dt_temp = GF_DataTableChange(dt_temp)
        Call hbDT(dt_temp, dbTol)
        '************以下通过运算得到其它数据************
        Dim NHFT As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_nhft") '能耗分摊

        With dbTol
            '分摊电
            For j As Integer = 3 To .Columns.Count - 1 Step 4
                Dim JYQ As Double = GF_jsColumnTotal(dbTol, j - 2, 14, 16) '技术、运行、QC用电量之和
                Dim sj As String = "tb_nhft_rq='" & Microsoft.VisualBasic.Left(.Columns(j - 1).Caption, 7) & "-25" & "'"

                Dim FTXS As Double
                Try
                    FTXS = GF_cnwithen(NHFT, sj, 4)
                    .Rows(8)(j) = .Rows(13)(j - 2) + JYQ * FTXS  '发酵分摊量=设备+（技术、运行、QC用电量之和）*分摊系数
                    .Rows(8)(j) = FormatNumber(.Rows(8)(j), 2) '2位小数
                Catch ex As Exception
                    FTXS = 0
                    .Rows(8)(j) = 0
                End Try
                Try
                    .Rows(9)(j) = JYQ * GF_cnwithen(NHFT, sj, 7)  '其他分摊量=（技术、运行、QC用电量之和）*分摊系数
                    .Rows(10)(j) = JYQ * GF_cnwithen(NHFT, sj, 10)
                    .Rows(11)(j) = JYQ * GF_cnwithen(NHFT, sj, 13)
                    .Rows(9)(j) = FormatNumber(.Rows(9)(j), 2) '2位小数
                    .Rows(10)(j) = FormatNumber(.Rows(10)(j), 2) '2位小数
                    .Rows(11)(j) = FormatNumber(.Rows(11)(j), 2) '2位小数
                Catch ex As Exception
                    .Rows(9)(j) = 0 : .Rows(10)(j) = 0 : .Rows(11)(j) = 0
                End Try
                .Rows(7)(j) = GF_jsColumnTotal(dbTol, j, 8, 11)
            Next

            '调整后用量
            For j As Integer = 2 To .Columns.Count - 1 Step 4
                Dim SuiYS, QiYS As Double
                Try
                    SuiYS = (.Rows(0)(j - 1) - .Rows(5)(j - 1)) / GF_jsColumnTotal(dbTol, j - 1, 1, 4) '用水总量/各部门计量用量之和
                Catch ex As Exception
                    SuiYS = 0
                End Try
                Try
                    QiYS = GF_jsColumnTotal(dbTol, j - 1, 19, 22) / .Rows(18)(j - 1) '各部门计量用量之和/用气总量;(SUM(C20:C23)/C19)
                Catch ex As Exception
                    QiYS = 0
                End Try
                '水
                .Rows(1)(j) = FormatNumber(Null2zero(.Rows(1)(j - 1)) * SuiYS, 2)
                .Rows(2)(j) = FormatNumber(Null2zero(.Rows(2)(j - 1)) * SuiYS, 2)
                .Rows(3)(j) = FormatNumber(Null2zero(.Rows(3)(j - 1)) * SuiYS, 2)
                .Rows(4)(j) = FormatNumber(Null2zero(.Rows(4)(j - 1)) * SuiYS, 2)
                .Rows(5)(j) = .Rows(5)(j - 1)

                '蒸汽
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
                '电
                .Rows(8)(j) = FormatNumber(CDbl(.Rows(8)(j - 1)) + CDbl(.Rows(8)(j + 1)), 2)
                .Rows(9)(j) = FormatNumber(CDbl(.Rows(9)(j - 1)) + CDbl(.Rows(9)(j + 1)), 2)
                .Rows(10)(j) = FormatNumber(CDbl(.Rows(10)(j - 1)) + CDbl(.Rows(10)(j + 1)), 2)
                .Rows(11)(j) = FormatNumber(CDbl(.Rows(11)(j - 1)) + CDbl(.Rows(11)(j + 1)), 2)
                .Rows(12)(j) = .Rows(12)(j - 1)
            Next

        End With
        'Unit  Consumption
        Dim NHPrice As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_nhjg") '能耗价格
        Dim sui, dian, qi, you, trq As Double
        Try
            sui = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian2.Text & " and tb_nhjg_lb='水'", 1)
            dian = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian2.Text & " and tb_nhjg_lb='电'", 1)
            qi = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian2.Text & " and tb_nhjg_lb='气'", 1)
            you = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian2.Text & " and tb_nhjg_lb='油'", 1)
            trq = GF_cnwithen(NHPrice, "tb_nhjg_nf=" & nian2.Text & " and tb_nhjg_lb='天然气'", 1)
        Catch ex As Exception
            MsgBox("对不起，因为没有填写所选年的能耗单价，故不能完成统计！") : Exit Sub
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
            ''''''''''''''''''''''''''''''''''''''''"Powder Ⅰ"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder Ⅰ"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(21)(i + 1) / .Rows(18)(i)) * .Rows(25)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''' "Powder Ⅱ"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder Ⅱ"
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
            aaRow(0) = "Natural gas (M³)"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Dim sj As String = GF_yuefen1(Microsoft.VisualBasic.Left(.Columns(i).Caption, 4))
                Dim yuefen1() As String
                yuefen1 = Split(sj, ",")
                Dim sql As String = "tb_zqb_rq between '" & yuefen1((Mid(.Columns(i).Caption, 6, 2) - 1) * 2) & "' and '" & yuefen1((Mid(.Columns(i).Caption, 6, 2) - 1) * 2 + 1) & "' order by tb_zqb_rq"
                sql = "select tb_zqb_trqzb+tb_zqb_trqxg from tb_zqb where " & sql
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
            ''''''''''''''''''''''''''''''''''''''''"Powder Ⅰ"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder Ⅰ"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(21)(i + 1) / .Rows(18)(i)) * .Rows(31)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''' "Powder Ⅱ"
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder Ⅱ"
            For i As Integer = 1 To .Columns.Count - 1 Step 4
                Try
                    aaRow(i + 3) = FormatNumber((.Rows(22)(i + 1) / .Rows(18)(i)) * .Rows(31)(i), 2)
                Catch ex As Exception
                    aaRow(i) = "0"
                End Try
            Next
            dbTol.Rows.Add(aaRow)
            '''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''锅炉分摊后''''''''''''''''''''''''''''
            For j As Integer = 2 To .Columns.Count - 1 Step 4
                ''''''水
                .Rows(1)(j + 2) = FormatNumber(Null2zero((.Rows(19)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(1)(j)), 2)
                .Rows(2)(j + 2) = FormatNumber(Null2zero((.Rows(20)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(2)(j)), 2)
                .Rows(3)(j + 2) = FormatNumber(Null2zero((.Rows(21)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(3)(j)), 2)
                .Rows(4)(j + 2) = FormatNumber(Null2zero((.Rows(22)(j) / .Rows(18)(j - 1)) * .Rows(5)(j - 1) + .Rows(4)(j)), 2)
                ''''''电
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
            ''''''''''''''''''''''''''''''''''''''''''''"Powder (Yuan/kg) Ⅰ
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder (Yuan/kg) Ⅰ"
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
            ''''''''''''''''''''''''''''''''''''''''''''Powder (Yuan/kg) Ⅱ
            aaRow = dbTol.NewRow()
            aaRow(0) = "Powder (Yuan/kg) Ⅱ"
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


        Call GS_useviewbydb2(ListView1, dbTol, -1, 80)
        ListView1.BeginUpdate()
        '设置颜色、宽度
        With ListView1
            .Columns(0).Width = 170
            For i As Integer = 0 To .Items.Count - 1
                .Items(i).UseItemStyleForSubItems = False
                .Items(i).SubItems(0).BackColor = Color.LightPink '部门
                For j As Integer = 1 To .Columns.Count - 1 Step 8
                    .Items(i).SubItems(j).BackColor = Color.LightBlue
                    .Items(i).SubItems(j + 1).BackColor = .Items(i).SubItems(j).BackColor
                    .Items(i).SubItems(j + 2).BackColor = .Items(i).SubItems(j).BackColor
                    .Items(i).SubItems(j + 3).BackColor = .Items(i).SubItems(j).BackColor
                    Try
                        .Items(i).SubItems(j + 4).BackColor = Color.LightGreen
                        .Items(i).SubItems(j + 5).BackColor = .Items(i).SubItems(j + 4).BackColor
                        .Items(i).SubItems(j + 6).BackColor = .Items(i).SubItems(j + 4).BackColor
                        .Items(i).SubItems(j + 7).BackColor = .Items(i).SubItems(j + 4).BackColor
                    Catch ex As Exception
                    End Try
                Next
            Next
            For j As Integer = 1 To .Columns.Count - 1 Step 4 '宽度
                .Columns(j).Width = 130
                .Columns(j + 1).Width = 130
                .Columns(j + 2).Width = 130
                .Columns(j + 3).Width = 130
            Next
            'style
            Dim font0 As New Font("宋体", 16, FontStyle.Bold, GraphicsUnit.Pixel)
            For j As Integer = 0 To .Columns.Count - 1
                ListView1.Items(0).SubItems(j).Font = font0
                ListView1.Items(7).SubItems(j).Font = font0
                ListView1.Items(18).SubItems(j).Font = font0
                ListView1.Items(26).SubItems(j).Font = font0
                ListView1.Items(31).SubItems(j).Font = font0
                ListView1.Items(36).SubItems(j).Font = font0
            Next
        End With
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大
        ListView1.EndUpdate()
    End Sub
    '能耗电
    Private Function getNHDian(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Electricity (KW·H) Total", Type.GetType("System.String"))
        dt.Columns.Add("Fermentation", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder Ⅰ", Type.GetType("System.String"))
        dt.Columns.Add("Powder Ⅱ", Type.GetType("System.String")) '5
        dt.Columns.Add(" Boiler", Type.GetType("System.String"))
        dt.Columns.Add("公用电:设备动力部", Type.GetType("System.String"))
        dt.Columns.Add("技术部", Type.GetType("System.String"))
        dt.Columns.Add("运行部", Type.GetType("System.String"))
        dt.Columns.Add("QC", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '分解月份字符串的数组
        Dim tmpMonthLow As String '临时低位日期
        Dim tmpMonthhigh As String '临时高位日期
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "计量用量"
            db0 = get2(tmpMonthLow, tmpMonthhigh, "电")
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
            aaRow(11) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4) - db0.Rows(0)(5) - db0.Rows(0)(6) - db0.Rows(0)(7) - db0.Rows(0)(8) - db0.Rows(0)(9)  'ullage损耗
            dt.Rows.Add(aaRow)
        Next
        getNHDian = dt
    End Function
    '能耗水
    Private Function getNHSui(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Water(ton) Total", Type.GetType("System.String"))
        dt.Columns.Add("Fermentation", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder Ⅰ", Type.GetType("System.String"))
        dt.Columns.Add("Powder Ⅱ", Type.GetType("System.String"))
        dt.Columns.Add("Boiler", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '分解月份字符串的数组
        Dim tmpMonthLow As String '临时低位日期
        Dim tmpMonthhigh As String '临时高位日期
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "计量用量"
            db0 = get2(tmpMonthLow, tmpMonthhigh, "水")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(5)
            aaRow(7) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4) - db0.Rows(0)(5) 'ullage(损耗/公用
            dt.Rows.Add(aaRow)
        Next
        getNHSui = dt
    End Function
    '能耗蒸汽
    Private Function getNHQi(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        dt.Columns.Add("", Type.GetType("System.String"))
        dt.Columns.Add("Steam (ton) Total", Type.GetType("System.String"))
        dt.Columns.Add("Crude Oil", Type.GetType("System.String"))
        dt.Columns.Add("Oil", Type.GetType("System.String"))
        dt.Columns.Add("Powder Ⅰ", Type.GetType("System.String"))
        dt.Columns.Add("Powder Ⅱ", Type.GetType("System.String"))
        dt.Columns.Add("Ullage", Type.GetType("System.String"))
        dt.Columns.Add("Air compressor Diesel(L)", Type.GetType("System.String"))
        dt.Columns.Add("Boiler Diesel (L) ", Type.GetType("System.String"))
        Dim db0 As DataTable
        Dim monthArr() As String = Split(monthStr, ",")  '分解月份字符串的数组
        Dim tmpMonthLow As String '临时低位日期
        Dim tmpMonthhigh As String '临时高位日期
        Dim aaRow As DataRow
        For i As Integer = 2 To monthArr.Length Step 2
            aaRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            aaRow(0) = Format(CDate(tmpMonthhigh), "yyyy-MM") & "计量用量"
            db0 = get2(tmpMonthLow, tmpMonthhigh, "蒸汽")
            aaRow(1) = db0.Rows(0)(0)
            aaRow(2) = db0.Rows(0)(1)
            aaRow(3) = db0.Rows(0)(2)
            aaRow(4) = db0.Rows(0)(3)
            aaRow(5) = db0.Rows(0)(4)
            aaRow(6) = db0.Rows(0)(0) - db0.Rows(0)(1) - db0.Rows(0)(2) - db0.Rows(0)(3) - db0.Rows(0)(4)  'ullage(损耗/公用
            aaRow(7) = db0.Rows(0)(5) '空气机柴油
            aaRow(8) = db0.Rows(0)(6) '锅炉房柴油
            dt.Rows.Add(aaRow)
        Next
        getNHQi = dt
    End Function

    Private Function getsui1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5 '总水，发酵水，油剂水，粉剂一水，粉剂二水
        zs = "tb_zls_zlszb"
        s1 = "tb_zls_hg + tb_zls_fx + tb_zls_pl + tb_zls_tca + tb_zls_tcb"
        s2 = "tb_zls_tc "
        s3 = "tb_zls_lfj"
        s4 = "tb_zls_js + tb_zls_cs + tb_zls_jx"
        s5 = "tb_zls_glf"
        's5 = "tb_zls_hg+tb_zls_fx+tb_zls_pl+tb_zls_pk+tb_zls_lst+tb_zls_wc+tb_zls_tc +tb_zls_tca+tb_zls_tcb+tb_zls_lfj+tb_zls_js+tb_zls_cs+tb_zls_jx" '分表之和，共13个分表
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5
        Dim sql As String = "select top 1 " & szfc & " from tb_zls where tb_zls_rq< '" & str1 & "' order by  tb_zls_rq desc "
        ''''
        If str2 <> "" Then
            sql = clsql(sql, "select tb_zls_hb from tb_zls where tb_zls_rq< '" & str2 & "' and  tb_zls_rq> '" & str1 & "' order by tb_zls_rq desc ")
        End If
        ''''
        getsui1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getdian1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5, s6, s7, s8, s9 '总电，发酵电,油剂电,粉剂一电,粉剂二电，设备动力，技术，运行，qc,锅炉电
        zs = "tb_dian_zjlg"
        s1 = "tb_dian_fxdlzb-tb_dian_sbdlwxj-tb_dian_yxsys+tb_dian_qcdl+tb_dian_zcyfx-tb_dian_zczm-tb_dian_pka-tb_dian_pkb-tb_dian_pkc-tb_dian_wlzm"
        's1 = "tb_dian_zjlg + tb_dian_qcdl - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zczm - tb_dian_yxsys - tb_dian_zcdlzb - tb_dian_wlzm - tb_dian_pka - tb_dian_pkb - tb_dian_pkc - tb_dian_xfjdl"
        s2 = "tb_dian_tcdl + tb_dian_jldl + tb_dian_zczm * 0.5"
        s3 = "tb_dian_zcdlzb - tb_dian_yfdl - tb_dian_tcdl - tb_dian_qcdl - tb_dian_jldl + tb_dian_zczm * 0.5"
        s4 = "tb_dian_xfjdl+tb_dian_5t" '粉剂二电
        s5 = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl + tb_dian_sbdlzm - tb_dian_glf-tb_dian_5t" '设备动力
        's5 = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl + tb_dian_sbdlzm" '设备动力
        s6 = "tb_dian_yxsys + tb_dian_yfdl" '技术
        s7 = "tb_dian_wszdlyzm + tb_dian_zzm - tb_dian_sbdlzm + tb_dian_wlzm" '运行
        s8 = "tb_dian_pka + tb_dian_pkb + tb_dian_pkc" 'qc
        s9 = "tb_dian_glf"
        's9 = "tb_dian_wszdlyzm+tb_dian_zzm+tb_dian_sbdlzm+tb_dian_mfzm+tb_dian_zcyfx+tb_dian_zczm+tb_dian_fxdlzb+tb_dian_zca+tb_dian_zcb+tb_dian_sbdlwxj+tb_dian_yxsys+tb_dian_zcdlzb+tb_dian_yfdl+tb_dian_tcdl+tb_dian_qcdl+tb_dian_jldl+tb_dian_wlzm+tb_dian_pka+tb_dian_pkb+tb_dian_pkc+tb_dian_xfjdl"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5 & "," & s6 & "," & s7 & "," & s8 & "," & s9
        Dim sql As String = "select top 1 " & szfc & " from tb_dian where tb_dian_rq< '" & str1 & "' order by tb_dian_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select tb_dian_hb from tb_dian where tb_dian_rq< '" & str2 & "' and tb_dian_rq> '" & str1 & "' order by tb_dian_rq desc ")
        End If
        getdian1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getzqb1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs, s1, s2, s3, s4, s5 '总蒸汽，发酵蒸汽,油剂蒸汽,粉剂一蒸汽,粉剂二蒸汽,总柴油,锅炉柴油
        zs = "tb_zqb_zqzb+tb_zqb_zqzb2+tb_zqb_zqzb3/1000" '蒸汽总表1+蒸汽总表2+蒸汽总表3
        s1 = "tb_zqb_zxg + tb_zqb_jsdg + tb_zqb_xtg + tb_zqb_hg + tb_zqb_xsdg + tb_zqb_plj + tb_zqb_qc"
        s2 = "tb_zqb_tca + tb_zqb_tcb + tb_zqb_tcc + tb_zqb_jl"
        s3 = "tb_zqb_fj"
        's4 = "tb_zqb_zqzb - (" & s1 & "+" & s2 & "+" & s3 & ") /1000"
        's4 = "tb_zqb_fj2 /1000"
        s4 = "tb_zqb_zqzb3 /1000" '读蒸汽总表3的数据,李锂于2010.4.28日13时修改
        s5 = "tb_zqb_glcy/1000"
        ' s5 = "tb_zqb_cyzb"
        's6 = "tb_zqb_zxg+tb_zqb_jsdg+tb_zqb_xtg+tb_zqb_hg+tb_zqb_xsdg+tb_zqb_plj+tb_zqb_qc+tb_zqb_tca+tb_zqb_tcb+tb_zqb_tcc+tb_zqb_fj+tb_zqb_jl"
        Dim szfc As String = zs & ",(" & s1 & ")/1000,(" & s2 & ")/1000,(" & s3 & ")/1000," & s4 & "," & s5 & ",'0'"
        Dim sql As String = "select top 1 " & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "' order by tb_zqb_rq desc ")
        End If
        getzqb1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function

    Private Function getZQ(ByVal str1 As String, ByVal str2 As String) As DataTable '天然气总表
        Dim zs '总天然气
        zs = "tb_zqb_trqzb+tb_zqb_trqxg " '天然气总表
        Dim szfc As String = zs
        Dim sql As String = "select top 1" & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' order by tb_zqb_rq desc ")
        End If
        'Dim sql As String = "select tb_zqb_trqzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "') and (tb_zqb_hb not Like '%天然气总表%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'柴油总表')=0 and tb_zqb_hb<>'柴油总表'" )
        getZQ = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getgas(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs
        zs = "tb_zqb_trqzb+tb_zqb_trqxg"
        Dim szfc As String = zs
        Dim sql As String = "select top 1 " & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "' order by tb_zqb_rq desc ")
        End If
        getgas = GF_CreateDataSource(G_cnnstr, sql)
    End Function

    Private Function getCaiYou(ByVal str1 As String, ByVal str2 As String) As Integer ''空压机柴油用量,时间段内数据之和
        Dim sql As String = "select tb_zqb_cyzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%空压机柴油用量%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'柴油总表')=0 and tb_zqb_hb<>'柴油总表'" )
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + cy.Rows(j)(0)
        Next
        getCaiYou = zcy
    End Function
    Private Function getCaiYou2(ByVal str1 As String, ByVal str2 As String) As Integer ''锅炉柴油用量,时间段内数据之和
        Dim sql As String = "select tb_zqb_glcy from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%锅炉柴油用量%'or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'柴油总表')=0 and tb_zqb_hb<>'柴油总表'" )
        '锅炉柴油用量
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + cy.Rows(j)(0)
        Next
        getCaiYou2 = zcy
    End Function
    '用于“换表”功能的实现
    '对sql语句进行处理，将换表字段变为数字0
    Private Function clsql(ByVal sql As String, ByVal sql2 As String) As String 'sql为待处理sql字符串；sql2为查询换表记录sql字符串
        Dim hbdb As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        Dim ccc As String = ""
        For i As Integer = 0 To hbdb.Rows.Count - 1
            If hbdb.Rows(i)(0).GetType Is Type.GetType("System.String") Then
                ccc = ccc & hbdb.Rows(i)(0) & ","
            End If
        Next
        ccc = GF_removedh(ccc)
        Dim ctableName As String = GF_zhzfccx(ccc) '查询止时间那条记录的“换表”字段数据
        hbdb = GF_CreateDataSource(G_cnnstr, "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_mx in(" & ctableName & ")") '“换表”字段数据对应英文字段名称DATATABLE

        For i As Integer = 0 To hbdb.Rows.Count - 1
            If hbdb.Rows(i)(0) = "tb_zls_tc" Then
                hbdb.Rows(i)(0) = "tb_zls_tc "
            End If
            sql = Replace(sql, hbdb.Rows(i)(0), "0") 'hbdb.Rows(i)(0)是“换表”字段数据对应英文字段名称
        Next
        clsql = sql
    End Function
    Private Function get2(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As DataTable
        Dim k1, k2 As New DataTable
        str2 = str2 & " 23:59:59"
        If str3 = "水" Then
            k1 = getsui1(str1, str2)
            k2 = getsui1(str2, "")

        ElseIf str3 = "电" Then
            k1 = getdian1(str1, str2)
            k2 = getdian1(str2, "")
        ElseIf str3 = "蒸汽" Then
            k1 = getzqb1(str1, str2)
            k2 = getzqb1(str2, "")
        ElseIf str3 = "天然气" Then
            k1 = getZQ(str1, str2)
            k2 = getZQ(str2, "")
        End If
        Dim kk As DataTable = k1.Clone
        Dim row As DataRow = kk.NewRow()
        For i As Integer = 0 To k1.Columns.Count - 1
            row(i) = k2.Rows(0)(i) - k1.Rows(0)(i)
            If str3 = "蒸汽" And i = 6 Then
                row(5) = getCaiYou(str1, str2) '柴油总表,时间段内数据之和
            End If
            If str3 = "蒸汽" And i = 6 Then
                row(6) = getCaiYou2(str1, str2)
            End If
        Next
        kk.Rows.Add(row)
        get2 = kk
    End Function
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian1.Text & "年能耗月报", Me)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    '状态锁定
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sj1 As String = nian1.Text & "-" & yue1.Text & "-26"
        Dim sj2 As String = nian2.Text & "-" & yue2.Text & "-25 23:59:59"
        Dim sql As String
        Dim ziddb As DataTable
        Dim zid As String
        '蒸汽、柴油
        sql = "select top 1 tb_zqb_id from tb_zqb where tb_zqb_rq< '" & sj1 & "' order by tb_zqb_rq desc"
        ziddb = GF_CreateDataSource(G_cnnstr, sql)
        zid = ziddb.Rows(0)(0) & ","
        sql = "select tb_zqb_id from tb_zqb where tb_zqb_rq< '" & sj2 & "' and tb_zqb_rq> '" & sj1 & "' "
        ziddb = GF_CreateDataSource(G_cnnstr, sql)
        For j As Integer = 0 To ziddb.Rows.Count - 1
            zid = zid & ziddb.Rows(j)(0) & ","
        Next
        zid = GF_removedh(zid)
        MsgBox("蒸汽、柴油" & zid)
        '电
        sql = "select top 1 tb_dian_id from tb_dian where tb_dian_rq< '" & sj1 & "' order by tb_dian_rq desc"
        ziddb = GF_CreateDataSource(G_cnnstr, sql)
        zid = ziddb.Rows(0)(0) & ","
        sql = "select tb_dian_id from tb_dian where tb_dian_rq< '" & sj2 & "' and tb_dian_rq> '" & sj1 & "' "
        ziddb = GF_CreateDataSource(G_cnnstr, sql)
        For j As Integer = 0 To ziddb.Rows.Count - 1
            zid = zid & ziddb.Rows(j)(0) & ","
        Next
        zid = GF_removedh(zid)
        MsgBox("电" & zid)
        '自来水
        sql = "select top 1 tb_zls_id from tb_zls where tb_zls_rq< '" & sj1 & "' order by tb_zls_rq desc"
        ziddb = GF_CreateDataSource(G_cnnstr, sql)
        zid = ziddb.Rows(0)(0) & ","
        sql = "select tb_zls_id from tb_zls where tb_zls_rq< '" & sj2 & "' and tb_zls_rq> '" & sj1 & "' "
        ziddb = GF_CreateDataSource(G_cnnstr, sql)
        zid = ""
        For j As Integer = 0 To ziddb.Rows.Count - 1
            zid = zid & ziddb.Rows(j)(0) & ","
        Next
        zid = GF_removedh(zid)
        MsgBox("自来水" & zid)

    End Sub
End Class