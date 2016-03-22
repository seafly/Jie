Public Class FrVb
    Public id As Integer = 2
    Public sda As System.Data.OleDb.OleDbDataAdapter
    Private Sub FrVb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
  
    '在DataTable中查询返回 一个DataRow数组
    Public Function GF_czmc(ByVal tbmc As DataTable, ByVal cxstr As String) As DataRow()
        Dim foundRows() As DataRow
        foundRows = tbmc.Select(cxstr)
        GF_czmc = foundRows
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sql As String = "select * from tb_ygpxda  "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        sda.FillSchema(dt, SchemaType.Source)
        Dim dr() As DataRow = dt.Select("tb_ygpxda_ID='" & id & "'")
        dr(0)("tb_ygpxda_rq") = "saa"
        dr(0)("tb_ygpxda_js") = "saaaaaa"
        sda.Update(dt)
        MessageBox.Show("更新成功")
    End Sub
End Class