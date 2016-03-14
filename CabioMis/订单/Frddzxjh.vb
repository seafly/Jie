Public Class Frddzxjh

    Private Sub Frddzxjh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = ""
        sql = "select  tb_dd_ID,tb_dd_ddh,tb_dd_ddl,tb_dd_fhtjdh,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_pm,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ddrq,tb_dd_bz,tb_dd_jhl from tb_dd where tb_dd_bz1='1' and tb_dd_bz2 ='2'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt, 12, 0) '隐藏tb_dd_jhl
        GroupBox1.Text = ""
        '隐藏列
        For i As Integer = 0 To 2
            ListView1.Columns(i).Width = 0
        Next
        GroupBox1.Text = "显示" & ListView1.Items.Count & "条记录"

    End Sub
    Private Sub weizhi()
        ListView1.Width = GroupBox1.Width - 10
        ListView1.Height = GroupBox1.Height - ListView1.Top - 10
    End Sub
  
    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Try
            Dim aa As New Frddhmx
            aa.fhtzdh = ListView1.SelectedItems(0).SubItems(3).Text '发货通知单号    
            aa.ddh = ListView1.SelectedItems(0).SubItems(1).Text
            aa.jhl = ListView1.SelectedItems(0).SubItems(9).Text
            aa.id = ListView1.SelectedItems(0).SubItems(0).Text
            aa.ShowDialog()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''更新
            Dim sqljch As String = ""
            sqljch = "select  tb_dd_ID,tb_dd_ddh,tb_dd_ddl,tb_dd_fhtjdh,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_pm,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ddrq,tb_dd_bz,tb_dd_jhl from tb_dd where tb_dd_bz1='1' and tb_dd_bz2 ='2'"
            Dim dtt As DataTable = GF_CreateDataSource(G_cnnstr, sqljch)
            GS_useviewbydb2(ListView1, dtt, 12, 0) '隐藏tb_dd_jhl
            GroupBox1.Text = ""
            '隐藏列
            For i As Integer = 0 To 2
                ListView1.Columns(i).Width = 0
            Next
            GroupBox1.Text = "显示" & ListView1.Items.Count & "条记录"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Frddzxjh_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub dd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New Frdddy
        Me.AddOwnedForm(nform)

        Dim sql1 As String = ""
        If sender.text = "已发货" Then
            sql1 = "tb_dd_bz1='1' and tb_dd_bz2='1' "
        End If
        nform.bs = sender.text
        nform.sql = "select tb_dd_ddh from tb_dd where " & sql1
        nform.sql &= " group by tb_dd_ddh"
        nform.Show()
    End Sub
#Region "发货计划"
    'Public Sub fhss(ByVal sjsj As String)
    '    If GF_storelog1("订单发货实施") = False Then
    '        Exit Sub
    '    End If ' 判断是否有权限
    '    If ListView1.SelectedItems.Count = 0 Then
    '        MsgBox("是否选择批号") : Exit Sub
    '    End If
    '    bs = False
    '    Dim nform As New Frddzxjh2
    '    Me.AddOwnedForm(nform)
    '    'nform.tb_dd_ddrq = GF_GetListText(ListView1, "tb_dd_ddrq", 0, 2)
    '    nform.Label2.Text = "订单号和计划量分别为 " & ListView1.SelectedItems(0).SubItems(1).Text & " ， " & ListView1.SelectedItems(0).SubItems(9).Text
    '    nform.ShowDialog()
    '    If bs = False Then
    '        Exit Sub
    '    End If

    '    With ListView1
    '        Dim sql As String = ""
    '        For i As Integer = 0 To .SelectedItems.Count - 1
    '            Dim fhtjdh As String = GF_GetListText(ListView1, "tb_dd_fhtjdh", i, 2) '发货通知单号
    '            Dim fhtjdhsz As String() = fhtjdh.Split("-")
    '            Dim ddhm As String = Nothing
    '            For cd As Integer = 0 To fhtjdhsz.Length - 2
    '                ddhm &= fhtjdhsz(cd) & "-" ''''''''''得到单号
    '            Next
    '            ddhm = GF_removedh(ddhm)
    '            sql = "select tb_dd_kcbiao,tb_dd_kcid,tb_dd_jhl,tb_dd_ph,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_id from tb_dd where tb_dd_fhtjdh='" & fhtjdh & "' and tb_dd_bz1='2' and tb_dd_bz2 ='2'"
    '            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    '            For j As Integer = 0 To dt.Rows.Count - 1
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''更新库存 表 
    '                Dim sql0 As String = "update " & dt.Rows(j)(0) & " set " & dt.Rows(j)(0) & "_ckcl=" & dt.Rows(j)(0) & "_ckcl- " & dt.Rows(j)(2) & " "
    '                sql0 &= " where " & dt.Rows(j)(0) & "_id=" & dt.Rows(j)(1)
    '                GS_upztxx(G_cnnstr, sql0)
    '                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘更新订单表（3级信息）
    '                sql0 = "update tb_dd set tb_dd_bz3='2',tb_dd_sjph='" & dt.Rows(j)("tb_dd_ph") & "',tb_dd_sjfhrq='" & sjsj & "',tb_dd_fhl=" & dt.Rows(j)(2) & " where tb_dd_id=" & dt.Rows(j)("tb_dd_id") '更新标识
    '                GS_upztxx(G_cnnstr, sql0)
    '                Dim fhzj As Double = (CDbl(Null2zero2(Trim(GF_getstringsql(G_cnnstr, "select tb_dd_yfh from tb_dd where  tb_dd_fhtjdh is null and tb_dd_ddh='" & ddhm & "'", "")))) + CDbl(dt.Rows(j)(2)))
    '                sql0 = "update tb_dd set tb_dd_yfh=" & fhzj & " where tb_dd_fhtjdh is null and tb_dd_ddh='" & ddhm & "'" '更新已发货量（一级信息）
    '                GS_upztxx(G_cnnstr, sql0)
    '                sql0 = "insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh,tb_jch_pldh) values"
    '                sql0 = sql0 & "('" & dt.Rows(j)("tb_dd_cplx") & "','" & dt.Rows(j)("tb_dd_cpdm") & "','" & dt.Rows(j)("tb_dd_jgdm") & "','" & dt.Rows(j)("tb_dd_ph") & "','出'," & dt.Rows(j)("tb_dd_jhl") & ",'" & sjsj & "','销售','订单','" & G_dlrgh & "','" & ddhm & "')"
    '                GS_upztxx(G_cnnstr, sql0) '存入进出货
    '            Next

    '            sql = "update tb_dd set tb_dd_bz2='1' where tb_dd_id='" & ListView1.SelectedItems(i).SubItems(0).Text & "'"
    '            GS_upztxx(G_cnnstr, sql) '更新标识2
    '        Next
    '    End With
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''更新
    '    Dim sqljch As String = ""
    '    sqljch = "select  tb_dd_ID,tb_dd_ddh,tb_dd_ddl,tb_dd_fhtjdh,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_pm,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ddrq,tb_dd_bz,tb_dd_jhl from tb_dd where tb_dd_bz1='1' and tb_dd_bz2 ='2'"
    '    Dim dtt As DataTable = GF_CreateDataSource(G_cnnstr, sqljch)
    '    GS_useviewbydb2(ListView1, dtt, 12, 0) '隐藏tb_dd_jhl
    '    'ListView1.CheckBoxes = True
    '    GroupBox1.Text = ""
    '    '隐藏列
    '    For i As Integer = 0 To 2
    '        ListView1.Columns(i).Width = 0
    '    Next
    '    GroupBox1.Text = "显示" & ListView1.Items.Count & "条记录"
    'End Sub
#End Region

 
End Class