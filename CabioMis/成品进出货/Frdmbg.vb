Public Class Frdmbg
    Private bm As String
    Private Sub Frdmbg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ComboBox1.SelectedIndex = 0
        '‘’‘
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Textbox4.Items.Clear()
        If kk.Rows.Count > 0 Then
            For i As Integer = 0 To kk.Rows.Count - 1
                Textbox4.Items.Add(kk.Rows(i)(1))
            Next
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim sql As String = "update " & bm & "  set  " & bm & "_mingc ='" & Textbox2.Text & "'," & bm & "_jiagdm='" & Textbox3.Text & "'," & bm & "_yg='" & Textbox4.Text & "'where " & bm & "_ID= " & ph.Tag & " "

            GS_upztxx(G_cnnstr, sql)
            GS_storelog3(ComboBox1.Text & "代码转换；ID：" & ph.Tag & "；" & "批号：" & ph.Text & "；" & "产品代码：" & Textbox2.Tag & "；加工代码：" & Textbox3.Tag & "；用途：" & Textbox4.Tag & "；改后产品代码：" & Textbox2.Text & "；改后加工代码：" & Textbox3.Text & "；改后用途：" & Textbox4.Text & "；备注：" & TextBox5.Text, "转换代码操作") '储存到日志
            MsgBox("更新成功！") : Me.Close()
        Catch ex As Exception
            MsgBox("请正确填写项目") : Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='" & ComboBox1.Text & "' and tb_cpdmhz_cplx='" & TextBox1.Text & "' ")
        GS_bcfbd(dt, 2, Textbox2) '产品代码

        Dim ph1 As String = ph.Text.Trim
        If ph1 = "" Then '判断批号不为空 
            Exit Sub
        End If
        Select Case ComboBox1.Text
            Case "毛油" : bm = "tb_x825p"
            Case "成品油" : bm = "tb_h195z"
            Case "成品粉" : bm = "tb_x832p"
        End Select
        Dim sql As String = "select " & bm & "_ID," & bm & "_mingc," & bm & "_jiagdm," & bm & "_yg," & bm & "_cplb from " & bm & " where " & bm & "_num= '" & ph1 & "'"
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, sql) '判断有没有批号
        If kk.Rows.Count = 0 Then
            MsgBox("查无此批号") : Exit Sub
        End If
        ph.Tag = Null2String(kk.Rows(0)(0)) 'ID
        Textbox2.Tag = Null2String(kk.Rows(0)(1)) '产品代码
        Textbox3.Tag = Null2String(kk.Rows(0)(2)) '加工代码
        Textbox4.Tag = Null2String(kk.Rows(0)(3)) '用途

        Textbox2.Text = Null2String(kk.Rows(0)(1)) '产品代码
        Textbox3.Text = Null2String(kk.Rows(0)(2)) '加工代码
        Textbox4.Text = Null2String(kk.Rows(0)(3)) '用途
        TextBox1.Text = Null2String(kk.Rows(0)(4)) '产品类型
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Textbox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textbox2.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='" & ComboBox1.Text & "' and tb_cpdmhz_cplx='" & TextBox1.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, Textbox3) '加工代码
    End Sub
  
End Class