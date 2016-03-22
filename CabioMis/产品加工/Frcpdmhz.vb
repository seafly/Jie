Imports DeepCode.DeepDoStr
Imports _S = CabioMis.Cl_StrMag
Imports _D= CabioMis.Cl_DataMag

Public Class Frcpdmhz
    Dim zd As String = ""
    Private Sub Frcpdmhz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        GF_OpenFaceList2(ToolStrip1) '切换菜单与关闭菜单的加载

    End Sub
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim aa As New Frhzcp2
            Me.AddOwnedForm(aa)
            aa.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Frcpdmhz_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox2.Width = Me.Width
        GroupBox2.Height = Me.Height - 250
        Label1.Top = GroupBox2.Height + ToolStrip1.Height
    End Sub

    '产品规范添加
    Private Sub 添加产品规范(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gf1.Click
        With show1
            If .SelectedRows.Count = 0 Then Return
            If GF_IsLock("tb_cpdmhz", .SelectedRows(0).Cells(0).Value) = True Then
                MsgBox("该记录已被锁定，不能操作")
                Return
            End If
        End With
        Try
            Dim nform As New Frcpgf
            Me.AddOwnedForm(nform)
            nform.id = show1.SelectedRows(0).Cells(0).Value
            nform.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
    '产品规范查询
    Private Sub gf2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gf2.Click

        showsj(sender.text)

    End Sub


    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem.Click
        Try
            Dim nform As New Frkhxq
            nform.tb_khyqqkyrb_cpdm.Text = show1.SelectedRows(0).Cells("tb_cpdmhz_cpdm").Value
            nform.tb_khyqqkyrb_jgdm.Text = show1.SelectedRows(0).Cells("tb_cpdmhz_jgdm").Value
            nform.tb_khyqqkyrb_cplx.Text = Null2String(show1.SelectedRows(0).Cells("tb_cpdmhz_cplx").Value)
            Dim sql As String = "select tb_cpdmhz_gysm,tb_cpdmhz_zbsm,tb_cpdmhz_bzsm,tb_cpdmhz_bqsm,tb_cpdmhz_tsjcsm,tb_cpdmhz_yxx from tb_cpdmhz where tb_cpdmhz_cpdm='" & show1.SelectedRows(0).Cells("tb_cpdmhz_cpdm").Value & "'and tb_cpdmhz_jgdm='" & show1.SelectedRows(0).Cells("tb_cpdmhz_jgdm").Value & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            nform.tb_khyqqkyrb_gy.Text = Null2String(dt.Rows(0)("tb_cpdmhz_gysm"))
            nform.tb_khyqqkyrb_bz.Text = Null2String(dt.Rows(0)("tb_cpdmhz_bzsm"))
            nform.tb_khyqqkyrb_zb.Text = Null2String(dt.Rows(0)("tb_cpdmhz_zbsm"))
            nform.tb_khyqqkyrb_wjyq.Text = Null2String(dt.Rows(0)("tb_cpdmhz_tsjcsm"))
            nform.tb_khyqqkyrb_bq.Text = Null2String(dt.Rows(0)("tb_cpdmhz_bqsm"))
            nform.tb_khyqqkyrb_yxx.Text = Null2String(dt.Rows(0)("tb_cpdmhz_yxx"))
            nform.id = ""
            nform.ShowDialog()
        Catch ex As Exception
            MsgBox("请先进入产品规范查询,再选择代码添加客户")
        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim nform As New Frkhxq2
        nform.ShowDialog()
    End Sub


    Private Sub 锁定该项ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 锁定该项ToolStripMenuItem.Click
        If GF_storelog1("产品加工锁定") = False Then
            Exit Sub
        End If ' 判断是否有权限
        With show1
            If .SelectedRows.Count = 0 Then Return
            GS_sd("tb_cpdmhz", .SelectedRows(0).Cells(0).Value.ToString, G_dlrgh, G_cnnstrWH)
            GS_sd("tb_cpdmhz", .SelectedRows(0).Cells(0).Value.ToString, G_dlrgh, G_cnnstr)
            MsgBox("完成")
        End With
    End Sub

    Private Sub 全部锁定ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全部锁定ToolStripMenuItem.Click
        If GF_storelog1("产品加工锁定") = False Then
            Exit Sub
        End If ' 判断是否有权限
        With show1
            If .SelectedRows.Count = 0 Then Return
            For i As Integer = 0 To .RowCount - 1
                GS_sd("tb_cpdmhz", .Rows(i).Cells(0).Value.ToString, G_dlrgh, G_cnnstrWH)
                GS_sd("tb_cpdmhz", .Rows(i).Cells(0).Value.ToString, G_dlrgh, G_cnnstr)
            Next
            MsgBox("完成")
        End With
    End Sub

    Private Sub 解锁该项ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 解锁该项ToolStripMenuItem.Click
        If GF_storelog1("产品加工解锁") = False Then
            Exit Sub
        End If ' 判断是否有权限
        With show1
            If .SelectedRows.Count = 0 Then Return
            GS_DelLock("tb_cpdmhz", .SelectedRows(0).Cells(0).Value.ToString, G_cnnstrWH)
            GS_DelLock("tb_cpdmhz", .SelectedRows(0).Cells(0).Value.ToString, G_cnnstr)
            MsgBox("完成")
        End With
    End Sub

    Private Sub 全部解锁ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全部解锁ToolStripMenuItem.Click
        If GF_storelog1("产品加工解锁") = False Then
            Exit Sub
        End If ' 判断是否有权限
        With show1
            If .SelectedRows.Count = 0 Then Return
            For i As Integer = 0 To .RowCount - 1
                GS_DelLock("tb_cpdmhz", .Rows(i).Cells(0).Value.ToString, G_cnnstrWH)
                GS_DelLock("tb_cpdmhz", .Rows(i).Cells(0).Value.ToString, G_cnnstr)

            Next
            MsgBox("完成")
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            showsj(sender.text)
        Catch
        End Try
    End Sub

    Private Sub 添加修改BOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加修改BOMToolStripMenuItem.Click
        'Try
        With show1
            If .SelectedRows.Count = 0 Then Return
            If GF_IsLock("tb_cpdmhz", .SelectedRows(0).Cells(0).Value) = True Then
                MsgBox("该记录已被锁定，不能操作")
                Return
            End If
        End With

        Dim aa As New Frhzcp
        Me.AddOwnedForm(aa)
        aa.id = show1.SelectedRows(0).Cells(0).Value
        aa.ShowDialog()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub 查询BOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查询BOMToolStripMenuItem.Click
        showsj(sender.text)
    End Sub

    Private Sub 添加修改产能ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加修改产能ToolStripMenuItem.Click
        Try
            With show1
                If .SelectedRows.Count = 0 Then Return
                If GF_IsLock("tb_cpdmhz", .SelectedRows(0).Cells(0).Value) = True Then
                    MsgBox("该记录已被锁定，不能操作")
                    Return
                End If
            End With
            'Try
            Dim aa As New Frhzcn
            Me.AddOwnedForm(aa)
            aa.id = show1.SelectedRows(0).Cells(0).Value
            aa.tb_cpdmhz_yzdccps.ReadOnly = True
            aa.tb_cpdmhz_yzdccl.ReadOnly = True
            aa.tb_cpdmhz_cpxl.ReadOnly = True
            aa.ShowDialog()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub X产能ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X产能ToolStripMenuItem.Click
        'Try
        showsj(sender.text)

        '    Catch
        'End Try
    End Sub

    '编辑产品标量界面
    Private Sub showMrpList(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frShow As New FrBmpSz
        frShow.m_cpbs = show1.SelectedRows(0).Cells(0).Value
        frShow.ShowDialog()
    End Sub
    '修改产品信息界面
    Private Sub showCpModFr(ByVal sender As Object, ByVal e As System.EventArgs)
        If GF_IsLock("tb_cpdmhz", show1.SelectedRows(0).Cells(0).Value) = True Then
            MsgBox("该记录已被锁定，不能操作")
            Return
        End If
        Dim aa As New Frhzcp
        Me.AddOwnedForm(aa)
        aa.id = show1.SelectedRows(0).Cells(0).Value
        aa.m_type = "DHA"
        aa.ShowDialog()
    End Sub

    Public Sub showsj(ByVal name As String)
        Select Case name
            Case "DHABOM"
                Dim menu1 As ContextMenuStrip = Nothing
                menu1 = New ContextMenuStrip
                menu1.Items.Add("查看明细")
                AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
                menu1.Items.Add("修改基本信息")
                AddHandler menu1.Items(1).Click, AddressOf showCpModFr
                menu1.Items.Add("编辑产品标量")
                AddHandler menu1.Items(2).Click, AddressOf showMrpList

                Dim Sql As String = "select tb_cpdmhz_ID,tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_cpxz,tb_cpdmhz_cpjz,tb_cpdmhz_njzq,tb_cpdmhz_wjzq " & _
                    "from tb_cpdmhz"  ' where tb_cpdmhz_cplx in ('DOGC','DOGF','DPGE')
                Dim dt As DataTable = _D.GF_CreateDataSource(Sql)

                '添加标量列
                setBmpshowView(dt)
                GS_DataGridViewbyDb(show1, dt, True, True, menu1)
                'show1.Columns("tb_QcJc_wlbs").Visible = False
            Case "查询BOM"
                Dim sql As String
                sql = "select tb_cpdmhz_ID,tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_yxx,tb_cpdmhz_cpxz,tb_cpdmhz_cpjz,tb_cpdmhz_cpy,tb_cpdmhz_my," &
                    "tb_cpdmhz_gjt,tb_cpdmhz_2a01a001,tb_cpdmhz_2a01a002,tb_cpdmhz_2a01a003,tb_cpdmhz_2a01a007,tb_cpdmhz_2a02a008,tb_cpdmhz_2a02a002," &
                    "tb_cpdmhz_2a01a006,tb_cpdmhz_2a02a005,tb_cpdmhz_2a02a007,tb_cpdmhz_2a02a009,tb_cpdmhz_2a02a006,tb_cpdmhz_2a02a001,tb_cpdmhz_2a02a011," &
                    "tb_cpdmhz_2a02a012,tb_cpdmhz_2a04a001,tb_cpdmhz_2a04a002,tb_cpdmhz_2a04a003,tb_cpdmhz_2a04a004,tb_cpdmhz_2a04a005,tb_cpdmhz_2a04a006," &
                    "tb_cpdmhz_2a04a007,tb_cpdmhz_2a04a010,tb_cpdmhz_5a01a006,tb_cpdmhz_5a02a001,tb_cpdmhz_5a03a003,tb_cpdmhz_5a03a002,tb_cpdmhz_5a01a009," &
                    "tb_cpdmhz_3a08a003,tb_cpdmhz_5a03a006,tb_cpdmhz_5a02a004,tb_cpdmhz_5a01a004,tb_cpdmhz_3a06a001,tb_cpdmhz_3a08a004,tb_cpdmhz_3a08a002," &
                    "tb_cpdmhz_3a08a005,tb_cpdmhz_3a07a010,tb_cpdmhz_3a07a011,tb_cpdmhz_3a07a020,tb_cpdmhz_5a02a002,tb_cpdmhz_5a03a005,tb_cpdmhz_2a04a014," &
                    "tb_cpdmhz_3a08a001,tb_cpdmhz_3a09a006,tb_cpdmhz_3a07a019,tb_cpdmhz_3a09a022,tb_cpdmhz_3a08a019,tb_cpdmhz_3a08a020,tb_cpdmhz_bz," &
                    "tb_cpdmhz_bz1,tb_cpdmhz_bomczr,tb_cpdmhz_bomrq,tb_cpdmhz_bcpxz,tb_cpdmhz_cpdmczr,tb_cpdmhz_cpdmrq "
                sql &= " from tb_cpdmhz"
                Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                GS_DataGridViewbyDb(show1, dt, True, True)
                Label1.Text = ""
                If show1.Rows.Count - 1 < 0 Then
                    Return
                End If
                show1.Rows(show1.Rows.Count - 1).Selected = True
            Case "查询产能"
                Dim sql As String
                sql = "select tb_cpdmhz_ID,tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_yxx,tb_cpdmhz_cpxz,tb_cpdmhz_cnsm,tb_cpdmhz_cpdpccsj,tb_cpdmhz_dpbzsj," &
                    "tb_cpdmhz_pltr,tb_cpdmhz_trphlyq,tb_cpdmhz_cpdpcl,tb_cpdmhz_yzdscsj,tb_cpdmhz_yzdccps,tb_cpdmhz_ytrl,tb_cpdmhz_yzdccl,tb_cpdmhz_cpxl,tb_cpdmhz_cpzhl," &
                    "tb_cpdmhz_njzq,tb_cpdmhz_wjzq,tb_cpdmhz_lldpsj,tb_cpdmhz_lldptrl,tb_cpdmhz_lldpcl,tb_cpdmhz_llyscsj,tb_cpdmhz_llyccps,tb_cpdmhz_llcpxl," &
                    "tb_cpdmhz_llcpzhl,tb_cpdmhz_cnczr,tb_cpdmhz_cnrq "
                sql &= " from tb_cpdmhz"
                Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)

                GS_DataGridViewbyDb(show1, dt, True, True)
                Dim a As String
                a = "产能数据说明:" & vbCrLf
                a &= "1、毛油AOGC	" & vbCrLf
                a &= "干菌体->毛油产品转换率%=总油50%*浸出收率82%=41%；月理论生产时间=365天/12*24H=730H；月投入量：按85%发酵合格率给定，等于单批投入量*月产出批数*发酵合格率；月产量：按85%发酵合格率给定，等于单批产量*月产出批数*发酵合格率。	" & vbCrLf
                a &= "2、成品油AOGF" & vbCrLf
                a &= "毛油成品油->产品转换率%=精炼收率86%；月理论生产时间=（365天-分装间清洗24天-精炼系统清洗28天）/12=26.08天*24H=626H；月实际生产时间=（365天-精炼系统清洗28天）/12=28.08天*24H=674H。	" & vbCrLf
                a &= "3、10%淀粉配方成品粉APGE64Q" & vbCrLf
                a &= "成品油->10%粉产品转换率%=油ARA43.18%/粉ARA11%*粉收率97%=381%；月理论生产时间=(365天/12*24H)/每轮生产时间216*每轮喷雾时间185.72=628H。" & vbCrLf
                a &= "4、10%成品粉APGE64S" & vbCrLf
                a &= "成品油->10%粉产品转换率%=油ARA43.18%/粉ARA11%*粉收率97%=381%；成品油->10.6%粉产品转换率%=油ARA43.18%/粉ARA11.5%*粉收率97%=364%；月理论生产时间=(365天/12*24H)/每轮生产时间216*每轮喷雾时间186.58=631H。	" & vbCrLf
                a &= "5、15%成品粉APGT	" & vbCrLf
                a &= "成品油->15%粉产品转换率%=油ARA45.23%/粉ARA15.5%*粉收率95%=277%；1KG包装品月理论生产时间=(365天/12*24H)/每轮生产时间216*每轮喷雾时间170.42=576H；5KG包装品月理论生产时间=(365天/12*24H)/每轮生产时间216*每轮喷雾时间174.92=591H。" & vbCrLf
                Label1.Text = a
                If show1.Rows.Count - 1 < 0 Then
                    Return
                End If
                show1.Rows(show1.Rows.Count - 1).Selected = True
            Case "查询产品规范"
                Dim sql As String = "select tb_cpdmhz_ID,tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_yxx,tb_cpdmhz_cpxz,tb_cpdmhz_gysm,tb_cpdmhz_hlsm,tb_cpdmhz_ylsm,tb_cpdmhz_tzsm,tb_cpdmhz_zbsm,tb_cpdmhz_bzsm,tb_cpdmhz_bqsm,tb_cpdmhz_tsjcsm,tb_cpdmhz_cpgfczr,tb_cpdmhz_cpgfrq"
                sql &= " from tb_cpdmhz "
                Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                GS_DataGridViewbyDb(show1, dt, True, True)
                Label1.Text = ""
                If show1.Rows.Count - 1 < 0 Then
                    Return
                End If
                show1.Rows(show1.Rows.Count - 1).Selected = True
                GroupBox2.Text &= "：查询到" & dt.Rows.Count & "条数据"
        End Select
    End Sub

    '添加标量列
    Private Sub setBmpshowView(ByRef pDt As DataTable)
        Dim sql As String = ""

        '所有用到的物品代码
        Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_wp_pm from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm")
        '添加到产品DT
        For Each dr As DataRow In tBqcxm.Rows
            pDt.Columns.Add(dr("tb_wp_pm").trim)
        Next

        '更新标量值
        For Each dr As DataRow In pDt.Rows  '将结果作为列添加进去
            sql = "select tb_wp_pm,tb_mrp_blz from tb_mrp as a left join tb_wp as b on a.tb_mrp_wpdm=b.tb_wp_dm where tb_mrp_cpbs='" & dr("tb_cpdmhz_ID") & "'"
            Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
            For Each tDr As DataRow In tDt.Rows
                Try
                    dr(tDr("tb_wp_pm").trim) = _S.YanFormatStr(tDr("tb_mrp_blz"), "0", False)
                Catch
                End Try
            Next
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        showxkh()
    End Sub
    Private Sub showxkh()
        Dim sql As String = "select * from tb_ddcys"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        Label1.Text = ""
        If show1.Rows.Count - 1 < 0 Then
            Return
        End If
        show1.Rows(show1.Rows.Count - 1).Selected = True
        GroupBox2.Text = "查询到" & dt.Rows.Count & "条数据"
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim aa As New Frxkh
        aa.ShowDialog()
        showxkh()
    End Sub

    Private Sub 小客户修改ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 小客户修改ToolStripMenuItem.Click
        Try
            Dim aa As New Frxkh
            aa.id = show1.SelectedRows(0).Cells(0).Value
            aa.ShowDialog()
            showxkh()
        Catch ex As Exception
        End Try
    End Sub



    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("产品加工")
    End Sub

    Private Sub DHABOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DHABOMToolStripMenuItem.Click
        showsj(sender.text)
    End Sub
End Class