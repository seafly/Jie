Public Class Frgxry
    Public wjid As String '文件ID
    Private Sub Frgxry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_yg_v753n,tb_yg_w779o,tb_yg_m381e,tb_yg_zw,tb_yg_n430f from tb_yg where tb_yg_yx='有效' and tb_yg_n430f<>'" & G_dlrgh & "' order by tb_yg_v753n ")
        Call GS_useviewbydb2(ListView1, db1, -1, 90)
        wjqx()
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub wjqx()
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_upfile_gxry from tb_upfile where tb_upfile_id=" & wjid)
        Dim wjsyqx As String = Null2String(dt.Rows(0)(0)) '得到文件的共享人员工号
        If wjsyqx = "" Then
            Exit Sub
        End If
        wjsyqx = GF_qhjdh(wjsyqx)
        For i As Integer = 0 To ListView1.Items.Count - 1
            Dim yghm As String = GF_qhjdh(ListView1.Items(i).SubItems(4).Text)
            If InStr(wjsyqx, yghm) > 0 Then
                ListView1.Items(i).Checked = True
            End If
        Next
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        For i As Integer = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = True
        Next
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim wjqxa As String = ""
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            Dim yghm As String = ListView1.CheckedItems(i).SubItems(4).Text
            wjqxa = wjqxa & yghm & ","
        Next
        wjqxa = GF_removedh(wjqxa)
        If wjqxa = "" Then
            MsgBox("请至少选择一个人员") : Exit Sub
        End If
        GS_upztxx(G_cnnstr, "update tb_upfile set tb_upfile_gxry='" & wjqxa & "' where tb_upfile_id=" & wjid)
        Me.Close()
    End Sub
End Class