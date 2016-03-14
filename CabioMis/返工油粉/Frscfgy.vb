Public Class Frscfgy

    Private Sub Frscfgy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '仓库用途是外加工的出货且产品类别是AOG40
        Dim sql As String = "select * from tb_jch where  tb_jch_yt='外加工' and tb_jch_cz='出' and tb_jch_cplb='AOG40' and tb_jch_fgyph is null "
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView1, db1, -1, 90)
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ListView1.CheckedItems.Count = 0 Then
            Exit Sub
        End If
        Dim zzid As String = Nothing '组成ID
        Dim zzzl As Double = 0 '合计重量
        Dim phxl As String = Nothing '成品油批号与重量序列
        Dim zlxl As String = Nothing
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            zzid &= ListView1.CheckedItems(i).SubItems(0).Text & ","
            zzzl += ListView1.CheckedItems(i).SubItems(4).Text
            phxl &= ListView1.CheckedItems(i).SubItems(2).Text & ","
            zlxl &= ListView1.CheckedItems(i).SubItems(4).Text & ","
        Next
        zzid = GF_removedh(zzid) : phxl = GF_removedh(phxl) : zlxl = GF_removedh(zlxl)
        Dim r As Integer = MsgBox("已选择" & ListView1.CheckedItems.Count & "，选择重量为：" & zzzl, 1, "提示")
        If r <> 1 Then
            Exit Sub
        End If
        Dim aa As String = InputBox("请输入一个批号？", "生成", "")
        If aa = "" Then
            MsgBox("请输入一个批号") : Exit Sub
        End If
        Dim sql As String = "select tb_fgyf_ID from tb_fgyf where tb_fgyf_num='" & aa & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            MsgBox("对不起，该批号已经存在了！") : Exit Sub
        End If
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("添加外加工油：" & aa, "添加外加工油") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        sql = "insert into tb_fgyf(tb_fgyf_num,tb_fgyf_zl,tb_fgyf_rq,tb_fgyf_czrgh,tb_fgyf_c,tb_fgyf_z)values"
        sql = sql & "('" & aa & "'," & zzzl & ",getdate(),'" & G_dlrgh & "','" & phxl & "','" & zlxl & "')"
        sql = sql & vbCrLf & "update tb_jch set tb_jch_fgyph='" & aa & "' where tb_jch_id in (" & zzid & ")"
        GS_upztxx(G_cnnstr, sql)
        MsgBox("操作完成")
        Me.Close()
    End Sub
End Class