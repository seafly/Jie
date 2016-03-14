Imports System.IO
Public Class frwjmenu
    Public aa, aa2 As New DataTable
    Private Sub frwjmenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        weizhi()
        ''''下面保证创建一个没有文件的文件夹,这个文件夹用于一个临时下载目录下载
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
    Private Sub xsls() '显示个人文档
        Dim sql As String = "SELECT tb_upfile_ID,tb_upfile_title,tb_upfile_size,tb_upfile_bm,tb_upfile_sj FROM tb_upfile where tb_upfile_bm='" & G_dlrgh & "' order by tb_upfile_id desc"
        aa = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao(ListView1, ImageList1, aa)
        GroupBox1.Text = "个人文档共" & ListView1.Items.Count & "个"
    End Sub
    Private Sub xsls2() '显示共享文档
        Dim sql As String = "SELECT tb_upfile_ID,tb_upfile_title,tb_upfile_size,tb_upfile_bm,tb_upfile_sj FROM tb_upfile where tb_upfile_gxry like '%" & G_dlrgh & "%' order by tb_upfile_id desc"
        aa2 = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao(ListView2, ImageList1, aa2)
        GroupBox2.Text = "共享文档共" & ListView2.Items.Count & "个"
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If GF_storelog1("文件上传") = False Then
            Exit Sub
        End If
        Dim ofdPic As New OpenFileDialog
        Dim wjm As String = ""
        If ofdPic.ShowDialog() <> Windows.Forms.DialogResult.OK Or ofdPic.FileName = "" Then
            ofdPic = Nothing : Exit Sub
        Else
            wjm = ofdPic.FileName : ofdPic = Nothing
        End If
        Dim wjdx As Long = FileToDb.GetFileSize(wjm)  '得到文件大小,字节单位
        If wjdx > 2 * 1024 * 1024 Then
            MsgBox("文件不能大于2M") : Exit Sub
        End If
        Dim wjbt As String = FileToDb.GetFileName(wjm)   '得到文件名
        Me.Cursor = Cursors.WaitCursor
        Dim szwj As New FileToDb(G_cnnstr, "tb_upfile", "tb_upfile_file")
        Dim newid As String = szwj.InsertToDb(wjm)   '存到数据库，返回刚刚储存的ID
        Me.Cursor = Cursors.Default
        If newid <> "" Then
            GS_upztxx(G_cnnstr, "update tb_upfile set tb_upfile_title='" & wjbt & "',tb_upfile_size=" & wjdx & ",tb_upfile_bm='" & G_dlrgh & "' where tb_upfile_id=" & newid)
            GS_storelog3("文件上传：" & wjm, "文件上传")
            MsgBox("文件传入成功", MsgBoxStyle.Information)
            xsls() '显示个人文档
        Else
            MsgBox("操作失败")
        End If


        '  frupload.ShowDialog()
        'Dim ofdPic As New OpenFileDialog
        'ofdPic.ShowDialog()
        'If ofdPic.FileName.Trim <> "" Then
        '    ''''''''''''''''''''
        '    If GF_storelog2("文件上传：" & ofdPic.FileName.Trim, "文件上传") = False Then
        '        Exit Sub
        '    End If
        '    '''''''''''''''''''''
        '    Me.Cursor = Cursors.WaitCursor

        '    Dim fs As FileStream = New FileStream(ofdPic.FileName, FileMode.Open, FileAccess.Read)
        '    Dim DSize As Integer = fs.Length
        '    If DSize > 2 * 1024 * 1024 Then
        '        MsgBox("文件不能大于2M")
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
        '    MsgBox("文件传入成功", MsgBoxStyle.Information)
        '    Call xsls()
        'End If

    End Sub
    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Close()
    End Sub

    Private Sub showliebiao(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db As DataTable)

        With LV1      'listview属性设置
            .Items.Clear() : .Groups.Clear() : .MultiSelect = False
            .View = View.LargeIcon '设置显示方式
            .LargeImageList = IL1 : .ShowItemToolTips = True
            For m As Integer = 0 To db.Rows.Count - 1
                Dim gh As String = db.Rows(m)(3)
                Dim xm As String = GF_cnwithen(G_yg, "tb_yg_n430f='" & gh & "'", 3) '通过工号得到姓名
                .Items.Add(New ListViewItem(db.Rows(m)(1).ToString, 0))
                Dim kk As String = "大小:" & GF_netfilesize(db.Rows(m)(2)) & vbCrLf
                kk = kk & "属于:" & xm & vbCrLf
                kk = kk & "时间:" & db.Rows(m)(4)
                .Items(m).ToolTipText = kk
            Next
        End With
        '   SendMessage(LV1.Handle, &H1035, 0, &H10000 * 50 + 50)
    End Sub
    '双击下载
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If GF_storelog1("文件下载") = False Then
            Exit Sub
        End If
        Call xz(aa, ListView1)
    End Sub
    '双击下载
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        If GF_storelog1("文件下载") = False Then
            Exit Sub
        End If
        Call xz(aa2, ListView2)
    End Sub
    Private Sub downfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downfile.Click
        If GF_storelog1("文件下载") = False Then
            Exit Sub
        End If
        Call xz(aa, ListView1)
    End Sub
    Public Sub xz(ByVal str As DataTable, ByVal str2 As ListView) '下载
        With str2
            If .SelectedItems.Count > 0 Then
                Dim lswjj As String = Application.StartupPath() & "\downfile\"
                Dim wj As String = lswjj & .SelectedItems(0).SubItems(0).Text
                File.Delete(wj)
                Dim aaa As Integer = .SelectedItems(0).Index
                Dim id As String = str.Rows(aaa)(0) '获取文件ID
                Me.Cursor = Cursors.WaitCursor
                Dim szwj As New FileToDb(G_cnnstr, "tb_upfile", "tb_upfile_file") '实例化对象定义是何种数据库
                If szwj.DownFile(wj, id) = False Then '下载并生成文件
                    MsgBox("操作失败") : Exit Sub
                End If
                szwj = Nothing
                Me.Cursor = Cursors.Default
                GS_storelog3("文件下载：" & .SelectedItems(0).SubItems(0).Text, "文件下载")
                Try
                    System.Diagnostics.Process.Start(wj)
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                    MsgBox("没有应用程序与此操作的指定文件有关联") : Exit Sub
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
                '    MsgBox("没有应用程序与此操作的指定文件有关联") : Exit Sub
                'End Try

            End If
        End With

    End Sub

    '删除
    Private Sub deletefile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletefile.Click
        If MsgBox("确定删除吗？", 1, "确定删除吗？") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''
        If GF_storelog2("删除文件：" & ListView1.SelectedItems(0).SubItems(0).Text, "删除文件") = False Then
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