Public Class fjylsy2
    Dim plpid As String
    Public ph As String = ""


    Private Sub fjylsy2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        weizhi()
        Dim sql As String = "select tb_yxjh_tjq from tb_yxjh  where  tb_yxjh_y846q='34号塔粉剂配料批' or tb_yxjh_y846q='1号塔粉剂配料批' or tb_yxjh_y846q='5号塔粉剂配料批'  group by tb_yxjh_tjq"
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(nian1, dt, 0, "")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' '在运行计划里面得到起和止批号 
        ' 根据起和止批号查询得到
        ' 起批号的开始时间 和 止批号的结束时间 
        ' 然后有这两个时间对报表进行统计
        Try
            Dim tjq As String = nian1.Text
            Dim sqljg As String = "select  tb_zfxylbb_ID,tb_zfxylbb_tjq,tb_zfxylbb_phq,tb_zfxylbb_phz,tb_zfxylbb_s644l,tb_zfxylbb_c18u,tb_zfxylbb_f147y,tb_zfxylbb_i251a,tb_zfxylbb_5th,tb_zfxylbb_plpid,tb_zfxylbb_czrgh,tb_zfxylbb_t674l,tb_zfxylbb_q562i,tb_zfxylbb_5tht from tb_zfxylbb  where  tb_zfxylbb_tjq='" & tjq & "'"
            Dim dts As Data.DataTable = GF_CreateDataSource(G_cnnstr, sqljg)
            If dts.Rows.Count > 0 Then
                dts.Columns.RemoveAt(0) '得到报表的架构
                Call hj(dts, tjq)
                Button2.Enabled = False : Exit Sub
            Else
                Button2.Enabled = True
            End If
            ''''''''''''''''''''''''''''''''配料批起止批号
            Dim qh11 As String = "" : Dim qh12 As String = ""
            Dim qh341 As String = "" : Dim qh342 As String = ""
            Dim qh51 As String = "" : Dim qh52 As String = ""
            Dim sql As String = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='34号塔粉剂配料批'  and tb_yxjh_tjq='" & tjq & "'"
            Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)

            If dt.Rows.Count = 0 Then
                MsgBox("配料批起止批号(34号塔)未设置")
            Else
                qh341 = dt.Rows(0)(0) : qh342 = dt.Rows(0)(1)
            End If

            sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='1号塔粉剂配料批'  and  tb_yxjh_tjq='" & tjq & "'"
            dt = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                'MsgBox("配料批起止批号(1号塔)未设置")
            Else
                qh11 = dt.Rows(0)(0) : qh12 = dt.Rows(0)(1)
            End If

            sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='5号塔粉剂配料批'  and  tb_yxjh_tjq='" & tjq & "'"
            dt = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                MsgBox("配料批起止批号(5号塔)未设置")
            Else
                qh51 = dt.Rows(0)(0) : qh52 = dt.Rows(0)(1)
            End If

            '''''''''''''''''''''''''''配料批的时间区间     

            Dim tt341, tt342, tt11, tt12, tt51, tt52 As String
            tt341 = frfjsczbYS2.sfyph("tb_n441f", qh341) : tt342 = frfjsczbYS2.sfyph("tb_n441f", qh342)
            tt11 = frfjsczbYS2.sfyph("tb_n441f", qh11) : tt12 = frfjsczbYS2.sfyph("tb_n441f", qh12)
            tt51 = frfjsczbYS2.sfyph("tb_n441f", qh51) : tt52 = frfjsczbYS2.sfyph("tb_n441f", qh52)

            If tt11 = "" Or tt12 = "" Or tt341 = "" Or tt342 = "" Or tt51 = "" Or tt51 = "" Then
                'MsgBox("配料批起止批号(一或三四或五号塔）没有开始和结束时间")
            End If


            '''''''''''''''''''粉剂小批(5号塔）起止批号

            sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='5号塔小批'  and  tb_yxjh_tjq='" & tjq & "'"
            dt = GF_CreateDataSource(G_cnnstr, sql)
            Dim qh551 As String = ""
            Dim qh552 As String = ""
            If dt.Rows.Count = 0 Then
                MsgBox("小批起止批号(5号塔)未设置")
            Else
                qh551 = dt.Rows(0)(0)
                qh552 = dt.Rows(0)(1)
            End If

            ''''''''''''''''''粉剂小批的时间区间      

            Dim k1, k2, k3, k4, k5, k6 As String
            k1 = frfjsczbYS2.sfyph("tb_p525h", qh341) : k2 = frfjsczbYS2.sfyph("tb_p525h", qh342)
            k3 = frfjsczbYS2.sfyph("tb_p525h", qh11) : k4 = frfjsczbYS2.sfyph("tb_p525h", qh12)
            k5 = sfyph("tb_p525h", qh551) : k6 = sfyph("tb_p525h", qh552)
            If k1 = "" Or k2 = "" Or k3 = "" Or k4 = "" Or k5 = "" Or k6 = "" Then
                'MsgBox("小批起止批号(五号塔）没有开始和结束时间")
            End If

            ''''''''''''''''''''''''

            '''''''''''''''''''''''成品粉起止批号
            sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='34号塔成品粉'  and tb_yxjh_tjq='" & tjq & "'"
            dt = GF_CreateDataSource(G_cnnstr, sql)
            Dim qh1341 As String = ""
            Dim qh1342 As String = ""
            If dt.Rows.Count = 0 Then
                MsgBox("成品粉起止批号(34号塔)未设置")
            Else
                qh1341 = dt.Rows(0)(0) : qh1342 = dt.Rows(0)(1)
            End If

            sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='1号塔成品粉' and tb_yxjh_tjq='" & tjq & "'"
            dt = GF_CreateDataSource(G_cnnstr, sql)

            Dim qh111 As String = ""
            Dim qh112 As String = ""
            If dt.Rows.Count = 0 Then
                'MsgBox("成品粉起止批号(1号塔)未设置")
            Else
                qh111 = dt.Rows(0)(0) : qh112 = dt.Rows(0)(1)
            End If

            sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='5号塔成品粉' and tb_yxjh_tjq='" & tjq & "'"
            dt = GF_CreateDataSource(G_cnnstr, sql)

            Dim qh151 As String = ""
            Dim qh152 As String = ""
            If dt.Rows.Count = 0 Then
                MsgBox("成品粉起止批号(5号塔)未设置")
            Else
                qh151 = dt.Rows(0)(0) : qh152 = dt.Rows(0)(1)
            End If
            ''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''成品粉时间区间    
            Dim tt1341, tt1342, tt111, tt112, tt151, tt152 As String
            tt1341 = frfjsczbYS2.sfyph("tb_x832p", qh1341) : tt1342 = frfjsczbYS2.sfyph("tb_x832p", qh1342)
            tt111 = frfjsczbYS2.sfyph("tb_x832p", qh111) : tt112 = frfjsczbYS2.sfyph("tb_x832p", qh112)
            tt151 = frfjsczbYS2.sfyph("tb_x832p", qh151) : tt152 = frfjsczbYS2.sfyph("tb_x832p", qh152)

            tt1341 = frfjsczbYS2.sfyph("tb_p525h", qh341) : tt1342 = frfjsczbYS2.sfyph("tb_p525h", qh342)
            tt111 = frfjsczbYS2.sfyph("tb_p525h", qh11) : tt112 = frfjsczbYS2.sfyph("tb_p525h", qh12)
            tt151 = sfyph("tb_p525h", qh551) : tt152 = sfyph("tb_p525h", qh552)
            If tt1341 = "" Or tt1342 = "" Or tt111 = "" Or tt112 = "" Or tt151 = "" Or tt152 = "" Then
                'MsgBox("成品粉起止批号(一或三四或五号塔）没有开始和结束时间")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''
            dt = getFJSCZBdatatable(tjq, qh11 & "," & qh341 & "," & qh51, qh12 & "," & qh342 & "," & qh52, tt11, tt12, tt341, tt342, tt51, tt52, tt111, tt112, tt1341, tt1342, tt151, tt152, k1, k2, k3, k4, k5, k6, qh111 & "," & qh1341 & "," & qh151, qh112 & "," & qh1342 & "," & qh152)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''增加一行进行统计  

            If dt.Rows.Count <> 0 Then
                Call hj(dt, tjq)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MsgBox("尚未生产到计划批次！")
        End Try

    End Sub
    Private Sub hj(ByVal dt As DataTable, ByVal tjq As Integer)
        plpid = dt.Rows(0)(8)

        Dim kk As DataRow = dt.NewRow
        Dim j As Integer = dt.Rows.Count - 4
        kk(0) = tjq
        kk(1) = "各个塔投入总量"

        kk(4) = GF_jsColumnTotal(dt, 4, 0, j)
        kk(5) = GF_jsColumnTotal(dt, 5, 0, j)
        kk(6) = GF_jsColumnTotal(dt, 6, 0, j)
        kk(7) = GF_jsColumnTotal(dt, 7, 0, j)
        dt.Rows.Add(kk)
        Call GS_useviewbydb2(Me.ListView1, dt, -1, 0)
        '隐藏ID 
        ListView1.Columns(8).Width = 0


    End Sub
    Private Function syph(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As String

        Dim str As String = str1 & "," & str2 & "," & str3
        syph = str1 & "," & str2 & "," & str3
        Dim xs() As String = str.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
        Dim sc As String = ""
        For i As Integer = 0 To xs.Length - 1
            sc &= xs(i) & ","
        Next
        sc = GF_removedh(sc)
        syph = sc
    End Function

    '********************************************************************************************
    Public Function getFJSCZBdatatable(ByVal tjq As String, ByVal phq As String, ByVal phz As String, ByVal n441f1q As String, ByVal n441f1z As String, ByVal n441f34q As String, ByVal n441f34z As String, ByVal n441f5q As String, ByVal n441f5z As String, ByVal x832p1q As String, ByVal x832p1z As String, ByVal x832p34q As String, ByVal x832p34z As String, ByVal x832p5q As String, ByVal x832p5z As String, ByVal k1 As String, ByVal k2 As String, ByVal k3 As String, ByVal k4 As String, ByVal k5 As String, ByVal k6 As String, ByVal cpnew As String, ByVal cpend As String) As Data.DataTable

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''配料批时间区间查询得到批号

        Dim phxl1 As String = ""
        If n441f1q <> "" And n441f1z <> "" Then
            phxl1 = frfjsczbYS2.ddphzh("select tb_n441f_num from tb_n441f where tb_n441f_m382e='1号塔' and tb_n441f_jgrq between '" & n441f1q & "' and  '" & n441f1z & "' ")
            phxl1 = GF_zhzfccx(phxl1)
        End If
        Dim phxl34 As String = ""
        If n441f34q <> "" And n441f34z <> "" Then
            phxl34 = frfjsczbYS2.ddphzh("select tb_n441f_num from tb_n441f where tb_n441f_m382e='34号塔' and tb_n441f_jgrq between '" & n441f34q & "' and  '" & n441f34z & "' ")
            phxl34 = GF_zhzfccx(phxl34)
        End If
        Dim phxl5 As String = ""
        If n441f5q <> "" And n441f5z <> "" Then
            phxl5 = frfjsczbYS2.ddphzh("select tb_n441f_num from tb_n441f where tb_n441f_m382e='5号塔' and tb_n441f_jgrq between '" & n441f5q & "' and  '" & n441f5z & "' ")
            phxl5 = GF_zhzfccx(phxl5)
        End If
        Dim allph As String = syph(phxl1, phxl34, phxl5) : ph = allph

        '根据批号得到对应 所有ID
        Dim allid As String = frfjsczbYS2.ddphzh("select tb_n441f_ID from tb_n441f where tb_n441f_num in(" & allph & ")")
        Dim zd(12, 1) As String
        zd(0, 0) = "dpzl" : zd(0, 1) = "AA油"
        zd(1, 0) = "z884r" : zd(1, 1) = "麦芽糊精(底料)"
        zd(2, 0) = "g154y" : zd(2, 1) = "麦芽糊精(喷雾)"
        zd(3, 0) = "g180y" : zd(3, 1) = "磷酸三钙"
        zd(4, 0) = "h209z" : zd(4, 1) = "变性淀粉"
        zd(5, 0) = "d66v" : zd(5, 1) = "酪蛋白酸钠"
        zd(6, 0) = "t685m" : zd(6, 1) = "柠檬酸钠"
        zd(7, 0) = "h201z" : zd(7, 1) = "葡萄糖"
        zd(8, 0) = "q535i" : zd(8, 1) = "维生素C钠"
        zd(9, 0) = "u693m" : zd(9, 1) = "固体玉米糖浆"
        'zd(10, 0) = "rtm" : zd(10, 1) = "乳糖"
        zd(10, 0) = "rqdbfm" : zd(10, 1) = "乳清蛋白粉"
        zd(11, 0) = "pttjm" : zd(11, 1) = "葡萄糖浆"
        zd(12, 0) = "llzm" : zd(12, 1) = "卵磷脂"
        Dim dt2 As New Data.DataTable

        For i As Integer = 1 To UBound(zd, 1)
            Dim sql As String = ""
            sql = "select " & tjq & " as  统计期, '" & phq & "' as 批号起, '" & phz & "' as 批号止,'" & zd(i, 1) & "'  as 原料名称, "
            sql = sql & "SUM(isnull(tb_n441f_" & zd(i, 0) & ",0.00)) AS 合计,"
            sql = sql & "SUM(CASE WHEN tb_n441f_m382e='1号塔' THEN tb_n441f_" & zd(i, 0) & " ELSE 0 END)AS '1号塔', "
            sql = sql & "SUM(CASE WHEN tb_n441f_m382e='34号塔'  THEN tb_n441f_" & zd(i, 0) & " ELSE 0 END)AS '34号塔',"
            sql = sql & "SUM(CASE WHEN tb_n441f_m382e='5号塔'  THEN tb_n441f_" & zd(i, 0) & " ELSE 0 END)AS '5号塔',"
            sql = sql & " '" & allid & "' as 对应配料批ID,'" & G_dlrgh & "' as 操作人工号 from tb_n441f where  tb_n441f_id in (" & allid & ")"
            Dim dt1 As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If i = 1 Then
                dt2 = dt1.Clone
            End If
            Dim nn As DataRow = dt1.Rows(0)
            dt2.ImportRow(nn)
            dt2.AcceptChanges()
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''' '增加一行,显示AA油
        Dim dtt1, dtt2, dtt3 As DataTable
        Dim Sql2 As String = "select SUM(CASE WHEN tb_n441f_m382e='1号塔' THEN tb_n441f_dpzl ELSE 0 END) as '1号塔' from tb_n441f where  tb_n441f_id in (" & allid & ")"
        dtt1 = GF_CreateDataSource(G_cnnstr, Sql2)
        Sql2 = "select SUM(CASE WHEN tb_n441f_m382e='34号塔' THEN tb_n441f_dpzl ELSE 0 END) as '34号塔' from tb_n441f where  tb_n441f_id in (" & allid & ") and (left(tb_n441f_num2,1)='c' or left(tb_n441f_num2,1)='f')"
        dtt2 = GF_CreateDataSource(G_cnnstr, Sql2)
        Dim sql3 As String = "select sum(tb_p525h_kytj) from tb_p525h where tb_p525h_jgrq between '" & k5 & "' and  '" & k6 & "' and (left(tb_p525h_pldh,1)='d' or left(tb_p525h_pldh,1)='e') "

        dtt3 = GF_CreateDataSource(G_cnnstr, sql3)

        Dim aa(9) As String
        aa(0) = tjq : aa(1) = phq : aa(2) = phz : aa(3) = "AA油重量" : aa(5) = FormatNumber(Null2zero2(dtt1.Rows(0)(0)), 2) : aa(6) = FormatNumber(Null2zero2(dtt2.Rows(0)(0)), 2) : aa(7) = FormatNumber(Null2zero2(dtt3.Rows(0)(0)), 2) : aa(4) = FormatNumber((Double.Parse(aa(5)) + Double.Parse(aa(6)) + Double.Parse(aa(7))), 2) : aa(9) = G_dlrgh
        '统计期 批号起 批号止 原料名称 合计 1号塔 34号塔 (5号塔)  对应配料批ID 操作人工号
        dt2.Rows.Add(aa)

        ''''''''''''''''''增加一行,显示乳糖

        Dim kvb1 As Integer = 0 : Dim kvb3 As Integer = 0 : Dim kvb5 As Integer = 0
        If k1 <> "" And k2 <> "" Then '1号塔的
            Try
                Dim phxl11 As String = frfjsczbYS2.ddphzh("select tb_p525h_num2 from tb_p525h where tb_p525h_th='1号塔' and tb_p525h_jgrq between '" & k1 & "' and  '" & k2 & "' ")
                phxl11 = GF_zhzfccx(phxl11) '根据时间区间得到配料批号
                Sql2 = "select sum(tb_p525h_rtzl) from tb_p525h where tb_p525h_num2 in (" & phxl11 & ")"
                Dim dt111 As DataTable = GF_CreateDataSource(G_cnnstr, Sql2)
                kvb1 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(0))
            Catch ex As Exception
                kvb1 = "0"
            End Try
        End If

        If k3 > "" And k4 <> "" Then '34号塔的
            Try
                Dim phxl11 As String = frfjsczbYS2.ddphzh("select tb_p525h_num2 from tb_p525h where tb_p525h_th='34号塔' and tb_p525h_jgrq between '" & k3 & "' and  '" & k4 & "' ")

                phxl11 = GF_zhzfccx(phxl11) '根据时间区间得到配料批号

                Sql2 = "select  sum(tb_p525h_rtzl) from tb_p525h where tb_p525h_num2 in (" & phxl11 & ")"
                Dim dt111 As DataTable = GF_CreateDataSource(G_cnnstr, Sql2)
                kvb3 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(0))
            Catch ex As Exception
                kvb3 = "0"
            End Try
        End If

        If k5 <> "" And k6 <> "" Then '5号塔的
            Dim sql As String = "select tb_p525h_num2 from tb_p525h where tb_p525h_th='5号塔' and tb_p525h_jgrq between '" & k5 & "' and  '" & k6 & "' "
            Dim phxl11 As String = frfjsczbYS2.ddphzh(sql)
            phxl11 = GF_zhzfccx(phxl11) '根据时间区间得到配料批号
            Sql2 = "select sum(tb_p525h_rtzl) from tb_p525h where tb_p525h_num2 in (" & phxl11 & ")"
            Dim dt111 As DataTable = GF_CreateDataSource(G_cnnstr, Sql2)
            kvb5 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(0))

        End If
        Dim cc(9) As String
        cc(0) = tjq : cc(1) = phq : cc(2) = phz : cc(3) = "乳糖重量" : cc(5) = kvb1 : cc(6) = kvb3 : cc(7) = kvb5 : cc(4) = FormatNumber((Double.Parse(cc(5)) + Double.Parse(cc(6)) + Double.Parse(cc(7))), 2) : cc(9) = G_dlrgh
        dt2.Rows.Add(cc)

        '''''''''''''''''''''''''增加一行，显示优粉铝箔袋
        Dim nvb1 As Integer = 0 : Dim nvb2 As Integer = 0 : Dim nvb3 As Integer = 0 : Dim nvb4 As Integer = 0 : Dim nvb5 As Integer = 0 : Dim nvb6 As Integer = 0 : Dim ovb1 As Integer = 0 : Dim ovb3 As Integer = 0 : Dim ovb5 As Integer = 0
        If x832p1q <> "" And x832p1z <> "" Then '1号塔
            Dim phxl11 As String = frfjsczbYS2.ddphzh("select tb_x832p_num from vw_x832p where tb_x832p_th='1号塔成品粉' and tb_x832p_jgrq between '" & x832p1q & "' and  '" & x832p1z & "' ")
            phxl11 = GF_zhzfccx(phxl11) '根据时间区间得到配料批号
            Sql2 = "select sum(tb_x832p_ybdzl),sum(tb_x832p_ypybdzl),sum(tb_x832p_yjlbdzl)  from vw_x832p where tb_x832p_num in (" & phxl11 & ")"
            Dim dt111 As DataTable = GF_CreateDataSource(G_cnnstr, Sql2)
            nvb1 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(0)) '5KG粉剂铝箔袋
            nvb2 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(1)) '1KG粉剂铝箔袋
            ovb1 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(2)) '5KG油剂铝箔袋 
        End If

        If x832p34q <> "" And x832p34z <> "" Then '34号塔
            Dim phxl11 As String = frfjsczbYS2.ddphzh("select tb_x832p_num from vw_x832p where tb_x832p_th='34号塔成品粉' and tb_x832p_jgrq between '" & x832p34q & "' and  '" & x832p34z & "' ")
            phxl11 = GF_zhzfccx(phxl11) '根据时间区间得到配料批号
            Sql2 = "select  sum(tb_x832p_ybdzl),sum(tb_x832p_ypybdzl) ,sum(tb_x832p_yjlbdzl) from vw_x832p where tb_x832p_num in (" & phxl11 & ")"

            Dim dt111 As DataTable = GF_CreateDataSource(G_cnnstr, Sql2)
            nvb3 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(0)) '5KG粉剂铝箔袋
            nvb4 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(1)) '1KG粉剂铝箔袋
            ovb3 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(2)) '5KG油剂铝箔袋 
        End If

        If x832p5q <> "" And x832p5z <> "" Then '5号塔
            Dim phxl11 As String = frfjsczbYS2.ddphzh("select tb_x832p_num from vw_x832p where tb_x832p_th='5号塔成品粉' and tb_x832p_jgrq between '" & x832p5q & "' and  '" & x832p5z & "' ")
            phxl11 = GF_zhzfccx(phxl11) '根据时间区间得到配料批号
            Sql2 = "select  sum(tb_x832p_ybdzl),sum(tb_x832p_ypybdzl) ,sum(tb_x832p_yjlbdzl) from vw_x832p where tb_x832p_num in (" & phxl11 & ")"
            Dim dt111 As DataTable = GF_CreateDataSource(G_cnnstr, Sql2)
            nvb5 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(0)) '5KG粉剂铝箔袋
            nvb6 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(1)) '1KG粉剂铝箔袋
            ovb5 = DeepCode.DeepDoStr.Null2zero(dt111.Rows(0)(2)) '5KG油剂铝箔袋 
        End If

        Dim aaa(9) As String
        aaa(0) = tjq : aaa(1) = cpnew : aaa(2) = cpend : aaa(3) = "5KG粉剂铝箔袋" : aaa(5) = nvb1 : aaa(6) = nvb3 : aaa(7) = nvb5 : aaa(4) = FormatNumber((Double.Parse(aaa(5)) + Double.Parse(aaa(6)) + Double.Parse(aaa(7))), 2) : aaa(9) = G_dlrgh
        dt2.Rows.Add(aaa)
        aaa(0) = tjq : aaa(1) = cpnew : aaa(2) = cpend : aaa(3) = "1KG粉剂铝箔袋" : aaa(5) = nvb2 : aaa(6) = nvb4 : aaa(7) = nvb6 : aaa(4) = FormatNumber((Double.Parse(aaa(5)) + Double.Parse(aaa(6)) + Double.Parse(aaa(7))), 2) : aaa(9) = G_dlrgh
        dt2.Rows.Add(aaa)
        aaa(0) = tjq : aaa(1) = cpnew : aaa(2) = cpend : aaa(3) = "优粉铝箔袋" : aaa(5) = ovb1 : aaa(6) = ovb3 : aaa(7) = ovb5 : aaa(4) = FormatNumber((Double.Parse(aaa(5)) + Double.Parse(aaa(6)) + Double.Parse(aaa(7))), 2) : aaa(9) = G_dlrgh
        dt2.Rows.Add(aaa)
        Return dt2
    End Function
    Private Sub weizhi()
        ListView1.Width = Me.Width - 20
        ListView1.Height = Me.Height - ListView1.Top - 20
    End Sub
    Private Sub fjylsy2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If GF_storelog1("锁定报表") = False Then
        '    Exit Sub
        'End If ' 判断是否有权限

        If Me.ListView1.Items.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("保存锁定报表将锁定相关的记录，您确定吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim n As Integer = GF_GetListIndexByText(ListView1, "对应配料批ID") '根据中文名返回列索引
        If ccrsdb2(Me.ListView1, "tb_zfxylbb") = True Then
            Call GS_sd("tb_n441f", Me.ListView1.Items(0).SubItems(n).Text, G_dlrgh)
            MsgBox("完成报表数据锁定")
            Button2.Enabled = False
        End If
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, Me.Text, Me)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GS_showmx("tb_n441f", plpid)
    End Sub
    'strtb2代表报表表，代表ID序列
    Public Function ccrsdb2(ByVal list1 As ListView, ByVal strtb2 As String) As Boolean
        ccrsdb2 = False
        Dim dt As DataTable = ListviewToDatatable(list1)
        Dim dtall As New DataTable
        dtall.Columns.Add("zw")
        dtall.Columns.Add("mx")
        Dim dr As DataRow
        dr = dtall.NewRow : dr(0) = "统计期" : dr(1) = "tb_zfxylbb_tjq" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "批号起" : dr(1) = "tb_zfxylbb_phq" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "批号止" : dr(1) = "tb_zfxylbb_phz" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "原料名称" : dr(1) = "tb_zfxylbb_s644l" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "合计" : dr(1) = "tb_zfxylbb_f147y" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "1号塔" : dr(1) = "tb_zfxylbb_f147y" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "34号塔" : dr(1) = "tb_zfxylbb_i251a" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "5号塔" : dr(1) = "tb_zfxylbb_5th" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "对应配料批ID" : dr(1) = "tb_zfxylbb_plpid" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "操作人工号" : dr(1) = "tb_zfxylbb_czrgh" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "1号塔投入总量" : dr(1) = "tb_zfxylbb_t674l" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "34号塔投入总量" : dr(1) = "tb_zfxylbb_q562i" : dtall.Rows.Add(dr)
        dr = dtall.NewRow : dr(0) = "5号塔投入总量" : dr(1) = "tb_zfxylbb_5tht" : dtall.Rows.Add(dr)


        '统计期 批号起 批号止 原料名称 合计 1号塔 34号塔 (5号塔)  对应配料批ID 操作人工号
        'Try
        Dim n As Integer = list1.Columns.Count
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()

        For i As Integer = 0 To ListView1.Items.Count - 2
            Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            Dim zd As String = "" : Dim zs As Integer : Dim zdl As String
            For j As Integer = 0 To n - 1
                zd = dt.Columns(j).ColumnName
                zdl = DeepCode.DeepDoDataTable.GF_cnwithen(dtall, "zw='" & zd & "'", 1)
                zs = GF_GetListIndexByTag(list1, zd)
                RS(zdl).value = list1.Items(i).SubItems(zs).Text

            Next
            RS.update()
            RS.close() : RS = Nothing
        Next
        cnn.close() : cnn = Nothing
        ccrsdb2 = True

    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GS_showmx("tb_p525h", ph)
    End Sub
    '得到某批号对应的开始和结束时间

    Public Function sfyph(ByVal strtb As String, ByVal strnum As String) As String
        Dim sql As String = "select " & strtb & "_jgrq   from " & strtb & "  where   " & strtb & "_num='" & strnum & "'"
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            Return ""
        Else
            Return dt.Rows(0)(0)
        End If
    End Function
End Class