Public Class Frtb_jcfxx

    Private Sub Frtb_jcfxx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim czid As String = Labelid.Text
        GS_wlbktlr2(tb_jcfxx_zrbm, G_bm, 1, "")
        GS_wlbktlr2(tb_jcfxx_ssbm, G_bm, 1, "")
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd")
        GS_wlbktlr2(tb_jcfxx_gd, dt, 1, "无")
        showComboList(Me.tb_jcfxx_wancheng)
        tb_jcfxx_jcxm.SelectedIndex = 0
        '''''''''''''''
        'tb_jcfxx_fl,tb_jcfxx_jczz,tb_jcfxx_qy,tb_jcfxx_jcr
        Dim sql As String
        Dim dtt As DataTable
        sql = "select top 1 * from tb_jcfxx order by tb_jcfxx_id desc"
        dtt = GF_CreateDataSource(G_cnnstr, sql)
        If dtt.Rows.Count > 0 Then
            tb_jcfxx_fl.Text = Null2String(dtt.Rows(0)("tb_jcfxx_fl"))
            tb_jcfxx_jczz.Text = Null2String(dtt.Rows(0)("tb_jcfxx_jczz"))
            tb_jcfxx_qy.Text = Null2String(dtt.Rows(0)("tb_jcfxx_qy"))
            tb_jcfxx_jcr.Text = Null2String(dtt.Rows(0)("tb_jcfxx_jcr"))
        End If

        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
        End If

        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改现场检查发现项跟踪系统") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改现场检查发现项跟踪系统", "修改现场检查发现项跟踪系统") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加现场检查发现项跟踪系统") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加现场检查发现项跟踪系统", "添加现场检查发现项跟踪系统") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除现场检查发现项跟踪系统", "删除现场检查发现项跟踪系统") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
End Class