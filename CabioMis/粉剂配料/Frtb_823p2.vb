''' <summary>
''' 粉剂配料
''' </summary>
Public Class Frtb_823p2

    Private Sub Frtb_823p2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        showsj()
        ListView2.View = View.Details : ListView3.View = View.Details
        ListView2.Columns.Add("流水号") : ListView2.Columns.Add("平均重量")
        ListView3.Columns.Add("流水号") : ListView3.Columns.Add("平均重量")
    End Sub
    Private Sub showsj()
        ' str表示隐藏DB中哪个字段,为-1表示不隐藏
        Dim xpgs As Integer = Label2.Text '小批个数
        Dim xpzl As Double = Label24.Text '平均重量
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d where tb_l358d_zd='34号塔'")
        Dim phqz As String = dt.Rows(0)(2) '前缀
        Dim dqz As Integer = dt.Rows(0)(3) '当前值
        With ListView1
            .Clear() : .CausesValidation = False : .View = View.Details
            .BeginUpdate()
            .Columns.Add("流水号") : .Columns.Add("平均重量")
            With .Items
                For i As Integer = 0 To xpgs - 1
                    dqz = dqz + 1
                    Dim ph As String = phqz & "-34-" & dqz.ToString
                    .Add(ph)
                    ListView1.Items(i).SubItems.Add(xpzl)
                Next
            End With
            .EndUpdate()
        End With
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        '浏览原来的下步ID是否有值
        With Me
            For j As Integer = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
                    If .Controls(j).Text.Trim = "" Then
                        MsgBox("请将数据填写完整！") : .Controls(j).Focus() : Exit Sub
                    End If
                    If .Controls(j).GetType.Name = "chentextint" Or .Controls(j).GetType.Name = "chentextintz" Or .Controls(j).GetType.Name = "chentextzs" Then
                        If .Controls(j).Text.Trim <= 0 Then
                            MsgBox("请填写大于0的数字！") : .Controls(j).Focus() : Exit Sub
                        End If
                    End If
                End If
            Next
        End With
        ''''''''''''''''''''''''''

        If ListView2.Items.Count = 0 Or ListView3.Items.Count = 0 Then
            MsgBox("3、4号塔内必须都有数据！") : Exit Sub
        End If
        If ListView1.Items.Count <> 0 Then
            MsgBox("数据必须拖拽完！") : Exit Sub
        End If


        '''''''''''''''''''''''''''''''''
        Dim sql As String = ""

        '读取原来的ID 加上现在的ID
        Dim idAll As String = ""

        Dim m As Integer = 0

        '插入三号塔小批
        For i As Integer = 0 To ListView2.Items.Count - 1
            sql = "insert into tb_n441f(tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_m382e,tb_n441f_num,tb_n441f_num2) values('tb_x823p','" & Labelid.Text & "','三号塔','" & ListView2.Items(i).SubItems(0).Text & "','" & Label1.Text & "')"
            idAll &= GF_upztxx2(G_cnnstr, sql, "tb_n441f") & ","
            m = m + 1
        Next

        '插入四号塔小批
        For i As Integer = 0 To ListView3.Items.Count - 1
            sql = "insert into tb_n441f(tb_n441f_sbtb,tb_n441f_sbid,tb_n441f_m382e,tb_n441f_num,tb_n441f_num2) values('tb_x823p','" & Labelid.Text & "','四号塔','" & ListView3.Items(i).SubItems(0).Text & "','" & Label1.Text & "')"
            idAll &= GF_upztxx2(G_cnnstr, sql, "tb_n441f") & ","
            m = m + 1
        Next
        GS_upztxx(G_cnnstr, "update tb_l358d set tb_l358d_dqz=tb_l358d_dqz + " & m & " where tb_l358d_zd='34号塔'")
        idAll = GF_removedh(idAll)


        '下步ID  3,4塔的 SBID
        Dim thid As String = "tb_x823p_xbid2"


        '更新配料表的 下步ID
        sql = "update tb_x823p set " & thid & "='" & idAll & "',tb_x823p_xbtb='tb_n441f', tb_x823p_cfsl=tb_x823p_cfsl-" & Label2.Text & "  where tb_x823p_ID=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub changelsh(ByVal str As ListView) '改变列表的流水号
        If str.Items.Count = 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To str.Items.Count - 1
            str.Items(i).SubItems(0).Text = i + 1
        Next
    End Sub
    '‘’‘’‘’‘’‘’‘’‘’‘’‘’下面是拖放的核心’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
    Private Sub ListView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDown
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim cc As String = ""
        For j As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim bb As String = ""
            For i As Integer = 0 To ListView1.Columns.Count - 1
                bb = bb & ListView1.SelectedItems(j).SubItems(i).Text & "さ" '列间隔号
            Next
            bb = GF_removedh(bb)
            cc = cc & bb & "な" '行间隔号
        Next
        cc = GF_removedh(cc)

        '上面用特殊字符间隔开所选的项目，便于以后分解
        ListView1.DoDragDrop(cc, DragDropEffects.Copy) '开始拖拽
    End Sub
    '判断拖拽数据，不要改动
    Private Sub ListView2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView2.DragEnter, ListView3.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    '放下
    Private Sub ListView2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView2.DragDrop
        Dim cc As String = e.Data.GetData(DataFormats.Text).ToString
        fxsj(ListView2, cc)

    End Sub

    '放下
    Private Sub ListView3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView3.DragDrop
        Dim cc As String = e.Data.GetData(DataFormats.Text).ToString
        fxsj(ListView3, cc)

    End Sub

    Private Sub fxsj(ByVal listviewstr As ListView, ByVal str As String) '填充拖拽数据
        Dim mm() As String = Split(str, "な")
        For j As Integer = 0 To UBound(mm)
            Dim bb() As String = Split(mm(j), "さ")
            Dim kk As ListViewItem = listviewstr.Items.Add(bb(0))
            For i As Integer = 1 To UBound(bb)
                kk.SubItems.Add(bb(i))
            Next
            '删除原来数据
            For i As Integer = 0 To ListView1.SelectedItems.Count - 1
                Dim ylsy As Integer = ListView1.SelectedItems(0).Index
                ListView1.Items.RemoveAt(ylsy)
            Next

        Next
    End Sub

    '‘’‘’‘’‘’‘’‘’‘’‘’‘’下面是还原数据’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
    Private Sub hysj(ByVal listviewstr As ListView)
        '   Dim ylsy1 As String = listviewstr.SelectedItems(0).SubItems(0).Text
        '  Dim ylsy2 As String = listviewstr.SelectedItems(0).SubItems(1).Text
        Dim ylsy As Integer = listviewstr.SelectedItems(0).Index

        Dim kk As ListViewItem = ListView1.Items.Add(listviewstr.SelectedItems(0).SubItems(0).Text)
        For i As Integer = 1 To ListView1.Columns.Count - 1
            With kk.SubItems
                .Add(listviewstr.SelectedItems(0).SubItems(i).Text)
            End With
        Next
        listviewstr.Items.RemoveAt(ylsy)
    End Sub

    Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        hysj(ListView2)
    End Sub

    Private Sub ListView3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView3.MouseDoubleClick
        hysj(ListView3)
    End Sub
End Class