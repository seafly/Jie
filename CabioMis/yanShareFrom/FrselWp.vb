Public Class FrselWp
    Private m_frOpen As FrgxAdd = CType(Application.OpenForms.Item("FrgxAdd"), FrgxAdd)
    Private Sub FrselWp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        AddHandler show1.DoubleClick, Sub()
                                          If show1.SelectedRows.Count = 0 Then
                                              Return
                                          End If
                                          Me.DialogResult = DialogResult.OK
                                      End Sub
        GS_FaceSearch(ComboBox3, "tb_wp", 1, "物品名称")
        ComboBox3.Items.Remove("物品分类")
        GS_wlbktlr3(ComboBox1, GetType(en_wpfl).YanEnToTb().YanDtToStr("name").Split(","), en_wpfl.过程品.ToString)
        showWp(getSql())
    End Sub
    '显示物品列表
    Private Sub showWp(Optional ByVal pStrSql As String = "")
        Dim sql As String = "select tb_wp_ID,tb_wp_dm,tb_wp_pm,tb_wp_wpfl,tb_wp_gsmc from tb_wp " & _
        " where 1=1  " & pStrSql & " order by tb_wp_dm"
        Dim dt As DataTable = sql.YanGetDb
        dt.YanDataBind(show1)
        GroupBox1.Text = "共有物品" & dt.Rows.Count
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showWp(getSql())
    End Sub

    Private Function getSql() As String
        Dim zdzw As String = ComboBox3.Text
        Dim db As DataTable = CType(ComboBox3.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = ""
        If jgzd <> "" Then
            sql = " and [" & jgzd & "] like '%" & TextBox2.Text.Trim & "%'"
        End If
        sql &= IIf(ComboBox1.Text = "", "", " and " & _D.GF_cnwithen(db, "tb_biaozdinf_mx='物品分类'", 1) & " ='" & ComboBox1.Text & "'")
        Return sql
    End Function
End Class