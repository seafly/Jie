Public Class Frtb_n441f

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If tb_p525h_qcrq.Text = "" Or tb_p525h_c17u.Text = "" Then
            MsgBox("ʱ���EB���Ա�����д") : Exit Sub
        End If
        'Dim qcrq As DateTime = tb_p525h_qcrq.Text
        'Dim jgrq As DateTime = DateAdd(DateInterval.Hour, -12, qcrq)
        'tb_p525h_jgrq.Text = jgrq : tb_p525h_b967t.Text = jgrq

        ''''''���EB������Ϊ�գ���QA�������Ϊ����
        If tb_p525h_u721n.Text <> "" Then
            tb_p525h_qaspjg.Text = "����"
        End If

        ''''''''''''''''''''
        If GF_storelog2("��ӷۼ�С��QC��" & tb_p525h_num.Text.Trim, "���QC") = False Then
            Exit Sub
        End If

        '''''''''''''''''''''
        For Each strTm As String In Labelid.Text.ToString.Split(",")
            If GF_modsjpc(Labeltb.Text, Me, strTm) = False Then
                MsgBox("����������Ŀ������")
                Exit For
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", strTm, G_dlrgh) '���²����˹���
        Next

        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_n441f_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim czid As String = Labelid.Text
        Gs_showsj(Labeltb.Text, Me, Labelid.Text.ToString.Split(",")(0))
        If tb_p525h_qcrq.Text = "" Then
            tb_p525h_c17u.Text = "0/1��50g"
        End If
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub

  
End Class