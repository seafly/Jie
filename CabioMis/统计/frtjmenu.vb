Imports System.IO
Public Class frtjmenu
    Dim dt As New DataTable
    Public aa2 As New DataTable
    Private Sub changefacego(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeface11.Click, changeface12.Click, changeface13.Click, _
           changeface14.Click, changeface15.Click, changeface16.Click, changeface17.Click, changeface18.Click, _
         changeface19.Click, changeface20.Click, changeface21.Click, changeface22.Click, changeface110.Click
        Dim nform As New Form
        Select Case CType(sender, Control).Name
            Case "changeface11" : nform = New Frshow_list '�ͼ�������
            Case "changeface12" : nform = New Frfenji_list '�ۼ�������
            Case "changeface13" : nform = New Frjsb_list '����������
            Case "changeface14" : nform = New Frqalist 'QA����
            Case "changeface15" : nform = New Frqc_list 'QC����
            Case "changeface16" : nform = New Frsbdllist 'EHS����
            Case "changeface17" : nform = New Frehslist '�豸����������
            Case "changeface18" : nform = New Fryllist '���в�����
            Case "changeface19" : nform = New Frcgrzlist '�ɹ�������
            Case "changeface20" : nform = New Frrlzy '������Դ������
            Case "changeface21" : nform = New frtjmenuNEW '�������
            Case "changeface22" : nform = New Frqjface 'ȫ�ֽ���
            Case "changeface110" : nform = New Fradminlist 'ϵͳ�������
        End Select
        nform.Show() : Me.Close()
    End Sub
    Private Sub weizhi()
        ListView1.Width = Me.Width
        ListView1.Height = GroupBox1.Top - ListView1.Top - 10
    End Sub
    '����Ĺر�
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '����Ĺر�
    End Sub
    Private Sub Frmain0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        G_TJicon = Drawing.Icon.ExtractAssociatedIcon(Application.StartupPath() & "\image\iphone0426_014.ico")
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        ''''���汣֤����һ��û���ļ����ļ���,����ļ�������һ����ʱ����Ŀ¼����
        Dim lswjj As String = Application.StartupPath() & "\downfile"
        Dim fso = CreateObject("Scripting.FileSystemObject")
        fso.DeleteFolder(lswjj)
        fso.CreateFolder(lswjj)
        fso = Nothing
        ''''''''''''''''''''''''
        weizhi()
        showbb("") : xsls2()
    End Sub
   
    Private Sub showbb(ByVal str As String)
        Dim sql As String = "select * from tb_tjmenu where 1=1"
        If G_js <> "����Ա" Then
            sql = sql & "  and tb_tjmenu_js like '%" & G_js & "%' "
        End If
        If str <> "" Then
            sql = sql & " and tb_tjmenu_fn='" & str & "'"
        End If
        sql &= "order by tb_tjmenu_fn"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao(ListView1, ImageList1, dt)
    End Sub
    Private Sub showliebiao(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db As DataTable)

        With LV1      'listview��������
            .Items.Clear() : .Groups.Clear() : .MultiSelect = False
            .View = View.LargeIcon '������ʾ��ʽ
            .LargeImageList = IL1 : .ShowItemToolTips = False
            '������
            Dim i As Integer
            For i = 0 To db.Rows.Count - 1
                Dim lvg As ListViewGroup
                lvg = New ListViewGroup(db.Rows(i)(2).ToString, HorizontalAlignment.Left)
                .Groups.Add(lvg.ToString, lvg.ToString)
            Next

            '����ImageList
            For m As Integer = 0 To db.Rows.Count - 1
                .Items.Add(New ListViewItem(db.Rows(m)(1).ToString, 0, .Groups(db.Rows(m)(2).ToString)))
            Next
        End With
        '   SendMessage(LV1.Handle, &H1035, 0, &H10000 * 50 + 50)
    End Sub

    Private Sub dkxck(ByVal str As String, ByVal bbname As String, ByVal bbsql As String)
        '������ �����ռ�+��+�������� 
        str = My.Application.Info.AssemblyName & "." & str
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(str), Form)
        frm2.Controls("bbname").Text = bbname
        frm2.Controls("bbsql").Text = bbsql
        frm2.Show()
        'frm2.Dispose()
    End Sub
    Private Sub dkxck(ByVal str As String, ByVal formtext As String)
        '������ �����ռ�+��+�������� 
        str = My.Application.Info.AssemblyName & "." & str
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(str), Form)
        frm2.Text = formtext
        frm2.Show()
        'frm2.Dispose()
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick, downfile.Click
        GS_CheckGuestDo() ' ������һ�β����Ƿ�ʱ,���ﳬʱ��ֱ���˳�����
        Try
            Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & ListView1.SelectedItems(0).Text & "'")
            Dim ckjs As String = kj.Rows(0)("tb_tjmenu_js") '�鿴��ɫ
            Dim texts As String = kj.Rows(0)("tb_tjmenu_mc") '��������
            ckjs = GF_qhjdh(ckjs)
            If InStr(ckjs, GF_qhjdh(G_js)) = 0 Then
                MsgBox("��û�в鿴" & ListView1.SelectedItems(0).Text & "��Ȩ��") : Exit Sub
            End If

            Dim dkct As String = kj.Rows(0)("tb_tjmenu_dkjm") '�򿪽���
            If dkct = "Frzdybb" Then '�Զ��屨�����Ĵ�
                Dim bbname As String = kj.Rows(0)("tb_tjmenu_mc")
                Dim bbsql As String = ""
                If IsDBNull(kj.Rows(0)("tb_tjmenu_sql")) = False Then
                    bbsql = kj.Rows(0)("tb_tjmenu_sql")
                End If
                dkxck(dkct, kj.Rows(0)("tb_tjmenu_mc"), kj.Rows(0)("tb_tjmenu_sql"))
            Else
                If IsDBNull(kj.Rows(0)("tb_tjmenu_sql")) = False Then
                    G_zdybbsql = kj.Rows(0)("tb_tjmenu_sql")
                End If
                dkxck(dkct, texts)
            End If

        Catch ex As Exception
            Exit Sub
        End Try
        GS_StoreLastDo() ' �������һ�β���ʱ��
    End Sub


    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click

        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim nform As New frchaph
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim nform As New Frdzxf3
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim nform As New frdzxf
        nform.ShowDialog()
    End Sub



    Private Sub deletefile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletefile.Click
        Try
            Dim bbmc As String = ListView1.SelectedItems(0).Text
            Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & bbmc & "'")
            Dim bblx As String = kj.Rows(0)(2)
            '''''�����˹���
            Dim scqx As String = Null2String(kj.Rows(0)(6))

            If bblx <> "�Զ��屨��" Then
                MsgBox("����ɾ��ϵͳ����") : Exit Sub
            End If
            If MsgBox("ȷ��Ҫɾ������" & bbmc & "��", 1, "����") <> 1 Then
                Exit Sub
            End If
  
            If GF_storelog2("ɾ���Զ��屨��" & bbmc, "ɾ���Զ��屨��") = False And scqx <> G_dlrgh Then
                MsgBox("�Բ��𣬸ñ������������޷�ɾ����")
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete from tb_tjmenu where tb_tjmenu_mc='" & bbmc & "'"
            GS_upztxx(G_cnnstr, sql)
            showbb("�Զ��屨��")
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub
    '�༭�Զ��屨��Ȩ��
    Private Sub editqx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editqx.Click
        Try
            Dim bbmc As String = ListView1.SelectedItems(0).Text
            Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & bbmc & "'")
            Dim bblx As String = kj.Rows(0)(2)
            '''''�����˹���
            Dim scqx As String = Null2String(kj.Rows(0)(6))

            If bblx <> "�Զ��屨��" Then
                MsgBox("���ܱ༭ϵͳ����") : Exit Sub
            End If
            If GF_storelog1("�༭�Զ��屨��Ȩ��") = False And scqx <> G_dlrgh Then
                MsgBox("�Բ��𣬸ñ������������޷��༭��")
                Exit Sub
            End If ' �ж��Ƿ���Ȩ��
            '''''''''''''''''''''
            Dim bbqx As String = kj.Rows(0)("tb_tjmenu_js")

            Dim nform As New Frbbiao2
            nform.Text = bbmc
            nform.k1 = bbqx
            nform.ShowDialog()
            showbb("�Զ��屨��")
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Private Sub upfilebutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upfilebutton.Click
        Dim nform As New frwjmenu
        nform.ShowDialog()
    End Sub


    Private Sub AllReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllReport.Click
        showbb("")
    End Sub

    Private Sub MonthReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthReport.Click
        showbb("�±���")
    End Sub

    Private Sub WeekReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeekReport.Click
        showbb("�ܱ���")
    End Sub
    Private Sub DateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateReport.Click
        showbb("�ձ���")
    End Sub

    Private Sub ElseReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElseReport.Click
        showbb("��������")
    End Sub

    Private Sub CustomReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomReport.Click
        showbb("�Զ��屨��")
    End Sub

    Private Sub ModPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModPass.Click
        Dim nform As New FrModPass
        nform.ShowDialog()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("����")
    End Sub
    ''''''''''''''''''''''''''''''''������ʾ�����ĵ������
    Private Sub xsls2() '��ʾ�����ĵ�
        Dim sql As String = "SELECT tb_upfile_ID,tb_upfile_title,tb_upfile_size,tb_upfile_bm,tb_upfile_sj FROM tb_upfile where tb_upfile_gxry like '%" & G_dlrgh & "%' order by tb_upfile_id desc"
        aa2 = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao2(ListView2, ImageList1, aa2)
        GroupBox1.Text = "�����ĵ���" & ListView2.Items.Count & "��"
    End Sub
    Private Sub showliebiao2(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db As DataTable)

        With LV1      'listview��������
            .Items.Clear() : .Groups.Clear() : .MultiSelect = False
            .View = View.LargeIcon '������ʾ��ʽ
            .LargeImageList = IL1 : .ShowItemToolTips = True
            For m As Integer = 0 To db.Rows.Count - 1
                Dim gh As String = db.Rows(m)(3)
                Dim xm As String = GF_cnwithen(G_yg, "tb_yg_n430f='" & gh & "'", 3) 'ͨ�����ŵõ�����
                .Items.Add(New ListViewItem(db.Rows(m)(1).ToString, 0))
                Dim kk As String = "��С:" & GF_netfilesize(db.Rows(m)(2)) & vbCrLf
                kk = kk & "����:" & xm & vbCrLf
                kk = kk & "ʱ��:" & db.Rows(m)(4)
                .Items(m).ToolTipText = kk
            Next
        End With
        '   SendMessage(LV1.Handle, &H1035, 0, &H10000 * 50 + 50)
    End Sub
    '˫������
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        If GF_storelog1("�ļ�����") = False Then
            Exit Sub
        End If
        Call frwjmenu.xz(aa2, ListView2)
    End Sub

    Private Sub frtjmenu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='tb_beizhu'", 2) '�õ���������˼
        nform.TextBox1.Text = "tb_beizhu"
        nform.Button3.Visible = True
        'nform.button.Visible = True
        'nform.shanchu.Visible = True
        nform.ShowDialog()
    End Sub
 

End Class