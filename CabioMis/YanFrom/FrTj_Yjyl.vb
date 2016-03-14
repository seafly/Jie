Public Class FrTj_Yjyl

    Private Sub FrTj_Yjyl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t1.Value = DateAdd(DateInterval.Month, -1, DateTime.Now)

        showSj()

        GroupBox2.Text = "使用原料列表"
    End Sub

    Private Sub showSj()
        '要显示字段的TB
        Dim dt As DataTable = _D.YanStrToDb(_D.YanDttoStr(GetType(en_Yltj).YanEnToTb, "name"))

        'Dim sql As String = ""
        'For Each dr As DataRow In _E.YanEnToTb(GetType(en_LcTableName)).Rows

        '    '该表的所有批号字段
        '    sql = "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao ='" & dr("name") & "' and right(tb_biaozdinf_mx,2)='批号'"
        '    Dim dtPhZd As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        '    sql = "select * from " & dr("name")
        '    Dim dtWl As DataTable = _D.GF_CreateDataSource(sql)
        '    For Each drWl As DataRow In dtWl.Rows
        '        For Each drPhZd As DataRow In dtPhZd.Rows

        '            If dtWl.Columns.IndexOf(drPhZd("tb_biaozdinf_mc") & "t") > 0 Then
        '                Dim drNewTj As DataRow = dt.NewRow
        '                drNewTj(en_Yltj.物料代码) = drWl(drPhZd("tb_biaozdinf_mc"))
        '                drNewTj(en_Yltj.使用量) = drWl(drPhZd("tb_biaozdinf_mc") & "t")
        '                dt.Rows.Add(drNewTj)
        '            End If
        '        Next
        '    Next
        'Next
        'GS_DataGridViewbyDb(show1, dt, True, True)
        'Return

        Dim sql As String = "select * from tb_wp where tb_wp_wpfl='原料'"
        Dim dtYl As DataTable = _D.GF_CreateDataSource(sql)
        For Each drYl As DataRow In dtYl.Rows
            Dim dtTm As DataTable = cl_theCl.getShowDtWltj(drYl("tb_wp_dm"), "", GF_gettrqsj(t1.Text) & " 00:00:00", GF_gettrqsj(t2.Text) & " 23:59:59")
            Dim iSyl As Double = 0
            For Each drTm As DataRow In dtTm.Rows
                iSyl += IIf(IsNumeric(drTm(en_Tjzd.使用量)), drTm(en_Tjzd.使用量), 0)
            Next
            If iSyl > 0 Then
                Dim drNewTj As DataRow = dt.NewRow
                drNewTj(en_Yltj.物料代码) = drYl("tb_wp_dm")
                drNewTj(en_Yltj.物料名称) = drYl("tb_wp_pm")
                drNewTj(en_Yltj.使用量) = iSyl
                dt.Rows.Add(drNewTj)
            End If
        Next
        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("查看使用详情")
        AddHandler menu1.Items(1).Click, AddressOf showSyQk

        GS_DataGridViewbyDb(show1, dt, True, True, menu1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showSj()
    End Sub

    Private Sub showSyQk(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New FrListYl_slqk
        aa.t1.Value = t1.Value
        aa.t2.Value = t2.Value
        aa.m_Dt = cl_theCl.getShowDtWltj(show1.SelectedRows(0).Cells("物料代码").Value, "", GF_gettrqsj(t1.Text) & " 00:00:00", GF_gettrqsj(t2.Text) & " 23:59:59")
        aa.m_Dt.TableName = "使用情况"
        aa.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frSave As New Frbb_save
        frSave.m_bbDt = show1.DataSource()
        frSave.ShowDialog()
    End Sub
End Class