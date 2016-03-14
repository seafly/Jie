Public Class FrbcList
    ''' <summary>
    ''' 工艺信息
    ''' </summary>
    Public m_gxszDt As DataTable = Nothing
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub FrbcList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If GF_storelog1("运行部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        AddHandler show1.CellClick, AddressOf showScxq
        AddHandler show1.CellDoubleClick, Sub()
                                              addPh_Click("修改", Nothing)
                                          End Sub
        setMenu()
        showList()
        '设置下拉框内容
        setSearchText()
    End Sub
    ''' <summary>
    ''' 设置头部菜单
    ''' </summary>
    Public Sub setMenu()
        tsMenu.Items.Clear()
        '添加BC工艺菜单
        Dim sql As String = "select * from tb_gxsz order by tb_gxsz_px"
        Dim dt As DataTable = sql.YanGetDb
        Dim m As ToolStripButton
        For i As Integer = 0 To dt.Rows.Count - 1
            m = New ToolStripButton
            m.Image = Frshow_list.ToolStripButton2.Image
            m.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            m.Text = dt.YanDtValue2("tb_gxsz_mc", i)
            m.Tag = dt.Rows(i).YanDrToDb
            AddHandler m.Click, Sub(s As System.Object, ev As System.EventArgs)
                                    m_gxszDt = CType(s.tag, DataTable)
                                    If showFjxx.DataSource IsNot Nothing Then
                                        CType(showFjxx.DataSource, DataTable).Clear()
                                    End If
                                    If showTlxx.DataSource IsNot Nothing Then
                                        CType(showTlxx.DataSource, DataTable).Clear()
                                    End If
                                    If showCcxx.DataSource IsNot Nothing Then
                                        CType(showCcxx.DataSource, DataTable).Clear()
                                    End If
                                    If showQcxx.DataSource IsNot Nothing Then
                                        CType(showQcxx.DataSource, DataTable).Clear()
                                    End If
                                    If show2.DataSource IsNot Nothing Then
                                        CType(show2.DataSource, DataTable).Clear()
                                    End If
                                    showList()
                                End Sub
            tsMenu.Items.Add(m)
            If i = 0 Then
                m_gxszDt = dt.Rows(i).YanDrToDb
            End If
        Next
        '参加BC仓位调整菜单
        m = New ToolStripButton
        m.Image = Frshow_list.ToolStripButton1.Image
        m.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        m.Text = "BC库存管理"
        AddHandler m.Click, Sub(s As System.Object, ev As System.EventArgs)
                                Dim nform As New Frkc_List
                                nform.ShowDialog()
                            End Sub
        tsMenu.Items.Add(m)
        '添加BC设置菜单
        Dim m2 As New ToolStripDropDownButton
        m2.Image = Frshow_list.wsButton3.Image
        m2.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        m2.Text = "BC设置"
        Dim q As ToolStripDropDownItem = m2.DropDownItems.Add("物品设置")
        AddHandler q.Click, AddressOf (New Frhccl).ShowDialog
        q = m2.DropDownItems.Add("工艺设置")
        AddHandler q.Click, AddressOf (New FrgxShow).ShowDialog
        tsMenu.Items.Add(m2)
        q = m2.DropDownItems.Add("自定义批号")
        AddHandler q.Click,AddressOf (New Frph_List).ShowDialog
        tsMenu.Items.Add(m2)
        '切换菜单与关闭菜单的加载
        GF_OpenFaceList2(tsMenu)
    End Sub
    ''' <summary>
    ''' 显示当前生产的列表
    ''' </summary>
    Private Sub showList()
        Me.Text = "BC-" & m_gxszDt.YanDtValue2("tb_gxsz_mc")
        GroupBox3.Text = m_gxszDt.YanDtValue2("tb_gxsz_mc")
        '列出该工艺产出的批号
        'Dim Sql As String = "select * from tb_sc where tb_sc_isEnd<>'是' and tb_sc_gxbs='" & m_gxszDt.YanDtValue2("tb_gxsz_ID") & "'"
        Dim Sql As String = "select b.tb_gxsz_mc,a.*,case when tb_gxsz_isqc='是' then" & vbCrLf & _
        "case when exists(select * from tb_QcJc where tb_QcJc_wlbs=a.tb_sc_ID and tb_QcJc_jcb='tb_sc' and tb_QcJc_sfsh='是') then" & vbCrLf & _
        "'是' else '否' end else '--' end as QC审核" & vbCrLf & _
        "from tb_sc as a left join tb_gxsz as b" & vbCrLf & _
        "on a.tb_sc_gxbs=b.tb_gxsz_ID where tb_sc_isEnd='"& en_sczt.待定.ToString &"' and tb_sc_gxbs='" & m_gxszDt.YanDtValue2("tb_gxsz_ID") & "'"
        Dim dt As DataTable = Sql.YanGetDb
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        '表示此菜单有添加功能
        menu1.Tag = 0
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("添加")
        AddHandler menu1.Items(1).Click, Sub()
                                             addPh_Click("添加", Nothing)
                                         End Sub
        menu1.Items.Add("修改")
        AddHandler menu1.Items(2).Click, Sub()
                                             addPh_Click("修改", Nothing)
                                         End Sub
        menu1.Items.Add("删除")
        AddHandler menu1.Items(3).Click, Sub()
                                             delPh()
                                             showList()
                                         End Sub
        dt.YanDataBind(show1, "tb_sc_ID,tb_sc_gxbs", menu1)
    End Sub
    ''' <summary>
    ''' 显示对应条目中的详情
    ''' </summary>
    Private Sub showScxq(sender As Object, e As System.EventArgs)
        If showFjxx.DataSource IsNot Nothing Then
            CType(showFjxx.DataSource, DataTable).Clear()
        End If
        If showTlxx.DataSource IsNot Nothing Then
            CType(showTlxx.DataSource, DataTable).Clear()
        End If
        If showCcxx.DataSource IsNot Nothing Then
            CType(showCcxx.DataSource, DataTable).Clear()
        End If
        If showQcxx.DataSource IsNot Nothing Then
            CType(showQcxx.DataSource, DataTable).Clear()
        End If

        Dim tShow As yangNetCl.yanDaTaGridView = CType(sender, yangNetCl.yanDaTaGridView)
        If tShow.SelectedRows.Count <= 0 Then
            Return
        End If
        '附加信息
        Dim sql As String = "select tb_scxq_text as 项目,tb_scxq_value from tb_scxq where tb_scxq_lx='附加信息' and " &
            " tb_scxq_scbs=" & tShow.SelectedRows(0).Cells("tb_sc_ID").Value
        Dim dt As DataTable = sql.YanGetDb
        dt.YanDataBind(showFjxx)

        '投料信息
        sql = "select tb_scxq_text as 物品名称,tb_scxq_value from tb_scxq where tb_scxq_lx='投料' and " &
        " tb_scxq_scbs=" & tShow.SelectedRows(0).Cells("tb_sc_ID").Value
        dt = sql.YanGetDb
        dt.Columns.Add("批号重量")
        dt.Columns.Add("总重量")
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim arrPh As String() = dt.YanDtValue2("tb_scxq_value", i).Split("|")(0).Split(",")
            Dim arrZl As String() = dt.YanDtValue2("tb_scxq_value", i).Split("|")(1).Split(",")
            Dim strPhzl As String = ""
            Dim douZzl As Double = 0
            For j As Integer = 0 To arrPh.Length - 1
                strPhzl &= arrPh(j) & "：" & arrZl(j) & ","
                douZzl += Convert.ToDouble(arrZl(j))
            Next
            dt.Rows(i)("批号重量") = strPhzl.YanRemovedh
            dt.Rows(i)("总重量") = douZzl
        Next
        dt.YanDataBind(showTlxx, "tb_scxq_value")
        '产出信息
        sql = "select tb_scxq_text as 物品名称,tb_scxq_value from tb_scxq where tb_scxq_lx='产出' and " &
        " tb_scxq_scbs=" & tShow.SelectedRows(0).Cells("tb_sc_ID").Value
        dt = sql.YanGetDb
        dt.Columns.Add("批号")
        dt.Columns.Add("重量")
        dt.Columns.Add("产品类型")
        dt.Columns.Add("产品代码")
        dt.Columns.Add("加工代码")

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("批号") = dt.YanDtValue2("tb_scxq_value", i).Split("|")(1)
            dt.Rows(i)("重量") = dt.YanDtValue2("tb_scxq_value", i).Split("|")(2)
            dt.Rows(i)("产品类型") = dt.YanDtValue2("tb_scxq_value", i).Split("|")(3)
            dt.Rows(i)("产品代码") = dt.YanDtValue2("tb_scxq_value", i).Split("|")(4)
            dt.Rows(i)("加工代码") = dt.YanDtValue2("tb_scxq_value", i).Split("|")(5)
        Next
        'sql = "select b.tb_wp_pm,tb_wp_dm,tb_wlph_wlph,tb_wlph_sl from tb_wlph as a left join tb_wp as b on a.tb_wlph_wpbs=b.tb_wp_ID  " &
        '    "where tb_wlph_cjtb='tb_sc' and tb_wlph_cjbs=" & tShow.SelectedRows(0).Cells("tb_sc_ID").Value
        'dt = sql.YanGetDb
        dt.YanDataBind(showCcxx, "tb_scxq_value")
        'QC信息
        sql = "select tb_QcVa_xmmc,tb_QcVa_xmva from tb_QcVa " &
            "where tb_QcVa_Qcbs=(select max(tb_QcJc_ID) from tb_QcJc where  tb_QcJc_jcb='tb_sc' " &
            "and tb_QcJc_wlbs=" & tShow.SelectedRows(0).Cells("tb_sc_ID").Value & ")"
        dt = sql.YanGetDb
        dt.YanDataBind(showQcxx)
    End Sub
    Private Sub ToExcel_Click(sender As Object, e As EventArgs) Handles ToExcel.Click
        GS_toexcel(show2, DateTimePicker1.Text & "至" & DateTimePicker2.Text, Me)
    End Sub
    ''' <summary>
    ''' 编辑生产信息
    ''' </summary>
    Private Sub addPh_Click(sender As Object, e As EventArgs) Handles addPh.Click
        Dim f As New FrWpAdd
        If sender.ToString = "修改" Then
            f.m_xgid = show1.SelectedRows(0).Cells("tb_sc_ID").Value
        End If
        If f.ShowDialog() = DialogResult.OK Then
            showList()
        End If
    End Sub
    ''' <summary>
    ''' 删除生产信息
    ''' </summary>
    Private Sub delPh()
        If MsgBox("确定要删除吗？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = vbNo Then
            Return
        End If
        Dim mt As New _D.myTransaction
        Try
            Dim xgid As String = show1.SelectedRows(0).Cells("tb_sc_ID").Value
            mt.dbExe("delete from tb_QcVa where tb_QcVa_Qcbs in(select tb_QcJc_ID from tb_QcJc where tb_QcJc_jcb='tb_sc' and tb_QcJc_wlbs=" & xgid & ")")
            mt.dbExe("delete from tb_QcJc where tb_QcJc_jcb='tb_sc' and tb_QcJc_wlbs=" & xgid)
            mt.dbExe("delete from tb_wlph where tb_wlph_cjtb='tb_sc' and  tb_wlph_cjbs=" & xgid)
            mt.dbExe("delete from tb_sc where tb_sc_ID=" & xgid)
            mt.dbExe("delete from tb_scxq where tb_scxq_scbs=" & xgid)
            mt.Commit()
            MsgBox("删除完成！")
        Catch ex As Exception
            mt.Rollback()
            MsgBox("发生错误，" & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            mt.close()
            mt = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' 填充查询下拉的文本
    ''' </summary>
    Private Sub setSearchText()
        If m_gxszDt.YanDtValue2("tb_gxsz_ID") = "" Then
            Return
        End If
        Dim lt As New List(Of Dictionary(Of String, String))
        Dim dic As New Dictionary(Of String, String)
        dic("name") = "tb_sc_dh"
        dic("text") = _D.getZdtext("tb_sc_dh")
        dic("tb") = "tb_sc"
        lt.Add(dic)
        dic = New Dictionary(Of String, String)
        dic("name") = "tb_wlph_wlph"
        dic("text") = "产出批号"
        dic("tb") = "tb_wlph"
        lt.Add(dic)
        Dim sql As String = "select * from tb_gxfjxx where tb_gxfjxx_gxbs=" & m_gxszDt.YanDtValue2("tb_gxsz_ID")
        Dim dt As DataTable = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            dic = New Dictionary(Of String, String)
            dic("name") = dt.YanDtValue2("tb_gxfjxx_mc", i)
            dic("text") = dt.YanDtValue2("tb_gxfjxx_mc", i)
            dic("type") = dt.YanDtValue2("tb_gxfjxx_lx", i)
            dic("tb") = "tb_gxfjxx"
            lt.Add(dic)
        Next
        For i As Integer = 0 To lt.Count - 1
            ComboBoxserchtext.Items.Add(lt(i)("text"))
        Next
        ComboBoxserchtext.Tag = lt
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strWhere As String = ""
        Dim sql As String = Nothing
        Dim tt1 As String = GF_gettrqsj(DateTimePicker1.Text) & " 00:00:00"
        Dim tt2 As String = GF_gettrqsj(DateTimePicker2.Text) & " 23:59:59"
        strWhere &= " and tb_sc_ftime between '" & tt1 & "' and '" & tt2 & "'"

        If ComboBoxserchtext.SelectedIndex >= 0 Then
            Dim lt As List(Of Dictionary(Of String, String)) = ComboBoxserchtext.Tag
            Dim dic As Dictionary(Of String, String) = lt(ComboBoxserchtext.SelectedIndex)
            Select Case dic("tb")
                Case "tb_sc"
                    strWhere &= " and " & dic("name") & " like '%" & TextBoxserchtext.Text.Trim & "%'"
                Case "tb_wlph"
                    strWhere &= " and tb_sc_ID in (select tb_wlph_cjbs from tb_wlph where tb_wlph_cjtb='tb_sc' " &
                        "and " & dic("name") & " like '%" & TextBoxserchtext.Text.Trim & "%')"
                Case "tb_gxfjxx"
                    strWhere &= " and tb_sc_ID in (select tb_scxq_scbs from tb_scxq where tb_scxq_lx='附加信息' " &
                        "and tb_scxq_text='" & dic("name") & "' and tb_scxq_value like '%" & TextBoxserchtext.Text.Trim & "%')"
            End Select
        End If
        sql = "select b.tb_gxsz_mc,a.*,case when tb_gxsz_isqc='是' then" & vbCrLf & _
         "case when exists(select * from tb_QcJc where tb_QcJc_wlbs=a.tb_sc_ID and tb_QcJc_jcb='tb_sc' and tb_QcJc_sfsh='是') then" & vbCrLf & _
         "'是' else '否' end else '--' end as QC审核" & vbCrLf & _
         "from tb_sc as a left join tb_gxsz as b" & vbCrLf & _
         "on a.tb_sc_gxbs=b.tb_gxsz_ID where tb_sc_isEnd<>'"& en_sczt.待定.ToString &"' and tb_sc_gxbs='" & m_gxszDt.YanDtValue2("tb_gxsz_ID") & "' " & strWhere
        Dim dt As DataTable = sql.YanGetDb
        AddHandler show2.CellClick, AddressOf showScxq
        dt.YanDataBind(show2, "tb_sc_ID,tb_sc_gxbs")

    End Sub
End Class