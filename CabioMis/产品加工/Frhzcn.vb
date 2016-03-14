Public Class Frhzcn

    Public id As Integer = 0
    Private Sub Frcn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        If id <> 0 Then
            Gs_showsj("tb_cpdmhz", Me, id)
        End If
        Dim sql As String = "select tb_cpdmhz_cplx,  tb_cpdmhz_cpxz from tb_cpdmhz where tb_cpdmhz_ID = " & id & " "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows(0)(0) = "DOGK" Then
            tb_cpdmhz_cpzhl.Enabled = False
        End If
        If dt.Rows(0)(1) = "干菌体" Then
            tb_cpdmhz_cpzhl.Text = 0.41
            tb_cpdmhz_cpzhl.Enabled = False
        End If
        Dim sj As String = GF_getstringsql(G_cnnstr, "select  DATEPART(year, GETDATE()) , DATEPART(month, GETDATE()) , DATEPART(day, GETDATE()) ", "-")
        sj = GF_gettrqsj(sj) '得到操作时间
        tb_cpdmhz_cnrq.Text = sj
        tb_cpdmhz_cnczr.Text = G_dlr & "|" & G_dlrgh

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''计算值
      
        Try
            Dim kk As Double = tb_cpdmhz_yzdccps.Text * tb_cpdmhz_cpdpcl.Text '月最大产出量
            kk = FormatNumber(kk, 2)
            tb_cpdmhz_yzdccl.Text = kk

            Dim dd As Double = tb_cpdmhz_cpdpcl.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text)) '产品效率
            dd = FormatNumber(dd, 2)
            tb_cpdmhz_cpxl.Text = dd
        Catch ex As Exception
        End Try
        Try
            Dim kk As Double = Fix(tb_cpdmhz_yzdscsj.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text))) '月最大产出批数 
            tb_cpdmhz_yzdccps.Text = Fix(kk)

            Dim dd As Double = tb_cpdmhz_cpdpcl.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text)) '产品效率
            dd = FormatNumber(dd, 2)
            tb_cpdmhz_cpxl.Text = dd

        Catch ex As Exception
        End Try
        Try
            Dim dd As Double = Null2zero2(tb_cpdmhz_yzdccl.Text) / Null2zero2(tb_cpdmhz_cpzhl.Text)
            tb_cpdmhz_ytrl.Text = Fix(dd)
        Catch ex As Exception

        End Try
        Try
            Dim dd As Double = Null2zero2(tb_cpdmhz_llyscsj.Text) / Null2zero2(tb_cpdmhz_lldpsj.Text)
            tb_cpdmhz_llyccps.Text = Fix(dd)
        Catch ex As Exception

        End Try
        Try
            Dim dd As Double = Null2zero2(tb_cpdmhz_lldpcl.Text) / Null2zero2(tb_cpdmhz_lldpsj.Text)
            tb_cpdmhz_llcpxl.Text = FormatNumber(dd, 2)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If GF_modsj("tb_cpdmhz", Me, id, G_cnnstrWH) = True And GF_modsj("tb_cpdmhz", Me, id, G_cnnstr) = True Then
            MsgBox("产能添加成功！")
            GS_storelog3("产能说明：" & tb_cpdmhz_cnsm.Text.Trim, "产能") '储存到日志
        Else
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        Dim aa As Frcpdmhz = Me.Owner
        aa.showsj("查询产能")

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub tb_cpdmhz_yzdscsj_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_yzdscsj.LostFocus, tb_cpdmhz_llyscsj.LostFocus, tb_cpdmhz_dpbzsj.LostFocus
        Try
            Dim kk As Double = Fix(tb_cpdmhz_yzdscsj.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text))) '月最大产出批数 
            tb_cpdmhz_yzdccps.Text = Fix(kk)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_cpdmhz_cpdpcl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_cpdpcl.LostFocus, tb_cpdmhz_lldpcl.LostFocus, tb_cpdmhz_dpbzsj.LostFocus, tb_cpdmhz_cpdpccsj.LostFocus
        Try
            Dim kk As Double = tb_cpdmhz_yzdccps.Text * tb_cpdmhz_cpdpcl.Text '月最大产出量
            kk = FormatNumber(kk, 2)
            tb_cpdmhz_yzdccl.Text = kk

            Dim dd As Double = tb_cpdmhz_cpdpcl.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text)) '产品效率
            dd = FormatNumber(dd, 2)
            tb_cpdmhz_cpxl.Text = dd
        Catch ex As Exception
        End Try
    End Sub


    Private Sub tb_cpdmhz_cpdpccsj_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_cpdpccsj.LostFocus, tb_cpdmhz_lldpsj.LostFocus, tb_cpdmhz_dpbzsj.LostFocus
        Try
            Dim kk As Double = Fix(tb_cpdmhz_yzdscsj.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text))) '月最大产出批数 
            tb_cpdmhz_yzdccps.Text = Fix(kk)

            Dim dd As Double = tb_cpdmhz_cpdpcl.Text / (tb_cpdmhz_cpdpccsj.Text + Null2zero2(tb_cpdmhz_dpbzsj.Text)) '产品效率
            dd = FormatNumber(dd, 2)
            tb_cpdmhz_cpxl.Text = dd

        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_cpdmhz_cpzhl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_cpzhl.DoubleClick, tb_cpdmhz_llcpzhl.DoubleClick
        Dim aa As New Frcpxlv
        aa.kj = CType(sender, Control).Name
        Me.AddOwnedForm(aa)
        aa.id = id
        aa.ShowDialog()

    End Sub

    Private Sub tb_cpdmhz_yzdccl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_yzdccl.TextChanged, tb_cpdmhz_cpxl.TextChanged, tb_cpdmhz_cpzhl.TextChanged
        Try
            Dim dd As Double = Null2zero2(tb_cpdmhz_yzdccl.Text) / Null2zero2(tb_cpdmhz_cpzhl.Text)
            tb_cpdmhz_ytrl.Text = Fix(dd)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tb_cpdmhz_llyscsj_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_llyscsj.TextChanged, tb_cpdmhz_lldpsj.TextChanged
        Try
            Dim dd As Double = Null2zero2(tb_cpdmhz_llyscsj.Text) / Null2zero2(tb_cpdmhz_lldpsj.Text)
            tb_cpdmhz_llyccps.Text = Fix(dd)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tb_cpdmhz_lldpcl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_lldpcl.TextChanged, tb_cpdmhz_lldpsj.TextChanged
        Try
            Dim dd As Double = Null2zero2(tb_cpdmhz_lldpcl.Text) / Null2zero2(tb_cpdmhz_lldpsj.Text)
            tb_cpdmhz_llcpxl.Text = FormatNumber(dd, 2)
        Catch ex As Exception

        End Try
    End Sub
End Class