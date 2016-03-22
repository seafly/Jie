Public Class Frjsb_list
    Private namepp As String
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub Frjsb_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("技术部界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        GF_OpenFaceList2(tsMenu) '切换菜单与关闭菜单的加载
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '  Me.namepp = "库存"
        '    Me.Text = "粉剂" & Me.namepp

        ' showsj()
    End Sub

  


 
    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("技术部")
    End Sub

 
    'Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
    '    Dim sql As String = "select tb_h195z_ID,tb_h195z_num,tb_h195z_s621k from oil  "
    '    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        Dim sql1 As String = "update tb_h195z set tb_h195z_s621k=" & dt.Rows(i)(2) & " where tb_h195z_ID=" & dt.Rows(i)(0) & " and tb_h195z_num='" & dt.Rows(i)(1) & "'"
    '        Call GS_upztxx(G_cnnstr, sql1)
    '    Next
    '    MsgBox("wanceng")
    'End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    '研发项目管理
    Private Sub MenuBtYFXMGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBtYFXMGL.Click
        If GF_storelog1("查看研发项目资料") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim nform As New Frjsb_YFXMGL
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Dim aa As New Frcpdmhz
        aa.ShowDialog()
    End Sub
End Class