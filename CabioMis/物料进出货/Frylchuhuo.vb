Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frylchuhuo
    Dim wpfl As String = "原料"
    '查询条件表达式
    Public m_strSqlWh As string=""
    Private Sub Frylchuhuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_FaceSearch(ComboBox1, "tb_yljch", 1) '填充进出货表下拉框
        showcz()
        showczz()
        wz()
    End Sub

    '包材初始化
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        wpfl = "包材"
        showsj() '包材初始化
        showczz() '进出货初始化
    End Sub
    '进出货筛选
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        showsjj()
    End Sub

    '物料出货

    Private Sub show1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles show1.MouseDoubleClick
        Dim aa As New Fryljch
        aa.Label9.Visible = False
        aa.tb_yljch_xgsm.Visible = False
        Me.AddOwnedForm(aa)

        With show1
            aa.id = .SelectedRows(0).Cells(0).Value 'id
            aa.tb_yljch_yllb.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_r596j").Value) '原料类别
            aa.tb_yljch_gg.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_gg").Value) '规格
            aa.tb_yljch_dm.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_i231a").Value) '原料代码
            aa.tb_yljch_mc.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_c24u").Value) '原料名称
            aa.tb_yljch_dw.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_h200z").Value) '单位
            aa.tb_yljch_num.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_num").Value) '批号
            aa.tb_yljch_jhdh.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_jhdh").Value) '计划单号
            aa.tb_yljch_zhbzq.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_zhbzq").Value) '最后保质日期
            aa.tb_yljch_cw.Text = Null2String(.SelectedRows(0).Cells("tb_i259b_cw").Value) '仓位
            aa.qa = Null2String(.SelectedRows(0).Cells("tb_i259b_qaspjg").Value) 'QA审批结果
            aa.ckcl = Null2zero2(.SelectedRows(0).Cells("tb_i259b_ckcl").Value) '仓库存量
            aa.sykcl = Null2zero2(.SelectedRows(0).Cells("tb_i259b_p518h").Value) '剩余库存量
            aa.qc = Null2String(show1.SelectedRows(0).Cells("tb_i259b_qcrq").Value) 'QC审批结果
            aa.m_cjcl = Null2String(show1.SelectedRows(0).Cells("tb_i259b_p518h").Value) '车间存量
            Dim bm As String = GF_getstringsql(G_cnnstr, "select top 1 tb_yljch_bm from tb_yljch order by tb_yljch_id desc", ",")
            aa.tb_yljch_bm.Text = bm
            aa.tb_yljch_czrgh.Text = G_dlrgh
            aa.tb_yljch_cz.Text = "出"
            aa.id2 = "" '物料进出货ID
            aa.ShowDialog()


            '''''''''''''''''''''''''''''''更新
            Select Case wpfl
                Case "原料"
                    showcz() ' 原料
                Case "包材"
                    showsj() '包材
                Case Else
                    showcz() ' 原料
            End Select
            showczz() '进出货

        End With
    End Sub

    '物料进出货修改

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Dim nform As New Fryljch

        Me.AddOwnedForm(nform)

        With DataGridView1 '''''''''''''''''''''''''''''''''

            Dim rq1 As DateTime = .SelectedRows(0).Cells("tb_yljch_rq").Value
            Dim rq2 As DateTime = "2011-5-4"
            If rq1 < rq2 Then
                MsgBox("2011年5月4号以前的信息修改可能会出现未知错误，请通知管理员从后台修改！", MsgBoxStyle.Exclamation)
            End If
            If .SelectedRows(0).Cells("tb_yljch_cz").Value <> "出" Then
                MessageBox.Show("人工操作不是出，或者出货用途为退单的不准编辑！")
                Return
            End If
            If .SelectedRows(0).Cells("tb_yljch_yt").Value = "退库" Then
                MessageBox.Show("出货用途为退库的不准编辑！")
                Return
            End If
            If .SelectedRows(0).Cells("tb_yljch_czrgh").Value <> G_dlrgh Then
                MessageBox.Show("该记录非本工号人员输入，不能修改！")
                Return
            End If
            Dim sql As String = "select tb_i259b_id,tb_i259b_qaspjg,tb_i259b_ckcl,tb_i259b_p518h,tb_i259b_qcrq from tb_i259b where tb_i259b_num='" & .SelectedRows(0).Cells("tb_yljch_num").Value & "' and tb_i259b_i231a='" & .SelectedRows(0).Cells("tb_yljch_dm").Value & "' "
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            nform.ReductionUse.Text = .SelectedRows(0).Cells("tb_yljch_yt").Value '用途
            nform.tb_yljch_sl.Tag = .SelectedRows(0).Cells("tb_yljch_sl").Value '原始出库数量
            nform.id2 = .SelectedRows(0).Cells(0).Value '物料进出货ID
            nform.id = dt.Rows(0)(0) '求物料库存ID
            nform.qa = Null2String(dt.Rows(0)("tb_i259b_qaspjg")) 'QA审批结果
            nform.ckcl = dt.Rows(0)("tb_i259b_ckcl") '仓库存量
            nform.sykcl = dt.Rows(0)("tb_i259b_p518h") '剩余库存量
            nform.qc = Null2String(dt.Rows(0)("tb_i259b_qcrq")) 'QC审批结果

        End With '''''''''''''''''''''''''''''''''''

        nform.Text = "修改物料进出货"
        nform.ShowDialog()


        ''''''''''''''''''''''''''''''''''''''''更新退库
        Select Case wpfl
            Case "原料"
                showcz()
            Case "包材"
                showsj()
            Case Else
                showcz()
        End Select

        showczz() '进出货初始化

        '''''''''''''''''''''''''''''''''
    End Sub
    '物料库存修改
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim id As Integer = show1.SelectedRows(0).Cells(0).Value
        Dim qaspjg As String = show1.SelectedRows(0).Cells("tb_i259b_qaspjg").Value
        Dim r596j As String = show1.SelectedRows(0).Cells("tb_i259b_r596j").Value '物料类别
        If id = Nothing Then
            MsgBox("请选择要修改的记录")
        End If
        Dim aa As New Frmodyl
        aa.id = id
        aa.r596j = r596j
        aa.qaspjg = qaspjg
        aa.tb_i259b_num.Tag = show1.SelectedRows(0).Cells("tb_i259b_num").Value
        aa.ShowDialog()

        '刷新
        showcz()
        showczz()
    End Sub
    '湖北入库武汉
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim aa As New Fzk1
        aa.ShowDialog()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        GS_toexcel(show1, GroupBox1.Text, Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GS_toexcel(DataGridView1, GroupBox2.Text, Me)
    End Sub
    ' '原料初始化

    Public Sub showcz()
        Dim sql As String = ""
        sql = "select tb_i259b_ID,tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_jhdh,tb_i259b_num," &
            "tb_i259b_ckcl,tb_i259b_p518h,tb_i259b_kczl,tb_i259b_q546i,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_qaspjg"
        sql &= ", tb_i259b_qajgsm,tb_i259b_zhbzq,tb_i259b_endrq,tb_i259b_h200z,tb_i259b_bz,tb_i259b_qcrq,tb_i259b_qarq," &
            "tb_i259b_yxx,tb_i259b_gg,tb_i259b_num2,tb_i259b_bf,tb_i259b_bfmx,tb_i259b_cpbzrq,tb_i259b_rkrq, tb_i259b_scrq," &
            "tb_i259b_cw,tb_i259b_scs,tb_i259b_remind,tb_wp_wllb from tb_i259b as a left join tb_wp as b on a.tb_i259b_i231a=b.tb_wp_dm"
        Select Case wpfl
            Case "原料"
                sql &= " where  tb_i259b_r596j like '%原料%' and (tb_i259b_ckcl>0 or tb_i259b_p518h>0)   and tb_i259b_yxx='有效' "
            Case "DHA原料"
                sql &= " where  (tb_i259b_r596j ='发酵原料' or  tb_i259b_r596j ='油剂原料') and (tb_i259b_ckcl>0 or tb_i259b_p518h>0)   and tb_i259b_yxx='有效'"
            Case "粉剂原料"
                sql &= " where  tb_i259b_r596j like '%原料%' and (tb_i259b_r596j <>'发酵原料' and  tb_i259b_r596j <>'油剂原料') and (tb_i259b_ckcl>0 or tb_i259b_p518h>0)   and tb_i259b_yxx='有效' "
        End Select
        sql &= m_strSqlWh & " order by tb_i259b_i231a desc,tb_i259b_y840q desc"

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Dim dt2 = EarlyWarning(dt) '预警时间更新
        GroupBox1.Text = wpfl & "库存：" & dt2.Rows.Count & "条记录"

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("查看原料")
        AddHandler menu1.Items(1).Click, AddressOf showListYl

        AddHandler menu1.Paint, AddressOf checkCd

        GS_DataGridViewbyDb(show1, dt2, True, True,menu1)
        Colour(show1) 'QA为不合格为红色
        'rq(show1)
        show1.Columns("tb_i259b_jhdh").Visible = False
        show1.Columns("tb_i259b_cpbzrq").Visible = False
    End Sub

    Private Sub checkCd(ByVal sender As ContextMenuStrip, ByVal e As System.EventArgs)
        Try
            '如果是合成材料那么合成操作可用
            If show1.SelectedRows(0).Cells("tb_wp_wllb").Value <> "Z" Then
                sender.Items(1).Enabled = False
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub showListYl(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select tb_syjl_ID,tb_syjl_wpdm,tb_syjl_ftime,tb_syjl_wlph,tb_syjl_zl  from tb_syjl where tb_syjl_xz=0 and tb_syjl_czbs=" & show1.SelectedRows(0).Cells("tb_i259b_ID").Value
        Dim fr As New FrListYl
        Cl_DataMag.GF_CreateDataSource(sql).YanDataBind(fr.show1)
        fr.ShowDialog()
    End Sub

    '包材初始化
    Private Sub showsj()
        Dim sql As String = "select tb_i259b_ID,tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_jhdh,tb_i259b_num,tb_i259b_ckcl,tb_i259b_p518h,tb_i259b_kczl,tb_i259b_q546i,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_qaspjg,tb_i259b_qajgsm,tb_i259b_zhbzq,tb_i259b_endrq,tb_i259b_h200z,tb_i259b_bz,tb_i259b_qcrq,tb_i259b_qarq,tb_i259b_yxx,tb_i259b_gg"
        sql &= ",tb_i259b_num2,tb_i259b_bf,tb_i259b_bfmx,tb_i259b_cpbzrq,tb_i259b_rkrq,tb_i259b_scrq,tb_i259b_cw,tb_i259b_scs,tb_i259b_remind,tb_wp_wllb from tb_i259b as a left join tb_wp as b on a.tb_i259b_i231a=b.tb_wp_dm"
        sql = sql & " where  tb_i259b_r596j like '%包材%'  and (tb_i259b_ckcl>0 or  tb_i259b_p518h>0)   and tb_i259b_yxx='有效' " & m_strSqlWh & " order by tb_i259b_i231a desc,tb_i259b_y840q desc"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Dim dt2 = EarlyWarning(dt) '预警时间更新
        GS_DataGridViewbyDb(show1, dt2, True, True)
        GroupBox1.Text = "包材库存：" & dt2.Rows.Count & "条记录"
        Colour(show1) 'QA为不合格为红色

        '是否请检，请检日期
        show1.Columns("tb_i259b_jhdh").Visible = False
        show1.Columns("tb_i259b_cpbzrq").Visible = False
        For i As Integer = 0 To show1.Rows.Count - 1
            If Fryljch.phpd(show1.Rows(i).Cells("tb_i259b_i231a").Value) = False Then
                show1.Rows(i).Cells("tb_i259b_p518h").Style.SelectionForeColor = Color.Transparent
                show1.Rows(i).Cells("tb_i259b_p518h").Style.ForeColor = Color.White
            End If
        Next

    End Sub
    '进出货表初始化
    Public Sub showczz()
        Dim tt1, tt2 As DateTime
        tt1 = Now.Date & " 00:00:00" : tt2 = DateTimePicker3.Text & " 23:59:59"
        Dim sql As String = "select tb_yljch_ID,tb_yljch_yllb,tb_yljch_dm,tb_yljch_mc,tb_yljch_jhdh," &
            "tb_yljch_num,tb_yljch_sl,tb_yljch_rq,tb_yljch_gg,tb_yljch_dw,tb_yljch_yt,tb_yljch_bz,tb_yljch_czrgh," &
            "tb_yljch_xgsm,tb_yljch_cz ,tb_yljch_cw ,tb_yljch_bm,tb_yljch_zhbzq from tb_yljch where tb_yljch_rq between  '" & tt1 & "' and '" & tt2 & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(DataGridView1, dt, True, True)
        GroupBox2.Text = "原料进出货数据：" & dt.Rows.Count & "条记录"
    End Sub
    '进出货表筛选
    Private Sub showsjj()
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker4.Text : tt2 = DateTimePicker3.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If

        Dim sql As String = "select tb_yljch_ID,tb_yljch_yllb,tb_yljch_dm,tb_yljch_mc,tb_yljch_jhdh,tb_yljch_num,tb_yljch_sl,tb_yljch_rq,tb_yljch_gg,tb_yljch_dw,tb_yljch_yt,tb_yljch_bz,tb_yljch_czrgh,tb_yljch_xgsm,tb_yljch_cz ,tb_yljch_bm,tb_yljch_zhbzq from tb_yljch where tb_yljch_rq between  '" & tt1 & "' and '" & tt2 & "'"
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBox1, TextBox1) '文本查询函数：挂接到查询文本
        sql &= sqlbdssep
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(DataGridView1, dt, True, True)
        GroupBox2.Text = "原料出货数据：" & dt.Rows.Count & "条记录"
    End Sub
    Private Sub Frylchuhuo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub wz()
        GroupBox1.Width = Me.Width - 20
        GroupBox2.Width = Me.Width - 20
        GroupBox2.Height = Me.Height - GroupBox1.Height - 150
    End Sub
    Private Sub Colour(ByVal DataGridViewName As DataGridView)
        Try
            With DataGridViewName
                For i As Integer = 0 To .Rows.Count - 1
                    Dim aa As String = .Rows(i).Cells("tb_i259b_qaspjg").Value
                    If aa = "不合格" Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If
                Next
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rq(ByVal DataGridViewName As DataGridView)
        Try
            With DataGridViewName
                For i As Integer = 0 To .Rows.Count - 1
                    If Null2String(.Rows(i).Cells("tb_i259b_rkrq").Value) <> "" Then
                        Dim zq As Date = .Rows(i).Cells("tb_i259b_rkrq").Value
                        Dim hq As Date = DateAdd(DateInterval.Day, 45, zq)
                        If DateDiff(DateInterval.Day, Now().Date, hq) >= 0 Then
                            .Rows(i).Cells("tb_i259b_zhbzq").Style.BackColor = Color.Purple
                        End If
                    End If
                Next
            End With
        Catch ex As Exception
        End Try

    End Sub
    '预警提醒
    '最后保质日期-预警时间<=系统时间<最后保质日期 显示“预警”，tb_i259b_zhbzq-tb_warning_rq<=date.now<tb_i259b_zhbzq
    '系统时间>=最后保质日期 显示“到期”。date.now>=tb_i259b_zhbzq
    Private Function EarlyWarning(ByVal dt As DataTable) As DataTable

        Dim sql As String = ""
        With dt
            For Each DR As DataRow In .Rows
                sql = "select  tb_warning_rq from tb_warning where tb_warning_dm='" & DR("tb_i259b_i231a") & "' "
                Dim DtWarn As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                If DtWarn.Rows.Count > 0 Then
                    If IsDBNull(DR("tb_i259b_zhbzq")) = False Then
                        If DateAndTime.DateDiff(DateInterval.Day, Now.Date, DR("tb_i259b_zhbzq")) <= Null2zero(DtWarn.Rows(0)("tb_warning_rq")) And DateAndTime.DateDiff(DateInterval.Day, DR("tb_i259b_zhbzq"), Now.Date) < 0 Then
                            DR("tb_i259b_remind") = "预警"
                        ElseIf DateAndTime.DateDiff(DateInterval.Day, DR("tb_i259b_zhbzq"), Now.Date) >= 0 Then
                            DR("tb_i259b_remind") = "到期"
                        End If
                    End If
                End If
            Next
        End With
        Return dt

    End Function

    '原料初始化
    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        wpfl = "原料"
        showcz()
        showczz()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        wpfl = "DHA原料"
        showcz()
        showczz()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        wpfl = "粉剂原料"
        showcz()
        showczz()
    End Sub
End Class