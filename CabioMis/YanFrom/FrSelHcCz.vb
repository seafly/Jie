Public Class FrSelHcCz
    Public m_strSqlWh As String = ""
    Public m_iCzBs As Integer = 0
    Public m_ds As New DataSet
    Public m_Ph As String = ""

    Private Sub FrSelHcCz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select 0 as 提取数量,tb_i259b_num,tb_i259b_p518h,tb_i259b_h200z,tb_i259b_i231a,tb_i259b_zlhsxs from tb_i259b where " & cl_getWhere.有效物料
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dt.TableName = "原料表"
        m_ds.Tables.Add(dt.Copy()) '得到原料表
        dt.Clear()
        dt = Nothing

        AddHandler show1.DoubleClick, AddressOf clMrpDbclick_1 '双击LV1
        AddHandler FormClosed, AddressOf clfrCloseed '关闭窗体

        AddHandler show2.DoubleClick, AddressOf clMrpDbclick_2 '双击LV2

        '填充SHOW1
        clWpSet_1()
        '初始化SHOW2
        Dim dt2 As New DataTable
        dt2.Columns.Add("提取数量")
        dt2.Columns.Add("tb_wp_dm")
        dt2.Columns.Add("tb_wp_pm")
        dt2.Columns.Add("tb_wp_dw")
        dt2.Columns.Add("重量", GetType(Double))
        GS_DataGridViewbyDb(show2, dt2, True, True)
        'show2.Columns("重量").Visible=False
    End Sub

    '显示show1
    Private Sub clWpSet_1(Optional ByVal pSql As String = "")
        '获取LV2的物品代码字符串
        Dim dtTm As DataTable = show2.DataSource
        Dim strTm As String = _D.YanDttoStr(dtTm, "tb_mrp_wpdm", True)
        If strTm <> "" Then
            strTm = "and tb_wp_dm not in (" & strTm & ")"
        End If
        Dim sql As String = "select tb_wp_dm,tb_wp_pm,tb_wp_dw,case when 车间存量 is null then 0 else 车间存量 end as 车间存量 from tb_wp as a left join " &
        "(select sum(tb_i259b_p518h) as 车间存量,tb_i259b_i231a from tb_i259b where " & cl_getWhere.有效物料 & " group by tb_i259b_i231a) " &
        " as b on a.tb_wp_dm=b.tb_i259b_i231a" &
        " where 1=1  and tb_wp_dm in (select tb_mrp_wpdm from tb_mrp where tb_mrp_xz=1 and tb_mrp_cpbs=" & m_iCzBs & ")  " &
        " " & m_strSqlWh & " order by tb_wp_ID"
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        dt.DefaultView.Sort = "tb_wp_dm asc"
        GS_DataGridViewbyDb(show1, dt, True, True)
        '重新排序
        'fr.show1.Sort(show1.Columns("tb_wp_dm"), ListSortDirection.Descending)
    End Sub
    '双击LV1的过程
    Private Sub clMrpDbclick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt1 As DataTable = GF_czmctb(m_ds.Tables("原料表"), "tb_i259b_i231a='" & show1.SelectedRows(0).Cells("tb_wp_dm").Value & "'")
        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt1
        objClpam.bs = show1.SelectedRows(0).Cells("tb_wp_dm").Value
        objClpam.titleText = show1.SelectedRows(0).Cells("tb_wp_pm").Value
        objClpam.callbackFn = AddressOf clmrpPhClSub
        GS_TCYLLIST_yan(Me, objClpam)

        'lv2增加一行
        Dim dr As DataGridViewRow = show1.SelectedRows(0)
        Dim dt2 As DataTable = show2.DataSource

        '总数量
        Dim iZsl As Double = 0
        '总重量
        Dim douZzl As Double = 0
        Dim dtWl As DataTable = CType(m_ds.Tables(dr.Cells("tb_wp_dm").Value), DataTable)
        If dtWl Is Nothing Then
            Return
        End If
        For Each drWl As DataRow In dtWl.Rows
            iZsl += drWl("提取数量")
            douZzl += drWl("提取数量") * GF_czmctb(m_ds.Tables("原料表"), "tb_i259b_num='" & drWl("tb_i259b_num") & "'").Rows(0)("tb_i259b_zlhsxs") '数量*转换系数
        Next
        If iZsl <= 0 Then
            Return
        End If
        dt2.Rows.Add({iZsl, dr.Cells("tb_wp_dm").Value, dr.Cells("tb_wp_pm").Value, dr.Cells("tb_wp_dw").Value, douZzl})
        'lv1删除相对应的行
        show1.Rows.Remove(dr)
    End Sub
    '批号列表处理的过程
    Private Function clmrpPhClSub(ByVal pObj As Object, ByVal pfr As Object) As Object
        '讲批号提取重量的结果保存进内存
        Dim dt As DataTable = CType(pObj, DataTable)
        Dim strTbName = dt.TableName
        dt.TableName = strTbName
        Try
            m_ds.Tables.Remove(strTbName)
        Catch
        End Try
        m_ds.Tables.Add(dt)
        Return Nothing
    End Function
    '双击LV2的过程
    Private Sub clMrpDbclick_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '显示批号提取重量的结果
        Dim strTbName = show2.SelectedRows(0).Cells("tb_wp_dm").Value
        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = m_ds.Tables(strTbName)
        objClpam.bs = strTbName
        objClpam.titleText = show2.SelectedRows(0).Cells("tb_wp_pm").Value
        objClpam.callbackFn = AddressOf clmrpPhClSub
        GS_TCYLLIST_yan(Me, objClpam)

        'lv2增加一行
        Dim dr As DataGridViewRow = show2.SelectedRows(0)
        Dim dt2 As DataTable = show2.DataSource
        Dim iZsl As Double = 0
        '计算提取的总重量
        For Each dr2 As DataRow In CType(m_ds.Tables(dr.Cells("tb_wp_dm").Value), DataTable).Rows
            iZsl += dr2("提取数量")
        Next
        '如果数量=0那么删除这一行，同时在lv1里增加对应的一行
        If iZsl <= 0 Then
            show2.Rows.Remove(dr)
            clWpSet_1()
            Return
        End If
        '更新数量
        dr.Cells("提取数量").Value = iZsl

    End Sub
    '关闭窗体的过程(物品合成操作)
    Private Sub clfrCloseed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        If show2.Rows.Count <= 0 Then
            Return
        End If
        If MsgBox("更新数据吗？", MsgBoxStyle.YesNo) = vbYes Then
            'Dim aa As New FrSelHcCz_2
            'aa.ShowDialog
            Dim sql As String = ""
            sql = "select * from tb_wp where tb_wp_ID=" & m_iCzBs
            Dim dt As DataTable = _D.GF_CreateDataSource(sql)
            Dim strZl As String = InputBox("请输入生成的数量，单位（" & dt.Rows(0)("tb_wp_dw") & "）", "输入数量")
            If strZl = "" OrElse IsNumeric(strZl) = False Then
                MsgBox("数量输入错误！")
                Return
            End If
            '计算重量换算关系
            Dim dtWl As DataTable = show2.DataSource
            Dim douZzl As Double = dtWl.Compute("sum(重量)", "")
            Dim douHsxs As Double = 1
            If dt.Rows(0)("tb_wp_dw") <> "公斤" And dt.Rows(0)("tb_wp_dw") <> "kg" Then
                '总重量/输入数量
                douHsxs = douZzl / strZl
            End If
            '存入物料表
            sql = "insert into tb_i259b(tb_i259b_r596j,tb_i259b_i231a,tb_i259b_num,tb_i259b_p518h,tb_i259b_c24u,tb_i259b_qaspjg,tb_i259b_qcsh,tb_i259b_h200z,tb_i259b_zlhsxs)  " &
                "values('合成原料','" & dt.Rows(0)("tb_wp_dm") & "','" & m_Ph & "'," & strZl &
                ",'" & dt.Rows(0)("tb_wp_pm") & "','合格','是','" & dt.Rows(0)("tb_wp_dw") & "'," & douHsxs & ")"
            Dim iWlbs As Integer = _D.GF_upztxx2(sql)

            '将本身的生成操作存入记录表
            _D.insertData("tb_syjl", {{"tb_syjl_wpdm", dt.Rows(0)("tb_wp_dm")},
                                      {"tb_syjl_xz", "1"},
                                      {"tb_syjl_czbs", iWlbs},
                                      {"tb_syjl_wlph", m_Ph},
                                      {"tb_syjl_czlx", "合成入库"},
                                      {"tb_syjl_zl", strZl}})
            '将消耗的原料存入记录表
            For i As Integer = 0 To show2.Rows.Count - 1
                For Each dr As DataRow In CType(m_ds.Tables(show2.Rows(i).Cells("tb_wp_dm").Value), DataTable).Rows
                    _D.insertData("tb_syjl", {{"tb_syjl_wpdm", show2.Rows(i).Cells("tb_wp_dm").Value},
                                              {"tb_syjl_czbs", iWlbs},
                                              {"tb_syjl_wlph", dr(1)},
                                              {"tb_syjl_czlx", "物品合成"},
                                              {"tb_syjl_zl", dr(0)}})
                    '更新车间存量
                    _D.GS_upztxx("update tb_i259b set tb_i259b_p518h=tb_i259b_p518h-" & dr(0) & "where tb_i259b_num='" & dr(1) & "'")
                Next
            Next
            Me.DialogResult = vbOK
        End If
    End Sub
End Class