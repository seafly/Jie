Imports Microsoft.VisualBasic

''' <summary>
''' 检测及时率统计表
''' </summary>
Public Class FrYanJcJsl

    Dim m_dt As DataTable
    Private Sub Frddzqzfl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""

        ComboBox1.DataSource = _S.getNumToStr(2008, DateTime.Now.Year).Split(",")
        ComboBox1.Text = Year(DateTime.Now)

        GroupBox2.Text = ComboBox1.Text & "年度检测及时率统计表"
        showTj()

    End Sub

    Private Sub showTj()
        '内存中建立数据表，由13列组成，一个空列，12个所选年的月份
        Dim dtTj As DataTable = New DataTable
        dtTj.Columns.Add("统计项目")
        For i As Integer = 1 To 12
            dtTj.Columns.Add(i & "月")
        Next
        dtTj.Columns.Add("总计")

        Dim Sql As String = "select tjTb.*,tb_wp_njzq,datediff(day,tb_i259b_qcrq,tb_i259b_y840q)+1+tb_wp_njzq as xcs from " & vbCrLf & _
        "(select tb_i259b_i231a," & vbCrLf & _
        "tb_i259b_num," & vbCrLf & _
        "tb_i259b_qjrq," & vbCrLf & _
        "tb_i259b_qcrq," & vbCrLf & _
        "tb_i259b_y840q" & vbCrLf & _
        "from tb_i259b" & vbCrLf & _
        "where tb_i259b_sfqj='是'" & vbCrLf & _
        ") as tjTb left join tb_wp as b on tjtb.tb_i259b_i231a=b.tb_wp_dm"

        Dim dt As DataTable = _D.GF_CreateDataSource(Sql)
        '添加4个列，请检年度，请检月份，检测年度，检测月份
        dt.Columns.Add("qjnd", GetType(Integer))
        dt.Columns.Add("qjyf", GetType(Integer))
        dt.Columns.Add("qcnd", GetType(Integer))
        dt.Columns.Add("qcyf", GetType(Integer))
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim strQjrq As String = _S.YanNull(dt.Rows(i)("tb_i259b_qjrq"))
            If strQjrq = "" Then
                dt.Rows(i)("qjnd") = 0
                dt.Rows(i)("qjyf") = 0
            Else
                If DateDiff(DateInterval.Month, CType("2013-6-1", DateTime), CType(strQjrq, DateTime)) < 0 Then
                    If Month(strQjrq) = 12 And Day(strQjrq) >= 26 Then
                        dt.Rows(i)("qjnd") = Year(strQjrq) - 1
                        dt.Rows(i)("qjyf") = 1
                    Else
                        dt.Rows(i)("qjnd") = Year(strQjrq)
                        dt.Rows(i)("qjyf") = IIf(Day(strQjrq) >= 26, Month(strQjrq) + 1, Month(strQjrq))
                    End If
                Else
                    dt.Rows(i)("qjnd") = Year(strQjrq)
                    dt.Rows(i)("qjyf") = Month(strQjrq)
                End If
            End If

            strQjrq = _S.YanNull(dt.Rows(i)("tb_i259b_qcrq"))
            If strQjrq = "" Then
                dt.Rows(i)("qcnd") = 0
                dt.Rows(i)("qcyf") = 0
            Else
                If DateDiff(DateInterval.Month, CType("2013-6-1", DateTime), CType(strQjrq, DateTime)) < 0 Then
                    If Month(strQjrq) = 12 And Day(strQjrq) >= 26 Then
                        dt.Rows(i)("qcnd") = Year(strQjrq) - 1
                        dt.Rows(i)("qcyf") = 1
                    Else
                        dt.Rows(i)("qcnd") = Year(strQjrq)
                        dt.Rows(i)("qcyf") = IIf(Day(strQjrq) >= 26, Month(strQjrq) + 1, Month(strQjrq))
                    End If
                Else
                    dt.Rows(i)("qcnd") = Year(strQjrq)
                    dt.Rows(i)("qcyf") = Month(strQjrq)
                End If
            End If
        Next

        m_dt = _D.YanArrToDb(dt.Select("qjnd=" & ComboBox1.Text))

        Dim iTm As Integer = 0
        '填充内存数据表
        Dim dr As DataRow = dtTj.NewRow
        dr(0) = "检测数"
        For i As Integer = 1 To 12
            Try
                dr(i) = m_dt.Select("qjyf=" & i & " and qcyf=" & i).Length
            Catch ex As Exception
                dr(i) = 0
            End Try
            iTm += dr(i)
        Next
        dr("总计") = iTm
        dtTj.Rows.Add(dr)

        iTm = 0
        dr = dtTj.NewRow
        dr(0) = "延期数"
        For i As Integer = 1 To 12
            Try
                dr(i) = m_dt.Select("qjyf=" & i & " and xcs<0").Length
            Catch ex As Exception
                dr(i) = 0
            End Try
            iTm += dr(i)
        Next
        dr("总计") = iTm
        dtTj.Rows.Add(dr)

        dr = dtTj.NewRow
        dr(0) = "检测及时率"
        For i As Integer = 1 To 12
            Try
                dr(i) = IIf(dtTj.Rows(0)(i) = 0, 0, _S.YanFormatNum(1 - dtTj.Rows(1)(i) / dtTj.Rows(0)(i)) * 100 & "%")
            Catch ex As Exception
                dr(i) = 0
            End Try
        Next
        dr("总计") = IIf(dtTj.Rows(0)("总计") = 0, 0, _S.YanFormatNum(1 - _S.YanFormatNum(dtTj.Rows(1)("总计")) / dtTj.Rows(0)("总计")) * 100 & "%")
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
                strWh = " and tb_i259b_num in (" & _D.YanDttoStr(_D.YanArrToDb(m_dt.Select("qjyf=" & e.ColumnIndex & " and qcyf=" & e.ColumnIndex)), "tb_i259b_num", True) & ")"
            Case 1
                strWh = " and tb_i259b_num in (" & _D.YanDttoStr(_D.YanArrToDb(m_dt.Select("qjyf=" & e.ColumnIndex & " and xcs<0")), "tb_i259b_num", True) & ")"
            Case Else
                Return
        End Select
        'If e.ColumnIndex = 13 Then
        '    Select Case e.RowIndex
        '        Case 0
        '            strWh = " and tb_i259b_num in (select tb_i259b_num from (" & m_viewDtSql & " and qjyf=qcyf) as numTb)"
        '        Case 1
        '            strWh = " and tb_i259b_num in (select tb_i259b_num from (" & m_viewDtSql & " and datediff(day,tb_i259b_qcrq,tb_i259b_y840q)+1+tb_wp_njzq<0) as numTb)"
        '        Case Else
        '            Return
        '    End Select
        'End If

        Dim sql As String = ""
        sql = "select * from tb_i259b where 1=1" & strWh

        Dim frTm As New Frzdybb_mx
        GS_DataGridViewbyDb(frTm.showl, _D.GF_CreateDataSource(sql), True, True)
        frTm.ShowDialog()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showTj()
    End Sub
End Class