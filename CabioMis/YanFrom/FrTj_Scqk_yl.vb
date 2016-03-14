Imports System.Globalization
''' <summary>
''' 原料使用列表
''' </summary>
Public Class FrTj_Scqk_yl
    Public m_strPh As String  '要统计的流程标识
    Public m_strScLc As String '要统计的流程名称
    Public m_blXh As Boolean = True '是否显示消耗
    Public m_showTypt As Integer = 0 '显示方式 0为列表，1为统计

    ''' <summary>
    ''' 显示的数据源
    ''' </summary>
    Public m_Dt As DataTable
    Private Sub FrTj_Scqk_yl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '行标题可见
        show1.RowHeadersVisible = True
        show1.RowHeadersWidth = 50
        show1.Tag = "showHj"

        If m_Dt IsNot Nothing Then
            Dim dtShow As DataTable = m_Dt
            Dim drHj As DataRow = dtShow.NewRow
            drHj(en_Tjzd.使用量) = _D.YanCountCol(dtShow, en_Tjzd.使用量.ToString)
            dtShow.Rows.Add(drHj)
            GS_DataGridViewbyDb(show1, m_Dt, True, True)
            Return
        End If
        Dim dtLcTable As DataTable = GetType(en_LcTableName).YanEnToTb

        '要显示字段的TB
        Dim dt As DataTable = GetType(en_Tjzd).YanEnToTbCol
        Dim StrLc As String = _D.YanDttoStr(GetType(en_LcTableName).YanEnToTb, "text", True)
        '获取所有流程中是批号的字段
        Dim sql As String = ""

        '获取操作起始表
        Dim strFirstTb As String = dtLcTable.Select("name='" & m_strScLc & "'")(0)("text")
        '获取原始DT
        setShowDt(strFirstTb, m_strPh, dt, m_blXh)

        '结果数据去重
        Dim dv As DataView = New DataView(dt)
        dt = dv.ToTable(True)
        '去掉成品油库存
        dt = _D.YanArrToDb(dt.Select(en_Tjzd.对象名称.ToString & "<>''"))
        m_Dt = dt

        dv = New DataView(dt)
        dt = dv.ToTable(True, en_Tjzd.对象名称.ToString)

        Dim objPoint As New System.Drawing.Point(122, 16)
        For Each dr As DataRow In GetType(en_LcTableName).YanEnToTb.Rows
            Dim objCk As New CheckBox
            objCk.Name = dr("text")
            objCk.Text = dr("name")
            objCk.Tag = ""
            objCk.Location = objPoint
            objCk.Width = 90
            Panel1.Controls.Add(objCk)
            '设置勾选按钮状态
            If dt.Select(en_Tjzd.对象名称.ToString & "='" & dr("name") & "'").Length = 0 Then
                '如果流程里面没有
                objCk.Checked = False
                objCk.Enabled = False
            Else
                objCk.Checked = True
            End If
            AddHandler objCk.CheckStateChanged, AddressOf CheckBox1_CheckedChanged
            objPoint.X += 90
        Next
        '填充DATAVIEW
        showSel(m_Dt)
        MyBase.Text = "原料使用统计"
    End Sub

    '原料使用详情
    Private Sub showXq()
        Dim frCpList As New FrTj_Scqk_yl
        frCpList.m_Dt = _D.YanArrToDb(m_Dt.Select("(" & getStrWh() & ") and " & en_Tjzd.物料代码.ToString & "='" & show1.SelectedRows(0).Cells(en_Yltj.物料代码.ToString).Value & "'"))
        frCpList.ShowDialog
    End Sub
    '填充DATAVIEW
    Private Sub showSel(pDt As DataTable)
        '按给定条件查询出所需要的
        Dim dt As DataTable = _D.YanArrToDb(pDt.Select(getStrWh()))

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        If m_showTypt = 1 Then
            menu1.Items.Add("原料使用详情")
            AddHandler menu1.Items(1).Click, AddressOf showXq
            '添加合计行
            dt = setShowTj(dt)
            Dim drHj As DataRow = dt.NewRow
            drHj(en_Yltj.使用量) = _D.YanCountCol(dt, en_Yltj.使用量.ToString)
            dt.Rows.Add(drHj)
            GS_DataGridViewbyDb(show1, dt, True, True, menu1)
        Else
            Dim drHj As DataRow = dt.NewRow
            drHj(en_Tjzd.使用量) = _D.YanCountCol(dt, en_Tjzd.使用量.ToString)
            dt.Rows.Add(drHj)
            GS_DataGridViewbyDb(show1, dt, True, True)
        End If
    End Sub

    '设置原料统计数据源
    Private Function setShowTj(pDt As DataTable) As DataTable
        If pDt Is Nothing Then
            Return GetType(en_Yltj).YanEnToTbCol
        End If

        '原料统计原始表
        Dim dtYlTj As DataTable = GetType(en_Yltj).YanEnToTbCol
        '填充数据
        Dim dv As DataView = New DataView(pDt)
        Dim dt2 As DataTable = dv.ToTable(True, en_Tjzd.物料代码.ToString, en_Tjzd.物料名称.ToString)
        For i As Integer = 0 To dt2.Rows.Count - 1
            Dim drNew As DataRow = dtYlTj.NewRow
            Dim tmDt As DataTable = _D.YanArrToDb(pDt.Select(en_Tjzd.物料代码.ToString & "='" & dt2.Rows(i)(en_Tjzd.物料代码.ToString) & "'"))
            drNew(en_Yltj.物料代码) = dt2.Rows(i)(en_Tjzd.物料代码.ToString)
            drNew(en_Yltj.物料名称) = dt2.Rows(i)(en_Tjzd.物料名称.ToString)
            drNew(en_Yltj.使用量) = _D.YanCountCol(tmDt, en_Tjzd.使用量.ToString)
            dtYlTj.Rows.Add(drNew)
        Next
        Return dtYlTj
    End Function

    '递归将所有关联的原料加入DT
    Private Sub setShowDt(pTb As String, pId As String, ByRef pDt As DataTable, Optional pBlXh As Boolean = True)
        '根据传来的批号获取该流程的数据集
        Dim Sql As String = "select * from " & pTb & "  where CHARINDEX(','+cast(" & pTb & "_ID as varchar(50))+',','," & pId & ",')>0"
        Dim dtWl As DataTable = _D.GF_CreateDataSource(Sql)

        '该表的所有批号字段
        Sql = "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao ='" & pTb & "' and right(tb_biaozdinf_mx,2)='批号'"
        Dim dtPhZd As DataTable = GF_CreateDataSource(G_cnnstr, Sql)

        '一条记录是一个批号
        For Each drWl As DataRow In dtWl.Rows
            '循环该记录的每个字段
            For Each drPhzd As DataRow In dtPhZd.Rows
                Sql = "select * from tb_i259b where CHARINDEX(','+tb_i259b_num+',','," & drWl(drPhzd("tb_biaozdinf_mc")) & ",')>0"
                Dim dtTm As DataTable = _D.GF_CreateDataSource(Sql)
                If dtTm.Rows.Count > 0 Then
                    '批号数组
                    Dim arrStrPh As String() = drWl(drPhzd("tb_biaozdinf_mc")).ToString.Split(",")
                    '数量数组
                    Dim arrStrSl As String() = drWl(drPhzd("tb_biaozdinf_mc") & "t").ToString.Split(",")
                    For i As Integer = 0 To arrStrPh.Length - 1
                        Dim drNewTj As DataRow = pDt.NewRow
                        drNewTj(en_Tjzd.物料代码) = dtTm.Rows(0)("tb_i259b_i231a")
                        drNewTj(en_Tjzd.物料名称) = dtTm.Rows(0)("tb_i259b_c24u")
                        drNewTj(en_Tjzd.操作类型) = "生产"
                        Try
                            drNewTj(en_Tjzd.使用量) = arrStrSl(i)
                        Catch ex As Exception
                            drNewTj(en_Tjzd.使用量) = 0
                        End Try
                        drNewTj(en_Tjzd.操作时间) = drWl(pTb & "_jgrq")
                        drNewTj(en_Tjzd.原料批号) = arrStrPh(i)
                        drNewTj(en_Tjzd.操作对象) = drWl(pTb & "_num")
                        drNewTj(en_Tjzd.对象名称) = GetType(en_LcTableName).YanGetEnT2N(pTb)
                        pDt.Rows.Add(drNewTj)
                    Next
                End If
            Next
            If pBlXh Then
                '调用该流程的上步表
                Try
                    Dim strSbtb As String = drWl(pTb & "_sbtb").ToString
                    Dim strSbid As String = drWl(pTb & "_sbid").ToString
                    If strSbtb <> "" And strSbid <> "" And InStr("tb_h195zkc,tb_x832pkc", strSbtb) <= 0 Then
                        setShowDt(drWl(pTb & "_sbtb").ToString, drWl(pTb & "_sbid").ToString, pDt)
                    End If
                Catch ex As Exception
                    'MsgBox(ex.Message)
                Finally
                End Try
            End If
        Next
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frSave As New Frbb_save
        frSave.m_bbDt=show1.DataSource()
        frSave.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        showSel(m_Dt)
    End Sub

    '获取勾选的条件表达式
    Private Function getStrWh() As String
        Dim objCk As CheckBox = Nothing
        Dim strWh As String = ""

        For Each dr As DataRow In GetType(en_LcTableName).YanEnToTb.Rows
            objCk = cl_YanMd.findcontrolinform(Me, dr("text"))
            If objCk IsNot Nothing Then
                If objCk.Checked Then
                    strWh &= "or " & en_Tjzd.对象名称.ToString & " = '" & dr("name") & "' "
                End If
            End If
        Next
        If strWh = "" Then
            Return "1=2"
        End If
        strWh = strWh.Remove(0, 2)
        Return strWh
    End Function

    Private Sub _dataGridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles show1.RowPostPaint
        SetDataGridViewRowXh(e, sender)
    End Sub
    Private Sub SetDataGridViewRowXh(e As DataGridViewRowPostPaintEventArgs, objDv As DataGridView)
        Dim solidBrush As New SolidBrush(objDv.RowHeadersDefaultCellStyle.ForeColor)
        Dim xh As Integer = e.RowIndex + 1
        If e.RowIndex = objDv.Rows.Count - 1 And objDv.Tag = "showHj" Then
            '显示合计
            e.Graphics.DrawString("合计".ToString(CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        Else
            e.Graphics.DrawString(xh.ToString(CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End If
    End Sub
End Class