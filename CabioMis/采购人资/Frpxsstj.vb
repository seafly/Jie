Public Class Frpxsstj

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        '''''''''''''''
        Dim dt0 As New DataTable
        With dt0
            .Columns.Add("部门", GetType(String)) : .Columns.Add("工段", GetType(String))
            .Columns.Add("SOP培训时数（H）", GetType(Double)) : .Columns.Add("SOP培训人数", GetType(Integer))
            .Columns.Add("FS培训时数（H）", GetType(Double)) : .Columns.Add("FS培训人数", GetType(Integer))
            .Columns.Add("EHS培训时数（H）", GetType(Double)) : .Columns.Add("EHS培训人数", GetType(Integer))
            .Columns.Add("其它培训时数（H）", GetType(Double)) : .Columns.Add("其它培训人数", GetType(Integer))
            .Columns.Add("外训时数（H）", GetType(Double)) : .Columns.Add("外训人数", GetType(Integer))
            .Columns.Add("时数合计（H）", GetType(Double)) : .Columns.Add("人数合计", GetType(Integer))
        End With
        '''''''''''''''''''

        ''''''''''''''''''''''''''''''''
        Try
            Dim sql As String = "select tb_ygpxda_bumen,tb_ygpxda_gd,sum(tb_ygpxda_kd) as 课时,count(*) as 人次 from tb_ygpxda where tb_ygpxda_rq between '" & tt1 & "' and '" & tt2 & "' group by tb_ygpxda_bumen,tb_ygpxda_gd order by tb_ygpxda_bumen"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            With dt
                For i As Integer = 0 To .Rows.Count - 1
                    Dim bm As String = .Rows(i)(0) : Dim gd As String = DeepCode.DeepDoStr.Null2String(.Rows(i)(1))
                    Dim hj1 As Double = DeepCode.DeepDoStr.Null2zero(.Rows(i)(2)) : Dim hj2 As String = .Rows(i)(3)
                    Dim kk As DataRow = dt0.NewRow
                    kk(0) = bm : kk(1) = gd
                    kk(12) = hj1 : kk(13) = hj2
                    '''''''''''''''''''''
                    For j As Integer = 0 To UBound(G_PXLB)
                        Dim sqll As String = "select sum(tb_ygpxda_kd),count(*) from tb_ygpxda where tb_ygpxda_rq between '" & tt1 & "' and '" & tt2 & "' and tb_ygpxda_bumen='" & bm & "' and tb_ygpxda_gd='" & gd & "' and tb_ygpxda_pxlb='" & G_PXLB(j) & "'"
                        Dim dttemp As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqll)
                        Dim n1 As Double = 0 : Dim n2 As Integer = 0
                        If dttemp.Rows.Count > 0 Then
                            Try
                                n1 = DeepCode.DeepDoStr.Null2zero(dttemp.Rows(0)(0))
                                n2 = dttemp.Rows(0)(1)
                            Catch ex As Exception

                            End Try

                        End If

                        Dim sy1 As Integer = 2 * (j + 1) : Dim sy2 As Integer = sy1 + 1
                        kk(sy1) = n1 : kk(sy2) = n2
                    Next

                    ''''''''''''''''
                    dt0.Rows.Add(kk)
                Next
            End With

            Dim kk1 As DataRow = dt0.NewRow
            kk1(0) = "合计" : kk1(1) = ""
            For i As Integer = 2 To dt0.Columns.Count - 1
                Dim b1 As Double = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt0, i, 0, dt0.Rows.Count - 1)
                kk1(i) = b1
            Next
            dt0.Rows.Add(kk1)
            ''''''''''''''''


            showl.DataSource = dt0
            GS_ysgx(showl) '求和最后一行颜色更新
        Catch ex As Exception
            MsgBox("出现错误，可能是2008年分类标志未建立，无法进行汇总统计造成")
        End Try

    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, DateTimePicker1.Text & "至" & DateTimePicker2.Text & Me.Text, Me)
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub
    Private Sub wz()
        With showl
            .Width = Me.Width - .Left - 20
            .Height = Me.Height - .Top - 30
        End With
    End Sub

    Private Sub Frpxsstj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        wz()
    End Sub

    Private Sub Frpxsstj_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
End Class