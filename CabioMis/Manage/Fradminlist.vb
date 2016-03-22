Public Class Fradminlist

    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub Fradminlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("进入系统界面", "进入系统界面") = False Then
            Me.Close() : Exit Sub
        End If
        GF_OpenFaceList2(ToolStrip1) '切换菜单与关闭菜单的加载
        '''''''''''''''''''''
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim nform As New Frphgn
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim nform As New Fttimecontr
        nform.ShowDialog()
    End Sub
    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Dim nform As New frShowLog
        nform.ShowDialog()
    End Sub

    Private Sub CustsSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustsSelect.Click
        Dim nform As New Frzdycxb
        nform.ShowDialog()
    End Sub

    Private Sub Gongduan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gongduan.Click
        Dim nform As New Fraddelse
        nform.biao = "tb_bmgd"
        nform.Text = "设定工段"
        nform.ShowDialog()
    End Sub

    Private Sub Bumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bumen.Click
        Dim nform As New Fraddelse
        nform.biao = "tb_bm"
        nform.Text = "设定部门"
        nform.ShowDialog()
    End Sub

    Private Sub ReportManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportManage.Click
        Dim nform As New Frbbiao
        nform.ShowDialog()
    End Sub

    Private Sub HumenManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HumenManage.Click
        Dim nform As New Frry
        nform.ShowDialog()
    End Sub

    Private Sub RoleManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoleManage.Click
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("角色管理", "角色管理") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim nform As New Frweb
        nform.ShowDialog()
    End Sub
    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("系统管理")
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim nform As New Frhccl
        nform.ShowDialog()
    End Sub

    Private Sub 流程信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 流程信息ToolStripMenuItem.Click
        Dim nform As New FrTj_Yjyl
        nform.ShowDialog()
    End Sub

    Private Sub 生产情况统计ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 生产情况统计ToolStripMenuItem.Click
        Dim nform As New FrTj_Scqk
        nform.ShowDialog()
    End Sub
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim nform As New Frtb_cplb
        nform.ShowDialog()
    End Sub
End Class