Public Class FrcpfMIX

    Private Sub FrcpfMIX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        SSSQD.Enabled = False '确定混合
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = TextBox1.Text
        If ph = "" Then
            MsgBox("请输入成品批号！") : Exit Sub
        End If
        Dim sql As String
        Dim dt1 As DataTable
        '以下判断输入的成品批号是否存在
        sql = "select tb_x832p_sykczl as '剩余库存重量',tb_x832p_cplb as '产品类别',tb_x832p_ID from vw_x832p where tb_x832p_num＝'" & ph & "'"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)
        If dt1.Rows.Count > 0 Then
            Label2.Text = dt1.Rows(0)(0) '剩余库存重量
            Label3.Text = dt1.Rows(0)(1) '产品类别
            Label4.Text = dt1.Rows(0)(2) 'id
        Else
            MsgBox("输入的成品批号不存在，请核查") : Exit Sub
        End If
        '
        sql = "select '0' as '混合重量',tb_x832p_num as '成品批号',tb_x832p_sykczl as '剩余库存重量',tb_x832p_cplb as '产品类别',tb_x832p_ID from vw_x832p where tb_x832p_sykczl>0  and tb_x832p_num<>'" & ph & "'"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)
        If dt1.Rows.Count = 0 Then
            MsgBox("没有查询到记录") : Exit Sub
        Else
            Button1.Enabled = False : TextBox1.Enabled = False : SSSQD.Enabled = True
        End If
        Call GS_useviewbydb2(ListView1, dt1, 4, 70)

    End Sub
    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        If e.Label = Nothing Then
            Exit Sub
        End If
        Dim zl As String = e.Label.ToString
        If IsNumeric(zl) = False Then
            MsgBox("应该填写数字") : e.CancelEdit = True : Exit Sub
        End If
        If zl < 0 Then
            MsgBox("应该填写大于等于0的数字。") : e.CancelEdit = True : Exit Sub
        End If
        Dim zsl As Integer = ListView1.Items(e.Item).SubItems(2).Text
        If zl > zsl Then
            MsgBox("应该填写提取重量不能大于本身重量" & zsl & "Kg。") : e.CancelEdit = True : Exit Sub
        End If
        '  ListView1.Items(e.Item).SubItems(3).Text = xyjg
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim sql As String = ""
        Dim kczl As Double, kcph, idall As String '扣除重量序列、批号序列。ID序列
        Dim ph, phid, phlb As String '查询的批号，ID,类别
        kcph = "" : idall = "" : kczl = 0
        phlb = Label3.Text : phid = Label4.Text : ph = TextBox1.Text
        For i As Integer = 0 To ListView1.Items.Count - 1
            If CDbl(ListView1.Items(i).SubItems(1).Text) > 0 Then '扣除重量大于0的才算法
                Dim bid, bph, blb As String, bzl As Double '大于0的ID，批号，产品类别，扣除的重量
                bid = ListView1.Items(i).SubItems(4).Text
                bph = ListView1.Items(i).SubItems(1).Text
                blb = ListView1.Items(i).SubItems(3).Text
                kcph = kcph & bph & ","
                idall = idall & bid & ","
                kczl = kczl + bzl
                GS_gengsb("tb_x832p", bid, "tb_x832p", phid) '更新扣除批号的下步ID
                sql = sql & vbCrLf & "update tb_x832p set tb_x832p_sykczl=tb_x832p_sykczl-" & bzl & " where tb_x832p_num='" & bph & "'"
                sql = sql & vbCrLf & "insert into tb_jch (tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh) values"
                sql = sql & " ('" & blb & "', '" & bph & "','出'," & bzl & ",getdate(),'生产','成品粉混合到:" & ph & "','" & G_dlrgh & "')"
            End If
        Next
        kcph = GF_removedh(kcph) : idall = GF_removedh(idall)

        If kczl = 0 Then
            MsgBox("没有输入混合的重量") : Exit Sub
        End If
        If MsgBox("确定将总重量为" & kczl & "kg的成品粉，混合到原剩余库存为" & Label2.Text & "kg中吗？", 1, "提示？") <> 1 Then
            Exit Sub
        End If
        sql = sql & vbCrLf & "insert into tb_jch (tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh) values"
        sql = sql & " ('" & phlb & "', '" & ph & "','进'," & kczl & ",getdate(),'生产','成品粉混合从:" & kcph & "','" & G_dlrgh & "')"
        sql = sql & vbCrLf & "update b_x832p set tb_x832p_sykczl=tb_x832p_sykczl+" & kczl & " where tb_x832p_num='" & ph & "'"
        GS_upztxx(G_cnnstr, sql) ''''''''''''这里这里依次更新上步的ID,更新上步表的库存数量,储存出入库表
        GS_gengsb2("tb_x832p", phid, "tb_x832p", idall) '更新被混批的上步表及字段
        MsgBox("成品粉混合成功") : Me.Close()
    End Sub
End Class