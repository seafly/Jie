Public Class frtjmenuNEW

    Dim dt As New DataTable
    Public aa2 As New DataTable
    Private Sub frtjmenuNEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GF_OpenFaceList2(ToolStrip1) '切换菜单与关闭菜单的加载
        G_TJicon = Drawing.Icon.ExtractAssociatedIcon(Application.StartupPath() & "\image\iphone0426_014.ico")
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        For i As Integer = 0 To TreeView1.Nodes.Count - 1
            TreeView1.Nodes(i).Expand()
        Next
        ''''下面保证创建一个没有文件的文件夹,这个文件夹用于一个临时下载目录下载
        Dim lswjj As String = Application.StartupPath() & "\downfile"
        Dim fso = CreateObject("Scripting.FileSystemObject")
        fso.DeleteFolder(lswjj)
        fso.CreateFolder(lswjj)
        fso = Nothing
        ''''''''''''''''''''''''
        dt = GF_CreateDataSource(G_cnnstr, "select * from tb_tjmenu ")
        weizhi()
        xsls2()
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim fj, zj, fjlist As String
        fj = "" : zj = "" : fjlist = ""
        Dim sql As String = ""
        Dim snode As TreeNode = TreeView1.SelectedNode
        snode.SelectedImageIndex = 1
        If snode.Parent Is Nothing Then
            fj = snode.Text
            fjlist = snode.Name
        Else
            fj = snode.Parent.Text : zj = snode.Text
            fjlist = snode.Parent.Name
        End If
        'MsgBox(fjlist)
        'MsgBox(Me.Controls(fjlist).Name)
        'MsgBox(ListViewNDP1.Parent.Name)
        Dim n As ListView = CType(Me.Controls("ListView" & fjlist), ListView)
        showbb(n, fj, zj)
    End Sub
    Private Sub showbb(ByVal strlist As ListView, ByVal strparent As String, ByVal strchild As String)
        Dim sql As String = "select * from tb_tjmenu where 1=1"
        If G_js <> "管理员" Then
            sql = sql & "  and tb_tjmenu_js like '%" & G_js & "%' "
        End If
        If strparent <> "" Then
            sql = sql & " and tb_tjmenu_fn='" & strparent & "'"
        End If
        If strchild <> "" Then
            sql = sql & " and tb_tjmenu_bumen='" & strchild & "'"
        End If
        sql &= "order by tb_tjmenu_fn"
        Dim dt11 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao(strlist, ImageList1, dt11)
    End Sub
    Private Sub showliebiao(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db As DataTable)

        With LV1      'listview属性设置
            .Items.Clear() : .Groups.Clear() : .MultiSelect = False
            .View = View.LargeIcon '设置显示方式
            .LargeImageList = IL1 : .ShowItemToolTips = False
            '设置组
            Dim i As Integer
            For i = 0 To db.Rows.Count - 1
                Dim lvg As ListViewGroup
                lvg = New ListViewGroup(db.Rows(i)(2).ToString, HorizontalAlignment.Left)
                .Groups.Add(lvg.ToString, lvg.ToString)
            Next

            '设置ImageList
            For m As Integer = 0 To db.Rows.Count - 1
                .Items.Add(New ListViewItem(db.Rows(m)(1).ToString, 0, .Groups(db.Rows(m)(2).ToString)))
            Next
        End With
        '   SendMessage(LV1.Handle, &H1035, 0, &H10000 * 50 + 50)
    End Sub

    Private Sub dkxck(ByVal str As String, ByVal bbname As String, ByVal bbsql As String)
        '必须是 命名空间+点+窗体类名 
        str = My.Application.Info.AssemblyName & "." & str
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(str), Form)
        frm2.Controls("bbname").Text = bbname
        frm2.Controls("bbsql").Text = bbsql
        frm2.Show()
        'frm2.Dispose()
    End Sub
    Private Sub dkxck(ByVal str As String, ByVal formtext As String)
        '必须是 命名空间+点+窗体类名 
        str = My.Application.Info.AssemblyName & "." & str
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(str), Form)
        frm2.Text = formtext
        frm2.Show()
        'frm2.Dispose()
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewNDP1.DoubleClick, ListViewNDP2.DoubleClick, ListViewNDP3.DoubleClick, ListViewNDP4.DoubleClick, ListViewNDP5.DoubleClick, ListViewNDP6.DoubleClick
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        Dim whichList As ListView = CType(sender, ListView)
        With whichList
            Try
                Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & .SelectedItems(0).Text & "'")
                Dim ckjs As String = kj.Rows(0)("tb_tjmenu_js") '查看角色
                Dim texts As String = kj.Rows(0)("tb_tjmenu_mc") '报表名称
                ckjs = GF_qhjdh(ckjs)
                If InStr(ckjs, GF_qhjdh(G_js)) = 0 Then
                    MsgBox("您没有查看" & .SelectedItems(0).Text & "的权限") : Exit Sub
                End If

                Dim dkct As String = kj.Rows(0)("tb_tjmenu_dkjm") '打开界面
                If dkct = "Frzdybb" Then '自定义报表界面的打开
                    Dim bbname As String = kj.Rows(0)("tb_tjmenu_mc")
                    Dim bbsql As String = ""
                    If IsDBNull(kj.Rows(0)("tb_tjmenu_sql")) = False Then
                        bbsql = kj.Rows(0)("tb_tjmenu_sql")
                    End If
                    dkxck(dkct, kj.Rows(0)("tb_tjmenu_mc"), Cl_StrMag.YanNullToEmpty(kj.Rows(0)("tb_tjmenu_sql")))
                Else
                    If IsDBNull(kj.Rows(0)("tb_tjmenu_sql")) = False Then
                        G_zdybbsql = kj.Rows(0)("tb_tjmenu_sql")
                    End If
                    dkxck(dkct, texts)
                End If

            Catch ex As Exception
                Exit Sub
            End Try
        End With

        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub
    Private Sub deletefile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletefile.Click
     

        Dim a As ToolStripMenuItem = sender
        Dim t As ContextMenuStrip = a.Owner
        'MsgBox(t.SourceControl.Name)
        Dim whichList As ListView = CType(t.SourceControl, ListView)
        Try
            Dim bbmc As String = whichList.SelectedItems(0).Text
            Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & bbmc & "'")
            Dim bblx As String = kj.Rows(0)(2)
            '''''操作人工号
            Dim scqx As String = Null2String(kj.Rows(0)(6))

            If bblx <> "自定义报表" Then
                MsgBox("不能删除系统报表") : Exit Sub
            End If
            If MsgBox("确定要删除报表：" & bbmc & "吗？", 1, "警告") <> 1 Then
                Exit Sub
            End If

            If GF_storelog2("删除自定义报表：" & bbmc, "删除自定义报表") = False And scqx <> G_dlrgh Then
                MsgBox("对不起，该表不是您创建，无法删除！")
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete from tb_tjmenu where tb_tjmenu_mc='" & bbmc & "'"
            GS_upztxx(G_cnnstr, sql)
            MsgBox("操作完成，你需要重新点击选择来刷新报表")
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub
    '编辑自定义报表权限
    Private Sub editqx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editqx.Click
        Dim a As ToolStripMenuItem = sender
        Dim t As ContextMenuStrip = a.Owner
        'MsgBox(t.SourceControl.Name)
        Dim whichList As ListView = CType(t.SourceControl, ListView)
        Try
            Dim bbmc As String = whichList.SelectedItems(0).Text
            Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & bbmc & "'")
            Dim bblx As String = kj.Rows(0)(2)
            '''''操作人工号
            Dim scqx As String = Null2String(kj.Rows(0)(6))

            If bblx <> "自定义报表" Then
                MsgBox("不能编辑系统报表") : Exit Sub
            End If
            If GF_storelog1("编辑自定义报表权限") = False And scqx <> G_dlrgh Then
                MsgBox("对不起，该表不是您创建，无法编辑！")
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim bbqx As String = kj.Rows(0)("tb_tjmenu_js")

            Dim nform As New Frbbiao2
            nform.Text = bbmc
            nform.k1 = bbqx
            nform.ShowDialog()
            MsgBox("操作完成，你需要重新点击选择来刷新报表")
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    '综合查询
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim nform As New frchaph
        nform.ShowDialog()
    End Sub
    '组合查询
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim nform As New Frdzxf3
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim nform As New frdzxf
        nform.ShowDialog()
    End Sub



  
    Private Sub upfilebutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upfilebutton.Click
        Dim nform As New frwjmenu
        nform.ShowDialog()
    End Sub
    Private Sub ModPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModPass.Click
        Dim nform As New FrModPass
        nform.ShowDialog()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("报表")
    End Sub
    ''''''''''''''''''''''''''''''''下面显示共享文档的相关
    Private Sub xsls2() '显示共享文档
        Dim sql As String = "SELECT tb_upfile_ID,tb_upfile_title,tb_upfile_size,tb_upfile_bm,tb_upfile_sj FROM tb_upfile where tb_upfile_gxry like '%" & G_dlrgh & "%' order by tb_upfile_id desc"
        aa2 = GF_CreateDataSource(G_cnnstr, sql)
        showliebiao2(ListView2, ImageList1, aa2)
        GroupBox1.Text = "共享文档共" & ListView2.Items.Count & "个"
    End Sub
    Private Sub showliebiao2(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db As DataTable)

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
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        If GF_storelog1("文件下载") = False Then
            Exit Sub
        End If
        Call frwjmenu.xz(aa2, ListView2)
    End Sub

    Private Sub frtjmenu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='tb_beizhu'", 2) '得到表中文意思
        nform.TextBox1.Text = "tb_beizhu"
        nform.Button3.Visible = True
        'nform.button.Visible = True
        'nform.shanchu.Visible = True
        nform.ShowDialog()
    End Sub

    Private Sub weizhi()
        Dim gd As Integer = TreeView1.Height
        Dim kd As Integer = Me.Width - ListViewNDP1.Left - 5
        ListViewNDP1.Width = kd : ListViewNDP1.Height = Int(gd / 6) - 4
        ListViewNDP2.Top = ListViewNDP1.Top + ListViewNDP1.Height + 2
        ListViewNDP2.Width = kd : ListViewNDP2.Height = Int(gd / 6) - 4
        ListViewNDP3.Top = ListViewNDP2.Top + ListViewNDP2.Height + 2
        ListViewNDP3.Width = kd : ListViewNDP3.Height = Int(gd / 6) - 4
        ListViewNDP4.Top = ListViewNDP3.Top + ListViewNDP3.Height + 2
        ListViewNDP4.Width = kd : ListViewNDP4.Height = Int(gd / 6) - 4
        ListViewNDP5.Top = ListViewNDP4.Top + ListViewNDP4.Height + 2
        ListViewNDP5.Width = kd : ListViewNDP5.Height = Int(gd / 6) - 4
        ListViewNDP6.Top = ListViewNDP5.Top + ListViewNDP5.Height + 2
        ListViewNDP6.Width = kd : ListViewNDP6.Height = Int(gd / 6) - 4
    End Sub
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub

    Private Sub ListViewNDP2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewNDP1.MouseClick, ListViewNDP2.MouseClick, ListViewNDP3.MouseClick, ListViewNDP4.MouseClick, ListViewNDP5.MouseClick, ListViewNDP6.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim whichList As ListView = CType(sender, ListView)
            whichList.ContextMenuStrip = ContextMenuStrip1
            ContextMenuStrip1.Show()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim FrTjbb As New Frbb
        FrTjbb.ShowDialog
    End Sub
End Class