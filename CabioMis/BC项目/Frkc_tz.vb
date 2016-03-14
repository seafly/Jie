Imports System.Linq
''' <summary>
''' 库存调整
''' </summary>
Public Class Frkc_tz
    Public m_wlDt As DataTable = Nothing
    Private m_ltCk As List(Of String) = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",").ToList
    Private m_hzDm As DataTable =Nothing

    Private Sub Frkc_tz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '用途数据源
        tb_wlphck_yt.DataSource = GetType(en_kcyt).YanEnToTb.YanDtToStr("name").Split(",")
        '产品代码，加工代码的联动
        Dim strCplb As String = "BC成品"
        m_hzDm = G_SYCPDMB.Select("tb_cpdmhz_cpxz='" & strCplb & "'").YanArrDrToDb()
        If m_hzDm.Rows.Count > 0 Then
            AddHandler tb_wlphck_cplb.SelectedIndexChanged,
                Sub(send As ComboBox, ev As EventArgs)
                tb_wlphck_mingc.DataSource =
                    m_hzDm.Select("tb_cpdmhz_cpxz='" & strCplb & "' and tb_cpdmhz_cplx='" & send.Text & "'").YanArrDrToDb.YanDtToStr("tb_cpdmhz_cpdm").Split(",").YanArrQc
            End Sub
            AddHandler tb_wlphck_mingc.SelectedIndexChanged,
                Sub(send As ComboBox, ev As EventArgs)
                tb_wlphck_jiagdm.DataSource =
                    m_hzDm.Select("tb_cpdmhz_cpxz='" & strCplb & "' and tb_cpdmhz_cpdm='" & send.Text & "'").YanArrDrToDb.YanDtToStr("tb_cpdmhz_jgdm").Split(",").YanArrQc
            End Sub
            tb_wlphck_cplb.DataSource = m_hzDm.YanDtToStr("tb_cpdmhz_cplx").Split(",").YanArrQc.YanArrAdd("", 0)
        End If

        _D.YanDtSetFrCon(Me, m_wlDt)

        m_ltCk.Add("cjcl")
        For Each s As String In m_ltCk
            AddHandler CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox).TextChanged,
                Sub(ser As Object, ex As EventArgs)
                    Dim countNum As Decimal = 0
                    For Each tS As String In m_ltCk
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl("tb_wlphck_" & tS).Text)
                    Next
                    syzl.Text = 仓库存量.Text - countNum
                    ser.text = IIf(ser.text = "", 0, ser.text)
                End Sub
        Next
        For Each s As String In m_ltCk
            AddHandler CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox).DoubleClick,
                Sub(ser As Object, ex As EventArgs)
                    'ser.text = IIf(syzl.Text > 0, Convert.ToDecimal(ser.text) + Convert.ToDecimal(syzl.Text), 0)
                    ser.text = IIf(ser.Text > 0, 0, Convert.ToDecimal(ser.text) + Convert.ToDecimal(syzl.Text))
                    ser.select(ser.text.length, 0)
                End Sub
        Next
    End Sub

    Private Sub kcKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_wlphck_storagewzlk.KeyPress,
        tb_wlphck_cjcl.KeyPress, tb_wlphck_kdlk.KeyPress, tb_wlphck_bfb.KeyPress, tb_wlphck_storagemslk.KeyPress
        Dim arrI As Integer() = New Integer() {22, 3, 8, 46}
        '排除例外键
        For Each iNum As Integer In arrI
            If iNum = Asc(e.KeyChar) Then
                Return
            End If
        Next
        If IsNumeric(e.KeyChar)=False Then
            e.Handled = True
            Return
        End If
        Dim t As TextBox = CType(sender, TextBox)
        '如果有选择字符，那么就拼接字符串
        Dim strIn As String = Strings.Left(t.Text, t.SelectionStart) & e.KeyChar &
            t.Text.Substring(t.SelectionStart + t.SelectionLength, t.Text.Length - t.SelectionStart - t.SelectionLength)
        Dim inNum As Decimal = Convert.ToDecimal(strIn)
        Dim countNum As Decimal = 0
        For Each s As String In m_ltCk
            If t.Name <> "tb_wlphck_" & s Then
                countNum += MyBase.YanFindControl("tb_wlphck_" & s).Text
            End If
        Next
        countNum += inNum
        If countNum <= 仓库存量.Text Then
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Convert.ToDecimal(syzl.Text) > 0 Then
            MsgBox("还有剩余重量没有分配！")
            Return
        End If
        Dim dicZl As New Dictionary(Of String, Decimal)
        '计算重量
        Dim rZl As Decimal = 0   '入库总重
        Dim cZl As Decimal = 0   '出库总重
        For Each s As String In m_ltCk
            '变动重量=原重量-新重量，那么负数就是入库数量
            Dim tZl As Decimal = m_wlDt.Rows(0)("tb_wlphck_" & s) - CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox).Text
            dicZl(s) = tZl
            If tZl < 0 Then
                rZl += tZl
            End If
            If tZl > 0 Then
                cZl += cZl
            End If
        Next
        '保存基本信息
        _D.YanFrVaAddDt(GroupBox1, m_wlDt, True)
        If rZl = 0 Then
            '重量没有发声变化，直接关闭
            Me.DialogResult = DialogResult.OK
            Return
        End If
        Using yMt As New _D.myTransaction
            Dim dic As Dictionary(Of String, String)
            '写入使用记录(入库)
            dic = New Dictionary(Of String, String)
            dic("tb_syjl_wpbs") = m_wlDt.Rows(0)("tb_wlphck_wpbs")
            dic("tb_syjl_wpdm") = m_wlDt.Rows(0)("tb_wp_dm")
            dic("tb_syjl_xz") = 1
            dic("tb_syjl_yb") = "tb_wlphck"
            dic("tb_syjl_ybs") = m_wlDt.Rows(0)("tb_wlphck_ID")
            dic("tb_syjl_wlph") = m_wlDt.Rows(0)("tb_wlphck_wlph")
            dic("tb_syjl_zl") = System.Math.Abs(rZl)
            dic("tb_syjl_czlx") = "转库"
            dic("tb_syjl_mbb") = "tb_wlphck"
            dic("tb_syjl_czbs") = m_wlDt.Rows(0)("tb_wlphck_ID")
            For Each k As String In dicZl.Keys
                dic("tb_syjl_" & k) = IIf(dicZl(k) < 0, System.Math.Abs(dicZl(k)), 0)
            Next
            yMt.insert("tb_syjl", dic)
            '写入使用记录(出库)
            dic = New Dictionary(Of String, String)
            dic("tb_syjl_wpbs") = m_wlDt.Rows(0)("tb_wlphck_wpbs")
            dic("tb_syjl_wpdm") = m_wlDt.Rows(0)("tb_wp_dm")
            dic("tb_syjl_xz") = 0
            dic("tb_syjl_yb") = "tb_wlphck"
            dic("tb_syjl_ybs") = m_wlDt.Rows(0)("tb_wlphck_ID")
            dic("tb_syjl_wlph") = m_wlDt.Rows(0)("tb_wlphck_wlph")
            dic("tb_syjl_zl") = System.Math.Abs(rZl)
            dic("tb_syjl_czlx") = "转库"
            dic("tb_syjl_mbb") = "tb_wlphck"
            dic("tb_syjl_czbs") = m_wlDt.Rows(0)("tb_wlphck_ID")
            For Each k As String In dicZl.Keys
                dic("tb_syjl_" & k) = IIf(dicZl(k) > 0, System.Math.Abs(dicZl(k)), 0)
            Next
            yMt.insert("tb_syjl", dic)

            '更新库存表
            dic = New Dictionary(Of String, String)
            For Each s As String In m_ltCk
                dic("tb_wlphck_" & s) = CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox).Text
            Next
            yMt.update("tb_wlphck", dic, "tb_wlphck_ID=" & m_wlDt.Rows(0)("tb_wlphck_ID"))
            yMt.Commit()
        End Using
        Me.DialogResult = DialogResult.OK
    End Sub
End Class