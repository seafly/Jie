Public Class DeepDoStr
    '�ַ���������
    '���һ���ַ�������һ���ַ������г��ּ��εĺ���
    Public Shared Function GF_CheckTheChar(ByVal TheChar As String, ByVal TheString As String) As Integer
        'TheChar="Ҫ�����ַ���"
        'TheString="�������ַ���"
        If InStr(TheString, TheChar) Then
            For n As Integer = 1 To Len(TheString)
                If Mid(TheString, n, Len(TheChar)) = TheChar Then
                    GF_CheckTheChar = GF_CheckTheChar + 1
                End If
            Next
        Else
            Return 0
        End If
    End Function

    '�õ��ַ�����1���ַ���������ȥ���ַ������Ķ��ſ�����
    Public Shared Function GF_removedh(ByVal str As String) As String
        If str = "" Then
            Return str
        End If
        Return Microsoft.VisualBasic.Left(str, Len(str) - 1)
    End Function
    'ǰ��Ӷ�����Ϊ��ʹInStr�����ж�׼ȷ
    Public Shared Function GF_qhjdh(ByVal str As String) As String
        Return "," & str & ","
    End Function
    '����ַ������IN��ѯ�ַ���
    Public Shared Function GF_zhzfccx(ByVal str As String) As String
        str = Replace(str, ",", "','")
        Return "'" & str & "'"
    End Function
    '��ֵ������str1�ַ�����str2�����٣�str3��ʲô�����ַ���
    '��PF_bzhs("8",5,"0")="00008"
    Public Shared Function GF_PF_bzhs(ByVal TheChar As String, ByVal HowMany As Integer, ByVal TheString As String) As String
        GF_PF_bzhs = TheChar
        Dim cd As Integer = Len(TheChar)
        If cd >= HowMany Then
            GF_PF_bzhs = Microsoft.VisualBasic.Left(TheChar, HowMany) : Exit Function
        End If
        Dim ybzfc As String = ""
        For i As Integer = 1 To HowMany - cd
            ybzfc = ybzfc.ToString & TheString.ToString
        Next
        GF_PF_bzhs = ybzfc.ToString & TheChar
    End Function

    '��DBNullֵת��Ϊ""
    Public Shared Function Null2String(ByVal str) As String
        If str Is DBNull.Value Then
            Return ""
        Else
            Return str
        End If
    End Function
    '��DBNullֵת��Ϊ0
    Public Shared Function Null2zero(ByVal str) As Double
        If str Is DBNull.Value Then
            Return 0
        Else
            Return str
        End If
    End Function
    '��ǰĳ���ָ���ָ���ַ�������
    Public Shared Function GF_searchchar(ByVal str1 As String, ByVal str2 As String, ByVal direction As String) As String
        GF_searchchar = ""
        Dim cc, cc2 As Integer
        cc = InStr(str1, str2)
        If cc = 0 Then
            Return "notexsit"
        End If
        cc2 = Len(str1)
        If direction = "left" Then
            cc2 = cc - 1
            Return Microsoft.VisualBasic.Left(str1, cc2)
        ElseIf direction = "right" Then
            cc2 = cc2 - InStrRev(str1, str2)
            Return Microsoft.VisualBasic.Right(str1, cc2)
        End If
    End Function
    '��ǰĳ���ָ��DiviString�ָ���ַ���������
    Public Shared Sub GF_searchchar(ByVal InString As String, ByVal DiviString As String, ByRef OutLeft As String, ByRef OutRight As String)
        Dim cc() As String = InString.Split(DiviString)
        OutLeft = cc(0) : OutRight = cc(1)
    End Sub
    '�õ�ĳ�����ַ���֮����ַ���,ע������ȥ���ո�Ľ��
    'strhead��ͷ�ַ�����strend��β�ַ���
    Public Shared Function GF_tczfc(ByVal strhead As String, ByVal str As String, ByVal strend As String)
        Dim kk, kk2 As Integer, strtemp As String
        kk = InStr(str, strhead) '�õ���ͷ��һ�γ��ֵ�λ��
        kk2 = Len(strhead) '�õ���ͷ�ַ�������
        strtemp = Mid(str, kk + kk2) '�������ͷ�ַ����Ժ���ַ���
        kk = InStr(strtemp, strend) '�õ���β�ַ�����һ�γ��ֵ�λ��
        GF_tczfc = Microsoft.VisualBasic.Left(strtemp, kk - 1) '�õ�Ŀ���ַ���
        GF_tczfc = Trim(GF_tczfc)
    End Function
    ' ��ʾ�ļ���С
    Public Shared Function GF_netfilesize(ByVal str As Integer) As String
        GF_netfilesize = ""
        If str < 1024 Then
            Return str & "�ֽ�"
        ElseIf str >= 1024 And str < 1048576 Then
            Return FormatNumber(str / 1024, 2) & "K"
        ElseIf str >= 1048576 Then
            Return FormatNumber(str / 1048576, 2) & "M"
        End If
    End Function
    'ת���
    Public Shared Function GF_ToDBC(ByVal input As String) As String 'ת���
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
    'MD5 ���ܺ���
    Public Shared Function GF_MD5(ByVal strSource As String, ByVal Code As Int16) As String
        GF_MD5 = ""
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
        Dim i As Integer
        Select Case Code
            Case 16  'ѡ��16λ�ַ��ļ��ܽ��
                For i = 4 To 11
                    GF_MD5 += Hex(hashvalue(i)).ToLower
                Next
            Case 32  'ѡ��32λ�ַ��ļ��ܽ��
                For i = 0 To 15
                    GF_MD5 += Hex(hashvalue(i)).ToLower
                Next
            Case Else   'Code����ʱ������ȫ���ַ�������32λ�ַ�
                For i = 0 To hashvalue.Length - 1
                    GF_MD5 += Hex(hashvalue(i)).ToLower
                Next
        End Select
    End Function
    '�õ���������������,16���ַ�
    Public Shared Function GF_getnewpath() As String
        Dim sj As Date = Date.Now
        Dim t1 As String = Microsoft.VisualBasic.Right(sj.Year, 2)
        t1 &= GF_PF_bzhs(sj.Month, 2, "0")
        t1 &= GF_PF_bzhs(sj.Day, 2, "0")
        t1 &= GF_PF_bzhs(sj.Hour, 2, "0")
        t1 &= GF_PF_bzhs(sj.Minute, 2, "0")
        t1 &= GF_PF_bzhs(sj.Second, 2, "0")
        Randomize()
        Dim ranNum As Integer = Int(9000 * Rnd()) + 999
        t1 &= GF_PF_bzhs(ranNum, 4, "0")
        Return t1
    End Function
    '�ϲ�2���ֽ�����,�ϲ����һ����ǰ
    Public Shared Function HBBYTES(ByVal BYTE1() As Byte, ByVal BYTE2() As Byte) As Byte()
        Dim cd As Integer = BYTE1.Length + BYTE2.Length - 1
        Dim newbyte(cd) As Byte
        Array.Copy(BYTE1, 0, newbyte, 0, BYTE1.Length)
        Array.Copy(BYTE2, 0, newbyte, BYTE1.Length, BYTE2.Length)
        Return newbyte
    End Function
    '�ϲ�2���ֽ�����,�ϲ����һ����ǰ
    Public Shared Sub UnionBYTES(ByRef BYTE1() As Byte, ByVal BYTE2() As Byte)
        Dim oldcd As Integer = BYTE1.Length
        Dim cd As Integer = oldcd + BYTE2.Length - 1
        ReDim Preserve BYTE1(cd)
        Array.Copy(BYTE2, 0, BYTE1, oldcd, BYTE2.Length)
    End Sub
#Region "�򵥼��ܽ��ܺ���"
    '
    Public Shared Function SimpleEncode(ByVal str As String) As String
        Dim i As Integer
        Dim lsstr As String, strlen As Integer
        strlen = Len(str)
        lsstr = ""
        For i = 1 To Len(str)
            lsstr = lsstr & Chr(Asc(Mid(str, i, 1)) - strlen)
        Next
        SimpleEncode = lsstr
    End Function
    '����
    Public Shared Function SimpleDecode(ByVal str As String) As String
        SimpleDecode = ""
        Dim i As Integer
        Dim strlen As Integer
        strlen = Len(str)
        For i = 1 To Len(str)
            SimpleDecode = SimpleDecode & Chr(Asc(Mid(str, i, 1)) + strlen)
        Next
    End Function
#End Region

End Class
