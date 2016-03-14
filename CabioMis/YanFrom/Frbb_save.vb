Imports _S = CabioMis.Cl_StrMag
Imports _D = CabioMis.Cl_DataMag
Imports _E = CabioMis.EnumDescription

Public Class Frbb_save
    Public m_bbDt As DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '名称和编号不能完全一样
        If _D.GF_CreateDataSource("select * from tb_xtszNr where tb_xtszNr_bs=" & en_xtLb.统计报表 & " " & _
                                  " and tb_xtszNr_mc='" & tb_xtszNr_mc.Text & "' and tb_xtszNr_dm='"& tb_xtszNr_dm.Text &"'").Rows.Count > 0 Then
            If MsgBox("已有相同的报表,是否删除原有报表！", MsgBoxStyle.YesNo) = vbYes Then
                cl_theCl.delTjBb(tb_xtszNr_mc.Text, tb_xtszNr_dm.Text)
            Else
                Return
            End If
        End If
        '先保存报表名称
        Dim strSaveBs As String = _D.insertData("tb_xtszNr", New String(,) {{"tb_xtszNr_bs", en_xtLb.统计报表}, _
                                                  {"tb_xtszNr_mc", tb_xtszNr_mc.Text}, _
                                                  {"tb_xtszNr_dm", tb_xtszNr_dm.Text}})
        '保存报表内容
        For i As Integer = 0 To m_bbDt.Rows.Count - 1
            For j As Integer = 0 To m_bbDt.Columns.Count - 1
                _D.insertData("tb_bcbb", New String(,) {{"tb_bcbb_zd", m_bbDt.Columns(j).ColumnName}, _
                                                        {"tb_bcbb_va", _S.YanNullToEmpty(m_bbDt.Rows(i)(j))}, _
                                                        {"tb_bcbb_bs", strSaveBs}, _
                                                        {"tb_bcbb_bh", i}})
            Next
        Next
        MsgBox("保存完毕！")
        m_bbDt = Nothing
        MyBase.Close()
    End Sub

    Private Sub Frbb_save_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "select distinct tb_xtszNr_mc from tb_xtszNr where tb_xtszNr_bs=" & en_xtLb.统计报表
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_xtszNr_mc.Items.Add(dt.Rows(0)(0))
        Next
    End Sub
End Class