Public Class frnhYearJG
    Dim sfcz As Boolean = False
    Private Sub frnhYearJG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        If sui.Text = "" Or dian.Text = "" Or qi.Text = "" Or caiyou.Text = "" Or trq.Text = "" Then
            MsgBox("请完整填写数据！") : Exit Sub
        End If
        If sfcz = True Then
            sql = "update tb_nhjg set tb_nhjg_ndj=" & sui.Text & " where tb_nhjg_lb='水' and tb_nhjg_nf='" & nian1.Text & "'"
            sql = sql & vbCrLf & "update tb_nhjg set tb_nhjg_ndj=" & dian.Text & " where tb_nhjg_lb='电' and tb_nhjg_nf='" & nian1.Text & "'"
            sql = sql & vbCrLf & "update tb_nhjg set tb_nhjg_ndj=" & qi.Text & " where tb_nhjg_lb='气' and tb_nhjg_nf='" & nian1.Text & "'"
            sql = sql & vbCrLf & "update tb_nhjg set tb_nhjg_ndj=" & caiyou.Text & " where tb_nhjg_lb='油' and tb_nhjg_nf='" & nian1.Text & "'"
            sql = sql & vbCrLf & "update tb_nhjg set tb_nhjg_ndj=" & trq.Text & " where tb_nhjg_lb='天然气' and tb_nhjg_nf='" & nian1.Text & "'"
        Else
            sql = "Insert into tb_nhjg(tb_nhjg_ndj,tb_nhjg_lb,tb_nhjg_nf) values(" & sui.Text & ",'水','" & nian1.Text & "')"
            sql = sql & vbCrLf & "Insert into tb_nhjg(tb_nhjg_ndj,tb_nhjg_lb,tb_nhjg_nf) values(" & dian.Text & ",'电','" & nian1.Text & "')"
            sql = sql & vbCrLf & "Insert into tb_nhjg(tb_nhjg_ndj,tb_nhjg_lb,tb_nhjg_nf) values(" & qi.Text & ",'气','" & nian1.Text & "')"
            sql = sql & vbCrLf & "Insert into tb_nhjg(tb_nhjg_ndj,tb_nhjg_lb,tb_nhjg_nf) values(" & caiyou.Text & ",'油','" & nian1.Text & "')"
            sql = sql & vbCrLf & "Insert into tb_nhjg(tb_nhjg_ndj,tb_nhjg_lb,tb_nhjg_nf) values(" & trq.Text & ",'天然气','" & nian1.Text & "')"
        End If
        '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
        If GF_storelog2("设定能耗价格：" & nian1.Text, "设定能耗价格") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''
        Call GS_upztxx(G_cnnstr, sql)
        MsgBox("操作成功！")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub nian1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian1.SelectedValueChanged
        Dim sql As String = "select tb_nhjg_id,tb_nhjg_ndj,tb_nhjg_lb from tb_nhjg where tb_nhjg_nf='" & nian1.Text & "'"
        Dim nhb As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If nhb.Rows.Count > 0 Then
            sui.Text = GF_cnwithen(nhb, "tb_nhjg_lb='水'", 1)
            dian.Text = GF_cnwithen(nhb, "tb_nhjg_lb='电'", 1)
            qi.Text = GF_cnwithen(nhb, "tb_nhjg_lb='气'", 1)
            caiyou.Text = GF_cnwithen(nhb, "tb_nhjg_lb='油'", 1)
            trq.Text = GF_cnwithen(nhb, "tb_nhjg_lb='天然气'", 1)
            sfcz = True
        Else
            sui.Text = ""
            dian.Text = ""
            qi.Text = ""
            caiyou.Text = ""
            trq.Text = ""
            sfcz = False
        End If

    End Sub

End Class