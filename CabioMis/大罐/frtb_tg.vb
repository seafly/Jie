Public Class Frtb_tg
    Public _ylnamc, _ylgnamc As String '原料名称、原料罐名称

    '各种原料罐的修改只是表示是否用完，因为配料添加后会不能拆分
    Private Sub frtb_tg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showph()
    End Sub
    '显示新批号
    Private Sub showph()
        Dim qztemp As String = ClassPhgn.ClassPhgn_Get(_ylgnamc, "-") '得到当前批号+1的批号
        If qztemp = "" Then
            MsgBox("批号设定不正确") : Exit Sub
        End If
        tb_tg_num.Text = qztemp
    End Sub
    Private Sub modfikucun() '更新库存
        '''''''''''''''''''''''''''''''''''扣除原料
        GS_kcylkc(tb_tg_ph, Me) '更新原料库存
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        'If GF_storelog1("添加原料罐") = False Then
        '    Exit Sub
        'End If ' 判断是否有权限

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If tb_tg_num.Text.trim  ="" Then
            MsgBox("批号不能为空！")
            Return
        End If

        Dim sql As String = "select * from tb_tg where tb_tg_num='" & tb_tg_num.Text & "'"
        If Cl_DataMag.GF_CreateDataSource(sql).Rows.Count > 0 Then
            MsgBox("已有相同的批号！")
            Return
        End If

        '''''''''判断必填''''''''''''

        If GF_YZSJ(Me, "") = False Then '验证控件
            Exit Sub
        End If

        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_tg_ph, tb_tg_zl, Me)
        ''''''''''''''''''''''''判断原料库存是否够
        Dim ylstr As String = Gf_pdylkc(tb_tg_ph, Me)
        If ylstr <> "" Then '
            MsgBox(ylstr) : Exit Sub
        End If
        ''''''''''''''''''''
        Dim tj As Double = tb_tg_tj.Text '体积
        Dim hsgx As Double = tb_tg_zl.Text / tj '得到换算关系
        tb_tg_hsgx.Text = hsgx
        Dim jj As String = GF_addsj(Labeltb.Text, Me)   '添加数据
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_kcylkc(tb_tg_ph, Me) '更新原料库存
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        GS_storelog3("添加原料罐：" & tb_tg_num.Text.Trim, "添加原料罐") '储存到日志
        MsgBox("完成")
        ClassPhgn.ClassPhgn_SetDqz2(_ylgnamc) '使当前批号+1
        showph() '显示新批号
        showsearch()
        ''''''''''''''''''
    End Sub

    Private Sub tb_tg_ph_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_tg_ph.MouseDoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        Dim yllb As String = tb_tg_yldm.Text
        yllb = DeepCode.DeepDoStr.GF_zhzfccx(yllb)
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a in(" & yllb & ")")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, _ylnamc)
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub BTN_SEARCH_Click(sender As System.Object, e As System.EventArgs) Handles BTN_SEARCH.Click

        showsearch()
    End Sub
    Private Sub showsearch()
        Dim tt1, tt2 As String
        tt1 = DateTimePicker1.Text
        tt2 = DateTimePicker2.Text
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Dim _yldm As String = tb_tg_yldm.Text '原料代码
        Dim sql As String = "select * from tb_tg where tb_tg_yldm in ('" & _yldm & "') and tb_tg_rq between '" & tt1 & "' and '" & tt2 & "' " '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(listview1, dt, "0", True, True)
        GroupBox1.Text = dt.Rows.Count & "条数据,双击修改用完或者未用完"
    End Sub
    Private Sub listview1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listview1.MouseDoubleClick
        With listview1
            If .SelectedRows.Count = 0 Then
                Exit Sub
            End If
            Dim czid As Integer = .SelectedRows(0).Cells("tb_tg_ID").Value
            Dim ph As String = .SelectedRows(0).Cells("tb_tg_num").Value
            Dim oldyw As String = DeepCode.DeepDoStr.Null2String(.SelectedRows(0).Cells("tb_tg_yw").Value) '原来是否用完
            Dim yw As String = "否"
            If oldyw = "否" Then
                yw = "是"
            End If
            If MsgBox("更新" & ph & "用完状态为【" & yw & "】？", 1, "提示") <> MsgBoxResult.Ok Then Return
            GS_upztxx(G_cnnstr, "update tb_tg set tb_tg_yw='" & yw & "' where tb_tg_id=" & czid)
            GS_storelog3("更新" & ph & "用完状态为【" & yw & "】", "更新原料罐") '储存到日志
            MsgBox("完成")
            showsearch()
        End With

    End Sub

    Private Sub BTN_EXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EXCEL.Click
        GS_toexcel(listview1, Me.Text, Me)
    End Sub
End Class