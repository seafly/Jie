Public Class Frrlzy

  
   
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        ''''''''''''''''''''''
        'Dim sql As String = "select * from tb_tjmenu"
        'Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        'Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='员工培训统计'")
        'Dim ckjs As String = kj.Rows(0)("tb_tjmenu_js") '查看角色
        'ckjs = GF_qhjdh(ckjs)
        'If InStr(ckjs, GF_qhjdh(G_js)) = 0 Then
        '    MsgBox("您没有查看员工培训统计的权限") : Exit Sub
        'End If
        '''''''''''''''''''''''
        'Dim nform As New frygpx
        'nform.ShowDialog()
    End Sub
    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '得到表中文意思
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ''''''''''''''''''''''
        'If GF_storelog2("查询CABIO员工培训档案", "查询CABIO员工培训档案") = False Then
        '    Exit Sub
        'End If
        '''''''''''''''''''''''
        'Call showform("tb_ygpxda")
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub



    Private Sub Frrlzy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("人力资源部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        GF_OpenFaceList2(ToolStrip1) '切换菜单与关闭菜单的加载
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub


    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("人力资源部")
    End Sub
End Class