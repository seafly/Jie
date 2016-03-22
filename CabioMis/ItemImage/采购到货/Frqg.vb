Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frqg
    Public id As String = ""
    Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    Private Sub Frqg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        If tb_qgcg_jhdh.Text = "" Then
            tb_qgcg_jhdh.Text = "无"
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_qgcg_qgbm.Items.Add(dt.Rows(i)(0))
        Next
        tb_qgcg_qgdsfsx.Text = "否"
        tb_qgcg_qgbm.SelectedIndex = 0
        If id <> "" Then '传值
            Gs_showsj("tb_qgcg", Me, id)
        Else
            Try
                Dim sql1 As String = "select top 1 tb_qgcg_qgr,tb_qgcg_qgrq,tb_qgcg_bz,tb_qgcg_yqyt,tb_qgcg_qgbm from tb_qgcg order by tb_qgcg_id desc "
                Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
                tb_qgcg_qgr.Text = dt1.Rows(0)(0)
                tb_qgcg_qgrq.Text = dt1.Rows(0)(1)
                tb_qgcg_bz.Text = dt1.Rows(0)(2)
                tb_qgcg_yqyt.Text = dt1.Rows(0)(3)
                tb_qgcg_qgbm.Text = dt1.Rows(0)(4)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        Dim bmcn As String = GF_cnwithen(dt, "tb_bm_p512h='" & tb_qgcg_qgbm.Text & "'", 0) '得到表中文名称
        If bmcn = "" Then
            MsgBox("请输入正确的请购部门！")
            Exit Sub
        End If

        If GF_YZSJ(Me, "tb_qgcg_qgdsxrq,tb_qgcg_ysbm,tb_qgcg_tdbz,tb_qgcg_ggxh,tb_qgcg_qgzt,tb_qgcg_wpbz,tb_qgcg_bz") = False Then '验证控件
            Exit Sub
        End If

        If id <> "" Then
            If GF_modsj("tb_qgcg", Me, id) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            'Dim sql1 As String = "update tb_cg set tb_cg_qgsl=" & tb_qgcg_qgsl.Text & ",tb_cg_qgbm='" & tb_qgcg_qgbm.Text & "',tb_cg_qgr='" & tb_qgcg_qgr.Text & "',tb_cg_yqyt='" & tb_qgcg_yqyt.Text & "',tb_cg_ysje=" & tb_qgcg_ysje.Text & ",tb_cg_yqdhrq='" & GF_gettrqsj(tb_qgcg_yqdhrq.Text) & "'where tb_cg_ID = '" & id & "' "
            'GS_upztxx(G_cnnstr, sql1) '修改
            Dim f As Frjh = Me.Owner
            Dim dtgr As DataGridView = f.show2
            Dim dt As DataTable = dtgr.DataSource
            If tb_qgcg_qgdsfsx.Text = "是" Then
                Frjh.DelRow(dt, id) '数据变化，少显示一行
            Else
                Frjh.ChangeData(Me, dt, id) '修改数据

            End If
        Else

            Dim jj As String = GF_addsj("tb_qgcg", Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            Dim f As Frjh = Me.Owner
            Dim dtgr As DataGridView = f.show2
            Dim dt As DataTable = dtgr.DataSource
            Frjh.ChangeAddData(Me, dt, jj) '添加数据
        End If
        'Dim nform As Frjh = Me.Owner
        'nform.xssj()
        Me.Close()
    End Sub



    Private Sub tb_qgcg_qgdsfsx_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_qgcg_qgdsfsx.DoubleClick
        Dim nform As New Frqgdsx
        Me.AddOwnedForm(nform)
        nform.ShowDialog()
    End Sub


End Class