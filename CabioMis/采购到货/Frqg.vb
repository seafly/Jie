Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frqg
    Public id As String = ""
    Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    Private Sub Frqg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_qgcg_qgbm.Items.Add(dt.Rows(i)(0))
        Next
        tb_qgcg_qgdsfsx.Text = "否"
        If id <> "" Then '传值
            Gs_showsj("tb_qgcg", Me, id)
        Else

            '''''''''''请购备注和预期用途默认为上条信息输入的值，如果是第一次输入则默认为数据库中上个id输入的值
            Try
                Dim nform As Frqg0 = Me.Owner
                Dim show As DataGridView = nform.show2
                tb_qgcg_bz.Text = Null2String(show.Rows(show.RowCount - 1).Cells("tb_qgcg_bz").Value)
                tb_qgcg_yqyt.Text = Null2String(show.Rows(show.RowCount - 1).Cells("tb_qgcg_yqyt").Value)
            Catch ex As Exception
                Dim sql1 As String = "select top 1 tb_qgcg_bz,tb_qgcg_yqyt from tb_qgcg order by tb_qgcg_id desc "
                Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
                tb_qgcg_bz.Text = Null2String(dt1.Rows(0)("tb_qgcg_bz"))
                tb_qgcg_yqyt.Text = dt1.Rows(0)("tb_qgcg_yqyt")

            End Try
        End If

        If tb_qgcg_wpfl.Text = "备品备件" Then
            tb_qgcg_qgdsxrq.Text = Convert.ToDateTime(tb_qgcg_qgrq.Text)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
        '    Exit Sub
        'End If

        Dim bmcn As String = GF_cnwithen(dt, "tb_bm_p512h='" & tb_qgcg_qgbm.Text & "'", 0) '得到表中文名称
        If bmcn = "" Then
            MsgBox("请输入正确的请购部门！")
            Exit Sub
        End If

        If GF_YZSJ(Me, "tb_qgcg_qgdsxrq,tb_qgcg_ysbm,tb_qgcg_tdbz,tb_qgcg_ggxh,tb_qgcg_qgzt,tb_qgcg_wpbz,tb_qgcg_bz,tb_qgcg_cgbz") = False Then '验证控件
            Exit Sub
        End If

        If id <> "" Then
            If GF_modsj("tb_qgcg", Me, id) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If

            Dim f As Frjh = Me.Owner
            Dim dtgr As DataGridView = f.show2
            Dim dt As DataTable = dtgr.DataSource
            If tb_qgcg_qgdsfsx.Text = "是" Then
                Frjh.DelRow(dt, id) '数据变化，少显示一行
            Else
                Frjh.ChangeData(Me, dt, id) '修改数据

            End If
            If tb_qgcg_wpfl.Text = "备品备件" Then
                bjlc()
                ClassPhgn.ClassPhgn_SetDqz2("备件采购单号") '使当前批号+1
            End If
        Else


            Dim f As Frqg0 = Me.Owner
            Dim dtgr As DataGridView = f.show2
            Dim dt As DataTable = dtgr.DataSource
            Frjh.ChangeAddData(Me, dt, 0) '添加数据


        End If

        Me.Close()
    End Sub



    Private Sub tb_qgcg_qgdsfsx_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_qgcg_qgdsfsx.DoubleClick
        If GF_storelog1("采购及请购单生效及偏差") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim nform As New Frqgdsx
        nform.id = id
        Me.AddOwnedForm(nform)
        nform.ShowDialog()

    End Sub
    ''' <summary>
    '''备件在请购审核通过后直接进入采购流程
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bjlc()
        Dim nform As New Frcg
        Me.AddOwnedForm(nform)
        Dim i As String = id
        nform.id = i
        nform.tb_cg_sbid.Text = i
        nform.tb_cg_jhdh.Text = Null2String(tb_qgcg_jhdh.Text) '计划单号
        nform.tb_cg_qgbm.Text = tb_qgcg_qgbm.Text
        nform.tb_cg_qgr.Text = tb_qgcg_qgr.Text
        nform.tb_cg_gsmc.Text = tb_qgcg_gsmc.Text
        nform.tb_cg_dm.Text = tb_qgcg_dm.Text
        nform.tb_cg_pm.Text = tb_qgcg_pm.Text
        nform.tb_cg_ggxh.Text = Null2String(tb_qgcg_ggxh.Text)
        nform.tb_cg_dw.Text = tb_qgcg_dw.Text
        nform.tb_cg_wllb.Text = tb_qgcg_wllb.Text
        nform.tb_cg_qgsl.Text = tb_qgcg_qgsl.Text
        nform.tb_cg_ysje.Text = tb_qgcg_ysje.Text
        nform.tb_cg_yqyt.Text = tb_qgcg_yqyt.Text
        nform.tb_cg_qgdsxrq.Text = DeepCode.DeepDoStr.Null2String(tb_qgcg_qgdsxrq.Text)
        nform.tb_cg_yqdhrq.Text = Null2String(tb_qgcg_yqdhrq.Text)
        nform.tb_cg_ysbm.Text = tb_qgcg_ysbm.Text
        nform.tb_cg_qgbz.Text = Null2String(tb_qgcg_bz.Text)
        nform.tb_cg_wpbz.Text = Null2String(tb_qgcg_wpbz.Text)
        nform.tb_cg_qgrq.Text = tb_qgcg_qgrq.Text
        nform.tb_cg_qgzt.Text = tb_qgcg_qgzt.Text
        nform.tb_cg_qgdsfsx.Text = tb_qgcg_qgdsfsx.Text
        nform.tb_cg_dgzl.Text = tb_qgcg_qgsl.Text
        nform.tb_cg_yjdhl1.Text = tb_qgcg_qgsl.Text
        nform.tb_cg_wpfl.Text = Null2String(tb_qgcg_wpfl.Text)
        nform.tb_cg_cgbz.Text = Null2String(tb_qgcg_cgbz.Text)
        nform.tb_cg_ysbm.Text = Null2String(tb_qgcg_ysbm.Text)
        'nform.tb_cg_yjdhrq1.Text = tb_qgcg_yqdhrq.Text
        nform.tb_cg_dj.Text = "0"
        nform.Label31.Visible = False
        nform.tb_cg_sfbh.Visible = False
        'nform.tb_cg_cgdh.ReadOnly = True
        nform.tb_cg_sbid.Text = i
        nform.tb_cg_fqcs.SelectedIndex = 0
        nform.tb_cg_qyfy.Text = 0
        nform.tb_cg_fzr.SelectedIndex = 0
        nform.tb_cg_yszq1.Text = 3
        nform.tb_cg_yszq2.Text = 3
        nform.tb_cg_yszq3.Text = 3
        nform.id = ""
        Dim qztemp As String = ClassPhgn.ClassPhgn_Get("备件采购单号", "/") '得到当前批号+1的批号
        If qztemp = "" Then
            MsgBox("批号设定不正确") : Exit Sub
        End If
        nform.tb_cg_cgdh.Text = qztemp
        'nform.ShowDialog()
        Dim sql1 As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz)"
        sql1 &= " values ('" & nform.tb_cg_qgbm.Text & "','" & nform.tb_cg_qgr.Text & "','" & nform.tb_cg_cgdh.Text & "','" & nform.tb_cg_cgdh.Text & "','" & nform.tb_cg_gsmc.Text & "','" & nform.tb_cg_dm.Text & "','" & nform.tb_cg_pm.Text & "','" & nform.tb_cg_ggxh.Text & "','" & nform.tb_cg_dw.Text & "','" & nform.tb_cg_wllb.Text & "','" & GF_gettrqsj(tb_qgcg_yqdhrq.Text) & "'," & nform.tb_cg_yjdhl1.Text & "," & nform.tb_cg_qgsl.Text & ",'" & nform.tb_cg_yqyt.Text & "'," & nform.tb_cg_ysje.Text & ",'" & GF_gettrqsj(nform.tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(nform.tb_cg_yqdhrq.Text) & "','" & nform.tb_cg_fzr.Text & "','" & GF_gettrqsj(Now.Date) & "','" & nform.tb_cg_gysmc.Text & "'," & nform.tb_cg_dgzl.Text & "," & nform.tb_cg_dj.Text & "," & nform.tb_cg_qyfy.Text & "," & nform.tb_cg_zj.Text & ",'" & nform.tb_cg_fqcs.Text & "','" & nform.tb_cg_ysbm.Text & "','" & nform.tb_cg_sfbh.Text & "','" & nform.tb_cg_yszq1.Text & "','" & nform.tb_cg_qgbz.Text & "','" & nform.tb_cg_wpbz.Text & "','" & nform.tb_cg_qgrq.Text & "','" & nform.tb_cg_qgzt.Text & "','" & nform.tb_cg_qgdsfsx.Text & "','" & nform.tb_cg_wpfl.Text & "','" & nform.tb_cg_sbid.Text & "','" & nform.tb_cg_jhdh.Text & "','" & nform.tb_cg_cgbz.Text & "')"
        Dim idstring As String = GF_upztxx2(G_cnnstr, sql1, "tb_cg")
        GS_upztxx(G_cnnstr, "update tb_qgcg set tb_qgcg_xbid='" & idstring & "' where tb_qgcg_ID= '" & nform.tb_cg_sbid.Text & "'")

    End Sub


End Class