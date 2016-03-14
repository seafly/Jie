Public Class FrRightNowMX
    Public sql As String = ""
    Private Sub FrRightNowMX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        With dt
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i)("到货差异时间") = DateAndTime.DateDiff(DateInterval.Day, .Rows(i)("tb_dhgz_yjdhrq"), .Rows(i)("tb_dhgz_dhrq"))

                If .Rows(i)("到货差异时间") >= 3 Then
                    .Rows(i)("是否即时到货") = "否"
                Else
                    .Rows(i)("是否即时到货") = "是"
                End If

            Next

        End With
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub
End Class