Public Class Frjsb_YFXMGL_ADD

    Private Sub Frjsb_YFXMGL_ADD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub


    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If tb_jyfxm_mc.Text.Trim = "" Then
            Return
        End If
        If GF_storelog1("添加研发项目") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_jyfxm_id from tb_jyfxm where tb_jyfxm_mc='" & tb_jyfxm_mc.Text.Trim & "'")
        If dt.Rows.Count > 0 Then
            MsgBox("要创建的项目与数据库现有重复！") : Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        Dim jj As String = GF_addsj("tb_jyfxm", Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_modczsj("tb_jyfxm", "tb_jyfxm_czrgh", jj, G_dlrgh) '更新操作人工号
        GS_storelog3("添加研发项目:" & tb_jyfxm_mc.Text.Trim, "添加研发项目") '储存到日志
        ''''''''''''''''
        Dim p1 As Frjsb_YFXMGL = Me.Owner
        p1.SHOWTreeViewAddNode() '主界面刷新
        'Dim tree1 As TreeView = p1.TreeView1
        'For i As Integer = 0 To tree1.Nodes.Count - 1
        '    If tree1.Nodes(i).Level = 0 And tree1.Nodes(i).Text = DatePart(DateInterval.Year, CType(tb_jyfxm_rq.Text, Date)) Then
        '        p1.AddProjectNode(tree1.Nodes(i), tb_jyfxm_mc.Text.Trim) '主界面刷新
        '    End If
        'Next
        MsgBox("操作成功")
        Me.Close()

        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
    End Sub
End Class