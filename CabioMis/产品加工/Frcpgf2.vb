Public Class Frcpgf2

    Private Sub Frcpgf2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        showsj()
    End Sub

    Private Sub BtnDelLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelLock.Click
        Me.Close()
    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLock.Click
        Dim nform As New Frcpgf
        Me.AddOwnedForm(nform)
        nform.id = show1.SelectedRows(0).Cells(0).Value
        nform.ShowDialog()
        showsj()
    End Sub
    Private Sub showsj()
        Dim sql As String = "select tb_cpdmhz_id,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_gysm,tb_cpdmhz_hlsm,tb_cpdmhz_ylsm,tb_cpdmhz_jgdm,tb_cpdmhz_tzsm,tb_cpdmhz_zbsm,tb_cpdmhz_bzsm,tb_cpdmhz_bqsm,tb_cpdmhz_tsjcsm,tb_cpdmhz_cpgfczr,tb_cpdmhz_cpgfrq"
        sql &= " from tb_cpdmhz where tb_cpdmhz_cpgfczr is not null and tb_cpdmhz_cpgfrq is not null"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        If show1.Rows.Count - 1 < 0 Then
            Return
        End If
        show1.Rows(show1.Rows.Count - 1).Selected = True
        GroupBox2.Text &= "：查询到" & dt.Rows.Count & "条数据"
    End Sub
End Class