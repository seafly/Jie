Public Class Frsavereport
    Public bbsql As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Frsavereport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_mc from tb_js")
        Call GS_useviewbydb2(ListView1, kk, -1, 0)
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tqps As String = TextBox1.Text.Trim
        If tqps = "" Then
            Exit Sub
        End If
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("请至少选择一个角色") : Exit Sub
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_tjmenu_id from tb_tjmenu where tb_tjmenu_mc='" & tqps & "'")
        If dt.Rows.Count > 0 Then
            MsgBox("要保存的报表与数据库现有报表重复！") : Exit Sub
        End If
        Dim wjqxa As String = ""
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            Dim yghm As String = ListView1.CheckedItems(i).SubItems(0).Text
            wjqxa = wjqxa & yghm & ","
        Next
        wjqxa = GF_removedh(wjqxa)
        ''''''''''''''''''''日志权限判断
        If GF_storelog2("保存自定义报表：" & tqps, "保存自定义报表") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        bczdybb(tqps, bbsql, wjqxa, ComboBox1.Text)
        MsgBox("报表" & tqps & "保存成功！")
        Me.Close()
    End Sub
    '标题，sql语句,角色
    Private Sub bczdybb(ByVal Str1 As String, ByVal str2 As String, ByVal str3 As String, ByVal str4 As String)  '保存自定义报表
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        RS.open("tb_tjmenu", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        RS.addnew()
        RS("tb_tjmenu_mc").value = Str1 : RS("tb_tjmenu_sql").value = str2
        RS("tb_tjmenu_fn").value = "自定义报表" : RS("tb_tjmenu_dkjm").value = "Frzdybb"

        RS("tb_tjmenu_js").value = str3
        RS("tb_tjmenu_bumen").value = str4
        RS("tb_tjmenu_czrgh").value = G_dlrgh
        RS.update()
        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
    End Sub
End Class