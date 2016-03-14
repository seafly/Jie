Public Class ClassPhgn
    '批号规律操作类
    Public Shared Function ClassPhgn_Get(ByVal str1 As String, ByVal str2 As String) As String '得到当前批号+1的批号
        'str1代表批号针对，str2代表分隔符
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d where tb_l358d_zd='" & str1 & "'")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Dim phqz As String = _S.YanNullToEmpty(dt.Rows(0)(2)) '前缀
        Dim dqz As Integer = _S.YanNullToEmpty(dt.Rows(0)(3)) '当前值
        If phqz = "" Then
            Return ""
        End If
        Return phqz & str2 & (dqz + 1)
    End Function
    Public Shared Function ClassPhgn_GetQz(ByVal str1 As String) As String '得到当前批号前缀
        'str1代表批号针对
        ClassPhgn_GetQz = ""
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d where tb_l358d_zd='" & str1 & "'")
        If dt.Rows.Count > 0 Then
            ClassPhgn_GetQz = dt.Rows(0)(2) '前缀
        End If
    End Function
    Public Shared Function ClassPhgn_GetDqz(ByVal str1 As String) As Integer '得到当前批号的当前值
        'str1代表批号针对
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d where tb_l358d_zd='" & str1 & "'")
        If dt.Rows.Count > 0 Then
            ClassPhgn_GetDqz = dt.Rows(0)(3) '当前值
        End If
    End Function
    Public Shared Sub ClassPhgn_SetDqz(ByVal str1 As String, ByVal str2 As Integer)  '设置当前批号的当前值
        'str1代表批号针对,str2代表要设置的值 where tb_l358d_z

        GS_upztxx(G_cnnstr, "update tb_l358d set tb_l358d_dqz=" & str2 & " where tb_l358d_zd='" & str1 & "'") '更新起始值
    End Sub
    Public Shared Sub ClassPhgn_SetDqz2(ByVal str1 As String)  '设置当前批号的当前值+1
        'str1代表批号针对,str2代表要设置的值
        GS_upztxx(G_cnnstr, "update tb_l358d set tb_l358d_dqz=tb_l358d_dqz+1 where tb_l358d_zd='" & str1 & "'") '更新起始值
    End Sub
End Class
