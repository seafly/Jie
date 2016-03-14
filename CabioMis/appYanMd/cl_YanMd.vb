''' <summary>
''' 条件表达式
''' </summary>
Public Class cl_getWhere
    Public Shared 有效物料 As String = " tb_i259b_p518h>0 and tb_i259b_qaspjg='合格'  and tb_i259b_yxx='有效'"
End Class

Public Class myDataCl
    Public m_Ds As New DataSet

    ''' <summary>
    ''' 获取或设置窗体使用的dataset
    ''' </summary>
    Public Property sorTable() As DataSet
        Set(ByVal value As DataSet)
            m_Ds = value
        End Set
        Get
            Return m_Ds
        End Get
    End Property

    ''' <summary>
    ''' 将数据库的表结构转换为TB
    ''' </summary>
    ''' <param name="pStrTb">表名</param>
    '''<param name="pIntId">主键，如果这个值不为空那么生成的表将从数据库中读取一条相应的记录</param> 
    ''' <remarks></remarks>
    Public Sub setDataTb(ByVal pStrTb As String, Optional ByVal pIntId As Integer = 0)
        If pIntId <> 0 Then
            Dim sql As String = "select * from " & pStrTb & " where " & pStrTb & "_ID =" & pIntId
            Dim dt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
            Dim copyDt As DataTable = dt.Copy
            copyDt.TableName = pStrTb
            If m_Ds.Tables(pStrTb) IsNot Nothing Then
                m_Ds.Tables.Remove(pStrTb)
            End If
            m_Ds.Tables.Add(copyDt)
            Return
        End If
        greatDataTb(pStrTb)
    End Sub

    ''' <summary>
    ''' 将容器内的数据填充进DT
    ''' </summary>
    ''' <param name="pStrTb">表名</param>
    '''<param name="pLv">listView容器</param> 
    ''' <param name="pRowIndex">行号</param> 
    ''' <remarks></remarks>
    Public Sub setDataTb(ByVal pStrTb As String, ByVal pLv As ListView, Optional ByVal pRowIndex As Integer = 0)
        greatDataTb(pStrTb)
    End Sub

    '创建一个TB
    Private Sub greatDataTb(ByVal pStrTb As String)
        '获取该表的所有字段
        Dim sql As String = "select * from tb_biaozdinf where tb_biaozdinf_biao='" & pStrTb & "'"
        Dim dt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
        Dim tDt As New DataTable
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim objCol As New DataColumn
            objCol.ColumnName = dt.Rows(i)("tb_biaozdinf_mc")
            objCol.DataType = GetType(String)
            tDt.Columns.Add(objCol)
        Next
        '添加一条空记录
        Dim tRow As DataRow = tDt.NewRow
        tRow(pStrTb & "_id") = 0
        tDt.Rows.Add(tRow)

        tDt.TableName = pStrTb
        If m_Ds.Tables(pStrTb) IsNot Nothing Then
            m_Ds.Tables.Remove(pStrTb)
        End If
        m_Ds.Tables.Add(tDt)
    End Sub
End Class

Public Class cl_YanMd
    ''' <summary>
    ''' 右键餐单查看明细
    ''' </summary>
    Public Shared Sub showCkxq(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim xa As ToolStripMenuItem = sender
        '获取该对象的父容器
        Dim mu As ContextMenuStrip = xa.GetCurrentParent
        '获取绑定的容器的类型
        Dim objType As Type = mu.SourceControl.GetType

        Select Case objType.Name
            Case "DataGridView", "yanDaTaGridView"
                If CType(mu.SourceControl, DataGridView).SelectedRows.Count > 0 Then
                    Dim k1 As String = ""
                    For i As Integer = 0 To CType(mu.SourceControl, DataGridView).Columns.Count - 1
                        k1 = k1 & CType(mu.SourceControl, DataGridView).Columns(i).HeaderText & "：" & CType(mu.SourceControl, DataGridView).SelectedRows(0).Cells(i).Value & vbCrLf & vbCrLf
                    Next
                    Dim nformmx As New Frshowmx
                    nformmx.TextBox1.Text = k1
                    nformmx.ShowDialog()
                End If
            Case "ListView"
                If CType(mu.SourceControl, ListView).SelectedItems.Count > 0 Then
                    Dim k1 As String = ""
                    For i As Integer = 0 To CType(mu.SourceControl, ListView).Columns.Count - 1
                        k1 = k1 & CType(mu.SourceControl, ListView).Columns(i).Tag & "：" & CType(mu.SourceControl, ListView).SelectedItems(0).SubItems(i).Text & vbCrLf & vbCrLf
                    Next
                    Dim nformmx As New Frshowmx
                    nformmx.TextBox1.Text = k1
                    nformmx.ShowDialog()
                End If
            Case Else
        End Select
    End Sub

    ''' <summary>
    ''' 获取DHAQC的历史记录
    ''' </summary>
    ''' <param name="pStrWlbs"></param>
    Public Shared Function getQcLsjl(ByVal pStrWlbs As String) As DataTable
        Dim Sql As String = "select tb_QcJc_ID,tb_QcJc_ftime,tb_QcJc_sfsh,tb_QcJc_wlbs,tb_i259b_c24u " & _
        "from tb_QcJc as a left join tb_i259b as b on a.tb_QcJc_wlbs=b.tb_i259b_id  " & _
        "where tb_QcJc_wlbs=" & pStrWlbs
        Dim dt As DataTable = Cl_DataMag.GF_CreateDataSource(Sql)
        'setQcshowView(dt)

        Sql = "select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_wldm =(select top 1 tb_i259b_i231a from tb_i259b where " & _
            "tb_i259b_ID=" & pStrWlbs & ")"
        Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource(Sql)
        For Each dr As DataRow In tBqcxm.Rows
            dt.Columns.Add(dr("tb_QcXm_xmmc").trim)
        Next

        For Each dr As DataRow In dt.Rows  '将结果作为列添加进去
            Sql = "select  * from tb_QcVa where tb_QcVa_Qcbs=" & dr("tb_QcJc_ID")
            'sql = "select * from tb_QcVa where tb_QcVa_Qcbs=" & dr("tb_QcJc_ID")
            Dim tDt As DataTable = Cl_DataMag.GF_CreateDataSource(Sql)
            For Each tDr As DataRow In tDt.Rows
                Try
                    dr(tDr("tb_QcVa_xmmc").trim) = tDr("tb_QcVa_xmva")
                Catch ex As Exception

                End Try

            Next
        Next

        Return dt
    End Function

    ''' <summary>
    ''' 根据名字获取控件
    ''' </summary>
    ''' <param name="myform">控件所在窗体</param>
    ''' <param name="myname">控件名</param>
    Public Shared Function findcontrolinform(ByVal myform As Form, ByVal myname As String)
        '返回myform窗体的控件名字为myname的控件，最多只能有两层容器，比如groupbox容器之内就不能再包含groupbox容器
        Dim mycontrol As Control

        Dim mycontrol2 As Control

        myform.Text = myform.Controls.Count '本窗体控件的个数
        For Each mycontrol In myform.Controls '遍历所有控件
            If (mycontrol.Name = myname) Then

                Return mycontrol

            ElseIf (mycontrol.Name <> myname And mycontrol.Controls.Count > 0) Then '如果该控件容纳其它控件，也就是像groupbox之类的容器
                For Each mycontrol2 In mycontrol.Controls '对容器的控件进行遍历
                    If (mycontrol2.Name = myname) Then

                        Return mycontrol2

                    End If

                Next mycontrol2

            End If

        Next mycontrol

        Return Nothing
    End Function

    ''' <summary>
    '''判断数据库中有否符合条件的记录
    ''' </summary>
    ''' <param name="pStrTable">数据库表名</param>
    ''' <param name="pStrWh">查询条件</param>
    ''' <returns>返回查询结果</returns>
    Public Shared Function isRowNull(ByVal pStrTable As String, Optional ByVal pStrWh As String = "") As Boolean
        Dim strWh As String = ""
        If Left(pStrWh.Trim, 3) = "and" Then
            strWh = pStrWh
        Else
            strWh = " and " & pStrWh
        End If
        Dim sql As String = "select top 1 * from " & pStrTable & " where 1=1 " & strWh
        If Cl_DataMag.GF_CreateDataSource(sql).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' 按F12可以获取控件名称
    ''' </summary>
    Public Shared Sub setEnbleContrName(pContr As Control)
        For Each child As Control In pContr.Controls
            AddHandler child.KeyUp, Sub(send As Object, ev As KeyEventArgs)
                                        If ev.KeyData = Keys.F12 Then
                                            InputBox("", "", send.name)
                                        End If
                                    End Sub
            If child.Controls.Count > 0 Then
                setEnbleContrName(child)
            End If
        Next
    End Sub
    ''' <summary>
    ''' 获取完整编码
    ''' </summary>
    ''' <param name="pStrMc">编码名称</param>
    ''' <param name="pTb">表</param>
    ''' <param name="pBs">标识</param>
    ''' <param name="pBlsy">是否使用获取的编码</param>
    Public Shared Function getBmVa(ByVal pStrMc As String, pTb As String, pBs As Integer,
                                   Optional ByVal pBlsy As Boolean = False, Optional pExpm As Object = Nothing) As String
        Dim strRn As String = ""
        Dim strMc As String = ""
        strMc = pStrMc

        Dim sql As String = "select * from tb_bcbm where tb_bcbm_bmmc='" & strMc & "' and tb_bcbm_tb='" & pTb & "' and tb_bcbm_bs=" & pBs
        Dim dt As DataTable = sql.YanGetDb
        Return getBmVa(dt, pBlsy,pExpm)
    End Function
    ''' <summary>
    ''' 获取完整编码
    ''' </summary>
    ''' <param name="pDt">组成编码的记录集</param>
    ''' <param name="pBlsy">是否使用获取的编码</param>
    Public Shared Function getBmVa(pDt As DataTable, Optional ByVal pBlsy As Boolean = False, Optional pExpm As Object = Nothing) As String
        Dim strRn As String = ""
        For Each dr As DataRow In pDt.Rows
            Select Case dr("tb_bcbm_lx")
                Case "文本"
                    strRn &= _S.YanNullToEmpty(dr("tb_bcbm_va"))
                Case "当前年"
                    strRn &= System.DateTime.Now.Year.ToString("0000")
                Case "当前年(2位)"
                    strRn &= Strings.Right(System.DateTime.Now.Year, 2)
                Case "当前月"
                    strRn &= DateTime.Now.Month.ToString("00")
                Case "当前日"
                    strRn &= _S.GF_PF_bzhs(System.DateTime.Now.Day, 2)
                Case "随机数"
                    'Dim iSx As Integer = _S.YanFormatNum2(dr("tb_bm_va"))
                    Dim iSx As Integer = _S.YanNullToEmpty(dr("tb_bcbm_va")).Length
                    Dim strMd As String = ""

                    If iSx = 0 Then
                        iSx = 3
                    End If
                    For i As Integer = 0 To iSx - 1
                        strMd &= "9"
                    Next
                    Dim rand = New System.Random()
                    strRn &= rand.Next(strMd)
                Case "累加数"
                    Dim strMd As String = ""
                    Dim iXz As Integer = 0
                    '如果设置了重新计数
                    Select Case _S.YanNullToEmpty(dr("tb_bcbm_zdbz"))
                        Case "年"
                            iXz = System.DateTime.Now.Year
                            If _S.YanFormatNum2(dr("tb_bcbm_xz")) <> System.DateTime.Now.Year Then
                                strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va2"))
                            Else
                                strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va"))
                            End If
                        Case "月"
                            iXz = System.DateTime.Now.Month
                            If _S.YanFormatNum2(dr("tb_bcbm_xz")) <> System.DateTime.Now.Month Then
                                strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va2"))
                            Else
                                strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va"))
                            End If
                        Case "日"
                            iXz = System.DateTime.Now.Day
                            If _S.YanFormatNum2(dr("tb_bcbm_xz")) <> System.DateTime.Now.Day Then
                                strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va2"))
                            Else
                                strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va"))
                            End If
                        Case Else
                            strMd &= _S.YanNullToEmpty(dr("tb_bcbm_va"))
                    End Select
                    strRn &= strMd
                    '如果使用，那么原初值值要+1
                    If pBlsy = True Then
                        '位数等于初始值的长度
                        Dim iWs As Integer = strMd.Length
                        '将原值格式化成数字
                        Dim iVa As Integer = _S.YanFormatNum2(strMd)
                        '获取新值
                        Dim strNew As String = _S.GF_PF_bzhs((iVa + 1).ToString, iWs, isForce:=True)
                        '更新数据库
                        _D.updateData("tb_bcbm", New String(,) {{"tb_bcbm_va", strNew}, {"tb_bcbm_xz", iXz}}, "tb_bcbm_ID=" & dr("tb_bcbm_ID"))
                    End If
                Case en_phEx.附加信息.ToString
                    If pExpm IsNot Nothing Then
                        Dim tStr As String = CType(pExpm, FrWpAdd).m_fjxxDt.Select("tb_gxfjxx_mc='" &
                                                           _S.YanNullToEmpty(dr("tb_bcbm_va")) & "'").YanArrDrToDb.YanDtValue2("tb_gxfjxx_ID")
                        Dim cor As Control = CType(pExpm, FrWpAdd).YanFindControl("fjxx" & tStr)
                        If cor IsNot Nothing Then
                            strRn &= cor.Text
                        End If
                    End If
                Case Else
            End Select
        Next
        Return strRn
    End Function
End Class


Class DatagridViewCheckBoxHeaderCell
    Inherits DataGridViewColumnHeaderCell
    Private checkBoxLocation As Point
    Private checkBoxSize As Size
    Private _checked As Boolean = False
    Private _cellLocation As New Point()
    Private _cbState As System.Windows.Forms.VisualStyles.CheckBoxState = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal
    Public OnCheckBoxClicked As CheckBoxClickedHandler

    Public Delegate Sub CheckBoxClickedHandler(state As Boolean)
    Public Class DataGridViewCheckBoxHeaderCellEventArgs
        Inherits EventArgs
        Private _bChecked As Boolean
        Public Sub New(bChecked As Boolean)
            _bChecked = bChecked
        End Sub
        Public ReadOnly Property Checked() As Boolean
            Get
                Return _bChecked
            End Get
        End Property
    End Class


    Public Sub New()
    End Sub
    Protected Overrides Sub Paint(graphics As System.Drawing.Graphics, clipBounds As System.Drawing.Rectangle, cellBounds As System.Drawing.Rectangle, rowIndex As Integer, dataGridViewElementState As DataGridViewElementStates, value As Object, _
        formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, _
            formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        Dim p As New Point()
        Dim s As Size = CheckBoxRenderer.GetGlyphSize(graphics, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal)
        p.X = cellBounds.Location.X + (cellBounds.Width \ 2) - (s.Width / 2)
        p.Y = cellBounds.Location.Y + (cellBounds.Height \ 2) - (s.Height / 2)
        _cellLocation = cellBounds.Location
        checkBoxLocation = p
        checkBoxSize = s
        If _checked Then
            _cbState = System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal
        Else
            _cbState = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal
        End If
        CheckBoxRenderer.DrawCheckBox(graphics, checkBoxLocation, _cbState)
    End Sub
    Protected Overrides Sub OnMouseClick(e As DataGridViewCellMouseEventArgs)
        Dim p As New Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y)
        If p.X >= checkBoxLocation.X AndAlso p.X <= checkBoxLocation.X + checkBoxSize.Width AndAlso p.Y >= checkBoxLocation.Y AndAlso p.Y <= checkBoxLocation.Y + checkBoxSize.Height Then
            _checked = Not _checked
            If OnCheckBoxClicked IsNot Nothing Then
                'RaiseEvent OnCheckBoxClicked(_checked)
                OnCheckBoxClicked(_checked)
                Me.DataGridView.InvalidateCell(Me)
            End If
        End If
        MyBase.OnMouseClick(e)
    End Sub
End Class

''' <summary>
''' 遮罩层类
''' </summary>
Class OpaqueCommand
    Private m_OpaqueLayer As MyOpaqueLayer = Nothing
    '半透明蒙板层
    ''' <summary>
    ''' 显示遮罩层
    ''' </summary>
    ''' <param name="control">控件</param>
    ''' <param name="alpha">透明度</param>
    ''' <param name="isShowLoadingImage">是否显示图标</param>
    Public Sub ShowOpaqueLayer(control As Control, alpha As Integer, isShowLoadingImage As Boolean)
        Try
            If Me.m_OpaqueLayer Is Nothing Then
                Me.m_OpaqueLayer = New MyOpaqueLayer(alpha, isShowLoadingImage, G_loadimg)
                control.Controls.Add(Me.m_OpaqueLayer)
                Me.m_OpaqueLayer.Dock = DockStyle.Fill
                Me.m_OpaqueLayer.BringToFront()
            End If
            Me.m_OpaqueLayer.Enabled = True
            Me.m_OpaqueLayer.Visible = True
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' 隐藏遮罩层
    ''' </summary>
    Public Sub HideOpaqueLayer()
        Try
            If Me.m_OpaqueLayer IsNot Nothing Then
                Me.m_OpaqueLayer.Visible = False
                Me.m_OpaqueLayer.Enabled = False
            End If
            'MessageBox.Show(ex.Message);
        Catch ex As Exception
        End Try
    End Sub
End Class



