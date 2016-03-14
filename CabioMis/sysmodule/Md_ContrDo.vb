Module Md_ContrDo
    '控件处理
#Region "ComboBox处理"
    '为一个ComboBox构建数字值，str1是默认值，str2是起点，str3是终点
    Public Sub GS_wlbktlr(ByVal STR As Windows.Forms.ComboBox, ByVal str1 As Integer, ByVal str2 As Integer, ByVal str3 As Integer)
        STR.Items.Clear()
        For i As Integer = str2 To str3
            STR.Items.Add(i)
        Next
        STR.Text = str1

    End Sub

    ''' <summary>
    ''' 根据DB为一个ComboBox构建下拉
    ''' </summary>
    ''' <param name="STR"></param>
    ''' <param name="db"></param>
    ''' <param name="str1">DB的字段序号</param>
    ''' <param name="str2">默认值</param>
    ''' <param name="blNull">是否添加空值</param>
    ''' <remarks></remarks>
    Public Sub GS_wlbktlr2(ByVal STR As Windows.Forms.ComboBox, ByVal db As DataTable, Optional ByVal str1 As Integer=0, Optional ByVal str2 As String="",Optional blNull AS Boolean=False)
        STR.Items.Clear()
        If blNull Then
             STR.Items.Add("")
        End If
        If db.Rows.Count > 0 Then
            For i As Integer = 0 To db.Rows.Count - 1
                STR.Items.Add(db.Rows(i)(str1))
            Next
        End If
        Try
            If blNull And str2 = "" Then
                STR.Text = ""
                Return
            End If
            If str2 = "" And db.Rows.Count > 0 Then
                STR.Text = db.Rows(0)(str1)
            Else
                STR.Text = str2
            End If
        Catch ex As Exception
            STR.Text = ""
        End Try

    End Sub
    Public Sub GS_wlbktlr22(ByVal STR As Windows.Forms.ComboBox, ByVal db As DataTable, ByVal str2 As String)
        STR.Items.Clear()
        If db.Rows.Count > 0 Then
            For i As Integer = 0 To db.Rows.Count - 1
                STR.Items.Add(db.Rows(i)("tb_yg_n430f") & "|" & db.Rows(i)("tb_yg_w779o"))
            Next
        End If
        Try
            STR.Text = str2
        Catch ex As Exception
            STR.Text = ""
        End Try

    End Sub
    '根据数组为一个ComboBox构建下拉，，str1是DB的字段序列，str2是默认值
    Public Sub GS_wlbktlr3(ByVal ComboBoxName As Windows.Forms.ComboBox, ByVal ArrayStr() As String, ByVal str As String)
        ComboBoxName.Items.Clear()
        If ArrayStr.Length = 0 Then
            Return
        End If
        For i As Integer = 0 To UBound(ArrayStr)
            ComboBoxName.Items.Add(ArrayStr(i))
        Next
        If str <> "" Then
            ComboBoxName.Text = str
        Else
            ComboBoxName.SelectedIndex = 0
        End If
    End Sub


    '根据DB为一个ComboBox构建下拉，，str1是DB的字段序列，str2是默认值
    Public Sub GS_wlbktlr3(ByVal STR As Windows.Forms.ToolStripComboBox, ByVal db As DataTable, ByVal str1 As Integer, ByVal str2 As String)
        If db.Rows.Count > 0 Then
            For i As Integer = 0 To db.Rows.Count - 1
                STR.Items.Add(db.Rows(i)(str1))
            Next
        End If
        If str2 = "" And db.Rows.Count > 0 Then
            STR.Text = db.Rows(0)(str1)
        Else
            STR.Text = str2
        End If
    End Sub
#End Region

    '得到某个ListView或者DataGridView显示的数据条
    Function GF_getListViewsz(ByVal list1 As Control) As Integer '得到ListView空间的行数

        If list1.GetType.ToString = "System.Windows.Forms.ListView" Then
            Dim cc As Windows.Forms.ListView = list1
            Return cc.Items.Count()
        ElseIf list1.GetType.ToString = "System.Windows.Forms.DataGridView" Then
            Dim cc As Windows.Forms.DataGridView = list1
            Return cc.Rows.Count()
        ElseIf list1.GetType.ToString = "yangNetCl.yanDaTaGridView" Then
            Dim cc As yangNetCl.yanDaTaGridView = list1
            Return cc.Rows.Count()
        End If

    End Function

    'ComboBox填充年数列
    Public Sub GS_niansl(ByVal str As ComboBox)
        For i As Integer = 2008 To 2025
            str.Items.Add(i)
        Next
        str.Text = Now.Year
    End Sub
    'ComboBox填充月数列
    Public Sub GS_monthsl(ByVal str As ComboBox)
        For i As Integer = 1 To 12
            str.Items.Add(i)
        Next
        str.Text = Now.Month
    End Sub
    '通过DB构造listview
    Public Sub GS_useviewbydb(ByVal listname As ListView, ByVal dbname As DataTable, ByVal str As Integer)
        ' str表示隐藏DB中哪个字段,为-1表示不隐藏
        Dim ls As Integer = dbname.Columns.Count
        Dim i, j As Integer
        With listname
            .Clear() : .Visible = True
            .CausesValidation = False
            .View = View.Details
            .BeginUpdate()
            If str = -1 Then
                For i = 0 To ls - 1
                    .Columns.Add(dbname.Columns(i).Caption, CType((.Width / ls), Integer), HorizontalAlignment.Center)
                Next
            Else '隐藏字段
                For i = 0 To ls - 1
                    If i = str Then
                        .Columns.Add(dbname.Columns(i).Caption, 0, HorizontalAlignment.Center)
                    Else
                        .Columns.Add(dbname.Columns(i).Caption, CType((.Width / (ls - 1)), Integer), HorizontalAlignment.Center)
                    End If

                Next
            End If


            With .Items
                For i = 0 To dbname.Rows.Count - 1
                    .Add(dbname.Rows(i)(0).ToString)
                    For j = 1 To ls - 1

                    Next
                Next
            End With
            .EndUpdate()
        End With
    End Sub

    ''' <summary>
    ''' 通过DB构造listview
    ''' </summary>
    ''' <param name="listname">listView对象</param>
    ''' <param name="dbname">数据源</param>
    ''' <param name="str">隐藏DB中哪个字段，默认-1表示不隐藏</param>
    ''' <param name="strkd">宽度，默认0代表自动分配列宽</param>
    ''' <param name="pBlbox">是否添加复选列，默认0代表自动分配列宽</param>
    ''' <param name="pCmenu">右键菜单对象</param>
    Public Sub GS_useviewbydb2(ByVal listname As ListView, ByVal dbname As DataTable, Optional ByVal str As Integer = -1,
                               Optional ByVal strkd As Integer = 0, Optional ByVal pBlbox As Boolean = False, Optional ByVal pCmenu As ContextMenuStrip = Nothing)
        If dbname Is Nothing Then
            Return
        End If
        Dim ls As Integer = dbname.Columns.Count
        Dim i, j As Integer
        Dim bb As String


        With listname
            '设置行高()
            Dim imgList As ImageList = New ImageList()
            imgList.ImageSize = New Size(18, 20) '分别是宽和高
            listname.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大

            .Clear() : .Visible = True : .HideSelection = False
            .CausesValidation = False
            .View = View.Details
            ''''''''''''''''''添加排序功能
            AddHandler .ColumnClick, AddressOf GS_LISTVIEWSORT
            '''''''''''''''''''''''''''
            .BeginUpdate()
            If .CheckBoxes = False Then
                .CheckBoxes = pBlbox  '是否显示复选框
            End If

            If str = -1 Then
                For i = 0 To ls - 1
                    '下面通过字段名称得到字段描叙()
                    bb = dbname.Columns(i).Caption

                    Dim zdn As String
                    zdn = GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & bb & "'", 4) '得到字段中文意思
                    If zdn = "" Then '当不通过查询来查找字段意思的时候
                        zdn = bb
                    End If
                    Dim newitem As ColumnHeader

                    If strkd = 0 Then '是否平均分配列宽
                        newitem = .Columns.Add(zdn, CType((.Width / ls), Integer), HorizontalAlignment.Center)
                    Else
                        newitem = .Columns.Add(zdn, strkd, HorizontalAlignment.Center)
                    End If
                    newitem.Tag = bb '把真正的字段名保存在这个属性中，如果不是从数据库中查询的，那么这个等于列标题
                Next

            Else '隐藏字段

                For i = 0 To ls - 1
                    '下面通过字段名称得到字段描叙()

                    bb = dbname.Columns(i).Caption
                    Dim zdn As String
                    zdn = GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & bb & "'", 4) '得到字段中文意思
                    If zdn = "" Then '当不通过查询来查找字段意思的时候
                        zdn = bb
                    End If
                    Dim newitem As ColumnHeader

                    If i = str Then
                        newitem = .Columns.Add(zdn, 0, HorizontalAlignment.Center)
                    Else
                        If strkd = 0 Then '是否平均分配列宽
                            newitem = .Columns.Add(zdn, CType((.Width / (ls - 1)), Integer), HorizontalAlignment.Center)
                        Else
                            newitem = .Columns.Add(zdn, strkd, HorizontalAlignment.Center)
                        End If
                    End If
                    newitem.Tag = bb '把真正的字段名保存在这个属性中，如果不是从数据库中查询的，那么这个等于列标题
                Next

            End If

            With .Items
                For i = 0 To dbname.Rows.Count - 1
                    .Add(dbname.Rows(i)(0).ToString)
                    For j = 1 To ls - 1
                        Dim llsj As String = Null2String(dbname.Rows(i)(j))
                        'llsj = Replace(llsj, "00:00:00", "")
                        listname.Items(i).SubItems.Add(llsj)
                    Next

                    If i Mod 2 = 0 Then
                        listname.Items(i).BackColor = System.Drawing.Color.AliceBlue
                    End If

                Next
            End With


            Dim menu1 As ContextMenuStrip
            If pCmenu Is Nothing Then
                menu1 = New ContextMenuStrip
                menu1.Items.Add("查看明细")
                AddHandler menu1.ItemClicked, AddressOf GS_mendj
            Else
                menu1 = pCmenu
            End If

            If .Items.Count > 0 Then
                listname.ContextMenuStrip = menu1
                AddHandler menu1.Paint, Sub(sender As ContextMenuStrip, e As System.EventArgs)
                                            If CType(sender.SourceControl, ListView).SelectedItems.Count = 0 AndAlso
                                               CType(sender.SourceControl, ListView).CheckedItems.Count = 0 Then
                                                sender.Hide()
                                            End If
                                        End Sub
            End If
            .EndUpdate()
        End With

    End Sub
    'LISTVIEW排序功能
    Public Sub GS_LISTVIEWSORT(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        With sender
            Dim djl As Integer = e.Column
            Dim cc As DataTable = ListviewToDatatable(sender)
            Dim view1 As DataView = cc.DefaultView
            Dim pxfs As String = "ASC"
            Randomize()
            Dim value As Integer = CInt(Int((2 * Rnd()) + 0))
            Select Case value
                Case 0 : pxfs = "ASC"
                Case 1 : pxfs = "DESC"
            End Select
            view1.Sort = cc.Columns(djl).Caption & " " & pxfs
            .Items.Clear()
            .BeginUpdate()
            For i As Integer = 0 To view1.Count - 1
                .Items.Add(view1(i)(0).ToString)
                If cc.Columns.Count > 1 Then
                    For j As Integer = 1 To cc.Columns.Count - 1
                        .Items(i).SubItems.Add(view1(i)(j).ToString)
                    Next
                End If
            Next
            .EndUpdate()
        End With
    End Sub
    '查看明细
    Public Sub GS_mendj(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) '这个过程配合下面的响应查看明细的点击
        Dim menu1 As ContextMenuStrip = sender
        Dim kk As ListView = sender.SourceControl
        Select Case e.ClickedItem.Text
            Case "查看明细"
                If kk.SelectedItems.Count > 0 Then
                    Dim k1 As String = ""
                    For i As Integer = 0 To kk.Columns.Count - 1
                        k1 = k1 & kk.Columns(i).Text & "：" & kk.SelectedItems(0).SubItems(i).Text & vbCrLf & vbCrLf
                    Next
                    Dim nformmx As New Frshowmx
                    nformmx.TextBox1.Text = k1
                    nformmx.ShowDialog()
                End If

            Case "打印"
                Dim tbhtml As String = Frprintweb.GF_DbToPrintWeb(kk)
                Dim webprint As New Frprintweb
                Dim webBrowserForPrinting As WebBrowser = webprint.WebBrowser1
                With webBrowserForPrinting
                    .Document.Write("<html><head><meta http-equiv='Content-Type' content='text/html; charset=gb2312'>" _
                    & "<title>打印</title></head>" _
                    & "<body style='margin-top:0px;' >")
                    .Document.Write(tbhtml)
                    .Document.Write("</body></html>")
                End With
                webprint.Show()
        End Select

    End Sub
    'Listview转化db
    Public Function ListviewToDatatable(ByVal Listview1 As ListView) As Data.DataTable  'listview转为Datatable函数
        Dim Table1 As New DataTable
        Dim i As Integer
        Dim datacol As DataColumn
        For i = 0 To Listview1.Columns.Count - 1
            datacol = New DataColumn
            datacol.DataType = GetType(String)
            datacol.ColumnName = IIf(Listview1.Columns(i).Name = "", Listview1.Columns(i).Text.Trim, Listview1.Columns(i).Name)
            If Table1.Columns.Contains(datacol.ColumnName)=False Then
                Table1.Columns.Add(datacol)
            End If
        Next i

        Dim j As Integer
        Dim Datarow1 As DataRow
        If Listview1.CheckBoxes = True Then
            For j = 0 To Listview1.CheckedItems.Count - 1
                Datarow1 = Table1.NewRow
                For i = 0 To Listview1.Columns.Count - 1
                    If Listview1.Columns(i).Text.Trim <> "" Then
                        Datarow1.Item(IIf(Listview1.Columns(i).Name = "", Listview1.Columns(i).Text.Trim, Listview1.Columns(i).Name)) =
                            Listview1.CheckedItems(j).SubItems(i).Text.ToString
                    End If
                Next i
                Table1.Rows.Add(Datarow1)
            Next j
        Else
            For j = 0 To Listview1.Items.Count - 1
                Datarow1 = Table1.NewRow
                For i = 0 To Listview1.Columns.Count - 1
                    Datarow1.Item(IIf(Listview1.Columns(i).Name = "", Listview1.Columns(i).Text.Trim, Listview1.Columns(i).Name)) =
                        Listview1.Items(j).SubItems(i).Text.ToString
                Next i
                Table1.Rows.Add(Datarow1)
            Next j
        End If
        Return Table1
    End Function
    '''这2个过程给DataGridView添加查看明细菜单
    Public Sub GS_mendj2(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) '这个过程配合下面的响应查看明细的点击
        Try
            Dim menu1 As ContextMenuStrip = sender
            Dim kk As DataGridView = sender.SourceControl
            Select Case e.ClickedItem.Text
                Case "查看明细"

                    If kk.SelectedRows.Count > 0 Then
                        Dim k1 As String = ""
                        For i As Integer = 0 To kk.Columns.Count - 1
                            k1 = k1 & kk.Columns(i).HeaderText & "：" & kk.SelectedRows(0).Cells(i).Value & vbCrLf & vbCrLf
                        Next
                        Dim nformmx As New Frshowmx
                        nformmx.TextBox1.Text = k1
                        nformmx.ShowDialog()
                    End If

                Case "打印"
                    Dim tbhtml As String = Frprintweb.GF_DbToPrintWeb(kk)
                    Dim webprint As New Frprintweb
                    Dim webBrowserForPrinting As WebBrowser = webprint.WebBrowser1
                    With webBrowserForPrinting
                        .Document.Write("<html><head><meta http-equiv='Content-Type' content='text/html; charset=gb2312'>" _
& "<title>打印</title></head>" _
& "<body style='margin-top:0px;' >")
                        .Document.Write(tbhtml)
                        .Document.Write("</body></html>")
                    End With


                    webprint.Show()
            End Select


        Catch ex As Exception

        End Try

    End Sub
    Public Sub GS_DataGridViewaddmenu(ByVal DataGridViewName As DataGridView) '颜色更新
   
        With DataGridViewName
            If .SelectedRows.Count > 0 Then
                Dim menu1 As New ContextMenuStrip
                menu1.Items.Add("查看明细")
                AddHandler menu1.ItemClicked, AddressOf GS_mendj2
                .ContextMenuStrip = menu1
            End If
        End With
    End Sub
    '通过DB构造DataGridView,isTanToCn是否翻译为中文字段名,isAddMenu是否增加右键查看明细菜单
    ''' <summary>
    ''' 通过DB构造DataGridView
    ''' </summary>
    ''' <param name="listname">DataGridView名称</param>
    ''' <param name="dbname">数据表对象</param>
    ''' <param name="isTanToCn">是否将列字段翻译成中文描述</param>
    ''' <param name="isAddMenu">是否添加右键餐单</param>
    ''' <param name="pCmenu">右键餐单对象</param>
    Public Sub GS_DataGridViewbyDb(ByVal listname As DataGridView, ByVal dbname As DataTable,
                                   Optional ByVal isTanToCn As Boolean = True,
                                   Optional ByVal isAddMenu As Boolean = True,
                                   Optional ByVal pCmenu As ContextMenuStrip = Nothing)
        If dbname.Columns.Count > 10 Then
            listname.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            listname.RowHeadersWidth = 40
        End If
        listname.Columns.Clear() '避免头部消失
        listname.DataSource = dbname

        Dim menu1 As ContextMenuStrip
        If pCmenu Is Nothing Then
            menu1 = New ContextMenuStrip
            menu1.Items.Add("查看明细")
            AddHandler menu1.ItemClicked, AddressOf GS_mendj2
        Else
            menu1 = pCmenu
        End If
        AddHandler menu1.Paint, Sub(sender As ContextMenuStrip, e As System.EventArgs)
                                    If CType(sender.SourceControl, DataGridView).SelectedRows.Count = 0 Then
                                        sender.Hide()
                                    End If
                                End Sub
        'If listname.RowCount > 0 Then
        listname.ContextMenuStrip = menu1
        'End If

        If isTanToCn = True Then
            GS_TranEtoC(listname) '将DataGridView列字段翻译成为中文描叙
        End If

    End Sub
    '通过DB构造DataGridView，隐藏列,colIndex列索引，多个逗号隔开,isTanToCn是否翻译为中文字段名,isAddMenu是否增加右键查看明细菜单
    Public Sub GS_DataGridViewbyDb(ByVal listname As DataGridView, ByVal dbname As DataTable, ByVal colIndex As String, ByVal isTanToCn As Boolean, ByVal isAddMenu As Boolean)
        If dbname.Columns.Count > 10 Then
            listname.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            listname.RowHeadersWidth = 40
        End If

        listname.Columns.Clear() '避免头部消失
        listname.DataSource = dbname

        If isAddMenu = True Then
            GS_DataGridViewaddmenu(listname) '增加查看明细菜单
        End If
        If isTanToCn = True Then
            GS_TranEtoC(listname) '将DataGridView列字段翻译成为中文描叙
        End If
        DeepCode.DeepDoGridView.HideSomeCol(listname, colIndex) '隐藏列索引
    End Sub
    '通过DB构造DataGridView,isTanToCn是否翻译为中文字段名,isAddMenu是否增加右键查看明细菜单
    Public Sub GS_DataGridViewbyDb2(ByVal listname As DataGridView, ByVal dbname As DataTable, ByVal isTanToCn As Boolean, ByVal isAddMenu As Boolean, ByVal dtzdinf As DataTable)
        If dbname.Columns.Count > 10 Then
            listname.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            listname.RowHeadersWidth = 40
        End If
        listname.Columns.Clear() '避免头部消失
        listname.DataSource = dbname

        If isAddMenu = True Then
            GS_DataGridViewaddmenu(listname) '增加查看明细菜单
        End If
        If isTanToCn = True Then
            GS_TranEtoC(listname, dtzdinf) '将DataGridView列字段翻译成为中文描叙
        End If

    End Sub
    '通过DB构造DataGridView，隐藏列,colIndex列索引，多个逗号隔开,isTanToCn是否翻译为中文字段名,isAddMenu是否增加右键查看明细菜单
    Public Sub GS_DataGridViewbyDb2(ByVal listname As DataGridView, ByVal dbname As DataTable, ByVal colIndex As String, ByVal isTanToCn As Boolean, ByVal isAddMenu As Boolean, ByVal dtzdinf As DataTable)
        If dbname.Columns.Count > 10 Then
            listname.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            listname.RowHeadersWidth = 40
        End If
        listname.Columns.Clear() '避免头部消失
        listname.DataSource = dbname
        If isAddMenu = True Then
            GS_DataGridViewaddmenu(listname) '增加查看明细菜单
        End If
        If isTanToCn = True Then
            GS_TranEtoC(listname, dtzdinf) '将DataGridView列字段翻译成为中文描叙
        End If
        'DeepCode.DeepDoGridView.HideSomeCol(listname, colIndex) '隐藏列索引
    End Sub


    '返回选中行所有选中行中某一列的值 num代表要获取哪一列的值  从0开始
    Public Function GF_GetSelectedValue(ByVal lv As Control, ByVal num As Integer) As String
        GF_GetSelectedValue = ""
        If lv.GetType.ToString = "System.Windows.Forms.ListView" Then
            Dim lt As ListView = lv
            For i As Integer = 0 To lt.SelectedItems.Count - 1
                If i = lt.SelectedItems.Count - 1 Then
                    GF_GetSelectedValue = GF_GetSelectedValue & lt.SelectedItems(i).SubItems(num).Text
                Else
                    GF_GetSelectedValue = GF_GetSelectedValue & lt.SelectedItems(i).SubItems(num).Text & ","
                End If
            Next
        Else
            Dim lt As DataGridView = lv
            For i As Integer = 0 To lt.SelectedRows.Count - 1
                If i = lt.SelectedRows.Count - 1 Then
                    GF_GetSelectedValue = GF_GetSelectedValue & lt.SelectedRows(i).Cells(num).Value
                Else
                    GF_GetSelectedValue = GF_GetSelectedValue & lt.SelectedRows(i).Cells(num).Value & ","
                End If
            Next
        End If

    End Function

    '返回选中行所有选中行中某一列的值 num代表要获取哪一列的值  从0开始
    Public Function GF_CheckedValue(ByVal lv As ListView, ByVal num As Integer) As String
        GF_CheckedValue = ""
        For i As Integer = 0 To lv.CheckedItems.Count - 1
            If i = lv.CheckedItems.Count - 1 Then
                GF_CheckedValue = GF_CheckedValue & lv.CheckedItems(i).SubItems(num).Text
            Else
                GF_CheckedValue = GF_CheckedValue & lv.CheckedItems(i).SubItems(num).Text & ","
            End If
        Next
    End Function

    'Listview转化db，str为指定Listview中要转化列的索引,str为all表示所有，无论如何，列宽为0的不加入
    Public Function GF_ListviewToDatatable2(ByVal Listview1 As ListView, ByVal str As String) As Data.DataTable  'listview转为Datatable函数
        Dim Table1 As New DataTable
        Dim ks As String = "," & str & "," '前后加逗号为了好判断

        Dim i As Integer
        Dim datacol As DataColumn
        For i = 0 To Listview1.Columns.Count - 1
            If Listview1.Columns(i).Width > 0 Then
                If str = "all" Then
                    datacol = New DataColumn
                    datacol.DataType = GetType(String)
                    datacol.ColumnName = Listview1.Columns(i).Text
                    Table1.Columns.Add(datacol)
                Else
                    Dim zd As String = "," & i.ToString & ","
                    If InStr(ks, zd) > 0 Then
                        datacol = New DataColumn
                        datacol.DataType = GetType(String)
                        datacol.ColumnName = Listview1.Columns(i).Text
                        Table1.Columns.Add(datacol)
                    End If
                End If
            End If


        Next

        Dim j As Integer
        Dim Datarow1 As DataRow
        If Listview1.CheckBoxes = True Then
            For j = 0 To Listview1.CheckedItems.Count - 1
                Datarow1 = Table1.NewRow
                For i = 0 To Listview1.Columns.Count - 1
                    If Listview1.Columns(i).Width > 0 Then
                        If str = "all" Then
                            Datarow1.Item(Listview1.Columns(i).Text) = Listview1.CheckedItems(j).SubItems(i).Text.ToString
                        Else
                            Dim zd As String = "," & i.ToString & ","
                            If InStr(ks, zd) > 0 Then
                                Datarow1.Item(Listview1.Columns(i).Text) = Listview1.CheckedItems(j).SubItems(i).Text.ToString
                            End If
                        End If
                    End If
                Next i
                Table1.Rows.Add(Datarow1)
            Next j
        Else
            For j = 0 To Listview1.Items.Count - 1
                Datarow1 = Table1.NewRow
                For i = 0 To Listview1.Columns.Count - 1
                    If Listview1.Columns(i).Width > 0 Then
                        If str = "all" Then
                            Datarow1.Item(Listview1.Columns(i).Text) = Listview1.Items(j).SubItems(i).Text.ToString
                        Else
                            Dim zd As String = "," & i.ToString & ","
                            If InStr(ks, zd) > 0 Then
                                Datarow1.Item(Listview1.Columns(i).Text) = Listview1.Items(j).SubItems(i).Text.ToString
                            End If
                        End If
                    End If


                Next i
                Table1.Rows.Add(Datarow1)
            Next j
        End If

        Return Table1
    End Function
    '回车切换焦点1
    Public Sub GS_qhjd(ByVal str As Form)
        str.Text = str.Text & "-" & str.Name

        With str
            For i As Integer = 0 To .Controls.Count - 1
                If .Controls(i).GetType.Name = "TextBox" Then
                    Dim nn As TextBox = .Controls(i)
                    If nn.Multiline = False Then
                        AddHandler .Controls(i).KeyDown, AddressOf GS_keyDownCheckFocus
                    End If
                Else
                    AddHandler .Controls(i).KeyDown, AddressOf GS_keyDownCheckFocus
                End If
            Next
        End With
    End Sub
    '回车切换焦点2
    Public Sub GS_keyDownCheckFocus(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 13 Then
            SendKeys.Send("{TAB}")
            Exit Sub
        End If
    End Sub
    '验证函数，判断哪些控件不能为空， 参数1窗体名，2例外控件
    Public Function GF_YZSJ(ByVal STR1 As Control, ByVal STR2 As String) As Boolean
        ''''''''''''''''''''''''''''''''''''''''''
        Try
            For j As Integer = 0 To STR1.Controls.Count - 1
                Dim KJM As String = STR1.Controls(j).Name
                If Microsoft.VisualBasic.Left(KJM, 3) = "tb_" And InStr(STR2, KJM) = 0 And STR1.Controls(j).Visible = True Then
                    If STR1.Controls(j).Text.Trim = "" Then
                        MsgBox("请将数据填写完整！")
                        STR1.Controls(j).Focus()
                        GF_YZSJ = False : Exit Function
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

        GF_YZSJ = True
    End Function
    '验证函数，判断哪些控件不能为空， 参数1窗体名，2例外控件
    Public Function GF_YZSJ2(ByVal STR1 As Form, ByVal STR2 As String) As Boolean
        Dim objTm As Object = Nothing
        Try
            For j As Integer = 0 To STR1.Controls.Count - 1
                Dim KJM As String = STR1.Controls(j).Name
                If Microsoft.VisualBasic.Left(KJM, 3) = "tb_" And InStr(STR2, KJM) = 0 And STR1.Controls(j).Visible = True Then
                    If STR1.Controls(j).Text.Trim = "" Then
                        objTm = STR1.Controls(j)
                        Exit For
                    End If
                End If
            Next
            If objTm IsNot Nothing Then
                If MsgBox("数据没有完整填写，是否继续！", MsgBoxStyle.YesNo) = vbNo Then
                    objTm.Focus()
                    Return False
                End If
            End If
        Catch ex As Exception

        End Try

        Return True
    End Function
    '验证函数，判断哪些控件不能为空， 参数1窗体名，2控件
    Public Function GF_YZSJ3(ByVal STR1 As Control, ByVal STR2 As String) As Boolean
        Dim objTm As Object = Nothing
        Dim arrControl As String() = STR2.Split(",")

        For Each s As String In arrControl
            Dim tCol As Control = STR1.YanFindControl(s)
            If tCol IsNot Nothing Then
                If tCol.Text = "" Then
                    MsgBox("输入项没有完整填写！", MsgBoxStyle.Exclamation)
                    tCol.Focus()
                     Return False
                End If
            End If
        Next
        Return True
    End Function
    ''' <summary>
    ''' 验证输入项不能为空
    ''' </summary>
    Public Function CheckControlNull(ByVal pControl As Control) As Boolean
        Try
            For j As Integer = 0 To pControl.Controls.Count - 1
                Dim KJM As String = pControl.Controls(j).Name
                If pControl.Controls(j).BackColor = Color.Wheat Then
                    If pControl.Controls(j).Text.Trim = "" Then
                        MsgBox("输入项没有完整填写！", MsgBoxStyle.Exclamation)
                        pControl.Controls(j).Focus()
                        Return False
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

        Return True
    End Function
    ''' <summary>
    ''' 验证是否存在相同批号
    ''' </summary>
    ''' <param name="pPh">批号</param>
    ''' <param name="pDm">代码</param>
    Public Function CheckPhExists(pPh As String, pDm As String) As Boolean
        Return _D.isRowNull("tb_wlph", "tb_wlph_wlph='" & pPh & "' and tb_wlph_wpdm='" & pDm & "'")
    End Function
    '对根据列标题返回列索引,-1表示没有匹配项目
    Public Function GF_GetListIndexByText(ByVal lsit1 As Control, ByVal bt As String) As Integer

        If lsit1.GetType.ToString = "System.Windows.Forms.ListView" Then
            Dim cc As Windows.Forms.ListView = lsit1
            For i As Integer = 0 To cc.Columns.Count - 1
                If cc.Columns(i).Text = bt Then
                    Return i
                End If
            Next
        Else
            Dim cc As System.Windows.Forms.DataGridView = lsit1
            For i As Integer = 0 To cc.Columns.Count - 1
                If cc.Columns(i).Name = bt Then
                    Return i
                End If
            Next
        End If

        Return -1
    End Function
    '使某些控件可见或不可见str表示控件名，逗号隔开，str3表示容器控件
    Public Sub GS_tofalse(ByVal str As String, ByVal str2 As Boolean, ByVal STR3 As Control)
        Dim KZJ() As String = str.Split(",")
        With STR3
            For I As Integer = 0 To UBound(KZJ)
                .Controls(KZJ(I)).Visible = str2
            Next
        End With
    End Sub
    '使某些控件有效或无效str表示控件名，逗号隔开，str3表示容器控件
    Public Sub GS_toenable(ByVal str As String, ByVal str2 As Boolean, ByVal STR3 As Control)
        Dim KZJ() As String = str.Split(",")
        With STR3
            For I As Integer = 0 To UBound(KZJ)
                .Controls(KZJ(I)).Enabled = str2
            Next
        End With
    End Sub
    '闭窗体警告
    Public Sub GS_Close3(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If My.Application.OpenForms.Count = 1 Then
            If MsgBox("您确定退出吗？", 1, "警告") = 1 Then
                Call GS_upztxx(G_cnnstr, "delete from tb_inline where tb_inline_gh='" & G_dlrgh & "'") '清除在线记录
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    '将DataGridView列字段翻译成为中文描叙
    Public Sub GS_TranEtoC(ByVal dv As DataGridView)

        For i As Integer = 0 To dv.Columns.Count - 1
            Try
                Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dv.Columns(i).Name & "'", 4)
                zwmz = Replace(zwmz, vbCrLf, "")
                If zwmz <> "" Then
                    dv.Columns(i).Name = dv.Columns(i).Name
                    dv.Columns(i).HeaderText = zwmz
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub
    '指定字段索引库的翻译，这是为了跨库显示正确字段
    Public Sub GS_TranEtoC(ByVal dv As DataGridView, ByVal dtzdinf As DataTable)
        For i As Integer = 0 To dv.Columns.Count - 1
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(dtzdinf, "tb_biaozdinf_mc='" & dv.Columns(i).Name & "'", 4)
            zwmz = Replace(zwmz, vbCrLf, "")
            If zwmz <> "" Then
                dv.Columns(i).Name = dv.Columns(i).Name
                dv.Columns(i).HeaderText = zwmz
            End If

        Next
    End Sub
    '将Datatable列字段翻译成为中文描叙
    Public Function GF_TranEtoC2(ByVal dv As DataTable) As DataTable
        Dim ndb As DataTable = dv
        For i As Integer = 0 To ndb.Columns.Count - 1
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & ndb.Columns(i).Caption & "'", 4)
            zwmz = Replace(zwmz, vbCrLf, "")
            ndb.Columns(i).Caption = zwmz
        Next
        Return ndb
    End Function
    '将Datatable列字段翻译成为中文描叙
    Public Function GF_TranEtoC2(ByVal dv As DataTable, ByVal dtzdinf As DataTable) As DataTable
        Dim ndb As DataTable = dv
        For i As Integer = 0 To ndb.Columns.Count - 1
            Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(dtzdinf, "tb_biaozdinf_mc='" & ndb.Columns(i).Caption & "'", 4)
            zwmz = Replace(zwmz, vbCrLf, "")
            ndb.Columns(i).Caption = zwmz
        Next
        Return ndb
    End Function
    '给datatable数字列自动求和，并将合计附加到最后一行
    Public Sub GS_DbSum(ByVal dv As DataTable)
        With dv
            If .Rows.Count = 0 Then
                Return
            End If
            Dim kk As String = ""
            For i As Integer = 0 To .Columns.Count - 1
                Select Case .Columns(i).DataType.ToString
                    Case "System.Decimal", "System.Short", "System.Integer", "System.Int32", "System.Long"
                        kk &= i.ToString & ","
                End Select
            Next
            If kk = "" Then
                Return
            End If
            Dim ws As Integer = .Columns.Count - 1
            Dim k(ws) As String
            .Rows.Add(k) '先附加一行，这时数据全部是空的
            '‘’‘下面填充最后一行的数据
            Dim m() As String = kk.Split(",")
            For i As Integer = 0 To m.Length - 2 '排除最后一个逗号
                Dim n As Integer = m(i) '得到求和的列索引
                Dim mz As String = .Columns(n).ColumnName
                If Microsoft.VisualBasic.Right(mz, 4) <> "_tjq" Then '因为统计期是数子字段，且很大，不参与求和
                    '求和
                    Dim zs As Double = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dv, n, 0, .Rows.Count - 2) '注意这里是减2，因为附加了一行
                    .Rows(.Rows.Count - 1)(n) = zs '求和赋值
                End If
            Next
        End With

    End Sub

    ''' <summary>
    ''' 返回ListView某行的值
    ''' </summary>
    ''' <param name="lsit1">listView对象</param>
    ''' <param name="FieldName">数据库字段名</param>
    ''' <param name="ItemIndex">行索引</param>
    ''' <param name="Model">0表示无CheckBox模式，为1表示有CheckBox模式，为2表示有select模式</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GF_GetListText(ByVal lsit1 As ListView, ByVal FieldName As String, Optional ByVal ItemIndex As Integer = 0, Optional ByVal Model As Integer = 2)
        With lsit1
            Dim sy As Integer = GF_GetListIndexByTag(lsit1, FieldName)
            If Model = 0 Then
                Return Cl_StrMag.YanNullToEmpty(.Items(ItemIndex).SubItems(sy).Text)
            ElseIf Model = 1 Then
                If .CheckedItems.Count = 0 Then
                    Return ""
                End If
                Return Cl_StrMag.YanNullToEmpty(.CheckedItems(ItemIndex).SubItems(sy).Text)
            ElseIf Model = 2 Then
                Return Cl_StrMag.YanNullToEmpty(.SelectedItems(ItemIndex).SubItems(sy).Text)
            End If
        End With
        Return ""
    End Function


    '对根据列Tag返回列索引,-1表示没有匹配项目,一般是使用真正字段查找列索引
    Public Function GF_GetListIndexByTag(ByVal lsit1 As ListView, ByVal FieldName As String) As Integer
        Dim cc As Windows.Forms.ListView = lsit1
        For i As Integer = 0 To cc.Columns.Count - 1
            If cc.Columns(i).Tag.ToLower = FieldName.ToLower Then
                Return i
            End If
        Next
        Return -1
    End Function
    Public Function GF_GetGridIndexByTag(ByVal lsit1 As DataGridView, ByVal FieldName As String) As Integer
        Dim cc As Windows.Forms.DataGridView = lsit1
        For i As Integer = 0 To cc.Columns.Count - 1
            If cc.Columns(i).Tag = FieldName Then
                Return i
            End If
        Next
        Return -1
    End Function
    ''返回ListView某行的值，FieldName数据库字段名，ItemIndex行索引，Model为0表示无CheckBox模式，为1表示有CheckBox模式，为2表示有select模式
    'Public Function GF_GetListText(ByVal lsit1 As ListView, ByVal FieldName As String, ByVal ItemIndex As Integer, ByVal Model As Integer)
    '    With lsit1
    '        Dim sy As Integer = GF_GetListIndexByTag(lsit1, FieldName)
    '        If Model = 0 Then
    '            Return .Items(ItemIndex).SubItems(sy).Text
    '        ElseIf Model = 1 Then
    '            Return .CheckedItems(ItemIndex).SubItems(sy).Text
    '        ElseIf Model = 2 Then
    '            Return .SelectedItems(ItemIndex).SubItems(sy).Text
    '        End If
    '    End With
    'End Function

    '打开一个界面
    Public Sub GS_dkxck(ByVal FormName As String)
        '必须是 命名空间+点+窗体类名 
        Dim ctclass As String = My.Application.Info.AssemblyName & "." & FormName
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(ctclass), Form)
        If frm2 Is Nothing Then
            Return
        End If
        frm2.Show()
    End Sub
    '打开一个界面
    Public Function GF_OpenFaceList(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean

        If sender.tag = "切换至湖北" Then
            Dim fileExists1 As Boolean
            fileExists1 = My.Computer.FileSystem.FileExists("c:\hbcabioexe.ini")
            If fileExists1 = False Then
                MsgBox("没有初始化湖北路径,请先手动登入湖北系统")
                Exit Function
            End If
            If MsgBox("是否切换至湖北?", 1, "提示") = 1 Then
                Call DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, "delete from tb_inline where tb_inline_gh='" & G_dlrgh & "'") '清除在线记录
                Dim lnk As String = GF_readwrite("c:\hbcabioexe.ini", "READ")
                GF_readwrite(lnk & "\Herson.ini", G_dlrgh & vbCrLf & G_dlrmm)
                System.Diagnostics.Process.Start(lnk & "\HBCabioMis.exe")
                System.Environment.Exit(System.Environment.ExitCode)
            End If
        End If
        Dim nform As String = sender.tag
        GS_dkxck(nform)

        '’把先前的界面关闭
        Dim m2 As ToolStripMenuItem = sender
        Dim m As Form = m2.OwnerItem.Owner.FindForm
        m.Close()
    End Function
    Public Function GF_OpenFaceList2(ByVal ToolStripName As ToolStrip) As Boolean
#If DEBUG Then
        Try
            Dim form As Form = CType(ToolStripName.Parent, Form)
            form.Text = form.Text & "-" & form.Name

        Catch ex As Exception

        End Try
#End If
        Dim m As New ToolStripDropDownButton
        With m
            .Image = frwjmenu.ToolStripButton6.Image
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            .Text = "切换"
            Dim q As ToolStripDropDownItem = .DropDownItems.Add("油剂部") : q.Tag = "Frshow_list"
            q = .DropDownItems.Add("粉剂部") : q.Tag = "Frfenji_list"
            q = .DropDownItems.Add("技术部") : q.Tag = "Frjsb_list"
            q = .DropDownItems.Add("QA") : q.Tag = "Frqalist"
            q = .DropDownItems.Add("QC") : q.Tag = "Frqc_list"
            q = .DropDownItems.Add("EHS") : q.Tag = "Frsbdllist"
            q = .DropDownItems.Add("设备动力部") : q.Tag = "Frehslist"
            q = .DropDownItems.Add("运行部") : q.Tag = "Fryllist"
            q = .DropDownItems.Add("采购部") : q.Tag = "Frcgrzlist"
            q = .DropDownItems.Add("人力资源部") : q.Tag = "Frrlzy"
            q = .DropDownItems.Add("报表") : q.Tag = "frtjmenuNEW"
            q = .DropDownItems.Add("全局") : q.Tag = "Frqjface"
            q = .DropDownItems.Add("系统管理") : q.Tag = "Fradminlist"
            q = .DropDownItems.Add("产品加工") : q.Tag = "Frcpdmhz"
            q = .DropDownItems.Add("BC") : q.Tag = "FrbcList"
            q = .DropDownItems.Add("切换至湖北") : q.Tag = "切换至湖北"
            For i As Integer = 0 To .DropDownItems.Count - 1
                AddHandler .DropDownItems(i).Click, AddressOf GF_OpenFaceList
            Next
        End With

        ToolStripName.Items.Add(m)
        Dim m2 As New ToolStripButton
        With m2
            .Image = frwjmenu.ToolStripDropDownButton2.Image
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            .Text = "关闭"
            AddHandler m2.Click, AddressOf GS_CLOSECHANGE
        End With
        ToolStripName.Items.Add(m2)
    End Function
    '关闭按钮的事件
    Public Sub GS_CLOSECHANGE(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m2 As ToolStripButton = sender
        Dim m As Form = m2.Owner.FindForm
        m.Close()
    End Sub
    '根据数组为一个ComboBox构建下拉，，str1是DB的字段序列，没有默认值
    Public Sub GS_wlbktlr4(ByVal ComboBoxName As Windows.Forms.ComboBox, ByVal ArrayStr() As String)
        ComboBoxName.Items.Clear()
        If ArrayStr.Length = 0 Then
            Return
        End If
        For i As Integer = 0 To UBound(ArrayStr)
            ComboBoxName.Items.Add(ArrayStr(i))
        Next
    End Sub

    Public Sub GS_bcfbd(ByVal dt As DataTable, ByVal column As Integer, ByVal ComboBoxName As Windows.Forms.ComboBox)
        Dim arrylist() As String = New String() {""}
        If dt.Rows.Count = 0 Then
            GS_wlbktlr4(ComboBoxName, arrylist)
            Exit Sub
        End If
        Dim sz As String = dt.Rows(0)(column)
        If dt.Rows.Count = 1 Then
            arrylist = New String() {sz}
            GS_wlbktlr4(ComboBoxName, arrylist)
            Exit Sub
        End If
        sz &= ","
        For i As Integer = 0 To dt.Rows.Count - 1
            If InStr("," & sz, "," & dt.Rows(i)(column) & ",") = 0 Then
                sz &= dt.Rows(i)(column) & ","
            End If
        Next

        arrylist = GF_removedh(sz).Split(",")
        GS_wlbktlr4(ComboBoxName, arrylist)
    End Sub
    '控件TAB顺序
    Public Function G_S_TURNTAB(ByVal controlparent As Control, ByVal tabstart As Integer) As Integer
        Try
            Dim dt1 As New DataTable
            With dt1
                .Columns.Add("handle", GetType(String))
                .Columns.Add("controlleft", GetType(Integer))
                .Columns.Add("controltop", GetType(Integer))
            End With
            Dim r As DataRow
            With controlparent
                For i As Integer = 0 To .Controls.Count - 1
                    r = dt1.NewRow
                    r(0) = .Controls(i).Name
                    r(1) = .Controls(i).Left
                    r(2) = .Controls(i).Top
                    dt1.Rows.Add(r)
                Next
                Dim rows() As DataRow = dt1.Select("", "controltop ASC,controlleft ASC")
                For i As Integer = 0 To rows.Length - 1
                    Dim m As Control = CType(.Controls(rows(i)(0)), Control)
                    m.TabIndex = i + 1
                    'Debug.WriteLine(rows(i)(0) & ":" & i + 1)
                Next
            End With
            Return controlparent.Controls.Count
        Catch ex As Exception
            Return 0
        End Try

    End Function
End Module
