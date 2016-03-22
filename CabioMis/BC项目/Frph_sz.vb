Public Class Frph_sz
    Private m_dt As DataTable = Nothing
    Private m_strWhere As String = ""
    Private Sub Frph_sz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = tb_bcbm_bmmc.Text & "设置"
        If tb_bcbm_tb.Text = "zdy" Then
            tb_bcbm_bmmc.Enabled = True
        Else
            tb_bcbm_bmmc.Enabled = False
        End If
        '添加右键餐单
        Dim menu1 As New ContextMenuStrip
        menu1.Items.Add("删除")
        AddHandler menu1.Items(0).Click, Sub()
                                             m_dt.Rows.Remove(m_dt.Select("rowBs='" & YanDaTaGridView1.SelectedRows(0).Cells("rowBs").Value & "'")(0))
                                             TextBox1.Text = cl_YanMd.getBmVa(m_dt)
                                         End Sub
        m_strWhere = "tb_bcbm_tb='" & tb_bcbm_tb.Text & "' and tb_bcbm_bs=" & tb_bcbm_bs.Text & " and tb_bcbm_bmmc='" & tb_bcbm_bmmc.Text & "'"
        m_dt = _D.GF_CreateDataSource("select *,cast(newid() as varchar(50)) as rowBs from tb_bcbm where " & m_strWhere)
        m_dt.TableName = "tb_bcbm"
        m_dt.YanDataBind(YanDaTaGridView1, "tb_bcbm_ID,tb_bcbm_tb,tb_bcbm_bs,tb_bcbm_va2,rowBs", menu1)

        AddHandler tb_bcbm_lx.SelectedIndexChanged,
            Sub()
                '赋值
                Select Case tb_bcbm_lx.Text
                    Case "文本"
                        tb_bcbm_va.Text = ""
                    Case "当前年"
                        tb_bcbm_va.Text = DateTime.Now.Year.ToString("0000")
                    Case "当前年(2位)"
                        tb_bcbm_va.Text = Strings.Right(System.DateTime.Now.Year, 2)
                    Case "当前月"
                        tb_bcbm_va.Text = DateTime.Now.Month.ToString("00")
                    Case "当前日"
                        tb_bcbm_va.Text = DateTime.Now.Day.ToString("00")
                    Case "随机数"
                        tb_bcbm_va.Text = "0000"
                    Case "累加数"
                        tb_bcbm_va.Text = "0000"
                End Select
                '隐藏累加数
                Select Case tb_bcbm_lx.Text
                    Case "累加数"
                        lableCxjs.Visible = True
                        tb_bcbm_zdbz.Visible = True
                    Case Else
                        lableCxjs.Visible = False
                        tb_bcbm_zdbz.Visible = False
                        tb_bcbm_zdbz.Text = ""
                End Select
                '是否输入数字
                Select Case tb_bcbm_lx.Text
                    Case "文本"
                        tb_bcbm_va.isOnlyNum = False
                    Case Else
                        tb_bcbm_va.isOnlyNum = True
                End Select
                '是否只读
                Select Case tb_bcbm_lx.Text
                    Case "当前年", "当前月", "当前日", "当前年(2位)"
                        tb_bcbm_va.ReadOnly = True
                    Case Else
                        tb_bcbm_va.ReadOnly = False
                End Select
                '是否只读
                Select Case tb_bcbm_lx.Text
                    Case en_phEx.附加信息.ToString
                        phEx.BackColor = System.Drawing.Color.Wheat
                        phEx.Visible = True
                        tb_bcbm_va.Visible = False
                        Label2.Visible = False
                        tb_bcbm_va.isOnlyNum = False
                    Case Else
                        phEx.BackColor = System.Drawing.SystemColors.Window
                        phEx.Visible = False
                        tb_bcbm_va.Visible = True
                        Label2.Visible = True
                End Select
            End Sub
        tb_bcbm_lx.Text = "文本"
        TextBox1.Text = cl_YanMd.getBmVa(m_dt)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case tb_bcbm_lx.Text
            Case "累加数"
                tb_bcbm_va2.Text = tb_bcbm_va.Text
            Case en_phEx.附加信息.ToString
                tb_bcbm_va.Text = phEx.Text
        End Select
        If CheckControlNull(Me) = False Then
            Return
        End If
        _D.YanFrVaAddDt(Me, m_dt)

        Select Case tb_bcbm_lx.Text
            Case "文本"
                tb_bcbm_va.Text = ""
            Case en_phEx.附加信息.ToString
                tb_bcbm_va.Text = ""
        End Select

        tb_bcbm_va2.Text = ""
        TextBox1.Text = cl_YanMd.getBmVa(m_dt)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If tb_bcbm_tb.Text = "zdy" Then
            If _D.isRowNull("tb_bcbm", "tb_bcbm_bmmc='" & tb_bcbm_bmmc.Text & "'") Then
                If MsgBox("此操作会覆盖自定义批号原有相同的名称，是否继续？", MsgBoxStyle.YesNo) = vbNo Then
                    Return
                End If
            End If
        End If
        _D.YanDtUpdateSv(m_dt)
        '删除刚才剔除的附加信息
        Dim Sql As String = "delete from tb_bcbm where " & m_strWhere &
            IIf(m_dt.Rows.Count = 0, "", " and tb_bcbm_ID not in (" & m_dt.YanDtToStr("tb_bcbm_ID") & ")")
        Sql.YanDbExe()
        Me.DialogResult = DialogResult.OK
    End Sub
End Class