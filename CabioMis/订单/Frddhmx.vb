Public Class Frddhmx
    Public fhtzdh As String = "" '发货通知单号
    Public ddh, jhl As String '订单号 计划量
    Public sjsj As String = Nothing '实际时间
    Public bs As Boolean  '用作Frddzxjh2的传真标识
    Public id As String = ""
    Private Sub Frddhmx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = "select tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cw,tb_dd_cys,tb_dd_ysfs,tb_dd_bfb,tb_dd_kdlk,tb_dd_storagewzlk,tb_dd_storagemslk from tb_dd where tb_dd_bz1='2' and tb_dd_fhtjdh='" & fhtzdh & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
        GroupBox1.Text = "显示" & show1.RowCount & "条记录"
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If GF_storelog1("订单发货实施") = False Then
            Exit Sub
        End If ' 判断是否有权限
       
        bs = False
        Dim nform As New Frddzxjh2
        Me.AddOwnedForm(nform)
        nform.Label2.Text = "订单号和计划量分别为 " & ddh & " ， " & jhl
        nform.ShowDialog()
        If bs = False Then
            Exit Sub
        End If
        Dim sql As String = ""
        Dim fhtjdhsz As String() = fhtzdh.Split("-")
        Dim ddhm As String = Nothing
        For cd As Integer = 0 To fhtjdhsz.Length - 2
            ddhm &= fhtjdhsz(cd) & "-" ''''''''''得到单号
        Next
        ddhm = GF_removedh(ddhm)
        sql = "select tb_dd_kcbiao,tb_dd_kcid,tb_dd_jhl,tb_dd_ph,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_id,tb_dd_bfb,tb_dd_kdlk,tb_dd_storagewzlk,tb_dd_storagemslk from tb_dd where tb_dd_fhtjdh='" & fhtzdh & "' and tb_dd_bz1='2' and tb_dd_bz2 ='2'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        For j As Integer = 0 To dt.Rows.Count - 1

            '更新库存 表 
            Dim sql0 As String = "update " & dt.Rows(j)(0) & " set " & dt.Rows(j)(0) & "_ckcl=" & dt.Rows(j)(0) & "_ckcl- " & dt.Rows(j)(2) & " "
            sql0 &= ",   " & dt.Rows(j)(0) & "_bfb=" & dt.Rows(j)(0) & "_bfb- " & dt.Rows(j)("tb_dd_bfb") & " "
            sql0 &= ",   " & dt.Rows(j)(0) & "_kdlk=" & dt.Rows(j)(0) & "_kdlk- " & dt.Rows(j)("tb_dd_kdlk") & " "
            sql0 &= ",   " & dt.Rows(j)(0) & "_storagewzlk=" & dt.Rows(j)(0) & "_storagewzlk- " & dt.Rows(j)("tb_dd_storagewzlk") & " "
            sql0 &= ",   " & dt.Rows(j)(0) & "_storagemslk=" & dt.Rows(j)(0) & "_storagemslk- " & dt.Rows(j)("tb_dd_storagemslk") & " "
            sql0 &= " where " & dt.Rows(j)(0) & "_id=" & dt.Rows(j)(1)
            GS_upztxx(G_cnnstr, sql0)

            '更新订单表（3级信息）
            sql0 = "update tb_dd set tb_dd_bz3='2',tb_dd_sjph='" & dt.Rows(j)("tb_dd_ph") & "',tb_dd_sjfhrq='" & sjsj & "',tb_dd_fhl=" & dt.Rows(j)(2) & " where tb_dd_id=" & dt.Rows(j)("tb_dd_id") '更新标识
            GS_upztxx(G_cnnstr, sql0)

            '更新已发货量（一级信息）
            Dim fhzj As Double = (CDbl(Null2zero2(Trim(GF_getstringsql(G_cnnstr, "select tb_dd_yfh from tb_dd where  tb_dd_fhtjdh is null and tb_dd_ddh='" & ddhm & "'", "")))) + CDbl(dt.Rows(j)(2)))
            sql0 = "update tb_dd set tb_dd_yfh=" & fhzj & " where tb_dd_fhtjdh is null and tb_dd_ddh='" & ddhm & "'"
            GS_upztxx(G_cnnstr, sql0)
            Dim _Bz As String = "订单"
            If Microsoft.VisualBasic.Right(fhtzdh, 1) = "H" Then
                _Bz = "订单退换货 "
            End If
            '存入进出货
            sql0 = "insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh,tb_jch_pldh,tb_jch_bfb,tb_jch_kdlk,tb_jch_storagewzlk,tb_jch_storagemslk) values"
            sql0 = sql0 & "('" & dt.Rows(j)("tb_dd_cplx") & "','" & dt.Rows(j)("tb_dd_cpdm") & "','" & dt.Rows(j)("tb_dd_jgdm") & "','" & dt.Rows(j)("tb_dd_ph") & "','出'," & dt.Rows(j)("tb_dd_jhl") & ",'" & sjsj & "','销售','" & _Bz & "','" & G_dlrgh & "','" & ddhm & "'," & dt.Rows(j)("tb_dd_bfb") & "," & dt.Rows(j)("tb_dd_kdlk") & "," & dt.Rows(j)("tb_dd_storagewzlk") & "," & dt.Rows(j)("tb_dd_storagemslk") & ")"
            GS_upztxx(G_cnnstr, sql0)

            GS_storelog3("订单发货实施： id " & dt.Rows(j)("tb_dd_id"), "订单发货实施") '储存到日志

        Next

        sql = "update tb_dd set tb_dd_bz2='1' where tb_dd_id='" & id & "'"
        GS_upztxx(G_cnnstr, sql) '更新标识2
        MsgBox("完成")
        Me.Close()
    End Sub
End Class