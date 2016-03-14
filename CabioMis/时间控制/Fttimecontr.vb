Public Class Fttimecontr

    Private Sub Fttimecontr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        CheckBox1_1.Text = G_xdz : CheckBox2_1.Text = G_zdd : CheckBox3_1.Text = G_ddf
        Changed2()
    End Sub

    Private Sub CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged
        Dim cc As CheckBox = sender
        Call Changed1(cc)
    End Sub
    Private Sub Changed1(ByVal str As CheckBox)
        Dim lwkj As String = str.Name & "_1" '时间框名称
        If str.Checked = True Then
            Me.Controls(lwkj).Enabled = True
        Else
            Me.Controls(lwkj).Enabled = False
        End If
    End Sub
    Private Sub Changed2()
        If G_xdz = 0 Then
            CheckBox1.Checked = False : Else : CheckBox1.Checked = True
        End If
        If G_zdd = 0 Then
            CheckBox2.Checked = False : Else : CheckBox2.Checked = True
        End If
        If G_ddf = 0 Then
            CheckBox3.Checked = False : Else : CheckBox3.Checked = True
        End If
        Call Changed1(CheckBox1) : Changed1(CheckBox2) : Changed1(CheckBox3)
    End Sub
    Private Function Changed3(ByVal str As CheckBox) As Boolean
        Dim lwkj As String = str.Name & "_1" '时间框名称
        If str.Checked = True And Me.Controls(lwkj).Text = "" Then
            Changed3 = False : Me.Controls(lwkj).Focus() : Exit Function
        End If
        If str.Checked = True And Int(Me.Controls(lwkj).Text) <= 0 Then
            Changed3 = False : Me.Controls(lwkj).Focus() : Exit Function
        End If
        Changed3 = True
    End Function
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If Changed3(CheckBox1) = False Or Changed3(CheckBox2) = False Or Changed3(CheckBox3) = False Then
            MsgBox("请正确填写时间！") : Exit Sub
        End If
        If CheckBox1_1.Enabled = True Then
            G_xdz = CheckBox1_1.Text : Else : G_xdz = 0
        End If
        If CheckBox2_1.Enabled = True Then
            G_zdd = CheckBox2_1.Text : Else : G_zdd = 0
        End If
        If CheckBox3_1.Enabled = True Then
            G_ddf = CheckBox3_1.Text : Else : G_ddf = 0
        End If
        Dim sql As String = "update tb_sjkz set tb_sjkz_xdz=" & G_xdz & ",tb_sjkz_zdd=" & G_zdd & ",tb_sjkz_ddf=" & G_ddf & ""
        GS_upztxx(G_cnnstr, sql)
        MsgBox("设置完成")
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

 
End Class