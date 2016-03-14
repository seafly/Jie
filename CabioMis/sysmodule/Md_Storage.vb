Module Md_Storage

    '打开提取仓库界面
    Public Sub GS_Storage(ByVal str As Form, ByVal num As String, ByVal Conkc As Control, ByVal tbname As String, ByVal id As String,Optional ByVal pBlsf As Boolean=False)

        Dim sql As String = "select tb_biaozdinf_mx,tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao='" & tbname.Replace(vbCrLf, "").Trim & "' and (tb_biaozdinf_mc like '%bfb%'or tb_biaozdinf_mc like '%kdlk%' or tb_biaozdinf_mc like '%storage%') "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim aa As New Frstorage
        aa.Num = num
        aa.Conkc = Conkc

        With aa.ListView1
            .Clear()
            .Visible = True
            .CausesValidation = False
            .View = View.Details
            .LabelEdit = True
            .BeginUpdate()

            If id = "" Then
                .Columns.Add("提取重量", CType(.Width / 2, Integer), HorizontalAlignment.Center)
                .Columns.Add("仓库名称", CType(.Width / 2, Integer), HorizontalAlignment.Center)
                .Columns.Add("字段名", CType(0, Integer), HorizontalAlignment.Center)

                For i As Integer = 0 To dt.Rows.Count - 1
                    .Items.Add(0) '数量
                    .Items(i).SubItems.Add(dt.Rows(i)("tb_biaozdinf_mx")) '冷库名称
                    .Items(i).SubItems.Add(dt.Rows(i)("tb_biaozdinf_mc")) '字段名
                Next

            Else

                .Columns.Add("提取重量", CType(.Width / 3, Integer), HorizontalAlignment.Center)
                .Columns.Add("仓库名称", CType(.Width / 3, Integer), HorizontalAlignment.Center)
                .Columns.Add("仓库库存", CType(.Width / 3, Integer), HorizontalAlignment.Center)
                .Columns.Add("字段名", CType(0, Integer), HorizontalAlignment.Center)

                Dim j As Integer = 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim sql2 As String = "select " & dt.Rows(i)("tb_biaozdinf_mc") & " from " & tbname & " where  " & tbname & "_id = '" & id & "' "
                    Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
                    If dt2.Rows(0)(0).ToString > 0 Or pBlsf Then
                        .Items.Add(0) '数量
                        .Items(j).SubItems.Add(dt.Rows(i)("tb_biaozdinf_mx")) ''冷库名称
                        .Items(j).SubItems.Add(dt2.Rows(0)(0).ToString) '仓库库存
                        .Items(j).SubItems.Add(dt.Rows(i)("tb_biaozdinf_mc")) ' 字段名    
                        j += 1
                    End If
                Next

            End If

            .EndUpdate()

        End With

        str.AddOwnedForm(aa)
        aa.ShowDialog()

    End Sub

    '更新添加仓库信息表
    Public Sub UpdateTbname(ByVal sbid As String, ByVal tbname As String, ByVal sl As String, ByVal zdm As String)

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select * from " & tbname & " where " & tbname & "_id=" & sbid
        RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim ArraySl() As String = sl.Split(",")
        Dim ArrayZdm() As String = zdm.Split(",")

        For i As Integer = 0 To ArrayZdm.Length - 1

            RS(ArrayZdm(i)).value = Convert.ToDouble(ArraySl(i))

        Next

        RS.update()
        RS.close()
        RS = Nothing
        cnn.close()
        cnn = Nothing
    End Sub

    ' 更新有关仓库信息库存表

    Public Function ReturnTbname(ByVal sbid As String, ByVal tbname As String, ByVal sl As String, ByVal zdm As String) As Boolean

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select * from " & tbname.Trim & " where " & tbname.Trim & "_id=" & sbid
        RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim ArraySl() As String = sl.Split(",")
        Dim ArrayZdm() As String = zdm.Split(",")

        For i As Integer = 0 To ArrayZdm.Length - 1

            RS(ArrayZdm(i)).value = RS(ArrayZdm(i)).value - Convert.ToDouble(ArraySl(i))
            If RS(ArrayZdm(i)).value < 0 Then
                Dim lkmc As String = GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & ArrayZdm(i) & "'", 4) '冷库名称
                MessageBox.Show("该批号的" & lkmc & "为负数！")
                Return False
            End If
        Next

        RS.update()
        RS.close()
        RS = Nothing
        cnn.close()
        cnn = Nothing
        Return True
    End Function
    '冷库负数
    Public Function GF_ZlNew(ByVal str As TextBox) As String
        Dim storage() As String = str.Text.Split(",")
        Dim a As String = ""
        For Each k As Double In storage
            a &= k * -1 & ","
        Next
        a = GF_removedh(a)
        Return a
    End Function
    Public Function Gf_ZdNew(ByVal str1 As String, ByVal str2 As String, ByVal str3 As TextBox)
        Dim b As String = str3.Tag
        Dim c As String = b.Replace(str1, str2)
        Return c
    End Function
End Module
