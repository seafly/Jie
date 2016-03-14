Public Class frfxyjylara
    Dim jlnoh As Double '得到精炼的氢氧化钠，为单独统计做准备
    Dim xgid, zgid, dgid, myid, cpyid, tgid, jgid, jg2id As String

    '发酵油剂原料使用统计
    Private Sub frfxyjyl2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        weizhi()
        Dim sql As String = "select tb_yxjh_tjq from tb_yxjh  where   tb_yxjh_y846q='成品油' group by tb_yxjh_tjq"
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(nian1, dt, 0, "")
    End Sub
    Private Sub weizhi()
        ListView1.Width = Me.Width - 20
        ListView1.Height = Me.Height - ListView1.Top - 20
    End Sub
    Private Sub gjdcexcel()
        Dim leftdb As New DataTable '定义列表，为导出EXCEL而不影响原来程序做准备
        With leftdb
            .Columns.Add("统计期", GetType(String)) : .Columns.Add("批号起", GetType(String)) : .Columns.Add("批号止", GetType(String))
            .Columns.Add("类别", GetType(String)) : .Columns.Add("原料代码", GetType(String)) : .Columns.Add("原料名称", GetType(String)) : .Columns.Add("合计", GetType(Double)) : .Columns.Add("操作人工号", GetType(String))
        End With
        With ListView1
            For i As Integer = 0 To .Items.Count - 1
                Dim k As DataRow = leftdb.NewRow
                For j As Integer = 0 To 7
                    k(j) = .Items(i).SubItems(j).Text
                Next
                leftdb.Rows.Add(k)
            Next
        End With
        GS_dbtoexcel(leftdb, Me.Text, Me)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Try
        Dim tjq As String = nian1.Text
        Dim dts As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select  *  from tb_zfjyjylbb  where  tb_zfjyjylbb_tjq=" & tjq)
        If dts.Rows.Count > 0 Then '这里的架构是含有ID的，下面得到的DB是不含ID的，所以赋值和下面有些不同
            dts.Columns.RemoveAt(0) '得到报表的架构
            xgid = dts.Rows(0)(8)
            zgid = dts.Rows(0)(9)
            dgid = dts.Rows(0)(10)
            myid = dts.Rows(0)(11)
            cpyid = dts.Rows(0)(12)
            tgid = dts.Rows(0)(13)
            jgid = dts.Rows(0)(14)
            jg2id = dts.Rows(0)(15)

            Call GS_useviewbydb2(Me.ListView1, dts, -1, 0)
            ycl()
            Button2.Enabled = False : Exit Sub

        End If
        ''''''''''''''''''''''如果该期报表已有那么直接就显示
        Dim sql As String = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='成品油'  and tb_yxjh_tjq=" & tjq
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("成品油起止批号未设置") : Exit Sub
        End If
        Dim qh341 As String = dt.Rows(0)(0) : Dim qh342 As String = dt.Rows(0)(1) '得到起止批号

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tt341, tt342 As String '得到时间区间
        tt341 = frfjsczbYS2.sfyph("tb_h195z", qh341) : tt342 = frfjsczbYS2.sfyph("tb_h195z", qh342)

        If tt341 = "" Or tt342 = "" Then
            MsgBox("成品油起止批号设置不对") : Exit Sub
        End If
        Dim q1, z1 As String
        q1 = "成品油:" & qh341 : z1 = "成品油:" & qh342
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='精炼'  and tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("精炼起止批号未设置") : Exit Sub
        End If
        qh341 = dt.Rows(0)(0) : qh342 = dt.Rows(0)(1) '得到起止批号

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tt441, tt442 As String '得到时间区间
        tt441 = frfjsczbYS2.sfyph("tb_k306c", qh341) : tt442 = frfjsczbYS2.sfyph("tb_k306c", qh342)

        If tt441 = "" Or tt442 = "" Then
            MsgBox("精炼起止批号设置不对") : Exit Sub
        End If
        q1 = q1 & " 精炼:" & qh341 : z1 = z1 & " 精炼:" & qh342
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='放罐'  and tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("放罐起止批号未设置") : Exit Sub
        End If
        qh341 = dt.Rows(0)(0) : qh342 = dt.Rows(0)(1) '得到起止批号

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tt541, tt542 As String '得到时间区间
        Dim sql11 As String = "select tb_x825p_jgrq   from tb_x825p  where   tb_x825p_num2 like '%" & qh341 & "%'"
        Dim dt11 As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql11)
        If dt11.Rows.Count = 0 Then
            MsgBox("放罐起止批号不正确") : Exit Sub
        Else
            tt541 = dt11.Rows(0)(0)
        End If
        sql11 = "select tb_x825p_jgrq from tb_x825p  where   tb_x825p_num2 like '%" & qh342 & "%'"
        dt11 = GF_CreateDataSource(G_cnnstr, sql11)
        If dt11.Rows.Count = 0 Then
            MsgBox("放罐起止批号不正确") : Exit Sub
        Else
            tt542 = dt11.Rows(0)(0)
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If tt541 = "" Or tt542 = "" Then
            MsgBox("放罐起止批号设置不对或尚未生产到计划批次！") : Exit Sub
        End If
        q1 = q1 & " 放罐:" & qh341 : z1 = z1 & " 放罐:" & qh342
        ''''''''''''''''''''''''''''''''''''''
        dt = getFJSCZBdatatable(tjq, qh341, qh342, tt341, tt342, tt441, tt442, tt541, tt542)
        If dt.Rows.Count <> 0 Then
            xgid = dt.Rows(0)(8)
            zgid = dt.Rows(0)(9)
            dgid = dt.Rows(0)(10)
            myid = dt.Rows(0)(11)
            cpyid = dt.Rows(0)(12)
            tgid = dt.Rows(0)(13)
            jgid = dt.Rows(0)(14)
            jg2id = dt.Rows(0)(15)
        End If

        Call GS_useviewbydb2(Me.ListView1, dt, -1, 100)
        Call qdeyhg() '去掉二氧化硅、二氧化硅干胶'氢氧化钠单独统计
        '隐藏所有ID
        ycl()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Catch ex As Exception
        '    MsgBox("查询统计期出错，请检查数据")
        'End Try

    End Sub

    Private Sub ycl()
        '隐藏所有ID
        For z As Integer = 8 To 15
            ListView1.Columns(z).Width = 0
        Next

    End Sub

    '********************************************************************************************依次为成品油、精炼、毛油时间区间
    Public Function getFJSCZBdatatable(ByVal tjq As String, ByVal phq As String, ByVal phz As String, ByVal sj1 As String, ByVal sj2 As String, ByVal sj21 As String, ByVal sj22 As String, ByVal sj31 As String, ByVal sj32 As String) As Data.DataTable
        Dim phx1 As String = frfjsczbYS2.ddphzh("select tb_b970t_num from tb_b970t where tb_b970t_jgrq between '" & sj31 & "' and  '" & sj32 & "' ")
        Dim phx2 As String = frfjsczbYS2.ddphzh("select tb_b959t_num from tb_b959t where tb_b959t_jgrq between '" & sj31 & "' and  '" & sj32 & "' ")
        Dim phx3 As String = frfjsczbYS2.ddphzh("select tb_i234a_num from tb_i234a where tb_i234a_jgrq between '" & sj31 & "' and  '" & sj32 & "' ")
        Dim phx4 As String = frfjsczbYS2.ddphzh("select tb_k306c_num from vw_k306c where tb_k306c_jgrq between '" & sj21 & "' and  '" & sj22 & "' ")
        Dim phx5 As String = frfjsczbYS2.ddphzh("select tb_h195z_num from vw_h195z where tb_h195z_jgrq between '" & sj1 & "' and  '" & sj2 & "' ")
        phx1 = GF_zhzfccx(phx1) : phx2 = GF_zhzfccx(phx2) : phx3 = GF_zhzfccx(phx3) : phx4 = GF_zhzfccx(phx4) : phx5 = GF_zhzfccx(phx5)
        Dim id1 As String = frfjsczbYS2.ddphzh("select tb_b970t_ID from tb_b970t where tb_b970t_num in(" & phx1 & ")") '得到对应的小罐生产所有ID
        Dim id2 As String = frfjsczbYS2.ddphzh("select tb_b959t_ID from tb_b959t where tb_b959t_num in(" & phx2 & ")") '得到对应的中罐生产所有ID
        Dim id3 As String = frfjsczbYS2.ddphzh("select tb_i234a_ID from tb_i234a where tb_i234a_num in(" & phx3 & ")") '得到对应的大罐生产所有ID
        Dim id4 As String = frfjsczbYS2.ddphzh("select tb_k306c_ID from vw_k306c where tb_k306c_num in(" & phx4 & ")") '得到对应的精炼所有ID
        Dim id5 As String = frfjsczbYS2.ddphzh("select tb_h195z_ID from vw_h195z where tb_h195z_num in(" & phx5 & ")") '得到对应的成品油所有ID
        '''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim idtemp As String = frfjsczbYS2.ddphzh("select tb_i234a_tgph from tb_i234a where tb_i234a_num in(" & phx3 & ")")
        idtemp = GF_zhzfccx(idtemp)
        Dim id6 As String = frfjsczbYS2.ddphzh("select tb_tg_ID from tb_tg where tb_tg_num in (" & idtemp & " )") '得到对应的糖罐所有ID
        idtemp = frfjsczbYS2.ddphzh("select tb_i234a_jgph from tb_i234a where tb_i234a_num in(" & phx3 & ")")
        idtemp = GF_zhzfccx(idtemp)
        Dim id7 As String = frfjsczbYS2.ddphzh("select tb_jg_ID from tb_jg where tb_jg_num in (" & idtemp & " )") ''得到对应的碱罐所有ID
        Dim id8 As String = frfjsczbYS2.ddphzh("select tb_jg2_ID from tb_jg2 where tb_jg2_rq between '" & sj31 & "' and  '" & sj32 & "'") '得到对应的CIP碱罐所有ID
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim id6 As String = frfjsczbYS2.ddphzh("select tb_tg_ID from tb_tg where tb_tg_rq between '" & sj31 & "' and  '" & sj32 & "'") '得到对应的糖罐所有ID
        'Dim id7 As String = frfjsczbYS2.ddphzh("select tb_jg_ID from tb_jg where tb_jg_rq between '" & sj31 & "' and  '" & sj32 & "'") '得到对应的碱罐所有ID
        'Dim id8 As String = frfjsczbYS2.ddphzh("select tb_jg2_ID from tb_jg2 where tb_jg2_rq between '" & sj31 & "' and  '" & sj32 & "'") '得到对应的CIP碱罐所有ID
        '''''''''''''''''''''''''上面得到小中大精炼成品油的批号和ID
        Dim tgozl1 As Double = 0 : Dim tgozl2 As Double = 0 : Dim tgozl3 As Double = 0 '依次为糖罐葡萄糖重量、碱罐氢氧化钠、CIP碱罐氢氧化钠
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tdb As DataTable = GF_CreateDataSource(G_cnnstr, "select sum(0) from tb_i234a where tb_i234a_num in(" & phx3 & ") ")
        'InputBox("asdf", "", phx3)
        tgozl1 = Null2zero2(tdb.Rows(0)(0)) '糖罐葡萄糖重量
        'MsgBox(tgozl1)
        tdb = GF_CreateDataSource(G_cnnstr, "select sum(tb_i234a_jgqyhnpht) from tb_i234a where tb_i234a_num in(" & phx3 & ") ")
        tgozl2 = Null2zero2(tdb.Rows(0)(0)) '碱罐氢氧化钠
        tdb = GF_CreateDataSource(G_cnnstr, "select sum(tb_jg2_zl) from tb_jg2 where tb_jg2_rq between '" & sj31 & "' and  '" & sj32 & "' ")
        tgozl3 = Null2zero2(tdb.Rows(0)(0)) 'CIP碱罐氢氧化钠
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim tdb As DataTable = GF_CreateDataSource(G_cnnstr, "select sum(tb_tg_zl) from tb_tg where tb_tg_rq between '" & sj31 & "' and  '" & sj32 & "' ")
        'tgozl1 = Null2zero2(tdb.Rows(0)(0)) '糖罐葡萄糖重量
        'tdb = GF_CreateDataSource(G_cnnstr, "select sum(tb_jg_zl) from tb_jg where tb_jg_rq between '" & sj31 & "' and  '" & sj32 & "' ")
        'tgozl2 = Null2zero2(tdb.Rows(0)(0)) '碱罐氢氧化钠
        'tdb = GF_CreateDataSource(G_cnnstr, "select sum(tb_jg2_zl) from tb_jg2 where tb_jg2_rq between '" & sj31 & "' and  '" & sj32 & "' ")
        'tgozl3 = Null2zero2(tdb.Rows(0)(0)) 'CIP碱罐氢氧化钠
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql As String = "" : Dim dt1 As New Data.DataTable, nn As DataRow
        '''''''''''''''''''''''''''''''''得到小罐
        sql = "select SUM(tb_b970t_c17u) AS '2.05.001'," '发酵原料的葡萄糖
        sql &= "SUM(tb_b970t_s633k)AS '2.05.002',SUM(tb_b970t_b971t)AS '2.05.003'," & fssz("2.05.005") & " ," & fssz("2.05.008") & " ,SUM(tb_b970t_a955t)AS '2.05.009' , " '发酵原料的酵母粉'消泡剂'葵花籽油、土豆'氢氧化钠
        ''''附属增加油剂原料列，好以后计算‘
        sql &= fsszyj()
        If id1 = "" Then
            id1 = 0
        End If
        sql &= "  from tb_b970t where tb_b970t_ID in(" & id1 & ")"

        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''得到中罐
        sql = "select SUM(tb_b959t_z898r) AS '2.05.001'," '发酵原料的葡萄糖
        sql &= "SUM(tb_b959t_k334c)AS '2.05.002',SUM(tb_b959t_g176y)AS '2.05.003'," & fssz("2.05.005") & " ," & fssz("2.05.008") & " ,SUM(tb_b959t_a948s)AS '2.05.009' , " '发酵原料的酵母粉'消泡剂'葵花籽油、土豆'氢氧化钠
        ''''附属增加列，好以后计算‘
        ''''附属增加油剂原料列，好以后计算‘
        sql &= fsszyj()
        If id2 = "" Then
            id2 = 0
        End If
        sql &= " from tb_b959t where tb_b959t_ID in(" & id2 & ")"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)
        nn = dt1.Rows(0) : dt.ImportRow(nn)
        '''''''''''''''''''''''''''''''''得到大罐
        sql = "select SUM(tb_i234a_s612k) AS '2.05.001'," '发酵原料的葡萄糖
        sql &= "SUM(tb_i234a_l170d)AS '2.05.002',SUM(tb_i234a_s621k)AS '2.05.003',SUM(tb_i234a_f137x)AS '2.05.005' ," & fssz("2.05.008") & " ,SUM(tb_i234a_a929s)AS '2.05.009' , " '发酵原料的酵母粉'消泡剂'葵花籽油、土豆'氢氧化钠
        ''''附属增加列，好以后计算‘
        ''''附属增加油剂原料列，好以后计算‘
        sql &= fsszyj()
        If id3 = "" Then
            id3 = 0
        End If
        sql &= " from tb_i234a where tb_i234a_ID in(" & id3 & ")"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)
        nn = dt1.Rows(0) : dt.ImportRow(nn)
        '''''''''''''''''''''''''''''''''''''''''''''''''''得到精炼
        sql = "select " & fssz("2.05.001") & " , " & fssz("2.05.002") & " ," & fssz("2.05.003") & " ," & fssz("2.05.005") & " ," & fssz("2.05.008") & "  ,SUM(tb_k306c_z903r)AS '2.05.009',"
        ' '油剂原料的VE油、柠檬酸、活性白土、正己烷、二氧化硅
        sql &= "" & fssz("2.06.001") & ",SUM(tb_k306c_m398e)AS '2.06.002',SUM(tb_k306c_r574j)AS '2.06.003' ," & fssz("2.06.004") & " ,SUM(tb_k306c_d39v)AS '2.06.005' , "
        ''油剂原料的VC棕榈酸脂、活性炭、正丁烷、葵花籽油、二氧化硅、二氧化硅(干胶)
        sql &= "" & fssz("2.06.006") & ",SUM(tb_k306c_j299c)AS '2.06.007'," & fssz("2.06.008") & " ," & fssz("2.06.009") & " ,SUM(tb_k306c_d39v)AS '2.06.010' "
        sql &= " from vw_k306c where tb_k306c_ID in(" & id4 & ")"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)
        jlnoh = Null2zero(dt1.Rows(0)(5)) ''''得到精炼的氢氧化钠，为单独统计做准备
        nn = dt1.Rows(0) : dt.ImportRow(nn)
        '''''''''''''''''''''''''''''''''''''''''''''''''''得到成品油
        sql = "select " & fsszfj() '发酵原料
        ' '油剂原料的VE油、柠檬酸、活性白土、正己烷、二氧化硅
        sql &= ",SUM(tb_h195z_c998u)AS '2.06.001'," & fssz("2.06.002") & "," & fssz("2.06.003") & " ," & fssz("2.06.004") & " ," & fssz("2.06.005") & " , "
        ''油剂原料的VC棕榈酸脂、活性炭、正丁烷、葵花籽油、二氧化硅、二氧化硅(干胶)、卵磷脂、油剂铝箔袋、1kg粉剂铝箔袋
        sql &= "SUM(tb_h195z_b989t)AS '2.06.006'," & fssz("2.06.007") & "," & fssz("2.06.008") & " ,(SUM(tb_h195z_p495h)+SUM(tb_h195z_tpyy))AS '2.06.009' , " & fssz("2.06.010") & ", SUM(tb_h195z_llzzl)AS '2.06.011', SUM(tb_h195z_ybd5kgzl)AS '3.08.001', SUM(tb_h195z_ypybdzl)AS '3.08.003'"
        sql &= " from vw_h195z where tb_h195z_ID in(" & id5 & ")"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)
        nn = dt1.Rows(0) : dt.ImportRow(nn)
        ''''''''''''''''''''''建立架构
        Dim dbTol As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select top 1 *  from tb_zfjyjylbb  ")
        dbTol.Rows.Clear() : dbTol.Columns.RemoveAt(0) '得到报表的架构
        Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, "select *  from tb_yllb  ") '得到原料类别表，为根据代码查找类别和名称做准备
        ''''''''''''''''''''''''''''''
        For i As Integer = 0 To dt.Columns.Count - 1
            Dim aaRow As DataRow : aaRow = dbTol.NewRow()
            aaRow(0) = tjq : aaRow(1) = phq : aaRow(2) = phz
            Dim dm As String = dt.Columns(i).Caption '代码
            aaRow(3) = GF_cnwithen(dttemp, "tb_yllb_dm='" & dm & "'", 1) : aaRow(4) = dm
            Dim hj As Double = 0
            For j As Integer = 0 To dt.Rows.Count - 1
                '''''''''''''''''''''''''求和
                hj = FormatNumber((hj + DeepCode.DeepDoStr.Null2zero(dt.Rows(j)(i))), 2)
            Next
            aaRow(5) = GF_cnwithen(dttemp, "tb_yllb_dm='" & dm & "'", 3)
            aaRow(6) = hj : hj = 0
            aaRow(7) = G_dlrgh : aaRow(8) = id1 : aaRow(9) = id2 : aaRow(10) = id3 : aaRow(11) = id4 : aaRow(12) = id5 : aaRow(13) = id6 : aaRow(14) = id7 : aaRow(15) = id8
            dbTol.Rows.Add(aaRow)
        Next
        '下面加上糖罐葡萄糖重量、碱罐氢氧化钠、CIP碱罐氢氧化钠
        dbTol.Rows(0)(6) = dbTol.Rows(0)(6) + tgozl1 : dbTol.Rows(5)(6) = dbTol.Rows(5)(6) + tgozl2 + tgozl3
        getFJSCZBdatatable = dbTol
    End Function
    Private Sub frfxyjyl2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        If ccrsdb2(Me.ListView1, "tb_zfjyjylbb") = True Then
            Call GS_sd("tb_b970t", Me.ListView1.Items(0).SubItems(8).Text, G_dlrgh) '锁定小罐
            Call GS_sd("tb_b959t", Me.ListView1.Items(0).SubItems(9).Text, G_dlrgh) '锁定中罐
            Call GS_sd("tb_i234a", Me.ListView1.Items(0).SubItems(10).Text, G_dlrgh) '锁定大罐
            Call GS_sd("tb_k306c", Me.ListView1.Items(0).SubItems(11).Text, G_dlrgh) ''锁定精炼
            Call GS_sd("tb_h195z", Me.ListView1.Items(0).SubItems(12).Text, G_dlrgh) '锁定成品油
            Call GS_sd("tb_tg", Me.ListView1.Items(0).SubItems(13).Text, G_dlrgh) '锁定糖罐
            Call GS_sd("tb_jg", Me.ListView1.Items(0).SubItems(14).Text, G_dlrgh) '锁定碱罐
            Call GS_sd("tb_jg2", Me.ListView1.Items(0).SubItems(15).Text, G_dlrgh) '锁定cip碱罐
            MsgBox("完成报表数据锁定")
            Button2.Enabled = False
        End If
    End Sub
    Private Function fssz(ByVal str As String) As String
        fssz = "0 AS '" & str & "'"
    End Function
    Private Function fsszfj() As String '发酵原料
        '葡萄糖/酵母粉/消泡剂/葵花籽油/土豆/氢氧化钠
        fsszfj = "" & fssz("2.05.001") & " , " & fssz("2.05.002") & " ," & fssz("2.05.003") & " ," & fssz("2.05.005") & " ," & fssz("2.05.008") & "  ," & fssz("2.05.009") & ""
    End Function
    Private Function fsszyj() As String '油剂原料
        '油剂原料的VE油、柠檬酸、活性白土、正己烷、二氧化硅
        fsszyj = "" & fssz("2.06.001") & " , " & fssz("2.06.002") & " ," & fssz("2.06.003") & " ," & fssz("2.06.004") & " ," & fssz("2.06.005") & " ,"
        '油剂原料的VC棕榈酸脂、活性炭、正丁烷、葵花籽油、二氧化硅、二氧化硅(干胶)、卵磷脂、油剂铝箔袋、1kg粉剂铝箔袋
        fsszyj &= "" & fssz("2.06.006") & " , " & fssz("2.06.007") & " ," & fssz("2.06.008") & " ," & fssz("2.06.009") & " ," & fssz("2.06.010") & "," & fssz("2.06.011") & " ," & fssz("3.08.001") & "," & fssz("3.08.003") & ""

    End Function

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        'GS_toexcel(ListView1, Me.Text, Me)
        gjdcexcel()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GS_showmx("tb_b970t", xgid)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GS_showmx("tb_b959t", zgid)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GS_showmx("tb_i234a", dgid)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        GS_showmx("tb_k306c", myid)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        GS_showmx("tb_h195z", cpyid)
    End Sub
    '糖罐明细
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        GS_showmx("tb_tg", tgid)
    End Sub
    '碱罐明细
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        GS_showmx("tb_jg", jgid)
    End Sub
    'strtb2代表报表表，代表ID序列
    Public Function ccrsdb2(ByVal list1 As ListView, ByVal strtb2 As String) As Boolean
        ccrsdb2 = False
        'Try
        Dim n As Integer = list1.Columns.Count
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()

        For i As Integer = 0 To ListView1.Items.Count - 1
            Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            For j As Integer = 0 To n - 1
                'MsgBox(list1.Items(i).SubItems(j).Text)
                ''MsgBox(j)
                RS(j + 1).value = list1.Items(i).SubItems(j).Text
            Next
            'RS(10).value = G_dlrgh
            RS.update()
            RS.close() : RS = Nothing
        Next
        cnn.close() : cnn = Nothing
        ccrsdb2 = True
        'Catch ex As Exception
        '    MsgBox("数据储存出错") : ccrsdb2 = False : Exit Function
        'End Try
    End Function
    '去掉二氧化硅'氢氧化钠单独统计
    Private Sub qdeyhg()
        Dim xx1, xx2 As New ListViewItem
        Dim scsy As String = ""
        With ListView1
            For i As Integer = 0 To .Items.Count - 1
                Dim lr As String = .Items(i).SubItems(5).Text
                If lr = "二氧化硅" Then
                    scsy &= i & ","
                End If
                If InStr(lr, "氢氧化钠") > 0 Then
                    xx1 = .Items(i).Clone '得到合计氢氧化钠行
                    xx2 = .Items(i).Clone '得到合计氢氧化钠行
                    scsy &= i & ","
                End If
            Next
            scsy = GF_removedh(scsy)
            '''''''''''''''''''''''''''''''
            Dim kk() As String = scsy.Split(",")
            Dim jj As Integer = UBound(kk)
            Dim nn(jj) As Integer
            For i As Integer = 0 To jj
                nn(i) = kk(i)
            Next
            Array.Sort(nn)
            For i As Integer = 0 To jj
                Dim ls As Integer = nn(i) - i
                .Items.RemoveAt(ls)
            Next
            '氢氧化钠单独统计
            Dim elseqyhn As Double = xx1.SubItems(6).Text - jlnoh
            xx1.SubItems(5).Text = "发酵氢氧化钠"
            xx1.SubItems(6).Text = elseqyhn
            xx2.SubItems(5).Text = "精炼氢氧化钠"
            xx2.SubItems(6).Text = jlnoh
            .Items.Add(xx1)
            .Items.Add(xx2)
        End With

    End Sub



End Class