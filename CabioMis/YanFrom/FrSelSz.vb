﻿Imports DeepCode.DeepDoStr
Imports _S = CabioMis.Cl_StrMag
Imports _D = CabioMis.Cl_DataMag

Public Class FrSelSz
    Public m_strSqlWh As String = ""
    Public m_iCzBs As Integer = 0
    Public m_ds As New DataSet

    Private Sub FrSelSz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GS_FaceSearch(selCb, "tb_wp", 1, "物品名称") '筛选
        AddHandler selBt.Click, AddressOf selShowLv1 '查询
        AddHandler show1.DoubleClick, AddressOf showDbclick_1 '双击LV1
        AddHandler FormClosed, AddressOf frCloseed '关闭窗体
        AddHandler show2.DoubleClick, AddressOf delBmpXm '双击LV2
        '填充SHOW1
        showViewSet_1()
        '初始化SHOW2
        showViewSet_2()
    End Sub

    '查询显示界面LV1
    Private Sub selShowLv1(ByVal sender As Button, ByVal e As System.EventArgs)
        Dim fr As FrSelSz = sender.FindForm
        Dim zdzw As String = fr.selCb.Text
        Dim db As DataTable = CType(fr.selCb.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like '%" & fr.selTb.Text.Trim & "%'"
        fr.m_strSqlWh = sql
        showViewSet_1()
    End Sub
    '显示show1
    Private Sub showViewSet_1(Optional ByVal pSql As String = "")
        '获取LV2的物品代码字符串
        Dim dtTm As DataTable = show2.DataSource
        Dim strTm As String = _D.YanDttoStr(dtTm, "tb_mrp_wpdm", True)
        If strTm <> "" Then
            strTm = "and tb_wp_dm not in (" & strTm & ")"
        End If
        Dim sql As String = "select tb_wp_ID,tb_wp_dm,tb_wp_pm,tb_wp_wpfl,tb_wp_gsmc,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc," &
        "tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm,tb_wp_yjdj from tb_wp " &
        " where 1=1 " & strTm & " and  tb_wp_dm not in (select tb_mrp_wpdm from tb_mrp where tb_mrp_xz=1 and tb_mrp_cpbs=" & m_iCzBs & ")  " &
        " " & m_strSqlWh & " order by tb_wp_ID"
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        dt.DefaultView.Sort = "tb_wp_dm asc"
        GS_DataGridViewbyDb(show1, dt, True, True)
        '重新排序
        'fr.show1.Sort(show1.Columns("tb_wp_dm"), ListSortDirection.Descending)
    End Sub
    '显示show2
    Private Sub showViewSet_2(Optional ByVal pSql As String = "")
        Dim sql As String = "select tb_mrp_wpdm,tb_wp_pm from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm  where " &
            " tb_mrp_xz=1 and tb_mrp_cpbs=" & m_iCzBs & " order by tb_mrp_wpdm"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)

        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("删除")
        AddHandler menu1.Items(1).Click, AddressOf delBmpXm

        GS_DataGridViewbyDb(show2, dt, True, True, menu1)
    End Sub
    '双击LV1的过程
    Private Sub showDbclick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fr As FrSelSz = sender.FindForm
        'lv2增加一行
        Dim dr As DataGridViewRow = fr.show1.SelectedRows(0)
        Dim dt As DataTable = fr.show2.DataSource
        dt.Rows.Add({dr.Cells("tb_wp_dm").Value, dr.Cells("tb_wp_pm").Value})
        'lv1删除相对应的行
        fr.show1.Rows.Remove(dr)
    End Sub
    '关闭窗体的过程
    Private Sub frCloseed(ByVal sender As FrSelSz, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        If MsgBox("更新数据吗？", MsgBoxStyle.YesNo) = vbYes Then
            '更新数据
            Dim sql As String = "delete from tb_mrp where tb_mrp_cpbs=" & sender.m_iCzBs
            _D.GS_upztxx(sql)
            sql = ""
            Dim dt As DataTable = sender.show2.DataSource
            For Each dr As DataRow In dt.Rows
                If dr.RowState <> DataRowState.Deleted Then
                    sql &= "insert into tb_mrp(tb_mrp_cpbs,tb_mrp_wpdm,tb_mrp_xz) values(" & sender.m_iCzBs & ",'" & dr("tb_mrp_wpdm") & "',1) " & vbCrLf
                End If
            Next
            _D.GS_upztxx(sql)
        End If
    End Sub

    '删除LV2的行
    Private Sub delBmpXm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fr As FrSelSz
        If sender.GetType.Name = "DataGridView" Then
            fr = sender.findform
        Else
            Dim xa As ToolStripMenuItem = sender
            '获取该对象的父容器
            Dim mu As ContextMenuStrip = xa.GetCurrentParent
            '获取绑定的容器的类型
            fr = mu.SourceControl.FindForm
        End If
        fr.show2.Rows.Remove(fr.show2.SelectedRows(0))
        showViewSet_1()
    End Sub


End Class