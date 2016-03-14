Public Class Fryllist
    Private ylbdb As DataTable '原料表查询结果供导出EXCEL使用

    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub

    Private Sub Fryllist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("运行部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        GF_OpenFaceList2(tsMenu) '切换菜单与关闭菜单的加载
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
        GroupBox1.Text = "原料"
        'showsj()

    End Sub
    Private Sub weizhi()
        ListView1.Width = GroupBox1.Width - 10
        ListView1.Height = GroupBox1.Height - ListView1.Top - 10
    End Sub
    Private Sub ButtonEnable(ByVal str As Integer) '按钮的有无效
        If str = 1 Then
            GS_toenable("Button4,Button5", False, GroupBox1)
        Else

            GS_toenable("Button4,Button5", True, GroupBox1)
        End If
    End Sub
    Private Sub Fryllist_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        weizhi()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New Fryl
        nform.tb_i259b_r596j.Text = GroupBox1.Text
        nform.ShowDialog()
        'showsj()
    End Sub
    
    Private Sub showsj2(ByVal str As String, ByVal th As String) '配料显示
        Dim sql As String = ""
        sql = "select tb_x823p_ID,tb_x823p_jgrq,tb_x823p_cplb,tb_x823p_mingc,tb_x823p_jiagdm,tb_x823p_num,tb_x823p_num2,tb_x823p_kczl,"
        sql = sql & "tb_x823p_t678l,tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_jhhl,tb_x823p_ckdb,tb_x823p_wcyp,tb_x823p_dpmx,tb_x823p_sbid from tb_x823p"
        sql = sql & " where tb_x823p_ckdb='未完成'and  tb_x823p_th like'%" & th & "%' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt, -1, 0)
        ListView1.CheckBoxes = True
        GroupBox1.Text = str
        'ButtonEnable(2)
    End Sub
    '毛油配料计划
    Private Sub showsj2(ByVal str As String)
        Dim sql As String = ""
        sql = "select tb_mypl_ID,tb_mypl_jiagdm,tb_mypl_mingc,tb_mypl_a953t,tb_mypl_i225a,tb_mypl_cplb,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_ckdb,tb_mypl_q569j,tb_mypl_myhl from tb_mypl"
        sql = sql & " where tb_mypl_ckdb='未完成'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt, -1, 0)
        ListView1.CheckBoxes = True
        GroupBox1.Text = str
        'ButtonEnable(2)
    End Sub


    '34号塔配料单的取消
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ListView1.CheckedItems.Count = 0 Then
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
        If GF_storelog1("作废" & GroupBox1.Text) = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''
        Dim dResult As DialogResult = MessageBox.Show("是否确定作废该计划？", "系统提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
        Dim bz As String = ""
        If dResult <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        Else
            bz = InputBox("请输入作废原因！", "系统提示：")
            If bz = "" Then
                MsgBox("未填写作废原因！")
                Exit Sub
            End If
        End If

        Dim biao As String = "tb_h195zkc"
        Dim biao2 As String = "tb_x823p"
        Dim biaozd As String = "tb_h195zkc_num"
        Dim biaoid As String = "tb_h195zkc_id"
        If GroupBox1.Text = "毛油配料执行" Then
            biao = "tb_x825pkc" : biaozd = "tb_x825pkc_num" : biao2 = "tb_x825ppl" : biaoid = "tb_x825pkc_id"
        End If
        Dim id1 As String = ""
        Dim sql As String = ""
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            id1 = id1 & ListView1.CheckedItems(i).SubItems(0).Text & ","
            Dim ph1, zl1, idsb As String
            idsb = GF_GetListText(ListView1, "tb_x823p_sbid", i, 1)
            ph1 = GF_GetListText(ListView1, "tb_x823p_num2", i, 1) '批号序列
            zl1 = GF_GetListText(ListView1, "tb_x823p_kczl", i, 1) '扣除的重量序列
            Dim phsz() As String = Split(ph1, ",") : Dim zlsz() As String = Split(zl1, ",") : Dim sbid() As String = Split(idsb, ",")
            For j As Integer = 0 To UBound(phsz)
                sql = "update " & biao & " set " & biao & "_sykczl=" & biao & "_sykczl+" & zlsz(j) & " where " & biaoid & " ='" & sbid(j) & "'"
                GS_upztxx(G_cnnstr, sql) '还原原来库存
            Next
            GS_storelog3("作废" & GroupBox1.Text & "：" & ListView1.CheckedItems(i).SubItems(4).Text, "报废" & GroupBox1.Text) '储存到日志
        Next
        id1 = GF_removedh(id1)
        sql = "update " & biao2 & " set " & biao2 & "_ckdb='取消'," & biao2 & "_num=" & biao2 & "_num+'(zf)'," & biao2 & "_bz='" & bz & "' where " & biao2 & "_ID in(" & id1 & ")"
        GS_upztxx(G_cnnstr, sql) '更新配料表信息
        showsj2(GroupBox1.Text, "34号塔")
    End Sub
    '34执行计划
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        With ListView1
            If .CheckedItems.Count = 0 Then
                Exit Sub
            End If
            If MsgBox("确定执行计划吗？", 1, "警告") <> 1 Then
                Exit Sub
            End If
            Dim sy As Integer = -1 'ListView1显示字段索引
            If GroupBox1.Text = "粉剂配料执行" Then
                Dim wcyp As String = GF_GetListText(ListView1, "tb_x823p_wcyp", 0, 1) '完成油配
                'sy = GF_GetListIndexByText(ListView1, "完成油配") '对根据列标题返回列索引,-1表示没有匹配项目
                If wcyp = "否" Then
                    If MsgBox("还未完成原料配比，确定执行计划吗？", 1, "警告") <> 1 Then
                        Exit Sub
                    End If
                End If


            End If
            Dim sql As String = ""
            If GroupBox1.Text = "粉剂配料执行" Then '拆分配料批的时候不赋值新的批号
                If GF_storelog1("完成粉剂配料计划") = False Then
                    Exit Sub
                End If ' 判断是否有权限
                '''''''''''''''''''''
                For i As Integer = 0 To .CheckedItems.Count - 1


                    Dim ta As String = GF_GetListText(ListView1, "tb_x823p_th", i, 1) '塔号
                    Dim aaph As String = GF_GetListText(ListView1, "tb_x823p_num2", i, 1) 'AA 油批号
                    Dim sbid As String = GF_GetListText(ListView1, "tb_x823p_sbid", i, 1) '上步ID

                    Dim sfqa As String = qasfjc(aaph, "tb_h195z") '确定qa是否检测过，str1表示批号序列，str2表示表名,正确为空值，否则为未检测的批号(通过条件为QA为合格或者返工)
                    If sfqa <> "" Then
                        MsgBox("成品油批号" & sfqa & "未被QA确定为合格或返工，不能执行计划") : Exit Sub
                    End If
                    ''''''''''''''''''''
                    Dim ta2 As String = ""
                    If Microsoft.VisualBasic.Left(ta, 1) = "1" Then
                        ta = "1号塔粉剂配料批" : ta2 = "1号塔"
                    ElseIf Microsoft.VisualBasic.Left(ta, 1) = "2" Then
                        ta = "2号塔粉剂配料批" : ta2 = "2号塔"
                    ElseIf Microsoft.VisualBasic.Left(ta, 1) = "3" Then
                        ta = "34号塔粉剂配料批" : ta2 = "34号塔"
                    ElseIf Microsoft.VisualBasic.Left(ta, 1) = "5" Then
                        ta = "5号塔粉剂配料批" : ta2 = "5号塔"

                    End If

                    ''''''''''''''''''''将配料计划的数据添加到执行计划里
                    Dim dtpl As DataTable
                    Dim sqlpl As String
                    'sy = GF_GetListIndexByText(ListView1, "主键")
                    Dim id As Integer = GF_GetListText(ListView1, "tb_x823p_ID", i, 1) '主键
                    Dim tb_x823p_fgfzl, tb_x823p_myhj, tb_x823p_lssg, tb_x823p_ldbsn, tb_x823p_bxdf, tb_x823p_ysjj, tb_x823p_pwgc, tb_x823p_myhj2, tb_x823p_nmsn, tb_x823p_vcna, tb_x823p_fgfph, tb_x823p_pfbh, tb_x823p_dpmx As String
                    sqlpl = "select tb_x823p_fgfzl,tb_x823p_myhj,tb_x823p_lssg,tb_x823p_ldbsn,tb_x823p_bxdf,tb_x823p_ysjj,tb_x823p_pwgc,tb_x823p_myhj2,tb_x823p_nmsn,tb_x823p_vcna,tb_x823p_fgfph,tb_x823p_pfbh,tb_x823p_dpmx from tb_x823p where tb_x823p_ID=" & id
                    dtpl = GF_CreateDataSource(G_cnnstr, sqlpl)
                    tb_x823p_fgfzl = Null2zero2(dtpl.Rows(0)(0))
                    tb_x823p_myhj = Null2zero2(dtpl.Rows(0)(1))
                    tb_x823p_lssg = Null2zero2(dtpl.Rows(0)(2))
                    tb_x823p_ldbsn = Null2zero2(dtpl.Rows(0)(3))
                    tb_x823p_bxdf = Null2zero2(dtpl.Rows(0)(4))
                    tb_x823p_ysjj = Null2zero2(dtpl.Rows(0)(5))
                    tb_x823p_pwgc = Null2zero2(dtpl.Rows(0)(6))
                    tb_x823p_myhj2 = Null2zero2(dtpl.Rows(0)(7))
                    tb_x823p_nmsn = Null2zero2(dtpl.Rows(0)(8))
                    tb_x823p_vcna = Null2zero2(dtpl.Rows(0)(9))
                    tb_x823p_fgfph = Null2String(dtpl.Rows(0)(10))
                    tb_x823p_pfbh = Null2String(dtpl.Rows(0)(11))
                    tb_x823p_dpmx = Null2String(dtpl.Rows(0)(12))
                    '''''''''''''''''''''''''''''''

                    Dim kcfsl As Integer = GF_GetListText(ListView1, "tb_x823p_cfsl", i, 1) '拆分数量
                    Dim ph1 As String = GF_GetListText(ListView1, "tb_x823p_num", i, 1) '配料单号
                    Dim jhhl As Double = GF_GetListText(ListView1, "tb_x823p_jhhl", i, 1) '计划含量
                    Dim dpzl As String = GF_GetListText(ListView1, "tb_x823p_dpzl", i, 1) '单批重量
                    Dim cplb As String = GF_GetListText(ListView1, "tb_x823p_cplb", i, 1) '产品类型
                    Dim cpdm As String = GF_GetListText(ListView1, "tb_x823p_mingc", i, 1) '产品代码
                    Dim jgdm As String = GF_GetListText(ListView1, "tb_x823p_jiagdm", i, 1) '加工代码
                    Dim kczl As String = GF_GetListText(ListView1, "tb_x823p_kczl", i, 1) '扣除重量

             
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim id2 As String = ""
                    For j As Integer = 0 To kcfsl - 1 '拆分数量拆分成配料批
                        sql = "insert into tb_n441f(tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_dpzl,tb_n441f_m382e,tb_n441f_aaph,tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_ara,tb_n441f_g154y,tb_n441f_g180y,tb_n441f_h209z,tb_n441f_d66v,tb_n441f_t685m,tb_n441f_i245at,tb_n441f_q535i,tb_n441f_z884r,tb_n441f_m397et,tb_n441f_a918st,tb_n441f_d61vt,tb_n441f_a943st,tb_n441f_e88wt,tb_n441f_v734nt,tb_n441f_j291bt,tb_n441f_y875rt,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_scdm,tb_n441f_dpmx)values"
                        sql = sql & "('" & cplb & "','" & cpdm & "','" & jgdm & "','" & ph1 & "'," & dpzl & ",'" & ta2 & "','" & aaph & "','tb_x823p','" & id & "'," & jhhl & "," & tb_x823p_myhj2 & "," & tb_x823p_lssg & "," & tb_x823p_bxdf & "," & tb_x823p_ldbsn & "," & tb_x823p_nmsn & "," & tb_x823p_ysjj & "," & tb_x823p_vcna & "," & tb_x823p_myhj & ",'" & tb_x823p_myhj & "','" & tb_x823p_myhj2 & "','" & tb_x823p_lssg & "','" & tb_x823p_bxdf & "','" & tb_x823p_ldbsn & "','" & tb_x823p_nmsn & "','" & tb_x823p_vcna & "'," & tb_x823p_pwgc & "," & tb_x823p_fgfzl & ",'" & tb_x823p_fgfph & "','" & tb_x823p_pfbh & "','" & tb_x823p_dpmx & "')"
                        id2 = id2 & GF_upztxx2(G_cnnstr, sql, "tb_n441f") & ","
                    Next

                    id2 = GF_removedh(id2)
                    sql = "update tb_x823p set tb_x823p_xbtb='tb_n441f',tb_x823p_ckdb='已完成',tb_x823p_glid='" & id2 & "' where tb_x823p_ID=" & id
                    GS_upztxx(G_cnnstr, sql) '更新配料表的下步表与ID字段
                    jckmx(aaph, kczl, ph1, sbid) 'aaphAA油批号，ph1配料单号
                    GS_storelog3("完成粉剂配料计划：" & ph1, "完成粉剂配料计划") '储存到日志
                Next
                showsj2("粉剂配料执行（34号塔）", "34号塔")

            End If
       
        End With


    End Sub
    '5号塔执行计划
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With ListView1
            If .CheckedItems.Count = 0 Then
                Exit Sub
            End If
            If MsgBox("确定执行计划吗？", 1, "警告") <> 1 Then
                Exit Sub
            End If
            Dim sy As Integer = -1 'ListView1显示字段索引
            If GroupBox1.Text = "粉剂配料执行" Then
                Dim wcyp As String = GF_GetListText(ListView1, "tb_x823p_wcyp", 0, 1) '完成油配
                'sy = GF_GetListIndexByText(ListView1, "完成油配") '对根据列标题返回列索引,-1表示没有匹配项目
                If wcyp = "否" Then
                    If MsgBox("还未完成原料配比，确定执行计划吗？", 1, "警告") <> 1 Then
                        Exit Sub
                    End If
                End If


            End If
            Dim sql As String = ""
            If GroupBox1.Text = "粉剂配料执行" Then '拆分配料批的时候不赋值新的批号
                If GF_storelog1("完成粉剂配料计划") = False Then
                    Exit Sub
                End If ' 判断是否有权限
                '''''''''''''''''''''
                For i As Integer = 0 To .CheckedItems.Count - 1


                    Dim ta As String = GF_GetListText(ListView1, "tb_x823p_th", i, 1) '塔号
                    Dim aaph As String = GF_GetListText(ListView1, "tb_x823p_num2", i, 1) 'AA 油批号
                    Dim sbid As String = GF_GetListText(ListView1, "tb_x823p_sbid", i, 1) '上步ID

                    Dim sfqa As String = qasfjc(aaph, "tb_h195z") '确定qa是否检测过，str1表示批号序列，str2表示表名,正确为空值，否则为未检测的批号(通过条件为QA为合格或者返工)
                    If sfqa <> "" Then
                        MsgBox("成品油批号" & sfqa & "未被QA确定为合格或返工，不能执行计划") : Exit Sub
                    End If
                    ''''''''''''''''''''
                    Dim ta2 As String = ""
                    If Microsoft.VisualBasic.Left(ta, 1) = "1" Then
                        ta = "1号塔粉剂配料批" : ta2 = "1号塔"
                    ElseIf Microsoft.VisualBasic.Left(ta, 1) = "2" Then
                        ta = "2号塔粉剂配料批" : ta2 = "2号塔"
                    ElseIf Microsoft.VisualBasic.Left(ta, 1) = "3" Then
                        ta = "34号塔粉剂配料批" : ta2 = "34号塔"
                    ElseIf Microsoft.VisualBasic.Left(ta, 1) = "5" Then
                        ta = "5号塔粉剂配料批" : ta2 = "5号塔"

                    End If

                    ''''''''''''''''''''将配料计划的数据添加到执行计划里
                    Dim dtpl As DataTable
                    Dim sqlpl As String
                    'sy = GF_GetListIndexByText(ListView1, "主键")
                    Dim id As Integer = GF_GetListText(ListView1, "tb_x823p_ID", i, 1) '主键
                    Dim tb_x823p_fgfzl, tb_x823p_myhj, tb_x823p_lssg, tb_x823p_ldbsn, tb_x823p_bxdf, tb_x823p_ysjj, tb_x823p_pwgc, tb_x823p_myhj2, tb_x823p_nmsn, tb_x823p_vcna, tb_x823p_fgfph, tb_x823p_pfbh, tb_x823p_dpmx As String
                    sqlpl = "select tb_x823p_fgfzl,tb_x823p_myhj,tb_x823p_lssg,tb_x823p_ldbsn,tb_x823p_bxdf,tb_x823p_ysjj,tb_x823p_pwgc,tb_x823p_myhj2,tb_x823p_nmsn,tb_x823p_vcna,tb_x823p_fgfph,tb_x823p_pfbh,tb_x823p_dpmx from tb_x823p where tb_x823p_ID=" & id
                    dtpl = GF_CreateDataSource(G_cnnstr, sqlpl)
                    tb_x823p_fgfzl = Null2zero2(dtpl.Rows(0)(0))
                    tb_x823p_myhj = Null2zero2(dtpl.Rows(0)(1))
                    tb_x823p_lssg = Null2zero2(dtpl.Rows(0)(2))
                    tb_x823p_ldbsn = Null2zero2(dtpl.Rows(0)(3))
                    tb_x823p_bxdf = Null2zero2(dtpl.Rows(0)(4))
                    tb_x823p_ysjj = Null2zero2(dtpl.Rows(0)(5))
                    tb_x823p_pwgc = Null2zero2(dtpl.Rows(0)(6))
                    tb_x823p_myhj2 = Null2zero2(dtpl.Rows(0)(7))
                    tb_x823p_nmsn = Null2zero2(dtpl.Rows(0)(8))
                    tb_x823p_vcna = Null2zero2(dtpl.Rows(0)(9))
                    tb_x823p_fgfph = Null2String(dtpl.Rows(0)(10))
                    tb_x823p_pfbh = Null2String(dtpl.Rows(0)(11))
                    tb_x823p_dpmx = Null2String(dtpl.Rows(0)(12))
                    '''''''''''''''''''''''''''''''

                    Dim kcfsl As Integer = GF_GetListText(ListView1, "tb_x823p_cfsl", i, 1) '拆分数量
                    Dim ph1 As String = GF_GetListText(ListView1, "tb_x823p_num", i, 1) '配料单号
                    Dim jhhl As Double = GF_GetListText(ListView1, "tb_x823p_jhhl", i, 1) '计划含量
                    Dim dpzl As String = GF_GetListText(ListView1, "tb_x823p_dpzl", i, 1) '单批重量
                    Dim cplb As String = GF_GetListText(ListView1, "tb_x823p_cplb", i, 1) '产品类型
                    Dim cpdm As String = GF_GetListText(ListView1, "tb_x823p_mingc", i, 1) '产品代码
                    Dim jgdm As String = GF_GetListText(ListView1, "tb_x823p_jiagdm", i, 1) '加工代码
                    Dim kczl As String = GF_GetListText(ListView1, "tb_x823p_kczl", i, 1) '实际扣除重量

                    '5号塔参考重量合计
                    Dim ReferenceHj As Double = 0
                    For Each cc As Double In kczl.Split(",")
                        ReferenceHj += cc
                    Next



                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim id2 As String = ""
                    For j As Integer = 0 To kcfsl - 1 '拆分数量拆分成配料批
                        sql = "insert into tb_n441f(tb_n441f_cplb,tb_n441f_mingc,tb_n441f_jiagdm,tb_n441f_num2,tb_n441f_dpzl,tb_n441f_m382e,tb_n441f_aaph,tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_ara,tb_n441f_g154y,tb_n441f_g180y,tb_n441f_h209z,tb_n441f_d66v,tb_n441f_t685m,tb_n441f_i245at,tb_n441f_q535i,tb_n441f_z884r,tb_n441f_m397et,tb_n441f_a918st,tb_n441f_d61vt,tb_n441f_a943st,tb_n441f_e88wt,tb_n441f_v734nt,tb_n441f_j291bt,tb_n441f_y875rt,tb_n441f_e95w,tb_n441f_y876r,tb_n441f_scdm,tb_n441f_dpmx)values"
                        sql = sql & "('" & cplb & "','" & cpdm & "','" & jgdm & "','" & ph1 & "'," & dpzl & ",'" & ta2 & "','" & aaph & "','tb_x823p','" & id & "'," & jhhl & "," & tb_x823p_myhj2 & "," & tb_x823p_lssg & "," & tb_x823p_bxdf & "," & tb_x823p_ldbsn & "," & tb_x823p_nmsn & "," & tb_x823p_ysjj & "," & tb_x823p_vcna & "," & tb_x823p_myhj & ",'" & tb_x823p_myhj & "','" & tb_x823p_myhj2 & "','" & tb_x823p_lssg & "','" & tb_x823p_bxdf & "','" & tb_x823p_ldbsn & "','" & tb_x823p_nmsn & "','" & tb_x823p_vcna & "'," & tb_x823p_pwgc & "," & tb_x823p_fgfzl & ",'" & tb_x823p_fgfph & "','" & tb_x823p_pfbh & "','" & tb_x823p_dpmx & "')"
                        id2 = id2 & GF_upztxx2(G_cnnstr, sql, "tb_n441f") & ","
                    Next

                    id2 = GF_removedh(id2)
                    Dim oil() As String = kczl.Split(",")
                    Dim aa As String = ""
                    For j As Integer = 0 To oil.Length - 1
                        aa = aa & "0,"
                    Next


                    sql = "update tb_x823p set tb_x823p_xbtb='tb_n441f',tb_x823p_ckdb='已完成',tb_x823p_glid='" & id2 & "', tb_x823p_kczl='" & GF_removedh(aa) & "',tb_x823p_Reference='" & kczl & "',tb_x823p_ReferenceHj=" & ReferenceHj & " where tb_x823p_ID=" & id
                    GS_upztxx(G_cnnstr, sql) '更新配料表的下步表与ID字段
                    'jckmx(aaph, kczl, ph1, sbid) 'aaphAA油批号，ph1配料单号
                    GS_storelog3("完成粉剂配料计划：" & ph1, "完成粉剂配料计划") '储存到日志
                Next
                showsj2("粉剂配料执行（5号塔）", "5号塔")

            End If

        End With
    End Sub
    '5号塔配料单取消
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListView1.CheckedItems.Count = 0 Then
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
        If GF_storelog1("作废" & GroupBox1.Text) = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''
        Dim dResult As DialogResult = MessageBox.Show("是否确定作废该计划？", "系统提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
        Dim bz As String = ""
        If dResult <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        Else
            bz = InputBox("请输入作废原因！", "系统提示：")
            If bz = "" Then
                MsgBox("未填写作废原因！")
                Exit Sub
            End If
        End If

        Dim biao As String = "tb_h195zkc"
        Dim biao2 As String = "tb_x823p"
        Dim biaozd As String = "tb_h195zkc_num"
        Dim biaoid As String = "tb_h195zkc_id"
        If GroupBox1.Text = "毛油配料执行" Then
            biao = "tb_x825pkc" : biaozd = "tb_x825pkc_num" : biao2 = "tb_x825ppl" : biaoid = "tb_x825pkc_id"
        End If
        Dim id1 As String = ""
        Dim sql As String = ""
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            id1 = id1 & ListView1.CheckedItems(i).SubItems(0).Text & ","
            Dim ph1, zl1, idsb As String
            idsb = GF_GetListText(ListView1, "tb_x823p_sbid", i, 1)
            ph1 = GF_GetListText(ListView1, "tb_x823p_num2", i, 1) '批号序列
            zl1 = GF_GetListText(ListView1, "tb_x823p_kczl", i, 1) '扣除的重量序列
            Dim phsz() As String = Split(ph1, ",") : Dim zlsz() As String = Split(zl1, ",") : Dim sbid() As String = Split(idsb, ",")
            'For j As Integer = 0 To UBound(phsz)
            '    sql = "update " & biao & " set " & biao & "_sykczl=" & biao & "_sykczl+" & zlsz(j) & " where " & biaoid & " ='" & sbid(j) & "'"
            '    GS_upztxx(G_cnnstr, sql) '还原原来库存
            'Next
            GS_storelog3("作废" & GroupBox1.Text & "：" & ListView1.CheckedItems(i).SubItems(4).Text, "报废" & GroupBox1.Text) '储存到日志
        Next
        id1 = GF_removedh(id1)
        sql = "update " & biao2 & " set " & biao2 & "_ckdb='取消'," & biao2 & "_num=" & biao2 & "_num+'(zf)'," & biao2 & "_bz='" & bz & "' where " & biao2 & "_ID in(" & id1 & ")"
        GS_upztxx(G_cnnstr, sql) '更新配料表信息
        showsj2(GroupBox1.Text, "34号塔")
    End Sub
    '确定qa是否检测过，str1表示批号序列，str2表示表名,正确为空值，否则为未检测的批号 
    Private Function qasfjc(ByVal str1 As String, ByVal str2 As String) As String
        Dim k1() As String = Split(str1, ",")
        For i As Integer = 0 To UBound(k1)
            Dim sql As String = "select " & str2 & "_id from " & str2 & " where (" & str2 & "_qaspjg='合格' or " & str2 & "_qaspjg='返工') and " & str2 & "_num='" & k1(i) & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                qasfjc = k1(i) : Exit Function
            End If
        Next
        qasfjc = ""
    End Function


    Private Sub MYPLDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MYPLDB.Click
        If GF_storelog2("查询毛油配料", "查询毛油配料") = False Then
            Exit Sub
        End If
        showsj2("毛油配料执行")
    End Sub

    '34号塔执行计划

    Private Sub FJPLDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FJPLDB.Click
        If GF_storelog2("查询粉剂配料", "查询粉剂配料") = False Then
            Exit Sub
        End If
        Button4.Enabled = True : Button5.Enabled = True
        Button1.Enabled = False : Button2.Enabled = False

        showsj2("粉剂配料执行", "34号塔")
    End Sub

    '5号塔执行计划

    Private Sub FiveJPLDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiveJPLDB.Click
        If GF_storelog2("查询粉剂配料", "查询粉剂配料") = False Then
            Exit Sub
        End If
        Button4.Enabled = False : Button5.Enabled = False
        Button1.Enabled = True : Button2.Enabled = True
        showsj2("粉剂配料执行", "5号塔")
    End Sub

    '打开成品进出货界面

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim nform As New frzchuo
        nform.ShowDialog()
    End Sub

    Private Sub YllbsdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New frShowyllbYS
        nform.ShowDialog()
    End Sub
    '配料计划查询

    Private Sub pljhcx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pljhcx.Click
        Dim nform As New Frpljhcx
        nform.ShowDialog()
    End Sub


    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        GF_TranEtoC2(ylbdb)
        GS_dbtoexcel(ylbdb, GroupBox1.Text, Me)
    End Sub

    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '得到表中文意思
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub
    Private Sub INSERT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERT1.Click
        Call showform("tb_yxjh")
    End Sub

    Private Sub INSERT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERT2.Click
        Call showform("tb_fhyb")
    End Sub
    '储存到进出库明细,批号序列，产品类型、产品代码、加工代码
    Private Sub jckmx(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String, ByVal str4 As String)
        Dim sbid() As String = Split(str4, ",")
        Dim ph1() As String = Split(str1, ",")
        Dim zl1() As String = Split(str2, ",")

        For i As Integer = 0 To UBound(sbid)
            Dim sql As String = "select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm from tb_h195zkc where tb_h195zkc_id= '" & sbid(i) & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Dim cplb1 As String = Null2String(dt.Rows(0)(0))
            Dim cpdm1 As String = Null2String(dt.Rows(0)(1))
            Dim jgdm1 As String = Null2String(dt.Rows(0)(2))
            Dim sql2 As String = ""
            sql2 = "insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh,tb_jch_pldh) values"
            sql2 = sql2 & "('" & cplb1 & "','" & cpdm1 & "','" & jgdm1 & "','" & ph1(i) & "','出'," & zl1(i) & ",getdate(),'生产','执行计划','" & G_dlrgh & "','" & str3 & "')"
            GS_upztxx(G_cnnstr, sql2)
        Next

    End Sub



    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'Call showform("tb_pljh")
        Dim nform As New Frfangong
        nform.ShowDialog()
    End Sub

    Private Sub LHJGSR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LHJGSR.Click
        If GF_storelog2("查询能耗价格", "查询能耗价格") = False Then
            Exit Sub
        End If
        Dim nform As New frnhYearJG
        nform.ShowDialog()
    End Sub

    Private Sub LHHTSR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LHHTSR.Click
        If GF_storelog2("查询能耗分摊", "查询能耗分摊") = False Then
            Exit Sub
        End If
        Dim nform As New frnbMonthft
        nform.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        If GF_storelog1("无效原料") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim yldm As String = ListView1.SelectedItems(0).SubItems(5).Text
        Dim xzindex As Integer = ListView1.SelectedItems(0).Index
        If MsgBox("确实要使" & yldm & "无效吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        Call GS_modczsj("tb_i259b", "tb_i259b_yxx", ListView1.SelectedItems(0).SubItems(0).Text, "无效")
        ListView1.Items.RemoveAt(xzindex)
        GS_storelog3("无效原料：" & yldm, "无效原料") '储存到日志
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("运行部")
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If InStr(GroupBox1.Text, "原料") = 0 And InStr(GroupBox1.Text, "包材") = 0 Then
            Exit Sub
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_i259b_id from tb_i259b where tb_i259b_qcrq is null and tb_i259b_id=" & ListView1.SelectedItems(0).SubItems(0).Text)
        If dt.Rows.Count = 0 Then
            MsgBox("已经被QC检测，不能修改") : Exit Sub
        End If
        Dim nform As New Fryl
        nform.Labelid.Text = ListView1.SelectedItems(0).SubItems(0).Text
        nform.Labeltb.Text = "tb_i259b"
        nform.ShowDialog()
    End Sub


    Private Sub ToolStripwjg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripwjg.Click
        Dim nform As New Frscfgy
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripcpf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripcpf.Click
        'Dim nform As New Frfgyf
        Dim nform As New FrAddwjgf
        nform.ShowDialog()
    End Sub

    Private Sub K3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call showform("tb_k3cpykc")
        'Dim nform As New frk3cpykc
        'nform.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItemGRPXDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemGRPXDA.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub



    Private Sub ToolStripMenuItemQTYFCL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemQTYFCL.Click
        Dim nform As New Frfscylsy
        nform.frname = "粉剂生产部"
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripMenuYLCYBJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If G_js <> "管理员" Then
            MsgBox("只有管理员有权限")
            Return
        End If
        Dim nform As New Frylcybj

        nform.ShowDialog()
    End Sub
    '物料进出货
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim aa As New Frylchuhuo
        aa.ShowDialog()
    End Sub

    Private Sub 导入原料ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New Form6
        nform.ShowDialog()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim aa As New Frwljhbb
        aa.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If GF_storelog1("订单查询") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim nform As New Frddlist
        nform.Show()
    End Sub

   
    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New FrVb
        nform.ShowDialog()
    End Sub


    Private Sub Button3_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim aa As New Frtb_warning
        aa.ShowDialog()
    End Sub
    '毛油配料执行
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Try
        If ListView1.CheckedItems.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("确定执行计划吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        Dim sql As String = ""
        'If GF_storelog1("完成精炼计划") = False Then
        '    Exit Sub
        'End If ' 判断是否有权限
        '''''''''''''''''''''
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            Dim ph1 As String = ListView1.CheckedItems(i).SubItems(6).Text '配料批号 4tb_mypl_num
            Dim sfqa As String = qasfjc(ListView1.CheckedItems(i).SubItems(7).Text, "tb_x825pkc", ListView1.CheckedItems(i).SubItems(1).Text) '5tb_mypl_num2
            Dim cplb As String = ListView1.CheckedItems(i).SubItems(5).Text '产品类型 3tb_mypl_cplb
            Dim jgdm As String = ListView1.CheckedItems(i).SubItems(1).Text '加工代码 tb_k306c_jiagdm
            Dim cpdm As String = ListView1.CheckedItems(i).SubItems(2).Text '产品代码 tb_k306c_mingc
            Dim aaph As String = ListView1.CheckedItems(i).SubItems(10).Text '精炼批重量 8tb_mypl_e95w
            Dim plmx() As String = ListView1.CheckedItems(i).SubItems(13).Text.Split("#") '毛油精炼批明细 11tb_mypl_q569j
            Dim plmxs As String = plmx(0)
            For ii As Integer = 1 To plmx.Length - 1
                plmxs = plmxs & "," & plmx(ii)
            Next


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '计算计划含量

            Dim dtt As DataTable
            Dim str3() As String = ListView1.CheckedItems(i).SubItems(7).Text.Split(",") '批号
            Dim str33() As String = ListView1.CheckedItems(i).SubItems(1).Text.Split(",") '加工代码
            Dim str4(str3.Length - 1) As String
            Dim IDD As String = ""

            For n As Integer = 0 To str3.Length - 1

                Dim dt01 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_x825pkc_m387e from tb_x825pkc where tb_x825pkc_num='" & str3(n) & "'and tb_x825pkc_jiagdm='S0600'")
                str4(n) = dt01.Rows(0)(0)
                Dim dt02 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_x825pkc_id from tb_x825pkc where tb_x825pkc_num='" & str3(n) & "'and tb_x825pkc_jiagdm='S0600'")
                IDD = IDD & dt02.Rows(0)(0) & "," '找到原料库存对应的ID
            Next
            IDD = GF_removedh(IDD)
            Dim tt As String = "select tb_x825pkc_m387e from tb_x825pkc where tb_x825pkc_id in (" & IDD & ")"

            dtt = GF_CreateDataSource(G_cnnstr, tt)
            Dim str1() As String
            Dim dd As Double = 0
            Dim cc As Double = 0
            Dim myhl As Double

            If InStr(ListView1.CheckedItems(i).SubItems(8).Text, ",") > 0 Then
                str1 = Split(ListView1.CheckedItems(i).SubItems(8).Text, ",")
                For ii As Integer = 0 To str1.Length - 1

                    dd = dd + Double.Parse(str4(ii)) * Double.Parse(str1(ii))

                    cc = cc + Double.Parse(str1(ii))
                Next

                If cc <= 0 Then
                    MsgBox("扣除对应的毛油DHA重量不能为0！")
                    Exit Sub
                End If
                dd = dd / cc
                myhl = FormatNumber(dd, 2)
            Else
                myhl = Null2zero2(dtt.Rows(0)(0))
            End If
            If MsgBox("确认毛油DHA含量：" & myhl, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim jlppzl() As String = Split(aaph, ",")
            Dim id2 As String = ""
            '设定放罐批号
            Dim qztemp As String = ClassPhgn.ClassPhgn_GetQz("精炼")
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            ''''''''''''''''''''
            Dim xh1 As String = qztemp '序号前面部分
            Dim qsz As String = ClassPhgn.ClassPhgn_GetDqz("精炼") '起始值
            qsz = qsz + 1
            Dim newxh As String = xh1 & "-" & qsz
            Dim zongliang As Double = 0
            Dim bfb As Double = 0
            For jj As Integer = 0 To jlppzl.Length - 1
                bfb = Double.Parse(bfb) + Double.Parse(myhl * jlppzl(jj) / 100)
                zongliang = Double.Parse(zongliang) + Double.Parse(jlppzl(jj))
            Next


            sql = "insert into tb_k306c(tb_k306c_num,tb_k306c_num2,tb_k306c_m383e,tb_k306c_sbtb,tb_k306c_sbid,tb_k306c_q559i,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_cplb,tb_k306c_jiagdm,tb_k306c_mingc)values"
            sql = sql & "('" & newxh & "','" & ph1 & "'," & zongliang & ",'tb_mypl','" & ListView1.CheckedItems(i).SubItems(0).Text & "', '" & plmxs & "'," & myhl & "," & bfb & ",'" & cplb & "','" & jgdm & "','" & cpdm & "')"

            id2 = id2 & GF_upztxx2(G_cnnstr, sql, "tb_k306c") & ","

            id2 = GF_removedh(id2)
            sql = "update tb_mypl set tb_mypl_xbtb='tb_k306c',tb_mypl_ckdb='已完成',tb_mypl_glid='" & id2 & "',tb_mypl_myhl='" & myhl & "' where tb_mypl_ID=" & ListView1.CheckedItems(i).SubItems(0).Text & ""

            GS_upztxx(G_cnnstr, sql) '更新配料表的下步表与ID字段
            ClassPhgn.ClassPhgn_SetDqz("精炼", qsz) '更新起始值
            '存储到进出货明细表
            CrudeJckmx(ListView1.CheckedItems(i).SubItems(7).Text, ListView1.CheckedItems(i).SubItems(8).Text, ListView1.CheckedItems(i).SubItems(6).Text)
            GS_storelog3("完成精炼计划：" & ph1, "完成精炼计划") '储存到日志,
        Next
        showsj2("毛油配料执行")
    End Sub
    '毛油配料计划作废
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If ListView1.CheckedItems.Count = 0 Then
                Exit Sub
            End If
            '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
            'If GF_storelog1("作废精炼计划") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            ''''''''''''''''''''
            Dim dResult As DialogResult = MessageBox.Show("是否确定作废该计划？", "系统提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            Dim bz As String = ""
            If dResult <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            Else
                bz = InputBox("请输入作废原因！", "系统提示：")
                If bz = "" Then
                    MsgBox("未填写作废原因！")
                    Exit Sub
                End If
            End If

            Dim biao As String = String.Empty
            Dim biao2 As String = String.Empty
            Dim biaozd As String = String.Empty
            Dim biaozdd As String = String.Empty
            If GroupBox1.Text = "毛油配料执行" Then
                biao = "tb_x825pkc" : biaozd = "tb_x825pkc_num" : biao2 = "tb_mypl" : biaozdd = "tb_x825pkc_jiagdm"
            End If
            Dim id1 As String = ""
            Dim sql As String = ""
            For i As Integer = 0 To ListView1.CheckedItems.Count - 1
                id1 = id1 & ListView1.CheckedItems(i).SubItems(0).Text & ","
                Dim ph1, zl1, jiagdm As String
                ph1 = ListView1.CheckedItems(i).SubItems(7).Text '批号序列
                zl1 = ListView1.CheckedItems(i).SubItems(8).Text '扣除的重量序列
                jiagdm = ListView1.CheckedItems(i).SubItems(1).Text '加工代码
                Dim phsz() As String = Split(ph1, ",") : Dim zlsz() As String = Split(zl1, ",")
                For j As Integer = 0 To UBound(phsz)
                    sql = "update " & biao & " set " & biao & "_sykczl=" & biao & "_sykczl+" & zlsz(j) & " where " & biaozd & " ='" & phsz(j) & "'and " & biaozdd & "='S0600'"
                    GS_upztxx(G_cnnstr, sql) '还原原来库存

                Next
                GS_storelog3("作废" & GroupBox1.Text & "：" & ListView1.CheckedItems(i).SubItems(6).Text, "报废" & GroupBox1.Text) '储存到日志
            Next
            id1 = GF_removedh(id1)
            sql = "update " & biao2 & " set " & biao2 & "_ckdb='取消'," & biao2 & "_num=" & biao2 & "_num+'(zf)'," & biao2 & "_bz='" & bz & "' where " & biao2 & "_ID in(" & id1 & ")"

            GS_upztxx(G_cnnstr, sql) '更新配料表信息
            showsj2(GroupBox1.Text)
        Catch ex As Exception
        End Try
    End Sub

    '毛油配料计划  进出货
    '储存到进出库明细,批号序列，重量序列 str3 为配料批号
    Private Sub CrudeJckmx(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String)
        Dim ph1() As String = Split(str1, ",")
        Dim zl1() As String = Split(str2, ",")
        'Dim gg() As String = Split(str4, ",") '加工代码
        Dim sql As String = ""
        For i As Integer = 0 To UBound(ph1)
            sql = "select tb_x825pkc_cplb ,tb_x825pkc_jiagdm,tb_x825pkc_mingc from tb_x825pkc where tb_x825pkc_num= '" & ph1(i) & "'and tb_x825pkc_jiagdm='S0600'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Dim cplb As String = Null2String(dt.Rows(0)(0)) '产品类型
            Dim mingc As String = Null2String(dt.Rows(0)(2)) '产品代码
            sql = "select tb_k306c_num from vw_k306c where tb_k306c_num2= '" & str3 & "'"
            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Dim jlph As String = Null2String(dt1.Rows(0)(0)) '精炼批号
            Dim sql1 As String = "insert into tb_jch(tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh,tb_jch_mingc,tb_jch_jiagdm,tb_jch_jlph) values"
            sql1 = sql1 & "('" & cplb & "','" & ph1(i) & "','出'," & zl1(i) & ",getdate(),'生产','执行计划','" & G_dlrgh & "','" & mingc & "','S0600','" & jlph & "')"
            GS_upztxx(G_cnnstr, sql1)
        Next
    End Sub

    '确定qa是否检测过，str1表示批号序列，str2表示表名,正确为空值，否则为未检测的批号
    Private Function qasfjc(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As String
        Dim k1() As String = Split(str1, ",")
        For i As Integer = 0 To UBound(k1)
            Dim sql As String = "select " & str2 & "_id from " & str2 & " where (" & str2 & "_qaspjg='合格' or " & str2 & "_qaspjg='返工') and " & str2 & "_num='" & k1(i) & "'and  " & str2 & "_jiagdm= '" & str3 & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                qasfjc = k1(i) : Exit Function
            End If
        Next
        qasfjc = ""
    End Function
End Class