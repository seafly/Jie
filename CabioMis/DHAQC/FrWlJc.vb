Public Class FrWlJc
    Public m_arrCor() As Control  '检测项目的控件数组

    Public m_qclx As Integer = 0
    Public m_wpbs As Integer = 0
    Public m_jcb As String = ""  '检测表
    Public m_wlbs As Integer = 0 '检测标识
    Public m_objMyDataCl As New myDataCl  '窗体数据操作对象
    Private m_dataRow As DataRow        '使用的数据行
    Private Sub FrWlJc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '数据准备
        tb_i259b_i231a.Text = GetType(en_QcLX).YanGetEnName(m_qclx)
        tb_QcJc_qjtime.BringToFront()
        tb_QcJc_ftime.BringToFront()

        '先查看是否有未完成的请检单
        Dim sql As String = "select * from tb_QcJc where tb_QcJc_jcb='" & m_jcb & "' and tb_QcJc_wlbs=" & m_wlbs & " and tb_QcJc_sfsh='否' and tb_QcJc_sfwc='否'"
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        If dt.Rows.Count > 0 Then
            GS_DataGridViewbyDb(show1, dt, True, True)
            setFrnr()
            AddHandler show1.SelectionChanged, AddressOf setFrnr
            Return
        End If

        button2_Click()

        '_D.Gs_showsj(Me, m_objMyDataCl.m_Ds.Tables("tb_i259b"))
        G_S_TURNTAB(Me, 1) '控件TAB顺序
        MyBase.Text = "QC审核"

        Select Case m_qclx
            Case en_QcLX.工艺
                Label7.Text = "生产单号："

                Dim objLabel As New Label
                objLabel.Text = "产出批号："
                objLabel.Height = Label8.Height
                objLabel.Width = Label8.Width
                objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
                objLabel.Location = New Point(Label8.Location.X + Label8.Width + 5, Label8.Location.Y)
                Me.Controls.Add(objLabel)

                objLabel = New Label
                objLabel.Text = CType(Application.OpenForms.Item("Frqc_list"), Frqc_list).m_ListDt.Select("tb_sc_ID=" & m_wlbs).YanArrDrToDb.YanDtValue2("产出批号")
                objLabel.Height = Label8.Height
                objLabel.Width = Label8.Width
                objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
                objLabel.Location = New Point(Label8.Location.X + Label8.Width * 2, Label8.Location.Y)
                objLabel.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                Me.Controls.Add(objLabel)

        End Select
    End Sub

    '根据自定义的检测项目显示控件
    Private Sub showConTrols_add()
        Dim sql As String = ""
        Dim dt As DataTable
        Select Case m_qclx
            Case en_QcLX.物品
                Select Case m_jcb
                    Case "tb_wlph"
                        sql = "select * from " & m_jcb & " where " & m_jcb & "_ID=" & m_wlbs
                        dt = _D.GF_CreateDataSource(sql)
                        sql = "select * from tb_Qcxm where tb_QcXm_qclx='" & m_qclx & "' and  tb_Qcxm_wpbs='" & dt.YanDtValue2("tb_wlph_wpbs") & "'"   '根据物料代码查找检测的项目
                    Case Else
                        sql = "select * from " & m_jcb & " where " & m_jcb & "_ID=" & m_wlbs
                        dt = _D.GF_CreateDataSource(sql)
                        sql = "select * from tb_Qcxm where tb_QcXm_qclx='" & m_qclx & "' and  tb_Qcxm_wldm='" & dt.Rows(0)("tb_i259b_i231a") & "'"   '根据物料代码查找检测的项目
                End Select
            Case en_QcLX.成品
                sql = "select * from tb_Qcxm where tb_QcXm_qclx='" & m_qclx & "' and  tb_Qcxm_wldm='" & GetType(en_cpMc).YanGetEnT2N(m_jcb) & "'"
            Case en_QcLX.工序
                sql = "select * from tb_Qcxm where tb_QcXm_qclx='" & m_qclx & "' and  tb_Qcxm_wldm='" & GetType(en_LcTableName).YanGetEnT2N(m_jcb) & "'"
            Case en_QcLX.工艺
                sql = "select * from tb_Qcxm where tb_QcXm_qclx='" & m_qclx & "' and  tb_QcXm_wpbs=" & m_wpbs
        End Select

        dt = _D.GF_CreateDataSource(sql)

        m_arrCor = New Control(dt.Rows.Count - 1) {}
        Dim objPoint As New System.Drawing.Point(10, 20)
        '循环检测项目
        For i As Integer = 0 To dt.Rows.Count - 1
            '先加文本
            Dim objLabel As New Label
            objLabel.Text = dt.Rows(i)("tb_Qcxm_xmmc")
            objLabel.Height = 23
            objLabel.Width = 220
            objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            objLabel.Location = objPoint
            Panel1.Controls.Add(objLabel)
            objPoint.X += objLabel.Width

            '在加控件
            Select Case dt.Rows(i)("tb_QcXm_lx").ToString
                Case "数字"
                    m_arrCor(i) = New yanTextBox
                    CType(m_arrCor(i), yanTextBox).m_vaMin = dt.Rows(i)("tb_QcXm_vaMin").ToString
                    CType(m_arrCor(i), yanTextBox).m_vaMax = dt.Rows(i)("tb_QcXm_vaMax").ToString
                    CType(m_arrCor(i), yanTextBox).m_blVapd = True
                Case ("文本")
                    m_arrCor(i) = New TextBox
                    m_arrCor(i).Text = dt.Rows(i)("tb_QcXm_vaDef").ToString
                    m_arrCor(i).ForeColor = Color.FromArgb(180, 180, 180)
                    AddHandler CType(m_arrCor(i), TextBox).TextChanged, AddressOf setTextColor
                    AddHandler CType(m_arrCor(i), TextBox).DoubleClick, Sub(sender As Object, e As EventArgs)
                                                                            sender.ForeColor = Color.FromArgb(0, 0, 0)
                                                                            CType(sender, TextBox).Focus()
                                                                            CType(sender, TextBox).Select(CType(sender, TextBox).TextLength, 0)
                                                                        End Sub
                Case "选择"
                    m_arrCor(i) = New ComboBox
                    CType(m_arrCor(i), ComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                    CType(m_arrCor(i), ComboBox).FormattingEnabled = True
                    CType(m_arrCor(i), ComboBox).Items.AddRange( _
                        dt.Rows(i)("tb_QcXm_dxz").ToString.Replace(vbCrLf, ",").Replace(Chr(13), "").Replace(Chr(10), "").Split(","))
                Case Else
                    m_arrCor(i) = New TextBox
            End Select
            m_arrCor(i).Name = "xm" & dt.Rows(i)("tb_Qcxm_ID")
            m_arrCor(i).Tag = dt.Rows(i)("tb_Qcxm_xmmc")
            m_arrCor(i).Width = 180
            m_arrCor(i).Location = objPoint
            Panel1.Controls.Add(m_arrCor(i))

            objPoint.X = IIf((i + 1) Mod 2 = 0, 10, objPoint.X + m_arrCor(i).Width + 10)
            objPoint.Y += IIf((i + 1) Mod 2 = 0, m_arrCor(i).Height + 20, 0)
        Next
    End Sub
    '根据检测id填充控件值
    Private Sub setKjVa(ByVal pQcbs As String)
        Dim sql As String = "select * from tb_QcVa where tb_QcVa_Qcbs=" & pQcbs
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)

        For i As Integer = 0 To m_arrCor.Length - 1
            For j As Integer = 0 To dt.Rows.Count - 1
                If m_arrCor(i).Tag = dt.Rows(j)("tb_QcVa_xmmc") Then
                    Select Case m_arrCor(i).GetType().Name
                        Case "ComboBox"
                            m_arrCor(i).Text = dt.Rows(j)("tb_QcVa_xmva")
                        Case Else
                            m_arrCor(i).ForeColor = Color.FromArgb(0, 0, 0)
                            m_arrCor(i).Text = dt.Rows(j)("tb_QcVa_xmva")
                    End Select
                    GoTo XXX
                End If
            Next
XXX:
        Next
        m_objMyDataCl.m_Ds.Tables("tb_QcJc").Rows(0)("tb_QcJc_ID") = pQcbs
    End Sub

    '保存QC结果
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        addQc()
    End Sub

    Private Sub setFrnr()
        m_objMyDataCl.setDataTb("tb_QcJc", show1.SelectedRows(0).Cells(0).Value) '用于提交数据的TB
        '根据自定义的检测项目显示控件
        Panel1.Controls.Clear()
        showConTrols_add()
        _D.Gs_showsj(Me, m_objMyDataCl.m_Ds.Tables("tb_QcJc"))
        setKjVa(m_objMyDataCl.m_Ds.Tables("tb_QcJc").Rows(0)("tb_QcJc_ID"))
        Return
    End Sub

    '新添QC记录
    Private Sub addQc()
        Dim tRow As DataRow = m_objMyDataCl.m_Ds.Tables("tb_QcJc").Rows(0)  '记录物料的数据
        tRow("tb_QcJc_jcb") = m_jcb  '写入原料标识
        tRow("tb_QcJc_wlbs") = m_wlbs  '写入原料标识
        tRow("tb_QcJc_czr") = G_dlrgh  '写入操作人工号 
        Dim sql As String = ""

        '如果是新添加判断请检单是否重复
        If tRow("tb_QcJc_ID") = 0 And _D.GF_CreateDataSource("select * from tb_QcJc where tb_QcJc_qjbh='" & tb_QcJc_qjbh.Text & "'").Rows.Count > 0 Then
            MsgBox("已有相同请检单！")
            Return
        End If
        '先保存QC记录
        Dim strQcId As String = _D.Gs_updasj(Me, m_objMyDataCl.m_Ds.Tables("tb_QcJc"), True)
        '先删除原来的
        sql = "delete from tb_QcVa where tb_QcVa_Qcbs=" & strQcId
        _D.GS_upztxx(sql)
        '在保存检测结果
        For i As Integer = 0 To m_arrCor.Length - 1
            If m_arrCor(i).Text.Trim <> "" And m_arrCor(i).ForeColor <> Color.FromArgb(180, 180, 180) Then
                sql &= "insert into tb_QcVa(tb_QcVa_xmmc,tb_QcVa_xmva,tb_QcVa_Qcbs) " & _
                "values('" & m_arrCor(i).Tag & "','" & m_arrCor(i).Text.Trim & "','" & strQcId & "');" & vbCrLf
            End If
        Next
        _D.GS_upztxx(sql)

        ClassPhgn.ClassPhgn_SetDqz2("请检编号") '使当前批号+1
        '更新物料检测标志
        Select Case m_jcb
            Case "tb_wlph"
            Case "tb_sc"
            Case Else
                sql = "update " & m_jcb & " set " & m_jcb & "_qcsh='" & tb_QcJc_sfsh.Text & "' where " & m_jcb & "_id='" & m_wlbs & "'"
                _D.GS_upztxx(sql)
        End Select
        Select Case m_jcb
            Case "tb_x832p"
                '更新进度表
                cl_theCl.saveBb(en_saveBb.成品粉生产进度2, m_wlbs)
            Case "tb_x825p"
                '更新DHA含量
                Dim strDhahl As String = ""
                For i As Integer = 0 To Panel1.Controls.Count - 1
                    If Panel1.Controls(i).Tag = "DHA含量/(面积百分比)" Then
                        strDhahl = Panel1.Controls(i).Text
                        Exit For
                    End If
                Next
                sql = "update tb_x825p set tb_x825p_m387e='" & strDhahl & "' where tb_x825p_id='" & m_wlbs & "'"
                _D.GS_upztxx(sql)
                sql = "update tb_x825pkc set tb_x825pkc_m387e='" & strDhahl & "' " &
                    "where tb_x825pkc_num=(select tb_x825p_num from tb_x825p where tb_x825p_ID=" & m_wlbs & ")"
                _D.GS_upztxx(sql)
        End Select

        MyBase.Close()
    End Sub

    Private Sub show1_CellContentClick(sender As Object, e As EventArgs) Handles show1.Click
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        setKjVa(show1.SelectedRows(0).Cells("tb_QcJc_ID").Value)
    End Sub
    Private Sub setTextColor(sender As Object, e As EventArgs)
        Dim objT As TextBox = sender
        objT.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub button2_Click() Handles button2.Click
        '根据自定义的检测项目显示控件
        Panel1.Controls.Clear()
        showConTrols_add()
        m_objMyDataCl.setDataTb("tb_QcJc")
        '请检单号
        tb_QcJc_qjbh.Text = ClassPhgn.ClassPhgn_Get("请检编号", "-") '得到当前批号+1的批号
    End Sub

    Private Sub tb_QcJc_sfsh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tb_QcJc_sfwc.SelectedIndexChanged
        If show1.RowCount <= 1 Then
            tb_QcJc_sfsh.Text = tb_QcJc_sfwc.Text
        End If
    End Sub
End Class