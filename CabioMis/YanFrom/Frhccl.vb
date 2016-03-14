Public Class Frhccl

    '查询物品的条件表达式
    Private m_StrSql As String = ""
    Private m_Ph As String = ""

    Private Sub Frhccl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        AddHandler show1.DoubleClick, AddressOf showWpXx
        GS_FaceSearch(ComboBox3, "tb_wp", 1, "物品名称")
        ComboBox3.Items.Remove("物品分类")
        GS_wlbktlr3(ComboBox1, GetType(en_wpfl).YanEnToTb().YanDtToStr("name").Split(","), en_wpfl.原料.ToString)
        showWp()
    End Sub

    '添加标量列
    Private Sub setBmpshowView(ByRef pDt As DataTable)
        Dim sql As String = ""

        '所有用到的物品代码
        Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_wp_pm from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm")
        '添加到产品DT
        For Each dr As DataRow In tBqcxm.Rows
            pDt.Columns.Add(dr("tb_wp_pm").trim)
        Next

        '更新标量值
        For Each dr As DataRow In pDt.Rows  '将结果作为列添加进去
            sql = "select tb_wp_pm,tb_mrp_blz from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm where tb_mrp_cpbs='" & dr("tb_cpdmhz_ID") & "'"
            Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
            For Each tDr As DataRow In tDt.Rows
                Try
                    dr(tDr("tb_wp_pm").trim) = _S.YanFormatStr(tDr("tb_mrp_blz"), "0", False)
                Catch
                End Try
            Next
        Next
    End Sub
    '显示物品编辑界面（添加和修改）
    Private Sub showWpXx(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nform As New Frtjxg
        Me.AddOwnedForm(nform)

        If sender.text = "编辑物品信息" OrElse CType(sender, Control).Name = "show1" Then
            Dim i As Integer = show1.SelectedRows(0).Cells("tb_wp_ID").Value
            nform.id = i
            If _S.YanNullToEmpty(show1.SelectedRows(0).Cells("tb_wp_wpfl").Value) = "备品备件" Then
                nform.tb_wp_njzq.Visible = False
                nform.Label15.Visible = False
            End If
            nform.tb_wp_dm.ReadOnly = True
        End If

        Dim iRn As Integer = nform.ShowDialog()
        If iRn = DialogResult.OK Then
            showWp(m_StrSql)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim zdzw As String = ComboBox3.Text
        Dim db As DataTable = CType(ComboBox3.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = ""
        If jgzd <> "" Then
            sql = " and [" & jgzd & "] like '%" & TextBox2.Text.Trim & "%'"
        End If
        sql &= IIf(ComboBox1.Text = "", "", " and " & _D.GF_cnwithen(db, "tb_biaozdinf_mx='物品分类'", 1) & " ='" & ComboBox1.Text & "'")
        showWp(sql)
    End Sub

    '显示物品列表
    Private Sub showWp(Optional ByVal pStrSql As String = "")
        Dim sql As String = "select tb_wp_ID,tb_wp_dm,tb_wp_pm,tb_wp_wpfl,tb_wp_gsmc,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm,tb_wp_yjdj from tb_wp " & _
        " where 1=1  " & pStrSql & " order by tb_wp_dm"

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("编辑物品信息")
        AddHandler menu1.Items(1).Click, AddressOf showWpXx
        menu1.Items.Add("物品原料编辑")
        AddHandler menu1.Items(2).Click, AddressOf showMrpList
        menu1.Items.Add("物品合成操作")
        AddHandler menu1.Items(3).Click, AddressOf clWphc
        menu1.Items.Add("查看库存信息")
        AddHandler menu1.Items(4).Click, AddressOf showKcxx
        menu1.Items.Add("查看使用情况")
        AddHandler menu1.Items(5).Click, AddressOf showSyQk
        menu1.Items.Add("查看所有批号")
        AddHandler menu1.Items(6).Click, AddressOf showSyPh
        menu1.Items.Add("QC设定")
        AddHandler menu1.Items(7).Click, AddressOf showQcSd

        AddHandler menu1.Paint, Sub(sender As ContextMenuStrip, e As System.EventArgs)
                                    Try
                                        sender.Items(2).Enabled = "XYZ".IndexOf(show1.SelectedRows(0).Cells("tb_wp_wllb").Value) >= 0
                                        sender.Items(3).Enabled = show1.SelectedRows(0).Cells("tb_wp_wllb").Value = "Z"
                                    Catch ex As Exception
                                    End Try
                                End Sub
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)

        GS_DataGridViewbyDb(show1, dt, True, True, menu1)
        GroupBox2.Text = "共有物品" & dt.Rows.Count
        m_StrSql = pStrSql
    End Sub

    Private Sub showSyQk(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New FrListYl_slqk
        aa.m_Dt = cl_theCl.getShowDtWltj(show1.SelectedRows(0).Cells("tb_wp_dm").Value)
        aa.m_Dt.TableName = "使用情况"
        aa.ShowDialog()
    End Sub
    Private Sub showSyPh(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New FrListYl_slqk
        Dim sql As String = "select * from tb_i259b where tb_i259b_i231a='" & show1.SelectedRows(0).Cells("tb_wp_dm").Value & "'"
        aa.m_Dt = _D.GF_CreateDataSource(sql)
        aa.ShowDialog()
    End Sub
    Private Sub showQcSd(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New FrQcSd
        aa.m_dm = show1.SelectedRows(0).Cells("tb_wp_dm").Value
        aa.m_mc = show1.SelectedRows(0).Cells("tb_wp_pm").Value
        aa.ShowDialog()
    End Sub
    Private Sub showKcxx(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New Frylchuhuo
        aa.m_strSqlWh = "and tb_i259b_i231a='" & show1.SelectedRows(0).Cells("tb_wp_dm").Value & "'"
        aa.ShowDialog()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        showWpXx(sender, Nothing)
    End Sub


#Region "选择窗体的操作(编辑合成物品)"
    '编辑产品标量界面
    Private Sub showMrpList(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim frShow As New FrBmpSz
        'frShow.m_cpbs = show1.SelectedRows(0).Cells("tb_wp_ID").Value
        'frShow.m_iType = en_Bllx.合成原料
        ''AddHandler frShow.show1.DoubleClick, AddressOf showKcxx
        'frShow.ShowDialog()

        Dim frShow As New FrSelSz
        frShow.m_iCzBs = show1.SelectedRows(0).Cells("tb_wp_ID").Value
        frShow.m_wpfl = show1.SelectedRows(0).Cells("tb_wp_wpfl").Value
        frShow.Text = "物品原料编辑"
        frShow.Width = 628
        frShow.GroupBox1.Text = "配置" & show1.SelectedRows(0).Cells("tb_wp_pm").Value & "所需的原料"
        frShow.GroupBox2.Text = show1.SelectedRows(0).Cells("tb_wp_pm").Value & "所需的原料"
        frShow.ShowDialog()
    End Sub


#End Region
#Region "选择窗体的操作（物品合成操作）"
    '合成原料操作界面
    Private Sub clWphc(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strPh As String = InputBox("请输入合成后的批号", "合成" & show1.SelectedRows(0).Cells("tb_wp_pm").Value)

        If strPh = "" OrElse _D.GF_CreateDataSource("select * from tb_i259b where tb_i259b_num='" & strPh & "'").Rows.Count > 0 Then
            MsgBox("批号输入错误！")
            Return
        End If

        Dim frShow As New FrSelHcCz
        frShow.m_iCzBs = show1.SelectedRows(0).Cells("tb_wp_ID").Value
        frShow.m_Ph = strPh
        frShow.Text = "物品合成操作"
        frShow.Width = 628
        frShow.GroupBox1.Text = "" & show1.SelectedRows(0).Cells("tb_wp_pm").Value & "未使用的原料"
        frShow.GroupBox2.Text = "" & show1.SelectedRows(0).Cells("tb_wp_pm").Value & "已使用的原料"

        frShow.ShowDialog()
    End Sub
#End Region

End Class