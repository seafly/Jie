Public Class Frtb_fgqc
    Public isxg As Boolean = False '�����Ƿ��޸Ļ��������
    Private Sub Frtb_fgqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
        Me.tb_x825p_qcsh.SelectedIndex = 1
        'Dim czid As String = Labelid.Text
        'If isxg = True Then
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        'End If
        G_S_TURNTAB(Me, 1) '�ؼ�TAB˳��
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''��־��Ȩ���ж�
        If GF_storelog1("���QC") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        ''''''''''''''''''''''''''''''''''''''''''ë���������(Y/N),ë��ɫ��-��,ë��ɫ��-��,ë�ͺ�������ppm��������д
        'If GF_YZSJ(Me, "") = False Then '��֤�ؼ�
        '    Exit Sub
        'End If
        '''''''''''''''

        If tb_x825p_qcrq.Text = "" Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If


        '����ë�������ֶ�=������ë��������Kg��*��1-ˮ�֣���/ʪ����������Kg��/ø��QC������

        'Try
        '    Dim mjph As String = tb_x825p_num2.Text 'ø������
        '    Dim sql As String = "select tb_meijieQC_zy from vw_meijieQC where tb_meijieQC_num='" & mjph & "'"
        '    Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        '    Dim mjzy As Double = dt1.Rows(0)("tb_meijieQC_zy") 'ø��QC������
        '    Dim jcmyzl As Double = tb_x825p_s640k.Text '����ë������
        '    Dim sf As Double = tb_x825p_mynetaa.Text 'ˮ��
        '    Dim sjtzl As Double = tb_x825p_r583j.Text 'ʪ��������
        '    Dim llsn As Double = (jcmyzl * (1 - sf)) / (sjtzl * mjzy)
        '    tb_x825p_sn.Text = llsn
        'Catch ex As Exception
        '    MsgBox("����ë�������ֶ�=������ë��������Kg��*��1-ˮ�֣���/ʪ����������Kg��/ø��QC������,������ֶε�ֵ")
        '    Return
        'End Try

        '''''''''''''''''''''
        ''''''''''''''''''��ϸë�Ϳ��
        Dim sql As String = "select * from tb_x825pkc  where tb_x825pkc_num = '" & tb_x825p_num.Text.Trim & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim sql1 As String = "update tb_x825pkc set tb_x825pkc_qcrq= '" & tb_x825p_qcrq.Text & "',tb_x825pkc_m387e= " & tb_x825p_m387e.Text & _
                ",tb_x825pkc_r602j='" & tb_x825p_r602j.Text & "'" & _
                ",tb_x825pkc_u699m='" & tb_x825p_u699m.Text & "'" & _
                ",tb_x825pkc_q547i='" & tb_x825p_q547i.Text & "'" & _
                ",tb_x825pkc_o479g='" & tb_x825p_o479g.Text & "'" & _
                ",tb_x825pkc_r600j='" & tb_x825p_r600j.Text & "'" & _
                ",tb_x825pkc_b959t='" & tb_x825p_b959t.Text & "'" & _
                ",tb_x825pkc_t686m='" & tb_x825p_t686m.Text & "'" & _
                ",tb_x825pkc_mynetaa='" & tb_x825p_mynetaa.Text & "'" & _
                ",tb_x825pkc_gjtzy='" & tb_x825p_gjtzy.Text & "'" & _
               ",tb_x825pkc_qcsh='" & tb_x825p_qcsh.Text & "'" & _
                " where tb_x825pkc_num= '" & tb_x825p_num.Text & "'"

            GS_upztxx(G_cnnstr, sql1)
        End If

        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '���²����˹���
        GS_storelog3("���ë��QC��" & tb_x825p_num.Text.Trim, "���QC") '���浽��־
        Me.Close()
    End Sub

  
End Class