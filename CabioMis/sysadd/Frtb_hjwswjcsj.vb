Public Class Frtb_hjwswjcsj
    'Dim cj, dd, mb, dx As String '车间、地点、目标、对象，为修改删除做判断
    '总的检测标准表
    'Private jcbz As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select * from tb_hjwswbz")
    Private Sub Frtb_hjwswjcsj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        'tb_hjwswjcsj_cj.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            ButtonDel.Visible = True
            'cj = tb_hjwswjcsj_cj.Text
            'dd = tb_hjwswjcsj_dd.Text
            'mb = tb_hjwswjcsj_jcmb.Text
            'dx = tb_hjwswjcsj_jcdx.Text
            '不能修改车间、地点、目标、对象
            GS_toenable("tb_hjwswjcsj_cj,tb_hjwswjcsj_dd,tb_hjwswjcsj_jcmb,tb_hjwswjcsj_jcdx", False, Me)

        End If
    End Sub
    Private Sub SSSQX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''备注可以不填写
        If GF_YZSJ(Me, "tb_hjwswjcsj_bz") = False Then '验证控件
            MsgBox("请将数据填写完整") : Exit Sub
        End If
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改EHS统计月报") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            'GS_storelog3("修改EHS统计月报", "修改EHS统计月报") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("添加EHS统计月报") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            'GS_storelog3("添加EHS统计月报", "添加EHS统计月报") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub tb_hjwswjcsj_cj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_hjwswjcsj_cj.SelectedIndexChanged
        Dim wz As String = sender.text
        Dim bds As String = "tb_hjwswbz_cj='" & wz & "'"
        Dim sql As String = "select tb_hjwswbz_dd from tb_hjwswbz where  " & bds & " group by tb_hjwswbz_dd"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(tb_hjwswjcsj_dd, dt, 0, "")
        'If tb_hjwswjcsj_jcmb.Text = "" Then
        '    tb_hjwswjcsj_jcmb.Text = ""
        '    tb_hjwswjcsj_jcdx.Text = ""
        'End If
    End Sub

    Private Sub tb_hjwswjcsj_dd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_hjwswjcsj_dd.SelectedIndexChanged
        Dim wz As String = sender.text
        Dim bds As String = "tb_hjwswbz_cj='" & tb_hjwswjcsj_cj.Text & "' and tb_hjwswbz_dd='" & wz & "'"
        Dim sql As String = "select tb_hjwswbz_jcmb from tb_hjwswbz where  " & bds & " group by tb_hjwswbz_jcmb"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(tb_hjwswjcsj_jcmb, dt, 0, "")

    End Sub

    Private Sub tb_hjwswjcsj_jcmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_hjwswjcsj_jcmb.SelectedIndexChanged
        Dim wz As String = sender.text
        Dim bds As String = "tb_hjwswbz_cj='" & tb_hjwswjcsj_cj.Text & "' and tb_hjwswbz_dd='" & tb_hjwswjcsj_dd.Text & "' and tb_hjwswbz_jcmb='" & wz & "'"
        Dim sql As String = "select tb_hjwswbz_jcdx from tb_hjwswbz where  " & bds & " group by tb_hjwswbz_jcdx"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(tb_hjwswjcsj_jcdx, dt, 0, "")
    End Sub

    Private Sub tb_hjwswjcsj_jcdx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_hjwswjcsj_jcdx.SelectedIndexChanged
        Dim wz As String = sender.text
        Dim bds As String = "tb_hjwswbz_cj='" & tb_hjwswjcsj_cj.Text & "' and tb_hjwswbz_dd='" & tb_hjwswjcsj_dd.Text & "' and tb_hjwswbz_jcmb='" & tb_hjwswjcsj_jcmb.Text & "' and tb_hjwswbz_jcdx='" & wz & "'"
        Dim sql As String = "select tb_hjwswbz_biaozun from tb_hjwswbz where  " & bds & " "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            tb_hjwswjcsj_czbz.Text = dt.Rows(0)("tb_hjwswbz_biaozun")
            tb_hjwswjcsj_jg.Text = tb_hjwswjcsj_czbz.Text
        End If


    End Sub
    Private Sub ButtonDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDel.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            '''''''''''''''''''''
            Dim sql As String  = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
End Class