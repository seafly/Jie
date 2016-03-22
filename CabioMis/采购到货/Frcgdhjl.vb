Public Class Frcgdhjl

    Private Sub weizhi()
        GroupBox1.Height = Me.Height * 3 / 4
        Dim t As Double = (Me.Height - GroupBox1.Height) / 3
        Label1.Top = t
        ComboBox1.Top = t
        Button1.Top = t
    End Sub
    Private Sub Frcgdhjl_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Private Sub Frcgdhjl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
        Dim sql As String = "select tb_dhgz_cgdh from tb_dhgz group by tb_dhgz_cgdh order by tb_dhgz_cgdh"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        GS_wlbktlr2(ComboBox1, dt, 0, "")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String = "select tb_dhgz_cgdh,tb_dhgz_dhdh,tb_dhgz_qgbm,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_qgr,tb_dhgz_yjdhl,tb_dhgz_yjdhrq from tb_dhgz"
        sql &= " where tb_dhgz_cgdh= '" & ComboBox1.Text & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub
End Class