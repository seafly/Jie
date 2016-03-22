''' <summary>
''' 单个物品的QC设定
''' </summary>
Public Class FrQcSd
    Public m_strSqlWh As String = ""  '附加查询条件
    Public m_dm As String = ""  '要设定的物品代码
    Public m_mc As String = ""  '要设定的物品名称
    Public m_bs As Integer = 0  '要设定的物品标识
    Public m_Qclx As Integer = 0

    Private Sub FrQcSd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Text = "QC项目"
        GroupBox2.Text = m_mc & "的QC项目"

        AddHandler show1.DoubleClick, AddressOf clMrpDbclick_1 '双击LV1
        AddHandler show2.DoubleClick, AddressOf clMrpDbclick_2 '双击LV2
        AddHandler FormClosed, AddressOf clfrCloseed '关闭窗体

        Dim dt As DataTable = _D.GF_CreateDataSource("select tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx="& m_Qclx &" and tb_QcXm_wldm='" & m_dm & "' ")
        GS_DataGridViewbyDb(show2, dt, True, True)
        '填充SHOW1
        clWpSet_1()
    End Sub

    '显示show1
    Private Sub clWpSet_1(Optional ByVal pSql As String = "")
        '获取LV2的物品代码字符串
        Dim dtTm As DataTable = show2.DataSource
        Dim strTm As String = _D.YanDttoStr(dtTm, "tb_QcXm_xmmc", True)
        If strTm <> "" Then
            strTm = "and tb_xtszNr_mc not in (" & strTm & ")"
        End If
        If selTb.Text <> "" Then
            strTm = "and tb_xtszNr_mc like '%" & selTb.Text & "%'"
        End If
        Dim sql As String = "select tb_xtszNr_mc from tb_xtszNr where 1=1 " & strTm
        Dim dt As DataTable = _D.GF_CreateDataSource(sql)
        dt.DefaultView.Sort = "tb_xtszNr_mc asc"
        GS_DataGridViewbyDb(show1, dt, True, True)
        '重新排序
        'fr.show1.Sort(show1.Columns("tb_wp_dm"), ListSortDirection.Descending)
    End Sub
    '双击LV1的过程
    Private Sub clMrpDbclick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim strPh As String = InputBox("输入标准值", "QC设定")
        'If strPh = "" Then
        '    MsgBox("标准值输入错误！")
        '    Return
        'End If

        'lv2增加一行
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        Dim dr As DataGridViewRow = show1.SelectedRows(0)
        Dim dt2 As DataTable = show2.DataSource

        dt2.Rows.Add({dr.Cells("tb_xtszNr_mc").Value})
        'lv1删除相对应的行
        show1.Rows.Remove(dr)
    End Sub
    '双击LV2的过程
    Private Sub clMrpDbclick_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If show2.SelectedRows.Count = 0 Then
            Return
        End If
        '显示批号提取重量的结果
        Dim dr As DataGridViewRow = show2.SelectedRows(0)
        show2.Rows.Remove(dr)
        show2.Update()
        clWpSet_1()
    End Sub
    '关闭窗体的过程
    Private Sub clfrCloseed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        If MsgBox("更新数据吗？", MsgBoxStyle.YesNo) <> vbYes Then
            Return
        End If
        Select Case m_Qclx
            Case en_QcLX.工艺
                '先删除原来的QC项目
                _D.GS_upztxx("delete from tb_QcXm where tb_QcXm_qclx=" & m_Qclx & " and tb_QcXm_wpbs ='" & m_bs & "'")
            Case Else
                '先删除原来的QC项目
                _D.GS_upztxx("delete from tb_QcXm where tb_QcXm_qclx=" & m_Qclx & " and tb_QcXm_wldm ='" & m_dm & "'")
        End Select
        If show2.Rows.Count <= 0 Then
            Return
        End If
        Dim dic As New Dictionary(Of String, String)
        For i As Integer = 0 To show2.Rows.Count - 1
            dic("tb_QcXm_xmmc") = show2.Rows(i).Cells("tb_QcXm_xmmc").Value
            dic("tb_QcXm_qclx") = m_Qclx
            dic("tb_QcXm_wldm") = m_dm
            dic("tb_QcXm_wpbs") = m_bs
            _D.insertData("tb_QcXm", dic)
        Next
        ''先删除原来的QC项目
        ''_D.GS_upztxx("delete from tb_QcXm where tb_QcXm_qclx=" & m_Qclx & " and tb_QcXm_wldm ='" & m_dm & "'")
        'Dim dt As DataTable = _D.GF_CreateDataSource("select tb_QcXm_xmmc  from tb_QcXm where tb_QcXm_qclx=" & m_Qclx & " and tb_QcXm_wldm ='" & m_dm & "'")
        'If show2.Rows.Count <= 0 Then
        '    Return
        'End If
        ''写入QC项目
        'For i As Integer = 0 To show2.Rows.Count - 1
        '    Dim flag As Boolean = False
        '    For Each rowData As DataRow In dt.Rows
        '        If rowData(0).ToString() = show2.Rows(i).Cells("tb_QcXm_xmmc").Value Then
        '            flag = True
        '        End If
        '    Next
        '    If flag = False Then
        '        'Console.WriteLine(show2.Rows(i).Cells("tb_QcXm_xmmc").Value)
        '        'Console.WriteLine(m_Qclx)
        '        'Console.WriteLine(m_dm)
        '        'Console.WriteLine("---------------------------------------")
        '        _D.insertData("tb_QcXm", {{"tb_QcXm_xmmc", show2.Rows(i).Cells("tb_QcXm_xmmc").Value},
        '                                  {"tb_QcXm_qclx", m_Qclx},
        '                                      {"tb_QcXm_wldm", m_dm}})
        '    End If

        'Next
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub selBt_Click(sender As Object, e As EventArgs) Handles selBt.Click
        clWpSet_1()
    End Sub
End Class