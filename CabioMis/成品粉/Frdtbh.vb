Public Class Frdtbh

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim tt1, tt2 As DateTime
        'tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        'If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
        '    MsgBox("起时间应当小于等于止时间") : Return
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql1 As String = "select tb_bhlb_mc,tb_bhlb_tj from tb_bhlb where tb_bhlb_mc not like '%SY%'" '把试验类当做一种类别
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql1)
        With dt1
            For i As Integer = 0 To .Rows.Count - 1
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lb As String = DeepCode.DeepDoStr.Null2String(.Rows(i)("tb_bhlb_mc")) '得到生产代码名
                'Dim tj As String = DeepCode.DeepDoStr.Null2String(.Rows(i)("tb_bhlb_tj")) '得到生产代码条件
                Dim tj As String = "  and tb_x832p_scdm='" & lb & "' and tb_x832p_sykczl>=20 and tb_x832p_qaspjg<>'报废'" '得到生产代码条件
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''
                Dim sql2 As String = "select tb_x832p_num,tb_x832p_sykczl,tb_x832p_qaspjg,tb_x832p_jgrq,tb_x832p_bzxs,tb_x832p_bfb,tb_x832p_d65v,tb_x832p_a948s from vw_x832p where   1=1 "
                sql2 &= tj
                ''''''''''''''''''''''''''''''''''''
                Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)
                If dt2.Rows.Count > 0 Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim dr As DataRow = dt2.NewRow
                    dr(0) = "合计"
                    dr("tb_x832p_sykczl") = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt2, 1, 0, dt2.Rows.Count - 1)
                    dr("tb_x832p_bfb") = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt2, 5, 0, dt2.Rows.Count - 1)
                    dt2.Rows.Add(dr)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim a As New GroupBox
                    a.Width = 450 : a.Height = 300
                    a.Text = lb & "记录数：" & dt2.Rows.Count - 1
                    a.Font = New System.Drawing.Font("宋体", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                    FlowLayoutPanel1.Controls.Add(a)
                    Dim b As New DataGridView
                    b.Dock = DockStyle.Fill
                    b.AllowUserToAddRows = False
                    b.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    b.RowHeadersVisible = False
                    b.ReadOnly = True
                    b.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                    a.Controls.Add(b)
                    GS_DataGridViewbyDb(b, dt2, True, True)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    GS_ysgx(b)
                End If
            Next
            '’‘’‘单独给出试验类别
            ''''''''''''''''''''''''''''''''''
            Dim sql3 As String = "select tb_x832p_num,tb_x832p_sykczl,tb_x832p_qaspjg,tb_x832p_jgrq,tb_x832p_bzxs,tb_x832p_bfb,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_scdm from vw_x832p where   1=1 "
            sql3 &= "  and tb_x832p_scdm like '%SY%' and tb_x832p_sykczl>=20 and tb_x832p_qaspjg<>'报废'"
            ''''''''''''''''''''''''''''''''''''
            Dim dt3 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql3)
            If dt3.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim dr As DataRow = dt3.NewRow
                dr(0) = "合计"
                dr("tb_x832p_sykczl") = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt3, 1, 0, dt3.Rows.Count - 1)
                dr("tb_x832p_bfb") = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt3, 5, 0, dt3.Rows.Count - 1)
                dt3.Rows.Add(dr)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim a As New GroupBox
                a.Width = 450 : a.Height = 300
                a.Text = "试验类记录数：" & dt3.Rows.Count - 1
                a.Font = New System.Drawing.Font("宋体", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                FlowLayoutPanel1.Controls.Add(a)
                Dim b As New DataGridView
                b.Dock = DockStyle.Fill
                b.AllowUserToAddRows = False
                b.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                b.RowHeadersVisible = False
                b.ReadOnly = True
                b.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                a.Controls.Add(b)
                GS_DataGridViewbyDb(b, dt3, True, True)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                GS_ysgx(b)
            End If
        End With


    End Sub
    Private Sub wz()
        FlowLayoutPanel1.Width = Me.Width - FlowLayoutPanel1.Left - 20
        FlowLayoutPanel1.Height = Me.Height - FlowLayoutPanel1.Top - 20
    End Sub

    Private Sub Frdtbh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
    End Sub

    Private Sub Frdtbh_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        Frylcx.dc(FlowLayoutPanel1)
    End Sub
End Class