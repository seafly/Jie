Public Class Frtb_dgqc

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_qc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        ComboBox1.SelectedIndex = 0
        tb_q546i_a941s.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then '�޸�ʱ������/�޺Ų����޸�
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Buttdel.Visible = True
            ComboBox1.Visible = False
        End If
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        If tb_q546i_qcrq.Text = "" Then
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

            GS_storelog3("�޸ķ��͹�QC��" & tb_q546i_num.Text.Trim, "�޸�QC") '���浽��־
        Else
            ''''''''''''''''''''
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
                Dim sql As String = "update tb_i234a set tb_i234a_qcsh='��' where tb_i234a_num='" & tb_q546i_num.Text & "'"
                GS_upztxx(G_cnnstr, sql)
            End If
            GS_storelog3("��ӷ��͹�QC��" & tb_q546i_num.Text.Trim, "���QC") '���浽��־
        End If
     
        Me.Close()
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttdel.Click
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        If biaoid = "" Then
            Exit Sub
        End If
        Dim r As Integer = MsgBox("ȷ��ɾ����", 1, "����")
        If r <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''��־��Ȩ���ж�
        If GF_storelog1("ɾ��QC") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        '''''''''''''''''''''
        Dim sql As String = "delete from " & biao & " where " & biao & "_ID=" & Labelid.Text
        sql = sql & vbCrLf & "update tb_i234a set tb_i234a_qcsh='��' where tb_i234a_num='" & tb_q546i_num.Text & "'"
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("ɾ�����͹�QC��" & tb_q546i_num.Text.Trim, "ɾ��QC") '���浽��־
        Me.Close()
    End Sub

  

End Class