
Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Fryl

    Dim phy As String = Nothing '如果为修改的话，用来记录修改前该条信息的批号
    Public m_ckcl As Double = 0
    Private Sub Fryl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        sfbh.SelectedIndex = 1
        tb_i259b_sfqj.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        m_ckcl = tb_i259b_ckcl.Text.Trim

        If czid <> "" Then '修改时候批号不能修改
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Dim sql As String = "select tb_i259b_i231a from tb_i259b where tb_i259b_id = '" & czid & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            tb_i259b_i231a.Items.Add(dt.Rows(0)(0))
            tb_i259b_i231a.Text = dt.Rows(0)(0)
            tb_i259b_i231a.Enabled = False
            tb_i259b_p518h.ReadOnly = True
            ComboBox1.SelectedIndex = 0
            ComboBox1.Enabled = False
            phy = tb_i259b_num.Text
        Else
            If tb_i259b_sbid.Text = "" Then '如果信息不是从采购中传出，则不需xglb方法
                xglb()
                tb_i259b_i231a.Items.Insert(0, "请选择")
                tb_i259b_i231a.SelectedItem = tb_i259b_i231a.Items(0)
            End If
        End If
        AddHandler ComboBox1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
        ComboBox1_SelectedIndexChanged()

    End Sub

    Private Sub tb_i259b_i231a_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_i259b_i231a.SelectedIndexChanged
        Try
            Dim lb As String = tb_i259b_i231a.Text '名称
            If lb <> "请选择" Then
                Dim sql As String = " select tb_wp_wpfl as 原料类别,tb_wp_dm as 原料代码,tb_wp_pm as 原料名称,tb_wp_dw  as 单位," &
                    "tb_wp_ggxh  as 规格 from tb_wp where  tb_wp_dm= '" & tb_i259b_i231a.Text & "'"
                Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                tb_i259b_c24u.Text = dt.Rows(0)(2)
                tb_i259b_h200z.Text = Null2String(dt.Rows(0)(3))
                tb_i259b_gg.Text = Null2String(dt.Rows(0)(4))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MessageBox.Show("所有日期都已正确填写？", "系统提示", MessageBoxButtons.YesNo) = vbNo Then
            Return
        End If
        changeDate()
        If cz() Then
            MessageBox.Show("更新成功！")
            Me.Close()
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub xglb()
        Dim lb As String = tb_i259b_r596j.Text '类别
        Dim sql As String = " select tb_wp_wpfl as 原料类别,tb_wp_dm as 原料代码,tb_wp_pm as 原料名称,tb_wp_dw  as 单位," &
            "tb_wp_ggxh  as 规格 from tb_wp where  tb_wp_wpfl = '" & lb & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(tb_i259b_i231a, dt, 1, "")
    End Sub

    Private Sub tb_i259b_p518h_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_i259b_p518h.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "." And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
        Dim textbox As TextBox = sender
        If InStr(textbox.Text, ".") And e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged()
        For i As Integer = 1 To 3
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_num" & IIf(i = 1, "", i)).Visible = False
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_ckcl" & IIf(i = 1, "", i)).Visible = False
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_cw" & IIf(i = 1, "", i)).Visible = False
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_scrq" & IIf(i = 1, "", i)).Visible = False
            Me.Controls("labelph" & i).Visible = False
            Me.Controls("labelcl" & i).Visible = False
            Me.Controls("labelcw" & i).Visible = False
            Me.Controls("labelsj" & i).Visible = False
        Next
        For i As Integer = 1 To _S.YanFormatNum(ComboBox1.Text)
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_num" & IIf(i = 1, "", i)).Visible = True
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_ckcl" & IIf(i = 1, "", i)).Visible = True
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_cw" & IIf(i = 1, "", i)).Visible = True
            Me.Controls(IIf(i = 1, "tb_", "") & "i259b_scrq" & IIf(i = 1, "", i)).Visible = True
            Me.Controls("labelph" & i).Visible = True
            Me.Controls("labelcl" & i).Visible = True
            Me.Controls("labelcw" & i).Visible = True
            Me.Controls("labelsj" & i).Visible = True
        Next

    End Sub

    Private Function cz() As Boolean
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Return False
        End If
        If tb_i259b_r596j.Text = "" Then
            MsgBox("请选择物料类别")
            Return False
        End If

        Dim pd As Boolean = True '原料入库时点确定后弹出提示“是否已填写正确的最后的保质日期和产品保质日期”是则入库，否则不入库。
        If MsgBox("是否已填写正确的最后的保质日期和产品保质日期？", 1, "提示") <> 1 Then
            pd = False
            Return False
        End If
        If tb_i259b_num.Text.Trim = "" Or tb_i259b_ckcl.Text.Trim = "" Or tb_i259b_q546i.Text.Trim = "" Then
            MsgBox("批号、数量、来源不能为空！")
            Return False
        End If
        If tb_i259b_i231a.Text = "请选择" Then
            MsgBox("代码选择错误！")
            Return False
        End If

        Dim sl As Double = tb_i259b_ckcl.Text.Trim
        Dim rksj As DateTime = tb_i259b_rkrq.Text
        Dim oldph As String = tb_i259b_num.Text.Trim
        tb_i259b_num2.Text = oldph
        Dim newph As String = tb_i259b_num.Text.Trim '得到不重复批号
        Dim sign As Boolean = True
        While (cxph(newph))
            MsgBox("该批号在原料表中已存，请重新填写 ")
            Return False
        End While

        '对输入批号进行判定
        Dim ltNum As New List(Of String)
        For i As Integer = 1 To ComboBox1.Text
            Dim objText As TextBox = Me.Controls(IIf(i = 1, "tb_", "") & "i259b_num" & IIf(i = 1, "", i))
            If ltNum.IndexOf(objText.Text.Trim) >= 0 Then
                MsgBox("不能有相同的批号！")
                objText.Focus()
                Return False
            End If
            ltNum.Add(objText.Text.Trim)
            '是否有相同记录
            If cxph(objText.Text) Then
                MsgBox("已有相同批号！")
                objText.Focus()
                Return False
            End If

            Dim objYt As yanTextBox = Me.Controls(IIf(i = 1, "tb_", "") & "i259b_ckcl" & IIf(i = 1, "", i))
            If objYt.Text <= 0 Then
                MsgBox("数字要大于0！")
                objYt.Focus()
                Return False
            End If
        Next
        Dim dhsl As Double = Null2zero2(tb_i259b_ckcl.Text) + Null2zero2(i259b_ckcl2.Text)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Labelid.Text = "" Then '当添加的时候判断批号是否重复
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加原料") = False Then
                Return False
            End If ' 判断是否有权限
            For cs As Integer = 1 To ComboBox1.SelectedIndex + 1
                '如果内包材和原料为0 不是则等于仓库库存量
                tb_i259b_num.Text = Me.Controls(IIf(cs = 1, "tb_", "") & "i259b_num" & IIf(cs = 1, "", cs)).Text
                tb_i259b_ckcl.Text = Me.Controls(IIf(cs = 1, "tb_", "") & "i259b_ckcl" & IIf(cs = 1, "", cs)).Text
                tb_i259b_kczl.Text = Me.Controls(IIf(cs = 1, "tb_", "") & "i259b_ckcl" & IIf(cs = 1, "", cs)).Text
                tb_i259b_cw.Text = Me.Controls(IIf(cs = 1, "tb_", "") & "i259b_cw" & IIf(cs = 1, "", cs)).Text
                tb_i259b_scrq.Text = Me.Controls(IIf(cs = 1, "tb_", "") & "i259b_scrq" & IIf(cs = 1, "", cs)).Text
                'tb_i259b_zhbzq.Text = zhbzq(CType(tb_i259b_scrq.Text, Date)) ' 最后保质日期（系统计算）
                'tb_i259b_endrq.Text = EndRq(CType(tb_i259b_zhbzq.Text, Date)) '允许出库的最终日期（系统计算）
                tb_i259b_zhbzq.Text = zhbzq(CType(tb_i259b_scrq.Text, Date)) ' 最后保质日期（系统计算）
                tb_i259b_endrq.Text = EndRq(CType(tb_i259b_scrq.Text, Date)) '允许出库的最终日期（系统计算）
                tb_i259b_p518h.Text = 0
                If tb_i259b_num.Text = "" And tb_i259b_ckcl.Text = "" Then
                    Exit For
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If tb_i259b_i231a.Text = "2.01.007" Then '湖葵花籽油原料请购输入时的单位为KG，在原料入库的时候 把剩余库存转换单位改成L，转换公式为200kg=190L
                ElseIf tb_i259b_i231a.Text = "2.01.003" Then '消泡剂原料请购输入时的单位为KG，可否在原料入库的时候 把剩余库存的单位转换成L，kg=L
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim jj As String = GF_addsj("tb_i259b", Me)
                Dim Sqlyljch As String = "Insert into tb_yljch(tb_yljch_yllb,tb_yljch_mc,tb_yljch_cz,tb_yljch_sl,tb_yljch_bz,tb_yljch_czrgh," &
                    "tb_yljch_rq,tb_yljch_dw,tb_yljch_jhdh,tb_yljch_num,tb_yljch_dm) values('" & tb_i259b_r596j.Text & "','" & tb_i259b_c24u.Text & "'," &
                    "'进'," & tb_i259b_ckcl.Text & ",'" & Null2String(tb_i259b_bz.Text) & "','" & G_dlrgh & "','" & rksj.ToString("yyyy-MM-dd") & "','" &
                    tb_i259b_h200z.Text & "','" & tb_i259b_jhdh.Text & "','" & tb_i259b_num.Text & "','" & tb_i259b_i231a.Text & "')"
                GS_upztxx(G_cnnstr, Sqlyljch) '导入原料进出货
                If jj = "" Then
                    MsgBox("请检查输入项目及数据")
                    Return False
                Else
                    GS_modczsj("tb_i259b", "tb_i259b_czrgh", jj, G_dlrgh) '更新操作人工号
                    GS_storelog3("添加原料：" & newph, "添加原料") '储存到日志
                End If
                '''''''''''''''''''''''''''''''''是否请检，如果是则到qc检测，如否则直接入库（并填充相应qc表，且qa为合格）
                Dim sql As String = ""
                Dim sqlc As String = ""
                Dim bmc As String = ""
                Dim idc As String = ""
                Select Case tb_i259b_r596j.Text
                    Case "锅炉原料", "发酵原料", "油剂原料", "粉剂原料", "通用原料"
                        sqlc = "insert into tb_t676l ( tb_t676l_num,tb_t676l_x836q,tb_t676l_p497h,tb_t676l_l345d,tb_t676l_qcsh)    "
                        sqlc &= " values ('" & tb_i259b_num.Text & "' , '" & tb_i259b_c24u.Text & "', '" & tb_i259b_scs.Text & "'," & tb_i259b_ckcl.Text & ",'否' )"
                        bmc = "tb_t676l"
                    Case "油剂包材", "粉剂包材", "通用包材"
                        sqlc = "insert into tb_bcQC (tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcsh)  "
                        sqlc &= " values ('" & tb_i259b_num.Text & "' , '" & tb_i259b_c24u.Text & "', '" & tb_i259b_scs.Text & "'," & tb_i259b_ckcl.Text & ",'否') "
                        bmc = "tb_bcQC"
                End Select
                idc = GF_upztxx2(G_cnnstr, sqlc, bmc)

                If tb_i259b_sfqj.Text = "否" Then
                    sql &= "  update tb_i259b set tb_i259b_qcsh='是',tb_i259b_qcrq='" & GF_gettrqsj(Now) & "',tb_i259b_qarq='" & GF_gettrqsj(Now) & "' ,tb_i259b_qaspjg='合格',tb_i259b_qaczrgh='" & G_dlrgh & "'" '更新qa
                    sql &= "  where tb_i259b_id=" & CType(jj, Integer) & vbCrLf
                    sql &= " update " & bmc & " set " & bmc & "_qcsh='是' where  " & bmc & "_id='" & idc & "' " & vbCrLf
                    GS_upztxx(G_cnnstr, sql)
                End If

            Next

            '‘更新采购模块中的信息及修改到货跟踪表 
            Dim sqlcg As String = "update tb_dhgz set tb_dhgz_xbid=" & tb_i259b_sbid.Text & " ,tb_dhgz_sfys='是',tb_dhgz_ysr='入库',tb_dhgz_dhsl=" & dhsl & " "
            If tb_i259b_sfqj.Text = "否" Then
                sqlcg &= " ,tb_dhgz_ysrq='" & GF_gettrqsj(Now) & "'"
            End If
            sqlcg &= "  where tb_dhgz_id =" & tb_i259b_sbid.Text & ""
            GS_upztxx(G_cnnstr, sqlcg)
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改原料") = False Then
                Return False
            End If ' 判断是否有权限
            '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
            If GF_modsj("tb_i259b", Me, Labelid.Text) = False Then '修改数据
                MsgBox("请检查输入项目及数据")
                Return False
            Else
                GS_modczsj("tb_i259b", "tb_i259b_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                GS_storelog3("修改原料：" & tb_i259b_num.Text.Trim, "修改原料") '储存到日志
            End If
            GF_modsj("tb_i259b", Me, Labelid.Text)

            '''''''''''''''''''''''''''''''''是否请检，如果是则到qc检测，如否则直接入库（并填充相应qc表，且qa为合格）
            Dim sql As String = ""
            Dim sqlc As String = ""
            Dim bmc As String = ""
            Dim idc As String = ""

            Select Case tb_i259b_r596j.Text
                Case "锅炉原料", "发酵原料", "油剂原料", "粉剂原料", "通用原料"
                    sqlc = "insert into tb_t676l ( tb_t676l_num,tb_t676l_x836q,tb_t676l_p497h,tb_t676l_l345d,tb_t676l_qcsh)    "
                    sqlc &= " values ('" & tb_i259b_num.Text & "' , '" & tb_i259b_c24u.Text & "', '" & tb_i259b_q546i.Text & "'," & tb_i259b_p518h.Text & ",'否' )"
                    bmc = "tb_t676l"
                Case "油剂包材", "粉剂包材", "通用包材"
                    sqlc = "insert into tb_bcQC (tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcsh)  "
                    sqlc &= " values ('" & tb_i259b_num.Text & "' , '" & tb_i259b_c24u.Text & "', '" & tb_i259b_scs.Text & "'," & tb_i259b_p518h.Text & ",'否') "
                    bmc = "tb_bcQC"
            End Select
            idc = GF_upztxx2(G_cnnstr, sqlc, bmc)

            If tb_i259b_sfqj.Text = "否" Then
                sql &= "  update tb_i259b set tb_i259b_qcsh='是',tb_i259b_qcrq='" & GF_gettrqsj(Now) & "',tb_i259b_qarq='" & GF_gettrqsj(Now) & "',tb_i259b_qaspjg='合格',tb_i259b_qaczrgh='" & G_dlrgh & "'" '更新qa
                sql &= "  where tb_i259b_id=" & CType(Labelid.Text, Integer)
                sql &= " update " & bmc & " set " & bmc & "_qcsh='是' where  " & bmc & "_id='" & idc & "' " & vbCrLf
            End If

            sql &= "update tb_yljch set tb_yljch_bz='" & tb_i259b_bz.Text & "',tb_yljch_rq='" & GF_gettrqsj(tb_i259b_rkrq.Text) & "',tb_yljch_num='" & tb_i259b_num.Text & "' where tb_yljch_num='" & phy & "' and tb_yljch_dm='" & tb_i259b_i231a.Text & "'"
            GS_upztxx(G_cnnstr, sql)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If
        If sfbh.Text = "补货" Then
            Dim bh = "update  tb_dhgz set tb_dhgz_sfbh='补货'   where tb_dhgz_id =" & tb_i259b_sbid.Text & ""
            GS_upztxx(G_cnnstr, bh)
        End If
        Return True
    End Function
    '最后保质日期（系统计算）=生产日期+产品保质期(天)
    '最后保质期日期=生产日期+供应商保质期(月)
    Private Function zhbzq(ByVal scrq As Date) As Date
        Dim sql As String = " select tb_GysTwo_bzq from tb_GysTwo where tb_GysTwo_ID ='" & tb_i259b_gysbs.Text & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, Sql)
        If dt.Rows.Count > 0 Then
            zhbzq = DateAndTime.DateAdd(DateInterval.Month, Convert.ToDouble(_S.YanFormatNum(dt.Rows(0)("tb_GysTwo_bzq"))), scrq)
        Else
            zhbzq = Now.Date
        End If
    End Function
    '允许出库的最终日期（系统计算）=最后保质日期-预警时间
    '允许出库日期=生产日期+内控保质期（字段tb_warning_keepdays）（天）
    Private Function EndRq(ByVal zhbzq As Date) As Date
        Dim sql As String = " select tb_warning_keepdays from tb_warning where tb_warning_dm ='" & tb_i259b_i231a.Text & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            'EndRq = DateAndTime.DateAdd(DateInterval.Day, -1 * dt.Rows(0)("tb_warning_rq"), zhbzq)
            EndRq = DateAndTime.DateAdd(DateInterval.Day, dt.Rows(0)("tb_warning_keepdays"), zhbzq)
        Else
            EndRq = Now.Date
        End If
    End Function
    Private Sub sfbh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sfbh.SelectedIndexChanged
        Select Case sfbh.SelectedIndex
            Case 0
                combox1()
                cz()
        End Select
    End Sub
    Private Sub combox1() '向采购界面传值

        If MsgBox("是否选择补货？", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim nform As New Frcg
        Dim sql As String = "select tb_cg_qgbm,tb_cg_qgr,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_ysbm,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_yqdhrq,tb_cg_qgdsxrq,tb_cg_gysmc,tb_cg_qgbz,tb_cg_wpbz ,tb_cg_yszq1,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_dj,tb_cg_gysmc, tb_cg_dgzl ,tb_cg_qyfy ,tb_cg_zj ,tb_cg_fzr, tb_cg_yjdhl1, tb_cg_yjdhrq1,tb_cg_cgdh,tb_cg_wpfl,tb_cg_jhdh,tb_cg_cgbz,tb_cg_scs from tb_cg where tb_cg_cgdh ='" & tb_i259b_cgdh.Text & "' and tb_cg_dm='" & tb_i259b_i231a.Text & "'  and tb_cg_jhdh='" & tb_i259b_jhdh.Text & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        nform.tb_cg_qgbm.Text = dt.Rows(0)("tb_cg_qgbm")
        nform.tb_cg_qgr.Text = dt.Rows(0)("tb_cg_qgr")
        nform.tb_cg_gsmc.Text = dt.Rows(0)("tb_cg_gsmc")
        nform.tb_cg_dm.Text = dt.Rows(0)("tb_cg_dm")
        nform.tb_cg_pm.Text = dt.Rows(0)("tb_cg_pm")
        nform.tb_cg_ggxh.Text = dt.Rows(0)("tb_cg_ggxh")
        nform.tb_cg_dw.Text = dt.Rows(0)("tb_cg_dw")
        nform.tb_cg_wllb.Text = dt.Rows(0)("tb_cg_wllb")
        nform.tb_cg_ysbm.Text = dt.Rows(0)("tb_cg_ysbm")
        nform.tb_cg_jhdh.Text = dt.Rows(0)("tb_cg_jhdh") '计划单号
        nform.tb_cg_cgdh.Text = dt.Rows(0)("tb_cg_cgdh")
        nform.tb_cg_qgsl.Text = dt.Rows(0)("tb_cg_qgsl")
        nform.tb_cg_ysje.Text = dt.Rows(0)("tb_cg_ysje")
        nform.tb_cg_yqyt.Text = dt.Rows(0)("tb_cg_yqyt")
        nform.tb_cg_qgdsxrq.Text = dt.Rows(0)("tb_cg_qgdsxrq")
        nform.tb_cg_yqdhrq.Text = dt.Rows(0)("tb_cg_yqdhrq")
        nform.tb_cg_gysmc.Text = Null2String(dt.Rows(0)("tb_cg_gysmc"))
        nform.tb_cg_wpbz.Text = Null2String(dt.Rows(0)("tb_cg_wpbz"))
        nform.tb_cg_qgbz.Text = Null2String(dt.Rows(0)("tb_cg_qgbz"))
        nform.tb_cg_yszq1.Text = dt.Rows(0)("tb_cg_yszq1")
        nform.tb_cg_qgrq.Text = dt.Rows(0)("tb_cg_qgrq")
        nform.tb_cg_qgzt.Text = dt.Rows(0)("tb_cg_qgzt")
        nform.tb_cg_qgdsfsx.Text = dt.Rows(0)("tb_cg_qgdsfsx")
        nform.tb_cg_dj.Text = dt.Rows(0)("tb_cg_dj")
        nform.tb_cg_gysmc.Text = dt.Rows(0)("tb_cg_gysmc")
        nform.tb_cg_dgzl.Text = dt.Rows(0)("tb_cg_dgzl")
        nform.tb_cg_qyfy.Text = dt.Rows(0)("tb_cg_qyfy")
        nform.tb_cg_zj.Text = dt.Rows(0)("tb_cg_zj")
        nform.tb_cg_fzr.Text = dt.Rows(0)("tb_cg_fzr")
        nform.tb_cg_yjdhl1.Text = dt.Rows(0)("tb_cg_yjdhl1")
        nform.tb_cg_yjdhrq1.Value = dt.Rows(0)("tb_cg_yjdhrq1")
        nform.tb_cg_wpfl.Text = Null2String(dt.Rows(0)("tb_cg_wpfl"))
        nform.tb_cg_cgbz.Text = Null2String(dt.Rows(0)("tb_cg_cgbz"))
        nform.tb_cg_scs.Text = Null2String(dt.Rows(0)("tb_cg_scs"))
        nform.tb_cg_rq.Value = Now.Date
        nform.tb_cg_rq.Enabled = False
        nform.tb_cg_dgzl.ReadOnly = True
        nform.tb_cg_zj.ReadOnly = True
        nform.tb_cg_fzr.Enabled = False
        nform.tb_cg_yszq1.ReadOnly = True
        nform.tb_cg_yjdhrq1.Visible = True
        nform.tb_cg_yjdhl1.Visible = True
        nform.tb_cg_yjdhrq2.Visible = False
        nform.tb_cg_yjdhl2.Visible = False
        nform.tb_cg_yjdhrq3.Visible = False
        nform.tb_cg_yjdhl3.Visible = False
        nform.tb_cg_yszq1.Visible = True
        nform.tb_cg_yszq2.Visible = False
        nform.tb_cg_yszq3.Visible = False
        nform.Label13.Visible = True
        nform.Label14.Visible = False
        nform.Label16.Visible = True
        nform.Label17.Visible = False
        nform.Label15.Visible = False
        nform.Label18.Visible = False
        nform.Label33.Visible = False
        nform.Label32.Visible = True
        nform.Label34.Visible = False
        nform.Button2.Enabled = False
        nform.tb_cg_cgdh.ReadOnly = True
        nform.tb_cg_fqcs.Enabled = False
        nform.tb_cg_sfbh.Text = "补货"

        nform.id = ""
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' '
        nform.tb_cg_fqcs.SelectedIndex = 0
        nform.tb_cg_qyfy.Text = 0
        nform.tb_cg_fzr.SelectedIndex = 0
        nform.tb_cg_yszq1.Text = 3
        nform.tb_cg_yszq2.Text = 3
        nform.tb_cg_yszq3.Text = 3

        Dim h As String = ""
        Dim dth As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cg_ID from tb_cg where tb_cg_cgdh ='" & nform.tb_cg_cgdh.Text & "' and tb_cg_dm='" & nform.tb_cg_dm.Text & "'")
        Select Case dth.Rows.Count + 1
            Case 1
                h = "-Ⅰ"
            Case 2
                h = "-Ⅱ"
            Case 3
                h = "-Ⅲ"
            Case 4
                h = "-Ⅳ"
            Case 5
                h = "-Ⅴ"
            Case 6
                h = "-Ⅵ"
        End Select
        Dim sqlq As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz)"
        sqlq &= "values('" & nform.tb_cg_qgbm.Text & "','" & nform.tb_cg_qgr.Text & "','" & nform.tb_cg_cgdh.Text & "','" & nform.tb_cg_cgdh.Text & h & "','" & nform.tb_cg_gsmc.Text & "','" & nform.tb_cg_dm.Text & "','" & nform.tb_cg_pm.Text & "','" & nform.tb_cg_ggxh.Text & "','" & nform.tb_cg_dw.Text & "','" & nform.tb_cg_wllb.Text & "','" & GF_gettrqsj(nform.tb_cg_yjdhrq1.Value) & "'," & nform.tb_cg_yjdhl1.Text & "," & nform.tb_cg_qgsl.Text & ",'" & nform.tb_cg_yqyt.Text & "'," & nform.tb_cg_ysje.Text & ",'" & GF_gettrqsj(nform.tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(nform.tb_cg_yqdhrq.Text) & "','" & nform.tb_cg_fzr.Text & "','" & GF_gettrqsj(nform.tb_cg_rq.Value) & "','" & nform.tb_cg_gysmc.Text & "'," & nform.tb_cg_dgzl.Text & "," & nform.tb_cg_dj.Text & "," & nform.tb_cg_qyfy.Text & "," & nform.tb_cg_zj.Text & ",'" & nform.tb_cg_fqcs.Text & "','" & nform.tb_cg_ysbm.Text & "','" & nform.tb_cg_sfbh.Text & "','" & nform.tb_cg_yszq1.Text & "','" & nform.tb_cg_qgbz.Text & "','" & nform.tb_cg_wpbz.Text & "','" & nform.tb_cg_qgrq.Text & "','" & nform.tb_cg_qgzt.Text & "','" & nform.tb_cg_qgdsfsx.Text & "','" & nform.tb_cg_wpfl.Text & "','" & nform.tb_cg_sbid.Text & "','" & nform.tb_cg_jhdh.Text & "','" & nform.tb_cg_cgbz.Text & "')"
        Dim idstring As String = GF_upztxx2(G_cnnstr, sqlq, "tb_cg")
        Me.Close()
    End Sub
    Private Function cxph(ByVal num As String) As Boolean

        Dim str As String = "select tb_i259b_id from tb_i259b where   tb_i259b_num ='" & num & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, str)
        If dt.Rows.Count > 0 Then
            cxph = True
        Else
            cxph = False
        End If
    End Function

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            tb_i259b_ckcl.Text = tb_i259b_ckcl.Tag - CDbl(i259b_ckcl2.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_i259b_sfqj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_i259b_sfqj.SelectedIndexChanged
        If tb_i259b_sfqj.SelectedIndex = 1 Then
            tb_i259b_qaspjg.Text = "合格"
        Else
            tb_i259b_qaspjg.Text = "待定"
        End If
    End Sub

    Private Sub tb_i259b_ckcl_TextChanged(sender As Object, e As EventArgs) Handles i259b_ckcl2.TextChanged, i259b_ckcl3.TextChanged
        Dim objName As String = CType(sender, TextBox).Name
        Select Case objName
            Case "i259b_ckcl2"
                tb_i259b_ckcl.Text = m_ckcl - _S.YanFormatNum(i259b_ckcl2.Text) - _S.YanFormatNum(i259b_ckcl3.Text)
            Case "i259b_ckcl3"
                tb_i259b_ckcl.Text = m_ckcl - _S.YanFormatNum(i259b_ckcl2.Text) - _S.YanFormatNum(i259b_ckcl3.Text)
        End Select
    End Sub

    Private Sub tb_i259b_qjrq_ValueChanged(sender As System.Object, e As System.EventArgs) Handles tb_i259b_qjrq.ValueChanged
        changeDate()
    End Sub
    Public Sub changeDate()
        Dim sql As String = "select tb_wp_njzq from tb_wp where tb_wp_dm ='" & Me.tb_i259b_i231a.Text & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim day As Int32 = 0

        If dt.Rows.Count > 0 Then
            day = Convert.ToInt32(dt.Rows(0)(0).ToString())
        End If

        tb_i259b_f122x.Value = tb_i259b_qjrq.Value.AddDays(day + 1)
    End Sub
End Class