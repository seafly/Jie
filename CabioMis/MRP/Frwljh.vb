
Public Class Frwljh
    Public ww As String = ""
    Private Sub Frwljh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj() '初始化产品产能汇总表
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim f As Frwljhbb = CType(Me.Owner, Frwljhbb)
            Dim dtgrid As DataGridView = f.show1 : f.cz()
            With dtgrid
                .Columns(14).Visible = False '差异
            End With

            Dim dt As DataTable = CType(dtgrid.DataSource, DataTable)

            With listview1
                'Dim tt As String = ""
                'For j As Integer = 7 To .Columns.Count - 1 'A物料
                '    Dim bb As Double = 0
                '    For i As Integer = 0 To .Rows.Count - 1 '遍历加工代码
                '        Dim zs As Double = FormatNumber(listview1.Rows(i).Cells(3).Value / listview1.Rows(i).Cells(2).Value, 2) '生产量除以成品基重 
                '        If listview1.Rows(i).Cells(2).Value = 0 Then
                '            zs = 0
                '        End If
                '        Dim tj As Double = FormatNumber(zs * listview1.Rows(i).Cells(j).Value, 2) '物料需求量
                '        bb += tj
                '    Next
                '    tt &= bb & ","
                'Next
                'tt = DeepCode.DeepDoStr.GF_removedh(tt)
                'Dim sy() As String = tt.Split(",") 'A物料 需求量数组
                'ww = DeepCode.DeepDoStr.GF_removedh(ww)
                'Dim sb() As String = ww.Split(",") 'A物料代码数组

                '保存已选产品标识的字符串
                Dim strTm As String = ""
                '保存已选产品内容的DT
                Dim dtTm As New DataTable
                dtTm.Columns.Add("tb_cpdmhz_ID")
                dtTm.Columns.Add("tb_cpdmhz_cpjz")
                dtTm.Columns.Add("生产量")
                For ii As Integer = 0 To listview1.Rows.Count - 1
                    'If Convert.ToInt32(listview1.Rows(ii).Cells("生产量").Value.ToString()) > 0 Then
                    strTm &= listview1.Rows(ii).Cells("tb_cpdmhz_ID").Value.ToString() & ","
                    Dim drTm As DataRow = dtTm.NewRow
                    drTm("tb_cpdmhz_ID") = listview1.Rows(ii).Cells("tb_cpdmhz_ID").Value
                    drTm("tb_cpdmhz_cpjz") = listview1.Rows(ii).Cells("tb_cpdmhz_cpjz").Value
                    drTm("生产量") = listview1.Rows(ii).Cells("生产量").Value
                    dtTm.Rows.Add(drTm)
                    'End If
                Next
                strTm = DeepCode.DeepDoStr.GF_removedh(strTm)

                'Dim strSql As String = "select * from tb_wp where tb_wp_dm in (select tb_mrp_wpdm from tb_mrp where tb_mrp_cpbs in (" & strTm & "))"
                Dim strSql As String = "select * from tb_wp where tb_wp_wpfl in ('原料','包材') and " & _
                    "tb_wp_dm in (select tb_i259b_i231a from tb_i259b group by tb_i259b_i231a having sum(tb_i259b_ckcl)>0)"
                Dim dtMrp As DataTable = Cl_DataMag.GF_CreateDataSource(strSql)
                strSql = "select * from tb_mrp where tb_mrp_xz=" & en_Bllx.生产原料 & " and tb_mrp_cpbs in (" & strTm & ")"
                Dim dtMrp2 As DataTable = Cl_DataMag.GF_CreateDataSource(strSql)
                If dtMrp.Rows.Count = 0 Then
                    MsgBox("选择的产品没有相应的物料")
                    Return
                End If

                '根据需要的物料进行循环
                For Each dtRow As DataRow In dtMrp.Rows
                    Dim mm As DataRow = dt.NewRow
                    mm(0) = dtRow("tb_wp_dm") 'A物料代码
                    mm(1) = dtRow("tb_wp_wpfl")
                    mm(2) = dtRow("tb_wp_pm")
                    mm(3) = dtRow("tb_wp_ggxh")
                    mm(4) = dtRow("tb_wp_dw")
                    mm(5) = dtRow("tb_wp_wllb")
                    '计算物料需求量
                    Dim iXql As Integer = 0
                    Dim drScl As DataRow() = dtMrp2.Select("tb_mrp_wpdm='" & dtRow("tb_wp_dm").ToString() & "'")
                    For i As Integer = 0 To drScl.Length - 1
                        Dim iSzl As Double = Convert.ToDouble(dtTm.Select("tb_cpdmhz_ID='" & drScl(i)("tb_mrp_cpbs").ToString() & "'")(0)("生产量").ToString())
                        Dim iBzl As Double = Convert.ToDouble(drScl(i)("tb_mrp_blz").ToString())
                        Dim iJzzl As Double = Convert.ToDouble(Cl_StrMag.YanFormatNum(dtTm.Select("tb_cpdmhz_ID='" & drScl(i)("tb_mrp_cpbs").ToString() & "'")(0)("tb_cpdmhz_cpjz")))
                        '需求量=生产量 * （标量/基准重量）
                        iXql += Convert.ToDouble(IIf(iJzzl = 0, 0, iSzl * (iBzl / iJzzl)).ToString())
                    Next
                    mm(8) = iXql
                    mm(10) = dtRow("tb_wp_aqkc")
                    mm(12) = dtRow("tb_wp_cgzq")
                    mm(13) = dtRow("tb_wp_jjcgl")


                    Dim sql2 As String = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a= '" & dtRow("tb_wp_dm").ToString() & "'"
                    Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
                    mm(6) = Null2zero(dt2.Rows(0)(0)) '仓库存量
                    Dim sql3 As String = "select sum(tb_qgcg_qgsl)  from tb_qgcg where tb_qgcg_dm = '" & dtRow("tb_wp_dm").ToString() & "' and  tb_qgcg_xbid is null "
                    Dim dt3 As DataTable = GF_CreateDataSource(G_cnnstr, sql3)
                    Dim sql4 As String = "select sum(tb_cg_qgsl) from tb_cg where tb_cg_dm = '" & dtRow("tb_wp_dm").ToString() & "'and  tb_cg_xbid is null"
                    Dim dt4 As DataTable = GF_CreateDataSource(G_cnnstr, sql4)
                    mm(7) = Null2zero(dt3.Rows(0)(0)) + Null2zero(dt4.Rows(0)(0))  '在途量
                    mm(9) = FormatNumber(mm(6) + mm(7) - mm(8) - mm(10), 2) '计划请购量
                    If mm(9) <= 0 Then
                        mm(11) = "否"
                    Else
                        mm(11) = "是"
                    End If
                    mm(14) = 0 '差异
                    Dim sql5 As String = "select tb_wp_njzq from tb_wp where tb_wp_dm = '" & dtRow("tb_wp_dm").ToString() & "'"
                    Dim dt5 As DataTable = GF_CreateDataSource(G_cnnstr, sql5)
                    If dt5.Rows.Count - 1 < 0 Then
                        mm(15) = ""
                    Else
                        mm(15) = dt5.Rows(0)(0) '内检周期
                    End If
                    Dim sql6 As String = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a = '" & dtRow("tb_wp_dm").ToString() & "'and tb_i259b_qaspjg <>'合格'"
                    Dim dt6 As DataTable = GF_CreateDataSource(G_cnnstr, sql6)
                    mm(16) = Null2zero(dt6.Rows(0)(0)) '尚未合格量
                    dt.Rows.Add(mm)
                Next

                '''''''''''''''''''
                'AddNewRow() ' 根据BC物料代码构造DATATABLE

                ChangeColor(dtgrid, 11) '仓库存量和在途量都为0 则不显示

                RemoveIndex(dtgrid) '是否满足需求为否显示红色
            End With
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        SavetoMrpWeight(listview1)
        Me.Close()
    End Sub
    Private Sub AddNewRow() ' 根据BC物料代码构造DATATABLE 没有需求量
        '''''''''''
        Dim f As Frwljhbb = CType(Me.Owner, Frwljhbb)
        Dim dtgrid As DataGridView = f.show1
        Dim dt As DataTable = CType(dtgrid.DataSource, DataTable)
        '''''''''''''''
        Dim sql1 As String = "select tb_i259b_i231a from tb_i259b group by tb_i259b_i231a "
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
        Dim mm As String = ""
        Dim tt As String = ""
        For i As Integer = 0 To dt1.Rows.Count - 1
            mm &= dt1.Rows(i)(0).ToString() & "," 'BC物料代码
        Next
        mm = DeepCode.DeepDoStr.GF_removedh(mm)
        Dim rr() As String = mm.Split(CChar(","))
        For j As Integer = 0 To UBound(rr)

            If InStr(ww, rr(j)) = 0 Then
                tt &= rr(j) & ","
            End If
        Next
        tt = DeepCode.DeepDoStr.GF_removedh(tt) 'BC物料代码
        Dim bc() As String = tt.Split(CChar(",")) 'BC物料代码数组
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
            Dim sql44 As String = "select sum(tb_cg_qgsl) from tb_cg where tb_cg_dm = '" & bc(i) & "'and  tb_cg_xbid is null"
            Dim dt44 As DataTable = GF_CreateDataSource(G_cnnstr, sql44)
            pp(7) = Null2zero(dt33.Rows(0)(0)) + Null2zero(dt44.Rows(0)(0))  '在途量
            pp(9) = FormatNumber(pp(6) + pp(7) - pp(8) - pp(10), 2) '计划请购量
            If pp(9) <= 0 Then
                pp(11) = "否"
            Else
                pp(11) = "是"
            End If
            pp(14) = 0 '差异
            Dim sql5 As String = "select tb_wp_njzq from tb_wp where tb_wp_dm = '" & bc(i) & "'"
            Dim dt5 As DataTable = GF_CreateDataSource(G_cnnstr, sql5)
            If dt5.Rows.Count - 1 < 0 Then
                pp(15) = ""
            Else
                pp(15) = dt5.Rows(0)(0) '内检周期
            End If
            Dim sql6 As String = "select sum(tb_i259b_ckcl) from tb_i259b where tb_i259b_i231a = '" & bc(i) & "'and tb_i259b_qaspjg <>'合格'"
            Dim dt6 As DataTable = GF_CreateDataSource(G_cnnstr, sql6)
            pp(16) = Null2zero(dt6.Rows(0)(0)) '尚未合格量
            dt.Rows.Add(pp)
        Next
    End Sub

    Private Sub showsj() '初始化产品产能汇总表
        Dim sql As String = "select tb_cpdmhz_cpdm,tb_cpdmhz_jgdm,tb_cpdmhz_cpjz, 0 as '生产量',tb_cpdmhz_ID,tb_cpdmhz_njzq,tb_cpdmhz_cpy,tb_cpdmhz_my,tb_cpdmhz_gjt,tb_cpdmhz_2a01a001,tb_cpdmhz_2a01a002,tb_cpdmhz_2a01a003,tb_cpdmhz_2a01a007,tb_cpdmhz_2a02a008,tb_cpdmhz_2a02a002,tb_cpdmhz_2a01a006,tb_cpdmhz_2a02a005,tb_cpdmhz_2a02a007,tb_cpdmhz_2a02a009,tb_cpdmhz_2a02a006,tb_cpdmhz_2a02a001,tb_cpdmhz_2a02a011,tb_cpdmhz_2a02a012,tb_cpdmhz_2a04a001,tb_cpdmhz_2a04a002,tb_cpdmhz_2a04a003,tb_cpdmhz_2a04a004,tb_cpdmhz_2a04a005,tb_cpdmhz_2a04a006,tb_cpdmhz_2a04a007,tb_cpdmhz_2a04a010,tb_cpdmhz_5a01a006,tb_cpdmhz_5a02a001,tb_cpdmhz_5a03a002,tb_cpdmhz_5a03a003,tb_cpdmhz_5a01a009,tb_cpdmhz_3a08a003,tb_cpdmhz_5a02a003,tb_cpdmhz_5a03a004,tb_cpdmhz_5a02a004,tb_cpdmhz_5a03a006,tb_cpdmhz_5a01a004,tb_cpdmhz_3a06a001,tb_cpdmhz_3a08a004,tb_cpdmhz_3a08a002,tb_cpdmhz_3a08a005,tb_cpdmhz_3a07a010,tb_cpdmhz_3a07a011,tb_cpdmhz_3a07a020,tb_cpdmhz_2a04a014,tb_cpdmhz_3a08a001,tb_cpdmhz_3a09a006,tb_cpdmhz_3a09a021,tb_cpdmhz_5a03a005,tb_cpdmhz_5a02a002,tb_cpdmhz_3a07a019,tb_cpdmhz_3a09a022,tb_cpdmhz_3a08a019,tb_cpdmhz_3a08a020 from tb_cpdmhz where tb_cpdmhz_yxx='有效' "
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
            For j As Integer = 5 To .Columns.Count - 1
                listview1.Columns(j).Visible = False
            Next
        End With

    End Sub
    Private Sub ChangeColor(ByVal DateGridName As DataGridView, ByVal Index As Integer) '是否满足需求为否显示红色
        With DateGridName
            For i As Integer = 0 To .Rows.Count - 1
                Dim sf As String = Null2String(.Rows(i).Cells(Index).Value)
                If sf = "否" Then
                    .Rows(i).Cells(Index).Style.BackColor = Color.Red
                End If
            Next
        End With
    End Sub
    Private Sub RemoveIndex(ByVal DateGridName As DataGridView) '仓库存量和在途量都为0 则不显示

        Dim dd As String = ""
        For i As Integer = 0 To DateGridName.Rows.Count - 1
            Dim ckzl As Double = Null2zero(DateGridName.Rows(i).Cells(6).Value)
            Dim xql As Double = Null2zero(DateGridName.Rows(i).Cells(7).Value)
            If ckzl = 0.0 And xql = 0.0 Then
                dd = dd & i & ","
            End If
        Next
        dd = DeepCode.DeepDoStr.GF_removedh(dd)
        If dd = "" Then
            Return
        End If
        Dim crlrsz() As String = dd.Split(CChar(","))
        For j As Integer = 0 To crlrsz.Length - 1
            Dim sy As Integer = CInt(CDbl(crlrsz(j)) - j)
            DateGridName.Rows.RemoveAt(sy)
        Next
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