Public Class Frwljhbb

    Private Sub Frwljhbb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '''''''''''于2011年3月22日开发
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        cz() '初始化
        bbname() '根据表类别填充表名
    End Sub
    '月请购计划
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aa As New Frwljh
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
    End Sub
    '周齐料计划
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim bb As New Frqljh
        Me.AddOwnedForm(bb)
        bb.ShowDialog()
    End Sub
    '查询
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        cx()
    End Sub
    '在datatable里筛选
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim dt1 As New DataTable
            dt1 = DeepCode.DeepDoGridView.ToDataTable(show1)
            Dim bds As String = "1=1"
            Dim cxzd1 As String = ComboBox2.Text '时间字段
            If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
                bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
            End If
            Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB
            show1.DataSource = dt2
        Catch ex As Exception
        End Try
    End Sub

    '保存表
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If ComboBox3.Text = "" Then
            MsgBox("请输入表名")
            Exit Sub
        End If

        Dim sql As String = ""
        Dim tt1 As DateTime = DateTimePicker3.Text
        sql = "select tb_wljh_bname from tb_wljh where  tb_wljh_bname ='" & ComboBox3.Text & "' "
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt2.Rows.Count > 0 Then
            MsgBox("有相同的表名存在") : Exit Sub
        End If
        ''''
        Dim dt As New DataTable
        dt = DeepCode.DeepDoGridView.ToDataTable(show1)
        Dim r As Integer = dt.Rows.Count
        Dim n As Integer = dt.Columns.Count

        ''''
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        RS.open("tb_wljh", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        ''''

        For i As Integer = 0 To r - 1
            RS.addnew()
            Dim zd As String = "" : Dim zdl As String = ""
            For j As Integer = 0 To n - 1
                Try
                    zd = dt.Columns(j).ColumnName 'datatable列名
                    zdl = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mx='" & zd & "'and tb_biaozdinf_biao='tb_wljh' ", 1) '字段名
                    RS(zdl).value = dt.Rows(i)(zd)
                    RS("tb_wljh_blb").value = ComboBox1.Text
                    RS("tb_wljh_bname").value = ComboBox3.Text
                    RS("tb_wljh_bcrq").value = tt1
                Catch ex As Exception
                End Try
            Next
            RS.Update()
        Next

        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
        bbname() '根据表类别填充表名
        MsgBox("保存成功")
        GS_storelog3("保存表" & ComboBox3.Text, "MRP") '储存到日志
    End Sub
    '删除表
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If ComboBox3.Text = "" Then
            MsgBox("请选择表名")
            Exit Sub
        End If
        Dim sql As String = "delete from tb_wljh where tb_wljh_bname= '" & ComboBox3.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        MsgBox("删除成功")
        cx()
        GS_storelog3("删除表" & ComboBox3.Text, "MRP") '储存到日志
    End Sub
    '根据表类别填充表名
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        bbname() '根据表类别填充表名
    End Sub
    '打印
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub
    '关闭
    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub Frwljhbb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub wz()
        GroupBox2.Width = Me.Width - 30
        GroupBox2.Height = Me.Height - GroupBox2.Top - 50
    End Sub
  
  Public Sub cz() '初始化
        ComboBox1.SelectedIndex = 0
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("物料代码", GetType(String)) : dt.Columns.Add("物品分类", GetType(String))
        dt.Columns.Add("物料名称", GetType(String)) : dt.Columns.Add("规格", GetType(String))
        dt.Columns.Add("单位", GetType(String)) : dt.Columns.Add("物料类别", GetType(String))
        dt.Columns.Add("仓库存量", GetType(Double)) : dt.Columns.Add("在途量", GetType(Double))
        dt.Columns.Add("需求量", GetType(Double)) : dt.Columns.Add("计划请购量", GetType(Double))
        dt.Columns.Add("安全库存", GetType(Double)) : dt.Columns.Add("是否满足需求", GetType(String))
        dt.Columns.Add("采购周期(天)", GetType(Double)) : dt.Columns.Add("经济采购量", GetType(Double))
        dt.Columns.Add("差异", GetType(String)) : dt.Columns.Add("内检周期", GetType(String))
        dt.Columns.Add("尚未合格量", GetType(Double))
        '‘’‘’‘’‘’‘’‘’
        For i As Integer = 0 To dt.Columns.Count - 1 '根据datatable填充筛选框
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String"
                    ComboBox2.Items.Add(dt.Columns(i).ColumnName)
            End Select
        Next
        '’‘’‘’‘’‘’‘’‘
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub
    Public Sub bbname() '根据表类别填充表名
        Dim sql As String = "select tb_wljh_bname from tb_wljh where tb_wljh_blb='" & ComboBox1.Text & "'  group by tb_wljh_bname  "
        Dim dtbname As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(ComboBox3, dtbname, 0, "")
    End Sub
   Private Sub cx() '查询
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim sql As String = "select * from tb_wljh  where 1=1  "
        sql = sql & " and tb_wljh_blb = '" & ComboBox1.Text & "'"
        sql = sql & " and tb_wljh_bname = '" & ComboBox3.Text & "'"
        sql = sql & " and tb_wljh_bcrq  between '" & tt1 & "' and '" & tt2 & "' "

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim aa As New FrMrpWeight
        aa.ShowDialog()
    End Sub
End Class