Public Class Frddjfyb

    Private Sub Frddjfyb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = GF_getstringsql(G_cnnstr, "select top 1 year(tb_dd_ddgsyf) from tb_dd  where tb_dd_ddgsyf is not null group by tb_dd_ddgsyf order by tb_dd_ddgsyf desc ", "")
        For i As Integer = 2011 To CInt(sql) '填充年
            ComboBox1.Items.Add(i)
            ComboBox3.Items.Add(i)
        Next
        For j As Integer = 1 To 12 '月
            ComboBox2.Items.Add(j)
            ComboBox4.Items.Add(j)
        Next
        ComboBox1.Text = Now.Year : ComboBox3.Text = Now.Year '年默认为今年
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        showsj()
    End Sub

    Private Sub showsj()
        ''''''''''''''''''''''''''''''''''''''得到时间区间
        Dim tt1 As Date = ComboBox1.Text & "-" & CInt(ComboBox2.Text) & "-1"
        Dim tt2 As Date = ComboBox3.Text & "-" & CInt(ComboBox4.Text) & "-1"
        Dim j As Integer = DateDiff(DateInterval.Month, tt1, tt2)  '得到间隔时间，为后面构建列作准备
        '‘构建sql语句

        'Case "按产品类型"
        ''''得到时间段内的所有的代码
        Dim dt As DataTable
        Dim sql As String = "select  tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm from tb_dd where tb_dd_ddgsyf between '" & tt1 & "' and '" & tt2 & "'  group by tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        ''''构建列
        Dim gsyue As Integer = CInt(ComboBox2.Text)
        For i As Integer = 0 To j
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "订单量")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "实发量")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "未发量 （已下计划）")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "未发量 （暂无计划）")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "退换货数量")
        Next
        '填充行数据
        For k As Integer = 0 To dt.Rows.Count - 1
            Dim sqlsj As String = ""
            Dim dt1 As DataTable = Nothing
            For ii As Integer = 0 To j

                ''''上个月25号到这个月26号为一个月
                Dim NowRq As String = Cl_StrMag.YanForDa_1(DateAndTime.DateAdd(DateInterval.Month, ii, tt1))
                Dim BeforeRq As String = Cl_StrMag.YanForDa_1(DateAndTime.DateAdd(DateInterval.Month, -1, CType(NowRq, Date)))
                Dim INTNowRq As Integer = Microsoft.VisualBasic.InStrRev(NowRq, "-")
                Dim INTBeforeRq As Integer = Microsoft.VisualBasic.InStrRev(BeforeRq, "-")
                BeforeRq = BeforeRq.Substring(0, INTBeforeRq) & "26"
                NowRq = NowRq.Substring(0, INTNowRq) & "25"
                ''''''''''''''''''''''''''''''''''''''''''''''''''
                sqlsj = "declare @a1 as money,@a2 as money,@a3 as money,@a4 as money " & vbCrLf ',@a4 订单输入流程中的信息   @a5 为 发货计划流程中计划量合计（按不同订单号合计联合查询是为了得到不同代码的订单号 然后再到一级信息中根据订单号统计订单量）
                sqlsj &= "select @a1 = sum(tb_dd_ddl) from tb_dd " & vbCrLf
                sqlsj &= "where tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & DateAdd(DateInterval.Month, ii, tt1) & "'  and (tb_dd_fhtjdh is null or tb_dd_fhtjdh='') " & vbCrLf
                sqlsj &= "select @a2 = sum(tb_dd_yfh) from tb_dd " & vbCrLf
                sqlsj &= "where tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & DateAdd(DateInterval.Month, ii, tt1) & "' and  (tb_dd_fhtjdh is null or tb_dd_fhtjdh='') " & vbCrLf
                sqlsj &= "select @a3 = sum(tb_dd_jhfhzl) from tb_dd " & vbCrLf
                sqlsj &= "where tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & DateAdd(DateInterval.Month, ii, tt1) & "'  and tb_dd_bz1='1'  and  tb_dd_bz2='2' and tb_dd_bz3 is null and (tb_dd_fhtjdh is null or tb_dd_fhtjdh='') " & vbCrLf
                sqlsj &= "select @a4= sum(tb_dd_returnsl) from tb_dd " & vbCrLf
                sqlsj &= "where  tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_returnrq between '" & CType(BeforeRq, Date) & "' and '" & CType(NowRq, Date) & "'"
                sqlsj &= "select @a1,@a2,@a3,@a4"
                dt1 = GF_CreateDataSource(G_cnnstr, sqlsj)
                dt.Rows(k)(ii * 5 + 3) = Null2zero2(dt1.Rows(0)(0))
                dt.Rows(k)(ii * 5 + 4) = Null2zero2(dt1.Rows(0)(1))
                dt.Rows(k)(ii * 5 + 5) = Null2zero2(dt1.Rows(0)(2))
                dt.Rows(k)(ii * 5 + 6) = Null2zero2(dt1.Rows(0)(0)) - Null2zero2(dt1.Rows(0)(1)) - Null2zero2(dt1.Rows(0)(2))
                dt.Rows(k)(ii * 5 + 7) = dt1.Rows(0)(3)
            Next
        Next
        GS_DataGridViewbyDb(show1, hj(dt, 0, 3, dt.Columns.Count - 1), True, True)
        ''''变色
        For hhh As Integer = 0 To show1.RowCount - 1
            If InStr(show1.Rows(hhh).Cells(0).Value, "合计") <> 0 Then
                show1.Rows(hhh).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        'For jj As Int16 = 3 To show1.Columns.Count - 1 Step 8
        '    show1.Columns(jj).DefaultCellStyle.BackColor = Color.AliceBlue
        '    show1.Columns(jj + 1).DefaultCellStyle.BackColor = Color.AliceBlue
        '    show1.Columns(jj + 2).DefaultCellStyle.BackColor = Color.AliceBlue
        '    show1.Columns(jj + 3).DefaultCellStyle.BackColor = Color.AliceBlue
        'Next

        GroupBox1.Text = "显示" & show1.RowCount & "条记录"
    End Sub
    Private Function hj(ByVal dt As DataTable, ByVal fzl As Integer, ByVal begincolums As Integer, ByVal endcoloums As Integer) As DataTable '按fzl列的datatable进行分组并插计算相应列的合计值
        Dim index As String = ""
        For i As Integer = 1 To dt.Rows.Count - 1
            If dt.Rows(i)(fzl) <> dt.Rows(i - 1)(fzl) Then
                index &= i.ToString & ","
            End If
        Next
        index &= dt.Rows.Count  '最后一行后面应该有一个合计行
        index = "0," & index
        Dim indexs As String() = index.Split(",")
        Dim sqlxz As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cpdmhz_cplx as mz,tb_cpdmhz_cplb as mx from tb_cpdmhz group by tb_cpdmhz_cplx,tb_cpdmhz_cplb")
        For j As Integer = 1 To indexs.Length - 1
            Dim beginrow As Integer
            Dim endrow As Integer
            beginrow = indexs(j - 1) + j - 1
            endrow = indexs(j) + j - 2 '每插入一行 则索引行加1 行
            Dim dr As DataRow = dt.NewRow
            For k As Integer = begincolums To endcoloums '''''''''''''''''合计
                Dim hjz As Double = 0
                For hh As Integer = beginrow To endrow
                    hjz += CDbl(Null2zero(dt.Rows(hh)(k)))
                Next
                dr(k) = hjz
            Next
            For kbl As Integer = 1 To begincolums - 1
                dr(kbl) = DBNull.Value
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dr(0) = GF_cnwithen(sqlxz, "mz='" & dt.Rows(beginrow)(0) & "'", 1) & "合计"
            If j <> indexs.Length - 1 Then
                dt.Rows.InsertAt(dr, indexs(j) + j - 1)
            Else
                dt.Rows.Add(dr)
            End If
        Next
        Return dt
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim nfrom As New Frddyxkc
            Dim dt As New DataTable
            dt.Columns.Add("产品类型") : dt.Columns.Add("产品代码") : dt.Columns.Add("加工代码") : dt.Columns.Add("未发货（暂无计划）") : dt.Columns.Add("有效库存", GetType(Double)) : dt.Columns.Add("QA待定", GetType(Double))
            Dim dt1 As DataTable = CType(show1.DataSource, DataTable)
            Dim dtr As DataRow
            For i As Integer = 0 To dt1.Rows.Count - 1
                If InStr(dt1.Rows(i)(0), "合计") <> 0 Then
                    Continue For
                End If
                dtr = dt.NewRow
                dtr(0) = dt1.Rows(i)(0)
                dtr(1) = dt1.Rows(i)(1)
                dtr(2) = dt1.Rows(i)(2)
                dt.Rows.Add(dtr)
            Next
            nfrom.dt = dt
            Me.AddOwnedForm(nfrom)
            nfrom.Show()

        Catch
        End Try
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(show1, "订单交付月报", Me)
    End Sub
    Private Sub Frddjfyb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub wz()
        GroupBox1.Height = Me.Height * 3 / 4
        Dim t As Double = (Me.Height - GroupBox1.Height) / 3
        Label1.Top = t + 2
        Label2.Top = t + 2
        Label3.Top = t + 2
        Label4.Top = t + 2
        ComboBox1.Top = t
        ComboBox2.Top = t
        ComboBox3.Top = t
        ComboBox4.Top = t
        ToExcel.Top = t
        Button1.Top = t
        Button2.Top = t
    End Sub
End Class