Imports DeepCode.DeepDoDataTable
Public Class Fryfcltj

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        With ListView1
            .Clear()
            .CausesValidation = False
            .View = View.Details
            .BeginUpdate()
            '’‘’‘’‘添加列
            .Columns.Add("名称", CType((.Width / 4), Integer), HorizontalAlignment.Center)
            .Columns.Add("领出工段", CType((.Width / 4), Integer), HorizontalAlignment.Center)
            .Columns.Add("数量", CType((.Width / 4), Integer), HorizontalAlignment.Center)
            .Columns.Add("单位", CType((.Width / 4), Integer), HorizontalAlignment.Center)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim a1 As String = "select tb_jch_cplb,tb_jch_yfcllygd,sum(tb_jch_sl) from tb_jch where tb_jch_rq between '" & tt1 & "'and '" & tt2 & "' and tb_jch_cz not in ('出','进')  group by tb_jch_cplb,tb_jch_yfcllygd order by tb_jch_cplb"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, a1)
            '''''''''''''''''''''''''''''''''''''下面为查询出的单位建立datatable
            Dim dtxx As New DataTable
            'Dim dr As DataRow
            dtxx.Columns.Add("单位")
            For ii As Integer = 0 To dt.Rows.Count - 1
                Dim cx As String = "select top 1 tb_i259b_h200z from tb_i259b where tb_i259b_c24u='" & dt.Rows(ii)(0) & "'"
                Dim dtdw As DataTable = GF_CreateDataSource(G_cnnstr, cx)
                Dim dr As DataRow = dtxx.NewRow
                dr(0) = dtdw.Rows(0)(0)
                dtxx.Rows.Add(dr)

            Next
            dt = hb(dt, dtxx) '’‘’‘’‘’‘’‘合并材料和单位datatable
            '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’ 
            For i As Integer = 0 To dt.Rows.Count - 1

                Dim mc As String = dt.Rows(i)(0)
                Dim mc1 As String = ""
                If i > 0 Then
                    mc1 = dt.Rows(i - 1)(0)
                End If
                If mc = mc1 Then '代表同类产品
                    .Items.Add("")
                    Dim h As Integer = .Items.Count - 1
                    .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(1)))
                    .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(2)))
                    .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(3)))

                Else

                    If mc1 = "" Then '代表第一行
                        .Items.Add(mc)
                        Dim h As Integer = .Items.Count - 1
                        .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(1)))
                        .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(2)))
                        .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(3)))
                    Else '非第一行
                        .Items.Add("合计")
                        Dim h As Integer = .Items.Count - 1
                        .Items(h).SubItems.Add("")
                        .Items(h).SubItems.Add("")
                        .Items.Add(mc)
                        h = .Items.Count - 1
                        .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(1)))
                        .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(2)))
                        .Items(h).SubItems.Add(DeepCode.DeepDoStr.Null2String(dt.Rows(i)(3)))
                    End If
                End If
                If i = dt.Rows.Count - 1 Then
                    .Items.Add("合计")
                    Dim h As Integer = .Items.Count - 1
                    .Items(h).SubItems.Add("")
                    .Items(h).SubItems.Add("")
                    .Items.Add("总计")
                    h = .Items.Count - 1
                    .Items(h).SubItems.Add("")
                    .Items(h).SubItems.Add("")
                End If
            Next
            .EndUpdate()
            Dim hj1 As Double = 0
            Dim zj1 As Double = 0
            Dim zj2 As Double = 0
            For i As Integer = 0 To .Items.Count - 1
                Dim cc As String = .Items(i).SubItems(0).Text
                If cc <> "合计" Then
                    If cc <> "总计" Then
                        zj1 = zj1 + .Items(i).SubItems(2).Text
                    Else
                        .Items(i).SubItems(2).Text = zj2
                    End If

                Else
                    .Items(i).SubItems(2).Text = zj1
                    zj2 = zj2 + zj1
                    zj1 = 0
                End If
            Next
        End With
    End Sub

    Private Sub Fryfcltj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(ListView1, Me.Text, Me)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim sql As String = "select * from tb_jch where tb_jch_rq between '" & tt1 & "'and '" & tt2 & "' and tb_jch_cz not in ('出','进')   order by tb_jch_cplb"

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Dim a As New Frzdybb_mx
        a.Text = "原辅材料明细"
        a.showl.DataSource = dt
        GS_TranEtoC(a.showl) '将DataGridView列字段翻译成为中文描叙

        a.Show()

    End Sub
    Private Function hb(ByVal dt1 As DataTable, ByVal dt2 As DataTable) As DataTable '横向合并相同行数的datatable
        Dim dt As New DataTable
        Dim dr As DataRow
        'Dim dt1r As String = ""
        For ll As Integer = 0 To dt1.Columns.Count - 1
            dt.Columns.Add(dt1.Columns(ll).ColumnName)
        Next
        ''''''''''''''''''''''''''''''''''''''
        'Dim dt2r As String = ""
        For rr As Integer = 0 To dt2.Columns.Count - 1
            dt.Columns.Add(dt2.Columns(rr).ColumnName)
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''上面构建datatable架构 下面添加信息
        For h As Integer = 0 To dt1.Rows.Count - 1 '两个datatable的行数相同
            dr = dt.NewRow
            For il As Integer = 0 To dt1.Columns.Count - 1
                dr(il) = dt1.Rows(h)(il)
            Next
            For jl As Integer = 0 To dt2.Columns.Count - 1

                dr(jl + dt1.Columns.Count) = dt2.Rows(h)(jl)
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
End Class