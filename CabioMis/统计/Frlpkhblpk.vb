Public Class Frlpkhblpk
    Private kk As String = "" '求和索引汇总
    Private djsm As String = "" '点击的是什么
    Private Sub Frlpkhblpk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
        cz("毛油")
        GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
    End Sub
    Private Sub cz(ByVal str As String) '初始化构造数据
        djsm = str
        Dim cxsql As String = ""
        Dim strTbName As String = ""
        Dim iLyb As Integer = -1
        Select Case djsm
            Case "毛油"
                'cxsql = "select tb_x825pkc.tb_x825pkc_cplb,tb_x825pkc.tb_x825pkc_mingc,tb_x825pkc.tb_x825pkc_jiagdm,tb_x825pkc.tb_x825pkc_num,tb_x825pkc.tb_x825pkc_ckcl,tb_x825pkc.tb_x825pkc_sykczl,tb_x825pkc.tb_x825pkc_cfdd,tb_x825pkc.tb_x825pkc_qaspjg,tb_x825pkc.tb_x825pkc_qajgsm,tb_x825pkc.tb_x825pkc_jgrq,tb_x825pkc.tb_x825pkc_m387e,tb_x825pkc_kczl,tb_x825pkc.tb_x825pkc_rkbz,tb_x825pkc.tb_x825pkc_yg,tb_x825pkc_rkts,tb_x825pkc.tb_x825pkc_wjbgrq,tb_x825pkc.tb_x825pkc_r600j,tb_x825pkc.tb_x825pkc_o479g ,tb_x825pkc.tb_x825pkc_q547i,tb_x825pkc.tb_x825pkc_u699m,tb_x825pkc.tb_x825pkc_bfb,tb_x825pkc.tb_x825pkc_kdlk,tb_x825pkc.tb_x825pkc_storagewzlk,tb_x825pkc.tb_x825pkc_storagemslk from tb_x825pkc where (1=1)    and tb_x825pkc.tb_x825pkc_ckcl>0   or tb_x825pkc.tb_x825pkc_sykczl>0          order by tb_x825pkc.tb_x825pkc_jgrq ASC"
                cxsql = "select tb_x825pkc.tb_x825pkc_cplb,tb_x825pkc.tb_x825pkc_mingc,tb_x825pkc.tb_x825pkc_jiagdm,tb_x825pkc.tb_x825pkc_num,tb_x825pkc.tb_x825pkc_ckcl,tb_x825pkc.tb_x825pkc_sykczl,tb_x825pkc.tb_x825pkc_cfdd,tb_x825pkc.tb_x825pkc_qaspjg,tb_x825pkc.tb_x825pkc_qajgsm,tb_x825pkc.tb_x825pkc_jgrq,tb_x825pkc_kczl,tb_x825pkc.tb_x825pkc_rkbz,tb_x825pkc.tb_x825pkc_yg,tb_x825pkc_rkts,tb_x825pkc.tb_x825pkc_wjbgrq,tb_x825pkc.tb_x825pkc_bfb,tb_x825pkc.tb_x825pkc_kdlk,tb_x825pkc.tb_x825pkc_storagewzlk,tb_x825pkc.tb_x825pkc_storagemslk from tb_x825pkc where (1=1)    and tb_x825pkc.tb_x825pkc_ckcl>0   or tb_x825pkc.tb_x825pkc_sykczl>0          order by tb_x825pkc.tb_x825pkc_jgrq ASC"
                strTbName = en_LcTableName.毛油.YanGetEnText
                iLyb = en_LcTableName.毛油
            Case "报废毛油"
                cxsql = "select tb_x825pkc.tb_x825pkc_cplb,tb_x825pkc.tb_x825pkc_mingc,tb_x825pkc.tb_x825pkc_jiagdm,tb_x825pkc.tb_x825pkc_num,tb_x825pkc.tb_x825pkc_bf,tb_x825pkc.tb_x825pkc_m387e,tb_x825pkc.tb_x825pkc_bfmx,tb_x825pkc_kczl,tb_x825pkc.tb_x825pkc_rkbz,tb_x825pkc.tb_x825pkc_jgrq,tb_x825pkc.tb_x825pkc_ckcl,tb_x825pkc.tb_x825pkc_cfdd,tb_x825pkc.tb_x825pkc_qaspjg,tb_x825pkc.tb_x825pkc_qajgsm,tb_x825pkc.tb_x825pkc_bfb,tb_x825pkc.tb_x825pkc_kdlk,tb_x825pkc.tb_x825pkc_storagewzlk,tb_x825pkc.tb_x825pkc_storagemslk from tb_x825pkc where (1=1)    and tb_x825pkc.tb_x825pkc_bf>0        order by tb_x825pkc.tb_x825pkc_cplb ASC ,tb_x825pkc.tb_x825pkc_num ASC"

            Case "成品油"
                cxsql = "select tb_h195zkc.tb_h195zkc_cplb,tb_h195zkc.tb_h195zkc_mingc,tb_h195zkc.tb_h195zkc_jiagdm,tb_h195zkc.tb_h195zkc_num,tb_h195zkc.tb_h195zkc_num2,tb_h195zkc.tb_h195zkc_ckcl,tb_h195zkc.tb_h195zkc_sykczl,tb_h195zkc.tb_h195zkc_cfdd,tb_h195zkc.tb_h195zkc_qaspjg,tb_h195zkc_qaytjy,tb_h195zkc.tb_h195zkc_qajgsm,tb_h195zkc.tb_h195zkc_jgrq,tb_h195zkc.tb_h195zkc_yg,tb_h195zkc.tb_h195zkc_c6u,tb_h195zkc.tb_h195zkc_c28u,tb_h195zkc.tb_h195zkc_wjbgrq,tb_h195zkc_kczl,tb_h195zkc.tb_h195zkc_rkbz,tb_h195zkc_cw,tb_h195zkc_bfb,tb_h195zkc_kdlk,tb_h195zkc_storagewzlk,tb_h195zkc_storagemslk from tb_h195zkc where (1=1)    and tb_h195zkc.tb_h195zkc_ckcl>0   or tb_h195zkc.tb_h195zkc_sykczl>0          order by tb_h195zkc.tb_h195zkc_jgrq ASC"
            Case "报废成品油"
                cxsql = "select tb_h195zkc.tb_h195zkc_cplb,tb_h195zkc.tb_h195zkc_mingc,tb_h195zkc.tb_h195zkc_jiagdm,tb_h195zkc.tb_h195zkc_num,tb_h195zkc.tb_h195zkc_bf,tb_h195zkc.tb_h195zkc_c6u,tb_h195zkc.tb_h195zkc_bfmx,tb_h195zkc_kczl,tb_h195zkc.tb_h195zkc_rkbz,tb_h195zkc.tb_h195zkc_jgrq,tb_h195zkc.tb_h195zkc_ckcl,tb_h195zkc.tb_h195zkc_cfdd,tb_h195zkc.tb_h195zkc_qaspjg,tb_h195zkc_qaytjy,tb_h195zkc.tb_h195zkc_qajgsm,tb_h195zkc.tb_h195zkc_bfb,tb_h195zkc.tb_h195zkc_kdlk,tb_h195zkc.tb_h195zkc_storagewzlk,tb_h195zkc.tb_h195zkc_storagemslk from tb_h195zkc where (1=1)    and tb_h195zkc.tb_h195zkc_bf>0        order by tb_h195zkc.tb_h195zkc_cplb ASC ,tb_h195zkc.tb_h195zkc_num ASC"

            Case "成品粉"
                cxsql = "select tb_x832pkc.tb_x832pkc_cplb,tb_x832pkc.tb_x832pkc_mingc,tb_x832pkc.tb_x832pkc_jiagdm,tb_x832pkc.tb_x832pkc_num,tb_x832pkc.tb_x832pkc_ckcl,tb_x832pkc.tb_x832pkc_sykczl,tb_x832pkc_cw,tb_x832pkc.tb_x832pkc_qaspjg,tb_x832pkc_qaytjy,tb_x832pkc.tb_x832pkc_qajgsm,tb_x832pkc.tb_x832pkc_jgrq,tb_x832pkc.tb_x832pkc_scdm,tb_x832pkc.tb_x832pkc_yg,tb_x832pkc.tb_x832pkc_num2,tb_x832pkc_kczl,tb_x832pkc.tb_x832pkc_wjbgrq,tb_x832pkc.tb_x832pkc_rkbz,tb_x832pkc.tb_x832pkc_a948s,tb_x832pkc.tb_x832pkc_d65v,tb_x832pkc.tb_x832pkc_bzxs,tb_x832pkc.tb_x832pkc_f119x,tb_x832pkc.tb_x832pkc_s626k,tb_x832pkc.tb_x832pkc_bfb,tb_x832pkc.tb_x832pkc_kdlk,tb_x832pkc.tb_x832pkc_storagewzlk,tb_x832pkc.tb_x832pkc_storagemslk from tb_x832pkc where (1=1)    and tb_x832pkc.tb_x832pkc_sykczl>0 or tb_x832pkc.tb_x832pkc_ckcl>0          order by tb_x832pkc.tb_x832pkc_cplb ASC ,tb_x832pkc.tb_x832pkc_num ASC"
            Case "报废成品粉"
                cxsql = "select tb_x832pkc.tb_x832pkc_cplb,tb_x832pkc.tb_x832pkc_mingc,tb_x832pkc.tb_x832pkc_jiagdm,tb_x832pkc.tb_x832pkc_num,tb_x832pkc.tb_x832pkc_bf,tb_x832pkc.tb_x832pkc_bfmx,tb_x832pkc_kczl,tb_x832pkc.tb_x832pkc_rkbz,tb_x832pkc.tb_x832pkc_jgrq,tb_x832pkc.tb_x832pkc_ckcl,tb_x832pkc.tb_x832pkc_cfdd,tb_x832pkc.tb_x832pkc_qaspjg,tb_x832pkc_qaytjy,tb_x832pkc.tb_x832pkc_qajgsm,tb_x832pkc.tb_x832pkc_bfb,tb_x832pkc.tb_x832pkc_kdlk,tb_x832pkc.tb_x832pkc_storagewzlk,tb_x832pkc.tb_x832pkc_storagemslk from tb_x832pkc where (1=1)    and tb_x832pkc.tb_x832pkc_bf>0        order by tb_x832pkc.tb_x832pkc_cplb ASC ,tb_x832pkc.tb_x832pkc_num ASC"
        End Select
        kk = ""
        ComboBox1.Items.Clear() : ComboBox2.Items.Clear() : ComboBox3.Items.Clear() : ComboBox4.Items.Clear() : TextBox1.Clear() : TextBox2.Clear()
        ComboBox1.Text = "" : ComboBox2.Text = "" : ComboBox3.Text = "" : ComboBox4.Text = ""
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, cxsql)

        '*************************添加QC结果********************************
        If strTbName <> "" Then
            cl_theCl.setQcshowView(dt, iLyb, isAddva:=False)
            For i As Integer = 0 To dt.Rows.Count - 1  '将结果作为列添加进去
                Dim Sql As String = "select  * from tb_QcVa where tb_QcVa_Qcbs =" &
                "(select top 1 tb_QcJc_ID from tb_QcJc where tb_QcJc_jcb='" & strTbName & "' " &
                "and tb_QcJc_wlbs=(select " & strTbName & "_ID from " & strTbName & " where " & strTbName & "_num='" & dt.Rows(i)(strTbName & "kc_num") & "') order by tb_QcJc_ID desc)"
                Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(Sql)
                For Each tDr As DataRow In tDt.Rows
                    Try
                        dt.Rows(i)(tDr("tb_QcVa_xmmc").trim) = tDr("tb_QcVa_xmva").trim
                    Catch ex As Exception

                    End Try
                Next
            Next
        End If
        '*********************************************************

        GroupBox1.Text = str & " 结果内筛选（共有" & dt.Rows.Count & "条记录）"
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
            'For i As Integer = 0 To showl.Columns.Count - 1
            '    If showl.Columns(i).Visible = True Then
            '        showl.Columns(i).Width = 40
            '    End If

            'Next
        End If
        GS_DataGridViewaddmenu(showl) '增加查看明细菜单
    End Sub


    Private Sub TB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.Click, TB2.Click, TB3.Click, TB4.Click, TB5.Click, TB6.Click
        cz(sender.text)
        GS_TranEtoC(showl) '将DataGridView列字段翻译成为中文描叙
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        If kk <> "" Then '求和的情况下少转化一行
            dt1 = DeepCode.DeepDoGridView.ToDataTable(showl, 0, showl.Rows.Count - 2)
        Else
            dt1 = DeepCode.DeepDoGridView.ToDataTable(showl)
        End If

        Dim bds As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) '时间字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '文本字段
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
        GroupBox1.Text = djsm & " 结果内筛选（共有" & dt2.Rows.Count & "条记录）"
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
        cz(djsm)
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
                    '求和
                    Dim zs As Double = DeepCode.DeepDoDataTable.GF_jsColumnTotal(db, n, 0, .Rows.Count - 2)

                    .Rows(.Rows.Count - 1)(n) = zs '赋值
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
    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub wz()

        showl.Width = Me.Width - 10
        showl.Height = Me.Height - showl.Top - 50
    End Sub

    Private Sub TOEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOEXCEL.Click
        GS_toexcel(showl, GroupBox1.Text, Me)
    End Sub

    Private Sub Frlpkhblpk_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim nform As New Frzdybb
        Dim sql As String = "select * from tb_sjbf"
        nform.bbname.Text = "良品库和不合格品库备份"
        nform.bbsql.Text = sql
        nform.ShowDialog()
    End Sub

    Private Sub TB7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB7.Click
        Dim nform As New Frcphzb
        nform.ShowDialog()
    End Sub
End Class