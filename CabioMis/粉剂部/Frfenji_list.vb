Public Class Frfenji_list
    Private bm As String
    Private namepp As String = Nothing
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub Frfenji_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("粉剂部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        GF_OpenFaceList2(tsMenu) '切换菜单与关闭菜单的加载
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
    End Sub

    Private Sub Frfenji_list_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        weizhi()
    End Sub

    Private Sub weizhi()
        GroupBox3.Width = Me.Width - GroupBox1.Left - 20
        GroupBox1.Top = GroupBox3.Bottom + 10
        GroupBox1.Height = Me.Height - GroupBox1.Top - 40
        GroupBox1.Width = Me.Width - GroupBox1.Left - 20
        ListView1.Width = GroupBox1.Width - 10
        ListView1.Height = GroupBox1.Height - 60
    End Sub

    Private Sub showsj()
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        ListView2.CheckBoxes = False

        GS_FaceSearch(ComboBoxserchtext, bm, 1) '文本查询函数：关联表的文本字段的显示
        Dim lastYearStr As String = Date.Now.AddYears(-1).ToString("yy")
        Dim yearStr As String = Date.Now.ToString("yy")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim boBox As Boolean = False
        Dim sql As String = ""
        Dim sql1 As String = ""
        Select Case namepp

            Case "1号塔粉剂配料批"
                sql = "select tb_n441f_ID,tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_num,tb_n441f_aaph,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_m397e,tb_n441f_z884r,tb_n441f_a918s,tb_n441f_g154y,tb_n441f_d61v,tb_n441f_g180y,tb_n441f_a943s,tb_n441f_h209z,tb_n441f_e88w,tb_n441f_d66v,tb_n441f_v734n,tb_n441f_t685m,tb_n441f_i245a,tb_n441f_i245at,tb_n441f_j291b,tb_n441f_q535i,tb_n441f_m382e,tb_n441f_y875r,tb_n441f_y875rt,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_dpmx,tb_n441f_xbtb,tb_n441f_glid,tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_czrgh from tb_n441f where tb_n441f_num is null and tb_n441f_m382e='1号塔'"


            Case "34号塔粉剂配料批"

                sql = "select tb_n441f_ID,tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_num,tb_n441f_aaph,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_m397e,tb_n441f_z884r,tb_n441f_a918s,tb_n441f_g154y,tb_n441f_d61v,tb_n441f_g180y,tb_n441f_a943s,tb_n441f_h209z,tb_n441f_e88w,tb_n441f_d66v,tb_n441f_v734n,tb_n441f_t685m,tb_n441f_i245a,tb_n441f_i245at,tb_n441f_j291b,tb_n441f_q535i,tb_n441f_m382e,tb_n441f_y875r,tb_n441f_y875rt,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_dpmx,tb_n441f_xbtb,tb_n441f_glid,tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_czrgh from tb_n441f where tb_n441f_num is null and tb_n441f_m382e='34号塔'"


            Case "5号塔粉剂配料批"
                sql = "select tb_n441f_ID,tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_num,tb_n441f_aaph,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_m397e,tb_n441f_z884r,tb_n441f_a918s,tb_n441f_g154y,tb_n441f_d61v,tb_n441f_g180y,tb_n441f_a943s,tb_n441f_h209z,tb_n441f_e88w,tb_n441f_d66v,tb_n441f_v734n,tb_n441f_t685m,tb_n441f_i245a,tb_n441f_i245at,tb_n441f_j291b,tb_n441f_q535i,tb_n441f_m382e,tb_n441f_y875r,tb_n441f_y875rt,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_dpmx,tb_n441f_xbtb,tb_n441f_glid,tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_czrgh from tb_n441f where tb_n441f_num is null and tb_n441f_m382e='5号塔'"

                '''''''''''''''''''''''''''''''''''''''
                'Case "1号塔喷雾前"
                '    sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n from tb_p525h where tb_p525h_sbid is not null  and tb_p525h_glid is  null and  tb_p525h_th='1号塔' "
         
            Case "1号塔成品粉"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n from tb_p525h where tb_p525h_sbid is not null  and tb_p525h_glid is  null  and tb_p525h_th='1号塔'"

                'Case "34号塔喷雾前" '喷雾时间为空
                '    sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_th,tb_p525h_bz,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n from tb_p525h where tb_p525h_sbid is not null  and tb_p525h_glid is  null  and tb_p525h_th in('3号塔','4号塔') and tb_p525h_jgrq is null "
        
            Case "普粉成品粉"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n from tb_p525h where  tb_p525h_sbid is not null  and tb_p525h_glid is  null and   (left(tb_p525h_num2,6)='M" + lastYearStr + "-34' or left(tb_p525h_num2,6)='M" + yearStr + "-34' )"
                boBox = True
                '''''''''''''''''''''''''''''''''''''''
            Case "优粉喷雾前" '乳糖重量为空
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_th,tb_p525h_bz,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_sbid from tb_p525h where  tb_p525h_sbid is not null  and tb_p525h_glid is null  and tb_p525h_rtpht is null and tb_p525h_rtzl is null  and  ( left(tb_p525h_num2,5)='M" + lastYearStr + "-5' or left(tb_p525h_num2,5)='M" + yearStr + "-5' ) "
                boBox = True
            Case "优粉成品粉" '乳糖重量不为空
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_rtph,tb_p525h_rtpht,tb_p525h_rtzl,tb_p525h_sbid from tb_p525h where  tb_p525h_sbid is not null and tb_p525h_glid is  null and tb_p525h_rtzl is not null and  ( left(tb_p525h_num2,5)='M" + lastYearStr + "-5' or left(tb_p525h_num2,5)='M" + yearStr + "-5') "
                boBox = True
            Case "成品粉零头"
                sql = "select tb_cpflt_ID,tb_cpflt_num,tb_cpflt_lt,tb_cpflt_czrgh from tb_cpflt where tb_cpflt_xbtb is null and tb_cpflt_glid is null "

            Case "成品粉"
                sql = "select tb_x832p_ID,tb_x832p_num,tb__x832p_cplb,tb__x832p_mingc,tb__x832p_jiagdm,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_z886r,tb_x832p_a920s,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_h199z,tb_x832p_d65v from vw_x832p"
            Case Else
                Return
        End Select

        Dim menu1 As ContextMenuStrip = Nothing
        If boBox Then
            menu1 = New ContextMenuStrip
            menu1.Items.Add("查看明细")
            AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
            Select Case namepp
                Case "普粉成品粉"
                    menu1.Items.Add("生成大批")
                    AddHandler menu1.Items(1).Click, AddressOf subMakeDp
                Case "优粉成品粉"
                    menu1.Items.Add("生成大批")
                    AddHandler menu1.Items(1).Click, AddressOf subMakeDp
                Case "优粉喷雾前"
                    menu1.Items.Add("喷雾")
                    AddHandler menu1.Items(1).Click, AddressOf subPw
            End Select
            AddHandler menu1.Paint, Sub(sender As ContextMenuStrip, e As System.EventArgs)
                                        Try
                                            '只有勾选了，操作才可以用
                                            If ListView2.CheckedItems.Count = 0 Then
                                                sender.Items(1).Enabled = False
                                            Else
                                                sender.Items(1).Enabled = True
                                            End If
                                        Catch ex As Exception
                                        End Try
                                    End Sub
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        'GS_useviewbydb2(ListView2, dt, -1, 100)
        GS_useviewbydb2(ListView2, dt, -1, 100, boBox, menu1)
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub
    '生成大批（通过小批）
    Sub subMakeDp()
        Dim Allid As String = ""
        Dim Allph As String = ""
        If ListView2.CheckedItems.Count > 0 Then
            For i As Integer = 0 To ListView2.CheckedItems.Count - 1
                Allid &= GF_GetListText(ListView2, "tb_p525h_ID", i, 1) & ","

                Allph &= GF_GetListText(ListView2, "tb_p525h_num", i, 1) & ","
            Next

            Allid = GF_removedh(Allid)
            Allph = GF_removedh(Allph)

            If MsgBox("您选择的小批是：" & Allph, MsgBoxStyle.OkCancel) = vbCancel Then
                Return
            End If
        End If


        Dim nfrom As New Frtb_x832p

        nfrom.Labelid2.Text = Allid
        nfrom.Labeltb2.Text = "tb_p525h"
        nfrom.Labeltb.Text = "tb_x832p"
        nfrom.Labelid.Text = ""

        nfrom.tb_x832p_th.Text = namepp
        nfrom.tb_x832p_sbid.Text = Allid
        nfrom.tb_x832p_sbtb.Text = IIf(Allid = "", "tb_x832pkc", "tb_p525h")
        nfrom.tb_x832p_num2.Text = Allph

        nfrom.tb_x832p_cplb.Text = GF_GetListText(ListView2, "tb_p525h_cplb", 0, 1) '产品类型
        nfrom.tb_x832p_mingc.Text = GF_GetListText(ListView2, "tb_p525h_mingc", 0, 1) '产品代码
        nfrom.tb_x832p_jiagdm.Text = GF_GetListText(ListView2, "tb_p525h_jiagdm", 0, 1) '加工代码

        If namepp = "优粉成品粉" Then
            '5KG粉剂铝箔袋（批号，重量，批号文本，重量文本）
            nfrom.tb_x832p_ybdph.Visible = False
            nfrom.tb_x832p_ybdpht.Visible = False
            nfrom.Label14.Visible = False
            nfrom.Label17.Visible = False
        ElseIf namepp = "普粉成品粉" Then
            '优粉铝箔袋隐藏（批号，重量，批号文本，重量文本）
            nfrom.tb_x832p_yjlbdph.Visible = False
            nfrom.tb_x832p_yjlbdpht.Visible = False
            nfrom.Label19.Visible = False
            nfrom.Label20.Visible = False
            '包装机卷膜（批号，重量，批号文本，重量文本）
            nfrom.tb_x832p_bzjjm.Visible = False
            nfrom.tb_x832p_bzjjmt.Visible = False
            nfrom.Label25.Visible = False
            nfrom.Label24.Visible = False
        End If
        nfrom.ngthm = namepp
        nfrom.ShowDialog()
        showsj()
    End Sub
    '生成大批
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        subMakeDp()
    End Sub
    '喷雾
    Private Sub subPw()
        If ListView2.CheckedItems.Count < 1 Then
            Exit Sub
        End If

        Dim idAll As String = "" : Dim ph As String = ""
        For i As Integer = 0 To ListView2.CheckedItems.Count - 1
            idAll &= ListView2.CheckedItems(i).SubItems(0).Text & ","
            ph &= ListView2.CheckedItems(i).SubItems(2).Text & ","
        Next
        idAll = GF_removedh(idAll) : ph = GF_removedh(ph)


        Dim th As String = GF_GetListText(ListView2, "tb_p525h_th", 0, 1)  '塔号 

        'If th = "5号塔" Then
        Dim sql As String

        '小批
        Dim num2 As String = GF_GetListText(ListView2, "tb_p525h_num2", 0, 1)  '配料批批号
        Dim num As String = GF_GetListText(ListView2, "tb_p525h_num", 0, 1)  '配料小批号
        Dim p525hsbid As String = GF_GetListText(ListView2, "tb_p525h_sbid", 0, 1) '小批上步ID
        Dim p525hid As String = GF_GetListText(ListView2, "tb_p525h_ID", 0, 1) '小批ID

        '配料批
        sql = "select tb_n441f_num2 ,tb_n441f_aaph,tb_n441f_sbid from tb_n441f where tb_n441f_id = '" & p525hsbid & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim aaph As String = "" 'AA油批号
        Dim pldh As String = "" '配料单号
        Dim n441fsbid As String = "" '配料批上步ID
        If dt.Rows.Count > 0 Then
            aaph = dt.Rows(0)("tb_n441f_aaph") 'AA油批号
            pldh = dt.Rows(0)("tb_n441f_num2") '配料单号
            n441fsbid = dt.Rows(0)("tb_n441f_sbid") '配料批上步ID
        End If

        ''''粉剂配料
        sql = "select  tb_x823p_id,tb_x823p_sbid ,tb_x823p_kczl,tb_x823p_t678l from tb_x823p where tb_x823p_id = '" & n441fsbid & "'  "
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim x823pid As String = dt2.Rows(0)("tb_x823p_id") '粉剂配料ID
        Dim x823psbid As String = dt2.Rows(0)("tb_x823p_sbid") '粉剂配料上步ID
        Dim x823pkczl As String = dt2.Rows(0)("tb_x823p_kczl") '数组 粉剂配料扣除重量
        Dim x823pt678l As String = dt2.Rows(0)("tb_x823p_t678l") 'AA油重量
        Dim nform As New Fr_fiveqq
        nform.Label2.Text = idAll
        nform.sbid.Text = x823psbid '粉剂配料上步ID
        nform.Label11.Text = x823pid '粉剂配料ID
        nform.TextBox2.Text = num2  '配料批批号
        nform.Label13.Text = p525hid '配料小批ID
        nform.TextBox3.Text = num '配料小批号
        nform.TextBox1.Text = x823pkczl '数组 粉剂配料扣除重量
        nform.TextBox5.Text = x823pt678l 'AA油重量

        nform.xpph = ph
        nform.ph1.Text = pldh
        nform.aaph.Text = aaph

        nform.ShowDialog()

        'Else
        'Dim nform As New Fr_qq
        'nform.Label2.Text = idAll
        'nform.xpph = ph
        'nform.ShowDialog()
        'End If
        showsj()
    End Sub


    Private Sub yipwhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        namepp = "1号塔喷雾后"
        bm = "tb_p525h"
        Button2.Visible = False
        'Button5.Visible = True
        ListView2.CheckBoxes = True
        showsj()
    End Sub


    Private Sub sanpwhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        namepp = "34号塔喷雾后"
        bm = "tb_p525h"
        Button2.Visible = False
        'Button5.Visible = True
        ListView2.CheckBoxes = True
        showsj()
    End Sub

    '成品粉零头
    'Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
    '    namepp = "成品粉零头"
    '    Button2.Visible = True
    '    Button4.Visible = False
    '    'Button5.Visible = False
    '    ListView2.CheckBoxes = True
    '    showsj()
    'End Sub
    '成品粉混批,移到运行部了
    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    '    Dim nform As New Frtb_x832p2
    '    namepp = "成品粉"
    '    nform.ShowDialog()
    'End Sub


    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        '验证锁定
        If GF_MakeIsSD("tb_n441f", ListView2.SelectedItems(0).SubItems(0).Text) = False Then
            Exit Sub
        End If
        If namepp = "1号塔粉剂配料批" Or namepp = "34号塔粉剂配料批" Then
            'TODO: 粉剂加原料
            Dim nfrom As New Frtb_x823p
            Dim id As String = Null2String(GF_GetListText(ListView2, "tb_n441f_ID", 0, 2)) '配料id
            Dim mingc As String = Null2String(GF_GetListText(ListView2, "tb_n441f_mingc", 0, 2)) '
            Dim jiagdm As String = Null2String(GF_GetListText(ListView2, "tb_n441f_jiagdm", 0, 2)) '
            Dim cplb As String = Null2String(GF_GetListText(ListView2, "tb_n441f_cplb", 0, 2)) '
            Dim tmpSql = "select tb_x823p_rt,tb_x823p_rqdbf,tb_x823p_pttj,tb_x823p_llz from tb_x823p where tb_x823p_id in (Select tb_n441f_sbid from tb_n441f where tb_n441f_ID = " & id & ")"

            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, tmpSql)
            If dt.Rows.Count > 0 Then
                Dim rtt As String = dt.Rows(0)(0).ToString()
                Dim rqdbft As String = dt.Rows(0)(1).ToString()
                Dim pttjt As String = dt.Rows(0)(2).ToString()
                Dim llzt As String = dt.Rows(0)(3).ToString()
                nfrom.tb_n441f_rtt.Text = rtt
                nfrom.tb_n441f_rqdbft.Text = rqdbft
                nfrom.tb_n441f_pttjt.Text = pttjt
                nfrom.tb_n441f_llzt.Text = llzt
            End If


            
            nfrom.tb_n441f_mingc.Text = mingc
            nfrom.tb_n441f_jiagdm.Text = jiagdm
            nfrom.tb_n441f_cplb.Text = cplb


            nfrom.Labelid.Text = id
            nfrom.Labeltb.Text = "tb_n441f"
            Dim num As String = Null2String(GF_GetListText(ListView2, "tb_n441f_num", 0, 2))
            nfrom.Labelph.Text = num '配料批批号
            nfrom.Label3.Text = namepp
            Me.AddOwnedForm(nfrom)
            nfrom.ShowDialog() : showsj()
        ElseIf namepp = "5号塔粉剂配料批" Then

            Dim nfrom As New Frx832p5
            Dim id As String = Null2String(GF_GetListText(ListView2, "tb_n441f_ID", 0, 2)) '配料id
            Dim mingc As String = Null2String(GF_GetListText(ListView2, "tb_n441f_mingc", 0, 2)) '
            Dim jiagdm As String = Null2String(GF_GetListText(ListView2, "tb_n441f_jiagdm", 0, 2)) '
            Dim cplb As String = Null2String(GF_GetListText(ListView2, "tb_n441f_cplb", 0, 2)) '
            nfrom.tb_n441f_mingc.Text = mingc
            nfrom.tb_n441f_jiagdm.Text = jiagdm
            nfrom.tb_n441f_cplb.Text = cplb
            nfrom.Labelid.Text = id
            nfrom.Labeltb.Text = "tb_n441f"
            Dim num As String = Null2String(GF_GetListText(ListView2, "tb_n441f_num", 0, 2))
            nfrom.Labelph.Text = num '配料批批号
            nfrom.Label3.Text = namepp  '塔号
            Me.AddOwnedForm(nfrom)
            nfrom.ShowDialog() : showsj()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Dim lastYearStr As String = Date.Now.AddYears(-1).ToString("yy")
        Dim yearStr As String = Date.Now.ToString("yy")

        Dim Sql As String = Nothing
        Dim cxq As String = Nothing
        '''''''''''''''''''''''''''''''''''''''''''''''
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext) '文本查询函数：挂接到查询文本
        ''''''''''''''''''''''''''''''''''''''''''''
        Select Case namepp
            Case "1号塔粉剂配料批"
                Sql = "select tb_n441f_ID,tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_num,tb_n441f_jgrq,tb_n441f_plksrq,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_aaph,tb_n441f_m397e,tb_n441f_z884r,tb_n441f_a918s,tb_n441f_g154y,tb_n441f_d61v,tb_n441f_g180y,tb_n441f_a943s,tb_n441f_h209z,tb_n441f_e88w,tb_n441f_d66v,tb_n441f_v734n,tb_n441f_t685m,tb_n441f_i245a,tb_n441f_h201z,tb_n441f_j291b,tb_n441f_q535i,tb_n441f_y875r,tb_n441f_u693m,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_m382e,tb_n441f_czrgh,tb_n441f_glid,tb_n441f_m397et,tb_n441f_a918st,tb_n441f_d61vt,tb_n441f_a943st,tb_n441f_e88wt,tb_n441f_v734nt,tb_n441f_i245at,tb_n441f_j291bt,tb_n441f_dpmx,tb_n441f_rt,tb_n441f_rtm,tb_n441f_rtt,tb_n441f_rqdbf,tb_n441f_rqdbfm,tb_n441f_rqdbft ,tb_n441f_pttj,tb_n441f_pttjm,tb_n441f_pttjt,tb_n441f_llz,tb_n441f_llzm,tb_n441f_llzt  from tb_n441f "
                Sql = Sql & " where tb_n441f_m382e='1号塔' and tb_n441f_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " order by tb_n441f_num asc"
                cxq = "查询粉剂配料"
            Case "34号塔粉剂配料批"
                Sql = "select tb_n441f_ID,tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_num,tb_n441f_jgrq,tb_n441f_plksrq,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_aaph,tb_n441f_m397e,tb_n441f_z884r,tb_n441f_a918s,tb_n441f_g154y,tb_n441f_d61v,tb_n441f_g180y,tb_n441f_a943s,tb_n441f_h209z,tb_n441f_e88w,tb_n441f_d66v,tb_n441f_v734n,tb_n441f_t685m,tb_n441f_i245a,tb_n441f_h201z,tb_n441f_j291b,tb_n441f_q535i,tb_n441f_y875r,tb_n441f_u693m,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_m382e,tb_n441f_czrgh,tb_n441f_glid,tb_n441f_m397et,tb_n441f_a918st,tb_n441f_d61vt,tb_n441f_a943st,tb_n441f_e88wt,tb_n441f_v734nt,tb_n441f_i245at,tb_n441f_j291bt,tb_n441f_dpmx,tb_n441f_rt,tb_n441f_rtm,tb_n441f_rtt,tb_n441f_rqdbf,tb_n441f_rqdbfm,tb_n441f_rqdbft ,tb_n441f_pttj,tb_n441f_pttjm,tb_n441f_pttjt,tb_n441f_llz,tb_n441f_llzm,tb_n441f_llzt  from tb_n441f "
                Sql = Sql & " where tb_n441f_m382e='34号塔' and tb_n441f_jgrq between '" & tt1 & "' and '" & tt2 & "' " & sqlbdssep & " order by tb_n441f_num asc"
                cxq = "查询粉剂配料"
            Case "5号塔粉剂配料批"
                Sql = "select tb_n441f_ID,tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_num,tb_n441f_jgrq,tb_n441f_plksrq,tb_n441f_ara,tb_n441f_dpzl,tb_n441f_aaph,tb_n441f_m397e,tb_n441f_z884r,tb_n441f_a918s,tb_n441f_g154y,tb_n441f_d61v,tb_n441f_g180y,tb_n441f_a943s,tb_n441f_h209z,tb_n441f_e88w,tb_n441f_d66v,tb_n441f_v734n,tb_n441f_t685m,tb_n441f_i245a,tb_n441f_h201z,tb_n441f_j291b,tb_n441f_q535i,tb_n441f_y875r,tb_n441f_u693m,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_m382e,tb_n441f_czrgh,tb_n441f_glid,tb_n441f_m397et,tb_n441f_a918st,tb_n441f_d61vt,tb_n441f_a943st,tb_n441f_e88wt,tb_n441f_v734nt,tb_n441f_i245at,tb_n441f_j291bt,tb_n441f_dpmx,tb_n441f_rt,tb_n441f_rtm,tb_n441f_rtt,tb_n441f_rqdbf,tb_n441f_rqdbfm,tb_n441f_rqdbft ,tb_n441f_pttj,tb_n441f_pttjm,tb_n441f_pttjt,tb_n441f_llz,tb_n441f_llzm,tb_n441f_llzt  from tb_n441f "
                Sql = Sql & " where tb_n441f_m382e='5号塔' and tb_n441f_jgrq between '" & tt1 & "' and '" & tt2 & "' " & sqlbdssep & " order by tb_n441f_num asc"
                cxq = "查询粉剂配料"
            Case "1号塔喷雾前"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n ,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm from tb_p525h where  tb_p525h_th='1号塔'"
                Sql = Sql & "  and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "1号塔喷雾后"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm  from tb_p525h where   tb_p525h_th='1号塔'"
                Sql = Sql & "   and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "1号塔成品粉"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n ,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm from tb_p525h where  tb_p525h_th='1号塔'"
                Sql = Sql & "  and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "普粉喷雾前"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm  from tb_p525h where  (left(tb_p525h_num2,6)='M" + lastYearStr + "-34' or left(tb_p525h_num2,6)='M" + yearStr + "-34')  "
                Sql = Sql & "  and  tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "普粉喷雾后"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n ,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm from tb_p525h where  ( left(tb_p525h_num2,6)='M" + lastYearStr + "-34' or left(tb_p525h_num2,6)='M" + yearStr + "-34')  "
                Sql = Sql & "   and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "普粉成品粉"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm  from tb_p525h where   (left(tb_p525h_num2,6)='M" + lastYearStr + "-34' or left(tb_p525h_num2,6)='M" + yearStr + "-34' ) "
                Sql = Sql & "  and  tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "优粉喷雾前"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n ,tb_p525h_qcrq,tb_p525h_rtph,tb_p525h_rtpht,tb_p525h_rtzl,tb_p525h_aaph,tb_p525h_ky,tb_p525h_pldh,tb_p525h_bz,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm from tb_p525h where  ( left(tb_p525h_num2,5)='M" + lastYearStr + "-5' or left(tb_p525h_num2,5)='M" + yearStr + "-5')  "
                Sql = Sql & "  and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "优粉成品粉"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_qcrq,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm  from tb_p525h where  (left(tb_p525h_num2,5)='M" + lastYearStr + "-5' or left(tb_p525h_num2,5)='M" + yearStr + "-5') "
                Sql = Sql & "   and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "5号塔成品粉"
                Sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_cplb,tb_p525h_mingc,tb_p525h_jiagdm,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_czrgh,tb_p525h_c17u,tb_p525h_u721n ,tb_p525h_qcrq ,tb_p525h_aaph,tb_p525h_ky,tb_p525h_pldh,tb_p525h_rqdbf,tb_p525h_rqdbft,tb_p525h_rqdbfm,tb_p525h_llz,tb_p525h_llzt,tb_p525h_llzm from tb_p525h where   (left(tb_p525h_num2,5)='M" + lastYearStr + "-5' or left(tb_p525h_num2,5)='M" + yearStr + "-5') "
                Sql = Sql & "  and tb_p525h_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询小批"
            Case "成品粉"
                Sql = "select tb_x832p_ID,tb_x832p_num,tb_x832p_cplb,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_z886r,tb_x832p_a920s,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_h199z,tb_x832p_d65v,tb_x832p_yjlbdph,tb_x832p_yjlbdpht" &
                    ",tb_x832p_fgfph,tb_x832p_fgfpht from tb_x832p where tb_x832p_jgrq between '" & tt1 & "' and '" & tt2 & "'  " & sqlbdssep & " "
                cxq = "查询成品粉"
        End Select
        If Sql = Nothing Then
            Exit Sub
        End If
        ''''''''''''''''''''
        If GF_storelog2(cxq, cxq) = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        'GS_useviewbydb2(ListView1, dt, 0, 100)
        GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
        GroupBox1.Text = "查询结果：" & GF_getListViewsz(ListView1) & "条记录"
    End Sub



    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, DateTimePicker1.Text & "至" & DateTimePicker2.Text, Me)
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ''''''''''''''''''''
        If GF_storelog2("查询成品粉", "查询成品粉") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim tt1, tt2 As String
        tt1 = _S.YanForDa_1(GF_gettrqsj(DateTimePicker1.Text))
        tt2 = _S.YanForDa_1(GF_gettrqsj(DateTimePicker2.Text))
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        If IsDate(tt1)=False OrElse IsDate(tt2)=False Then
            MsgBox("无法得到正确的日期格式，请检查系统的日期设置！", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim Sql As String = "select tb_x832p_ID,tb_x832p_jgrq as '配料单生成日期',tb_x832p_num,tb_x832p_num2,tb_x832p_cplb,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_lzlt,tb_x832p_ltzl,tb_x832p_bzxs,tb_x832p_bz,tb_x832p_h199z,tb_x832p_d65v,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_ybdph,tb_x832p_ybdzl,tb_x832p_ybdpht,tb_x832p_ypybdph,tb_x832p_ypybdzl,tb_x832p_ypybdpht,tb_x832p_yjlbdph,tb_x832p_yjlbdzl,tb_x832p_yjlbdpht,tb_x832p_pwkssj,tb_x832p_pwjssj,tb_x832p_bzjjm,tb_x832p_bzjjmt,tb_x832p_bzjjmzl " &
            ",tb_x832p_fgfph,tb_x832p_fgfpht from tb_x832p where tb_x832p_jgrq between '" & tt1 & "' and '" & tt2 & "' "

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        'GS_useviewbydb2(ListView1, dt, 0, 100)
        GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
        GroupBox1.Text = "查询结果：" & GF_getListViewsz(ListView1) & "条记录"
        namepp = "成品粉"
        bm = "tb_x832p"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, bm, 1) '文本查询函数：关联表的文本字段的显示
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    '成品粉混批
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim nform As New Frcpfhp
        namepp = "成品粉"
        bm = "tb_x832p"
        nform.ShowDialog()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("粉剂部")
    End Sub



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim nform As New Frfscylsy
        'nform.frname = Me.Text
        nform.frname = "粉剂生产部"
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If GF_storelog2("查询粉剂配料调配", "查询粉剂配料调配") = False Then
            Exit Sub
        End If
        Dim nform As New Frpljhcx
        nform.ComboBox1.Text = "粉剂配料计划"
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Dim nform As New Frxgfjnbd
        nform.ShowDialog()
    End Sub

    '手工粉剂调配
    Private Sub ToolStripMenuItemSGFJTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSGFJTP.Click
        Dim nform As New Frsgfjtp
        nform.ShowDialog()
    End Sub

    '粉剂配料批1号塔

    Private Sub TA1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TA1.Click
        namepp = "1号塔粉剂配料批"
        bm = "tb_n441f"
        Button2.Visible = False
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "粉剂配料批(1号塔)"
        showsj()
    End Sub

    '粉剂小批1号塔（喷雾前）

    Private Sub yipwqToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        namepp = "1号塔喷雾前"
        bm = "tb_p525h"
        Button2.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "粉剂小批1号塔（喷雾前）"
        showsj()
    End Sub

    '粉剂小批1号塔（喷雾后）

    Private Sub dsc1MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dsc1MenuItem1.Click
        namepp = "1号塔成品粉"
        bm = "tb_p525h"
        Button2.Visible = True
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "粉剂小批1号塔（喷雾后）"
        showsj()
    End Sub


    '粉剂配料批34号塔

    Private Sub TA34_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TA34.Click
        namepp = "34号塔粉剂配料批"
        bm = "tb_n441f"
        Button2.Visible = False
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "粉剂配料批(普粉)"
        showsj()
    End Sub

    '粉剂小批34号塔（喷雾前）

    'Private Sub sanpwqToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sanpwqToolStripMenuItem.Click
    '    namepp = "34号塔喷雾前"
    '    bm = "tb_p525h"
    '    Button2.Visible = False
    '    Button4.Visible = True
    '    'Button5.Visible = False
    '    ListView2.CheckBoxes = True
    '    GroupBox3.Text = "粉剂小批34号塔（喷雾前）"
    '    showsj()
    'End Sub

    '粉剂小批34号塔（喷雾后）

    Private Sub dsc34MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dsc34MenuItem.Click
        namepp = "普粉成品粉"
        bm = "tb_p525h"
        Button2.Visible = True
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "普粉粉剂小批（喷雾后）"
        showsj()
    End Sub

    '粉剂配料批5号塔

    Private Sub TA5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TA5.Click
        namepp = "5号塔粉剂配料批"
        bm = "tb_n441f"
        Button2.Visible = False
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "粉剂配料批(优粉）"
        showsj()
    End Sub

    '粉剂小批5号塔（喷雾前）

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        namepp = "优粉喷雾前"
        bm = "tb_p525h"
        Button2.Visible = False
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "优粉粉剂小批（喷雾前）"
        showsj()
    End Sub

    '粉剂小批5号塔粉（喷雾后）
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        namepp = "优粉成品粉"
        bm = "tb_p525h"
        Button2.Visible = True
        'Button5.Visible = False
        ListView2.CheckBoxes = True
        GroupBox3.Text = "优粉粉剂小批（喷雾后）"

        'RemoveHandler ListView2.ItemCheck, AddressOf lv2Check
        'AddHandler ListView2.ItemCheck, AddressOf lv2Check
        showsj()
    End Sub

    Private Sub ToolStripMenuTP1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuTP1.Click
        If GF_storelog2("进行粉剂配料调配", "进行粉剂配料调配") = False Then
            Exit Sub
        End If
        Dim nform As New Frtb_one
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItemTP2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemTP2.Click
        If GF_storelog2("进行粉剂配料调配", "进行粉剂配料调配") = False Then
            Exit Sub
        End If
        Dim nform As New Frtb_ss
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If GF_storelog2("进行粉剂配料调配", "进行粉剂配料调配") = False Then
            Exit Sub
        End If
        Dim nform As New Frtb_five
        nform.ShowDialog()
    End Sub
    Private Sub 小批扣油明细ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 小批扣油明细ToolStripMenuItem.Click
        Dim aa As New Frtb_FiveBuckleOil
        aa.ShowDialog()
    End Sub

    Private Sub ComboBoxserchtext_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxserchtext.SelectedIndexChanged

    End Sub

    Private Sub TextBoxserchtext_TextChanged(sender As Object, e As EventArgs) Handles TextBoxserchtext.TextChanged

    End Sub
End Class