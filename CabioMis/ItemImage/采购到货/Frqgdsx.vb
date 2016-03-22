Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frqgdsx
    Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    Private Sub Frqgdsx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        qgdsfsx.SelectedIndex = 0
        'ysbm.SelectedIndex = 0

        For i As Integer = 0 To dt.Rows.Count - 1
            ysbm.Items.Add(dt.Rows(i)(0))
        Next
        ysbm.Text = Me.Owner.Controls("tb_qgcg_qgbm").Text

        Dim b() As String = {"紧急", "非紧急"}
        For i As Integer = 0 To UBound(b)
            qgzt.Items.Add(b(i))
        Next
        qgzt.SelectedItem = b(1)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim bmcn As String = GF_cnwithen(dt, "tb_bm_p512h='" & ysbm.Text & "'", 0) '得到表中文名称
        If bmcn = "" Then
            MsgBox("请输入正确的验收部门！")
            Exit Sub
        End If
        If GF_YZSJ(Me, "qgdsxrq") = False Then '验证控件
            Exit Sub
        End If
        If qgdsfsx.Text = "否" Then '判断请购单生效日期
            qgdsxrq.Text = ""
        Else
            qgdsxrq.Text = rq.Text
        End If
        Dim a As TextBox = Me.Owner.Controls("tb_qgcg_qgdsfsx")
        a.Text = qgdsfsx.Text
        Dim b As TextBox = Me.Owner.Controls("tb_qgcg_qgdsxrq")
        b.Text = GF_gettrqsj(qgdsxrq.Text)
        Dim c As TextBox = Me.Owner.Controls("tb_qgcg_ysbm")
        c.Text = ysbm.Text
        Dim d As TextBox = Me.Owner.Controls("tb_qgcg_tdbz")
        d.Text = tdbz.Text
        Dim f As TextBox = Me.Owner.Controls("tb_qgcg_qgzt")
        f.Text = qgzt.Text
        If qgdsfsx.Text = "退单" Then
            If tdbz.Text = "" Then
                MsgBox("请输入退单备注")
                Exit Sub
            End If
        Else

        End If
        Me.Close()
    End Sub


    Private Sub qgdsfsx_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles qgdsfsx.SelectedIndexChanged
        If qgdsfsx.SelectedIndex = 0 Then '请购单生效判断请购单日期显示
            rq.Enabled = False
            tdbz.ReadOnly = True
        ElseIf qgdsfsx.SelectedIndex = 1 Then
            rq.Enabled = True
            tdbz.ReadOnly = True
        ElseIf qgdsfsx.SelectedIndex = 2 Then
            rq.Enabled = True
            tdbz.ReadOnly = False
        End If

    End Sub
End Class