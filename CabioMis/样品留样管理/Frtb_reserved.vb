Public Class Frtb_reserved

    Private Sub Frtb_reserved_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized
        showsj("")
    End Sub
    Private Sub Frtb_reserved_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - GroupBox1.Top - 50
    End Sub
        

    Private Sub showsj(ByVal str As String)
        Dim sql As String = ""
        Select Case str
            Case "原料"
                sql = "select tb_reserved_id,tb_reserved_wllb,tb_reserved_pm,tb_reserved_num,tb_reserved_source,tb_reserved_nyrq,tb_reserved_nysl,tb_reserved_savedays,tb_reserved_yplx,tb_reserved_pizhu,tb_reserved_remark  from tb_reserved where tb_reserved_wllb='原料'"
            Case "成品粉"
                sql = "select tb_reserved_id,tb_reserved_wllb,tb_reserved_qyrq,tb_reserved_pm,tb_reserved_num,tb_reserved_nysl,tb_reserved_nybh,tb_reserved_kc,tb_reserved_qysl,tb_reserved_savedays,tb_reserved_pizhu,tb_reserved_remark from tb_reserved where  tb_reserved_wllb='成品粉'"
            Case "成品油"
                sql = "select tb_reserved_id,tb_reserved_wllb,tb_reserved_pm,tb_reserved_num, tb_reserved_nyrq,tb_reserved_nysl,tb_reserved_savedays,tb_reserved_nybh,tb_reserved_kc,tb_reserved_yplx,tb_reserved_pizhu,tb_reserved_remark from tb_reserved where  tb_reserved_wllb='成品油'"
            Case Else
                sql = "select * from tb_reserved"
        End Select

        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        GroupBox1.Text = str & " （共有" & dt.Rows.Count & "条记录）"
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

        Dim dt2 As DataTable = GF_czmctb(dt1, bds) '查询并得到结果DB
        show1.DataSource = dt2
        GS_TranEtoC(show1) '将DataGridView列字段翻译成为中文描叙
        GroupBox1.Text = " （共有" & dt2.Rows.Count & "条记录）"
    End Sub
    '得描述转换为英文字段
    Private Function GettrueZdm(ByVal str As String) As String
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_biao='tb_reserved' and tb_biaozdinf_mx='" & str & "'", 1) '得到英文字段名称
        Return zd
    End Function

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click, Button7.Click, Button8.Click, Button9.Click
        Dim button As Button = CType(sender, Windows.Forms.Button)
        showsj(button.Text)
    End Sub
    '添加
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aa As New Frtb_reservedAdd
        aa.Text = "添加留样管理信息"
        aa.ShowDialog()
    End Sub
    '修改
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If show1.SelectedRows.Count = 0 Then
            MessageBox.Show("没有选择要修改的记录！")
            Exit Sub

        Else
            Dim aa As New Frtb_reservedAdd
            aa.Text = "修改留样管理信息"
            aa.id = Convert.ToInt32(show1.SelectedRows(0).Cells(0).Value.ToString())
            aa.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub


End Class