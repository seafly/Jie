Imports DeepCode.DeepDoStr
Public Class FrSelSz
    Public m_strSqlWh As String = ""
    Public m_iCzBs As Integer = 0
    Public m_ds As New DataSet
    Public m_wpfl As String = ""
    Public m_isCz As Boolean=False

    Private Sub FrSelSz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GS_FaceSearch(selCb, "tb_wp", 1, "物品名称") '筛选
        selCb.Items.Remove("物品分类")
        GS_wlbktlr3(ComboBox1, GetType(en_wpfl).YanEnToTb().YanDtToStr("name").Split(","), en_wpfl.原料.ToString)

        AddHandler selBt.Click, AddressOf selShowLv1 '查询
        AddHandler show1.DoubleClick, AddressOf showDbclick_1 '双击LV1
        AddHandler FormClosed, AddressOf frCloseed '关闭窗体
        AddHandler FormClosing, AddressOf frCloseing
        '填充SHOW1
        showViewSet_1()
        '初始化SHOW2
        showViewSet_2()
        For Each col As DataGridViewColumn In show2.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    '查询显示界面LV1
    Private Sub selShowLv1(ByVal sender As Button, ByVal e As System.EventArgs)
        Dim fr As FrSelSz = sender.FindForm
        Dim zdzw As String = fr.selCb.Text
        Dim db As DataTable = CType(fr.selCb.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like '%" & fr.selTb.Text.Trim & "%'"
        sql &= IIf(ComboBox1.Text = "", "", " and " & _D.GF_cnwithen(db, "tb_biaozdinf_mx='物品分类'", 1) & " ='" & ComboBox1.Text & "'")
        fr.m_strSqlWh = sql
        showViewSet_1()
    End Sub
    '显示show1
    Private Sub showViewSet_1(Optional ByVal pSql As String = "")
        '获取LV2的物品代码字符串
        Dim dtTm As DataTable = show2.DataSource
        Dim strTm As String = _D.YanDttoStr(dtTm, "tb_mrp_wpdm", True)
        If strTm <> "" Then
            strTm = "and tb_wp_dm not in (" & strTm & ")"
        End If
        Dim sql As String = "select tb_wp_ID,tb_wp_dm,tb_wp_pm,tb_wp_wpfl,tb_wp_gsmc,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc," &
        "tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm,tb_wp_yjdj from tb_wp " &
        " where 1=1 " & strTm & " and  tb_wp_dm not in (select tb_mrp_wpdm from tb_mrp where tb_mrp_xz=1 and tb_mrp_cpbs=" & m_iCzBs & ")  " &
        " " & m_strSqlWh & " order by tb_wp_ID"
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        dt.DefaultView.Sort = "tb_wp_dm asc"
        GS_DataGridViewbyDb(show1, dt, True, True)
        '重新排序
        'fr.show1.Sort(show1.Columns("tb_wp_dm"), ListSortDirection.Descending)
    End Sub
    '显示show2
    Private Sub showViewSet_2(Optional ByVal pSql As String = "")
        Dim sql As String = "select tb_mrp_wpdm,case when tb_mrp_yllx='返工' then tb_wp_pm+'(返工)' else tb_wp_pm end as tb_wp_pm," &
            "tb_wp_wpfl,tb_mrp_yllx,tb_mrp_isbx,cast(newid() as varchar(50)) as rowBs " &
            "from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm  where " &
            " tb_mrp_xz=1 and tb_mrp_cpbs=" & m_iCzBs & " order by tb_mrp_wpdm"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)

        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("删除")
        AddHandler menu1.Items(1).Click, AddressOf delBmpXm
        dt.YanDataBind(show2, "tb_mrp_yllx,tb_mrp_isbx,rowBs", menu1)
        If m_wpfl = en_wpfl.过程品.ToString Or m_wpfl = en_wpfl.成品.ToString Then
            Dim col As New DataGridViewDisableCheckBoxColumn
            col.HeaderText = "是否必须"
            col.Name = "isbx"
            show2.Columns.Add(col)
            For i As Integer = 0 To show2.Rows.Count - 1
                show2.Rows(i).Cells("isbx").Value = (show2.Rows(i).Cells("tb_mrp_isbx").Value = "是")
            Next
        End If
    End Sub
    '点击show2单元格的过程
    Private Sub show2_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles show2.CellClick
        If m_wpfl = en_wpfl.过程品.ToString Or m_wpfl = en_wpfl.成品.ToString Then
            Select Case show2.Columns(e.ColumnIndex).Name
                Case "isbx"
                    '是否必须
                    show2.SelectedRows(0).Cells("isbx").Value = (show2.SelectedRows(0).Cells("isbx").Value = False)
                    show2.SelectedRows(0).Cells("tb_mrp_isbx").Value = IIf(show2.SelectedRows(0).Cells("isbx").Value, "是", "否")
                    m_isCz = True
            End Select
        End If
    End Sub
    '双击LV1的过程
    Private Sub showDbclick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim fr As FrSelSz = sender.FindForm
        'lv2增加一行
        Dim dr As DataGridViewRow = Me.show1.SelectedRows(0)
        Dim dt As DataTable = Me.show2.DataSource
        If show1.SelectedRows(0).Cells("tb_wp_wpfl").Value = en_wpfl.成品.ToString Then
            Dim f As New FrSelClInfo
            If f.ShowDialog = DialogResult.OK Then
                If f.iszp.Checked = False And f.isfg.Checked = False Then
                    Return
                End If
                If f.iszp.Checked Then
                    dt.Rows.Add({dr.Cells("tb_wp_dm").Value, dr.Cells("tb_wp_pm").Value, dr.Cells("tb_wp_wpfl").Value, "正品", "否", _S.getGuid()})
                    Dim i As Integer = dt.Rows.Count - 1
                    show2.Rows(i).Cells("isbx").Value = (show2.Rows(i).Cells("tb_mrp_isbx").Value = "是")
                End If
            End If
            If f.isfg.Checked Then
                If f.isfg.Checked Then
                    dt.Rows.Add({dr.Cells("tb_wp_dm").Value, dr.Cells("tb_wp_pm").Value & "(返工)", dr.Cells("tb_wp_wpfl").Value, "返工", "否", _S.getGuid()})
                    Dim i As Integer = dt.Rows.Count - 1
                    show2.Rows(i).Cells("isbx").Value = (show2.Rows(i).Cells("tb_mrp_isbx").Value = "是")
                End If
            End If
            m_isCz = True
        Else
            dt.Rows.Add({dr.Cells("tb_wp_dm").Value, dr.Cells("tb_wp_pm").Value, dr.Cells("tb_wp_wpfl").Value, "正品", "否", _S.getGuid()})
            Dim i As Integer = dt.Rows.Count - 1
            show2.Rows(i).Cells("isbx").Value = (show2.Rows(i).Cells("tb_mrp_isbx").Value = "是")
            m_isCz = True
        End If
        'lv1删除相对应的行
        Me.show1.Rows.Remove(dr)
    End Sub
    '关闭窗体的过程
    Private Sub frCloseed(ByVal sender As FrSelSz, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        If m_isCz = False Then
            Return
        End If
        If MsgBox("更新数据吗？", MsgBoxStyle.YesNo) = vbYes Then
            '更新数据
            Dim sql As String = "delete from tb_mrp where tb_mrp_xz=1 and tb_mrp_cpbs=" & sender.m_iCzBs
            _D.GS_upztxx(sql)
            sql = ""
            Dim dt As DataTable = sender.show2.DataSource
            If dt.Rows.Count = 0 Then
                Return
            End If
            For Each dr As DataRow In dt.Rows
                If dr.RowState <> DataRowState.Deleted Then
                    Dim dic As New Dictionary(Of String, String)
                    dic("tb_mrp_cpbs") = sender.m_iCzBs
                    dic("tb_mrp_wpdm") = _S.YanNullToEmpty(dr("tb_mrp_wpdm"))
                    dic("tb_mrp_xz") = 1
                    dic("tb_mrp_isbx") = _S.YanNullToEmpty(dr("tb_mrp_isbx"))
                    dic("tb_mrp_yllx") = _S.YanNullToEmpty(dr("tb_mrp_yllx"))
                    sql &= _D.insertData("tb_mrp", dic, pType:=1) & vbCrLf
                End If
            Next
            If sql <> "" Then
                _D.GS_upztxx(sql)
            End If
        End If
    End Sub
    Private Sub frCloseing(ByVal sender As FrSelSz, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        'e.Cancel=True
    End Sub
    '删除LV2的行
    Private Sub delBmpXm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("确定删除吗？", MsgBoxStyle.YesNo) = vbNo Then
            Return
        End If
        Dim fr As FrSelSz
        If sender.GetType.Name = "DataGridView" Then
            fr = sender.findform
        Else
            Dim xa As ToolStripMenuItem = sender
            '获取该对象的父容器
            Dim mu As ContextMenuStrip = xa.GetCurrentParent
            '获取绑定的容器的类型
            fr = mu.SourceControl.FindForm
        End If
        fr.show2.Rows.Remove(fr.show2.SelectedRows(0))
        showViewSet_1()
        m_isCz = True
    End Sub
End Class