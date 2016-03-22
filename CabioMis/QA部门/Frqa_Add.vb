Public Class Frqa_Add
    Public biao2 As String = ""
    Public m_lb As String = ""
    Public m_wlbs As String=""
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
        t2.Items.Add("合格")
        t2.Items.Add("不合格")

        'QA用途建议的下拉框
        qaytjy.DataSource = ("," & GetType(en_qaYtJy).YanEnToTb.YanDtToStr("name")).Split(",")

        Dim sql As String = "select * from tb_wlph as a left join tb_qa as b on a.tb_wlph_ID=b.tb_qa_wlbs where tb_wlph_id=" & m_wlbs
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If IsDBNull(dt.Rows(0)("tb_qa_ftime")) = False Then
            t1.Value = dt.Rows(0)("tb_qa_ftime")
        End If
        If IsDBNull(dt.Rows(0)("tb_qa_qaspjg")) = False Then
            t2.Text = dt.Rows(0)("tb_qa_qaspjg")
        End If
        If IsDBNull(dt.Rows(0)("tb_qa_qajgsm")) = False Then
            t3.Text = dt.Rows(0)("tb_qa_qajgsm")
        End If
        qaytjy.Text = dt.YanDtValue2("tb_qa_qaytjy")

        dt = _D.GF_CreateDataSource(sql)
        GS_useviewbydb2(ListView1, dt, 0, 150)

        dt = cl_theCl.setQcshowViewForQA("tb_wlph", m_wlbs)
        GS_useviewbydb2(ListView2, dt, 0, 250)
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim n1 As String = GF_gettrqsj(t1.Text)
        Dim n2 As String = t2.Text
        Dim n3 As String = t3.Text.Trim
        If n2 = "" Then
            n2 = "待定"
        End If
        If n2 = "不合格" And n3 = "" Then
            MsgBox(n2 & "请填写原因")
            Exit Sub
        End If
        If GF_storelog2("添加QA：" & m_wlbs & "，操作人：" & G_dlrgh, "添加QA") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        Dim dataDic As New Dictionary(Of String, String)
        dataDic("tb_qa_ftime") = n1
        dataDic("tb_qa_qaspjg") = n2
        dataDic("tb_qa_qajgsm") = n3
        dataDic("tb_qa_qaytjy") = qaytjy.Text
        dataDic("tb_qa_czr") = G_dlrgh
        dataDic("tb_qa_wlbs") = m_wlbs

        Dim sql As String = "select tb_qa_ID from tb_qa where tb_qa_wlbs=" & m_wlbs
        Dim dt As DataTable = sql.YanGetDb
        If dt.Rows.Count > 0 Then
            _D.updateData("tb_qa", dataDic, "tb_qa_ID=" & dt.YanDtValue2())
        Else
            _D.insertData("tb_qa", dataDic)
        End If
        me.DialogResult=DialogResult.OK
    End Sub

    Private Sub Buttdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttdel.Click
        If MsgBox("确定删除QA数据吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        Me.Close()
    End Sub
End Class
