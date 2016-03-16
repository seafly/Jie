Imports System.Linq
Public Class Frkc_ck
    Public m_wlDt As DataTable = Nothing
    Private m_ltCk As List(Of String) = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",").ToList   '记录库存名称
    Private m_hzDm As DataTable = Nothing
    Private m_dicKczl As New Dictionary(Of String, String)     '记录源重量

    Private Sub Frkc_tz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '用途数据源
        yt.DataSource = (GetType(en_kcyt).YanEnToTb.YanDtToStr("name") & ",").Replace _
            (en_kcyt.返工.ToString & ",", "").Replace(en_kcyt.生产.ToString & ",", "").YanRemovedh.Split(",")
        '页面赋值
        _D.YanDtSetFrCon(Me, m_wlDt)

        m_ltCk.Add("cjcl")
        '源库
        For Each s As String In m_ltCk
            Dim tContrKcSource As TextBox = CType(MyBase.YanFindControl("tb_wlphck_" & s), TextBox)
            Dim tContrKc As TextBox = CType(MyBase.YanFindControl(s), TextBox)
            '记录初始值
            m_dicKczl(s) = m_wlDt.YanDtValue2(tContrKcSource.Name)

            tContrKc.Enabled = (Convert.ToDecimal(tContrKcSource.Text) > 0)

            '添加数量的值改变事件
            AddHandler tContrKc.TextChanged,
                Sub(ser As TextBox, ex As EventArgs)
                    Dim countNum As Decimal = 0
                    For Each ss As String In m_ltCk
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl(ss).Text)
                    Next
                    出库重量.Text = countNum
                    ser.Text = IIf(ser.Text = "", 0, ser.Text)
                    tContrKcSource.Text = m_dicKczl(ser.Name) - ser.Text
                End Sub
            '双击最大或最小
            AddHandler tContrKc.DoubleClick,
               Sub(ser As TextBox, ex As EventArgs)
                   If ser.Text > 0 Then
                       ser.Text = 0
                   Else
                       Dim tZl As Decimal = m_dicKczl(ser.Name)
                       ser.Text = IIf(tZl > m_dicKczl(ser.Name), m_dicKczl(ser.Name), tZl)
                   End If
                   ser.Select(ser.Text.Length, 0)
               End Sub
        Next
    End Sub

    ''' <summary>
    ''' 更新原库存（只能减少）
    ''' </summary>
    Private Sub kcKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cjcl.KeyPress, kdlk.KeyPress, bfb.KeyPress, storagemslk.KeyPress, storagewzlk.KeyPress

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
                countNum += MyBase.YanFindControl(s).Text
            End If
            countNum += MyBase.YanFindControl(s).Text
        Next
        countNum += inNum
        Return

        e.Handled = True
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckControlNull(GroupBox2) = False Then
            Return
        End If
        If 出库重量.Text <= 0 Then
            MsgBox("出库重量不能为零！", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("确定要出库吗？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = vbNo Then
            Return
        End If

        Using mt As New _D.myTransaction
            Dim dic As Dictionary(Of String, String)
            '更新原数据数量
            dic = New Dictionary(Of String, String)
            For Each s As String In m_ltCk
                dic("tb_wlphck_" & s) = GroupBox2.YanFindControl("tb_wlphck_" & s).Text
            Next
            mt.update("tb_wlphck", dic, "tb_wlphck_ID='" & m_wlDt.YanDtValue2("tb_wlphck_ID") & "'")

            '写入使用记录（出库）
            dic = New Dictionary(Of String, String)()
            dic("tb_syjl_wpbs") = m_wlDt.YanDtValue2("tb_wlphck_wpbs")
            dic("tb_syjl_wpdm") = m_wlDt.YanDtValue2("tb_wp_dm")
            dic("tb_syjl_xz") = 0
            dic("tb_syjl_yb") = "tb_wlphck"
            dic("tb_syjl_ybs") = m_wlDt.YanDtValue2("tb_wlphck_ID")
            dic("tb_syjl_wlph") = m_wlDt.YanDtValue2("tb_wlphck_wlph")
            dic("tb_syjl_mbb") = ""
            dic("tb_syjl_czbs") = 0
            dic("tb_syjl_czlx") = yt.Text
            dic("tb_syjl_zl") = 出库重量.Text
            dic("tb_syjl_ctime") = tb_syjl_ctime.Text
            dic("tb_syjl_czrgh") = G_dlrgh
            For Each s As String In m_ltCk
                dic("tb_syjl_" & s) = GroupBox2.YanFindControl(s).Text
            Next
            mt.insert("tb_syjl", dic)

            mt.Commit()
        End Using
        Me.DialogResult = DialogResult.OK
    End Sub
End Class