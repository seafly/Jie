Public Class Frtb_jg2
    Dim dt As DataTable
    Private Sub frtb_jg2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        dt = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�
    End Sub

    Private Sub tb_jg2_ph_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_jg2_ph.MouseDoubleClick
        Dim aa As New Frphzl : Me.AddOwnedForm(aa)
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        Call ltcsh(dt1, aa.ListView1, "��������", 5, 6, tb_jg2_ph.Text, tb_jg2_pht.Text)
        aa.ShowDialog()
        tb_jg2_ph.Text = ph.Text : tb_jg2_pht.Text = zl.Text
        ph.Text = "" : zl.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GF_storelog1("���CIP���") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        '''''''''�жϱ���''''''''''''

        If GF_YZSJ(Me, "") = False Then '��֤�ؼ�
            Exit Sub
        End If

        ''''''''''''''''''''''''
        ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
        Dim ylstr As String = Gf_pdylkc(tb_jg2_ph, Me)
        If ylstr <> "" Then '
            MsgBox(ylstr) : Exit Sub
        End If
        GS_hjkcylkc(tb_jg2_ph, tb_jg2_zl, Me)
        ''''''''''''''''''''�ϼƻ���
        '''''''''''''''''''''
        Dim jj As String = GF_addsj(Labeltb.Text, Me)
        If jj = "" Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If
        GS_kcylkc(tb_jg2_ph, Me) '����ԭ�Ͽ��
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
        GS_storelog3("���CIP��ޣ�" & tb_jg2_ph.Text.Trim, "���CIP���") '���浽��־
        Me.Close()


        '''''''''''''''''
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class