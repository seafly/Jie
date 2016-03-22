''' <summary>
''' 流程统计
''' </summary>
Public Class FrTj_Scqk

    '查询条件的日期表达式
    Private Sub FrTj_Scqk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t1.Value = DateAdd(DateInterval.Month, -1, DateTime.Now)

        showPitj()
        MyBase.Text = "生产情况统计"
        GroupBox2.Text = "生产情况统计"
        AddHandler show1.DoubleClick, AddressOf showCplist
    End Sub
    '显示详细批次列表
    Sub showCplist(sender As Object, e As System.EventArgs)
        Dim frCpList As New FrTj_Scqk_cp
        frCpList.m_strSclc = show1.SelectedRows(0).Cells(en_PcTj.名称).Value
        frCpList.t1.Value = t1.Value
        frCpList.t2.Value = t2.Value
        frCpList.ShowDialog()
    End Sub
    '原料投放统计
    Sub showTftj(sender As Object, e As System.EventArgs)
        Dim frCpList As New FrTj_Scqk_yl
        frCpList.m_strScLc = show1.SelectedRows(0).Cells(en_PcTj.名称).Value
        frCpList.m_blXh = IIf(sender.ToString = "原料使用统计", True, False)
        frCpList.m_showTypt = 1
        '这里应该显示所选条件的所有批次
        Dim strCztbName As String = GetType(en_LcTableName).YanGetEnText_1(show1.SelectedRows(0).Cells(en_PcTj.名称).Value)
        Dim sql As String = "select " & strCztbName & "_ID from " & strCztbName & " where " & strCztbName & "_jgrq between " & _
            "'" & GF_gettrqsj(t1.Text) & " 00:00:00' and '" & GF_gettrqsj(t2.Text) & " 23:59:59" & "'"
        frCpList.m_strPh = _D.YanDttoStr(_D.GF_CreateDataSource(sql), strCztbName & "_ID")

        frCpList.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showPitj()
    End Sub

    '显示批次统计
    Sub showPitj()
        '要显示字段的TB
        Dim dt As DataTable = GetType(en_PcTj).YanEnToTbCol
        Dim dtLc As DataTable = GetType(en_LcTableName).YanEnToTb

        Dim sql As String = ""
        Dim dtData As DataTable = Nothing

        For Each drLc As DataRow In dtLc.Rows
            Dim strMc As String = ""
            Dim strTb As String = ""
            Dim strZl As String = ""

            Select Case drLc("name")
                Case en_LcTableName.毛油.ToString
                    strZl = ",sum(tb_x825p_s640k) as " & en_PcTj.产出量.ToString
                Case en_LcTableName.成品油.ToString
                    strZl = ",sum(tb_h195z_m408e) as " & en_PcTj.产出量.ToString
                Case en_LcTableName.成品粉.ToString
                    strZl = ",sum(tb_x832p_i232a) as " & en_PcTj.产出量.ToString
                Case Else
                    strZl = ",0 as " & en_PcTj.产出量.ToString
            End Select

            sql = "select '" & drLc("name") & "' as " & [Enum].GetName(GetType(en_PcTj), en_PcTj.名称) & _
            ",count(*) as " & [Enum].GetName(GetType(en_PcTj), en_PcTj.数量) & strZl & _
            " from " & drLc("text") & _
            " where  " & drLc("text") & "_jgrq between " & "'" & GF_gettrqsj(t1.Text) & " 00:00:00' and '" & GF_gettrqsj(t2.Text) & " 23:59:59" & "'"
            dtData = _D.GF_CreateDataSource(sql)
            dt.ImportRow(dtData.Rows(0))
        Next

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("批次详情")
        AddHandler menu1.Items(1).Click, AddressOf showCplist
        menu1.Items.Add("原料投放统计") '只计算本流程的原料使用情况
        AddHandler menu1.Items(2).Click, AddressOf showTftj
        menu1.Items.Add("原料使用统计") '计算所有流程的原料使用情况
        AddHandler menu1.Items(3).Click, AddressOf showTftj
        GS_DataGridViewbyDb(show1, dt, True, True, menu1)
        '显示数据说明
        Label1.Text = "共有记录" & show1.Rows.Count & "条！"
    End Sub
End Class