Public Class Frddjfyb2
    Dim qx As String = qxpd()
    Dim showDataTable As DataTable = Nothing

    Private Sub Frddjfyb2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql As String = GF_getstringsql(G_cnnstr, "select top 1 year(tb_dd_ddgsyf) from tb_dd  where tb_dd_ddgsyf is not null group by tb_dd_ddgsyf order by tb_dd_ddgsyf desc ", "")
        For i As Integer = 2011 To CInt(sql) '填充年
            ComboBox1.Items.Add(i)
            ComboBox3.Items.Add(i)
        Next
        For j As Integer = 1 To 12 '月
            ComboBox2.Items.Add(j)
            ComboBox4.Items.Add(j)
        Next
        ComboBox1.Text = Now.Year
        ComboBox3.Text = Now.Year '年默认为今年
    End Sub
    Private Sub wz()
        GroupBox1.Width = Me.Width - 10
        GroupBox1.Height = Me.Height - Button3.Top - Button3.Height - 40
    End Sub

    Private Sub Frddjfyb2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(show1, "订单交付月报", Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            showsj()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub showsj()
        ''''***********************'构建列
        Dim tt1 As Date = ComboBox1.Text & "-" & CInt(ComboBox2.Text) & "-1"
        Dim tt2 As Date = ComboBox3.Text & "-" & CInt(ComboBox4.Text) & "-1"
        Dim dt As DataTable
        Dim sql As String = "select  tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_kh from tb_dd"
        sql &= " where tb_dd_ddgsyf between '" & tt1 & "' and '" & tt2 & "'" & qx & " group by tb_dd_kh,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm"
        dt = GF_CreateDataSource(G_cnnstr, sql)
        Dim gsyue As Integer = CInt(ComboBox2.Text) '始月
        Dim j As Integer = DateDiff(DateInterval.Month, tt1, tt2)  'j代表止月到始月的间隔数

        For i As Integer = 0 To j  'j代表止月到始月的间隔数
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "订单量")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "实发量")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "未发量")
            dt.Columns.Add((gsyue + i).ToString & "月" & vbCrLf & "退换货数量")
        Next
        '************************************
        ''''''填充行数据
        For k As Integer = 0 To dt.Rows.Count - 1
            Dim sqlsj As String = ""
            Dim dt1 As DataTable = Nothing
            For ii As Integer = 0 To j 'j代表止月到始月的间隔数

                '''''''''''''''''''''''''''''''上个月25号到这个月26号为一个时间段
                Dim NowRq As String = DateAndTime.DateAdd(DateInterval.Month, ii, tt1).ToString("yyyy-MM-dd")
                Dim BeforeRq As String = DateAndTime.DateAdd(DateInterval.Month, -1, CType(NowRq, Date)).ToString("yyyy-MM-dd")
                Dim INTNowRq As Integer = Microsoft.VisualBasic.InStrRev(NowRq, "-")
                Dim INTBeforeRq As Integer = Microsoft.VisualBasic.InStrRev(BeforeRq, "-")
                BeforeRq = BeforeRq.Substring(0, INTBeforeRq) & "25"
                NowRq = NowRq.Substring(0, INTNowRq) & "26"
                ''''''''''''''''''''''''''''''''''''''''''''''''''

                '@a4 订单输入流程中的信息 ‘
                ' @a5 为 发货计划流程中计划量合计（按不同订单号合计联合查询是为了得到不同代码的订单号 然后再到一级信息中根据订单号统计订单量）

                sqlsj = "declare @a1 as money,@a2 as money,@a3 as money,@a4 as money,@a5 as money" & vbCrLf
                sqlsj &= "select @a1 = sum(tb_dd_ddl) from tb_dd " & vbCrLf
                sqlsj &= "where  tb_dd_kh='" & dt.Rows(k)("tb_dd_kh") & "' and  tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & DateAdd(DateInterval.Month, ii, tt1) & "'  and tb_dd_fhtjdh is null " & vbCrLf
                sqlsj &= "select @a2 = sum(tb_dd_yfh) from tb_dd " & vbCrLf
                sqlsj &= "where  tb_dd_kh='" & dt.Rows(k)("tb_dd_kh") & "' and  tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & DateAdd(DateInterval.Month, ii, tt1) & "' and tb_dd_fhtjdh is null " & vbCrLf
                sqlsj &= "select @a3 = sum(tb_dd_jhfhzl) from tb_dd " & vbCrLf
                sqlsj &= "where  tb_dd_kh='" & dt.Rows(k)("tb_dd_kh") & "' and   tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "' and  tb_dd_ddgsyf = '" & DateAdd(DateInterval.Month, ii, tt1) & "'  and tb_dd_bz1='2'  and  tb_dd_bz2 is not null and tb_dd_bz3 is null and tb_dd_fhtjdh is not null" & vbCrLf
                sqlsj &= "select @a4 = sum(tb_dd_returnsl) from tb_dd " & vbCrLf
                sqlsj &= "where  tb_dd_kh='" & dt.Rows(k)("tb_dd_kh") & "' and   tb_dd_cplx='" & dt.Rows(k)("tb_dd_cplx") & "' and  tb_dd_cpdm ='" & dt.Rows(k)("tb_dd_cpdm") & "' and tb_dd_jgdm='" & dt.Rows(k)("tb_dd_jgdm") & "'  and  tb_dd_returnrq  between'" & CType(BeforeRq, Date) & "' and '" & CType(NowRq, Date) & "' "
                sqlsj &= "select @a1,@a2,@a3,@a4 "
                dt1 = GF_CreateDataSource(G_cnnstr, sqlsj)
                dt.Rows(k)(ii * 4 + 4) = Null2zero2(dt1.Rows(0)(0))
                dt.Rows(k)(ii * 4 + 5) = Null2zero2(dt1.Rows(0)(1))
                dt.Rows(k)(ii * 4 + 6) = Null2zero2(dt1.Rows(0)(0)) - Null2zero2(dt1.Rows(0)(1))
                dt.Rows(k)(ii * 4 + 7) = Null2zero2(dt1.Rows(0)(3))

            Next
        Next
        showDataTable = dt
        dt.DefaultView.Sort = "tb_dd_cpdm,tb_dd_jgdm,tb_dd_kh"
        GS_DataGridViewbyDb(show1, dt, 0, True, True)
        GroupBox1.Text = "显示" & show1.RowCount & "条记录"
    End Sub
    Private Function qxpd() As String
        Dim sql As String = "select tb_khyqqkyrb_khmc from tb_khyqqkyrb where tb_khyqqkyrb_ddgh='" & G_dlr & "|" & G_dlrgh & "'  group by tb_khyqqkyrb_khmc"
        sql = GF_getstringsql(G_cnnstr, sql, ",")
        If sql = "" Then
            Return ""
        Else
            sql = "'" & Replace(sql, ",", "','") & "'"
            Return " and  tb_dd_kh in (" & sql & ")"
        End If
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim nfrom As New Fryxkc
            nfrom.ToolStripLabel1.Text = ""
            Me.AddOwnedForm(nfrom)
            nfrom.Show()

        Catch
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim bds As String = "1=1"
        Select Case ComboBox5.Text
            Case "产品代码"
                bds &= " and tb_dd_cpdm  like '%" & TextBox1.Text.Trim & "%'"
            Case "加工代码"
                bds &= " and  tb_dd_jgdm like '%" & TextBox1.Text.Trim & "%'"
            Case "客户"
                bds &= " and  tb_dd_kh  like '%" & TextBox1.Text.Trim & "%'"
        End Select
     
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(showDataTable, bds) '查询并得到结果DB
        GS_DataGridViewbyDb(show1, dt2, 0, True, True)
        GroupBox1.Text = "显示" & show1.RowCount & "条记录"
    End Sub

   
End Class