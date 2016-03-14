Public Class Frylcx

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = TextBox1.Text.Trim
        If ph = "" Then
            Exit Sub
        End If
        Dim bm(7) As String
        bm(0) = "tb_b970t" : bm(1) = "tb_b959t" : bm(2) = "tb_i234a"
        bm(3) = "tb_k306c" : bm(4) = "tb_h195z" : bm(5) = "tb_n441f" : bm(6) = "tb_x832p" : bm(7) = "tb_p525h"
        For i As Integer = 0 To UBound(bm)
            Dim sql As String = "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao='" & bm(i) & "' and right(tb_biaozdinf_mx,2)='批号'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            sql = " select " & zhzfc2(bm(i)) & " from " & bm(i) & "  where " & zhzfc(dt, ph)
            Dim zz1 As String = "GroupBox" & (i)
            Dim zz2 As String = "ListView" & (i)
            If i = 6 Then
                zz1 = "GroupBox10"
                zz2 = "ListView10"
            End If
            If i = 7 Then
                zz1 = "GroupBox11"
                zz2 = "ListView11"
            End If

            dt = GF_CreateDataSource(G_cnnstr, sql)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''统计记录数'''''''''
            Me.Controls("FlowLayoutPanel1").Controls(zz1).Text = Me.Controls("FlowLayoutPanel1").Controls(zz1).Text & " (共有" & dt.Rows.Count & "条记录)"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            GS_DbSum(dt) '自动最后一行求和
            '‘’‘’‘’‘’‘’‘’‘’‘’‘’
            Dim ll As DataGridView = Me.Controls("FlowLayoutPanel1").Controls(zz1).Controls(zz2)
            GS_DataGridViewbyDb(ll, dt, True, True)
        Next
       


        '‘’‘’‘’‘’‘’‘’‘’‘’‘’
        '''''''''统计原料记录数''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_i259b where tb_i259b_num like '%" & ph & "%' ")
        Me.Controls("FlowLayoutPanel1").Controls("GroupBox6").Text &= " (共有" & dt1.Rows.Count & "条记录)"
        GS_DbSum(dt1) '自动最后一行求和
        Call GS_DataGridViewbyDb(ListView6, dt1, "0", True, True)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''糖罐
        Dim sql1 As String = "select * from tb_tg where tb_tg_ph like  '%" & ph & "%'"
        dt1 = GF_CreateDataSource(G_cnnstr, sql1)
        GroupBox7.Text = "糖罐(共有" & dt1.Rows.Count & "条记录)"
        GS_DbSum(dt1) '自动最后一行求和
        Call GS_DataGridViewbyDb(ListView7, dt1, "0", True, True)
        ''''''''''''''''''''''''''''''''''''''''''''''''碱罐
        sql1 = "select * from tb_jg where tb_jg_ph like  '%" & ph & "%'"
        dt1 = GF_CreateDataSource(G_cnnstr, sql1)
        GroupBox8.Text = "碱罐(共有" & dt1.Rows.Count & "条记录)"
        GS_DbSum(dt1) '自动最后一行求和
        Call GS_DataGridViewbyDb(ListView8, dt1, "0", True, True)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''其它原辅材料
        sql1 = "select * from tb_jch where tb_jch_num like  '%" & ph & "%' and  tb_jch_cz not in('出','进')"
        dt1 = GF_CreateDataSource(G_cnnstr, sql1)
        GroupBox9.Text = "其它原辅材料(共有" & dt1.Rows.Count & "条记录)"
        GS_DbSum(dt1) '自动最后一行求和
        Call GS_DataGridViewbyDb(ListView9, dt1, "0", True, True)
        '''''''''''''''''''''''''''''
        SetLastRowColor() '使有数据的列表最后一行合计变色
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        frchaph.xisykj2(FlowLayoutPanel1, ComboBoxdcxz)
    End Sub

    Private Sub Frylcx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
    End Sub
    Private Sub weizhi()
        FlowLayoutPanel1.Width = Me.Width - FlowLayoutPanel1.Left - 10
        FlowLayoutPanel1.Height = Me.Height - FlowLayoutPanel1.Top - 10
        GroupBox0.Width = FlowLayoutPanel1.Width - 20

        GroupBox1.Width = GroupBox0.Width
        GroupBox2.Width = GroupBox0.Width
        GroupBox3.Width = GroupBox0.Width
        GroupBox4.Width = GroupBox0.Width
        GroupBox5.Width = GroupBox0.Width
        GroupBox6.Width = GroupBox0.Width
        GroupBox7.Width = GroupBox0.Width
        GroupBox8.Width = GroupBox0.Width
        GroupBox9.Width = GroupBox0.Width
        GroupBox10.Width = GroupBox0.Width
        GroupBox11.Width = GroupBox0.Width
    End Sub
    Private Function zhzfc(ByVal db As DataTable, ByVal str As String) As String
        zhzfc = ""
        For i As Integer = 0 To db.Rows.Count - 1
            zhzfc = zhzfc & db.Rows(i)(0) & " like '%" & str & "%' or "
        Next
        zhzfc = Microsoft.VisualBasic.Left(zhzfc, Len(zhzfc) - 3)
    End Function
    Private Function zhzfc2(ByVal str As String) As String
        zhzfc2 = ""
        Dim Sql As String = "select tb_biaozdinf_mc from tb_biaozdinf "
        Sql = Sql & "where tb_biaozdinf_biao='" & str & "' and tb_biaozdinf_mx not in ('上步表','下步表','上步ID','下步ID','主键')"
        Dim db As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        For i As Integer = 0 To db.Rows.Count - 1
            zhzfc2 = zhzfc2 & db.Rows(i)(0) & ","
        Next
        zhzfc2 = GF_removedh(zhzfc2)
    End Function

    Private Sub Frylcx_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Public Sub dc(ByVal str As FlowLayoutPanel, ByVal ComboBoxdcxz As CheckedListBox)
        Dim dcsm As Integer = ComboBoxdcxz.CheckedItems.Count
        If dcsm = 0 Then
            Return
        End If
        Dim dhk As New SaveFileDialog
        dhk.Filter = "EXCEL电子表格|*.XLS"
        If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim wjm As String = dhk.FileName : dhk = Nothing
        If wjm = "" Then
            Exit Sub
        End If
        Dim ss As New DeepCode.DeepDoExcel(True, wjm) : Dim jj As Integer = 1
        For i As Integer = 0 To dcsm - 1
            Dim n As String = ComboBoxdcxz.CheckedItems.Item(i).ToString
            With str
                For j As Integer = 0 To .Controls.Count - 1
                    Dim kk As Control = .Controls(j)
                    If kk.GetType.ToString = "System.Windows.Forms.GroupBox" And n = kk.Text Then
                        Dim m As Control = kk.Controls(0)
                        jj = gz2(ss, m, 15, n, jj)
                    End If
                Next
            End With
        Next
        Dim jcdh As Integer = System.GC.GetGeneration(ss) : ss = Nothing : System.GC.Collect(jcdh)
        MsgBox("生成电子表格完毕！")
        Me.TopMost = False
        System.Diagnostics.Process.Start(wjm)
    End Sub
    Public Sub pc(ByVal str As Panel, ByVal ComboBoxdcxz As CheckedListBox)
        Dim dcsm As Integer = ComboBoxdcxz.CheckedItems.Count
        If dcsm = 0 Then
            Return
        End If
        Dim dhk As New SaveFileDialog
        dhk.Filter = "EXCEL电子表格|*.XLS"
        If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim wjm As String = dhk.FileName : dhk = Nothing
        If wjm = "" Then
            Exit Sub
        End If
        Dim ss As New DeepCode.DeepDoExcel(True, wjm) : Dim jj As Integer = 1
        For i As Integer = 0 To dcsm - 1
            Dim n As String = ComboBoxdcxz.CheckedItems.Item(i).ToString
            With str
                For j As Integer = 0 To .Controls.Count - 1
                    Dim kk As Control = .Controls(j)
                    If kk.GetType.ToString = "System.Windows.Forms.GroupBox" And n = kk.Text Then
                        Dim m As Control = kk.Controls(0)
                        jj = gz2(ss, m, 15, n, jj)
                    End If
                Next
            End With
        Next
        Dim jcdh As Integer = System.GC.GetGeneration(ss) : ss = Nothing : System.GC.Collect(jcdh)
        MsgBox("生成电子表格完毕！")
        Me.TopMost = False
        System.Diagnostics.Process.Start(wjm)
    End Sub
    Public Sub dc(ByVal str As FlowLayoutPanel)
        Dim dhk As New SaveFileDialog
        dhk.Filter = "EXCEL电子表格|*.XLS"
        If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim wjm As String = dhk.FileName : dhk = Nothing
        If wjm = "" Then
            Exit Sub
        End If
        Dim ss As New DeepCode.DeepDoExcel(True, wjm) : Dim jj As Integer = 1
        For i As Integer = 0 To str.Controls.Count - 1
            Dim kk As Control = str.Controls(i)
            If kk.GetType.ToString = "System.Windows.Forms.GroupBox" Then
                Dim m As Control = kk.Controls(0)
                jj = gz2(ss, m, 15, kk.Text, jj)
            End If
        Next
        Dim jcdh As Integer = System.GC.GetGeneration(ss) : ss = Nothing : System.GC.Collect(jcdh)
        MsgBox("生成电子表格完毕！")
        Me.TopMost = False
        System.Diagnostics.Process.Start(wjm)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dc(FlowLayoutPanel1, ComboBoxdcxz)
    End Sub
    Public Function gz(ByVal nn As DeepDoExcel, ByVal lst As ListView, ByVal kd As Integer, ByVal bt As String, ByVal ks As Integer) As Integer
        If lst.Items.Count = 0 Then
            gz = ks
        Else
            gz = nn.CreateByListview(lst, kd, bt, ks)

        End If
    End Function
    Public Function gz2(ByVal nn As DeepCode.DeepDoExcel, ByVal lst As DataGridView, ByVal kd As Integer, ByVal bt As String, ByVal ks As Integer) As Integer
        If GF_getListViewsz(lst) = 0 Then
            Return ks
        Else
            Dim cc As Windows.Forms.DataGridView = lst
            'Dim dt1 As DataTable = DeepCode.DeepDoGridView.ToDataTable(cc)
            Return nn.CreateByDataGridView(cc, kd, bt, ks)
        End If
    End Function
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    '使有数据的列表最后一行合计变色
    Private Sub SetLastRowColor()
        For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            Dim c As GroupBox = FlowLayoutPanel1.Controls(i)
            Dim b As DataGridView = c.Controls(0)
            With b
                Dim a As Integer = .Rows.Count - 1
                If a > -1 Then
                    .Rows(a).DefaultCellStyle.BackColor = Color.GreenYellow
                End If

            End With

        Next
    End Sub
End Class