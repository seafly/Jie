Imports DeepCode.DeepDoDataTable
Public Class Frddadd
    Public id As String = ""
    Public ddhpd As String = ""
    Public jm As String
    Dim g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效' and  tb_cpdmhz_cplx  not in ('发酵罐' ,'二级罐','一级罐','种子罐') order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ") '所有产品代码表
    Public xg As Boolean   '如果修改标识
    Dim kh As DataTable '用来判定客户是否为下拉框的信息
    Public fhtjdid As String = Nothing '用于在已发货步骤进行批量修改
    '’******************************************************88
    '订单模块的表中 存在三个级别的信息
    '1级：发货通知单号为空但是订单号不为空的,用于在即时表中显示，用于总揽订单信息
    '2级：bz1为1的，此处的信息为订第一次单拆分后的信息，拆分后，拆分几批则发货通知单号跟“-1，-2。。。。”，该级信息主要是用于在运行部的执行计划中显示，并且利于第三级信息拆分
    '3级：bz1为2的，因为发货通知单号相同的信息可能会存在相同代码却不同批号的产品发货，且进出货中主要操作的是该级别信息
    '’******************************************************88
    Private Sub Frddadd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_dd_cfs.SelectedIndex = 0
        If id <> "" Then
            Gs_showsj("tb_dd", Me, id)
        End If
        If tb_dd_bz1.Text = "" Then ''如果是第一步的添加则给勾选框是否小客户
            checkb()
        End If
        tb_dd_jhfhrq.Checked = True : tb_dd_jdrq.Checked = True
        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘如果是修改发货计划则
        If xg = True Then
            Dim bt As New Button
            bt.Text = "查询"
            bt.Location = New System.Drawing.Point(694, 373)
            bt.Size = New System.Drawing.Size(75, 23)
            Me.Controls.Add(bt)
            AddHandler bt.Click, AddressOf btt
        End If
        If tb_dd_jfwc.Text = "否" Then
            tb_dd_jfwc.Enabled = True
        End If
        tb_dd_returnrq.Text = ""
    End Sub
    Private Sub btt(ByVal o As Object, ByVal e As EventArgs)
        id = ""
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_dd_id,tb_dd_bz3 from tb_dd where tb_dd_ddh='" & tb_dd_ddh.Text & "'and tb_dd_fhtjdh is null")
        If dt.Rows.Count = 0 Then
            MsgBox("未找到符合要求的信息") : Exit Sub
        End If
        If DeepCode.DeepDoStr.Null2String(dt.Rows(0)(1)) <> "" Then
            MsgBox("已经使用不可修改") : Exit Sub
        End If
        Gs_showsj("tb_dd", Me, dt.Rows(0)(0))
        tb_dd_bz2.Text = ""
      

    End Sub
#Region "产品代码加工代码下拉框的填充"
    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        GS_bcfbd(g_sycpdmb, 1, tb_dd_cplx)

    End Sub
    Private Sub tb_dd_pm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dd_cplx.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, " tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, tb_dd_cpdm)

    End Sub
    Private Sub tb_dd_cpdm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dd_cpdm.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, " tb_cpdmhz_cplx='" & tb_dd_cplx.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_dd_jgdm)
    End Sub
#End Region
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button4.Click, Button7.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim bmcn As String = GF_cnwithen(kh, "客户='" & tb_dd_kh.Text & "'", 0) '判定客户是否为下拉的信息
        If bmcn = "" Then
            MsgBox("请输入正确的客户！")
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’单号是否重复
        Dim sql As String = GF_getstringsql(G_cnnstr, "select tb_dd_id from tb_dd where tb_dd_ddh='" & tb_dd_ddh.Text & "'", ",")
        If sql <> "" And Trim(sql) <> id Then
            MsgBox("已存在该订单号")
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
        If Trim(tb_dd_ddrq.Text) = "" Then
            Me.Controls.Remove(tb_dd_ddrq)
        End If

        If id <> "" Then
            If GF_modsj("tb_dd", Me, id) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_storelog3("订单添加修改：订单添加 id " & id & "", "订单添加修改") '储存到日志

        Else
            Dim jj As String = GF_addsj("tb_dd", Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_storelog3("订单添加修改：订单修改 id " & id & "", "订单添加修改") '储存到日志

        End If

        Dim nform As Frddlist = Me.Owner
        nform.xxsj(jm)
        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If ComboBox1.Text = "否" Then
                MsgBox("数据没有审核无法进行保存？", 1, "提示")
                Exit Sub
            End If
            If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
                Exit Sub
            End If
            If tb_dd_ph.Text = "" Then
                MsgBox("请将数据填写完整") : Exit Sub
            End If
            If tb_dd_jhl.Text = "" Then
                tb_dd_jhl.Text = 0
            End If
            If tb_dd_fhl.Text = "" Then
                tb_dd_fhl.Text = 0
            End If

            If xg = True Then
                xggn()
            End If

            If id <> "" Then

                If GF_modsj("tb_dd", Me, id) = False Then '修改数据
                    MsgBox("请检查输入项目及数据") : Exit Sub
                End If
            End If

            If xg <> True Then
                Dim nform As Frddlist = Me.Owner
                nform.xxsj(jm)
            End If
            GS_storelog3("订单添加修改：发货计划修改 id " & id & "", "订单添加修改") '储存到日志
            MessageBox.Show("更新成功！")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub tb_dd_ph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dd_ph.DoubleClick, tb_dd_jhl.DoubleClick
        If jm = "已发货" Or jm = "已签收" Then
            Return
        End If
        If tb_dd_cplx.Text = "" Then
            Exit Sub
        End If
        Dim nform As New Frkcxs
        nform.ph = tb_dd_ph.Text
        nform.cplb = tb_dd_cplx.Text
        nform.sl = tb_dd_jhl.Text
        Me.AddOwnedForm(nform)
        nform.cpdm = tb_dd_cpdm.Text
        nform.jgdm = tb_dd_jgdm.Text

        nform.ShowDialog()

        Try
            Dim jhl As String() = tb_dd_jhl.Text.Split(",")
            Dim jhzl As Integer = 0
            For i As Integer = 0 To jhl.Length - 1
                jhzl += CDbl(jhl(i))
            Next
            tb_dd_jhfhzl.Text = jhzl
        Catch ex As Exception
        End Try
    End Sub
    '未发货进入下一步
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If tb_dd_ph.Text = "" Then
            MsgBox("请将数据填写完整") : Exit Sub
        End If
        If tb_dd_jhl.Text = "" Then
            tb_dd_jhl.Text = 0
        End If
        If tb_dd_fhl.Text = "" Then
            tb_dd_fhl.Text = 0
        End If
        tb_dd_bz2.Text = "2"  '’‘’‘ 更新数据库表中的标识

        If xg = True Then
            xggn()
        End If

        ''添加修改原来级别的信息
        If id <> "" Then
            If GF_modsj("tb_dd", Me, id) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If

        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim jhl As String() = tb_dd_jhl.Text.Split(",")
        Dim ph As String() = tb_dd_ph.Text.Split(",")
        Dim lid As String() = tb_dd_kcid.Text.Split(",") '库存ID
        Dim cw As String() = tb_dd_cw.Text.Split(",")
        Dim bfbArray() As String = bfb.Text.Split(",")
        Dim kdlkArray() As String = kdlk.Text.Split(",")
        Dim mslk() As String = storagemslk.Text.Split(",")
        Dim wzlk() As String = storagewzlk.Text.Split(",")

        '''''''''''''判断剩余库存与计划量
        For i As Integer = 0 To jhl.Length - 1
            Dim cyl As String = "select " & tb_dd_kcbiao.Text & "_sykczl from " & tb_dd_kcbiao.Text & " where  " & tb_dd_kcbiao.Text & "_id=(" & lid(i) & ")"
            Dim sykc As Double = CDbl(Trim(GF_getstringsql(G_cnnstr, cyl, "")))
            If sykc < jhl(i) Then
                MsgBox("剩余库存小于计划量，请重新选择批号")
                Exit Sub
            End If
        Next
        '''''''''''''''''''''''得到拆分的批次
        For i As Integer = 0 To jhl.Length - 1
            Try
                tb_dd_bz1.Text = "2" '3级信息
                tb_dd_jhl.Text = jhl(i)
                tb_dd_ph.Text = ph(i)
                tb_dd_kcid.Text = lid(i)
                tb_dd_cw.Text = cw(i)

                Dim jj As String = GF_addsj("tb_dd", Me)
                If jj = "" Then
                    MsgBox("请检查输入项目及数据")
                    Exit Sub
                End If

                ''''更新冷库信息(更新的是订单的内容)
                Dim upstorage As String = "update tb_dd set  tb_dd_bfb=" & bfbArray(i) & ",  tb_dd_kdlk=" & kdlkArray(i) & ",  tb_dd_storagemslk=" & mslk(i) & ",tb_dd_storagewzlk=" & wzlk(i) & " where tb_dd_id='" & jj & "'  "
                GS_upztxx(G_cnnstr, upstorage)

                '''' 更新剩余库存（只更新了总的剩余库存）
                Dim sql As String = "update " & tb_dd_kcbiao.Text & " set " & tb_dd_kcbiao.Text & "_sykczl=" & tb_dd_kcbiao.Text & "_sykczl-" & jhl(i) & "  where " & tb_dd_kcbiao.Text & "_id=" & lid(i) & ""
                GS_upztxx(G_cnnstr, sql)

            Catch ex As Exception
                MsgBox("库存更新出错，请联系管理员！")
            End Try
        Next

        '储存到日志 
        GS_storelog3("订单添加修改：发货计划 id " & id & "", "订单添加修改")
        If xg <> True Then
            Dim nform As Frddlist = Me.Owner
            nform.xxsj(jm)
        End If
        MessageBox.Show("更新成功！")
        Me.Close()

    End Sub

    Private Sub ComboBox1SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged, tb_dd_cfs.SelectedValueChanged

        If ComboBox1.Text = "否" Then
            Button5.Enabled = False
            Button3.Enabled = True
            Return
        End If
        Button3.Enabled = False
        Button5.Enabled = True

    End Sub

    Private Sub tb_dd_sfsh_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dd_sfsh.SelectedValueChanged
        If tb_dd_sfsh.Text = "是" Then
            Button1.Enabled = False
            Button6.Enabled = True
        Else
            Button6.Enabled = False
            Button1.Enabled = True
        End If
    End Sub
    '订单输入与审核 进入下一步
    Private Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '判定客户是否为下拉的信息
        Dim bmcn As String = GF_cnwithen(kh, "客户='" & tb_dd_kh.Text & "'", 0)
        If bmcn = "" Then
            MsgBox("请输入正确的客户！")
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’单号是否重复
        Dim sql As String = GF_getstringsql(G_cnnstr, "select tb_dd_id from tb_dd where tb_dd_ddh='" & tb_dd_ddh.Text & "'", ",")
        If sql <> "" And Trim(sql) <> id Then
            MsgBox("已存在该订单号")
            Exit Sub
        End If
        If Trim(tb_dd_ddrq.Text) = "" Then
            MsgBox("要求到货日期不能为空") : Return
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’库存判定，如果库存不足 不许审核
        Dim kcbmx As String = Trim(GF_getstringsql(G_cnnstr, "select top 1 tb_cpdmhz_cpxz from tb_cpdmhz where tb_cpdmhz_cplx='" & tb_dd_cplx.Text & "'", ""))

        Dim kcb As String = ""
        If InStr(kcbmx, "毛油") <> 0 Then
            kcb = "tb_x825pkc"
        ElseIf InStr(kcbmx, "成品油") <> 0 Then
            kcb = "tb_h195zkc"
        ElseIf InStr(kcbmx, "粉") <> 0 Then
            kcb = "tb_x832pkc"
        End If
        ''''''''''''''''''''添加修改原来级别的信息
        If id <> "" Then
            If GF_modsj("tb_dd", Me, id) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_storelog3("订单添加修改：订单审核 id " & id & "", "订单添加修改") '储存到日志
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tb_dd_bz1.Text = "1" '2级信息

        For i As Integer = 1 To CInt(tb_dd_cfs.Text)
            tb_dd_fhtjdh.Text = tb_dd_ddh.Text & "-" & i.ToString '‘’‘发货通知单号
            Dim jj As String = GF_addsj("tb_dd", Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
        Next
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim nform As Frddlist = Me.Owner
        nform.xxsj(jm)
        Me.Close()


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Trim(tb_dd_sjdhrq.Text) = "" Then
            MsgBox("实际到货日期不能为空")
            Exit Sub
        End If
        If CDate(tb_dd_ddrq.Text) < CDate(tb_dd_sjdhrq.Text) Then
            If MsgBox("实际到货晚于客户要求日期,是否确认？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If
        End If

        tb_dd_jfwc.SelectedIndex = 0
        If jm = "已签收" Then

            tb_dd_fhssczrgh.Text = G_dlrgh '已签收操作人工号
            If GF_modsj("tb_dd", Me, id) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_storelog3("订单添加修改：已签收 id " & id & "", "订单添加修改") '储存到日志
            ''''''''''''''''''批量修改
        Else
            If MsgBox("同一发货通知单号的信息将同时进入下一步,此单已经完成交付！", 1, "提示") <> 1 Then
                Exit Sub
            End If
            Dim sql As String = "update tb_dd set tb_dd_bz4 = '2' , tb_dd_sjdhrq='" & tb_dd_sjdhrq.Text & "'  ,tb_dd_yc='" & tb_dd_yc.Text & "'  ,tb_dd_fhycms='" & tb_dd_fhycms.Text & "',tb_dd_jfwc='" & tb_dd_jfwc.Text & "'  where tb_dd_id in (" & fhtjdid & ")"
            GS_upztxx(G_cnnstr, sql)
            sql = "update tb_dd set  tb_dd_jfwc='完成' where tb_dd_fhtjdh='" & tb_dd_fhtjdh.Text & "' and tb_dd_bz1='1'" '更新二级信息 用于判定该订单号的信息是否都完成了 如都完成了则更新第一条信息为完成
            GS_upztxx(G_cnnstr, sql)
            Dim wcpd As String = GF_getstringsql(G_cnnstr, "select tb_dd_jfwc from tb_dd where tb_dd_ddh='" & tb_dd_ddh.Text & "' and tb_dd_bz1='1'", ",")
            If InStr(wcpd, "否") = 0 Then
                sql = " update tb_dd set  tb_dd_jfwc='完成', tb_dd_sjdhrq='" & tb_dd_sjdhrq.Text & "'  where tb_dd_fhtjdh is null and tb_dd_ddh='" & tb_dd_ddh.Text & "'" '更新（一级信息）"
                GS_upztxx(G_cnnstr, sql)
            End If
            GS_storelog3("订单添加修改：已发货 id " & fhtjdid & "", "订单添加修改") '储存到日志
        End If
        Dim nform As Frddlist = Me.Owner
        nform.xxsj(jm)
        Me.Close()
    End Sub
    Private Sub checkb()
        Dim che As New CheckBox
        che.Text = "小客户"
        che.Checked = False
        che.Location = New System.Drawing.Point(334, 72)
        che.BackColor = Color.Transparent
        Me.Controls.Add(che)
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’判定客户类型 如果是小客户则check默认勾选 下拉显示小客户信息，否则显示大客户信息 check不勾选
        Dim sql As String = "select tb_ddcys_mc as '客户' from tb_ddcys where  tb_ddcys_fl='小客户' order by tb_ddcys_mc"
        kh = GF_CreateDataSource(G_cnnstr, sql)

        Dim str As String = tb_dd_kh.Text
        Dim sc As DataRow() = kh.Select("客户='" & str & "'")
        If sc.Length <> 0 Then
            che.Checked = True
        Else
            sql = "select tb_khyqqkyrb_khmc as '客户' from tb_khyqqkyrb where  tb_khyqqkyrb_yxx='有效' group by tb_khyqqkyrb_khmc "
            kh = GF_CreateDataSource(G_cnnstr, sql)
        End If
        ''''''''''''''''填充下拉框
        Dim v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        For i As Integer = 0 To kh.Rows.Count - 1
            tb_dd_kh.Items.Add(kh.Rows(i)(0))
            v.Add(Null2String(kh.Rows(i)(0)))
            tb_dd_kh.AutoCompleteCustomSource = v
        Next
        AddHandler che.CheckedChanged, AddressOf chckd
    End Sub
    Private Sub chckd(ByVal o As Object, ByVal e As EventArgs)
        Dim v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        Dim sql As String = Nothing
        Dim sql1 As String = ""
        If o.Checked <> False Then
            sql = "select tb_ddcys_mc as '客户' from tb_ddcys where  tb_ddcys_fl='小客户' order by tb_ddcys_mc"
            sql1 = "select tb_khyqqkyrb_cpdm,tb_khyqqkyrb_jgdm,tb_khyqqkyrb_cplx,tb_khyqqkyrb_pm,tb_khyqqkyrb_khqc,tb_khyqqkyrb_ddgh from tb_khyqqkyrb  "
            sql1 &= " where tb_khyqqkyrb_khmc like'%小客户%'and  tb_khyqqkyrb_yxx='有效'"
            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
            If dt1.Rows.Count <> 0 Then
                tb_dd_cplx.Text = Null2String(dt1.Rows(0)("tb_khyqqkyrb_cplx"))
                tb_dd_cpdm.Text = Null2String(dt1.Rows(0)("tb_khyqqkyrb_cpdm"))
                tb_dd_jgdm.Text = Null2String(dt1.Rows(0)("tb_khyqqkyrb_jgdm"))
                tb_dd_pm.Text = Null2String(dt1.Rows(0)("tb_khyqqkyrb_pm"))
                tb_dd_khqc.Text = Null2String(dt1.Rows(0)("tb_khyqqkyrb_khqc"))
                tb_dd_ddgh.Text = Null2String(dt1.Rows(0)("tb_khyqqkyrb_ddgh"))
            End If
        Else
            sql = "select tb_khyqqkyrb_khmc as '客户' from tb_khyqqkyrb  where  tb_khyqqkyrb_yxx='有效' group by tb_khyqqkyrb_khmc"
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        kh = Nothing
        kh = dt
        tb_dd_kh.Items.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_dd_kh.Items.Add(dt.Rows(i)(0))
            v.Add(Null2String(dt.Rows(i)(0)))
            tb_dd_kh.AutoCompleteCustomSource = v
        Next
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim id As String = GF_getstringsql(G_cnnstr, "select tb_dd_id from tb_dd where tb_dd_ddh='" & tb_dd_ddh.Text & "' and tb_dd_fhtjdh is null", ",")
        Gs_showsj("tb_dd", Me, id)
    End Sub
    Private Sub xggn() '修改发货计划
        Dim sql As String = "delete from tb_dd where tb_dd_ddh='" & tb_dd_ddh.Text & "'"
        GS_upztxx(G_cnnstr, sql)
    End Sub

    Private Sub tb_dd_kh_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dd_kh.SelectedValueChanged
        Dim sql As String = "select tb_khyqqkyrb_cpdm,tb_khyqqkyrb_jgdm,tb_khyqqkyrb_cplx,tb_khyqqkyrb_pm,tb_khyqqkyrb_khqc,tb_khyqqkyrb_ddgh from tb_khyqqkyrb  "
        sql &= " where tb_khyqqkyrb_khmc='" & tb_dd_kh.Text & "' and  tb_khyqqkyrb_yxx='有效'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count <> 0 Then
            tb_dd_cplx.Text = Null2String(dt.Rows(0)("tb_khyqqkyrb_cplx"))
            tb_dd_cpdm.Text = Null2String(dt.Rows(0)("tb_khyqqkyrb_cpdm"))
            tb_dd_jgdm.Text = Null2String(dt.Rows(0)("tb_khyqqkyrb_jgdm"))
            tb_dd_pm.Text = Null2String(dt.Rows(0)("tb_khyqqkyrb_pm"))
            tb_dd_khqc.Text = Null2String(dt.Rows(0)("tb_khyqqkyrb_khqc"))
            tb_dd_ddgh.Text = Null2String(dt.Rows(0)("tb_khyqqkyrb_ddgh"))
        End If

    End Sub

    Private Sub tb_dd_ddrq_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dd_ddrq.ValueChanged
        tb_dd_ddrq.Format = DateTimePickerFormat.Short
        tb_dd_ddrq.Checked = True
    End Sub

    Private Sub tb_dd_sjdhrq_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dd_sjdhrq.ValueChanged
        tb_dd_sjdhrq.Format = DateTimePickerFormat.Short
        tb_dd_sjdhrq.Checked = True
    End Sub
    '订单退货
    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If tb_dd_returnsl.Text = "" Then
            MessageBox.Show("退换货数量没有输入！")
            Exit Sub
        End If
        thkc()       '退货
        MessageBox.Show("退货OKay！")
        Me.Close()
    End Sub
    '订单退换货
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If tb_dd_returnsl.Text = "" Or tb_dd_returnrq.Text = "" Then
            MessageBox.Show("退换货数量或者时间没有输入！")
            Exit Sub
        End If

        '换货
        If huankc() = False Then
            Exit Sub
        End If
        '退货
        thkc()
        MessageBox.Show("退换货OKay！")
        Me.Close()
    End Sub
    '退货
    Private Sub thkc()
        Dim bm As String = ""
        Dim sql As String
        Dim kcbmx As String = Trim(GF_getstringsql(G_cnnstr, "select top 1 tb_cpdmhz_cpxz from tb_cpdmhz where tb_cpdmhz_cplx='" & tb_dd_cplx.Text & "'", ""))
        If InStr(kcbmx, "毛油") <> 0 Then
            bm = "tb_x825pkc"
        ElseIf InStr(kcbmx, "成品油") <> 0 Then
            bm = "tb_h195zkc"
        ElseIf InStr(kcbmx, "粉") <> 0 Then
            bm = "tb_x832pkc"
        End If
        sql = "select  " & bm & "_id," & bm & "_kczl," & bm & "_sykczl," & bm & "_ckcl  from  " & bm & "  where " & bm & "_num='" & tb_dd_ph.Text & "'and " & bm & "_mingc='" & tb_dd_cpdm.Text & "'and " & bm & "_jiagdm='" & tb_dd_jgdm.Text & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim tmpId As String = Null2String(dt.Rows(0)(bm & "_id"))
            Dim kczl As Double = Double.Parse(dt.Rows(0)(bm & "_kczl"))
            Dim sykczl As Double = Double.Parse(dt.Rows(0)(bm & "_sykczl"))
            Dim ckcl As Double = Double.Parse(dt.Rows(0)(bm & "_ckcl"))
            '更新订单表里的退换货数量和日期
            sql = " update tb_dd set  tb_dd_returnsl = " & tb_dd_returnsl.Text & ",tb_dd_returnrq='" & tb_dd_returnrq.Text & "',tb_dd_fhycms='" & tb_dd_fhycms.Text & "'  where tb_dd_id =" & id & " ; "
            GS_upztxx(G_cnnstr, sql)
            '写入订单退货表
            sql = "insert into tb_returns ( tb_returns_num,tb_returns_cplb,tb_returns_mingc,tb_returns_jiagdm,tb_returns_bm,tb_returns_kcid,tb_returns_ckcl,tb_returns_sykczl,tb_returns_kczl, tb_returns_status,tb_returns_returnsl,tb_returns_returnrq,tb_returns_ddh) "
            sql &= "  values ('" & tb_dd_ph.Text & "','" & tb_dd_cplx.Text & "','" & tb_dd_cpdm.Text & "', '" & tb_dd_jgdm.Text & "' ,'" & bm & "','" & tmpId & "'," & ckcl & "," & sykczl & "," & kczl & ",'未退', " & tb_dd_returnsl.Text & ",'" & CType(tb_dd_returnrq.Text, Date) & "','" & tb_dd_ddh.Text & "')"
            GS_upztxx(G_cnnstr, sql)
        End If
    End Sub
    '换货
    Private Function huankc() As Boolean
        Dim sql As String
        Dim fhhao As String = tb_dd_fhtjdh.Text & "-H"
        sql = "select tb_dd_id from tb_dd where tb_dd_fhtjdh='" & fhhao & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            MessageBox.Show("该条订单已经退换货了")
            Return False
            Exit Function
        End If
        sql = " update tb_dd set  tb_dd_returnsl = " & tb_dd_returnsl.Text & ",tb_dd_returnrq='" & tb_dd_returnrq.Text & "',tb_dd_fhycms='" & tb_dd_fhycms.Text & "'  where tb_dd_id = '" & id & "'  "
        sql &= " insert into tb_dd  (tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs, tb_dd_ddgsyf,tb_dd_ddsrshgh,tb_dd_bz1,tb_dd_bz2,tb_dd_cplx,tb_dd_pm,tb_dd_cw,tb_dd_khqc, tb_dd_ddgh) "
        sql &= " select tb_dd_ddh, 0, tb_dd_cpdm,tb_dd_jgdm,'" & fhhao & "',tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs, tb_dd_ddgsyf,tb_dd_ddsrshgh,'1', null ,tb_dd_cplx,tb_dd_pm,tb_dd_cw,'" & tb_dd_khqc.Text & "', '" & tb_dd_ddgh.Text & "'  "
        sql &= " from tb_dd where tb_dd_id = '" & id & "'  "
        GS_upztxx(G_cnnstr, sql)
        Return True
    End Function

    Private Sub tb_dd_returnsl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dd_returnsl.TextChanged
        If tb_dd_returnsl.Text.Trim = "" Then
            Button9.Enabled = False
            Button10.Enabled = False
        Else
            Button9.Enabled = True
            Button10.Enabled = True
        End If
    End Sub
End Class