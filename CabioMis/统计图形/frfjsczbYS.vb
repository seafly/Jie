'************************************************************************************************
'*窗体名称：frfjsczbYS
'*功    能：粉剂生产周报
'*编 写 者：yangshuai
'*编写日期
'*邮    箱：shuaigoplay@yahoo.com.cn
'*输    入：
'*输    出：excel文件
'*修 改 者：
'*修改日期：
'*备    注：
'************************************************************************************************
Public Class frfjsczbYS
    Private ylbdb As DataTable '查询结果供图形使用
    Private Sub frfjsczbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        wz()
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '显示上月的月份
    End Sub

    '********************************************************************************************
    '*函数名称：getYJSCZBdatatable
    '*功    能：生成油剂生产周报数据的datatable
    '*编 写 者：yangshuai
    '*编写日期
    '*邮    箱：shuaigoplay@yahoo.com.cn
    '*输    入：monthStr as string :月份字符串，由多个月份组成每个月份以“,”隔开
    '*输    出：油剂生产周报数据的datatable
    '*修 改 者：
    '*修改日期：
    '*备    注：
    '********************************************************************************************
    Public Function getFJSCZBdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        Dim monthArr() As String  '分解月份字符串的数组
        Dim tmpMonthLow As String '临时低位日期
        Dim tmpMonthhigh As String '临时高位日期
        Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
        Dim myread As New Data.OleDb.OleDbCommand()
        Dim rs As Data.OleDb.OleDbDataReader
        '添加datatable列开始
        dt.Columns.Add("时间起", GetType(String))
        dt.Columns.Add("时间止", GetType(String))
        dt.Columns.Add("1#塔止批号", GetType(String)) '成品粉生产日期区间
        dt.Columns.Add("1#塔成品批数", GetType(Integer)) '成品粉生产日期区间
        dt.Columns.Add("1#塔成品产量", GetType(Double)) '成品粉生产日期区间
        dt.Columns.Add("1#塔报废量", GetType(Double)) 'QA判定为报废的成品粉(成品粉生产日期区间)重量+QA判定报废的小批(喷雾开始时间区间)报废量
        dt.Columns.Add("1#塔平均ARA含量", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("1#塔平均表面油", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("1#塔小批EB检出批数", GetType(Integer)) '喷雾开始时间区间，小批EB定性等于“0/1×50g”的不为空的批数
        dt.Columns.Add("1#塔成品EB检出批数", GetType(Integer)) '成品粉生产日期区间,成品EB定性不等于“0/5×10g”的不为空的批数
        dt.Columns.Add("1#塔菌落≥10批数", GetType(Integer)) '成品粉生产日期区间,菌落计数不是<10和不为空的批数
        dt.Columns.Add("1#塔单批平均产量", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("34#塔止批号", GetType(String)) '成品粉生产日期区间
        dt.Columns.Add("34#塔成品批数", GetType(Integer)) '成品粉生产日期区间
        dt.Columns.Add("34#塔成品产量", GetType(Double)) '成品粉生产日期区间
        dt.Columns.Add("34#塔报废量", GetType(Double)) 'QA判定为报废的成品粉(成品粉生产日期区间)重量+QA判定报废的小批(喷雾开始时间区间)报废量
        dt.Columns.Add("34#塔平均ARA含量", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("34#塔平均表面油", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("34#塔小批EB检出批数", GetType(Integer)) '喷雾开始时间区间，小批EB定性等于“0/1×50g”的不为空的批数
        dt.Columns.Add("34#塔成品EB检出批数", GetType(Integer)) '成品粉生产日期区间,成品EB定性不等于“0/5×10g”的不为空的批数
        dt.Columns.Add("34#塔菌落≥10批数", GetType(Integer)) '成品粉生产日期区间,菌落计数不是<10和不为空的批数
        dt.Columns.Add("34#塔单批平均产量", GetType(Double)) '成品粉生产日期区间,不平均0

        dt.Columns.Add("5#塔止批号", GetType(String)) '成品粉生产日期区间'
        dt.Columns.Add("5#塔成品批数", GetType(Integer)) '成品粉生产日期区间'
        dt.Columns.Add("5#塔成品产量", GetType(Double)) '成品粉生产日期区间'
        dt.Columns.Add("5#塔报废量", GetType(Double)) 'QA判定为报废的成品粉(成品粉生产日期区间)重量+QA判定报废的小批(喷雾开始时间区间)报废量
        dt.Columns.Add("5#塔平均ARA含量", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("5#塔平均表面油", GetType(Double)) '成品粉生产日期区间,不平均0
        dt.Columns.Add("5#塔小批EB检出批数", GetType(Integer)) '喷雾开始时间区间，小批EB定性等于“0/1×50g”的不为空的批数'
        dt.Columns.Add("5#塔成品EB检出批数", GetType(Integer)) '成品粉生产日期区间,成品EB定性不等于“0/5×10g”的不为空的批数'
        dt.Columns.Add("5#塔菌落≥10批数", GetType(Integer)) '成品粉生产日期区间,菌落计数不是<10和不为空的批数'
        dt.Columns.Add("5#塔单批平均产量", GetType(Double)) '成品粉生产日期区间,不平均0

        '添加datatable列结束
        cnn.Open()
        myread.Connection = cnn
        monthArr = Split(monthStr, ",")
        For i As Integer = 2 To monthArr.Length Step 2
            Dim dataRow As Data.DataRow
            Dim index As Integer = 0
            dataRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            'MsgBox(tmpMonthLow)
            dataRow(0) = tmpMonthLow
            dataRow(1) = tmpMonthhigh
            tmpMonthhigh &= " 23:59:59"
            '''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select top 1  tb_x832p_num from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉' order by tb_x832p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔止批号") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''1#塔成品批数,1#塔成品产量,
            myread.CommandText = "select count(*),sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔成品批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
                dataRow("1#塔成品产量") = DeepCode.DeepDoStr.Null2zero(rs(1))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''菌落计数不是<10和不为空的批数
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉'   and tb_x832p_e106x<>'<10' and tb_x832p_e106x is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔菌落≥10批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉'   and tb_x832p_e106x<>'<10' and tb_x832p_e106x is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔菌落≥10批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉'   and tb_x832p_e106x<>'<10' and tb_x832p_e106x is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔菌落≥10批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''成品EB定性不等于“0/5×10g”的不为空的批数。
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉'   and tb_x832p_h199z<>'0/5×10g' and tb_x832p_h199z is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔成品EB检出批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉'   and tb_x832p_h199z<>'0/5×10g' and tb_x832p_h199z is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔成品EB检出批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉'   and tb_x832p_h199z<>'0/5×10g' and tb_x832p_h199z is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔成品EB检出批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''喷雾开始时间区间，小批EB定性等于“0/1×50g”的不为空的批数。
            myread.CommandText = "select count(*)  from tb_p525h where (tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_p525h_th in ('1号塔')    and (tb_p525h_c17u<>'0/1×50g' and tb_p525h_c17u<>'-')"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔小批EB检出批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from tb_p525h where (tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_p525h_th in ('3号塔','4号塔')   and tb_p525h_c17u<>'0/1×50g' and tb_p525h_c17u<>'-'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔小批EB检出批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from tb_p525h where (tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_p525h_th in ('5号塔')   and tb_p525h_c17u<>'0/1×50g' and tb_p525h_c17u<>'-'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔小批EB检出批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_d65v)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉'   and tb_x832p_d65v>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔平均ARA含量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_a948s)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉'   and tb_x832p_a948s>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔平均表面油") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_i232a)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1号塔成品粉'   and tb_x832p_i232a>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#塔单批平均产量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select top 1  tb_x832p_num from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉' order by tb_x832p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔止批号") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''34#塔成品批数,34#塔成品产量
            myread.CommandText = "select count(*),sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔成品批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
                dataRow("34#塔成品产量") = DeepCode.DeepDoStr.Null2zero(rs(1))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_d65v)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉'   and tb_x832p_d65v>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔平均ARA含量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_a948s)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉'   and tb_x832p_a948s>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔平均表面油") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_i232a)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34号塔成品粉'   and tb_x832p_i232a>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#塔单批平均产量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''QA判定为报废的成品粉重量+QA判定报废的小批(喷雾开始时间区间)报废量
            myread.CommandText = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='1号塔成品粉' and tb_x832p_qaspjg='报废'"
            rs = myread.ExecuteReader
            Dim t1, t2 As Double
            rs.Read()
            t1 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            myread.CommandText = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_p525h_th in ('1号塔') and tb_p525h_qaspjg='报废'"
            rs = myread.ExecuteReader
            rs.Read()
            t2 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            dataRow("1#塔报废量") = t1 + t2


            myread.CommandText = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='34号塔成品粉' and tb_x832p_qaspjg='报废'"
            rs = myread.ExecuteReader
            Dim t11, t12 As Double
            rs.Read()
            t1 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            myread.CommandText = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_p525h_th in ('3号塔','4号塔') and tb_p525h_qaspjg='报废'"
            rs = myread.ExecuteReader
            rs.Read()
            t2 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            dataRow("34#塔报废量") = t11 + t12
            rs.Close()

            myread.CommandText = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='5号塔成品粉' and tb_x832p_qaspjg='报废'"
            rs = myread.ExecuteReader
            Dim ttt1, ttt2 As Double
            rs.Read()
            ttt1 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            myread.CommandText = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_p525h_th in ('5号塔') and tb_p525h_qaspjg='报废'"
            rs = myread.ExecuteReader
            rs.Read()
            ttt2 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            dataRow("5#塔报废量") = t1 + t2

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Try
            '    'dataRow(5) = Format((dataRow(5) + (dataRow(3) / dataRow(2))), "00.00%")
            'Catch ex As Exception
            '    dataRow(5) = 0
            'End Try

            'Try
            '    dataRow(4) = Format((dataRow(3) / dataRow(2)), "00.00%")
            'Catch ex As Exception
            '    dataRow(4) = 0
            'End Try


            'myread.CommandText = "select sum(tb_x832p_z886r),sum(tb_x832p_i232a),sum(tb_x832p_l349d)  from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='34号塔成品粉'"
            'rs = myread.ExecuteReader
            'If rs.Read Then
            '    'dataRow(5) = Null2Zero(rs(0))
            '    dataRow(5) = Null2zero(rs(1))
            '    'dataRow(10) = Null2Zero(rs(2))
            'End If
            'rs.Close()
            'myread.CommandText = "select sum(tb_x832p_z886r) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='34号塔成品粉' and tb_x832p_qaspjg='报废'"
            'rs = myread.ExecuteReader
            'If rs.Read Then
            '    dataRow(6) = Null2zero(rs(0))
            'End If
            'rs.Close()
            ''Try
            ''    dataRow(10) = Format((dataRow(10) + (dataRow(8) / dataRow(7))), "00.00%")
            ''Catch ex As Exception
            ''    dataRow(10) = 0
            ''End Try

            'Try
            '    dataRow(7) = Format((dataRow(6) / dataRow(5)), "00.00%")
            'Catch ex As Exception
            '    dataRow(7) = 0
            'End Try

            'dataRow(8) = dataRow(2) + dataRow(5)
            'dataRow(9) = dataRow(3) + dataRow(6)
            'dataRow(10) = Format((Format(dataRow(4), "00.00%") + Format(dataRow(7), "00.00%")), "00.00%")
            'Dim tmpint As Integer = 0
            'If dataRow(5) <> "00.00%" Then
            '    tmpint = tmpint + 1
            'End If
            'If dataRow(10) <> "00.00%" Then
            '    tmpint = tmpint + 1
            'End If
            ''Try
            '    dataRow(15) = Format((dataRow(5) + dataRow(10)) / tmpint, "00.00%")
            'Catch ex As Exception
            '    dataRow(15) = 0
            'End Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select top 1  tb_x832p_num from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉' order by tb_x832p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔止批号") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''1#塔成品批数,1#塔成品产量,
            myread.CommandText = "select count(*),sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔成品批数") = DeepCode.DeepDoStr.Null2zero(rs(0))
                dataRow("5#塔成品产量") = DeepCode.DeepDoStr.Null2zero(rs(1))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select avg(tb_x832p_d65v)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉'   and tb_x832p_d65v>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔平均ARA含量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_a948s)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉'   and tb_x832p_a948s>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔平均表面油") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不平均0
            myread.CommandText = "select avg(tb_x832p_i232a)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5号塔成品粉'   and tb_x832p_i232a>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#塔单批平均产量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            dt.Rows.Add(dataRow)
        Next
        Dim aaRow As DataRow = dt.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 3 To dt.Columns.Count - 1
            Dim m As Double = 0
            Try
                m = FormatNumber(GF_jsColumnTotal(dt, i, 0, dt.Rows.Count - 1), 2)
            Catch ex As Exception

            End Try
            aaRow(i) = m
        Next
        dt.Rows.Add(aaRow)
        getFJSCZBdatatable = dt
    End Function
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim monthStr As String = GF_Time2Week(CDate(nian1.Text & "-" & yue1.Text))
    '    Dim dt As Data.DataTable = getFJSCZBdatatable(monthStr)
    '    GS_DataGridViewbyDb(ListView1, dt, True, True)
    'End Sub 
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim monthStr As String = GF_Time2Week(CDate(nian1.Text & "-" & yue1.Text))
        Dim dt As Data.DataTable = getFJSCZBdatatable(monthStr)
        ylbdb = dt.Copy()
        GS_DataGridViewbyDb(ListView1, dt, True, True)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ys(4) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Pink : ys(3) = Color.Gold : ys(4) = Color.Blue
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        ylbdb.Columns.RemoveAt(0)
        ylbdb.Columns.RemoveAt(ylbdb.Columns.Count - 1)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ShowLine(Chart3, False, ylbdb, "粉剂三平均指标(周)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 5)
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
        DeepDoDataTable.DelDataColAtIndex(ylbdb, "20,21,22,23,24,25,26,27,28,29")
        ShowLine(Chart2, False, ylbdb, "粉剂二平均指标(周)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 5)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DeepDoDataTable.DelDataColAtIndex(ylbdb, "19,18,17,16,15,14,13,12,11,5,4,3,2,1")
        ShowLine(Chart1, False, ylbdb, "粉剂一平均指标(周)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 5)
   
    End Sub
    Private Sub ShowLine(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking, ByVal colorC() As Color, ByVal SeriesBegin As Integer)
        If DataTableName.Columns.Count < 2 Then
            MsgBox("至少应该有2列") : Return
        End If
        With MsChartName
            .Series.Clear() : .Titles.Clear()
            .DataSource = DataTableName '指定数据源
            .ChartAreas(0).Area3DStyle.Enable3D = Show3D '显示区域3D效果
            .ChartAreas(0).AxisX.Interval = 1
            If DataTableName.Rows.Count > 60 Then
                .ChartAreas(0).AxisX.Interval = 6
            End If
            .Titles.Add(ChartTitle) '标题文字
            ' XY轴坐标的放大
            .ChartAreas(0).CursorX.IsUserEnabled = True
            .ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            .ChartAreas(0).AxisX.ScaleView.Zoomable = True
            .ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True
            .ChartAreas(0).CursorY.IsUserEnabled = True
            .ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            .ChartAreas(0).AxisY.ScaleView.Zoomable = True
            .ChartAreas(0).AxisY.ScrollBar.IsPositionedInside = True
        End With

        With MsChartName.Legends(0)
            .Enabled = True '确认显示标题
            .Alignment = StringAlignment.Center '标题对齐图的方式
            .TitleForeColor = Color.Black '颜色
            .TitleAlignment = StringAlignment.Center '文字对齐方式
            .TitleSeparator = DataVisualization.Charting.LegendSeparatorStyle.Line '分割样式
            .TitleSeparatorColor = Color.Black
            .Docking = ChartTitleDock '相对图的停靠方式
        End With

        For i As Integer = SeriesBegin To DataTableName.Columns.Count - 1
            MsChartName.Series.Add(DataTableName.Columns(i).Caption)
            With MsChartName.Series(i - SeriesBegin)
                .ChartType = DataVisualization.Charting.SeriesChartType.Line '折线图
                .BorderWidth = 3 '线粗细
                .ShadowOffset = 2 '阴影
                .Color = colorC(i - SeriesBegin)
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle '点的形状
                .MarkerSize = 5 '点大小
                .MarkerColor = Color.Gold '点的颜色
                .IsValueShownAsLabel = True '显示点的值
                .XValueMember = DataTableName.Columns(0).Caption '指定横坐标字段
                .XValueType = DataVisualization.Charting.ChartValueType.Auto '指定坐标类型
                .YValueMembers = DataTableName.Columns(i).Caption '指定纵坐标字段
            End With
        Next
        MsChartName.Update() '这句话很重要，才能显示下面的tooltip
        '显示下面的各个点的tooltip为DataTableName0列的值
        For i As Integer = 0 To MsChartName.Series.Count - 1
            For j As Integer = 0 To MsChartName.Series(i).Points.Count - 1
                MsChartName.Series(i).Points(j).ToolTip = DataTableName.Rows(j)(0)
            Next
        Next

    End Sub
    Private Sub wz()

        ListView1.Width = Me.Width - ListView1.Left - 10
        Dim kd As Integer = Int(Me.Width / 3)
        Panel1.Width = kd
        Panel1.Height = Me.Height - Panel1.Top - 30
        'MsgBox(Chart1.Height)
        Panel2.Left = Panel1.Width + Panel1.Left
        Panel2.Width = kd
        Panel2.Height = Panel1.Height
        Panel3.Left = Panel2.Left + Panel2.Width
        Panel3.Width = Me.Width - 2 * kd
        Panel3.Height = Panel1.Height
    End Sub
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, GroupBox1.Text, Me)
    End Sub
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub fryjzbYS_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub ToChartImg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg2.Click
        ClassDeepChart.GS_SaveChartImg(Chart2)
    End Sub

    Private Sub ToChartImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClassDeepChart.GS_SaveChartImg(Chart3)
    End Sub
End Class