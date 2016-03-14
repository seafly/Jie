Public Class Frtb_ylqa
    Public biao2 As String = ""
    Public m_lb As String = ""
    ''' <summary>
    ''' 流程标识
    ''' </summary>
    Public m_jcbNum As Integer = -1
    Public m_wldm As String = ""

    Private Sub Frtb_qa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        '''''''''''''''''''下面填写好默认项目
        't2.DataSource = GetType(en_qaJg).YanEnToTb.YanDtToStr("name").Split(",")
        t2.Items.Add("待定")
        If Labeltb.Text = "tb_i259b" Then
            t2.Items.Add("合格")
            t2.Items.Add("不合格")
            t2.Items.Add("冻结")

        Else
            t2.Items.Add("合格")
            t2.Items.Add("报废")
            t2.Items.Add("不合格")
            t2.Items.Add("冻结")
        End If
        qaytjy.DataSource = ("," & GetType(en_qaYtJy).YanEnToTb.YanDtToStr("name")).Split(",")

        Dim sql As String = "select * from " & Labeltb.Text & " where " & Labeltb.Text & "_id=" & Labelid.Text
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_qarq")) = False Then
            t1.Value = dt.Rows(0)(Labeltb.Text & "_qarq")
        End If
        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_qaspjg")) = False Then
            t2.Text = dt.Rows(0)(Labeltb.Text & "_qaspjg")
        End If
        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_qajgsm")) = False Then
            t3.Text = dt.Rows(0)(Labeltb.Text & "_qajgsm")
        End If

        qaytjy.Text = dt.YanDtValue2(Labeltb.Text & "_qaytjy")

        If IsDBNull(dt.Rows(0)(Labeltb.Text & "_fhxz")) = False Then
            tb_x825p_fhxz.Text = dt.Rows(0)(Labeltb.Text & "_fhxz")
        End If

        If qcbiao.Text = "tb_t676l" Or qcbiao.Text = "tb_bcQC" Then
            Label6.Visible = False
            tb_x825p_fhxz.Visible = False
        End If

        If m_lb = "油剂原料" Or m_lb = "发酵原料" Then
            dt = cl_YanMd.getQcLsjl(Labelid.Text)
        Else
            Dim bm, zd, ph As String 'QC表、字段、批号
            bm = qcbiao.Text : zd = qczd.Text : ph = qcph.Text
            dt = GF_CreateDataSource(G_cnnstr, "select * from " & bm & " where " & zd & " = '" & ph & "'")
        End If
        ''''''''''''下面显示该批号已经有QC的记录
        Dim strTb As String = IIf(m_jcbNum = -1, "tb_i259b", GetType(en_LcTableName).YanGetEnText(m_jcbNum))

        If Labeltb.Text = "tb_i259b" Then
            sql = "select *  from " & strTb & " where " & strTb & "_ID=" & Labelid.Text & ""
        Else
            Select Case strTb
                Case "tb_h195z" '成品油
                    sql = "select " & strTb & "_ID ," & strTb & "_num," & strTb & "_mingc," & strTb & "_jiagdm,tb_h195z_m408e," & strTb & "_jgrq," & strTb & "_bz," & strTb & "_qaspjg from " & strTb & " where " & strTb & "_ID=" & Labelid.Text & ""
                Case "tb_x832p"  '成品粉
                    sql = "select " & strTb & "_ID ," & strTb & "_num," & strTb & "_mingc," & strTb & "_jiagdm,tb_x832p_i232a," & strTb & "_jgrq," & strTb & "_bz," & strTb & "_qaspjg  from " & strTb & " where " & strTb & "_ID=" & Labelid.Text & ""
                Case Else
                    sql = "select " & strTb & "_ID ," & strTb & "_num," & strTb & "_mingc," & strTb & "_jiagdm," & strTb & "_qaspjg  from " & strTb & " where " & strTb & "_ID=" & Labelid.Text & ""
            End Select

        End If

        dt = _D.GF_CreateDataSource(sql)
        GS_useviewbydb2(ListView1, dt, 0, 150)

        '成品油或成品粉的时候启动QA用途建议
        qaytjy.Enabled = InStr("tb_h195z,tb_x832p", strTb) > 0

        If (strTb = "tb_p525h") Then
            sql = "select tb_p525h_id,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_d46v from tb_p525h  where  " & strTb & "_ID =" & Labelid.Text & ""
            dt = GF_CreateDataSource(G_cnnstr, sql)
        Else
            dt = cl_theCl.setQcshowViewForQA(strTb, Convert.ToInt32(Labelid.Text))
        End If
        GS_useviewbydb2(ListView2, dt, 0, 250)
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim n1 As String = GF_gettrqsj(t1.Text)
        Dim n2 As String = t2.Text
        Dim n3 As String = t3.Text.Trim
        If n2 = "报废" And qcbiao.Text = "tb_p525h" Then
            If TextBox1.Text = "" Then
                MsgBox("报废重量不可以为空！")
                Exit Sub
            Else
                Dim sql2 As String = "update tb_p525h set tb_p525h_dpbfl=" & TextBox1.Text & " where tb_p525h_num='" & qcph.Text & "'"
                GS_upztxx(G_cnnstr, sql2)
            End If
        End If
        If n2 = "不合格" Or n2 = "返工" Or n2 = "报废" Then
            If n3 = "" Then
                MsgBox(n2 & "请填写原因") : Exit Sub
            End If
        End If
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        ''''''''''''''''''''
        If GF_storelog2("添加QA：" & qcph.Text, "添加QA") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim dataDic As New Dictionary(Of String, String)
        dataDic(biao & "_qarq") = n1
        dataDic(biao & "_qaspjg") = n2
        dataDic(biao & "_qajgsm") = n3
        dataDic(biao & "_qaczrgh") = G_dlrgh
        dataDic(biao & "_fhxz") = tb_x825p_fhxz.Text
        If biao = "tb_h195z" OrElse biao = "tb_x832p" Then
            dataDic(biao & "_qaytjy") = IIf(t2.Text = en_qaJg.合格.ToString And qaytjy.Text = en_qaYtJy.返工.ToString, qaytjy.Text, "")
        End If
        _D.updateData(biao, dataDic, biao & "_ID=" & biaoid)
        ''''''''''更新库存表的QA
        If biao2 <> "" Then
            Dim sql1 As String = "select * from " & biao2 & " where " & biao2 & "_num='" & qcph.Text & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
            If dt.Rows.Count > 0 Then
                Dim dataDic2 As New Dictionary(Of String, String)
                dataDic2(biao2 & "_qarq") = n1
                dataDic2(biao2 & "_qaspjg") = n2
                dataDic2(biao2 & "_qajgsm") = n3
                dataDic2(biao2 & "_qaczrgh") = G_dlrgh
                dataDic2(biao2 & "_fhxz") = tb_x825p_fhxz.Text
                If biao = "tb_h195z" OrElse biao = "tb_x832p" Then
                    dataDic2(biao2 & "_qaytjy") = IIf(t2.Text = en_qaJg.合格.ToString And qaytjy.Text = en_qaYtJy.返工.ToString, qaytjy.Text, "")
                End If
                _D.updateData(biao2, dataDic2, biao2 & "_num='" & qcph.Text & "'")
            End If
        End If
        Select Case biao
            Case "tb_x832p"
                '更新进度表
                cl_theCl.saveBb(en_saveBb.成品粉生产进度2, biaoid)
        End Select

        Me.Close()
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttdel.Click
        If MsgBox("确定删除QA数据吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        Dim biao As String = Labeltb.Text
        Dim biaoid As String = Labelid.Text
        ''''''''''''''''''''
        If GF_storelog2("删除QA：" & qcph.Text, "删除QA") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim sql As String = "update " & biao & " set " & biao & "_qarq=null ," & biao & "_qaspjg='待定'," & biao & "_qajgsm=null"
        sql = sql & " where " & biao & "_id=" & biaoid
        GS_upztxx(G_cnnstr, sql)
        '‘’‘’‘’‘’‘’‘’‘
        If biao2 <> "" Then
            Dim sql1 As String = "select * from " & biao2 & " where " & biao2 & "_num='" & qcph.Text & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
            If dt.Rows.Count - 1 >= 0 Then
                Dim sql2 As String = "update " & biao2 & " set " & biao2 & "_qarq=null ," & biao2 & "_qaspjg='待定'," & biao2 & "_qajgsm=null"
                sql2 = sql2 & " where " & biao2 & "_num='" & qcph.Text & "'"
                GS_upztxx(G_cnnstr, sql)
            End If
            '‘’‘’‘’‘’‘’‘’‘’‘
        End If
        Me.Close()

    End Sub

    Private Sub t2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2.SelectedIndexChanged
        If t2.Text = "报废" And qcbiao.Text = "tb_p525h" Then
            Label4.Visible = True
            Label5.Visible = True
            TextBox1.Visible = True
        End If
    End Sub

End Class