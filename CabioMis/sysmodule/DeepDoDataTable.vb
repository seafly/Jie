Public Class DeepDoDataTable
    'DataTable操作类
    '设置主键
    Public Shared Function AddPrimaryKey(ByVal ColIndex As Integer, ByVal db As DataTable) As Boolean
        Try
            With db '设置主键示例
                Dim key(0) As DataColumn
                key(0) = .Columns(ColIndex)
                .PrimaryKey = key
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    '删除主键标识的行
    Public Shared Sub RemoveRowByKey(ByVal strkey As String, ByVal db As DataTable)
        Dim rowCollection As DataRowCollection = db.Rows
        If rowCollection.Contains(strkey) Then
            Dim foundRow As DataRow = rowCollection.Find(strkey)
            rowCollection.Remove(foundRow)
        End If
    End Sub
    '查找主键标识的行
    Public Shared Function GetRowByKey(ByVal strkey As String, ByVal db As DataTable) As DataRow
        GetRowByKey = Nothing
        Dim rowCollection As DataRowCollection = db.Rows
        If rowCollection.Contains(strkey) Then
            Dim foundRow As DataRow = rowCollection.Find(strkey)
            Return foundRow
        End If
    End Function
    '删除DataTable中的列，参数str表示要删除的列，多个用逗号隔开
    Public Shared Function DelDataColAtIndex(ByVal db As DataTable, ByVal str As String) As DataTable
        Dim kk() As String = str.Split(",")
        Dim nn(UBound(kk)) As Integer
        For i As Integer = 0 To UBound(kk)
            nn(i) = kk(i)
        Next
        Array.Sort(nn)
        For i As Integer = 0 To UBound(nn)
            Dim ls As Integer = nn(i) - i
            db.Columns.RemoveAt(ls)
        Next
        Return db
    End Function
    '删除DataTable中的行，参数str表示要删除的行，多个用逗号隔开
    Public Shared Function DelDataRowAtIndex(ByVal db As DataTable, ByVal str As String) As DataTable
        Dim kk() As String = str.Split(",")
        Dim nn(UBound(kk)) As Integer
        For i As Integer = 0 To UBound(kk)
            nn(i) = kk(i)
        Next
        Array.Sort(nn)
        For i As Integer = 0 To UBound(nn)
            Dim ls As Integer = nn(i) - i
            db.Rows.RemoveAt(ls)
        Next
        Return db
    End Function
    '数据处理模块'建立一个矩阵以获取数据库内容
    Public Shared Function GF_CreateDataSource(ByVal strcnn As String, ByVal strsql As String) As DataTable
        Dim DS As New System.Data.DataSet
        Dim MyCommand As New System.Data.OleDb.OleDbDataAdapter
        Dim MyConnection As New System.Data.OleDb.OleDbConnection
        MyConnection = New System.Data.OleDb.OleDbConnection(strcnn)
        MyCommand = New System.Data.OleDb.OleDbDataAdapter(strsql, MyConnection)
        MyCommand.Fill(DS)
        MyConnection.Close() : MyCommand = Nothing
        GF_CreateDataSource = DS.Tables(0)
        DS.Dispose()
    End Function

    '在DataTable中查询返回 一个DataRow数组
    Public Shared Function GF_czmc(ByVal Db As DataTable, ByVal cxstr As String) As DataRow()
        Dim foundRows() As DataRow
        foundRows = Db.Select(cxstr)
        Return foundRows
    End Function
    '在DataTable中查询返回 一个DataTable.按照指定的排序方式pxstr
    Public Function GF_czmctb(ByVal tbmc As DataTable, ByVal cxstr As String, ByVal pxstr As String) As DataTable
        Dim foundRows() As DataRow
        foundRows = tbmc.Select(cxstr, pxstr)
        Dim n1 As DataTable = tbmc.Clone
        For i As Integer = 0 To foundRows.Length - 1
            n1.ImportRow(foundRows(i))
        Next
        Return n1
    End Function
    '在DataTable中查询返回 一个DataTable
    Public Function GF_czmctb(ByVal tbmc As DataTable, ByVal cxstr As String) As DataTable
        Dim foundRows() As DataRow
        foundRows = tbmc.Select(cxstr)
        Dim n1 As DataTable = tbmc.Clone
        For i As Integer = 0 To foundRows.Length - 1
            n1.ImportRow(foundRows(i))
        Next
        Return n1
    End Function
    '从DB中查询一个表达式，参数分别表示DB，表达式,取第几个字段值
    Public Shared Function GF_cnwithen(ByVal Db As DataTable, ByVal cxstr As String, ByVal Dbindex As Integer) As String
        Dim foundrow() As DataRow
        Try
            foundrow = GF_czmc(Db, cxstr)
            Return foundrow(0)(Dbindex).ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '计算DataTable中某一列所有数字的合计值
    Public Shared Function GF_jsColumnTotal(ByVal Db As DataTable, ByVal ColIndex As Integer, ByVal RowBegin As Integer, ByVal RowEnd As Integer) As Double
        Dim jsTotal As Double = 0
        For i As Integer = RowBegin To RowEnd
            Try
                jsTotal = jsTotal + CDbl(Db.Rows(i)(ColIndex))
            Catch ex As Exception
            End Try
        Next
        Return jsTotal
    End Function
    '计算DataTable中某一行所有数字的合计值
    Public Shared Function GF_jsRowTotal(ByVal Db As DataTable, ByVal RowIndex As Integer, ByVal ColBegin As Integer, ByVal ColEnd As Integer) As Double
        Dim jsTotal As Double = 0
        For i As Integer = ColBegin To ColEnd
            Try
                jsTotal = jsTotal + CDbl(Db.Rows(RowIndex)(i))
            Catch ex As Exception
            End Try
        Next
        Return jsTotal
    End Function
    '数据库一个不带返回值的SQL语句过程
    Public Sub GS_upztxx(ByVal str1 As String, ByVal str2 As String)
        Dim cnn As New OleDb.OleDbConnection(str1)
        cnn.Open()
        Dim myread As New OleDb.OleDbCommand(str2, cnn)
        myread.ExecuteNonQuery()
        myread = Nothing : cnn.Close()
    End Sub

    '数据库一个不带返回值的SQL语句过程;str3表,结果得到插入的新ID
    '连接字符串,SQL语句,插入的表
    Public Function GF_upztxx2(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As String
        GF_upztxx2 = ""
        '    Try
        Dim cnn As New OleDb.OleDbConnection(str1)
        cnn.Open()
        Dim myread As New OleDb.OleDbCommand(str2, cnn)
        myread.ExecuteNonQuery()
        Dim rs As OleDb.OleDbDataReader
        myread.CommandText = "select @@IDENTITY from " & str3 & ""
        rs = myread.ExecuteReader()
        rs.Read()
        GF_upztxx2 = rs(0)
        rs.Close() : rs = Nothing : myread = Nothing : cnn.Close()
        '    Catch ex As Exception
        '   End Try
    End Function
    '得到信息，strsql表示查询语句，str2表示字段间隔开，行间用逗号隔开
    Public Function GF_getstringsql(ByVal strcnn As String, ByVal strsql As String, ByVal str2 As String) As String
        Dim cnn, rs As Object
        cnn = CreateObject("ADODB.Connection")
        cnn.Open(strcnn)
        rs = cnn.execute(strsql)
        Dim gndlr As String = ""
        If Not rs.eof Then
            gndlr = rs.getstring(, , str2, ",")
            gndlr = GF_removedh(gndlr) '这里得到内容，字段间用str2隔开
        End If
        rs = Nothing : cnn.close() : cnn = Nothing
        Return gndlr
    End Function

End Class
