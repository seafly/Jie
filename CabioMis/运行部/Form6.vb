Public Class Form6
    Private dtaa As New DataTable
    Private adp As OleDb.OleDbDataAdapter
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        For i As Integer = 1990 To 2100
            ComboBox1.Items.Add(i)
            ComboBox1.Text = Now.Year
        Next

        For i As Integer = 1 To 12
            ComboBox2.Items.Add(i)
            ComboBox2.SelectedIndex = 0
        Next
        Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("此操作根据数据量大小来决定时间,可能时间比较长!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim file As New OpenFileDialog
        file.ShowDialog()

        Dim dt1 As DataTable

        '原料
        Dim sql As String = "select tb_i259b_c24u,tb_i259b_num,tb_i259b_p518h from tb_i259b"
        dt1 = GF_CreateDataSource(G_cnnstr, sql)

        'excel
        Dim dta As New DataTable

        If file.FileName = "" Then
            Exit Sub
        End If

        XlsDataTable(file.FileName, dta)

        sql = "select tb_n419f_b978t,tb_n419f_ylph,tb_n419f_r589j,tb_n419f_u697m,tb_n419f_cy,tb_n419f_rq from tb_n419f"
        Dim cnn As New OleDb.OleDbConnection(G_cnnstr)
        adp = New OleDb.OleDbDataAdapter(sql, cnn)
        Dim bul As New OleDb.OleDbCommandBuilder(adp)
        adp.Fill(dtaa)

        For i As Integer = 0 To dt1.Rows.Count - 1
            For j As Integer = 0 To dta.Rows.Count - 1
                If dt1.Rows(i)(1).ToString() = dta.Rows(j)(0).ToString() Then
                    Dim row As DataRow = dtaa.NewRow()
                    row(0) = dt1.Rows(i)(0)
                    row(1) = dt1.Rows(i)(1)
                    row(2) = dt1.Rows(i)(2)
                    row(3) = dta.Rows(i)(1)
                    row(4) = Convert.ToDouble(dta.Rows(i)(1)) - Convert.ToDouble(dt1.Rows(i)(2))
                    row(5) = Now.ToString()
                    dtaa.Rows.Add(row)
                End If
            Next
        Next

        GS_useviewbydb2(ListView1, dtaa, -1, 0)
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListView1.Items.Count < 1 Then
            MsgBox("没有数据")
            Exit Sub
        End If
        Try
            adp.Update(dtaa)
            MsgBox("保存成功")
            Button2.Enabled = False
            Button3.Enabled = True
        Catch ex As Exception
            MsgBox("保存失败")
        End Try
    End Sub

    Public Sub XlsDataTable(ByVal db1 As String, ByVal dt As DataTable)
        Try
            Dim xlsApp As Object = CreateObject("Excel.Application")
            xlsApp.DisplayAlerts = False '不显示警告
            xlsApp.Application.Visible = False '不显示界面
            Dim xlbook As Object = xlsApp.Workbooks.Open(db1)
            Dim xlsSheet As Object = xlbook.Worksheets(1)
            ' xlsSheet.Activate()

            dt.Columns.Add("批号", GetType(String))
            dt.Columns.Add("剩余量", GetType(Double))

            Dim i As Integer = 2
            While xlsSheet.Cells(i, 1).value <> ""
                Dim row As DataRow = dt.NewRow()
                row(0) = xlsSheet.Cells.Item(i, 5).value
                row(1) = xlsSheet.Cells.Item(i, 9).value
                dt.Rows.Add(row)
                i = i + 1
            End While


            xlsSheet = Nothing
            xlbook.Close()
            xlbook = Nothing
            xlsApp.Quit()
            Dim jcdh As Integer = System.GC.GetGeneration(xlsApp)
            xlsApp = Nothing
            System.GC.Collect(jcdh)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql As String = "select tb_n419f_ID,tb_n419f_b978t,tb_n419f_ylph,tb_n419f_r589j,tb_n419f_u697m,tb_n419f_cy,tb_n419f_rq from tb_n419f where year(tb_n419f_rq)='" & ComboBox1.Text & "' and month(tb_n419f_rq)='" & ComboBox2.Text & "'"
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt1, 0, 0)
    End Sub
End Class