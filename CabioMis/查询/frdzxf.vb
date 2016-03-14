Public Class frdzxf

    Private Sub frdzxf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_zdycxb from tb_js where tb_js_mc='" & G_js & "'")
        If IsDBNull(kk.Rows(0)(0)) Then
            MsgBox("尚未设定该角色任何自定义查看表权限") : Me.Close() : Exit Sub
        End If
        Dim jsckqx As String = GF_zhzfccx(kk.Rows(0)(0)) ' '组合字符串组合IN查询字符串

        kk = GF_CreateDataSource(G_cnnstr, "select * from tb_biaoinf where tb_biaoinf_mc  in (" & jsckqx & ") order by tb_biaoinf_id")
        Call GS_wlbktlr2(gongxu, kk, 2, "")
        gongxu.SelectedItem = gongxu.Items(0)
        Call showsj()
        ListView2.View = View.Details
        ListView2.Columns.Add("tb", 0) : ListView2.Columns.Add("表", 100) : ListView2.Columns.Add("字段", 100) : ListView2.Columns.Add("字段类型", 100) : ListView2.Columns.Add("条件", 100) : ListView2.Columns.Add("排序", 50) : ListView2.Columns.Add("逻辑", 50)
    End Sub

    Private Sub gongxu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gongxu.SelectedIndexChanged
        Call showsj()
    End Sub
    Private Sub showsj()
        Dim gx As String = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mx='" & gongxu.Text & "'", 1)
        Dim sql As String
        Dim dt As DataTable
        sql = "select tb_biaozdinf_mc,'" & gongxu.Text & "' as 表 ,tb_biaozdinf_mx ,tb_biaozdinf_lx from tb_biaozdinf "
        sql = sql & "where tb_biaozdinf_biao='" & gx & "' and tb_biaozdinf_mx not in ('上步表','下步表','上步ID','下步ID','主键')"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView1, dt, 0, 100)
        showl.Rows.Clear()
        showl.Columns.Clear() '避免头部消失
        ListView2.Items.Clear() : Label2.Text = "查询结果："
    End Sub
 
    '‘’‘’‘’‘’‘’‘’‘’‘’‘’下面是还原数据’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
    '把listviewstr的数据还原到listviewstr2
    Private Sub hysj(ByVal listviewstr As ListView, ByVal listviewstr2 As ListView)
        Dim ylsy As Integer = listviewstr.SelectedItems(0).Index
        Dim k1, k2 As String
        k1 = listviewstr.SelectedItems(0).SubItems(1).Text
        k2 = listviewstr.SelectedItems(0).SubItems(2).Text
        For i As Integer = 0 To listviewstr2.Items.Count - 1
            If listviewstr2.Items(i).SubItems(1).Text = k1 And listviewstr2.Items(i).SubItems(2).Text = k2 Then
                MsgBox("该字段已经选择") : Exit Sub
            End If
            If i > 0 And listviewstr2.Items(i).SubItems(1).Text <> k1 Then
                MsgBox("自定义查询不能选择不同的表") : Exit Sub
            End If
        Next
      
        Dim kk As ListViewItem = listviewstr2.Items.Add(listviewstr.SelectedItems(0).SubItems(0).Text)
        For i As Integer = 1 To listviewstr2.Columns.Count - 4
            With kk.SubItems
                .Add(listviewstr.SelectedItems(0).SubItems(i).Text)
            End With
        Next
        kk.SubItems.Add("无") : kk.SubItems.Add("无") : kk.SubItems.Add("")
    End Sub
    '下面是删除
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
    '查询
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListView2.Items.Count = 0 Then
            Exit Sub
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, GZSQL(ListView2))
        Try
            Call GS_DataGridViewbyDb(showl, dt, True, True)
            Label2.Text = "查询结果：" & GF_getListViewsz(showl) & "条记录"
        Catch ex As Exception
            MsgBox("条件构造出错，请检查")
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
                Dim ZDM As String = .Items(I).SubItems(0).Text '字段名
                bm = ddbm(ZDM) '得到表名
                Dim ZDlx As String = .Items(I).SubItems(3).Text '字段类型
                Dim ZDtj As String = .Items(I).SubItems(4).Text '条件
                Dim ZDpx As String = .Items(I).SubItems(5).Text '排序
                Dim locic As String = .Items(I).SubItems(6).Text '逻辑
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
        zdzfc = GF_removedh(zdzfc) '查询的字段串
        tjzfc = GF_removedh(tjzfc) '条件字段串
        pxzfc = GF_removedh(pxzfc) '排序的字段串
        If Trim(pxzfc) <> "" Then
            pxzfc = " order by " & pxzfc
        End If
        GZSQL = "select " & zdzfc & " from " & bm & " where (1=1) " & tjzfc & pxzfc
    End Function
    Public Function tjbds(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String, ByVal locic As String) As String '得到条件表达式,字段类型,内容,名称
        Dim ysf As String = locic '逻辑
        Select Case locic
            Case "且", "" : ysf = " and "
            Case "或" : ysf = " or "
        End Select
        tjbds = ""
        str3 = ddbm(str3) & "." & str3 '字段名
        If str2 = "无" Then
            Exit Function
        End If
        Dim tj1 As String = GF_searchchar(str2, "：", "left") '条件
        Dim tj2 As String = GF_searchchar(str2, "：", "right") '内容
        If str1 = "varchar(8000)" And tj1 = "模糊" Then
            tjbds = ysf & "(" & str3 & " like '%" & tj2 & "%')"
            Exit Function
        End If
        If (str1 = "datetime" Or str1 = "smalldatetime") And tj1 = "之间" Then '日期之间
            Dim tjj1 As String = GF_searchchar(tj2, ",", "left")
            Dim tjj2 As String = GF_searchchar(tj2, ",", "right")
            tjbds = ysf & "(" & str3 & " between '" & tjj1 & "' and '" & tjj2 & "')"
            Exit Function
        End If
        If str1 <> "datetime" And str1 <> "smalldatetime" And tj1 = "之间" Then '数字之间
            Dim tjj1 As String = GF_searchchar(tj2, ",", "left")
            Dim tjj2 As String = GF_searchchar(tj2, ",", "right")
            tjbds = ysf & "(" & str3 & " between " & tjj1 & " and " & tjj2 & ")"
            Exit Function
        End If
        tj1 = Replace(tj1, "大于", ">") : tj1 = Replace(tj1, "小于", "<")
        tj1 = Replace(tj1, "不等于", "<>") : tj1 = Replace(tj1, "等于", "=")
        tj1 = Replace(tj1, "不包含", " not in ") : tj1 = Replace(tj1, "包含", " in ")
        If str1 = "varchar(8000)" Or str1 = "smalldatetime" Or str1 = "datetime" Then
            tj2 = Replace(tj2, ",", "','")
            tj2 = "'" & tj2 & "'"
            If InStr(tj1, "in") > 0 Then
                tj2 = "(" & tj2 & ")"
            End If
        End If
        tjbds = ysf & str3 & tj1 & tj2 & " "

    End Function
    Public Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
    Public Function pxfs(ByVal str As String) As String
        pxfs = ""
        If str = "升序" Then
            pxfs = " ASC "
        ElseIf str = "降序" Then
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