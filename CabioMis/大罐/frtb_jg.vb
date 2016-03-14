Public Class Frtb_jg
    Dim dt As DataTable

    Private Sub frtb_jg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        tb_jg_yw.SelectedIndex = 1
        If Labelid.Text <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            tb_jg_rq.Enabled = False
            tb_jg_ph.Enabled = False
            tb_jg_pht.Enabled = False
            tb_jg_num.Enabled = False
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If GF_storelog1("添加碱罐") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If Labelid.Text <> "" Then
            GS_upztxx(G_cnnstr, "update tb_jg set tb_jg_yw='" & tb_jg_yw.Text & "' where tb_jg_id=" & Labelid.Text)
            Exit Sub
            Me.Close()
        End If

        '''''''''判断必填''''''''''''

        If GF_YZSJ(Me, "") = False Then '验证控件
            Exit Sub
        End If

    
        ''''''''''''''''''''''''判断原料库存是否够
        Dim ylstr As String = Gf_pdylkc(tb_jg_ph, Me)
        If ylstr <> "" Then '
            MsgBox(ylstr) : Exit Sub
        End If
        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_jg_ph, tb_jg_zl, Me)
     
        If GF_cxph("tb_jg_num", tb_jg_num.Text.Trim) = True Then
            MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
        End If
        '''''''''''''''''''''
        Dim jj As String = GF_addsj(Labeltb.Text, Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_kcylkc(tb_jg_ph, Me) '更新原料库存
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        GS_storelog3("添加碱罐：" & tb_jg_num.Text.Trim, "添加碱罐") '储存到日志
        Me.Close()


        ''''''''''''''''''


     


    End Sub

    Private Sub tb_jg_ph_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_jg_ph.MouseDoubleClick
        Dim aa As New Frphzl : Me.AddOwnedForm(aa)
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        Call ltcsh(dt1, aa.ListView1, "氢氧化钠", 5, 6, tb_jg_ph.Text, tb_jg_pht.Text)
        aa.ShowDialog()
        tb_jg_ph.Text = ph.Text : tb_jg_pht.Text = zl.Text
        ph.Text = "" : zl.Text = ""
    End Sub

 
End Class