Public Class FrQcXmsz

    Private Sub FrQcXmsz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showTb()
    End Sub

    Private Sub showTb()
        Dim dt As DataTable = _D.GF_CreateDataSource("select tb_xtszNr_ID,tb_xtszNr_mc from tb_xtszNr where tb_xtszNr_bs=" & en_xtLb.QC项目)

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("删除")
        AddHandler menu1.Items(1).Click, AddressOf delXm

        GS_DataGridViewbyDb(show1, dt, True, True, menu1)
    End Sub

    Private Sub delXm()
        Dim sql As String = "delete from tb_xtszNr where tb_xtszNr_ID=" & show1.SelectedRows(0).Cells("tb_xtszNr_ID").Value
        _D.GS_upztxx(sql)
        showTb()
    End Sub

    Private Sub selBt_Click(sender As Object, e As EventArgs) Handles selBt.Click
        If selTb.Text.Trim = "" Then
            Return
        End If
        If _D.GF_CreateDataSource("select * from tb_xtszNr where tb_xtszNr_bs=" & en_xtLb.QC项目 & " and tb_xtszNr_mc='" & selTb.Text.Trim & "'").Rows.Count > 0 Then
            MsgBox("已有该名称的项目！")
            Return
        End If

        _D.insertData("tb_xtszNr", New String(,) {{"tb_xtszNr_mc", selTb.Text.Trim}})
        showTb()
        MsgBox("添加成功！")
        selTb.Text = ""
    End Sub

End Class