
Public Class Frgyslist

    Private Sub Frgyslist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_FaceSearch(ComboBox1, "tb_GysTwo", 1)
        showsj()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim sql As String = "select * from tb_GysTwo where 1=1 and tb_GysTwo_dm in (select tb_wp_dm from tb_wp  where  tb_wp_sfyx='是') "
        'Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBox1, TextBox1)
        'sql &= sqlbdssep
        'Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        'GS_DataGridViewbyDb(DataGridView2, dt, "0", True, True)
        showsj
    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Dim aa As New Frgysadd
        Me.AddOwnedForm(aa)
        aa.tb_GysTwo_gg.Text = Null2String(DataGridView1.SelectedRows(0).Cells("tb_wp_ggxh").Value)
        aa.tb_GysTwo_dm.Text = Null2String(DataGridView1.SelectedRows(0).Cells("tb_wp_dm").Value)
        aa.tb_GysTwo_wpfl.Text = Null2String(DataGridView1.SelectedRows(0).Cells("tb_wp_wpfl").Value)
        aa.tb_GysTwo_emc.Text = Null2String(DataGridView1.SelectedRows(0).Cells("tb_wp_pm").Value)
        aa.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql As String = "select tb_wp_id,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_wpfl from tb_wp where tb_wp_dm='" & TextBox2.Text & "'  and  tb_wp_sfyx='是'  "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(DataGridView1, dt, "0", True, True)
    End Sub

    Private Sub Frgyslist_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width / 3
        GroupBox2.Width = Me.Width / 2 + 70
        GroupBox1.Left = GroupBox1.Left + 10
        GroupBox2.Left = GroupBox1.Left + GroupBox1.Width + 50
        GroupBox1.Height = Me.Height - Button3.Top - Button3.Height - 70
        GroupBox2.Height = GroupBox1.Height
        GroupBox3.Left = GroupBox2.Left
    End Sub

    Public Sub showsj()
        Dim sql As String = "select tb_wp_id,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_wpfl,tb_wp_sfyx from tb_wp  where  tb_wp_sfyx='是' order by tb_wp_dm "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(DataGridView1, dt, "0", True, True)

        Dim sql2 As String = "select * from tb_GysTwo where tb_GysTwo_dm in (select tb_wp_dm from tb_wp  where  tb_wp_sfyx='是') "
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBox1, TextBox1)
        sql2 &= sqlbdssep & " order by tb_GysTwo_dm"
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)
        'GS_DataGridViewbyDb(DataGridView2, dt2, "0", True, True)
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("修改")
        AddHandler menu1.Items(1).Click, Sub()
                                             Dim aa As New Frgysadd
                                             aa.id = DataGridView2.SelectedRows(0).Cells("tb_GysTwo_id").Value
                                             If aa.ShowDialog = DialogResult.OK Then
                                                 sql = "select * from tb_GysTwo where tb_GysTwo_id='" & DataGridView2.SelectedRows(0).Cells("tb_GysTwo_id").Value & "'"
                                                 dt = sql.YanGetDb
                                                 For i As Integer = 0 To DataGridView2.ColumnCount - 1
                                                     DataGridView2.SelectedRows(0).Cells(DataGridView2.Columns(i).Name).Value = dt.YanDtValue2(DataGridView2.Columns(i).Name)
                                                 Next
                                             End If
                                         End Sub
        menu1.Items.Add("删除")
        AddHandler menu1.Items(2).Click, Sub()
                                             sql = "delete from tb_GysTwo where tb_GysTwo_id='" & DataGridView2.SelectedRows(0).Cells("tb_GysTwo_id").Value & "'"
                                             sql.YanDbExe()
                                             DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
                                         End Sub
        dt2.YanDataBind(DataGridView2, "tb_GysTwo_ID", menu1)
    End Sub
End Class