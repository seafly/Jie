Public Class Frhzcp2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '添加数据
        If GF_YZSJ(Me, "tb_cpdmhz_cpdm,tb_cpdmhz_cplx,tb_cpdmhz_jgdm,tb_cpdmhz_yxx,tb_cpdmhz_cpxz") = False Then '验证控件
            Exit Sub
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_cpdm ='" & tb_cpdmhz_cpdm.Text & "'and tb_cpdmhz_jgdm ='" & tb_cpdmhz_jgdm.Text & "'and tb_cpdmhz_jgdm<>'无'")
        If dt.Rows.Count > 0 Then
            MsgBox("产品类型 ，产品代码 ，加工代码 有重复") : Return
        End If
        Dim jj As String = GF_addsj("tb_cpdmhz", Me, G_cnnstrWH)
        jj = GF_addsj("tb_cpdmhz", Me, G_cnnstr)
        If jj = "" Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        MsgBox("添加成功！")
        GS_storelog3("产品代码：" & tb_cpdmhz_cpdm.Text.Trim & "产品类型：" & tb_cpdmhz_cplx.Text & "加工代码：" & tb_cpdmhz_jgdm.Text, "产品加工") '储存到日志

        '如果产品类别没有，那么添加
        If _D.isRowNull("tb_cplb", "tb_cplb_p512h='" & tb_cpdmhz_cplb.Text.Trim & "'")=False Then
            Dim tCocc As New Dictionary(Of String, String)
            tCocc("tb_cplb_p512h") = tb_cpdmhz_cplb.Text.Trim
            _D.insertData("tb_cplb", tCocc)
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Frhzcp2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        tb_cpdmhz_yxx.Text = tb_cpdmhz_yxx.Items(0)
        tb_cpdmhz_cpxz.Text = tb_cpdmhz_cpxz.Items(0)
        Dim sj As String = GF_getstringsql(G_cnnstr, "select  DATEPART(year, GETDATE()) , DATEPART(month, GETDATE()) , DATEPART(day, GETDATE()) ", "-")
        sj = GF_gettrqsj(sj) '得到操作时间
        tb_cpdmhz_cpdmrq.Text = sj
        tb_cpdmhz_cpdmczr.Text = G_dlr & "|" & G_dlrgh

        Dim sql As String = "select tb_cplb_p512h from tb_cplb where (tb_cplb_isShow is null or tb_cplb_isShow=0)"
        Dim dt As DataTable = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_cpdmhz_cplb.Items.Add(dt.YanDtValue2("tb_cplb_p512h", i))
        Next
    End Sub

 
End Class