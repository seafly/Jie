Imports System.Linq
''' <summary>
''' 转库到湖北
''' </summary>
Public Class Frzk
    Private m_ltCk As List(Of String) = GetType(en_cklist).YanEnToTb.YanDtToStr("text").Split(",").ToList
    Private m_frOpen As frchuhuo = CType(Application.OpenForms.Item("frchuhuo"), frchuhuo)
    Private m_hzDm As DataTable = Nothing   '代码汇总DATA
    Private m_dt As DataTable = Nothing
    Public m_strTb As String = ""
    Public m_strCplb As String = ""
    public m_strPh As String=""

    Sub New(pCplb As String)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        '产品代码，加工代码的联动
        m_strCplb = pCplb
        m_hzDm = G_SYCPDMB.Select("tb_cpdmhz_cpxz='" & m_strCplb & "'").YanArrDrToDb()
        If m_hzDm.Rows.Count > 0 Then
            AddHandler cplb.SelectedIndexChanged,
                Sub(send As ComboBox, ev As EventArgs)
                    mingc.DataSource =
                        m_hzDm.Select("tb_cpdmhz_cpxz='" & m_strCplb & "' and tb_cpdmhz_cplx='" & send.Text & "'").YanArrDrToDb.YanDtToStr("tb_cpdmhz_cpdm").Split(",").YanArrQc
                End Sub
            AddHandler mingc.TextChanged,
                Sub(send As ComboBox, ev As EventArgs)
                    jiagdm.DataSource =
                        m_hzDm.Select("tb_cpdmhz_cpxz='" & m_strCplb & "' and tb_cpdmhz_cpdm='" & send.Text & "'").YanArrDrToDb.YanDtToStr("tb_cpdmhz_jgdm").Split(",").YanArrQc
                End Sub
            cplb.DataSource = m_hzDm.YanDtToStr("tb_cpdmhz_cplx").Split(",").YanArrQc.YanArrAdd("", 0)
        End If

    End Sub

    Private Sub Frzk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_dt = New DataTable
        m_dt.Columns.Add(m_strTb & "_kczl")
        m_dt.Columns.Add(m_strTb & "_cplb")
        m_dt.Columns.Add(m_strTb & "_mingc")
        m_dt.Columns.Add(m_strTb & "_jiagdm")
        For Each s As String In m_ltCk
            m_dt.Columns.Add(m_strTb & "_" & s)
        Next
        Dim menu As New ContextMenuStrip
        menu.Items.Add("删除")
        AddHandler menu.Items(0).Click, Sub()
                                            zkzl.Tag += CDbl(YanDaTaGridView1.SelectedRows(0).Cells(m_strTb & "_kczl").Value)
                                            zkzl.Text += CDbl(YanDaTaGridView1.SelectedRows(0).Cells(m_strTb & "_kczl").Value)
                                            m_dt.Rows.Remove(m_dt.Select("rowBs='" & YanDaTaGridView1.SelectedRows(0).Cells("rowBs").Value & "'")(0))
                                        End Sub
        m_dt.Columns.Add("rowBs")
        m_dt.YanDataBind(YanDaTaGridView1, "rowBs", menu)

        '添加值改变事件
        For Each s As String In m_ltCk
            AddHandler CType(MyBase.YanFindControl(s), TextBox).TextChanged,
                Sub(ser As Object, ex As EventArgs)
                    Dim countNum As Decimal = 0
                    For Each tS As String In m_ltCk
                        countNum += _S.YanFormatNum3(MyBase.YanFindControl(tS).Text)
                    Next
                    zkzl.Text = zkzl.Tag - countNum
                    ser.text = IIf(ser.text = "", 0, ser.text)
                End Sub
        Next
        '添加双击事件
        For Each s As String In m_ltCk
            AddHandler CType(MyBase.YanFindControl(s), TextBox).DoubleClick,
                Sub(ser As Object, ex As EventArgs)
                    ser.text = IIf(ser.Text > 0, 0, Convert.ToDecimal(ser.text) + Convert.ToDecimal(zkzl.Text))
                    ser.select(ser.text.length, 0)
                End Sub
        Next
        '添加键盘输入事件
        For Each s As String In m_ltCk
            AddHandler CType(MyBase.YanFindControl(s), TextBox).KeyPress,
                Sub(ser As Object, ex As System.Windows.Forms.KeyPressEventArgs)
                    Dim arrI As Integer() = New Integer() {22, 3, 8, 46}
                    '排除例外键
                    For Each iNum As Integer In arrI
                        If iNum = Asc(ex.KeyChar) Then
                            Return
                        End If
                    Next
                    If IsNumeric(ex.KeyChar) = False Then
                        ex.Handled = True
                        Return
                    End If
                    Dim t As TextBox = CType(ser, TextBox)
                    '如果有选择字符，那么就拼接字符串
                    Dim strIn As String = Strings.Left(t.Text, t.SelectionStart) & ex.KeyChar &
                        t.Text.Substring(t.SelectionStart + t.SelectionLength, t.Text.Length - t.SelectionStart - t.SelectionLength)
                    Dim inNum As Decimal = Convert.ToDecimal(strIn)
                    Dim countNum As Decimal = 0
                    For Each s2 As String In m_ltCk
                        If t.Name <> s2 Then
                            countNum += MyBase.YanFindControl(s2).Text
                        End If
                    Next
                    countNum += inNum
                    If countNum <= zkzl.Tag Then
                        Return
                    End If
                    ex.Handled = True
                End Sub
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If mingc.Text.Trim = "" Or jiagdm.Text.Trim = "" Then
            MsgBox("产品代码和加工代码不能为空！")
            Return
        End If
        If m_dt.Select(m_strTb & "_mingc='" & mingc.Text.Trim & "' and " & m_strTb & "_jiagdm='" & jiagdm.Text.Trim & "'").YanArrDrToDb.Rows.Count > 0 Then
            MsgBox("已经添加了相同的代码！")
            Return
        End If
        Dim strRemoteDb As String = IIf(m_strTb = "tb_x825pkc", "tb_mykc", m_strTb)
        Dim sql As String = "select * from hbcabiodb.." & strRemoteDb & " where " & strRemoteDb & "_num='" & m_frOpen.ph.Text & "' and " &
            strRemoteDb & "_cplb='" & cplb.Text.Trim & "' and " & strRemoteDb & "_mingc='" & mingc.Text.Trim & "' and " & strRemoteDb & "_jiagdm='" & jiagdm.Text.Trim & "'"
        Dim dt As DataTable = sql.YanGetDb()
        If dt.Rows.Count > 0 Then
            If MsgBox("湖北库中已有相同的记录，是否继续？", MsgBoxStyle.YesNo) <> vbYes Then
                Return
            End If
        End If

        Dim kczl As Double = 0
        Dim dr As DataRow = m_dt.NewRow
        For Each s As String In m_ltCk
            dr(m_strTb & "_" & s) = Me.YanFindControl(s).Text
            kczl += Me.YanFindControl(s).Text
        Next
        If kczl = 0 Then
            MsgBox("入库重量不能为0！")
            Return
        End If

        dr(m_strTb & "_kczl") = kczl
        dr(m_strTb & "_cplb") = cplb.Text.Trim
        dr(m_strTb & "_mingc") = mingc.Text.Trim
        dr(m_strTb & "_jiagdm") = jiagdm.Text.Trim

        dr("rowBs") = _S.getGuid()
        m_dt.Rows.Add(dr)

        zkzl.Tag = zkzl.Text
        For Each s As String In m_ltCk
            Me.YanFindControl(s).Text = 0
        Next
        zkzl.Text = zkzl.Tag
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If zkzl.Text <> 0 Then
            MsgBox("还有重量没有入库！")
            Return
        End If
        If YanDaTaGridView1.RowCount = 0 Then
            MsgBox("没有批次入库！")
            Return
        End If
        Me.DialogResult = DialogResult.OK
    End Sub
End Class