Public Class Frjsb_YFXMGL_ZLADD
    Public xmmc, zlmc, webz As String '项目名称和子类名称，添加的时候不能为空,webz为网页地址前缀
    Public xgid As Integer = 0 '修改id，修改的时候不能为空

    Private Sub Frjsb_YFXMGL_ZLADD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        WebBrowser1.Navigate(webz & "/cabioyfxm/edit/edit.htm")
    End Sub
    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Close()
    End Sub
    Private Sub MenuAddProcj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAddProcj.Click
        WebBrowser1.Document.Window.Frames(0).Document.Body.InnerHtml = ""
        Title.Text = ""
    End Sub

    Private Sub showl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles showl.DoubleClick
        With showl
            If .SelectedRows.Count = 0 Then
                Return
            End If

            Dim wzid As String = .SelectedRows(0).Cells(0).Value '文章id
            Dim wzbt As String = .SelectedRows(0).Cells(2).Value '文章标题
            Dim inserturl As String = "<a href='show.asp?id=" & wzid & "' target='_blank'>" & wzbt & "</a>"
            WebBrowser1.Document.InvokeScript("insertHTML", New String() {inserturl})
        End With
    End Sub
    '资料的搜索
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n As String = TextBox1.Text.Trim
        If n = "" Then Return
        Dim sql As String = "select tb_jyfxmsj_ID,tb_jyfxmsj_mc,tb_jyfxmsj_wdbt,tb_jyfxmsj_rq,tb_jyfxmsj_czrgh from tb_jyfxmsj where  tb_jyfxmsj_wdbt like '%" & n & "%'"
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt1, "0,3,4", True, True)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim glwd, gldz As String '关联文档和关联地址。用特殊符号さβ隔开
        glwd = "" : gldz = ""
        With WebBrowser1.Document
            Dim s As Integer = .Window.Frames(0).Document.Links.Count
            If s > 0 Then
                For i As Integer = 0 To s - 1
                    Dim A As String = .Window.Frames(0).Document.Links(i).InnerText
                    Dim B As String = .Window.Frames(0).Document.Links(i).GetAttribute("href")
                    B = Replace(B, webz, "/cabiojs") '替换是怕带入IP地址，会给以后迁移带来不便，只是保存相对地址
                    If i = s - 1 Then

                        glwd &= A
                        gldz &= B

                    Else
                        glwd &= A & "さ"
                        gldz &= B & "さ"
                    End If

                    'MsgBox(A & "---" & B)
                Next
            End If
        End With
        ''''
        Dim bt As String = Title.Text.Trim
        Dim lr As String = WebBrowser1.Document.Window.Frames(0).Document.Body.InnerHtml
        lr = Replace(lr, webz, "/cabiojs") '替换是怕带入IP地址，会给以后迁移带来不便，只是保存相对地址
        'MsgBox(lr)
        'Return
        If bt = "" Or lr = "" Then
            MsgBox("注意标题和内容不能为空白") : Return
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        If xgid > 0 Then '修改操作是否有权限在主界面判定

            Dim sql As String = "select * from tb_jyfxmsj where tb_jyfxmsj_id=" & xgid
            RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS("tb_jyfxmsj_wdbt").value = bt
            RS("tb_jyfxmsj_wdlr").value = lr
            RS("tb_jyfxmsj_czrgh").value = G_dlrgh
            RS("tb_jyfxmsj_glwd").value = glwd
            RS("tb_jyfxmsj_glwddz").value = gldz
            RS.update()

        Else '添加操作
            Dim qxxz As String = "" '权限性质
            Select Case zlmc
                Case "立项", "实施", "小结", "总结"
                    qxxz = "添加研发项目档案"
                Case "图片", "文献", "报告", "其它"
                    qxxz = "添加研发项目资料"
            End Select
            If GF_storelog1(qxxz) = False Then
                Exit Sub
            End If ' 判断是否有权限
            RS.open("tb_jyfxmsj", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            RS("tb_jyfxmsj_mc").value = xmmc
            RS("tb_jyfxmsj_fl").value = zlmc
            RS("tb_jyfxmsj_wdbt").value = bt
            RS("tb_jyfxmsj_wdlr").value = lr
            RS("tb_jyfxmsj_czrgh").value = G_dlrgh
            RS("tb_jyfxmsj_glwd").value = glwd
            RS("tb_jyfxmsj_glwddz").value = gldz
            RS.update()
            GS_storelog3(qxxz & bt, qxxz) '储存到日志
        End If

        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

        '''''''''''''''''''''''''''''''''''''''
        MsgBox("操作成功")
        Me.Close()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If xgid > 0 Then
            Dim sql As String = "select * from tb_jyfxmsj where tb_jyfxmsj_id=" & xgid
            Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            WebBrowser1.Document.Window.Frames(0).Document.Body.InnerHtml = dt1.Rows(0)("tb_jyfxmsj_wdlr")
            Title.Text = dt1.Rows(0)("tb_jyfxmsj_wdbt")
        End If
    End Sub
End Class