Public Class Frbbiao

    Private Sub Frbbiao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showsj()
    End Sub
    Private Sub showsj()
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_tjmenu_mc,tb_tjmenu_js,tb_tjmenu_daochu from tb_tjmenu  ")
        Call GS_useviewbydb2(ListView1, db1, -1, 0)
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_mc from tb_js")
        Call GS_useviewbydb2(ListView2, kk, -1, 0)
        Call GS_useviewbydb2(ListView3, kk, -1, 0)
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
        Dim k1 As String = ListView1.SelectedItems(0).SubItems(1).Text '查看权限字符串
        Dim k2 As String = ListView1.SelectedItems(0).SubItems(2).Text '导出权限字符串
        k1 = GF_qhjdh(k1) : k2 = GF_qhjdh(k2)
        '查看权限
        For i As Integer = 0 To ListView2.Items.Count - 1
            ListView2.Items(i).Checked = False
            Dim yghm As String = GF_qhjdh(ListView2.Items(i).SubItems(0).Text)
            If InStr(k1, yghm) > 0 Then
                ListView2.Items(i).Checked = True
            End If
        Next
        '导出权限
        For i As Integer = 0 To ListView3.Items.Count - 1
            ListView3.Items(i).Checked = False
            Dim yghm As String = GF_qhjdh(ListView3.Items(i).SubItems(0).Text)
            If InStr(k2, yghm) > 0 Then
                ListView3.Items(i).Checked = True
            End If
        Next
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim k1 As String = ListView1.SelectedItems(0).SubItems(0).Text
        '以下为查看权限保存操作
        Dim wjqxa As String = ""
        For i As Integer = 0 To ListView2.CheckedItems.Count - 1
            Dim yghm As String = ListView2.CheckedItems(i).SubItems(0).Text
            wjqxa = wjqxa & yghm & ","
        Next
        wjqxa = GF_removedh(wjqxa)
        If wjqxa = "" Then
            MsgBox("请至少选择一个项目") : Exit Sub
        End If
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("设定报表权限", "设定报表权限") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        GS_upztxx(G_cnnstr, "update tb_tjmenu set tb_tjmenu_js='" & wjqxa & "' where tb_tjmenu_mc='" & k1 & "'")

        '以下为导出权限保存操作
        Dim wjqxa2 As String = ""
        For i As Integer = 0 To ListView3.CheckedItems.Count - 1
            Dim yghm2 As String = ListView3.CheckedItems(i).SubItems(0).Text
            wjqxa2 = wjqxa2 & yghm2 & ","
        Next
        wjqxa2 = GF_removedh(wjqxa2)
        If wjqxa2 = "" Then
            MsgBox("请至少选择一个项目") : Exit Sub
        End If
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("设定报表权限", "设定报表权限") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        GS_upztxx(G_cnnstr, "update tb_tjmenu set tb_tjmenu_daochu='" & wjqxa & "' where tb_tjmenu_mc='" & k1 & "'")

        If MsgBox("操作成功，是否继续设置？", 1, "提示") <> 1 Then
            Me.Close()
        Else
            showsj()
        End If
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
End Class