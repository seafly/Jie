Imports System.Linq
Imports Cabio.BLL.Crafts
Imports Cabio.Model.Crafts
Imports Cabio.BLL.Produce
Imports Cabio.Model.Produce

Public Class FrWpAdd
    ''' <summary>
    ''' 修改标识
    ''' </summary>
    Public m_xgid As Integer = 0
    ''' <summary>
    '''父窗体
    ''' </summary>
    Private m_frOpen As FrbcList = CType(Application.OpenForms.Item("FrbcList"), FrbcList)
    ''' <summary>
    ''' 附加信息数据
    ''' </summary>
    Public m_fjxxDt As DataTable = Nothing
    ''' <summary>
    ''' 原料数据
    ''' </summary>
    Public m_ylDt As DataTable = Nothing
    ''' <summary>
    ''' 产出物品数据
    ''' </summary>
    Public m_cccpDt As DataTable = Nothing
    ''' <summary>
    ''' 产品代码汇总数据
    ''' </summary>
    Private m_hzDm As DataTable = Nothing
    Private m_strCplb As String = "BC成品"
    ''' <summary>
    ''' 构造函数
    ''' </summary>
    Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()

        m_hzDm = G_SYCPDMB.Select("tb_cpdmhz_cpxz='" & m_strCplb & "'").YanArrDrToDb()
        '先检查该工序是否有附加信息

        'Dim Service As New CraftsInfoService()
        'Service.getCraftsInfoList(工艺设置ID)

        Dim sql As String = "select * from tb_gxfjxx where tb_gxfjxx_gxbs=" & m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID") & " order by tb_gxfjxx_ID"
        m_fjxxDt = sql.YanGetDb
        If m_fjxxDt.Rows.Count = 0 Then
            GroupBox1.Location = New Point(GroupBox1.Location.X, GroupBox1.Location.Y - GroupBoxFjxx.Height)
            GroupBox1.Height += GroupBoxFjxx.Height
            Me.Controls.Remove(GroupBoxFjxx)
        End If
        showConTrols_fjxx()
        showConTrols_yl()
    End Sub
    Private Sub for_reszi(sender As Object, e As EventArgs) Handles MyBase.Resize
        MyBase.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        GroupBoxFjxx.Height = 20 + Int(m_fjxxDt.Rows.Count / 5 + IIf(m_fjxxDt.Rows.Count Mod 5 = 0, 0, 1)) * 33
        GroupBoxFjxx.Height = IIf(m_fjxxDt.Rows.Count = 0, 0, GroupBoxFjxx.Height)

        GroupBox1.Location = New Point(GroupBox1.Location.X, GroupBoxFjxx.Location.Y + GroupBoxFjxx.Height + 10)
        GroupBox1.Height = 20 + Int(m_ylDt.Rows.Count / 3 + IIf(m_ylDt.Rows.Count Mod 3 = 0, 0, 1)) * 33
        GroupBox1.Height = IIf(GroupBox1.Height < 200, 200, GroupBox1.Height)

        showConTrols_cp()
        Label5.Location = New Point(5, GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10)
        tb_sc_bz.Location = New Point(Label5.Location.X + Label1.Width + 10, GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10)

        Label1.Location = New Point(5, GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10 + 30)
        tb_sc_etime.Location = New Point(Label1.Location.X + Label1.Width + 10, GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10 + 30)
        Label4.Location = New Point(tb_sc_etime.Location.X + tb_sc_etime.Width + 10, GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10 + 30)
        tb_sc_isEnd.Location = New Point(Label4.Location.X + Label4.Width + 10, GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10 + 30)
        Button1.Location = New Point(Int(Me.Width / 2) - Int(Button1.Width / 2), GroupBox1.Location.Y + GroupBox1.Height + 10 + 200 + 10 + 30)
        Button2.Location = New Point(Button1.Location.X + 100, Button1.Location.Y)
    End Sub
    ''' <summary>
    '''窗体LOAD
    ''' </summary>
    Private Sub FrWpAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_sc_etime.BringToFront()
        tb_sc_etime.BringToFront()
        tb_sc_ftime.Controls(1).BackColor = Color.Wheat
        tb_sc_etime.Controls(1).BackColor = Color.Wheat

        'GroupBox2.Text = "产出" & m_frOpen.m_gxDr("tb_wp_pm")
        Me.Text = m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_mc") & "生产"
        tb_sc_isEnd.Text = en_sczt.待定.ToString
        If m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_isMod") = "否" Then
            tb_sc_isEnd.Text =en_sczt.完成.ToString
            tb_sc_isEnd.Enabled = False
        End If
        If m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_isBf") = "否" Then
            button2.Visible=False
        End If
        setKjVa()
        tb_sc_ftime.BringToFront()
        tb_sc_etime.BringToFront()
        '生产单号
        If m_xgid = 0 Then
            tb_sc_dh.Text = cl_YanMd.getBmVa("生产单号", "tb_gxsz", m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID"), True)
        End If
        AddHandler tb_sc_dh.DoubleClick, Sub()
                                             tb_sc_dh.Text = cl_YanMd.getBmVa("生产单号", "tb_gxsz", m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID"), True)
                                         End Sub
        cl_YanMd.setEnbleContrName(Me)
    End Sub
    ''' <summary>
    ''' 添加附加信息
    ''' </summary>
    Private Sub showConTrols_fjxx()
        Dim dt As DataTable = m_fjxxDt
        Dim objPoint As New System.Drawing.Point(5, 20)
        '循环检测项目
        For i As Integer = 0 To dt.Rows.Count - 1
            '先加文本
            Dim objLabel As New Label
            objLabel.Text = dt.Rows(i)("tb_gxfjxx_mc")
            objLabel.Height = 23
            objLabel.Width = 100
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            GroupBoxFjxx.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '在加控件
            Dim tControl As Control
            Select Case dt.Rows(i)("tb_gxfjxx_lx").ToString
                Case en_fjxxLx.数字.ToString
                    tControl = New yanTextBox
                    CType(tControl, yanTextBox).m_vaMin = dt.Rows(i)("tb_gxfjxx_vamin").ToString
                    CType(tControl, yanTextBox).m_vaMax = dt.Rows(i)("tb_gxfjxx_vamax").ToString
                    CType(tControl, yanTextBox).m_blVapd = True
                Case en_fjxxLx.文本.ToString
                    tControl = New TextBox
                    tControl.Text = dt.Rows(i)("tb_gxfjxx_vadef").ToString
                    tControl.ForeColor = Color.FromArgb(180, 180, 180)
                    AddHandler CType(tControl, TextBox).TextChanged, Sub(sender As Object, e As EventArgs)
                                                                         sender.ForeColor = Color.FromArgb(0, 0, 0)
                                                                     End Sub
                    AddHandler CType(tControl, TextBox).DoubleClick, Sub(sender As Object, e As EventArgs)
                                                                         sender.ForeColor = Color.FromArgb(0, 0, 0)
                                                                         CType(sender, TextBox).Focus()
                                                                         CType(sender, TextBox).Select(CType(sender, TextBox).TextLength, 0)
                                                                     End Sub
                Case en_fjxxLx.批号.ToString
                    Dim arrStr As String() = dt.YanDtValue2("tb_gxfjxx_dxz").Split(",")

                    tControl = New ComboBox
                    CType(tControl, ComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                    CType(tControl, ComboBox).FormattingEnabled = True
                    For Each s As String In arrStr
                        CType(tControl, ComboBox).Items.Add(cl_YanMd.getBmVa(s, "zdy", 0))
                    Next
                    Dim menu1 As New ContextMenuStrip
                    menu1.Items.Add("刷新")
                    AddHandler menu1.Items(0).Click, Sub(send As ToolStripMenuItem, ev As EventArgs)
                                                         Dim iNum As Integer = CType(tControl, ComboBox).SelectedIndex
                                                         If iNum >= 0 And iNum < arrStr.Length Then
                                                             cl_YanMd.getBmVa(arrStr(iNum), "zdy", 0, True)
                                                             CType(tControl, ComboBox).Items(CType(tControl, ComboBox).SelectedIndex) =
                                                                 cl_YanMd.getBmVa(arrStr(iNum), "zdy", 0)
                                                         End If
                                                     End Sub
                    CType(tControl, ComboBox).ContextMenuStrip = menu1
                Case en_fjxxLx.选择.ToString
                    tControl = New ComboBox
                    CType(tControl, ComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                    CType(tControl, ComboBox).FormattingEnabled = True
                    CType(tControl, ComboBox).Items.AddRange( _
                    dt.Rows(i)("tb_gxfjxx_dxz").ToString.Replace(vbCrLf, ",").Replace(Chr(13), "").Replace(Chr(10), "").Split(","))
                Case en_fjxxLx.时间.ToString
                    tControl = New chencontrol.chendatepick
                    If dt.YanDtValue2("tb_gxfjxx_isbx", i) = "是" Then
                        tControl.BackColor = Color.Wheat
                        tControl.Controls(1).BackColor = Color.Wheat
                    End If
                    If dt.Rows(i)("tb_gxfjxx_vadef").ToString = "" Then
                        tControl.Text = ""
                    End If
                Case Else
                    tControl = New TextBox
            End Select
            If dt.YanDtValue2("tb_gxfjxx_isbx", i) = "是" Then
                tControl.BackColor = Color.Wheat
            End If
            tControl.Name = "fjxx" & dt.Rows(i)("tb_gxfjxx_ID")
            tControl.Tag = dt.Rows(i).YanDrToDb
            tControl.Width = 130
            tControl.Location = objPoint

            GroupBoxFjxx.Controls.Add(tControl)
            If dt.YanDtValue2("tb_gxfjxx_lx", i) = "时间" Then
                tControl.Parent = Me
                tControl.Location = New Point(GroupBoxFjxx.Location.X + tControl.Location.X, GroupBoxFjxx.Location.Y + tControl.Location.Y)
                tControl.BringToFront()
            End If

            objPoint.X += tControl.Width

            objPoint.X = IIf((i + 1) Mod 5 = 0, 5, objPoint.X + 10)
            objPoint.Y += IIf((i + 1) Mod 5 = 0, tControl.Height + 10, 0)
        Next
    End Sub
    ''' <summary>
    ''' 添加产出产品控件
    ''' </summary>
    Private Sub showConTrols_cp()
        If m_cccpDt IsNot Nothing Then
            Return
        End If
        '先检查产出产品的数目

        'Dim Service As New CraftsProductService()
        'Service.GetCraftsProductList(工艺设置ID)

        Dim sql As String = "select b.tb_wp_pm,b.tb_wp_dm,b.tb_wp_wpfl,b.tb_wp_ID,a.* from tb_gxcccp as a left join tb_wp as b on a.tb_gxcccp_wpbs=b.tb_wp_ID " &
            " where tb_gxcccp_gxbs=" & m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID")
        m_cccpDt = sql.YanGetDb

        For i As Integer = 0 To m_cccpDt.Rows.Count - 1
            Dim w As Integer = GroupBox1.Width / m_cccpDt.Rows.Count
            Dim iWpbs As Integer = m_cccpDt.YanDtValue2("tb_wp_ID", i)
            '添加GROUP
            Dim tGroup As New GroupBox
            tGroup.Name = "groupCp" & iWpbs
            tGroup.Text = m_cccpDt.YanDtValue2("tb_wp_pm", i)
            tGroup.Width = w
            tGroup.Height = 200
            tGroup.Location = New Point(GroupBox1.Location.X + i * w, GroupBox1.Location.Y + GroupBox1.Height + 10)
            tGroup.Text = m_cccpDt.YanDtValue2("tb_wp_pm", i)
            Me.Controls.Add(tGroup)

            Dim objPoint As New System.Drawing.Point(5, 20)
            '添加lable
            Dim objLabel As New Label
            objLabel.Name = "lb_tb_gxcccp_ccps" & iWpbs
            objLabel.Text = "批数"
            objLabel.Height = 23
            objLabel.Width = 30
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            tGroup.Controls.Add(objLabel)
            objPoint.X += objLabel.Width
            '添加产出产品控件
            Dim tControl As New ComboBox
            tControl.Name = "tb_gxcccp_ccps" & iWpbs
            tControl.Tag = m_cccpDt.Rows(i).YanDrToDb
            tControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            tControl.FormattingEnabled = True
            tControl.Items.AddRange(_S.getNumToStr(IIf(i = 0, 1, 0), 5).Split(","))
            If m_cccpDt.YanDtValue2("tb_gxcccp_isdp", i) = "否" Then
                CType(tControl, ComboBox).Enabled = False
            End If
            tControl.Location = objPoint
            tGroup.Controls.Add(tControl)
            AddHandler tControl.SelectedIndexChanged, AddressOf SelectedChanged_ev
            tControl.Text = IIf(CInt(m_cccpDt.YanDtValue2("tb_gxcccp_ccps", i)) > 0, m_cccpDt.YanDtValue2("tb_gxcccp_ccps", i), IIf(i = 0, 1, 0))
        Next
    End Sub
    '''<summary>
    ''' 添加原料控件
    ''' </summary>
    Private Sub showConTrols_yl()
        Dim sql As String = ""
        Dim dt As DataTable

        '多种产出的原料是一样的，所以只需要按第一种产出添加原料
        sql = "select * from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm where tb_mrp_cpbs=(select top 1 tb_gxcccp_wpbs " &
            "from tb_gxcccp where tb_gxcccp_gxbs='" & m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID") & "') and tb_mrp_xz=1 order by tb_mrp_wpdm"
        dt = _D.GF_CreateDataSource(sql)
        m_ylDt = dt
        Dim objPoint As New System.Drawing.Point(5, 20)
        '循环检测项目
        For i As Integer = 0 To dt.Rows.Count - 1
            '先加文本
            Dim objLabel As New Label
            objLabel.Text = dt.YanDtValue2("tb_wp_pm", i) & IIf(dt.YanDtValue2("tb_mrp_yllx", i) = "返工", "(返工)", "")
            objLabel.Height = 23
            objLabel.Width = 100
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            GroupBox1.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '再加控件
            Dim tControl As New TextBox
            If dt.YanDtValue2("tb_mrp_isbx", i) = "是" Then
                tControl.BackColor = Color.Wheat
            End If
            tControl.ReadOnly = True
            tControl.Name = "wp" & dt.YanDtValue2("tb_mrp_ID", i)
            tControl.Tag = dt.Rows(i).YanDrToDb
            tControl.Width = 130
            tControl.Location = objPoint
            GroupBox1.Controls.Add(tControl)
            objPoint.X += tControl.Width
            AddHandler tControl.DoubleClick, AddressOf addCpph

            '重量文本
            objLabel = New Label
            objLabel.Text = "重量"
            objLabel.Height = 23
            objLabel.Width = 30
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            GroupBox1.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '重量控件
            tControl = New TextBox
            If dt.YanDtValue2("tb_mrp_isbx", i) = "是" Then
                tControl.BackColor = Color.Wheat
            End If
            tControl.ReadOnly = True
            tControl.Name = "wp" & dt.YanDtValue2("tb_mrp_ID", i) & "t"
            tControl.Width = 80
            tControl.Location = objPoint
            GroupBox1.Controls.Add(tControl)
            '隐藏的标识字段
            tControl = New TextBox
            tControl.Visible = False
            tControl.Name = "wp" & dt.YanDtValue2("tb_mrp_ID", i) & "bs"
            GroupBox1.Controls.Add(tControl)

            objPoint.X = IIf((i + 1) Mod 3 = 0, 5, objPoint.X + tControl.Width + 30)
            objPoint.Y += IIf((i + 1) Mod 3 = 0, tControl.Height + 10, 0)
        Next

    End Sub
    ''' <summary>
    ''' 双击添加原料的过程
    ''' </summary>
    Sub addCpph(sender As Object, e As EventArgs)
        Dim tStrBiao As String = ""
        Dim sql As String = ""
        Dim czDt As DataTable = CType(sender.tag, DataTable).Rows(0).YanDrToDb
        Select Case czDt.YanDtValue2("tb_wp_wpfl")
            Case en_wpfl.过程品.ToString, en_wpfl.成品.ToString
                '过程品，成品，根据物品设置里的属性，判断是否需要取QC,QA的状态
                Dim strWhere As String = ""
                If czDt.YanDtValue2("tb_wp_isqc") = "是" Then
                    strWhere &= "and tb_wlphck_wlbs in (select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_sfsh='是' and tb_QcJc_jcb='tb_wlph')"
                End If

                'QA状态要先判断是否返工
                If czDt.YanDtValue2("tb_mrp_yllx") = "返工" Then
                    strWhere &= "and tb_wlphck_yt='返工'"
                    If czDt.YanDtValue2("tb_wp_isqa") = "是" Then
                        strWhere &= "and tb_wlphck_wlbs in (select tb_qa_wlbs from tb_qa where tb_qa_qaspjg='合格' or tb_qa_qaspjg='不合格')"
                    End If
                Else
                    strWhere &= "and tb_wlphck_yt<>'返工'"
                    If czDt.YanDtValue2("tb_wp_isqa") = "是" Then
                        strWhere &= "and tb_wlphck_wlbs in (select tb_qa_wlbs from tb_qa where tb_qa_qaspjg='合格')"
                    End If
                End If

                sql = "select 0 as 使用重量,tb_wlphck_wlph,tb_wlphck_cjcl,tb_wp_dw as 单位,tb_wlphck_ID " &
                    "from tb_wlphck as a left join tb_wp as b on a.tb_wlphck_wpbs=b.tb_wp_ID" &
                    " where tb_wlphck_cjcl>0 and tb_wp_sfyx='是' and tb_wlphck_wpbs='" & czDt.YanDtValue2("tb_wp_ID") & "' " & strWhere

                Dim dt As DataTable = sql.YanGetDb
                Dim objClpam As New frYanPhzl.CLphzlPam
                objClpam.souserDt = dt
                objClpam.titleText = czDt.YanDtValue2("tb_wp_pm")
                objClpam.colHide = "tb_wlphck_ID"
                objClpam.phName = sender.name
                objClpam.bsName = sender.name & "bs"
                objClpam.numBs = 4
                GS_TCYLLIST_yan(Me, objClpam)
            Case Else
                sql = "select 0 as 使用重量,tb_i259b_num,tb_i259b_p518h,tb_i259b_h200z as 单位,tb_i259b_ID from tb_i259b " &
                    " where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' and tb_i259b_i231a='" & czDt.YanDtValue3("tb_wp_dm") & "'"
                Dim dt As DataTable = sql.YanGetDb
                Dim objClpam As New frYanPhzl.CLphzlPam
                objClpam.souserDt = dt
                objClpam.titleText = czDt.YanDtValue2("tb_wp_pm")
                objClpam.colHide = "tb_i259b_ID"
                objClpam.phName = sender.name
                objClpam.bsName = sender.name & "bs"
                objClpam.numBs = 4
                GS_TCYLLIST_yan(Me, objClpam)
        End Select
    End Sub
    ''' <summary>
    ''' 选择产出批数的过程
    ''' </summary>
    Private Sub SelectedChanged_ev(sender As ComboBox, e As EventArgs)
        CType(sender.Parent, GroupBox).Controls.Cast(Of Control)().Where(
            Function(c) c.Name <> sender.Name And c.Name <> "lb_" & sender.Name).ToList().ForEach(Sub(c) sender.Parent.Controls.Remove(c))
        Dim iWpbs As Integer = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_ID")
        Dim strWpmc As String = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_pm")

        Dim objPoint As New System.Drawing.Point(5, 50)
        For i As Integer = 0 To sender.Text - 1
            '添加产出产品控件
            Dim objLabel As New Label
            objLabel.Name = "phLable" & iWpbs & "_" & i
            objLabel.Text = "批号"
            objLabel.Height = 23
            objLabel.Width = 30
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            sender.Parent.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '再加控件
            Dim tControl As New TextBox
            tControl.BackColor = Color.Wheat
            tControl.Name = "ph" & iWpbs & "_" & i
            tControl.Width = 80
            tControl.Location = objPoint
            sender.Parent.Controls.Add(tControl)
            objPoint.X += tControl.Width

            '重量文本
            objLabel = New Label
            objLabel.Name = "zlLable" & iWpbs & "_" & i
            objLabel.Text = "重量"
            objLabel.Height = 23
            objLabel.Width = 30
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            sender.Parent.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '重量控件
            tControl = New yanTextBox
            tControl.BackColor = Color.Wheat
            tControl.Text = ""
            tControl.Name = "zl" & iWpbs & "_" & i
            tControl.Width = 40
            tControl.Location = objPoint
            sender.Parent.Controls.Add(tControl)

            '如果是成品，添加产品类型，产品代码，加工代码
            objPoint.X += tControl.Width
            '产品类别文本
            objLabel = New Label
            objLabel.Name = "cplbLable" & iWpbs & "_" & i
            objLabel.Text = "产品类型"
            objLabel.Height = 23
            objLabel.Width = 60
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            objLabel.Visible = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_wpfl") = en_wpfl.成品.ToString()
            sender.Parent.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '产品类别控件
            Dim tComboBox As New ComboBox
            tComboBox.Name = "cplb" & iWpbs & "_" & i
            tComboBox.Width = 80
            tComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            tComboBox.Location = objPoint
            tComboBox.Visible = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_wpfl") = en_wpfl.成品.ToString()
            sender.Parent.Controls.Add(tComboBox)
            objPoint.X += tComboBox.Width

            '产品代码文本
            objLabel = New Label
            objLabel.Name = "mingcLable" & iWpbs & "_" & i
            objLabel.Text = "产品代码"
            objLabel.Height = 23
            objLabel.Width = 60
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            objLabel.Visible = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_wpfl") = en_wpfl.成品.ToString()
            sender.Parent.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '产品代码控件
            tComboBox = New ComboBox
            tComboBox.Name = "mingc" & iWpbs & "_" & i
            tComboBox.Width = 80
            tComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            tComboBox.Location = objPoint
            tComboBox.Visible = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_wpfl") = en_wpfl.成品.ToString()
            sender.Parent.Controls.Add(tComboBox)
            objPoint.X += tComboBox.Width

            '加工代码文本
            objLabel = New Label
            objLabel.Name = "jiagdmLable" & iWpbs & "_" & i
            objLabel.Text = "加工代码"
            objLabel.Height = 23
            objLabel.Width = 60
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            objLabel.Visible = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_wpfl") = en_wpfl.成品.ToString()
            sender.Parent.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '加工代码控件
            tComboBox = New ComboBox
            tComboBox.Name = "jiagdm" & iWpbs & "_" & i
            tComboBox.Width = 80
            tComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
            tComboBox.Visible = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_wpfl") = en_wpfl.成品.ToString()
            tComboBox.Location = objPoint
            sender.Parent.Controls.Add(tComboBox)

            '物品标识
            tControl = New TextBox
            tControl.Visible = False
            tControl.Name = "wpbs" & iWpbs & "_" & i
            tControl.Text = CType(sender.Tag, DataTable).YanDtValue2("tb_gxcccp_wpbs")
            sender.Parent.Controls.Add(tControl)
            '物品代码
            tControl = New TextBox
            tControl.Visible = False
            tControl.Name = "wpdm" & iWpbs & "_" & i
            tControl.Text = CType(sender.Tag, DataTable).YanDtValue2("tb_wp_dm")
            sender.Parent.Controls.Add(tControl)

            objPoint.X = 5
            objPoint.Y += 30

            Dim strCorbs = iWpbs & "_" & i

            AddHandler CType(Me.YanFindControl("ph" & strCorbs), TextBox).DoubleClick,
                Sub(send As TextBox, ev As EventArgs)
                    send.Text = cl_YanMd.getBmVa(strWpmc & "批号", "tb_wp", iWpbs, True, Me)
                End Sub

            AddHandler CType(Me.YanFindControl("cplb" & strCorbs), ComboBox).SelectedIndexChanged,
            Sub(send As ComboBox, ev As EventArgs)
                If m_hzDm.Rows.Count = 0 Then
                    Return
                End If
                CType(Me.YanFindControl("mingc" & strCorbs), ComboBox).DataSource =
                m_hzDm.Select("tb_cpdmhz_cpxz='" & m_strCplb & "' and tb_cpdmhz_cplx='" & send.Text & "'").YanArrDrToDb.YanDtToStr("tb_cpdmhz_cpdm").Split(",").YanArrQc
            End Sub
            AddHandler CType(Me.YanFindControl("mingc" & strCorbs), ComboBox).SelectedIndexChanged,
            Sub(send As ComboBox, ev As EventArgs)
                If m_hzDm.Rows.Count = 0 Then
                    Return
                End If
                CType(Me.YanFindControl("jiagdm" & strCorbs), ComboBox).DataSource =
                m_hzDm.Select("tb_cpdmhz_cpxz='" & m_strCplb & "' and tb_cpdmhz_cpdm='" & send.Text & "'").YanArrDrToDb.YanDtToStr("tb_cpdmhz_jgdm").Split(",").YanArrQc
            End Sub
            CType(Me.YanFindControl("cplb" & strCorbs), ComboBox).DataSource = m_hzDm.YanDtToStr("tb_cpdmhz_cplx").Split(",").YanArrQc.YanArrAdd("", 0)
            cl_YanMd.setEnbleContrName(sender.Parent)
        Next
    End Sub
    ''' <summary>
    ''' 填充窗体值
    ''' </summary>
    Private Sub setKjVa()
        '主窗体

        'Dim produceService As New ProduceService()
        'produceService.GetObject()

        Dim sql As String = "select * from tb_sc where tb_sc_ID=" & m_xgid
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        _D.YanDtSetFrCon(Me, dt)
        '附加信息

        Dim producedetailService As New ProduceDetailService()
        producedetailService.GetInfoList("附加信息", "")


        sql = "select * from tb_scxq as a left join tb_gxfjxx as b on a.tb_scxq_xxbs=b.tb_gxfjxx_ID where tb_scxq_lx='附加信息' and tb_scxq_scbs=" & m_xgid
        dt = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim tContr As Control = Me.YanFindControl("fjxx" & dt.YanDtValue2("tb_scxq_xxbs", i))
            If tContr Is Nothing Then
                Continue For
            End If
            If dt.YanDtValue2("tb_gxfjxx_lx", i) = en_fjxxLx.批号.ToString Then
                CType(tContr, ComboBox).Items.Add(dt.YanDtValue2("tb_scxq_value", i))
            End If
            tContr.Text = dt.YanDtValue3("tb_scxq_value", i)
        Next
        '投料信息

        producedetailService.GetInfoList("投料", "")

        sql = "select * from tb_scxq where tb_scxq_lx='投料' and tb_scxq_scbs=" & m_xgid
        dt = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim arrStr As String() = dt.YanDtValue2("tb_scxq_value", i).Split("|")
            If arrStr.Length <> 3 Then
                Continue For
            End If
            If GroupBox1.YanFindControl("wp" & dt.YanDtValue2("tb_scxq_xxbs", i)) Is Nothing Then
                Continue For
            End If
            GroupBox1.YanFindControl("wp" & dt.YanDtValue2("tb_scxq_xxbs", i)).Text = arrStr(0)
            GroupBox1.YanFindControl("wp" & dt.YanDtValue2("tb_scxq_xxbs", i) & "t").Text = arrStr(1)
            GroupBox1.YanFindControl("wp" & dt.YanDtValue2("tb_scxq_xxbs", i) & "bs").Text = arrStr(2)
        Next
        '产出信息

        producedetailService.GetInfoList("产出", "")

        sql = "select * from tb_scxq where tb_scxq_lx='产出' and tb_scxq_scbs=" & m_xgid
        dt = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim arrStr As String() = dt.YanDtValue2("tb_scxq_value", i).Split("|")
            If arrStr.Length <> 6 Then
                Continue For
            End If

            Me.YanFindControl("ph" & dt.YanDtValue2("tb_scxq_xxbs", i) & "_" & arrStr(0)).Text = arrStr(1)
            Me.YanFindControl("zl" & dt.YanDtValue2("tb_scxq_xxbs", i) & "_" & arrStr(0)).Text = arrStr(2)
            Me.YanFindControl("cplb" & dt.YanDtValue2("tb_scxq_xxbs", i) & "_" & arrStr(0)).Text = arrStr(3)
            Me.YanFindControl("mingc" & dt.YanDtValue2("tb_scxq_xxbs", i) & "_" & arrStr(0)).Text = arrStr(4)
            Me.YanFindControl("jiagdm" & dt.YanDtValue2("tb_scxq_xxbs", i) & "_" & arrStr(0)).Text = arrStr(5)
        Next
        'sql = "select * from tb_wlph where tb_wlph_cjtb='tb_sc' and tb_wlph_cjbs=" & m_xgid & " order by tb_wlph_ID"
        'dt = sql.YanGetDb
        'If dt.Rows.Count > 0 Then
        '    For i As Integer = 0 To m_cccpDt.Rows.Count - 1
        '        Dim tGroup As GroupBox = Me.YanFindControl("groupCp" & i)
        '        Dim wpbs As String = CType(tGroup.YanFindControl("tb_gxcccp_ccps" & i).Tag, DataTable).YanDtValue2("tb_wp_ID")
        '        Dim tDtTm As DataTable = dt.Select("tb_wlph_wpbs=" & wpbs).YanArrDrToDb
        '        tGroup.YanFindControl("tb_gxcccp_ccps" & i).Text = tDtTm.Rows.Count
        '        For j As Integer = 0 To tDtTm.Rows.Count - 1
        '            tGroup.YanFindControl("ph" & j).Text = tDtTm.YanDtValue2("tb_wlph_wlph", j)
        '            tGroup.YanFindControl("zl" & j).Text = tDtTm.YanDtValue2("tb_wlph_sl", j)
        '        Next
        '    Next
        'End If
    End Sub
    ''' <summary>
    ''' 提交的过程
    ''' </summary>
    Private Function saveFrom() As Boolean

        'Dim Service As New ProduceService()
        'Service.Save()

        '检查表单必填项
        If CheckControlNull(Me) = False Then
            Return False
        End If
        If m_xgid > 0 Then
            If _D.isRowNull("tb_sc", "tb_sc_dh='" & tb_sc_dh.Text.Trim & "'  and tb_sc_ID<>" & m_xgid) Then
                MsgBox("已经存在的生产单号！", MsgBoxStyle.Exclamation)
                Return False
            End If
        Else
            If _D.isRowNull("tb_sc", "tb_sc_dh='" & tb_sc_dh.Text.Trim & "'") Then
                MsgBox("已经存在的生产单号！", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
        '检查原料必填项
        If CheckControlNull(GroupBox1) = False Then
            Return False
        End If
        '检查附加信息必填项
        If CheckControlNull(GroupBoxFjxx) = False Then
            Return False
        End If
        '检查产出产品必填项
        For i As Integer = 0 To m_cccpDt.Rows.Count - 1
            Dim iWpbs As Integer = m_cccpDt.YanDtValue2("tb_wp_ID", i)
            Dim group As GroupBox = Me.YanFindControl("groupCp" & iWpbs)
            If CheckControlNull(group) = False Then
                Return False
            End If
            '验证批号是否已经存在
            For j As Integer = 0 To group.YanFindControl("tb_gxcccp_ccps" & iWpbs).Text - 1
                If m_xgid > 0 Then
                    If _D.isRowNull("tb_wlph", "tb_wlph_wpbs=" & group.YanFindControl("wpbs" & iWpbs & "_" & j).Text &
                                    " and tb_wlph_wlph='" & group.YanFindControl("ph" & iWpbs & "_" & j).Text & "' " &
                                    "and not (tb_wlph_cjbs=" & m_xgid & " and tb_wlph_cjtb='tb_sc')") Then
                        MsgBox("已经存在的批号！", MsgBoxStyle.Exclamation)
                        Return False
                    End If
                Else
                    If _D.isRowNull("tb_wlph", "tb_wlph_wpbs=" & group.YanFindControl("wpbs" & iWpbs & "_" & j).Text &
                    " and tb_wlph_wlph='" & group.YanFindControl("ph" & iWpbs & "_" & j).Text & "'") Then
                        MsgBox("已经存在的批号！", MsgBoxStyle.Exclamation)
                        Return False
                    End If
                End If
            Next
        Next

        Dim dic As New Dictionary(Of String, String)
        Dim strNewBs As String = ""
        '启用事物
        Dim mt As New _D.myTransaction
        Try
            '写入生产表
            dic = New Dictionary(Of String, String)
            dic("tb_sc_ftime") = tb_sc_ftime.Text
            dic("tb_sc_etime") = tb_sc_etime.Text
            dic("tb_sc_czrgh") = G_dlrgh
            dic("tb_sc_gxbs") = m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID")
            dic("tb_sc_isEnd") = tb_sc_isEnd.Text
            dic("tb_sc_dh") = tb_sc_dh.Text
            dic("tb_sc_bz") = tb_sc_bz.Text
            '生产标识
            Dim iScbs As Integer = 0
            If m_xgid > 0 Then
                iScbs = m_xgid
                mt.update("tb_sc", dic, "tb_sc_ID=" & m_xgid)
            Else
                iScbs = mt.insert("tb_sc", dic)
            End If
            '写入生产详情表(附加信息)
            If m_xgid > 0 Then
                mt.dbExe("delete from tb_scxq where tb_scxq_lx='附加信息' and tb_scxq_scbs=" & iScbs)
            End If
            For i As Integer = 0 To m_fjxxDt.Rows.Count - 1
                dic = New Dictionary(Of String, String)
                Dim tContr As Control = Me.YanFindControl("fjxx" & m_fjxxDt.YanDtValue2("tb_gxfjxx_ID", i))
                dic("tb_scxq_xxbs") = CType(tContr.Tag, DataTable).YanDtValue2("tb_gxfjxx_ID")
                dic("tb_scxq_text") = CType(tContr.Tag, DataTable).YanDtValue2("tb_gxfjxx_mc")
                dic("tb_scxq_value") = tContr.Text
                dic("tb_scxq_lx") = "附加信息"
                dic("tb_scxq_scbs") = iScbs
                mt.insert("tb_scxq", dic)
            Next
            '写入生产详情表(投料信息)
            If m_xgid > 0 Then
                mt.dbExe("delete from tb_scxq where tb_scxq_lx='投料' and tb_scxq_scbs=" & iScbs)
            End If
            For Each c As Control In GroupBox1.Controls
                If c.Tag IsNot Nothing And c.Text <> "" Then
                    dic = New Dictionary(Of String, String)
                    dic("tb_scxq_xxbs") = CType(c.Tag, DataTable).YanDtValue2("tb_mrp_ID")
                    dic("tb_scxq_text") = CType(c.Tag, DataTable).YanDtValue2("tb_wp_pm") & IIf(CType(c.Tag, DataTable).YanDtValue2("tb_mrp_yllx") = "返工", "(返工)", "")
                    '批号，重量，库存标识
                    dic("tb_scxq_value") = c.Text & "|" & GroupBox1.YanFindControl(c.Name & "t").Text & "|" & GroupBox1.YanFindControl(c.Name & "bs").Text
                    dic("tb_scxq_scbs") = iScbs
                    mt.insert("tb_scxq", dic)
                End If
            Next
            '写入生产详情表(产出信息)
            If m_xgid > 0 Then
                mt.dbExe("delete from tb_scxq where tb_scxq_lx='产出' and tb_scxq_scbs=" & iScbs)
            End If
            For i As Integer = 0 To m_cccpDt.Rows.Count - 1
                Dim iWpbs As Integer = m_cccpDt.YanDtValue2("tb_wp_ID", i)
                Dim group As GroupBox = Me.YanFindControl("groupCp" & iWpbs)
                For j As Integer = 0 To group.YanFindControl("tb_gxcccp_ccps" & iWpbs).Text - 1
                    '写入批号表
                    dic = New Dictionary(Of String, String)
                    dic("tb_scxq_xxbs") = iWpbs
                    dic("tb_scxq_text") = m_cccpDt.YanDtValue2("tb_wp_pm", i)
                    '序号,批号，重量，库存标识
                    dic("tb_scxq_value") = j & "|" & group.YanFindControl("ph" & iWpbs & "_" & j).Text & "|" & group.YanFindControl("zl" & iWpbs & "_" & j).Text &
                        "|" & group.YanFindControl("cplb" & iWpbs & "_" & j).Text & "|" & group.YanFindControl("mingc" & iWpbs & "_" & j).Text & "|" &
                        group.YanFindControl("jiagdm" & iWpbs & "_" & j).Text
                    dic("tb_scxq_scbs") = iScbs
                    dic("tb_scxq_lx") = "产出"
                    Dim tWlbs As String = mt.insert("tb_scxq", dic)
                Next
            Next
            '如果是已经完成的,那么写入物料使用记录，并扣除对应重量
            If tb_sc_isEnd.Text = en_sczt.完成.ToString Then
                For i As Integer = 0 To m_cccpDt.Rows.Count - 1
                    Dim iWpbs As Integer = m_cccpDt.YanDtValue2("tb_wp_ID", i)
                    Dim group As GroupBox = Me.YanFindControl("groupCp" & iWpbs)
                    For j As Integer = 0 To group.YanFindControl("tb_gxcccp_ccps" & iWpbs).Text - 1
                        '写入批号表
                        dic = New Dictionary(Of String, String)
                        dic("tb_wlph_wpbs") = group.YanFindControl("wpbs" & iWpbs & "_" & j).Text
                        dic("tb_wlph_wpdm") = group.YanFindControl("wpdm" & iWpbs & "_" & j).Text
                        dic("tb_wlph_wlph") = group.YanFindControl("ph" & iWpbs & "_" & j).Text
                        dic("tb_wlph_sl") = group.YanFindControl("zl" & iWpbs & "_" & j).Text
                        dic("tb_wlph_cjbs") = iScbs
                        Dim tWlbs As String = mt.insert("tb_wlph", dic)
                        strNewBs &= tWlbs & ","
                        '批号入库
                        dic = New Dictionary(Of String, String)
                        dic("tb_wlphck_wpbs") = group.YanFindControl("wpbs" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_wlbs") = tWlbs
                        dic("tb_wlphck_wlph") = group.YanFindControl("ph" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_cjcl") = group.YanFindControl("zl" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_zzl") = group.YanFindControl("zl" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_kyzl") = group.YanFindControl("zl" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_cplb") = group.YanFindControl("cplb" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_mingc") = group.YanFindControl("mingc" & iWpbs & "_" & j).Text
                        dic("tb_wlphck_jiagdm") = group.YanFindControl("jiagdm" & iWpbs & "_" & j).Text
                        Dim tCzbs As String = mt.insert("tb_wlphck", dic)
                        '使用记录(入库)
                        dic = New Dictionary(Of String, String)
                        dic("tb_syjl_wpbs") = group.YanFindControl("wpbs" & iWpbs & "_" & j).Text
                        dic("tb_syjl_wpdm") = group.YanFindControl("wpdm" & iWpbs & "_" & j).Text
                        dic("tb_syjl_xz") = 1
                        dic("tb_syjl_yb") = "tb_wlph"
                        dic("tb_syjl_ybs") = tWlbs
                        dic("tb_syjl_wlph") = group.YanFindControl("ph" & iWpbs & "_" & j).Text
                        dic("tb_syjl_zl") = group.YanFindControl("zl" & iWpbs & "_" & j).Text
                        dic("tb_syjl_cjcl") = group.YanFindControl("zl" & iWpbs & "_" & j).Text
                        dic("tb_syjl_czlx") = "生产"
                        dic("tb_syjl_mbb") = "tb_wlphck"
                        dic("tb_syjl_czbs") = tCzbs
                        mt.insert("tb_syjl", dic)
                    Next
                Next

                strNewBs = strNewBs.YanRemovedh
                For Each c As Control In GroupBox1.Controls
                    If c.Tag IsNot Nothing And c.Text <> "" Then
                        Dim tDr As DataRow = CType(c.Tag, DataTable).Rows(0)
                        Dim strYb As String = ""   '扣除重量表
                        Dim strCjcl As String = ""   '车间存量字段
                        '写入使用记录（出库）
                        Select Case tDr("tb_wp_wpfl")
                            Case en_wpfl.过程品.ToString, en_wpfl.成品.ToString
                                strYb = "tb_wlphck"
                                strCjcl = "tb_wlphck_cjcl"
                            Case Else
                                strYb = "tb_i259b"
                                strCjcl = "tb_i259b_p518h"
                        End Select
                        Dim arrPh As String() = c.Text.Split(",")
                        Dim arrZl As String() = GroupBox1.YanFindControl(c.Name & "t").Text.Split(",")
                        Dim arrBs As String() = GroupBox1.YanFindControl(c.Name & "bs").Text.Split(",")
                        For i As Integer = 0 To arrPh.Length - 1
                            '判断重量是否足够
                            Dim iSycjcl As Decimal = Convert.ToDecimal(mt.getDb("select " & strCjcl & " from " & strYb & " where " & strYb & "_ID=" & arrBs(i)).YanDtValue2)
                            If iSycjcl - Convert.ToDecimal(arrZl(i)) < 0 Then
                                mt.Rollback()
                                mt.close()
                                MsgBox(tDr("tb_wp_pm") & "车间存量不足，无法完成！", MsgBoxStyle.Exclamation)
                                Return False
                            End If
                            '扣除重量
                            dic = New Dictionary(Of String, String)
                            dic("#" & strCjcl) = strCjcl & "-" & arrZl(i)
                            mt.update(strYb, dic, strYb & "_ID=" & arrBs(i), "#")
                            '使用记录(出库)
                            dic = New Dictionary(Of String, String)
                            dic("tb_syjl_wpbs") = tDr("tb_wp_ID")
                            dic("tb_syjl_wpdm") = tDr("tb_wp_dm")
                            dic("tb_syjl_xz") = 0
                            dic("tb_syjl_yb") = strYb
                            dic("tb_syjl_wlph") = arrPh(i)
                            dic("tb_syjl_zl") = arrZl(i)
                            dic("tb_syjl_cjcl") = arrZl(i)
                            dic("tb_syjl_ybs") = arrBs(i)
                            dic("tb_syjl_czlx") = "生产"
                            dic("tb_syjl_mbb") = "tb_wlph"
                            dic("tb_syjl_czbs") = strNewBs
                            mt.insert("tb_syjl", dic)
                        Next
                    End If
                Next
            End If
            mt.Commit()
        Catch ex As Exception
            mt.Rollback()
            mt.close()
            Return False
        Finally
            mt.close()
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 报废
    ''' </summary>
    Private Sub baofei()
        '检查表单必填项
        If CheckControlNull(Me) = False Then
            Return
        End If
        If MsgBox("确定报废吗？", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = vbNo Then
            Return
        End If
        If tb_sc_bz.Text.Trim="" Then
            MsgBox("报废时备注不能为空！", MsgBoxStyle.Exclamation)
            Return
        End If
        If m_xgid > 0 Then
            If _D.isRowNull("tb_sc", "tb_sc_dh='" & tb_sc_dh.Text.Trim & "'  and tb_sc_ID<>" & m_xgid) Then
                MsgBox("已经存在的生产单号！", MsgBoxStyle.Exclamation)
                Return
            End If
        Else
            If _D.isRowNull("tb_sc", "tb_sc_dh='" & tb_sc_dh.Text.Trim & "'") Then
                MsgBox("已经存在的生产单号！", MsgBoxStyle.Exclamation)
                Return
            End If
        End If

        Dim dic As New Dictionary(Of String, String)
        '启用事物
        Using mt As New _D.myTransaction
            '写入生产表
            dic = New Dictionary(Of String, String)
            dic("tb_sc_ftime") = tb_sc_ftime.Text
            dic("tb_sc_etime") = tb_sc_etime.Text
            dic("tb_sc_czrgh") = G_dlrgh
            dic("tb_sc_gxbs") = m_frOpen.m_gxszDt.YanDtValue2("tb_gxsz_ID")
            dic("tb_sc_isEnd") = en_sczt.报废.ToString
            dic("tb_sc_dh") = tb_sc_dh.Text
            dic("tb_sc_bz") = tb_sc_bz.Text
            '生产标识
            Dim iScbs As Integer = 0
            If m_xgid > 0 Then
                iScbs = m_xgid
                mt.update("tb_sc", dic, "tb_sc_ID=" & m_xgid)
            Else
                iScbs = mt.insert("tb_sc", dic)
            End If
            '写入生产详情表(附加信息)
            If m_xgid > 0 Then
                mt.dbExe("delete from tb_scxq where tb_scxq_lx='附加信息' and tb_scxq_scbs=" & iScbs)
            End If
            For i As Integer = 0 To m_fjxxDt.Rows.Count - 1
                dic = New Dictionary(Of String, String)
                Dim tContr As Control = GroupBoxFjxx.YanFindControl("fjxx" & m_fjxxDt.YanDtValue2("tb_gxfjxx_ID", i))
                dic("tb_scxq_xxbs") = CType(tContr.Tag, DataTable).YanDtValue2("tb_gxfjxx_ID")
                dic("tb_scxq_text") = CType(tContr.Tag, DataTable).YanDtValue2("tb_gxfjxx_mc")
                dic("tb_scxq_value") = tContr.Text
                dic("tb_scxq_lx") = "附加信息"
                dic("tb_scxq_scbs") = iScbs
                mt.insert("tb_scxq", dic)
            Next
            '写入生产详情表(投料信息)
            If m_xgid > 0 Then
                mt.dbExe("delete from tb_scxq where tb_scxq_lx='投料' and tb_scxq_scbs=" & iScbs)
            End If
            For Each c As Control In GroupBox1.Controls
                If c.Tag IsNot Nothing And c.Text <> "" Then
                    dic = New Dictionary(Of String, String)
                    dic("tb_scxq_xxbs") = CType(c.Tag, DataTable).YanDtValue2("tb_mrp_ID")
                    dic("tb_scxq_text") = CType(c.Tag, DataTable).YanDtValue2("tb_wp_pm")
                    '批号，重量，库存标识
                    dic("tb_scxq_value") = c.Text & "|" & GroupBox1.YanFindControl(c.Name & "t").Text & "|" & GroupBox1.YanFindControl(c.Name & "bs").Text
                    dic("tb_scxq_scbs") = iScbs
                    mt.insert("tb_scxq", dic)
                End If
            Next
            '写入生产详情表(产出信息)
            If m_xgid > 0 Then
                mt.dbExe("delete from tb_scxq where tb_scxq_lx='产出' and tb_scxq_scbs=" & iScbs)
            End If
            For i As Integer = 0 To m_cccpDt.Rows.Count - 1
                Dim iWpbs As Integer = m_cccpDt.YanDtValue2("tb_wp_ID", i)
                Dim group As GroupBox = Me.YanFindControl("groupCp" & iWpbs)
                For j As Integer = 0 To group.YanFindControl("tb_gxcccp_ccps" & iWpbs).Text - 1
                    '写入批号表
                    dic = New Dictionary(Of String, String)
                    dic("tb_scxq_xxbs") = iWpbs
                    dic("tb_scxq_text") = m_cccpDt.YanDtValue2("tb_wp_pm", i)
                    '序号,批号，重量，库存标识
                    dic("tb_scxq_value") = j & "|" & group.YanFindControl("ph" & iWpbs & "_" & j).Text & "|" & group.YanFindControl("zl" & iWpbs & "_" & j).Text &
                        "|" & group.YanFindControl("cplb" & iWpbs & "_" & j).Text & "|" & group.YanFindControl("mingc" & iWpbs & "_" & j).Text & "|" &
                        group.YanFindControl("jiagdm" & iWpbs & "_" & j).Text
                    dic("tb_scxq_scbs") = iScbs
                    dic("tb_scxq_lx") = "产出"
                    Dim tWlbs As String = mt.insert("tb_scxq", dic)
                Next
            Next
            For Each c As Control In GroupBox1.Controls
                If c.Tag IsNot Nothing And c.Text <> "" Then
                    Dim tDr As DataRow = CType(c.Tag, DataTable).Rows(0)
                    Dim strYb As String = ""   '扣除重量表
                    Dim strCjcl As String = ""   '车间存量字段
                    '写入使用记录（出库）
                    Select Case tDr("tb_wp_wpfl")
                        Case en_wpfl.过程品.ToString, en_wpfl.成品.ToString
                            strYb = "tb_wlphck"
                            strCjcl = "tb_wlphck_cjcl"
                        Case Else
                            strYb = "tb_i259b"
                            strCjcl = "tb_i259b_p518h"
                    End Select
                    Dim arrPh As String() = c.Text.Split(",")
                    Dim arrZl As String() = GroupBox1.YanFindControl(c.Name & "t").Text.Split(",")
                    Dim arrBs As String() = GroupBox1.YanFindControl(c.Name & "bs").Text.Split(",")
                    For i As Integer = 0 To arrPh.Length - 1
                        '判断重量是否足够
                        Dim iSycjcl As Decimal = Convert.ToDecimal(mt.getDb("select " & strCjcl & " from " & strYb & " where " & strYb & "_ID=" & arrBs(i)).YanDtValue2)
                        If iSycjcl - Convert.ToDecimal(arrZl(i)) < 0 Then
                            mt.Rollback()
                            mt.close()
                            MsgBox(tDr("tb_wp_pm") & "车间存量不足，无法完成！", MsgBoxStyle.Exclamation)
                            Return
                        End If
                        '扣除重量
                        dic = New Dictionary(Of String, String)
                        dic("#" & strCjcl) = strCjcl & "-" & arrZl(i)
                        mt.update(strYb, dic, strYb & "_ID=" & arrBs(i), "#")
                        '使用记录(出库)
                        dic = New Dictionary(Of String, String)
                        dic("tb_syjl_wpbs") = tDr("tb_wp_ID")
                        dic("tb_syjl_wpdm") = tDr("tb_wp_dm")
                        dic("tb_syjl_xz") = 0
                        dic("tb_syjl_yb") = strYb
                        dic("tb_syjl_wlph") = arrPh(i)
                        dic("tb_syjl_zl") = arrZl(i)
                        dic("tb_syjl_cjcl") = arrZl(i)
                        dic("tb_syjl_ybs") = arrBs(i)
                        dic("tb_syjl_czlx") = "生产"
                        dic("tb_syjl_mbb") = "tb_sc"
                        dic("tb_syjl_czbs") = iScbs
                        mt.insert("tb_syjl", dic)
                    Next
                End If
            Next
            mt.Commit()
        End Using

        Me.DialogResult = DialogResult.OK
    End Sub
    ''' <summary>
    ''' 更新批号
    ''' </summary>
    Private Sub updatePh()
        Dim dt As DataTable = m_fjxxDt.Select("tb_gxfjxx_lx='" & en_fjxxLx.批号.ToString & "'").YanArrDrToDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim cor As Control = GroupBoxFjxx.YanFindControl("fjxx" & dt.YanDtValue2("tb_gxfjxx_ID", i))
            If CType(cor, ComboBox).Text <> "" Then
                Dim iNum As Integer = CType(cor, ComboBox).SelectedIndex
                Dim arrStr As String() = dt.YanDtValue2("tb_gxfjxx_dxz", i).Split(",")
                If iNum >= 0 And iNum < arrStr.Length Then
                    cl_YanMd.getBmVa(arrStr(iNum), "zdy", 0, True)
                End If
            End If
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = False
        If saveFrom() Then
            updatePh()
            Me.DialogResult = DialogResult.OK
        End If
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = False
        Button2.Enabled = False
        baofei()
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub
End Class