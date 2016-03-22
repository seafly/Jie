Public Class Frehslist

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
        If GF_storelog2("查询自来水", "查询自来水") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_zls")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        '''''''''''''''''''''
        If GF_storelog2("查询电", "查询电") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_dian")
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        '''''''''''''''''''''
        If GF_storelog2("查询蒸汽、柴油", "查询蒸汽、柴油") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_zqb")
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        '''''''''''''''''''''
        If GF_storelog2("查询过滤器更换记录", "查询过滤器更换记录") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_glqghjl")
    End Sub

    Private Sub Frehslist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("设备动力部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        GF_OpenFaceList2(ToolStrip1) '切换菜单与关闭菜单的加载
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub



    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("设备动力部")
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub


End Class