Public Class Frlpkhblpk
    Private kk As String = "" '�����������
    Private djsm As String = "" '�������ʲô
    Private Sub Frlpkhblpk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
        cz("ë��")
        GS_TranEtoC(showl) '��DataGridView���ֶη����Ϊ��������
    End Sub
    Private Sub cz(ByVal str As String) '��ʼ����������
        djsm = str
        Dim cxsql As String = ""
        Dim strTbName As String = ""
        Dim iLyb As Integer = -1
        Select Case djsm
            Case "ë��"
                'cxsql = "select tb_x825pkc.tb_x825pkc_cplb,tb_x825pkc.tb_x825pkc_mingc,tb_x825pkc.tb_x825pkc_jiagdm,tb_x825pkc.tb_x825pkc_num,tb_x825pkc.tb_x825pkc_ckcl,tb_x825pkc.tb_x825pkc_sykczl,tb_x825pkc.tb_x825pkc_cfdd,tb_x825pkc.tb_x825pkc_qaspjg,tb_x825pkc.tb_x825pkc_qajgsm,tb_x825pkc.tb_x825pkc_jgrq,tb_x825pkc.tb_x825pkc_m387e,tb_x825pkc_kczl,tb_x825pkc.tb_x825pkc_rkbz,tb_x825pkc.tb_x825pkc_yg,tb_x825pkc_rkts,tb_x825pkc.tb_x825pkc_wjbgrq,tb_x825pkc.tb_x825pkc_r600j,tb_x825pkc.tb_x825pkc_o479g ,tb_x825pkc.tb_x825pkc_q547i,tb_x825pkc.tb_x825pkc_u699m,tb_x825pkc.tb_x825pkc_bfb,tb_x825pkc.tb_x825pkc_kdlk,tb_x825pkc.tb_x825pkc_storagewzlk,tb_x825pkc.tb_x825pkc_storagemslk from tb_x825pkc where (1=1)    and tb_x825pkc.tb_x825pkc_ckcl>0   or tb_x825pkc.tb_x825pkc_sykczl>0          order by tb_x825pkc.tb_x825pkc_jgrq ASC"
                cxsql = "select tb_x825pkc.tb_x825pkc_cplb,tb_x825pkc.tb_x825pkc_mingc,tb_x825pkc.tb_x825pkc_jiagdm,tb_x825pkc.tb_x825pkc_num,tb_x825pkc.tb_x825pkc_ckcl,tb_x825pkc.tb_x825pkc_sykczl,tb_x825pkc.tb_x825pkc_cfdd,tb_x825pkc.tb_x825pkc_qaspjg,tb_x825pkc.tb_x825pkc_qajgsm,tb_x825pkc.tb_x825pkc_jgrq,tb_x825pkc_kczl,tb_x825pkc.tb_x825pkc_rkbz,tb_x825pkc.tb_x825pkc_yg,tb_x825pkc_rkts,tb_x825pkc.tb_x825pkc_wjbgrq,tb_x825pkc.tb_x825pkc_bfb,tb_x825pkc.tb_x825pkc_kdlk,tb_x825pkc.tb_x825pkc_storagewzlk,tb_x825pkc.tb_x825pkc_storagemslk from tb_x825pkc where (1=1)    and tb_x825pkc.tb_x825pkc_ckcl>0   or tb_x825pkc.tb_x825pkc_sykczl>0          order by tb_x825pkc.tb_x825pkc_jgrq ASC"
                strTbName = en_LcTableName.ë��.YanGetEnText
                iLyb = en_LcTableName.ë��
            Case "����ë��"
                cxsql = "select tb_x825pkc.tb_x825pkc_cplb,tb_x825pkc.tb_x825pkc_mingc,tb_x825pkc.tb_x825pkc_jiagdm,tb_x825pkc.tb_x825pkc_num,tb_x825pkc.tb_x825pkc_bf,tb_x825pkc.tb_x825pkc_m387e,tb_x825pkc.tb_x825pkc_bfmx,tb_x825pkc_kczl,tb_x825pkc.tb_x825pkc_rkbz,tb_x825pkc.tb_x825pkc_jgrq,tb_x825pkc.tb_x825pkc_ckcl,tb_x825pkc.tb_x825pkc_cfdd,tb_x825pkc.tb_x825pkc_qaspjg,tb_x825pkc.tb_x825pkc_qajgsm,tb_x825pkc.tb_x825pkc_bfb,tb_x825pkc.tb_x825pkc_kdlk,tb_x825pkc.tb_x825pkc_storagewzlk,tb_x825pkc.tb_x825pkc_storagemslk from tb_x825pkc where (1=1)    and tb_x825pkc.tb_x825pkc_bf>0        order by tb_x825pkc.tb_x825pkc_cplb ASC ,tb_x825pkc.tb_x825pkc_num ASC"

            Case "��Ʒ��"
                cxsql = "select tb_h195zkc.tb_h195zkc_cplb,tb_h195zkc.tb_h195zkc_mingc,tb_h195zkc.tb_h195zkc_jiagdm,tb_h195zkc.tb_h195zkc_num,tb_h195zkc.tb_h195zkc_num2,tb_h195zkc.tb_h195zkc_ckcl,tb_h195zkc.tb_h195zkc_sykczl,tb_h195zkc.tb_h195zkc_cfdd,tb_h195zkc.tb_h195zkc_qaspjg,tb_h195zkc_qaytjy,tb_h195zkc.tb_h195zkc_qajgsm,tb_h195zkc.tb_h195zkc_jgrq,tb_h195zkc.tb_h195zkc_yg,tb_h195zkc.tb_h195zkc_c6u,tb_h195zkc.tb_h195zkc_c28u,tb_h195zkc.tb_h195zkc_wjbgrq,tb_h195zkc_kczl,tb_h195zkc.tb_h195zkc_rkbz,tb_h195zkc_cw,tb_h195zkc_bfb,tb_h195zkc_kdlk,tb_h195zkc_storagewzlk,tb_h195zkc_storagemslk from tb_h195zkc where (1=1)    and tb_h195zkc.tb_h195zkc_ckcl>0   or tb_h195zkc.tb_h195zkc_sykczl>0          order by tb_h195zkc.tb_h195zkc_jgrq ASC"
            Case "���ϳ�Ʒ��"
                cxsql = "select tb_h195zkc.tb_h195zkc_cplb,tb_h195zkc.tb_h195zkc_mingc,tb_h195zkc.tb_h195zkc_jiagdm,tb_h195zkc.tb_h195zkc_num,tb_h195zkc.tb_h195zkc_bf,tb_h195zkc.tb_h195zkc_c6u,tb_h195zkc.tb_h195zkc_bfmx,tb_h195zkc_kczl,tb_h195zkc.tb_h195zkc_rkbz,tb_h195zkc.tb_h195zkc_jgrq,tb_h195zkc.tb_h195zkc_ckcl,tb_h195zkc.tb_h195zkc_cfdd,tb_h195zkc.tb_h195zkc_qaspjg,tb_h195zkc_qaytjy,tb_h195zkc.tb_h195zkc_qajgsm,tb_h195zkc.tb_h195zkc_bfb,tb_h195zkc.tb_h195zkc_kdlk,tb_h195zkc.tb_h195zkc_storagewzlk,tb_h195zkc.tb_h195zkc_storagemslk from tb_h195zkc where (1=1)    and tb_h195zkc.tb_h195zkc_bf>0        order by tb_h195zkc.tb_h195zkc_cplb ASC ,tb_h195zkc.tb_h195zkc_num ASC"

            Case "��Ʒ��"
                cxsql = "select tb_x832pkc.tb_x832pkc_cplb,tb_x832pkc.tb_x832pkc_mingc,tb_x832pkc.tb_x832pkc_jiagdm,tb_x832pkc.tb_x832pkc_num,tb_x832pkc.tb_x832pkc_ckcl,tb_x832pkc.tb_x832pkc_sykczl,tb_x832pkc_cw,tb_x832pkc.tb_x832pkc_qaspjg,tb_x832pkc_qaytjy,tb_x832pkc.tb_x832pkc_qajgsm,tb_x832pkc.tb_x832pkc_jgrq,tb_x832pkc.tb_x832pkc_scdm,tb_x832pkc.tb_x832pkc_yg,tb_x832pkc.tb_x832pkc_num2,tb_x832pkc_kczl,tb_x832pkc.tb_x832pkc_wjbgrq,tb_x832pkc.tb_x832pkc_rkbz,tb_x832pkc.tb_x832pkc_a948s,tb_x832pkc.tb_x832pkc_d65v,tb_x832pkc.tb_x832pkc_bzxs,tb_x832pkc.tb_x832pkc_f119x,tb_x832pkc.tb_x832pkc_s626k,tb_x832pkc.tb_x832pkc_bfb,tb_x832pkc.tb_x832pkc_kdlk,tb_x832pkc.tb_x832pkc_storagewzlk,tb_x832pkc.tb_x832pkc_storagemslk from tb_x832pkc where (1=1)    and tb_x832pkc.tb_x832pkc_sykczl>0 or tb_x832pkc.tb_x832pkc_ckcl>0          order by tb_x832pkc.tb_x832pkc_cplb ASC ,tb_x832pkc.tb_x832pkc_num ASC"
            Case "���ϳ�Ʒ��"
                cxsql = "select tb_x832pkc.tb_x832pkc_cplb,tb_x832pkc.tb_x832pkc_mingc,tb_x832pkc.tb_x832pkc_jiagdm,tb_x832pkc.tb_x832pkc_num,tb_x832pkc.tb_x832pkc_bf,tb_x832pkc.tb_x832pkc_bfmx,tb_x832pkc_kczl,tb_x832pkc.tb_x832pkc_rkbz,tb_x832pkc.tb_x832pkc_jgrq,tb_x832pkc.tb_x832pkc_ckcl,tb_x832pkc.tb_x832pkc_cfdd,tb_x832pkc.tb_x832pkc_qaspjg,tb_x832pkc_qaytjy,tb_x832pkc.tb_x832pkc_qajgsm,tb_x832pkc.tb_x832pkc_bfb,tb_x832pkc.tb_x832pkc_kdlk,tb_x832pkc.tb_x832pkc_storagewzlk,tb_x832pkc.tb_x832pkc_storagemslk from tb_x832pkc where (1=1)    and tb_x832pkc.tb_x832pkc_bf>0        order by tb_x832pkc.tb_x832pkc_cplb ASC ,tb_x832pkc.tb_x832pkc_num ASC"
        End Select
        kk = ""
        ComboBox1.Items.Clear() : ComboBox2.Items.Clear() : ComboBox3.Items.Clear() : ComboBox4.Items.Clear() : TextBox1.Clear() : TextBox2.Clear()
        ComboBox1.Text = "" : ComboBox2.Text = "" : ComboBox3.Text = "" : ComboBox4.Text = ""
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, cxsql)

        '*************************���QC���********************************
        If strTbName <> "" Then
            cl_theCl.setQcshowView(dt, iLyb, isAddva:=False)
            For i As Integer = 0 To dt.Rows.Count - 1  '�������Ϊ����ӽ�ȥ
                Dim Sql As String = "select  * from tb_QcVa where tb_QcVa_Qcbs =" &
                "(select top 1 tb_QcJc_ID from tb_QcJc where tb_QcJc_jcb='" & strTbName & "' " &
                "and tb_QcJc_wlbs=(select " & strTbName & "_ID from " & strTbName & " where " & strTbName & "_num='" & dt.Rows(i)(strTbName & "kc_num") & "') order by tb_QcJc_ID desc)"
                Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(Sql)
                For Each tDr As DataRow In tDt.Rows
                    Try
                        dt.Rows(i)(tDr("tb_QcVa_xmmc").trim) = tDr("tb_QcVa_xmva").trim
                    Catch ex As Exception

                    End Try
                Next
            Next
        End If
        '*********************************************************

        GroupBox1.Text = str & " �����ɸѡ������" & dt.Rows.Count & "����¼��"
        For i As Integer = 0 To dt.Columns.Count - 1 '�������ɸѡ��
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4)
            Dim bm As String = frdzxf.ddbm(dt.Columns(i).Caption) '�õ�����
            Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & bm & "'", 2) '�õ�����������
            zwmz = bmcn & ":" & zwmz
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(zwmz)
                Case "System.DateTime" : ComboBox1.Items.Add(zwmz)
                Case "System.Decimal", "System.Short", "System.Integer", "System.Int32", "System.Long"
                    ComboBox3.Items.Add(zwmz)
                    kk &= i.ToString & ","
                    'Case Else
                    '    MsgBox(zwmz & ":" & dt.Columns(i).DataType.ToString)
            End Select
        Next
        If kk <> "" Then '�����Զ������ͻ���
            With ComboBox4
                .Items.Add("����") : .Items.Add("������")
                .Items.Add("����") : .Items.Add("���ڵ���")
                .Items.Add("С��") : .Items.Add("С�ڵ���")
                .Items.Add("֮��")
                .SelectedIndex = 0
            End With
            kk = DeepCode.DeepDoStr.GF_removedh(kk)
            dt = dbqh(dt, kk) '��Ͳ����ӵ����һ��
        End If
        showl.Columns.Clear() '����ͷ����ʧ
        showl.DataSource = dt

        If kk <> "" Then
            GS_ysgx(showl) '������һ����ɫ����
        End If
        If showl.Columns.Count > 15 Then
            showl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            showl.RowHeadersWidth = 40
            'For i As Integer = 0 To showl.Columns.Count - 1
            '    If showl.Columns(i).Visible = True Then
            '        showl.Columns(i).Width = 40
            '    End If

            'Next
        End If
        GS_DataGridViewaddmenu(showl) '���Ӳ鿴��ϸ�˵�
    End Sub


    Private Sub TB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.Click, TB2.Click, TB3.Click, TB4.Click, TB5.Click, TB6.Click
        cz(sender.text)
        GS_TranEtoC(showl) '��DataGridView���ֶη����Ϊ��������
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        If kk <> "" Then '��͵��������ת��һ��
            dt1 = DeepCode.DeepDoGridView.ToDataTable(showl, 0, showl.Rows.Count - 2)
        Else
            dt1 = DeepCode.DeepDoGridView.ToDataTable(showl)
        End If

        Dim bds As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) 'ʱ���ֶ�
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '�ı��ֶ�
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then
                Return
            End If
            bds &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
        Dim cxzd3 As String = gettruezdm(ComboBox3.Text) '�����ֶ�
        If cxzd3 <> "" And TextBox2.Text.Trim <> "" Then
            cxzd3 = "[" & cxzd3 & "]"
            Dim sz As String = TextBox2.Text.Trim
            sz = Replace(sz, "��", ",") '�³������Ķ���
            Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
            If nnn <> "" Then
                bds &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
            End If
        End If
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '��ѯ���õ����DB
        GroupBox1.Text = djsm & " �����ɸѡ������" & dt2.Rows.Count & "����¼��"
        If kk <> "" Then '�����Զ������ͻ���
            dt2 = dbqh(dt2, kk) '��Ͳ����ӵ����һ��
        End If
        showl.Columns.Clear() '����ͷ����ʧ
        showl.DataSource = dt2
        If kk <> "" Then
            GS_ysgx(showl) '������һ����ɫ����
        End If

        GS_TranEtoC(showl) '��DataGridView���ֶη����Ϊ��������
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cz(djsm)
        GS_TranEtoC(showl) '��DataGridView���ֶη����Ϊ��������
    End Sub
    Private Function gettruezdm(ByVal str As String) As String '�õ�����Ӣ���ֶ�����
        Dim bmcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "left")
        Dim zdcn As String = DeepCode.DeepDoStr.GF_searchchar(str, ":", "right")
        If bmcn = "" Then
            Return zdcn
        End If
        Dim bm As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mx='" & bmcn & "'", 1) '�õ���Ӣ������
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_biao='" & bm & "' and tb_biaozdinf_mx='" & zdcn & "'", 1) '�õ�Ӣ���ֶ�����
        Return zd
    End Function

    Private Function dbqh(ByVal db As DataTable, ByVal dbindex As String) As DataTable '��Ͳ����ӵ����һ��
        With db
            If .Rows.Count > 0 Then
                Dim ws As Integer = .Columns.Count - 1
                Dim k(ws) As String
                .Rows.Add(k)
                Dim m() As String = dbindex.Split(",")
                For i As Integer = 0 To m.Length - 1
                    Dim n As Integer = m(i) '�õ���͵�������
                    '���
                    Dim zs As Double = DeepCode.DeepDoDataTable.GF_jsColumnTotal(db, n, 0, .Rows.Count - 2)

                    .Rows(.Rows.Count - 1)(n) = zs '��ֵ
                Next
            End If

        End With
        Return db
    End Function
    Private Function zhbds(ByVal zd As String, ByVal bd As String, ByVal wb As String) As String '�û����ʽ
        Dim ss As String = ""
        Dim bds As String = ""
        Select Case bd
            Case "����", "С��", "������", "����", "���ڵ���", "С�ڵ���"
                If IsNumeric(wb) = False Then
                    MsgBox("�������˷�����") : Return ""
                End If
            Case "֮��"
                If InStr(wb, ",") = 0 Then
                    MsgBox("֮����ʽӦ��������д��50,78") : Return ""
                End If
        End Select
        Select Case bd
            Case "����" : ss = ">" : bds = zd & ss & wb
            Case "С��" : ss = "<" : bds = zd & ss & wb
            Case "������" : ss = "<>" : bds = zd & ss & wb
            Case "����" : ss = "=" : bds = zd & ss & wb
            Case "���ڵ���" : ss = ">=" : bds = zd & ss & wb
            Case "С�ڵ���" : ss = "<=" : bds = zd & ss & wb
            Case "֮��"
                Dim sz1, sz2 As Double
                sz1 = DeepCode.DeepDoStr.GF_searchchar(wb, ",", "left")
                sz2 = DeepCode.DeepDoStr.GF_searchchar(wb, ",", "right")
                bds = zd & ">=" & sz1 & " and " & zd & "<=" & sz2
        End Select
        Return bds
    End Function
    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub wz()

        showl.Width = Me.Width - 10
        showl.Height = Me.Height - showl.Top - 50
    End Sub

    Private Sub TOEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOEXCEL.Click
        GS_toexcel(showl, GroupBox1.Text, Me)
    End Sub

    Private Sub Frlpkhblpk_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim nform As New Frzdybb
        Dim sql As String = "select * from tb_sjbf"
        nform.bbname.Text = "��Ʒ��Ͳ��ϸ�Ʒ�ⱸ��"
        nform.bbsql.Text = sql
        nform.ShowDialog()
    End Sub

    Private Sub TB7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB7.Click
        Dim nform As New Frcphzb
        nform.ShowDialog()
    End Sub
End Class