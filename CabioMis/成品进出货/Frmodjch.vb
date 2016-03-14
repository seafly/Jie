Public Class Frmodjch

    Dim oldjchsl As Double '本条记录的原始进出数量
    Dim oldyt As String '本条记录的原始用途
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If Labelid.Text <> "" Then
            If tb_jch_xgsm.Text.Trim = "" Then
                MsgBox("必须填写修改说明") : Exit Sub
            End If
            '''''''''''''''''''''''''''''
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim lbtb As DataTable = getjchlbb() '得到进出货类别对应的表
            Dim bm As String = DeepCode.DeepDoDataTable.GF_cnwithen(lbtb, "t1='" & tb_jch_cplb.Text & "'", 2)
            If bm = "" Then '得到表名称
                MsgBox("未查找到进出货类别") : Exit Sub
            End If
            lbtb = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select " & bm & "_id from " & bm & " where " & bm & "_num='" & tb_jch_num.Text & "'and " & bm & "_mingc='" & tb_jch_mingc.Text & "'and " & bm & "_jiagdm='" & tb_jch_jiagdm.Text & "'")
            If lbtb.Rows.Count = 0 Then
                MsgBox("未查找到进出货批号") : Exit Sub
            End If
            Dim bmid As String = lbtb.Rows(0)(0) '得到关联表ID
            hyoldsl(bm, bmid)  '还原库存操作
            newcz(bm, bmid) '更新库存操作
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改进出货", "修改进出货：" & tb_jch_num.Text & "，原因：" & tb_jch_xgsm.Text.Trim) '储存到日志



            MsgBox("操作成功，您可能需要刷新查询发现更改")
        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("添加偏差台账") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            'Dim jj As String = GF_addsj(Labeltb.Text, Me)
            'If jj = "" Then
            '    MsgBox("请检查输入项目及数据") : Exit Sub
            'End If
            'GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            'GS_storelog3("添加进出货", "添加进出货") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("删除进出货", "删除进出货：" & tb_jch_num.Text & "，原因：" & tb_jch_xgsm.Text.Trim) '储存到日志
            MsgBox("操作成功，您可能需要刷新查询发现更改")
            Me.Close()

        End If
    End Sub

    Private Sub Frmodjch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Call GS_wlbktlr2(tb_jch_yt, kk, 1, "")

        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            'Button3.Visible = True
        End If
        ''''''''''''''''''' '修改时间 = 系统时间
        Dim StrXg As String = Now.Date & " " & Now.TimeOfDay.ToString
        Dim IntXg As Integer = InStrRev(StrXg, ".")
        tb_jch_xgrq.Text = Microsoft.VisualBasic.Left(StrXg, IntXg - 1)
        ''''''''''''''
        oldjchsl = tb_jch_sl.Text.Trim '本条记录的原始进出数量
        oldyt = tb_jch_yt.Text '本条记录的原始用途
        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub
    '修改进出货的关联库存算法

    Private Sub hyoldsl(ByVal strbiao As String, ByVal strbiaoid As String)  '还原库存操作
        Dim zd1 As String = strbiao & "_ckcl" '仓库存量字段
        Dim zd2 As String = strbiao & "_sykczl" '剩余库存字段
        Dim zd3 As String = strbiao & "_kczl" '入库重量
        Dim sql As String = "update " & strbiao & " set "
        Select Case tb_jch_cz.Text
            Case "进" '入库任何用途，均同时扣除两个库存字段
                sql &= zd1 & "=" & zd1 & "-" & oldjchsl
                sql &= "," & zd2 & "=" & zd2 & "-" & oldjchsl
                sql &= "," & zd3 & "=" & zd3 & "-" & oldjchsl
            Case "出"
                Select Case oldyt
                    Case "生产领料"
                        sql &= zd1 & "=" & zd1 & "+" & oldjchsl
                    Case "生产"
                        sql &= zd2 & "=" & zd2 & "+" & oldjchsl
                    Case Else
                        sql &= zd1 & "=" & zd1 & "+" & oldjchsl
                        sql &= "," & zd2 & "=" & zd2 & "+" & oldjchsl
                End Select
        End Select
        sql &= " where " & strbiao & "_id=" & strbiaoid
        Call GS_upztxx(G_cnnstr, sql)
    End Sub

    Private Sub newcz(ByVal strbiao As String, ByVal strbiaoid As String) '修改后操作
        Dim xghsl As Double = tb_jch_sl.Text.Trim '修改后的数量
        Dim zd1 As String = strbiao & "_ckcl" '仓库存量字段
        Dim zd2 As String = strbiao & "_sykczl" '剩余库存字段
        Dim zd3 As String = strbiao & "_kczl" '入库重量
        Dim sql As String = "update " & strbiao & " set "
        Select Case tb_jch_cz.Text
            Case "进" '入库任何用途，均同时增加两个库存字段
                sql &= zd1 & "=" & zd1 & "+" & xghsl
                sql &= "," & zd2 & "=" & zd2 & "+" & xghsl
                sql &= "," & zd3 & "=" & zd3 & "+" & xghsl
            Case "出"
                Select Case tb_jch_yt.Text
                    Case "生产领料"
                        sql &= zd1 & "=" & zd1 & "-" & xghsl
                    Case "生产"
                        sql &= zd2 & "=" & zd2 & "-" & xghsl
                    Case Else
                        sql &= zd1 & "=" & zd1 & "-" & xghsl
                        sql &= "," & zd2 & "=" & zd2 & "-" & xghsl
                End Select
        End Select
        sql &= " where " & strbiao & "_id=" & strbiaoid
        Call GS_upztxx(G_cnnstr, sql)
    End Sub
    '得到进出货类别对应的表
    Private Function getjchlbb() As DataTable
        Dim a As New DataTable
        a.Columns.Add("t1", GetType(String)) : a.Columns.Add("t2", GetType(String)) : a.Columns.Add("t3", GetType(String))
        Dim d As DataRow = a.NewRow
        d(0) = "AOG40" : d(1) = "成品油" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "试验油" : d(1) = "成品油" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOG40 HB" : d(1) = "成品油" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOGC" : d(1) = "毛油" : d(2) = "tb_x825pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APG10" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APG15" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APGK" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APG10B" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOG40A" : d(1) = "成品油" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "AOGF" : d(1) = "成品油" : d(2) = "tb_h195zkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APGE" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "APGT" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        d = a.NewRow : d(0) = "DOGK" : d(1) = "成品粉" : d(2) = "tb_x832pkc" : a.Rows.Add(d)
        Return a
    End Function
End Class