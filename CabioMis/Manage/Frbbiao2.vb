Public Class Frbbiao2
    Public k1 As String
    Private Sub Frbbiao2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub showsj()
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_mc from tb_js")
        Call GS_useviewbydb2(ListView2, kk, -1, 0)
        'Dim k1 As String = ListView1.SelectedItems(0).SubItems(1).Text '查看权限字符串
        k1 = GF_qhjdh(k1)
        '查看权限
        For i As Integer = 0 To ListView2.Items.Count - 1
            ListView2.Items(i).Checked = False
            Dim yghm As String = GF_qhjdh(ListView2.Items(i).SubItems(0).Text)
            If InStr(k1, yghm) > 0 Then
                ListView2.Items(i).Checked = True
            End If
        Next
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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
        GS_upztxx(G_cnnstr, "update tb_tjmenu set tb_tjmenu_js='" & wjqxa & "' where tb_tjmenu_mc='" & Me.Text & "'")
        GS_storelog3("编辑自定义报表权限：" & Me.Text, "编辑自定义报表权限") '储存到日志
        MsgBox("操作成功") : Me.Close()
    End Sub
End Class