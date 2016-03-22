Imports System.IO
Public Class frtjmenu
    Dim dt As New DataTable
    Public aa2 As New DataTable
    Private Sub changefacego(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeface11.Click, changeface12.Click, changeface13.Click, _
           changeface14.Click, changeface15.Click, changeface16.Click, changeface17.Click, changeface18.Click, _
         changeface19.Click, changeface20.Click, changeface21.Click, changeface22.Click, changeface110.Click
        Dim nform As New Form
        Select Case CType(sender, Control).Name
            Case "changeface11" : nform = New Frshow_list '油剂部界面
            Case "changeface12" : nform = New Frfenji_list '粉剂部界面
            Case "changeface13" : nform = New Frjsb_list '技术部界面
            Case "changeface14" : nform = New Frqalist 'QA界面
            Case "changeface15" : nform = New Frqc_list 'QC界面
            Case "changeface16" : nform = New Frsbdllist 'EHS界面
            Case "changeface17" : nform = New Frehslist '设备动力部界面
            Case "changeface18" : nform = New Fryllist '运行部界面
            Case "changeface19" : nform = New Frcgrzlist '采购部界面
            Case "changeface20" : nform = New Frrlzy '人力资源部界面
            Case "changeface21" : nform = New frtjmenuNEW '报表界面
            Case "changeface22" : nform = New Frqjface '全局界面
            Case "changeface110" : nform = New Fradminlist '系统管理界面
        End Select
        nform.Show() : Me.Close()
    End Sub
    Private Sub weizhi()
        ListView1.Width = Me.Width
        ListView1.Height = GroupBox1.Top - ListView1.Top - 10
    End Sub
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub Frmain0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        G_TJicon = Drawing.Icon.ExtractAssociatedIcon(Application.StartupPath() & "\image\iphone0426_014.ico")
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        ''''下面保证创建一个没有文件的文件夹,这个文件夹用于一个临时下载目录下载
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
        If G_js <> "管理员" Then
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
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick, downfile.Click
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        Try
            Dim kj As DataTable = GF_czmctb(dt, "tb_tjmenu_mc='" & ListView1.SelectedItems(0).Text & "'")
            Dim ckjs As String = kj.Rows(0)("tb_tjmenu_js") '查看角色
            Dim texts As String = kj.Rows(0)("tb_tjmenu_mc") '报表名称
            ckjs = GF_qhjdh(ckjs)
            If InStr(ckjs, GF_qhjdh(G_js)) = 0 Then
                MsgBox("您没有查看" & ListView1.SelectedItems(0).Text & "的权限") : Exit Sub
            End If

            Dim dkct As String = kj.Rows(0)("tb_tjmenu_dkjm") '打开界面
            If dkct = "Frzdybb" Then '自定义报表界面的打开
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
        GS_StoreLastDo() ' 更新最后一次操作时间
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
            showbb("自定义报表")
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub
    '编辑自定义报表权限
    Private Sub editqx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editqx.Click
        Try
            Dim bbmc As String = ListView1.SelectedItems(0).Text
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
            showbb("自定义报表")
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
        showbb("月报表")
    End Sub

    Private Sub WeekReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeekReport.Click
        showbb("周报表")
    End Sub
    Private Sub DateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateReport.Click
        showbb("日报表")
    End Sub

    Private Sub ElseReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElseReport.Click
        showbb("其它报表")
    End Sub

    Private Sub CustomReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomReport.Click
        showbb("自定义报表")
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
 

End Class