Public Class Frdrk3kc
    Private Sub weizhi()
        GroupBox1.Width = Me.Width - GroupBox1.Left - 20
        GroupBox1.Height = Int(Me.Height / 2) - 30
        GroupBox2.Width = GroupBox1.Width
        GroupBox2.Top = GroupBox1.Top + GroupBox1.Height + 10
        GroupBox2.Height = GroupBox1.Height
    End Sub

    Private Sub Frdrk3kc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
        '假使m代表毛油，f代表成品油
        showsj("m") : showsj("f")
    End Sub
    Private Sub Frdrk3kc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Private Sub showsj(ByVal str As String)
        '显示K3库存里面的编号，库存，本数据库里面的含量，条件是本数据库的库存为0,K3库存大于0
        If str = "m" Then
            Dim sql As String = "select a.k3ck_b957t as 批号,a.k3ck_h221a as 库存,b.tb_x825p_m387e from k3.dbo.k3ck a left join  tb_x825p b " _
                  & " on a.k3ck_b957t=b.tb_x825p_num where a.k3ck_m381e='" & str & "' and b.tb_x825p_kczl=0 and a.k3ck_h221a>0"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_useviewbydb2(ListView1, dt, -1, 0)
        ElseIf str = "f" Then
            Dim sql As String = "select a.k3ck_b957t as 批号,a.k3ck_h221a as 库存,b.tb_h195z_c6u from k3.dbo.k3ck a left join  tb_h195z b " _
                           & " on a.k3ck_b957t=b.tb_h195z_num where a.k3ck_m381e='" & str & "' and b.tb_h195z_kczl=0"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_useviewbydb2(ListView2, dt, -1, 0)
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        With ListView1
            If .SelectedItems.Count = 0 Then
                Exit Sub
            End If
            If MsgBox("确定导入吗？", 1, "提示") = 1 Then
                Dim bh As String = .SelectedItems(0).SubItems(0).Text '获得编号
                Dim kc As Double = .SelectedItems(0).SubItems(1).Text '获得库存
                Dim sql As String = "update tb_x825p set tb_x825p_kczl=" & kc & " ,tb_x825p_sykczl=" & kc & " where tb_x825p_num='" & bh & "'"
                GS_upztxx(G_cnnstr, sql)
                showsj("m")
            End If

        End With
    End Sub

    Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        With ListView2
            If .SelectedItems.Count = 0 Then
                Exit Sub
            End If
            If MsgBox("确定导入吗？", 1, "提示") = 1 Then
                Dim bh As String = .SelectedItems(0).SubItems(0).Text '获得编号
                Dim kc As Double = .SelectedItems(0).SubItems(1).Text '获得库存
                Dim sql As String = "update tb_h195z set tb_h195z_kczl=" & kc & " ,tb_h195z_sykczl=" & kc & " where tb_h195z_num='" & bh & "'"
                GS_upztxx(G_cnnstr, sql)
                showsj("f")
            End If

        End With
    End Sub

   
End Class