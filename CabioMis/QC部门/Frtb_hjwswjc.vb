Public Class Frtb_hjwswjc

    Private Sub Frtb_hjwswjc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        tb_hjwswjc_ebsfwes.SelectedIndex = 0
        tb_hjwswjc_did.SelectedIndex = 0
        tb_hjwswjc_jcmb.SelectedIndex = 0
        tb_hjwswjc_jczt.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True
        Else
            Dim sql As String = "select max(tb_hjwswjc_ID) from tb_hjwswjc"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            Gs_showsj("tb_hjwswjc", Me, dt.Rows(0)(0))
            tb_hjwswjc_jcdx.Text=""
            Button1.Visible = True
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If

        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("�޸Ļ���΢������") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
            GS_storelog3("�޸Ļ���΢������", "�޸Ļ���΢������") '���浽��־
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("��ӻ���΢������") = False Then
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("����������Ŀ������") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '���²����˹���
            GS_storelog3("��ӻ���΢������", "��ӻ���΢������") '���浽��־
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("��ȷ��ɾ��������¼��?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''��־Ȩ���ж�
            If GF_storelog2("ɾ������΢������", "ɾ������΢������") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub
End Class