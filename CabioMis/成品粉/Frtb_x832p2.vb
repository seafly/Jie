Public Class Frtb_x832p2

    Private Sub Frtb_x832p2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cplb")
        GS_wlbktlr2(tb_x832p_cplb, dt, 1, "")
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Function ggetph(ByVal str As String) As String
        Dim qztemp As String = ""
        Dim xh1 As String = ""
        Dim qsz As String = ""
        If str = "1号塔成品粉" Then
            qztemp = GF_getxh("1号塔成品粉")
            xh1 = GF_searchchar(qztemp, ",", "left") '序号前面部分
            qsz = GF_searchchar(qztemp, ",", "right") '起始值
        Else
            qztemp = GF_getxh("34号塔成品粉")
            xh1 = GF_searchchar(qztemp, ",", "left") '序号前面部分
            qsz = GF_searchchar(qztemp, ",", "right") '起始值
        End If
        qsz = qsz + 1
        ggetph = xh1 & GF_PF_bzhs(qsz, 6, "0") & "0"
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        tb_x832p_num.Text = ggetph(ComboBox1.Text)
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''
        If GF_YZSJ(Me, "tb_x832p_a920s") = False Then '验证控件
            Exit Sub
        End If
        ''''''''''''''''''''''''
        '每批收率（％）=成品重量（Kg）+取样量（Kg）

        '        然后除以每批投入量(Kg)
        Dim i232a As Decimal = tb_x832p_i232a.Text
        Dim l349d As Decimal = tb_x832p_l349d.Text
        Dim z886r As Decimal = tb_x832p_z886r.Text
        tb_x832p_a920s.Text = FormatNumber((i232a + l349d) / z886r, 2)

        ''''''''''''''''''''''''
        Dim jj As String = GF_addsj("tb_x832p", Me)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''
        Dim idall() As String = Split(tb_x832p_sbid.Text, ",") 'id序列
        Dim phall() As String = Split(tb_x832p_num2.Text, ",") '批号序列
        Dim zlall() As String = Split(TextBox1.Text, ",") '重量系列
        Dim cplball() As String = Split(TextBox2.Text, ",") '产品类别系列
        Dim sql As String = ""
        For i As Integer = 0 To UBound(idall)
            GS_gengsb("tb_x832p", idall(i), "tb_x832p", jj)
            sql = sql & vbCrLf & "update tb_x832p set tb_x832p_sykczl=tb_x832p_sykczl-" & zlall(i) & " where tb_x832p_num='" & phall(i) & "'"
            sql = sql & vbCrLf & "insert into tb_jch (tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh) values"
            sql = sql & " ('" & cplball(i) & "', '" & phall(i) & "','出'," & zlall(i) & ",getdate(),'生产','成品粉混批','" & G_dlrgh & "')"
        Next
        GS_upztxx(G_cnnstr, sql) ''''''''''''这里这里依次更新上步的ID,更新上步表的库存数量,储存出入库表
        MsgBox("成品粉混批成功") : Me.Close()

    End Sub
    '混批窗口
    Private Sub tb_x832p_num2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_num2.DoubleClick
        Dim aa As New frhunpixl : Me.AddOwnedForm(aa)
        aa.ShowDialog()
    End Sub


 
End Class