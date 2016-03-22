Public Class Frtb_meijie
    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' ") '得到原料表
    Public old(0, 1) As String
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub Frtb_meijie_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        ''''''''''''''''''''''''''''''''''''''''''这里是为了修改而保存的原始值
        setvalue("tb_meijie_dbmph", 0)

        tb_meijie_jgrq.BringToFront()
    End Sub
    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
#Region "原料添加"
    Private Sub tb_meijie_dbmph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_meijie_dbmph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.039'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "蛋白酶")
    End Sub

    Private Sub tb_meijie_qyhnph_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_meijie_qyhnph.MouseDoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        GS_TCYLLISTzl(Me, dt1, CType(sender, Control).Name, "氢氧化钠")
    End Sub
#End Region
    Private Sub modfikucun() '更新库存
        GS_kcylkc(tb_meijie_dbmph, Me) '更新原料库存
        GS_kcylkc(tb_meijie_qyhnph, Me) '更新原料库存
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''备注

        'If GF_YZSJ(Me, "") = False Then '验证控件
        '    Exit Sub
        'End If
        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_meijie_dbmph, tb_meijie_dbmphzl, Me)
        ''''''''''''''''''''''''''''''''''''''''''
        'If GF_storelog1("修改酶解") = False Then
        '    Exit Sub
        'End If ' 判断是否有权限

        Dim sql As String = "select * from vw_meijie where tb_meijie_num='" & tb_meijie_num.Text & "' and tb_meijie_ID<>" & Labelid.Text
        If Cl_DataMag.GF_CreateDataSource(sql).Rows.Count > 0 Then
            MsgBox("已有相同酶解批号")
            Return
        End If

        ''''''''''''''''''''
        GS_sancusql(old) ''''还原原料
        ''''''''''''''''''''''''判断原料库存是否够
        Dim ylstr As String = Gf_pdylkc(tb_meijie_dbmph, Me)
        If ylstr <> "" Then
            GS_hycusql(old) '反还原原料
            MsgBox(ylstr) : Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
            GS_hycusql(old) '反还原原料
            MsgBox("请检查输入项目及数据")
            Exit Sub
        Else
            modfikucun() '更新库存
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改酶解：" & tb_meijie_num.Text.Trim, "修改酶解") '储存到日志
        End If

        Me.Close()
    End Sub



    Private Sub tb_meijie_qyhnphz11l_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_meijie_qyhnpht.TextChanged

    End Sub
End Class