Public Class FrInternal
    Public bm As String
    Public fromzdm As String
    Public Tozdm As String
    Public id As String
    Public dttemp As DataTable
    Private Sub FrInternal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '朱露帆于2012年3月31日 开发成品内部转库
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        bm = "tb_h195zkc"
        showsj()
        Label7.Visible = False
        TextBox2.Visible = False
    End Sub

    '转库
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If id <> "" And Tozdm <> "" And fromzdm <> "" And TextBox1.Text <> "" Then
            Dim sql As String = "select * from " & bm & " where " & bm & "_id ='" & id & ""
            Dim dt As DataTable = sql.YanGetDb
            dim zl As String=""
            Select Case ComboBox4.Text
                Case "葛店冷库"
                    zl = dt.YanDtValue2(bm & "_kdlk")
                Case "庙山冷库"
                    zl = dt.YanDtValue2(bm & "_storagemslk")
                Case "外租冷库"
                    zl = dt.YanDtValue2(bm & "_storagewzlk")
                Case "北方办"
                    zl = dt.YanDtValue2(bm & "_bfb")
            End Select
            If _S.YanFormatNum2(TextBox1.Text) < _S.YanFormatNum2(zl) Then
                MsgBox("转出重量不能大于仓位重量！")
                Return
            End If

            Dim bz As String = ComboBox4.Text & ",转" & TextBox1.Text & ",至" & ComboBox5.Text
            sql = "update " & bm & " set " & fromzdm & " = " & fromzdm & "-" & TextBox1.Text & ",  "
            sql &= "  " & Tozdm & " =" & Tozdm & " +" & TextBox1.Text & " where " & bm & "_id ='" & id & "' " & vbCrLf
            sql &= " insert into tb_jch (tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_czrgh,tb_jch_mingc,tb_jch_jiagdm,tb_jch_bz)  "
            sql &= "  values ('" & cplb.Text & "', '" & ph.Text & "','内部转库'," & TextBox1.Text & ",getdate(),'" & G_dlrgh & "' , '" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & bz & "') "
            GS_upztxx(G_cnnstr, sql)

            Dim sql0 As String = ""
            Select Case ComboBox5.Text
                Case "葛店冷库"
                    sql0 = "update " & bm & " set " & bm & "_cw='" & TextBox2.Text & "' where " & bm & "_id ='" & id & "'"
                Case "庙山冷库"
                    sql0 = "update " & bm & " set " & bm & "_mscw='" & TextBox2.Text & "' where " & bm & "_id ='" & id & "'"
                Case "外租冷库"
                    sql0 = "update " & bm & " set " & bm & "_wzcw='" & TextBox2.Text & "' where " & bm & "_id ='" & id & "'"
                Case "北方办"
                    sql0 = "update " & bm & " set " & bm & "_bfcw='" & TextBox2.Text & "' where " & bm & "_id ='" & id & "'"
            End Select
            GS_upztxx(G_cnnstr, sql0)
            If ComboBox4.Text = "葛店冷库" Then
                sql0 = "update " & bm & " set " & bm & "_cw=0  where " & bm & "_id ='" & id & "'   and  " & bm & "_kdlk=0"
                GS_upztxx(G_cnnstr, sql0)
            End If
        End If
        Dim store As String = "产品:" & ComboBox1.Text & "批号:" & ph.Text & "产品代码:" & ComboBox2.Text & "加工代码: " & ComboBox3.Text & vbCrLf
        store &= "由仓库:" & ComboBox4.Text & "转:" & TextBox1.Text & "到仓库:" & ComboBox5.Text
        GS_storelog3(store, "内部转库") '储存到日志
        MessageBox.Show("转库成功！")
        Me.Close()
    End Sub
    '切换表
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "成品油"
                bm = "tb_h195zkc"
            Case "成品粉"
                bm = "tb_x832pkc"
            Case "毛油"
                bm = "tb_x825pkc"
        End Select
        showsj()
    End Sub
    '填充产品代码
    Private Sub ph_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ph.LostFocus

        Dim sql As String = "select " & bm & "_mingc from " & bm & " where " & bm & "_num= '" & ph.Text.Trim & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_bcfbd(dt, 0, ComboBox2)


    End Sub

    '填充加工代码
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim sql As String = "select " & bm & "_jiagdm from " & bm & " where " & bm & "_mingc= '" & sender.Text & "' "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_bcfbd(dt, 0, ComboBox3)


    End Sub
    '选择冷库
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If id <> "" Then
            fromzdm = GF_cnwithen(dttemp, "tb_biaozdinf_mx='" & ComboBox4.Text & "'", 1)
            Dim sql As String = "select " & fromzdm & " from  " & bm & "  where " & bm & "_id ='" & id & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Label3.Text = dt.Rows(0)(0).ToString
        End If

    End Sub
    '选择冷库
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged

        If id <> "" Then
            Tozdm = GF_cnwithen(dttemp, "tb_biaozdinf_mx='" & ComboBox5.Text & "'", 1)
            Dim sql As String = "select " & Tozdm & "," & bm & "_cw from  " & bm & " where  " & bm & "_id ='" & id & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count > 0 Then
                Label4.Text = dt.Rows(0)(0).ToString
                TextBox2.Text = dt.Rows(0)(bm & "_cw").ToString
            End If
        End If

        Label7.Visible = True
        TextBox2.Visible = True

    End Sub
    Private Sub showsj()
        Dim sql As String = "select tb_biaozdinf_mx,tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao='" & bm & "' and (tb_biaozdinf_mc like '%bfb%'or tb_biaozdinf_mc like '%kdlk%' or tb_biaozdinf_mc like '%storage%') "
        dttemp = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(ComboBox4, dttemp, 0, "")
        GS_wlbktlr2(ComboBox5, dttemp, 0, "")
        ComboBox4.Text = ""
        ComboBox5.Text = ""
    End Sub
    '加工代码操作
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim Sql = "select * from " & bm & " where " & bm & "_num='" & ph.Text.Trim & "'  and  " & bm & "_mingc='" & ComboBox2.Text & "'and " & bm & "_jiagdm='" & ComboBox3.Text & "'"
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        If kk.Rows.Count = 0 Then
            MsgBox("查无此批号") : Exit Sub
        Else
            cplb.Text = kk.Rows(0)(bm & "_cplb")
            id = kk.Rows(0)(bm & "_id")
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub ph_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ph.MouseLeave

        ph.Text = UCase(ph.Text)
    End Sub


End Class