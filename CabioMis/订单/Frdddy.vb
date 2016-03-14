Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frdddy
    Public bs As String = ""
    Public sql As String
    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        Dim sql0 As String = "select tb_dd_ID,tb_dd_ddh,tb_dd_ddl,tb_dd_fhtjdh,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_pm,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ddrq,tb_dd_bz,tb_dd_jhl,tb_dd_bfb,tb_dd_kdlk,tb_dd_storagewzlk,tb_dd_storagemslk from tb_dd"
        sql0 &= " where tb_dd_bz1='2'  and (tb_dd_bz2 is null or tb_dd_bz2='2') and tb_dd_bz3 is null and tb_dd_fhtjdh='" & ComboBox1.Text & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql0)
        GS_DataGridViewbyDb(show1, dt, 12, True, True)
        GroupBox1.Text = "显示" & show1.RowCount & "条记录"
        '隐藏列
        For i As Integer = 0 To 2
            show1.Columns(i).Visible = False
        Next

    End Sub

    Private Sub Frdddy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_wlbktlr2(ComboBox1, dt, 0, "")
    End Sub

    Private Sub Frdddy_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Private Sub weizhi()
        GroupBox1.Height = Me.Height * 3 / 4
        Dim t As Double = (Me.Height - GroupBox1.Height) / 3
        Label1.Top = t
        ComboBox1.Top = t
        Button1.Top = t
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        Dim nform As New Form
        nform.Text = "订单打印"
        nform.Size = New System.Drawing.Size(755, 464)
        AddHandler nform.Load, AddressOf loard
        Dim toll As New ToolStrip
        toll.Dock = DockStyle.Top

        nform.Controls.Add(toll)
        '**********************************
        Dim wb As New WebBrowser
        wb.Name = "wb1"
        wb.Dock = DockStyle.Fill
        nform.Controls.Add(wb)
        Dim dtt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_dd_ph,tb_dd_jhl,'',tb_dd_jhfhrq from tb_dd where tb_dd_bz1='2' and (tb_dd_bz2 is null or tb_dd_bz2='2')  and tb_dd_bz3 is null  and tb_dd_fhtjdh='" & show1.SelectedRows(0).Cells("tb_dd_fhtjdh").Value & "'")
        Dim dttcount As DataTable = GF_CreateDataSource(G_cnnstr, "select sum(tb_dd_bfb),sum(tb_dd_kdlk),sum(tb_dd_storagewzlk),sum(tb_dd_storagemslk) from tb_dd where tb_dd_bz1='2' and (tb_dd_bz2 is null or tb_dd_bz2='2')  and tb_dd_bz3 is null  and tb_dd_fhtjdh='" & show1.SelectedRows(0).Cells("tb_dd_fhtjdh").Value & "'")
        wb.DocumentText = str(show1.SelectedRows(0).Cells("tb_dd_ddh").Value, show1.SelectedRows(0).Cells("tb_dd_ddl").Value, show1.SelectedRows(0).Cells("tb_dd_cpdm").Value, show1.SelectedRows(0).Cells("tb_dd_jgdm").Value, show1.SelectedRows(0).Cells("tb_dd_fhtjdh").Value, show1.SelectedRows(0).Cells("tb_dd_jhfhzl").Value, dttcount.Rows(0)(0), dttcount.Rows(0)(1), dttcount.Rows(0)(2), dttcount.Rows(0)(3), dtt)

        '**************************
        Dim tb As New ToolStripButton

        '*********************
        tb = New ToolStripButton
        tb.Text = "打印"
        tb.DisplayStyle = ToolStripItemDisplayStyle.Text
        toll.Items.Add(tb)
        AddHandler tb.Click, AddressOf dc2
        '*********************
        tb = New ToolStripButton
        tb.Text = "打印预览"
        tb.DisplayStyle = ToolStripItemDisplayStyle.Text
        toll.Items.Add(tb)
        AddHandler tb.Click, AddressOf dc3
        '*********************
        tb = New ToolStripButton
        tb.Text = "页面设置"
        tb.DisplayStyle = ToolStripItemDisplayStyle.Text
        toll.Items.Add(tb)
        AddHandler tb.Click, AddressOf dc4
        '****************************************
        Me.AddOwnedForm(nform)
        nform.ShowDialog()
    End Sub
    Public Sub dc2()
        Dim s As Form = Me.OwnedForms(0)
        Dim wb1 As WebBrowser = s.Controls("wb1")
        wb1.ShowPrintDialog()
    End Sub
    Public Sub dc3()
        Dim s As Form = Me.OwnedForms(0)
        Dim wb1 As WebBrowser = s.Controls("wb1")
        wb1.ShowPrintPreviewDialog()
    End Sub
    Public Sub dc4()
        Dim s As Form = Me.OwnedForms(0)
        Dim wb1 As WebBrowser = s.Controls("wb1")
        wb1.ShowPageSetupDialog()
    End Sub
    Private Sub loard(ByVal o As Object, ByVal e As EventArgs)
        o.Icon = G_icon : o.BackgroundImage = G_backimg
    End Sub
    Private Sub dc(ByVal o As Object, ByVal e As EventArgs)
        Dim i As Object() = o.tag
        CL_Word.GS_dhgzword2(i(0), i(1), i(2), i(3), i(4), i(5), i(6))
    End Sub
    Private Function str(ByVal ddh As String, ByVal ddl As Double, ByVal cpdm As String, ByVal jgdm As String, ByVal fhtzdh As String, ByVal bdfhzl As Double, ByVal bfb As Double, ByVal kdlk As Double, ByVal storagewzlk As Double, ByVal storagemslk As Double, ByVal dt As DataTable) As String
        Dim file As String = Application.StartupPath()
        file = Replace(file, ":", "|")
        file = "file:///" & file '图片路径
        Dim col As String() = New String() {ddh, ddl.ToString, cpdm, jgdm, fhtzdh, bdfhzl.ToString, bfb.ToString, kdlk.ToString, storagewzlk.ToString, storagemslk.ToString}
        Dim colname As String() = New String() {"销售出库单编号：<br>（销售订单号）", "订单量（KG）", "产品代码", "加工代码", "发货单号", "本单发货总数量", "北方办", "葛店冷库", "外租冷库", "庙山冷库"}
        Dim a As String = "<head><title></title><style type=text/css> .style1{width: 150px; height: 40px;} </style></head><body style='text-align:center'><br><br><br><img src='" & file & "\logo.jpg' width='662' height='51' /><br/><p align='center'><strong>销售出货通知单</strong></p>"
        ''''''''''''''''''''''''''''''''添加前三行
        a &= "<table align='center'  width='650'  border='1' cellpadding='0' cellspacing='0' bordercolor='#000000'><tr class='style1'  cellpadding='0' cellspacing='0' bordercolor='#000000'>"
        For i As Integer = 1 To col.Length
            Dim aa = col(i - 1).ToString
            If aa = "" Then
                aa = "&nbsp;"
            End If
            a &= "<td  class='style1'>" & colname(i - 1) & "</td><td>" & aa & "</td>"
            If i Mod 2 = 0 Then
                a &= "</tr>"
            End If
        Next
        '第四行
        a &= "<tr  class='style1'><td >出库批号</td><td>出库数量（KG）</td><td>仓位</td><td>备注（KG）</td></tr>"
        '''''''''''''''''''''''''''''添加批号重量
        If dt.Rows.Count > 0 Then
            a &= ""
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim kcbmx As String = Trim(GF_getstringsql(G_cnnstr, "select top 1 tb_cpdmhz_cpxz from tb_cpdmhz where tb_cpdmhz_cpdm='" & cpdm & "' and tb_cpdmhz_jgdm='" & jgdm & "'", ""))
                Dim kcb As String = ""
                If InStr(kcbmx, "毛油") <> 0 Then
                    kcb = "tb_x825pkc"
                ElseIf InStr(kcbmx, "成品油") <> 0 Then
                    kcb = "tb_h195zkc"
                ElseIf InStr(kcbmx, "粉") <> 0 Then
                    kcb = "tb_x832pkc"
                End If
                kcbmx = Trim(GF_getstringsql(G_cnnstr, "select top 1 " & kcb & "_cw from " & kcb & " where " & kcb & "_num='" & zh(dt.Rows(j)("tb_dd_ph")) & "' ", "")) '得到仓位
                a &= "<tr class='style1'><td >" & zh(dt.Rows(j)("tb_dd_ph")) & "</td><td>" & zh(dt.Rows(j)("tb_dd_jhl")) & "</td><td >" & kcbmx & "</td><td>&nbsp;</td></tr>"
            Next

        End If
        ''''''''''''''''''''''''''''最后四行
        a &= "<tr  class='style1'><td>计划发货日期：</td><td colspan='3'>" & zh(dt.Rows(0)("tb_dd_jhfhrq")) & "</td></tr>"
        Dim colname1 As String() = New String() {"保管员复核：", "发货专员:"}
        For k As Integer = 0 To colname1.Length - 1
            a &= "<tr  class='style1'><td>" & colname1(k) & "</td><td>&nbsp;</td><td>发货时间：</td><td>&nbsp;</td></tr>"
        Next
        a &= "<tr  class='style1'><td >备注：</td><td colspan  ='3'>&nbsp;</td></tr>"
        a &= "</table></body>"
        Return a
    End Function
    Private Function zh(ByVal str As Object) As String
        If str Is DBNull.Value Then
            Return "&nbsp;"
        Else
            Return str
        End If

    End Function
End Class