Public Class Frtb_five
    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 1, ComboBox1)

    End Sub
    Private Sub tb_x825p_cplb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, tb_x823p_mingc)

    End Sub
    Private Sub tb_x825p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x823p_mingc.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & ComboBox1.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_x823p_jiagdm)
    End Sub

    Private Sub Frtb_one_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        ComboBox2.Items.Add("之间")
        ComboBox2.Items.Add("之外")
        ComboBox2.Items.Add("之间(包括本身)")
        ComboBox2.Items.Add("之外(包括本身)")
        ComboBox2.SelectedItem = ComboBox2.Items(0)
        GroupBox3.Text = "成品油库存"
        Chentextzs1.Text = ""
        Chentextzs2.Text = ""
        Chentextzs3.Text = ""
        weizhi()
        showsj()
    End Sub

    Private Sub weizhi()
        GroupBox3.Width = Me.Width - 20
        GroupBox3.Height = Me.Height - GroupBox3.Top - 40

    End Sub

    'ARA含量查询
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Chentextzs1.Text = "" Then
            MsgBox("请填写数字")
            Chentextzs1.Focus()
            Exit Sub
        End If
        If Chentextzs2.Text = "" Then
            MsgBox("请填写数字")
            Chentextzs2.Focus()
            Exit Sub
        End If
        If Chentextzs3.Text = "" Then
            MsgBox("请填写数字")
            Chentextzs3.Focus()
            Exit Sub
        End If

        '设定的AA含量
        Dim num As Double = Chentextzs3.Text
        Dim sign As String = ""
        Dim sign2 As String = ""
        Select Case ComboBox2.SelectedIndex
            Case 0
                sign = ">" : sign2 = "<"
            Case 1
                sign = "<" : sign2 = ">"
            Case 2
                sign = ">=" : sign2 = "<="
            Case 3
                sign = "<=" : sign2 = ">="
        End Select

        '1 ID 2 成品油批号 3 重量  4库存  5 用途
        Dim strWh As String = ""
        If ComboBox1.Text = "DPGE" Then
            strWh = " and tb_h195zkc_cplb='DOGF' "
        Else
            strWh = " and tb_h195zkc_cplb<>'DOGF' "
        End If
        Dim sql As String = "select tb_h195zkc_ID,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_c6u,tb_h195zkc_yg,tb_h195zkc_jgrq,tb_h195zkc_ckcl,tb_h195zkc_jiagdm,tb_h195zkc_mingc,tb_h195zkc_cplb,tb_h195zkc_rkbz,tb_h195zkc_kdlk,tb_h195zkc_cw,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk  from tb_h195zkc  where tb_h195zkc_c6u " & sign & Chentextzs1.Text & " and tb_h195zkc_c6u" & sign2 & Chentextzs2.Text & " and tb_h195zkc_sykczl>0 "
        sql = sql & " and tb_h195zkc_qaspjg='合格' and tb_h195zkc_yg='生产' " & strWh & " order by tb_h195zkc_jgrq"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count < 1 Then
            MsgBox("没有符合要求的配料")
            Exit Sub
        End If

        GS_useviewbydb2(ListView2, dt, 0, 150)

        Dim ps As Integer

        ListView2.Columns.Insert(4, "可生产小批数", 150)
        ListView2.Columns.Insert(5, "单批重量", 100)
        For i As Integer = 0 To dt.Rows.Count - 1
            ps = Int((dt.Rows(i)(2)) / num)
            Dim si As New ListViewItem.ListViewSubItem(ListView2.Items(i), ps)
            ListView2.Items(i).SubItems.Insert(4, si)
        Next
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim pjz As Double = num

            Dim si As New ListViewItem.ListViewSubItem(ListView2.Items(i), pjz)
            ListView2.Items(i).SubItems.Insert(5, si)
        Next
        Button5.Visible = True
    End Sub

    Private Sub showsj()
        Dim sql As String = ""
        Dim sql1 As String = ""

        sql = "select tb_h195zkc_ID,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_c6u,tb_h195zkc_yg,tb_h195zkc_jgrq,tb_h195zkc_ckcl,tb_h195zkc_jiagdm,tb_h195zkc_mingc,tb_h195zkc_cplb,tb_h195zkc_rkbz,tb_h195zkc_kdlk,tb_h195zkc_cw,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk from tb_h195zkc  where tb_h195zkc_sykczl > 0 and tb_h195zkc_qaspjg='合格' and tb_h195zkc_yg='生产'  order by tb_h195zkc_jgrq"

        sql1 = "select tb_h195zkc_ID,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_c6u,tb_h195zkc_yg,tb_h195zkc_jgrq,tb_h195zkc_ckcl,tb_h195zkc_jiagdm,tb_h195zkc_mingc,tb_h195zkc_cplb,tb_h195zkc_rkbz,tb_h195zkc_kdlk,tb_h195zkc_cw,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk from tb_h195zkc where tb_h195zkc_sykczl <= 0 and tb_h195zkc_qaspjg='合格' and tb_h195zkc_yg='生产'  order by tb_h195zkc_jgrq"

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView2, dt, 0, 150)

    End Sub


    Private Sub Frtb_one_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        weizhi()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        '''''''''''''''''''''''''''''
        If MsgBox("请确认生产代码和加工代码是否正确？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If GF_storelog1("完成粉剂配料调配") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If ListView2.SelectedItems.Count < 1 Then
            MsgBox("请选择要进塔的记录")
            Exit Sub
        End If
        Dim aa As String = InputBox("填写提取多少批？", "提取", ListView2.SelectedItems(0).SubItems(4).Text)
        If aa = "" Then
            MsgBox("请填写提取多少批") : Exit Sub
        End If
        Dim ps As Integer
        Try
            ps = aa
        Catch ex As Exception
            MsgBox("请填写大于0的数字") : Exit Sub
        End Try
        If ps <= 0 Then
            MsgBox("请填写大于0的数字") : Exit Sub
        End If

        Dim dpzl As Double = ListView2.SelectedItems(0).SubItems(5).Text '单批重量
        If dpzl > ListView2.SelectedItems(0).SubItems(5).Text Then
            MsgBox("输入量不可大于可生产小批数！")
            Exit Sub
        End If
        Dim num As Double = dpzl * ps '总量
        If MsgBox("确认提取重量" & num & "吗?", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''
        '设定5号塔配料批号
        Dim qztemp As String=""
        If ListView2.SelectedItems(0).SubItems(11).Text = "DOGF" Then
            qztemp = ClassPhgn.ClassPhgn_Get("5号DHA配料单", "-") '得到当前批号+1的批号
        Else
            qztemp = ClassPhgn.ClassPhgn_Get("5号塔配料单", "-") '得到当前批号+1的批号
        End If

        If qztemp = "" Then
            MsgBox("批号设定不正确") : Exit Sub
        End If
        Dim ph As String = qztemp
        If MsgBox("将生成新的配料批号：" & ph, 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''
        Dim sql As String = "Insert into tb_x823p(tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_t678l,tb_x823p_num2,tb_x823p_jgrq,tb_x823p_num,tb_x823p_kczl,tb_x823p_sbtb,tb_x823p_sbid,tb_x823p_cplb,tb_x823p_jhhl,tb_x823p_czrgh ,tb_x823p_mingc,tb_x823p_jiagdm,tb_x823p_dpmx) values(" & dpzl & "," & ps & ",'5号塔配料'," & num & ",'" & ListView2.SelectedItems(0).SubItems(1).Text & "',getdate(),'" & ph & "'," & num & ",'tb_h195zkc'," & ListView2.SelectedItems(0).SubItems(0).Text & ",'" & ComboBox1.Text & "'," & ListView2.SelectedItems(0).SubItems(3).Text & ",'" & G_dlrgh & "','" & tb_x823p_mingc.Text & "','" & tb_x823p_jiagdm.Text & "'," & dpzl & ")"
        '插入记录到粉剂配料
        Dim idAll As String = GF_upztxx2(G_cnnstr, sql, "tb_x823p")
        '修改配料原来的AA含量,下步表,下步ID
        'sql = "update tb_h195zkc set tb_h195zkc_sykczl=tb_h195zkc_sykczl-" & num & " ,tb_h195zkc_glid='" & idAll & "', tb_h195zkc_xbtb='tb_x823p' where tb_h195zkc_ID=" & ListView2.SelectedItems(0).SubItems(0).Text
        'GS_upztxx(G_cnnstr, sql) '更新
        sql = "update tb_h195zkc set tb_h195zkc_glid='" & idAll & "', tb_h195zkc_xbtb='tb_x823p' where tb_h195zkc_ID=" & ListView2.SelectedItems(0).SubItems(0).Text
        GS_upztxx(G_cnnstr, sql) '更新

        If ListView2.SelectedItems(0).SubItems(11).Text = "DOGF" Then
            ClassPhgn.ClassPhgn_SetDqz2("5号DHA配料单") '使当前批号+1
        Else
            ClassPhgn.ClassPhgn_SetDqz2("5号塔配料单") '使当前批号+1
        End If
        GS_storelog3("完成粉剂配料调配：" & ph, "完成粉剂配料调配") '储存到日志
        MsgBox("已提取" & ps & "批,共提取" & num & "(Kg)," & "单批重量为" & dpzl)

        Dim nform As New Faddfjpl5
        nform.Labeltb.Text = "tb_x823p"
        nform.Labelid.Text = idAll
        nform.ShowDialog()

        showsj()
        Chentextzs1.Text = ""
        Chentextzs2.Text = ""
        Chentextzs3.Text = ""
    End Sub


End Class