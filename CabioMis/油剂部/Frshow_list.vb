Public Class Frshow_list
    Private bm As String
    Private smbdj As String '��ʱ��������
    '����Ĺر�
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '����Ĺر�
    End Sub

    Private Sub Frshow_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("�ͼ�������") = False Then
            Me.Close() : Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        GF_OpenFaceList2(tsMenu) '�л��˵���رղ˵��ļ���
        Me.Icon = G_icon
        Me.BackgroundImage = G_backimg
        smbdj = "С��"
        weizhi()
        showsj()
    End Sub

    Private Sub Frshow_list_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        weizhi()
    End Sub

    Private Sub weizhi()
        GroupBox1.Height = Me.Height - GroupBox1.Top - 60
        GroupBox3.Height = GroupBox2.Height
        GroupBox3.Width = Me.Width - GroupBox3.Left - 10
        GroupBox1.Width = GroupBox3.Right - GroupBox2.Left
        ListView3.Width = GroupBox1.Width - 14
        ListView3.Height = GroupBox1.Height - 64
    End Sub

    Private Sub showsj()
        GS_CheckGuestDo() ' ������һ�β����Ƿ�ʱ,���ﳬʱ��ֱ���˳�����

        Button2.Visible = InStr("����,����,�ѳ�,��Ʒ��", smbdj) > 0
        ListView1.CheckBoxes = False

        GS_FaceSearch(ComboBoxserchtext, bm, 1) '�ı���ѯ��������������ı��ֶε���ʾ
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql As String = ""
        Dim sql1 As String = ""
        Dim boBox As Boolean = False

        '���Ƿ���ȡ��ʱ�����ж�
        Select Case smbdj
            Case "С��"
                sql = "select tb_b970t_ID,tb_b970t_num,tb_b970t_jgrq  from tb_b970t " _
           & "where  (tb_b970t_sfyz is null or tb_b970t_sfyz='')"
                sql1 = "select tb_b970t_ID,tb_b970t_num,tb_b970t_jgrq,tb_b970t_a949s,tb_b970t_s621k,tb_b970t_q539i,tb_b970t_l363d,tb_b970t_c17u,tb_b970t_p532i,tb_b970t_i255a,tb_b970t_s633k,tb_b970t_k303c,tb_b970t_b971t,tb_b970t_q557i,tb_b970t_a955t from tb_b970t " _
           & "where tb_b970t_xbtb is null "

            Case "�й�" 'С������Ϊ��ʶ
                '���漸��������BUG����ѡ��һ�֣�û����ӵ�ʱ�򣬻���ּ�¼�޷���ʾ��������Ƿ����ֵ��ж�Ӧ������һ�����Ų�����һ������
                sql = "select tb_b970t_ID,tb_b970t_num,tb_b970t_jgrq from tb_b970t where (tb_b970t_sfyz is null or tb_b970t_sfyz='')"
                If G_xdz > 0 Then '�ж��Ƿ�����ʱ�����
                    sql = sql & " and datediff(hh,b.tb_b970t_jgrq,getdate())>" & G_xdz
                End If
                sql1 = "select tb_b959t_ID,tb_b959t_num2,tb_b959t_num,tb_b959t_jgrq,tb_b959t_x835p,tb_b959t_r575j,tb_b959t_t665l,tb_b959t_z898r,tb_b959t_v730n,tb_b959t_k334c,tb_b959t_f119x,tb_b959t_g176y,tb_b959t_j286b,tb_b959t_a948s from tb_b959t " _
           & "where tb_b959t_xbtb is null "

            Case "���" '�й�����Ϊ��ʶ
                sql = "select tb_b959t_ID,tb_b959t_num,tb_b959t_num2,tb_b959t_jgrq from tb_b959t where (tb_b959t_sfyz is null or tb_b959t_sfyz='')"
                If G_zdd > 0 Then '�ж��Ƿ�����ʱ�����
                    sql = sql & "  and datediff(hh,b.tb_b959t_jgrq,getdate())>" & G_zdd
                End If
                sql1 = "select tb_i234a_ID,tb_i234a_num,tb_i234a_num2,tb_i234a_jgrq,tb_i234a_h225a,tb_i234a_k303c,tb_i234a_s612k,tb_i234a_u704m,tb_i234a_l170d,tb_i234a_l344d,tb_i234a_s621k,tb_i234a_j276b,tb_i234a_a929s,tb_i234a_j281b,tb_i234a_f137x from tb_i234a " _
           & "where tb_i234a_xbtb is null"
            Case "ø��" '�������Ϊ��ʶ
                sql = "select tb_i234a_ID,tb_i234a_num,tb_i234a_num2,tb_i234a_jgrq from tb_i234a where tb_i234a_sfyz is null "

                '     sql1 = "select tb_meijie_ID,tb_meijie_num,tb_meijie_num2,tb_meijie_jgrq,tb_meijie_dbmph,tb_meijie_dbmpht,tb_meijie_dbmphzl,tb_meijie_qyhnph,tb_meijie_qyhnpht,tb_meijie_qyhnphzl,tb_meijie_jsl,tb_meijie_bz from vw_meijie " _
                '& "where tb_meijie_xbtb is null"
                sql1 = "select tb_meijie_ID,tb_meijie_num,tb_meijie_num2,tb_meijie_jgrq,tb_meijie_dbmph,tb_meijie_dbmpht,tb_meijie_dbmphzl,tb_meijie_qyhnph," &
                "tb_meijie_qyhnpht,tb_meijie_qyhnphzl,tb_meijie_jsl,tb_meijie_fgtj,tb_meijie_mjzl,tb_meijie_bz from tb_meijie  " &
                " where tb_meijie_xbtb is null"

            Case "ë��" '
                sql = "select tb_meijie_ID,tb_meijie_num,tb_meijie_num2,tb_meijie_jgrq from vw_meijie where tb_meijie_xbtb is null "
                sql1 = "select tb_x825p_ID,tb_x825p_num2,tb_x825p_num,tb_x825p_jgrq,tb_x825p_r583j from tb_x825p " _
           & "where tb_x825p_xbtb is null "

            Case "����" 'ע��������1��ë��������ë�ͣ���N����������
                '����ı䣬�������ﲻ������ë��ֱ�����ɾ���
                sql = "select tb_x825pkc_ID,tb_x825pkc_num,tb_x825pkc_num2,tb_x825pkc_jgrq from tb_x825pkc " _
                & "where tb_x825pkc_xbtb is null and 1=2"
                sql1 = "select tb_k306c_ID,tb_k306c_num,tb_k306c_jgrq,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_m383e,tb_k306c_h217z,tb_k306c_z903r,tb_k306c_c5u,tb_k306c_u716m,tb_k306c_m398e,tb_k306c_v744n,tb_k306c_y860q,tb_k306c_z902r,tb_k306c_d47v,tb_k306c_c27u,tb_k306c_d39v,tb_k306c_s626k,tb_k306c_j299c,tb_k306c_t653l,tb_k306c_r574j,tb_k306c_t678l from vw_k306c " _
                & "where tb_k306c_xbtb is null "
            Case "����" '8�����ε���ɫ��(����)����һ��������֬
                '�����ʾ����
                sql = "select tb_k306c_ID,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_m383e from vw_k306c where tb_k306c_xbtb is null "
                '�ұ���ʾ������֬
                sql1 = "select tb_donghua_ID,tb_donghua_num2,tb_donghua_num,tb_donghua_jgrq from vw_donghua where tb_donghua_xbtb is null "
                boBox = True
            Case "�ѳ�"
                sql = "select tb_donghua_ID,tb_donghua_num,tb_donghua_num2,tb_donghua_jgrq,tb_donghua_mytrl from vw_donghua where tb_donghua_xbtb is null "
                sql1 = "select tb_tuoxiu_ID,tb_tuoxiu_num,tb_tuoxiu_num2,tb_tuoxiu_jgrq,tb_tuoxiu_bz from vw_tuoxiu where tb_tuoxiu_xbtb is null"
            Case "��Ʒ��" 'ע��������n���������ζ�n����Ʒ������
                sql = "select tb_tuoxiu_ID,tb_tuoxiu_num,tb_tuoxiu_num2,tb_tuoxiu_jgrq,tb_tuoxiu_mytrl from vw_tuoxiu   where tb_tuoxiu_xbtb is null"
                sql1 = "select top 20 tb_h195z_ID,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_tpyy,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_llzph,tb_h195z_llzzl,tb_h195z_llzpht,tb_h195z_pf,tb_h195z_bz,tb_h195z_wjbgrq from vw_h195z " _
           & "where tb_h195z_xbtb is null order by tb_h195z_ID desc"
                boBox = True
            Case "��������"
                sql = "select tb_jch_id,tb_jch_num from tb_jch where  tb_jch_yt='��������' and tb_jch_cz='��' and tb_jch_cplb like '%DOG%' and tb_jch_fgyph is null"
                sql1 = "select top 20 tb_h195z_ID,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_tpyy,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_llzph,tb_h195z_llzzl,tb_h195z_llzpht,tb_h195z_pf,tb_h195z_bz,tb_h195z_wjbgrq from vw_h195z " _
           & "where tb_h195z_xbtb is null order by tb_h195z_ID desc"
        End Select
        '''''''''''

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim menu1 As ContextMenuStrip = Nothing

        If boBox Then
            menu1 = New ContextMenuStrip
            menu1.Items.Add("�鿴��ϸ")
            AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
            Select Case smbdj
                Case "����"
                    menu1.Items.Add("��������")
                    AddHandler menu1.Items(1).Click, AddressOf makeDhcc
                Case "��Ʒ��"
                    menu1.Items.Add("��Ʒ������")
                    AddHandler menu1.Items(1).Click, AddressOf makeCpy
            End Select
            AddHandler menu1.Paint, Sub(sender As ContextMenuStrip, e As System.EventArgs)
                                        Try
                                            'ֻ�й�ѡ�ˣ������ſ�����
                                            If ListView1.CheckedItems.Count = 0 Then
                                                sender.Items(1).Enabled = False
                                            Else
                                                sender.Items(1).Enabled = True
                                            End If
                                        Catch ex As Exception
                                        End Try
                                    End Sub
        End If

        GS_useviewbydb2(ListView1, dt, -1, 100, boBox, menu1)
        dt = GF_CreateDataSource(G_cnnstr, sql1)
        GS_useviewbydb2(ListView2, dt, -1, 100)
        ''''''''''''''''''''''''''''''''''''''''

        GS_StoreLastDo() ' �������һ�β���ʱ��
    End Sub
    ''' <summary>
    ''' ������ѡ����
    ''' </summary>
    Private Sub makeDhcc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If smbdj <> "����" Then
            MsgBox("���ȵ��������ѡ�ٵ����������") : Exit Sub
        End If
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("δѡ������")
            Exit Sub
        End If
        Dim xzxh As String = "" 'ѡ�еľ�������
        Dim sbid As String = "" 'ѡ�еı�ʶ
        Dim mytrl As Double = 0 'ë��Ͷ����
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            xzxh = xzxh & ListView1.CheckedItems(i).SubItems(1).Text & ","
            sbid &= ListView1.CheckedItems(i).SubItems(0).Text & ","
            mytrl += ListView1.CheckedItems(i).SubItems(4).Text
        Next

        sbid = GF_removedh(sbid)
        xzxh = GF_removedh(xzxh)
        Dim nform As New Frtb_donghua
        nform.tb_donghua_mytrl.Text = mytrl
        nform.tb_tuoxiu_mytrl.Text = mytrl
        nform.Labeltb.Text = "tb_donghua" '�ϲ���
        nform.Labelid.Text = ""           '�ϲ���ʶ
        nform.tb_donghua_num2.Text = xzxh '������
        nform.Labeltb2.Text = "tb_k306c"
        nform.Labelid2.Text = sbid '�õ��ϲ�ID
        nform.tb_donghua_sbtb.Text = nform.Labeltb2.Text
        nform.tb_donghua_sbid.Text = nform.Labelid2.Text
        nform.ShowDialog()
        showsj()
    End Sub
    ''' <summary>
    ''' ��ѡ�ѳ�������Ʒ��
    ''' </summary>
    Private Sub makeCpy()
        Dim xzxh As String = "" 'ѡ�е��ѳ�����
        Dim sbid As String = "" '
        Dim mytrl As Double = 0
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            xzxh = xzxh & ListView1.CheckedItems(i).SubItems(1).Text & ","
            sbid &= ListView1.CheckedItems(i).SubItems(0).Text & ","
            mytrl += Cl_StrMag.YanFormatNum(ListView1.SelectedItems(0).SubItems(4).Text)
        Next
        sbid = GF_removedh(sbid)
        xzxh = GF_removedh(xzxh)

        Dim nform As New Frtb_h195z
        nform.tb_h195z_n426f.Text = mytrl
        nform.Labeltb.Text = "tb_h195z"
        nform.Labelid.Text = ""
        nform.tb_h195z_num2.Text = xzxh '������
        nform.Labeltb2.Text = "tb_tuoxiu"
        nform.Labelid2.Text = sbid '�õ��ϲ�ID
        nform.tb_h195z_sbtb.Text = nform.Labeltb2.Text
        nform.tb_h195z_sbid.Text = nform.Labelid2.Text
        nform.ShowDialog()
        showsj()
    End Sub

#Region "��ť���"
    'ԭ��
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New Frtb_t676l
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='tb_t676l'", 2) '�õ���������˼
        nform.ShowDialog()
        showsj()
    End Sub

    'С��
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim nform As New Frtb_b970t
        nform.Labeltb.Text = "tb_b970t"
        nform.ShowDialog()
        ListView1.CheckBoxes = False
        smbdj = "С��"
        bm = "tb_b970t"
        showsj()
    End Sub

    '�й�
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        smbdj = "�й�"
        bm = "tb_b959t"
        showsj()
        ListView1.CheckBoxes = False
    End Sub

    '���
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        smbdj = "���"
        bm = "tb_i234a"
        showsj()
        ListView1.CheckBoxes = False
    End Sub
    'ø��
    Private Sub TSB_MJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_mj.Click
        smbdj = "ø��"
        bm = "tb_meijie"
        showsj()
        ListView1.CheckBoxes = False
    End Sub

    'ë��
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        smbdj = "ë��"
        bm = "tb_x825p"
        showsj()
        ListView1.CheckBoxes = False
    End Sub

    '����
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        smbdj = "����"
        bm = "tb_k306c"
        showsj()
        ListView1.CheckBoxes = False
    End Sub
    '������ѡ
    Private Sub TSB_DH_Click(sender As Object, e As EventArgs) Handles TSB_DH.Click
        smbdj = "����"
        bm = "tb_donghua"
        ListView1.CheckBoxes = True
        showsj()
    End Sub
    '�ѳ�
    Private Sub TSB_TUOXIU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_TUOXIU.Click
        smbdj = "�ѳ�"
        bm = "tb_tuoxiu"
        showsj()
        ListView1.CheckBoxes = False
    End Sub

    '��Ʒ�ʹ�ѡ
    Private Sub TSB_CPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_CPY.Click
        smbdj = "��Ʒ��"
        bm = "tb_h195z"
        showsj()
    End Sub
    ''��Ʒ�Ͳ���
    'Private Sub TSB_CPY_CC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_CPY_CC.Click
    '    If smbdj <> "��Ʒ��" Then
    '        MsgBox("���ȵ����Ʒ�ʹ�ѡ�ٵ����Ʒ�Ͳ���") : Exit Sub
    '    End If
    '    If ListView1.CheckedItems.Count = 0 Then
    '        MsgBox("δѡ���ѳ�������") : Exit Sub
    '    End If
    '    Dim xzxh As String = "" 'ѡ�еľ�������
    '    Dim sbid As String = "" '
    '    For i As Integer = 0 To ListView1.CheckedItems.Count - 1
    '        xzxh = xzxh & ListView1.CheckedItems(i).SubItems(1).Text & ","
    '        sbid &= ListView1.CheckedItems(i).SubItems(0).Text & ","
    '    Next

    '    sbid = GF_removedh(sbid)
    '    xzxh = GF_removedh(xzxh)
    '    Dim nform As New Frtb_h195z
    '    nform.Labeltb.Text = "tb_h195z"
    '    nform.Labelid.Text = ""
    '    nform.tb_h195z_num2.Text = xzxh '������
    '    Dim xzxh2 As String = GF_zhzfccx(xzxh)
    '    Dim sql As String = "select sum(tb_k306c_k337d),sum(tb_k306c_m383e) from vw_k306c where tb_k306c_num in(" & xzxh2 & ")"
    '    Dim dts As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    '    nform.tb_h195z_s621k.Text = dts.Rows(0)(0) '���NET AA
    '    nform.tb_h195z_n426f.Text = dts.Rows(0)(1) '���ë��Ͷ����/ÿ��Ʒ����Kg��
    '    nform.Labeltb2.Text = "tb_k306c"
    '    nform.Labelid2.Text = sbid '�õ��ϲ�ID
    '    nform.tb_h195z_sbtb.Text = nform.Labeltb2.Text
    '    nform.tb_h195z_sbid.Text = nform.Labelid2.Text
    '    nform.ShowDialog()
    '    showsj()
    'End Sub
#End Region
    'һ���ޣ������ޡ�����ʱ����һ����ʾ�Ƿ����֣����͹��Ƿ�Źޣ��Ǿ�������һ�����ߣ����Ҫ˵��ԭ��
    Private Function isnextstep(tsid As String, tsmes As String, tbname As String)
        Dim r As Boolean = True
        If MsgBox("�Ƿ����" & tsmes & "?", 1, "��ʾ") <> 1 Then
            Dim aaa As String = InputBox("������ԭ��", "��ʾ")
            If aaa = "" Then
                MsgBox("������ԭ��") : r = False
            Else
                Dim sql As String = "update " & tbname & " set " & tbname & "_sfyz='��'," & tbname & "_bz=case when " & tbname & "_bz  is null then '' else " & tbname & "_bz  end + '" & aaa & "' where " & tbname & "_ID=" & tsid
                GS_upztxx(G_cnnstr, sql)
                r = False
            End If
        Else
            Dim sql As String = "update " & tbname & " set " & tbname & "_sfyz='��' where " & tbname & "_ID=" & tsid
            GS_upztxx(G_cnnstr, sql)
        End If
        Return r
    End Function
    Private Sub ListView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Select Case smbdj
            Case "�й�"
                If isnextstep(ListView1.SelectedItems(0).SubItems(0).Text, "����", "tb_b970t") = False Then
                    showsj()
                    Return
                End If
                Dim nform As New Frtb_b959t
                nform.Labeltb.Text = "tb_b959t"
                nform.Labelid.Text = ""
                nform.tb_b959t_num2.Text = ListView1.SelectedItems(0).SubItems(1).Text '������
                nform.Labeltb2.Text = "tb_b970t"
                nform.Labelid2.Text = ListView1.SelectedItems(0).SubItems(0).Text '�õ��ϲ�ID
                nform.tb_b959t_sbtb.Text = nform.Labeltb2.Text
                nform.tb_b959t_sbid.Text = nform.Labelid2.Text
                nform.ShowDialog()
                showsj()
            Case "���"
                If isnextstep(ListView1.SelectedItems(0).SubItems(0).Text, "����", "tb_b959t") = False Then
                    showsj()
                    Return
                End If
                Dim nform As New Frtb_i234a
                nform.Labeltb.Text = "tb_i234a"
                nform.Labelid.Text = ""
                nform.tb_i234a_num2.Text = ListView1.SelectedItems(0).SubItems(1).Text '������
                nform.Labeltb2.Text = "tb_b959t"
                nform.Labelid2.Text = ListView1.SelectedItems(0).SubItems(0).Text '�õ��ϲ�ID
                nform.tb_i234a_sbtb.Text = nform.Labeltb2.Text
                nform.tb_i234a_sbid.Text = nform.Labelid2.Text
                nform.ShowDialog()
                showsj()
            Case "ø��"
                If isnextstep(ListView1.SelectedItems(0).SubItems(0).Text, "�Ź�", "tb_i234a") = False Then
                    showsj()
                    Return
                End If
                'If MsgBox("ȷ��ø���𣿱���¼������Ϊ2��ø���¼,�����Զ�����", 1, "��ʾ") <> MsgBoxResult.Ok Then Return
                Dim iMj As Integer = Cl_StrMag.YanFormatNum(InputBox("������ø����������", "ø��������", 2))
                If iMj = 0 Then
                    Return
                End If

                Dim fjgph As String = ListView1.SelectedItems(0).SubItems(1).Text '�ϼ�����
                Dim sbid As Integer = ListView1.SelectedItems(0).SubItems(0).Text '�ϼ�ID
                Dim idxl As String = ""
                For i As Integer = 0 To iMj - 1
                    Dim qztemp As String = ClassPhgn.ClassPhgn_Get("ø��", "-") '�õ���ǰ����+1������
                    If qztemp = "" Then
                        MsgBox("�����趨����ȷ") : Exit Sub
                    End If
                    Dim sql As String = "insert into tb_meijie(tb_meijie_num,tb_meijie_num2,tb_meijie_sbtb,tb_meijie_sbid) values"
                    sql &= "('" & qztemp & "','" & fjgph & "','tb_i234a','" & sbid & "')"
                    idxl &= DeepCode.DeepDoDataTable.GF_upztxx2(G_cnnstr, sql, "tb_meijie") & ","
                    ClassPhgn.ClassPhgn_SetDqz2("ø��") 'ʹ��ǰ����+1
                Next
                idxl = DeepCode.DeepDoStr.GF_removedh(idxl) '�õ������id���� '�����ϲ��������ֶ�  '���·��͹�
                DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, "update tb_i234a set tb_i234a_xbtb='tb_meijie',tb_i234a_glid='" & idxl & "' where tb_i234a_id=" & sbid)

                showsj()


            Case "ë��"
                Dim nform As New Frtb_x825p
                nform.Labeltb.Text = "tb_x825p"
                nform.Labelid.Text = ""
                nform.tb_x825p_num2.Text = ListView1.SelectedItems(0).SubItems(1).Text '������
                nform.Labeltb2.Text = "tb_meijie"
                nform.Labelid2.Text = ListView1.SelectedItems(0).SubItems(0).Text '�õ��ϲ�ID
                nform.tb_x825p_sbtb.Text = nform.Labeltb2.Text
                nform.tb_x825p_sbid.Text = nform.Labelid2.Text
                nform.ShowDialog()
                showsj()
            Case "����"
                'If MsgBox("ȷ�������𣿱���¼������Ϊ4��������¼,�����Զ�����", 1, "��ʾ") <> MsgBoxResult.Ok Then Return
                'Dim fjgph As String = ListView1.SelectedItems(0).SubItems(1).Text '�ϼ�����
                'Dim sbid As Integer = ListView1.SelectedItems(0).SubItems(0).Text '�ϼ�ID
                'Dim idxl As String = ""
                'For i As Integer = 0 To 3
                '    Dim qztemp As String = ClassPhgn.ClassPhgn_Get("����", "-") '�õ���ǰ����+1������
                '    If qztemp = "" Then
                '        MsgBox("�����趨����ȷ") : Exit Sub
                '    End If
                '    Dim sql As String = "insert into tb_k306c(tb_k306c_num,tb_k306c_num2,tb_k306c_sbtb,tb_k306c_sbid) values"
                '    sql &= "('" & qztemp & "','" & fjgph & "','tb_x825p','" & sbid & "')"
                '    idxl &= DeepCode.DeepDoDataTable.GF_upztxx2(G_cnnstr, sql, "tb_k306c") & ","
                '    ClassPhgn.ClassPhgn_SetDqz2("����") 'ʹ��ǰ����+1
                'Next
                'idxl = DeepCode.DeepDoStr.GF_removedh(idxl) '�õ������id���� '�����ϲ��������ֶ�  '���·��͹�
                'DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, "update tb_x825p set tb_x825p_xbtb='tb_k306c',tb_x825p_glid='" & idxl & "' where tb_x825p_id=" & sbid)

                'showsj()
            Case "�ѳ�"
                'If MsgBox("ȷ���ѳ��𣿱���¼������Ϊ3���ѳ���¼,�����Զ�����", 1, "��ʾ") <> MsgBoxResult.Ok Then Return
                Dim iMj As Integer = Cl_StrMag.YanFormatNum(InputBox("", "�ѳ��������", 3))
                If iMj = 0 Then
                    Return
                End If

                Dim fjgph As String = ListView1.SelectedItems(0).SubItems(1).Text '�ϼ�����
                Dim sbid As Integer = ListView1.SelectedItems(0).SubItems(0).Text '�ϼ�ID
                Dim mytrl As Double = ListView1.SelectedItems(0).SubItems(4).Text / iMj 'ë��Ͷ����
                Dim idxl As String = ""
                For i As Integer = 0 To iMj - 1
                    Dim qztemp As String = ClassPhgn.ClassPhgn_Get("�ѳ�", "-") '�õ���ǰ����+1������
                    If qztemp = "" Then
                        MsgBox("�����趨����ȷ") : Exit Sub
                    End If
                    Dim sql As String = "insert into tb_tuoxiu(tb_tuoxiu_num,tb_tuoxiu_num2,tb_tuoxiu_sbtb,tb_tuoxiu_sbid,tb_tuoxiu_mytrl) values"
                    sql &= "('" & qztemp & "','" & fjgph & "','tb_donghua','" & sbid & "'," & mytrl & ")"
                    idxl &= DeepCode.DeepDoDataTable.GF_upztxx2(G_cnnstr, sql, "tb_tuoxiu") & ","
                    ClassPhgn.ClassPhgn_SetDqz2("�ѳ�") 'ʹ��ǰ����+1
                Next
                idxl = DeepCode.DeepDoStr.GF_removedh(idxl) '�õ������id���� '�����ϲ��������ֶ�  
                DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, "update tb_donghua set tb_donghua_xbtb='tb_tuoxiu',tb_donghua_glid='" & idxl & "' where tb_donghua_id=" & sbid)

                showsj()
            Case "��Ʒ��"
                'Dim nform As New Frtb_h195z
                'nform.tb_h195z_n426f.Text = ListView1.SelectedItems(0).SubItems(4).Text '������
                'nform.Labeltb.Text = "tb_h195z"
                'nform.Labelid.Text = ""
                'nform.tb_h195z_num2.Text = ListView1.SelectedItems(0).SubItems(1).Text '������
                'nform.Labeltb2.Text = "tb_tuoxiu"
                'nform.Labelid2.Text = ListView1.SelectedItems(0).SubItems(0).Text '�õ��ϲ�ID
                'nform.tb_h195z_sbtb.Text = nform.Labeltb2.Text
                'nform.tb_h195z_sbid.Text = nform.Labelid2.Text
                'nform.ShowDialog()
                'showsj()
            Case "��������"
                Dim nform As New Frtb_h195z
                nform.tb_h195z_n426f.Text = 0  'ListView1.SelectedItems(0).SubItems(1).Text '������
                nform.Labeltb.Text = "tb_h195z"
                nform.Labelid.Text = ""
                nform.tb_h195z_num2.Text = ListView1.SelectedItems(0).SubItems(1).Text '������
                nform.Labeltb2.Text = "tb_jch"
                nform.Labelid2.Text = ListView1.SelectedItems(0).SubItems(0).Text '�õ��ϲ�ID
                nform.tb_h195z_sbtb.Text = nform.Labeltb2.Text
                nform.tb_h195z_sbid.Text = nform.Labelid2.Text
                nform.ShowDialog()
                showsj()
        End Select
    End Sub
    '�ұ�˫��
    Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        If ListView2.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim sql As String = Nothing
        Dim aa As New Form
        Dim xgbm As String = ""
        Dim chioseid As String = Me.ListView2.SelectedItems(0).SubItems(0).Text 'ѡ���ID
        Select Case smbdj
            Case "ø��"
                aa = New Frtb_meijie : xgbm = "tb_meijie"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid
            Case "����"
                aa = New FrYJ_jlts : xgbm = "tb_k306c"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid
            Case "�ѳ�"
                aa = New Frtb_tuoxiu : xgbm = "tb_tuoxiu"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid
            Case Else
                Return
        End Select
        aa.Controls("Labelid").Text = chioseid
        aa.Controls("Labeltb").Text = xgbm
        Me.AddOwnedForm(aa) : aa.ShowDialog()
        showsj()
    End Sub


    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '�õ���������˼
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        showlistview3sj()
    End Sub
    Private Sub showlistview3sj()
        If GF_storelog2("��ѯ" & smbdj, "��ѯ" & smbdj) = False Then
            Exit Sub
        End If
        Dim sql As String = Nothing
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Select Case smbdj
            Case "С��"
                sql = "select tb_b970t_ID,tb_b970t_num,tb_b970t_jgrq,tb_b970t_a949s,tb_b970t_s621k,tb_b970t_q539i,tb_b970t_l363d,tb_b970t_c17u,tb_b970t_p532i,tb_b970t_i255a,tb_b970t_s633k,tb_b970t_k303c,tb_b970t_b971t,tb_b970t_q557i,tb_b970t_a955t,tb_b970t_bz,tb_b970t_p532igz,tb_b970t_mphgz,tb_b970t_vphgz,tb_b970t_i255at,tb_b970t_k303ct,tb_b970t_q557it,tb_b970t_gasnph,tb_b970t_gasnpht,tb_b970t_gasnphzl,tb_b970t_lseqjph,tb_b970t_lseqjpht,tb_b970t_lseqjphzl,tb_b970t_lsmph,tb_b970t_lsmpht,tb_b970t_lsmphzl,tb_b970t_nhgph,tb_b970t_nhgpht,tb_b970t_nhgphzl,tb_b970t_tsqnph,tb_b970t_tsqnpht,tb_b970t_tsqnphzl,tb_b970t_lsnph,tb_b970t_lsnpht,tb_b970t_lsnphzl,tb_b970t_mph,tb_b970t_mpht,tb_b970t_mphzl,tb_b970t_vph,tb_b970t_vpht,tb_b970t_vphzl,tb_b970t_sfyz from tb_b970t " _
                & "where tb_b970t_jgrq between '" & tt1 & "' and '" & tt2 & "'"
            Case "�й�"
                sql = "select tb_b959t_ID,tb_b959t_num2,tb_b959t_num,tb_b959t_jgrq,tb_b959t_x835p,tb_b959t_r575j,tb_b959t_t665l,tb_b959t_z898r,tb_b959t_v730n,tb_b959t_k334c,tb_b959t_f119x,tb_b959t_g176y,tb_b959t_j286b,tb_b959t_a948s,tb_b959t_qarq,tb_b959t_qaspjg,tb_b959t_qajgsm,tb_b959t_czrgh,tb_b959t_gh,tb_b959t_t665lt,tb_b959t_v730nt,tb_b959t_f119xt,tb_b959t_j286bt,tb_b959t_qaczrgh,tb_b959t_bz,tb_b959t_qcsh,tb_b959t_jn,tb_b959t_gasnph,tb_b959t_gasnpht,tb_b959t_gasnphzl,tb_b959t_lseqjph,tb_b959t_lseqjpht,tb_b959t_lseqjphzl,tb_b959t_lsmph,tb_b959t_lsmpht,tb_b959t_lsmphzl,tb_b959t_nhgph,tb_b959t_nhgpht,tb_b959t_nhgphzl,tb_b959t_tsqnph,tb_b959t_tsqnpht,tb_b959t_tsqnphzl,tb_b959t_lsnph,tb_b959t_lsnpht,tb_b959t_lsnphzl,tb_b959t_mph,tb_b959t_mpht,tb_b959t_mphzl,tb_b959t_vph,tb_b959t_vpht,tb_b959t_vphzl,tb_b959t_t665lgz,tb_b959t_mphgz,tb_b959t_vphgz,tb_b959t_sfyz from tb_b959t " _
           & "where tb_b959t_jgrq between '" & tt1 & "' and '" & tt2 & "'"
                '2008��10��22���޸�
            Case "���"
                sql = "select tb_i234a_ID,tb_i234a_num2,tb_i234a_num,tb_i234a_jgrq,tb_i234a_x805p,tb_i234a_h225a,tb_i234a_k303c,tb_i234a_s612k,tb_i234a_u704m,tb_i234a_l170d,tb_i234a_l344d,tb_i234a_s621k,tb_i234a_j276b,tb_i234a_a929s,tb_i234a_j281b,tb_i234a_f137x,tb_i234a_qarq,tb_i234a_qaspjg,tb_i234a_qajgsm,tb_i234a_czrgh,tb_i234a_gh,tb_i234a_k303ct,tb_i234a_u704mt,tb_i234a_l344dt,tb_i234a_j276bt,tb_i234a_j281bt,tb_i234a_qaczrgh,tb_i234a_qcrq,tb_i234a_tgph,tb_i234a_tgpht,tb_i234a_tgphzl,tb_i234a_jgph,tb_i234a_jgqyhnph,tb_i234a_jgqyhnpht,tb_i234a_bz,tb_i234a_qcsh,tb_i234a_YZSJR,tb_i234a_YZSPH,tb_i234a_CSPH,tb_i234a_lsmph,tb_i234a_lsmpht,tb_i234a_lsmphzl,tb_i234a_nhgph,tb_i234a_nhgpht,tb_i234a_nhgphzl,tb_i234a_tsqnph,tb_i234a_tsqnpht,tb_i234a_tsqnphzl,tb_i234a_lsnph,tb_i234a_lsnpht,tb_i234a_lsnphzl,tb_i234a_mph,tb_i234a_mpht,tb_i234a_mphzl,tb_i234a_vph,tb_i234a_vpht,tb_i234a_vphzl,tb_i234a_tgphgz,tb_i234a_mphgz,tb_i234a_vphgz,tb_i234a_suanph,tb_i234a_suanpht,tb_i234a_suanphzl,tb_i234a_suanphgz,tb_i234a_dygph,tb_i234a_dygpht,tb_i234a_dygphzl,tb_i234a_dygphgz,tb_i234a_xpjgph,tb_i234a_xpjgpht,tb_i234a_xpjgphzl,tb_i234a_xpjgphgz,tb_i234a_pttph,tb_i234a_pttpht,tb_i234a_pttphzl,tb_i234a_lmsph,tb_i234a_lmspht,tb_i234a_lmsphzl,tb_i234a_gasnph,tb_i234a_gasnpht,tb_i234a_gasnphzl,tb_i234a_xpjph,tb_i234a_xpjpht,tb_i234a_xpjphzl,tb_i234a_sfyz from tb_i234a " _
           & "where tb_i234a_jgrq between '" & tt1 & "' and '" & tt2 & "'"
            Case "ø��"
                '     sql = "select tb_meijie_ID,tb_meijie_num2,tb_meijie_num,tb_meijie_jgrq,tb_meijie_dbmph,tb_meijie_dbmpht,tb_meijie_dbmphzl,tb_meijie_qyhnph,tb_meijie_qyhnpht,tb_meijie_qyhnphzl,tb_meijie_bz,tb_meijie_czrgh,tb_meijie_qcsh,tb_meijie_jsl from vw_meijie " _
                '& "where tb_meijie_jgrq between '" & tt1 & "' and '" & tt2 & "'"
                sql = "select tb_meijie_ID,tb_meijie_num2,tb_meijie_num,tb_meijie_jgrq,tb_meijie_dbmph,tb_meijie_dbmpht,tb_meijie_dbmphzl,tb_meijie_qyhnph," &
                    "tb_meijie_qyhnpht,tb_meijie_qyhnphzl,tb_meijie_bz,tb_meijie_czrgh,tb_meijie_qcsh,tb_meijie_jsl,tb_meijie_fgtj,tb_meijie_mjzl from tb_meijie " &
                     "where tb_meijie_jgrq between '" & tt1 & "' and '" & tt2 & "'"
            Case "ë��"
                sql = "select tb_x825p_ID,tb_x825p_num2,tb_x825p_mingc,tb_x825p_jiagdm,tb_x825p_num,tb_x825p_jgrq,tb_x825p_r583j,tb_x825p_s640k,tb_x825p_bz,tb_x825p_czrgh from tb_x825p " _
           & "where tb_x825p_jgrq between '" & tt1 & "' and '" & tt2 & "'"
            Case "����" 'ע�������Ǹ�ë��������ë�ͣ���N����������
                sql = "select tb_k306c_ID,tb_k306c_num2,tb_k306c_num,tb_k306c_jgrq,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_m383e,tb_k306c_q559i,tb_k306c_h217z,tb_k306c_z903r,tb_k306c_c5u,tb_k306c_u716m,tb_k306c_m398e,tb_k306c_c27u,tb_k306c_d39v,tb_k306c_s626k,tb_k306c_j299c,tb_k306c_t653l,tb_k306c_r574j,tb_k306c_t678l,tb_k306c_bz,tb_k306c_c27ut,tb_k306c_s626kt,tb_k306c_t653lt " &
                    ",tb_k306c_fgfph,tb_k306c_fgfpht from tb_k306c where tb_k306c_jgrq between '" & tt1 & "' and '" & tt2 & "'"
            Case "����"
                sql = "select * from tb_donghua where tb_donghua_jgrq  between '" & tt1 & "' and '" & tt2 & "'"
            Case "�ѳ�"
                sql = "select * from tb_tuoxiu where tb_tuoxiu_jgrq  between '" & tt1 & "' and '" & tt2 & "'"
            Case "��Ʒ��", "��������" '
                sql = "select tb_h195z_ID,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_mingc,tb_h195z_jiagdm,tb_h195z_jgrq,tb_h195z_n426f,tb_h195z_c6u,tb_h195z_qaspjg,tb_h195z_s621k,tb_h195z_m408e,tb_h195z_tpyy,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_bz,tb_h195z_y876r,tb_h195z_e95w,tb_h195z_llzph,tb_h195z_llzzl,tb_h195z_llzpht,tb_h195z_pf,tb_h195z_ybd5kgph,tb_h195z_ybd5kgzl,tb_h195z_ybd5kgpht,tb_h195z_ypybdph,tb_h195z_ypybdzl,tb_h195z_ypybdpht,tb_h195z_bf,tb_h195z_bfmx,tb_h195z_zfbz ,tb_h195z_g179yt,tb_h195z_y878rt" &
                    ",tb_h195z_fgfph,tb_h195z_fgfpht from tb_h195z where tb_h195z_jgrq between '" & tt1 & "' and '" & tt2 & "'"
        End Select
        '''''''''''''''''''''''''''''''''''''''''''''''
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        sql = sql & sqlbdssep '�ı���ѯ�������ҽӵ���ѯ�ı�
        ''''''''''''''''''''''''''''''''''''''''''''
        Dim dt As DataTable
        dt = GF_CreateDataSource(G_cnnstr, sql)
        'GS_useviewbydb2(ListView3, dt, 0, 100)
        GS_DataGridViewbyDb(ListView3, dt, "0", True, True)
        GroupBox1.Text = "��ѯ�����" & GF_getListViewsz(ListView3) & "����¼"
    End Sub
    Private Sub ListView3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView3.MouseDoubleClick
        If ListView3.SelectedRows.Count < 1 Then
            Exit Sub
        End If
        Dim sql As String = Nothing
        Dim aa As New Form
        Dim xgbm As String = ""
        Dim chioseid As String = Me.ListView3.SelectedRows(0).Cells(0).Value
        Select Case smbdj
            Case "С��"
                aa = New Frtb_b970t : xgbm = "tb_b970t"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & " and " & xgbm & "_xbtb is not null"
            Case "�й�"
                aa = New Frtb_b959t : xgbm = "tb_b959t"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & " and " & xgbm & "_xbtb is not null"
            Case "���"
                aa = New Frtb_i234a : xgbm = "tb_i234a"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & " and " & xgbm & "_xbtb is not null"

            Case "ø��"
                aa = New Frtb_meijie : xgbm = "tb_meijie"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & " and tb_meijie_num is not null"
            Case "ë��"
                aa = New Frtb_x825p : xgbm = "tb_x825p"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & "  and " & xgbm & "_xbtb is not null"
            Case "����" 'ע�������Ǹ�ë��������ë�ͣ���N����������
                aa = New FrYJ_jlts : xgbm = "tb_k306c"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & " and  tb_k306c_num is not null"
            Case "��Ʒ��" 'ע��������n���������ζԸ���Ʒ������
                aa = New Frtb_h195z : xgbm = "tb_h195z"
                sql = "select " & xgbm & "_id from " & xgbm & " where " & xgbm & "_id=" & chioseid & " and " & xgbm & "_xbtb is not null"
        End Select

        '��֤����
        If GF_MakeIsSD(xgbm, chioseid) = False Then
            Exit Sub
        End If

        If sql = "" Then
            Return
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        If dt.Rows.Count > 0 Then
            MsgBox("������¼�Ѿ����뵽��һ����,�޷��޸Ļ���ɾ��!") : aa = Nothing : Exit Sub
        End If
        aa.Controls("Labelid").Text = chioseid
        aa.Controls("Labeltb").Text = xgbm
        Me.AddOwnedForm(aa) : aa.ShowDialog()
        showlistview3sj()
    End Sub

    Private Sub SpMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMenuItem.Click
        showform("tb_jcdftj")
    End Sub

    Private Sub pMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pMenuItem.Click
        showform("tb_jcfxx")
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView3, DateTimePicker1.Text & "��" & DateTimePicker2.Text, Me)
    End Sub

    'ԭ�Ϲ޵Ĵ�
    Private Sub tgMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _ylnamc, _ylgnamc, _ylph As String 'ԭ�����ơ�ԭ�Ϲ����ơ�����
        _ylnamc = "" : _ylph = ""
        _ylgnamc = sender.text
        Select Case _ylgnamc
            Case "�ǹ�����"
                _ylnamc = "������" : _ylph = "2.07.001"
            Case "�������"
                _ylnamc = "������" : _ylph = "2.06.002','2.07.045"
            Case "��Դ������"
                _ylnamc = "�Ȱ�����" : _ylph = "2.07.004"
            Case "���ݼ�������"
                _ylnamc = "���ݼ�" : _ylph = "2.07.022"
            Case "M��Һ"
                If GF_storelog1("���MV��Һ") = False Then
                    Exit Sub
                End If ' �ж��Ƿ���Ȩ��
                _ylnamc = "M��Һ" : _ylph = "2.07.012','2.07.013','2.07.014','2.07.015','2.07.017','2.07.018','2.07.019"
            Case "V��Һ"
                If GF_storelog1("���MV��Һ") = False Then
                    Exit Sub
                End If ' �ж��Ƿ���Ȩ��
                _ylnamc = "V��Һ" : _ylph = "2.07.010','2.07.016','2.07.020','2.07.016','2.07.021"
        End Select
        Dim ui As New Frtb_tg
        With ui
            ._ylgnamc = _ylgnamc
            ._ylnamc = _ylnamc
            .tb_tg_yldm.Text = _ylph
            .Text = _ylgnamc
            .ShowDialog()
        End With
    End Sub


    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("�ͼ���")
    End Sub

    Private Sub mToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mToolStripMenuItem.Click
        If GF_storelog2("����ë�͵���", "����ë�͵���") = False Then
            Exit Sub
        End If
        Dim nform As New Frfg_ss
        nform.ShowDialog()
    End Sub

    Private Sub cToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cToolStripMenuItem.Click
        If GF_storelog2("��ѯë�͵���", "��ѯë�͵���") = False Then
            Exit Sub
        End If
        Dim nform As New Frpljhcx
        nform.ComboBox1.Text = "ë�����ϼƻ�"
        nform.ShowDialog()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Dim nform As New Frfg_ss2
        nform.ShowDialog()
    End Sub

    Private Sub fscylsy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fscylsy.Click
        Dim nform As New Frfscylsy
        nform.frname = "����������"
        nform.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim nform As New Frzpfg
        'nform.ShowDialog()
        Select Case smbdj
            Case "����"
                Dim nform As New FrYJ_jlts
                nform.Labelid.Text = ""
                nform.Labeltb.Text = "tb_k306c"
                nform.tb_k306c_sbtb.Text = "tb_h195zkc"
                nform.tb_k306c_sbid.Text = "" '�õ��ϲ�ID
                If nform.ShowDialog() = DialogResult.OK Then
                    showsj()
                End If
            Case "����"
                Dim nform As New Frtb_donghua
                nform.tb_donghua_mytrl.Text = 0
                nform.tb_tuoxiu_mytrl.Text = 0
                nform.Labeltb.Text = "tb_donghua" '�ϲ���
                nform.Labelid.Text = ""           '�ϲ���ʶ
                nform.tb_donghua_num2.Text = "" '������
                nform.Labeltb2.Text = "tb_h195zkc"
                nform.Labelid2.Text = "" '�õ��ϲ�ID
                nform.tb_donghua_sbtb.Text = nform.Labeltb2.Text
                nform.tb_donghua_sbid.Text = nform.Labelid2.Text
                nform.ShowDialog()
                showsj()
            Case "�ѳ�"
                Dim nform As New Frtb_tuoxiu
                nform.Labeltb.Text = "tb_tuoxiu"
                nform.Labelid.Text = ""
                nform.tb_tuoxiu_sbtb.Text = "tb_h195zkc"
                nform.tb_tuoxiu_sbid.Text = ""
                nform.ShowDialog()
                showsj()
            Case "��Ʒ��"
                Dim nform As New Frtb_h195z
                nform.tb_h195z_n426f.Text = "" 'ë��Ͷ����
                nform.Labeltb.Text = "tb_h195z"
                nform.Labelid.Text = ""
                nform.tb_h195z_num2.Text = "" '�ϼ�����
                nform.Labeltb2.Text = "tb_h195zkc"
                nform.Labelid2.Text = "" '�õ��ϲ�ID
                nform.tb_h195z_sbtb.Text = nform.Labeltb2.Text
                nform.tb_h195z_sbid.Text = nform.Labelid2.Text
                If nform.ShowDialog() = DialogResult.OK Then
                    showsj()
                End If
        End Select
    End Sub
    Private Sub ToolStripMenuItemGRPXDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemGRPXDA.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    'ԭ�Ϲ�����
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ToolStripMenuItem2.Click, ToolStripMenuItem3.Click, _
        ToolStripMenuItem4.Click, ToolStripMenuItem5.Click, _
        ToolStripMenuItem6.Click, ToolStripMenuItem7.Click, ToolStripMenuItem8.Click, _
        ToolStripMenuItem9.Click, ToolStripMenuItem10.Click,
        VRYTP.Click, MRYTP.Click
        Dim _ylnamc, _ylgnamc, _ylph As String 'ԭ�����ơ�ԭ�Ϲ����ơ�����
        _ylnamc = "" : _ylph = ""
        _ylgnamc = sender.text
        Select Case _ylgnamc
            Case "802", "803"
                _ylnamc = "������" : _ylph = "1.01.003"
            Case "701", "702"
                _ylnamc = "���" : _ylph = "1.01.004"
            Case "401", "402"
                _ylnamc = "����" : _ylph = "1.01.005"
            Case "604", "605", "606"
                _ylnamc = "���ݼ���" : _ylph = "1.01.006"
            Case "M��Һ"
                _ylnamc = "M��Һ" : _ylph = "1.01.001"
            Case "V��Һ"
                _ylnamc = "V��Һ" : _ylph = "1.01.002"
        End Select
        Dim ui As New Frtb_tg
        'With ui
        '    ._ylgnamc = _ylgnamc
        '    ._ylnamc = _ylnamc
        '    .tb_tg_yldm.Text = _ylph
        '    .Text = _ylgnamc
        '    .tb_tg_gmc.Text = _ylnamc & "��"
        '    .ShowDialog()
        'End With

        '�ϳ�ԭ�ϲ�������

        Dim strPh As String = InputBox("������ϳɺ������", "�ϳ�" & _ylnamc, ClassPhgn.ClassPhgn_Get(_ylgnamc, "-"))

        If strPh = "" OrElse Cl_DataMag.GF_CreateDataSource("select * from tb_i259b where tb_i259b_num='" & strPh & "'").Rows.Count > 0 Then
            MsgBox("�����������")
            Return
        End If

        Dim frShow As New FrSelHcCz
        frShow.m_iCzBs = Cl_DataMag.GF_CreateDataSource("select tb_wp_ID from tb_wp where tb_wp_dm in ('" & _ylph & "')").Rows(0)("tb_wp_ID")
        frShow.m_Ph = strPh
        frShow.Text = "�ϳ�"
        frShow.Width = 628
        frShow.GroupBox1.Text = "δ���ԭ��"
        frShow.GroupBox2.Text = "�����ԭ��"

        Dim s As Object = frShow.ShowDialog()
        If s = vbOK Then
            ClassPhgn.ClassPhgn_SetDqz2(_ylgnamc) 'ʹ��ǰ����+1
        End If

    End Sub

    '�����ƻ�
    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim nn As New Fr_jljh
        nn.ShowDialog()
    End Sub


End Class