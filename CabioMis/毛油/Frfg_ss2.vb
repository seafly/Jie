Public Class Frfg_ss2

    Private Sub Frfg_ss2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '�س����л����㣬��ע����
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("ȷ������������", 1, "��ʾ") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        If GF_YZSJ(Me, "tb_mypl_bz") = False Then '��֤�ؼ�
            Exit Sub
        End If
        '''''''''''''''
        '''''''''''''''''''''''''''''
        If GF_storelog1("�ֹ�ë�͵���") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        ''''''''''''''''''''
        'Me.tb_mypl_myhl.Visible = False
        Dim cfsl As Integer = tb_mypl_p532i.Text '�������
        'Dim jhhl As Double = tb_mypl_myhl.Text  '�ƻ�����
        Dim t1 As String = tb_mypl_num2.Text.Trim : t1 = Replace(t1, "��", ",")
        Dim myphxl() As String = Split(t1, ",") 'ë������
        Dim t2 As String = tb_mypl_p524h.Text.Trim : t2 = Replace(t2, "��", ",")
        Dim myphxl2() As String = Split(t2, ",") '�۳���Ӧë������
        If UBound(myphxl) <> UBound(myphxl2) Then
            MsgBox("�������Ӧ�۳���������") : Exit Sub
        End If
        Dim t3 As String = tb_mypl_e95w.Text.Trim : t3 = Replace(t3, "��", ",")
        Dim dpzlxl() As String = Split(t3, ",") '����������������
        Dim t4 As String = tb_mypl_q569j.Text.Trim : t4 = Replace(t4, "��", "#")

        Dim jlpmx() As String = Split(t4, "#") '��������ϸ����

        If UBound(dpzlxl) + 1 <> cfsl Or UBound(jlpmx) + 1 <> cfsl Then
            MsgBox("�����������") : Exit Sub
        End If
        Dim ph As String = GF_getnewpath2() '��������
        Dim sqltemp As String = Nothing
        Dim hjzl As Double = 0 '�ϼ�����
        Dim idall As String = "" 'ԭ����ID
        For i As Integer = 0 To UBound(myphxl)
            Dim dmymx As String = myphxl(i) '����
            Dim dkczl As String = myphxl2(i) '��Ӧ�۳�����
            Dim sql As String = "select tb_x825p_sykczl,tb_x825p_id from tb_x825p  where tb_x825p_sykczl>=" & dkczl & " and tb_x825p_num='" & dmymx & "'"
            Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            sql = "select tb_x825p_qaspjg from tb_x825p  where tb_x825p_qaspjg='�ϸ�' or tb_x825p_qaspjg='����' and tb_x825p_num='" & dmymx & "'"
            Dim dttemp2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dttemp.Rows.Count = 0 Then
                MsgBox("�����ڸ�����:" & dmymx & "���߸�����ʣ����С�ڶ�Ӧ�۳�������:" & dkczl) : Exit Sub
            ElseIf dttemp2.Rows.Count = 0 Then
                MsgBox("ë������QA����������Ǻϸ���ߴ�����") : Exit Sub
            Else

                hjzl = hjzl + dkczl
                idall &= dttemp.Rows(0)(1) & ","
                '���¿��
                sql = "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & dkczl & "  where  tb_x825p_num='" & dmymx & "'" & vbCrLf
                sqltemp = sqltemp & sql
            End If
        Next
        '  Try
        '�����¼������
        idall = GF_removedh(idall)
        Dim tsql As String = sqltemp & vbCrLf & "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_q569j,tb_mypl_czrgh,tb_mypl_sbtb,tb_mypl_sbid,tb_mypl_bz) values"
        tsql = tsql & "('" & tb_mypl_a953t.Text & "','" & ph & "','" & ph & "','" & t1 & "','" & t2 & "'," & hjzl & ",'" & t3 & "'," & cfsl & ",'" & t4 & "','" & G_dlrgh & "','tb_x825p','" & idall & "','" & tb_mypl_bz.Text & "')"
        Dim newid As String = GF_upztxx2(G_cnnstr, tsql, "tb_mypl") '�õ�ë�����ϵ�ID
        '�������θ���ë�ͱ���²�ID�ֶ�
        Dim newidsz() As String = idall.Split(",")
        For i As Integer = 0 To UBound(newidsz)
            GS_gengsb("tb_x825p", newidsz(i), "tb_mypl", newid) '�����ϲ�ID
        Next
        GS_storelog3("�ֹ�ë�͵��䣺" & ph, "�ֹ�ë�͵���") '���浽��־
        MsgBox("�ֹ�ë�͵���ɹ���") : Me.Close()
        '   Catch ex As Exception
        '    MsgBox("���ݲ�����ִ�����������") : Exit Sub
        'End Try

    End Sub
End Class