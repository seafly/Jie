Public Class frchuhuo
    Private g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效' order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ")
    Private Sub frchuhuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Case "tb_h195zkc"
                tb_x825p_yg.Text = "生产领料"
            Case "tb_x832pkc"
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

        GS_upztxx(G_cnnstr, sql)

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
            If ReturnTbname(Labelid.Text, Labeltb.Text, StorageOne.Text, StorageOne.Tag) = False Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        ''''''''''''''''''''''''''更新冷库添加操作
        sql = "Insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_yt,tb_jch_chts,tb_jch_czrgh,tb_jch_jiagdmsm) values"
        sql &= "('" & cpnb & "','" & cpdm.Text & "','" & jgdm.Text & "','" & ph.Text & "','出'," & bfs & ",'" & sj.Text & "','" & tb_x825p_rkbz.Text & "','" & tb_x825p_yg.Text & "'," & rkts & ",'" & G_dlrgh & "','" & jiagdmsm & "')"
        Dim StrId As String = GF_upztxx2(G_cnnstr, sql, "tb_jch")
        Try
            Dim b As String = Gf_ZdNew(Labeltb.Text, "tb_jch", StorageOne)
            UpdateTbname(StrId, "tb_jch", StorageOne.Text, b)
        Catch ex As Exception
        End Try
        ''''''''''''''''''''''''''''

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