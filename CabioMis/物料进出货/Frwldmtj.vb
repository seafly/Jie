Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frwldmtj
    '使用本类必须给bbname和bbsql这2个文本框赋值
    '本类的最后一行是数字字段的求和
    '使用本类必须给bbname和bbsql这2个文本框赋值
    '本类的最后一行是数字字段的求和
    Private kk As String = "" '求和索引汇总
    Private dtpublic As DataTable '真实数据
    Private Sub Frwldmtj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.bbsql.Text = "select tb_i259b.tb_i259b_r596j,tb_i259b.tb_i259b_i231a,tb_i259b.tb_i259b_c24u,tb_i259b.tb_i259b_h200z,tb_i259b.tb_i259b_num,tb_i259b.tb_i259b_ckcl,tb_i259b.tb_i259b_p518h,tb_i259b.tb_i259b_q546i,tb_i259b.tb_i259b_y840q,tb_i259b.tb_i259b_bz,tb_i259b.tb_i259b_qaspjg,tb_i259b.tb_i259b_qajgsm,tb_i259b.tb_i259b_cpbzrq,tb_i259b.tb_i259b_zhbzq,tb_i259b.tb_i259b_kczl,tb_i259b.tb_i259b_yxx from tb_i259b where (1=1)  and tb_i259b.tb_i259b_r596j in ('包材')       and tb_i259b.tb_i259b_ckcl>0            and tb_i259b.tb_i259b_yxx in ('有效')  order by tb_i259b.tb_i259b_i231a ASC"
        'Me.Text = Me.bbname.Text
        'wz()
        cz()
    End Sub
    Private Sub cz() '初始化构造数据
        kk = ""
        ComboBox1.Items.Clear() : ComboBox2.Items.Clear() : ComboBox3.Items.Clear() : ComboBox4.Items.Clear() : TextBox1.Clear() : TextBox2.Clear()
        ComboBox1.Text = "" : ComboBox2.Text = "" : ComboBox3.Text = "" : ComboBox4.Text = ""
        dtpublic = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, Me.bbsql.Text) '获得真实数据
        Dim sjl As Integer = dtpublic.Rows.Count '数据量
        Dim zmbds As String = ""
        Dim dttemp As DataTable = Nothing
        If sjl <= 30 Then
            zmbds = " （共有" & sjl & "条记录）"
            dttemp = dtpublic.Copy '****************************下面负责把数据拷贝到临时表中来显示
        Else
            zmbds = " （共有" & sjl & "条记录,只显示最近30条，你可以使用筛选功能筛选所有记录）"
            '****************************下面负责把数据的最近30条拷贝到临时表中来显示
            dttemp = dtpublic.Clone
            For i As Integer = sjl - 30 To sjl - 1
                Dim p As DataRow = dttemp.NewRow
                p.ItemArray = dtpublic.Rows(i).ItemArray
                dttemp.Rows.Add(p)
            Next
        End If
        ToolStripLabel1.Text = zmbds
        If sjl = 0 Then Return

        '***************************
        For i As Integer = 0 To dttemp.Columns.Count - 1 '这里填充筛选框
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dttemp.Columns(i).Caption & "'", 4)
            Dim bm As String = ddbm(dttemp.Columns(i).Caption) '得到表名
            Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '得到表中文名称
            zwmz = bmcn & ":" & zwmz
            Select Case dttemp.Columns(i).DataType.ToString
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
            dttemp = dbqh(dttemp, kk) '求和并附加到最后一行
        End If
        showl.Columns.Clear() '避免头部消失
        '******************
        showl.DataSource = dttemp
        If kk <> "" Then
            GS_ysgx(showl) '求和最后一行颜色更新
        End If
        If showl.Columns.Count > 15 Then
            showl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            showl.RowHeadersWidth = 40

        End If
        GS_DataGridViewaddmenu(showl) '增加查看明细菜单
        GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
        Select Case Me.Text
            Case "原料—动态库存"
                Dim newcontrol As New ToolStripLabel
                With newcontrol
                    .ForeColor = Color.Red
                    .Text = "(仓库存量为库存实存，剩余库存为仓库存量+生产现场数量)"
                End With
                ToolStrip1.Items.Add(newcontrol)
        End Select
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

    Private Sub Frwldmtj_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    '在真实数据中筛选
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt1 As DataTable = dtpublic.Copy
            'If kk <> "" And dt1.Rows.Count > 0 Then '求和的情况下少转化一行
            '    dt1.Rows.RemoveAt(dt1.Rows.Count - 1)
            'End If
            Dim bds As String = Creatbds() '产生表达式
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
        Catch ex As Exception

        End Try

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



    Private Sub showl_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles showl.CellMouseDoubleClick
        With showl
            If .Rows.Count = 0 Then
                Return
            End If
            If .SelectedRows.Count = 0 Then
                Return
            End If
            Dim sql As String = ""
            Select Case Me.Text
                Case "成品油生产进度"
                    Dim ph As String = Null2String(.SelectedRows(0).Cells("tb_h195z_num2").Value) '得到精练的批号
                    ph = DeepCode.DeepDoStr.GF_zhzfccx(ph)
                    sql = "select tb_k306c.tb_k306c_num,tb_k306c.tb_k306c_jgrq,tb_k306c.tb_k306c_q559i,tb_mypl.tb_mypl_myhl from vw_k306c,tb_mypl where tb_k306c.tb_k306c_num in(" & ph & ") and tb_k306c.tb_k306c_sbid=tb_mypl.tb_mypl_ID"
                    'Case "成品粉生产进度"
                    '    Dim ph As String = .SelectedRows(0).Cells(2).Value '得到精练的批号
                    '    ph = DeepCode.DeepDoStr.GF_zhzfccx(ph)
                    '    sql = ""
                    '    sql = "select tb_n441f_cplb,tb_n441f_num2,tb_n441f_aaph,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_scdm from tb_n441f where tb_n441f_num in(" & ph & ")"
                Case Else
                    Return
            End Select
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            Dim a As New Frzdybb_mx
            a.Text = "精炼明细"
            a.showl.DataSource = dt
            GS_TranEtoC(a.showl) '将DataGridView列字段翻译成为中文描叙

            a.Show()
            GS_DataGridViewaddmenu(a.showl) '增加查看明细菜单
        End With
    End Sub

    Private Sub ButtonAVG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAVG.Click
        With showl
            Dim a As Integer = .Rows.Count
            If a < 2 Then
                Return
            End If
            For i As Integer = 0 To .Rows(a - 1).Cells.Count - 1
                Dim s As Object = .Rows(a - 1).Cells(i).Value
                If IsNumeric(s) = True Then
                    .Rows(a - 1).Cells(i).Value = s / (a - 1)
                End If
            Next

        End With
    End Sub

    Public Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
    Private Function Creatbds() As String

        Dim bdss As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) '时间字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bdss &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '文本字段
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then

            End If
            bdss &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
        Dim cxzd3 As String = gettruezdm(ComboBox3.Text) '数字字段
        If cxzd3 <> "" And TextBox2.Text.Trim <> "" Then
            cxzd3 = "[" & cxzd3 & "]"
            Dim sz As String = TextBox2.Text.Trim
            sz = Replace(sz, "，", ",") '怕出现中文逗号
            Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
            If nnn <> "" Then
                bdss &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
            End If
        End If
        Return bdss

    End Function

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.bbsql.Text = "select tb_i259b.tb_i259b_r596j,tb_i259b.tb_i259b_i231a,tb_i259b.tb_i259b_c24u,tb_i259b.tb_i259b_h200z,tb_i259b.tb_i259b_num,tb_i259b.tb_i259b_ckcl,tb_i259b.tb_i259b_p518h,tb_i259b.tb_i259b_q546i,tb_i259b.tb_i259b_y840q,tb_i259b.tb_i259b_bz,tb_i259b.tb_i259b_qaspjg,tb_i259b.tb_i259b_qajgsm,tb_i259b.tb_i259b_cpbzrq,tb_i259b.tb_i259b_zhbzq,tb_i259b.tb_i259b_kczl,tb_i259b.tb_i259b_yxx from tb_i259b where (1=1)  and tb_i259b.tb_i259b_r596j  like '%包材%'      and tb_i259b.tb_i259b_ckcl>0            and tb_i259b.tb_i259b_yxx in ('有效')  order by tb_i259b.tb_i259b_i231a ASC"
        cz()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.bbsql.Text = "select tb_i259b.tb_i259b_r596j,tb_i259b.tb_i259b_i231a,tb_i259b.tb_i259b_c24u,tb_i259b.tb_i259b_h200z,tb_i259b.tb_i259b_num,tb_i259b.tb_i259b_ckcl,tb_i259b.tb_i259b_p518h,tb_i259b.tb_i259b_q546i,tb_i259b.tb_i259b_y840q,tb_i259b.tb_i259b_bz,tb_i259b.tb_i259b_qaspjg,tb_i259b.tb_i259b_qajgsm,tb_i259b.tb_i259b_cpbzrq,tb_i259b.tb_i259b_zhbzq,tb_i259b.tb_i259b_kczl,tb_i259b.tb_i259b_yxx from tb_i259b where (1=1)  and tb_i259b.tb_i259b_r596j like '%原料%'    and tb_i259b.tb_i259b_ckcl>0            and tb_i259b.tb_i259b_yxx in ('有效')  order by tb_i259b.tb_i259b_i231a ASC"
        cz()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim aa As New Frwldmhz
        aa.ShowDialog()
    End Sub
End Class