Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frtb_warning

    Private Sub Frtb_warning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub

    Private Sub Frtb_warning_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - GroupBox1.Top - 50
    End Sub


    Private Sub showsj()
        Dim sql As String = "select * from tb_warning "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)

        For Each Dc As DataColumn In dt.Columns
            Dim zdmx As String = GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & Dc.Caption & "'", 4) '将英文字段名转换成中文描述
            Select Case Dc.DataType.ToString
                Case "System.String"
                    ComboBox2.Items.Add(zdmx)
            End Select
        Next


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim dt1 As New DataTable
        dt1 = DeepCode.DeepDoGridView.ToDataTable(show1)
        Dim bds As String = "1=1"
        Dim cxzd1 As String = GettrueZdm(ComboBox2.Text)    '得描述转换为英文字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If

        Dim dt2 As DataTable= GF_czmctb(dt1, bds) '查询并得到结果DB
        show1.DataSource = dt2
        GS_TranEtoC(show1) '将DataGridView列字段翻译成为中文描叙
        GroupBox1.Text = " （共有" & dt2.Rows.Count & "条记录）"
    End Sub
    '得描述转换为英文字段
    Private Function GettrueZdm(ByVal str As String) As String
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_biao='tb_warning' and tb_biaozdinf_mx='" & str & "'", 1) '得到英文字段名称
        Return zd
    End Function
    '
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        showsj()
    End Sub
    '添加
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aa As New Frtb_WarningAdd
        aa.Text = "添加预警时间信息"
        aa.ShowDialog()
    End Sub
    '修改
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If show1.SelectedRows.Count = 0 Then
            MessageBox.Show("没有选择要修改的记录！")
            Exit Sub

        Else
            Dim aa As New Frtb_WarningAdd
            aa.Text = "修改预警时间信息"
            aa.id = show1.SelectedRows(0).Cells(0).Value
            aa.dm = show1.SelectedRows(0).Cells(1).Value
            aa.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If show1.SelectedRows.Count = 0 Then
            MessageBox.Show("没有选择要修改的记录！")
            Exit Sub
        End If
        Dim sql As String = "delete  from tb_warning where  tb_warning_id='" & show1.SelectedRows(0).Cells(0).Value & "' "
        GS_upztxx(G_cnnstr, sql)
        MessageBox.Show("删除成功！")
        showsj()
    End Sub
End Class