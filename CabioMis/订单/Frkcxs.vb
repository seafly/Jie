Public Class Frkcxs
    Public cplb, cpdm, jgdm, ph, sl As String
    Dim biao As String = ""
    Public ddid As Integer = 0 'tb_dd 的主键
    Private Sub Frkcxs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sqllb As String = "select top 1 tb_cpdmhz_cpxz from tb_cpdmhz where tb_cpdmhz_cplx= '" & cplb & "'" ''''''''''得到该产品的产品性质（毛油 or成品油 or 成品粉）
        sqllb = GF_getstringsql(G_cnnstr, sqllb, ",")

        Dim sql1 As String = ""
        Select Case sqllb ''''''''''''''''''''''得到表名
            Case "毛油"
                biao = "tb_x825pkc"
                sql1 = ",tb_x825pkc_kdlk,tb_x825pkc_storagewzlk,tb_x825pkc_storagemslk,tb_x825pkc_remind,tb_x825pkc_fhxz,tb_x825pkc_mscw,tb_x825pkc_wzcw,tb_x825pkc_bfcw"
            Case "成品油"
                biao = "tb_h195zkc"
                sql1 = ",tb_h195zkc_kdlk,tb_h195zkc_bfb,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk,tb_h195zkc_a948s"
            Case "成品粉"
                biao = "tb_x832pkc"
                sql1 = ",tb_x832pkc_kdlk,tb_x832pkc_bfb,tb_x832pkc_storagemslk,tb_x832pkc_storagewzlk,tb_x832pkc_d65v,tb_x832pkc_a948s"
        End Select
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''得到满足对应产品/加工代码并且qa为合格仓库存量大于20 的信息
        Dim sql As String = "select " & biao & "_id," & biao & "_cplb," & biao & "_mingc," & biao & "_jiagdm," & biao & "_num ," & biao & "_sykczl," & biao & "_fhxz," & biao & "_cw ," & biao & "_sbtb , " & biao & "_jgrq ," & biao & "_qaspjg " & sql1
        sql &= " from " & biao & " where " & biao & "_sykczl>0 and " & biao & "_mingc='" & cpdm & "' and " & biao & "_jiagdm='" & jgdm & "' and  " & biao & "_qaspjg ='合格'"

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        If dt.Rows.Count > 0 Then

            Dim dt2 As DataTable = dt.Clone ''克隆架构

            GS_DataGridViewbyDb(show2, dt2, True, True)

            show2.Columns(5).HeaderText = "使用量"
            GroupBox3.Text = "显示" & show1.RowCount & "条记录"
            GroupBox1.Text = "显示" & show2.RowCount & "条记录"
        End If
    End Sub

    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        If show1.RowCount = 0 Then
            Return
        End If
        With show1
            Dim id As String = .SelectedRows(0).Cells(biao & "_id").Value
            Dim jiagdm As String = .SelectedRows(0).Cells(biao & "_jiagdm").Value
            Dim num As String = .SelectedRows(0).Cells(biao & "_num").Value
            Dim mingc As String = .SelectedRows(0).Cells(biao & "_mingc").Value
            Dim tbname As String = .SelectedRows(0).Cells(biao & "_sbtb").Value & "kc"
            Dim sykczl As Double = .SelectedRows(0).Cells(biao & "_sykczl").Value
            Dim aa As New Frddstorage
            Me.AddOwnedForm(aa)
            aa.mingc.Text = mingc
            aa.cplb.Text = cplb
            aa.num.Text = num
            aa.jiagdm.Text = jiagdm
            aa.id.Text = id
            aa.tbname.Text = tbname
            aa.sykczl.Text = sykczl
            aa.ShowDialog()
        End With
    End Sub

    Private Sub BtnDelLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelLock.Click
        Me.Close()
    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLock.Click
        Dim dt As DataTable = show2.DataSource
        If MsgBox("使用量总量为 " & DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt, 5, 0, dt.Rows.Count - 1) & " 公斤", 1, "提示") <> 1 Then
            Exit Sub
        End If


        '''''''''''''''''得到列索引
        Dim phl, jhll, idl, cwl, intbfb, intkdlk, intmslk, intwzlk As Integer
        phl = getindex(show2, biao & "_num")
        jhll = getindex(show2, biao & "_sykczl")
        idl = getindex(show2, biao & "_id")
        cwl = getindex(show2, biao & "_cw")
        intbfb = getindex(show2, biao & "_bfb")
        intkdlk = getindex(show2, biao & "_kdlk") '
        intmslk = getindex(show2, biao & "_storagemslk")
        intwzlk = getindex(show2, biao & "_storagewzlk")
        '''''''''''
        Dim ph As String = "" : Dim jhl As String = "" : Dim lid As String = "" : Dim cw As String = ""
        Dim strbfb As String = "" : Dim strkdlk As String = "" : Dim strmslk As String = "" : Dim strwzlk As String = ""
        For i As Integer = 0 To show2.RowCount - 1
            ph &= show2.Rows(i).Cells(phl).Value & ","
            jhl &= show2.Rows(i).Cells(jhll).Value & ","
            lid &= show2.Rows(i).Cells(idl).Value & ","
            cw &= show2.Rows(i).Cells(cwl).Value & ","
            strbfb &= show2.Rows(i).Cells(intbfb).Value & ","
            strkdlk &= show2.Rows(i).Cells(intkdlk).Value & ","
            strmslk &= show2.Rows(i).Cells(intmslk).Value & ","
            strwzlk &= show2.Rows(i).Cells(intwzlk).Value & ","
        Next

        Dim tb_dd_ph As TextBox = Me.Owner.Controls("tb_dd_ph")
        Dim tb_dd_jhl As TextBox = Me.Owner.Controls("tb_dd_jhl")
        Dim tb_dd_cw As TextBox = Me.Owner.Controls("tb_dd_cw")
        Dim Labelid As Label = Me.Owner.Controls("tb_dd_kcid")
        Dim Labelbiao As Label = Me.Owner.Controls("tb_dd_kcbiao")
        tb_dd_ph.Text = GF_removedh(ph)
        tb_dd_jhl.Text = GF_removedh(jhl)
        Labelid.Text = GF_removedh(lid)
        tb_dd_cw.Text = GF_removedh(cw)
        Me.Owner.Controls("bfb").Text = GF_removedh(strbfb)
        Me.Owner.Controls("kdlk").Text = GF_removedh(strkdlk)
        Me.Owner.Controls("storagemslk").Text = GF_removedh(strmslk)
        Me.Owner.Controls("storagewzlk").Text = GF_removedh(strwzlk)
        Me.Owner.Controls("tb_dd_jhl").Enabled = False
        Me.Owner.Controls("tb_dd_cw").Enabled = False
        Me.Owner.Controls("tb_dd_jhfhzl").Enabled = False
        Labelbiao.Text = biao
        MessageBox.Show("提交成功！")
        Me.Close()
    End Sub
    Private Function getindex(ByVal show1 As DataGridView, ByVal str As String) As Integer
        For i As Integer = 0 To show1.Columns.Count - 1
            If show1.Columns(i).Name = str Then
                Return i
            End If
        Next
    End Function
    Private Sub show2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show2.DoubleClick
        show2.Rows.RemoveAt(show2.SelectedRows(0).Index)
        GroupBox3.Text = "显示" & show1.RowCount & "条记录"
        GroupBox1.Text = "显示" & show2.RowCount & "条记录"
    End Sub
    Public Sub showsj()
        Dim sqllb As String = "select top 1 tb_cpdmhz_cpxz from tb_cpdmhz where tb_cpdmhz_cplx= '" & cplb & "'" ''''''''''得到该产品的产品性质（毛油 or成品油 or 成品粉）
        sqllb = GF_getstringsql(G_cnnstr, sqllb, ",")

        Dim sql1 As String = ""
        Select Case sqllb ''''''''''''''''''''''得到表名
            Case "毛油"
                biao = "tb_x825pkc"
            Case "成品油"
                biao = "tb_h195zkc"
                sql1 = ",tb_h195zkc_kdlk,tb_h195zkc_bfb,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk,tb_h195zkc_a948s"
            Case "成品粉"
                biao = "tb_x832pkc"
                sql1 = ",tb_x832pkc_kdlk,tb_x832pkc_bfb,tb_x832pkc_storagemslk,tb_x832pkc_storagewzlk,tb_x832pkc_d65v,tb_x832pkc_a948s"
        End Select
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''得到满足对应产品/加工代码并且qa为合格仓库存量大于20 的信息
        Dim sql As String = "select " & biao & "_id," & biao & "_cplb," & biao & "_mingc," & biao & "_jiagdm," & biao & "_num ," & biao & "_sykczl," & biao & "_cw ," & biao & "_sbtb , " & biao & "_jgrq ," & biao & "_qaspjg " & sql1
        sql &= " from " & biao & " where " & biao & "_sykczl>0 and " & biao & "_mingc='" & cpdm & "' and " & biao & "_jiagdm='" & jgdm & "' and  " & biao & "_qaspjg ='合格'"

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub


End Class

