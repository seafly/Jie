Public Class FrAddfangong
    '仓库名称数组
    Dim m_arrCkName As String()=Nothing
    Private Sub FrAddfangong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = G_icon
        Me.BackgroundImage = G_backimg

        AddHandler tb_fangong_bs2.DoubleClick, AddressOf addCpph

        m_arrCkName = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",")
        For i As Integer = 0 To m_arrCkName.Length - 1
            m_arrCkName(i) = tb_fangong_tbname.Text & "_" & m_arrCkName(i)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GF_YZSJ(Me, "tb_fangong_bz") = False Then '验证控件
            Exit Sub
        End If
        Dim dt As DataTable = MyBase.Tag
        dt = dt.Select("使用重量<>'0'").YanArrDrToDb
        '重量判断
        For Each tDr As DataRow In dt.Rows
            '总重量
            Dim sql As String = "select * from " & tb_fangong_tbname.Text & " where " & tb_fangong_tbname.Text & "_ID=" & tDr(tb_fangong_tbname.Text & "_ID")
            Dim tDt As DataTable = sql.YanGetDb
            '将两条记录进行对比
            If tDt.Rows.Count = 0 Then
                MsgBox("数据丢失！", MsgBoxStyle.Exclamation)
                Return
            End If
            '总重量(数据库重量，提取重量)
            If CDbl(tDt.YanDtValue2(tb_fangong_tbname.Text & "_sykczl")) < CDbl(tDr(0)) Then
                MsgBox("总重量不匹配！", MsgBoxStyle.Exclamation)
                Return
            End If
            '仓库重量
            If CDbl(tDt.YanDtValue2(tb_fangong_tbname.Text & "_sykczl")) >= CDbl(tDr(0)) Then
                For i As Integer = 0 To m_arrCkName.Length - 1
                    If CDbl(tDt.YanDtValue2(m_arrCkName(i))) < CDbl(tDr(m_arrCkName(i))) Then
                        MsgBox("仓库重量不匹配！", MsgBoxStyle.Exclamation)
                        Return
                    End If
                Next
            End If
        Next
        '更新数据库
        For Each tDr As DataRow In dt.Rows
            Dim tCollDic As New Dictionary(Of String, String)
            '更新可用数量，仓库存量，车间存量
            tCollDic("@" & tb_fangong_tbname.Text & "_sykczl") = tb_fangong_tbname.Text & "_sykczl - " & tDr(0)
            tCollDic("@" & tb_fangong_tbname.Text & "_ckcl") = tb_fangong_tbname.Text & "_ckcl - " & tDr(0)
            tCollDic("@" & tb_fangong_tbname.Text & "_cjcl") = tb_fangong_tbname.Text & "_cjcl + " & tDr(0)
            '仓库重量
            For i As Integer = 0 To m_arrCkName.Length - 1
                tCollDic("@" & m_arrCkName(i)) = m_arrCkName(i) & " - " & tDr(m_arrCkName(i))
            Next
            '更新库存表
            _D.updateData(tb_fangong_tbname.Text, tCollDic, tb_fangong_tbname.Text & "_ID=" & tDr(tb_fangong_tbname.Text & "_ID"), "@")
            '写入进出货表
            tCollDic = New Dictionary(Of String, String)
            tCollDic("tb_jch_cplb") = tDr(tb_fangong_tbname.Text & "_cplb")
            tCollDic("tb_jch_mingc") = tDr(tb_fangong_tbname.Text & "_mingc")
            tCollDic("tb_jch_jiagdm") = tDr(tb_fangong_tbname.Text & "_jiagdm")
            tCollDic("tb_jch_num") = tDr(tb_fangong_tbname.Text & "_num")
            tCollDic("tb_jch_cz") = "出"
            tCollDic("tb_jch_sl") = tDr(0)
            tCollDic("tb_jch_rq") = _S.YanForDa_2(DateTime.Now)
            tCollDic("tb_jch_bz") = tb_fangong_bz.text
            tCollDic("tb_jch_yt") = "返工"
            tCollDic("tb_jch_chts") = 0
            tCollDic("tb_jch_czrgh") = G_dlrgh
            tCollDic("tb_jch_jiagdmsm") = tDr(tb_fangong_tbname.Text & "_jiagdm")
            Dim tarrCkName() As String = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",")
            For i As Integer = 0 To tarrCkName.Length - 1
                tCollDic("tb_jch_" & tarrCkName(i)) = tDr(m_arrCkName(i))
            Next
            _D.insertData("tb_jch", tCollDic)
        Next
        Me.DialogResult = DialogResult.OK
    End Sub

    Sub addCpph()
        '操作的表名
        Dim tStrBiao As String = tb_fangong_tbname.Text
        '数据库仓库字符串
        Dim tStrCk As String = ""
        For Each tDr As DataRow In GetType(en_cklist).YanEnToTb.Rows
            tStrCk &= tStrBiao & "_" & tDr("text") & ","
        Next
        tStrCk = tStrCk.YanRemovedh
        Dim sql As String = "select 0 as 使用重量," & tStrBiao & "_num," & tStrBiao & "_sykczl," & tStrBiao & "_jgrq,'KG' as 单位," & tStrBiao & "_id," &
            tStrBiao & "_mingc," & tStrBiao & "_jiagdm," & tStrBiao & "_cplb," & tStrCk &
            " from " & tStrBiao & " where " & tStrBiao & "_qaytjy='返工' and " & tStrBiao & "_qaspjg='合格' and " & tStrBiao & "_sykczl>0"
        Dim dt As DataTable = sql.YanGetDb

        Dim tStrTit As String = IIf(tb_fangong_tbname.Text = "tb_x832pkc", "成品粉", "成品油")

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = tStrTit
        objClpam.colHide = tStrCk
        objClpam.isLabelEdit = False
        objClpam.phName = "tb_fangong_bs2"
        objClpam.isDoubleClick=False
        objClpam.callbackRckFn = AddressOf setCkcl
        objClpam.callbackFn = AddressOf setAddPh
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub
    '设置仓库存量
    Function setCkcl(pFr2 As frYanPhzl) As Boolean
        Dim tStrBiao As String = tb_fangong_tbname.Text
        Dim tItem As ListViewItem = pFr2.ListView1.SelectedItems(0)
        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = IIf(tItem.Tag Is Nothing, cl_theCl.getCkslToTb(tStrBiao, tItem.SubItems(tStrBiao & "_ID").Text), tItem.Tag)
        objClpam.callbackFn = Function(pDt As DataTable, pFr As frYanPhzl) As Boolean
                                  '右键确定后的操作
                                  tItem.SubItems(0).Text = pFr.m_countNum
                                  tItem.Tag = pDt
                                  '设置仓库提取量
                                  For Each tRvdr As DataRow In pDt.Rows
                                      tItem.SubItems(tStrBiao & "_" & GetType(en_cklist).YanGetEnText_1(tRvdr("仓库"))).Text = tRvdr(0)
                                  Next
                                  pFr2.setCountNum()
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Function
    '选择确定的操作
    Function setAddPh(pDt As DataTable, pFr As frYanPhzl) As Boolean
        If pFr.m_countNum <= 0 Then
            MyBase.Tag = Nothing
            Return False
        End If
        pFr.setOwnerVa()
        MyBase.Tag = pDt
    End Function
End Class