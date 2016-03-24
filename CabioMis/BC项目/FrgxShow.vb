Imports Cabio.BLL.Crafts
Public Class FrgxShow

    Private Sub FrgxShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_FaceSearch(ComboBox1, "tb_gxsz", 1, "名称")
        showList()
        For Each col As DataGridViewColumn In YanDaTaGridView1.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    '修改工序
    Private Sub gxadd(Optional pBs As Integer = 0)
        Dim f As New FrgxAdd
        f.m_gxid = pBs
        If f.ShowDialog = DialogResult.OK Then
            showList()
            CType(Application.OpenForms.Item("FrbcList"), FrbcList).setMenu()
        End If
    End Sub

    Private Sub showList(Optional pSql As String = "")
        Dim Service As New CraftsSettingService()
        'Service.GetListByQuery()根据查询条件出入不同的HashMap
        Dim sql As String = "select * from tb_gxsz where 1=1 " & pSql & " order by tb_gxsz_px"
        Dim dt As DataTable = sql.YanGetDb
        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("修改")
        AddHandler menu1.Items(1).Click, Sub()
                                             gxadd(YanDaTaGridView1.SelectedRows(0).Cells("tb_gxsz_ID").Value)
                                         End Sub
        menu1.Items.Add("单号设置")
        AddHandler menu1.Items(2).Click, Sub()
                                             Dim f As New Frph_sz
                                             f.tb_bcbm_tb.Text = "tb_gxsz"
                                             f.tb_bcbm_bs.Text = YanDaTaGridView1.SelectedRows(0).Cells("tb_gxsz_ID").Value
                                             f.tb_bcbm_bmmc.Text = "生产单号"
                                             f.ShowDialog()
                                         End Sub
        menu1.Items.Add("删除")
        AddHandler menu1.Items(3).Click, Sub()
                                             If MsgBox("确定要删除吗？", MsgBoxStyle.YesNo) = vbYes Then
                                                 'Service.Delete(工艺设置ID)
                                                 sql = "delete from tb_gxsz where tb_gxsz_ID=" & YanDaTaGridView1.SelectedRows(0).Cells("tb_gxsz_ID").Value
                                                 sql &= vbCrLf & "delete from tb_gxfjxx where tb_gxfjxx_gxbs=" & YanDaTaGridView1.SelectedRows(0).Cells("tb_gxsz_ID").Value
                                                 sql &= vbCrLf & "delete from tb_gxcccp where tb_gxcccp_gxbs=" & YanDaTaGridView1.SelectedRows(0).Cells("tb_gxsz_ID").Value
                                                 sql.YanDbExe()
                                                 showList()
                                                 CType(Application.OpenForms.Item("FrbcList"), FrbcList).setMenu()
                                             End If
                                         End Sub
        dt.YanDataBind(YanDaTaGridView1, "tb_gxsz_ID,tb_gxsz_wpbs", pCmenu:=menu1)
    End Sub
    '点击查询
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim zdzw As String = ComboBox1.Text
        Dim db As DataTable = CType(ComboBox1.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = _D.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = IIf(jgzd = "", "", " and [" & jgzd & "] like '%" & TextBox1.Text.Trim & "%'")
        showList(sql)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gxadd()
    End Sub

    Private Sub YanDaTaGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles YanDaTaGridView1.CellDoubleClick
        gxadd(YanDaTaGridView1.SelectedRows(0).Cells("tb_gxsz_ID").Value)
    End Sub
End Class