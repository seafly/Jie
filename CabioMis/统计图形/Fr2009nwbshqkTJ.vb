﻿Public Class Fr2009nwbshqkTJ

    Private Sub Fr2009nwbshqkTJ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_niansl(ComboBox1)
        Dim LB As String() = {"HuBei", "WuHan"}
        GS_wlbktlr3(ComboBox2, LB, "")
    End Sub

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Dim l() As String = {"Customer audit", "Government audit", "Other audit(The Food Safety&QA systems)"}
        Dim n As Integer = ComboBox1.Text
        Dim dj As DataTable = GF_GetMonthDb()
        Dim datedb As DataTable = GF_GetCountDateTb(n, 26, False) '生成一个统计年度的月份起止的日期DB，参数代表年，统计日起，是否加入时分秒
        With dj
            For q As Integer = 0 To UBound(l)
                Dim zsj As String = ""
                Dim lb As String = l(q)
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                Dim dr As DataRow = .NewRow
                Dim hj As Double = 0
                dr(0) = q + 1 : dr(1) = l(q)
                '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                For i As Integer = 0 To datedb.Rows.Count - 1
                    Dim tt1, tt2 As String
                    tt1 = datedb.Rows(i)(0) : tt2 = datedb.Rows(i)(1)
                    Dim sql As String = "select count(*) from tb_2009nwbshqktj where tb_2009nwbshqktj_rq between '" & tt1 & "' and '" & tt2 & "'"

                    sql &= " and tb_2009nwbshqktj_shlb='" & lb & "' and tb_2009nwbshqktj_shdx='" & ComboBox2.Text & "'"


                    Dim dt11 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                    zsj &= dt11.Rows(0)(0) & ","
                    hj += dt11.Rows(0)(0)
                    dr(2 + i) = dt11.Rows(0)(0)
                Next

                dr(14) = hj
                .Rows.Add(dr)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim k As DataRow = .NewRow
            k(0) = dj.Rows.Count + 1 : k(1) = "Total"

            For i As Integer = 2 To 14
                k(i) = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dj, i, 0, dj.Rows.Count - 1)
            Next
            .Rows.Add(k)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End With
        '''''''''''''''''''''''''''''''''
        showl.DataSource = dj
        showchart(dj)
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub

    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub

    Private Sub showchart(ByVal dj As DataTable)
        Dim ys(2) As Color
        ys(0) = Color.Blue : ys(1) = Color.Red : ys(2) = Color.Green
        ClassDeepChart.G_Chart_ShowColumn(Chart1, False, dj, "External audit statistic for  " & ComboBox2.Text & ComboBox1.Text, DataVisualization.Charting.Docking.Bottom, Color.Blue, ys, 2, dj.Columns.Count - 2, 0, dj.Rows.Count - 2)
    End Sub

    Private Sub showl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles showl.CellEndEdit
        Dim dj As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl)
        showchart(dj)
    End Sub
End Class