Public Class frnhzb
    Private dbys1 As DataTable '为导出做准备
    Private Sub frnhzb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '显示上月的月份
    End Sub
    '确定
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sj As Date = nian1.Text & "-" & yue1.Text & "-26" '开始时间
        Dim sjStr As String = GF_Time2Week(sj) '时间周期字符串
        Dim zqsj() As String = Split(sjStr, ",")
        Dim db3 As DataTable = New DataTable
        db3.Columns.Add("时间起", Type.GetType("System.String")) '0
        db3.Columns.Add("时间止", Type.GetType("System.String"))
        db3.Columns.Add("总量水（吨）", GetType(Double)) '2
        db3.Columns.Add("总量电(Kw.h)", GetType(Double))
        db3.Columns.Add("总量蒸汽（吨）", GetType(Double))
        db3.Columns.Add("总量柴油（L）", GetType(Double)) '5
        db3.Columns.Add("总量天然气（L）", GetType(Double)) '6
        db3.Columns.Add("发酵水（吨）", GetType(Double))
        db3.Columns.Add("发酵电(Kw.h)", GetType(Double))
        db3.Columns.Add("发酵蒸汽（吨）", GetType(Double)) '9
        db3.Columns.Add("油剂水（吨）", GetType(Double))
        db3.Columns.Add("油剂电(Kw.h)", GetType(Double))
        db3.Columns.Add("油剂蒸汽（吨）", GetType(Double))
        db3.Columns.Add("粉剂I水（吨）", GetType(Double)) '13
        db3.Columns.Add("粉剂I电(Kw.h)", GetType(Double))
        db3.Columns.Add("粉剂I蒸汽（吨）", GetType(Double))
        db3.Columns.Add("粉剂II水（吨）", GetType(Double))
        db3.Columns.Add("粉剂II电(Kw.h)", GetType(Double))
        db3.Columns.Add("粉剂II蒸汽（吨）", GetType(Double)) '18
        db3.Columns.Add("设备动力电(Kw.h)", GetType(Double))
        db3.Columns.Add("技术(Kw.h)", GetType(Double))
        db3.Columns.Add("运行(Kw.h)", GetType(Double))
        db3.Columns.Add("QC(Kw.h)", GetType(Double))
        db3.Columns.Add("锅炉房水(吨)", GetType(Double)) '23
        db3.Columns.Add("锅炉房电(Kw.h)", GetType(Double))
        db3.Columns.Add("锅炉房柴油(L)", GetType(Double))

        Dim aaRow As DataRow
        For i As Integer = 0 To zqsj.Length - 1 Step 2
            aaRow = db3.NewRow()
            aaRow(0) = zqsj(i)
            aaRow(1) = zqsj(i + 1)
            Dim cpdb As DataTable
            cpdb = get2(zqsj(i), zqsj(i + 1), "水")
            aaRow(2) = FormatNumber(cpdb.Rows(0)(0), 2)
            aaRow(7) = cpdb.Rows(0)(1)
            aaRow(10) = cpdb.Rows(0)(2)
            aaRow(13) = cpdb.Rows(0)(3)
            aaRow(16) = cpdb.Rows(0)(4)
            aaRow(23) = cpdb.Rows(0)(5)
            '
            cpdb = get2(zqsj(i), zqsj(i + 1), "电")
            aaRow(3) = cpdb.Rows(0)(0)
            aaRow(8) = cpdb.Rows(0)(1)
            aaRow(11) = cpdb.Rows(0)(2)
            aaRow(14) = cpdb.Rows(0)(3)
            aaRow(17) = cpdb.Rows(0)(4)
            aaRow(19) = cpdb.Rows(0)(5)
            aaRow(20) = cpdb.Rows(0)(6)
            aaRow(21) = cpdb.Rows(0)(7)
            aaRow(22) = cpdb.Rows(0)(8)
            aaRow(24) = cpdb.Rows(0)(9)
            '
            cpdb = get2(zqsj(i), zqsj(i + 1), "蒸汽")
            aaRow(4) = cpdb.Rows(0)(0)
            aaRow(9) = cpdb.Rows(0)(1)
            aaRow(12) = cpdb.Rows(0)(2)
            aaRow(15) = cpdb.Rows(0)(3)
            aaRow(18) = cpdb.Rows(0)(4)
            aaRow(5) = cpdb.Rows(0)(5)
            aaRow(25) = cpdb.Rows(0)(6)
            '
            cpdb = get2(zqsj(i), zqsj(i + 1), "天然气")
            aaRow(6) = cpdb.Rows(0)(0)


            db3.Rows.Add(aaRow)
        Next

        Call GS_useviewbydb2(ListView1, db3, -1, 90)
        dbys1 = db3 '为导出做准备
        '设置颜色
        With ListView1
            For i As Integer = 0 To .Items.Count - 1
                .Items(i).UseItemStyleForSubItems = False
                .Items(i).SubItems(0).BackColor = Color.LightSkyBlue '起时间
                .Items(i).SubItems(1).BackColor = .Items(i).SubItems(0).BackColor '止时间
                '以下为总量
                .Items(i).SubItems(2).BackColor = Color.LightPink
                .Items(i).SubItems(3).BackColor = .Items(i).SubItems(2).BackColor : .Items(i).SubItems(4).BackColor = .Items(i).SubItems(2).BackColor : .Items(i).SubItems(5).BackColor = .Items(i).SubItems(2).BackColor : .Items(i).SubItems(6).BackColor = .Items(i).SubItems(2).BackColor
                '以下为发酵
                .Items(i).SubItems(7).BackColor = Color.LightGreen
                .Items(i).SubItems(8).BackColor = .Items(i).SubItems(7).BackColor : .Items(i).SubItems(9).BackColor = .Items(i).SubItems(7).BackColor
                '以下为油剂
                .Items(i).SubItems(10).BackColor = Color.LightBlue
                .Items(i).SubItems(11).BackColor = .Items(i).SubItems(10).BackColor : .Items(i).SubItems(12).BackColor = .Items(i).SubItems(10).BackColor
                '以下为粉剂I
                .Items(i).SubItems(13).BackColor = .Items(i).SubItems(7).BackColor
                .Items(i).SubItems(14).BackColor = .Items(i).SubItems(13).BackColor : .Items(i).SubItems(15).BackColor = .Items(i).SubItems(13).BackColor
                '以下为粉剂II
                .Items(i).SubItems(16).BackColor = .Items(i).SubItems(10).BackColor
                .Items(i).SubItems(17).BackColor = .Items(i).SubItems(16).BackColor : .Items(i).SubItems(18).BackColor = .Items(i).SubItems(16).BackColor
                '以下为其他部门电
                .Items(i).SubItems(19).BackColor = .Items(i).SubItems(7).BackColor
                .Items(i).SubItems(20).BackColor = .Items(i).SubItems(19).BackColor : .Items(i).SubItems(21).BackColor = .Items(i).SubItems(19).BackColor : .Items(i).SubItems(22).BackColor = .Items(i).SubItems(19).BackColor
                '以下为锅炉房
                .Items(i).SubItems(23).BackColor = .Items(i).SubItems(10).BackColor
                .Items(i).SubItems(24).BackColor = .Items(i).SubItems(23).BackColor : .Items(i).SubItems(25).BackColor = .Items(i).SubItems(23).BackColor
            Next
        End With
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大

    End Sub

    Private Function getsui1(ByVal str1 As String, ByVal str2 As String) As DataTable
        str1 = str1





        '总水，发酵水，油剂水，粉剂一水，粉剂二水,锅炉房水
        Dim zs As String = " tb_zls_zlszb "
        Dim s1 As String = " tb_zls_hg + tb_zls_fx  + tb_zls_pl + tb_zls_tca + tb_zls_tcb "
        Dim s2 As String = " tb_zls_tc "
        Dim s3 As String = " tb_zls_lfj "
        Dim s4 As String = " tb_zls_js + tb_zls_cs + tb_zls_jx "
        Dim s5 As String = "tb_zls_glf"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5
        Dim sql As String = "select top 1 " & szfc & " from tb_zls where tb_zls_rq< '" & str1 & "' order by  tb_zls_rq desc "
        ''''
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zls_hb from tb_zls where tb_zls_rq< '" & str2 & "' order by tb_zls_rq desc ")
        End If
        ''''
        getsui1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getdian1(ByVal str1 As String, ByVal str2 As String) As DataTable

        '总电，发酵电,油剂电,粉剂一电,粉剂二电，设备动力，技术，运行，qc,锅炉房电
        Dim zs As String = "tb_dian_zjlg"
        's1 = "tb_dian_zjlg + tb_dian_qcdl - tb_dian_wszdlyzm - tb_dian_zzm + tb_dian_sbdlzm - tb_dian_zczm - tb_dian_yxsys - tb_dian_zcdlzb - tb_dian_wlzm - tb_dian_pka - tb_dian_pkb - tb_dian_pkc - tb_dian_xfjdl"
        Dim s1 As String = "tb_dian_fxdlzb-tb_dian_sbdlwxj-tb_dian_yxsys+tb_dian_qcdl+tb_dian_zcyfx-tb_dian_zczm-tb_dian_pka-tb_dian_pkb-tb_dian_pkc-tb_dian_wlzm"
        Dim s2 As String = "tb_dian_tcdl + tb_dian_jldl + tb_dian_zczm * 0.5"
        Dim s3 As String = "tb_dian_zcdlzb - tb_dian_yfdl - tb_dian_tcdl - tb_dian_qcdl - tb_dian_jldl + tb_dian_zczm * 0.5"
        Dim s4 As String = "tb_dian_xfjdl+tb_dian_5t" '粉剂二电
        Dim s5 As String = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm + tb_dian_sbdlzm - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl-tb_dian_glf-tb_dian_xfjdl-tb_dian_5t " '设备动力
        Dim s6 As String = "tb_dian_yxsys + tb_dian_yfdl" '技术
        Dim s7 As String = "tb_dian_wszdlyzm + tb_dian_zzm - tb_dian_sbdlzm + tb_dian_wlzm" '运行
        Dim s8 As String = "tb_dian_pka + tb_dian_pkb + tb_dian_pkc" 'qc
        Dim s9 As String = "tb_dian_glf"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5 & "," & s6 & "," & s7 & "," & s8 & "," & s9
        Dim sql As String = "select top 1 " & szfc & " from tb_dian where tb_dian_rq< '" & str1 & "' order by tb_dian_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_dian_hb from tb_dian where tb_dian_rq< '" & str2 & "' order by tb_dian_rq desc ")
        End If
        getdian1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getzqb1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs As String = "tb_zqb_zqzb+tb_zqb_zqzb2+tb_zqb_zqzb3/1000" '蒸汽总表1+蒸汽总表2+蒸汽总表3
        Dim s1 As String = "tb_zqb_zxg + tb_zqb_jsdg + tb_zqb_xtg + tb_zqb_hg + tb_zqb_xsdg + tb_zqb_plj + tb_zqb_qc"
        Dim s2 As String = "tb_zqb_tca + tb_zqb_tcb + tb_zqb_tcc + tb_zqb_jl"
        Dim s3 As String = "tb_zqb_fj"
        Dim s4 As String = "tb_zqb_zqzb3 /1000" '读蒸汽总表3的数据,李锂于2010.4.28日14时修改

        Dim szfc As String = zs & ",(" & s1 & ")/1000,(" & s2 & ")/1000,(" & s3 & ")/1000," & s4 & ",'0','0'"
        Dim sql As String = "select top 1" & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' order by tb_zqb_rq desc ")
        End If
        getzqb1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getCaiYou(ByVal str1 As String, ByVal str2 As String) As Integer ''柴油总表,时间段内数据之和\
        'MsgBox(str1 & "^^^^^^" & str2)
        Dim sql As String = "select tb_zqb_cyzb+tb_zqb_glcy from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%空压机柴油用量%' or tb_zqb_hb not Like '%锅炉柴油用量%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'柴油总表')=0 and tb_zqb_hb<>'柴油总表'" )
        '空压机柴油用量 + 锅炉柴油用量
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + Convert.ToInt32(cy.Rows(j)(0).ToString())
        Next
        getCaiYou = zcy
    End Function
    Private Function getCaiYou2(ByVal str1 As String, ByVal str2 As String) As Integer ''柴油总表,时间段内数据之和
        Dim sql As String = "select tb_zqb_glcy from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%空压机柴油用量%' or tb_zqb_hb not Like '%锅炉柴油用量%'or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'柴油总表')=0 and tb_zqb_hb<>'柴油总表'" )
        '空压机柴油用量 + 锅炉柴油用量
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + Convert.ToInt32(cy.Rows(j)(0).ToString())
        Next
        getCaiYou2 = zcy
    End Function

    Private Function getZQ(ByVal str1 As String, ByVal str2 As String) As DataTable '天然气总表
        '总天然气
        Dim zs As String = "tb_zqb_trqzb+tb_zqb_trqxg "
        Dim szfc As String = zs
        Dim sql As String = "select top 1" & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' order by tb_zqb_rq desc ")
        End If
        'Dim sql As String = "select tb_zqb_trqzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "') and (tb_zqb_hb not Like '%天然气总表%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'柴油总表')=0 and tb_zqb_hb<>'柴油总表'" )
        getZQ = GF_CreateDataSource(G_cnnstr, sql)
    End Function

    '用于“换表”功能的实现
    '对sql语句进行处理，将换表字段变为数字0
    Private Function clsql(ByVal sql As String, ByVal sql2 As String) As String 'sql为待处理sql字符串；sql2为查询换表记录sql字符串
        Dim hbdb As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        If hbdb.Rows(0)(0).GetType Is Type.GetType("System.String") Then
            Dim ctableName As String = GF_zhzfccx(hbdb.Rows(0)(0).ToString()) '查询止时间那条记录的“换表”字段数据
            hbdb = GF_CreateDataSource(G_cnnstr, "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_mx in(" & ctableName & ")") '“换表”字段数据对应英文字段名称DATATABLE
            For i As Integer = 0 To hbdb.Rows.Count - 1
                If hbdb.Rows(i)(0).ToString() = "tb_zls_tc" Then
                    hbdb.Rows(i)(0) = "tb_zls_tc "
                End If
                sql = Replace(sql, hbdb.Rows(i)(0).ToString(), "0") 'hbdb.Rows(i)(0)是“换表”字段数据对应英文字段名称
            Next
        End If
        clsql = sql
    End Function

    Private Function get2(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As DataTable
        Dim k1, k2 As New DataTable
        str1 = str1 & " 00:00:00"
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
            Try
                row(i) = FormatNumber((k2.Rows(0)(i)) - Null2zero(k1.Rows(0)(i)), 2)
                If str3 = "蒸汽" And i = 5 Then
                    row(5) = getCaiYou(str1, str2) '柴油总表,时间段内数据之和
                End If
                If str3 = "蒸汽" And i = 6 Then
                    row(6) = getCaiYou2(str1, str2)
                End If
            Catch ex As Exception
            End Try
        Next
        kk.Rows.Add(row)
        get2 = kk
    End Function
 
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        'GS_toexcel(ListView1, nian1.Text & "年" & yue1.Text & "月统计", Me)
        GS_dbtoexcel(dbys1, nian1.Text & "年" & yue1.Text & "月统计", Me)
    End Sub


    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class