Public Class Frph_List
    Public m_strType As String=""
    Private m_dt As DataTable = Nothing
    Private Sub Frph_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If m_strType = "选择" Then
            Dim checkboxColumn As New System.Windows.Forms.DataGridViewCheckBoxColumn
            checkboxColumn.DataPropertyName = "选择"
            checkboxColumn.FalseValue = "0"
            checkboxColumn.HeaderText = "选择"
            checkboxColumn.Name = "选择"
            checkboxColumn.ReadOnly = True
            checkboxColumn.TrueValue = "1"
            show1.Columns.Add(checkboxColumn)
            AddHandler show1.CellClick, Sub()
                                            show1.SelectedRows(0).Cells("选择").Value = IIf(show1.SelectedRows(0).Cells("选择").Value = 0, 1, 0)
                                        End Sub
            AddHandler MyBase.FormClosing, Sub()
                                               If MsgBox("确定选择吗？", MsgBoxStyle.YesNo) = vbNo Then
                                                   Return
                                               End If
                                               Me.DialogResult = DialogResult.OK
                                           End Sub
        End If
        m_dt = getSource()
        showList()
    End Sub

    Private Function getSource() As DataTable
        Dim sql As String = "select distinct tb_bcbm_bmmc from tb_bcbm where tb_bcbm_tb='zdy'"
        Dim dt As DataTable = sql.YanGetDb
        dt.Columns.Add("完整批号")
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("完整批号") = cl_YanMd.getBmVa(dt.YanDtValue2("tb_bcbm_bmmc", i), "zdy", 0)
        Next

        If m_strType = "选择" Then
            dt.Columns.Add("选择")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("选择") = 0
            Next
        End If
        Return dt
    End Function
    Private Sub showList()
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        '表示此菜单有添加功能
        menu1.Tag = 0
        menu1.Items.Add("添加")
        AddHandler menu1.Items(0).Click, Sub()
                                             Dim f As New Frph_sz
                                             f.tb_bcbm_tb.Text = "zdy"
                                             f.tb_bcbm_bs.Text = 0
                                             If f.ShowDialog() = DialogResult.OK Then
                                                 show1.DataSource = getSource()
                                             End If
                                         End Sub
        menu1.Items.Add("修改")
        AddHandler menu1.Items(1).Click, Sub()
                                             Dim f As New Frph_sz
                                             f.tb_bcbm_tb.Text = "zdy"
                                             f.tb_bcbm_bs.Text = 0
                                             f.tb_bcbm_bmmc.Text = show1.SelectedRows(0).Cells("tb_bcbm_bmmc").Value
                                             If f.ShowDialog() = DialogResult.OK Then
                                                 show1.DataSource = getSource()
                                             End If
                                         End Sub
        menu1.Items.Add("删除")
        AddHandler menu1.Items(2).Click, Sub()
                                             Dim Sql As String = "delete from tb_bcbm where tb_bcbm_tb='zdy' and tb_bcbm_bmmc='" &
                                                 show1.SelectedRows(0).Cells("tb_bcbm_bmmc").Value & "'"
                                             Sql.YanDbExe()
                                             show1.DataSource = getSource()
                                         End Sub
        AddHandler show1.CellDoubleClick, Sub()
                                              Dim f As New Frph_sz
                                              f.tb_bcbm_tb.Text = "zdy"
                                              f.tb_bcbm_bs.Text = 0
                                              f.tb_bcbm_bmmc.Text = show1.SelectedRows(0).Cells("tb_bcbm_bmmc").Value
                                              If f.ShowDialog() = DialogResult.OK Then
                                                  show1.DataSource = getSource()
                                              End If
                                          End Sub
        m_dt.YanDataBind(show1, "", menu1)
    End Sub

End Class