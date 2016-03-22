''' <summary>
''' 产品生产列表（显示详细批次）
''' </summary>
Public Class FrTj_Scqk_cp
    ''' <summary>
    ''' 要显示的流程名称
    ''' </summary>
    Public m_strSclc As String = ""

    Private Sub FrTj_Scqk_cp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        't1.Value = DateAdd(DateInterval.Month, -1, DateTime.Now)

        showSj()
        GroupBox2.Text = m_strSclc & "列表"
        MyBase.Text = "生产批次列表"
        AddHandler show1.CellClick, AddressOf CellSel_onclick
    End Sub

    Private Sub showSyQk(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New FrTj_Scqk_yl
        '传入原料使用统计所需的参数
        Dim strPh As String = "" '选取的标识
        For i As Integer = 0 To show1.RowCount - 1
            If Convert.ToInt32(_S.YanFormatNum(show1.Rows(i).Cells(0).Value)) = 1 Then
                strPh &= show1.Rows(i).Cells(en_LcTj.主键 + 1).Value.ToString() & ","
            End If
        Next
        If strPh <> "" Then
            strPh = DeepCode.DeepDoStr.GF_removedh(strPh)
        Else
            strPh = show1.SelectedRows(0).Cells(en_LcTj.主键 + 1).Value.ToString()
        End If

        aa.m_blXh = CBool(IIf(sender.ToString = "原料使用统计", True, False))
        aa.m_showTypt = 1
        aa.m_strPh = strPh   '选取的标识
        aa.m_strScLc = show1.SelectedRows(0).Cells(en_LcTj.名称 + 1).Value.ToString() '需要统计的流程

        aa.ShowDialog()
    End Sub

    Sub allSel(pBl As Boolean)
        For i As Integer = 0 To show1.Rows.Count - 1
            show1.Rows(i).Cells(0).Value = IIf(pBl, 1, 0)
        Next
    End Sub
    '点击勾选框单元格处理
    Sub CellSel_onclick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex = -1 Then
            Return
        End If
        Dim cel As DataGridViewCell = show1.Rows(e.RowIndex).Cells(e.ColumnIndex)

        If cel.ColumnIndex > 0 Then
            Return
        End If
        If cel.Value = Nothing Then
            cel.Value = 0
        End If
        cel.Value = IIf(Convert.ToInt32(cel.Value.ToString()) = 0, 1, 0)
    End Sub

    '显示批次详情
    Sub showSj()
        '流程列表
        Dim dtLcTable As DataTable = GetType(en_LcTableName).YanEnToTb
        '要显示字段的TB
        Dim dt As DataTable = GetType(en_LcTj).YanEnToTbCol

        Dim sql As String = ""
        Dim strTb As String = GetType(en_LcTableName).YanGetEnText_1(m_strSclc)
        Dim strZl As String = ""
        Select Case m_strSclc
            Case en_LcTableName.毛油.ToString
                strZl = "tb_x825p_s640k"
            Case en_LcTableName.成品油.ToString
                strZl = "tb_h195z_m408e"
            Case en_LcTableName.成品粉.ToString
                strZl = "tb_x832p_i232a"
            Case Else
                strZl = ""
        End Select
        Dim strCpDm As String = strTb & "_mingc"
        Dim strJgDm As String = strTb & "_jiagdm"

        sql = "select * from " & strTb & " where " & strTb & "_jgrq between '" & GF_gettrqsj(t1.Text) & " 00:00:00' and '" & GF_gettrqsj(t2.Text) & " 23:59:59" & "' "
        Dim dtCpy As DataTable = _D.GF_CreateDataSource(sql)
        For Each drCpy As DataRow In dtCpy.Rows
            Dim drNewTj As DataRow = dt.NewRow
            drNewTj(en_LcTj.主键) = drCpy(strTb & "_ID")
            drNewTj(en_LcTj.名称) = m_strSclc
            If strZl <> "" Then
                drNewTj(en_LcTj.产品代码) = drCpy(strCpDm)
                drNewTj(en_LcTj.加工代码) = drCpy(strJgDm)
                drNewTj(en_LcTj.产出量) = drCpy(strZl)
            End If
            drNewTj(en_LcTj.批号) = drCpy(strTb & "_num")
            drNewTj(en_LcTj.产出日期) = drCpy(strTb & "_jgrq")
            dt.Rows.Add(drNewTj)
        Next

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("原料投放统计")
        AddHandler menu1.Items(1).Click, AddressOf showSyQk
        menu1.Items.Add("原料使用统计")
        AddHandler menu1.Items(2).Click, AddressOf showSyQk

        GS_DataGridViewbyDb(show1, dt, True, True, menu1)
        '显示数据说明
        Label1.Text = "共有记录" & show1.Rows.Count & "条！"

        Dim drTm As New DataGridViewCheckBoxColumn
        Dim headCkCell As New DatagridViewCheckBoxHeaderCell
        headCkCell.OnCheckBoxClicked = AddressOf allSel
        drTm.HeaderCell = headCkCell
        drTm.ReadOnly = False
        drTm.TrueValue = 1
        drTm.FalseValue = 0
        show1.Columns.Insert(0, drTm)

        show1.Columns(en_LcTj.主键 + 1).Visible = False
    End Sub
End Class