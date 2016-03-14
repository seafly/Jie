Public Class Frdzxf3

    Private Sub Frdzxf3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_czmctb(_D.G_biaoinf, "tb_biaoinf_mx  in ('小罐生产','中罐生产','大罐生产','毛油')")
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
        sql = sql & "where tb_biaozdinf_biao='" & gx & "'"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView1, dt, 0, 100)

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
        
        Next
        Dim kk As ListViewItem = listviewstr2.Items.Add(listviewstr.SelectedItems(0).SubItems(0).Text)
        For i As Integer = 1 To listviewstr2.Columns.Count - 4
            With kk.SubItems
                .Add(listviewstr.SelectedItems(0).SubItems(i).Text)
            End With
        Next
        kk.SubItems.Add("无") : kk.SubItems.Add("无") : kk.SubItems.Add("")
    End Sub
    Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        Dim aa As New frdzxf2
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        hysj(ListView1, ListView2)
    End Sub
    '查询
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListView2.Items.Count = 0 Then
            Exit Sub
        End If
        ' MsgBox(GZSQL(ListView2))
        '  TextBox1.Text = GZSQL(ListView2) : Exit Sub
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
        Dim xzfjhm = "" '定义涉及的所有查询表
        With STR
            For I As Integer = 0 To ListView2.Items.Count - 1
                Dim ZDM As String = .Items(I).SubItems(0).Text '字段名
                '''''''''''''''''''''''
                Dim bm As String = frdzxf.ddbm(ZDM) '得到表名
                If InStr(xzfjhm, bm) > 0 Then '过滤掉重复
                Else
                    xzfjhm &= bm & ","
                End If
                '''''''''''''''''''''''

                Dim ZDlx As String = .Items(I).SubItems(3).Text '字段类型
                Dim ZDtj As String = .Items(I).SubItems(4).Text '条件
                Dim ZDpx As String = .Items(I).SubItems(5).Text '排序
                Dim locic As String = .Items(I).SubItems(6).Text '逻辑
                zdzfc = zdzfc & bm & "." & ZDM & ","
                Dim hh As String = frdzxf.tjbds(ZDlx, ZDtj, ZDM, locic)
                '  If hh <> "" Then
                tjzfc = tjzfc & hh & " "
                '  End If
                If frdzxf.pxfs(ZDpx) <> "" Then
                    pxzfc = pxzfc & bm & "." & ZDM & frdzxf.pxfs(ZDpx) & ","
                End If
            Next
        End With
        zdzfc = GF_removedh(zdzfc) '查询的字段串
        tjzfc = GF_removedh(tjzfc) '条件字段串
        pxzfc = GF_removedh(pxzfc) '排序的字段串
        If Trim(pxzfc) <> "" Then
            pxzfc = " order by " & pxzfc
        End If
        ''''''''''''''''''''''''''''''
        xzfjhm = GF_removedh(xzfjhm) '涉及的所有查询表
        Dim xzd As String = ""
        If InStr(xzfjhm, "tb_b970t") > 0 And InStr(xzfjhm, "tb_b959t") > 0 Then '过滤掉重复
            xzd &= "  and tb_b959t.tb_b959t_num2=tb_b970t.tb_b970t_num "
        End If
        If InStr(xzfjhm, "tb_i234a") > 0 And InStr(xzfjhm, "tb_b959t") > 0 Then '过滤掉重复
            xzd &= " and tb_b959t.tb_b959t_num=tb_i234a.tb_i234a_num2 "
        End If
        If InStr(xzfjhm, "tb_i234a") > 0 And InStr(xzfjhm, "tb_x825p") > 0 Then '过滤掉重复
            xzd &= " and tb_x825p.tb_x825p_num2=tb_i234a.tb_i234a_num  "
        End If
        '''''''''''''''''''''''''''''
        GZSQL = "select " & zdzfc & " from  " & xzfjhm & "  where 1=1  "
        GZSQL = GZSQL & xzd
        If tjzfc.Trim <> "" Then
            tjzfc = Replace(tjzfc, " and ", " and (", 1, 1)
            tjzfc = tjzfc & ")"
        End If
        GZSQL = GZSQL & tjzfc & pxzfc
        'MsgBox(GZSQL)
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