Public Class Frtb_cpqc

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_cpqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Me.tb_h195z_qcsh.SelectedIndex = 1
        Dim czid As String = Labelid.Text
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''2008年10月22日修改
        'If CInt(tb_h195z_c6u.Text) <= 0 Then
        '    MsgBox("请检查输入项目及数据")
        '    tb_h195z_c6u.Focus()
        '    Exit Sub
        'End If
        'If tb_h195z_qcrq.Text = "" Or tb_h195z_c28u.Text = "" Then
        '    MsgBox("过氧化值及时间必须填写") : Exit Sub
        'End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("添加QC") = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''''''''计算开始yangshuai''''''''''''''''''

        '成品油Net(AA = 成品油重量 * (QC输入的成品油AA含量)/100)
        '成品油收率(W) = (成品油重量-返工油量-调配用油）* 100 / 毛油投入量lili
        '成品油收率（AA）=成品油Net AA/毛油Net AA
        '09/11/24成品油收率计算公式有变，应该收率Weight=成品油重量*100/(毛油投入重量+返工油重量+调配用油)
        'If tb_h195z_c6u.Text <> "" Then
        '    Dim cpyNetAA As Decimal = 0
        '    Dim cpyslw As Decimal = 0
        '    Dim cpyslAA As Decimal = 0
        '    '查询成品油重量（Kg）、毛油投入量/每成品批（Kg）、投入毛油Net AA（Kg）、返工油重量（Kg）、调配用油(Kg)
        '    Dim tmpDt As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select tb_h195z_m408e,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_e95w,tb_h195z_tpyy from vw_h195z where tb_h195z_ID=" & Labelid.Text)
        '    'FormatNumber(str / 1024, 2)
        '    If tmpDt.Rows.Count > 0 Then
        '        Try
        '            cpyNetAA = FormatNumber(tmpDt.Rows(0)(0) * tb_h195z_c6u.Text / 100, 2)
        '            cpyslw = FormatNumber(tmpDt.Rows(0)(0) * 100 / (tmpDt.Rows(0)(1) + tmpDt.Rows(0)(3) + tmpDt.Rows(0)(4)), 2)
        '            cpyslAA = FormatNumber(cpyNetAA * 100 / tmpDt.Rows(0)(2), 2)
        '        Catch ex As Exception

        '        End Try

        '        Me.tb_h195z_t673l.Text = cpyNetAA
        '        Me.tb_h195z_u704m.Text = cpyslw
        '        Me.tb_h195z_q554i.Text = cpyslAA
        '    End If
        'End If
        '''''''''''''更细成品油库存信息
        Dim sql As String = "select * from tb_h195zkc  where  tb_h195zkc_num = '" & tb_h195z_num.Text.Trim & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim sql1 As String = "update tb_h195zkc set tb_h195zkc_qcrq= '" & tb_h195z_qcrq.Text & "',tb_h195zkc_y855q= '" & tb_h195z_y855q.Text & "',tb_h195zkc_c6u= " & tb_h195z_c6u.Text & ",tb_h195zkc_c28u= " & tb_h195z_c28u.Text & ", "
            sql1 &= "tb_h195zkc_m403e= " & tb_h195z_m403e.Text & ",tb_h195zkc_b991u= " & tb_h195z_b991u.Text & ",tb_h195zkc_k309c= " & tb_h195z_k309c.Text & ",tb_h195zkc_a948s= " & tb_h195z_a948s.Text & ", "
            sql1 &= "tb_h195zkc_l356d= " & tb_h195z_l356d.Text & ",tb_h195zkc_j268b= " & tb_h195z_j268b.Text & ",tb_h195zkc_o485g= '" & tb_h195z_o485g.Text & "',tb_h195zkc_d36v= '" & tb_h195z_d36v.Text & "', "
            sql1 &= "tb_h195zkc_h192z= " & tb_h195z_h192z.Text & ",tb_h195zkc_g158y= " & tb_h195z_g158y.Text & ",tb_h195zkc_qcsh= '" & tb_h195z_qcsh.Text & "', "
            sql1 &= "tb_h195zkc_u704m= " & tb_h195z_u704m.Text & ",tb_h195zkc_q554i= " & tb_h195z_q554i.Text & ",tb_h195zkc_t673l= " & tb_h195z_t673l.Text & " where tb_h195zkc_num= '" & tb_h195z_num.Text.Trim & "' "
            GS_upztxx(G_cnnstr, sql1)
        End If
        '''''''''''''''''''''''

        ''''''''''''''''''''''''''计算开始yangshuai''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '更新操作人工号
        GS_storelog3("添加成品油QC：" & tb_h195z_num.Text.Trim, "添加QC") '储存到日志
        Me.Close()
    End Sub

  
End Class