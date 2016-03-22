Public Class DeepDoFileToDb
    '��������������ļ����������ݿ�
    'ע��ֻ��֧��SQLSERVER��ACCESS
    '���Ӵ���ʹ��OLEDB��ʽ��ʹ�ñ���_ID�ṹ
    Private _cnnstr, _cnntb, _cnncol As String
    Private _whatdb As String '�����Ǻ������ݿ�
    '���캯����ָ�����ݿ����Ӵ��Ͳ����ı��������ֶ���
    Sub New(ByVal cnnstr As String, ByVal cnntb As String, ByVal cnncol As String)
        _cnnstr = cnnstr : _cnntb = cnntb : _cnncol = cnncol
        If InStr(_cnnstr, "sqloledb") > 0 Then 'SQLSERVER
            _whatdb = "SQLSERVER"
        Else
            _whatdb = "ACCESS"
        End If
    End Sub

    '�浽���ݿ⣬���ظոմ����ID������Ϊ��
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

    '�����ļ�����ַ����Ҫ��ַ������ID�������ɹ�TrueΪʧ��ΪFalse
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

    ' �����ļ��ֶΣ���Ҫ��ַ��ID����
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

    '������ַ��������ΪNULL
    Public Function UpdateFile(ByVal sqlid As Integer) As Boolean '������ַ��������ΪNULL
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

    '�õ��ļ���С,�ֽڵ�λ
    Public Shared Function GetFileSize(ByVal filepath As String) As Long
        Dim fi As System.IO.FileInfo = New System.IO.FileInfo(filepath)
        GetFileSize = fi.Length
        fi = Nothing
    End Function

    '�õ��ļ���
    Public Shared Function GetFileName(ByVal filepath As String) As String
        Dim fi As System.IO.FileInfo = New System.IO.FileInfo(filepath)
        GetFileName = fi.Name
        fi = Nothing
    End Function

#Region "�ڲ�˽�к�������"
    '����ACCESS,����ID
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
    '����SQLSERVER,����ID
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
    '����access�ļ��ֶ�
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
    '����SQLSERVER�ļ��ֶ�
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
    '�������Ϊ����ȡOLEDB���������
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
