Public Class Frcpdmbgbb
    Private Sub Frcpdmbgbb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
   
    End Sub
    Private Sub showsj()
        '''''''''''''''''''''''''''''''
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("说明", GetType(String)) : dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("批号", GetType(String)) : dt.Columns.Add("原始产品代码", GetType(String))
        dt.Columns.Add("原始加工代码", GetType(String)) : dt.Columns.Add("原始用途", GetType(String))
        dt.Columns.Add("修改后产品代码", GetType(String)) : dt.Columns.Add("修改后加工代码", GetType(String))
        dt.Columns.Add("修改后用途", GetType(String)) : dt.Columns.Add("备注", GetType(String))
        dt.Columns.Add("时间", GetType(Date)) : dt.Columns.Add("操作人工号", GetType(String))
        ''''''''''''''''''''''''''''
        Dim sql As String = "select tb_zclog_sm ,tb_zclog_gh,tb_zclog_rq from tb_zclog where tb_zclog_lx= '转换代码操作' "
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt1.Rows.Count - 1
            Dim mm As DataRow = dt.NewRow
            Dim jj() As String = dt1.Rows(i)(0).Split("；")
            For j As Integer = 0 To UBound(jj)
                mm(j) = jj(j) '填充日志里说明
                mm(UBound(jj) + 1) = dt1.Rows(i)(2) '填充时间
                mm(UBound(jj) + 2) = dt1.Rows(i)(1) '填充工号
            Next
            dt.Rows.Add(mm)
        Next
        ''''''''''''''    
        ComboBox2.Items.Clear()
        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            If dt.Columns(i).DataType.ToString = "System.String" Then
                ComboBox2.Items.Add(dt.Columns(i).Caption)
            End If
        Next
        '''''''''''''''''''''''''

        For i As Integer = 0 To dt.Rows.Count - 1 '去掉冒号显示 
            For j As Integer = 0 To dt.Columns.Count - 1
                If InStr(dt.Rows(i)(j), "：") <> 0 And dt.Columns(j).DataType.ToString <> "System.DateTime" Then
                    Dim kk() As String = dt.Rows(i)(j).Split("：") ' 由于时间字段里面也有冒号 提出来不是文本类型 所以加个判断
                    dt.Rows(i)(j) = kk(1)
                End If
            Next
        Next
        '''''''''''''''''''''''''
        GroupBox1.Text = dt.Rows.Count & "条记录"
        GS_DataGridViewbyDb(show1, dt, True, True)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        dt = DeepCode.DeepDoGridView.ToDataTable(show1)
        '''''''''''''''''''''''''''''''
        Dim bds As String = "1=1"
        Dim cxzd1 As String = ComboBox2.Text '时间字段

        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= "and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        ''''''''''''''''''''''''''''''''
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        bds &= "and [时间] >='" & tt1 & "' and [时间] <='" & tt2 & "' "

        '''''''''''''''''''''''''''''''''''
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt, bds) '查询并得到结果DB
        GroupBox1.Text = dt2.Rows.Count & "条记录"
        GS_DataGridViewbyDb(show1, dt2, True, True)

    End Sub
   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub
End Class