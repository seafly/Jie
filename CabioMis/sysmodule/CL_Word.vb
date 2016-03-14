Public Class CL_Word
    'wbz外包装，ddh 订单号；name货物名称；gg货物规格； jhdhsl；计划到货数量；jhdhrq计划到货日期；dls代理商；scs生产商； gdpdrq 规定判断时间； dj单价
    Public Shared Sub GS_dhgzword(ByVal wbz As String, ByVal ddh As String, _
                                  ByVal name As String, ByVal gg As String, ByVal jhdhsl As String, _
                                  ByVal jhdhrq As String, ByVal dls As String, ByVal scs As String, _
                                  ByVal gdpdrq As String, ByVal dj As String, ByVal WordPath As String,
                                  ByVal xinhao As String, ByVal qgbz As String, ByVal cgbz As String,
                                  wbwlmc As String, bzq As String, isGmy As String, gmyly As String, cctj As String, wldm As String)
        '新文档
        Dim newpath As String = Application.StartupPath() & "\" & DeepCode.DeepDoStr.GF_getnewpath & ".doc"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim dhk As New SaveFileDialog
        dhk.Filter = "Word文档 |*.doc"
        If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim wjm As String = dhk.FileName : dhk = Nothing
        If wjm = "" Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''
        My.Computer.FileSystem.CopyFile(WordPath, wjm, True)
        ''''''''''''''''''''''''''''
        Dim xlApp As Object
        xlApp = CreateObject("Word.Application")
        xlApp.Documents.Open(wjm)
        xlApp.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone '显示警告
        xlApp.Application.Visible = True '显示界面
        With xlApp.Documents(wjm)
            '''''''''''''''''''''''''''''''''''''
            .Bookmarks("ddh").Range.Text = ddh : .Bookmarks("name").Range.Text = name
            .Bookmarks("gg").Range.Text = gg : .Bookmarks("xinhao").Range.Text = xinhao : .Bookmarks("jhdhsl").Range.Text = jhdhsl
            .Bookmarks("jhdhrq").Range.Text = jhdhrq : .Bookmarks("dls").Range.Text = dls
            .Bookmarks("scs").Range.Text = scs
            .Bookmarks("wbz").Range.Text = wbz
            .Bookmarks("qgbz").Range.Text = qgbz
            .Bookmarks("cgbz").Range.Text = cgbz
            .Bookmarks("wbwlmc").Range.Text = wbwlmc
            .Bookmarks("bzq").Range.Text = bzq
            .Bookmarks("isGmy").Range.Text = isGmy
            .Bookmarks("gmyly").Range.Text = gmyly
            .Bookmarks("cctj").Range.Text = cctj
            .Bookmarks("wldm").Range.Text = wldm
            .Bookmarks("dj").Range.Text = dj
            '''''''''''''''''''''''''''''''''''''''''''

        End With

        xlApp = Nothing
        MsgBox("完成")
    End Sub
    Public Shared Sub GS_dhgzword2(ByVal ddh As String, ByVal ddl As Double, ByVal cpdm As String, ByVal jgdm As String, ByVal fhtzdh As String, ByVal bdfhzl As Double, ByVal dt As DataTable)
        '新文档   Application.StartupPath() & "\shjl.doc"
        'Dim newpath As String = Application.StartupPath() & "\" & DeepCode.DeepDoStr.GF_getnewpath & ".doc"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim dhk As New SaveFileDialog
        'dhk.Filter = "Word文档 |*.doc"
        'If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If
        'Dim wjm As String = dhk.FileName : dhk = Nothing
        'If wjm = "" Then
        '    Exit Sub
        'End If
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ''My.Computer.FileSystem.CopyFile(WordPath, newpath, True)
        'My.Computer.FileSystem.CopyFile(WordPath, wjm, True)
        '''''''''''''''''''''''''''''
        'Dim xlApp As Object
        'xlApp = CreateObject("Word.Application")
        'xlApp.Documents.Open(wjm)
        'xlApp.DisplayAlerts = True '显示警告
        'xlApp.Application.Visible = True '显示界面
        'With xlApp.Documents(wjm)
        '    '''''''''''''''''''''''''''''''''''''
        '    .Bookmarks("ddh").Range.Text = ddh : .Bookmarks("name").Range.Text = name
        '    .Bookmarks("gg").Range.Text = gg : .Bookmarks("jhdhsl").Range.Text = jhdhsl
        '    .Bookmarks("jhdhrq").Range.Text = jhdhrq : .Bookmarks("dls").Range.Text = dls
        '    .Bookmarks("scs").Range.Text = scs : .Bookmarks("gdpdrq").Range.Text = gdpdrq
        '    .Bookmarks("dj").Range.Text = dj

        '    '''''''''''''''''''''''''''''''''''''''''''

        'End With

        'xlApp = Nothing

    End Sub
End Class
