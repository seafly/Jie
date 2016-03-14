Public Class Frtb_dian

    Private Sub Frtb_dian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ''''''''''''''''''''''''''''']填充填表人和审核人
        Dim yg As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_yg order by tb_yg_w779o desc")
        Dim dt As DataTable = GF_czmctb(yg, "tb_yg_v753n='设备动力部' and tb_yg_yx='有效'")
        'GS_wlbktlr2(tb_zls_tby, dt, 3, "")
        tb_dian_tby.Items.Add("刘琨")
        tb_dian_tby.Items.Add("夏鸿")
        tb_dian_tby.Items.Add("罗胜军")
        tb_dian_tby.SelectedIndex = 0
        'GS_wlbktlr2(tb_dian_shr, dt, 3, "")
        '''''''''''''''''''''''''''''''
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
            '以下填充换表勾选
            Dim zqsj() As String = Split(tb_dian_hb.Text, ",")
            For i As Integer = 0 To hblv.Items.Count - 1
                For j As Integer = 0 To zqsj.Length - 1
                    If hblv.Items.Item(i).ToString = zqsj(j) Then
                        hblv.SetItemChecked(i, True)
                    End If
                Next
            Next
        End If
        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        'If GF_YZSJ(Me, "tb_dian_shr") = False Then '验证控件
        '    Exit Sub
        'End If
        '''''''''''''''

        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改电") = False Then
                Exit Sub
            End If ' 判断是否有权限
         
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改电", "修改电") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加电") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加电", "添加电") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除电", "删除电") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
    '“总量电”应乘2000的倍率
    Private Sub tb_dian_zjlg_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zjlg.Enter
        If tb_dian_zjlg.Text <> "" Then
            If tb_dian_zjlg.Text > 0 Then
                tb_dian_zjlg.Text = tb_dian_zjlg.Text / 3000
            End If
        End If
    End Sub
    Private Sub tb_dian_zjlg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zjlg.Leave
        If tb_dian_zjlg.Text <> "" Then
            tb_dian_zjlg.Text = tb_dian_zjlg.Text * 3000
        End If
    End Sub
    '峰（倍率为2000）
    Private Sub tb_dian_feng_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_feng.Enter
        If tb_dian_feng.Text <> "" Then
            If tb_dian_feng.Text > 0 Then
                tb_dian_feng.Text = tb_dian_feng.Text / 3000
            End If
        End If
    End Sub
    Private Sub tb_dian_feng_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_feng.Leave
        If tb_dian_feng.Text <> "" Then
            tb_dian_feng.Text = tb_dian_feng.Text * 3000
        End If
    End Sub
    '平（倍率为2000）
    Private Sub tb_dian_ping_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_ping.Enter
        If tb_dian_ping.Text <> "" Then
            If tb_dian_ping.Text > 0 Then
                tb_dian_ping.Text = tb_dian_ping.Text / 3000
            End If
        End If
    End Sub
    Private Sub tb_dian_ping_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_ping.Leave
        If tb_dian_ping.Text <> "" Then
            tb_dian_ping.Text = tb_dian_ping.Text * 3000
        End If
    End Sub
    '谷（倍率为2000）
    Private Sub tb_dian_gu_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_gu.Enter
        If tb_dian_gu.Text <> "" Then
            If tb_dian_gu.Text > 0 Then
                tb_dian_gu.Text = tb_dian_gu.Text / 3000
            End If
        End If
    End Sub
    Private Sub tb_dian_gu_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_gu.Leave
        If tb_dian_gu.Text <> "" Then
            tb_dian_gu.Text = tb_dian_gu.Text * 3000
        End If
    End Sub
    ' 低压总柜（医药园临时线，倍率为80）
    Private Sub tb_dian_dyzg_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_dyzg.Enter
        If tb_dian_dyzg.Text <> "" Then
            If tb_dian_dyzg.Text > 0 Then
                tb_dian_dyzg.Text = tb_dian_dyzg.Text / 80
            End If
        End If
    End Sub
    Private Sub tb_dian_dyzg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_dyzg.Leave
        If tb_dian_dyzg.Text <> "" Then
            tb_dian_dyzg.Text = tb_dian_dyzg.Text * 80
        End If
    End Sub
    '柴油发电机（倍率为60）
    Private Sub tb_dian_cyfdjzb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_cyfdjzb.Enter
        If tb_dian_cyfdjzb.Text <> "" Then
            If tb_dian_cyfdjzb.Text > 0 Then
                tb_dian_cyfdjzb.Text = tb_dian_cyfdjzb.Text / 60
            End If
        End If
    End Sub
    Private Sub tb_dian_cyfdjzb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_cyfdjzb.Leave
        If tb_dian_cyfdjzb.Text <> "" Then
            tb_dian_cyfdjzb.Text = tb_dian_cyfdjzb.Text * 60
        End If
    End Sub
    '锅炉房（倍率为50）
    Private Sub tb_dian_glf_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_glf.Enter
        If tb_dian_glf.Text <> "" Then
            If tb_dian_glf.Text > 0 Then
                tb_dian_glf.Text = tb_dian_glf.Text / 50
            End If
        End If
    End Sub
    Private Sub tb_dian_glf_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_glf.Leave
        If tb_dian_glf.Text <> "" Then
            tb_dian_glf.Text = tb_dian_glf.Text * 50
        End If
    End Sub

    '污水站动力与照明（倍率为15） 
    Private Sub tb_dian_wszdlyzm_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_wszdlyzm.Enter
        If tb_dian_wszdlyzm.Text <> "" Then
            If tb_dian_wszdlyzm.Text > 0 Then
                tb_dian_wszdlyzm.Text = tb_dian_wszdlyzm.Text / 15
            End If
        End If
    End Sub
    Private Sub tb_dian_wszdlyzm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_wszdlyzm.Leave
        If tb_dian_wszdlyzm.Text <> "" Then
            tb_dian_wszdlyzm.Text = tb_dian_wszdlyzm.Text * 15
        End If
    End Sub
    '门房、空压房、冷库总照明（倍率为100）
    Private Sub tb_dian_zzm_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zzm.Enter
        If tb_dian_zzm.Text <> "" Then
            If tb_dian_zzm.Text > 0 Then
                tb_dian_zzm.Text = tb_dian_zzm.Text / 100
            End If
        End If
    End Sub
    Private Sub tb_dian_zzm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zzm.Leave
        If tb_dian_zzm.Text <> "" Then
            tb_dian_zzm.Text = tb_dian_zzm.Text * 100
        End If
    End Sub
    '制成与发酵总照明*100
    Private Sub tb_dian_zcyfx_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zcyfx.Enter
        If tb_dian_zcyfx.Text <> "" Then
            If tb_dian_zcyfx.Text > 0 Then
                tb_dian_zcyfx.Text = tb_dian_zcyfx.Text / 100
            End If
        End If
    End Sub
    Private Sub tb_dian_zcyfx_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zcyfx.Leave
        If tb_dian_zcyfx.Text <> "" Then
            tb_dian_zcyfx.Text = tb_dian_zcyfx.Text * 100
        End If
    End Sub
    '发酵大楼总表*200
    Private Sub tb_dian_fxdlzb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_fxdlzb.Enter
        If tb_dian_fxdlzb.Text <> "" Then
            If tb_dian_fxdlzb.Text > 0 Then
                tb_dian_fxdlzb.Text = tb_dian_fxdlzb.Text / 200
            End If
        End If
    End Sub
    Private Sub tb_dian_fxdlzb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_fxdlzb.Leave
        If tb_dian_fxdlzb.Text <> "" Then
            tb_dian_fxdlzb.Text = tb_dian_fxdlzb.Text * 200
        End If
    End Sub
    '制成（一） 烘干与洗涤（倍率为30）
    Private Sub tb_dian_zca_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zca.Enter
        If tb_dian_zca.Text <> "" Then
            If tb_dian_zca.Text > 0 Then
                tb_dian_zca.Text = tb_dian_zca.Text / 30
            End If
        End If
    End Sub
    Private Sub tb_dian_zca_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zca.Leave
        If tb_dian_zca.Text <> "" Then
            tb_dian_zca.Text = tb_dian_zca.Text * 30
        End If
    End Sub
    '制成（二） 电梯与空压（倍率为30）
    Private Sub tb_dian_zcb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zcb.Enter
        If tb_dian_zcb.Text <> "" Then
            If tb_dian_zcb.Text > 0 Then
                tb_dian_zcb.Text = tb_dian_zcb.Text / 30
            End If
        End If
    End Sub
    Private Sub tb_dian_zcb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zcb.Leave
        If tb_dian_zcb.Text <> "" Then
            tb_dian_zcb.Text = tb_dian_zcb.Text * 30
        End If
    End Sub
    '制成大楼总表*100
    Private Sub tb_dian_zcdlzb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zcdlzb.Enter
        If tb_dian_zcdlzb.Text <> "" Then
            If tb_dian_zcdlzb.Text > 0 Then
                tb_dian_zcdlzb.Text = tb_dian_zcdlzb.Text / 100
            End If
        End If
    End Sub
    Private Sub tb_dian_zcdlzb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_zcdlzb.Leave
        If tb_dian_zcdlzb.Text <> "" Then
            tb_dian_zcdlzb.Text = tb_dian_zcdlzb.Text * 100
        End If
    End Sub
    '浸出动力（倍率为20）
    Private Sub tb_dian_qcdl_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_qcdl.Enter
        If tb_dian_qcdl.Text <> "" Then
            If tb_dian_qcdl.Text > 0 Then
                tb_dian_qcdl.Text = tb_dian_qcdl.Text / 20
            End If
        End If
    End Sub
    Private Sub tb_dian_qcdl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_qcdl.Leave
        If tb_dian_qcdl.Text <> "" Then
            tb_dian_qcdl.Text = tb_dian_qcdl.Text * 20
        End If
    End Sub
    ' 新粉剂动力．照明160倍
    Private Sub tb_dian_xfjdl_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_xfjdl.Enter
        If tb_dian_xfjdl.Text <> "" Then
            If tb_dian_xfjdl.Text > 0 Then
                tb_dian_xfjdl.Text = tb_dian_xfjdl.Text / 160
            End If
        End If
    End Sub
    Private Sub tb_dian_xfjdl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_xfjdl.Leave
        If tb_dian_xfjdl.Text <> "" Then
            tb_dian_xfjdl.Text = tb_dian_xfjdl.Text * 160
        End If
    End Sub
  
    Private Sub hblv_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles hblv.MouseUp
        Dim zz As String = ""
        For i As Integer = 0 To hblv.CheckedItems.Count - 1
            zz = zz & hblv.CheckedItems.Item(i).ToString & ","
        Next
        tb_dian_hb.Text = GF_removedh(zz)
    End Sub

    Private Sub tb_dian_5t_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_dian_5t.Leave
        If tb_dian_5t.Text <> "" Then
            tb_dian_5t.Text = tb_dian_5t.Text * 100
        End If
    End Sub

   

End Class