
Public Class Frtb_k3cpykc

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If GF_storelog1("设定K3成品月库存及5S总分") = False Then
            Exit Sub
        End If ' 判断是否有权限

        If Crude.Text = "" Or Finish.Text = "" Or Power.Text = "" Or Gold.Text = "" Then
            MsgBox("请完整数据的填写！") : Exit Sub
        End If
        Dim a, b, c, d, f, g As Double
        a = Double.Parse(Crude.Text)
        b = Double.Parse(Finish.Text)
        c = Double.Parse(Power.Text)
        d = Double.Parse(Gold.Text)
        'f = FormatNumber((a * 0.92 * 0.94 * 0.98 + b * 0.94 * 0.98 + c / 4 + d / 4), 2)
        f = FormatNumber((a * 0.93 + b + c / 4 + d / 4), 2) '2010年1月28日 更新公式
        g = Double.Parse(zf.Text)
        Dim sql As String
        sql = "insert into tb_k3cpykc(tb_k3cpykc_rq,tb_k3cpykc_c19u,tb_k3cpykc_d36v,tb_k3cpykc_y869q,tb_k3cpykc_n452g,tb_k3cpykc_k326c,tb_k3cpykc_zf,tb_k3cpykc_czrgh) values("
        sql &= " '" & rq.Value & " ','" & a & "','" & b & "','" & c & "','" & d & "','" & f & "'," & g & ",'" & G_dlrgh & "') "
        Call GS_upztxx(G_cnnstr, sql)
        MsgBox("操作成功！")
        Me.Close()
    End Sub

    Private Sub frk3cpykc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub
End Class