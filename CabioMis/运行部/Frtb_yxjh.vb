Public Class Frtb_yxjh

    Private Sub Frtb_yxjh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d")
        Call GS_wlbktlr2(tb_yxjh_y846q, kk, 1, "")
        Dim czid As String = Labelid.Text

        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
            tb_yxjh_tjq.ReadOnly = True 'ͳ���ڲ����޸�
        End If
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
   
        If Labelid.Text <> "" Then
            '''''''''�жϱ���''''''''''''��ע��ֹ���ſɲ���д

            If GF_YZSJ(Me, "tb_yxjh_bz,tb_yxjh_o476g") = False Then '��֤�ؼ�
                Exit Sub
            End If
            ''''''''''''''''''''��־
            If GF_storelog1("�޸����мƻ�") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_storelog2("�޸����мƻ�", "�޸����мƻ�") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸����мƻ�������" & tb_yxjh_y846q.Text & "��ͳ���ڣ�" & tb_yxjh_tjq.Text, "�޸����мƻ�") '���浽��־
        Else
            '''''''''�жϱ���''''''''''''���ʱ��ע��ʵ��ֹ���ſɲ���д

            If GF_YZSJ(Me, "tb_yxjh_bz,tb_yxjh_sjzph") = False Then '��֤�ؼ�
                Exit Sub
            End If
            ''''''''''''''''''''��־
            If GF_storelog1("������мƻ�") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("������мƻ�������" & tb_yxjh_y846q.Text & "��ͳ���ڣ�" & tb_yxjh_tjq.Text, "������мƻ�") '���浽��־
        End If
        Me.Close()
    End Sub



    Private Function tjqcf(ByVal str1 As String, ByVal str2 As Integer) As Boolean '�ж�ĳ�����ͳ�����Ƿ��Ѿ������
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_yxjh_id from tb_yxjh where tb_yxjh_y846q='" & str1 & "' and tb_yxjh_tjq=" & str2 & "")
        If dt.Rows.Count > 0 Then
            tjqcf = True
        Else
            tjqcf = False
        End If
    End Function


    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("��ȷ��ɾ��������¼��?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''��־Ȩ���ж�
            If GF_storelog2("ɾ�����мƻ�������" & tb_yxjh_y846q.Text & "��ͳ���ڣ�" & tb_yxjh_tjq.Text, "ɾ�����мƻ�") = False Then
                Exit Sub
            End If
            ''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            Me.Close()
        End If
    End Sub

    Private Sub tb_yxjh_y846q_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_yxjh_y846q.SelectedIndexChanged
        If Labelid.Text = "" Then
            Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d")
            Dim ss As String = GF_cnwithen(kk, "tb_l358d_zd='" & tb_yxjh_y846q.Text & "'", 2)
            tb_yxjh_t685m.Text = ss
            tb_yxjh_o476g.Text = ss
            '��������������������������������������õ����Ź���
            kk = GF_CreateDataSource(G_cnnstr, "select top 1 * from tb_yxjh where  tb_yxjh_y846q='" & tb_yxjh_y846q.Text & "' order by    tb_yxjh_tjq desc ")
            If kk.Rows.Count = 0 Then
                tb_yxjh_tjq.Text = "20090001"
                Label11.Text = "������ֹ����"
            Else
                tb_yxjh_tjq.Text = Int(kk.Rows(0)("tb_yxjh_tjq")) + 1 '�Զ���ͳ���ڼ�1
                Label11.Text = "����ֹ����Ϊ��" & kk.Rows(0)("tb_yxjh_sjzph") '�Զ����ϴεĽ�ֹ������ʾ����

            End If
        End If

    End Sub
End Class