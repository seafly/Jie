Imports System.IO
Module Md_Yw1
  
    ' 判断是否有权限
    Public Function GF_storelog1(ByVal str2 As String) As Boolean
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序

        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
        ''''''''''''''''''''''''''''''''''''''''''
        GF_storelog1 = True
        Dim qx1 As String = "," & G_dlqx & ","
        Dim qx2 As String = "," & str2 & ","
        If InStr(qx1, qx2) = 0 Then
            MsgBox("请确认您是否具有" & str2 & "的权限！")
            Return False
        End If
    End Function
    ' 储存操作日志
    'str1操作说明,str2系列操作字符串
    Public Sub GS_storelog3(ByVal str As String, ByVal str2 As String)
        Dim Sql As String = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx)values"
        Sql = Sql & "('" & G_dlrgh & "','" & G_dlr & "','" & str & "','" & str2 & "')"
        Call GS_upztxx(G_cnnstr, Sql)
    End Sub
    ' 更新最后一次操作
    Public Sub GS_StoreLastDo()
        Dim Sql As String = "update tb_inline set tb_inline_IP='" & G_IPAdress & "',tb_inline_rq=GETDATE(),tb_inline_xlh='" & G_DriverNum & "'  where tb_inline_gh='" & G_dlrgh & "'"
        Call GS_upztxx(G_cnnstr, Sql)
    End Sub
    ' 检测最后一次操作是否超时,这里超时将直接退出程序
    Public Sub GS_CheckGuestDo()
        Dim Sql As String = "select  tb_inline_rq ,getdate() from  tb_inline where  tb_inline_gh='" & G_dlrgh & "'"
        Dim cg1 As DataTable = GF_CreateDataSource(G_cnnstr, Sql)
        If cg1.Rows.Count = 0 Then
            MsgBox("您可能长时间未进行操作，需要重新登陆！刚才的操作已成功！")
            End
            'Application.Exit()
            'System.Diagnostics.Process.Start("CabioMisUpdate.exe")
        End If
        Dim sj1 As DateTime = cg1.Rows(0)("tb_inline_rq") '得到最后一次操作时间
        Dim sj2 As DateTime = cg1.Rows(0)(1) '得到服务器时间
        If DateAdd(DateInterval.Minute, G_TimeSession, sj1) < sj2 Then
            Call GS_upztxx(G_cnnstr, "delete from tb_inline where tb_inline_gh='" & G_dlrgh & "'")
            MsgBox("您可能长时间未进行操作，需要重新登陆！刚才的操作已成功！")
            End
            'Application.Exit()
            'System.Diagnostics.Process.Start("CabioMisUpdate.exe")
        End If
    End Sub
    ' 储存操作日志
    'str1操作说明,str2系列操作字符串
    Public Function GF_storelog2(ByVal str As String, ByVal str2 As String) As Boolean
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        GF_storelog2 = True
        Dim qx1 As String = "," & G_dlqx & ","
        Dim qx2 As String = "," & str2 & ","
        'If InStr(qx1, qx2) = 0 Then
        '    MsgBox("请确认您是否具有" & str2 & "的权限！")
        '    Return False
        'End If
        Dim Sql As String = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx)values"
        Sql = Sql & "('" & G_dlrgh & "','" & G_dlr & "','" & str & "','" & str2 & "')"
        Call GS_upztxx(G_cnnstr, Sql)
    End Function
    '得到月份时间段字符串
    'str为年
    Public Function GF_yuefen(ByVal str As Integer) As String
        Dim cc As String = ""
        Dim bb As String
        cc = str - 1 & "-12-26" & ","
        For i As Integer = 1 To 12
            bb = Format(CDate(str & "-" & i), "yyyy-MM")
            cc = cc & bb & "-25" & ","
            If i < 12 Then
                cc = cc & bb & "-26" & ","
            End If
        Next
        cc = GF_removedh(cc)
        cc = Replace(cc, "2009-1-25", "2009-1-21")
        cc = Replace(cc, "2009-1-26", "2009-1-22")
        GF_yuefen = cc
    End Function
    Public Function GF_Time2Week(ByVal tjsj As Date) As String
        Dim cc As String = ""
        Dim dy1 As Date = Format(tjsj, "yyyy-MM") & "-1"
        Dim qsj As Date = DateAdd("d", -Weekday(dy1), dy1) '上月最后一个周六
        cc = qsj & "," '
        Dim bsj As Date '时间变量
        Dim zsj As Date
        zsj = DateAdd("d", -1, DateAdd("m", 1, dy1)) '当月最后一天
        Dim cccc As Integer = Weekday(zsj)
        If cccc = 7 Then
            cccc = 0
        End If
        zsj = DateAdd("d", 6 - cccc, zsj) '下月第一个周五
        Dim i As Integer = 0
        Do
            bsj = DateAdd("d", i, qsj)
            If bsj.DayOfWeek = DayOfWeek.Friday And zsj <> Format(bsj, "yyyy-MM-dd") Then
                cc = cc & bsj & ","
            ElseIf bsj.DayOfWeek = DayOfWeek.Saturday And qsj <> Format(bsj, "yyyy-MM-dd") Then
                cc = cc & bsj & ","
            End If
            If zsj = Format(bsj, "yyyy-MM-dd") Then
                cc = cc & bsj
                Exit Do
            End If
            i = i + 1
        Loop

        GF_Time2Week = cc
    End Function


    '例如：2008-9-26,2008-9-26,2008-9-27,2008-10-3,2008-10-4,2008-10-10,2008-10-11,2008-10-17,2008-10-18,2008-10-24,2008-10-25,2008-10-25
    '一个月按四周算，从上月26日起，到周五为第一周，周六到下周五为第二周，最后一个周六到25日为最后一周。
    'Dim cc As String = ""
    'Dim qsj As Date = Format(DateAdd("m", -1, tjsj), "yyyy-MM") & "-26" '第一个时间，即上一月26号
    'cc = qsj & "," '
    'Dim bsj As Date '时间变量
    'Dim zsj As Date = Format(tjsj, "yyyy-MM") & "-25" '结束时间
    'Dim i As Integer = 0
    'Do
    '    bsj = DateAdd("d", i, qsj)
    '    If bsj.DayOfWeek = DayOfWeek.Friday And zsj <> Format(bsj, "yyyy-MM-dd") Then
    '        cc = cc & bsj & ","
    '    ElseIf bsj.DayOfWeek = DayOfWeek.Saturday And qsj <> Format(bsj, "yyyy-MM-dd") Then
    '        cc = cc & bsj & ","
    '    End If
    '    If zsj = Format(bsj, "yyyy-MM-dd") Then
    '        cc = cc & bsj
    '        Exit Do
    '    End If
    '    i = i + 1
    'Loop
    'cc = Replace(cc, "2009-1-25", "2009-1-21")
    'cc = Replace(cc, "2009-1-26", "2009-1-22")
    'GF_Time2Week = cc

    Public Sub showComboList(ByVal str As ComboBox)
        str.Items.Add("未完成")
        str.Items.Add("进行中")
        str.Items.Add("完成")
        str.SelectedItem = str.Items(0)
    End Sub
    Public Sub showComboList2(ByVal str As ComboBox)
        str.Items.Add("计划阶段")
        str.Items.Add("执行阶段")
        str.Items.Add("关闭阶段")
        str.Items.Add("终止阶段")
        str.SelectedItem = str.Items(0)
    End Sub
    '得到月份时间段字符串
    'str为年
    Public Function GF_yuefen1(ByVal str As Integer) As String
        Dim cc As String = ""
        Dim bb As String
        cc = str - 1 & "-12-25" & ","
        For i As Integer = 1 To 12
            bb = Format(CDate(str & "-" & i), "yyyy-MM")
            cc = cc & bb & "-25" & ","
            If i < 12 Then
                cc = cc & bb & "-25" & ","
            End If
        Next
        cc = GF_removedh(cc)
        GF_yuefen1 = cc
    End Function

End Module
