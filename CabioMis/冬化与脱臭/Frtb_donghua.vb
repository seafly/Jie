Public Class Frtb_donghua
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub Frtb_donghua_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        If Labelid.Text <> "" Then '修改的情况'修改时候批号不能修改
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        Else '新增
            ComboBox1.Text = "冬化"
            tb_donghua_num.Text = ClassPhgn.ClassPhgn_Get(ComboBox1.Text, "-") '得到当前批号+1的批号
            AddHandler tb_donghua_num.DoubleClick,
                Sub()
                    ClassPhgn.ClassPhgn_SetDqz2(ComboBox1.Text) '使当前批号+1
                    tb_donghua_num.Text = ClassPhgn.ClassPhgn_Get(ComboBox1.Text, "-") '得到当前批号+1的批号
                End Sub
        End If

        If Labelid2.Text = "" Then
            ComboBox1.Enabled=False
        End If

        AddHandler tb_donghua_fgfph.DoubleClick, AddressOf addFangongfen
    End Sub
    Private Sub addFangongfen(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select 0 as 使用重量,tb_h195zkc_num,tb_h195zkc_cjcl,tb_h195zkc_jgrq,'KG' as 单位,tb_h195zkc_ID,tb_h195zkc_cplb,tb_h195zkc_mingc  from tb_h195zkc where " &
         "tb_h195zkc_cjcl>0 and tb_h195zkc_qaytjy='返工'"
        Dim dt As DataTable = sql.YanGetDb

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "返工油"
        objClpam.phName = "tb_donghua_fgfph"
        objClpam.bsName = "tb_donghua_fgfbs"
        objClpam.callbackFn = Function(pTb As DataTable, pfr As frYanPhzl) As Boolean
                                  pfr.setOwnerVa()
                                  If tb_donghua_sbtb.Text = "tb_h195zkc" Then
                                      Me.tb_donghua_sbid.Text = pfr.m_rvBs
                                  End If
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''备注可不填写
        If tb_donghua_num2.Text = "" And tb_donghua_fgfph.Text="" Then
            MsgBox("没有选择批次的情况下返工油不能为空！",MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If GF_YZSJ3(Me, "tb_donghua_num,tb_donghua_zl") = False Then '验证控件
            Exit Sub
        End If
        ''''''''''''''''''''
        If ComboBox1.Text = "冬化" Then
            '如果有本表ID，那么是修改
            If Labelid.Text <> "" Then
                '''''''''''''''''''''''''''''
                'If GF_storelog1("修改二级罐") = False Then
                '    Exit Sub
                'End If ' 判断是否有权限

                If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                    MsgBox("请检查输入项目及数据")
                    Exit Sub
                Else
                    GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                    GS_storelog3("修改冬化：" & tb_donghua_num.Text.Trim, "修改冬化") '储存到日志
                End If
            Else
                If GF_cxph("tb_donghua_num", tb_donghua_num.Text.Trim) = True Then '检测批号重复性
                    MsgBox("数据库内已经存在该数据，请重新输入！") : Exit Sub
                End If
                '添加冬化
                Dim jj As String = GF_addsj(Labeltb.Text, Me)
                If jj = "" Then
                    MsgBox("请检查输入项目及数据") : Exit Sub
                Else
                    ClassPhgn.ClassPhgn_SetDqz2("冬化") '使当前批号+1
                    '更新返工油库存
                    GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_donghua_fgfbs, tb_donghua_fgfpht, pBszd:="id")
                    '上步表，上步ID，下步表，下步ID
                    GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj) '更新上步流程的下步表及下步ID字段
                    GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
                    GS_storelog3("添加冬化：" & tb_donghua_num.Text.Trim, "添加冬化") '储存到日志
                End If
            End If
        Else
            '如果有本表ID，那么是修改
            If Labelid.Text <> "" Then
                '''''''''''''''''''''''''''''
                'If GF_storelog1("修改二级罐") = False Then
                '    Exit Sub
                'End If ' 判断是否有权限

                If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                    MsgBox("请检查输入项目及数据")
                    Exit Sub
                Else
                    GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                    GS_storelog3("修改脱臭：" & tb_donghua_num.Text.Trim, "修改脱臭") '储存到日志
                End If
            Else
                '添加脱臭
                Dim sql As String = "insert into tb_tuoxiu(tb_tuoxiu_num,tb_tuoxiu_num2,tb_tuoxiu_jgrq,tb_tuoxiu_bz,tb_tuoxiu_sbtb,tb_tuoxiu_sbid,tb_tuoxiu_zl,tb_tuoxiu_mytrl) "
                sql &= " values('" & tb_donghua_num.Text & "','" & tb_donghua_num2.Text & "','" & tb_donghua_jgrq.Text & "','" & tb_donghua_bz.Text & "'," & _
                "'" & Labeltb2.Text & "','" & Labelid2.Text & "','" & tb_donghua_zl.Text & "'," & tb_tuoxiu_mytrl.Text & ")"
                Dim jj As String = DeepCode.DeepDoDataTable.GF_upztxx2(G_cnnstr, sql, "tb_tuoxiu")
                If jj = "" Then
                    MsgBox("请检查输入项目及数据") : Exit Sub
                Else
                    ClassPhgn.ClassPhgn_SetDqz2("脱臭") '使当前批号+1
                    '上步表，上步ID，下不表，下步ID
                    GS_gengsb(Labeltb2.Text, Labelid2.Text, "tb_tuoxiu", jj) '更新上步流程的下步表及下步ID字段
                    GS_modczsj("tb_tuoxiu", "tb_tuoxiu_czrgh", jj, G_dlrgh) '更新操作人工号
                    GS_storelog3("添加脱臭：" & tb_donghua_num.Text.Trim, "添加脱臭") '储存到日志
                End If
            End If
        End If

        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "冬化" Then
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("冬化", "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            tb_donghua_num.Text = qztemp
            Label2.Text = "冬化批号"
        Else
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("脱臭", "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            tb_donghua_num.Text = qztemp
            Label2.Text = "脱臭批号"
        End If
    End Sub
End Class