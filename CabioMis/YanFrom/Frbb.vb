Imports System.Globalization

Public Class Frbb
    Public m_bbId As Integer = 0

    Private Sub Frbb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        show1.RowHeadersVisible = True
        show1.RowHeadersWidth = 50
        show1.Tag = "showHj"

        '报表名称
        Dim sql As String = "select distinct tb_xtszNr_mc from tb_xtszNr where tb_xtszNr_bs=" & en_xtLb.统计报表
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        GS_wlbktlr2(ComboBox1, dt, blNull:=True)

        AddHandler ComboBox1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
        Button3.Enabled = False
        Button4.Enabled = False
        Button2.Enabled=False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        '报表编号
        Dim sql As String = "select tb_xtszNr_dm from tb_xtszNr where tb_xtszNr_mc='" & ComboBox1.Text & "' and tb_xtszNr_bs=" & en_xtLb.统计报表
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        GS_wlbktlr2(ComboBox2, dt)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim sql As String = " select tb_xtszNr_ID from tb_xtszNr where tb_xtszNr_mc='" & ComboBox1.Text & "' and tb_xtszNr_dm='" & ComboBox2.Text & "' " & _
        "and tb_xtszNr_bs=" & en_xtLb.统计报表
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        If dt.Rows.Count = 0 Then
            MsgBox("没有该名称的报表！")
            Return
        Else
            m_bbId = dt.Rows(0)("tb_xtszNr_ID")
        End If
        sql = "select * from tb_bcbb where tb_bcbb_bs = " & m_bbId
        dt = _D.GF_CreateDataSource(sql)
        If dt.Rows.Count = 0 Then
            MsgBox("没有报表内容！")
            Return
        End If
        Dim dtBb As DataTable = New DataTable
        '添加列
        For Each dr As DataRow In dt.Select("tb_bcbb_bh=0")
            dtBb.Columns.Add(dr("tb_bcbb_zd"))
        Next
        Dim iBh As Integer = -1
        Dim drNew As DataRow = Nothing
        '添加行
        For i As Integer = 0 To dt.Rows.Count - 1
            If iBh <> dt.Rows(i)("tb_bcbb_bh") Then
                If (drNew Is Nothing) = False Then
                    dtBb.Rows.Add(drNew)
                End If
                drNew = dtBb.NewRow
                iBh = dt.Rows(i)("tb_bcbb_bh")
            End If
            drNew(dt.Rows(i)("tb_bcbb_zd")) = dt.Rows(i)("tb_bcbb_va")
        Next
        dtBb.Rows.Add(drNew)
        show1.DataSource = dtBb

        Button3.Enabled = True
        Button4.Enabled = False
        Button2.Enabled=True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("确定要删除吗！", MsgBoxStyle.YesNo) = vbYes Then
            cl_theCl.delTjBb(m_bbId)
        End If
    End Sub

    '添加列
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim FrGs As New Frbb_Gs
        FrGs.m_dt = show1.DataSource
        FrGs.ShowDialog()
    End Sub

    Private Sub show1_dataChage(sender As Object, e As EventArgs) Handles show1.ColumnAdded, show1.ControlRemoved
        Button4.Enabled = True
    End Sub

    '删除列事件
    Private Sub show1_delCol(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles show1.ColumnHeaderMouseClick

        Dim menu1 As ContextMenuStrip = Nothing
        If e.Button.ToString = "Left" Then
            Return
        End If
        menu1 = New ContextMenuStrip
        menu1.Items.Add("删除列")
        AddHandler menu1.Items(0).Click, AddressOf munuDelCol
        Dim pt As New System.Drawing.Point
        For i As Integer = 0 To e.ColumnIndex - 1
            pt.X += show1.Columns(i).Width
        Next
        pt.X += e.Location.X
        pt.Y = e.Y
        menu1.Tag = e
        menu1.Show(show1, pt)
    End Sub
    '删除列
    Private Sub munuDelCol(sender As Object, e As System.EventArgs)
        Dim mu As ContextMenuStrip = sender.owner
        Dim ev As System.Windows.Forms.DataGridViewCellMouseEventArgs = mu.Tag

        If MsgBox("确定要删除这个列吗？", MsgBoxStyle.YesNo) = vbYes Then
            Dim dt As DataTable = show1.DataSource
            dt.Columns.RemoveAt(ev.ColumnIndex)
        End If
    End Sub
    '保存修改
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql As String = "delete from tb_bcbb where tb_bcbb_bs = " & m_bbId & ";" & vbCrLf
        _D.GS_upztxx(sql)
        '保存报表内容
        Dim dt As DataTable = show1.DataSource
        For i As Integer = 0 To dt.Rows.Count - 1
            For j As Integer = 0 To dt.Columns.Count - 1
                _D.insertData("tb_bcbb", New String(,) {{"tb_bcbb_zd", dt.Columns(j).ColumnName}, _
                                                        {"tb_bcbb_va", _S.YanNullToEmpty(dt.Rows(i)(j))}, _
                                                        {"tb_bcbb_bs", m_bbId}, _
                                                        {"tb_bcbb_bh", i}})
            Next
        Next
        MsgBox("保存完毕！")
    End Sub


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