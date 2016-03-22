Imports System.IO
Public Class DeepDoZipFile
    '压缩
    Public Shared Sub CompressFile(ByVal InFile As String, ByVal OutFile As String)
        Using instream As New FileStream(InFile, FileMode.Open, FileAccess.Read, FileShare.None, 4096)
            Using outstream As New FileStream(OutFile, FileMode.Create)
                Using zipstream As New Compression.GZipStream(outstream, Compression.CompressionMode.Compress)
                    Dim buffer(4095) As Byte
                    Do
                        Dim readbytes As Integer = instream.Read(buffer, 0, buffer.Length)
                        If readbytes = 0 Then Exit Do
                        zipstream.Write(buffer, 0, readbytes)
                    Loop
                    zipstream.Flush()
                End Using
            End Using
        End Using
    End Sub
    '解压缩
    Public Shared Sub UnCompressFile(ByVal InFile As String, ByVal OutFile As String)
        Dim offset As Integer = 0
        Using outstream As New FileStream(OutFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096)
            Using instream As New FileStream(InFile, FileMode.Open)
                instream.Position = 0
                Dim zipStream As New Compression.GZipStream(instream, Compression.CompressionMode.Decompress)
                While True
                    Dim buffer(4095) As Byte
                    Dim bytesRead As Integer = zipStream.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then
                        Exit While
                    End If
                    outstream.Seek(offset, SeekOrigin.Begin) '初始化写的地方
                    outstream.Write(buffer, 0, bytesRead)
                    offset += bytesRead
                End While
            End Using
        End Using
    End Sub
    '压缩字节
    '压缩
    Public Shared Function CompressByte(ByVal InByte() As Byte) As Byte()
        Using outstream As New IO.MemoryStream()
            Using zipstream As New IO.Compression.GZipStream(outstream, IO.Compression.CompressionMode.Compress)
                zipstream.Write(InByte, 0, InByte.Length)
                zipstream.Flush()
            End Using
            CompressByte = outstream.ToArray
        End Using

    End Function
    '解压缩字节
    Public Shared Function UnCompressByte(ByVal InByte() As Byte) As Byte()

        Dim offset As Integer = 0
        Using outstream As New MemoryStream
            outstream.Position = 0
            Using instream As New MemoryStream(InByte)
                instream.Position = 0
                Dim zipStream As New Compression.GZipStream(instream, Compression.CompressionMode.Decompress)
                While True
                    Dim buffer(4095) As Byte
                    Dim bytesRead As Integer = zipStream.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then
                        Exit While
                    End If
                    outstream.Seek(offset, SeekOrigin.Begin) '初始化写的地方
                    outstream.Write(buffer, 0, bytesRead)
                    offset += bytesRead
                End While
            End Using
            Return outstream.ToArray
        End Using
    End Function
    '序列化到文件
    Public Shared Sub SerializetoFile(Of t)(ByVal FilePath As String, ByVal obj As t)
        Using fs As New FileStream(FilePath, FileMode.OpenOrCreate)
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext(Runtime.Serialization.StreamingContextStates.File))
            bf.Serialize(fs, obj)
        End Using
    End Sub
    '返序列化到从文件
    Public Shared Function DeSerializeFromFile(Of T)(ByVal FilePath As String) As T
        Using fs As New FileStream(FilePath, FileMode.Open)
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext(Runtime.Serialization.StreamingContextStates.File))
            Return DirectCast(bf.Deserialize(fs), T)
        End Using
    End Function
End Class
