Public Class FrgetGysmc
    Public dm As String = ""
    Private Sub FrgetGysmc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select * from tb_GysTwo  where tb_GysTwo_sfhg<>'否' and tb_GysTwo_dm = '" & dm & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(ListView1, dt, True, True)
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        With ListView1
            If .SelectedRows.Count > 0 Then
                Dim gysmc As String = Null2String(.SelectedRows(0).Cells("tb_GysTwo_gysmc").Value)
                Dim scs As String = Null2String(.SelectedRows(0).Cells("tb_GysTwo_scsmc").Value)
                Dim xh As String = Null2String(.SelectedRows(0).Cells("tb_GysTwo_xh").Value)
                Dim wbz As String = Null2String(.SelectedRows(0).Cells("tb_GysTwo_wbz").Value)
                Dim ggxh As String = Null2String(.SelectedRows(0).Cells("tb_GysTwo_gg").Value)
                Dim nform As Frcg = Me.Owner
                nform.tb_cg_gysmc.Text = gysmc
                nform.tb_cg_scs.Text = scs
                nform.tb_cg_xh.Text = xh
                nform.tb_cg_wbz.Text = wbz
                nform.tb_cg_ggxh.Text = ggxh
                nform.tb_cg_gysbs.Text = Null2String(.SelectedRows(0).Cells("tb_GysTwo_ID").Value)
            End If
        End With
        Me.Close()
    End Sub


End Class