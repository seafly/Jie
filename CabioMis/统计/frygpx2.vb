Public Class frygpx2

    Private Sub frygpx2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim aa As ListView = Me.Owner.Controls("ListView1")
        Dim sql As String
        With aa.SelectedItems(0)
            sql = "select tb_ygpxda_ID as 流水号,tb_ygpxda_xm,tb_ygpxda_xingbie,tb_ygpxda_bumen,tb_ygpxda_sfkh,tb_ygpxda_pxcj,tb_ygpxda_sfhqzs "
            sql = sql & "from tb_ygpxda "
            sql = sql & "where tb_ygpxda_rq='" & .SubItems(0).Text & "' and tb_ygpxda_jssj='" & .SubItems(1).Text & "' and  tb_ygpxda_dd='" & .SubItems(2).Text & "' and tb_ygpxda_js='" & .SubItems(3).Text & "' and tb_ygpxda_kc='" & .SubItems(4).Text & "' and tb_ygpxda_kd=" & .SubItems(5).Text & "  and  tb_ygpxda_pxlb='" & .SubItems(6).Text & "'"
        End With
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Call GS_useviewbydb2(ListView1, db1, -1, 90)
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, "员工培训详情", Me)

    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class