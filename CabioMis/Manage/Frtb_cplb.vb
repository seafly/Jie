Public Class Frtb_cplb

    '页面负责产品类别的添加
    Public biao As String = "tb_cplb"
    Private Sub Frtb_cplb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub
    Private Sub showsj()
        YanDaTaGridView1.Rows.Clear()
        Dim sql As String = "select * from  " & biao
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            YanDaTaGridView1.Rows.Add(dt.YanDtValue2("tb_cplb_p512h", i))
            If CInt(_S.YanFormatNum2(dt.YanDtValue2("tb_cplb_isShow", i))) = 0 Then
                YanDaTaGridView1.Rows(i).Cells("tb_cplb_isShow").Value = True
            End If
        Next
        'GS_useviewbydb2(ListView1, dt, 0, 0)
        'GroupBox1.Text = "列表（双击删除）" & GF_getListViewsz(ListView1) & "条记录"
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bm As String = TextBox1.Text.Trim
        If bm = "" Then
            Exit Sub
        End If
        If GF_cxph(biao & "_p512h", bm) = True Then
            MsgBox("数据库内已经存在该数据，请重新输入！") : Exit Sub
        End If
        If GF_storelog1("添加产品类别") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim sql As String = "insert into " & biao & "(" & biao & "_p512h)values('" & bm & "')"
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("添加产品类别：" & bm, "添加偏差台账") '储存到日志
        showsj()
    End Sub
    Private Sub ListView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles YanDaTaGridView1.CellClick
        YanDaTaGridView1.SelectedRows(0).Cells("tb_cplb_isShow").Value = (YanDaTaGridView1.SelectedRows(0).Cells("tb_cplb_isShow").Value = False)
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles YanDaTaGridView1.CellDoubleClick
        If YanDaTaGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim biaozd As String = "tb_yg_v753n"
        If biao = "tb_bmgh" Then
            biaozd = "tb_yg_bmgd"
        End If
        Dim bm As String = YanDaTaGridView1.SelectedRows(0).Cells("tb_cplb_p512h").Value
        If MsgBox("确定删除：" & bm & "吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        If GF_storelog1("删除产品类别") = False Then
            Exit Sub
        End If
        Dim zz As Integer = 0
        Dim sql As String = "select  tb_mypl_ID from  tb_mypl where tb_mypl_cplb='" & bm & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        zz = dt.Rows.Count '看毛油配料里面有吗
        ''''''''''''
        sql = "select  tb_h195z_ID from  tb_h195z where tb_h195z_cplb='" & bm & "'"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        zz = zz + dt.Rows.Count '看成品油里面有吗
        '''''''''''''''''''''''
        sql = "select  tb_x823p_ID from  tb_x823p where tb_x823p_cplb='" & bm & "'"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        zz = zz + dt.Rows.Count '看粉剂配料里面有吗
        ''''''''''''''''''''''''
        sql = "select  tb_n441f_ID from  tb_n441f where tb_n441f_cplb='" & bm & "'"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        zz = zz + dt.Rows.Count '看配料批里面有吗
        ''''''''''''''''''''''''''
        If zz > 0 Then
            MsgBox("生产流程中存在该类别数据，不能删除！") : Exit Sub
        End If
        sql = "delete from " & biao & " where " & biao & "_p512h='" & bm & "'"
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("删除产品类别：" & bm, "删除产品类别") '储存到日志
        showsj()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i As Integer = 0 To YanDaTaGridView1.Rows.Count - 1
            Dim tCollDic As New Dictionary(Of String, String)
            tCollDic("tb_cplb_isShow") = IIf(YanDaTaGridView1.Rows(i).Cells("tb_cplb_isShow").Value, 0, 1)
            _D.updateData("tb_cplb", tCollDic, "tb_cplb_p512h='" + YanDaTaGridView1.Rows(i).Cells("tb_cplb_p512h").Value + "'")
        Next
        MsgBox("操作完成！")
       me.DialogResult=DialogResult.OK
    End Sub
End Class