Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class frchaph

    Private TbSearch As DataTable
    Private Sub frchaph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon
        TbSearch = New DataTable
        With TbSearch
            .Columns.Add("table", GetType(String))
            .Columns.Add("tablecn", GetType(String))
            .Columns.Add("connstr", GetType(String))
            Dim m As DataRow
            m = .NewRow() : m(0) = "tb_zzg" : m(1) = "种子罐" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_b970t" : m(1) = "一级罐生产" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_b959t" : m(1) = "二级罐生产" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_i234a" : m(1) = "发酵生产" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_x825p" : m(1) = "放罐烘干" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_my" : m(1) = "毛油" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_mykc" : m(1) = "毛油库存" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_mypl" : m(1) = "毛油配料" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_k306c" : m(1) = "精炼" : m(2) = G_cnnstrWH : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_h195z" : m(1) = "成品油" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_h195zkc" : m(1) = "成品油库存" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_x823p" : m(1) = "粉剂配料" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_n441f" : m(1) = "配料批" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_p525h" : m(1) = "粉剂小批" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_x832p" : m(1) = "成品粉" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_x832pkc" : m(1) = "成品粉库存" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_cpflt" : m(1) = "成品粉零头" : m(2) = G_cnnstr : .Rows.Add(m)
            m = .NewRow() : m(0) = "tb_x832p" : m(1) = "组合成品粉" : m(2) = G_cnnstr : .Rows.Add(m)
        End With
        GS_wlbktlr2(gongxu, TbSearch, 1, "")
        Call weizhi()

    End Sub
    Private Sub weizhi()
        pp.Width = Me.Width - 10
        pp.Left = 5
        pp.Height = Me.Height - pp.Top - 20
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ph As String = Trim(cxph.Text) '批号
        Dim bm As String = GF_cnwithen(TbSearch, "tablecn='" & gongxu.Text & "'", 0)  '通过工序得到表英文名
        Dim bmconnstr As String = GF_cnwithen(TbSearch, "tablecn='" & gongxu.Text & "'", 2)  '通过工序得到链接字符串
        If ph = "" Or bm = "" Then
            MsgBox("请选择工序，并填写批号") : Exit Sub
        End If
        Dim sql As String = "select * from  " & bm & " where " & bm & "_num ='" & ph & "'"
        Dim dttemp As DataTable = GF_CreateDataSource(bmconnstr, sql)

        If dttemp.Rows.Count = 0 Then
            Return
        End If
        pp.Controls.Clear()
        Alljh.Clear()
        ComboBoxdcxz.Items.Clear() '导出选择列表清空
        dttemp.TableName = gongxu.Text
        Alljh.Add(dttemp)

        ' dttemp
        If bm <> "tb_zzg" Then
            '得到上步表
            Dim sbtb As String = DeepCode.DeepDoStr.Null2String(dttemp.Rows(0)(bm & "_sbtb"))
            '得到上步ID
            Dim sbid As String = DeepCode.DeepDoStr.Null2String(dttemp.Rows(0)(bm & "_sbid"))

            If Microsoft.VisualBasic.Right(sbid, 1) = "," Then
                sbid = DeepCode.DeepDoStr.GF_removedh(sbid)
            End If
            Call SearchForMutUp(sbtb, sbid)

        End If

        '得到下步表
        Dim xbtb As String = DeepCode.DeepDoStr.Null2String(dttemp.Rows(0)(bm & "_xbtb"))
        '得到下步ID
        Dim glid As String = DeepCode.DeepDoStr.Null2String(dttemp.Rows(0)(bm & "_glid"))
        If Microsoft.VisualBasic.Right(glid, 1) = "," Then
            glid = DeepCode.DeepDoStr.GF_removedh(glid)
        End If
        Call SearchForMutDown(xbtb, glid)


        For i As Integer = 0 To Alljh.Count - 1
            Dim zs As Integer = pp.Controls.Count
            Dim dt As DataTable = Alljh(i)
            Dim m As New GroupBox
            m.Text = dt.TableName
            Dim newconnstr As String = GF_cnwithen(TbSearch, "tablecn='" & dt.TableName & "'", 2)  '通过工序得到链接字符串
            Dim zdsyk As DataTable = GF_CreateDataSource(newconnstr, "select * from tb_biaozdinf") '所有字段表
            m.BackColor = Color.Transparent
            ComboBoxdcxz.Items.Add(dt.TableName)
            pp.Controls.Add(m)
            m.Left = 1
            m.Width = pp.Width - 10
            m.Height = 200
            m.Top = zs * m.Height + 2 * (zs + 1)
            Dim b As New DataGridView
            b.AllowUserToAddRows = False
            b.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            b.RowHeadersVisible = False
            b.ReadOnly = True
            b.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            m.Controls.Add(b)
            GS_DataGridViewbyDb2(b, dt, "0", True, True, zdsyk)
            GS_DbSum(dt) '最后一行求和
            GS_ysgx(b) '最后一行变颜色
            m.Controls.Add(b)
            b.Dock = DockStyle.Fill
        Next

    End Sub
    Private Alljh As New ArrayList '定义集合作为datatable的容器

    '查上步的所有表
    Private Sub SearchForMutUp(ByVal TableName As String, ByVal IdString As String)
        If IdString = "" Or TableName = "" Then
            Return
        End If

        Dim sbtb As String = "" '得到上步表
        Dim sbid As String = "" '得到上步ID
        Dim dt As DataTable

        If TableName = "tb_h195z" Then
            '当上步表是成品油的时候就垮裤查湖北的

            Dim sql As String = "select * from  " & TableName & " where " & TableName & "_id in(" & IdString & ")"
            dt = GF_CreateDataSource(G_cnnstr, sql)
            Dim hbcpyph As String = GetIdString(dt, "tb_h195z_num")

            hbcpyph = DeepCode.DeepDoStr.GF_zhzfccx(hbcpyph) '得到湖北工厂关联的成品油批号

            sql = "select * from  tb_h195z  where tb_h195z_num in(" & hbcpyph & ")"
            dt = GF_CreateDataSource(G_cnnstrWH, sql)
        Else
            '通过工序得到工厂连接字符串
            Dim bmconnstr As String = GF_cnwithen(TbSearch, "table='" & TableName.Split(",")(0).Trim() & "'", 2)
            Dim sql As String = "select * from  " & TableName.Split(",")(0).Trim() & " where " & TableName.Split(",")(0).Trim() & "_id in(" & IdString & ")"
            dt = GF_CreateDataSource(bmconnstr, sql)

        End If

        With dt
            If .Rows.Count = 0 Then
                Return
            End If
            .TableName = GF_cnwithen(TbSearch, "table='" & TableName.Split(",")(0).Trim() & "'", 1) '得到表中文名
            Alljh.Add(dt) '集合显示的是符合条件的湖北工厂的成品油
            If TableName = "tb_zzg" Then
                Return
            End If

            sbtb = GetIdString(dt, TableName.Split(",")(0).Trim() & "_sbtb") '得到上步表

            sbid = GetIdString(dt, TableName.Split(",")(0).Trim() & "_sbid") '得到上步ID

        End With

        Call SearchForMutUp(sbtb, sbid)

    End Sub

    '查下步的所有表
    Private Sub SearchForMutDown(ByVal TableName As String, ByVal IdString As String)
        If IdString = "" Or TableName = "" Then
            Return
        End If
        Dim sbtb As String = "" '得到上步表
        Dim sbid As String = "" '得到上步ID
        Dim dt As DataTable

        Dim bmconnstr As String = GF_cnwithen(TbSearch, "table='" & TableName & "'", 2)  '通过工序得到链接字符串
        Dim sql As String = "select * from  " & TableName & " where " & TableName & "_id in(" & IdString & ")"

        dt = GF_CreateDataSource(bmconnstr, sql)

        With dt
            If .Rows.Count = 0 Then
                Return
            End If
            dt.TableName = GF_cnwithen(TbSearch, "table='" & TableName & "'", 1)  '得到表中文名
            Alljh.Add(dt) '集合显示的是符合条件的湖北工厂的成品油
            'If TableName = "tb_h195zkc" Then '当是成品油的时候
            '    Dim hbcpyph As String = GetIdString(dt, "tb_h195zkc_num")

            '    hbcpyph = DeepCode.DeepDoStr.GF_zhzfccx(hbcpyph) '得到湖北工厂关联的成品油批号

            '    Dim sql2 As String = "select * from  tb_h195zkc  where tb_h195zkc_num in(" & hbcpyph & ")"
            '    Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
            '    If dt2.Rows.Count = 0 Then
            '        Return
            '    End If
            '    sbtb = GetIdString(dt2, TableName & "_xbtb")
            '    sbid = GetIdString(dt2, TableName & "_glid") '得到下步ID

            'Else
            sbtb = GetIdString(dt, TableName & "_xbtb")
            sbid = GetIdString(dt, TableName & "_glid") '得到下步ID
            'End If
            'MsgBox(sbtb, sbid)
            Call SearchForMutDown(sbtb, sbid)

        End With

    End Sub
    '得到所有关联ID
    Private Function GetIdString(ByVal Dt As DataTable, ByVal ColName As String) As String
        Dim t As String = ""
        If Dt.Rows.Count = 0 Then
            Return ""
        End If
        For i As Integer = 0 To Dt.Rows.Count - 1
            Dim f As String = DeepCode.DeepDoStr.Null2String(Dt.Rows(i)(ColName))

            If Microsoft.VisualBasic.Right(f, 1) = "," Then '如果本事右边有逗号
                f = DeepCode.DeepDoStr.GF_removedh(f)
            End If
            If f <> "" Then '避免重复
                If InStr("," & t, "," & f & ",") = 0 Then
                    t &= f & ","
                End If
            End If
        Next
        If Microsoft.VisualBasic.Right(t, 1) = "," Then
            t = DeepCode.DeepDoStr.GF_removedh(t)
        End If
        Return t
    End Function
  
    '原来综合查询
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim aa As New Frylcx
        aa.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim aa As New frcpfcx
        aa.ShowDialog()
    End Sub



#Region "数据导出"


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Frylcx.pc(pp, ComboBoxdcxz)

    End Sub
    Public Sub xisykj2(ByVal ss As Control, ByVal mm As CheckedListBox)
        mm.Items.Clear()
        With ss
            For i As Integer = 0 To .Controls.Count - 1
                Dim kk As Control = .Controls(i)
                If kk.GetType.ToString = "System.Windows.Forms.GroupBox" Then
                    If GF_getListViewsz(kk.Controls(0)) > 0 Then
                        mm.Items.Add(kk.Text, True)
                    End If

                End If
            Next
        End With

        mm.SelectedIndex = 0
    End Sub
#End Region

    Private Sub ComboBoxdcxz_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBoxdcxz.MouseDoubleClick
        For i As Integer = 0 To ComboBoxdcxz.Items.Count - 1
            ComboBoxdcxz.SetItemChecked(i, False)
        Next
    End Sub

  
End Class