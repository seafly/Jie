Imports System.Linq
''' <summary>
''' 成品进出货
''' </summary>
Public Class frchuhuo
    Private m_frOpen As frzchuo = CType(Application.OpenForms.Item("frzchuo"), frzchuo)
    private m_lv2Dt As DataTable=ListviewToDatatable(m_frOpen.ListView2)
    Private m_ltCk As List(Of String) = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",").ToList
    Private g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效' order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ")
    Private Sub frchuhuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_ltCk.Remove(GetType(en_cklist).YanGetEnText(en_cklist.庙山冷库))
        m_ltCk.Remove(GetType(en_cklist).YanGetEnText(en_cklist.外租冷库))
        '朱露帆于2012年3月31日  添加各个 仓库出库功能
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Dim bm As String = Labeltb.Text '' 库存表
        tb_x825p_yg.Items.Clear()
        If kk.Rows.Count > 0 Then
            For i As Integer = 0 To kk.Rows.Count - 1
                tb_x825p_yg.Items.Add(kk.Rows(i)(1))
            Next
        End If
        Select Case bm
            Case "tb_h195zkc"  '成品油
                tb_x825p_yg.Text = "生产领料"
                tb_x825p_yg.Items.Add("湖北工厂")
            Case "tb_x825pkc" '毛油
                tb_x825p_yg.Items.Add("湖北工厂")
            Case "tb_x832pkc"   '成品粉
                tb_x825p_yg.Text = "销售"
        End Select


        Dim bmid As String = Labelid.Text
        Dim sql As String = "select " & bm & "_qaspjg," & bm & "_qajgsm," & bm & "_cplb," & bm & "_mingc," & bm & "_jiagdm, " & bm & "_ckcl," & bm & "_sykczl," & bm & "_bf from " & bm & " where " & bm & "_id=" & bmid
        kk = GF_CreateDataSource(G_cnnstr, sql)
        Labelsykc.Text = kk.Rows(0)(bm & "_sykczl") '剩余库存重量
        Label11.Text = kk.Rows(0)(bm & "_bf") '报废重量
        Label13.Text = kk.Rows(0)(bm & "_ckcl") '仓库存量 
        Label2.Text = "QA结果:" & kk.Rows(0)(0)
        Label3.Text = "QA结果说明:" & Null2String(kk.Rows(0)(1))
        ComboBox1.Text = Null2String(kk.Rows(0)(bm & "_cplb")) '产品类型
        cpdm.Text = Null2String(kk.Rows(0)(bm & "_mingc")) '产品代码
        jgdm.Text = Null2String(kk.Rows(0)(bm & "_jiagdm")) '加工代码
        jgdm.Tag = Null2String(kk.Rows(0)(bm & "_jiagdm"))
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpdm='" & cpdm.Text & "'")

        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If InStr(Label2.Text, "冻结") Then
            MessageBox.Show("产品已经冻结，无法操作!")
            Exit Sub
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If tb_x825p_yg.Text = "" Then
            MessageBox.Show("用途为空")
            Exit Sub
        End If
        Dim kcc, rkts As Double
        If chts.Text.Trim = "" Then
            rkts = 0
        End If
        Try
            kcc = kc.Text
        Catch ex As Exception
            MsgBox("请正确填写数字") : Exit Sub
        End Try

        '''''''''''''''''''''''''''''''冷库判断
        If StorageOne.Text = "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("没有输入相关的冷库信息!，确定麽？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        If tb_x825p_yg.Text = "销售" And InStr(Label2.Text, "合格") = 0 Then
            MsgBox("出库用途 为销售时，QA 结果必须是合格") : Exit Sub
        End If
        Dim bfs As Double = kc.Text '报废数量
        If CDbl(Labelsykc.Text) < CDbl(kc.Text) And (tb_x825p_yg.Text <> "销毁" And tb_x825p_yg.Text <> "报废品实验" And tb_x825p_yg.Text <> "生产领料") Then
            MsgBox("您所输入的出货量超过剩余库存重量，请重新输入！") : Exit Sub
        End If
        Dim fn As String = Labeltb.Text
        Dim cwzd As String = ""

        cwzd = fn & "_cw='" & cw.Text & "'"

        ''''''''''''''''''
        If GF_storelog2("出货：" & ph.Text, "出货") = False Then
            Exit Sub
        End If
        ''''''''''''''''' 
        '*更新“剩余库存重量”=剩余库存总量-出货量
        '*更新 销毁或者报废品试验量=报废重量-出货量（默认的出货量为销毁或者报废品试验总量）
        Dim sql As String = ""
        Dim sykczl As Double = CDbl(Labelsykc.Text) - CDbl(kc.Text)
        Dim aaa As Double = CDbl(kc.Text)
        If tb_x825p_yg.Text = "整批返工" And sykczl <> 0 Then
            MsgBox("出库用途 整批返工时，库存值应该等于剩余库存重量，请重新输入！") : Exit Sub
        End If

        Select Case tb_x825p_yg.Text
            Case "生产", "销售", "生产领料", "生产和销售"
                Dim dtas As DataTable = GF_CreateDataSource(G_cnnstr, "select " & fn & "_qaspjg from " & fn & " where " & fn & "_ID=" & Labelid.Text)
                If dtas.Rows(0)(0) = "报废" Then
                    MsgBox("该批的QA审批结果为报废，不能出库！")
                    Exit Sub
                ElseIf dtas.Rows(0)(0) = "不合格" Then
                    MsgBox("该批的QA审批结果为不合格，不能出库！")
                End If
            Case "外加工", "生产和外加工"
                Dim dtas As DataTable = GF_CreateDataSource(G_cnnstr, "select " & fn & "_qaspjg from " & fn & " where " & fn & "_ID=" & Labelid.Text)
                If dtas.Rows(0)(0) = "不合格" Then
                    MsgBox("该批的QA审批结果为不合格，不能出库！")
                    Exit Sub
                End If
        End Select

        '入库用途为锁定的毛油、成品油、成品粉，均不能以“销售、生产、生产+销售、外加工、外加工+生产”用途出库
        Select Case tb_x825p_yg.Text
            Case "生产", "销售", "生产领料", "生产和销售", "外加工", "生产和外加工"
                Dim dtas As DataTable = GF_CreateDataSource(G_cnnstr, "select " & fn & "_yg from " & fn & " where " & fn & "_ID=" & Labelid.Text)
                If dtas.Rows(0)(0) = "锁定" Then
                    MsgBox("该批入库用途为锁定，不能出库！")
                    Exit Sub
                End If
        End Select

        Using yMt As New _D.myTransaction
            '更新目标数据库（湖北）
            If tb_x825p_yg.Text = "湖北工厂" Then
                Dim dic As Dictionary(Of String, String)
                Dim sqlMt As String = ""
                Dim dtMt As DataTable = Nothing
                Dim dtBind As DataTable = Nothing
                Dim f As Frzk
                Select Case Labeltb.Text
                    Case "tb_h195zkc" '成品油转库
                        '转库到湖北工厂，那么直接弹出入库湖北的界面
                        f = New Frzk("成品油")
                        f.zkzl.Text = kcc
                        f.zkzl.Tag = kcc
                        f.m_strTb = "tb_h195zkc"
                        f.m_strPh = ph.Text
                        f.cplb.Text = m_lv2Dt.YanDtValue2("tb_h195zkc_cplb", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.mingc.Text = m_lv2Dt.YanDtValue2("tb_h195zkc_mingc", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.jiagdm.Text = m_lv2Dt.YanDtValue2("tb_h195zkc_jiagdm", m_frOpen.ListView2.SelectedItems(0).Index)
                        If f.ShowDialog <> DialogResult.OK Then
                            Return
                        End If
                        '得到结果，开始湖北入库操作
                        Dim dtRv As DataTable = f.YanDaTaGridView1.DataSource
                        dtRv.Columns.Remove("rowBs")
                        For Each tDr As DataRow In dtRv.Rows
                            sqlMt = "select * from hbcabiodb..tb_h195zkc where tb_h195zkc_num='" & ph.Text &
                            "' and tb_h195zkc_cplb='" & tDr("tb_h195zkc_cplb") &
                            "' and tb_h195zkc_mingc='" & tDr("tb_h195zkc_mingc") &
                            "' and tb_h195zkc_jiagdm='" & tDr("tb_h195zkc_jiagdm") & "'"
                            dtMt = yMt.getDb(sqlMt)
                            If dtMt.Rows.Count > 0 Then
                                '成品油中，批号代码都一样那么更新库存
                                dic = New Dictionary(Of String, String)
                                dic("tb_h195zkc_sykczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_sykczl"))) + CDbl(tDr("tb_h195zkc_kczl"))
                                dic("tb_h195zkc_ckcl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_ckcl"))) + CDbl(tDr("tb_h195zkc_kczl"))
                                dic("tb_h195zkc_kczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_kczl"))) + CDbl(tDr("tb_h195zkc_kczl"))
                                dic("tb_h195zkc_bz") = dtMt.YanDtValue2("tb_h195zkc_bz") & "," & DateTime.Now & ":" & "由湖北工厂入库" & tDr("tb_h195zkc_kczl")
                                For Each s As String In m_ltCk
                                    dic("tb_h195zkc_" & s) = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_h195zkc_" & s))) + CDbl(tDr("tb_h195zkc_" & s))
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_h195zkc", dic, "tb_h195zkc_ID=" & dtMt.YanDtValue2("tb_h195zkc_ID"))
                                yMt.dbExe(sqlMt)
                            Else
                                '没有一样的，那么先写入库存
                                sqlMt = "Insert into hbcabiodb..tb_h195zkc(tb_h195zkc_num2,tb_h195zkc_num,tb_h195zkc_cplb,tb_h195zkc_jgrq,tb_h195zkc_bz,tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u,tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v,tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_qcsh,tb_h195zkc_pf,tb_h195zkc_cw,tb_h195zkc_mingc,tb_h195zkc_jiagdm) "
                                sqlMt &= " select tb_h195zkc_num2,tb_h195zkc_num,'AOGF',tb_h195zkc_jgrq,'由武汉工厂入库',   tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u,tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v,tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_qcsh,tb_h195zkc_pf,tb_h195zkc_cw,tb_h195zkc_mingc,tb_h195zkc_jiagdm"
                                sqlMt &= " from tb_h195zkc where tb_h195zkc_ID=" & Labelid.Text & ""
                                Dim iId As Integer = yMt.dbExe(sqlMt, 1)
                                dic = New Dictionary(Of String, String)
                                dic("tb_h195zkc_cplb") = tDr("tb_h195zkc_cplb")
                                dic("tb_h195zkc_mingc") = tDr("tb_h195zkc_mingc")
                                dic("tb_h195zkc_jiagdm") = tDr("tb_h195zkc_jiagdm")
                                dic("tb_h195zkc_sykczl") = tDr("tb_h195zkc_kczl")
                                dic("tb_h195zkc_ckcl") = tDr("tb_h195zkc_kczl")
                                dic("tb_h195zkc_kczl") = tDr("tb_h195zkc_kczl")
                                dic("tb_h195zkc_bz") = DateTime.Now & ":" & "由武汉工厂入库" & tDr("tb_h195zkc_kczl")
                                For Each s As String In m_ltCk
                                    dic("tb_h195zkc_" & s) = tDr("tb_h195zkc_" & s)
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_h195zkc", dic, "tb_h195zkc_ID=" & iId)
                                yMt.dbExe(sqlMt)
                            End If
                            '写入湖北进出货
                            dic = New Dictionary(Of String, String)
                            dic("tb_jch_cplb") = tDr("tb_h195zkc_cplb")
                            dic("tb_jch_num") = ph.Text
                            dic("tb_jch_cz") = "入"
                            dic("tb_jch_sl") = tDr("tb_h195zkc_kczl")
                            dic("tb_jch_rq") = DateTime.Now
                            dic("tb_jch_yt") = "湖北工厂"
                            dic("tb_jch_bz") = tb_x825p_rkbz.Text
                            dic("tb_jch_czrgh") = G_dlrgh
                            dic("tb_jch_mingc") = tDr("tb_h195zkc_mingc")
                            dic("tb_jch_jiagdm") = tDr("tb_h195zkc_jiagdm")
                            dic("tb_jch_jiagdmsm") = jgdm.Text
                            yMt.insert("hbcabiodb..tb_jch", dic)
                        Next
                        'sqlMt = "select tb_h195z_id from hbcabiodb..tb_h195z where tb_h195z_num='" & ph.Text & "' and tb_h195z_jiagdm='" &
                        '                                            jgdm.Text & "' and tb_h195z_mingc='" & cpdm.Text & "'"
                        'dtMt = yMt.getDb(sqlMt)
                        'If dtMt.Rows.Count > 0 Then   '成品油中，批号代码都一样那么更新库存
                        '    '判断是否已经入过库了，存在下步ID
                        '    If dtMt.YanDtValue2("tb_h195z_glid") <> "" Then
                        '        '如果有一样的成品，并且入库了，那么弹出对应的库存选择界面
                        '        sqlMt = "select tb_h195zkc_num, from hbcabiodb..tb_h195zkc where tb_h195zkc_sbtb='tb_h195z' and tb_h195zkc_sbid=" & dtMt.YanDtValue2("tb_h195z_glid")
                        '        dtBind = yMt.getDb(sqlMt)
                        '        dtBind.YanDataBind(f.YanDaTaGridView1)
                        '    Else
                        '        '有一样的记录，但是没有入库，那么更新库存
                        '        MsgBox("已经有批号，代码都相同的成品存在，请在湖北工厂入库后在进行操作！")
                        '        Return
                        '        'sqlMt = "update hbcabiodb..tb_h195z set tb_h195z_cw='" & cw.Text & "',tb_h195z_m408e=tb_h195z_m408e+ " & kcc &
                        '        '    "  where tb_h195z_id='" & dtMt.YanDtValue2("tb_h195z_id") & "' "
                        '        'yMt.dbExe(sqlMt)
                        '    End If
                        'Else    '没有一样的记录，那么直接入库（插入记录）
                        '    sqlMt = "Insert into hbcabiodb..tb_h195z(tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c,tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_qcsh,tb_h195z_pf,tb_h195z_cw,tb_h195z_mingc,tb_h195z_jiagdm) "
                        '    sqlMt &= " select tb_h195zkc_num2,tb_h195zkc_num,'AOGF',tb_h195zkc_jgrq,'由新工厂入库',   tb_h195zkc_qcrq,tb_h195zkc_y855q,tb_h195zkc_c6u,tb_h195zkc_c28u,tb_h195zkc_m403e,tb_h195zkc_b991u,tb_h195zkc_k309c,tb_h195zkc_a948s,tb_h195zkc_j268b,tb_h195zkc_l356d,tb_h195zkc_o485g,tb_h195zkc_h192z,tb_h195zkc_g158y,tb_h195zkc_d36v,tb_h195zkc_qarq,tb_h195zkc_qaspjg,tb_h195zkc_qajgsm,tb_h195zkc_qcczrgh,tb_h195zkc_qaczrgh,tb_h195zkc_qcsh,tb_h195zkc_pf,tb_h195zkc_cw,tb_h195zkc_mingc,tb_h195zkc_jiagdm"
                        '    sqlMt &= " from tb_h195zkc where tb_h195zkc_ID=" & Labelid.Text & ""
                        '    yMt.dbExe(sqlMt)
                        '    '更新,
                        'End If
                    Case "tb_x825pkc" '毛油转库    
                        '转库到湖北工厂，那么直接弹出入库湖北的界面
                        f = New Frzk("毛油")
                        f.zkzl.Text = kcc
                        f.zkzl.Tag = kcc
                        f.m_strTb = "tb_x825pkc"
                        f.m_strPh = ph.Text
                        f.cplb.Text = m_lv2Dt.YanDtValue2("tb_x825pkc_cplb", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.mingc.Text = m_lv2Dt.YanDtValue2("tb_x825pkc_mingc", m_frOpen.ListView2.SelectedItems(0).Index)
                        f.jiagdm.Text = m_lv2Dt.YanDtValue2("tb_x825pkc_jiagdm", m_frOpen.ListView2.SelectedItems(0).Index)
                        If f.ShowDialog <> DialogResult.OK Then
                            Return
                        End If
                        '得到结果，开始湖北入库操作
                        Dim dtRv As DataTable = f.YanDaTaGridView1.DataSource
                        dtRv.Columns.Remove("rowBs")
                        For Each tDr As DataRow In dtRv.Rows
                            sqlMt = "select * from hbcabiodb..tb_mykc where tb_mykc_num='" & ph.Text &
                            "' and tb_mykc_cplb='" & tDr("tb_x825pkc_cplb") &
                            "' and tb_mykc_mingc='" & tDr("tb_x825pkc_mingc") &
                            "' and tb_mykc_jiagdm='" & tDr("tb_x825pkc_jiagdm") & "'"
                            dtMt = yMt.getDb(sqlMt)
                            If dtMt.Rows.Count > 0 Then
                                '成品油中，批号代码都一样那么更新库存
                                dic = New Dictionary(Of String, String)
                                dic("tb_mykc_sykczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_sykczl"))) + CDbl(tDr("tb_x825pkc_kczl"))
                                dic("tb_mykc_ckcl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_ckcl"))) + CDbl(tDr("tb_x825pkc_kczl"))
                                dic("tb_mykc_kczl") = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_kczl"))) + CDbl(tDr("tb_x825pkc_kczl"))
                                dic("tb_mykc_bz") = dtMt.YanDtValue2("tb_mykc_bz") & "," & DateTime.Now & ":" & "由武汉工厂入库" & tDr("tb_x825pkc_kczl")
                                For Each s As String In m_ltCk
                                    dic("tb_mykc_" & s) = CDbl(_S.YanFormatNum(dtMt.YanDtValue2("tb_mykc_" & s))) + CDbl(tDr("tb_x825pkc_" & s))
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_mykc", dic, "tb_mykc_ID=" & dtMt.YanDtValue2("tb_mykc_ID"))
                                yMt.dbExe(sqlMt)
                            Else
                                '没有一样的，那么先写入库存
                                sqlMt = "Insert into hbcabiodb..tb_mykc(tb_mykc_num2,tb_mykc_num,tb_mykc_jgrq,tb_mykc_qarq,tb_mykc_qaspjg,tb_mykc_qajgsm," &
                                    "tb_mykc_qaczrgh,tb_mykc_qcrq,tb_mykc_qcsh,tb_mykc_qcczrgh,tb_mykc_m387e,tb_mykc_sn, tb_mykc_bzxs,tb_mykc_bf,tb_mykc_yg," &
                                    "tb_mykc_cfdd,tb_mykc_bfmx,tb_mykc_cplb,tb_mykc_kdlk,tb_mykc_cw,tb_mykc_mingc,tb_mykc_jiagdm,tb_mykc_wjbgrq ,tb_mykc_sykcsm," &
                                    "tb_mykc_mynetaa,tb_mykc_r602j,tb_mykc_rkbz,tb_mykc_kczl, tb_mykc_rkts,tb_mykc_sykczl,tb_mykc_t686m,tb_mykc_bz," &
                                    "tb_mykc_czrgh, tb_mykc_gjtzzl,tb_mykc_sjmycc,tb_mykc_v744n)"
                                sqlMt &= " select tb_x825pkc_num2,tb_x825pkc_num,tb_x825pkc_jgrq,tb_x825pkc_qarq,tb_x825pkc_qaspjg,tb_x825pkc_qajgsm,tb_x825pkc_qaczrgh," &
                                    "tb_x825pkc_qcrq,tb_x825pkc_qcsh,tb_x825pkc_qcczrgh,tb_x825pkc_m387e,tb_x825pkc_sn,tb_x825pkc_bzxs,tb_x825pkc_bf,tb_x825pkc_yg,tb_x825pkc_cfdd," &
                                    "tb_x825pkc_bfmx,tb_x825pkc_cplb,tb_x825pkc_kdlk,tb_x825pkc_cw,tb_x825pkc_mingc,tb_x825pkc_jiagdm,tb_x825pkc_wjbgrq,tb_x825pkc_sykcsm ," &
                                    "tb_x825pkc_mynetaa,tb_x825pkc_r602j,tb_x825pkc_rkbz,tb_x825pkc_kczl,tb_x825pkc_rkts,tb_x825pkc_sykczl,tb_x825pkc_t686m,tb_x825pkc_bz," &
                                    "tb_x825pkc_czrgh, tb_x825pkc_r583j,tb_x825pkc_s640k,tb_x825pkc_gjtzy"
                                sqlMt &= " from tb_x825pkc where tb_x825pkc_id=" & Labelid.Text & ""
                                Dim iId As Integer = yMt.dbExe(sqlMt, 1)
                                dic = New Dictionary(Of String, String)
                                dic("tb_mykc_cplb") = tDr("tb_x825pkc_cplb")
                                dic("tb_mykc_mingc") = tDr("tb_x825pkc_mingc")
                                dic("tb_mykc_jiagdm") = tDr("tb_x825pkc_jiagdm")
                                dic("tb_mykc_sykczl") = tDr("tb_x825pkc_kczl")
                                dic("tb_mykc_ckcl") = tDr("tb_x825pkc_kczl")
                                dic("tb_mykc_kczl") = tDr("tb_x825pkc_kczl")
                                dic("#tb_mykc_bz") = "dbo.YanNullToEmpty(tb_mykc_bz,0)+'" & DateTime.Now & ":" & "由武汉工厂入库" & tDr("tb_x825pkc_kczl") & "'"
                                For Each s As String In m_ltCk
                                    dic("tb_mykc_" & s) = tDr("tb_x825pkc_" & s)
                                Next
                                sqlMt = _D.getUpdateStr("hbcabiodb..tb_mykc", dic, "tb_mykc_ID=" & iId, "#")
                                yMt.dbExe(sqlMt)
                            End If
                            '写入湖北进出货
                            dic = New Dictionary(Of String, String)
                            dic("tb_jch_cplb") = tDr("tb_x825pkc_cplb")
                            dic("tb_jch_num") = ph.Text
                            dic("tb_jch_cz") = "入"
                            dic("tb_jch_sl") = tDr("tb_x825pkc_kczl")
                            dic("tb_jch_rq") = DateTime.Now
                            dic("tb_jch_yt") = "湖北工厂"
                            dic("tb_jch_bz") = tb_x825p_rkbz.Text
                            dic("tb_jch_czrgh") = G_dlrgh
                            dic("tb_jch_mingc") = tDr("tb_x825pkc_mingc")
                            dic("tb_jch_jiagdm") = tDr("tb_x825pkc_jiagdm")
                            dic("tb_jch_jiagdmsm") = jgdm.Text
                            yMt.insert("hbcabiodb..tb_jch", dic)
                        Next

                        'sqlMt = "select tb_x825p_id from hbcabiodb..tb_x825p where tb_x825p_num='" & ph.Text &
                        '        "' and tb_x825p_jiagdm='" & jgdm.Text & "' and tb_x825p_mingc='" & cpdm.Text & "'"
                        'dtMt = yMt.getDb(sqlMt)
                        'If dtMt.Rows.Count > 0 Then   '毛油中，批号代码都一样那么更新库存
                        '    '判断是否已经入过库了，存在下步ID
                        '    If dtMt.YanDtValue2("tb_x825p_glid") <> "" Then
                        '        '如果有一样的毛油，并且入库了，那么弹出对应的库存选择界面
                        '    Else
                        '        '有一样的记录，但是没有入库，那么更新库存
                        '        sqlMt = "update hbcabiodb..tb_x825p set tb_x825p_cw='" & cw.Text & "',tb_x825p_hblsrkzl=tb_x825p_hblsrkzl+ " & kcc &
                        '            " where tb_x825p_id ='" & dtMt.YanDtValue2("tb_x825p_id") & "' "
                        '        yMt.dbExe(sqlMt)
                        '    End If
                        'Else    '没有一样的记录，那么直接入库（插入记录）
                        '    sqlMt = "Insert into cabiodb..tb_x825p(tb_x825p_num2,tb_x825p_num,tb_x825p_jgrq,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_qaczrgh,tb_x825p_qcrq,tb_x825p_qcsh,tb_x825p_qcczrgh,tb_x825p_m387e,tb_x825p_sn,tb_x825p_bzxs,tb_x825p_bf,tb_x825p_yg,tb_x825p_cfdd,tb_x825p_bfmx,tb_x825p_cplb,tb_x825p_kdlk,tb_x825p_cw,tb_x825p_mingc,tb_x825p_jiagdm,tb_x825p_wjbgrq,tb_x825p_sykcsm ,tb_x825p_mynetaa,tb_x825p_r602j,tb_x825p_rkbz,tb_x825p_kczl,tb_x825p_rkts,tb_x825p_sykczl,tb_x825p_t686m,tb_x825p_bz,tb_x825p_czrgh, tb_x825p_r583j,tb_x825p_s640k,tb_x825p_gjtzy,tb_x825p_hblsrkzl) "
                        '    sqlMt &= " select tb_mykc_num2,tb_mykc_num,tb_mykc_jgrq,tb_mykc_qarq,tb_mykc_qaspjg,tb_mykc_qajgsm,tb_mykc_qaczrgh,tb_mykc_qcrq,tb_mykc_qcsh,tb_mykc_qcczrgh,tb_mykc_m387e,tb_mykc_sn, tb_mykc_bzxs,tb_mykc_bf,tb_mykc_yg,tb_mykc_cfdd,tb_mykc_bfmx,tb_mykc_cplb,tb_mykc_kdlk,tb_mykc_cw,tb_mykc_mingc,tb_mykc_jiagdm,tb_mykc_wjbgrq ,tb_mykc_sykcsm ,tb_mykc_mynetaa,tb_mykc_r602j,tb_mykc_rkbz,tb_mykc_kczl, tb_mykc_rkts,tb_mykc_sykczl,tb_mykc_t686m,'由新工厂入库',tb_mykc_czrgh, tb_mykc_gjtzzl,tb_mykc_sjmycc,tb_mykc_v744n, " & kcc & "  "
                        '    sqlMt &= " from tb_mykc where tb_mykc_ID=" & Labelid.Text & ""
                        '    yMt.dbExe(sqlMt)
                        'End If
                End Select
            End If

            Select Case tb_x825p_yg.Text
                Case "销毁", "报废品实验"

                    Label11.Text = CDbl(Label11.Text) - CDbl(kc.Text)
                    sykczl = CDbl(Label11.Text)

                    If sykczl < 0 Then
                        MsgBox("出库重量不能大于报废库存！")
                        Exit Sub
                    End If
                    sql = "update " & fn & " set " & cwzd & "," & fn & "_bf=" & fn & "_bf-" & kc.Text & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
                Case "生产领料"
                    '生产领料只更新仓库存量
                    sql = "update " & fn & " set  " & cwzd & ", " & fn & "_ckcl=" & fn & "_ckcl-" & aaa & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
                Case "生产"
                    '生产只更新可用数量
                    sql = "update " & fn & " set  " & cwzd & "," & fn & "_sykczl=" & sykczl & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
                Case Else
                    '同时更新可用数量和仓库存量
                    sql = "update " & fn & " set  " & cwzd & "," & fn & "_ckcl=" & fn & "_ckcl-" & aaa & "," & fn & "_sykczl=" & sykczl & "," & fn & "_rkts=" & fn & "_rkts-" & rkts & "  where " & fn & "_ID=" & Labelid.Text & ""
            End Select

            yMt.dbExe(sql)

            '更新进出货表
            ''''''''''
            Dim jiagdmsm As String = ""
            If jgdm.Tag = jgdm.Text Then
                jiagdmsm = ""
            Else
                jiagdmsm = jgdm.Tag
            End If
            '''''''''''''''''
            Dim cpnb As String = ComboBox1.Text '产品类别
            Dim slnum As Double = 0 '数量
            If bfs > 0 And (tb_x825p_yg.Text = "销毁" Or tb_x825p_yg.Text = "报废品实验") Then '当是报废出货的时候数量是报废值
                slnum = bfs
            Else
                slnum = kc.Text
            End If

            '''''''''''''''''''''''' 更新冷库库存操作
            Try
                If ReturnTbname(Labelid.Text, Labeltb.Text, StorageOne.Text, StorageOne.Tag, yMt) = False Then
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            ''''''''''''''''''''''''''更新冷库添加操作
            sql = "Insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_yt,tb_jch_chts,tb_jch_czrgh,tb_jch_jiagdmsm) values"
            sql &= "('" & cpnb & "','" & cpdm.Text & "','" & jgdm.Text & "','" & ph.Text & "','出'," & bfs & ",'" & sj.Text & "','" & tb_x825p_rkbz.Text & "','" & tb_x825p_yg.Text & "'," & rkts & ",'" & G_dlrgh & "','" & jiagdmsm & "')"
            Dim StrId As String = yMt.dbExe(sql, 1)
            Try
                Dim b As String = Gf_ZdNew(Labeltb.Text, "tb_jch", StorageOne)
                UpdateTbname(StrId, "tb_jch", StorageOne.Text, b, yMt)
            Catch ex As Exception
            End Try
            ''''''''''''''''''''''''''''
            yMt.Commit()
        End Using
        MsgBox("更新成功！")

        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub tb_x825p_yg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x825p_yg.SelectedIndexChanged
        If tb_x825p_yg.Text = "销毁" Or tb_x825p_yg.Text = "报废品实验" Then

            chts.Text = 0
        End If
    End Sub

    '冷库
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOne.Click

        If StorageOne.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的冷库信息，需要重新输入么？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        GS_Storage(Me, ButtonOne.Name.Substring(6), kc, Labeltb.Text, Labelid.Text)
    End Sub
End Class