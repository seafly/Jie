Public Class Frtb_hjwswbz
    Dim cj, dd, mb, dx As String '车间、地点、目标、对象，为修改删除做判断
    Private Sub Frtb_hjwswbz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        tb_hjwswbz_cj.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            cj = tb_hjwswbz_cj.Text
            dd = tb_hjwswbz_dd.Text
            mb = tb_hjwswbz_jcmb.Text
            dx = tb_hjwswbz_jcdx.Text
            '不能修改车间、地点、目标、对象
            GS_toenable("tb_hjwswbz_cj,tb_hjwswbz_dd,tb_hjwswbz_jcmb,tb_hjwswbz_jcdx", False, Me)
            ButtonDel.Visible = True
        End If
    End Sub
    Private Sub SSSQX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", MsgBoxStyle.OkCancel, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''备注可以不填写
        If GF_YZSJ(Me, "tb_hjwswbz_bz") = False Then '验证控件
            MsgBox("请将数据填写完整") : Exit Sub
        End If
 
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改EHS统计月报") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim sql As String = "select tb_hjwswjcsj_id from tb_hjwswjcsj where "
            sql &= " tb_hjwswjcsj_cj='" & cj & "' and "
            sql &= "tb_hjwswjcsj_dd='" & dd & "' and "
            sql &= "tb_hjwswjcsj_jcmb='" & mb & "' and "
            sql &= " tb_hjwswjcsj_jcdx='" & dx & "'"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count > 0 Then
                MsgBox("数据库已有检测数据输入，不能修改！") : Exit Sub
            End If
            '''''''''''''''''''''''''''
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
            Dim sql As String = "select tb_hjwswbz_id from tb_hjwswbz where "
            sql &= " tb_hjwswbz_cj='" & tb_hjwswbz_cj.Text.Trim & "' and "
            sql &= "tb_hjwswbz_dd='" & tb_hjwswbz_dd.Text.Trim & "' and "
            sql &= "tb_hjwswbz_jcmb='" & tb_hjwswbz_jcmb.Text.Trim & "' and "
            sql &= " tb_hjwswbz_jcdx='" & tb_hjwswbz_jcdx.Text.Trim & "'"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count > 0 Then
                MsgBox("数据库已有该条记录了，注意车间、地点、检测目标、检测对象必须是唯一！") : Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            'GS_storelog3("添加EHS统计月报", "添加EHS统计月报") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub ButtonDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDel.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            '''''''''''''''''''''
            Dim sql As String = "select tb_hjwswjcsj_id from tb_hjwswjcsj where "
            sql &= " tb_hjwswjcsj_cj='" & cj & "' and "
            sql &= "tb_hjwswjcsj_dd='" & dd & "' and "
            sql &= "tb_hjwswjcsj_jcmb='" & mb & "' and "
            sql &= " tb_hjwswjcsj_jcdx='" & dx & "'"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count > 0 Then
                MsgBox("数据库已有检测数据输入，不能删除！") : Exit Sub
            End If
            '''''''''''''''''''''''''''
            '''''''''''''''''''''
            sql = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
End Class