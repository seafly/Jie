Public Class Frylcybj2
    Public xghc As String '修改何处
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim t1 As Double
        Try
            t1 = TextBox1.Text.Trim
        Catch ex As Exception
            MsgBox("请认真填写数据") : Return
        End Try
        Dim tt2 As String = TextBox2.Text.Trim
        tt2 = Replace(tt2, "'", "’")
        If tt2 = "" Then
            MsgBox("请填写修改原因") : Return
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Return
        End If
        If xghc = "top" Then
            Dim ss As DataGridView = Me.Owner.Controls("GroupBox1").Controls("showl")
            Dim t2 As Double = ss.SelectedRows(0).Cells(4).Value
            Dim cy As Double = t1 - t2
            With ss.SelectedRows(0)
                Dim ph, dm, mc As String '批号，代码，名称
                dm = .Cells(0).Value '代码
                mc = .Cells(1).Value '名称
                ph = .Cells(2).Value '批号
                Dim sql As String = "select  tb_i259b_id from tb_i259b where tb_i259b_i231a='" & dm & "' and tb_i259b_c24u='" & mc & "' and tb_i259b_num='" & ph & "'"
                Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                If dt1.Rows.Count <> 1 Then
                    MsgBox("数据不存在或者大于一条数据") : Return
                End If
                '''''''''''''''''''
                Dim wb As String = Label1.Text & "原来数据为：" & .Cells(3).Value & ",修改为：" & t1 & ",原因为：" & tt2
                GS_storelog3(wb, "原料差异比较库存调整") '储存到日志
                sql = "update tb_i259b set tb_i259b_p518h=" & t1 & " where tb_i259b_i231a='" & dm & "' and tb_i259b_c24u='" & mc & "' and tb_i259b_num='" & ph & "'"
                GS_upztxx(G_cnnstr, sql)
                .Cells(3).ReadOnly = False
                .Cells(5).ReadOnly = False
                .Cells(3).Value = t1
                .Cells(5).Value = cy
            End With
        ElseIf xghc = "right" Then
            Dim ss As DataGridView = Me.Owner.Controls("GroupBox3").Controls("DataGridView2")
            With ss.SelectedRows(0)
                Dim ph, dm, mc As String '批号，代码，名称
                dm = .Cells(0).Value '代码
                mc = .Cells(1).Value '名称
                ph = .Cells(2).Value '批号
                Dim sql As String = "select  tb_i259b_id from tb_i259b where tb_i259b_i231a='" & dm & "' and tb_i259b_c24u='" & mc & "' and tb_i259b_num='" & ph & "'"
                Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                If dt1.Rows.Count <> 1 Then
                    MsgBox("数据不存在或者大于一条数据") : Return
                End If
                '''''''''''''''''''
                Dim wb As String = Label1.Text & "原来数据为：" & .Cells(3).Value & ",修改为：" & t1 & ",原因为：" & tt2
                GS_storelog3(wb, "原料差异比较库存调整") '储存到日志
                sql = "update tb_i259b set tb_i259b_p518h=" & t1 & " where tb_i259b_i231a='" & dm & "' and tb_i259b_c24u='" & mc & "' and tb_i259b_num='" & ph & "'"
                GS_upztxx(G_cnnstr, sql)
                .Cells(3).ReadOnly = False
                .Cells(3).Value = t1
            End With
        End If


        Me.Close()
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frylcybj2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub
End Class