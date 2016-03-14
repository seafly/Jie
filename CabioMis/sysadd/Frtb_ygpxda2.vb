Public Class Frtb_ygpxda2

    Private Sub Frtb_ygpxda2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_yg_w779o,tb_yg_v753n,tb_yg_bmgd,tb_yg_m381e from tb_yg where tb_yg_zt='正常' and tb_yg_w779o<>'软件公司'  order by tb_yg_v753n,tb_yg_bmgd,tb_yg_m381e,tb_yg_w779o ")
        Call GS_useviewbydb2(ListView2, db1, -1, 90)
        setlist()
        Dim alreadychoise As String = Label1.Text
        If alreadychoise <> "" Then
            For i As Integer = 0 To ListView2.Items.Count - 1
                If InStr(alreadychoise, ListView2.Items(i).SubItems(0).Text) > 0 Then
                    Dim a As ListViewItem = ListView2.Items(i).Clone
                    ListView1.Items.Add(a)
                    'ListView2.Items.Remove(ListView2.Items(i))
                End If
            Next
        End If
        '''''''''''''

        ''''''''''''''

    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub setlist()
        With ListView1
            .Clear() : .HideSelection = False
            .CausesValidation = False
            .View = View.Details
            '''''''''''''''''''''''''''
            .BeginUpdate()
            For i As Integer = 0 To ListView2.Columns.Count - 1
                .Columns.Add(ListView2.Columns(i).Text, 90, HorizontalAlignment.Center)
            Next

            'With .Items
            '    If alreadychoise <> "" Then
            '        For i As Integer = 0 To ListView2.Items.Count - 1
            '            If InStr(alreadychoise, ListView2.Items(i).SubItems(0).Text) > 0 Then
            '                Dim a As ListViewItem = ListView2.Items(i).Clone
            '                ListView1.Items.Add(a)
            '                ListView2.Items.Remove(ListView2.Items(i))
            '            End If
            '        Next
            '    End If
            '    '    .Add(dbname.Rows(i)(0).ToString)
            '    '    For j = 1 To ls - 1
            '    '        Dim llsj As String = Null2String(dbname.Rows(i)(j))
            '    '        'llsj = Replace(llsj, "00:00:00", "")
            '    '        listname.Items(i).SubItems.Add(llsj)
            '    '    Next

            '    '    If i Mod 2 = 0 Then
            '    '        listname.Items(i).BackColor = System.Drawing.Color.AliceBlue
            '    '    End If

            '    'Next
            'End With

            .EndUpdate()
        End With
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim ry, bm, xb, gd As String
        ry = "" : bm = "" : xb = "" : gd = ""
        For i As Integer = 0 To ListView1.Items.Count - 1
            ry = ry & ListView1.Items(i).SubItems(0).Text & ","
            bm = bm & ListView1.Items(i).SubItems(1).Text & ","
            gd = gd & ListView1.Items(i).SubItems(2).Text & ","
            xb = xb & ListView1.Items(i).SubItems(3).Text & ","
        Next
        ry = GF_removedh(ry) : bm = GF_removedh(bm) : xb = GF_removedh(xb) : gd = GF_removedh(gd)
        If ry = "" Then
            MsgBox("请选择一个人员") : Exit Sub
        End If
        Dim r As Integer = MsgBox("已选择" & ListView1.Items.Count, 1, "提示")
        If r <> 1 Then
            Exit Sub
        End If
        Me.Owner.Controls("TextBox1").Text = ry '系列
        Me.Owner.Controls("TextBox2").Text = bm '
        Me.Owner.Controls("TextBox3").Text = xb '
        Me.Owner.Controls("TextBox4").Text = gd '
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim t1 As String = TextBox1.Text.Trim
        Dim sql As String = "select tb_yg_w779o,tb_yg_v753n,tb_yg_bmgd,tb_yg_m381e from tb_yg  where tb_yg_w779o like '%" & t1 & "%' group by tb_yg_v753n,tb_yg_bmgd,tb_yg_m381e,tb_yg_w779o"
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView2, db1, -1, 90)
    End Sub

    Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        With ListView2
            If .SelectedItems.Count = 0 Then
                Return
            End If
            Dim a As ListViewItem = .SelectedItems(0).Clone
            ListView1.Items.Add(a)
            .Items.Remove(.SelectedItems(0))
        End With
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        With ListView1
            If .SelectedItems.Count = 0 Then
                Return
            End If
            Dim a As Integer = .SelectedItems(0).Index
            .Items.RemoveAt(a)
        End With
    End Sub
 
End Class