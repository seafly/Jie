Public Class FrFGHTTJB
    Private kk As String = "" '求和索引汇总
    Private Sub FrFGHTTJB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        wz()
        cz()
        GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
     
    End Sub
    Private Sub cz() '初始化构造数据
        kk = ""
        ComboBox1.Items.Clear() : ComboBox2.Items.Clear() : ComboBox3.Items.Clear() : ComboBox4.Items.Clear() : TextBox1.Clear() : TextBox2.Clear()
        ComboBox1.Text = "" : ComboBox2.Text = "" : ComboBox3.Text = "" : ComboBox4.Text = ""
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql1 As String = "select tb_x825p.tb_x825p_num3,tb_x825p.tb_x825p_jgrq2,tb_x825p.tb_x825p_d42v,tb_x825p.tb_x825p_l349d,tb_q546i.tb_q546i_j300c,tb_q546i.tb_q546i_x817p,tb_q546i.tb_q546i_n455g,tb_q546i.tb_q546i_g184z,tb_x825p.tb_x825p_r583j,tb_q546i.tb_q546i_n448f,tb_q546i.tb_q546i_v744n,tb_q546i.tb_q546i_f144x,tb_x825p.tb_x825p_d68w,tb_q546i.tb_q546i_a941s,tb_q546i.tb_q546i_bz,tb_x825p.tb_x825p_qaspjg from  tb_x825p, tb_q546i"
        sql1 &= " where tb_x825p_num2=tb_q546i_num and tb_q546i_t651l='烘干'        order by tb_x825p.tb_x825p_jgrq2 asc"
        Dim sql2 As String = "select tb_x825p.tb_x825p_num3,tb_x825p.tb_x825p_jgrq2,tb_x825p.tb_x825p_d42v,tb_x825p.tb_x825p_l349d,tb_q546i.tb_q546i_j300c,tb_q546i.tb_q546i_x817p,tb_q546i.tb_q546i_n455g,tb_q546i.tb_q546i_g184z,tb_x825p.tb_x825p_r583j,tb_q546i.tb_q546i_n448f,tb_q546i.tb_q546i_v744n,tb_q546i.tb_q546i_f144x,tb_x825p.tb_x825p_d68w,tb_q546i.tb_q546i_a941s,tb_q546i.tb_q546i_bz,tb_x825p.tb_x825p_qaspjg  from  tb_x825p, tb_q546i"
        sql2 &= " where tb_x825p_num2=tb_q546i_num and tb_q546i_t651l='放罐'        order by tb_x825p.tb_x825p_jgrq2 asc"
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql1)
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)
        Dim cwzfc As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim ph As String = dt.Rows(i)("tb_x825p_num3")
            Dim foundRows() As DataRow = dt1.Select("tb_x825p_num3='" & ph & "'")

            If foundRows.Length = 0 Then '干菌体水分、干菌体总油、干菌体AA”是等于烘干的记录
                cwzfc &= vbCrLf & "错误消息：" & ph & "未找到相应的烘干记录"
            End If
            If foundRows.Length > 1 Then '干菌体水分、干菌体总油、干菌体AA”是等于烘干的记录
                cwzfc &= vbCrLf & "错误消息：" & ph & "相应的烘干记录有" & foundRows.Length & " 条，应该只有1条记录"
            End If
            If foundRows.Length = 1 Then
                dt.Rows(i)("tb_q546i_n448f") = foundRows(0)("tb_q546i_n448f")
                dt.Rows(i)("tb_q546i_v744n") = foundRows(0)("tb_q546i_v744n")
                dt.Rows(i)("tb_q546i_f144x") = foundRows(0)("tb_q546i_f144x")
            End If

        Next
        If cwzfc <> "" Then
            MsgBox(cwzfc)
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ToolStripLabel1.Text = " （共有" & dt.Rows.Count & "条记录）"
        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4)
            Dim bm As String = frdzxf.ddbm(dt.Columns(i).Caption) '得到表名
            Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '得到表中文名称
            zwmz = bmcn & ":" & zwmz
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(zwmz)
                Case "System.DateTime" : ComboBox1.Items.Add(zwmz)
                Case "System.Decimal", "System.Short", "System.Integer", "System.Int32", "System.Long"
                    ComboBox3.Items.Add(zwmz)
                    kk &= i.ToString & ","
                    'Case Else
                    '    MsgBox(zwmz & ":" & dt.Columns(i).DataType.ToString)
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
            dt = dbqh(dt, kk) '求和并附加到最后一行
        End If
        showl.Columns.Clear() '避免头部消失
        showl.DataSource = dt

        If kk <> "" Then
            GS_ysgx(showl) '求和最后一行颜色更新
        End If
        If showl.Columns.Count > 15 Then
            showl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            showl.RowHeadersWidth = 40
          
        End If
        GS_DataGridViewaddmenu(showl) '增加查看明细菜单
    End Sub
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
        Dim dt1 As New DataTable
        If kk <> "" Then '求和的情况下少转化一行
            dt1 = DeepCode.DeepDoGridView.ToDataTable(showl, 0, showl.Rows.Count - 2)
        Else
            dt1 = DeepCode.DeepDoGridView.ToDataTable(showl)
        End If

        Dim bds As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) '文本字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '时间字段
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then
                Return
            End If
            bds &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
        Dim cxzd3 As String = gettruezdm(ComboBox3.Text) '数字字段
        If cxzd3 <> "" And TextBox2.Text.Trim <> "" Then
            cxzd3 = "[" & cxzd3 & "]"
            Dim sz As String = TextBox2.Text.Trim
            sz = Replace(sz, "，", ",") '怕出现中文逗号
            Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
            If nnn <> "" Then
                bds &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
            End If
        End If
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB
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
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cz()
        GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
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
    Private Function zhbds(ByVal zd As String, ByVal bd As String, ByVal wb As String) As String '置换表达式
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
End Class