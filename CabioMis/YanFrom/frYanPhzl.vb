Public Class frYanPhzl
    Delegate Function callbackFrok(ByVal outArgs As DataTable, ByVal outFrobj As frYanPhzl) As Object    '委托声明
    Delegate Function callbackCliciRight(ByVal outArgs As frYanPhzl) As Object    '委托声明
    ''' <summary>
    ''' 提供给窗体调用的参数类
    ''' </summary>
    Public Class CLphzlPam
        ''' <summary>
        ''' 显示列表的数据源
        ''' </summary>
        Public souserDt As DataTable = Nothing
        ''' <summary>
        ''' 该操作的标识(返回表的名称)
        ''' </summary>
        Public bs As String = ""
        ''' <summary>
        ''' 标题
        ''' </summary>
        Public titleText As String = "提取操作"
        ''' <summary>
        ''' 点击确定后执行的函数
        ''' </summary>
        Public callbackFn As callbackFrok = Nothing
        ''' <summary>
        ''' 全部列
        ''' </summary>
        Public colItem As String = ""
        ''' <summary>
        ''' 隐藏的列
        ''' </summary>
        Public colHide As String = ""
        ''' <summary>
        ''' 批号控件的名称
        ''' </summary>
        Public phName As String = ""
        ''' <summary>
        ''' 标识控件的名称
        ''' </summary>
        Public bsName As String = ""
        ''' <summary>
        '''重量控件的名称 
        ''' </summary>
        ''' <remarks></remarks>
        Public zlName As String = ""
        ''' <summary>
        ''' 列表的批号数字位
        ''' </summary>
        Public numPh As Integer = 1
        ''' <summary>
        ''' 列表的重量数字位
        ''' </summary>
        Public numZl As Integer = 2
        ''' <summary>
        ''' 列表的标识数字位
        ''' </summary>
        Public numBs As Integer = 5
        ''' <summary>
        ''' 是否显示前面批次未完的警告
        ''' </summary>
        Public isShowW As Boolean = False
        ''' <summary>
        ''' 是否允许编辑提取数字
        ''' </summary>
        Public isLabelEdit As Boolean = True
        ''' <summary>
        ''' 右键功能
        ''' </summary>
        Public callbackRckFn As callbackCliciRight = Nothing
        ''' <summary>
        ''' 是否启用双击功能
        ''' </summary>
        Public isDoubleClick As Boolean = True
    End Class
    ''' <summary>
    ''' 调用此窗体必须的类
    ''' </summary>
    Public m_PhzlPam As CLphzlPam
#Region "供返回调用的变量"
    ''' <summary>
    ''' 总计提取重量
    ''' </summary>
    Public m_countNum As Double = 0
    ''' <summary>
    ''' 提取的批号序列
    ''' </summary>
    Public m_rvPh As String = ""
    ''' <summary>
    ''' 提取的重量序列
    ''' </summary>
    Public m_rvZl As String = ""
    ''' <summary>
    ''' 提取的ID序列
    ''' </summary>
    Public m_rvBs As String = ""
#End Region
    Sub New(pClpam As CLphzlPam)
        InitializeComponent()

        Me.m_PhzlPam = pClpam

        ListView1.Clear()
        Me.Text = m_PhzlPam.titleText
        ListView1.Visible = True
        ListView1.CausesValidation = False
        ListView1.View = View.Details
        ListView1.LabelEdit = m_PhzlPam.isLabelEdit
        'ListView1.Scrollable = True
        'ListView1.BeginUpdate()

        Dim arrItem As String()
        If m_PhzlPam.colItem = "" Then
            arrItem = New String(m_PhzlPam.souserDt.Columns.Count - 1) {}
            For i As Integer = 0 To m_PhzlPam.souserDt.Columns.Count - 1
                arrItem(i) = _D.getZdtext(m_PhzlPam.souserDt.Columns(i).ColumnName, 1)
            Next
        Else
            arrItem = m_PhzlPam.colItem.Split(",")
        End If
        Dim arrHide As String() = m_PhzlPam.colHide.Split(",")
        '显示的项目
        For i As Integer = 0 To arrItem.Length - 1
            Dim ttW As Integer = CType(ListView1.Width / IIf(m_PhzlPam.colHide <> "", arrItem.Length - arrHide.Length, arrItem.Length), Integer) - 10
            ttW = IIf(ttW < 100, 100, ttW)
            Dim iW As Integer = ttW
            If i = 0 Then
                iW -= 4
            End If
            ListView1.Columns.Add(arrItem(i), iW, HorizontalAlignment.Center)
            ListView1.Columns(i).Name = m_PhzlPam.souserDt.Columns(i).ColumnName
        Next
        '设置隐藏列宽度为0
        If m_PhzlPam.colHide <> "" Then
            For i As Integer = 0 To arrHide.Length - 1
                ListView1.Columns(arrHide(i)).Width = 0
            Next
        End If

        For i As Integer = 0 To m_PhzlPam.souserDt.Rows.Count - 1
            For j As Integer = 0 To arrItem.Length - 1
                If j = 0 Then
                    ListView1.Items.Add(m_PhzlPam.souserDt.Rows(i)(arrItem(j)))
                    '名字等于数据库对应的字段名
                    ListView1.Items(0).SubItems(0).Name = m_PhzlPam.souserDt.Columns(j).ColumnName
                Else
                    Dim tItemSub As New ListViewItem.ListViewSubItem
                    tItemSub.Name = m_PhzlPam.souserDt.Columns(j).ColumnName
                    tItemSub.Text = m_PhzlPam.souserDt.Rows(i)(j)
                    ListView1.Items(i).SubItems.Add(tItemSub)
                End If
            Next
        Next
        'ListView1.EndUpdate()
        If m_PhzlPam.isDoubleClick = False Then
            Label1.Text = ""
        End If
        If m_PhzlPam.isLabelEdit = False Then
            Label1.Text &= ",右键单击选择项编辑提取数量"
        End If
    End Sub

    Private Sub Frphzl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(1, 18)
        ListView1.SmallImageList = imgList

        '为提取数量赋值
        If m_PhzlPam.phName <> "" Then
            If m_PhzlPam.zlName = "" Then
                m_PhzlPam.zlName = m_PhzlPam.phName & "t"
            End If

            Dim objPh As Control = Me.Owner.YanFindControl(m_PhzlPam.phName)
            Dim objZl As Control = Me.Owner.YanFindControl(m_PhzlPam.zlName)
            If objPh Is Nothing OrElse objZl Is Nothing OrElse objZl.Text = "" OrElse objPh.Text = "" Then
                Return
            End If
            Dim arrPh As String() = objPh.Text.Split(",")
            Dim arrZl As String() = objZl.Text.Split(",")

            For i As Integer = 0 To ListView1.Items.Count - 1
                For j As Integer = 0 To arrPh.Length - 1
                    '如果找到有这个批号，那么设置提取重量为对应的重量
                    If ListView1.Items(i).SubItems(m_PhzlPam.numPh).Text = arrPh(j) Then
                        ListView1.Items(i).SubItems(0).Text = arrZl(j)
                    End If
                Next
            Next
        End If
        '为提取数量赋值
        If m_PhzlPam.bsName <> "" Then
            If m_PhzlPam.zlName = "" Then
                m_PhzlPam.zlName = m_PhzlPam.bsName & "t"
            End If

            Dim objbs As Control = Me.Owner.YanFindControl(m_PhzlPam.bsName)
            Dim objZl As Control = Me.Owner.YanFindControl(m_PhzlPam.zlName)
            If objbs Is Nothing OrElse objZl Is Nothing OrElse objZl.Text = "" OrElse objbs.Text = "" Then
                Return
            End If
            Dim arrBs As String() = objbs.Text.Split(",")
            Dim arrZl As String() = objZl.Text.Split(",")

            For i As Integer = 0 To ListView1.Items.Count - 1
                For j As Integer = 0 To arrBs.Length - 1
                    '如果找到有这个批号，那么设置提取重量为对应的重量
                    If ListView1.Items(i).SubItems(m_PhzlPam.numBs).Text = arrBs(j) Then
                        ListView1.Items(i).SubItems(0).Text = arrZl(j)
                    End If
                Next
            Next
        End If
        setCountNum()
    End Sub
    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        If e.Label = Nothing Then
            Exit Sub
        End If
        Dim zl As String = e.Label.ToString
        If IsNumeric(zl) = False Then
            MsgBox("提取数量应该填写数字！")
            e.CancelEdit = True
            Exit Sub
        End If
        If CDbl(zl) < 0 Then
            MsgBox("提取数量应该填写大于等于0的数字！")
            e.CancelEdit = True
            Exit Sub
        End If
        Dim zsl As Double = CDbl(ListView1.Items(e.Item).SubItems(m_PhzlPam.numZl).Text)
        If CDbl(zl) > zsl Then
            MsgBox("提取重量不能大于本身重量" & zsl & "Kg。")
            e.CancelEdit = True
            Exit Sub
        End If

        If m_PhzlPam.isShowW Then
            For i As Integer = 0 To e.Item - 1
                If CDbl(ListView1.Items(e.Item).SubItems(m_PhzlPam.numZl).Text) > CDbl(ListView1.Items(e.Item).SubItems(0).Text) Then
                    If MsgBox("前一批次尚未提取完，确定提取当前批次？", MsgBoxStyle.OkCancel, "提示") <> 1 Then
                        e.CancelEdit = True
                        Exit Sub
                    End If
                    Exit For
                End If
            Next
        End If
        setCountNum(e.Label.ToString, e.Item)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = ListviewToDatatable(ListView1)
        Dim ph As String = ""
        Dim zl As String = ""
        Dim tStrBs As String = ""
        For Each col As DataColumn In dt.Columns
            If Strings.Left(col.ColumnName, 3) = "tb_" And Strings.Right(col.ColumnName, 3) = "_ID" Then
                tStrBs = col.ColumnName
                Exit For
            End If
        Next
        For i As Integer = 0 To dt.Rows.Count - 1
            If CDbl(dt.Rows(i)(0)) > 0 Then
                ph &= dt.Rows(i)(m_PhzlPam.numPh) & ","
                zl &= dt.Rows(i)(0) & ","
                If tStrBs <> "" Then
                    m_rvBs &= dt.Rows(i)(tStrBs) & ","
                End If
            End If
        Next
        m_rvPh = ph.YanRemovedh()
        m_rvZl = zl.YanRemovedh()
        m_rvBs=m_rvBs.YanRemovedh()
        '默认处理程序，将值写入调用该过程的控件，已经对应的重量控件
        If m_PhzlPam.callbackFn Is Nothing Then
            setOwnerVa()
        Else
            '返回调用该过程的表和窗体，表的名字就是传进来的标识
            dt.TableName = CStr(m_PhzlPam.bs)
            m_PhzlPam.callbackFn.Invoke(dt, Me)
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 默认对父窗体的操作
    ''' </summary>
    Public Sub setOwnerVa()
        Try
            If m_PhzlPam.phName <> "" Then
                Me.Owner.YanFindControl(m_PhzlPam.phName).Text = m_rvPh
            End If
            If m_PhzlPam.bsName <> "" Then
                Me.Owner.YanFindControl(m_PhzlPam.bsName).Text = m_rvBs
            End If
            Me.Owner.YanFindControl(m_PhzlPam.zlName).Text = m_rvZl
        Catch
        End Try
    End Sub
    '双击变成最大值，再次双击变成0
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If m_PhzlPam.isDoubleClick = False Then
            Return
        End If
        If ListView1.SelectedItems(0).SubItems(0).Text = ListView1.SelectedItems(0).SubItems(m_PhzlPam.numZl).Text Then
            ListView1.SelectedItems(0).SubItems(0).Text = 0
        Else
            ListView1.SelectedItems(0).SubItems(0).Text = ListView1.SelectedItems(0).SubItems(m_PhzlPam.numZl).Text
        End If
        setCountNum()
    End Sub
    '右键事件
    Private Sub ListView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        If e.Button <> MouseButtons.Right Then
            Return
        End If
        If m_PhzlPam.callbackRckFn IsNot Nothing Then
            m_PhzlPam.callbackRckFn.Invoke(Me)
        End If
    End Sub
    '设置总计值
    Public Sub setCountNum(Optional pEditZl As Double = 0, Optional pItem As Integer = -1)
        Dim douNum As Double = 0
        For Each tItem As ListViewItem In ListView1.Items
            If tItem.Index <> pItem Then
                douNum += CDbl(tItem.SubItems(0).Text)
            End If
        Next
        m_countNum = douNum + pEditZl
        Label3.Text = m_countNum
    End Sub
End Class