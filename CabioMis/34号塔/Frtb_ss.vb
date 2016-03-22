Public Class Frtb_ss


    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 1, ComboBox2)
    End Sub
    Private Sub tb_x825p_cplb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, tb_x823p_mingc)
    End Sub
    Private Sub tb_x825p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x823p_mingc.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & ComboBox2.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_x823p_jiagdm)
    End Sub

    Private Sub Frtb_ss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        Chentextzs5.Text = 40.5
        Chentextzs1.Text = 42.5
        Chentextzs2.Text = 44
        Chentextzs3.Text = 60
        Chentextzs4.Text = 50
        gs3.Text = 80
        Chentextzs4.Text = 70
        ComboBox1.SelectedIndex = 0
        weizhi()
    End Sub
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub

    Private Sub weizhi()
        GroupBox2.Width = Me.Width - 40
        GroupBox1.Width = GroupBox2.Width
        GroupBox5.Width = GroupBox2.Width
        GroupBox6.Width = GroupBox2.Width
        GroupBox6.Height = Me.Height - GroupBox6.Top - 40
        GroupBox3.Width = Me.Width / 2 - 25
        GroupBox4.Left = GroupBox3.Right + 10
        GroupBox4.Width = GroupBox3.Width
    End Sub

    Private Sub Frtb_ss_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        weizhi()
    End Sub

    '查询
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'ＡＡ油下线
        Dim xx As Double = Chentextzs5.Text
        'ＡＡ油上线
        Dim sx As Double = Chentextzs2.Text
        'AA含量中线
        Dim zx As Double = Chentextzs1.Text
        'ＡＡ油重量
        Dim zl As Double = Chentextzs3.Text
        '参考重量
        Dim ckzl As Double = Chentextzs4.Text

        Dim strWh As String = ""
        Select Case ComboBox3.Text
            Case "DHA"
                strWh = " and tb_h195zkc_cplb='DOGF'"
            Case "ARA"
                strWh = " and tb_h195zkc_cplb<>'DOGF'"
        End Select
        Dim sql As String = "select tb_h195zkc_ID,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_c6u,tb_h195zkc_jgrq,tb_h195zkc_pf,tb_h195zkc_jiagdm,tb_h195zkc_mingc,tb_h195zkc_rkbz,tb_h195zkc_kdlk,tb_h195zkc_cw,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk from tb_h195zkc  where tb_h195zkc_sykczl > 0 and tb_h195zkc_qaspjg='合格' and tb_h195zkc_yg='生产' " & strWh & "order by tb_h195zkc_jgrq asc" '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        Dim dt1 As DataTable = GF_czmctb(dt, "tb_h195zkc_c6u<" & xx, "tb_h195zkc_jgrq asc")
        GS_useviewbydb2(ListView1, dt1, 0, 150) 'ＡＡ油下线列表
        dt1 = GF_czmctb(dt, "tb_h195zkc_c6u>" & sx, "tb_h195zkc_jgrq asc")
        GS_useviewbydb2(ListView2, dt1, 0, 150) 'ＡＡ油上线列表
        dt1 = GF_czmctb(dt, "tb_h195zkc_c6u>=" & xx & " and tb_h195zkc_c6u<" & zx, "tb_h195zkc_jgrq asc")
        GS_useviewbydb2(ListView3, dt1, 0, 150) '下至中
        dt1 = GF_czmctb(dt, "tb_h195zkc_c6u>=" & zx & " and tb_h195zkc_c6u<=" & sx, "tb_h195zkc_jgrq asc")
        GS_useviewbydb2(ListView4, dt1, 0, 150) '中至上
        dt1 = GF_czmctb(dt, "tb_h195zkc_sykczl<" & ckzl, "tb_h195zkc_jgrq asc")
        GS_useviewbydb2(ListView5, dt1, 0, 150) '小于设定重量
        Dim dt2 As DataTable = dt1.Clone
        GS_useviewbydb2(ListView6, dt2, 0, 150) '混合表
        ListView6.Columns.Insert(4, "可生产小批数", 150)
        ListView6.Columns.Insert(5, "单批重量", 100)
        ListView6.Columns.Insert(6, "计划含量", 100)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        '''''''''''''''''''''''''判断组合是否有效
        If MsgBox("请确认生产代码和加工代码是否正确？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If ListView6.Items.Count = 0 Then
            MsgBox("配料组合不对！") : Exit Sub
        End If
        Dim sdzl As String = Chentextzs4.Text.Trim '设定重量
        Dim zhid As String = "" '组合粉剂ID与批号
        Dim ylph As String = Nothing
        Dim ylkc As String = "" '原料库存
        For i As Integer = 0 To ListView6.Items.Count - 1
            zhid = zhid & ListView6.Items(i).SubItems(0).Text & ","
            ylph &= ListView6.Items(i).SubItems(1).Text & ","
            ylkc = ylkc & ListView6.Items(i).SubItems(2).Text & ","
        Next
        zhid = GF_removedh(zhid) : ylph = GF_removedh(ylph) : ylkc = GF_removedh(ylkc)
        Dim zhxp As Integer = getzxps() '得到小批个数
        Dim dpzl As Double = ListView6.Items(0).SubItems(5).Text '单批重量
        Dim zzl As Double = zhxp * dpzl ';总重量
        Dim jhhl As Double = ListView6.Items(0).SubItems(6).Text '得到计划含量
        ''''''''''''''''''''''''
        '设定配料批号
        Dim qztemp As String = ClassPhgn.ClassPhgn_Get("34号塔配料单", "-") '得到当前批号+1的批号
        If ComboBox2.Text = "DPGE" Then
            qztemp = ClassPhgn.ClassPhgn_Get("34号DHA配料单", "-") '得到当前批号+1的批号
        Else
            qztemp = ClassPhgn.ClassPhgn_Get("34号塔配料单", "-") '得到当前批号+1的批号
        End If
        If qztemp = "" Then
            MsgBox("批号设定不正确") : Exit Sub
        End If
        Dim ph As String = qztemp
        ''''''''''''''''''''''''''''''''''''''
        If MsgBox("将生成新的配料批号：" & ph, 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tqps As Integer '需要提取的批数
        Try
            tqps = InputBox("填写提取多少批？", "提取", zhxp.ToString)
        Catch ex As Exception
            MsgBox("请正确填写提取批数！") : Exit Sub
        End Try
        ''''''''''''''''''''''''''''''''
        If tqps > zhxp Or tqps = 0 Then
            MsgBox("请正确填写提取批数！") : Exit Sub
        End If
        ''''''''''''''''''''''''''''
        If ComboBox1.SelectedIndex = 0 Then '高低混配

            If gdhpgs(tqps, ylph, ph, zhid, jhhl) = False Then
                MsgBox("配料失败") : Exit Sub
            Else
                MsgBox("配料成功") : addpljhsj() : Me.Close()
            End If

        End If

        If ComboBox1.SelectedIndex = 1 Then '直接选取
            If gdhpgs2(tqps, ylph, ph, zhid, jhhl) = False Then
                MsgBox("配料失败") : Exit Sub
            Else
                MsgBox("配料成功")
                addpljhsj()
                Me.Close()
            End If
        End If

        ''''''''''''''''''''''''''''
        If ComboBox1.SelectedIndex = 2 Then '零头混配
            If ListView6.Items(0).SubItems(5).Text - Chentextzs3.Text < 0 Then
                MsgBox("单批重量小于下限！") : Exit Sub
            End If
            If gdhpgs3(ylkc, ylph, ph, zhid, jhhl) = False Then
                MsgBox("配料失败") : Exit Sub
            Else
                MsgBox("配料成功") : addpljhsj() : Me.Close()
            End If
        End If

    End Sub

    '1/2/3双击选入组合表
    Private Sub ListViewk_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick, ListView2.MouseDoubleClick, ListView3.MouseDoubleClick, ListView4.MouseDoubleClick, ListView5.MouseDoubleClick
        Dim kke As ListView = sender
        With kke
            '’‘’下面判断
            If .SelectedItems.Count = 0 Then
                Exit Sub
            End If
            For i As Integer = 0 To ListView6.Items.Count - 1
                If ListView6.Items(i).SubItems(0).Text = .SelectedItems(0).SubItems(0).Text Then
                    MsgBox("选择重复")
                    Exit Sub
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''下面填充
            Dim kk As ListViewItem = ListView6.Items.Add(.SelectedItems(0).SubItems(0).Text)
            For i As Integer = 1 To .Columns.Count - 1
                kk.SubItems.Add(.SelectedItems(0).SubItems(i).Text)
            Next
            '如果listview6 没有记录 退出公式判断
            If ListView6.Items.Count <= 0 Then
                Exit Sub
            End If
            ''''''''''''''''''''''''
            Select Case ComboBox1.SelectedIndex
                Case 2 '零头混配
                    Call gs11()
                Case 1 '直接选取
                    Call gs12()
                Case 0 '高低混配
                    Call gs13()
            End Select
            ''''''''''''''''''''''
        End With
    End Sub

    Private Sub ListView4_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView6.MouseDoubleClick
        ''''''''
        ListView6.Items.RemoveAt(ListView6.SelectedItems(0).Index)
        Select Case ComboBox1.SelectedIndex
            Case 2 '零头混配
                Call gs11()
            Case 1 '直接选取
                Call gs12()
            Case 0 '高低混配
                Call gs13()
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView6.Items.Clear()
        GroupBox6.Text = "组合"
        Debug.Print(ComboBox1.SelectedIndex)
        If ComboBox1.SelectedIndex = 2 Then '零头混批
            GS_tofalse("Label7,Label2,gs3,Label4,Chentextzs3", True, Me)
            ListView1.Enabled = False
            ListView2.Enabled = False
            ListView3.Enabled = False
            ListView4.Enabled = False
            ListView5.Enabled = True
        ElseIf ComboBox1.SelectedIndex = 1 Then '直接选取
            GS_tofalse("Label7,gs3,Label4,Chentextzs3", False, Me)
            Label2.Visible = True : Chentextzs4.Visible = True
            ListView1.Enabled = False
            ListView5.Enabled = False
            ListView4.Enabled = True
            ListView2.Enabled = True
            ListView3.Enabled = True
        ElseIf ComboBox1.SelectedIndex = 0 Then '高低混配
            GS_tofalse("Label7,gs3,Label4,Chentextzs3", False, Me)
            Label2.Visible = True : Chentextzs4.Visible = True
            If ListView6.Items.Count = 0 Then
                ListView1.Enabled = True
                ListView2.Enabled = False
            End If
            If ListView6.Items.Count = 1 Then
                ListView1.Enabled = False
                ListView2.Enabled = True
            End If
            ListView5.Enabled = False
            ListView3.Enabled = False
            ListView4.Enabled = True
        End If
    End Sub



    Private Function expression1(ByVal str As Double) As String '公式1,结果得到组合参考值重量
        Dim a As Double = Chentextzs5.Text.Trim : Dim b As Double = Chentextzs1.Text.Trim
        Dim c As Double = Chentextzs2.Text.Trim : Dim d As Double = Chentextzs4.Text.Trim

        Dim hl1, hl2 As Double
        hl1 = ListView6.Items(0).SubItems(3).Text '含量1
        hl2 = str '含量2
        Dim min1, max1 As Double
        If hl1 < hl2 Then
            min1 = hl1 : max1 = hl2
        Else
            min1 = hl2 : max1 = hl1
        End If
        Dim x As Double = d * (a - max1) / (min1 - max1)
        Dim y As Double = d - x

        Dim xp1 As Integer = Int(x / 5) * 5
        Dim xp2 As Integer = d - xp1
        expression1 = xp1 & "," & xp2
    End Function
    '求最小或者最大值
    Private Function expression2(ByVal str1 As Double, ByVal str2 As Double, ByVal str3 As String) As Double
        If str3 = "min" Then
            If str1 <= str2 Then
                expression2 = str1
            Else
                expression2 = str2
            End If
        Else
            If str1 <= str2 Then
                expression2 = str2
            Else
                expression2 = str1
            End If
        End If
    End Function
    Private Function expression3(ByVal str1 As String, ByVal str2 As String) As Double
        Dim t1, t2 As String
        t1 = GF_searchchar(str1, ",", "left")
        t2 = GF_searchchar(str1, ",", "right")
        expression3 = expression2(t1, t2, str2)
    End Function
    '高低混配,提取批数，原来批号，配料批号,成品油ID
    Private Function gdhpgs(ByVal tqps As Integer, ByVal ylph As String, ByVal ph As String, ByVal allid As String, ByVal hl As Double) As Boolean
        Try
            gdhpgs = False
            Dim zdps As Double = expression2(ListView6.Items(0).SubItems(4).Text, ListView6.Items(1).SubItems(5).Text, "min") '得到能够提取的最大批次
            If tqps > zdps Then
                MsgBox("请正确填写提取批数！") : Exit Function
            End If
            Dim cplb As String = ComboBox2.Text '产品类别
            Dim zl1, zl2 As Double
            zl1 = ListView6.Items(1).SubItems(5).Text
            zl2 = ListView6.Items(0).SubItems(5).Text
            Dim dpzl As Double = zl1 + zl2 '单批重量
            Dim dpmx As String = zl1.ToString & zl2.ToString '单批明细
            '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
            If GF_storelog2("完成粉剂配料高低混配：" & ph, "完成粉剂配料调配") = False Then
                Exit Function
            End If
            ''''''''''''''''''''
            Dim kczl As String = (zl2 * tqps).ToString & "," & (zl1 * tqps).ToString '扣除的对应成品油批号的重量字符串
            Dim Sql As String = "Insert into tb_x823p(tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_t678l,tb_x823p_num2,tb_x823p_num,tb_x823p_jgrq,tb_x823p_kczl,tb_x823p_sbtb,tb_x823p_sbid,tb_x823p_jhhl,tb_x823p_cplb,tb_x823p_czrgh,tb_x823p_mingc,tb_x823p_jiagdm,tb_x823p_dpmx) values"
            Sql = Sql & "(" & dpzl & "," & tqps & ",'34号塔配料'," & (dpzl * tqps) & ",'" & ylph & "','" & ph & "',getdate(),'" & kczl & "','tb_h195zkc','" & allid & "'," & hl & ",'" & cplb & "','" & G_dlrgh & "','" & tb_x823p_mingc.Text & "','" & tb_x823p_jiagdm.Text & "','" & dpmx & "')"
            Dim nextid As String = GF_upztxx2(G_cnnstr, Sql, "tb_x823p")
            '储存到配料表
            '''''''''''''''''扣库存
            Sql = "update tb_h195zkc set tb_h195zkc_sykczl=tb_h195zkc_sykczl-" & (zl2 * tqps) & " where tb_h195zkc_id=" & ListView6.Items(0).SubItems(0).Text
            Sql = Sql & vbCrLf & "update tb_h195zkc set tb_h195zkc_sykczl=tb_h195zkc_sykczl-" & (zl1 * tqps) & "  where tb_h195zkc_id=" & ListView6.Items(1).SubItems(0).Text
            GS_upztxx(G_cnnstr, Sql) '更新

            If ComboBox2.Text = "DPGE" Then
                ClassPhgn.ClassPhgn_SetDqz2("34号DHA配料单") '使当前批号+1
            Else
                ClassPhgn.ClassPhgn_SetDqz2("34号塔配料单") '使当前批号+1
            End If
            '''''''''更新成品油的下步字段
            gxcpyxbid(nextid)
            ''''''''''''''''''
            gdhpgs = True
        Catch ex As Exception
            gdhpgs = False
        End Try
    End Function
    '直接选取
    Private Function gdhpgs2(ByVal tqps As Integer, ByVal ylph As String, ByVal ph As String, ByVal allid As String, ByVal hl As Double) As Boolean
        Try
            gdhpgs2 = False
            Dim cplb As String = ComboBox2.Text '产品类别

            Dim dpzl As Double = ListView6.Items(0).SubItems(5).Text '单批重量
            Dim kczl As Double = tqps * dpzl '扣除库存
            '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
            If GF_storelog2("完成粉剂配料直接选取：" & ph, "完成粉剂配料调配") = False Then
                Exit Function
            End If
            ''''''''''''''''''''

            Dim Sql As String = "Insert into tb_x823p(tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_t678l,tb_x823p_num2,tb_x823p_num,tb_x823p_jgrq,tb_x823p_kczl,tb_x823p_sbtb,tb_x823p_sbid,tb_x823p_jhhl,tb_x823p_cplb,tb_x823p_czrgh,tb_x823p_mingc,tb_x823p_jiagdm,tb_x823p_dpmx) values"
            Sql = Sql & "(" & dpzl & "," & tqps & ",'34号塔配料'," & kczl & ",'" & ylph & "','" & ph & "',getdate(),'" & kczl & "','tb_h195zkc','" & allid & "'," & hl & ",'" & cplb & "','" & G_dlrgh & "','" & tb_x823p_mingc.Text & "','" & tb_x823p_jiagdm.Text & "'," & dpzl & ")"
            Dim nextid As String = GF_upztxx2(G_cnnstr, Sql, "tb_x823p")  '储存到配料表
            '''''''''''''''''扣库存
            Sql = "update tb_h195zkc set tb_h195zkc_sykczl=tb_h195zkc_sykczl-" & kczl & " where tb_h195zkc_id=" & ListView6.Items(0).SubItems(0).Text
            DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, Sql) '更新
            ClassPhgn.ClassPhgn_SetDqz2("34号塔配料单") '使当前批号+1
            '''''''''更新成品油的下步字段
            gxcpyxbid(nextid)
            ''''''''''''''''''
            gdhpgs2 = True
        Catch ex As Exception
            gdhpgs2 = False
        End Try

    End Function
    '零头混配
    Private Function gdhpgs3(ByVal kczll As String, ByVal ylph As String, ByVal ph As String, ByVal allid As String, ByVal hl As Double) As Boolean
        Try
            gdhpgs3 = False
            Dim cplb As String = ComboBox2.Text '产品类别
            Dim dpzl As Double = ListView6.Items(0).SubItems(5).Text '单批重量
            Dim kczl As Double = dpzl '扣除库存
            '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
            If GF_storelog2("完成粉剂配料零头混配：" & ph, "完成粉剂配料调配") = False Then
                Exit Function
            End If
            ''''''''''''''''''''
            Dim Sql As String = "Insert into tb_x823p(tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_t678l,tb_x823p_num2,tb_x823p_num,tb_x823p_jgrq,tb_x823p_kczl,tb_x823p_sbtb,tb_x823p_sbid,tb_x823p_jhhl,tb_x823p_cplb,tb_x823p_czrgh,tb_x823p_mingc,tb_x823p_jiagdm,tb_x823p_dpxm) values"
            Sql = Sql & "(" & dpzl & ",1,'34号塔配料'," & kczl & ",'" & ylph & "','" & ph & "',getdate(),'" & kczll & "','tb_h195zkc','" & allid & "'," & hl & ",'" & cplb & "','" & G_dlrgh & "','" & tb_x823p_mingc.Text & "','" & tb_x823p_jiagdm.Text & "'," & dpzl & ")"
            Dim nextid As String = GF_upztxx2(G_cnnstr, Sql, "tb_x823p")  '储存到配料表
            '''''''''''''''''扣库存
            Sql = "update tb_h195zkc set tb_h195zkc_sykczl=0 where tb_h195zkc_id in(" & allid & ")"
            GS_upztxx(G_cnnstr, Sql) '更新
            ClassPhgn.ClassPhgn_SetDqz2("34号塔配料单") '使当前批号+1
            '''''''''更新成品油的下步字段
            gxcpyxbid(nextid)
            ''''''''''''''''''
            gdhpgs3 = True
        Catch ex As Exception
            gdhpgs3 = False
        End Try

    End Function
    Private Sub gxcpyxbid(ByVal nextid As String)
        '''''''''更新成品油的下步字段
        For i As Integer = 0 To ListView6.Items.Count - 1
            GS_gengsb("tb_h195zkc", ListView6.Items(i).SubItems(0).Text, "tb_x823p", nextid)
        Next
    End Sub

    Private Sub inserthl() '本功能实现计划含量
        Dim zz1, zz2 As Double
        zz1 = 0 : zz2 = 0
        For j As Integer = 0 To ListView6.Items.Count - 1
            Dim m1 As Double = 0
            Select Case ComboBox1.SelectedIndex
                Case 2 '零头混配
                    m1 = ListView6.Items(j).SubItems(2).Text
                Case 1, 0 '直接选取 '高低混配
                    m1 = ListView6.Items(j).SubItems(5).Text

            End Select
            Dim z1 As Double = ListView6.Items(j).SubItems(3).Text
            zz1 = zz1 + m1 * z1
            zz2 = zz2 + m1
        Next
        Dim jhhl As Double = 0
        Try
            jhhl = zz1 / zz2
        Catch ex As Exception

        End Try

        jhhl = FormatNumber(jhhl, 2) '保留2位小数四舍五入CInt(jhhl * 100) / 100 

        For j As Integer = 0 To ListView6.Items.Count - 1
            Dim si As New ListViewItem.ListViewSubItem(ListView6.Items(j), jhhl)
            ListView6.Items(j).SubItems.Insert(6, si)
        Next
    End Sub
    Private Sub gs13()  '高低混配的公式
        If ListView6.Items.Count > 2 Then
            MsgBox("超过了指定记录数量!")
            ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
            Exit Sub
        End If
        If ListView6.Items.Count <> 2 Then
            Exit Sub
        End If
        ''''''''''''''得到2个ara含量
        Dim hl1 As Double = ListView6.Items(1).SubItems(3).Text
        Dim hl2 As Double = ListView6.Items(0).SubItems(3).Text
        ''''''''''''''''''得到2个库存重量
        Dim kc1 As Double = ListView6.Items(1).SubItems(2).Text
        Dim kc2 As Double = ListView6.Items(0).SubItems(2).Text
        '''''''''''''''
        Dim bt As String = expression1(hl1)
        GroupBox6.Text = "组合参考：" & bt
        ''''''''''''''''得到2个参考值
        Dim ckzzxmin As Double = expression3(bt, "min")
        Dim ckzzxmax As Double = expression3(bt, "max")
        '''''''''''''''''''插入 2 列 用于显示 批数 和 单批重量  位置6 ,7列 
        insertzlps(0, "")
        '''''''''''''''''''''''''''''''''''''''每次removeAt 之后都会自动 Refresh''''''''''''''''''''''''''''
        If hl1 = ckzzxmin Then
            Dim dps1 As Integer = Int(kc1 / ckzzxmin) '得到批数
            Dim dps2 As Integer = Int(kc2 / ckzzxmax) '得到批数
            ListView6.Items(1).SubItems(4).Text = dps1
            ListView6.Items(1).SubItems(5).Text = ckzzxmin
            ListView6.Items(0).SubItems(4).Text = dps2
            ListView6.Items(0).SubItems(5).Text = ckzzxmax
        Else
            Dim dps1 As Integer = Int(kc1 / ckzzxmax) '得到批数
            Dim dps2 As Integer = Int(kc2 / ckzzxmin) '得到批数
            ListView6.Items(1).SubItems(4).Text = dps1
            ListView6.Items(1).SubItems(5).Text = ckzzxmax
            ListView6.Items(0).SubItems(4).Text = dps2
            ListView6.Items(0).SubItems(5).Text = ckzzxmin
        End If
        ''''''''''''''''''''''''''''''
        inserthl() '计划含量
        '''''''''''杨帅于2008年11月7日更新begin'''''''''''
        ListView2.Enabled = True
        '''''''''''杨帅于2008年11月7日更新end''''''''''
    End Sub
    Private Sub gs12()  '直接选取的公式
        Dim zll As Double = 0
        If ListView6.Items.Count = 2 Then
            MsgBox("已经有一条数据了")
            ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
            Exit Sub
        End If
        '重量累加 
        For i As Integer = 0 To ListView6.Items.Count - 1
            zll = zll + ListView6.Items(i).SubItems(2).Text
        Next
        Dim dpzl As Double = Chentextzs4.Text
        Dim ps As Integer = Int(zll / dpzl)
        insertzlps(ps, dpzl) : inserthl() '插入批数、单批重量、计划含量
    End Sub
    Private Sub gs11()  '零头混配的公式

        Dim zll As Double = 0
        '重量累加 
        For i As Integer = 0 To ListView6.Items.Count - 1
            zll = zll + ListView6.Items(i).SubItems(2).Text
        Next
        '重量上线
        Dim zlsx As Double = gs3.Text
        '重量下线
        Dim zlxx As Double = Chentextzs3.Text
        If zll >= zlxx And zll <= zlsx Then
            MsgBox("已经达到要求的重量!")
        End If
        If zll > zlsx Then
            MsgBox("超出了要求的重量!")
            ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
            Exit Sub
        End If
        Dim dpzl As Double = zll
        Dim ps As Integer = Int(zll / dpzl)
        insertzlps(ps, zll) : inserthl() '插入批数、单批重量、计划含量
    End Sub
    Private Sub insertzlps(ByVal str1 As Integer, ByVal str2 As String) '本功能插入单批数与单批重量
        For i As Integer = 0 To ListView6.Items.Count - 1
            Dim si As New ListViewItem.ListViewSubItem(ListView6.Items(i), str1)
            ListView6.Items(i).SubItems.Insert(4, si)
            Dim si2 As New ListViewItem.ListViewSubItem(ListView6.Items(i), str2)
            ListView6.Items(i).SubItems.Insert(5, si2)
        Next
    End Sub
    Private Function getzxps() As Integer '得到提取的小批数
        Select Case ComboBox1.SelectedIndex
            Case 2 '零头混配
                getzxps = 1
            Case 1 '直接选取
                getzxps = ListView6.Items(0).SubItems(4).Text
            Case 0 '高低混配
                Dim zl1, zl2 As Integer
                zl1 = ListView6.Items(0).SubItems(4).Text
                zl2 = ListView6.Items(1).SubItems(4).Text
                getzxps = expression2(zl1, zl2, "min")
        End Select
    End Function
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    '使某些控件可见或不可见str表示控件名，逗号隔开，str3表示容器控件
    Public Sub GS_tofalse(ByVal str As String, ByVal str2 As Boolean, ByVal STR3 As Control)
        Dim KZJ() As String = str.Split(",")
        With STR3
            For I As Integer = 0 To UBound(KZJ)
                .Controls(KZJ(I)).Visible = str2
            Next
        End With
    End Sub

    Private Sub addpljhsj()
        Dim inid As Integer
        Dim dtx As DataTable = GF_CreateDataSource(G_cnnstr, "select top 1 tb_x823p_id from tb_x823p  order by  tb_x823p_id DESC ")
        inid = dtx.Rows(0)(0)
        Dim nform As New Fraddfjpl
        nform.Labeltb.Text = "tb_x823p"
        nform.Labelid.Text = inid
        nform.ShowDialog()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub


End Class