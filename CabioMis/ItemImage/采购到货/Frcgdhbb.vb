﻿Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frcgdhbb
    Private dts As DataTable
    Private Sub Frcgdhbb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
        'showsj()

    End Sub
    Private Sub wz()
        GroupBox2.Width = Me.Width - 30
        GroupBox2.Height = Me.Height - GroupBox2.Top - 50
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub showsj()
        dts = New DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("物品分类", GetType(String))
        dt.Columns.Add("请购部门", GetType(String))
        dt.Columns.Add("请购人", GetType(String))
        dt.Columns.Add("请购日期", GetType(Date))
        dt.Columns.Add("要求到货日期", GetType(Date))
        dt.Columns.Add("物料代码", GetType(String))
        dt.Columns.Add("物品名称", GetType(String))
        dt.Columns.Add("规格型号", GetType(String))
        dt.Columns.Add("单位", GetType(String))
        dt.Columns.Add("请购数量", GetType(String))
        dt.Columns.Add("预期用途", GetType(String))
        dt.Columns.Add("请购状态", GetType(String))
        dt.Columns.Add("计划单号", GetType(String))
        dt.Columns.Add("请购单是否生效", GetType(String))
        dt.Columns.Add("单价", GetType(String))
        dt.Columns.Add("采购单号", GetType(String))
        dt.Columns.Add("合同/订单日期", GetType(Date))
        dt.Columns.Add("合同/订单负责人", GetType(String))
        dt.Columns.Add("订购总量", GetType(String))
        dt.Columns.Add("验收部门", GetType(String))
        dt.Columns.Add("预计次数", GetType(Integer))
        dt.Columns.Add("是否补货", GetType(String))
        dt.Columns.Add("预计到货日期", GetType(String))
        dt.Columns.Add("验收合格量", GetType(Integer))
        dt.Columns.Add("验收周期", GetType(String))
        dt.Columns.Add("验收时限", GetType(String))
        dt.Columns.Add("验收人", GetType(String))

        'Select Case ComboBox3.SelectedIndex
        '    Case 3
        '        Call dtall()
        '        dts = dtshow(dt, dtall)
        '        GS_DataGridViewbyDb(show1, dts, True, True)
        '        GroupBox2.Text = "共有" & dts.Rows.Count & "条记录" '
        '    Case 0
        '        Call dtqg2()
        '        dts = dtshow(dt, dtqg2)
        '        GS_DataGridViewbyDb(show1, dts, True, True)
        '        GroupBox2.Text = "共有" & dts.Rows.Count & "条记录" '
        '    Case 1
        '        Call dtcg()
        '        dts = dtshow(dt, dtcg)
        '        GS_DataGridViewbyDb(show1, dts, True, True)
        '        GroupBox2.Text = "共有" & dts.Rows.Count & "条记录" '
        '    Case 2
        '        Call dtdhgz()
        '        dts = dtshow(dt, dtdhgz)
        '        GS_DataGridViewbyDb(show1, dts, True, True)
        '        GroupBox2.Text = "共有" & dts.Rows.Count & "条记录" '
        'End Select
        Dim dr As DataRow
        Dim bzl As Integer = 0 '用于计算备注的条数
        If CheckBox1.Checked = True Then
            dr = dt.NewRow
            dr(0) = "请购单未生效"
            dt.Rows.Add(dr)
            bzl += 1
            Call dtqg2()
            dts = dtshow(dt, dtqg2)

        End If
        If CheckBox2.Checked = True Then
            dr = dt.NewRow
            dr(0) = "请购单已生效"
            dt.Rows.Add(dr)
            bzl += 1
            Call dtqg()
            dts = dtshow(dt, dtqg)

        End If
        If CheckBox3.Checked = True Then
            dr = dt.NewRow
            dr(0) = "已采购未到货"
            dt.Rows.Add(dr)
            bzl += 1
            Call dtcg()
            dts = dtshow(dt, dtcg)

        End If
        If CheckBox4.Checked = True Then
            dr = dt.NewRow
            dr(0) = "已到货未验收"
            dt.Rows.Add(dr)
            bzl += 1
            Call dtdhgz()
            dts = dtshow(dt, dtdhgz)

        End If
        If CheckBox5.Checked = True Then
            dr = dt.NewRow
            dr(0) = "已验收"
            dt.Rows.Add(dr)
            bzl += 1
            Call dtys()
            dts = dtshow(dt, dtys)

        End If
        GS_DataGridViewbyDb(show1, dts, True, True)
        GroupBox2.Text = "共有" & dts.Rows.Count - bzl & "条记录" '


        For i As Integer = 0 To show1.Rows.Count - 1
            Try
                If show1.Rows(i).Cells("验收时限").Value < Now().Date And show1.Rows(i).Cells("验收人").Value.ToString = "" Then
                    show1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow '变色
                    Dim cgdh As String = show1.Rows(i).Cells("采购单号").Value
                    For j As Integer = 0 To show1.Rows.Count - 1 '请购单相同的变色
                        If show1.Rows(j).Cells("采购单号").Value = cgdh Then
                            show1.Rows(j).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                    Next
                End If

            Catch ex As Exception

            End Try
            If show1.Rows(i).Cells(2).Value.ToString = "" Then ''''如果该行为插入的备注行则变色
                show1.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
        Next
        ComboBox2.Items.Clear() : ComboBox1.Items.Clear()
        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            'Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4)
            'Dim bm As String = frdzxf.ddbm(dt.Columns(i).Caption) '得到表名
            'Dim bm As String = ddbm(dt.Columns(i).Caption) '得到表名
            'Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '得到表中文名称
            'zwmz = bmcn & ":" & zwmz
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(dt.Columns(i).ColumnName)
                Case "System.DateTime" : ComboBox1.Items.Add(dt.Columns(i).ColumnName)

            End Select
        Next



    End Sub

    Private Sub Frcgdhbb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        dt1 = DeepCode.DeepDoGridView.ToDataTable(show1)
        MsgBox(dt1.Columns(0).Caption)
        Dim bds As String = "1=1"
        Dim cxzd1 As String = ComboBox2.Text '时间字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = ComboBox1.Text '文本字段
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then
                Return
            End If
            bds &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
        'Dim cxzd3 As String = gettruezdm(ComboBox3.Text) '数字字段
        'If cxzd3 <> "" And TextBox2.Text.Trim <> "" Then
        '    cxzd3 = "[" & cxzd3 & "]"
        '    Dim sz As String = TextBox2.Text.Trim
        '    sz = Replace(sz, "，", ",") '怕出现中文逗号
        '    'Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
        '    'If nnn <> "" Then
        '    '    bds &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
        '    'End If
        'End If
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB

        'If kk <> "" Then '下面自动完成求和汇总
        '    dt2 = dbqh(dt2, kk) '求和并附加到最后一行
        'End If
        show1.Columns.Clear() '避免头部消失
        show1.DataSource = dt2
        'If kk <> "" Then
        '    GS_ysgx(show1) '求和最后一行颜色更新
        'End If

        GS_TranEtoC(show1) '将DataGridView列字段翻译成为中文描叙
    End Sub
    Private Function gettruezdm(ByVal str As String) As String '得到真正英文字段名称
        Dim bmcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "left")
        Dim zdcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "right")
        If bmcn = "" Then
            Return zdcn
        End If
        Dim bm As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_biaoinf, "tb_biaoinf_mx='" & bmcn & "'", 1) '得到表英文名称
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_zdinf, "tb_biaozdinf_biao='" & bm & "' and tb_biaozdinf_mx='" & zdcn & "'", 1) '得到英文字段名称
        Return zd
    End Function

    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        Dim nform As New Frcgxx
        Me.AddOwnedForm(nform)
        Dim id As String = ""
        id = show1.SelectedRows(0).Cells("采购单号").Value.ToString
        If id <> "" Then
            'nform.sql = "select tb_dhgz_wpfl,tb_dhgz_cgdh,tb_dhgz_yjdhrq,tb_dhgz_yjdhl,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_yssx2,tb_dhgz_ysr,tb_dhgz_ysrq,tb_dhgz_yshgl,tb_dhgz_bhgl,tb_dhgz_pccl from tb_dhgz"
            'nform.sql &= " where tb_dhgz_cgdh='" & id & "'"
            'nform.dt = GF_CreateDataSource(G_cnnstr, nform.sql)
            Dim dtth As DataTable = DeepCode.DeepDoGridView.ToDataTable(show1)
            nform.dt = DeepCode.DeepDoDataTable.GF_czmctb(dtth, "采购单号='" & id & "'")
            If nform.dt.Rows.Count = 0 Then
                MsgBox("未到货！")
                Exit Sub
            End If
            nform.ShowDialog()
        Else
            MsgBox("未采购！")
        End If

    End Sub
    Public Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
    Private Function dtqg() As DataTable '请购中数据请购单生效的
        Dim sqlqg As String = "select tb_qgcg_wpfl,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_qgrq,tb_qgcg_yqdhrq,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_dw,tb_qgcg_qgsl,tb_qgcg_yqyt,tb_qgcg_qgzt,tb_qgcg_jhdh,tb_qgcg_qgdsfsx from tb_qgcg where tb_qgcg_wpfl='备品备件'and tb_qgcg_qgdsfsx='是'  and tb_qgcg_xbid is null"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sqlqg)
        Return dt
    End Function
    Private Function dtqg2() As DataTable '请购中数据请购单不是生效的
        Dim sqlqg As String = "select tb_qgcg_wpfl,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_qgrq,tb_qgcg_yqdhrq,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_dw,tb_qgcg_qgsl,tb_qgcg_yqyt,tb_qgcg_qgzt,tb_qgcg_jhdh,tb_qgcg_qgdsfsx from tb_qgcg where tb_qgcg_wpfl='备品备件' and tb_qgcg_qgdsfsx<>'是' and tb_qgcg_xbid is null"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sqlqg)
        Return dt
    End Function

    Private Function dtcg() As DataTable '采购的数据
        Dim sqlcg As String = "select tb_cg_wpfl,tb_cg_qgbm,tb_cg_qgr,tb_cg_qgrq,tb_cg_yqdhrq,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_qgsl,tb_cg_yqyt,tb_cg_qgzt,tb_cg_jhdh,tb_cg_qgdsfsx,tb_cg_dj,tb_cg_cgdh,tb_cg_rq,tb_cg_fzr,tb_cg_dgzl,tb_cg_ysbm,tb_cg_fqcs,tb_cg_sfbh,tb_cg_yjdhrq1 from tb_cg where tb_cg_wpfl='备品备件' and tb_cg_xbid is null"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sqlcg)
        Return dt
    End Function
    Private Function dtdhgz() As DataTable '已到货但未验收
        Dim sql As String = "select tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_yqdhrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_jhdh,tb_dhgz_qgdsfsx,tb_dhgz_dj,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,tb_dhgz_yjdhrq,sum(tb_dhgz_yshgl) as '总合格量',tb_dhgz_yszq,tb_dhgz_yssx2,tb_dhgz_ysr from tb_dhgz "
        Dim sql0 As String = "where tb_dhgz_wpfl='备品备件' and tb_dhgz_sfys is null group by  tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,tb_dhgz_yssx2,tb_dhgz_ysr,tb_dhgz_yszq,tb_dhgz_dj,tb_dhgz_yqdhrq,tb_dhgz_yjdhrq,tb_dhgz_jhdh"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql & sql0) '验收的数据
        Return dt
    End Function
    'Private Function dtall() As DataTable '请购单尚未生效，已采购但未到货，已到货但未验收,已验收
    '    Dim sql As String = "select tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_yqdhrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_dj,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,sum(tb_dhgz_yshgl) as '总合格量',tb_dhgz_yszq,tb_dhgz_yssx2,tb_dhgz_ysr from tb_dhgz "
    '    Dim sql0 As String = "where tb_dhgz_wpfl='备品备件' group by  tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,tb_dhgz_yssx2,tb_dhgz_ysr,tb_dhgz_yszq,tb_dhgz_dj,tb_dhgz_yqdhrq"
    '    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql & sql0) '验收的数据
    '    'Dim dr0 As DataRow '采购表中显示的只是此报表中的前十九列，因为其他列要经过到货跟踪验收来填充才有数据
    '    Dim f As DataTable = dtcg()
    '    dtshow(dt, f)

    '    Dim f2 As DataTable = dtqg()
    '    dtshow(dt, f2)

    '    Return dt
    'End Function
    Private Function dtys() '验收数据
        Dim sql As String = "select tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_yqdhrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_jhdh,tb_dhgz_qgdsfsx,tb_dhgz_dj,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,tb_dhgz_yjdhrq,sum(tb_dhgz_yshgl) as '总合格量',tb_dhgz_yszq,tb_dhgz_yssx2,tb_dhgz_ysr from tb_dhgz "
        Dim sql0 As String = "where tb_dhgz_wpfl='备品备件' and tb_dhgz_sfys is not null group by  tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_qgrq,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_cgdh,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_ysbm,tb_dhgz_fqcs,tb_dhgz_sfbh,tb_dhgz_yssx2,tb_dhgz_ysr,tb_dhgz_yszq,tb_dhgz_dj,tb_dhgz_yqdhrq,tb_dhgz_yjdhrq,tb_dhgz_jhdh"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql & sql0) '验收的数据
        Return dt
    End Function
    Public Function dtshow(ByVal dt As DataTable, ByVal dt2 As DataTable) As DataTable 'dt为主的datable， dt2要被和并到dt的datable
        Dim dr As DataRow
        For j As Integer = 0 To dt2.Rows.Count - 1
            dr = dt.NewRow() '一行一行循环填充
            For i As Integer = 0 To dt2.Columns.Count - 1
                dr(i) = dt2.Rows(j)(i)
            Next
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    'Private Sub CheckBox5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CheckBox5.Checked = True Then
    '        Dim n As CheckBox
    '        For i As Integer = 0 To GroupBox1.Controls.Count - 1
    '            If GroupBox1.Controls(i).GetType.Name = "CheckBox" Then
    '                n = GroupBox1.Controls(i)

    '                n.Checked = True
    '                CheckBox5.Checked = True
    '            End If
    '        Next

    '    End If
    'End Sub
    'Private Sub check(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged

    '    If CheckBox1.Checked = False Or CheckBox2.Checked = False Or CheckBox3.Checked = False Or CheckBox4.Checked = False Then
    '        CheckBox5.Checked = False
    '    End If
    'End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        showsj()
    End Sub
End Class