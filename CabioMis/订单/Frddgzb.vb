Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frddgzb
    Dim qxpd1 As String = qxpd() '权限
    Private Sub Frddgzb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
        showsj()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        Dim rq As DateTime = DateTimePicker1.Text
        DateTimePicker1.Text = DateAdd(DateInterval.Month, -1, rq)
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
    Private Function jhwx() As DataTable '计划未下
        Dim sql As String = "select tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jfwc,tb_dd_fhtjdh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,tb_dd_ckrq,tb_dd_ckl,tb_dd_sjdhrq,tb_dd_fhycms,tb_dd_ddgsyf,tb_dd_yfh,tb_dd_yc, tb_dd_fhl,tb_dd_sjph,tb_dd_cfs,tb_dd_returnsl,tb_dd_returnrq from tb_dd where tb_dd_bz1 is null and tb_dd_sfsh='否'" & qxpd1
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Return dt
    End Function
    Private Function jhyx() As DataTable '已下计划未发货
        Dim sql1 As String = "select tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jfwc,tb_dd_fhtjdh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,tb_dd_ckrq,tb_dd_ckl,tb_dd_sjdhrq,tb_dd_fhycms,tb_dd_ddgsyf,tb_dd_yfh,tb_dd_yc, tb_dd_fhl,tb_dd_sjph,tb_dd_cfs,tb_dd_returnsl,tb_dd_returnrq from tb_dd "
        Dim Sql As String = sql1 & "where tb_dd_bz1='1'  and tb_dd_bz2 is null " & qxpd1
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim sql2 As String = sql1 & " where  tb_dd_bz1='2'  and  tb_dd_bz2 is not null and tb_dd_bz3 is null and tb_dd_fhtjdh is not null " & qxpd1
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        dt = Frcgdhbb.dtshow(dt, dt2)
        Return dt
    End Function
    Private Function fhwdh() As DataTable '发货未到货
        Dim sql As String = "select tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jfwc,tb_dd_fhtjdh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,tb_dd_ckrq,tb_dd_ckl,tb_dd_sjdhrq,tb_dd_fhycms,tb_dd_ddgsyf,tb_dd_yfh,tb_dd_yc, tb_dd_fhl,tb_dd_sjph,tb_dd_cfs,tb_dd_returnsl,tb_dd_returnrq from tb_dd "
        sql &= "where tb_dd_bz1='2'  and tb_dd_bz3 is not null and tb_dd_bz4 is null" & qxpd1
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Return dt
    End Function
    Private Function dhjf() As DataTable '到货交付
        Dim sql As String = "select tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jfwc,tb_dd_fhtjdh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,tb_dd_ckrq,tb_dd_ckl,tb_dd_sjdhrq,tb_dd_fhycms,tb_dd_ddgsyf,tb_dd_yfh,tb_dd_yc, tb_dd_fhl,tb_dd_sjph,tb_dd_cfs,tb_dd_returnsl,tb_dd_returnrq from tb_dd "
        sql &= "  where tb_dd_bz1='2'  and  tb_dd_bz4 is not null" & qxpd1
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Return dt
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        showsj()
    End Sub
    Private Sub showsj()
        Dim sql As String = "select top 1 tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jfwc,tb_dd_fhtjdh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,tb_dd_ckrq,tb_dd_ckl,tb_dd_sjdhrq,tb_dd_fhycms,tb_dd_ddgsyf,tb_dd_yfh,tb_dd_yc, tb_dd_fhl,tb_dd_sjph,tb_dd_cfs,tb_dd_returnsl,tb_dd_returnrq from tb_dd "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dt.Clear() '''''''''''''''''''''''''''''''''''''''''''''''''''''''得到表架构

        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim dr As DataRow
        Dim bzl As Integer = 0 '用于计算备注的条数
        If CheckBox1.Checked = True Then
            dr = dt.NewRow
            dr(1) = "计划未下"
            dt.Rows.Add(dr)
            bzl += 1
            Call jhwx()
            dt = Frcgdhbb.dtshow(dt, jhwx)

        End If
       
        If CheckBox2.Checked = True Then
            dr = dt.NewRow
            dr(1) = "已下计划未发货"
            dt.Rows.Add(dr)
            bzl += 1
            Call jhyx()
            dt = Frcgdhbb.dtshow(dt, jhyx)

        End If
        If CheckBox3.Checked = True Then
            dr = dt.NewRow
            dr(1) = "发货未到货"
            dt.Rows.Add(dr)
            bzl += 1
            Call fhwdh()
            dt = Frcgdhbb.dtshow(dt, fhwdh)

        End If
        If CheckBox4.Checked = True Then
            dr = dt.NewRow
            dr(1) = "到货交付"
            dt.Rows.Add(dr)
            bzl += 1
            Call dhjf()
            dt = Frcgdhbb.dtshow(dt, dhjf)

        End If
     

        GS_DataGridViewbyDb(show1, dt, 0, True, True)
        GroupBox2.Text = "共有" & dt.Rows.Count - bzl & "条记录" '

        For hhh As Integer = 0 To show1.RowCount - 1
            If show1.Rows(hhh).Cells(2).Value.ToString = "" Then ''''如果该行为插入的备注行则变色
                show1.Rows(hhh).DefaultCellStyle.BackColor = Color.Green
            End If
        Next

        ComboBox2.Items.Clear()
        ComboBox1.Items.Clear()

        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4)
            Dim bm As String = ddbm(dt.Columns(i).Caption) '得到表名
            Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '得到表中文名称
            zwmz = bmcn & ":" & zwmz
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(zwmz)
                Case "System.DateTime" : ComboBox1.Items.Add(zwmz)

            End Select
        Next
        GroupBox2.Text = "显示" & show1.RowCount & "条记录"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        dt1 = DeepCode.DeepDoGridView.ToDataTable(show1)

        Dim bds As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) '文本字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '时间字段
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text
            tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then
                Return
            End If
            bds &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
     
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB

        show1.Columns.Clear() '避免头部消失
        show1.DataSource = dt2

        GS_TranEtoC(show1) '将DataGridView列字段翻译成为中文描叙

        GroupBox2.Text = "显示" & show1.RowCount & "条记录"
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
    Public Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function

    Private Sub Frddgzb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False Then
            CheckBox1.Checked = True : CheckBox2.Checked = True : CheckBox3.Checked = True : CheckBox4.Checked = True
            showsj()
            CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False
        Else
            showsj()
        End If

    End Sub
    Private Function qxpd() As String
        Dim sql As String = "select tb_khyqqkyrb_ddgh from tb_khyqqkyrb group by tb_khyqqkyrb_ddgh"
        sql = GF_getstringsql(G_cnnstr, sql, ",")
        sql = "'" & Replace(sql, ",", "','") & "'"
        If InStr(sql, "'" & G_dlr & "|" & G_dlrgh & "'") <> 0 Then
            Return " and tb_dd_ddgh='" & G_dlr & "|" & G_dlrgh & "' "
        Else
            Return " and  (1=1) "
        End If

    End Function
End Class