Public Class Frtb_x824pcpf

    Private Sub Frtb_x824pcpf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Call GS_wlbktlr2(tb_x825p_yg, kk, 1, "")
        Dim bm As String = Labeltb.Text
        Dim bmid As String = Labelid.Text
        Dim sql As String = "select " & bm & "_qaspjg," & bm & "_qajgsm," & bm & "_cplb," & bm & "_bzxs," & bm & "_scdm from " & bm & " where " & bm & "_id=" & bmid
        kk = GF_CreateDataSource(G_cnnstr, sql)
        Label9.Text = "QA���:" & kk.Rows(0)(0)
        Label8.Text = "QA���˵��:" & Null2String(kk.Rows(0)(1))
        ComboBox1.Text = kk.Rows(0)(2)
        tb_x832p_scdm.Text = Null2String(kk.Rows(0)(4)) '
        tb_x825p_bzxs.Text = Null2String(kk.Rows(0)(3)) '��װ��ʽ
        GS_qhjd(Me) '�س����л����㣬��ע����
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        Dim fn As String = Labeltb.Text
        Dim kcc, rkts As Double
        rkts = zzero(tb_x825p_rkts.Text.Trim)
        Dim kdlk, bfb As Double '�Ƶ�����뱱����
        kdlk = zzero(tb_x832p_kdlk.Text.Trim)
        bfb = zzero(tb_x832p_bfb.Text.Trim)
        '''''''''''''''''''''''''''''''''''
        Try
            kcc = kc.Text
        Catch ex As Exception
            MsgBox("����ȷ��д����") : Exit Sub
        End Try
        Try
            '����������������������
            If GF_storelog2("������" & ph.Text, "����") = False Then
                Exit Sub
            End If
            '������������������������
            Dim sql As String = "update tb_x832p set tb_x832p_bzxs='" & tb_x825p_bzxs.Text & "',tb_x832p_cfdd='" & tb_x825p_cfdd.Text & "',tb_x832p_rkts=" & rkts & ","
            sql &= "tb_x832p_rkbz='" & tb_x825p_rkbz.Text & "',tb_x832p_kczl=" & kcc & ",tb_x832p_yg='" & tb_x825p_yg.Text & "'," & fn & "_ckcl=" & kcc & ",tb_x832p_sykczl=" & kcc & ","
            sql &= "tb_x832p_kdlk=" & kdlk & ",tb_x832p_bfb=" & bfb & ",tb_x832p_scdm='" & tb_x832p_scdm.Text & "' where tb_x832p_ID=" & Labelid.Text & ""
            GS_upztxx(G_cnnstr, sql)
            '���½�������
            Dim cpnb As String = ComboBox1.Text '��Ʒ���
            sql = "Insert into tb_jch(tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_bz,tb_jch_chts,tb_jch_yt,tb_jch_czrgh) values('" & cpnb & "','" & ph.Text & "','��'," & kcc & ",'" & sj.Text & "','" & tb_x825p_rkbz.Text & "'," & rkts & ",'" & tb_x825p_yg.Text & "','" & G_dlrgh & "')"
            GS_upztxx(G_cnnstr, sql)
            MsgBox("���³ɹ���") : Me.Close()
        Catch ex As Exception
            MsgBox("����ȷ��д��Ŀ") : Exit Sub
        End Try


    End Sub
    '��ֵת��Ϊ0
    Private Function zzero(ByVal str As String) As Integer
        If str = "" Then
            Return 0
        Else
            Return str
        End If
    End Function
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class