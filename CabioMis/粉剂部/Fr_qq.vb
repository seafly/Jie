Public Class Fr_qq
    Public xpph As String 'С������
    Private Sub Fr_qq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''
        If GF_storelog2("���С������" & xpph, "С������") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String
        sql = "update tb_p525h set tb_p525h_czrgh='" & G_dlrgh & "'where tb_p525h_ID in(" & Label2.Text & ")"

        GS_upztxx(G_cnnstr, sql)
        ''''''''''''''
        Dim ylstr As String = Gf_pdylkc(tb_p525h_rtph, Me)

        If ylstr <> "" Then
            MsgBox(ylstr)
            Exit Sub
        End If
        ''''''''''''''''''''�ϼƻ���,
        GS_hjkcylkc(tb_p525h_rtph, tb_p525h_rtzl, Me)

        '������������������������������
        Dim idall() As String = Label2.Text.Split(",")
        For ids As Integer = 0 To idall.Length - 1
            If GF_modsj("tb_p525h", Me, idall(ids)) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
        Next

        '''''''''''''''''''''''''����ԭ�Ͽ��
        GS_kcylkc(tb_p525h_rtph, Me)


        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

 
    Private Sub tb_p525h_rtph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_p525h_rtph.DoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.014'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����")
    End Sub
End Class