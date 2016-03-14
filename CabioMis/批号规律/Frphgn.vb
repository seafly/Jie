Public Class Frphgn

    Private Sub Frphgn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select * from tb_l358d "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(ComboBox1, dt, 1, "")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim = "" Or Chentextintz1.Text.Trim = "" Then
            MsgBox("请填写前缀和当前值！") : Exit Sub
        End If
        Dim z As String = ComboBox1.Text
        Dim qz As String = TextBox1.Text.Trim
        Dim dqz As Integer = Chentextintz1.Text.Trim
        ''''''''''''''''''''日志与权限判断
        If GF_storelog2("修改批号规律：" & z, "批号规律管理") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update tb_l358d set tb_l358d_qz='" & qz & "',tb_l358d_dqz=" & dqz & " where  tb_l358d_zd='" & z & "'"
        GS_upztxx(G_cnnstr, sql)
        MsgBox("设定完成！")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim z As String = ComboBox1.Text
        Dim sql As String = "select * from tb_l358d where tb_l358d_zd='" & z & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        TextBox1.Text = dt.Rows(0)("tb_l358d_qz")
        Chentextintz1.Text = dt.Rows(0)("tb_l358d_dqz")
    End Sub
End Class