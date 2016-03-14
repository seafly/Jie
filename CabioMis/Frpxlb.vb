Public Class Frpxlb
    'Public bm As String
    Private Sub Frpxlb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        wz()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, "tb_ygpxda", 1) '文本查询函数：关联表的文本字段的显示
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cx()
    End Sub
    Private Sub cx()
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"


        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim dbs As String = ""
        If Trim(TextBox1.Text) <> "" Then
            dbs = dbs & " and tb_ygpxda_xm like '%" & TextBox1.Text.Trim & "%' "
        End If
        If Trim(TextBox2.Text) <> "" Then
            dbs = dbs & " and tb_ygpxda_js like '%" & TextBox2.Text.Trim & "%' "
        End If
        If Trim(TextBox3.Text) <> "" Then
            dbs = dbs & " and tb_ygpxda_kc like '%" & TextBox3.Text.Trim & "%' "
        End If
        Dim sql As String = "select  tb_ygpxda.tb_ygpxda_ID,tb_ygpxda.tb_ygpxda_rq,tb_ygpxda.tb_ygpxda_jssj,tb_ygpxda.tb_ygpxda_pxsj,tb_ygpxda.tb_ygpxda_dd,tb_ygpxda.tb_ygpxda_js,tb_ygpxda.tb_ygpxda_kc,tb_ygpxda.tb_ygpxda_kd,tb_ygpxda.tb_ygpxda_xm,tb_ygpxda.tb_ygpxda_xingbie,tb_ygpxda.tb_ygpxda_bumen,tb_ygpxda.tb_ygpxda_gd,tb_ygpxda.tb_ygpxda_sfkh,tb_ygpxda.tb_ygpxda_pxcj,tb_ygpxda.tb_ygpxda_sfhqzs,tb_ygpxda.tb_ygpxda_bz,tb_ygpxda.tb_ygpxda_czrgh,tb_ygpxda.tb_ygpxda_pxlb,tb_ygpxda.tb_ygpxda_qcsh from tb_ygpxda where tb_ygpxda_rq between '" & tt1 & "' and '" & tt2 & "' " & dbs & "  "
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        sql &= sqlbdssep & " order by tb_ygpxda_xm,tb_ygpxda_js"

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt, "0", True, True)
        Label5.Text = "查询结果" & dt.Rows.Count & "条记录"
    End Sub
    Private Sub wz()

        showl.Width = Me.Width - 10
        showl.Height = Me.Height - showl.Top - 50
    End Sub

    Private Sub Frpxlb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim nform As New Frtb_ygpxda
        nform.Labelid.Text = ""
        nform.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub


    Private Sub showl_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles showl.CellMouseDoubleClick
        With showl
            If .SelectedRows.Count > 0 Then
                Dim lr As String = .SelectedRows(0).Cells("tb_ygpxda_qcsh").Value
                If lr = "是" Then
                    MsgBox("已经完成审核，不能修改") : Exit Sub
                End If
                Dim nform As New Frtb_ygpxda
                nform.Labelid.Text = .SelectedRows(0).Cells(0).Value
                nform.Labeltb.Text = "tb_ygpxda"
                nform.ShowDialog()
                cx()
            End If
        End With
    End Sub
End Class