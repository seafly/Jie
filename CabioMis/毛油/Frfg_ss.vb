Public Class Frfg_ss
    Private Sub Frfg_ss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Chentextzs5.Text = 250 : Chentextzs1.Text = 480 : Chentextzs2.Text = 530
        gs3.Text = 0 : Chentextzs1.Text = 480 : Chentextzs4.Text = 0 : Chentextzs3.Text = 0
        ComboBox1.SelectedIndex = 0
        weizhi()
    End Sub

    Private Sub weizhi()
        GroupBox2.Width = Me.Width - 40
        GroupBox1.Width = GroupBox2.Width
        GroupBox6.Width = GroupBox2.Width
        GroupBox6.Height = Me.Height - GroupBox6.Top - 40
        GroupBox3.Width = Me.Width / 2 - 25
        GroupBox4.Left = GroupBox3.Right + 10
        GroupBox4.Width = GroupBox3.Width
    End Sub

    Private Sub Frfg_ss_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        'ＡＡ油下上限
        Dim b1 As Double = Chentextzs3.Text : Dim b2 As Double = gs3.Text
        '''''''''''''''''重量中上限,参考重量
        : Dim a2 As Double = Chentextzs1.Text : Dim a3 As Double = Chentextzs2.Text : Dim a1 As Double = Chentextzs5.Text
        ''''''''''''''''
        Dim sql As String = "select tb_x825p_ID,tb_x825p_num,tb_x825p_sykczl,tb_x825p_m387e from tb_x825p  where tb_x825p_sykczl > 0 and (tb_x825p_qaspjg='合格' or tb_x825p_qaspjg='待定')" '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        Dim dt1 As DataTable = GF_czmctb(dt, "tb_x825p_m387e<" & b1)
        GS_useviewbydb2(ListView1, dt1, 0, 150) 'ＡＡ油下线列表
        dt1 = GF_czmctb(dt, "tb_x825p_m387e>" & b2)
        GS_useviewbydb2(ListView2, dt1, 0, 150) 'ＡＡ油上线列表
        '''''''''''''''''''''''''''''''''''
        dt1 = GF_czmctb(dt, "tb_x825p_m387e>=" & b1 & " and tb_x825p_m387e<=" & b2 & " and tb_x825p_sykczl>=" & a2)
        GS_useviewbydb2(ListView3, dt1, 0, 150) '下至中
        dt1 = GF_czmctb(dt, "tb_x825p_m387e>=" & b1 & " and tb_x825p_m387e<=" & b2 & "  and tb_x825p_sykczl<" & a2)
        GS_useviewbydb2(ListView4, dt1, 0, 150) '中至上
        Dim dt2 As DataTable = dt1.Clone
        GS_useviewbydb2(ListView6, dt2, 0, 150) '混合表

        ListView6.Columns.Insert(4, "可生产精炼批数", 150)
        ListView6.Columns.Insert(5, "单批重量", 150)
        ListView6.Columns.Insert(6, "计划含量", 150)
    End Sub
    '1/2/3双击选入组合表
    Private Sub ListViewk_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick, ListView2.MouseDoubleClick, ListView3.MouseDoubleClick, ListView4.MouseDoubleClick
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
            ''''''''
            Select Case ComboBox1.SelectedIndex
                Case 0 '1号公式,直接选取
                    Call gs11()
                Case 1 '2号公式,零头混配
                    Call gs12()
                Case 2 '3号公式,高低混配
                    Call gs13()
            End Select

        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView6.Items.Clear()
        GroupBox6.Text = "组合"
        If ComboBox1.SelectedIndex = 0 Then
            ListView1.Enabled = False : ListView2.Enabled = False : ListView4.Enabled = False : ListView3.Enabled = True
            Label2.Visible = False : Label3.Visible = False : Chentextzs4.Visible = False : Chentextzs5.Visible = False
        ElseIf ComboBox1.SelectedIndex = 1 Then
            ListView1.Enabled = False : ListView2.Enabled = False : ListView3.Enabled = False : ListView4.Enabled = True
            Label2.Visible = False : Label3.Visible = False : Chentextzs4.Visible = False : Chentextzs5.Visible = False
        ElseIf ComboBox1.SelectedIndex = 2 Then
            ListView3.Enabled = False : ListView4.Enabled = False : ListView1.Enabled = True : ListView2.Enabled = False
            Label2.Visible = True : Label3.Visible = True : Chentextzs4.Visible = True : Chentextzs5.Visible = True
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If GF_storelog1("完成毛油调配") = False Then
            Exit Sub
        End If ' 判断是否有权限
        '’‘’‘’‘’‘’‘’‘’下面可以加入公式判断了
        If ListView6.Items.Count < 1 Then
            MsgBox("必须先查询数据!")
            Exit Sub
        End If
        If MsgBox("确定配料批？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim myjhhl As Double = ListView6.Items(0).SubItems(6).Text '得到计划含量
        Dim ph As String = GF_getnewpath2() '配料批号
        Dim idAll As String = "" '所有选取的毛油ID序列
        For i As Integer = 0 To ListView6.Items.Count - 1
            idAll = idAll & ListView6.Items(i).SubItems(0).Text & ","
        Next
        idAll = GF_removedh(idAll)
        If ComboBox1.SelectedIndex = 2 Then '高低混批
            '''''''''''''''''''
            For i As Integer = 0 To ListView6.Items.Count - 1
                Dim zl0 As Double = ListView6.Items(i).SubItems(5).Text
                Dim kc As Double = ListView6.Items(i).SubItems(2).Text
                If zl0 > kc Then
                    MsgBox("不能大于库存重量，不能混配！") : Exit Sub
                End If
            Next
            '''''''''''''''''''''''
            Dim zl1, zl2 As Double '分别扣除的重量
            zl1 = ListView6.Items(0).SubItems(5).Text
            zl2 = ListView6.Items(1).SubItems(5).Text
            Dim m1 As Double = CDbl(Chentextzs1.Text) / 2
            If zl1 + zl2 <> CDbl(Chentextzs5.Text) Then
                MsgBox("不符合设定的重量" & CDbl(Chentextzs1.Text) & "，不能混配！") : Exit Sub
            End If
            Dim m2 As String = m1 & "," & m1 '精炼的单批重量
            Dim m3 As String = zl1 & "," & zl2 '分别扣除的重量
            ''''''''''''''''''''''''''
            Dim ph1, ph2, myph As String '毛油的批号
            ph1 = ListView6.Items(0).SubItems(1).Text
            ph2 = ListView6.Items(1).SubItems(1).Text
            myph = ph1 & "," & ph2
            '''''''''''''''''''''高低混配明细
            Dim temp1, temp2 As Double, gdhpmx As String
            temp1 = zl1 / 2 : temp2 = zl2 / 2
            Dim dhpmx As String = ph1 & "/" & temp1.ToString & "," & ph2 & "/" & temp2.ToString
            Dim mymxz1 As String = InputBox("填写精炼1批明细？", "提取", dhpmx)
            If mymxz1 = "" Then
                MsgBox("必须填写精炼1批明细!") : Exit Sub
            End If
            Dim mymxz2 As String = InputBox("填写精炼2批明细？", "提取", dhpmx)
            If mymxz2 = "" Then
                MsgBox("必须填写精炼2批明细!") : Exit Sub
            End If
            gdhpmx = mymxz1 & "#" & mymxz2


            ''备注
            Dim bzxx As String = InputBox("输入备注信息！", "备注", " ")
            ''''''''''''''''''''
            Dim Sql As String = "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_sbtb,tb_mypl_sbid,tb_mypl_q569j,tb_mypl_myhl,tb_mypl_czrgh,tb_mypl_bz) values"
            Sql = Sql & "(getdate(),'" & ph & "','" & ph & "','" & myph & "','" & m3 & "'," & Chentextzs1.Text & ",'" & m2 & "',2,'tb_x825p','" & idAll & "','" & gdhpmx & "'," & myjhhl & ",'" & G_dlrgh & "','" & bzxx & "')"
            Dim xbid As String = GF_upztxx2(G_cnnstr, Sql, "tb_mypl")
            ''''''''''''''''''''''''''''''''''''''''
            Sql = "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & zl1 & " where tb_x825p_id =" & ListView6.Items(0).SubItems(0).Text
            Sql = Sql & vbCrLf & "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & zl2 & " where tb_x825p_id =" & ListView6.Items(1).SubItems(0).Text
            GS_upztxx(G_cnnstr, Sql)
            gexbb(xbid) '更新毛油表下步字段表
            GS_storelog3("完成毛油高低混批：" & ph, "完成毛油调配") '储存到日志
            '''''''''''''''''''''
        ElseIf ComboBox1.SelectedIndex = 1 Then '零头混配
            '判断每批重量是否符合要求
            Dim dx As String() = ListView6.Items(0).SubItems(5).Text.Split(",")

            If CDbl(dx(0)) + CDbl(dx(1)) < CDbl(Chentextzs1.Text) Then
                MsgBox("重量不足!") : Exit Sub
            End If
            '得到扣除对应的毛油批号的重量序列,毛油明细
            Dim dymyzl As String = "" : Dim mymxxl As String = "" : Dim myph As String = "" : Dim zl As Double = 0
            For i As Integer = 0 To ListView6.Items.Count - 1
                dymyzl = dymyzl & ListView6.Items(i).SubItems(2).Text & ","
                mymxxl = mymxxl & ListView6.Items(i).SubItems(1).Text & "/" & ListView6.Items(i).SubItems(2).Text & ","
                myph = myph & ListView6.Items(i).SubItems(1).Text & ","
                zl = zl + ListView6.Items(i).SubItems(3).Text
            Next
            dymyzl = GF_removedh(dymyzl) : myph = GF_removedh(myph)
            Dim mymxz1 As String = InputBox("填写精炼1批明细？", "提取", mymxxl)
            If mymxz1 = "" Then
                MsgBox("必须填写精炼1批明细!") : Exit Sub
            End If
            Dim mymxz2 As String = InputBox("填写精炼2批明细？", "提取", mymxxl)
            If mymxz2 = "" Then
                MsgBox("必须填写精炼2批明细!") : Exit Sub
            End If
            Dim gdhpmx As String = mymxz1 & "#" & mymxz2
            '''''
            Dim bzxx As String = InputBox("输入备注信息！", "备注")
            ''''''''''''''''''''''
            Dim sql As String = "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_sbtb,tb_mypl_sbid,tb_mypl_q569j,tb_mypl_myhl,tb_mypl_czrgh,tb_mypl_bz) values"
            sql = sql & "(getdate(),'" & ph & "','" & ph & "','" & myph & "','" & dymyzl & "'," & zl & ",'" & ListView6.Items(0).SubItems(5).Text & "',2,'tb_x825p','" & idAll & "','" & gdhpmx & "'," & myjhhl & ",'" & G_dlrgh & "','" & bzxx & "')"
            Dim xbid As String = GF_upztxx2(G_cnnstr, sql, "tb_mypl")
            '插入记录到配料
            sql = "update tb_x825p set tb_x825p_sykczl=0 where tb_x825p_ID in(" & idAll & ")"
            GS_upztxx(G_cnnstr, sql)
            gexbb(xbid) '更新毛油表下步字段表
            GS_storelog3("完成毛油零头混配：" & ph, "完成毛油调配") '储存到日志
        ElseIf ComboBox1.SelectedIndex = 0 Then '直接选取
            '得到扣除对应的毛油批号的重量序列,毛油明细
            Dim dpzlxl As String = ListView6.Items(0).SubItems(5).Text
            Dim dx As String() = dpzlxl.Split(",")
            Dim kczl As Double = CDbl(dx(0)) + CDbl(dx(1)) '得到毛油实际扣除重量
            Dim jlpzlxl As String = dx(0) & "," & dx(1) '精炼皮重量
            Dim gdhpmx As String = ListView6.Items(0).SubItems(1).Text & "/" & dx(0) & "#" & ListView6.Items(0).SubItems(1).Text & "/" & dx(1)


            Dim bzxx As String = InputBox("输入备注信息！", "备注")
            ''''''''''''''''''''''
            Dim sql As String = "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_sbtb,tb_mypl_sbid,tb_mypl_q569j,tb_mypl_myhl,tb_mypl_czrgh,tb_mypl_bz) values"
            sql = sql & "(getdate(),'" & ph & "','" & ph & "','" & ListView6.Items(0).SubItems(1).Text & "','" & kczl & "'," & kczl & ",'" & jlpzlxl & "',2,'tb_x825p','" & idAll & "','" & gdhpmx & "'," & myjhhl & ",'" & G_dlrgh & "','" & bzxx & "')"
            Dim xbid As String = GF_upztxx2(G_cnnstr, sql, "tb_mypl")
            '插入记录到配料
            sql = "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & kczl & " where tb_x825p_ID in(" & idAll & ")"
            GS_upztxx(G_cnnstr, sql)
            gexbb(xbid) '更新毛油表下步字段表
            GS_storelog3("完成毛油直接选取：" & ph, "完成毛油调配") '储存到日志
        End If
        MsgBox("混配成功") : Me.Close()
    End Sub

    Private Sub ListView6_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView6.MouseDoubleClick
        If ListView6.SelectedItems.Count < 1 Then
            Exit Sub
        End If
        ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
        Select Case ComboBox1.SelectedIndex
            Case 0 '1号公式,直接选取
                Call gs11()
            Case 1 '2号公式,零头混配
                Call gs12()
            Case 2 '3号公式,高低混配
                Call gs13()
        End Select
    End Sub

    Private Sub gs11()  '直接选取的公式
        If ListView6.Items.Count = 2 Then
            MsgBox("已经有一条数据了")
            ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
            Exit Sub
        End If
        Dim zll As Double = 0
        '重量累加 
        For i As Integer = 0 To ListView6.Items.Count - 1
            zll = zll + ListView6.Items(i).SubItems(2).Text
        Next
        If zll - Chentextzs2.Text > 0 Then '第一种情况，重量大于上限
            zll = Chentextzs2.Text
        End If
        Dim zl1 As Integer = 0
        zl1 = CInt(zll / 10) * 5
        Dim zl2 As Integer = 0
        zl2 = zll - zl1
        insertzlps(2, zl1.ToString() & "," & zl2.ToString()) : inserthl() '插入批数、单批重量、计划含量
    End Sub
    Private Sub gs12()  '零头混配的公式
        Dim zll As Double = 0
        '重量累加 
        For i As Integer = 0 To ListView6.Items.Count - 1
            zll = zll + ListView6.Items(i).SubItems(2).Text
        Next
        If zll - Chentextzs2.Text >= 0 Then
            MsgBox("超过了指定重量")
            ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
            Exit Sub
        End If
        If zll - Chentextzs1.Text >= 0 And zll - Chentextzs2.Text <= 0 Then
            MsgBox("达到了指定重量")
        End If
        Dim A1 As Double = Int(zll / 10) * 5 '单批重量1=总重量减去设定AA重量下限
        Dim A2 As Double = zll - A1 '单批重量2=设定AA重量下限
        Dim dpzl1 As String = A1.ToString() & "," & A2.ToString()
        insertzlps(2, dpzl1) : inserthl() '插入批数、单批重量、计划含量
    End Sub

    Private Sub gs13()  '高低混配的公式
        If ListView6.Items.Count > 2 Then
            MsgBox("超过了指定记录数量!")
            ListView6.Items.RemoveAt(ListView6.Items.Count - 1)
            Exit Sub
        End If
        If ListView6.Items.Count = 0 Then
            ListView1.Enabled = True
            ListView2.Enabled = False
        End If

        If ListView6.Items.Count = 1 Then
            ListView1.Enabled = False
            ListView2.Enabled = True
        End If
        If ListView6.Items.Count = 2 Then
            Dim ckz1 As Integer = expression1()
            Dim ckz2 As Integer = Chentextzs5.Text.Trim - ckz1
            insertzlps(2, "")
            Dim ts1, ts2 As Double
            ts1 = ListView6.Items(0).SubItems(3).Text
            ts2 = ListView6.Items(1).SubItems(3).Text
            If ts1 > ts2 Then
                ListView6.Items(0).SubItems(5).Text = ckz1
                ListView6.Items(1).SubItems(5).Text = ckz2
            Else
                ListView6.Items(0).SubItems(5).Text = ckz2
                ListView6.Items(1).SubItems(5).Text = ckz1
            End If
            ts2 = Chentextzs5.Text - ts1
            '''''''''''''''''''

            ''''''''''''
            'ListView6ListView6.Items(0).SubItems(5).Text = ts2
            '  .Items(1).SubItems(5).Text = ts1
            inserthl()
            Exit Sub
            '''''''''''''''''
        End If
    End Sub
    Private Function expression1() As Integer '公式3,结果得到批次
        Dim a As Double = Chentextzs4.Text.Trim
        Dim d As Double = Chentextzs5.Text.Trim

        Dim hl1, hl2 As Double
        hl1 = ListView6.Items(0).SubItems(3).Text '含量1
        hl2 = ListView6.Items(1).SubItems(3).Text '含量2
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
        Dim ddz As Double

        If xp1 < xp2 Then
            ddz = xp2

        Else
            ddz = xp1
        End If


        GroupBox6.Text = "组合参考值重量：" & xp1 & "," & xp2
        expression1 = ddz
    End Function
    Private Sub gexbb(ByVal xbid As String)
        For i As Integer = 0 To ListView6.Items.Count - 1
            GS_gengsb("tb_x825p", ListView6.Items(i).SubItems(0).Text, "tb_mypl", xbid)
        Next
    End Sub
    Private Sub insertzlps(ByVal str1 As Integer, ByVal str2 As String) '本功能插入单批数与单批重量
        For i As Integer = 0 To ListView6.Items.Count - 1
            Dim si As New ListViewItem.ListViewSubItem(ListView6.Items(i), str1)
            ListView6.Items(i).SubItems.Insert(4, si)
            Dim si2 As New ListViewItem.ListViewSubItem(ListView6.Items(i), str2)
            ListView6.Items(i).SubItems.Insert(5, si2)
        Next
    End Sub
    Private Sub inserthl() '本功能实现计划含量
        Dim zz1, zz2 As Double
        zz1 = 0 : zz2 = 0
        For j As Integer = 0 To ListView6.Items.Count - 1
            Dim m1 As Double = ListView6.Items(j).SubItems(2).Text
            Dim z1 As Double = ListView6.Items(j).SubItems(3).Text
            zz1 = zz1 + m1 * z1
            zz2 = zz2 + m1
            Dim si As New ListViewItem.ListViewSubItem(ListView6.Items(j), ListView6.Items(j).SubItems(3).Text)
            ListView6.Items(j).SubItems.Insert(6, si)
        Next
        Dim jhhl As Double = 0
        Try
            jhhl = zz1 / zz2
        Catch ex As Exception

        End Try
        If ComboBox1.SelectedIndex = 2 Then '高低混配的时候参考含量就是计划含量
            jhhl = Chentextzs4.Text
        Else
            jhhl = CInt(jhhl * 100) / 100 '保留2位小数四舍五入
        End If
        For j As Integer = 0 To ListView6.Items.Count - 1
            Dim si As New ListViewItem.ListViewSubItem(ListView6.Items(j), jhhl)
            ListView6.Items(j).SubItems.Insert(6, si)
        Next
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class