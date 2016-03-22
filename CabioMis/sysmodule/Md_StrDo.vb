Module Md_StrDo
    '字符串处理模块
    '检测一个字符串在另一个字符串当中出现几次的函数
    Public Function GF_CheckTheChar(ByVal TheChar As String, ByVal TheString As String) As Integer
        'TheChar="要检测的字符串"
        'TheString="待检测的字符串"
        Dim n As Integer
        If InStr(TheString, TheChar) Then
            For n = 1 To Len(TheString)
                If Mid(TheString, n, Len(TheChar)) = TheChar Then
                    GF_CheckTheChar = GF_CheckTheChar + 1
                End If
            Next
        Else
            GF_CheckTheChar = 0
        End If
    End Function
   

    '得到字符串减1的字符串，比如去掉字符串最后的逗号可以用
    Public Function GF_removedh(ByVal str As String) As String
        If str = "" Then
            GF_removedh = str
            Exit Function
        End If
        GF_removedh = Microsoft.VisualBasic.Left(str, Len(str) - 1)
    End Function
    Function GF_qhjdh(ByVal str As String) As String '前后加逗号是为了使InStr函数判断准确
        GF_qhjdh = "," & str & ","
    End Function
    '组合字符串组合IN查询字符串
    Function GF_zhzfccx(ByVal str As String) As String
        str = Replace(str, ",", "','")
        GF_zhzfccx = "'" & str & "'"
    End Function
    '得到不重名的新名称
    Function GF_getnewpath() As String
        Randomize()
        Dim ranNum As Integer = Int(9000 * Rnd()) + 999
        GF_getnewpath = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & ranNum
    End Function
    Public Function GF_gettrqsj(ByVal k1 As String) As String
        k1 = Replace(k1, "年", "-") : k1 = Replace(k1, "月", "-") : k1 = Replace(k1, "日", "") : GF_gettrqsj = k1
    End Function
    Public Function GF_gettrqsj2(ByVal k1 As DateTime) As DateTime
        GF_gettrqsj2 = DatePart(DateInterval.Year, k1) & "-" & DatePart(DateInterval.Month, k1) & "-" & DatePart(DateInterval.Day, k1)
    End Function
    '补值函数，str1字符串，str2补多少，str3补什么样的字符串
    '如PF_bzhs("8",5,"0")="00008"
    Public Function GF_PF_bzhs(ByVal str1 As String, ByVal str2 As Integer, ByVal str3 As String) As String
        GF_PF_bzhs = str1
        Dim cd As Integer = Len(str1)
        If cd >= str2 Then
            GF_PF_bzhs = Microsoft.VisualBasic.Left(str1, str2) : Exit Function
        End If
        Dim ybzfc As String = ""
        For i As Integer = 1 To str2 - cd
            ybzfc = ybzfc.ToString & str3.ToString
        Next
        GF_PF_bzhs = ybzfc.ToString & str1
    End Function
    'MD5 加密函数
    Public Function GF_MD5(ByVal strSource As String, ByVal Code As Int16) As String
        GF_MD5 = ""
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
        Dim i As Integer
        Select Case Code
            Case 16  '选择16位字符的加密结果
                For i = 4 To 11
                    GF_MD5 += Hex(hashvalue(i)).ToLower
                Next
            Case 32  '选择32位字符的加密结果
                For i = 0 To 15
                    GF_MD5 += Hex(hashvalue(i)).ToLower
                Next
            Case Else   'Code错误时，返回全部字符串，即32位字符
                For i = 0 To hashvalue.Length - 1
                    GF_MD5 += Hex(hashvalue(i)).ToLower
                Next
        End Select
    End Function
    '把DBNull值转换为""
    Public Function Null2String(ByVal str) As String
        If str Is DBNull.Value Then
            Return ""
        Else
            Return str
        End If
    End Function
    '把DBNull值转换为0
    Public Function Null2zero(ByVal str) As Double
        If str Is DBNull.Value Then
            Return 0
        Else
            Return str
        End If
    End Function

    '把DBNull值转换为0
    Public Function Null2zero2(ByVal str) As Double
        If str Is DBNull.Value Then
            Return 0
        ElseIf IsNumeric(str) = False Then
            Return 0
        End If
        Return str
    End Function
    '提前某个分割符分割的字符串函数
    Function GF_searchchar(ByVal str1 As String, ByVal str2 As String, ByVal direction As String) As String
        GF_searchchar = ""
        Dim cc, cc2 As Integer
        cc = InStr(str1, str2)
        If cc = 0 Then
            GF_searchchar = "notexsit"
            Exit Function
        End If
        cc2 = Len(str1)
        If direction = "left" Then
            cc2 = cc - 1
            GF_searchchar = Microsoft.VisualBasic.Left(str1, cc2)
        ElseIf direction = "right" Then
            cc2 = cc2 - InStrRev(str1, str2)
            GF_searchchar = Microsoft.VisualBasic.Right(str1, cc2)
        End If
    End Function
    ' 显示文件大小
    Public Function GF_netfilesize(ByVal str As Integer) As String
        GF_netfilesize = ""
        If str < 1024 Then
            GF_netfilesize = str & "字节"
        ElseIf str >= 1024 And str < 1048576 Then
            GF_netfilesize = FormatNumber(str / 1024, 2) & "K"
        ElseIf str >= 1048576 Then
            GF_netfilesize = FormatNumber(str / 1048576, 2) & "M"
        End If
    End Function
    Public Function GF_getnewpath2() As String
        GF_getnewpath2 = Now.Year & "-" & Now.Month & "-" & Now.Day & "-" & Now.Hour & "-" & Now.Minute & "-" & Now.Second
    End Function
    Public Function GF_getnewpath3() As String
        GF_getnewpath3 = Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString
    End Function

    Public Function GF_getnewpath3(ByVal ph As String) As String
        Dim newph As String
        newph = ph & "."
        GF_getnewpath3 = newph
    End Function
    '转半角
    Public Function GF_ToDBC(ByVal input As String) As String
        GF_ToDBC = ""
        If IsDBNull(input) Then
            Exit Function
        End If
        If input = "" Then
            Exit Function
        End If
        Dim c As Char() = input.ToCharArray
        Dim i As Integer = 0
        While i < c.Length
            If AscW(c(i)) = 12288 Then
                c(i) = ChrW(32)
            ElseIf AscW(c(i)) > 65280 AndAlso AscW(c(i)) < 65375 Then
                c(i) = ChrW(AscW(c(i)) - 65248)
            End If
            System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Return New String(c)
    End Function
    Public Function GF_ShowDriveInfo(ByVal drvpath) As String
        Dim fso, d As Object
        fso = CreateObject("Scripting.FileSystemObject")
        d = fso.GetDrive(fso.GetDriveName(fso.GetAbsolutePathName(drvpath)))
        Dim xlh As String = d.SerialNumber
        d = Nothing : fso = Nothing
        Return xlh
    End Function

End Module
