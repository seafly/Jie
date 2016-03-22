Public Class FrChenReturn
    Public bm As String
    Public strid As String

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "毛油"
                bm = "tb_x825pkc"
            Case "成品油"
                bm = "tb_h195zkc"
            Case "成品粉"
                bm = "tb_x832pkc"
        End Select
    End Sub

    Private Sub FrChenReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub

    Private Sub ButtonOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOne.Click

        If StorageOne.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的仓库信息，需要重新输入么？", "仓库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If
        GS_Storage(Me, ButtonOne.Name.Substring(6), Tk, bm, strid, True)
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If RichTextBox1.Text = "" Then
            MessageBox.Show("备注不能为空！")
            Exit Sub
        End If
        If CheckBox1.Checked = False And CheckBox2.Checked = False Then
            MessageBox.Show("请选择要退的库!")
            Exit Sub
        End If
        If StorageOne.Text = "" Then
            MessageBox.Show("没有输入相关的仓库信息!", "仓库输入")
            Exit Sub
        End If
        Dim kc As Double = Double.Parse(Tk.Text)
        returnkc(strid, bm, kc, StorageOne, "成品退库") '成品退库操作

        GS_storelog3("对批号" & ph.Text & "进行成品退库", "成品退库") '储存到日志
        MessageBox.Show("更新成功！")
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        sql = "select " & bm & "_id," & bm & "_kczl," & bm & "_sykczl," & bm & "_ckcl," & bm & "_glid from " & bm & " where " & bm & "_num='" & ph.Text & "'and " & bm & "_mingc='" & ComboBox2.Text & "'and " & bm & "_jiagdm='" & ComboBox3.Text & "'"
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If kk.Rows.Count = 0 Then
            MsgBox("查无此批号") : Exit Sub
        End If
        strid = kk.Rows(0)(0)
        kc.Text = kk.Rows(0)(1) 'ID
        sykc.Text = kk.Rows(0)(2)
        ckcl.Text = kk.Rows(0)(3)
    End Sub
    '成品批号操作
    Private Sub ph_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ph.LostFocus
        Try
            Dim sql As String = "select " & bm & "_mingc from " & bm & " where " & bm & "_num= '" & ph.Text.Trim & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_bcfbd(dt, 0, ComboBox2)

            ComboBox2.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    '代码操作
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            Dim sql As String = "select " & bm & "_jiagdm from " & bm & " where " & bm & "_mingc= '" & sender.Text & "' "
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_bcfbd(dt, 0, ComboBox3)
            ComboBox3.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ph_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ph.MouseLeave
        ph.Text = UCase(ph.Text)
    End Sub
    Private Sub returnkc(ByVal strid As String, ByVal bm As String, ByVal kc As Double, ByVal storage As Control, ByVal sm As String)

        '''''''''''''''''''''''''''更新库存冷库信息
        Dim b As String = Gf_ZdNew(bm, "tb_jch", storage) '新表字段
        Dim a As String = GF_ZlNew(storage) '转为负数

        If ReturnTbname(strid, bm, a, storage.Tag) = False Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''

        Dim sqlkc As String = ""
        Dim aa As String = ""


        If CheckBox1.Checked = True Then
            sqlkc = " update  " & bm & " set " & bm & "_sykczl= " & bm & "_sykczl+" & kc & " where " & bm & "_id='" & strid & "'  "
            GS_upztxx(G_cnnstr, sqlkc)
        End If
        If CheckBox2.Checked = True Then
            sqlkc = " update  " & bm & " set " & bm & "_ckcl= " & bm & "_ckcl+" & kc & " where " & bm & "_id='" & strid & "'  "
            GS_upztxx(G_cnnstr, sqlkc)
        End If

        Dim sql As String = ""
        '更新进出货冷库信息
        sql = " insert into tb_jch (tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_czrgh,tb_jch_mingc,tb_jch_jiagdm,tb_jch_pldh,tb_jch_bz)"
        sql &= " select " & bm & "_cplb," & bm & "_num,'出'," & kc * -1 & ",getdate(),'" & sm & "','" & G_dlrgh & "'," & bm & "_mingc," & bm & "_jiagdm,'" & aa & "','" & RichTextBox1.Text & "'   from "
        sql &= " " & bm & "  where " & bm & "_id='" & strid & "'"
        Dim id As String = GF_upztxx2(G_cnnstr, sql, "tb_jch")
        UpdateTbname(id, "tb_jch", a, b)
    End Sub

End Class