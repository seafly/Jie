Public Class Frtb_jg2
    Dim dt As DataTable
    Private Sub frtb_jg2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
    End Sub

    Private Sub tb_jg2_ph_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_jg2_ph.MouseDoubleClick
        Dim aa As New Frphzl : Me.AddOwnedForm(aa)
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        Call ltcsh(dt1, aa.ListView1, "氢氧化钠", 5, 6, tb_jg2_ph.Text, tb_jg2_pht.Text)
        aa.ShowDialog()
        tb_jg2_ph.Text = ph.Text : tb_jg2_pht.Text = zl.Text
        ph.Text = "" : zl.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GF_storelog1("添加CIP碱罐") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''

        If GF_YZSJ(Me, "") = False Then '验证控件
            Exit Sub
        End If

        ''''''''''''''''''''''''
        ''''''''''''''''''''''''判断原料库存是否够
        Dim ylstr As String = Gf_pdylkc(tb_jg2_ph, Me)
        If ylstr <> "" Then '
            MsgBox(ylstr) : Exit Sub
        End If
        GS_hjkcylkc(tb_jg2_ph, tb_jg2_zl, Me)
        ''''''''''''''''''''合计汇总
        '''''''''''''''''''''
        Dim jj As String = GF_addsj(Labeltb.Text, Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_kcylkc(tb_jg2_ph, Me) '更新原料库存
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        GS_storelog3("添加CIP碱罐：" & tb_jg2_ph.Text.Trim, "添加CIP碱罐") '储存到日志
        Me.Close()


        '''''''''''''''''
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class