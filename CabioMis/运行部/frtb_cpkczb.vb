Public Class frtb_cpkczb



    Private Sub frtb_cpkczb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        'showkczb()
        Me.tb_cpkczb_rq.Text = Date.Now

        Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
        Dim myread As New Data.OleDb.OleDbCommand()
        Dim rs As Data.OleDb.OleDbDataReader
        cnn.Open()
        myread.Connection = cnn
        myread.CommandText = "select sum(tb_x825p_sykczl) from tb_x825p where tb_x825p_cplb='AOGC'"
        rs = myread.ExecuteReader
        If rs.Read Then
            tb_cpkczb_coil.Text = Null2Zero(rs(0))
        End If
        rs.Close()
        myread.CommandText = "select sum(tb_h195z_sykczl) from vw_h195z where tb_h195z_cplb='AOG40'"
        rs = myread.ExecuteReader
        If rs.Read Then
            tb_cpkczb_foil.Text = Null2zero2(rs(0))
        End If
        rs.Close()

        myread.CommandText = "select sum(tb_x832p_sykczl) from vw_x832p where tb_x832p_cplb in    ('APG10','APG15')"
        rs = myread.ExecuteReader
        If rs.Read Then
            tb_cpkczb_Powder.Text = Null2zero2(rs(0))
        End If
        rs.Close()

        myread.CommandText = "select sum(tb_x832p_sykczl) from vw_x832p where tb_x832p_cplb in    ('APGK','APGB')"
        rs = myread.ExecuteReader
        If rs.Read Then
            tb_cpkczb_gaa.Text = Null2zero2(rs(0))
        End If
        rs.Close()
        myread.CommandText = "select sum(tb_fgyf_zl) from tb_fgyf where tb_fgyf_zl-tb_fgyf_syzl >0"
        rs = myread.ExecuteReader
        If rs.Read Then
            tb_cpkczb_toil.Text = Null2zero2(rs(0))
        End If
        rs.Close() : rs = Nothing
        myread = Nothing : cnn.Close() : cnn = Nothing
        tb_cpkczb_sum.Text = Double.Parse(tb_cpkczb_coil.Text) * 0.93 + (Double.Parse(tb_cpkczb_foil.Text) + Double.Parse(tb_cpkczb_toil.Text)) + Double.Parse(tb_cpkczb_Powder.Text) / 4 + Double.Parse(tb_cpkczb_gaa.Text) / 4
        'tb_cpkczb_sum.Text = Double.Parse(tb_cpkczb_coil.Text) * 0.92 * 0.94 * 0.98 + (Double.Parse(tb_cpkczb_foil.Text) + Double.Parse(tb_cpkczb_toil.Text)) * 0.94 * 0.98 + Double.Parse(tb_cpkczb_Powder.Text) / 4 + Double.Parse(tb_cpkczb_gaa.Text) / 4
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("添加成品库存周报") = False Then
            Exit Sub
        End If ' 判断是否有权限
        '''''''''''''''''''''
        Dim jj As String = GF_addsj("tb_cpkczb", Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_modczsj("tb_cpkczb", "tb_cpkczb_czrgh", jj, G_dlrgh) '更新操作人工号
        GS_storelog3("添加成品库存周报：" & tb_cpkczb_rq.Text, "添加成品库存周报") '储存到日志
        Me.Close()
        'showkczb()
    End Sub


    'Private Sub tb_cpkczb_toil_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cpkczb_toil.TextChanged
    '    Try
    '        tb_cpkczb_sum.Text = tb_cpkczb_coil.Text * 0.92 * 0.94 * 0.98 + (tb_cpkczb_foil.Text + tb_cpkczb_toil.Text) * 0.94 * 0.98 + tb_cpkczb_Powder.Text / 4 + tb_cpkczb_gaa.Text / 4
    '    Catch ex As Exception
    '        tb_cpkczb_sum.Text = ""
    '    End Try
    'End Sub

    Private Sub tb_cpkczb_rq_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.Print(tb_cpkczb_rq.Text)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        'If Me.ListView1.SelectedItems.Count = 0 Then
        '    MsgBox("请选择一条记录再点击删除") : Exit Sub
        'End If
        'If MsgBox("你确定删除本条记录吗？", 1, "提示") <> 1 Then
        '    Exit Sub
        'End If
        ''''''''''''''''''''''''''''''
        'If GF_storelog1("删除成品库存周报") = False Then
        '    Exit Sub
        'End If ' 判断是否有权限
        'GS_upztxx(G_cnnstr, "delect from tb_cpkczb where tb_cpkczb_id=" & Me.ListView1.SelectedItems(0).SubItems(0).Text)
        'GS_storelog3("删除成品库存周报：" & Me.ListView1.SelectedItems(0).SubItems(1).Text, "删除成品库存周报") '储存到日志
        'showkczb()
    End Sub
    'Private Sub showkczb()
    '    Dim cpkcdt As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cpkczb_ID as [id],tb_cpkczb_rq as [日期],tb_cpkczb_coil as [Crude Oil (kg)],tb_cpkczb_foil as [Finished Oil (kg)],tb_cpkczb_toil as [Toll Oil(Kg)],tb_cpkczb_Powder as [Powder(kg)], tb_cpkczb_gaa as [Gold-AA (kg)],tb_cpkczb_sum as [Sum( As 40% AA)] from tb_cpkczb order by tb_cpkczb_ID desc")
    '    Call GS_useviewbydb2(Me.ListView1, cpkcdt, 0, 0)
    'End Sub
End Class