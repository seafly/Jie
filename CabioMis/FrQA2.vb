Public Class FrQA2

    Private Sub FrQA2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        t2.Items.Add("待定")
        t2.Items.Add("合格")
        t2.Items.Add("不合格")
        t2.Items.Add("冻结")
        Dim sql As String = "select * from " & Labeltb.Text & " where " & Labeltb.Text & "_id=" & Labelid.Text
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_qarq")) = False Then
            t1.Value = dt.Rows(0)(Labeltb.Text & "_qarq")
        End If
        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_qaspjg")) = False Then
            t2.Text = dt.Rows(0)(Labeltb.Text & "_qaspjg")
        End If
        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_qajgsm")) = False Then
            t3.Text = dt.Rows(0)(Labeltb.Text & "_qajgsm")
        End If
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttdel.Click
        If MsgBox("确定删除QA数据吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        ''''''''''''''''''''
        If GF_storelog2("删除QA：" & tb_pljh_num.Text, "删除QA") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update " & biao & " set " & biao & "_qarq=null ," & biao & "_qaspjg='待定'," & biao & "_qajgsm=null"
        sql = sql & " where " & biao & "_id=" & biaoid
        GS_upztxx(G_cnnstr, sql)
        Me.Close()

    End Sub
    Private Sub hyzl() '还原零头重量
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_pljh_ph,tb_pljh_phzl from tb_pljh where tb_pljh_ID=" & Labelid.Text)
        Dim phxl() As String = dt.Rows(0)(0).Split(",") '批号序列
        Dim phzl() As String = dt.Rows(0)(1).Split(",") '重量序列
        Dim sql As String = ""
        For i As Integer = 0 To UBound(phxl)
            sql = sql & "update tb_x832p set tb_x832p_sykczl=tb_x832p_sykczl+" & phzl(i) & " where tb_x832p_num='" & phxl(i) & "' " & vbCrLf
        Next
        GS_upztxx(G_cnnstr, sql)
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim n1 As String = GF_gettrqsj(t1.Text)
        Dim n2 As String = t2.Text
        Dim n3 As String = t3.Text.Trim
        If n2 = "不合格" And n3 = "" Then
            MsgBox(n2 & "请填写原因") : Exit Sub
        End If
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        ''''''''''''''''''''
        If GF_storelog2("添加QA：" & tb_pljh_num.Text, "添加QA") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update " & biao & " set " & biao & "_qarq='" & n1 & "' ," & biao & "_qaspjg='" & n2 & "'," & biao & "_qajgsm='" & n3 & "'," & biao & "_qaczrgh='" & G_dlrgh & "'"
        sql = sql & " where " & biao & "_id=" & biaoid
        GS_upztxx(G_cnnstr, sql)
        If n2 = "不合格" Then
            hyzl() '还原零头重量
        End If
        Me.Close()
    End Sub
End Class