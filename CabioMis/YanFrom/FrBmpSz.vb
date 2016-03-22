Imports _S = CabioMis.Cl_StrMag
Imports _D = CabioMis.Cl_DataMag

Public Class FrBmpSz
    '产品标识
    Public m_cpbs As Integer = 0
    '列表条件表达实
    Private m_strSql As String = ""
    '操作类型(0为生产产品所需原料，1为物品组成材料)
    Public m_iType As Integer = en_Bllx.生产原料

    Private Sub FrBmpSz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GS_FaceSearch(ComboBox1, "tb_wp", 1, "物品名称") '筛选

        Dim dt As DataTable = _D.GF_CreateDataSource("select * from tb_wp where tb_wp_ID=" & m_cpbs)
        Select Case m_iType
            Case en_Bllx.生产原料
                Me.Text = "生产原料编辑"
                GroupBox1.Text = "选择生产" & dt.Rows(0)("tb_wp_pm") & "所需的原料"
                GroupBox2.Text = "生产" & dt.Rows(0)("tb_wp_pm") & "所需的原料"
            Case en_Bllx.合成原料
                Me.Text = "合成原料编辑"
                GroupBox1.Text = "选择合成" & dt.Rows(0)("tb_wp_pm") & "所需的原料"
                GroupBox2.Text = "合成" & dt.Rows(0)("tb_wp_pm") & "所需的原料"
        End Select

        showWp()
        showcz()
        show2.Focus()

        AddHandler show2.DoubleClick, AddressOf delBmpXm
    End Sub
    '显示属于该物品的原料
    Public Sub showcz()
        Dim sql As String = ""
        Select Case m_iType
            Case en_Bllx.生产原料
                sql = "select tb_mrp_ID,tb_wp_pm,tb_mrp_wpdm,tb_mrp_blz from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm  where " &
                    " tb_mrp_xz=" & en_Bllx.生产原料 & " and tb_mrp_cpbs=" & m_cpbs & " order by tb_mrp_wpdm"
            Case en_Bllx.合成原料
                sql = "select tb_mrp_ID,tb_wp_pm,tb_mrp_wpdm from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm  where " &
                    " tb_mrp_xz=" & en_Bllx.合成原料 & " and tb_mrp_cpbs=" & m_cpbs & " order by tb_mrp_wpdm"
        End Select

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, Sql)

        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("删除")
        AddHandler menu1.Items(1).Click, AddressOf delBmpXm
        'menu1.Items.Add("QC设置")
        'AddHandler menu1.Items(1).Click, AddressOf showQcSz
        GS_DataGridViewbyDb(show2, dt, True, True, menu1)
    End Sub

    Private Sub showWp()
        Dim sql As String = "select tb_wp_ID,tb_wp_dm,tb_wp_pm,tb_wp_wpfl,tb_wp_gsmc,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm,tb_wp_yjdj from tb_wp " & _
        " where 1=1 and tb_wp_dm not in (select tb_mrp_wpdm from tb_mrp where (tb_mrp_xz is null or tb_mrp_xz=" & m_iType & ") and tb_mrp_cpbs=" & m_cpbs & ") " & m_strSql & " order by tb_wp_dm"
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub
    '查询筛选
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim zdzw As String = ComboBox1.Text
        Dim db As DataTable = CType(ComboBox1.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like '%" & TextBox3.Text.Trim & "%'"
        m_strSql = sql
        showWp()
    End Sub

    '左侧列表选择
    Private Sub show1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        If show1.SelectedRows.Count > 0 Then
            Dim strInp As String = ""
            Select Case m_iType
                Case en_Bllx.生产原料
                    strInp = InputBox("请输入标量值", "标量值输入", 0)
                    If strInp = "" Then
                        Return
                    End If
                    If IsNumeric(strInp) = False Then
                        MsgBox("请输入数字！")
                        Return
                    End If
                Case en_Bllx.合成原料
                    strInp = "0"
            End Select

            Dim sql As String = "select * from tb_mrp where tb_mrp_xz=" & m_iType & " and tb_mrp_cpbs='" & m_cpbs & "' and tb_mrp_wpdm  ='" & show1.SelectedRows(0).Cells("tb_wp_dm").Value & "'"
            If Cl_DataMag.GF_CreateDataSource(sql).Rows.Count > 0 Then
                MsgBox("该产品已有相同标量！")
                Return
            End If

            sql = "insert into tb_mrp(tb_mrp_cpbs,tb_mrp_wpdm,tb_mrp_blz,tb_mrp_xz)  " & _
                "values('" & m_cpbs & "','" & show1.SelectedRows(0).Cells("tb_wp_dm").Value & "'," & strInp & "," & m_iType & ")"
            DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)

            showWp()
            showcz()
        End If
    End Sub

    Private Sub delBmpXm()
        Dim sql As String = ""
        sql = "delete tb_mrp where  tb_mrp_ID='" & show2.SelectedRows(0).Cells(0).Value & "'"
        DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)

        showWp()
        showcz()
    End Sub
End Class