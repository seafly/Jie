Public Class frdzxf

    Private Sub frdzxf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_zdycxb from tb_js where tb_js_mc='" & G_js & "'")
        If IsDBNull(kk.Rows(0)(0)) Then
            MsgBox("��δ�趨�ý�ɫ�κ��Զ���鿴��Ȩ��") : Me.Close() : Exit Sub
        End If
        Dim jsckqx As String = GF_zhzfccx(kk.Rows(0)(0)) ' '����ַ������IN��ѯ�ַ���

        kk = GF_CreateDataSource(G_cnnstr, "select * from tb_biaoinf where tb_biaoinf_mc  in (" & jsckqx & ") order by tb_biaoinf_id")
        Call GS_wlbktlr2(gongxu, kk, 2, "")
        gongxu.SelectedItem = gongxu.Items(0)
        Call showsj()
        ListView2.View = View.Details
        ListView2.Columns.Add("tb", 0) : ListView2.Columns.Add("��", 100) : ListView2.Columns.Add("�ֶ�", 100) : ListView2.Columns.Add("�ֶ�����", 100) : ListView2.Columns.Add("����", 100) : ListView2.Columns.Add("����", 50) : ListView2.Columns.Add("�߼�", 50)
    End Sub

    Private Sub gongxu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gongxu.SelectedIndexChanged
        Call showsj()
    End Sub
    Private Sub showsj()
        Dim gx As String = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mx='" & gongxu.Text & "'", 1)
        Dim sql As String
        Dim dt As DataTable
        sql = "select tb_biaozdinf_mc,'" & gongxu.Text & "' as �� ,tb_biaozdinf_mx ,tb_biaozdinf_lx from tb_biaozdinf "
        sql = sql & "where tb_biaozdinf_biao='" & gx & "' and tb_biaozdinf_mx not in ('�ϲ���','�²���','�ϲ�ID','�²�ID','����')"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView1, dt, 0, 100)
        showl.Rows.Clear()
        showl.Columns.Clear() '����ͷ����ʧ
        ListView2.Items.Clear() : Label2.Text = "��ѯ�����"
    End Sub
 
    '�����������������������������������������ǻ�ԭ���ݡ�����������������������������������������������������������
    '��listviewstr�����ݻ�ԭ��listviewstr2
    Private Sub hysj(ByVal listviewstr As ListView, ByVal listviewstr2 As ListView)
        Dim ylsy As Integer = listviewstr.SelectedItems(0).Index
        Dim k1, k2 As String
        k1 = listviewstr.SelectedItems(0).SubItems(1).Text
        k2 = listviewstr.SelectedItems(0).SubItems(2).Text
        For i As Integer = 0 To listviewstr2.Items.Count - 1
            If listviewstr2.Items(i).SubItems(1).Text = k1 And listviewstr2.Items(i).SubItems(2).Text = k2 Then
                MsgBox("���ֶ��Ѿ�ѡ��") : Exit Sub
            End If
            If i > 0 And listviewstr2.Items(i).SubItems(1).Text <> k1 Then
                MsgBox("�Զ����ѯ����ѡ��ͬ�ı�") : Exit Sub
            End If
        Next
      
        Dim kk As ListViewItem = listviewstr2.Items.Add(listviewstr.SelectedItems(0).SubItems(0).Text)
        For i As Integer = 1 To listviewstr2.Columns.Count - 4
            With kk.SubItems
                .Add(listviewstr.SelectedItems(0).SubItems(i).Text)
            End With
        Next
        kk.SubItems.Add("��") : kk.SubItems.Add("��") : kk.SubItems.Add("")
    End Sub
    '������ɾ��
    Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick

        Dim aa As New frdzxf2
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
        ' Dim ylsy As Integer = ListView2.SelectedItems(0).Index
        ' ListView2.Items.RemoveAt(ylsy)
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        hysj(ListView1, ListView2)
    End Sub
    '��ѯ
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListView2.Items.Count = 0 Then
            Exit Sub
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, GZSQL(ListView2))
        Try
            Call GS_DataGridViewbyDb(showl, dt, True, True)
            Label2.Text = "��ѯ�����" & GF_getListViewsz(showl) & "����¼"
        Catch ex As Exception
            MsgBox("���������������")
        End Try

    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub
    Private Function GZSQL(ByVal STR As ListView) As String
        Dim zdzfc As String = ""
        Dim tjzfc As String = ""
        Dim pxzfc As String = ""
        Dim bm As String = ""
        With STR
            For I As Integer = 0 To ListView2.Items.Count - 1
                Dim ZDM As String = .Items(I).SubItems(0).Text '�ֶ���
                bm = ddbm(ZDM) '�õ�����
                Dim ZDlx As String = .Items(I).SubItems(3).Text '�ֶ�����
                Dim ZDtj As String = .Items(I).SubItems(4).Text '����
                Dim ZDpx As String = .Items(I).SubItems(5).Text '����
                Dim locic As String = .Items(I).SubItems(6).Text '�߼�
                zdzfc = zdzfc & bm & "." & ZDM & ","
                Dim hh As String = tjbds(ZDlx, ZDtj, ZDM, locic)
                '  If hh <> "" Then
                tjzfc = tjzfc & hh & " "
                '  End If
                If pxfs(ZDpx) <> "" Then
                    pxzfc = pxzfc & bm & "." & ZDM & pxfs(ZDpx) & ","
                End If
            Next
        End With
        zdzfc = GF_removedh(zdzfc) '��ѯ���ֶδ�
        tjzfc = GF_removedh(tjzfc) '�����ֶδ�
        pxzfc = GF_removedh(pxzfc) '������ֶδ�
        If Trim(pxzfc) <> "" Then
            pxzfc = " order by " & pxzfc
        End If
        GZSQL = "select " & zdzfc & " from " & bm & " where (1=1) " & tjzfc & pxzfc
    End Function
    Public Function tjbds(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String, ByVal locic As String) As String '�õ��������ʽ,�ֶ�����,����,����
        Dim ysf As String = locic '�߼�
        Select Case locic
            Case "��", "" : ysf = " and "
            Case "��" : ysf = " or "
        End Select
        tjbds = ""
        str3 = ddbm(str3) & "." & str3 '�ֶ���
        If str2 = "��" Then
            Exit Function
        End If
        Dim tj1 As String = GF_searchchar(str2, "��", "left") '����
        Dim tj2 As String = GF_searchchar(str2, "��", "right") '����
        If str1 = "varchar(8000)" And tj1 = "ģ��" Then
            tjbds = ysf & "(" & str3 & " like '%" & tj2 & "%')"
            Exit Function
        End If
        If (str1 = "datetime" Or str1 = "smalldatetime") And tj1 = "֮��" Then '����֮��
            Dim tjj1 As String = GF_searchchar(tj2, ",", "left")
            Dim tjj2 As String = GF_searchchar(tj2, ",", "right")
            tjbds = ysf & "(" & str3 & " between '" & tjj1 & "' and '" & tjj2 & "')"
            Exit Function
        End If
        If str1 <> "datetime" And str1 <> "smalldatetime" And tj1 = "֮��" Then '����֮��
            Dim tjj1 As String = GF_searchchar(tj2, ",", "left")
            Dim tjj2 As String = GF_searchchar(tj2, ",", "right")
            tjbds = ysf & "(" & str3 & " between " & tjj1 & " and " & tjj2 & ")"
            Exit Function
        End If
        tj1 = Replace(tj1, "����", ">") : tj1 = Replace(tj1, "С��", "<")
        tj1 = Replace(tj1, "������", "<>") : tj1 = Replace(tj1, "����", "=")
        tj1 = Replace(tj1, "������", " not in ") : tj1 = Replace(tj1, "����", " in ")
        If str1 = "varchar(8000)" Or str1 = "smalldatetime" Or str1 = "datetime" Then
            tj2 = Replace(tj2, ",", "','")
            tj2 = "'" & tj2 & "'"
            If InStr(tj1, "in") > 0 Then
                tj2 = "(" & tj2 & ")"
            End If
        End If
        tjbds = ysf & str3 & tj1 & tj2 & " "

    End Function
    Public Function ddbm(ByVal str As String) As String '�õ�����
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
    Public Function pxfs(ByVal str As String) As String
        pxfs = ""
        If str = "����" Then
            pxfs = " ASC "
        ElseIf str = "����" Then
            pxfs = " DESC "
        End If
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListView2.Items.Count = 0 Then
            Exit Sub
        End If
        Dim aa As New Frsavereport
        aa.bbsql = GZSQL(ListView2)
        aa.ShowDialog()
    End Sub


    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class