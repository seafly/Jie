Public Class frpassword

    Private Sub frpassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        TextBox1.Text = G_dlrgh

    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim zkrxm As String = GF_cnwithen(G_yginf, "tb_yg_n430f='" & G_dlrgh & "' and tb_yg_pass='" & GF_MD5(TextBox2.Text, 16) & "'", 2)
        'If zkrxm = "" Then 'ͨ�����Ż������
        '    MsgBox("ԭ����������������롣") : Exit Sub
        'End If
        'If TextBox3.Text = "" Then
        '    MsgBox("�����������롣") : Exit Sub
        'End If
        'If TextBox3.Text <> TextBox4.Text Then
        '    MsgBox("��������������벻һ�£����������롣") : Exit Sub
        'End If

        'Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        'cnn.ConnectionString = G_cnnstr
        'cnn.Open()
        'Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & G_dlrgh & "'"
        'Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        'RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        'RS("tb_yg_pass").value = GF_MD5(TextBox3.Text, 16)
        'RS.update()
        'RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
        'MsgBox("�޸ĳɹ���", MsgBoxStyle.OkOnly)
        'Me.Close()
    End Sub
End Class