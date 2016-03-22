Public Class Frtb_FiveBuckleOil

    Private Sub Frtb_FiveBuckleOil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select tb_FiveBuckleOil_pldh from tb_FiveBuckleOil group by tb_FiveBuckleOil_pldh"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(ComboBox1, dt, 0, "")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String = "select tb_FiveBuckleOil_pldh,tb_FiveBuckleOil_num,tb_FiveBuckleOil_oilweight,tb_FiveBuckleOil_oilnum,tb_FiveBuckleOil_oilcplb,tb_FiveBuckleOil_oilmingc,tb_FiveBuckleOil_oiljiagdm from tb_FiveBuckleOil where tb_FiveBuckleOil_pldh ='" & ComboBox1.Text & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DbSum(dt) '最后一行求和
        GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
        GS_ysgx(ListView1) '最后一行变颜色
    End Sub
End Class