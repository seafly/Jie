Public Class frcpfcx

    Private Sub frcpfcx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        'Call cx(ListView1, "", "")
        'DateTimePicker1.Value = DateAdd(DateInterval.Month, -1, Date.Today)
        Label6.Visible = False : Label5.Visible = False
        DateTimePicker1.Visible = False : DateTimePicker2.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sj1, sj2 As Date
        sj1 = DateTimePicker1.Value : sj2 = DateTimePicker2.Value
        If sj1 > sj2 Then
            MsgBox("错误！您输入的开始时间大于结束时间。请正确选择时间段！") : Exit Sub
        End If
        Call cx(ListView1, sj1, sj2)
    End Sub

    Private Sub cx(ByVal lv As ListView, ByVal sj1 As String, ByVal sj2 As String)
        lv.Clear()
        Dim sql As String = "select * from vw_x832p where tb_x832p_sbtb ='tb_pljh'"
        If sj1 <> "" And sj2 <> "" Then
            sql = sql & " and tb_x832p_jgrq between '" & sj1 & "' and '" & sj2 & "'"
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dt.Columns.Add("混批重量")
        Dim ls As Integer = dt.Columns.Count - 1
        Dim cc As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_pljh_id,tb_pljh_hpzl from tb_pljh")
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim sbid As Integer = dt.Rows(i)("tb_x832p_sbid")
            dt.Rows(i)(ls) = GF_cnwithen(cc, "tb_pljh_id=" & sbid, 1)
        Next

        'MsgBox(sj2 & "……" & sj1)

        If dt.Rows.Count = 0 Then
            MsgBox("没有查询到记录！") : Exit Sub
        End If
        '去掉datatable中的 上、下步表，表id，操作人工号
        If dt.Columns.Contains("tb_x832p_xbtb") = True Then
            dt.Columns.Remove("tb_x832p_xbtb") : dt.Columns.Remove("tb_x832p_glid")
        End If
        If dt.Columns.Contains("tb_x832p_sbtb") = True Then
            dt.Columns.Remove("tb_x832p_sbtb") : dt.Columns.Remove("tb_x832p_sbid")
        End If
        If dt.Columns.Contains("tb_x832p_czrgh") = True Then
            dt.Columns.Remove("tb_x832p_czrgh")
        End If
        If dt.Columns.Contains("tb_x832p_qaczrgh") = True Then
            dt.Columns.Remove("tb_x832p_qaczrgh")
        End If
        If dt.Columns.Contains("tb_x832p_qcczrgh") = True Then
            dt.Columns.Remove("tb_x832p_qcczrgh")
        End If
        '
        GS_useviewbydb2(lv, dt, -1, 100)
    End Sub


    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, "混批成品粉查询结果", Me)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Label6.Visible = True : Label5.Visible = True
            DateTimePicker1.Visible = True : DateTimePicker2.Visible = True
            CheckBox1.Enabled = False
        End If
    End Sub
End Class