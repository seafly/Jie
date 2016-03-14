Public Class Frzdycxb

    Private Sub Frzdycxb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_zdycxb,tb_js_mc from tb_js  ")
        Call GS_useviewbydb2(ListView1, db1, 0, 100)
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_biaoinf where tb_biaoinf_id not in (1,2) order by tb_biaoinf_id")
        Call GS_useviewbydb2(ListView2, kk, -1, 100)

    End Sub
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        qh()
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        qh()
    End Sub
    Private Sub qh()
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim k1 As String = ListView1.SelectedItems(0).SubItems(0).Text
        k1 = GF_qhjdh(k1)
        For i As Integer = 0 To ListView2.Items.Count - 1
            ListView2.Items(i).Checked = False
            Dim yghm As String = GF_qhjdh(ListView2.Items(i).SubItems(1).Text)
            If InStr(k1, yghm) > 0 Then
                ListView2.Items(i).Checked = True
            End If
        Next
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim wjqxa As String = ""
        For i As Integer = 0 To ListView2.CheckedItems.Count - 1
            Dim yghm As String = ListView2.CheckedItems(i).SubItems(1).Text
            wjqxa = wjqxa & yghm & ","
        Next
        wjqxa = GF_removedh(wjqxa)
        If wjqxa = "" Then
            MsgBox("请至少选择一个表") : Exit Sub
        End If
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("设定自定义查询表权限", "设定自定义查询表权限") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        GS_upztxx(G_cnnstr, "update tb_js set tb_js_zdycxb='" & wjqxa & "' where tb_js_mc='" & ListView1.SelectedItems(0).SubItems(1).Text & "'")
        Me.Close()
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
End Class