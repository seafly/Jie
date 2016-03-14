﻿Public Class Frfgyf
    Dim dt As DataTable
    Private Sub Frfgyf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        dt = GF_CreateDataSource(G_cnnstr, "select * from tb_fgyf where tb_fgyf_num2 is null")
        Call GS_wlbktlr2(ComboBox1, dt, 1, "")

        Dim cplb As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cplb_p512h from tb_cplb")
        Call GS_wlbktlr2(tb_x832p_cplb, cplb, 0, "")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim wjgyph As String = ComboBox1.Text
        Dim zl As Double = GF_cnwithen(dt, "tb_fgyf_num='" & wjgyph & "'", 2)
        Dim sj As String = GF_cnwithen(dt, "tb_fgyf_num='" & wjgyph & "'", 3)
        Label8.Text = "重量：" & zl
        Label10.Text = "生成时间：" & sj
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        '''''''''''''''''''''''''''''
        If GF_storelog1("添加成品粉") = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''''''''''''''''''''''''来自零头、零头重量，零头可以不填写
        If GF_YZSJ(Me, "tb_x832p_bz") = False Then '验证控件
            MsgBox("请将数据填写完整") : Exit Sub
        End If
        '''''''''''''''
        '''''''''''''''''''''''''''''''''''''''
        If GF_cxph("tb_x832p_num", tb_x832p_num.Text.Trim) = True Then
            MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
        End If
        '''''''''''''''''''''
        tb_x832p_bz.Text = "（外加工）" & tb_x832p_bz.Text
        Dim jj As String = GF_addsj(Labeltb.Text, Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        Dim sql As String = "update tb_fgyf set tb_fgyf_num2='" & tb_x832p_num.Text.Trim & "' where tb_fgyf_num='" & ComboBox1.Text & "'"
        GS_upztxx(G_cnnstr, sql) '更新外加工油的粉剂批号，便于追踪
        GS_storelog3("添加外加工成品粉：" & tb_x832p_num.Text.Trim, "添加成品粉") '储存到日志
        MsgBox("操作成功")
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

  
End Class