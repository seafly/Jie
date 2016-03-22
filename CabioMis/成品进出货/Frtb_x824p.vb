Public Class Frtb_x824p
    Private g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效' order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ")
    Public cpxz As String = ""
    Private Sub Frtb_x824p_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ComboBox2.SelectedIndex = 0

        '''''''''''''''''''''''''''''''''''''''用途下拉框
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        YgOne.Items.Clear()
        Call GS_wlbktlr2(YgOne, kk, 1, "生产")
        Call GS_wlbktlr2(YgTwo, kk, 1, "生产")
        Call GS_wlbktlr2(YgFour, kk, 1, "生产")
        Call GS_wlbktlr2(YgThree, kk, 1, "生产")

        ''''''''''''''''''''''''''''''''''''获取产品性质
        Dim bm As String = Labeltb.Text '生产表
        Select Case bm
            Case "tb_h195z"
                YgOne.Text = "生产"
                cpxz = "成品油"
                Me.Text = "成品油入库"
            Case "tb_x832p"
                YgOne.Text = "销售"
                cpxz = "成品粉"
                Me.Text = "成品粉入库"
            Case "tb_x825p"
                cpxz = "毛油"
                Me.Text = "毛油入库"
        End Select

        Dim bmid As String = Labelid.Text
        Dim sql As String = "select " & bm & "_qaspjg," & bm & "_qajgsm," & bm & "_cplb," & bm & "_bzxs," & bm & "_mingc," & bm & "_jiagdm," & bm & "_jgrq from " & bm & " where " & bm & "_id=" & bmid
        kk = GF_CreateDataSource(G_cnnstr, sql)
        Label9.Text = "QA结果:" & kk.Rows(0)(0)
        Label8.Text = "QA结果说明:" & Null2String(kk.Rows(0)(1))
        ComboBox1.Text = Null2String(kk.Rows(0)(2)) '产品类型
        CpdmOne.Text = Null2String(kk.Rows(0)(4)) '产品代码
        JgdmOne.Text = Null2String(kk.Rows(0)(5)) '加工代码
        BzxsOne.Text = Null2String(kk.Rows(0)(3)) '包装形式
        scsj.Text = kk.Rows(0)(bm & "_jgrq")   '生产时间

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='" & cpxz & "'and tb_cpdmhz_cplx='" & ComboBox1.Text & "'")
        GS_bcfbd(dt, 2, CpdmOne)
        GS_wlbktlr4(JgdmOne, (_D.YanDttoStr(dt, "tb_cpdmhz_jgdm") & ",型式检测样品,商检样品,客户样品,分装损耗").Split(","))


        KcTwo.Text = "0" : KcFour.Text = "0"
        KcThree.Text = "0" : RktsOne.Text = "0"
        RktsTwo.Text = "0" : RktsThree.Text = "0"
        RktsFour.Text = "0"
        '''''''''''''''''''''''''''''''''''''''''''''''


        ''''''''''''''''''''''''''''''''''''''''''

        GS_qhjd(Me) '回车键切换焦点，备注除外

    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If KcOne.Text < 0 Then
            MsgBox("数字输入有误！")
            Exit Sub
        End If

        '更新毛油或者成品油表

        Dim fn As String = Labeltb.Text
        Dim kcc, rkts As Double
        If RktsOne.Text.Trim = "" Then
            rkts = 0
        Else
            rkts = RktsOne.Text.Trim
        End If
        Try
            kcc = KcOne.Text
        Catch ex As Exception
            MsgBox("请正确填写数字") : Exit Sub
        End Try
        'Try
        '’‘’‘’‘’‘’‘’
        If GF_storelog2("进货：" & ph.Text, "进货") = False Then
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        Dim jiagdm() As String = {JgdmOne.Text, JgdmTwo.Text, JgdmThree.Text, JgdmFour.Text} '加工代码
        Dim cpdm() As String = {CpdmOne.Text, CpdmTwo.Text, CpdmThree.Text, CpdmFour.Text} '产品代码
        Dim sykczl() As String = {KcOne.Text, KcTwo.Text, KcThree.Text, KcFour.Text} '入库数量
        Dim sykczlTag() As String = {KcOne.Tag, KcTwo.Tag, KcThree.Tag, KcFour.Tag}
        Dim yg() As String = {YgOne.Text, YgTwo.Text, YgThree.Text, YgFour.Text} '用途
        Dim bzxs() As String = {BzxsOne.Text, BzxsTwo.Text, BzxsThree.Text, BzxsFour.Text} '包装形式
        Dim cw() As String = {CwOne.Text, CwTwo.Text, CwThree.Text, CwFour.Text} '葛店仓位
        Dim mscw() As String = {mscw1.Text, mscw2.Text, mscw3.Text, mscw4.Text} '庙山仓位
        Dim wzcw() As String = {wzcw1.Text, wzcw2.Text, wzcw3.Text, wzcw4.Text} '外租仓位
        Dim bfcw() As String = {bfcw1.Text, bfcw2.Text, bfcw3.Text, bfcw4.Text} '北方仓位
        Dim Rktss() As String = {RktsOne.Text, RktsTwo.Text, RktsThree.Text, RktsFour.Text} '库存桶/箱数
        Dim storage() As Control = {StorageOne, StorageTwo, StorageThree, StorageFour} '冷库

        '***********************************************成品入库操作
        Dim Kcid As String
        Dim Jchid As String = ""
        Dim xbid As String = ""
        Dim sql As String
        Dim sql0 As String
        Dim dt0 As DataTable

        '成品粉多批次的加工代码和产品代码不能重复
        'If fn = "tb_x832p" Then
        Dim dtTm As New DataTable
        dtTm.Columns.Add("jgdm")
        dtTm.Columns.Add("cpdm")
        dtTm.Columns.Add("xh", GetType(Integer))

        For i As Integer = 0 To ComboBox2.SelectedIndex
            If _D.GF_CreateDataSource("select  " & fn & "kc_id  from " & fn & "kc where " & fn & "kc_cplb = '" & ComboBox1.Text & "'and " & fn & "kc_mingc= '" &
                                      cpdm(i) & "' and " & fn & "kc_jiagdm= '" & jiagdm(i) & "'and " & fn & "kc_num = '" & ph.Text & "'").Rows.Count > 0 Then
                MessageBox.Show(ph.Text & "," & ComboBox1.Text & "," & cpdm(i) & "," & jiagdm(i) & "已存在！")
                Exit Sub
            End If
            dtTm.Rows.Add({jiagdm(i), cpdm(i), i})
        Next
        For i As Integer = 0 To ComboBox2.SelectedIndex
            If dtTm.Select("jgdm='" & jiagdm(i) & "' and cpdm='" & cpdm(i) & "' and xh<>" & i).Length > 0 Then
                MessageBox.Show("多批次的加工代码和产品代码不能重复")
                Exit Sub
            End If
        Next
        For i As Integer = 0 To ComboBox2.SelectedIndex
            If storage(i).Text = "" Then
                MessageBox.Show("第" & i + 1 & "批没有输入相关的冷库信息.", "冷库输入")
                Exit Sub
            End If
        Next
        'End If
        Using yMt As New _D.myTransaction
            For i As Integer = 0 To ComboBox2.SelectedIndex
                Select Case fn
                    Case "tb_h195z"   '成品油入库'''''''''''''''''''''''''''''''''''''''''''''''''''
                        sql0 = "select  tb_h195zkc_id from tb_h195zkc where tb_h195zkc_cplb = '" & ComboBox1.Text & "'and  tb_h195zkc_mingc= '" & cpdm(i) &
                            "' and  tb_h195zkc_jiagdm= '" & jiagdm(i) & "'and  tb_h195zkc_num = '" & ph.Text & "'"
                        dt0 = yMt.getDb(sql0)
                        If dt0.Rows.Count > 0 Then
                            '' 累加
                            'sql = "update  tb_h195zkc set  tb_h195zkc_sykczl = tb_h195zkc_sykczl+ " & sykczl(i) & " , tb_h195zkc_ckcl = tb_h195zkc_ckcl+ " & sykczl(i) &
                            '    " , tb_h195zkc_kczl = tb_h195zkc_kczl+ " & sykczl(i) & "  where tb_h195zkc_id = '" & dt0.Rows(0)("tb_h195zkc_id") & "' "
                            'GS_upztxx(G_cnnstr, sql)
                            'Dim a As String = GF_ZlNew(storage(i)) '转为负数
                            'If ReturnTbname(dt0.Rows(0)("tb_h195zkc_id"), fn & "kc", a, storage(i).Tag) = False Then
                            '    Exit Sub
                            'End If
                            MessageBox.Show(ph.Text & "," & ComboBox1.Text & "," & cpdm(i) & "," & jiagdm(i) & "已存在！")
                            Exit Sub
                        Else
                            '添加
                            sql = "insert into tb_h195zkc(tb_h195zkc_num2,tb_h195zkc_num,tb_h195zkc_jgrq,tb_h195zkc_m408e,tb_h195zkc_e95w,tb_h195zkc_o460g,tb_h195zkc_p495h," &
                                "tb_h195zkc_y878r,tb_h195zkc_c998u,tb_h195zkc_g179y,tb_h195zkc_b989t,tb_h195zkc_n426f,tb_h195zkc_s621k,tb_h195zkc_u704m,tb_h195zkc_q554i," &
                                "tb_h195zkc_t673l,tb_h195zkc_bz,tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u," &
                                "tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v," &
                                "tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_rkts,tb_h195zkc_sbtb,tb_h195zkc_sbid,tb_h195zkc_glid,tb_h195zkc_xbtb," &
                                "tb_h195zkc_czrgh,tb_h195zkc_o460gt,tb_h195zkc_y878rt,tb_h195zkc_g179yt,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_y876r," &
                                "tb_h195zkc_qcsh,tb_h195zkc_bf,tb_h195zkc_bfmx,tb_h195zkc_zfbz,tb_h195zkc_tpyy,tb_h195zkc_llzph,tb_h195zkc_llzzl,tb_h195zkc_llzpht," &
                                "tb_h195zkc_pf,tb_h195zkc_ybd5kgph,tb_h195zkc_ybd5kgzl,tb_h195zkc_ybd5kgpht,tb_h195zkc_ypybdph,tb_h195zkc_ypybdzl,tb_h195zkc_ypybdpht," &
                                "tb_h195zkc_wgbh,tb_h195zkc_wjbgrq,tb_h195zkc_dry,tb_h195zkc_sykcsm,tb_h195zkc_sykczl,tb_h195zkc_yg,tb_h195zkc_ckcl,tb_h195zkc_rkbz," &
                                "tb_h195zkc_cw,tb_h195zkc_bzxs,tb_h195zkc_kczl,tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,tb_h195zkc_hblsrkbz," &
                                "tb_h195zkc_hblsrkzl,tb_h195zkc_rkrq,tb_h195zkc_mscw,tb_h195zkc_wzcw,tb_h195zkc_bfcw) "
                            sql &= "select tb_h195z_num2,tb_h195z_num,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r," &
                                "tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l," &
                                "tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c," &
                                "tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v," &
                                "tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm, " & Rktss(i) & ",'tb_h195z'," & Labelid.Text & ",null,null," &
                                "tb_h195z_czrgh,tb_h195z_o460gt,tb_h195z_y878rt,tb_h195z_g179yt,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_y876r,tb_h195z_qcsh," &
                                "tb_h195z_bf,tb_h195z_bfmx,tb_h195z_zfbz,tb_h195z_tpyy,tb_h195z_llzph,tb_h195z_llzzl,tb_h195z_llzpht,tb_h195z_pf,tb_h195z_ybd5kgph," &
                                "tb_h195z_ybd5kgzl,tb_h195z_ybd5kgpht,tb_h195z_ypybdph,tb_h195z_ypybdzl,tb_h195z_ypybdpht,tb_h195z_wgbh,tb_h195z_wjbgrq," &
                                "tb_h195z_dry,tb_h195z_sykcsm, " & sykczl(i) & ",'" & yg(i) & "'," & sykczl(i) & ",'" & tb_x825p_rkbz.Text & "','" & cw(i) & "', '" &
                                bzxs(i) & "'," & sykczl(i) & ",'" & ComboBox1.Text & "','" & cpdm(i) & "','" & jiagdm(i) & "',1,0,'" & sj.Text & "','" &
                                mscw(i) & "','" & wzcw(i) & "','" & bfcw(i) & "' from vw_h195z where tb_h195z_id = '" & Labelid.Text & "'"
                            Kcid = yMt.dbExe(sql, 1)
                            '添加冷库数据
                            UpdateTbname(Kcid, fn & "kc", storage(i).Text, storage(i).Tag,yMt)
                            '集成下步ID
                            xbid &= Kcid & ","
                        End If
                        '扣湖北转库数量
                        'Dim sql2 As String = "update " & fn & " set " & fn & "_hblsrkzl= " & fn & "_hblsrkzl - " & sykczl(i) & " where " & fn & "_ID=" & Labelid.Text & ""
                        'yMt.dbExe(sql2)
                    Case "tb_x825p"   '毛油入库''''''''''''''''''''''''''''''''''''''''''
                        sql0 = "select tb_x825pkc_id from tb_x825pkc where tb_x825pkc_cplb = '" & ComboBox1.Text & "'and tb_x825pkc_mingc= '" & cpdm(i) & "' and tb_x825pkc_jiagdm= '" & jiagdm(i) & "'and tb_x825pkc_num = '" & ph.Text & "'"
                        dt0 = yMt.getDb(sql0)

                        If dt0.Rows.Count > 0 Then
                            '' 累加、增加可用数量和仓库存量,库存重量
                            'sql = "update tb_x825pkc set  tb_x825pkc_sykczl = tb_x825pkc_sykczl+ " & sykczl(i) & " , tb_x825pkc_ckcl =tb_x825pkc_ckcl+ " & sykczl(i) &
                            '    " ,tb_x825pkc_kczl =tb_x825pkc_kczl+ " & sykczl(i) & "  where tb_x825pkc_id = '" & dt0.Rows(0)(0) & "' "
                            'GS_upztxx(G_cnnstr, sql)
                            'Dim a As String = GF_ZlNew(storage(i)) '转为负数
                            'If ReturnTbname(dt0.Rows(0)("tb_x825pkc_id"), fn & "kc", a, storage(i).Tag) = False Then
                            '    Exit Sub
                            'End If
                            MessageBox.Show(ph.Text & "," & ComboBox1.Text & "," & cpdm(i) & "," & jiagdm(i) & "已存在！")
                            Exit Sub
                        Else
                            '添加
                            sql = "  insert into tb_x825pkc " & vbCrLf
                            sql &= " ("
                            sql &= " tb_x825pkc_num2, tb_x825pkc_num, tb_x825pkc_jgrq, tb_x825pkc_r583j  " & vbCrLf
                            sql &= " ,tb_x825pkc_s640k,tb_x825pkc_qcrq,tb_x825pkc_q547i,tb_x825pkc_u699m " & vbCrLf
                            sql &= " ,tb_x825pkc_r600j,tb_x825pkc_o479g,tb_x825pkc_b959t,tb_x825pkc_m387e " & vbCrLf
                            sql &= " ,tb_x825pkc_qarq,tb_x825pkc_qaspjg,tb_x825pkc_qajgsm,tb_x825pkc_rkts " & vbCrLf
                            sql &= " ,tb_x825pkc_sbtb,tb_x825pkc_sbid,tb_x825pkc_xbtb,tb_x825pkc_glid " & vbCrLf
                            sql &= " ,tb_x825pkc_czrgh,tb_x825pkc_qcczrgh,tb_x825pkc_qaczrgh,tb_x825pkc_r602j " & vbCrLf
                            sql &= " , tb_x825pkc_sn,tb_x825pkc_bz,tb_x825pkc_qcsh,tb_x825pkc_mynetaa " & vbCrLf
                            sql &= " ,tb_x825pkc_gjtzy,tb_x825pkc_bf,tb_x825pkc_bfmx,tb_x825pkc_zfbz " & vbCrLf
                            sql &= ",tb_x825pkc_t686m,tb_x825pkc_wgbh,tb_x825pkc_wjbgrq " & vbCrLf
                            sql &= " ,tb_x825pkc_sykczl,tb_x825pkc_yg,tb_x825pkc_ckcl,tb_x825pkc_rkbz,tb_x825pkc_cw" & vbCrLf
                            sql &= " ,tb_x825pkc_bzxs,tb_x825pkc_kczl" & vbCrLf
                            sql &= " ,tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,tb_x825pkc_rkrq,tb_x825pkc_mscw,tb_x825pkc_wzcw,tb_x825pkc_bfcw" & vbCrLf
                            sql &= ") " & vbCrLf
                            sql &= " select  tb_x825p_num2, tb_x825p_num, tb_x825p_jgrq, tb_x825p_r583j " & vbCrLf
                            sql &= " ,tb_x825p_s640k,tb_x825p_qcrq,tb_x825p_q547i,tb_x825p_u699m " & vbCrLf
                            sql &= " ,tb_x825p_r600j,tb_x825p_o479g,tb_x825p_b959t,tb_x825p_m387e " & vbCrLf
                            sql &= " ,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm," & Rktss(i) & " " & vbCrLf
                            sql &= " ,'tb_x825p'," & Labelid.Text & ",null,null" & vbCrLf
                            sql &= " ,tb_x825p_czrgh,tb_x825p_qcczrgh,tb_x825p_qaczrgh,tb_x825p_r602j " & vbCrLf
                            sql &= " ,tb_x825p_sn,tb_x825p_bz,tb_x825p_qcsh,tb_x825p_mynetaa " & vbCrLf
                            sql &= " ,tb_x825p_gjtzy,tb_x825p_bf,tb_x825p_bfmx,tb_x825p_zfbz " & vbCrLf
                            sql &= " ,tb_x825p_t686m,tb_x825p_wgbh,tb_x825p_wjbgrq " & vbCrLf
                            sql &= " , " & sykczl(i) & ",'" & yg(i) & "'," & sykczl(i) & ",'" & tb_x825p_rkbz.Text & "' " & vbCrLf
                            sql &= " ,'" & cw(i) & "', '" & bzxs(i) & "'," & sykczl(i) & ",'" & ComboBox1.Text & "' " & vbCrLf
                            sql &= " ,'" & cpdm(i) & "','" & jiagdm(i) & "','" & sj.Text & "','" & mscw(i) & "','" & wzcw(i) & "','" & bfcw(i) & "'  " & vbCrLf
                            sql &= " from tb_x825p  where tb_x825p_num = '" & ph.Text & "'" & vbCrLf
                            Kcid = yMt.dbExe(sql, 1)
                            '添加冷库数据
                            UpdateTbname(Kcid, fn & "kc", storage(i).Text, storage(i).Tag, yMt)
                            '集成下步ID
                            xbid &= Kcid & ","
                        End If
                        '扣湖北转库数量
                        'Dim sql2 As String = "update " & fn & " set " & fn & "_hblsrkzl= " & fn & "_hblsrkzl - " & sykczl(i) & " where " & fn & "_ID=" & Labelid.Text & ""
                        'yMt.dbExe(sql2)
                    Case "tb_x832p"   '成品粉入库''''''''''''''''''''''''''''''''''''''''''''''''
                        sql0 = "select  tb_x832pkc_id  from tb_x832pkc where tb_x832pkc_cplb = '" & ComboBox1.Text & "'and tb_x832pkc_mingc= '" & cpdm(i) & "' and tb_x832pkc_jiagdm= '" & jiagdm(i) & "'and tb_x832pkc_num = '" & ph.Text & "'"
                        dt0 = yMt.getDb(sql0)
                        If dt0.Rows.Count > 0 Then
                            MessageBox.Show(ph.Text & "," & ComboBox1.Text & "," & cpdm(i) & "," & jiagdm(i) & "已存在！")
                            Exit Sub
                        Else
                            '添加
                            sql = "insert into tb_x832pkc(tb_x832pkc_num,tb_x832pkc_num2,tb_x832pkc_y864q,tb_x832pkc_l349d,tb_x832pkc_i232a,tb_x832pkc_qarq,tb_x832pkc_qaspjg,tb_x832pkc_qajgsm,tb_x832pkc_sbtb,tb_x832pkc_sbid,tb_x832pkc_xbtb,tb_x832pkc_glid,tb_x832pkc_czrgh,tb_x832pkc_bz,tb_x832pkc_qaczrgh,tb_x832pkc_qcrq,tb_x832pkc_d65v,tb_x832pkc_a948s,tb_x832pkc_n422f,tb_x832pkc_s624k,tb_x832pkc_s644l,tb_x832pkc_c995u,tb_x832pkc_s613k,tb_x832pkc_m381e,tb_x832pkc_j284b,tb_x832pkc_c12u,tb_x832pkc_f119x,tb_x832pkc_s626k,tb_x832pkc_e106x,tb_x832pkc_n446f,tb_x832pkc_h199z,tb_x832pkc_o468g,tb_x832pkc_u691m,tb_x832pkc_c16u,tb_x832pkc_k308c,tb_x832pkc_r599j,tb_x832pkc_d39v,tb_x832pkc_qcczrgh,tb_x832pkc_rkts,tb_x832pkc_jgrq,tb_x832pkc_qcsh,tb_x832pkc_lzlt,tb_x832pkc_ltzl,tb_x832pkc_bf,tb_x832pkc_bfmx,tb_x832pkc_a920s,tb_x832pkc_z886r,tb_x832pkc_scdm,tb_x832pkc_ybdph,tb_x832pkc_ybdzl,tb_x832pkc_ybdpht,tb_x832pkc_ypybdph,tb_x832pkc_ypybdzl,tb_x832pkc_ypybdpht,tb_x832pkc_sjqa,tb_x832pkc_kss,tb_x832pkc_nxam,tb_x832pkc_th,tb_x832pkc_wjbgrq,tb_x832pkc_sykczl,tb_x832pkc_yg,tb_x832pkc_ckcl,tb_x832pkc_rkbz,tb_x832pkc_cw,tb_x832pkc_bzxs,tb_x832pkc_kczl,tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,tb_x832pkc_rkrq,tb_x832pkc_mscw,tb_x832pkc_wzcw,tb_x832pkc_bfcw) "
                            sql &= "select tb_x832p_num,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,'tb_x832p'," & Labelid.Text & ",null,null,tb_x832p_czrgh,tb_x832p_bz,tb_x832p_qaczrgh,tb_x832p_qcrq,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_n422f,tb_x832p_s624k,tb_x832p_s644l,tb_x832p_c995u,tb_x832p_s613k,tb_x832p_m381e,tb_x832p_j284b,tb_x832p_c12u,tb_x832p_f119x,tb_x832p_s626k,tb_x832p_e106x,tb_x832p_n446f,tb_x832p_h199z,tb_x832p_o468g,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_k308c,tb_x832p_r599j,tb_x832p_d39v,tb_x832p_qcczrgh," & Rktss(i) & ",tb_x832p_jgrq,tb_x832p_qcsh,tb_x832p_lzlt,tb_x832p_ltzl,tb_x832p_bf,tb_x832p_bfmx,tb_x832p_a920s,tb_x832p_z886r,tb_x832p_scdm,tb_x832p_ybdph,tb_x832p_ybdzl,tb_x832p_ybdpht,tb_x832p_ypybdph,tb_x832p_ypybdzl,tb_x832p_ypybdpht,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_th,tb_x832p_wjbgrq," & sykczl(i) & ",'" & yg(i) & "'," & sykczl(i) & ",'" & tb_x825p_rkbz.Text & "','" & cw(i) & "', '" & bzxs(i) & "'," & sykczl(i) & ",'" & ComboBox1.Text & "','" & cpdm(i) & "','" & jiagdm(i) & "','" & sj.Text & "','" & mscw(i) & "','" & wzcw(i) & "','" & bfcw(i) & "' from vw_x832p where tb_x832p_num = '" & ph.Text & "'"
                            Kcid = yMt.dbExe(sql, 1)
                            UpdateTbname(Kcid, fn & "kc", storage(i).Text, storage(i).Tag,yMt) '添加冷库数据
                            xbid &= Kcid & ","
                        End If
                End Select
                '  保存到进出货表
                Dim cpnb As String = ComboBox1.Text
                Dim sql3 As String = "Insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_chts,tb_jch_yt,tb_jch_czrgh) values('" & cpnb & "','" & cpdm(i) & "','" & jiagdm(i) & "','" & ph.Text & "','进'," & sykczl(i) & ",'" & sj.Text & "','" & tb_x825p_rkbz.Text & "'," & rkts & ",'" & yg(i) & "','" & G_dlrgh & "')"
                '集成进出货下步ID
                Jchid &= yMt.dbExe(sql3) & ","
            Next

            xbid = GF_removedh(xbid) '库存ID
            Dim xbtb As String = fn & "kc"
            Jchid = GF_removedh(Jchid) '进出货ID

            '更新进出货表冷库信息
            If Jchid <> "" Then
                Dim JchidArray() As String = Jchid.Split(",")
                For i As Integer = 0 To UBound(JchidArray)
                    Try
                        UpdateTbname(JchidArray(i), "tb_jch", storage(i).Text, Gf_ZdNew(xbtb, "tb_jch", storage(i)),yMt)
                    Catch ex As Exception
                    End Try
                Next
            End If

            '更新成品生产表 下步id 下步表
            If xbid <> "" Then
                Dim sqlsb As String = "update " & fn & " set  " & fn & "_xbtb= '" & xbtb & "' , " & fn & "_glid= '" & xbid & "'  where  " & fn & "_id = " & Labelid.Text & " "
                yMt.dbExe(sqlsb)
            End If
            yMt.Commit
            MsgBox("更新成功！")
        End Using
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='" & cpxz & "'and tb_cpdmhz_cplx='" & ComboBox1.Text & "'")
        Select Case ComboBox2.SelectedIndex
            Case 0
                JgdmOne.Items.Clear()
                GS_bcfbd(dt, 2, CpdmOne)
                GS_tofalse("CpdmTwo,CpdmFour,CpdmThree,JgdmTwo,KcTwo,YgTwo,JgdmThree,KcThree,YgThree,JgdmFour,KcFour,YgFour,BzxsTwo,BzxsThree,BzxsFour,CwTwo,CwFour,CwThree,RktsTwo,RktsFour,RktsThree,ButtonTwo,ButtonThree,ButtonFour", False, Me)
                GS_tofalse("mscw2,mscw3,mscw4,wzcw2,wzcw3,wzcw4,bfcw2,bfcw3,bfcw4", False, Me)
                'JgdmOne.Items.Add("样品")
                GS_wlbktlr4(JgdmOne, (_D.YanDttoStr(dt, "tb_cpdmhz_jgdm") & ",型式检测样品,商检样品,客户样品,分装损耗").Split(","))
                KcTwo.Text = 0
                KcThree.Text = 0
                KcFour.Text = 0
            Case 1
                GS_bcfbd(dt, 2, CpdmOne)
                GS_bcfbd(dt, 2, CpdmTwo)
                GS_tofalse("CpdmThree,CpdmFour,JgdmThree,KcThree,YgThree,JgdmFour,KcFour,YgFour,BzxsThree,CwThree,RktsThree,BzxsFour,CwFour,RktsFour,ButtonThree,ButtonFour", False, Me)
                GS_tofalse("mscw2,mscw3,mscw4,wzcw2,wzcw3,wzcw4,bfcw2,bfcw3,bfcw4", False, Me)

                GS_tofalse("CpdmTwo,JgdmTwo,KcTwo,YgTwo,BzxsTwo,CwTwo,RktsTwo,ButtonTwo", True, Me)
                GS_tofalse("mscw2,wzcw2,bfcw2", True, Me)
                MessageBox.Show("请确定入库重量是否正确，确定后才可以入库")
                KcThree.Text = 0
                KcFour.Text = 0
            Case 2
                GS_bcfbd(dt, 2, CpdmOne)
                GS_bcfbd(dt, 2, CpdmTwo)
                GS_bcfbd(dt, 2, CpdmThree)
                ''''''''
                GS_tofalse("CpdmTwo,CpdmThree,JgdmTwo,KcTwo,YgTwo,JgdmThree,KcThree,YgThree,BzxsThree,BzxsTwo,CwThree,CwTwo,RktsTwo,RktsThree,ButtonTwo,ButtonThree", True, Me)
                GS_tofalse("CpdmFour,JgdmFour,KcFour,YgFour,BzxsFour,CwFour,RktsFour,ButtonFour", False, Me)

                GS_tofalse("mscw2,mscw3,mscw4,wzcw2,wzcw3,wzcw4,bfcw2,bfcw3,bfcw4", True, Me)
                GS_tofalse("mscw4,wzcw4,bfcw4", False, Me)
                MessageBox.Show("请确定入库重量是否正确，确定后才可以入库")
                KcFour.Text = 0
            Case 3
                GS_bcfbd(dt, 2, CpdmOne)
                GS_bcfbd(dt, 2, CpdmTwo)
                GS_bcfbd(dt, 2, CpdmThree)
                GS_bcfbd(dt, 2, CpdmFour)
                GS_tofalse("CpdmTwo,CpdmFour,CpdmThree,JgdmTwo,KcTwo,YgTwo,JgdmThree,KcThree,YgThree,JgdmFour,KcFour,YgFour,BzxsFour,CwFour,RktsFour,BzxsTwo,CwThree,CwTwo,RktsTwo,RktsThree,BzxsThree,ButtonTwo,ButtonThree,ButtonFour", True, Me)
                GS_tofalse("mscw2,mscw3,mscw4,wzcw2,wzcw3,wzcw4,bfcw2,bfcw3,bfcw4", True, Me)
                MessageBox.Show("请确定入库重量是否正确，确定后才可以入库")
        End Select
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
     Handles KcOne.TextChanged, KcTwo.TextChanged, KcThree.TextChanged, KcFour.TextChanged
        Try
            KcOne.Text = KcOne.Tag - CDbl(_S.YanFormatNum(KcTwo.Text)) - CDbl(_S.YanFormatNum(KcThree.Text)) - CDbl(_S.YanFormatNum(KcFour.Text))
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cpdm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CpdmOne.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='" & cpxz & "'and tb_cpdmhz_cplx='" & ComboBox1.Text & "'and tb_cpdmhz_cpdm='" & sender.Text & "'")
        'GS_bcfbd(dt, 3, JgdmOne)
        'JgdmOne.Items.Add("样品")
        GS_wlbktlr4(JgdmOne, (_D.YanDttoStr(dt, "tb_cpdmhz_jgdm") & ",型式检测样品,商检样品,客户样品,分装损耗").Split(","))
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CpdmTwo.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='" & cpxz & "'and tb_cpdmhz_cplx='" & ComboBox1.Text & "'and tb_cpdmhz_cpdm='" & sender.Text & "'")
        'GS_bcfbd(dt, 3, JgdmTwo)
        'JgdmTwo.Items.Add("样品")
        GS_wlbktlr4(JgdmTwo, (_D.YanDttoStr(dt, "tb_cpdmhz_jgdm") & ",型式检测样品,商检样品,客户样品,分装损耗").Split(","))
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CpdmThree.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='" & cpxz & "'and tb_cpdmhz_cplx='" & ComboBox1.Text & "'and tb_cpdmhz_cpdm='" & sender.Text & "'")
        'GS_bcfbd(dt, 3, JgdmThree)
        'JgdmThree.Items.Add("样品")
        GS_wlbktlr4(JgdmThree, (_D.YanDttoStr(dt, "tb_cpdmhz_jgdm") & ",型式检测样品,商检样品,客户样品,分装损耗").Split(","))
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CpdmFour.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='" & cpxz & "'and tb_cpdmhz_cplx='" & ComboBox1.Text & "'and tb_cpdmhz_cpdm='" & sender.Text & "'")
        'GS_bcfbd(dt, 3, JgdmFour)
        'JgdmFour.Items.Add("样品")
        GS_wlbktlr4(JgdmFour, (_D.YanDttoStr(dt, "tb_cpdmhz_jgdm") & ",型式检测样品,商检样品,客户样品,分装损耗").Split(","))
    End Sub

    Private Sub kc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        KcOne.Tag = KcOne.Text
    End Sub
    '获取冷库相关信息
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOne.Click

        If StorageOne.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的冷库信息，需要重新输入么？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        GS_Storage(Me, ButtonOne.Name.Substring(6), KcOne, Labeltb.Text & "kc", "")
    End Sub
    '获取冷库相关信息
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTwo.Click
        If StorageTwo.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的冷库信息，需要重新输入么？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        GS_Storage(Me, ButtonTwo.Name.Substring(6), KcTwo, Labeltb.Text & "kc", "")
    End Sub
    '获取冷库信息
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonThree.Click
        If StorageThree.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的冷库信息，需要重新输入么？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If
        GS_Storage(Me, ButtonThree.Name.Substring(6), KcThree, Labeltb.Text & "kc", "")
    End Sub
    '获取冷库相关信息
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFour.Click
        If StorageFour.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的冷库信息，需要重新输入么？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If
        GS_Storage(Me, ButtonFour.Name.Substring(6), KcFour, Labeltb.Text & "kc", "")
    End Sub


End Class