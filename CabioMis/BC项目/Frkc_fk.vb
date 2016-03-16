Imports System.Linq
Public Class Frkc_fk
    Public m_wlDt As DataTable = Nothing
    Private m_ltCk As List(Of String) = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",").ToList   '记录库存名称
    Private m_hzDm As DataTable = Nothing
    Private m_dicKczl As New Dictionary(Of String, String)     '记录源重量

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

        '页面赋值
        _D.YanDtSetFrCon(Me, m_wlDt)
        '复制同字段的值
        For Each cor As Control In GroupBox2.Controls
            Dim tContr As Control = GroupBox1.YanFindControl(cor.Name & "2")
            If tContr IsNot Nothing Then
                tContr.Text = cor.Text
            End If
        Next

        m_ltCk.Add("cjcl")
        '源库
        For Each s As String In m_ltCk
            Dim tContrKc As TextBox = CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox)
            tContrKc.Enabled = (Convert.ToDecimal(tContrKc.Text) > 0)
            m_dicKczl(tContrKc.Name) = m_wlDt.YanDtValue2(tContrKc.Name)
            '添加数量的值改变事件
            AddHandler tContrKc.TextChanged,
                Sub(ser As TextBox, ex As EventArgs)
                    Dim countNum As Decimal = 0
                    For Each tS As String In m_ltCk
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl("tb_wlphck_" & tS).Text)
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl(tS).Text)
                    Next
                    syzl.Text = 仓库存量.Text - countNum
                    ser.Text = IIf(ser.Text = "", 0, ser.Text)
                End Sub
            '双击最大或最小
            AddHandler tContrKc.DoubleClick,
               Sub(ser As TextBox, ex As EventArgs)
                   If ser.Text > 0 Then
                       ser.Text = 0
                   Else
                       Dim tZl As Decimal = Convert.ToDecimal(ser.Text) + Convert.ToDecimal(syzl.Text)
                       ser.Text = IIf(tZl > m_dicKczl(ser.Name), m_dicKczl(ser.Name), tZl)
                   End If
                   ser.Select(ser.Text.Length, 0)
               End Sub
        Next
        '分库
        For Each s As String In m_ltCk
            Dim tContrKc As TextBox = CType(MyBase.YanFindControl(s), TextBox)
            '分库数量的值改变事件
            AddHandler tContrKc.TextChanged,
                Sub(ser As TextBox, ex As EventArgs)
                    Dim countNum As Decimal = 0
                    For Each tS As String In m_ltCk
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl("tb_wlphck_" & tS).Text)
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl(tS).Text)
                    Next
                    syzl.Text = 仓库存量.Text - countNum
                    ser.Text = IIf(ser.Text = "", 0, ser.Text)
                End Sub
            '双击最大或最小
            AddHandler tContrKc.DoubleClick,
               Sub(ser As TextBox, ex As EventArgs)
                   ser.Text = IIf(ser.Text > 0, 0, Convert.ToDecimal(ser.Text) + Convert.ToDecimal(syzl.Text))
                   ser.Select(ser.Text.Length, 0)
               End Sub
        Next
    End Sub

    ''' <summary>
    ''' 更新原库存（只能减少）
    ''' </summary>
    Private Sub kcKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_wlphck_storagewzlk.KeyPress,
    tb_wlphck_cjcl.KeyPress, tb_wlphck_kdlk.KeyPress, tb_wlphck_bfb.KeyPress, tb_wlphck_storagemslk.KeyPress
        Dim arrI As Integer() = New Integer() {22, 3, 8, 46}
        '排除例外键
        For Each iNum As Integer In arrI
            If iNum = Asc(e.KeyChar) Then
                Return
            End If
        Next
        If IsNumeric(e.KeyChar) = False Then
            e.Handled = True
            Return
        End If
        Dim t As TextBox = CType(sender, TextBox)
        '如果有选择字符，那么就拼接字符串
        Dim strIn As String = Strings.Left(t.Text, t.SelectionStart) & e.KeyChar &
            t.Text.Substring(t.SelectionStart + t.SelectionLength, t.Text.Length - t.SelectionStart - t.SelectionLength)
        Dim inNum As Decimal = Convert.ToDecimal(strIn)
        '输入的数字不能大于自己的库存数
        If inNum > m_dicKczl(t.Name) Then
            e.Handled = True
            Return
        End If

        Dim countNum As Decimal = 0
        For Each s As String In m_ltCk
            If t.Name <> "tb_wlphck_" & s Then
                countNum += MyBase.YanFindControl("tb_wlphck_" & s).Text
            End If
            countNum += MyBase.YanFindControl(s).Text
        Next
        countNum += inNum
        If countNum <= 仓库存量.Text Then
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub kcKeyPress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles storagewzlk.KeyPress,
        storagemslk.KeyPress, kdlk.KeyPress, cjcl.KeyPress, bfb.KeyPress
        Dim arrI As Integer() = New Integer() {22, 3, 8, 46}
        '排除例外键
        For Each iNum As Integer In arrI
            If iNum = Asc(e.KeyChar) Then
                Return
            End If
        Next
        If IsNumeric(e.KeyChar) = False Then
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
            If t.Name <> s Then
                countNum += MyBase.YanFindControl(s).Text
            End If
            countNum += MyBase.YanFindControl("tb_wlphck_" & s).Text
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
        If tb_wlphck_cplb.Text = m_wlDt.YanDtValue2("tb_wlphck_cplb") And tb_wlphck_mingc.Text = m_wlDt.YanDtValue2("tb_wlphck_mingc") And
            tb_wlphck_jiagdm.Text = m_wlDt.YanDtValue2("tb_wlphck_jiagdm") Then
            MsgBox("库存信息没有进行更改，无法分库！")
            Return
        End If

        Using mt As New _D.myTransaction
            tb_wlphck_ID.Text = 0
            Dim tNewBs As String = ""
            Dim dic As Dictionary(Of String, String)

            Dim sql As String = "select * from tb_wlphck where tb_wlphck_wlbs='" & tb_wlphck_wlbs.Text & "' and tb_wlphck_cplb='" & tb_wlphck_cplb.Text & "' " &
                " and tb_wlphck_mingc='" & tb_wlphck_mingc.Text & "' and tb_wlphck_jiagdm='" & tb_wlphck_jiagdm.Text &
                "' and tb_wlphck_ID<>" & m_wlDt.YanDtValue2("tb_wlphck_ID")
            Dim dt As DataTable = sql.YanGetDb
            If dt.Rows.Count > 0 Then
                If MsgBox("已经存在相同的库存，是否将重量加入该库存！", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = vbNo Then
                    Return
                End If
                dt = dt.Rows(0).YanDrToDb
                tb_wlphck_ID.Text = dt.YanDtValue2("tb_wlphck_ID")
                tNewBs = dt.YanDtValue2("tb_wlphck_ID")

                '如果是更新，那么数量为原数量加输入数量，只更新数量
                dic = New Dictionary(Of String, String)
                For Each s As String In m_ltCk
                    dic("tb_wlphck_" & s) = Convert.ToDecimal(dt.YanDtValue2("tb_wlphck_" & s)) + GroupBox2.YanFindControl(s).Text
                Next
                mt.update("tb_wlphck",dic,"tb_wlphck_ID=" & tNewBs)
            Else
                dt.TableName = "tb_wlphck"
                tNewBs = _D.YanFrVaAddDt(Me, dt, True, mt, 1)
                '更新写入的库存信息
                dic = New Dictionary(Of String, String)
                For Each s As String In m_ltCk
                    dic("tb_wlphck_" & s) = GroupBox2.YanFindControl(s).Text
                Next
                mt.update("tb_wlphck", dic, "tb_wlphck_ID='" & tNewBs & "'")
            End If
            '更新原数据数量
            dic = New Dictionary(Of String, String)
            For Each s As String In m_ltCk
                'dic("tb_wlphck_" & s) = Convert.ToDecimal(m_dicKczl("tb_wlphck_" & s)) - GroupBox2.YanFindControl("tb_wlphck_" & s).Text
                dic("tb_wlphck_" & s) = GroupBox2.YanFindControl("tb_wlphck_" & s).Text
            Next
            mt.update("tb_wlphck", dic, "tb_wlphck_ID='" & m_wlDt.YanDtValue2("tb_wlphck_ID") & "'")

            '写入使用记录（出库）
            dic = New Dictionary(Of String, String)()
            dic("tb_syjl_wpbs") = m_wlDt.Rows(0)("tb_wlphck_wpbs")
            dic("tb_syjl_wpdm") = m_wlDt.Rows(0)("tb_wp_dm")
            dic("tb_syjl_xz") = 0
            dic("tb_syjl_yb") = "tb_wlphck"
            dic("tb_syjl_ybs") = m_wlDt.Rows(0)("tb_wlphck_ID")
            dic("tb_syjl_wlph") = m_wlDt.Rows(0)("tb_wlphck_wlph")
            dic("tb_syjl_mbb") = "tb_wlphck"
            dic("tb_syjl_czbs") = tNewBs
            dic("tb_syjl_czlx") = "分库"
            dic("tb_syjl_ctime") = tb_syjl_ctime.Text
            dic("tb_syjl_czrgh") = G_dlrgh
            Dim rZl As Decimal = 0
            For Each s As String In m_ltCk
                dic("tb_syjl_" & s) = Convert.ToDecimal(m_dicKczl("tb_wlphck_" & s)) - GroupBox2.YanFindControl("tb_wlphck_" & s).Text
                rZl += Convert.ToDecimal(m_dicKczl("tb_wlphck_" & s)) - GroupBox2.YanFindControl("tb_wlphck_" & s).Text
            Next
            dic("tb_syjl_zl") = System.Math.Abs(rZl)
            mt.insert("tb_syjl", dic)

            '写入使用记录（入库）
            dic = New Dictionary(Of String, String)()
            dic("tb_syjl_wpbs") = m_wlDt.Rows(0)("tb_wlphck_wpbs")
            dic("tb_syjl_wpdm") = m_wlDt.Rows(0)("tb_wp_dm")
            dic("tb_syjl_xz") = 1
            dic("tb_syjl_yb") = "tb_wlphck"
            dic("tb_syjl_ybs") = m_wlDt.Rows(0)("tb_wlphck_ID")
            dic("tb_syjl_wlph") = m_wlDt.Rows(0)("tb_wlphck_wlph")
            dic("tb_syjl_mbb") = "tb_wlphck"
            dic("tb_syjl_czbs") = tNewBs
            dic("tb_syjl_czlx") = "分库"
            dic("tb_syjl_ctime") = tb_syjl_ctime.Text
            dic("tb_syjl_czrgh") = G_dlrgh
            rZl = 0
            For Each s As String In m_ltCk
                dic("tb_syjl_" & s) = GroupBox2.YanFindControl(s).Text
                rZl += Convert.ToDecimal(m_dicKczl("tb_wlphck_" & s)) - GroupBox2.YanFindControl("tb_wlphck_" & s).Text
            Next
            dic("tb_syjl_zl") = System.Math.Abs(rZl)
            mt.insert("tb_syjl", dic)

            mt.Commit()
        End Using


        ''写入使用记录(出库)
        'Dim dic As Dictionary(Of String, String)
        'dic("tb_syjl_wpbs") = m_wlDt.Rows(0)("tb_wlphck_wpbs")
        'dic("tb_syjl_wpdm") = m_wlDt.Rows(0)("tb_wp_dm")
        'dic("tb_syjl_xz") = 0
        'dic("tb_syjl_yb") = "tb_wlphck"
        'dic("tb_syjl_ybs") = m_wlDt.Rows(0)("tb_wlphck_ID")
        'dic("tb_syjl_wlph") = m_wlDt.Rows(0)("tb_wlphck_wlph")
        ''dic("tb_syjl_zl") = System.Math.Abs(rZl)
        'dic("tb_syjl_czlx") = "分库"
        'dic("tb_syjl_mbb") = "tb_wlphck"
        'dic("tb_syjl_czbs") = m_wlDt.Rows(0)("tb_wlphck_ID")
        'For Each k As String In dicZl.Keys
        '    dic("tb_syjl_" & k) = IIf(dicZl(k) > 0, System.Math.Abs(dicZl(k)), 0)
        'Next
        '_D.insertData("tb_syjl", dic)

        ''保存基本信息
        '_D.YanFrVaAddDt(GroupBox1, m_wlDt, True)


        'Dim dic As Dictionary(Of String, String)
        ''写入使用记录(入库)
        'dic = New Dictionary(Of String, String)
        'dic("tb_syjl_wpbs") = m_wlDt.Rows(0)("tb_wlphck_wpbs")
        'dic("tb_syjl_wpdm") = m_wlDt.Rows(0)("tb_wp_dm")
        'dic("tb_syjl_xz") = 1
        'dic("tb_syjl_yb") = "tb_wlphck"
        'dic("tb_syjl_ybs") = m_wlDt.Rows(0)("tb_wlphck_ID")
        'dic("tb_syjl_wlph") = m_wlDt.Rows(0)("tb_wlphck_wlph")
        ''dic("tb_syjl_zl") = System.Math.Abs(rZl)
        'dic("tb_syjl_czlx") = "转库"
        'dic("tb_syjl_mbb") = "tb_wlphck"
        'dic("tb_syjl_czbs") = m_wlDt.Rows(0)("tb_wlphck_ID")
        'For Each k As String In dicZl.Keys
        '    dic("tb_syjl_" & k) = IIf(dicZl(k) < 0, System.Math.Abs(dicZl(k)), 0)
        'Next
        '_D.insertData("tb_syjl", dic)

        'If _D.isRowNull("tb_wlphck", "tb_wlphck_wlbs='" & tb_wlphck_wlbs.Text & "' and tb_wlphck_cplb='" & tb_wlphck_cplb.Text & "' " &
        '                " and tb_wlphck_mingc='" & tb_wlphck_mingc.Text & "' and tb_wlphck_jiagdm='" & tb_wlphck_jiagdm.Text & "'") Then
        '    MsgBox("已经存在相同的库存，是否将重量加入该库存！", MsgBoxStyle.Exclamation)
        '    Return
        'End If
        ''更新库存表
        'dic = New Dictionary(Of String, String)
        'For Each s As String In m_ltCk
        '    dic("tb_wlphck_" & s) = CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox).Text
        'Next
        '_D.updateData("tb_wlphck", dic, "tb_wlphck_ID=" & m_wlDt.Rows(0)("tb_wlphck_ID"))
        Me.DialogResult = DialogResult.OK
    End Sub
End Class