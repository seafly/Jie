''' <summary>
''' 编辑工序产品
''' </summary>
Public Class FrEdit_gxcp
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        tb_gxcccp_isdp.Text = "否"
        tb_gxcccp_ccps.Text = 1

    End Sub
    Private Sub FrEdit_gxcp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sourceDt As DataTable = Nothing       '使用的数据
        Dim frOpen As FrgxAdd = CType(Application.OpenForms.Item("FrgxAdd"), FrgxAdd)
        If rowBs.Text <>"" Then
            sourceDt = CType(frOpen.showWpxx.DataSource, DataTable).Select("rowBs='" & rowBs.Text & "'").YanArrDrToDb
            _D.Gs_showsj(Me, sourceDt)
        End If
    End Sub

    Private Sub tb_wp_dm_DoubleClick(sender As Object, e As EventArgs) Handles tb_wp_dm.DoubleClick
        Dim f As New FrselWp
        If f.ShowDialog() = DialogResult.OK Then
            Dim dt As DataTable = CType(f.show1.DataSource, DataTable).Select("tb_wp_ID=" & f.show1.SelectedRows(0).Cells(0).Value).YanArrDrToDb
            _D.YanDtSetFrCon(Me, dt)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckControlNull(Me) = False Then
            Return
        End If
        Me.DialogResult = DialogResult.OK
    End Sub
End Class