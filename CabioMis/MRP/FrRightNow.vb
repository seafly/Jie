''' <summary>
''' 到货即时率
''' </summary>
Public Class FrRightNow

    Dim strStarDate As String
    Dim strEndDate As String
    Private Sub FrRightNow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_niansl(ComboBox1)
        GS_monthsl(ComboBox2)
        GS_monthsl(ComboBox3)

    End Sub

    Private Sub FrRightNow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - GroupBox1.Top - 50
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt0 As DataTable = New DataTable

        With dt0
            dt0.Columns.Add("供应商", GetType(String))
            dt0.Columns.Add("合计到货次数", GetType(Double))
            dt0.Columns.Add("即时到货次数", GetType(Double))
            dt0.Columns.Add("月到货即时率", GetType(String))
            dt0.Columns.Add("订购总量", GetType(Double))
            dt0.Columns.Add("到货总量", GetType(Double))
        End With

        '*************************多重统计时间判断***************
        Select Case CInt(ComboBox1.Text)
            Case Is < 2013
                strStarDate = IIf(ComboBox2.Text = 1, ComboBox1.Text - 1, ComboBox1.Text) & _
                    "-" & IIf(ComboBox2.Text = 1, 12, ComboBox2.Text - 1) & "-26 00:00:00"
                strEndDate = ComboBox1.Text & "-" & ComboBox3.Text & "-25 23:59:59"
            Case Is = 2013
                Select Case CInt(ComboBox2.Text)
                    Case Is <= 6
                        strStarDate = IIf(ComboBox2.Text = 1, ComboBox1.Text - 1, ComboBox1.Text) & _
                            "-" & IIf(ComboBox2.Text = 1, 12, ComboBox2.Text - 1) & "-26 00:00:00"
                    Case Is > 6
                        strStarDate = ComboBox1.Text & "-" & ComboBox2.Text & "-1 00:00:00"
                End Select
                Select Case CInt(ComboBox3.Text)
                    Case Is < 6
                        strEndDate = ComboBox1.Text & "-" & ComboBox3.Text & "-25 23:59:59"
                    Case Is >= 6
                        strEndDate = DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Month, 1, CType(ComboBox1.Text & "-" & ComboBox3.Text & "-1 00:00:00", DateTime)))
                End Select
            Case Is > 2013
                strStarDate = ComboBox1.Text & "-" & ComboBox2.Text & "-1 00:00:00"
                strEndDate = DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Month, 1, CType(ComboBox1.Text & "-" & ComboBox3.Text & "-1 00:00:00", DateTime)))
        End Select

        '*************************end***************
        If DateDiff(DateInterval.Day, CType(strStarDate, DateTime), CType(strEndDate, DateTime)) < 0 Then
            MsgBox("结束时间不能大于开始时间！")
            Return
        End If

        Dim Hj As String = "select count(*),tb_dhgz_gysmc,sum(tb_dhgz_dhsl)  as '到货总量' from  tb_dhgz "
        Hj &= " where tb_dhgz_dhrq between  '" & strStarDate & "'  and '" & strEndDate & "'"
        Hj &= " group by tb_dhgz_gysmc "
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, Hj)


        Dim sql As String
        Dim dt As DataTable

        With dt1
            If .Rows.Count > 0 Then
                Dim dgzl As Double = 0 '订购总量
                For i As Integer = 0 To .Rows.Count - 1
                    Dim StrGys As String = Null2String(.Rows(i)("tb_dhgz_gysmc"))
                    ''''''''''''''''得到即时统计
                    If StrGys <> "" Then
                        Dim CountJs As Double = 0
                        sql = " select tb_dhgz_dhrq, tb_dhgz_yjdhrq ,tb_dhgz_dgzl from tb_dhgz where  tb_dhgz_gysmc = '" & StrGys & "' "
                        sql &= " and tb_dhgz_dhrq between  '" & strStarDate & "'  and '" & strEndDate & "'"
                        dt = GF_CreateDataSource(G_cnnstr, sql)
                        If dt.Rows.Count > 0 Then
                            For ii As Integer = 0 To dt.Rows.Count - 1
                                dgzl += Null2zero(dt.Rows(ii)("tb_dhgz_dgzl")) '订购总量
                                If DateAndTime.DateDiff(DateInterval.Day, dt.Rows(ii)("tb_dhgz_yjdhrq"), dt.Rows(ii)("tb_dhgz_dhrq")) <= 3 Then
                                    CountJs += 1
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''

                        Dim CountHj As Double = Null2zero(.Rows(i)(0)) '合计到货次数
                        Dim Immediate As String = FormatNumber(CountJs / CountHj, 2) * 100 & "%" '月到货即时率

                        Dim mm As DataRow = dt0.NewRow
                        mm(0) = StrGys : mm(1) = CountHj : mm(2) = CountJs : mm(3) = Immediate
                        mm("到货总量") = .Rows(i)("到货总量") '到货总量
                        mm("订购总量") = dgzl
                        dgzl = 0
                        dt0.Rows.Add(mm)
                    End If

                Next
            End If
        End With
        GroupBox1.Text = "有" & dt0.Rows.Count & "条数据"
        GS_DataGridViewbyDb(show1, dt0, True, True)

    End Sub
    '即时到货明细
    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        Dim aa As New FrRightNowMX

        aa.sql = "select tb_dhgz_gysmc,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_yjdhrq,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_dgzl,tb_dhgz_qgbz,null as 到货差异时间,cast( null as varchar ) as 是否即时到货 from tb_dhgz"
        aa.sql &= " where tb_dhgz_dhrq between  '" & strStarDate & "'  and '" & strEndDate & "'"
        aa.sql &= " and  tb_dhgz_gysmc='" & show1.SelectedRows(0).Cells(0).Value & "'  "

        aa.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub
End Class