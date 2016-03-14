Public Class fryjzbYS2
    Dim myid, cpyid, fgid As String
    Private Sub fryjzbYS2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        weizhi()
        Dim sql As String = "select tb_yxjh_tjq from tb_yxjh  where  tb_yxjh_y846q='成品油' or tb_yxjh_y846q='毛油' group by tb_yxjh_tjq"
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(nian1, dt, 0, "")
    End Sub
    Private Sub weizhi()
        ListView1.Width = Me.Width - 20
        ListView1.Height = Me.Height - ListView1.Top - 20
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Try
        Dim tjq As String = nian1.Text
        Dim dts As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select  *  from tb_zyjbb  where  tb_zyjbb_tjq=" & tjq)
        If dts.Rows.Count > 0 Then
            dts.Columns.RemoveAt(0) '得到报表的架构
            myid = dts.Rows(0)(15)
            cpyid = dts.Rows(0)(16)

            GS_DataGridViewbyDb(listview1, dts, True, True)
            Button2.Enabled = False

            Exit Sub
        Else
            Button2.Enabled = True
        End If
        ''''''''''''''''''''''如果该期报表已有那么直接就显示
        Dim sql As String = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='毛油'  and tb_yxjh_tjq=" & tjq
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("毛油起止批号未设置") : Exit Sub
        End If
        Dim qh341 As String = dt.Rows(0)(0) : Dim qh342 As String = dt.Rows(0)(1) '得毛油的起止批号
        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='成品油'   and  tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("成品油起止批号未设置") : Exit Sub
        End If
        Dim qh11 As String = dt.Rows(0)(0) : Dim qh12 As String = dt.Rows(0)(1) '得到成品油的起止批号
        sql = "select tb_yxjh_t685m,tb_yxjh_sjzph  from tb_yxjh  where   tb_yxjh_y846q='放罐'   and  tb_yxjh_tjq=" & tjq
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("放罐起止批号未设置") : Exit Sub
        End If
        Dim qhfgq As String = dt.Rows(0)(0) : Dim qhfgz As String = dt.Rows(0)(1) '得到放罐的起止批号
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tt341, tt342, tt11, tt12 As String '得到毛油、成品油的时间区间
        tt341 = frfjsczbYS2.sfyph("tb_x825p", qh341) : tt342 = frfjsczbYS2.sfyph("tb_x825p", qh342)
        tt11 = frfjsczbYS2.sfyph("tb_h195z", qh11) : tt12 = frfjsczbYS2.sfyph("tb_h195z", qh12)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sql = "select tb_x825p_jgrq2  from tb_x825p  where   tb_x825p_num3='" & qhfgq & "'"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("放罐起批号设置不对") : Exit Sub
        End If
        Dim ttfgq As String = dt.Rows(0)(0)
        sql = "select tb_x825p_jgrq2  from tb_x825p  where   tb_x825p_num3='" & qhfgz & "'"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            MsgBox("放罐止批号设置不对") : Exit Sub
        End If
        Dim ttfgz As String = dt.Rows(0)(0)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If tt341 = "" Or tt341 = "" Or tt341 = "" Or tt341 = "" Or ttfgq = "" Or ttfgz = "" Then
            MsgBox("毛油或成品油或放罐起止批号设置不对") : Exit Sub
        End If                        
        dt = getFJSCZBdatatable(tjq, qh11 & "," & qh341, qh12 & "," & qh342, tt11, tt12, tt341, tt342, ttfgq, ttfgz)
        If dt.Rows.Count <> 0 Then
            myid = dt.Rows(0)(15)
            cpyid = dt.Rows(0)(16)
            fgid = dt.Rows(0)(18)
        End If
        GS_DataGridViewbyDb(listview1, dt, True, True)
        'Call GS_useviewbydb2(Me.ListView1, dt, -1, 100)
        'Catch ex As Exception
        '    MsgBox("尚未生产到计划批次！")
        'End Try

    End Sub
    Public Function getFJSCZBdatatable(ByVal tjq As String, ByVal phq As String, ByVal phz As String, ByVal sj1 As String, ByVal sj2 As String, ByVal sj3 As String, ByVal sj4 As String, ByVal sj5 As String, ByVal sj6 As String) As Data.DataTable
        Dim phxl1 As String = frfjsczbYS2.ddphzh("select tb_h195z_num from vw_h195z where  tb_h195z_jgrq between '" & sj1 & "' and  '" & sj2 & "' ") '得到成品油的批号范围
        Dim phxl34 As String = frfjsczbYS2.ddphzh("select tb_x825p_num from tb_x825p where  tb_x825p_jgrq between '" & sj3 & "' and  '" & sj4 & "' ") '得到毛油的批号范围
        Dim phxlfg As String = frfjsczbYS2.ddphzh("select tb_x825p_num3 from tb_x825p where  tb_x825p_jgrq2 between '" & sj5 & "' and  '" & sj6 & "' ") '得到放罐的批号范围
        phxl1 = GF_zhzfccx(phxl1) : phxl34 = GF_zhzfccx(phxl34) : phxlfg = GF_zhzfccx(phxlfg)
        Dim phdg As String = frfjsczbYS2.ddphzh("select tb_x825p_num2 from tb_x825p where  tb_x825p_num  in (" & phxl34 & ")") '根据毛油的批号范围得到大罐的批号范围
        phdg = GF_zhzfccx(phdg)
        '        得到批号区间范围()
        '''''''''''''''''''''''''''''''''''''''''''''''''
        Dim zongshu, xiaoshu As Double
        Dim sql As String = "select top 1 *  from tb_zyjbb  "
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dt.Rows.Clear() : dt.Columns.RemoveAt(0) '得到报表的架构

        Dim dataRow As Data.DataRow
        Dim index As Integer = 0
        dataRow = dt.NewRow()
        dataRow(0) = tjq : dataRow(1) = phq : dataRow(2) = phz

        sql = "select count(*) from tb_x825p where tb_x825p_num3 in (" & phxlfg & ") "
        Dim dt3 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dataRow(3) = Null2zero2(dt3.Rows(0)(0))
        sql = "select count(*) from tb_q546i where tb_q546i_t651l='放罐' and tb_q546i_a941s='染菌' and tb_q546i_qcrq between '" & sj5 & "' and  '" & sj6 & "' "
        dt3 = GF_CreateDataSource(G_cnnstr, sql)
        dataRow(4) = Null2zero2(dt3.Rows(0)(0))
        '''''''''''''''''''''''''''''''''''''''''''
        sql = "select  avg(tb_x825p_k317c) from tb_x825p where tb_x825p_qaspjg<>'报废' and tb_x825p_num3 in (" & phxlfg & ") "
        dt3 = GF_CreateDataSource(G_cnnstr, sql)
        dataRow(5) = Format(Null2zero2(dt3.Rows(0)(0)), "0.00")
        '''''''''''''''''''''''''''''''''

        sql = "select count(*), avg(tb_x825p_k317c),sum(tb_x825p_s640k),avg(tb_x825p_sn) from tb_x825p where tb_x825p_qaspjg<>'报废' and tb_x825p_num in (" & phxl34 & ") "
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        'zongshu = Null2zero2(dt2.Rows(0)(0))
        zongshu = dataRow(3)
        Dim bbfs As Integer = dt2.Rows(0)(0) '毛油的非报废数
        'dataRow(5) = Format(Null2zero2(dt2.Rows(0)(1)), "0.00")
        dataRow(7) = Null2zero2(dt2.Rows(0)(2))
        dataRow(9) = Double.Parse(Format(Null2zero2(dt2.Rows(0)(3)), "0.00"))

        sql = "select count(*) from tb_x825p where tb_x825p_qaspjg='报废' and tb_x825p_num in (" & phxl34 & ") "
        dt2 = GF_CreateDataSource(G_cnnstr, sql)

        'xiaoshu = Null2zero2(dt2.Rows(0)(0))
        xiaoshu = dataRow(4)

        sql = "select sum(tb_h195z_n426f),sum(tb_h195z_m408e),avg(tb_h195z_u704m),avg(tb_h195z_q554i),sum(tb_h195z_e95w),sum(tb_h195z_tpyy) from vw_h195z where tb_h195z_num in (" & phxl1 & ") and  tb_h195z_num2 not in(select tb_jch_num from tb_jch where tb_jch_yt='整批返工')"
        dt2 = GF_CreateDataSource(G_cnnstr, sql)
        dataRow(10) = Format(Null2zero2(dt2.Rows(0)(0)), "0.00")
        dataRow(11) = Double.Parse(Format(Null2zero2(dt2.Rows(0)(1)), "0.00"))
        dataRow(12) = Format(Null2zero2(dt2.Rows(0)(4)) + Null2zero2(dt2.Rows(0)(5)), "0.00")
        'dataRow(12) = dataRow(10) / (dataRow(9) + dataRow(11))
        'dataRow(13) = Format(Null2zero2(dt2.Rows(0)(2)), "0.00")
        dataRow(13) = Format((dataRow(11) - dataRow(12)) / dataRow(10) * 100, "0.00")
        dataRow(14) = Format(Null2zero2(dt2.Rows(0)(3)), "0.00")
        Dim j1 As Double = Null2zero2(zongshu) + xiaoshu
        Try 'C-rate不良率
            If j1 = 0 Then
                dataRow(6) = 0
            Else
                'dataRow(6) = CInt(dataRow(4)) / CInt((dataRow(3) + dataRow(4)) * 100)
                'dataRow(6) = Format(dataRow(4) / (dataRow(3) + dataRow(4)) * 1000, "0.00")
                'Dim aa As Integer = xiaoshu
                'Dim aa2 As Integer = zongshu
                'Dim i As Double = aa / (aa + aa2)
                'dataRow(6) = Format(i * 100, "0.00")
                '2009/11/29算法改变，陈巍
                dataRow(6) = FormatPercent(dataRow(4) / dataRow(3), 2)
            End If
        Catch ex As Exception
            dataRow(6) = 0
        End Try
        Try
            'dataRow(8) = Format(dataRow(7) / zongshu, "0.00")
            '2009/11/29算法改变，陈巍
            dataRow(8) = FormatNumber(dataRow(7) / bbfs, 2)
            ' dataRow(7) = Format(dataRow(6) / dataRow(2), "0.00%")
        Catch ex As Exception
            dataRow(8) = 0
        End Try

        Dim allid1 As String = frfjsczbYS2.ddphzh("select tb_x825p_ID from tb_x825p where tb_x825p_num in(" & phxl34 & ")") '得到毛油对应的所有ID
        Dim allid2 As String = frfjsczbYS2.ddphzh("select tb_h195z_ID from vw_h195z where tb_h195z_num in(" & phxl1 & ")") '得到成品油对应的所有ID
        Dim allid3 As String = frfjsczbYS2.ddphzh("select tb_q546i_ID from tb_q546i where tb_q546i_num in(" & phdg & ")") '得到大罐QC对应的所有ID
        Dim allid4 As String = frfjsczbYS2.ddphzh("select tb_x825p_ID from tb_x825p where tb_x825p_num3 in(" & phxlfg & ")") '得到放罐对应的所有ID
        dataRow(15) = allid1 : dataRow(16) = allid2 : dataRow(17) = allid3 : dataRow(18) = allid4
        dt.Rows.Add(dataRow)
        Return dt
    End Function

    Private Sub fryjzbYS2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If GF_storelog1("锁定报表") = False Then
            Exit Sub
        End If ' 判断是否有权限

        If GF_getListViewsz(listview1) = 0 Then
            Exit Sub
        End If
        If MsgBox("保存锁定报表将锁定相关的记录，您确定吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If frfjsczbYS2.ccrsdb(Me.ListView1, "tb_zyjbb") = True Then
            Dim n As Integer = GF_GetListIndexByText(ListView1, "对应大罐QCID") '根据中文名返回列索引
            Call GS_sd("tb_q546i", Me.listview1.Rows(0).Cells(15).Value, G_dlrgh) '锁定大罐QCid
            n = GF_GetListIndexByText(ListView1, "对应成品油ID") '根据中文名返回列索引
            Call GS_sd("tb_h195z", Me.listview1.Rows(0).Cells(16).Value, G_dlrgh) '锁定成品油id
            n = GF_GetListIndexByText(listview1, "对应毛油ID") '根据中文名返回列索引
            Dim sz1 As String = Me.listview1.Rows(0).Cells(17).Value
            n = GF_GetListIndexByText(listview1, "对应放罐ID") '根据中文名返回列索引
            sz1 &= "," & Me.listview1.Rows(0).Cells(18).Value
            Call GS_sd("tb_x825p", sz1, G_dlrgh) '锁定毛油id
            MsgBox("完成报表数据锁定")
            Button2.Enabled = False
        End If

    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, Me.Text, Me)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GS_showmx("tb_x825p", myid)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GS_showmx("tb_h195z", cpyid)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GS_showmx("tb_x825p", fgid)
    End Sub
End Class