Public Class Frzpfg
    Dim dt As DataTable
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''备注、返工油批号及重量可以不填写
        If GF_YZSJ(Me, "tb_h195z_bz,tb_h195z_y876r,tb_h195z_e95w") = False Then '验证控件
            Exit Sub
        End If
        '验证返工填写得是否正确()
        If GF_yzfglr(tb_h195z_y876r.Text.Trim, tb_h195z_e95w.Text.Trim) = False Then
            Exit Sub
        End If
        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_h195z_o460g, tb_h195z_p495h, Me)
        GS_hjkcylkc(tb_h195z_y878r, tb_h195z_c998u, Me)
        GS_hjkcylkc(tb_h195z_g179y, tb_h195z_b989t, Me)
        '''''''''''''''''''''''''''''
        If GF_storelog1("添加成品油") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If GF_cxph("tb_h195z_num", tb_h195z_num.Text.Trim) = True Then
            MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''
        Dim jj As String = GF_addsj(Labeltb.Text, Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If

        GS_kcylkc(tb_h195z_o460g, Me) '更新原料库存
        GS_kcylkc(tb_h195z_y878r, Me) '更新原料库存
        GS_kcylkc(tb_h195z_g179y, Me) '更新原料库存
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        '''''''''''''''''''''
        GS_gengsb("tb_h195z", Labelid.Text, "tb_h195z", jj)
        Dim sql As String ="update tb_jch set tb_jch_fgyph='" & tb_h195z_num.Text & "' where tb_jch_ID=" & ListView1.SelectedItems(0).SubItems(0).Text
        GS_upztxx(G_cnnstr, sql)
        ClassPhgn.ClassPhgn_SetDqz2("成品油") '使当前批号+1
        GS_storelog3("添加成品油：" & tb_h195z_num.Text.Trim, "添加成品油") '储存到日志
        MsgBox("操作成功")
        Me.Close()
    End Sub
    Private Sub tb_h195z_o460g_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_o460g.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.009'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "葵花籽油")
    End Sub

    Private Sub tb_h195z_g179y_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_g179y.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "VC总油酸脂")
    End Sub

    Private Sub tb_h195z_y878r_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_y878r.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.001'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "VE油")
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frzpfg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_jch_id,tb_jch_num from tb_jch where  tb_jch_yt='整批返工' and tb_jch_cz='出' and tb_jch_cplb like '%DOG%' and tb_jch_fgyph is null ")
        If dt1.Rows.Count = 0 Then
            MsgBox("当前没有整批返工的成品油") : Me.Close()
        End If
        GS_useviewbydb2(ListView1, dt1, 0, 0)
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效'" '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        showls()
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        showls()
    End Sub
    Private Sub showls()
        Dim ph As String = ListView1.SelectedItems(0).SubItems(1).Text '选择的返工批号
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_h195z_id from vw_h195z where tb_h195z_num='" & ph & "'")
        Dim yid As String = dt1.Rows(0)(0) '得到返工的ID
        Gs_showsj("tb_h195z", Me, yid) '显示数据
        tb_h195z_num.Text = "AOG40 "
        tb_h195z_num2.Text = ph
        Labelid.Text = yid
        tb_h195z_jgrq.Text = Date.Now
        tb_h195z_sbid.Text = yid
        tb_h195z_sbtb.Text = "tb_h195z"
    End Sub
End Class