Public Class Frtb_zgqc

    Private Sub Frtb_zgqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        Dim czid As String = Labelid.Text
        ComboBox1.SelectedIndex = 0
        tb_f123x_d35v.SelectedIndex = 0
        If czid <> "" Then '�޸�ʱ������/�޺Ų����޸�
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Buttdel.Visible = True

            ComboBox1.Visible = False
        End If
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub

    Private Sub SSSQD_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        If tb_f123x_qcrq.Text = "" Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If
        If Labelid.Text <> "" Then
            ''''''''''''''''''''��־��Ȩ���ж�
            If GF_storelog1("�޸�QC") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸��й�QC��" & tb_f123x_num.Text.Trim, "�޸�QC") '���浽��־
        Else
            ''''''''''''''''''''Ȩ���ж�
            If GF_storelog1("���QC") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������")
                Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            If ComboBox1.SelectedIndex = 1 Then
                Dim sql As String = "update tb_b959t set tb_b959t_qcsh='��' where tb_b959t_num='" & tb_f123x_num.Text & "'"
                GS_upztxx(G_cnnstr, sql)
            End If
            GS_storelog3("����й�QC��" & tb_f123x_num.Text.Trim, "���QC") '���浽��־
        End If
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttdel.Click
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        If biaoid = "" Then
            Exit Sub
        End If
        If MsgBox("ȷ��ɾ����", 1, "����") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''��־��Ȩ���ж�
        If GF_storelog1("ɾ��QC") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        '''''''''''''''''''''
        Dim sql As String = "delete from " & biao & " where " & biao & "_ID=" & Labelid.Text
        sql = sql & vbCrLf & "update tb_b959t set tb_b959t_qcsh='��' where tb_b959t_num='" & tb_f123x_num.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("ɾ���й�QC��" & tb_f123x_num.Text.Trim, "ɾ��QC") '���浽��־
        Me.Close()
    End Sub
End Class