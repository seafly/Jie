Imports _D = CabioMis.Cl_DataMag
Imports _S = CabioMis.Cl_StrMag

''' <summary>
''' 年度订单交付率统计表
''' </summary>
Public Class Frddzqzfl
    Private Sub Frddzqzfl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""

        ComboBox1.Text = Year(DateTime.Now)

        GroupBox2.Text = ComboBox1.Text & "年度订单交付率统计表"
        'showTj()

    End Sub

    Private Sub showTj()
        '内存中建立数据表，由13列组成，一个空列，12个所选年的月份
        Dim dtTj As DataTable = New DataTable
        dtTj.Columns.Add("统计项目")
        For i As Integer = 1 To 12
            dtTj.Columns.Add(i & "月")
        Next
        dtTj.Columns.Add("总计")

        Dim sql As String = ""
        '按订单号归属月的分组统计
        sql = "select count(*) as sl,year(tb_dd_ddgsyf) as nd,month(tb_dd_ddgsyf) as yf from " &
        "(select tb_dd_ddgsyf,tb_dd_ddh from tb_dd where tb_dd_ddh is not null and year(tb_dd_ddgsyf)=" & ComboBox1.Text & vbCrLf & _
        "group by tb_dd_ddgsyf,tb_dd_ddh) as dt" & vbCrLf & _
        "group by tb_dd_ddgsyf"
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)

        '填充内存数据表
        Dim dr As DataRow = dtTj.NewRow
        dr(0) = "订单数"
        For i As Integer = 1 To 12
            Try
                dr(i) = dt.Select("yf=" & i)(0)(0)
            Catch ex As Exception
                dr(i) = 0
            End Try
        Next
        dr("总计") = dt.Compute("sum(sl)", "")
        dtTj.Rows.Add(dr)
        '按计划发货日期分组统计发货单数
        sql = "select count(*) as sl,nd,yf from " & vbCrLf & _
        "(select year(tb_dd_ddgsyf) as nd, month(tb_dd_ddgsyf) as yf,tb_dd_fhtjdh from tb_dd where tb_dd_fhtjdh is not null and year(tb_dd_ddgsyf)=" & ComboBox1.Text & vbCrLf & _
        "group by year(tb_dd_ddgsyf) , month(tb_dd_ddgsyf),tb_dd_fhtjdh) as dt" & vbCrLf & _
        "group by nd,yf"
        dt = _D.GF_CreateDataSource(sql)
        dr = dtTj.NewRow
        dr(0) = "发货单数"
        For i As Integer = 1 To 12
            Try
                dr(i) = dt.Select("yf=" & i)(0)(0)
            Catch ex As Exception
                dr(i) = 0
            End Try
        Next
        dr("总计") = dt.Compute("sum(sl)", "")
        dtTj.Rows.Add(dr)
        '按计划发货日期分组统计发货单数，实际到货日期大于计划到货日期，即为延后到货
        sql = "select count(*) as sl,nd,yf from " & vbCrLf & _
        "(select year(tb_dd_ddgsyf) as nd, month(tb_dd_ddgsyf) as yf,tb_dd_fhtjdh from tb_dd where tb_dd_fhtjdh is not null  and tb_dd_sjdhrq>tb_dd_ddrq and year(tb_dd_ddgsyf)=" & ComboBox1.Text & vbCrLf & _
        "group by year(tb_dd_ddgsyf) , month(tb_dd_ddgsyf),tb_dd_fhtjdh) as dt" & vbCrLf & _
        "group by nd,yf"
        dt = _D.GF_CreateDataSource(sql)
        dr = dtTj.NewRow
        dr(0) = "延期单数"
        For i As Integer = 1 To 12
            Try
                dr(i) = dt.Select("yf=" & i)(0)(0)
            Catch ex As Exception
                dr(i) = 0
            End Try
        Next
        dr("总计") = _S.YanFormatNum(dt.Compute("sum(sl)", ""))
        dtTj.Rows.Add(dr)

        '计算准确交付率（行2/行1）
        dr = dtTj.NewRow
        dr(0) = "准确交付率"
        For i As Integer = 1 To 12
            Try
                dr(i) = IIf(dtTj.Rows(1)(i) = 0, 0, _S.YanFormatNum(1 - dtTj.Rows(2)(i) / dtTj.Rows(1)(i)) * 100 & "%")
            Catch ex As Exception
                dr(i) = 0
            End Try
        Next
        dr("总计") = IIf(dtTj.Rows(1)("总计") = 0, 0, _S.YanFormatNum(1 - _S.YanFormatNum(dtTj.Rows(2)("总计")) / dtTj.Rows(1)("总计")) * 100 & "%")
        dtTj.Rows.Add(dr)

        show1.DataSource = dtTj
        AddHandler show1.CellContentClick, AddressOf showXx
    End Sub
    Private Sub showXx(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 Then
            Return
        End If

        Dim strWh As String = ""
        Select Case e.RowIndex
            Case 0
                strWh = " and tb_dd_ddh is not null"
            Case 1
                strWh = " and tb_dd_fhtjdh is not null"
            Case 2
                strWh = " and tb_dd_fhtjdh is not null  and tb_dd_sjdhrq>tb_dd_ddrq"
        End Select
        strWh &= " and year(tb_dd_ddgsyf)=" & ComboBox1.Text
        If e.ColumnIndex < 13 Then
            strWh &= " and month(tb_dd_ddgsyf)=" & e.ColumnIndex
        End If
        Dim sql As String = ""
        sql = "select * from tb_dd where 1=1" & strWh

        Dim frTm As New Frzdybb_mx
        GS_DataGridViewbyDb(frTm.showl, _D.GF_CreateDataSource(sql), True, True)
        frTm.ShowDialog()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            showTj()
        Catch ex As Exception
            MessageBox.Show("对不起没有该年数据！")
        End Try

    End Sub
End Class