Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Public Class CDESCryp
    Private EncryptKey As DESCryptoServiceProvider = Nothing
    Private defaultKey As Byte() = New Byte() {101, 102, 103, 104, 105, 106, 107, 108}
    Private defaultIV As Byte() = New Byte() {201, 202, 203, 204, 205, 206, _
    207, 208}

    Public Sub New()
        EncryptKey = New DESCryptoServiceProvider()
        EncryptKey.BlockSize = 64
        EncryptKey.Key = defaultKey
        '密钥长度必须等于 BlockSizeValue。 
        '此算法支持长度为 64 位的密钥。 
        'IV 属性的大小必须与 BlockSize 属性的大小相同 
        EncryptKey.IV = defaultIV
    End Sub
    ''' <summary> 
    ''' CDESCryp构造函数 
    ''' </summary> 
    ''' <param name="key"></param> 
    ''' <param name="iv"></param> 
    Public Sub New(ByVal key As Byte(), ByVal iv As Byte())
        EncryptKey = New DESCryptoServiceProvider()
        EncryptKey.BlockSize = iv.Length * 8
        EncryptKey.Key = key
        EncryptKey.IV = iv
    End Sub
    Public Sub New(ByVal key As Byte())
        EncryptKey = New DESCryptoServiceProvider()
        EncryptKey.BlockSize = defaultIV.Length * 8
        EncryptKey.Key = key
        EncryptKey.IV = defaultIV
    End Sub
#Region "ICustomCryptography 成员"

    Public Function Encrypt(ByVal PlainText As String) As String
        EncryptKey.BlockSize = 64
        EncryptKey.Key = defaultKey
        '密钥长度必须等于 BlockSizeValue。 
        '此算法支持长度为 64 位的密钥。 
        EncryptKey.IV = defaultIV
        Dim ms As New MemoryStream()
        Dim encStream As New CryptoStream(ms, EncryptKey.CreateEncryptor(), CryptoStreamMode.Write)
        Dim sw As New StreamWriter(encStream)
        sw.WriteLine(PlainText)
        sw.Close()
        encStream.Close()
        Dim buffer As Byte() = ms.ToArray()
        ms.Close()
        'ASCIIEncoding encoding = new ASCIIEncoding(); 

        'For i As Integer = 0 To buffer.Length - 1
        '    System.Diagnostics.Debug.WriteLine(buffer(i))
        'Next
        Dim ret As New StringBuilder()
        For Each b As Byte In ms.ToArray()
            ret.AppendFormat("{0:X2}", b)
            'System.Diagnostics.Debug.WriteLine(ret.ToString())
        Next

        Return ret.ToString()
    End Function




    Public Function Decrypt(ByVal CypherText As String) As String

        Dim len As Integer
        len = CypherText.Length / 2
        Dim buffer As Byte() = New Byte(len - 1) {}
        Dim x As Integer, j As Integer
        For x = 0 To len - 1
            j = Convert.ToInt32(CypherText.Substring(x * 2, 2), 16)
            buffer(x) = CByte(j)
        Next

        'For i As Integer = 0 To buffer.Length - 1
        '    System.Diagnostics.Debug.WriteLine(buffer(i))
        'Next


        Dim ms As New MemoryStream(buffer)
        Dim encStream As New CryptoStream(ms, EncryptKey.CreateDecryptor(), CryptoStreamMode.Read)
        Dim sr As New StreamReader(encStream)
        Dim val As String = sr.ReadLine()
        sr.Close()
        encStream.Close()
        ms.Close()


        Return val
    End Function

#End Region

End Class
