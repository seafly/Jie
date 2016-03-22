Public Class DeepDoFileToDb
    '负责操作二进制文件存入存出数据库
    '注意只是支持SQLSERVER和ACCESS
    '连接串请使用OLEDB方式，使用表名_ID结构
    Private _cnnstr, _cnntb, _cnncol As String
    Private _whatdb As String '定义是何种数据库
    '构造函数，指定数据库连接串和操作的表，操作的字段名
    Sub New(ByVal cnnstr As String, ByVal cnntb As String, ByVal cnncol As String)
        _cnnstr = cnnstr : _cnntb = cnntb : _cnncol = cnncol
        If InStr(_cnnstr, "sqloledb") > 0 Then 'SQLSERVER
            _whatdb = "SQLSERVER"
        Else
            _whatdb = "ACCESS"
        End If
    End Sub

    '存到数据库，返回刚刚储存的ID，错误为空
    Public Function InsertToDb(ByVal filepath As String) As String
        InsertToDb = ""
        Dim fs As System.IO.FileStream = New System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim DSize As Integer = fs.Length
        Dim bt(DSize - 1) As Byte
        fs.Read(bt, 0, DSize)
        fs.Close() : fs = Nothing
        If _whatdb = "SQLSERVER" Then
            InsertToDb = tosql(bt)
        Else
            InsertToDb = toaccess(bt)
        End If
    End Function

    '保存文件到地址，需要地址参数和ID参数，成功True为失败为False
    Public Function DownFile(ByVal filepath As String, ByVal sqlid As Integer) As Boolean
        Try
            Dim cnn As New OleDb.OleDbConnection(_cnnstr)
            cnn.Open()
            Dim sql As String = "SELECT " & _cnncol & " FROM " & _cnntb & " where " & _cnntb & "_id=" & sqlid
            Dim myread As New OleDb.OleDbCommand(sql, cnn)
            Dim rs As OleDb.OleDbDataReader
            rs = myread.ExecuteReader()
            rs.Read()
            Dim bt() As Byte = rs(0)
            rs.Close() : rs = Nothing : myread = Nothing : cnn.Close() : cnn = Nothing
            System.IO.File.WriteAllBytes(filepath, bt)
            DownFile = True
        Catch ex As Exception
            DownFile = False
        End Try
    End Function

    ' 更新文件字段，需要地址和ID参数
    Public Function UpdateFile(ByVal filepath As String, ByVal sqlid As Integer) As Boolean
        Dim fs As System.IO.FileStream = New System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim DSize As Integer = fs.Length
        Dim bt(DSize - 1) As Byte
        fs.Read(bt, 0, DSize)
        fs.Close() : fs = Nothing
        If _whatdb = "SQLSERVER" Then
            UpdateFile = utosql(bt, sqlid)
        Else
            UpdateFile = utoaccess(bt, sqlid)
        End If
    End Function

    '不带地址参数更新为NULL
    Public Function UpdateFile(ByVal sqlid As Integer) As Boolean '不带地址参数更新为NULL
        Try
            Dim cnn As New OleDb.OleDbConnection(_cnnstr)
            cnn.Open()
            Dim myread As New OleDb.OleDbCommand
            myread.Connection = cnn
            myread.CommandText = "update " & _cnntb & "  set " & _cnncol & "=null " & _cnntb & "_id=" & sqlid
            myread.ExecuteNonQuery()
            myread = Nothing : cnn.Close() : cnn = Nothing
            UpdateFile = True
        Catch ex As Exception
            UpdateFile = False
        End Try
    End Function

    '得到文件大小,字节单位
    Public Shared Function GetFileSize(ByVal filepath As String) As Long
        Dim fi As System.IO.FileInfo = New System.IO.FileInfo(filepath)
        GetFileSize = fi.Length
        fi = Nothing
    End Function

    '得到文件名
    Public Shared Function GetFileName(ByVal filepath As String) As String
        Dim fi As System.IO.FileInfo = New System.IO.FileInfo(filepath)
        GetFileName = fi.Name
        fi = Nothing
    End Function

#Region "内部私有函数操作"
    '存入ACCESS,返回ID
    Private Function toaccess(ByVal bt() As Byte) As String
        Try
            Dim cnn As New OleDb.OleDbConnection(_cnnstr)
            cnn.Open()
            Dim myread As New OleDb.OleDbCommand
            myread.Connection = cnn
            myread.CommandText = "Insert Into " & _cnntb & " (" & _cnncol & ") Values (@img) "
            myread.Parameters.Add("@img", OleDb.OleDbType.VarBinary).Value = bt
            myread.ExecuteNonQuery()
            myread.CommandText = "select @@IDENTITY from  " & _cnntb
            Dim rs As OleDb.OleDbDataReader
            rs = myread.ExecuteReader()
            rs.Read() : toaccess = rs(0) : rs.Close() : rs = Nothing
            myread = Nothing : cnn.Close() : cnn = Nothing
        Catch ex As Exception
            toaccess = ""
        End Try

    End Function
    '存入SQLSERVER,返回ID
    Private Function tosql(ByVal bt() As Byte) As String
        Try
            Dim cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Server=" & getzfc(_cnnstr, "Data Source=") & ";User Id=" & getzfc(_cnnstr, "User ID=") & ";Password=" & getzfc(_cnnstr, "Password=") & ";Database=" & getzfc(_cnnstr, "Initial Catalog="))
            cnn.Open()
            Dim myread As New SqlClient.SqlCommand
            myread.Connection = cnn
            myread.CommandText = "Insert Into " & _cnntb & " (" & _cnncol & ") Values (@img) "
            myread.Parameters.Add("@img", SqlDbType.Image).Value = bt
            myread.ExecuteNonQuery()
            myread.CommandText = "select @@IDENTITY from  " & _cnntb
            Dim rs As SqlClient.SqlDataReader
            rs = myread.ExecuteReader()
            rs.Read() : tosql = rs(0) : rs.Close() : rs = Nothing
            myread = Nothing : cnn.Close() : cnn = Nothing
        Catch ex As Exception
            tosql = ""
        End Try
    End Function
    '更新access文件字段
    Private Function utoaccess(ByVal bt() As Byte, ByVal sqlid As Integer) As Boolean
        Try
            Dim cnn As New OleDb.OleDbConnection(_cnnstr)
            cnn.Open()
            Dim myread As New OleDb.OleDbCommand
            myread.Connection = cnn
            myread.CommandText = "update " & _cnntb & "  set " & _cnncol & "=@img  where " & _cnntb & "_id=" & sqlid
            myread.Parameters.Add("@img", OleDb.OleDbType.VarBinary).Value = bt
            myread.ExecuteNonQuery()
            myread = Nothing : cnn.Close() : cnn = Nothing
            utoaccess = True
        Catch ex As Exception
            utoaccess = False
        End Try

    End Function
    '更新SQLSERVER文件字段
    Private Function utosql(ByVal bt() As Byte, ByVal sqlid As Integer) As Boolean
        Try
            Dim cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Server=" & getzfc(_cnnstr, "Data Source=") & ";User Id=" & getzfc(_cnnstr, "User ID=") & ";Password=" & getzfc(_cnnstr, "Password=") & ";Database=" & getzfc(_cnnstr, "Initial Catalog="))
            cnn.Open()
            Dim myread As New SqlClient.SqlCommand
            myread.Connection = cnn
            myread.CommandText = "update " & _cnntb & "  set " & _cnncol & "=@img  where " & _cnntb & "_id=" & sqlid
            myread.Parameters.Add("@img", SqlDbType.Image).Value = bt
            myread.ExecuteNonQuery()
            myread = Nothing : cnn.Close() : cnn = Nothing
            utosql = True
        Catch ex As Exception
            utosql = False
        End Try
    End Function
    '这个函数为了提取OLEDB的输入参数
    Private Function getzfc(ByVal str1 As String, ByVal str2 As String) As String
        Dim t As Integer = InStr(str1, str2)
        Dim t2 As Integer = Len(str2)
        Dim t3 As Integer = InStr(t, str1, ";")
        Dim ss As String = ""
        If t3 = 0 Then
            ss = Mid(str1, t + t2)
        Else
            ss = Mid(str1, t + t2, t3 - t - t2)
        End If
        getzfc = ss
    End Function
#End Region
End Class
