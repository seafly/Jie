Public Class Frtb_fgqc
    Public isxg As Boolean = False '定义是否修改还是新添加
    Private Sub Frtb_fgqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Me.tb_x825p_qcsh.SelectedIndex = 1
        'Dim czid As String = Labelid.Text
        'If isxg = True Then
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        'End If
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''日志与权限判断
        If GF_storelog1("添加QC") = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''''''''''''''''''''''''毛油外观评价(Y/N),毛油色泽-红,毛油色泽-黄,毛油含磷量（ppm）可以填写
        'If GF_YZSJ(Me, "") = False Then '验证控件
        '    Exit Sub
        'End If
        '''''''''''''''

        If tb_x825p_qcrq.Text = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If


        '理论毛油收率字段=（浸出毛油重量（Kg）*（1-水分））/湿菌体重量（Kg）/酶解QC的总油

        'Try
        '    Dim mjph As String = tb_x825p_num2.Text '酶解批号
        '    Dim sql As String = "select tb_meijieQC_zy from vw_meijieQC where tb_meijieQC_num='" & mjph & "'"
        '    Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        '    Dim mjzy As Double = dt1.Rows(0)("tb_meijieQC_zy") '酶解QC的总油
        '    Dim jcmyzl As Double = tb_x825p_s640k.Text '浸出毛油重量
        '    Dim sf As Double = tb_x825p_mynetaa.Text '水分
        '    Dim sjtzl As Double = tb_x825p_r583j.Text '湿菌体重量
        '    Dim llsn As Double = (jcmyzl * (1 - sf)) / (sjtzl * mjzy)
        '    tb_x825p_sn.Text = llsn
        'Catch ex As Exception
        '    MsgBox("理论毛油收率字段=（浸出毛油重量（Kg）*（1-水分））/湿菌体重量（Kg）/酶解QC的总油,请检查各字段的值")
        '    Return
        'End Try

        '''''''''''''''''''''
        ''''''''''''''''''更细毛油库存
        Dim sql As String = "select * from tb_x825pkc  where tb_x825pkc_num = '" & tb_x825p_num.Text.Trim & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim sql1 As String = "update tb_x825pkc set tb_x825pkc_qcrq= '" & tb_x825p_qcrq.Text & "',tb_x825pkc_m387e= " & tb_x825p_m387e.Text & _
                ",tb_x825pkc_r602j='" & tb_x825p_r602j.Text & "'" & _
                ",tb_x825pkc_u699m='" & tb_x825p_u699m.Text & "'" & _
                ",tb_x825pkc_q547i='" & tb_x825p_q547i.Text & "'" & _
                ",tb_x825pkc_o479g='" & tb_x825p_o479g.Text & "'" & _
                ",tb_x825pkc_r600j='" & tb_x825p_r600j.Text & "'" & _
                ",tb_x825pkc_b959t='" & tb_x825p_b959t.Text & "'" & _
                ",tb_x825pkc_t686m='" & tb_x825p_t686m.Text & "'" & _
                ",tb_x825pkc_mynetaa='" & tb_x825p_mynetaa.Text & "'" & _
                ",tb_x825pkc_gjtzy='" & tb_x825p_gjtzy.Text & "'" & _
               ",tb_x825pkc_qcsh='" & tb_x825p_qcsh.Text & "'" & _
                " where tb_x825pkc_num= '" & tb_x825p_num.Text & "'"

            GS_upztxx(G_cnnstr, sql1)
        End If

        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '更新操作人工号
        GS_storelog3("添加毛油QC：" & tb_x825p_num.Text.Trim, "添加QC") '储存到日志
        Me.Close()
    End Sub

  
End Class