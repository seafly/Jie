Public Class Frcpfhp
    Dim dt21 As DataTable
    Public old2(1, 1) As String
    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 1, tb_x832p_cplb)

    End Sub
    Private Sub tb_x832p_cplb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x832p_cplb.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, tb_x832p_mingc)

    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x832p_mingc.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & tb_x832p_cplb.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_x832p_jiagdm)
    End Sub
    Private Sub Frcpfhp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_pljh_num from tb_pljh where tb_pljh_qcsh='是' and tb_pljh_qczx='否' ")
        GS_wlbktlr2(ComboBox1, dt, 0, "")
        tb_x832p_th.SelectedIndex = 0
        dt21 = GF_CreateDataSource(G_cnnstr, "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效'") '得到原料表库存大于0

    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("添加成品粉") = False Then
            Exit Sub
        End If ' 判断是否有权限

        ''''''''''''''''''''''''''''''''''''''''''
        'If GF_YZSJ(Me, "tb_x832p_bz,tb_x832p_scdm,tb_x832p_bzxs") = False Then '验证控件，备注、生产代码。包装形式可以不填写可以不填写
        '    Exit Sub
        'End If
        '''''''''''''''
        If GF_cxph("tb_x832p_num", tb_x832p_num.Text.Trim) = True Then '检测批号重复性
            MsgBox("数据库内已经存在该数据，请重新输入！") : Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘’‘合计汇总
        GS_hjkcylkc(tb_x832p_ybdph, tb_x832p_ybdzl, Me)
        GS_hjkcylkc(tb_x832p_ypybdph, tb_x832p_ypybdzl, Me)
        GS_hjkcylkc(tb_x832p_yjlbdph, tb_x832p_yjlbdzl, Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''
        '每批收率（％）=成品重量（Kg）+取样量（Kg）

        '        然后除以每批投入量(Kg)
        Dim i232a As Decimal = tb_x832p_i232a.Text
        Dim l349d As Decimal = tb_x832p_l349d.Text
        Dim z886r As Decimal = tb_x832p_z886r.Text
        tb_x832p_a920s.Text = FormatNumber((i232a + l349d) / z886r, 2)

        Dim jj As String = GF_addsj(Labeltb.Text, Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据")
        End If
        GS_storelog3("添加混批成品粉：" & tb_x832p_num.Text.Trim, "添加成品粉") '储存到日志
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        'gxdpph(TextBox1.Text) '更新起始值
        Dim Sql As String = "update tb_pljh set tb_pljh_qczx='是',tb_pljh_cpph='" & tb_x832p_num.Text & "',tb_pljh_cpzl=" & tb_x832p_i232a.Text & ",tb_pljh_hpzl=" & tb_x832p_z886r.Text & " where tb_pljh_num='" & ComboBox1.Text & "'"
        GS_upztxx(G_cnnstr, Sql) '更新
        GS_kcylkc(tb_x832p_ybdph, Me) '更新原料库存
        GS_kcylkc(tb_x832p_ypybdph, Me) '更新原料库存
        GS_kcylkc(tb_x832p_yjlbdph, Me) '更新原料库存
        Me.Close()
    End Sub
    Private Function ggetph(ByVal str As String) As String
        Dim xh1 As String = ""
        Dim qsz As String = ""
        If str = "1号塔成品粉" Then
            xh1 = ClassPhgn.ClassPhgn_GetQz("1号塔成品粉") '序号前面部分
            qsz = ClassPhgn.ClassPhgn_GetDqz("1号塔成品粉") '起始值
        Else
            xh1 = ClassPhgn.ClassPhgn_GetQz("34号塔成品粉") '序号前面部分
            qsz = ClassPhgn.ClassPhgn_GetDqz("34号塔成品粉") '起始值
        End If
        qsz = qsz + 1
        ggetph = xh1 & GF_PF_bzhs(qsz, 6, "0") & "0"
    End Function
    Private Sub gxdpph(ByVal str As String) '更新起始值
        Dim qztemp As String = ""
        If str = "1号塔成品粉" Then
            qztemp = "1号塔成品粉"
        Else
            qztemp = "34号塔成品粉"
        End If
        ClassPhgn.ClassPhgn_SetDqz2(qztemp) '更新起始值
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim jhmc As String = ComboBox1.Text
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_pljh where tb_pljh_num='" & jhmc & "'")
        tb_x832p_num2.Text = dt.Rows(0)("tb_pljh_ph").ToString()
        tb_x832p_ltzl.Text = dt.Rows(0)("tb_pljh_phzl").ToString()
        tb_x832p_lzlt.Text = dt.Rows(0)("tb_pljh_ph").ToString()
        tb_x832p_sbid.Text = dt.Rows(0)("tb_pljh_id").ToString()
        tb_x832p_scdm.Text = DeepCode.DeepDoStr.Null2String(dt.Rows(0)("tb_pljh_scdm"))
        If tb_x832p_ltzl.Text <> "" Then
            Dim kk1() As String = tb_x832p_ltzl.Text.Split(CChar(","))
            Dim jl As Double = 0
            For i As Integer = 0 To UBound(kk1)
                jl += Convert.ToDouble(kk1(i).ToString())
            Next
            tb_x832p_z886r.Text = jl.ToString
        End If
    End Sub


    Private Sub tb_x832p_ybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_ybdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, " (tb_i259b_i231a='3.08.002' or tb_i259b_i231a='3.08.101')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "5KG粉剂铝箔袋")
    End Sub

    Private Sub tb_x832p_ypybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_ypybdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, " (tb_i259b_i231a='3.08.003' or tb_i259b_i231a='3.08.102' )")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "1KG粉剂铝箔袋")
    End Sub

    Private Sub tb_x832p_yjlbdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_yjlbdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, " (tb_i259b_i231a='3.08.020' or tb_i259b_i231a='3.08.103')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "优粉铝箔袋")
    End Sub
    

    Private Sub tb_x832p_th_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x832p_th.SelectedIndexChanged
        Select Case tb_x832p_th.Text
            Case "34号塔成品粉"
                Label17.Visible = False
                Label18.Visible = False
                tb_x832p_yjlbdph.Visible = False
                tb_x832p_yjlbdpht.Visible = False
                Label19.Visible = True
                Label20.Visible = True
                Label21.Visible = True
                Label22.Visible = True
                tb_x832p_ybdph.Visible = True
                tb_x832p_ybdpht.Visible = True
                tb_x832p_ypybdph.Visible = True
                tb_x832p_ypybdpht.Visible = True
            Case "5号塔成品粉"
                Label19.Visible = False
                Label20.Visible = False
                Label21.Visible = True
                Label22.Visible = True
                tb_x832p_ybdph.Visible = False
                tb_x832p_ybdpht.Visible = False
                tb_x832p_ypybdph.Visible = True
                tb_x832p_ypybdpht.Visible = True
                Label17.Visible = True
                Label18.Visible = True
                tb_x832p_yjlbdph.Visible = True
                tb_x832p_yjlbdpht.Visible = True

        End Select
    End Sub


End Class