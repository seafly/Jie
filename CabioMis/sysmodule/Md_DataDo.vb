Module Md_DataDo
    '数据处理模块
    Public Function GF_CreateDataSource(ByVal str1 As String, ByVal str2 As String) As DataTable '建立一个矩阵以获取数据库内容
        Dim DS As New System.Data.DataSet
        Dim MyCommand As New System.Data.OleDb.OleDbDataAdapter
        Dim MyConnection As New System.Data.OleDb.OleDbConnection
        MyConnection = New System.Data.OleDb.OleDbConnection(str1)
        MyCommand = New System.Data.OleDb.OleDbDataAdapter(str2, MyConnection)
        MyCommand.Fill(DS)
        MyConnection.Close() : MyCommand = Nothing
        GF_CreateDataSource = DS.Tables(0)
        DS.Dispose()
    End Function

    '数据库一个不带返回值的SQL语句过程
    Public Sub GS_upztxx(ByVal str1 As String, ByVal str2 As String)
        Dim cnn As New OleDb.OleDbConnection(str1)
        cnn.Open()
        Dim myread As New OleDb.OleDbCommand(str2, cnn)
        myread.ExecuteNonQuery()
        myread = Nothing : cnn.Close()
    End Sub

    '数据库一个不带返回值的SQL语句过程;str3表
    '连接字符串,SQL语句,插入的表
    Public Function GF_upztxx2(ByVal str1 As String, ByVal str2 As String,Optional ByVal str3 As String="") As String
        GF_upztxx2 = ""
        '    Try
        Dim cnn As New OleDb.OleDbConnection(str1)
        cnn.Open()
        Dim myread As New OleDb.OleDbCommand(str2, cnn)
        myread.ExecuteNonQuery()
        Dim rs As OleDb.OleDbDataReader
        myread.CommandText = "select SCOPE_IDENTITY();"
        rs = myread.ExecuteReader()
        rs.Read()
        GF_upztxx2 = rs(0).ToString()
        rs.Close() : rs = Nothing : myread = Nothing : cnn.Close()
        '    Catch ex As Exception
        '   End Try
    End Function

    '在DataTable中查询返回 一个DataRow数组
    Public Function GF_czmc(ByVal tbmc As DataTable, ByVal cxstr As String) As DataRow()
        Dim foundRows() As DataRow
        foundRows = tbmc.Select(cxstr)
        GF_czmc = foundRows
    End Function
    ''' <summary>
    ''' 在DataTable中查询返回 一个DataTable
    ''' </summary>
    Public Function GF_czmctb(ByVal tbmc As DataTable, ByVal cxstr As String) As DataTable
        Dim foundRows() As DataRow
        foundRows = tbmc.Select(cxstr)
        Dim n1 As DataTable = tbmc.Clone
        For i As Integer = 0 To foundRows.Length - 1
            n1.ImportRow(foundRows(i))
        Next
        GF_czmctb = n1
    End Function
    '在DataTable中查询返回 一个DataTable.按照指定的排序方式pxstr
    Public Function GF_czmctb(ByVal tbmc As DataTable, ByVal cxstr As String, ByVal pxstr As String) As DataTable
        Dim foundRows() As DataRow
        foundRows = tbmc.Select(cxstr, pxstr)
        Dim n1 As DataTable = tbmc.Clone
        For i As Integer = 0 To foundRows.Length - 1
            n1.ImportRow(foundRows(i))
        Next
        GF_czmctb = n1
    End Function
    '从DB中查询一个表达式，str0表示DB，str1表示表达式,str2表示取第几个字段值
    Public Function GF_cnwithen(ByVal str0 As DataTable, ByVal str1 As String, ByVal str2 As Integer) As String
        Dim foundrow() As DataRow
        Try
            foundrow = GF_czmc(str0, str1)
            If foundrow.Length = 0 Then
                Return ""
            End If
            GF_cnwithen = foundrow(0)(str2).ToString
        Catch ex As Exception
            GF_cnwithen = ""
        End Try
    End Function
    '更新操作记录的某个字段数据,str表，str2字段，str3表示ID，str4表示更新内容
    Public Sub GS_modczsj(ByVal strtb As String, ByVal strzd As String, ByVal strid As String, ByVal str4 As String)
        If strid.Split(",").Length > 1 Then
            _D.GS_upztxx("update  " & strtb & " set " & strzd & "='" & GF_ToDBC(str4) & "' where " & strtb & "_id in (" & strid & ")")
            Return
        End If
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select * from " & strtb & " where " & strtb & "_id=" & strid
        RS.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        RS(strzd).Value = GF_ToDBC(str4)
        RS.Update() : RS.Close() : RS = Nothing : cnn.Close() : cnn = Nothing
    End Sub
    Public Function GF_addsj(ByVal str As String, ByVal str2 As Form, ByVal strcnn As String) As String
        ' 分别代表表名。窗体名
        'Try
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = strcnn
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        RS.open(str, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        RS.addnew()
        Dim j As Integer, nn As DateTimePicker
        With str2
            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
                    Dim zdsz As String = .Controls(j).Name
                    If .Controls(j).GetType.Name = "DateTimePicker" Then

                        nn = CType(.Controls(j), DateTimePicker)
                        If nn.Checked = True Then

                            RS(zdsz).value = GF_gettrqsj(nn.Text)
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).value = DeepCode.DeepDoStr.GF_ToDBC(Trim(.Controls(j).Text))
                        End If
                    End If
                End If
            Next
        End With
        RS.update()
        GF_addsj = RS(str & "_id").Value.ToString()
        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
    End Function

    Public Function GF_addsj(ByVal str As String, ByVal str2 As Form) As String
        ' 分别代表表名。窗体名r

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        RS.open(str, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        RS.addnew()
        Dim j As Integer, nn As DateTimePicker
        With str2
            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And InStr(.Controls(j).Name, str) > 0 Then
                    Dim zdsz As String = .Controls(j).Name
                    If .Controls(j).GetType.Name = "DateTimePicker" Then

                        nn = .Controls(j)
                        If nn.Checked = True Then
                            RS(zdsz).value = GF_gettrqsj(nn.Text)
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" Then
                            Try
                                RS(zdsz).value = GF_ToDBC(Trim(.Controls(j).Text))
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                End If
            Next

        End With

        RS.update()
        GF_addsj = RS(str & "_id").Value.ToString()
        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

    End Function
    ''' <summary>
    ''' 更新数据
    ''' </summary>
    ''' <param name="str">表</param>
    ''' <param name="str2">窗体</param>
    ''' <param name="str3">标识</param>
    Public Function GF_modsj(ByVal str As String, ByVal str2 As Form, ByVal str3 As String) As Boolean
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select top 1 * from " & str & " where " & str & "_id=" & str3
        RS.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim j As Integer, nn As DateTimePicker

        With str2
            For j = 0 To .Controls.Count - 1
                '判断这个控件是否是这个表内的
                If Microsoft.VisualBasic.Left(.Controls(j).Name, Len(str)) = str Then
                    Dim zdsz As String = .Controls(j).Name

                    If .Controls(j).GetType.Name = "DateTimePicker" Then
                        nn = .Controls(j)
                        If nn.Checked = True Then
                            RS(zdsz).Value = GF_gettrqsj(nn.Text)
                        Else
                            RS(zdsz).Value = Nothing
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).Value = GF_ToDBC(Trim(str2.Controls(j).Text))
                        Else
                            RS(zdsz).Value = Nothing
                        End If
                    End If
                End If
            Next

        End With
        RS.Update()
        RS.Close()
        RS = Nothing
        cnn.Close()
        cnn = Nothing
        GF_modsj = True

    End Function
    Public Function GF_modsjpc(ByVal str As String, ByVal str2 As Form, ByVal str3 As String) As Boolean

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select top 1 * from " & str & " where " & str & "_id=" & str3
        RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim j As Integer, nn As DateTimePicker

        With str2
            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, Len(str)) = str Then
                    Dim zdsz As String = .Controls(j).Name

                    If .Controls(j).GetType.Name = "DateTimePicker" Then
                        nn = .Controls(j)
                        If nn.Checked = True Then
                            RS(zdsz).value = GF_gettrqsj(nn.Text)
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" And .Controls(j).Enabled Then
                            RS(zdsz).Value = GF_ToDBC(Trim(str2.Controls(j).Text))
                        End If
                    End If
                End If
            Next

        End With
        RS.update()
        RS.close()
        RS = Nothing
        cnn.close()
        cnn = Nothing
        GF_modsjpc = True

    End Function
    Public Function GF_modsj(ByVal str As String, ByVal str2 As Form, ByVal str3 As String, ByVal strcnn As String) As Boolean

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = strcnn
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select * from " & str & " where " & str & "_id=" & str3
        RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim j As Integer, nn As DateTimePicker
        With str2

            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
                    Dim zdsz As String = .Controls(j).Name
                    If .Controls(j).GetType.Name = "DateTimePicker" Then
                        nn = .Controls(j)
                        If nn.Checked = True Then
                            RS(zdsz).value = GF_gettrqsj(nn.Text)
                        Else
                            RS(zdsz).value = Nothing
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).value = DeepCode.DeepDoStr.GF_ToDBC(Trim(.Controls(j).Text))
                        Else
                            RS(zdsz).value = Nothing
                        End If
                    End If
                End If
            Next
        End With

        RS.update() : RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
        GF_modsj = True


    End Function
    ''' <summary>
    ''' 将数据库内的值填入窗体控件
    ''' </summary>
    ''' <param name="str">表</param>
    ''' <param name="str2">窗体</param>
    ''' <param name="str3">表对应的ID</param>
    Public Sub Gs_showsj(ByVal str As String, ByVal str2 As Form, ByVal str3 As String)
        '分别代表表名。窗体名，ID值
        If str3 = "" Then
            Return
        End If
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim sql As String = "select * from " & str & " where " & str & "_id=" & str3
        Dim RS As ADODB.Recordset = cnn.Execute(sql)
        Dim j As Integer, nn As DateTimePicker
        With str2
            For j = 0 To .Controls.Count - 1
                Try
                    If Microsoft.VisualBasic.Left(.Controls(j).Name, 3).ToLower = "tb_" Then
                        Dim zdsz As String = .Controls(j).Name
                        Dim sj As String = ""
                        Dim isExistField As Boolean = False
                        For i As Integer = 0 To RS.Fields.Count - 1
                            If RS(i).Name.ToLower = .Controls(j).Name.ToLower Then
                                isExistField = True
                                Exit For
                            End If
                        Next
                        If isExistField = False Then
                            Continue For
                        End If
                        If IsDBNull(RS(zdsz).Value) = False Then
                            sj = RS(zdsz).Value.ToString()
                        End If
                        If .Controls(j).GetType.Name = "DateTimePicker" Then
                            nn = CType(.Controls(j), DateTimePicker)
                            If sj <> "" Then
                                nn.Text = sj
                                If nn.ShowCheckBox = True Then
                                    nn.Checked = True
                                End If
                            Else
                                If nn.ShowCheckBox = True Then
                                    nn.Checked = False
                                End If
                            End If
                        End If
                        .Controls(j).Text = sj
                    End If
                Catch ex As Exception
                    'MessageBox.Show(.Controls(j).Name)
                End Try
            Next
        End With
        RS.Close() : RS = Nothing : cnn.Close() : cnn = Nothing
    End Sub
    '显示最后一条记录的明细
    Public Sub Gs_showsj2(ByVal str As String, ByVal str2 As Form, ByVal str3 As String)
        '分别代表表名。窗体名,str3代表例外控件
        str3 = GF_qhjdh(str3)
        Dim sql As String = "select top 1 * from " & str & " order by " & str & "_jgrq desc"
        Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dttemp.Rows.Count > 0 Then
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS As ADODB.Recordset = cnn.Execute(sql)
            Dim j As Integer, nn As DateTimePicker
            With str2
                For j = 0 To .Controls.Count - 1
                    Dim zdsz As String = .Controls(j).Name
                    If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And .Controls(j).Visible = True And InStr(str3, GF_qhjdh(zdsz)) = 0 Then
                        Dim sj As String = ""
                        If IsDBNull(RS(zdsz).value) = False Then
                            sj = RS(zdsz).Value.ToString()
                        End If
                        If .Controls(j).GetType.Name = "chendatepick" Then
                            sj = Date.Now.ToString("yyyy-MM-dd hh:mm;ss")
                        End If
                        If .Controls(j).GetType.Name = "DateTimePicker" Then
                            nn = CType(.Controls(j), DateTimePicker)
                            If sj <> "" Then
                                nn.Text = sj
                                If nn.ShowCheckBox = True Then
                                    nn.Checked = True
                                End If

                            Else

                                If nn.ShowCheckBox = True Then
                                    nn.Checked = False
                                End If
                            End If
                        End If
                        .Controls(j).Text = sj
                    End If
                Next
            End With
            RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

        End If
    End Sub
    '计算DataTable中某一列所有数字的合计值
    Public Function GF_jsColumnTotal(ByVal db As DataTable, ByVal n As Integer, ByVal n1 As Integer, ByVal n2 As Integer) As Double
        Dim jsTotal As Double = 0
        For i As Integer = n1 To n2
            Try
                jsTotal = jsTotal + CDbl(Null2zero2(db.Rows(i)(n)))
            Catch ex As Exception
            End Try
        Next
        GF_jsColumnTotal = jsTotal
    End Function

    ''计算DataTable中某一行所有数字的合计值
    Public Function GF_jsRowAvg(ByVal db As DataTable, ByVal n As Integer, ByVal n1 As Integer, ByVal n2 As Integer) As Double
        Dim jsTotal As Double = 0
        Dim temp As Double = 0
        Dim count As Integer = 0
        For i As Integer = n1 To n2
            Try
                temp = jsTotal
                jsTotal = jsTotal + CDbl(Null2zero2(db.Rows(n)(i)))
                If jsTotal > temp Then
                    count += 1
                End If
            Catch ex As Exception
            End Try
        Next
        GF_jsRowAvg = jsTotal / count
    End Function

    '计算DataTable中某一行所有数字的合计值

    Public Function GF_jsRowTotal(ByVal db As DataTable, ByVal n As Integer, ByVal n1 As Integer, ByVal n2 As Integer) As Double
        Dim jsTotal As Double = 0
        For i As Integer = n1 To n2
            Try
                jsTotal = jsTotal + CDbl(Null2zero2(db.Rows(n)(i)))
            Catch ex As Exception
            End Try
        Next
        GF_jsRowTotal = jsTotal
    End Function
    'DataTable行列数据互换
    Public Function GF_DataTableChange(ByVal db1 As DataTable) As DataTable
        Dim db2 As DataTable = New DataTable
        db2.Columns.Add(db1.Columns(0).Caption, Type.GetType("System.String"))
        For i As Integer = 0 To db1.Rows.Count - 1
            db2.Columns.Add(db1.Rows(i)(0).ToString(), Type.GetType("System.String"))
        Next
        For m As Integer = 1 To db1.Columns.Count - 1
            Dim aaRow As DataRow = db2.NewRow()
            aaRow(0) = db1.Columns(m).Caption
            For n As Integer = 1 To db1.Rows.Count
                aaRow(n) = db1.Rows(n - 1)(m).ToString
            Next
            db2.Rows.Add(aaRow)
        Next
        GF_DataTableChange = db2
    End Function

    '将dt_temp的数据合并到dbTol中
    Public Sub hbDT(ByVal dt_temp As DataTable, ByVal dbTol As DataTable)
        Dim aaRow As DataRow
        For n As Integer = 0 To dt_temp.Rows.Count - 1
            aaRow = dbTol.NewRow()
            aaRow(0) = dt_temp.Rows(n)(0)
            For ii As Integer = 1 To dbTol.Columns.Count - 1
                For m As Integer = 1 To dt_temp.Columns.Count - 1
                    If dbTol.Columns(ii).Caption = dt_temp.Columns(m).Caption Then
                        aaRow(ii) = dt_temp.Rows(n)(m)
                        GoTo ss
                    End If
                Next
ss:
            Next
            dbTol.Rows.Add(aaRow)
        Next
    End Sub
    '得到字符串信息，str表示查询语句，str2表示字段间隔开，行间用逗号隔开
    Public Function GF_getstringsql(ByVal strcnn As String, ByVal str As String, ByVal str2 As String) As String
        Dim cnn As ADODB.Connection, rs As ADODB.Recordset
        cnn = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.Open(strcnn)
        rs = cnn.execute(str)
        Dim gndlr As String = ""
        If Not rs.eof Then
            gndlr = rs.getstring(, , str2, ",")
            gndlr = GF_removedh(gndlr) '这里得到内容，字段间用str2隔开
        End If
        rs = Nothing : cnn.close() : cnn = Nothing
        Return gndlr
    End Function
    ''' <summary>
    ''' 检测某字段的同样的值有多少个，可以用来判断数据重复
    ''' </summary>
    ''' <param name="strcnn"></param>
    ''' <param name="TableName"></param>
    ''' <param name="Field"></param>
    ''' <param name="FieldValue"></param>
    ''' <returns>返回多少</returns>
    ''' <remarks></remarks>
    Public Function GF_CheckRepeat(ByVal strcnn As String, ByVal TableName As String, ByVal Field As String, ByVal FieldValue As String) As Integer '
        Dim sql As String = "select count(*) from " & TableName & "  where " & Field & "='" & FieldValue & "'"
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(strcnn, Sql)
        Return Convert.ToInt32(dt1.Rows(0)(0).ToString())
    End Function
    ''' <summary>
    ''' 检测某表达式在数据库的数据条数
    ''' </summary>
    ''' <param name="strcnn"></param>
    ''' <param name="TableName"></param>
    ''' <param name="SQLBDS">表达式</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GF_CheckRepeat(ByVal strcnn As String, ByVal TableName As String, ByVal SQLBDS As String) As Integer '
        Dim sql As String = "select count(*) from " & TableName & "  where 1=1 and " & SQLBDS
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(strcnn, sql)
        Return Convert.ToInt32(dt1.Rows(0)(0).ToString())
    End Function
End Module
