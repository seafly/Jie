Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frddfhzb
    Private Sub showsj()
        Dim nian As String = ComboBox1.Text : Dim yue As String = ComboBox2.Text
        Dim tt2 As Date = CDate(nian & "-" & yue & "-25")
        Dim tt1 As Date = DateAdd(DateInterval.Day, +1, DateAdd(DateInterval.Month, -1, tt2)) 'tt2上个月的26号
        Dim gsyue As Date = CDate(ComboBox1.Text & "-" & ComboBox2.Text & "-1") ' 订单归属月份（数据库订单表中订单归属月份默认为选择年月的1号）
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tt3 As Date = DateAdd(DateInterval.Day, -Weekday(tt1) - 1 + 7, tt1) '上月26号后第一个周五
        Dim sj As String = tt1
        ' sj  = tt1 & "," & tt3 '''''''''''''''''''''''’‘’‘’‘’‘’‘’‘’‘’‘得到时间段内所有时间
        While tt3 < tt2
            sj &= "," & tt3
            sj &= "," & DateAdd(DateInterval.Day, 1, tt3)
            tt3 = DateAdd(DateInterval.Day, 7, tt3)
        End While
          sj &= "," & tt2
        Dim sjz As String() = sj.Split(",")
        Dim sjzh As Integer = sjz.Length
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''下面开始构建datatable
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''得到时间段内的所有的代码
        Dim sql As String = "select  tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm from tb_dd where tb_dd_ddgsyf = '" & gsyue & "'  group by tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’现在动态添加列表头，列数为时间段个数*2（每个时间段有计划和实际量）+ 2列（计划量合计和实际量合计）
        dt.Columns.Add("发货计划总量")
        dt.Columns.Add("实发总量")
        For i As Integer = 0 To sjzh - 1 Step 2
            dt.Columns.Add(sjz(i) & "至" & sjz(i + 1) & vbCrLf & "计划量")
            dt.Columns.Add(sjz(i) & "至" & sjz(i + 1) & vbCrLf & "实际量")
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''现在添加行数据
        For j As Integer = 0 To dt.Rows.Count - 1
            Dim sqlsj As String = "" : Dim dt1 As DataTable
            '’‘’‘’‘’‘’‘’计算合计
            sqlsj = "declare @a1 as money,@a2 as money" & vbCrLf
            sqlsj &= "select @a1 = sum(tb_dd_jhfhzl) from tb_dd " & vbCrLf
            sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_jhfhrq is not null and tb_dd_bz1='1'  " & vbCrLf

            sqlsj &= "select @a2 = sum(tb_dd_fhl) from tb_dd " & vbCrLf
            sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_sjfhrq is not null and tb_dd_bz1='2' " & vbCrLf

            sqlsj &= "select @a1,@a2"
            dt1 = GF_CreateDataSource(G_cnnstr, sqlsj)
            dt.Rows(j)(3) = Null2zero2(dt1.Rows(0)(0)) '计划量
            dt.Rows(j)(4) = Null2zero2(dt1.Rows(0)(1)) '发货量
            For ii As Integer = 0 To sjzh - 1 Step 2

                ''''''''''''''计算时间段内的计划和发货量
                If ii = 0 Then '因为会存在发货提早  所以每月第一周的提取为满足订单归属月 且 时间小于该月第一个周五
                    sqlsj = "declare @a1 as money,@a2 as money" & vbCrLf
                    sqlsj &= "select @a1 = sum(tb_dd_jhfhzl) from tb_dd " & vbCrLf
                    sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_jhfhrq <= '" & sjz(ii + 1) & "' and tb_dd_bz1='1'  " & vbCrLf
                    sqlsj &= "select @a2 = sum(tb_dd_fhl) from tb_dd " & vbCrLf
                    sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_sjfhrq  <=  '" & sjz(ii + 1) & "' and tb_dd_bz1='2' " & vbCrLf
                    sqlsj &= "select @a1,@a2"
                ElseIf ii = sjzh - 1 Then '因为会存在发货推迟  所以每月第一周的提取为满足订单归属月 且 时间大于该月最后一个周六
                    sqlsj = "declare @a1 as money,@a2 as money" & vbCrLf
                    sqlsj &= "select @a1 = sum(tb_dd_jhfhzl) from tb_dd " & vbCrLf
                    sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_jhfhrq >= '" & sjz(ii) & "' and tb_dd_bz1='1'  " & vbCrLf
                    sqlsj &= "select @a2 = sum(tb_dd_fhl) from tb_dd " & vbCrLf
                    sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_sjfhrq >= '" & sjz(ii) & "'  and tb_dd_bz1='2' " & vbCrLf
                    sqlsj &= "select @a1,@a2"
                Else
                    sqlsj = "declare @a1 as money,@a2 as money" & vbCrLf
                    sqlsj &= "select @a1 = sum(tb_dd_jhfhzl) from tb_dd " & vbCrLf
                    sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_jhfhrq between '" & sjz(ii) & "' and '" & sjz(ii + 1) & "' and tb_dd_bz1='1'  " & vbCrLf
                    sqlsj &= "select @a2 = sum(tb_dd_fhl) from tb_dd " & vbCrLf
                    sqlsj &= "where tb_dd_cplx='" & dt.Rows(j)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(j)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(j)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & gsyue & "' and  tb_dd_sjfhrq between '" & sjz(ii) & "' and '" & sjz(ii + 1) & "' and tb_dd_bz1='2' " & vbCrLf
                    sqlsj &= "select @a1,@a2"
                End If

                dt1 = GF_CreateDataSource(G_cnnstr, sqlsj)
                dt.Rows(j)(ii + 5) = Null2zero2(dt1.Rows(0)(0)) '计划量
                dt.Rows(j)(ii + 6) = Null2zero2(dt1.Rows(0)(1)) '发货量

            Next
        Next
        GS_DataGridViewbyDb(show1, hj(dt, 0, 3, dt.Columns.Count - 1), True, True)
        bs(show1)
        GroupBox1.Text = "显示" & show1.RowCount & "条记录"


    End Sub

    Private Sub Frddfhzb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = GF_getstringsql(G_cnnstr, "select top 1 year(tb_dd_sjfhrq) from tb_dd  where tb_dd_sjfhrq is not null group by tb_dd_sjfhrq order by tb_dd_sjfhrq desc ", "")
        For i As Integer = 2011 To CInt(sql) '填充年
            ComboBox1.Items.Add(i)
        Next
        For j As Integer = 1 To 12 '月
            ComboBox2.Items.Add(j)
        Next
        ComboBox1.SelectedIndex = 0
        ComboBox2.Text = Now.Month
    End Sub
    Private Sub wz()
        GroupBox1.Height = Me.Height * 3 / 4
        Dim t As Double = (Me.Height - GroupBox1.Height) / 3
        Label1.Top = t + 2
        ComboBox1.Top = t
        Label2.Top = t + 2
        ComboBox2.Top = t
        Button1.Top = t
        Button2.Top = t
    End Sub

    Private Sub Frddfhzb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        showsj()
    End Sub
    Private Function zh(ByVal str As String) As String
        Return "@a" & str
    End Function
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
        For j As Integer = 1 To indexs.Length - 1
            Dim beginrow As Integer
            Dim endrow As Integer
            'If j <> indexs.Length - 1 Then
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
            dr(0) = "合计"
            If j <> indexs.Length - 1 Then
                dt.Rows.InsertAt(dr, indexs(j) + j - 1)
            Else
                dt.Rows.Add(dr)
            End If


        Next
        Return dt
    End Function
    Private Sub bs(ByVal dtgrd As DataGridView)
        For i As Integer = 0 To dtgrd.ColumnCount - 1
            If InStr(dtgrd.Columns(i).HeaderText, "实际量") <> 0 Or InStr(dtgrd.Columns(i).HeaderText, "实发总量") <> 0 Then
                dtgrd.Columns(i).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub
End Class