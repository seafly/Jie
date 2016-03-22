Public Class FrModsykc
    Private bm, zdm As String
    Private Sub FrModsykc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph1 As String = ph.Text.Trim
        If ph1 = "" Then
            Exit Sub
        End If
        Select Case ComboBox1.Text
            Case "毛油" : bm = "tb_x825p" : zdm = bm & "_sykczl"
            Case "成品油" : bm = "tb_h195z" : zdm = bm & "_sykczl"
            Case "成品粉" : bm = "tb_x832p" : zdm = bm & "_sykczl"
            Case "原料" : bm = "tb_i259b" : zdm = "tb_i259b_p518h"
        End Select
        Dim sql As String
        Select Case bm
            Case "tb_x825p", "tb_h195z", "tb_x832p"
                sql = "select " & zdm & "," & bm & "_bf" & "," & bm & "_bfmx" & "," & bm & "_ckcl" & "  from " & bm & " where " & bm & "_num='" & ph1 & "'"
                Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                If kk.Rows.Count = 0 Then
                    MsgBox("查无此批号") : Exit Sub
                End If
                ckcl.Enabled = True : ckcl.Text = Null2zero2(kk.Rows(0)(3))
                sykc.Text = kk.Rows(0)(0) : Textbfs.Text = kk.Rows(0)(1) : TextBoxbfmx.Text = Null2String(kk.Rows(0)(2))
            Case "tb_i259b"
                sql = "select " & zdm & "," & bm & "_bf" & "," & bm & "_bfmx" & "  from " & bm & " where " & bm & "_num='" & ph1 & "'"
                Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                If kk.Rows.Count = 0 Then
                    MsgBox("查无此批号") : Exit Sub
                End If
                ckcl.Enabled = False
                sykc.Text = kk.Rows(0)(0) : Textbfs.Text = kk.Rows(0)(1) : TextBoxbfmx.Text = Null2String(kk.Rows(0)(2))
        End Select

        ph.Enabled = False : ComboBox1.Enabled = False : Button1.Enabled = False
        sykc.Enabled = True : SSSQD.Enabled = True : TextBox1.Enabled = True
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("更新库存数据可能会对整个生产流程产生影响，确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("修改剩余库存") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If TextBox1.Text.Trim = "" Then
            MsgBox("必须填写修改原因！") : Exit Sub
        End If
        Dim sykcsl, bfs As Double
        Try
            sykcsl = sykc.Text : bfs = Textbfs.Text
        Catch ex As Exception
            MsgBox("请正确填写数字")
        End Try
        Dim ph1 As String = ph.Text.Trim
        Dim sm As String = TextBox1.Text.Trim : sm = Replace(sm, ",", "，")
        '''''''''''''''''
        Dim sql As String = ""
        Select Case ComboBox1.Text
            Case "毛油", "成品油", "成品粉"
                sql = "update " & bm & " set " & zdm & "=" & sykcsl & "," & bm & "_bf" & "=" & bfs & "," & bm & "_bfmx" & "='" & TextBoxbfmx.Text.Trim & "'," & bm & "_ckcl=" & ckcl.Text.Trim & " where " & bm & "_num='" & ph1 & "'"
            Case "原料"
                sql = "update " & bm & " set " & zdm & "=" & sykcsl & "," & bm & "_bf" & "=" & bfs & "," & bm & "_bfmx" & "='" & TextBoxbfmx.Text.Trim & "'  where " & bm & "_num='" & ph1 & "'"
        End Select
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("修改" & ComboBox1.Text & ph.Text & "剩余库存为：" & sykcsl & "（说明：" & sm & "）", "修改剩余库存") '储存到日志
        MsgBox("更新成功")
        Me.Close()
    End Sub

    Private Sub Textbfs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textbfs.Leave
        Try
            sykc.Text = sykc.Text - Textbfs.Text
            Textbfs.Enabled = False
        Catch ex As Exception
            MsgBox("数字输入错误！")
        End Try

    End Sub
End Class