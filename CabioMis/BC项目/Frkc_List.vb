Imports System.Linq
Public Class Frkc_List
    ''' <summary>
    ''' 流程产出的物品代码
    ''' </summary>
    Public m_wpDt As DataTable = Nothing
    Private Sub Frkc_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If GF_storelog1("运行部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        '添加BC工艺菜单
        'Dim sql As String = "select a.*,b.tb_wp_pm,b.tb_wp_ID from tb_gxsz as a left join tb_wp as b on a.tb_gxsz_wpbs=b.tb_wp_ID order by tb_gxsz_px"
        Dim sql As String = "select a.*,b.tb_wp_pm,b.tb_wp_ID,b.tb_wp_isqc,b.tb_wp_isqa from tb_gxcccp as a left join tb_wp as b on a.tb_gxcccp_wpbs=b.tb_wp_ID " &
        "left join tb_gxsz as c on a.tb_gxcccp_gxbs=c.tb_gxsz_ID order by tb_gxsz_px"
        Dim dt As DataTable = sql.YanGetDb
        Dim listCp As List(Of String) = dt.YanDtToStr("tb_wp_ID").Split(",").ToList()
        Dim m As ToolStripButton
        For i As Integer = 0 To dt.Rows.Count - 1
            If tsMenu.Items.Find("ts" & dt.YanDtValue2("tb_wp_ID", i), True).Length > 0 Then
                Continue For
            End If
            m = New ToolStripButton
            m.Name = "ts" & dt.YanDtValue2("tb_wp_ID", i)
            m.Image = Frshow_list.ToolStripButton2.Image
            m.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            m.Text = dt.YanDtValue2("tb_wp_pm", i)
            m.Tag = dt.Rows(i)
            AddHandler m.Click, Sub(s As System.Object, ev As System.EventArgs)
                                    m_wpDt = CType(s.tag, DataRow).YanDrToDb
                                    GroupBox1.Text = m_wpDt.YanDtValue2("tb_wp_pm") & "库存情况"
                                    Me.Text = "BC-库存" & m_wpDt.YanDtValue2("tb_wp_pm")
                                    showList()
                                End Sub
            tsMenu.Items.Add(m)
            If i = 0 Then
                m_wpDt = dt.Rows(i).YanDrToDb
            End If
        Next
        '切换菜单与关闭菜单的加载
        m = New ToolStripButton
        m.Image = frwjmenu.ToolStripDropDownButton2.Image
        m.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        m.Text = "关闭"
        AddHandler m.Click, Sub()
                                Me.Close()
                            End Sub
        tsMenu.Items.Add(m)
        AddHandler ComboQc.SelectedIndexChanged, Sub()
                                                     showList()
                                                 End Sub
        AddHandler ComboQa.SelectedIndexChanged, Sub()
                                                     showList()
                                                 End Sub

        '显示变动记录的事件
        AddHandler show1.CellClick, AddressOf showScxq
        '上级修改库存
        AddHandler show1.CellDoubleClick,AddressOf modKc

        '显示列表
        showList()
        '设置下拉框内容
        setSearchText()
    End Sub
    Private Sub showList()
        If m_wpDt is Nothing OrElse m_wpDt.Rows.Count = 0 Then
            Return
        End If
        ComboQc.Enabled = (m_wpDt.YanDtValue2("tb_wp_isqc") = "是")
        ComboQa.Enabled = (m_wpDt.YanDtValue2("tb_wp_isqa") = "是")

        Dim strWhere As String = "1=2"
        strWhere &= IIf(cjcl.Checked, " or tb_wlphck_cjcl>0", "")
        For Each s As String In GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",")
            strWhere &= IIf(CType(MyBase.YanFindControl(s), CheckBox).Checked, " or tb_wlphck_" & s & ">0", "")
        Next
        strWhere = IIf(strWhere = "", "", " and (" & strWhere & ")")
        If ComboQc.Text <> "" Then
            Select Case ComboQc.Text
                Case "是"
                    strWhere &= " and tb_wlphck_wlbs in (select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_sfsh='是' and tb_QcJc_jcb='tb_wlph')"
                Case "否"
                    strWhere &= " and tb_wlphck_wlbs not in (select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_sfsh='是' and tb_QcJc_jcb='tb_wlph')"
            End Select
        End If
        If ComboQa.Text <> "" Then
            Select Case ComboQa.Text
                Case "待定"
                    strWhere &= " and tb_wlphck_wlbs not in (select tb_qa_wlbs from tb_qa where tb_qa_qaspjg<>'待定')"
                Case Else
                    strWhere &= " and tb_wlphck_wlbs in (select tb_qa_wlbs from tb_qa where tb_qa_qaspjg='" & ComboQc.Text & "')"
            End Select
        End If
        Dim sql As String = "select b.tb_wp_pm,b.tb_wp_dm,(tb_wlphck_cjcl+tb_wlphck_bfb+tb_wlphck_kdlk+tb_wlphck_storagemslk+tb_wlphck_storagewzlk) as 仓库存量," &
            "a.*,c.tb_wlph_cjfs "
        sql &= " from tb_wlphck as a left join tb_wp as b on a.tb_wlphck_wpbs=b.tb_wp_ID left join tb_wlph as c on a.tb_wlphck_wlbs=c.tb_wlph_ID"
        sql &= " where tb_wlphck_wpbs=" & m_wpDt.YanDtValue2("tb_wp_ID") & " " & strWhere

        Dim dt As DataTable = sql.YanGetDb

        Dim strHid As String = "tb_wlphck_ID,tb_wlphck_wpbs,tb_wlphck_wlbs,tb_wlphck_zzl,tb_wlphck_kyzl"

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("库存调整")
        AddHandler menu1.Items(1).Click, AddressOf modKc
        menu1.Items.Add("分库")
        AddHandler menu1.Items(2).Click,
            Sub()
                Dim f As New Frkc_fk
                f.m_wlDt = CType(show1.DataSource, DataTable).Select("tb_wlphck_ID=" & show1.SelectedRows(0).Cells("tb_wlphck_ID").Value).YanArrDrToDb
                f.m_wlDt.TableName = "tb_wlphck"
                If f.ShowDialog = DialogResult.OK Then
                    showList()
                End If
            End Sub
        menu1.Items.Add("出库")
        AddHandler menu1.Items(3).Click,
            Sub()
                Dim f As New Frkc_ck
                f.m_wlDt = CType(show1.DataSource, DataTable).Select("tb_wlphck_ID=" & show1.SelectedRows(0).Cells("tb_wlphck_ID").Value).YanArrDrToDb
                f.m_wlDt.TableName = "tb_wlphck"
                If f.ShowDialog = DialogResult.OK Then
                    showList()
                End If
            End Sub
        dt.YanDataBind(show1, strHid, menu1)
    End Sub
    ''' <summary>
    ''' 库存调整
    ''' </summary>
    Private Sub modKc()
        Dim f As New Frkc_tz
        f.m_wlDt = CType(show1.DataSource, DataTable).Select("tb_wlphck_ID=" & show1.SelectedRows(0).Cells("tb_wlphck_ID").Value).YanArrDrToDb
        f.m_wlDt.TableName = "tb_wlphck"
        If f.ShowDialog = DialogResult.OK Then
            showList()
        End If
    End Sub
    Private Sub cjcl_CheckedChanged(sender As Object, e As EventArgs) Handles cjcl.Click,
        storagewzlk.Click, storagemslk.Click, kdlk.Click, bfb.Click
        showList()
    End Sub
    ''' <summary>
    ''' 显示对应条目中的详情
    ''' </summary>
    Private Sub showScxq(sender As Object, e As System.EventArgs)
        If show3.DataSource IsNot Nothing Then
            CType(show3.DataSource, DataTable).Clear()
        End If

        Dim tShow As yangNetCl.yanDaTaGridView = CType(sender, yangNetCl.yanDaTaGridView)
        If tShow.SelectedRows.Count <= 0 Then
            Return
        End If
        '附加信息
        Dim bs = tShow.SelectedRows(0).Cells("tb_wlphck_ID").Value
        Dim strWhere As String = " and ((tb_syjl_xz=1 and tb_syjl_mbb='tb_wlphck' and tb_syjl_czbs='" & bs & "') or " &
            "(tb_syjl_xz=0 and tb_syjl_yb='tb_wlphck' and tb_syjl_ybs='" & bs & "'))"
        showList3(strWhere)
    End Sub
    ''' <summary>
    ''' 填充查询下拉的文本
    ''' </summary>
    Private Sub setSearchText()
        Dim lt As New List(Of Dictionary(Of String, String))
        Dim arrStr As String() = {"tb_syjl_wlph", "tb_syjl_zl", "tb_syjl_czlx"}
        For Each s As String In arrStr
            Dim dic As New Dictionary(Of String, String)
            dic("name") = s
            dic("text") = _D.getZdtext(s)
            dic("type") = _D.getZdtext(s, pNumWz:=2)
            dic("tb") = _D.getZdtext(s, pNumWz:=3)
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
        strWhere &= " and tb_syjl_ftime between '" & tt1 & "' and '" & tt2 & "'"

        If ComboBoxserchtext.SelectedIndex >= 0 Then
            Dim lt As List(Of Dictionary(Of String, String)) = ComboBoxserchtext.Tag
            Dim dic As Dictionary(Of String, String) = lt(ComboBoxserchtext.SelectedIndex)
            Select Case dic("type")
                Case "varchar(8000)"
                    strWhere &= " and " & dic("name") & " like '%" & TextBoxserchtext.Text.Trim & "%'"
                Case Else
                    strWhere &= " and " & dic("name") & " ='" & TextBoxserchtext.Text.Trim & "'"
            End Select
        End If
        showList3(strWhere)
    End Sub
    Private Sub showList3(Optional pWhere As String = "")
        Dim sql As String = "select tb_wp_pm,tb_wp_dm,case when tb_syjl_xz=0 then '出' else '入' end 性质,tb_syjl_ftime," & vbCrLf & _
        "tb_syjl_czlx,tb_syjl_zl,tb_syjl_cjcl,tb_syjl_bfb,tb_syjl_kdlk,tb_syjl_storagewzlk," & vbCrLf & _
        "(select tb_biaoinf_mx from tb_biaoinf where tb_biaoinf_mc=tb_syjl_yb) as 源," & vbCrLf & _
        "(select tb_biaoinf_mx from tb_biaoinf where tb_biaoinf_mc=tb_syjl_mbb) as 目标" & vbCrLf & _
        "from tb_syjl as a left join tb_wp as b on a.tb_syjl_wpbs=b.tb_wp_ID" & vbCrLf & _
        "where tb_wp_ID=" & m_wpDt.YanDtValue2("tb_wp_ID") & " " & pWhere & " order by tb_syjl_ID "
        Dim dt As DataTable = sql.YanGetDb
        dt.YanDataBind(show3, "")
    End Sub

End Class