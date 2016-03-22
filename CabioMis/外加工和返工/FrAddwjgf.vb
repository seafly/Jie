''' <summary>
''' 添加外加工粉
''' </summary>
Public Class FrAddwjgf
    Dim m_dt As DataTable
    Dim m_wjgph As String
    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Icon = G_icon
        Me.BackgroundImage = G_backimg
        formInit()
        m_wjgph = _S.YanForDa_2(DateTime.Now).Replace("-", "").Replace(":", "").Replace(" ", "")
    End Sub

    '表单初始化
    Private Sub formInit(Optional pStrColnames As String = "")
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        '产品类型
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 1, tb_x832p_cplb)
        '产品代码
        AddHandler tb_x832p_cplb.SelectedIndexChanged,
        Function(sender As System.Object, e As System.EventArgs) As Boolean
            Dim dtTm As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "'")
            GS_bcfbd(dtTm, 2, tb_x832p_mingc)
        End Function
        '加工代码
        AddHandler tb_x832p_mingc.SelectedIndexChanged,
        Function(sender As System.Object, e As System.EventArgs) As Boolean
            Dim dtTm As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & tb_x832p_cplb.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
            GS_bcfbd(dtTm, 3, tb_x832p_jiagdm)
        End Function

        '表单赋值
        tb_x832p_cplb.SelectedIndex = 2
        tb_x832p_jiagdm.Items.Clear()
        tb_x832p_jiagdm.Text = ""

        For Each tCon As Control In Panel1.Controls
            If InStr(tCon.GetType.Name, "TextBox") > 0 And InStr(pStrColnames & ",", tCon.Name & ",") <= 0 Then
                tCon.Text = ""
            End If
        Next
    End Sub


    Private Sub Frfgyf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon
        m_dt = _D.GF_CreateDataSource("select tb_x832p_id,tb_x832p_num,tb_x832p_i232a,tb_x832p_bz," &
                                      "tb_x832p_cplb,tb_x832p_jgrq,tb_x832p_wjgfdhrq,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_wjgyph,tb_x832p_wjgypht,tb_x832p_wjgfhpc " &
                                      "from tb_x832p where 1=2")
        m_dt.TableName = "tb_x832p"
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("删除")
        AddHandler menu1.Items(1).Click,
        Sub()
            If show1.SelectedRows(0).Cells("rowBs").Value.ToString.YanNullToEmpty = "" Then
                Return
            End If
            For Each tRow As DataRow In m_dt.Rows
                If tRow("rowBs") = show1.SelectedRows(0).Cells("rowBs").Value Then
                    m_dt.Rows.Remove(tRow)
                    Return
                End If
            Next
        End Sub
        GS_DataGridViewbyDb(show1, m_dt, True, True, menu1)
        show1.YanHideDataGriwHead("tb_x832p_id")
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '' 判断是否有权限
        'If GF_storelog1("添加成品粉") = False Then
        '    Exit Sub
        'End If
        ' ''''''''''''''''''''''''''''''''''''''''''来自零头、零头重量，零头可以不填写
        'If GF_YZSJ(Panel1, "tb_x832p_bz") = False Then '验证控件
        '    MsgBox("请将数据填写完整") : Exit Sub
        'End If
        ' '''''''''''''''
        ' '''''''''''''''''''''''''''''''''''''''
        'If GF_cxph("tb_x832p_num", tb_x832p_num.Text.Trim) = True Then
        '    MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
        'End If
        ' '''''''''''''''''''''
        'tb_x832p_bz.Text = "（外加工）" & tb_x832p_bz.Text
        'Dim jj As String = GF_addsj(Labeltb.Text, Me)
        'If jj = "" Then
        '    MsgBox("请检查输入项目及数据") : Exit Sub
        'End If
        'GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        'Dim sql As String = "update tb_fgyf set tb_fgyf_num2='" & tb_x832p_num.Text.Trim & "' where tb_fgyf_num='" & ComboBox1.Text & "'"
        'GS_upztxx(G_cnnstr, sql) '更新外加工油的粉剂批号，便于追踪
        'GS_storelog3("添加外加工成品粉：" & tb_x832p_num.Text.Trim, "添加成品粉") '储存到日志
        'MsgBox("操作成功")
        'Me.Close()
    End Sub

    Private Sub SSSQD_Click_1(sender As Object, e As EventArgs) Handles SSSQD.Click
        If GF_YZSJ(Panel1, "tb_x832p_bz,rowBs,tb_x832p_id") = False Then '验证控件
            Exit Sub
        End If
        If GF_cxph("tb_x832p_num", tb_x832p_num.Text.Trim) = True Then
            MsgBox("数据库内已经存在该批号，请重新输入！")
            Exit Sub
        End If
        tb_x832p_bz.Text = "（外加工）" & tb_x832p_bz.Text
        _D.YanFrVaAddDt(Me, m_dt)
        show1.YanHideDataGriwHead("rowBs")
        formInit("tb_x832p_wjgyph,tb_x832p_wjgypht")
    End Sub

    Private Sub tb_x832p_wjgyph_DoubleClick(sender As Object, e As EventArgs) Handles tb_x832p_wjgyph.DoubleClick
        If m_dt.Rows.Count > 0 Then
            Return
        End If
        '显示批号提取重量的结果
        Dim dt As DataTable = _D.GF_CreateDataSource("select 0 as 使用重量,tb_fgyf_num,tb_fgyf_syzl,tb_fgyf_rq,'KG' as 单位 from tb_fgyf " &
                                              "where tb_fgyf_syzl>0")

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "外加工油"
        objClpam.phName = CType(sender, Control).Name
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub

    Private Sub show1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles show1.CellClick
        If e.RowIndex < 0 Then
            Return
        End If
        _D.YanDtSetFrCon(Panel1, m_dt, show1.SelectedRows(0).Cells("rowBs").Value)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        formInit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If m_dt.Rows.Count = 0 Then
            MsgBox("没有数据提交！", MsgBoxStyle.Exclamation)
            Return
        End If
        '返回批次不能重复
        Dim iNum As Integer = 0
        While True
            If _D.GF_CreateDataSource("select * from tb_x832p where tb_x832p_wjgfhpc='" & m_wjgph & "'").Rows.Count > 0 Then
                iNum += 1
                m_wjgph = _S.YanForDa_2(DateTime.Now).Replace("-", "").Replace(":", "").Replace(" ", "") & "_" & iNum
            End If
            For Each tDr As DataRow In m_dt.Rows
                tDr("tb_x832p_wjgfhpc") = m_wjgph
            Next
            Exit While
        End While

        '成品粉批号不能重复
        For Each tRow As DataRow In m_dt.Rows
            If GF_cxph("tb_x832p_num", tRow("tb_x832p_num")) = True Then
                MsgBox("数据库内已有批号（" & tRow("tb_x832p_num") & "），请重新输入！")
                Exit Sub
            End If
        Next
        '批号跟重量的键值集合
        Dim dataDic As New Dictionary(Of String, Integer)
        '使用的外加工油批号
        'Dim tArrWph As String() = m_dt.YanDtToStr("tb_x832p_wjgyph").Split(",")
        Dim tArrWph As String() = tb_x832p_wjgyph.Text.Split(",")
        '使用的外加工油重量
        'Dim tArrWzl As String() = m_dt.YanDtToStr("tb_x832p_wjgypht").Split(",")
        Dim tArrWzl As String() = tb_x832p_wjgypht.Text.Split(",")
        '批号去重
        For i As Integer = 0 To tArrWph.Length - 1
            If dataDic.ContainsKey(tArrWph(i)) Then
                '如果有相同批号，那么重量相加
                dataDic(tArrWph(i)) += tArrWzl(i)
            Else
                dataDic.Add(tArrWph(i), tArrWzl(i))
            End If
        Next
        '判断重量
        For Each kvp As KeyValuePair(Of String, Integer) In dataDic
            Dim sql As String = "select tb_fgyf_syzl from tb_fgyf where tb_fgyf_num='" & kvp.Key & "'"
            Dim iSyzl As Integer = _S.YanFormatNum(sql.YanGetDb.YanDtToStr)
            If kvp.Value > iSyzl Then
                MsgBox("批号（" & kvp.Key & "）的重量（" & kvp.Value & "）大于数据库中的重量（" & iSyzl & "），请重新输入！")
                Exit Sub
            End If
        Next
        '更新重量
        For Each kvp As KeyValuePair(Of String, Integer) In dataDic
            Dim sql As String = "update tb_fgyf set tb_fgyf_syzl=tb_fgyf_syzl-" & kvp.Value & " where tb_fgyf_num='" & kvp.Key & "'"
            sql.YanDbExe()
        Next
        '提交DATATABLE
        Dim jj As String = _D.YanDtUpdateSv(m_dt)
        tArrWph = tArrWph.YanArrQc()
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
        For Each s As String In tArrWph
            '更新外加工油的粉剂批号()
            Dim sql As String = "select tb_x832p_num from tb_x832p where tb_x832p_wjgyph+',' like '%" & s & ",%'"
            Dim tStrFph As String = sql.YanGetDb.YanDtToStr
            sql = "update tb_fgyf set tb_fgyf_num2='" & tStrFph & "' where tb_fgyf_num='" & s & "'"
            sql.YanDbExe()
            '储存到日志
            GS_storelog3("添加外加工成品粉：" & tStrFph, "添加成品粉")
        Next
        MsgBox("操作成功")
        Me.Close()
    End Sub
End Class