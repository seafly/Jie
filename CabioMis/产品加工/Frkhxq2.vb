Public Class Frkhxq2
    Private m_strWhere As String=""
    Private Sub BtnDelLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelLock.Click
        Me.Close()
    End Sub

    Private Sub Frkhxq2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        GS_FaceSearch(ComboBoxserchtext, "tb_khyqqkyrb", 1) '文本查询函数：关联表的文本字段的显示
        showsj()
    End Sub
    Private Sub showsj()
        Dim sql As String = "select tb_khyqqkyrb_ID,tb_khyqqkyrb_khlx,tb_khyqqkyrb_khmc,tb_khyqqkyrb_cplx,tb_khyqqkyrb_cpdm,tb_khyqqkyrb_jgdm,tb_khyqqkyrb_ddlx,tb_khyqqkyrb_xxdyq,tb_khyqqkyrb_gy,tb_khyqqkyrb_zb,tb_khyqqkyrb_bz,tb_khyqqkyrb_bq,tb_khyqqkyrb_wjyq,tb_khyqqkyrb_cyr,tb_khyqqkyrb_ysfs,tb_khyqqkyrb_yssxts,tb_khyqqkyrb_qtjtyq,tb_khyqqkyrb_czr,tb_khyqqkyrb_gxrq,tb_khyqqkyrb_pm,tb_khyqqkyrb_khqc,tb_khyqqkyrb_ddgh,tb_khyqqkyrb_yxx from tb_khyqqkyrb " &
            "where 1=1 " & m_strWhere
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        If show1.Rows.Count - 1 < 0 Then
            Return
        End If
        show1.Rows(show1.Rows.Count - 1).Selected = True
        GroupBox2.Text = "查询结果：查询到" & dt.Rows.Count & "条数据"
    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLock.Click
        Dim nform As New Frkhxq
        nform.id = show1.SelectedRows(0).Cells(0).Value
        nform.ShowDialog()
        showsj()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        m_strWhere = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext) '文本查询函数：挂接到查询文本
        showsj()
    End Sub
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub
End Class