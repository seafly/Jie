

Public Class cl_theCl
    ''' <summary>
    ''' 获取物料使用情况列表
    ''' </summary>
    ''' <param name="pStrWldm">物料代码</param>
    ''' <param name="pStlph">物料批号</param>
    ''' <returns>返回物料的使用列表</returns>
    ''' <remarks>如果批号为空，那么列出该物料所有批号的列表</remarks>
    Public Shared Function getShowDtWltj(pStrWldm As String, Optional pStlph As String = "", Optional pStarDate As String = "", Optional pEndDate As String = "") As DataTable
        '要显示字段的TB
        Dim dt As DataTable = _D.YanStrToDb(_D.YanDttoStr(GetType(en_Tjzd).YanEnToTb, "name"))

        Dim StrLc As String = _D.YanDttoStr(GetType(en_LcTableName).YanEnToTb, "text", True)
        '获取所有流程中是批号的字段
        Dim sql As String = ""

        '循环流程
        For Each dr As DataRow In GetType(en_LcTableName).YanEnToTb.Rows
            '该表的所有批号字段
            sql = "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao ='" & dr("text") & "' and right(tb_biaozdinf_mx,2)='批号'"
            Dim dtPhZd As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            '根据物料代码找出所有批号
            Dim strWh As String = IIf(pStlph = "", "", " and tb_i259b_num='" & pStlph & "'")
            sql = "select * from tb_i259b where tb_i259b_i231a='" & pStrWldm & "'" & strWh
            Dim dtPh As DataTable = _D.GF_CreateDataSource(sql)
            '根据传来的批号获取该流程的数据集
            Dim strWlDate As String = ""
            If pStarDate <> "" And pEndDate <> "" Then
                strWlDate = "and (" & dr("text") & "_jgrq" & " between '" & pStarDate & "' and '" & pEndDate & "') "
            End If
            sql = "select * from " & dr("text") & "  where 1=1 " & strWlDate & zhzfc(dtPhZd, dtPh, pStrWldm)
            Dim dtWl As DataTable = _D.GF_CreateDataSource(sql)
            '写入统计表

            '循环该流程
            For Each drWl As DataRow In dtWl.Rows
                '循环该记录的每个字段
                For Each drPhzd As DataRow In dtPhZd.Rows
                    Dim arrDr As DataRow() = dtPh.Select("','+tb_i259b_num+',' like '," & drWl(drPhzd("tb_biaozdinf_mc")) & ",'")
                    If arrDr.Length > 0 Then

                        Dim drNewTj As DataRow = dt.NewRow
                        drNewTj(en_Tjzd.物料代码) = arrDr(0)("tb_i259b_i231a")
                        drNewTj(en_Tjzd.物料名称) = arrDr(0)("tb_i259b_c24u")
                        drNewTj(en_Tjzd.操作类型) = "生产"
                        Try
                            drNewTj(en_Tjzd.使用量) = drWl(drPhzd("tb_biaozdinf_mc") & "t")
                        Catch ex As Exception
                            drNewTj(en_Tjzd.使用量) = 0
                        End Try
                        drNewTj(en_Tjzd.操作时间) = drWl(dr("text") & "_jgrq")
                        drNewTj(en_Tjzd.原料批号) = drWl(drPhzd("tb_biaozdinf_mc"))
                        drNewTj(en_Tjzd.操作对象) = drWl(dr("text") & "_num")
                        drNewTj(en_Tjzd.对象名称) = dr("name")
                        dt.Rows.Add(drNewTj)
                    End If
                Next
            Next
        Next

        '合成材料
        Dim strWh2 As String = IIf(pStlph = "", "", " and tb_syjl_wlph='" & pStlph & "'")
        strWh2 = IIf((pStarDate <> "" And pEndDate <> ""), " and tb_syjl_ftime between '" & pStarDate & "' and '" & pEndDate & "'", "")
        For Each drSyjl As DataRow In _D.GF_CreateDataSource("select * from tb_syjl as a left join tb_i259b as b on a.tb_syjl_wlph=b.tb_i259b_num where tb_syjl_wpdm='" & pStrWldm & "' and tb_syjl_xz=0 " & strWh2).Rows
            Select Case drSyjl("tb_syjl_czlx")
                Case "物品合成"
                    sql = "select * from tb_i259b where tb_i259b_ID=" & drSyjl("tb_syjl_czbs")
                    Dim drBs As DataRow = _D.GF_CreateDataSource(sql).Rows(0)
                    Dim drNewTj As DataRow = dt.NewRow
                    drNewTj(en_Tjzd.物料代码) = pStrWldm
                    drNewTj(en_Tjzd.物料名称) = drSyjl("tb_i259b_c24u")
                    drNewTj(en_Tjzd.操作类型) = drSyjl("tb_syjl_czlx")
                    drNewTj(en_Tjzd.使用量) = drSyjl("tb_syjl_zl")
                    drNewTj(en_Tjzd.操作时间) = drSyjl("tb_syjl_ftime")
                    drNewTj(en_Tjzd.原料批号) = drSyjl("tb_syjl_wlph")
                    drNewTj(en_Tjzd.操作对象) = drBs("tb_i259b_i231a")
                    drNewTj(en_Tjzd.对象名称) = drBs("tb_i259b_c24u")
                    dt.Rows.Add(drNewTj)
            End Select
        Next
        Return dt
    End Function

    Private Shared Function zhzfc(ByVal pDtZd As DataTable, pDtPh As DataTable, ByVal str As String) As String
        zhzfc = ""

        For Each dr As DataRow In pDtPh.Rows
            For i As Integer = 0 To pDtZd.Rows.Count - 1
                zhzfc = zhzfc & "CHARINDEX(','+" & pDtZd.Rows(i)(0) & "+',', '," & dr("tb_i259b_num") & ",')>0 or "
            Next
        Next
        If zhzfc = "" Then
            Return ""
        End If
        zhzfc = Microsoft.VisualBasic.Left(zhzfc, Len(zhzfc) - 3)
        zhzfc = " and (" & zhzfc & ")"
    End Function

    Public Shared Function delTjBb(pStrMc As String, pDm As String) As Boolean
        '先删除保存的报表的内容
        Dim sql As String = "delete from tb_bcbb where tb_bcbb_bs = " & _
        "(select tb_xtszNr_ID from tb_xtszNr where tb_xtszNr_mc='" & pStrMc & "' " & _
        "and tb_xtszNr_dm='" & pDm & "' and tb_xtszNr_bs=" & en_xtLb.统计报表 & ");" & vbCrLf
        '再删除报表的名称
        sql &= "delete from tb_xtszNr where tb_xtszNr_mc='" & pStrMc & "' " & _
            "and tb_xtszNr_dm='" & pDm & "' and tb_xtszNr_bs=" & en_xtLb.统计报表 & ";" & vbCrLf
        _D.GS_upztxx(sql)
        Return True
    End Function
    Public Shared Function delTjBb(pId As Integer) As Boolean
        '先删除保存的报表的内容
        Dim sql As String = "delete from tb_bcbb where tb_bcbb_bs = " & pId & vbCrLf
        '再删除报表的名称
        sql &= "delete from tb_xtszNr where tb_xtszNr_ID=" & pId & vbCrLf
        _D.GS_upztxx(sql)
        Return True
    End Function
    ''' <summary>
    ''' 添加QC结果列(源数据表为已有数据的表，将QC的列和结果添加上去)
    ''' </summary>
    ''' <param name="pDt">源数据表</param>
    ''' <param name="pJcbNum">QC来源表</param>
    ''' <param name="pWldm">原料的物料代码</param>
    ''' <param name="isAddva">是否添加检测结果</param>
    Public Shared Sub setQcshowView(ByRef pDt As DataTable, Optional pJcbNum As Integer = -1, Optional pWldm As String = "",
                                    Optional isAddva As Boolean = True, Optional pWpbs As Integer = 0)
        Dim sql As String = ""
        '将QC项目转为DT，每个项目一列
        Select Case pJcbNum
            Case -1
                sql = "select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.物品 & " " & IIf(pWldm = "", "", "and tb_QcXm_wldm='" & pWldm & "'")
            Case -2
                sql = "select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.工艺 & " " & IIf(pWldm = "", "", "and tb_QcXm_wpbs='" & pWpbs & "'")
            Case Else
                sql = "select tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.工序 & _
                    " and tb_QcXm_wldm='" & GetType(en_LcTableName).YanGetEnName(pJcbNum) & "'"
        End Select
        Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource(sql)

        For Each dr As DataRow In tBqcxm.Rows
            pDt.Columns.Add(dr("tb_QcXm_xmmc").trim)
        Next
        If Not isAddva Then
            Return
        End If
        '设置值
        For Each dr As DataRow In pDt.Rows  '将结果作为列添加进去
            sql = "select  * from tb_QcVa where tb_QcVa_Qcbs = " & dr("tb_QcJc_ID")
            Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
            For Each tDr As DataRow In tDt.Rows
                Try
                    dr(tDr("tb_QcVa_xmmc").trim) = tDr("tb_QcVa_xmva").trim
                Catch ex As Exception

                End Try
            Next
        Next
    End Sub

    ''' <summary>
    ''' 将QC项目转为DT，每个项目一列
    ''' </summary>
    ''' <param name="tableName">检测表</param>
    ''' <param name="id">物料标识</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function setQcshowViewForQA(tableName As String, id As Int32) As DataTable
        Dim sql As String = ""
        '将QC项目转为DT，每个项目一列
       
        sql = "select tb_QcJc_ID from tb_QcJc where tb_QcJc_jcb='" & tableName & _
                    "' and tb_QcJc_wlbs=" & id.ToString() & ""

        Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
        If tBqcxm.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim qcbs As Integer = Convert.ToInt32(Convert.ToInt32(tBqcxm.Rows(0)(0).ToString()))
        Dim qcDataTable As DataTable = loadQcVal(qcbs)

        Return qcDataTable
    End Function
    Private Shared Function loadQcVal(qcbs As Integer) As DataTable
        Dim sql As String = "select tb_QcVa_ID,tb_QcVa_xmmc,tb_QcVa_xmva from tb_QcVa where tb_QcVa_Qcbs=" & qcbs.ToString()
        Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
        Return tDt
    End Function
    ''' <summary>
    ''' 获取报表
    ''' </summary>
    Public Shared Function getBb(pType As en_saveBb, Optional pOrderby As String = "") As DataTable
        Dim sql As String = ""
        Select Case pType
            Case en_saveBb.成品粉生产进度2
                If ("select * from sys.tables where name='" & en_saveBb.成品粉生产进度2.YanGetEnText & "' and type = 'u'").YanGetDb.Rows.Count = 0 Then
                    Return Nothing
                End If
                '组成报表所需的数据
                sql = "select * from " & en_saveBb.成品粉生产进度2.YanGetEnText & " " & pOrderby
                Dim dt As DataTable = sql.YanGetDb
                Return dt
        End Select
        Return Nothing
    End Function
    ''' <summary>
    ''' 保存报表
    ''' </summary>
    Public Shared Function saveBb(pType As en_saveBb, Optional pCs As Object = Nothing, Optional pCl As Integer = 0) As Boolean
        Dim sql As String = ""
        Select Case pType
            Case en_saveBb.成品粉生产进度2
                If CInt(_S.YanFormatNum(pCs)) > 0 Then
                    sql = "delete from " & en_saveBb.成品粉生产进度2.YanGetEnText & " where tb_x832p_num=(select tb_x832p_num from tb_x832p where tb_x832p_ID=" & pCs & ")"
                    sql.YanDbExe()
                End If
                Dim strUpWhere As String = ""
                '如果有这个表
                If ("select * from sys.tables where name='" & en_saveBb.成品粉生产进度2.YanGetEnText & "' and type = 'u'").YanGetDb.Rows.Count > 0 Then
                    strUpWhere = " and tb_x832p_num not in (select tb_x832p_num from " & en_saveBb.成品粉生产进度2.YanGetEnText & ")"
                End If
                sql = "select tb_x832p.tb_x832p_cplb,tb_x832p.tb_x832p_mingc,tb_x832p.tb_x832p_jiagdm,tb_x832p.tb_x832p_num,tb_x832p.tb_x832p_num2,tb_x832p.tb_x832p_jgrq," &
                    "tb_x832p.tb_x832p_i232a,tb_x832p.tb_x832p_l349d,tb_x832p.tb_x832p_scdm,tb_x832p.tb_x832p_bzxs,tb_x832p.tb_x832p_bz,tb_x832p.tb_x832p_qarq," &
                    "tb_x832p.tb_x832p_qaspjg,tb_x832p.tb_x832p_qajgsm,tb_x832p.tb_x832p_fhxz,tb_x832p.tb_x832p_d65v,tb_x832p.tb_x832p_a948s,tb_x832p.tb_x832p_s624k," &
                    "tb_x832p.tb_x832p_s644l,tb_x832p.tb_x832p_c995u,tb_x832p.tb_x832p_m381e,tb_x832p.tb_x832p_j284b,tb_x832p.tb_x832p_c12u,tb_x832p.tb_x832p_e106x," &
                    "tb_x832p.tb_x832p_n446f,tb_x832p.tb_x832p_h199z,tb_x832p.tb_x832p_o468g,tb_x832p.tb_x832p_u691m,tb_x832p.tb_x832p_c16u,tb_x832p.tb_x832p_f119x," &
                    "tb_x832p.tb_x832p_s626k,tb_x832p.tb_x832p_hms,tb_x832p.tb_x832p_hyn,tb_x832p.tb_x832p_midu,tb_x832p.tb_x832p_vcna,tb_x832p.tb_x832p_remark," &
                    "tb_x832p.tb_x832p_th,tb_x832p.tb_x832p_pwkssj,tb_x832p.tb_x832p_pwjssj,tb_x832p.tb_x832p_z886r,dbo.sumSplit(tb_x832p_fgfpht,',') as 返工油重量," &
                    "tb_x832p.tb_x832p_ybdph,tb_x832p.tb_x832p_ybdpht," &
                    "tb_x832p.tb_x832p_ypybdph,tb_x832p.tb_x832p_ypybdpht,tb_x832p.tb_x832p_yjlbdph,tb_x832p.tb_x832p_yjlbdpht  from tb_x832p where (1=1) " &
                    "and tb_x832p.tb_x832p_jgrq>'2008-12-25 23:59:59' " & strUpWhere & " order by tb_x832p.tb_x832p_jgrq desc"
                Dim dt As DataTable = _D.GF_CreateDataSource(sql) '获得真实数据
                Dim strTbName As String = en_LcTableName.成品粉.YanGetEnText
                cl_theCl.setQcshowView(dt, en_LcTableName.成品粉, isAddva:=False)
                '添加结果
                For i As Integer = 0 To dt.Rows.Count - 1  '将结果作为列添加进去
                    sql = "select  * from tb_QcVa where tb_QcVa_Qcbs =" &
                    "(select top 1 tb_QcJc_ID from tb_QcJc where tb_QcJc_jcb='tb_x832p' " &
                    "and tb_QcJc_wlbs=(select tb_x832p_ID from tb_x832p where tb_x832p_num='" & dt.Rows(i)("tb_x832p_num") & "') order by tb_QcJc_ID desc)"
                    Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
                    For Each tDr As DataRow In tDt.Rows
                        Try
                            dt.Rows(i)(tDr("tb_QcVa_xmmc").trim) = tDr("tb_QcVa_xmva").trim
                        Catch ex As Exception

                        End Try
                    Next
                Next

                '删除废弃表
                sql = "if exists(select * from sys.tables where name= '" & en_saveBb.成品粉生产进度.YanGetEnText & "' and type = 'u')" & vbCrLf & _
                "DROP TABLE  " & en_saveBb.成品粉生产进度.YanGetEnText & ""
                sql.YanDbExe()
                '没有表那么就创建表
                If ("select * from sys.tables where name='" & en_saveBb.成品粉生产进度2.YanGetEnText & "' and type = 'u'").YanGetDb.Rows.Count = 0 Then
                    sql = "CREATE TABLE " & en_saveBb.成品粉生产进度2.YanGetEnText & " (" & dt.Columns(0).ColumnName & " " & getZdDataType(dt.Columns(0).DataType.FullName) & ")"
                    sql.YanDbExe()
                    sql = ""
                    For j As Integer = 0 To dt.Columns.Count - 2
                        sql &= "ALTER TABLE " & en_saveBb.成品粉生产进度2.YanGetEnText & " ADD [" & dt.Columns(j + 1).ColumnName & "] " & getZdDataType(dt.Columns(j + 1).DataType.FullName) & " ;" & vbCrLf
                    Next
                    sql.YanDbExe()
                End If
                '保存数据
                'sql = "delete " & en_saveBb.成品粉生产进度.YanGetEnText & ""
                'sql.YanDbExe()
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim arrStr(dt.Columns.Count - 1, 1) As String

                    For j As Integer = 0 To dt.Columns.Count - 1
                        arrStr(j, 0) = dt.Columns(j).ColumnName
                        arrStr(j, 1) = _S.YanNullToEmpty(dt.Rows(i)(j))
                    Next
                    _D.insertData(en_saveBb.成品粉生产进度2.YanGetEnText, arrStr)
                Next
        End Select
        Return True
    End Function
    ''' <summary>
    ''' 将.NET数据类型转成相应的SQL数据类型
    ''' </summary>
    Public Shared Function getZdDataType(pStrNetType As String) As String
        Select Case pStrNetType
            Case "System.String"
                Return "VARCHAR(8000)"
            Case "System.DateTime"
                Return "smalldatetime"
            Case "System.Decimal", "System.Short", "System.Integer", "System.Int32", "System.Long"
                Return "money"
            Case Else
                Return "VARCHAR(8000)"
        End Select
    End Function
    ''' <summary>
    ''' 获取一个指定标识的仓库存量
    ''' </summary>
    ''' <param name="pTbName"></param>
    ''' <param name="pId"></param>
    Public Shared Function getCkslToTb(pTbName As String, pId As Integer) As DataTable
        Dim sql As String = "select * from " & pTbName & " where  " & pTbName & "_id = '" & pId & "' "
        Dim dt As DataTable = sql.YanGetDb

        Dim dtRn As New DataTable
        dtRn.Columns.Add("提取重量")
        dtRn.Columns.Add("仓库")
        dtRn.Columns.Add("仓库存量")

        Dim dtEn As DataTable = GetType(en_cklist).YanEnToTb
        For i As Integer = 0 To dtEn.Rows.Count - 1
            If _S.YanFormatNum(dt.YanDtValue2(pTbName & "_" & dtEn.YanDtValue2("text", i))) > 0 Then
                dtRn.Rows.Add({"0", dtEn.YanDtValue2("name", i), dt.YanDtValue2(pTbName & "_" & dtEn.YanDtValue2("text", i))})
            End If
        Next
        Return dtRn
    End Function
End Class
