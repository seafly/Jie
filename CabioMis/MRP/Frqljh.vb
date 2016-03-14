Public Class Frqljh
    Public ww As String = ""
    Private Sub Frqljh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub
    Private Sub showsj()
        Dim sql As String = "select tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_cpjz, 0 as '生产量',tb_cpdmhz_cpy,tb_cpdmhz_my,tb_cpdmhz_gjt,tb_cpdmhz_2a01a001,tb_cpdmhz_2a01a002,tb_cpdmhz_2a01a003,tb_cpdmhz_2a01a007,tb_cpdmhz_2a02a008,tb_cpdmhz_2a02a002,tb_cpdmhz_2a01a006,tb_cpdmhz_2a02a005,tb_cpdmhz_2a02a007,tb_cpdmhz_2a02a009,tb_cpdmhz_2a02a006,tb_cpdmhz_2a02a001,tb_cpdmhz_2a02a011,tb_cpdmhz_2a02a012,tb_cpdmhz_2a04a001,tb_cpdmhz_2a04a002,tb_cpdmhz_2a04a003,tb_cpdmhz_2a04a004,tb_cpdmhz_2a04a005,tb_cpdmhz_2a04a006,tb_cpdmhz_2a04a007,tb_cpdmhz_2a04a010,tb_cpdmhz_5a01a006,tb_cpdmhz_5a02a001,tb_cpdmhz_5a03a002,tb_cpdmhz_5a03a003,tb_cpdmhz_5a01a009,tb_cpdmhz_3a08a003,tb_cpdmhz_5a02a003,tb_cpdmhz_5a03a004,tb_cpdmhz_5a02a004,tb_cpdmhz_5a03a006,tb_cpdmhz_5a01a004,tb_cpdmhz_3a06a001,tb_cpdmhz_3a08a004,tb_cpdmhz_3a08a002,tb_cpdmhz_3a08a005,tb_cpdmhz_3a07a010,tb_cpdmhz_3a07a011,tb_cpdmhz_3a07a020,tb_cpdmhz_2a04a014,tb_cpdmhz_3a08a001,tb_cpdmhz_3a09a006,tb_cpdmhz_3a09a021,tb_cpdmhz_5a03a005,tb_cpdmhz_5a02a002,tb_cpdmhz_3a07a019,tb_cpdmhz_3a09a022,tb_cpdmhz_3a08a019,tb_cpdmhz_3a08a020  from tb_cpdmhz where tb_cpdmhz_yxx='有效' "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        For k As Integer = 7 To dt.Columns.Count - 1
            Dim ss As String = Mid(dt.Columns(k).Caption, 11)
            ss = Replace(ss, "a", ".")
            ww &= ss & ","
        Next
        GS_DataGridViewbyDb(listview1, dt, True, True)
        With listview1
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = False
            .Columns(4).ReadOnly = True
            For j As Integer = 4 To .Columns.Count - 1
                listview1.Columns(j).Visible = False
            Next
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        With listview1
            Dim tt As String = ""
            For j As Integer = 7 To .Columns.Count - 1
                Dim bb As Double = 0
                For i As Integer = 0 To .Rows.Count - 1
                    Dim zs As Double = IIf(.Rows(i).Cells(2).Value = 0, 0, _S.YanFormatNum(.Rows(i).Cells(3).Value / .Rows(i).Cells(2).Value)) '生产量除以成品基重 
                    Dim tj As Double = _S.YanFormatNum(zs * .Rows(i).Cells(j).Value) '得要所有加工代码需要同一种原料总和
                    bb = bb + tj
                Next
                tt &= bb & ","
            Next
            tt = DeepCode.DeepDoStr.GF_removedh(tt)
            Dim sy() As String = tt.Split(",") '需求量
            ww = DeepCode.DeepDoStr.GF_removedh(ww)
            Dim sb() As String = ww.Split(",") '加工代码

            Dim f As Frwljhbb = Me.Owner
            Dim dtgrid As DataGridView = f.show1 : f.cz()
            With dtgrid
                .Columns(9).Visible = False  '计划请购量
            End With

            Dim dt As DataTable = dtgrid.DataSource

            For i As Integer = 0 To UBound(sb)
                Dim mm As DataRow = dt.NewRow
                mm(0) = sb(i) 'A物料代码
                mm(8) = _S.YanFormatNum(sy(i)) 'A物料代码需求量

                Dim sql1 As String = "select tb_wp_wpfl,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_aqkc,tb_wp_cgzq,tb_wp_jjcgl from tb_wp where tb_wp_dm='" & sb(i) & "' "

                Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
                If dt1.Rows.Count - 1 < 0 Then
                    mm(1) = "" : mm(2) = ""
                    mm(3) = "" : mm(4) = ""
                    mm(5) = "" : mm(10) = "0"
                    mm(12) = "0" : mm(13) = "0"
                Else
                    mm(1) = dt1.Rows(0)("tb_wp_wpfl") : mm(2) = dt1.Rows(0)("tb_wp_pm")
                    mm(3) = dt1.Rows(0)("tb_wp_ggxh") : mm(4) = dt1.Rows(0)("tb_wp_dw")
                    mm(5) = dt1.Rows(0)("tb_wp_wllb") : mm(10) = dt1.Rows(0)("tb_wp_aqkc")
                    mm(12) = dt1.Rows(0)("tb_wp_cgzq") : mm(13) = dt1.Rows(0)("tb_wp_jjcgl")
                End If
                Dim sql2 As String = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a= '" & sb(i) & "'"
                Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
                mm(6) = Null2zero(dt2.Rows(0)(0)) '仓库存量

                Dim sql3 As String = "select sum(tb_qgcg_qgsl)  from tb_qgcg where tb_qgcg_dm = '" & sb(i) & "' and  tb_qgcg_xbid is null "
                Dim dt3 As DataTable = GF_CreateDataSource(G_cnnstr, sql3)
                Dim sql4 = "select sum(tb_cg_qgsl) from tb_cg where tb_cg_dm = '" & sb(i) & "'and  tb_cg_xbid is null"
                Dim dt4 As DataTable = GF_CreateDataSource(G_cnnstr, sql4)
                mm(7) = Null2zero(dt3.Rows(0)(0)) + Null2zero(dt4.Rows(0)(0))  '在途量
                mm(9) = _S.YanFormatNum(mm(6) + mm(7) - mm(8) - mm(10))  '计划请购量
                mm(14) = mm(6) - mm(8) '奇料差异
                If mm(6) <= mm(10) Then
                    mm(11) = "否"
                Else
                    mm(11) = "是"
                End If
                Dim sql5 = "select tb_wp_njzq from tb_wp where tb_wp_dm = '" & sb(i) & "'"
                Dim dt5 As DataTable = GF_CreateDataSource(G_cnnstr, sql5)
                If dt5.Rows.Count - 1 < 0 Then
                    mm(15) = ""
                Else
                    mm(15) = dt5.Rows(0)(0)
                End If

                Dim sql6 = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a = '" & sb(i) & "'and tb_i259b_qaspjg <>'合格'"
                Dim dt6 As DataTable = GF_CreateDataSource(G_cnnstr, sql6)
                mm(16) = Null2zero(dt6.Rows(0)(0))
                dt.Rows.Add(mm)
            Next
            Call AddNewRow() '添加BC物料代码
            ChangeColor(dtgrid, 11)
            ChangeColorfs(dtgrid, 14)
            RemoveIndex(dtgrid)
        End With

        '保存到成品到半成品计划表
        SavetoMrpWeight(listview1)
        Me.Close()


    End Sub
    Private Sub AddNewRow()
        '''''''''''
        Dim f As Frwljhbb = Me.Owner
        Dim dtgrid As DataGridView = f.show1
        Dim dt As DataTable = dtgrid.DataSource
        '''''''''''''''
        Dim sql1 As String = "select tb_i259b_i231a from tb_i259b group by tb_i259b_i231a "
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
        Dim mm As String = ""
        Dim tt As String = ""
        For i As Integer = 0 To dt1.Rows.Count - 1
            mm &= dt1.Rows(i)(0) & "," '物料代码
        Next
        mm = DeepCode.DeepDoStr.GF_removedh(mm)
        Dim rr() As String = mm.Split(",")
        For j As Integer = 0 To UBound(rr)
            If InStr(ww, rr(j)) = 0 Then
                tt &= rr(j) & ","
            End If
        Next
        tt = DeepCode.DeepDoStr.GF_removedh(tt) 'BC物料代码
        Dim bc() As String = tt.Split(",")
        For i As Integer = 0 To UBound(bc)
            Dim pp As DataRow = dt.NewRow
            pp(0) = bc(i)
            pp(8) = "0"
            Dim sql11 As String = "select tb_wp_wpfl,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_aqkc,tb_wp_cgzq,tb_wp_jjcgl from tb_wp where tb_wp_dm='" & bc(i) & "' "
            Dim dt11 As DataTable = GF_CreateDataSource(G_cnnstr, sql11)
            If dt11.Rows.Count - 1 < 0 Then
                pp(1) = "" : pp(2) = ""
                pp(3) = "" : pp(4) = ""
                pp(5) = "" : pp(10) = "0"
                pp(12) = "0" : pp(13) = "0"
            Else
                pp(1) = dt11.Rows(0)("tb_wp_wpfl") : pp(2) = dt11.Rows(0)("tb_wp_pm")
                pp(3) = dt11.Rows(0)("tb_wp_ggxh") : pp(4) = dt11.Rows(0)("tb_wp_dw")
                pp(5) = dt11.Rows(0)("tb_wp_wllb") : pp(10) = dt11.Rows(0)("tb_wp_aqkc")
                pp(12) = dt11.Rows(0)("tb_wp_cgzq") : pp(13) = dt11.Rows(0)("tb_wp_jjcgl")
            End If
            Dim sql22 As String = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a= '" & bc(i) & "'"
            Dim dt22 As DataTable = GF_CreateDataSource(G_cnnstr, sql22)
            pp(6) = Null2zero(dt22.Rows(0)(0)) '仓库存量

            Dim sql33 As String = "select sum(tb_qgcg_qgsl)  from tb_qgcg where tb_qgcg_dm = '" & bc(i) & "' and  tb_qgcg_xbid is null "
            Dim dt33 As DataTable = GF_CreateDataSource(G_cnnstr, sql33)
            Dim sql44 = "select sum(tb_cg_qgsl) from tb_cg where tb_cg_dm = '" & bc(i) & "'and  tb_cg_xbid is null"
            Dim dt44 As DataTable = GF_CreateDataSource(G_cnnstr, sql44)
            pp(7) = Null2zero(dt33.Rows(0)(0)) + Null2zero(dt44.Rows(0)(0))  '在途量
            pp(9) = FormatNumber(pp(6) + pp(7) - pp(8) - pp(10), 2) '计划请购量
            pp(14) = pp(6) - pp(8) '奇料差异
            If pp(6) <= pp(10) Then
                pp(11) = "否"
            Else
                pp(11) = "是"
            End If
            Dim sql5 = "select tb_wp_njzq from tb_wp where tb_wp_dm = '" & bc(i) & "'"
            Dim dt5 As DataTable = GF_CreateDataSource(G_cnnstr, sql5)
            If dt5.Rows.Count - 1 < 0 Then
                pp(15) = ""
            Else
                pp(15) = dt5.Rows(0)(0)
            End If
            Dim sql6 = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a = '" & bc(i) & "'and tb_i259b_qaspjg <>'合格'"
            Dim dt6 As DataTable = GF_CreateDataSource(G_cnnstr, sql6)
            pp(16) = Null2zero(dt6.Rows(0)(0))
            dt.Rows.Add(pp)
        Next
    End Sub
    Private Sub ChangeColor(ByVal DateGridName As DataGridView, ByVal Index As Integer)
        With DateGridName
            For i As Integer = 0 To .Rows.Count - 1
                Dim sf As String = Null2String(.Rows(i).Cells(Index).Value)
                If sf = "否" Then
                    .Rows(i).Cells(Index).Style.BackColor = Color.Red
                End If
            Next
        End With
    End Sub
    Private Sub RemoveIndex(ByVal DateGridName As DataGridView)
        With DateGridName
            Dim dd As String = ""
            For i As Integer = 0 To .Rows.Count - 1
                Dim ckzl As Integer = .Rows(i).Cells(6).Value
                Dim xql As Integer = .Rows(i).Cells(7).Value
                If ckzl = "0" And xql = "0" Then
                    dd = dd & i & ","
                End If
            Next
            dd = DeepCode.DeepDoStr.GF_removedh(dd)
            Dim crlrsz() As String = dd.Split(",")
            For i As Integer = 0 To UBound(crlrsz)
                Dim sy As Integer = crlrsz(i) - i
                .Rows.RemoveAt(sy)
            Next
        End With
    End Sub
    Private Sub ChangeColorfs(ByVal DateGridName As DataGridView, ByVal Index As Integer)
        With DateGridName
            For i As Integer = 0 To .Rows.Count - 1
                Dim sf As String = Null2zero(.Rows(i).Cells(Index).Value)
                If sf < 0 Then
                    .Rows(i).Cells(Index).Style.BackColor = Color.Red
                End If
            Next
        End With
    End Sub
    Private Function SavetoMrpWeight(ByVal showl As DataGridView) As Boolean
        Try
            Dim SaveDate As String = DateTimePicker1.Text & "-" & DateTimePicker2.Text
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            RS.open("tb_mrpweight", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            With showl
                For i As Integer = 0 To .Rows.Count - 1
                    RS.addnew()
                    RS("tb_mrpweight_mingc").value = .Rows(i).Cells(0).Value
                    RS("tb_mrpweight_jiagdm").value = .Rows(i).Cells(1).Value
                    RS("tb_mrpweight_cpjz").value = .Rows(i).Cells(2).Value
                    RS("tb_mrpweight_weight").value = .Rows(i).Cells(3).Value
                    RS("tb_mrpweight_rq").value = SaveDate
                    RS.Update()
                Next

            End With
            RS.close()
            RS = Nothing
            cnn.close()
            cnn = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class