Public Class FrQcSz
    Private Sub FrQcSz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("工艺")
        ComboBox2.Text = en_QcLX.物品.ToString
        GS_FaceSearch(ComboBox1, "tb_wp", 1, "物品名称") '筛选
        ComboBox1.Items.Remove("物品分类")
        GS_wlbktlr3(ComboBox3, GetType(en_wpfl).YanEnToTb().YanDtToStr("name").Split(","), en_wpfl.原料.ToString)

        Label2.Text = ""
        showcz()
        show1.Focus()
    End Sub
    '显示原料列表
    Public Sub showcz(Optional ByVal pStrSql As String = "")
        Dim sql As String = ""
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("QC设置")
        AddHandler menu1.Items(1).Click, AddressOf showQcSz
        Select Case ComboBox2.Text
            Case en_QcLX.物品.ToString
                sql = "select tb_wp_ID,tb_wp_dm,tb_wp_pm,tb_wp_gsmc,tb_wp_wpfl,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx," &
                    "tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm,tb_wp_yjdj from tb_wp where tb_wp_sfyx<>'无效' " & _
                      pStrSql & "  order by tb_wp_dm"
                Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                GroupBox1.Text = "库存：" & dt.Rows.Count & "条记录"
                GS_DataGridViewbyDb(show1, dt, True, True, menu1)
            Case "工艺"
                sql = "select * from tb_gxsz where tb_gxsz_isqc='是' order by tb_gxsz_px"
                Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                dt.YanDataBind(show1, "tb_gxsz_ID", menu1)
            Case en_QcLX.成品.ToString()
                GS_DataGridViewbyDb(show1, GetType(en_cpMc).YanEnToTb, True, True, menu1)
            Case en_QcLX.工序.ToString()
                GS_DataGridViewbyDb(show1, GetType(en_LcTableName).YanEnToTb, True, True, menu1)
        End Select
    End Sub

    '打开QC设置窗口
    Sub showQcSz()
        Dim aa As New FrQcSd
        aa.m_Qclx = GetType(en_QcLX).YanGetEnValue(ComboBox2.Text)
        Select Case ComboBox2.Text
            Case en_QcLX.物品.ToString
                aa.m_dm = show1.SelectedRows(0).Cells("tb_wp_dm").Value
                aa.m_mc = show1.SelectedRows(0).Cells("tb_wp_pm").Value
                aa.m_bs = show1.SelectedRows(0).Cells("tb_wp_ID").Value
            Case en_QcLX.工艺.ToString
                aa.m_dm = show1.SelectedRows(0).Cells("tb_gxsz_dm").Value
                aa.m_mc = show1.SelectedRows(0).Cells("tb_gxsz_mc").Value
                aa.m_bs = show1.SelectedRows(0).Cells("tb_gxsz_ID").Value
            Case Else
                aa.m_dm = show1.SelectedRows(0).Cells(0).Value
                aa.m_mc = show1.SelectedRows(0).Cells(0).Value
                aa.m_bs = show1.SelectedRows(0).Cells("value").Value
        End Select
        aa.ShowDialog()
        showQcXm()
    End Sub
    Private Sub show1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles show1.SelectionChanged
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        Select Case ComboBox2.Text
            Case en_QcLX.物品.ToString
                '第3列放置名称
                Label2.Text = show1.SelectedRows(0).Cells(2).Value
            Case en_QcLX.工艺.ToString
                Label2.Text = show1.SelectedRows(0).Cells("tb_gxsz_mc").Value
            Case Else
                '第1列放置名称
                Label2.Text = show1.SelectedRows(0).Cells(0).Value
        End Select
        showQcXm()
    End Sub

    '打开数据设置窗口
    Sub showSjsz()
        Dim nform As New FrXmSjsz
        nform.m_Id = show2.SelectedRows(0).Cells(0).Value
        nform.ShowDialog()
    End Sub
    Private Sub showQcXm()
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        Dim sql As String = ""

        Select Case ComboBox2.Text
            Case en_QcLX.物品.ToString
                sql = "select * from tb_Qcxm where tb_QcXm_qclx=" & en_QcLX.物品 & " and tb_Qcxm_wldm='" & show1.SelectedRows(0).Cells(1).Value & "'"
            Case en_QcLX.成品.ToString
                sql = "select * from tb_Qcxm where tb_QcXm_qclx=" & en_QcLX.成品 & " and tb_Qcxm_wldm='" & show1.SelectedRows(0).Cells(0).Value & "'"
            Case en_QcLX.工序.ToString
                sql = "select * from tb_Qcxm where tb_QcXm_qclx=" & en_QcLX.工序 & " and tb_Qcxm_wldm='" & show1.SelectedRows(0).Cells(0).Value & "'"
            Case "工艺"
                sql = "select * from tb_Qcxm where tb_QcXm_qclx=" & en_QcLX.工艺 & " and tb_Qcxm_wpbs='" & show1.SelectedRows(0).Cells("tb_gxsz_ID").Value & "'"
        End Select
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("数据设置")
        AddHandler menu1.Items(1).Click, AddressOf showSjsz
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show2, dt, True, True, menu1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim zdzw As String = ComboBox1.Text
        Dim db As DataTable = CType(ComboBox1.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like '%" & TextBox3.Text.Trim & "%'"
        sql &= IIf(ComboBox3.Text = "", "", " and " & _D.GF_cnwithen(db, "tb_biaozdinf_mx='物品分类'", 1) & " ='" & ComboBox3.Text & "'")
        showcz(sql)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nform As New FrQcXmsz
        nform.ShowDialog()
    End Sub

    '根据第一层选择框的内容填充第二层选择框的内容
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Select Case ComboBox2.Text
            Case en_QcLX.物品.ToString
                GS_FaceSearch(ComboBox1, "tb_wp", 1, "物品名称")
            Case en_QcLX.成品.ToString
                ComboBox1.Items.Clear()
                'ComboBox1.Items.AddRange(New String() {"原料", "成品", "工序"})
            Case "工序"
                ComboBox1.Items.Clear()
            Case Else
        End Select
        showcz()
    End Sub
End Class