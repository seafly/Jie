Public Class frfjsczbYS2
    Dim tt341, tt342, tt11, tt12, tt51, tt52 As String '得到34号塔配料批、1号塔配料批的时间区间
    Dim cpfid As String

    Private Sub frfjsczbYS2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        weizhi()
        Dim sql As String = "select tb_yxjh_tjq from tb_yxjh  where  tb_yxjh_y846q='34号塔成品粉' or tb_yxjh_y846q='1号塔成品粉'or  tb_yxjh_y846q='5号塔成品粉' group by tb_yxjh_tjq"
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(nian1, dt, 0, "")
    End Sub
    Private Sub weizhi()
        ListView1.Width = Me.Width - 30
        ListView1.Height = Me.Height - ListView1.Top - 30
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim tjq As String = nian1.Text
        Dim dts As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select  tb_zfjbb_ID,tb_zfjbb_tjq,tb_zfjbb_phq,tb_zfjbb_phz,tb_zfjbb_d44v,tb_zfjbb_a935s,tb_zfjbb_v741n,tb_zfjbb_g159y,tb_zfjbb_n449f,tb_zfjbb_r573j,tb_zfjbb_q550i,tb_zfjbb_n455g,tb_zfjbb_lthp34,tb_zfjbb_m382e,tb_zfjbb_g186z,tb_zfjbb_z914s,tb_zfjbb_c997u,tb_zfjbb_input,tb_zfjbb_fp,tb_zfjbb_lthp5,tb_zfjbb_rjct,tb_zfjbb_yield,tb_zfjbb_rjctrt,tb_zfjbb_rwkpwd,tb_zfjbb_b978t,tb_zfjbb_l342d,tb_zfjbb_x812p,tb_zfjbb_l349d,tb_zfjbb_dyid from tb_zfjbb  where  tb_zfjbb_tjq=" & tjq)
        If dts.Rows.Count > 0 Then
            dts.Columns.RemoveAt(0) '得到报表的架构
            cpfid = dts.Rows(0)("tb_zfjbb_dyid") '对应的成品粉ID
            Call GS_useviewbydb2(Me.ListView1, dts, -1, 100)
            Button2.Enabled = False
            Exit Sub
        Else
            Button2.Enabled = True
        End If

        ''''如果该期报表已有那么直接就显示
        Dim sql As String = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='34号塔成品粉'  and tb_yxjh_tjq=" & tjq
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)


        ''''求粉剂配料时间区间

        Dim qh341 As String = ""
        Dim qh342 As String = ""
        If dt.Rows.Count = 0 Then
            MsgBox("34号塔起止批号未设置")
        Else
            qh341 = dt.Rows(0)(0) : qh342 = dt.Rows(0)(1) '34号塔粉剂配料 起止批号 
        End If

        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='1号塔成品粉' and tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)

        Dim qh11 As String = ""
        Dim qh12 As String = ""
        If dt.Rows.Count = 0 Then
            MsgBox("1号塔起止批号未设置")
        Else
            qh11 = dt.Rows(0)(0) : qh12 = dt.Rows(0)(1) '1号塔粉剂配料 起止批号 
        End If


        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='5号塔成品粉' and tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        Dim qh51 As String = ""
        Dim qh52 As String = ""
        If dt.Rows.Count = 0 Then
            MsgBox("5号塔起止批号未设置")
        Else
            qh51 = dt.Rows(0)(0) : qh52 = dt.Rows(0)(1) '5号成品粉 起止批号  
        End If

        '成品粉时间区间 
        Dim tt341, tt342, tt11, tt12, tt51, tt52 As String
        tt341 = sfyph("tb_x832p", qh341) : tt342 = sfyph("tb_x832p", qh342) '34号塔
        tt11 = sfyph("tb_x832p", qh11) : tt12 = sfyph("tb_x832p", qh12) '1号塔
        tt51 = sfyph("tb_x832p", qh51) : tt52 = sfyph("tb_x832p", qh52) '5号塔
        If tt341 = "" And tt342 = "" And tt11 = "" And tt12 = "" And tt51 = "" And tt52 = "" Then
            MsgBox("1号塔或34号塔或5号塔起止批号设置不对") : Exit Sub
        End If


        '''''''''''求配料批的时间区间

        Dim pqh11 As String = "" : Dim pqh12 As String = ""
        Dim pqh341 As String = "" : Dim pqh342 As String = ""
        Dim pqh51 As String = "" : Dim pqh52 As String = ""
        Dim psql As String = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='34号塔粉剂配料批'  and tb_yxjh_tjq=" & tjq
        Dim pdt As Data.DataTable = GF_CreateDataSource(G_cnnstr, psql)
        If pdt.Rows.Count > 0 Then
            pqh341 = pdt.Rows(0)(0) : pqh342 = pdt.Rows(0)(1) '得到334号塔粉剂配料批的起止批号
        End If

        psql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='1号塔粉剂配料批'  and  tb_yxjh_tjq=" & tjq
        pdt = GF_CreateDataSource(G_cnnstr, psql)
        If pdt.Rows.Count > 0 Then
            pqh11 = pdt.Rows(0)(0) : pqh12 = pdt.Rows(0)(1) '得到1号塔粉剂配料批的起止批号
        End If

        psql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='5号塔粉剂配料批'  and  tb_yxjh_tjq=" & tjq
        pdt = GF_CreateDataSource(G_cnnstr, psql)
        If pdt.Rows.Count > 0 Then
            pqh51 = pdt.Rows(0)(0) : pqh52 = pdt.Rows(0)(1) '得到5号塔粉剂配料批的起止批号
        End If

        '配料批的时间区间
        Dim ptt341, ptt342, ptt11, ptt12, ptt51, ptt52 As String
        ptt341 = sfyph("tb_n441f", pqh341) : ptt342 = sfyph("tb_n441f", pqh342) '34号塔
        ptt11 = sfyph("tb_n441f", pqh11) : ptt12 = sfyph("tb_n441f", pqh12) '1号塔
        ptt51 = sfyph("tb_n441f", pqh51) : ptt52 = sfyph("tb_n441f", pqh52) '5号塔

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        dt = getFJSCZBdatatable(tjq, qh11 & "," & qh341 & "," & qh51, qh12 & "," & qh342 & "," & qh52, tt11, tt12, tt341, tt342, tt51, tt52, ptt11, ptt12, ptt341, ptt342, ptt51, ptt52)

        If dt.Rows.Count <> 0 Then
            cpfid = dt.Rows(0)("tb_zfjbb_dyid")
        End If

        Call GS_useviewbydb2(Me.ListView1, dt, -1, 100)
        'Catch ex As Exception
        '    MsgBox("尚未生产到计划批次！")
        'End Try
    End Sub
    '********************************************************************************************
    Public Function getFJSCZBdatatable(ByVal tjq As String, ByVal phq As String, ByVal phz As String, ByVal sj1 As String, ByVal sj2 As String, ByVal sj3 As String, ByVal sj4 As String, ByVal sj5 As String, ByVal sj6 As String, ByVal sj7 As String, ByVal sj8 As String, ByVal sj9 As String, ByVal sj10 As String, ByVal sj11 As String, ByVal sj12 As String) As Data.DataTable

        '''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql As String = "select top 1 tb_zfjbb_ID,tb_zfjbb_tjq,tb_zfjbb_phq,tb_zfjbb_phz,tb_zfjbb_d44v,tb_zfjbb_a935s,tb_zfjbb_v741n,tb_zfjbb_g159y,tb_zfjbb_n449f,tb_zfjbb_r573j,tb_zfjbb_q550i,tb_zfjbb_n455g,tb_zfjbb_lthp34,tb_zfjbb_m382e,tb_zfjbb_g186z,tb_zfjbb_z914s,tb_zfjbb_c997u,tb_zfjbb_input,tb_zfjbb_fp,tb_zfjbb_lthp5,tb_zfjbb_rjct,tb_zfjbb_yield,tb_zfjbb_rjctrt,tb_zfjbb_rwkpwd,tb_zfjbb_b978t,tb_zfjbb_aayzl,tb_zfjbb_l342d,tb_zfjbb_x812p,tb_zfjbb_l349d,tb_zfjbb_dyid  from tb_zfjbb  "
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dt.Rows.Clear() : dt.Columns.RemoveAt(0) '得到粉剂报表的架构

        Dim dataRow As Data.DataRow
        dataRow = dt.NewRow()
        dataRow(0) = tjq : dataRow(1) = phq : dataRow(2) = phz
        '''''''''在原料报表中统计input'''''''
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, "select sum(tb_zfxylbb_f147y),sum(tb_zfxylbb_i251a),sum(tb_zfxylbb_5th) from tb_zfxylbb where tb_zfxylbb_s644l not like '%铝箔袋%' and tb_zfxylbb_tjq=" & tjq)
        If dt2.Rows.Count > 0 Then
            dataRow("tb_zfjbb_d44v") = Null2zero2(dt2.Rows(0)(0))
            dataRow("tb_zfjbb_q550i") = Null2zero2(dt2.Rows(0)(1))
            dataRow("tb_zfjbb_input") = Null2zero2(dt2.Rows(0)(2))
        Else
            dataRow("tb_zfjbb_d44v") = 0
            dataRow("tb_zfjbb_q550i") = 0
            dataRow("tb_zfjbb_input") = 0
        End If

        '''''''''''''''''''''''''''''''''''''1,34,5#-Rework Power
        gettime(tjq)
        Dim dtdp As DataTable = GF_CreateDataSource(G_cnnstr, "select sum(tb_n441f_e95w) from tb_n441f where tb_n441f_m382e='1号塔' and tb_n441f_jgrq between '" & tt11 & "' and  '" & tt12 & "' ")
        dataRow("tb_zfjbb_r573j") = Null2zero2(dtdp.Rows(0)(0))
        dtdp = GF_CreateDataSource(G_cnnstr, "select sum(tb_n441f_e95w) from tb_n441f where tb_n441f_m382e='34号塔' and tb_n441f_jgrq between '" & tt341 & "' and  '" & tt342 & "' ")
        dataRow("tb_zfjbb_c997u") = Null2zero2(dtdp.Rows(0)(0))
        dtdp = GF_CreateDataSource(G_cnnstr, "select sum(tb_n441f_e95w) from tb_n441f where tb_n441f_m382e='5号塔' and tb_n441f_jgrq between '" & tt51 & "' and  '" & tt52 & "' ")
        dataRow("tb_zfjbb_rwkpwd") = Null2zero2(dtdp.Rows(0)(0))
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘


        Dim allph As String = ""
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        '1号塔成品粉时间区间
        If sj1 <> "" And sj2 <> "" Then
            Dim phxl1 As String = ddphzh("select tb_x832p_num from vw_x832p where tb_x832p_th='1号塔成品粉' and  tb_x832p_jgrq between '" & sj1 & "' and  '" & sj2 & "' ")
            phxl1 = GF_zhzfccx(phxl1)
            allph = phxl1
            sql = "select sum(tb_x832p_z886r),sum(tb_x832p_i232a),sum(tb_x832p_l349d)  from vw_x832p where tb_x832p_num in (" & phxl1 & ")"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            dataRow("tb_zfjbb_g159y") = Double.Parse(Null2zero2(dt2.Rows(0)(2)))
            ''''''''''''''''''finished
            Dim shuju1 As Double = Null2zero2(dt2.Rows(0)(1))
            sql = "select sum(tb_pljh_cpzl) from tb_pljh where left(tb_pljh_cpph,1)='1' and tb_pljh_rq between'" & sj1 & "' and  '" & sj2 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju2 As Double = Null2zero2(dt2.Rows(0)(0))
            'sql = "select sum(tb_fgyf_zl) from tb_fgyf where tb_fgyf_rq between'" & sj1 & "' and  '" & sj2 & "'"
            sql = "select sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_cplb='APGK' or tb_x832p_cplb='APGB') and tb_x832p_th='1号塔成品粉' and tb_x832p_jgrq between'" & sj1 & "' and  '" & sj2 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju3 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_bz='零头混批' and tb_x832p_th='34号塔成品粉' and tb_x832p_jgrq between'" & sj3 & "' and  '" & sj4 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju4 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))

            dataRow("tb_zfjbb_a935s") = Double.Parse((shuju1 - shuju2 - shuju3 - shuju4))
            ''''''''''''''''''''rejection''''''''''''''''''''
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_th='1号塔成品粉' and (tb_x832p_cplb<>'APGK' and tb_x832p_cplb<>'APGB')  and tb_x832p_num in (" & phxl1 & ") and tb_x832p_qaspjg='报废'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            shuju1 = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            sql = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_th='1号塔' and tb_p525h_jgrq between'" & sj1 & "' and  '" & sj2 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            shuju2 = Null2zero2(dt2.Rows(0)(0))
            dataRow("tb_zfjbb_v741n") = FormatNumber(Double.Parse(shuju1) + Double.Parse(shuju2), 2)
            '''''''''''''''''''''''yield'''''''''''''
            If dataRow("tb_zfjbb_d44v") > 0 Then
                Dim aaa As Double = Double.Parse(dataRow("tb_zfjbb_g159y")) + Double.Parse(dataRow("tb_zfjbb_a935s"))
                Dim bbb As Double = Double.Parse(dataRow("tb_zfjbb_d44v")) + Double.Parse(dataRow("tb_zfjbb_r573j"))
                dataRow("tb_zfjbb_g159y") = Format(aaa * 100 / (bbb), "0.00")
            Else
                dataRow("tb_zfjbb_g159y") = 0
            End If

            If dataRow("tb_zfjbb_a935s") > 0 Then
                dataRow("tb_zfjbb_n449f") = Format((dataRow("tb_zfjbb_v741n") * 100 / (dataRow("tb_zfjbb_a935s"))), "0.00")
            Else
                dataRow("tb_zfjbb_n449f") = 0
            End If
        Else
            dataRow("tb_zfjbb_d44v") = 0 : dataRow("tb_zfjbb_a935s") = 0 : dataRow("tb_zfjbb_v741n") = 0 : dataRow("tb_zfjbb_g159y") = 0 : dataRow("tb_zfjbb_n449f") = 0
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''

        '34号塔成品粉时间区间
        If sj3 <> "" And sj4 <> "" Then
            Dim phxl34 As String = ddphzh("select tb_x832p_num from vw_x832p where tb_x832p_th='34号塔成品粉'  and  tb_x832p_jgrq between '" & sj3 & "' and  '" & sj4 & "' ")
            phxl34 = GF_zhzfccx(phxl34)
            If allph <> "" Then
                allph = allph & "," & phxl34
            Else
                allph = phxl34
            End If
            sql = "select sum(tb_x832p_z886r),sum(tb_x832p_i232a),sum(tb_x832p_l349d)  from vw_x832p where  tb_x832p_num in (" & phxl34 & ")"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            dataRow("tb_zfjbb_g186z") = Double.Parse(Null2zero2(dt2.Rows(0)(2)))
            Dim shuju1 As Double = FormatNumber(Null2zero2(dt2.Rows(0)(1)), 2)
            sql = "select sum(tb_pljh_cpzl) from tb_pljh where left(tb_pljh_cpph,1)='2' and tb_pljh_rq between'" & sj3 & "' and  '" & sj4 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju2 As Double = FormatNumber(Null2zero2(dt2.Rows(0)(0)), 2)
            sql = "select sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_cplb='APGK' or tb_x832p_cplb='APGB') and tb_x832p_th='34号塔成品粉' and tb_x832p_jgrq between'" & sj3 & "' and  '" & sj4 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju3 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_bz='零头混批' and tb_x832p_th='34号塔成品粉' and tb_x832p_jgrq between'" & sj3 & "' and  '" & sj4 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju4 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            dataRow("tb_zfjbb_n455g") = FormatNumber((shuju1 - shuju2 - shuju3 - shuju4), 2)
            '3/4#零头混批
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_sbtb<>'tb_p525h' and tb_x832p_th='34号塔成品粉' and tb_x832p_jgrq between'" & sj3 & "' and  '" & sj4 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            dataRow("tb_zfjbb_lthp34") = Null2zero2(dt2.Rows(0)(0))
            ''''''''''''''''''''rejection''''''''''''''''''''
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_th='34号塔成品粉'and (tb_x832p_cplb<>'APGK' and tb_x832p_cplb<>'APGB') and tb_x832p_num in (" & phxl34 & ") and tb_x832p_qaspjg='报废'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            shuju1 = Null2zero2(dt2.Rows(0)(0))
            sql = ("select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_th='34号塔' and tb_p525h_jgrq between'" & sj3 & "' and  '" & sj4 & "'")
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            shuju2 = Null2zero2(dt2.Rows(0)(0))
            dataRow("tb_zfjbb_m382e") = FormatNumber(shuju1 + shuju2, 2)

            If dataRow("tb_zfjbb_q550i") > 0 Then
                dataRow("tb_zfjbb_g186z") = Format(((Double.Parse(dataRow("tb_zfjbb_g186z")) + Double.Parse(dataRow("tb_zfjbb_n455g"))) * 100 / (Double.Parse(dataRow("tb_zfjbb_q550i")) + Double.Parse(dataRow("tb_zfjbb_c997u")))), "0.00")
            Else
                dataRow("tb_zfjbb_g186z") = 0
            End If

            If dataRow("tb_zfjbb_n455g") > 0 Then
                dataRow("tb_zfjbb_z914s") = Format((dataRow("tb_zfjbb_c997u") * 100 / dataRow("tb_zfjbb_n455g")), "0.00")
            Else
                dataRow("tb_zfjbb_z914s") = 0
            End If
        Else
            dataRow("tb_zfjbb_q550i") = 0 : dataRow("tb_zfjbb_n455g") = 0 : dataRow("tb_zfjbb_m382e") = 0 : dataRow("tb_zfjbb_g186z") = 0 : dataRow("tb_zfjbb_z914s") = 0
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '5号塔成品粉时间区间
        If sj5 <> "" And sj6 <> "" Then
            Dim phxl5 As String = ddphzh("select tb_x832p_num from vw_x832p where tb_x832p_th='5号塔成品粉'  and  tb_x832p_jgrq between '" & sj5 & "' and  '" & sj6 & "' ")
            phxl5 = GF_zhzfccx(phxl5)
            If allph <> "" Then
                allph = allph & "," & phxl5
            Else
                allph = phxl5
            End If
            sql = "select sum(tb_x832p_z886r),sum(tb_x832p_i232a),sum(tb_x832p_l349d)  from vw_x832p where  tb_x832p_num in (" & phxl5 & ")"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            dataRow("tb_zfjbb_yield") = Double.Parse(Null2zero2(dt2.Rows(0)(2)))
            Dim shuju1 As Double = FormatNumber(Null2zero2(dt2.Rows(0)(1)), 2)
            sql = "select sum(tb_pljh_cpzl) from tb_pljh where left(tb_pljh_cpph,1)='5' and tb_pljh_rq between'" & sj5 & "' and  '" & sj6 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju2 As Double = FormatNumber(Null2zero2(dt2.Rows(0)(0)), 2)
            sql = "select sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_cplb='APGK' or tb_x832p_cplb='APGB') and tb_x832p_th='5号塔成品粉' and tb_x832p_jgrq between'" & sj5 & "' and  '" & sj6 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju3 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_bz='零头混批' and tb_x832p_th='5号塔成品粉' and tb_x832p_jgrq between'" & sj5 & "' and  '" & sj6 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim shuju4 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            dataRow("tb_zfjbb_fp") = FormatNumber((shuju1 - shuju2 - shuju3 - shuju4), 2) 'finish powder
            '5#零头混批
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_sbtb<>'tb_p525h' and tb_x832p_th='5号塔成品粉' and tb_x832p_jgrq between'" & sj5 & "' and  '" & sj6 & "'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            Dim t5 As Double = Double.Parse(Null2zero2(dt2.Rows(0)(0)))
            dataRow("tb_zfjbb_lthp5") = t5


            ''''''''''''''''''''rejection''''''''''''''''''''
            sql = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_th='5号塔成品粉'and (tb_x832p_cplb<>'APGK' and tb_x832p_cplb<>'APGB') and tb_x832p_num in (" & phxl5 & ") and tb_x832p_qaspjg='报废'"
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            shuju1 = Null2zero2(dt2.Rows(0)(0))
            sql = ("select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_th='5号塔' and tb_p525h_jgrq between'" & sj5 & "' and  '" & sj6 & "'")
            dt2 = GF_CreateDataSource(G_cnnstr, sql)
            shuju2 = Null2zero2(dt2.Rows(0)(0))
            dataRow("tb_zfjbb_rjct") = FormatNumber(shuju1 + shuju2, 2)

            If dataRow("tb_zfjbb_input") > 0 Then
                dataRow("tb_zfjbb_yield") = Format(((Double.Parse(dataRow("tb_zfjbb_yield")) + Double.Parse(dataRow("tb_zfjbb_fp"))) * 100 / (Double.Parse(dataRow("tb_zfjbb_input")) + Double.Parse(dataRow("tb_zfjbb_rwkpwd")))), "0.00")
            Else
                dataRow("tb_zfjbb_yield") = 0
            End If

            If dataRow("tb_zfjbb_fp") > 0 Then
                dataRow("tb_zfjbb_rjctrt") = Format((dataRow("tb_zfjbb_rwkpwd") * 100 / dataRow("tb_zfjbb_fp")), "0.00")
            Else
                dataRow("tb_zfjbb_rjctrt") = 0
            End If
        Else
            dataRow("tb_zfjbb_input") = 0 : dataRow("tb_zfjbb_fp") = 0 : dataRow("tb_zfjbb_rjct") = 0 : dataRow("tb_zfjbb_yield") = 0 : dataRow("tb_zfjbb_rjctrt") = 0 : dataRow("tb_zfjbb_lthp5") = 0

        End If

        dataRow("tb_zfjbb_b978t") = CDbl(dataRow("tb_zfjbb_a935s")) + CDbl(dataRow("tb_zfjbb_n455g")) + CDbl(dataRow("tb_zfjbb_fp"))
        dataRow("tb_zfjbb_l342d") = Format(CDbl(dataRow("tb_zfjbb_v741n")) + CDbl(dataRow("tb_zfjbb_m382e")) + CDbl(dataRow("tb_zfjbb_rjct")), "0.00")
        dataRow("tb_zfjbb_x812p") = Format((dataRow("tb_zfjbb_l342d") * 100 / (dataRow("tb_zfjbb_b978t"))), "0.00")
        Dim tmpint As Integer = 1
        If dataRow("tb_zfjbb_g159y") <> "0" And dataRow("tb_zfjbb_g186z") <> "0" And dataRow("tb_zfjbb_yield") <> "0" Then
            tmpint = tmpint + 1
        End If
        dataRow("tb_zfjbb_l349d") = Format((Double.Parse(dataRow("tb_zfjbb_g159y")) + Double.Parse(dataRow("tb_zfjbb_g186z")) + Double.Parse(dataRow("tb_zfjbb_yield"))) / tmpint, "0.00")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''计算aa油
        Dim pphxl1 As String = ""
        If sj7 <> "" And sj8 <> "" Then
            pphxl1 = ddphzh("select tb_n441f_num from tb_n441f where tb_n441f_m382e='1号塔' and tb_n441f_jgrq between '" & sj7 & "' and  '" & sj8 & "' ")
            pphxl1 = GF_zhzfccx(pphxl1)
        End If
        Dim pphxl34 As String = ""
        If sj9 <> "" And sj10 <> "" Then
            pphxl34 = ddphzh("select tb_n441f_num from tb_n441f where tb_n441f_m382e='34号塔' and tb_n441f_jgrq between '" & sj9 & "' and  '" & sj10 & "' ")
            pphxl34 = GF_zhzfccx(pphxl34)
        End If
        Dim pphxl5 As String = ""
        If sj11 <> "" And sj12 <> "" Then
            pphxl5 = ddphzh("select tb_n441f_num from tb_n441f where tb_n441f_m382e='5号塔' and tb_n441f_jgrq between '" & sj11 & "' and  '" & sj12 & "' ")
            pphxl5 = GF_zhzfccx(pphxl5)
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pallph As String = syph(pphxl1, pphxl34, pphxl5)
        Dim pallid As String = ddphzh("select tb_n441f_ID from tb_n441f where tb_n441f_num in(" & pallph & ")") '得到对应的所有ID

        Dim dtt1, dtt2, dtt3 As DataTable
        Dim Sql2 As String = "select SUM(CASE WHEN tb_n441f_m382e='1号塔' THEN tb_n441f_dpzl ELSE 0 END) as '1号塔' from tb_n441f where  tb_n441f_id in (" & pallid & ")"
        dtt1 = GF_CreateDataSource(G_cnnstr, Sql2)
        Sql2 = "select SUM(CASE WHEN tb_n441f_m382e='34号塔' THEN tb_n441f_dpzl ELSE 0 END) as '34号塔' from tb_n441f where  tb_n441f_id in (" & pallid & ")"
        dtt2 = GF_CreateDataSource(G_cnnstr, Sql2)

        Sql2 = "select SUM(CASE WHEN tb_n441f_m382e='5号塔' THEN tb_n441f_dpzl ELSE 0 END) as '5号塔' from tb_n441f where  tb_n441f_id in (" & pallid & ")"
        dtt3 = GF_CreateDataSource(G_cnnstr, Sql2)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim allid As String = ddphzh("select tb_x832p_ID from vw_x832p where tb_x832p_num in(" & allph & ")") '得到对应的所有ID

        dataRow("tb_zfjbb_dyid") = allid
        dt.Rows.Add(dataRow)
        getFJSCZBdatatable = dt
    End Function
    '得到某批号对应的时间
    Public Function sfyph(ByVal strtb As String, ByVal strnum As String) As String
        Dim sql As String = ""
        If strtb = "tb_p525h" Then
            sql &= "select " & strtb & "_jgrq   from " & strtb & "  where   " & strtb & "_num2='" & strnum & "'"
        Else
            sql &= "select " & strtb & "_jgrq   from " & strtb & "  where   " & strtb & "_num='" & strnum & "'"
        End If
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            Return ""
        Else
            Return dt.Rows(0)(0)
        End If
    End Function
    '得到某批号序列并组成可以进行IN查询的字符串
    Public Function ddphzh(ByVal str As String) As String
        Dim cnn, rs As Object
        cnn = CreateObject("ADODB.Connection")
        cnn.Open(G_cnnstr)
        rs = cnn.execute(str)
        If rs.eof Then
            Return ""

        End If
        ddphzh = rs.getstring(, , , ",")
        rs = Nothing : cnn.close() : cnn = Nothing
        ddphzh = GF_removedh(ddphzh)
    End Function

    Private Sub frfjsczbYS2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If GF_storelog1("锁定报表") = False Then
            Exit Sub
        End If ' 判断是否有权限

        If Me.ListView1.Items.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("保存锁定报表将锁定相关的记录，您确定吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim n As Integer = Me.ListView1.Columns.Count
        If ccrsdb(Me.ListView1, "tb_zfjbb") = True Then
            Call GS_sd("tb_x832p", Me.ListView1.Items(0).SubItems(n - 2).Text, G_dlrgh)
            MsgBox("完成报表数据锁定")
            Button2.Enabled = False
        End If

    End Sub
    'strtb2代表报表表，代表ID序列
    Public Function ccrsdb(ByVal list1 As Control, ByVal strtb2 As String) As Boolean
        ccrsdb = False

        'Try
        If list1.GetType.ToString = "System.Windows.Forms.ListView" Then
            Dim lt As ListView = list1
            Dim dt As DataTable = ListviewToDatatable(list1)
            Dim n As Integer = dt.Columns.Count
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            Dim zd As String = "" : Dim zs As Integer : Dim zdl As String
            For j As Integer = 0 To n - 1

                zd = dt.Columns(j).ColumnName
                zdl = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mx='" & zd & "'", 1)
                zs = GF_GetListIndexByTag(lt, zdl)
                RS(zdl).value = lt.Items(0).SubItems(zs).Text

            Next

            RS.update()
            RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
            ccrsdb = True
        Else
            Dim lt As DataGridView = list1
            Dim n As Integer = lt.Columns.Count
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            For j As Integer = 0 To n - 2
                RS(j + 1).value = lt.Rows(0).Cells(j).Value
            Next
            RS(n).value = G_dlrgh
            RS.update()
            RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
            ccrsdb = True
        End If
    
    End Function

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, Me.Text, Me)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GS_showmx("tb_x832p", cpfid)
    End Sub

    Private Sub gettime(ByVal tjq As String)
        Dim dts As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select  *  from tb_zfxylbb  where  tb_zfxylbb_tjq=" & tjq)
        ''''''''''''''''''''''如果该期报表已有那么直接就显示
        Dim qh11 As String = "" : Dim qh12 As String = ""
        Dim qh341 As String = "" : Dim qh342 As String = "" '得到334号塔粉剂配料批的起止批号
        Dim qh51 As String = "" : Dim qh52 As String = ""
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql As String = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='34号塔粉剂配料批'  and tb_yxjh_tjq=" & tjq
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            qh341 = dt.Rows(0)(0) : qh342 = dt.Rows(0)(1) '得到334号塔粉剂配料批的起止批号
        End If

        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='1号塔粉剂配料批'  and  tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            qh11 = dt.Rows(0)(0) : qh12 = dt.Rows(0)(1) '得到1号塔粉剂配料批的起止批号
        End If

        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='5号塔粉剂配料批'  and  tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            qh51 = dt.Rows(0)(0) : qh52 = dt.Rows(0)(1) '得到5号塔粉剂配料批的起止批号
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If qh11 = "" And qh12 = "" And qh341 = "" And qh342 = "" And qh51 = "" And qh52 = "" Then
            MsgBox("1号塔或34号塔或5号塔粉剂配料批起止批号设置不对") : Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        tt341 = sfyph("tb_n441f", qh341) : tt342 = sfyph("tb_n441f", qh342)
        tt11 = sfyph("tb_n441f", qh11) : tt12 = sfyph("tb_n441f", qh12)
        tt51 = sfyph("tb_n441f", qh51) : tt52 = sfyph("tb_n441f", qh52)
    End Sub
    Private Function syph(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As String
        'If str1 = "" Then
        '    syph = str2 : Exit Function
        'End If
        'If str2 = "" Then
        '    syph = str1 : Exit Function
        'End If
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
End Class