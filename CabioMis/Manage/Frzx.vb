Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr

Public Class Frzx
    Public xgid = 0
    Private Sub Frzx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        Dim m As DataGridView = Me.Owner.Controls("listview1")
        Call GS_wlbktlr2(tb_yg_js, GF_CreateDataSource(G_cnnstr, "select tb_js_mc from tb_js"), 0, Null2String(m.SelectedRows(0).Cells(5).Value))
        tb_yg_n430f.Enabled = False

    End Sub
    '''''下面更新权限与登陆界面
    Private Sub gxqx(ByVal str1 As String)
        Dim dljm, qx As String
        Dim sql As String = "select tb_js_qx,tb_js_jm from tb_js where tb_js_mc='" & tb_yg_js.Text & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        dljm = dt.Rows(0)(1) : qx = dt.Rows(0)(0)
        sql = "update tb_yg set tb_yg_dl='" & dljm & "',tb_yg_quan='" & qx & "' where tb_yg_id='" & str1 & "'"
        GS_upztxx(G_cnnstr, sql)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If GF_modsj("tb_yg", Me, xgid) = True Then
            gxqx(xgid)
            MsgBox("修改资料完成!")
            Dim m As DataGridView = Me.Owner.Controls("listview1")

            m.SelectedRows(0).Cells(1).Value = tb_yg_n430f.Text
            m.SelectedRows(0).Cells(5).Value = tb_yg_js.Text
            Me.Close()
        Else
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub tb_yg_n430f_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_yg_n430f.TextChanged

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub tb_yg_js_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_yg_js.SelectedIndexChanged

    End Sub
End Class