Module Md_Yw2
    '业务处理2
    '更新下步表。目标表、目标表ID。现在表，现在表ID
    '即由现在的生成ID更新前一步的ID
    Public Sub GS_gengsb(ByVal stroldbiao, ByVal strbiaooldid, ByVal strnewbiao, ByVal strnewid) '更新原表
        If InStr("tb_x832pkc,tb_h195zkc", stroldbiao) > 0 Then
            Return
        End If
        Dim xid As String = ""
        Dim tpid As String = GF_gxpd(stroldbiao, stroldbiao & "_glid", strbiaooldid)
        If tpid = "" Then
            xid = strnewid
        Else
            xid = tpid & "," & strnewid
        End If
        Dim sql As String = "update " & stroldbiao & " set " & stroldbiao & "_xbtb='" & strnewbiao & "' "
        sql = sql & "," & stroldbiao & "_glid='" & xid & "' "
        sql = sql & " WHERE " & stroldbiao & "_id  in(" & strbiaooldid & ")"
        GS_upztxx(G_cnnstr, sql)
    End Sub

    '更新上步表。目标表、目标表ID。现在表，现在表ID
    Public Sub GS_gengsb2(ByVal stroldbiao, ByVal strbiaooldid, ByVal strnewbiao, ByVal strnewid) '更新原表
        Dim xid As String = ""
        Dim tpid As String = GF_gxpd(stroldbiao, stroldbiao & "_xbid", strbiaooldid)
        tpid = "," & tpid & ","
        tpid = Replace(tpid, "," & strnewid & ",", "")
        If tpid = ",," Then
            Dim sql1 As String = "update " & stroldbiao & " set " & stroldbiao & "_xbtb=null," & stroldbiao & "_glid=null "
            sql1 = sql1 & " WHERE " & stroldbiao & "_id in(" & strbiaooldid & ")"
            GS_upztxx(G_cnnstr, sql1)
            Exit Sub
        End If
        If Microsoft.VisualBasic.Right(tpid, 1) = "," Then
            xid = GF_removedh(tpid)
        ElseIf Microsoft.VisualBasic.Left(tpid, 1) = "," Then
            xid = Microsoft.VisualBasic.Right(tpid, Len(tpid) - 1)
        End If
        Dim sql As String = "update " & stroldbiao & " set " & stroldbiao & "_glid='" & xid & "' "
        sql = sql & " WHERE " & stroldbiao & "_id in(" & strbiaooldid & ")"
        GS_upztxx(G_cnnstr, sql)
    End Sub
    Public Function GF_gxpd(ByVal stroldbiao, ByVal stroldbiaozd, ByVal strbiaooldid) As String
        GF_gxpd = ""
        Dim sql As String = "select " & stroldbiaozd & "  from " & stroldbiao & "  WHERE " & stroldbiao & "_id in(" & strbiaooldid & ")"
        Dim tb As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If IsDBNull(tb.Rows(0)(0)) = True Then
            GF_gxpd = ""
        Else
            GF_gxpd = tb.Rows(0)(0)
        End If
    End Function
    '返回true表示被锁定，否则是未锁定
    Public Function GF_IsLock(ByVal inputTableName As String, ByVal inputDataId As Integer) As Boolean '判断记录是否被锁定
        If inputTableName = "" Then Return False
        '参数分别代表表名, 代表ID序
        Dim sql As String = "select tb_zlock_ID from  tb_zlock  where tb_zlock_bm='" & inputTableName & "'  and tb_zlock_bmid=" & inputDataId & ""
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    '删除数据，表，ID
    Public Sub GS_delsj(ByVal strbiao As String, ByVal strid As String)
        Dim xbtbzd1 As String = strbiao & "_xbtb"
        Dim xbtbzd2 As String = strbiao & "_glid"
        Dim sbtbzd1 As String = strbiao & "_sbtb"
        Dim sbtbzd2 As String = strbiao & "_sbid"
        Dim bds As String = "," & sbtbzd1 & "," & sbtbzd2 & ""
        If strbiao = "tb_t676l" Then '原料表
            bds = ""
        End If
        Dim sql As String = "select " & xbtbzd1 & bds & " from  " & strbiao & " where  " & strbiao & "_id=" & strid
        '’‘’‘’‘’‘看看是否到了下步表
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If IsDBNull(dt.Rows(0)(0)) = False Then
            MsgBox("本记录已经关联到下个生产步骤，不能删除！") : Exit Sub
        End If
        '''''''''''''''''
        If strbiao = "tb_t676l" Then '原料表可以直接删除了
            sql = "delete from  " & strbiao & " where  " & strbiao & "_id=" & strid
            GS_upztxx(G_cnnstr, sql) : Exit Sub
        End If
        Dim sbtb As String = dt.Rows(0)(1) '上步表
        Dim sbid As String = dt.Rows(0)(2) '上步表ID
        sql = "SELECT " & sbtb & "_glid ," & sbtb & "_id from  " & sbtb & "  where " & sbtb & "_id in(" & sbid & ") "
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到上步表相关记录中的下步表字段内容
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim temp1 As String = "," & dt.Rows(i)(0) & ","
            Dim temp2 As String = "," & strid & "," '''''''''''''前后加逗号是为了准确判断
            temp1 = Replace(temp1, temp2, ",")
            Dim zfccd As Integer = Len(temp1)
            If zfccd = 1 Then
                sql = "update " & sbtb & " set " & sbtb & "_glid=null," & sbtb & "_xbtb=null  where  " & sbtb & "_id=" & dt.Rows(i)(1)
            Else '出现1对多情况
                If Microsoft.VisualBasic.Left(temp1, 1) = "," Then
                    temp1 = Microsoft.VisualBasic.Right(temp1, zfccd - 1)
                Else
                    temp1 = GF_removedh(temp1)
                End If
                sql = "update " & sbtb & " set " & sbtb & "_glid=" & temp1 & "  where  " & sbtb & "_id=" & dt.Rows(i)(1)
            End If
            GS_upztxx(G_cnnstr, sql)
        Next
        sql = "delete from  " & strbiao & " where  " & strbiao & "_id=" & strid
        GS_upztxx(G_cnnstr, sql)
    End Sub



    Public Sub GS_sd(ByVal input1 As String, ByVal input2 As String, ByVal input3 As String) '储存锁定表
        If input2 <> "" Then
            '参数分别代表表名, 代表ID序列, 代表操作人工号
            Dim sql As String = "insert into tb_zlock(tb_zlock_bm,tb_zlock_bmid,tb_zlock_czrgh) select '" & input1 & "'," & input1 & "_id, '" & input3 & "' from " & input1 & " where " & input1 & "_id in(" & input2 & ")"
            GS_upztxx(G_cnnstr, sql)
        End If

    End Sub
    Public Sub GS_sd(ByVal input1 As String, ByVal input2 As String, ByVal input3 As String, ByVal strcnn As String) '储存锁定表
        If input2 <> "" Then
            '参数分别代表表名, 代表ID序列, 代表操作人工号
            Dim sql As String = "insert into tb_zlock(tb_zlock_bm,tb_zlock_bmid,tb_zlock_czrgh) select '" & input1 & "'," & input1 & "_id, '" & input3 & "' from " & input1 & " where " & input1 & "_id in(" & input2 & ")"
            DeepCode.DeepDoDataTable.GS_upztxx(strcnn, sql)
        End If

    End Sub

    'str1 代表要查询的字段，str2代表查询值
    Public Function GF_cxph(ByVal str1 As String, ByVal str2 As String, Optional pBs As Integer = 0) As Boolean '查询批号
        Dim zd As String = Replace(str1, "tb_", "")
        zd = GF_searchchar(zd, "_", "left")
        zd = "tb_" & zd '上面获取表名称
        dim strWhBs As String=""
        If pBs > 0 Then
            strWhBs &=" and "& zd &"_ID<>" & pBs
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select " & zd & "_id from " & zd & " where " & str1 & "='" & str2 & "' " & strWhBs)
        If dt.Rows.Count > 0 Then
            GF_cxph = True
        Else
            GF_cxph = False
        End If
    End Function
    Public Sub GS_qlsj(ByVal str As Control) '清理数据
        str.Text = GF_searchchar(str.Text, "|", "left")
    End Sub
#Region "原料库存和原料罐的库存操作"
    '业务处理1
    '提取原料重量的ListView
    ' Call ltcsh(dt1, aa.ListView1, "葡萄糖", 5, 6, tb_b970t_p532i.Text, tb_b970t_c17u.Text)
    Public Sub ltcsh(ByVal db1 As DataTable, ByVal frlv1 As ListView, ByVal str0 As String, ByVal str1 As Integer, ByVal str2 As Integer, ByVal str3 As String, ByVal str4 As String)
        Dim strph() As String = Split(str3, ",")
        Dim strzl() As String = Split(str4, ",")
        With frlv1
            .Clear() : .Visible = True : .CausesValidation = False : .View = View.Details : .LabelEdit = True
            .BeginUpdate()
            .Columns.Add("提取" & str0 & "数量", CType(.Width / 4 - 4, Integer), HorizontalAlignment.Center)
            .Columns.Add(str0 & "批号", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add(str0 & "车间存量", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add(str0 & "单位", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("换算系数", 0)
            For i As Integer = 0 To db1.Rows.Count - 1
                .Items.Add(0)
                .Items(i).SubItems.Add(db1.Rows(i)(str1))
                .Items(i).SubItems.Add(db1.Rows(i)(str2))
                .Items(i).SubItems.Add(db1.Rows(i)("tb_i259b_h200z"))
                .Items(i).SubItems.Add(db1.Rows(i)("tb_i259b_zlhsxs"))
            Next
            .EndUpdate()
            For i As Integer = 0 To strph.Length - 1
                For j As Integer = 0 To .Items.Count - 1
                    If .Items(j).SubItems(1).Text = strph(i) Then
                        .Items(j).SubItems(0).Text = strzl(i)
                        GoTo XXX
                    End If
                Next
XXX:
            Next
        End With

    End Sub
    '**************此处更新原料的库存
    Public Sub GS_kcylkc(ByVal str As TextBox, ByVal str3 As Form) '更新原料库存str表示批号控件
        Try
            Dim ph() As String = Split(str.Text, ",") '批号数组
            Dim temp1 As String = str3.Controls(str.Name & "t").Text
            Dim zl() As String = Split(temp1, ",") '重量数组
            For i As Integer = 0 To UBound(ph)
                Dim kczl As Double = CDbl(_S.YanFormatNum(zl(i))) '应该扣除的重量
                Dim sql As String = "update tb_i259b set tb_i259b_p518h=tb_i259b_p518h-" & kczl & " where tb_i259b_num='" & ph(i) & "'"

                GS_upztxx(G_cnnstr, sql)
            Next
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 更新批号序列原表的数量
    ''' </summary>
    ''' <param name="pFr">操作窗体</param>
    ''' <param name="pMbzdname">目标字段名</param>
    ''' <param name="pPh">批号文本框</param>
    ''' <param name="pZl">重量文本框</param>
    ''' <param name="pBszd">标识字段名</param>
    Public Sub GS_yanUpdatePhzl(pFr As Control, pMbzdname As String, pPh As TextBox, Optional pZl As TextBox = Nothing, Optional pBszd As String = "num")
        Try
            Dim tTbname As String = _D.getZdtext(pMbzdname, 0, 3)
            If pZl Is Nothing Then
                pZl = pFr.YanFindControl(pPh.Name & "t")
            End If
            Dim ph() As String = pPh.Text.Trim.Split(",") '批号数组
            Dim zl() As String = pZl.Text.Trim.Split(",") '重量数组
            For i As Integer = 0 To ph.Length - 1
                Dim kczl As Double = CDbl(_S.YanFormatNum(zl(i))) '应该扣除的重量
                Dim sql As String = "update " & tTbname & " set " & pMbzdname & "=" & pMbzdname & "-" & kczl & " where " & tTbname & "_" & pBszd & "='" & ph(i) & "'"
                sql.YanDbExe()
            Next
        Catch ex As Exception

        End Try
    End Sub
    '判断库存是否小于输入值
    Public Function Gf_pdylkc(ByVal str As TextBox, ByVal str3 As Form) As String '合计扣除原料库存str表示批号控件，str2表示合计控件
        Gf_pdylkc = ""
        If str.Text = "" Then
            Exit Function
        End If
        Dim temp1 As String = str3.Controls(str.Name & "t").Text
        Dim zl() As String = Split(temp1, ",") '重量数组
        Dim ph() As String = Split(str.Text, ",") '批号数组
        For i As Integer = 0 To UBound(ph)
            Dim sql As String = "select tb_i259b_id from tb_i259b where tb_i259b_num='" & ph(i) & "' and tb_i259b_p518h>=" & zl(i) & ""
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                Gf_pdylkc = "批号" & ph(i) & "不存在或重量不够" : Exit Function
            End If
        Next
    End Function
    Public Sub GS_sancusql(ByVal str(,) As String) '还原原料
        Dim sql As String = ""
        For i As Integer = 0 To UBound(str, 1)
            Dim old1 As String = str(i, 0) '对应原料批号及重量
            Dim old2 As String = str(i, 1)
            Dim kk1() As String = Split(old1, ",")
            Dim kk2() As String = Split(old2, ",")
            For j As Integer = 0 To UBound(kk1)
                If kk1(j) <> "" Then
                    sql = sql & vbCrLf & " update tb_i259b set tb_i259b_p518h=tb_i259b_p518h+" & kk2(j) & " where tb_i259b_num='" & kk1(j) & "'"
                End If

            Next
        Next
        If sql <> "" Then
            GS_upztxx(G_cnnstr, sql) '一起还原
        End If

    End Sub
    Public Sub GS_hycusql(ByVal str(,) As String) '反还原原料
        Dim sql As String = ""
        For i As Integer = 0 To UBound(str, 1)
            Dim old1 As String = str(i, 0) '对应原料批号及重量
            Dim old2 As String = str(i, 1)
            Dim kk1() As String = Split(old1, ",")
            Dim kk2() As String = Split(old2, ",")
            For j As Integer = 0 To UBound(kk1)
                If kk1(j) <> "" Then
                    sql = sql & vbCrLf & " update tb_i259b set tb_i259b_p518h=tb_i259b_p518h-" & kk2(j) & " where tb_i259b_num='" & kk1(j) & "'"
                End If

            Next
        Next
        If sql <> "" Then
            GS_upztxx(G_cnnstr, sql) '一起还原
        End If

    End Sub
    '****************************************************此处是原料罐的过程
    Public Sub ltcsh2(ByVal db1 As DataTable, ByVal frlv1 As ListView, ByVal str0 As String, ByVal str1 As Integer, ByVal str2 As Integer, ByVal str3 As String, ByVal str4 As String)
        Dim strph() As String = Split(str3, ",")
        Dim strzl() As String = Split(str4, ",")
        With frlv1
            .Clear() : .Visible = True : .CausesValidation = False : .View = View.Details : .LabelEdit = True
            .BeginUpdate()
            .Columns.Add("提取" & str0 & "体积", CType(.Width / 4 - 4, Integer), HorizontalAlignment.Center)
            .Columns.Add(str0 & "批号", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add(str0 & "体积", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add(str0 & "换算关系", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            For i As Integer = 0 To db1.Rows.Count - 1
                .Items.Add(0)
                .Items(i).SubItems.Add(db1.Rows(i)(str1))
                .Items(i).SubItems.Add(db1.Rows(i)(str2))
                .Items(i).SubItems.Add(db1.Rows(i)(4))
            Next
            .EndUpdate()
            For i As Integer = 0 To strph.Length - 1
                For j As Integer = 0 To .Items.Count - 1
                    If .Items(j).SubItems(1).Text = strph(i) Then
                        .Items(j).SubItems(0).Text = strzl(i)
                        GoTo XXX
                    End If
                Next
XXX:
            Next
        End With

    End Sub
    Public Sub GS_TCYLLIST2(ByVal STR1 As Form, ByVal STR2 As DataTable, ByVal STR3 As String, ByVal STR4 As String)
        Dim KJM2 As String = STR3 & "t"
        Dim aa As New Frphzl
        With STR1
            .AddOwnedForm(aa)
            Call ltcsh2(STR2, aa.ListView1, STR4, 5, 6, .Controls(STR3).Text, .Controls(KJM2).Text)
            aa.ShowDialog()
            .Controls(STR3).Text = .Controls("ph").Text : .Controls(KJM2).Text = .Controls("zl").Text
            GS_GETGUANGUZ(STR2, STR3, STR1) '得到原料罐的估计重量并赋值给文本框
            .Controls("ph").Text = "" : .Controls("zl").Text = ""
        End With
    End Sub
    ''' <summary>
    ''' '得到原料罐的估计重量
    ''' </summary>
    ''' <param name="gtable">原料罐DATATABLE</param>
    ''' <param name="phkj">原料批号控件</param>
    ''' <param name="whichform">窗体</param>
    ''' <remarks></remarks>
    Public Sub GS_GETGUANGUZ(ByVal gtable As DataTable, ByVal phkj As String, ByVal whichform As Form)

        Dim temp1 As String = whichform.Controls(phkj & "t").Text
        Dim phsz() As String = Split(whichform.Controls(phkj).Text, ",") '批号数组
        Dim zl() As String = Split(temp1, ",") '体积数组
        '批号数组应该和体积数组一样维度
        Dim hjzl As Double = 0 '合计重量
        Try
            For i As Integer = 0 To UBound(zl)
                Dim ph As String = phsz(i) '批号
                Dim hsgx As Double = GF_cnwithen(gtable, "tb_tg_num='" & ph & "'", 4) '得到换算关系
                Dim tj As Double = CDbl(zl(i)) '得到体积
                hjzl += tj * hsgx
            Next
        Catch ex As Exception

        End Try

        whichform.Controls(phkj & "gz").Text = hjzl.ToString
    End Sub
    Public Sub GS_kcylkc2(ByVal str As TextBox, ByVal str3 As Form) '更新原料库存str表示批号控件
        Try
            Dim ph() As String = Split(str.Text, ",") '批号数组
            Dim temp1 As String = str3.Controls(str.Name & "t").Text
            Dim zl() As String = Split(temp1, ",") '重量数组
            For i As Integer = 0 To UBound(ph)
                Dim kczl As Double = CDbl(zl(i)) '应该扣除的重量
                Dim sql As String = "update tb_tg set tb_tg_tj=tb_tg_tj-" & kczl & " where tb_tg_num='" & ph(i) & "'"

                GS_upztxx(G_cnnstr, sql)
            Next
        Catch ex As Exception

        End Try
    End Sub
    '判断库存是否小于输入值
    Public Function Gf_pdylkc2(ByVal str As TextBox, ByVal str3 As Form) As String '合计扣除原料库存str表示批号控件，str2表示合计控件
        Gf_pdylkc2 = ""
        If str.Text = "" Then
            Exit Function
        End If
        Dim temp1 As String = str3.Controls(str.Name & "t").Text
        Dim zl() As String = Split(temp1, ",") '重量数组
        Dim ph() As String = Split(str.Text, ",") '批号数组
        For i As Integer = 0 To UBound(ph)
            Dim sql As String = "select tb_tg_id from tb_tg where tb_tg_num='" & ph(i) & "' and tb_tg_tj>=" & zl(i) & ""
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                Gf_pdylkc2 = "批号" & ph(i) & "不存在或体积不够" : Exit Function
            End If
        Next
    End Function
    Public Sub GS_sancusql2(ByVal str(,) As String) '还原原料罐
        Dim sql As String = ""
        For i As Integer = 0 To UBound(str, 1)
            Dim old1 As String = str(i, 0) '对应原料批号及重量
            Dim old2 As String = str(i, 1)
            Dim kk1() As String = Split(old1, ",")
            Dim kk2() As String = Split(old2, ",")
            For j As Integer = 0 To UBound(kk1)
                If kk1(j) <> "" Then
                    sql = sql & vbCrLf & " update tb_tg set tb_tg_tj=tb_tg_tj+" & kk2(j) & " where tb_tg_num='" & kk1(j) & "'"
                End If

            Next
        Next
        If sql <> "" Then
            GS_upztxx(G_cnnstr, sql) '一起还原
        End If

    End Sub
    Public Sub GS_hycusql2(ByVal str(,) As String) '反还原原料罐
        Dim sql As String = ""
        For i As Integer = 0 To UBound(str, 1)
            Dim old1 As String = str(i, 0) '对应原料批号及重量
            Dim old2 As String = str(i, 1)
            Dim kk1() As String = Split(old1, ",")
            Dim kk2() As String = Split(old2, ",")
            For j As Integer = 0 To UBound(kk1)
                If kk1(j) <> "" Then
                    sql = sql & vbCrLf & " update tb_tg set tb_tg_tj=tb_tg_tj-" & kk2(j) & " where tb_tg_num='" & kk1(j) & "'"
                End If

            Next
        Next
        If sql <> "" Then
            GS_upztxx(G_cnnstr, sql) '一起还原
        End If
    End Sub
    ''*******
    '弹出原料窗体过程，窗体，原料DB，原料批号控件名，原料名称
    Public Sub GS_TCYLLIST(ByVal STR1 As Form, ByVal STR2 As DataTable, ByVal STR3 As String, ByVal STR4 As String)
        Dim KJM2 As String = STR3 & "t"
        Dim aa As New Frphzl
        With STR1
            .AddOwnedForm(aa)
            aa.m_gzkj = STR3 & "gz"
            Call ltcsh(STR2, aa.ListView1, STR4, 5, 6, .Controls(STR3).Text, .Controls(KJM2).Text)
            aa.ShowDialog()
            .Controls(STR3).Text = .Controls("ph").Text : .Controls(KJM2).Text = .Controls("zl").Text
            .Controls("ph").Text = "" : .Controls("zl").Text = ""
        End With
    End Sub
    ''*******
    '弹出原料窗体过程，窗体，原料DB，原料批号控件名，原料名称
    Public Sub GS_TCYLLISTzl(ByVal STR1 As Form, ByVal STR2 As DataTable, ByVal STR3 As String, ByVal STR4 As String)
        Dim KJM2 As String = STR3 & "t"
        Dim aa As New Frphzl
        With STR1
            .AddOwnedForm(aa)
            aa.m_gzkj = STR3 & "zl"
            Call ltcsh(STR2, aa.ListView1, STR4, 5, 6, .Controls(STR3).Text, .Controls(KJM2).Text)
            aa.ShowDialog()
            .Controls(STR3).Text = .Controls("ph").Text : .Controls(KJM2).Text = .Controls("zl").Text
            .Controls("ph").Text = "" : .Controls("zl").Text = ""
        End With
    End Sub


    ''' <summary>
    ''' 弹出原料窗体过程
    ''' </summary>
    ''' <param name="pFrOwner">父窗体</param>
    Public Function GS_TCYLLIST_yan(ByVal pFrOwner As Form, pClpam As frYanPhzl.CLphzlPam) As DataTable
        Dim aa As New frYanPhzl(pClpam)
        pFrOwner.AddOwnedForm(aa)
        aa.ShowDialog()
        Return Nothing
    End Function

    Public Sub GS_hjkcylkc(ByVal str As TextBox, ByVal str2 As TextBox, ByVal str3 As Form) '合计扣除原料库存str表示批号控件，str2表示合计控件
        Dim temp1 As String = str3.Controls(str.Name & "t").Text
        Dim zl() As String = Split(temp1, ",") '重量数组
        Dim hjzl As Double = 0 '合计重量
        Try
            For i As Integer = 0 To UBound(zl)
                Dim kczl As Double = CDbl(_S.YanFormatNum(zl(i))) '应该扣除的重量
                hjzl = hjzl + kczl
            Next
        Catch ex As Exception

        End Try

        str2.Text = hjzl.ToString
    End Sub
  
#End Region

    Public Sub GS_DelLock(ByVal inputTableName As String, ByVal inputDataId As Integer) '删除锁定记录
        If inputTableName <> "" Then
            '参数分别代表表名, 代表ID
            Dim sql As String = "delete from  tb_zlock where tb_zlock_bm='" & inputTableName & "'  and tb_zlock_bmid=" & inputDataId & ""
            DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)
        End If
    End Sub
    Public Sub GS_DelLock(ByVal inputTableName As String, ByVal inputDataId As Integer, ByVal strcnn As String) '删除锁定记录
        If inputTableName <> "" Then
            '参数分别代表表名, 代表ID
            Dim sql As String = "delete from  tb_zlock where tb_zlock_bm='" & inputTableName & "'  and tb_zlock_bmid=" & inputDataId & ""
            DeepCode.DeepDoDataTable.GS_upztxx(strcnn, sql)
        End If
    End Sub

 
    '得到批号前缀与起始值
    'Public Function GF_getxh(ByVal str As String) As String
    '    GF_getxh = ""
    '    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_l358d where tb_l358d_zd='" & str & "'")
    '    If dt.Rows.Count > 0 Then
    '        Dim phqz As String = dt.Rows(0)(2) '前缀
    '        Dim dqz As Integer = dt.Rows(0)(3) '当前值
    '        GF_getxh = phqz & "," & dqz
    '    End If
    'End Function
   

    '添加，修改，删除某一条记录的时候，根据表名，ID判断该记录是否已经被锁定
    Public Function GF_MakeIsSD(ByVal tb As String, ByVal id As String) As Boolean
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_zlock where tb_zlock_bm='" & tb & "' and tb_zlock_bmid=" & id)
        If dt.Rows.Count > 0 Then
            MsgBox("该条记录已经锁定，无法完成操作！")
            GF_MakeIsSD = False
        Else
            GF_MakeIsSD = True
        End If
    End Function


End Module
