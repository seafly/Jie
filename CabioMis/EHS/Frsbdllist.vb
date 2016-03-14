Public Class Frsbdllist


    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '得到表中文意思
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        '''''''''''''''''''''
        If GF_storelog2("查询幸免事故报告追踪系统", "查询幸免事故报告追踪系统") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_xmsgbgzzxt")
    End Sub

    Private Sub Frsbdllist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("EHS界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        GF_OpenFaceList2(ToolStrip1) '切换菜单与关闭菜单的加载
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        '''''''''''''''''''''
        If GF_storelog2("查询EHS统计月报", "查询EHS统计月报") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_b962t")
    End Sub


    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        '''''''''''''''''''''
        If GF_storelog2("查询现场检查安排表", "查询现场检查安排表") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_xcjcapb")
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        '''''''''''''''''''''
        If GF_storelog2("查询现场检查发现项跟踪系统", "查询现场检查发现项跟踪系统") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_jcfxx")
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("EHS部")
    End Sub
End Class