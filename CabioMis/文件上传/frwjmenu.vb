Imports System.IO
Public Class frwjmenu
    Public aa, aa2 As New DataTable
    Private Sub frwjmenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        weizhi()
        ''''���汣֤����һ��û���ļ����ļ���,����ļ�������һ����ʱ����Ŀ¼����
        Dim lswjj As String = Application.StartupPath() & "\downfile"
        Dim fso = CreateObject("Scripting.FileSystemObject")
        fso.DeleteFolder(lswjj)
        fso.CreateFolder(lswjj)
        fso = Nothing
        ''''''''''''''''''''''''
        Call xsls()
        xsls2()
    End Sub
    Private Sub frwjmenu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Private Sub weizhi()
        GroupBox1.Width = CInt(Me.Width / 2) - 10
        GroupBox2.Left = GroupBox1.Left + GroupBox1.Width + 10
        GroupBox2.Width = Me.Width - GroupBox2.Left - 10
        GroupBox1.Height = Me.Height - GroupBox1.Top - 10
        GroupBox2.Height = GroupBox1.Height
    End Sub
    Private Sub xsls() '��ʾ�����ĵ�
        Dim sql As String = "SELECT tb_upfile_ID,tb_upfile_title,tb_upfile_size,tb_upfile_bm,tb_upfile_sj FROM tb_upfile where tb_upfile_bm='" & G_dlrgh & "' order by tb_upfile_id desc"
        aa = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao(ListView1, ImageList1, aa)
        GroupBox1.Text = "�����ĵ���" & ListView1.Items.Count & "��"
    End Sub
    Private Sub xsls2() '��ʾ�����ĵ�
        Dim sql As String = "SELECT tb_upfile_ID,tb_upfile_title,tb_upfile_size,tb_upfile_bm,tb_upfile_sj FROM tb_upfile where tb_upfile_gxry like '%" & G_dlrgh & "%' order by tb_upfile_id desc"
        aa2 = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao(ListView2, ImageList1, aa2)
        GroupBox2.Text = "�����ĵ���" & ListView2.Items.Count & "��"
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If GF_storelog1("�ļ��ϴ�") = False Then
            Exit Sub
        End If
        Dim ofdPic As New OpenFileDialog
        Dim wjm As String = ""
        If ofdPic.ShowDialog() <> Windows.Forms.DialogResult.OK Or ofdPic.FileName = "" Then
            ofdPic = Nothing : Exit Sub
        Else
            wjm = ofdPic.FileName : ofdPic = Nothing
        End If
        Dim wjdx As Long = FileToDb.GetFileSize(wjm)  '�õ��ļ���С,�ֽڵ�λ
        If wjdx > 2 * 1024 * 1024 Then
            MsgBox("�ļ����ܴ���2M") : Exit Sub
        End If
        Dim wjbt As String = FileToDb.GetFileName(wjm)   '�õ��ļ���
        Me.Cursor = Cursors.WaitCursor
        Dim szwj As New FileToDb(G_cnnstr, "tb_upfile", "tb_upfile_file")
        Dim newid As String = szwj.InsertToDb(wjm)   '�浽���ݿ⣬���ظոմ����ID
        Me.Cursor = Cursors.Default
        If newid <> "" Then
            GS_upztxx(G_cnnstr, "update tb_upfile set tb_upfile_title='" & wjbt & "',tb_upfile_size=" & wjdx & ",tb_upfile_bm='" & G_dlrgh & "' where tb_upfile_id=" & newid)
            GS_storelog3("�ļ��ϴ���" & wjm, "�ļ��ϴ�")
            MsgBox("�ļ�����ɹ�", MsgBoxStyle.Information)
            xsls() '��ʾ�����ĵ�
        Else
            MsgBox("����ʧ��")
        End If


        '  frupload.ShowDialog()
        'Dim ofdPic As New OpenFileDialog
        'ofdPic.ShowDialog()
        'If ofdPic.FileName.Trim <> "" Then
        '    ''''''''''''''''''''
        '    If GF_storelog2("�ļ��ϴ���" & ofdPic.FileName.Trim, "�ļ��ϴ�") = False Then
        '        Exit Sub
        '    End If
        '    '''''''''''''''''''''
        '    Me.Cursor = Cursors.WaitCursor

        '    Dim fs As FileStream = New FileStream(ofdPic.FileName, FileMode.Open, FileAccess.Read)
        '    Dim DSize As Integer = fs.Length
        '    If DSize > 2 * 1024 * 1024 Then
        '        MsgBox("�ļ����ܴ���2M")
        '        fs.Close() : fs = Nothing
        '        Exit Sub
        '    End If
        '    Dim bt(DSize - 1) As Byte
        '    fs.Read(bt, 0, DSize)
        '    fs.Close() : fs = Nothing
        '    Dim fi As FileInfo = New FileInfo(ofdPic.FileName)
        '    Dim wjm As String = fi.Name
        '    fi = Nothing
        '    Dim yhm, mm, sjk, fwq As String
        '    Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
        '        yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = sr.ReadLine() : fwq = sr.ReadLine() : sr.Close()
        '    End Using
        '    Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Server=" & fwq & ";User Id=" & yhm & ";Password=" & mm & ";Database=" & sjk)
        '    sqlConn.Open()
        '    Dim sqlCmd As New SqlClient.SqlCommand
        '    sqlCmd.Connection = sqlConn
        '    sqlCmd.CommandText = "Insert Into tb_upfile (tb_upfile_title,tb_upfile_file,tb_upfile_size,tb_upfile_bm) Values (@wb,@img,@size,@bm)"
        '    sqlCmd.Parameters.Add("@wb", SqlDbType.VarChar).Value = wjm
        '    sqlCmd.Parameters.Add("@img", SqlDbType.Image).Value = bt
        '    sqlCmd.Parameters.Add("@size", SqlDbType.Int).Value = DSize
        '    sqlCmd.Parameters.Add("@bm", SqlDbType.VarChar).Value = G_dlrgh
        '    sqlCmd.ExecuteNonQuery()
        '    sqlCmd = Nothing : sqlConn.Close() : sqlConn = Nothing
        '    Me.Cursor = Cursors.Default
        '    MsgBox("�ļ�����ɹ�", MsgBoxStyle.Information)
        '    Call xsls()
        'End If

    End Sub
    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Close()
    End Sub

    Private Sub showliebiao(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db As DataTable)

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
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If GF_storelog1("�ļ�����") = False Then
            Exit Sub
        End If
        Call xz(aa, ListView1)
    End Sub
    '˫������
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        If GF_storelog1("�ļ�����") = False Then
            Exit Sub
        End If
        Call xz(aa2, ListView2)
    End Sub
    Private Sub downfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downfile.Click
        If GF_storelog1("�ļ�����") = False Then
            Exit Sub
        End If
        Call xz(aa, ListView1)
    End Sub
    Public Sub xz(ByVal str As DataTable, ByVal str2 As ListView) '����
        With str2
            If .SelectedItems.Count > 0 Then
                Dim lswjj As String = Application.StartupPath() & "\downfile\"
                Dim wj As String = lswjj & .SelectedItems(0).SubItems(0).Text
                File.Delete(wj)
                Dim aaa As Integer = .SelectedItems(0).Index
                Dim id As String = str.Rows(aaa)(0) '��ȡ�ļ�ID
                Me.Cursor = Cursors.WaitCursor
                Dim szwj As New FileToDb(G_cnnstr, "tb_upfile", "tb_upfile_file") 'ʵ�����������Ǻ������ݿ�
                If szwj.DownFile(wj, id) = False Then '���ز������ļ�
                    MsgBox("����ʧ��") : Exit Sub
                End If
                szwj = Nothing
                Me.Cursor = Cursors.Default
                GS_storelog3("�ļ����أ�" & .SelectedItems(0).SubItems(0).Text, "�ļ�����")
                Try
                    System.Diagnostics.Process.Start(wj)
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                    MsgBox("û��Ӧ�ó�����˲�����ָ���ļ��й���") : Exit Sub
                End Try
                'Dim cnn As New OleDb.OleDbConnection(G_cnnstr)
                'cnn.Open()
                'Dim sql As String = "SELECT * FROM tb_upfile where tb_upfile_id=" & id
                'Dim myread As New OleDb.OleDbCommand(sql, cnn)
                'Dim rs As OleDb.OleDbDataReader
                'rs = myread.ExecuteReader()
                'rs.Read()
                'Dim wj As String = rs(1)
                'Dim bt() As Byte = rs(2)
                'rs.Close() : rs = Nothing : myread = Nothing : cnn.Close() : cnn = Nothing
                'Dim lswjj As String = Application.StartupPath() & "\downfile\"
                'File.Delete(lswjj & wj)
                ''Dim ofdPic As New SaveFileDialog
                ''ofdPic.FileName = wj
                ''Me.Cursor = Cursors.Default
                ''If ofdPic.ShowDialog() = Windows.Forms.DialogResult.OK And Not bt Is Nothing Then
                'File.WriteAllBytes(lswjj & wj, bt)
                'Try
                '    System.Diagnostics.Process.Start(lswjj & wj)
                '    Me.Cursor = Cursors.Default
                'Catch ex As Exception
                '    MsgBox("û��Ӧ�ó�����˲�����ָ���ļ��й���") : Exit Sub
                'End Try

            End If
        End With

    End Sub

    'ɾ��
    Private Sub deletefile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletefile.Click
        If MsgBox("ȷ��ɾ����", 1, "ȷ��ɾ����") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''
        If GF_storelog2("ɾ���ļ���" & ListView1.SelectedItems(0).SubItems(0).Text, "ɾ���ļ�") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim aaa As Integer = ListView1.SelectedItems(0).Index
        Dim id As String = aa.Rows(aaa)(0)
        GS_upztxx(G_cnnstr, "delete  from tb_upfile where tb_upfile_id=" & id)
        xsls()

    End Sub

    Private Sub sharefile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sharefile.Click
        Dim aaa As Integer = ListView1.SelectedItems(0).Index
        Dim id As String = aa.Rows(aaa)(0)
        Dim nform As New Frgxry
        nform.wjid = id
        nform.ShowDialog()
    End Sub

  
End Class