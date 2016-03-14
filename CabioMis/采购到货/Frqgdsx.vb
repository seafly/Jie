Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frqgdsx
    Public id As String
    Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    Private Sub Frqgdsx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_qgcg_qgdsfsx.SelectedIndex = 0
        'ysbm.SelectedIndex = 0

        For i As Integer = 0 To dt.Rows.Count - 1
            tb_qgcg_ysbm.Items.Add(dt.Rows(i)(0))
        Next
        tb_qgcg_ysbm.Text = Me.Owner.Controls("tb_qgcg_qgbm").Text

        Dim b() As String = {"紧急", "非紧急"}
        For i As Integer = 0 To UBound(b)
            tb_qgcg_qgzt.Items.Add(b(i))
        Next
        tb_qgcg_qgzt.SelectedItem = b(1)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
        '    Exit Sub
        'End If
        Dim bmcn As String = GF_cnwithen(dt, "tb_bm_p512h='" & tb_qgcg_ysbm.Text & "'", 0) '得到表中文名称
        If bmcn = "" Then
            MsgBox("请输入正确的验收部门！")
            Exit Sub
        End If
        'If GF_YZSJ(Me, "qgdsxrq") = False Then '验证控件
        '    Exit Sub
        'End If
        If tb_qgcg_qgdsfsx.Text = "否" Then '判断请购单生效日期
            tb_qgcg_qgdsxrq.Text = ""
        Else
            tb_qgcg_qgdsxrq.Text = rq.Text
        End If

        If tb_qgcg_qgdsfsx.Text = "退单" Then
            If tb_qgcg_tdbz.Text = "" Then
                MsgBox("请输入退单备注")
                Exit Sub
            End If
        Else
        End If
        'GS_storelog3("采购及请购单生效及偏差：请购单生效  " & id & "", "采购及请购单生效及偏差") '储存到日志
        Dim aa As Frqg = Me.Owner
        With aa
            .tb_qgcg_qgdsfsx.Text = tb_qgcg_qgdsfsx.Text
            .tb_qgcg_qgdsxrq.Text = tb_qgcg_qgdsxrq.Text
            .tb_qgcg_ysbm.Text = tb_qgcg_ysbm.Text
            .tb_qgcg_tdbz.Text = tb_qgcg_tdbz.Text
            .tb_qgcg_qgzt.Text = tb_qgcg_qgzt.Text
        End With
        'Dim a As TextBox = Me.Owner.Controls("tb_qgcg_qgdsfsx")
        'a.Text = tb_qgcg_qgdsfsx.Text
        'Dim b As TextBox = Me.Owner.Controls("tb_qgcg_qgdsxrq")
        'b.Text = GF_gettrqsj(tb_qgcg_qgdsxrq.Text)
        'Dim c As TextBox = Me.Owner.Controls("tb_qgcg_ysbm")
        'c.Text = tb_qgcg_ysbm.Text
        'Dim d As TextBox = Me.Owner.Controls("tb_qgcg_tdbz")
        'd.Text = tb_qgcg_tdbz.Text
        'Dim f As TextBox = Me.Owner.Controls("tb_qgcg_qgzt")
        'f.Text = tb_qgcg_qgzt.Text
        'aa.Close()
        Me.Close()
    End Sub


    Private Sub qgdsfsx_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_qgcg_qgdsfsx.SelectedIndexChanged
        If tb_qgcg_qgdsfsx.SelectedIndex = 0 Then '请购单生效判断请购单日期显示
            rq.Enabled = False
            tb_qgcg_tdbz.ReadOnly = True
        ElseIf tb_qgcg_qgdsfsx.SelectedIndex = 1 Then
            rq.Enabled = True
            tb_qgcg_tdbz.ReadOnly = True
        ElseIf tb_qgcg_qgdsfsx.SelectedIndex = 2 Then
            rq.Enabled = True
            tb_qgcg_tdbz.ReadOnly = False
        End If

    End Sub
End Class