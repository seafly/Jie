Public Class Frjsb_YFXMGL
    Private ADDXMMC, ADDZLMC As String '选中的项目名称、子类名称
    Private webz As String
    Private Sub Frjsb_YFXMGL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        SHOWTreeViewAddNode() '代表显示的是项目
        '’‘’‘’‘’‘’‘’‘’‘’‘’
        Dim yhm, mm, sjk, fwq, port As String
        Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
            yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = sr.ReadLine() : fwq = sr.ReadLine() : port = sr.ReadLine() : sr.Close()
        End Using
        If fwq = "(local)" Then
            fwq = "127.0.0.1"
        End If
        If port = "80" Then
            port = ""
        Else
            port = ":" & port
        End If
        webz = "http://" & fwq & port & "/cabiojs"
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘
    End Sub

    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Close()
    End Sub
    Private Sub ToolStripDropDownButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton5.Click
        WebBrowser1.ShowPrintPreviewDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        WebBrowser1.ShowPageSetupDialog()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        WebBrowser1.ShowPrintDialog()
    End Sub
    '新项目的添加
    Private Sub MenuAddProcj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddProcj.Click
        Dim nform As New Frjsb_YFXMGL_ADD
        Me.AddOwnedForm(nform)
        nform.ShowDialog()
    End Sub
    '查看参考资料或者项目文档
    Public Sub SHOWTreeViewAddNode() '显示所有节点
        TreeView1.Nodes.Clear()
        TreeView1.ImageList = frtjmenuNEW.ImageList2

        Dim sql0 As String = "select DATEPART ( year , tb_jyfxm_rq ) from tb_jyfxm group by DATEPART ( year , tb_jyfxm_rq ) order by DATEPART ( year , tb_jyfxm_rq ) desc"
        Dim dt0 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql0)
        For j As Integer = 0 To dt0.Rows.Count - 1
            Dim newNode As New TreeNode(dt0.Rows(j)(0))
            TreeView1.Nodes.Add(newNode) '顶级节点添加

            Dim sql As String = "select * from tb_jyfxm  where DATEPART ( year , tb_jyfxm_rq )=" & dt0.Rows(j)(0) & " order by tb_jyfxm_rq desc"
            Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            With dt1
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1

                        AddProjectNode(newNode, .Rows(i)("tb_jyfxm_mc"))
                        'Dim newNode2 As New TreeNode(.Rows(i)("tb_jyfxm_mc"))

                        'newNode.Nodes.Add(newNode2) '添加项目节点
                        'SHOWTreeViewAddNode2(newNode2, n)
                        ''''''''''''''''''''''''''''''''''''''''
                        'newNode.Expand()
                    Next
                End If
            End With
        Next
    End Sub
    '添加一个项目
    Public Sub AddProjectNode(ByVal ProjectNode As TreeNode, ByVal NodeText As String)
        Dim Node As TreeNode = ProjectNode.Nodes.Add(NodeText)
        Dim n As String() = New String() {"档案", "资料"}
        SHOWTreeViewAddNode2(Node, n)
        Dim n1 As String() = New String() {"立项", "实施", "小结", "总结"}
        SHOWTreeViewAddNode2(Node.Nodes(0), n1)
        Dim n2 As String() = New String() {"图片", "文献", "报告", "其它"}
        SHOWTreeViewAddNode2(Node.Nodes(1), n2)
    End Sub
    '利用数组添加节点
    Public Sub SHOWTreeViewAddNode2(ByVal node As TreeNode, ByVal SOURCE() As String) '显示支节点
        For i As Integer = 0 To SOURCE.Length - 1
            Dim m As New TreeNode(SOURCE(i), 0, 0)
            node.Nodes.Add(m)
        Next
    End Sub

  
    ''新增资料
    'Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
    '    Dim m As New Frjsb_YFXMGL_ZLADD
    '    m.xmmc = ADDXMMC
    '    m.zlmc = ADDZLMC
    '    m.webz = webz
    '    m.ShowDialog()
    'End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        showsj()

        Dim snode As TreeNode = TreeView1.SelectedNode
        snode.SelectedImageIndex = 1
        snode.Expand()

    End Sub
    '得到项目名称,不包括选中年份节点
    Private Function GetProcjectName(ByVal snode As TreeNode) As String
        If snode.Level = 1 Then '选中2级节点,项目
            Return snode.Text
        ElseIf snode.Level = 2 Then '选中3级节点’项目的基本分类
            Return snode.Parent.Text
        ElseIf snode.Level = 3 Then '选中4级节点，项目的具体分类
            Dim Node As TreeNode = snode.Parent
            Return Node.Parent.Text '项目名称(选中子类父节点的父节点)
        End If
        Return Nothing
    End Function
    Private Sub showl_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles showl.MouseClick
        With showl
            If .SelectedRows.Count = 0 Then
                Return
            End If
            Dim sid As String = .SelectedRows(0).Cells(0).Value
            Dim wdfl As String = .SelectedRows(0).Cells(2).Value '得到文档分类
            Select Case wdfl
                Case "立项", "实施", "小结", "总结"
                    If GF_storelog1("查看研发项目档案") = False Then
                        Exit Sub
                    End If ' 判断是否有权限
            End Select
            showweb(sid) '显示web内容
            ''关联文档的填充
            Dim wdbt, wddz As String '文档名称与文档地址
            wdbt = DeepCode.DeepDoStr.Null2String(.SelectedRows(0).Cells(6).Value)
            wddz = DeepCode.DeepDoStr.Null2String(.SelectedRows(0).Cells(7).Value)

            Dim a() As String = wdbt.Split("さ") '标题数组
            Dim b() As String = wddz.Split("さ") '地址数组
            Dim m As New DataTable
            With m
                .Columns.Add("文档地址", GetType(String))
                .Columns.Add("文档名称", GetType(String))
                If UBound(a) > -1 Then
                    For i As Integer = 0 To UBound(a)
                        Dim n As DataRow = .NewRow
                        n(0) = b(i)
                        n(1) = a(i)
                        .Rows.Add(n)
                    Next
                End If

                GS_DataGridViewbyDb(DataGridView1, m, "0", False, False) '隐藏文档地址
            End With

        End With

    End Sub
    '双击修改文档
    Private Sub showl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles showl.DoubleClick
        With showl
            If .SelectedRows.Count = 0 Then
                Return
            End If
            Dim fbzgh As String = .SelectedRows(0).Cells(5).Value.ToString
            If fbzgh <> G_dlrgh Then '编辑只有添加者有权限
                MsgBox("只有工号为：" & fbzgh & "才能够修改")
                Return
            End If
            Dim wzid As String = .SelectedRows(0).Cells(0).Value '文章id
            Dim m As New Frjsb_YFXMGL_ZLADD
            m.webz = webz
            m.xgid = wzid
            m.ShowDialog()

        End With
    End Sub
    '显示数据
    Private Sub showsj()
        Dim snode As TreeNode = TreeView1.SelectedNode
        If snode.Level = 0 Or snode.Level > 3 Then
            Return
        End If
        Dim sql As String = ""

        If snode.Level = 1 Then '点击父节点显示所有
            Dim wb As String = GetProcjectName(snode)
            sql = "select tb_jyfxmsj_ID,tb_jyfxmsj_mc,tb_jyfxmsj_fl,tb_jyfxmsj_rq,tb_jyfxmsj_wdbt,tb_jyfxmsj_czrgh,tb_jyfxmsj_glwd,tb_jyfxmsj_glwddz from tb_jyfxmsj where tb_jyfxmsj_mc='" & wb & "'"

        ElseIf snode.Level = 2 Then '只显示分支节点内容
            Dim wb As String = GetProcjectName(snode)
            Dim dfl As String = snode.Text
            Dim f As String = ""
            If dfl = "档案" Then
                f = "'立项', '实施', '小结','总结'"
            ElseIf dfl = "资料" Then
                f = "'图片', '文献', '报告','其它'"
            End If
            sql = "select tb_jyfxmsj_ID,tb_jyfxmsj_mc,tb_jyfxmsj_fl,tb_jyfxmsj_rq,tb_jyfxmsj_wdbt,tb_jyfxmsj_czrgh,tb_jyfxmsj_glwd,tb_jyfxmsj_glwddz from tb_jyfxmsj where tb_jyfxmsj_mc='" & wb & "' and tb_jyfxmsj_fl in(" & f & ")"
        ElseIf snode.Level = 3 Then '只显示分支节点内容
            Dim wb As String = GetProcjectName(snode)
            Dim dfl As String = snode.Text
            sql = "select tb_jyfxmsj_ID,tb_jyfxmsj_mc,tb_jyfxmsj_fl,tb_jyfxmsj_rq,tb_jyfxmsj_wdbt,tb_jyfxmsj_czrgh,tb_jyfxmsj_glwd,tb_jyfxmsj_glwddz from tb_jyfxmsj where tb_jyfxmsj_mc='" & wb & "' and tb_jyfxmsj_fl='" & dfl & "'"
        End If
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt, "0,6,7", True, False) '隐藏文档名称与文档地址

    End Sub
    '最新20篇文档
    Private Sub MenuTopNewDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTopNewDoc.Click
        Dim sql As String = "select top 20 tb_jyfxmsj_ID,tb_jyfxmsj_mc,tb_jyfxmsj_fl,tb_jyfxmsj_rq,tb_jyfxmsj_wdbt,tb_jyfxmsj_czrgh,tb_jyfxmsj_glwd,tb_jyfxmsj_glwddz from tb_jyfxmsj order by tb_jyfxmsj_rq desc"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt, "0,6,7", True, False) '隐藏文档名称与文档地址
    End Sub
    Private Sub showweb(ByVal strid As String) '显示web内容


        WebBrowser1.Navigate(webz & "/cabioyfxm/edit/show.asp?id=" & strid)
        'Dim sql As String = "select tb_jyfxmsj_wdlr from tb_jyfxmsj where tb_jyfxmsj_id=" & sid
        'Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        'Dim zfc As String = "<html>"
        'zfc &= vbCrLf & "<head><meta http-equiv='Content-Type' content='text/html; charset=gb2312'>"
        'zfc &= vbCrLf & "<title>文档</title>"
        'zfc &= vbCrLf & "<script language='VBScript'>"
        'zfc &= vbCrLf & "sub jingao"
        'zfc &= vbCrLf & "if window.event.button=2 then"
        ''zfc &= vbCrLf & "msgbox " & Chr(34) & "文档严禁复制" & Chr(34)

        'zfc &= vbCrLf & "end if"
        'zfc &= vbCrLf & "end sub"
        'zfc &= vbCrLf & "sub zt"
        'zfc &= vbCrLf & "window.event.returnValue = false"
        'zfc &= vbCrLf & "window.clipboardData.setData " & Chr(34) & "text" & Chr(34) & ", " & Chr(34) & "嘉吉烯王生物工程" & Chr(34)
        'zfc &= vbCrLf & "window.event.returnValue = false"
        'zfc &= vbCrLf & "end sub"
        'zfc &= vbCrLf & "</script>"

        'zfc &= vbCrLf & "</head>"
        'zfc &= vbCrLf & "<body onmousedown=jingao  oncopy=zt language=vbscript >"
        'zfc &= vbCrLf & dt1.Rows(0)("tb_jyfxmsj_wdlr")
        'zfc &= vbCrLf & "</body></html>"
        'WebBrowser1.DocumentText = zfc
        'MsgBox(zfc)


    End Sub





    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'Dim f As String = WebBrowser1.Document.Body.InnerHtml
        ''MsgBox(f)
        'f = Replace(f, "/cabiojs", webz)
        'WebBrowser1.Document.Body.InnerHtml = f
    End Sub

    '内部链接的打开
    'Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow
    '    Dim NewURL As String = CType(sender, WebBrowser).StatusText
    '    Dim frmNew As New Frprintweb
    '    frmNew.WebBrowser1.Navigate(NewURL)
    '    frmNew.Show()
    '    e.Cancel = True
    'End Sub



    '关联文档的查看
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        With DataGridView1
            If .SelectedRows.Count = 0 Then
                Return
            End If

            Dim f As String = .SelectedRows(0).Cells(0).Value '文章地址
            If f = "" Then Return
            f = Replace(f, "/cabiojs", webz)
            'Dim frmNew As New Frprintweb
            'frmNew.WebBrowser1.Navigate(f)
            'frmNew.Show()
            Dim bzurl As String = f
            System.Diagnostics.Process.Start("IExplore.exe", bzurl)
        End With
    End Sub
    '搜索
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Dim bds As String = ""
        If CheckBox1.Checked = True Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
            If GF_qdsjdx(tt1, tt2) = False Then
                Return
            End If
            bds = " and tb_jyfxmsj_rq between '" & tt1 & "' and '" & tt2 & "' "
        End If

        Dim AA As DataTable = DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_jyfxmsj_ID,tb_jyfxmsj_mc,tb_jyfxmsj_fl,tb_jyfxmsj_rq,tb_jyfxmsj_wdbt,tb_jyfxmsj_czrgh,tb_jyfxmsj_glwd,tb_jyfxmsj_glwddz from tb_jyfxmsj where tb_jyfxmsj_wdbt like '%" & TextBox1.Text.Trim & "%'" & bds)

        GS_DataGridViewbyDb(showl, AA, "0,6,7", True, False)
    End Sub

    '修改研发项目
    Private Sub MenuModProcj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuModProcj.Click
        Dim snode As TreeNode = TreeView1.SelectedNode
        If snode.Level <> 1 Then
            MsgBox("请选中一个项目")
            Return
        End If
        If GF_storelog1("修改研发项目") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim xmmc As String = snode.Text '项目名称
   
        Dim r As String = InputBox("输入名称！", "将会修改该项目所有档案和资料！", xmmc)
        If r = "" Then Return
        ''''''''''''''''''''''''''''''''''
        Dim sql As String = "select * from tb_jyfxm where tb_jyfxm_mc='" & r & "'"
        Dim AA As DataTable = DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If AA.Rows.Count > 0 Then
            MsgBox("对不起，已经存在相同项目名称，不能修改！")
            Return
        End If
        sql = "update tb_jyfxmsj set tb_jyfxmsj_mc='" & r & "' where tb_jyfxmsj_mc='" & xmmc & "'"
        sql &= vbCrLf & "update   tb_jyfxm set tb_jyfxm_mc='" & r & "' where tb_jyfxm_mc='" & xmmc & "'"
        DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)

        GS_storelog3("修改研发项目:" & xmmc, "修改研发项目") '储存到日志
        SHOWTreeViewAddNode() '主界面刷新
    End Sub
    '删除研发项目
    Private Sub MenuDelProcj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDelProcj.Click
        Dim snode As TreeNode = TreeView1.SelectedNode
        If snode.Level <> 1 Then
            MsgBox("请选中一个项目")
            Return
        End If
        If GF_storelog1("删除研发项目") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim xmmc As String = snode.Text '项目名称
        If MsgBox("确实要删除项目" & xmmc & "吗？是将会删除该项目所有档案和资料！", 1, "提示") <> 1 Then
            Return
        End If
        Dim sql As String = "delete from tb_jyfxmsj where tb_jyfxmsj_mc='" & xmmc & "'"
        sql &= vbCrLf & "delete from tb_jyfxm where tb_jyfxm_mc='" & xmmc & "'"
        DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)

        GS_storelog3("删除研发项目:" & xmmc, "删除研发项目") '储存到日志
        SHOWTreeViewAddNode() '主界面刷新
    End Sub
    ' 删除文档
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDelDoc.Click
        If showl.SelectedRows.Count = 0 Then
            Return
        End If
        Dim sy As Integer = showl.SelectedRows(0).Index
        Dim wzid As String = showl.SelectedRows(0).Cells(0).Value '文章id
        If GF_storelog1("删除研发项目文档") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim xmmc As String = showl.SelectedRows(0).Cells(4).Value '文档名称
        If MsgBox("确实要删除研发项目文档" & xmmc & "吗？", 1, "提示") <> 1 Then
            Return
        End If
        DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, "delete from tb_jyfxmsj where tb_jyfxmsj_ID=" & wzid)
        GS_storelog3("删除研发项目文档:" & xmmc, "删除研发项目文档") '储存到日志
        '''''下面刷新显示
        WebBrowser1.Document.Write("")

        showl.Rows.Remove(showl.SelectedRows(0))
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim snode As TreeNode = TreeView1.SelectedNode
        If snode.Level <> 3 Then
            MsgBox("请选择一个子类，然后进行添加")
            Return
        Else

            ADDXMMC = GetProcjectName(snode) '项目名称(选中子类父节点的父节点)
            ADDZLMC = snode.Text '子类名称
        End If

        Dim m As New Frjsb_YFXMGL_ZLADD
        m.xmmc = ADDXMMC
        m.zlmc = ADDZLMC
        m.webz = webz
        m.ShowDialog()
        showsj()
    End Sub

  
End Class