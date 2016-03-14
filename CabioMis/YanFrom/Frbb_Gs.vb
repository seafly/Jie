Imports System.Globalization
Imports _S = CabioMis.Cl_StrMag
Imports _D = CabioMis.Cl_DataMag
Imports _E = CabioMis.EnumDescription

Public Class Frbb_Gs
    Public m_dt As DataTable = Nothing

    Private Sub Frbb_Gs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If m_dt Is Nothing Then
            Return
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strGs As String = TextBox2.Text
        If strGs = "" Then
            Return
        End If
        Try
            Dim strColName As String = IIf(TextBox1.Text = "", "公式列" & m_dt.Columns.Count, TextBox1.Text)
            m_dt.Columns.Add(strColName)
            For Each dr As DataRow In m_dt.Rows
                dr(strColName) = getGsValue(dr)
            Next
            MsgBox("添加完成！")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function getGsValue(pDr As DataRow) As String
        Dim strGs As String = TextBox2.Text

        '替换表达式内的值
        For Each col As DataColumn In m_dt.Columns
            strGs = strGs.Replace(col.ColumnName, pDr(col.ColumnName).ToString)
        Next
        Return _S.Calculate(strGs)
    End Function
End Class