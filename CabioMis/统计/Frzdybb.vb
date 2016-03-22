Imports System.ComponentModel
Public Class Frzdybb
    '使用本类必须给bbname和bbsql这2个文本框赋值
    '本类的最后一行是数字字段的求和
    Private kk As String = "" '求和索引汇总
    Private dtpublic As DataTable '真实数据
    Private m_isUpdate As Boolean = False
    Private m_strSort="" '排序方式
    Dim m_Opaque As OpaqueCommand = New OpaqueCommand()
    Private m_BkWork As BackgroundWorker
    ''' <summary>
    ''' 处理状态
    ''' </summary>
    Private Enum en_state
        开始 = 0
        暂停 = 1
        数据出错 = 2
        完成 = 100
    End Enum
    Private Sub Frzdybb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.Text = Me.bbname.Text
        wz()
        'cz()
        m_BkWork = New BackgroundWorker
        m_BkWork.WorkerReportsProgress = True
        m_BkWork.WorkerSupportsCancellation = True
        '异步操作开始
        AddHandler m_BkWork.DoWork, AddressOf cz
        '异步操作的进度
        AddHandler m_BkWork.ProgressChanged, AddressOf ProgressSub


        m_BkWork.RunWorkerAsync()
    End Sub
    Private Sub ProgressSub(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        If e.ProgressPercentage = en_state.数据出错 Then
            showl.Rows.Clear()
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            ButtonAVG.Enabled = True
            Return
        End If
        If e.ProgressPercentage = en_state.开始 Then
            m_Opaque.ShowOpaqueLayer(Me, 125, True)
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            TextBox1.Clear()
            TextBox2.Clear()
            ComboBox1.Text = "" : ComboBox2.Text = "" : ComboBox3.Text = "" : ComboBox4.Text = ""

            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            ButtonAVG.Enabled = False
            Return
        End If
        If e.ProgressPercentage = en_state.完成 Then
            m_Opaque.HideOpaqueLayer()
            Dim sjl As Integer = dtpublic.Rows.Count '数据量
            Dim zmbds As String = ""
            Dim dttemp As DataTable = Nothing
            If sjl <= 30 Then
                zmbds = " （共有" & sjl & "条记录）"
                dttemp = dtpublic.Copy '****************************下面负责把数据拷贝到临时表中来显示
            Else
                zmbds = " （共有" & sjl & "条记录,只显示最近30条，你可以使用筛选功能筛选所有记录）"
                '****************************下面负责把数据的最近30条拷贝到临时表中来显示
                dttemp = dtpublic.Clone
                For i As Integer = 0 To 29
                    dttemp.ImportRow(dtpublic.Rows(i))
                Next
            End If
            ToolStripLabel1.Text = zmbds
            If sjl = 0 Then
                Button1.Enabled = True
                Button2.Enabled = True
                Button3.Enabled = True
                ButtonAVG.Enabled = True
                Return
            End If


            '***************************
            For i As Integer = 0 To dttemp.Columns.Count - 1 '这里填充筛选框
                Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dttemp.Columns(i).Caption & "'", 4) '字段描述
                Dim bm As String = ddbm(dttemp.Columns(i).Caption) '表的英文名
                Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '表的中文名称
                zwmz = bmcn & ":" & zwmz
                Select Case dttemp.Columns(i).DataType.ToString
                    Case "System.String" : ComboBox2.Items.Add(zwmz)
                    Case "System.DateTime" : ComboBox1.Items.Add(zwmz)
                    Case "System.Decimal", "System.Short", "System.Integer", "System.Int32", "System.Long"
                        ComboBox3.Items.Add(zwmz)
                        kk &= i.ToString & ","

                End Select
            Next
            If kk <> "" Then '下面自动完成求和汇总
                With ComboBox4
                    .Items.Add("等于") : .Items.Add("不等于")
                    .Items.Add("大于") : .Items.Add("大于等于")
                    .Items.Add("小于") : .Items.Add("小于等于")
                    .Items.Add("之间")
                    .SelectedIndex = 0
                End With
                kk = DeepCode.DeepDoStr.GF_removedh(kk)
                dttemp = dbqh(dttemp, kk) '求和并附加到最后一行
            End If
            showl.Columns.Clear() '避免头部消失
            '******************
            showl.DataSource = dttemp
            If pd(bbname.Text) Then
                showl.DataSource = dtpublic
            End If
            If kk <> "" Then
                GS_ysgx(showl) '求和最后一行颜色更新
            End If
            If showl.Columns.Count > 15 Then
                showl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                showl.RowHeadersWidth = 40

            End If
            GS_DataGridViewaddmenu(showl) '增加查看明细菜单
            GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
            Select Case Me.Text
                Case "原料—动态库存"
                    Dim newcontrol As New ToolStripLabel
                    With newcontrol
                        .ForeColor = Color.Red
                        .Text = "(仓库存量为库存实存，剩余库存为仓库存量+生产现场数量)"
                    End With
                    ToolStrip1.Items.Add(newcontrol)
            End Select
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            ButtonAVG.Enabled = True
            Return
        End If
    End Sub
    Private Sub cz(ByVal sender As Object, ByVal e As DoWorkEventArgs) '初始化构造数据
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        worker.ReportProgress(en_state.开始, Nothing)

        kk = ""
        dtpublic = getShowTable()
        If dtpublic Is Nothing Then
            worker.ReportProgress(en_state.数据出错, Nothing)
            Return
        End If
        worker.ReportProgress(100, Nothing)
    End Sub
    Function getShowTable() As DataTable
        Dim sql As String = ""
        Dim dt As DataTable = Nothing
        Select Case Me.bbname.Text
            Case "DHA毛油生产进度表"
                sql = "select " & vbCrLf & _
                "tb_x825p_num2," & vbCrLf & _
                "tb_meijie_jgrq," & vbCrLf & _
                "tb_meijie_zy," & vbCrLf & _
                "tb_meijie_sf," & vbCrLf & _
                "tb_x825p_r583j," & vbCrLf & _
                "tb_x825p_mingc," & vbCrLf & _
                "tb_x825p_jiagdm," & vbCrLf & _
                "tb_x825p_num," & vbCrLf & _
                "tb_x825p_jgrq," & vbCrLf & _
                "tb_x825p_s640k," & vbCrLf & _
                "convert(decimal(18,2),case when tb_x825p_r583j*tb_meijie_zy>0 then" & vbCrLf & _
                "(tb_x825p_s640k *10000)/(tb_x825p_r583j*tb_meijie_zy) " & vbCrLf & _
                "else" & vbCrLf & _
                "0" & vbCrLf & _
                "end) " & vbCrLf & _
                "as 浸出收率," & vbCrLf & _
                "tb_x825p_s640k*(case tb_x825p_m387e when 0 then tb_x825p_m387e else tb_x825p_m387e end) /100 as [毛油NET DHA]," & vbCrLf & _
                "tb_x825p_r602j," & vbCrLf & _
                "tb_x825p_m387e," & vbCrLf & _
                "tb_x825p_q547i," & vbCrLf & _
                "tb_x825p_u699m," & vbCrLf & _
                "tb_x825p_r600j," & vbCrLf & _
                "tb_x825p_o479g," & vbCrLf & _
                "tb_x825p_b959t," & vbCrLf & _
                "tb_x825p_mynetaa," & vbCrLf & _
                "tb_x825p_gjtzy," & vbCrLf & _
                "tb_x825p_bz," & vbCrLf & _
                "tb_x825p_qaspjg," & vbCrLf & _
                "tb_x825p_qajgsm" & vbCrLf & _
                " from tb_x825p as a left join tb_meijie as b on a.tb_x825p_num2=b.tb_meijie_num" & vbCrLf & _
                " where tb_x825p_num2<>''" & vbCrLf & _
                " and left(tb_x825p_mingc,4)='DOGC' order by tb_meijie_jgrq desc"
                m_strSort = "tb_meijie_jgrq desc"
                dt = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql) '获得真实数据
            Case "发酵罐DHA指标"
                sql = "select " & vbCrLf & _
                "tb_i234a_num," & vbCrLf & _
                "tb_q546i_qcrq," & vbCrLf & _
                "tb_q546i_t651l," & vbCrLf & _
                "tb_q546i_j300c," & vbCrLf & _
                "tb_q546i_n455g," & vbCrLf & _
                "tb_q546i_f144x," & vbCrLf & _
                "tb_q546i_j300c*tb_q546i_n455g*tb_q546i_f144x/1000 as 发酵生产率" & vbCrLf & _
                "from tb_i234a as a left join " & vbCrLf & _
                "tb_q546i as b on a.tb_i234a_num=b.tb_q546i_num" & vbCrLf & _
                "where DATEPART(hh,tb_q546i_qcrq)=7 or left(tb_q546i_t651l,1)='放' order by tb_q546i_qcrq desc"
                m_strSort = "tb_q546i_qcrq desc"
                dt = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql) '获得真实数据
            Case "DHA成品油进度表"
                sql = "select '' as [投入毛油批号], " & vbCrLf & _
                "tb_h195z_n426f," & vbCrLf & _
                "tb_h195z_s621k," & vbCrLf & _
                "tb_h195z_num2," & vbCrLf & _
                "tb_h195z_mingc," & vbCrLf & _
                "tb_h195z_jiagdm," & vbCrLf & _
                "tb_h195z_num," & vbCrLf & _
                "tb_h195z_jgrq," & vbCrLf & _
                "tb_h195z_m408e," & vbCrLf & _
                "tb_h195z_o460g," & vbCrLf & _
                "tb_h195z_p495h," & vbCrLf & _
                "tb_h195z_y876r," & vbCrLf & _
                "tb_h195z_e95w," & vbCrLf & _
                "case when" & vbCrLf & _
                " tb_h195z_n426f + dbo.YanNullToEmpty(tb_h195z_e95w,1) +  dbo.YanNullToEmpty(tb_h195z_p495h,1)=0" & vbCrLf & _
                "then" & vbCrLf & _
                "0" & vbCrLf & _
                "else" & vbCrLf & _
                "tb_h195z_m408e/(tb_h195z_n426f + dbo.YanNullToEmpty(tb_h195z_e95w,1) +  dbo.YanNullToEmpty(tb_h195z_p495h,1))" & vbCrLf & _
                "end  as [成品油收率（weight）]," & vbCrLf & _
                "case when tb_h195z_s621k=0 " & vbCrLf & _
                "then" & vbCrLf & _
                "0" & vbCrLf & _
                "else" & vbCrLf & _
                "tb_h195z_m408e*tb_h195z_c6u/100/tb_h195z_s621k*100" & vbCrLf & _
                "end as [成品油收率（DHA）]," & vbCrLf & _
                "tb_h195z_m408e*tb_h195z_c6u/100 as [成品油NET DHA]," & vbCrLf & _
                "tb_h195z_c6u," & vbCrLf & _
                "tb_h195z_c28u," & vbCrLf & _
                "tb_h195z_m403e," & vbCrLf & _
                "tb_h195z_b991u," & vbCrLf & _
                "tb_h195z_k309c," & vbCrLf & _
                "tb_h195z_a948s," & vbCrLf & _
                "tb_h195z_j268b," & vbCrLf & _
                "tb_h195z_l356d," & vbCrLf & _
                "tb_h195z_o485g," & vbCrLf & _
                "tb_h195z_bz," & vbCrLf & _
                "tb_h195z_qaspjg," & vbCrLf & _
                "tb_h195z_qajgsm" & vbCrLf & _
                "from vw_h195z" & vbCrLf & _
                "where tb_h195z_cplb='DOGF'" & vbCrLf & _
                " order by tb_h195z_jgrq desc"
                m_strSort = "tb_h195z_jgrq desc"
                dt = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql) '获得真实数据
            Case "成品粉生产进度"
                m_strSort = "tb_x832p_jgrq desc"
                If m_isUpdate = False Then
                    dt = cl_theCl.getBb(en_saveBb.成品粉生产进度2, "order by tb_x832p_jgrq desc")
                    If dt IsNot Nothing AndAlso dt.Rows.Count >= 0 Then
                        Return dt
                    End If
                End If
                '保存表
                cl_theCl.saveBb(en_saveBb.成品粉生产进度2)
                dt = cl_theCl.getBb(en_saveBb.成品粉生产进度2, "order by tb_x832p_jgrq desc")
                Return dt
            Case "成品油生产进度"
                sql = "select  tb_h195z.tb_h195z_num2,tb_h195z.tb_h195z_num,tb_h195z.tb_h195z_cplb,tb_h195z.tb_h195z_mingc,tb_h195z.tb_h195z_jiagdm," &
                    "tb_h195z.tb_h195z_jgrq,tb_h195z.tb_h195z_n426f,tb_h195z.tb_h195z_s621k,tb_h195z.tb_h195z_m408e,tb_h195z.tb_h195z_tpyy,tb_h195z.tb_h195z_e95w," &
                    "dbo.sumSplit(tb_h195z_fgfpht,',') as 返工油重量,tb_h195z.tb_h195z_u704m,tb_h195z.tb_h195z_pf,tb_h195z.tb_h195z_bz,tb_h195z.tb_h195z_c6u," &
                    "tb_h195z.tb_h195z_c28u,tb_h195z.tb_h195z_qaspjg,tb_h195z.tb_h195z_qajgsm,tb_h195z.tb_h195z_t673l,tb_h195z.tb_h195z_q554i,tb_h195z.tb_h195z_m403e," &
                    "tb_h195z.tb_h195z_b991u,tb_h195z.tb_h195z_k309c,tb_h195z.tb_h195z_a948s,tb_h195z.tb_h195z_j268b,tb_h195z.tb_h195z_l356d,tb_h195z.tb_h195z_o485g," &
                    "tb_h195z.tb_h195z_dry from tb_h195z where (1=1)    and tb_h195z.tb_h195z_jgrq>'2008-12-25 23:59:59' order by tb_h195z.tb_h195z_jgrq desc"
                m_strSort = "tb_h195z_jgrq desc"
                dt = _D.GF_CreateDataSource(sql) '获得真实数据
            Case Else
                sql = Me.bbsql.Text
                dt = _D.GF_CreateDataSource(sql) '获得真实数据
        End Select
        If sql = "" Then
            Return Nothing
        End If
        Debug.Print(sql)

        Return dt
    End Function
    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(showl, Me.Text, Me)

    End Sub
    Private Sub wz()

        showl.Width = Me.Width - 10
        showl.Height = Me.Height - showl.Top - 50
    End Sub

    Private Sub Frzdybb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt1 As DataTable = dtpublic.Copy
            Dim bds As String = Creatbds() '产生表达式
            'Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB
            Dim dt2 As DataTable = dt1.Select(bds, m_strSort).YanArrDrToDb
            ToolStripLabel1.Text = " （共有" & dt2.Rows.Count & "条记录）"
            If kk <> "" Then '下面自动完成求和汇总
                dt2 = dbqh(dt2, kk) '求和并附加到最后一行
            End If
            showl.Columns.Clear() '避免头部消失
            showl.DataSource = dt2
            If kk <> "" Then
                GS_ysgx(showl) '求和最后一行颜色更新
            End If

            GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        m_BkWork.RunWorkerAsync()
        'GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
    End Sub
    Private Function gettruezdm(ByVal str As String) As String '得到真正英文字段名称
        Dim bmcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "left")
        Dim zdcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "right")
        If bmcn = "" Then
            Return zdcn
        End If
        Dim bm As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mx='" & bmcn & "'", 1) '得到表英文名称
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_biao='" & bm & "' and tb_biaozdinf_mx='" & zdcn & "'", 1) '得到英文字段名称
        Return zd
    End Function

    Private Function dbqh(ByVal db As DataTable, ByVal dbindex As String) As DataTable '求和并附加到最后一行
        With db
            If .Rows.Count > 0 Then
                Dim ws As Integer = .Columns.Count - 1
                Dim k(ws) As String
                .Rows.Add(k)
                Dim m() As String = dbindex.Split(",")
                For i As Integer = 0 To m.Length - 1
                    Dim n As Integer = m(i) '得到求和的列索引
                    Dim mz As String = db.Columns(n).ColumnName
                    If Microsoft.VisualBasic.Right(mz, 4) <> "_tjq" Then '因为统计期是数子字段，且很大，不参与求和
                        '求和
                        Dim zs As Double = DeepCode.DeepDoDataTable.GF_jsColumnTotal(db, n, 0, .Rows.Count - 2)
                        .Rows(.Rows.Count - 1)(n) = zs '求和赋值
                    End If
                Next
            End If
        End With
        Return db
    End Function
    '置换表达式
    Private Function zhbds(ByVal zd As String, ByVal bd As String, ByVal wb As String) As String
        Dim ss As String = ""
        Dim bds As String = ""
        Select Case bd
            Case "大于", "小于", "不等于", "等于", "大于等于", "小于等于"
                If IsNumeric(wb) = False Then
                    MsgBox("您输入了非数字") : Return ""
                End If
            Case "之间"
                If InStr(wb, ",") = 0 Then
                    MsgBox("之间表达式应该这样填写：50,78") : Return ""
                End If
        End Select
        Select Case bd
            Case "大于" : ss = ">" : bds = zd & ss & wb
            Case "小于" : ss = "<" : bds = zd & ss & wb
            Case "不等于" : ss = "<>" : bds = zd & ss & wb
            Case "等于" : ss = "=" : bds = zd & ss & wb
            Case "大于等于" : ss = ">=" : bds = zd & ss & wb
            Case "小于等于" : ss = "<=" : bds = zd & ss & wb
            Case "之间"
                Dim sz1, sz2 As Double
                sz1 = DeepCode.DeepDoStr.GF_searchchar(wb, ",", "left")
                sz2 = DeepCode.DeepDoStr.GF_searchchar(wb, ",", "right")
                bds = zd & ">=" & sz1 & " and " & zd & "<=" & sz2
        End Select
        Return bds
    End Function
    Private Sub showl_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles showl.CellMouseDoubleClick
        With showl
            If .Rows.Count = 0 Then
                Return
            End If
            If .SelectedRows.Count = 0 Then
                Return
            End If
            Dim sql As String = ""
            Select Case Me.Text
                Case "成品油生产进度"
                    Dim ph As String = .SelectedRows(0).Cells("tb_h195z_num2").Value '得到精练的批号
                    ph = DeepCode.DeepDoStr.GF_zhzfccx(ph)
                    sql = "select tb_k306c.tb_k306c_num,tb_k306c.tb_k306c_jgrq,tb_k306c.tb_k306c_q559i,tb_mypl.tb_mypl_myhl from vw_k306c,tb_mypl where tb_k306c.tb_k306c_num in(" & ph & ") and tb_k306c.tb_k306c_sbid=tb_mypl.tb_mypl_ID"

                Case Else
                    Return
            End Select
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            Dim a As New Frzdybb_mx
            a.Text = "精炼明细"
            a.showl.DataSource = dt
            GS_TranEtoC(a.showl) '将DataGridView列字段翻译成为中文描叙

            a.Show()
            GS_DataGridViewaddmenu(a.showl) '增加查看明细菜单
        End With
    End Sub

    Private Sub ButtonAVG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAVG.Click
        With showl
            Dim a As Integer = .Rows.Count
            If a < 2 Then
                Return
            End If
            For i As Integer = 0 To .Rows(a - 1).Cells.Count - 1
                Dim s As Object = .Rows(a - 1).Cells(i).Value
                If IsNumeric(s) = True Then
                    .Rows(a - 1).Cells(i).Value = s / (a - 1)
                End If
            Next

        End With
    End Sub
    Public Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
    Private Function Creatbds() As String

        Dim bdss As String = "1=1"
        '时间字段
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text)
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bdss &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        '文本字段
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text)
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then

            End If
            bdss &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
        '数字字段
        Dim cxzd3 As String = gettruezdm(ComboBox3.Text)
        If cxzd3 <> "" And TextBox2.Text.Trim <> "" Then
            cxzd3 = "[" & cxzd3 & "]"
            Dim sz As String = TextBox2.Text.Trim
            sz = Replace(sz, "，", ",") '怕出现中文逗号
            Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
            If nnn <> "" Then
                bdss &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
            End If
        End If
        Return bdss

    End Function
    Private Function pd(ByVal biaoming As String) As Boolean
        Dim i As String = "毛油生产进度,大罐AA指标跟踪,酵母粉投入情况,葛店浸出的毛油,放罐&烘干,有机计划执行跟踪表,成品油生产进度,原料-动态库存明细表,包材-动态库存明细表"
        If InStr(i, biaoming) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        m_isUpdate = True
        m_BkWork.RunWorkerAsync()
    End Sub
End Class