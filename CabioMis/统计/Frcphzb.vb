Public Class Frcphzb
    '''''''''''''''''''''此模块用于根据不同的产品类型 产品代码 加工代码  用途 操作 来显即时信息
    '''''''''''''''''''''（产品类型，产品代码，加工代码，仓库存量，剩余库存,销售，合格供生产，待定供生产）
    Private Sub wz()
        GroupBox2.Width = Me.Width - 10
        GroupBox2.Height = Me.Height - GroupBox2.Top - 50
    End Sub

    Private Sub Frcphzb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Frcphzb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'and tb_cpdmhz_cplx  not in ('发酵罐' ,'二级罐','一级罐','种子罐','干菌体') order by tb_cpdmhz_cplx ")
        dt.Columns.Add("tb") '添加列用于储存表名
        For t As Integer = 0 To dt.Rows.Count - 1
            Dim cpxz As String
            cpxz = dt.Rows(t)("tb_cpdmhz_cpxz") & "库存"
            Dim dtb As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mx='" & cpxz & "'", 1)
            dt.Rows(t)("tb") = dtb '通过产品性质找到英文表名 

        Next
        Dim alldt As New ArrayList
        Dim dtjg As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select top 1 tb_sjbf_cplb,tb_sjbf_mingc,tb_sjbf_jiagdm,tb_sjbf_ckcl,tb_sjbf_sykc,tb_sjbf_ddgsc,tb_sjbf_xs,tb_sjbf_hggsc from tb_sjbf")
        dtjg.Clear() '得到表架构
        alldt.Add(dtjg)
        ''''''''''''''''''''''''''''''''''''
        '根据产品代码 类型 加工代码 查询即时库存
        For i As Integer = 0 To dt.Rows.Count - 1

            Dim sql As String = "select '" & dt.Rows(i)("tb_cpdmhz_cplx") & "' as '产品类型', '" & dt.Rows(i)("tb_cpdmhz_cpdm") & "' as '产品代码','" & dt.Rows(i)("tb_cpdmhz_jgdm") & "' as  '加工代码',sum(" & dt.Rows(i)("tb") & "_ckcl) as '仓库存量',sum(" & dt.Rows(i)("tb") & "_sykczl) as '剩余库存重量',"
            sql &= "(select sum(" & dt.Rows(i)("tb") & "_ckcl) from " & dt.Rows(i)("tb") & "  where " & dt.Rows(i)("tb") & "_qaspjg='待定'and " & dt.Rows(i)("tb") & "_yg='生产' and " & dt.Rows(i)("tb") & "_cplb='" & dt.Rows(i)("tb_cpdmhz_cplx") & "' and " & dt.Rows(i)("tb") & "_mingc='" & dt.Rows(i)("tb_cpdmhz_cpdm") & "'and " & dt.Rows(i)("tb") & "_jiagdm='" & dt.Rows(i)("tb_cpdmhz_jgdm") & "') as '待定供生产',"
            sql &= "(select sum(" & dt.Rows(i)("tb") & "_ckcl) from " & dt.Rows(i)("tb") & "  where  " & dt.Rows(i)("tb") & "_yg='销售' and " & dt.Rows(i)("tb") & "_cplb='" & dt.Rows(i)("tb_cpdmhz_cplx") & "' and " & dt.Rows(i)("tb") & "_mingc='" & dt.Rows(i)("tb_cpdmhz_cpdm") & "'and " & dt.Rows(i)("tb") & "_jiagdm='" & dt.Rows(i)("tb_cpdmhz_jgdm") & "') as '销售',"
            sql &= "(select sum(" & dt.Rows(i)("tb") & "_ckcl) from " & dt.Rows(i)("tb") & "  where " & dt.Rows(i)("tb") & "_qaspjg='合格'and " & dt.Rows(i)("tb") & "_yg='生产' and " & dt.Rows(i)("tb") & "_cplb='" & dt.Rows(i)("tb_cpdmhz_cplx") & "' and " & dt.Rows(i)("tb") & "_mingc='" & dt.Rows(i)("tb_cpdmhz_cpdm") & "'and " & dt.Rows(i)("tb") & "_jiagdm='" & dt.Rows(i)("tb_cpdmhz_jgdm") & "') as '合格供生产'"
            sql &= " from " & dt.Rows(i)("tb") & "  where( " & dt.Rows(i)("tb") & "_ckcl>0 or " & dt.Rows(i)("tb") & "_sykczl>0 ) and " & dt.Rows(i)("tb") & "_cplb='" & dt.Rows(i)("tb_cpdmhz_cplx") & "' and " & dt.Rows(i)("tb") & "_mingc='" & dt.Rows(i)("tb_cpdmhz_cpdm") & "'and " & dt.Rows(i)("tb") & "_jiagdm='" & dt.Rows(i)("tb_cpdmhz_jgdm") & "'"

            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)

            'For n As Integer = 3 To dt1.Columns.Count - 1
            '    Dim pd As Integer = 0 '用于判断该行的数据出类型代码之外的数量是否全部为空
            '    If DeepCode.DeepDoStr.Null2String(dt1.Rows(0)(n)) <> "" Then
            '        pd = 1
            alldt.Add(dt1)
            'Exit For

            '    End If
        Next

        'Next
        For k As Integer = 1 To alldt.Count - 1
            Frcgdhbb.dtshow(alldt(0), alldt(k)) '合并各个datatable （各个table的架构是相同的）
        Next

        If alldt.Count > 0 Then
            'Dim dt1 As DataTable = add(alldt(0)) ' 从新构造alldt(0)
            GS_DataGridViewbyDb(show1, alldt(0), True, True)
            GroupBox2.Text = "共有" & show1.RowCount & "条数据"
        End If

    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.show1.Rows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("保存报表将锁定相关的记录，您确定吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim n As Integer = Me.show1.Columns.Count
        If ccrsdb(Me.show1, "tb_sjbf") = True Then
            'Call GS_sd("tb_x832p", Me.showl.Rows(0).Cells(n - 2).Value, G_dlrgh)
            MsgBox("完成报表数据保存")
        End If
    End Sub
    Private Function ccrsdb(ByVal list1 As Control, ByVal strtb2 As String) As Boolean
        ccrsdb = False
        'Try
        Dim sj As Object = InputBox("格式如2010-1-1" & vbCrLf & "(请勿输入成2010-01-01)", "请输入保存时间", DatePart(DateInterval.Year, Now) & "-" & DatePart(DateInterval.Month, Now) & "-" & DatePart(DateInterval.Day, Now))
        If sj Is "" Then
            Exit Function
        End If
        Dim lt As DataGridView = list1
        For k As Integer = 0 To lt.Rows.Count - 1
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
            cnn.ConnectionString = G_cnnstr
            cnn.Open()
            Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            RS.open(strtb2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            Dim dtsj As DataTable = show1.DataSource
            For j As Integer = 0 To dtsj.Columns.Count - 1

                RS(dtsj.Columns(j).ColumnName).value = lt.Rows(k).Cells(dtsj.Columns(j).ColumnName).Value

            Next
            RS("tb_sjbf_rq").Value = sj
            RS.update()
            RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

        Next

        ccrsdb = True
        'Catch ex As Exception
        '    MsgBox("数据储存出错") : ccrsdb = False : Exit Function
        'End Try
    End Function
    'Private Function add(ByVal dtName As DataTable) As DataTable

    '    With dtName
    '        Dim xjz As Double = DeepCode.DeepDoStr.Null2zero(.Rows(0)(3)) '仓库存量起始值
    '        Dim xdz As Double = DeepCode.DeepDoStr.Null2zero(.Rows(0)(4)) '剩余库存起始值
    '        'Dim crsy As String = ""
    '        Dim crlr As String = ""
    '        Dim crdd As String = ""
    '        For i As Integer = 0 To .Rows.Count - 1
    '            If i > 0 Then
    '                Dim lx As String = DeepCode.DeepDoStr.Null2String(.Rows(i)(1))
    '                Dim lx1 As String = DeepCode.DeepDoStr.Null2String(.Rows(i - 1)(1))
    '                If lx <> lx1 Then
    '                    'crsy &= i & ","
    '                    crlr &= .Rows(i - 1)(1) & "仓库存量：" & xjz & ","
    '                    crdd &= .Rows(i - 1)(1) & "剩余库存：" & xdz & ","
    '                    xjz = DeepCode.DeepDoStr.Null2zero(.Rows(i)(3)) '每次累加完后仓库存量从新赋值
    '                    xdz = DeepCode.DeepDoStr.Null2zero(.Rows(i)(4)) '每次累加完后剩余库存从新赋值
    '                Else
    '                    xjz += DeepCode.DeepDoStr.Null2zero(.Rows(i)(3))
    '                    xdz += DeepCode.DeepDoStr.Null2zero(.Rows(i)(4))
    '                End If
    '            End If
    '        Next
    '        'crsy &= .Rows.Count & ","
    '        crlr &= .Rows(.Rows.Count - 1)(1) & "仓库存量：" & xjz & ","
    '        crdd &= .Rows(.Rows.Count - 1)(1) & "剩余库存：" & xdz & ","
    '        'If crsy <> "" Then
    '        '    crsy = DeepCode.DeepDoStr.GF_removedh(crsy)
    '        crlr = DeepCode.DeepDoStr.GF_removedh(crlr)
    '        crdd = DeepCode.DeepDoStr.GF_removedh(crdd)
    '        'End If
    '        'Dim crsysz() As String = crsy.Split(",")
    '        Dim crlrsz() As String = crlr.Split(",")
    '        Dim crlrdd() As String = crdd.Split(",")
    '        For i As Integer = 0 To crlrsz.Length - 1
    '            'Dim f As Integer = crsysz(i) + i '插入的索引
    '            ''''''
    '            Dim mm As DataRow = .NewRow
    '            mm(0) = crlrsz(i) '添加仓库存量
    '            mm(1) = crlrdd(i) '添加剩余库存
    '            .Rows.Add(mm)

    '            '''''''''''''''''
    '        Next
    '        '''''''''''''''''''''''''''''''''''''''''''''''
    '    End With
    '    Return dtName

    'End Function
End Class