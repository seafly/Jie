Public Class Frtb_x823p
    Dim th As String '����
    Dim dt As DataTable
 
    Private Sub Frtb_x823p_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

 

        GS_qhjd(Me) '�س����л����㣬��ע����
        th = Label3.Text
        showzhsj2(th, Me, "") '��ʾ���һ����¼����ϸ
        ''''''''''''''''''''''''''''
        Dim ylsj As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_n441f where tb_n441f_ID=" & Labelid.Text)


        tp1.Text = "���ϵ��ţ�" & ylsj.Rows(0)("tb_n441f_num2") & " ARA�����ţ�" & ylsj.Rows(0)("tb_n441f_aaph") _
        & " ����������" & ylsj.Rows(0)("tb_n441f_dpzl") & " ARA������" & ylsj.Rows(0)("tb_n441f_ara")
        tb_n441f_jgrq.Text = Date.Now
        'tb_n441f_cplb.Text = ylsj.Rows(0)("tb_n441f_cplb") '���ز�Ʒ���Ϊ��С����ֵ׼��
     
        ''''''''''''''''''''''''''''
        tb_n441f_num.Text = ClassPhgn.ClassPhgn_Get(th, "-") '�õ���ǰ����+1������
        If th = "1�����ۼ�������" Then
            Chentextintz1.Visible = False : Chentextintz2.Visible = False : Label1.Visible = False : Label2.Visible = False
            Label26.Visible = False : Label25.Visible = False
        Else
            Chentextintz1.Visible = True : Chentextintz2.Visible = True : Label1.Visible = True : Label2.Visible = True
            Label26.Visible = True : Label25.Visible = True
            Chentextintz1.Text = 1 : Chentextintz2.Text = 1
        End If
        Dim dt4 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_l358d_qz,tb_l358d_dqz from tb_l358d where tb_l358d_zd='3����С��'")
        Label25.Text = "(��ǰ:" & dt4.Rows(dt4.Rows.Count - 1)(0) & "-" & dt4.Rows(dt4.Rows.Count - 1)(1) & ")"
        dt4 = GF_CreateDataSource(G_cnnstr, "select tb_l358d_qz,tb_l358d_dqz from tb_l358d where tb_l358d_zd='4����С��'")
        Label26.Text = "(��ǰ:" & dt4.Rows(dt4.Rows.Count - 1)(0) & "-" & dt4.Rows(dt4.Rows.Count - 1)(1) & ")"

        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='�ϸ�' and tb_i259b_yxx='��Ч' " '������0
        dt = GF_CreateDataSource(G_cnnstr, sql) '�õ�ԭ�ϱ�

        If tb_n441f_y876r.Text = "0" Then
            tb_n441f_y876r.Text = ""
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("��ӷۼ�������") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        '''''''''�жϱ���''''''''''''

        'If GF_YZSJ(Me, "tb_n441f_y875r,tb_n441f_i245a,tb_n441f_i245at,tb_n441f_y875rt,tb_n441f_a943s,tb_n441f_a943st,tb_n441f_y876r,tb_n441f_e95w") = False Then '��֤�ؼ�
        '    Exit Sub
        'End If
        '��֤������д���Ƿ���ȷ()
        If GF_yzfglr(tb_n441f_y876r.Text.Trim, tb_n441f_e95w.Text.Trim) = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''''�ж�ԭ�Ͽ���Ƿ�
        Dim ylstr As String = Gf_pdylkc(tb_n441f_m397e, Me) & Gf_pdylkc(tb_n441f_a918s, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_d61v, Me) & Gf_pdylkc(tb_n441f_a943s, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_e88w, Me) & Gf_pdylkc(tb_n441f_v734n, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_i245a, Me) & Gf_pdylkc(tb_n441f_j291b, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_y875r, Me) & Gf_pdylkc(tb_n441f_rt, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_rqdbf, Me) & Gf_pdylkc(tb_n441f_pttj, Me) & Gf_pdylkc(tb_n441f_llz, Me)
        If ylstr <> "" Then
            MsgBox(ylstr)
            Exit Sub
        End If
        ''''''''''''''''''''�ϼƻ���
        GS_hjkcylkc(tb_n441f_m397e, tb_n441f_z884r, Me)
        GS_hjkcylkc(tb_n441f_a918s, tb_n441f_g154y, Me)
        GS_hjkcylkc(tb_n441f_d61v, tb_n441f_g180y, Me)
        GS_hjkcylkc(tb_n441f_a943s, tb_n441f_h209z, Me)
        GS_hjkcylkc(tb_n441f_e88w, tb_n441f_d66v, Me)
        GS_hjkcylkc(tb_n441f_v734n, tb_n441f_t685m, Me)
        GS_hjkcylkc(tb_n441f_i245a, tb_n441f_h201z, Me)
        GS_hjkcylkc(tb_n441f_j291b, tb_n441f_q535i, Me)
        GS_hjkcylkc(tb_n441f_y875r, tb_n441f_u693m, Me)
        GS_hjkcylkc(tb_n441f_rt, tb_n441f_rtm, Me)
        GS_hjkcylkc(tb_n441f_rqdbf, tb_n441f_rqdbfm, Me)
        GS_hjkcylkc(tb_n441f_pttj, tb_n441f_pttjm, Me)
        GS_hjkcylkc(tb_n441f_llz, tb_n441f_llzm, Me)
        '������������������������������
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("����������Ŀ������") : Exit Sub
        End If
        '''''''''''''''''''''''''����ԭ�Ͽ��
        GS_kcylkc(tb_n441f_m397e, Me)
        GS_kcylkc(tb_n441f_a918s, Me)
        GS_kcylkc(tb_n441f_d61v, Me)
        GS_kcylkc(tb_n441f_a943s, Me)
        GS_kcylkc(tb_n441f_e88w, Me)
        GS_kcylkc(tb_n441f_v734n, Me)
        GS_kcylkc(tb_n441f_i245a, Me)
        GS_kcylkc(tb_n441f_j291b, Me)
        GS_kcylkc(tb_n441f_y875r, Me)
        GS_kcylkc(tb_n441f_rt, Me)
        GS_kcylkc(tb_n441f_rqdbf, Me)
        GS_kcylkc(tb_n441f_pttj, Me)
        GS_kcylkc(tb_n441f_llz, Me)

        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '���²����˹���
        GS_storelog3("��ӷۼ���������" & tb_n441f_num.Text, "��ӷۼ�������") '���浽��־
        '''''''''''''''''''''''''''
        '������ӷۼ�С����¼
        Dim sql As String = ""
        Dim idAll As String = ""
        If th = "1�����ۼ�������" Then
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("1����С��", "-") '�õ���ǰ����+1������
            If qztemp = "" Then
                MsgBox("�����趨����ȷ") : Exit Sub
            End If
            sql = "insert into tb_p525h(tb_p525h_num2,tb_p525h_num,tb_p525h_th,tb_p525h_sbtb,tb_p525h_sbid,tb_p525h_cplb,tb_p525h_jiagdm,tb_p525h_mingc,tb_p525h_jgrq,tb_p525h_b967t) values('" & tb_n441f_num.Text & "','" & qztemp & "','1����','" & Labeltb.Text & "','" & Labelid.Text & "','" & tb_n441f_cplb.Text & "','" & tb_n441f_jiagdm.Text & "','" & tb_n441f_mingc.Text & "',getdate(),getdate()) "
            idAll = GF_upztxx2(G_cnnstr, sql, "tb_p525h")
            ClassPhgn.ClassPhgn_SetDqz2("1����С��") '������ʼֵ
        Else
            '�����ֵ�34����
            Dim qztemp As String = ClassPhgn.ClassPhgn_GetQz("3����С��")
            If qztemp = "" Then
                MsgBox("�����趨����ȷ") : Exit Sub
            End If
            Dim xh1 As String = qztemp '���ǰ�沿��
            Dim qsz1 As String = ClassPhgn.ClassPhgn_GetDqz("3����С��") '��ʼֵ

            '''''''''''''''''''''''''''
            Dim qztemp2 As String = ClassPhgn.ClassPhgn_GetQz("4����С��")
            If qztemp2 = "" Then
                MsgBox("�����趨����ȷ") : Exit Sub
            End If
            Dim xh2 As String = qztemp2 '���ǰ�沿��
            Dim qsz2 As String = ClassPhgn.ClassPhgn_GetDqz("4����С��") '��ʼֵ
            '''''''''''''''''''''''''''
            If Chentextintz1.Text > 0 Then
                For i As Integer = 1 To Chentextintz1.Text 'С�����α��i
                    Dim xph As String = ""
                    While True
                        qsz1 = qsz1 + 1
                        xph = xh1 & "-" & qsz1
                        sql = "select * from tb_p525h where tb_p525h_num='" & xph & "'"
                        If sql.YanGetDb.Rows.Count = 0 Then
                            Exit While
                        End If
                    End While
                    sql = "insert into tb_p525h(tb_p525h_num2,tb_p525h_num,tb_p525h_th,tb_p525h_sbtb,tb_p525h_sbid,tb_p525h_cplb,tb_p525h_jiagdm,tb_p525h_mingc,tb_p525h_jgrq,tb_p525h_b967t) values('" & tb_n441f_num.Text & "','" & xph & "','3����','" & Labeltb.Text & "','" & Labelid.Text & "','" & tb_n441f_cplb.Text & "','" & tb_n441f_jiagdm.Text & "','" & tb_n441f_mingc.Text & "',getdate(),getdate()) "
                    idAll = idAll & GF_upztxx2(G_cnnstr, sql, "tb_p525h") & ","
                Next
            End If
            If Chentextintz2.Text > 0 Then
                For i As Integer = 1 To Chentextintz2.Text 'С�����α��i
                    Dim xph As String = ""
                    While True
                        qsz2 = qsz2 + 1
                        xph = xh2 & "-" & qsz2
                        sql = "select * from tb_p525h where tb_p525h_num='" & xph & "'"
                        If sql.YanGetDb.Rows.Count = 0 Then
                            Exit While
                        End If
                    End While
                    sql = "insert into tb_p525h(tb_p525h_num2,tb_p525h_num,tb_p525h_th,tb_p525h_sbtb,tb_p525h_sbid,tb_p525h_cplb,tb_p525h_jiagdm,tb_p525h_mingc,tb_p525h_jgrq,tb_p525h_b967t) values('" & tb_n441f_num.Text & "','" & xph & "','4����','" & Labeltb.Text & "','" & Labelid.Text & "','" & tb_n441f_cplb.Text & "','" & tb_n441f_jiagdm.Text & "','" & tb_n441f_mingc.Text & "',getdate(),getdate()) "
                    idAll = idAll & GF_upztxx2(G_cnnstr, sql, "tb_p525h") & ","
                Next
            End If
            ClassPhgn.ClassPhgn_SetDqz("3����С��", qsz1) '������ʼֵ
            ClassPhgn.ClassPhgn_SetDqz("4����С��", qsz2) '������ʼֵ
        End If
        ClassPhgn.ClassPhgn_SetDqz2(th) 'ʹ��������ǰ����+1

        '��������������²���id�ֶ�
        sql = "update tb_n441f set tb_n441f_xbtb='tb_p525h',tb_n441f_glid='" & idAll & "' where tb_n441f_ID=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        Me.Close()
    End Sub
    Private Sub tb_n441f_j291b_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_j291b.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "ά����C��")
    End Sub
    Private Sub tb_n441f_a918s_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_a918s.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��ѿ����")
    End Sub

    Private Sub tb_n441f_m397e_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_n441f_m397e.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��ѿ����")
    End Sub

    Private Sub tb_n441f_a943s_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_a943s.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.003' or tb_i259b_i231a='2.04.016' or tb_i259b_i231a='2.04.017' or tb_i259b_i231a='2.04.019' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "���Ե��")
    End Sub

    Private Sub tb_n441f_d61v_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_d61v.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��������")
    End Sub
    Private Sub tb_n441f_v734n_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_v734n.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��������")
    End Sub

    Private Sub tb_n441f_e88w_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_n441f_e88w.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "��������")
    End Sub

    Private Sub tb_n441f_i245a_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_i245a.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.001' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "������")
    End Sub
    Private Sub tb_n441f_y875r_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_y875r.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " tb_i259b_i231a='2.04.010' or tb_i259b_i231a='2.04.018'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "���������ǽ�")
    End Sub
    Private Sub tb_n441f_rt_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_n441f_rt.MouseDoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.014' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����")
    End Sub

    Private Sub tb_n441f_rqdbf_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_n441f_rqdbf.MouseDoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.021' or tb_i259b_i231a='2.04.015' or tb_i259b_i231a='2.04.013'  or tb_i259b_i231a='2.04.022' or tb_i259b_i231a='2.04.023' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "���嵰�׷�")
    End Sub

    Private Sub tb_n441f_pttj_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_n441f_pttj.MouseDoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.020' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "�����ǽ�")
    End Sub

    Private Sub tb_n441f_llz_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_n441f_llz.MouseDoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.042' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "����֬")
    End Sub
    '��ʾ���һ����¼����ϸ
    Private Sub showzhsj2(ByVal str As String, ByVal str2 As Form, ByVal str3 As String)
        '�ֱ���������������,str3��������ؼ�
        str3 = GF_qhjdh(str3)
        Dim th As String = "34����"
        If str = "1�����ۼ�������" Then
            th = "1����"
        End If
        'MsgBox(Labelid.Text)
        Dim sql As String = "select  * from tb_n441f where tb_n441f_id=" & Labelid.Text
        Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dttemp.Rows.Count > 0 Then
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS = cnn.execute(sql)
            Dim j As Integer, nn As DateTimePicker
            With str2
                For j = 0 To .Controls.Count - 1
                    Dim zdsz As String = .Controls(j).Name
                    If zdsz <> "tb_n441f_rtt" And zdsz <> "tb_n441f_rqdbft" And zdsz <> "tb_n441f_pttjt" And zdsz <> "tb_n441f_llzt" Then
                        If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And .Controls(j).Visible = True And InStr(str3, GF_qhjdh(zdsz)) = 0 Then
                            Dim sj As String = ""
                            If IsDBNull(RS(zdsz).value) = False Then
                                sj = RS(zdsz).value
                            End If
                            If .Controls(j).GetType.Name = "chendatepick" Then
                                sj = Date.Now
                            End If
                            If .Controls(j).GetType.Name = "DateTimePicker" Then
                                nn = .Controls(j)
                                If sj <> "" Then
                                    nn.Text = sj
                                    If nn.ShowCheckBox = True Then
                                        nn.Checked = True
                                    End If

                                Else

                                    If nn.ShowCheckBox = True Then
                                        nn.Checked = False
                                    End If
                                End If
                            End If
                            .Controls(j).Text = sj
                        End If
                    End If
                    
                Next
            End With
            RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

        End If
    End Sub
End Class