Public Class Frxgfjnbd

    Public old2(1, 1) As String
    Private xgid As String, dt As DataTable
    Private Sub Frxgfjnbd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        dt = GF_CreateDataSource(G_cnnstr, "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效'") '得到原料表库存大于0
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim t As String = TextBox1.Text.Trim
        If t = "" Then
            Return
        End If
        Dim sql As String = "select * from vw_x832p where tb_x832p_num='" & t & "'"
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt1.Rows.Count = 0 Then
            MsgBox("未查到该批号") : Return
        End If
        Button1.Enabled = False
        SSSQD.Enabled = True
        '''''''''''''''''''
        xgid = dt1.Rows(0)("tb_x832p_ID")
        ''''''''''''''5KG粉剂铝箔袋
        tb_x832p_ybdph.Text = DeepCode.DeepDoStr.Null2String(dt1.Rows(0)("tb_x832p_ybdph")) : tb_x832p_ybdzl.Text = DeepCode.DeepDoStr.Null2zero(dt1.Rows(0)("tb_x832p_ybdzl")) : tb_x832p_ybdpht.Text = DeepCode.DeepDoStr.Null2String(dt1.Rows(0)("tb_x832p_ybdpht"))
        ''''''''''''''''''''1KG粉剂铝箔袋
        tb_x832p_ypybdph.Text = DeepCode.DeepDoStr.Null2String(dt1.Rows(0)("tb_x832p_ypybdph")) : tb_x832p_ypybdzl.Text = DeepCode.DeepDoStr.Null2zero(dt1.Rows(0)("tb_x832p_ypybdzl")) : tb_x832p_ypybdpht.Text = DeepCode.DeepDoStr.Null2String(dt1.Rows(0)("tb_x832p_ypybdpht"))
        '''''''''''''''''
        old2(0, 0) = tb_x832p_ybdph.Text : old2(0, 1) = tb_x832p_ybdpht.Text
        old2(1, 0) = tb_x832p_ypybdph.Text : old2(1, 1) = tb_x832p_ypybdpht.Text
        MsgBox("已经查到该批号，可以修改了")
    End Sub
    Private Sub tb_x832p_ybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_ybdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='3.08.002' or tb_i259b_i231a='3.08.101')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "5KG粉剂铝箔袋")
    End Sub

    Private Sub tb_x832p_ypybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_ypybdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='3.08.003' or tb_i259b_i231a='3.08.102' )")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "1KG粉剂铝箔袋")
    End Sub
    Private Sub tb_x832p_yjlbdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_yjlbdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='3.08.020' or tb_i259b_i231a='3.08.103')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "优粉铝箔袋")
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘合计汇总
        GS_hjkcylkc(tb_x832p_ybdph, tb_x832p_ybdzl, Me)
        GS_hjkcylkc(tb_x832p_ypybdph, tb_x832p_ypybdzl, Me)
        '''''''''''''
        ''''''''''''''''''''
        If GF_storelog1("修改成品粉") = False Then
            Exit Sub
        End If ' 判断是否有权限
        GS_sancusql(old2) ''''还原原料
        ''''''''''''''''''''''''判断原料库存是否够
        Dim ylstr As String = Gf_pdylkc(tb_x832p_ybdph, Me) & Gf_pdylkc(tb_x832p_ypybdph, Me)
        If ylstr <> "" Then
            GS_hycusql(old2) ''''反还原原料
            MsgBox(ylstr) : Exit Sub
        End If
        '''''''''''''''''''''
        If GF_modsj("tb_x832p", Me, xgid) = False Then
            GS_hycusql(old2) '反还原原料
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_kcylkc(tb_x832p_ybdph, Me) '更新原料库存
        GS_kcylkc(tb_x832p_ypybdph, Me) '更新原料库存
        GS_modczsj("tb_x832p", "tb_x832p_czrgh", xgid, G_dlrgh) '更新操作人工号
        GS_storelog3("修改成品粉铝箔袋：" & TextBox1.Text.Trim, "修改成品粉") '储存到日志
        MsgBox("操作完成")
        Me.Close()
    End Sub
   
End Class