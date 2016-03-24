Imports com.uceip.Common
Imports Cabio.Model.Crafts
Imports Cabio.BLL.Crafts


Public Class FrgxAdd
    '基本信息数据
    Dim m_gxszDt As DataTable
    '产出产品信息
    Dim m_cccpDt As DataTable
    '附加信息
    Dim m_fjxxDt As DataTable
    '修改ID
    Public m_gxid As Integer = 0

    Dim craftsSettingBll As CraftsProductService = New CraftsProductService()

    Public Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        tb_gxsz_isMod.Text = "否"
        tb_gxsz_isqc.Text = "是"
        tb_gxsz_isBf.Text = "是"
        tb_gxsz_dm.Text = 1
    End Sub
    Private Sub form_closeing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("更新数据吗？", MsgBoxStyle.YesNo) = vbYes Then
            button1_Click("", Nothing)
        End If
    End Sub
    Private Sub FrgxAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        'Dim Service As New CraftsSettingService()
        'Dim gysz As tb_gxsz
        'gysz = Service.GetObject(工艺设置ID)


        'Dim sql As String = "select * from tb_gxsz where tb_gxsz_ID=" & IIf(m_gxid > 0, m_gxid, 0)
        'm_gxszDt = sql.YanGetDb

        Dim list As IList(Of tb_gxsz) = New CraftsSettingService().GetListByQuery(Of tb_gxsz)()
        Dim dt As DataTable = DataTableExtensions.ToDataTable(list)
        dt.TableName = "tb_gxsz"
        If m_gxid > 0 Then
            _D.YanDtSetFrCon(Me, dt)
        End If
        setCccp()
        setFjxx()
        For Each col As DataGridViewColumn In showWpxx.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each col As DataGridViewColumn In showFjxx.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    ''' <summary>
    ''' 产出产品 的过程
    ''' </summary>
    Private Sub setCccp()

        'Dim Service As New CraftsProductService()
        'Service.GetCraftsProductList(工艺设置ID)

        'Dim Sql As String = "select b.tb_wp_pm,b.tb_wp_dm,tb_wp_ID,a.*,cast(newid() as varchar(50)) as rowBs " &
        '    " from tb_gxcccp as a left join tb_wp as b on a.tb_gxcccp_wpbs=b.tb_wp_ID  where tb_gxcccp_gxbs=" & IIf(m_gxid > 0, m_gxid, 0)
        'm_cccpDt = Sql.YanGetDb

        Dim list As IList(Of tb_gxcccp) = craftsSettingBll.GetCraftsProductList(IIf(m_gxid > 0, m_gxid, Nothing))
        m_cccpDt = DataTableExtensions.ToDataTable(list)
        m_cccpDt.TableName = "tb_gxcccp"
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        '表示此菜单有添加功能
        menu1.Tag = 0
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("添加")
        AddHandler menu1.Items(1).Click, AddressOf showSetCccp
        menu1.Items.Add("修改")
        AddHandler menu1.Items(2).Click, Sub()
                                             showSetCccp("修改", Nothing)
                                         End Sub
        menu1.Items.Add("批号设置")
        AddHandler menu1.Items(3).Click, Sub()
                                             Dim f As New Frph_sz
                                             f.tb_bcbm_tb.Text = "tb_wp"
                                             f.tb_bcbm_bs.Text = showWpxx.SelectedRows(0).Cells("tb_wp_ID").Value
                                             f.tb_bcbm_bmmc.Text = showWpxx.SelectedRows(0).Cells("tb_wp_pm").Value & "批号"
                                             f.tb_bcbm_lx.Items.Add(en_phEx.附加信息.ToString)
                                             f.phEx.Items.AddRange(m_fjxxDt.YanDtToStr("tb_gxfjxx_mc").Split(","))
                                             f.ShowDialog()
                                         End Sub
        menu1.Items.Add("删除")
        AddHandler menu1.Items(4).Click, Sub()
                                             'Service.Remove(附件信息ID)
                                             m_cccpDt.Rows.Remove(m_cccpDt.Select("rowBs='" & showWpxx.SelectedRows(0).Cells("rowBs").Value & "'")(0))
                                         End Sub
        AddHandler showWpxx.CellDoubleClick, Sub()
                                                 showSetCccp("修改", Nothing)
                                             End Sub
        m_cccpDt.YanDataBind(showWpxx, "tb_wp_ID,rowBs,tb_gxcccp_ID,tb_gxcccp_gxbs,tb_gxcccp_wpbs", menu1)
    End Sub
    Private Sub showSetCccp(sender As Object, e As EventArgs)
        If sender.ToString() <> "修改" Then
            If m_cccpDt.Rows.Count >= 2 Then
                MsgBox("最多只能产出2种物品！", MsgBoxStyle.Exclamation)
                Return
            End If
        End If
        Dim f As New FrEdit_gxcp
        If sender.ToString() = "修改" Then
            f.rowBs.Text = showWpxx.SelectedRows(0).Cells("rowBs").Value
        End If
        If f.ShowDialog() = DialogResult.OK Then
            'Dim Service As New CraftsProductService()
            'If (添加) Then
            '    Service.Insert(工艺产出产品实体);
            'else
            '    Service.Update(工艺产出产品实体)

            If m_cccpDt.Select("tb_gxcccp_ID<>" & f.tb_gxcccp_ID.Text & " and tb_gxcccp_wpbs=" & f.tb_wp_ID.Text).Length > 0 Then
                MsgBox("已有相同的物品！", MsgBoxStyle.Exclamation)
                Return
            End If
            If m_cccpDt.Rows.Count > 0 Then
                Dim Sql As String = "select * from tb_mrp where tb_mrp_cpbs=" & m_cccpDt.YanDtValue2("tb_gxcccp_wpbs") & " order by tb_mrp_wpdm"
                Dim strWpdm As String = Sql.YanGetDb.YanDtToStr("tb_mrp_wpdm")
                Sql = "select * from tb_mrp where tb_mrp_cpbs=" & f.tb_wp_ID.Text & " order by tb_mrp_wpdm"
                If strWpdm <> Sql.YanGetDb.YanDtToStr("tb_mrp_wpdm") Then
                    MsgBox("产出物品的原料必须完全一致！", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If
            Dim rowBs As String = _D.YanFrVaAddDt(f, m_cccpDt)
            m_cccpDt.Select("rowBs='" & rowBs & "'")(0)("tb_gxcccp_wpbs") =
                m_cccpDt.Select("rowBs='" & rowBs & "'")(0)("tb_wp_ID")
        End If
    End Sub
    ''' <summary>
    ''' 设置附加信息的过程
    ''' </summary>
    Private Sub setFjxx()

        'Dim Service As New CraftsInfoService()
        'Service.getCraftsInfoList(工艺设置ID)

        Dim Sql As String = "select *,cast(newid() as varchar(50)) as rowBs  from tb_gxfjxx where tb_gxfjxx_gxbs=" & IIf(m_gxid > 0, m_gxid, 0)
        m_fjxxDt = Sql.YanGetDb
        m_fjxxDt.TableName = "tb_gxfjxx"
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        '表示此菜单有添加功能
        menu1.Tag = 0
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("添加")
        AddHandler menu1.Items(1).Click, Sub()
                                             Dim f As New FrEdit_gxfjxx
                                             If f.ShowDialog() = DialogResult.OK Then
                                                 'Service.Insert()
                                                 If m_fjxxDt.Select("tb_gxfjxx_mc='" & f.tb_gxfjxx_mc.Text & "'").Length > 0 Then
                                                     MsgBox("已有相同名称的项目！", MsgBoxStyle.Exclamation)
                                                     Return
                                                 End If
                                                 _D.YanFrVaAddDt(f, m_fjxxDt)
                                             End If
                                         End Sub
        menu1.Items.Add("修改")
        AddHandler menu1.Items(2).Click, AddressOf modFjxx
        menu1.Items.Add("删除")
        AddHandler menu1.Items(3).Click, Sub()
                                             'Service.Remove()
                                             m_fjxxDt.Rows.Remove(m_fjxxDt.Select("rowBs='" & showFjxx.SelectedRows(0).Cells("rowBs").Value & "'")(0))
                                         End Sub
        AddHandler showFjxx.CellDoubleClick, AddressOf modFjxx
        m_fjxxDt.YanDataBind(showFjxx, "tb_gxfjxx_ID,rowBs,tb_gxfjxx_gxbs", menu1)
    End Sub
    Private Sub modFjxx()
        Dim f As New FrEdit_gxfjxx
        f.rowBs.Text = showFjxx.SelectedRows(0).Cells("rowBs").Value
        If f.ShowDialog() = DialogResult.OK Then
            'Dim Service As New CraftsInfoService()
            'Service.Update()
            If m_fjxxDt.Select("tb_gxfjxx_mc='" & f.tb_gxfjxx_mc.Text & "' and rowBs<>'" & f.rowBs.Text & "'").Length > 0 Then
                MsgBox("已有相同名称的项目！", MsgBoxStyle.Exclamation)
                Return
            End If
            _D.YanFrVaAddDt(f, m_fjxxDt)
        End If
    End Sub
    '确定
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        'Dim Service As New CraftsSettingService()
        'Service.Insert()添加
        'Service.Update()修改

        If CheckControlNull(GroupBox1) = False Then
            Return
        End If
        If m_gxid = 0 Then
            If _D.isRowNull("tb_gxsz", "tb_gxsz_mc='" & tb_gxsz_mc.Text.Trim & "'") Then
                MsgBox("已有相同的工艺！", MsgBoxStyle.Exclamation)
                Return
            End If
            If _D.isRowNull("tb_gxsz", "tb_gxsz_dm='" & tb_gxsz_dm.Text.Trim & "'") Then
                MsgBox("已有相同的工艺代码！", MsgBoxStyle.Exclamation)
                Return
            End If
        Else
            If _D.isRowNull("tb_gxsz", "tb_gxsz_mc='" & tb_gxsz_mc.Text.Trim & "' and tb_gxsz_ID<>" & m_gxid) Then
                MsgBox("已有相同的工艺！", MsgBoxStyle.Exclamation)
                Return
            End If
            If _D.isRowNull("tb_gxsz", "tb_gxsz_dm='" & tb_gxsz_dm.Text.Trim & "' and tb_gxsz_ID<>" & m_gxid) Then
                MsgBox("已有相同的工艺！", MsgBoxStyle.Exclamation)
                Return
            End If
        End If
        If m_cccpDt.Rows.Count = 0 Then
            MsgBox("产出物品不能为空！", MsgBoxStyle.Exclamation)
            Return
        End If

        '更新主表
        _D.YanFrVaAddDt(GroupBox1, m_gxszDt, True)
        m_gxid = m_gxszDt.YanDtValue2("tb_gxsz_ID")
        '更新工序标识
        For Each dr As DataRow In m_cccpDt.Rows
            dr("tb_gxcccp_gxbs") = m_gxid
        Next
        '更新产出产品
        _D.YanDtUpdateSv(m_cccpDt)
        '删除刚才剔除的产出产品
        Dim sql As String = "delete from tb_gxcccp where tb_gxcccp_gxbs=" & m_gxid & " and tb_gxcccp_ID not in (" & m_cccpDt.YanDtToStr("tb_gxcccp_ID") & ")"
        sql.YanDbExe()

        '更新工序标识
        For Each dr As DataRow In m_fjxxDt.Rows
            dr("tb_gxfjxx_gxbs") = m_gxid
        Next
        '更新附加信息
        _D.YanDtUpdateSv(m_fjxxDt)
        '删除刚才剔除的附加信息
        sql = "delete from tb_gxfjxx where tb_gxfjxx_gxbs=" & m_gxid &
            IIf(m_fjxxDt.Rows.Count = 0, "", " and tb_gxfjxx_ID not in (" & m_fjxxDt.YanDtToStr("tb_gxfjxx_ID") & ")")
        sql.YanDbExe()

        Me.DialogResult = DialogResult.OK
    End Sub
End Class