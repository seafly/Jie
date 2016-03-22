Public Class Frx832p5
    Dim th As String '塔号
    Dim dt As DataTable
    Public m_objMyDataCl As New myDataCl  '窗体数据操作对象
    Private Sub Frtb_x823p_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        m_objMyDataCl.setDataTb("tb_n441f", Labelid.Text)

        Chentextintz3.Text = "0"
        Chentextintz4.Text = "0"
        Chentextintz5.Text = "0"

        GS_qhjd(Me) '回车键切换焦点，备注除外
        th = Label3.Text
        showzhsj2(th, Me, "") '显示最后一条记录的明细
        ''''''''''''''''''''''''''''
        Dim ylsj As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_n441f where tb_n441f_ID=" & Labelid.Text)
     

        tp1.Text = "配料单号：" & ylsj.Rows(0)("tb_n441f_num2") & " ARA油批号：" & ylsj.Rows(0)("tb_n441f_aaph") _
        & " 单批重量：" & ylsj.Rows(0)("tb_n441f_dpzl") & " ARA含量：" & ylsj.Rows(0)("tb_n441f_ara")
        tb_n441f_rqdbft.Text = ylsj.Rows(0)("tb_n441f_rqdbfm")
        tb_n441f_llzt.Text = ylsj.Rows(0)("tb_n441f_llzm")

        tb_n441f_jgrq.Text = Date.Now
        tb_n441f_plksrq.Text = Date.Now

        ''''''''''''''''''''''''''''
        tb_n441f_num.Text = ClassPhgn.ClassPhgn_Get(th, "-") '得到当前批号+1的批号
      
        Dim dt4 As DataTable
        dt4 = GF_CreateDataSource(G_cnnstr, "select tb_l358d_qz,tb_l358d_dqz from tb_l358d where tb_l358d_zd='3号塔小批'")
        Label103.Text = "(当前:" & dt4.Rows(dt4.Rows.Count - 1)(0) & "-" & dt4.Rows(dt4.Rows.Count - 1)(1) & ")"
        dt4 = GF_CreateDataSource(G_cnnstr, "select tb_l358d_qz,tb_l358d_dqz from tb_l358d where tb_l358d_zd='4号塔小批'")
        Label104.Text = "(当前:" & dt4.Rows(dt4.Rows.Count - 1)(0) & "-" & dt4.Rows(dt4.Rows.Count - 1)(1) & ")"
        dt4 = GF_CreateDataSource(G_cnnstr, "select tb_l358d_qz,tb_l358d_dqz from tb_l358d where tb_l358d_zd='5号塔小批'")
        Label105.Text = "(当前:" & dt4.Rows(dt4.Rows.Count - 1)(0) & "-" & dt4.Rows(dt4.Rows.Count - 1)(1) & ")"

        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表

        If tb_n441f_y876r.Text = "0" Then
            tb_n441f_y876r.Text = ""
        End If


    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If CInt(Chentextintz3.Text) + CInt(Chentextintz4.Text) + CInt(Chentextintz5.Text) <= 0 Then
            MsgBox("小批数合计不能为0！")
            Return
        End If

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("添加粉剂配料批") = False Then
            Exit Sub
        End If ' 判断是否有权限
        '''''''''判断必填''''''''''''

        'If GF_YZSJ(Me, "tb_n441f_y875r,tb_n441f_i245a,tb_n441f_i245at,tb_n441f_y875rt,tb_n441f_a943s,tb_n441f_a943st,tb_n441f_y876r,tb_n441f_e95w") = False Then '验证控件
        '    Exit Sub
        'End If
        '验证返工填写得是否正确()
        If GF_yzfglr(tb_n441f_y876r.Text.Trim, tb_n441f_e95w.Text.Trim) = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''''判断原料库存是否够
        Dim ylstr As String = ""
        ylstr = ylstr & Gf_pdylkc(tb_n441f_e88w, Me) & Gf_pdylkc(tb_n441f_v734n, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_j291b, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_y875r, Me) & Gf_pdylkc(tb_n441f_i245a, Me)
        ylstr = ylstr & Gf_pdylkc(tb_n441f_rqdbf, Me) & Gf_pdylkc(tb_n441f_llz, Me)
        If ylstr <> "" Then
            MsgBox(ylstr)
            Exit Sub
        End If
        ''''''''''''''''''''合计汇总    
        GS_hjkcylkc(tb_n441f_e88w, tb_n441f_d66v, Me)
        GS_hjkcylkc(tb_n441f_v734n, tb_n441f_t685m, Me)
        GS_hjkcylkc(tb_n441f_j291b, tb_n441f_q535i, Me)
        GS_hjkcylkc(tb_n441f_y875r, tb_n441f_u693m, Me)
        GS_hjkcylkc(tb_n441f_i245a, tb_n441f_h201z, Me)
        GS_hjkcylkc(tb_n441f_rqdbf, tb_n441f_rqdbfm, Me)
        GS_hjkcylkc(tb_n441f_llz, tb_n441f_llzm, Me)
        '’‘’‘’‘’‘’‘’‘’‘’
        If _D.Gs_updasj(Me, m_objMyDataCl.m_Ds.Tables(Labeltb.Text), True) = 0 Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        'If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
        '    MsgBox("请检查输入项目及数据") : Exit Sub
        'End If
        '''''''''''''''''''''''''更新原料库存
        GS_kcylkc(tb_n441f_e88w, Me)
        GS_kcylkc(tb_n441f_v734n, Me)
        GS_kcylkc(tb_n441f_j291b, Me)
        GS_kcylkc(tb_n441f_y875r, Me)
        GS_kcylkc(tb_n441f_i245a, Me)
        GS_kcylkc(tb_n441f_rqdbf, Me)
        GS_kcylkc(tb_n441f_llz, Me)

        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
        GS_storelog3("添加粉剂配料批：" & tb_n441f_num.Text, "添加粉剂配料批") '储存到日志
        '''''''''''''''''''''''''''
        '以下添加粉剂小批记录
        Dim sql As String = ""
        Dim idAll As String = ""

        '优粉小批生产
        If th = "5号塔粉剂配料批" Then
            If CDbl(Chentextintz3.Text) > 0 Then
                Dim qztemp As String = ClassPhgn.ClassPhgn_GetQz("3号塔小批")
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                ''''''''''''''''''''''''''''''''''''''
                Dim xh1 As String = qztemp '序号前面部分         
                Dim qsz1 As Integer = Convert.ToInt32(ClassPhgn.ClassPhgn_GetDqz("3号塔小批").ToString()) '起始值

                For i As Integer = 1 To Convert.ToInt32(Chentextintz3.Text) '小批批次编号i
                    Dim xph As String = ""
                    While True
                        qsz1 = qsz1 + 1
                        xph = xh1 & "-" & qsz1
                        sql = "select * from tb_p525h where tb_p525h_num='" & xph & "'"
                        If sql.YanGetDb.Rows.Count = 0 Then
                            Exit While
                        End If
                    End While
                    sql = "insert into tb_p525h(tb_p525h_num2,tb_p525h_num,tb_p525h_th,tb_p525h_sbtb,tb_p525h_sbid,tb_p525h_cplb,tb_p525h_jiagdm,tb_p525h_mingc,tb_p525h_jgrq,tb_p525h_b967t) values('" & tb_n441f_num.Text & "','" & xph & "','3号塔','" & Labeltb.Text & "','" & Labelid.Text & "','" & tb_n441f_cplb.Text & "','" & tb_n441f_jiagdm.Text & "','" & tb_n441f_mingc.Text & "',getdate(),getdate()) "
                    idAll = idAll & GF_upztxx2(G_cnnstr, sql, "tb_p525h") & ","
                Next
                ClassPhgn.ClassPhgn_SetDqz("3号塔小批", qsz1) '更新起始值
            End If
            If CDbl(Chentextintz4.Text) > 0 Then
                Dim qztemp As String = ClassPhgn.ClassPhgn_GetQz("4号塔小批")
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                ''''''''''''''''''''''''''''''''''''''
                Dim xh1 As String = qztemp '序号前面部分         
                Dim qsz1 As Integer = ClassPhgn.ClassPhgn_GetDqz("4号塔小批") '起始值

                For i As Integer = 1 To CInt(Chentextintz4.Text) '小批批次编号i
                    Dim xph As String = ""
                    While True
                        qsz1 = qsz1 + 1
                        xph = xh1 & "-" & qsz1
                        sql = "select * from tb_p525h where tb_p525h_num='" & xph & "'"
                        If sql.YanGetDb.Rows.Count = 0 Then
                            Exit While
                        End If
                    End While

                    sql = "insert into tb_p525h(tb_p525h_num2,tb_p525h_num,tb_p525h_th,tb_p525h_sbtb,tb_p525h_sbid,tb_p525h_cplb,tb_p525h_jiagdm,tb_p525h_mingc,tb_p525h_jgrq,tb_p525h_b967t) values('" & tb_n441f_num.Text & "','" & xph & "','4号塔','" & Labeltb.Text & "','" & Labelid.Text & "','" & tb_n441f_cplb.Text & "','" & tb_n441f_jiagdm.Text & "','" & tb_n441f_mingc.Text & "',getdate(),getdate()) "
                    idAll = idAll & GF_upztxx2(G_cnnstr, sql, "tb_p525h") & ","
                Next
                ClassPhgn.ClassPhgn_SetDqz("4号塔小批", qsz1) '更新起始值
            End If
            If CDbl(Chentextintz5.Text) > 0 Then
                Dim qztemp As String = ClassPhgn.ClassPhgn_GetQz("5号塔小批")
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                ''''''''''''''''''''''''''''''''''''''
                Dim xh1 As String = qztemp '序号前面部分         
                Dim qsz1 As Integer = ClassPhgn.ClassPhgn_GetDqz("5号塔小批") '起始值

                For i As Integer = 1 To CInt(Chentextintz5.Text) '小批批次编号i
                    Dim xph As String = ""
                    While True
                        qsz1 = qsz1 + 1
                        xph = xh1 & "-" & qsz1
                        sql = "select * from tb_p525h where tb_p525h_num='" & xph & "'"
                        If sql.YanGetDb.Rows.Count = 0 Then
                            Exit While
                        End If
                    End While

                    sql = "insert into tb_p525h(tb_p525h_num2,tb_p525h_num,tb_p525h_th,tb_p525h_sbtb,tb_p525h_sbid,tb_p525h_cplb,tb_p525h_jiagdm,tb_p525h_mingc,tb_p525h_jgrq,tb_p525h_b967t) values('" & tb_n441f_num.Text & "','" & xph & "','5号塔','" & Labeltb.Text & "','" & Labelid.Text & "','" & tb_n441f_cplb.Text & "','" & tb_n441f_jiagdm.Text & "','" & tb_n441f_mingc.Text & "',getdate(),getdate()) "
                    idAll = idAll & GF_upztxx2(G_cnnstr, sql, "tb_p525h") & ","
                Next
                ClassPhgn.ClassPhgn_SetDqz("5号塔小批", qsz1) '更新起始值
            End If
        End If
        ClassPhgn.ClassPhgn_SetDqz2(th) '使配料批表当前批号+1

        '更新配料批表的下步表，id字段
        sql = "update tb_n441f set tb_n441f_xbtb='tb_p525h',tb_n441f_glid='" & idAll & "' where tb_n441f_ID=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        Me.Close()
    End Sub
    Private Sub tb_n441f_j291b_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_j291b.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "维生素C钠")
    End Sub

    Private Sub tb_n441f_v734n_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_v734n.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "柠檬酸钠")
    End Sub

    Private Sub tb_n441f_e88w_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_n441f_e88w.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "酪朊酸钠")
    End Sub
    Private Sub tb_n441f_y875r_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_n441f_y875r.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " tb_i259b_i231a='2.04.010' or tb_i259b_i231a='2.04.018'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "固体玉米糖浆")
    End Sub
    '显示最后一条记录的明细
    Private Sub showzhsj2(ByVal str As String, ByVal str2 As Form, ByVal str3 As String)
        '分别代表表名。窗体名,str3代表例外控件
        ' ''str3 = GF_qhjdh(str3)
        ' ''Dim th As String = "34号塔"
        ' ''If str = "1号塔粉剂配料批" Then
        ' ''    th = "1号塔"
        ' ''End If
        'MsgBox(Labelid.Text)
        Dim sql As String = "select  * from tb_n441f where tb_n441f_id=" & Labelid.Text
        Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dttemp.Rows.Count > 0 Then
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS As ADODB.Recordset = cnn.Execute(sql)
            Dim j As Integer, nn As DateTimePicker
            With str2
                For j = 0 To .Controls.Count - 1
                    Dim zdsz As String = .Controls(j).Name
                    If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And .Controls(j).Visible = True And InStr(str3, GF_qhjdh(zdsz)) = 0 Then
                        Dim sj As String = ""
                        If IsDBNull(RS(zdsz).value) = False Then
                            sj = RS(zdsz).Value.ToString()
                        End If
                        If .Controls(j).GetType.Name = "chendatepick" Then
                            sj = Date.Now.ToString("yyyy-MM-dd hh:mm:ss")
                        End If
                        If .Controls(j).GetType.Name = "DateTimePicker" Then
                            nn = CType(.Controls(j), DateTimePicker)
                            If sj <> "" Then
                                nn.Text = sj
                                If nn.ShowCheckBox = True Then
                                    nn.Checked = True
                                End If

                            Else

                                If nn.ShowCheckBox = True Then
                                    nn.Checked = False
                                End If
                            End If
                        End If
                        .Controls(j).Text = sj
                    End If
                Next
            End With
            RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
            '  Gs_showsj(str, str2, dttemp.Rows(0)(0))
        End If
    End Sub

    Private Sub tb_n441f_rqdbf_DoubleClick(sender As System.Object, e As System.EventArgs) Handles tb_n441f_rqdbf.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.013' or tb_i259b_i231a='2.04.015' or tb_i259b_i231a='2.04.021' or tb_i259b_i231a='2.04.022' or tb_i259b_i231a='2.04.023'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "乳清蛋白粉")
    End Sub
    Private Sub tb_n441f_llz_DoubleClick(sender As System.Object, e As System.EventArgs) Handles tb_n441f_llz.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.042'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "卵磷脂")
    End Sub
    Private Sub tb_n441f_i245a_DoubleClick(sender As System.Object, e As System.EventArgs) Handles tb_n441f_i245a.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.001'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "葡萄糖")
    End Sub

End Class