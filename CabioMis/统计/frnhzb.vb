Public Class frnhzb
    Private dbys1 As DataTable 'Ϊ������׼��
    Private Sub frnhzb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '��ʾ���µ��·�
    End Sub
    'ȷ��
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sj As Date = nian1.Text & "-" & yue1.Text & "-26" '��ʼʱ��
        Dim sjStr As String = GF_Time2Week(sj) 'ʱ�������ַ���
        Dim zqsj() As String = Split(sjStr, ",")
        Dim db3 As DataTable = New DataTable
        db3.Columns.Add("ʱ����", Type.GetType("System.String")) '0
        db3.Columns.Add("ʱ��ֹ", Type.GetType("System.String"))
        db3.Columns.Add("����ˮ���֣�", GetType(Double)) '2
        db3.Columns.Add("������(Kw.h)", GetType(Double))
        db3.Columns.Add("�����������֣�", GetType(Double))
        db3.Columns.Add("�������ͣ�L��", GetType(Double)) '5
        db3.Columns.Add("������Ȼ����L��", GetType(Double)) '6
        db3.Columns.Add("����ˮ���֣�", GetType(Double))
        db3.Columns.Add("���͵�(Kw.h)", GetType(Double))
        db3.Columns.Add("�����������֣�", GetType(Double)) '9
        db3.Columns.Add("�ͼ�ˮ���֣�", GetType(Double))
        db3.Columns.Add("�ͼ���(Kw.h)", GetType(Double))
        db3.Columns.Add("�ͼ��������֣�", GetType(Double))
        db3.Columns.Add("�ۼ�Iˮ���֣�", GetType(Double)) '13
        db3.Columns.Add("�ۼ�I��(Kw.h)", GetType(Double))
        db3.Columns.Add("�ۼ�I�������֣�", GetType(Double))
        db3.Columns.Add("�ۼ�IIˮ���֣�", GetType(Double))
        db3.Columns.Add("�ۼ�II��(Kw.h)", GetType(Double))
        db3.Columns.Add("�ۼ�II�������֣�", GetType(Double)) '18
        db3.Columns.Add("�豸������(Kw.h)", GetType(Double))
        db3.Columns.Add("����(Kw.h)", GetType(Double))
        db3.Columns.Add("����(Kw.h)", GetType(Double))
        db3.Columns.Add("QC(Kw.h)", GetType(Double))
        db3.Columns.Add("��¯��ˮ(��)", GetType(Double)) '23
        db3.Columns.Add("��¯����(Kw.h)", GetType(Double))
        db3.Columns.Add("��¯������(L)", GetType(Double))

        Dim aaRow As DataRow
        For i As Integer = 0 To zqsj.Length - 1 Step 2
            aaRow = db3.NewRow()
            aaRow(0) = zqsj(i)
            aaRow(1) = zqsj(i + 1)
            Dim cpdb As DataTable
            cpdb = get2(zqsj(i), zqsj(i + 1), "ˮ")
            aaRow(2) = FormatNumber(cpdb.Rows(0)(0), 2)
            aaRow(7) = cpdb.Rows(0)(1)
            aaRow(10) = cpdb.Rows(0)(2)
            aaRow(13) = cpdb.Rows(0)(3)
            aaRow(16) = cpdb.Rows(0)(4)
            aaRow(23) = cpdb.Rows(0)(5)
            '
            cpdb = get2(zqsj(i), zqsj(i + 1), "��")
            aaRow(3) = cpdb.Rows(0)(0)
            aaRow(8) = cpdb.Rows(0)(1)
            aaRow(11) = cpdb.Rows(0)(2)
            aaRow(14) = cpdb.Rows(0)(3)
            aaRow(17) = cpdb.Rows(0)(4)
            aaRow(19) = cpdb.Rows(0)(5)
            aaRow(20) = cpdb.Rows(0)(6)
            aaRow(21) = cpdb.Rows(0)(7)
            aaRow(22) = cpdb.Rows(0)(8)
            aaRow(24) = cpdb.Rows(0)(9)
            '
            cpdb = get2(zqsj(i), zqsj(i + 1), "����")
            aaRow(4) = cpdb.Rows(0)(0)
            aaRow(9) = cpdb.Rows(0)(1)
            aaRow(12) = cpdb.Rows(0)(2)
            aaRow(15) = cpdb.Rows(0)(3)
            aaRow(18) = cpdb.Rows(0)(4)
            aaRow(5) = cpdb.Rows(0)(5)
            aaRow(25) = cpdb.Rows(0)(6)
            '
            cpdb = get2(zqsj(i), zqsj(i + 1), "��Ȼ��")
            aaRow(6) = cpdb.Rows(0)(0)


            db3.Rows.Add(aaRow)
        Next

        Call GS_useviewbydb2(ListView1, db3, -1, 90)
        dbys1 = db3 'Ϊ������׼��
        '������ɫ
        With ListView1
            For i As Integer = 0 To .Items.Count - 1
                .Items(i).UseItemStyleForSubItems = False
                .Items(i).SubItems(0).BackColor = Color.LightSkyBlue '��ʱ��
                .Items(i).SubItems(1).BackColor = .Items(i).SubItems(0).BackColor 'ֹʱ��
                '����Ϊ����
                .Items(i).SubItems(2).BackColor = Color.LightPink
                .Items(i).SubItems(3).BackColor = .Items(i).SubItems(2).BackColor : .Items(i).SubItems(4).BackColor = .Items(i).SubItems(2).BackColor : .Items(i).SubItems(5).BackColor = .Items(i).SubItems(2).BackColor : .Items(i).SubItems(6).BackColor = .Items(i).SubItems(2).BackColor
                '����Ϊ����
                .Items(i).SubItems(7).BackColor = Color.LightGreen
                .Items(i).SubItems(8).BackColor = .Items(i).SubItems(7).BackColor : .Items(i).SubItems(9).BackColor = .Items(i).SubItems(7).BackColor
                '����Ϊ�ͼ�
                .Items(i).SubItems(10).BackColor = Color.LightBlue
                .Items(i).SubItems(11).BackColor = .Items(i).SubItems(10).BackColor : .Items(i).SubItems(12).BackColor = .Items(i).SubItems(10).BackColor
                '����Ϊ�ۼ�I
                .Items(i).SubItems(13).BackColor = .Items(i).SubItems(7).BackColor
                .Items(i).SubItems(14).BackColor = .Items(i).SubItems(13).BackColor : .Items(i).SubItems(15).BackColor = .Items(i).SubItems(13).BackColor
                '����Ϊ�ۼ�II
                .Items(i).SubItems(16).BackColor = .Items(i).SubItems(10).BackColor
                .Items(i).SubItems(17).BackColor = .Items(i).SubItems(16).BackColor : .Items(i).SubItems(18).BackColor = .Items(i).SubItems(16).BackColor
                '����Ϊ�������ŵ�
                .Items(i).SubItems(19).BackColor = .Items(i).SubItems(7).BackColor
                .Items(i).SubItems(20).BackColor = .Items(i).SubItems(19).BackColor : .Items(i).SubItems(21).BackColor = .Items(i).SubItems(19).BackColor : .Items(i).SubItems(22).BackColor = .Items(i).SubItems(19).BackColor
                '����Ϊ��¯��
                .Items(i).SubItems(23).BackColor = .Items(i).SubItems(10).BackColor
                .Items(i).SubItems(24).BackColor = .Items(i).SubItems(23).BackColor : .Items(i).SubItems(25).BackColor = .Items(i).SubItems(23).BackColor
            Next
        End With
        '�����и�
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '�ֱ��ǿ�͸�
        ListView1.SmallImageList = imgList '��������listView��SmallImageList ,��imgList����Ŵ�

    End Sub

    Private Function getsui1(ByVal str1 As String, ByVal str2 As String) As DataTable
        str1 = str1





        '��ˮ������ˮ���ͼ�ˮ���ۼ�һˮ���ۼ���ˮ,��¯��ˮ
        Dim zs As String = " tb_zls_zlszb "
        Dim s1 As String = " tb_zls_hg + tb_zls_fx  + tb_zls_pl + tb_zls_tca + tb_zls_tcb "
        Dim s2 As String = " tb_zls_tc "
        Dim s3 As String = " tb_zls_lfj "
        Dim s4 As String = " tb_zls_js + tb_zls_cs + tb_zls_jx "
        Dim s5 As String = "tb_zls_glf"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5
        Dim sql As String = "select top 1 " & szfc & " from tb_zls where tb_zls_rq< '" & str1 & "' order by  tb_zls_rq desc "
        ''''
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zls_hb from tb_zls where tb_zls_rq< '" & str2 & "' order by tb_zls_rq desc ")
        End If
        ''''
        getsui1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getdian1(ByVal str1 As String, ByVal str2 As String) As DataTable

        '�ܵ磬���͵�,�ͼ���,�ۼ�һ��,�ۼ����磬�豸���������������У�qc,��¯����
        Dim zs As String = "tb_dian_zjlg"
        's1 = "tb_dian_zjlg + tb_dian_qcdl - tb_dian_wszdlyzm - tb_dian_zzm + tb_dian_sbdlzm - tb_dian_zczm - tb_dian_yxsys - tb_dian_zcdlzb - tb_dian_wlzm - tb_dian_pka - tb_dian_pkb - tb_dian_pkc - tb_dian_xfjdl"
        Dim s1 As String = "tb_dian_fxdlzb-tb_dian_sbdlwxj-tb_dian_yxsys+tb_dian_qcdl+tb_dian_zcyfx-tb_dian_zczm-tb_dian_pka-tb_dian_pkb-tb_dian_pkc-tb_dian_wlzm"
        Dim s2 As String = "tb_dian_tcdl + tb_dian_jldl + tb_dian_zczm * 0.5"
        Dim s3 As String = "tb_dian_zcdlzb - tb_dian_yfdl - tb_dian_tcdl - tb_dian_qcdl - tb_dian_jldl + tb_dian_zczm * 0.5"
        Dim s4 As String = "tb_dian_xfjdl+tb_dian_5t" '�ۼ�����
        Dim s5 As String = "tb_dian_zjlg - tb_dian_wszdlyzm - tb_dian_zzm + tb_dian_sbdlzm - tb_dian_zcyfx - tb_dian_fxdlzb - tb_dian_zcdlzb + tb_dian_sbdlwxj - tb_dian_xfjdl-tb_dian_glf-tb_dian_xfjdl-tb_dian_5t " '�豸����
        Dim s6 As String = "tb_dian_yxsys + tb_dian_yfdl" '����
        Dim s7 As String = "tb_dian_wszdlyzm + tb_dian_zzm - tb_dian_sbdlzm + tb_dian_wlzm" '����
        Dim s8 As String = "tb_dian_pka + tb_dian_pkb + tb_dian_pkc" 'qc
        Dim s9 As String = "tb_dian_glf"
        Dim szfc As String = zs & "," & s1 & "," & s2 & "," & s3 & "," & s4 & "," & s5 & "," & s6 & "," & s7 & "," & s8 & "," & s9
        Dim sql As String = "select top 1 " & szfc & " from tb_dian where tb_dian_rq< '" & str1 & "' order by tb_dian_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_dian_hb from tb_dian where tb_dian_rq< '" & str2 & "' order by tb_dian_rq desc ")
        End If
        getdian1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getzqb1(ByVal str1 As String, ByVal str2 As String) As DataTable
        Dim zs As String = "tb_zqb_zqzb+tb_zqb_zqzb2+tb_zqb_zqzb3/1000" '�����ܱ�1+�����ܱ�2+�����ܱ�3
        Dim s1 As String = "tb_zqb_zxg + tb_zqb_jsdg + tb_zqb_xtg + tb_zqb_hg + tb_zqb_xsdg + tb_zqb_plj + tb_zqb_qc"
        Dim s2 As String = "tb_zqb_tca + tb_zqb_tcb + tb_zqb_tcc + tb_zqb_jl"
        Dim s3 As String = "tb_zqb_fj"
        Dim s4 As String = "tb_zqb_zqzb3 /1000" '�������ܱ�3������,�����2010.4.28��14ʱ�޸�

        Dim szfc As String = zs & ",(" & s1 & ")/1000,(" & s2 & ")/1000,(" & s3 & ")/1000," & s4 & ",'0','0'"
        Dim sql As String = "select top 1" & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' order by tb_zqb_rq desc ")
        End If
        getzqb1 = GF_CreateDataSource(G_cnnstr, sql)
    End Function
    Private Function getCaiYou(ByVal str1 As String, ByVal str2 As String) As Integer ''�����ܱ�,ʱ���������֮��\
        'MsgBox(str1 & "^^^^^^" & str2)
        Dim sql As String = "select tb_zqb_cyzb+tb_zqb_glcy from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%��ѹ����������%' or tb_zqb_hb not Like '%��¯��������%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        '��ѹ���������� + ��¯��������
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + Convert.ToInt32(cy.Rows(j)(0).ToString())
        Next
        getCaiYou = zcy
    End Function
    Private Function getCaiYou2(ByVal str1 As String, ByVal str2 As String) As Integer ''�����ܱ�,ʱ���������֮��
        Dim sql As String = "select tb_zqb_glcy from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq>= '" & str1 & "') and (tb_zqb_hb not Like '%��ѹ����������%' or tb_zqb_hb not Like '%��¯��������%'or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        '��ѹ���������� + ��¯��������
        Dim cy As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim zcy As Integer = 0
        For j As Integer = 0 To cy.Rows.Count - 1
            zcy = zcy + Convert.ToInt32(cy.Rows(j)(0).ToString())
        Next
        getCaiYou2 = zcy
    End Function

    Private Function getZQ(ByVal str1 As String, ByVal str2 As String) As DataTable '��Ȼ���ܱ�
        '����Ȼ��
        Dim zs As String = "tb_zqb_trqzb+tb_zqb_trqxg "
        Dim szfc As String = zs
        Dim sql As String = "select top 1" & szfc & " from tb_zqb where tb_zqb_rq< '" & str1 & "' order by tb_zqb_rq desc "
        If str2 <> "" Then
            sql = clsql(sql, "select top 1 tb_zqb_hb from tb_zqb where tb_zqb_rq< '" & str2 & "' order by tb_zqb_rq desc ")
        End If
        'Dim sql As String = "select tb_zqb_trqzb from tb_zqb where (tb_zqb_rq< '" & str2 & "' and tb_zqb_rq> '" & str1 & "') and (tb_zqb_hb not Like '%��Ȼ���ܱ�%' or tb_zqb_hb is null)" '(instr(tb_zqb_hb,'�����ܱ�')=0 and tb_zqb_hb<>'�����ܱ�'" )
        getZQ = GF_CreateDataSource(G_cnnstr, sql)
    End Function

    '���ڡ��������ܵ�ʵ��
    '��sql�����д����������ֶα�Ϊ����0
    Private Function clsql(ByVal sql As String, ByVal sql2 As String) As String 'sqlΪ������sql�ַ�����sql2Ϊ��ѯ�����¼sql�ַ���
        Dim hbdb As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        If hbdb.Rows(0)(0).GetType Is Type.GetType("System.String") Then
            Dim ctableName As String = GF_zhzfccx(hbdb.Rows(0)(0).ToString()) '��ѯֹʱ��������¼�ġ������ֶ�����
            hbdb = GF_CreateDataSource(G_cnnstr, "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_mx in(" & ctableName & ")") '�������ֶ����ݶ�ӦӢ���ֶ�����DATATABLE
            For i As Integer = 0 To hbdb.Rows.Count - 1
                If hbdb.Rows(i)(0).ToString() = "tb_zls_tc" Then
                    hbdb.Rows(i)(0) = "tb_zls_tc "
                End If
                sql = Replace(sql, hbdb.Rows(i)(0).ToString(), "0") 'hbdb.Rows(i)(0)�ǡ������ֶ����ݶ�ӦӢ���ֶ�����
            Next
        End If
        clsql = sql
    End Function

    Private Function get2(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As DataTable
        Dim k1, k2 As New DataTable
        str1 = str1 & " 00:00:00"
        str2 = str2 & " 23:59:59"
        If str3 = "ˮ" Then
            k1 = getsui1(str1, str2)
            k2 = getsui1(str2, "")
        ElseIf str3 = "��" Then
            k1 = getdian1(str1, str2)
            k2 = getdian1(str2, "")
        ElseIf str3 = "����" Then
            k1 = getzqb1(str1, str2)
            k2 = getzqb1(str2, "")
        ElseIf str3 = "��Ȼ��" Then
            k1 = getZQ(str1, str2)
            k2 = getZQ(str2, "")
        End If

        Dim kk As DataTable = k1.Clone
        Dim row As DataRow = kk.NewRow()
        For i As Integer = 0 To k1.Columns.Count - 1
            Try
                row(i) = FormatNumber((k2.Rows(0)(i)) - Null2zero(k1.Rows(0)(i)), 2)
                If str3 = "����" And i = 5 Then
                    row(5) = getCaiYou(str1, str2) '�����ܱ�,ʱ���������֮��
                End If
                If str3 = "����" And i = 6 Then
                    row(6) = getCaiYou2(str1, str2)
                End If
            Catch ex As Exception
            End Try
        Next
        kk.Rows.Add(row)
        get2 = kk
    End Function
 
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        'GS_toexcel(ListView1, nian1.Text & "��" & yue1.Text & "��ͳ��", Me)
        GS_dbtoexcel(dbys1, nian1.Text & "��" & yue1.Text & "��ͳ��", Me)
    End Sub


    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class