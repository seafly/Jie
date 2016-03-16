Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frddlist
    Private smbdj As String '临时交换变量
    Private Sub Frddlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub
#Region "位置，显示，隐藏控件方法，按钮选择为TRUE"
    Private Sub weizhi()
        GroupBox3.Width = Me.Width - GroupBox3.Left - 20
        GroupBox3.Top = tsMenu.Height
        GroupBox3.Height = Me.Height - GroupBox3.Top - 40
        show1.Height = GroupBox3.Height - 70
    End Sub

    Private Sub Frddlist_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub


    Private Sub guangbiao(ByVal DataGridviewName As DataGridView)
        Dim aa As Integer = 0
        Try
            With DataGridviewName
                If .Rows.Count >= 0 Then

                    Dim id As Integer = .SelectedRows(0).Cells(0).Value
                    For i As Integer = 0 To .Rows.Count - 1
                        If .Rows(i).Cells(0).Value = id Then
                            aa = i
                        End If
                    Next
                    .Rows(aa).Selected = True
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub comb(ByVal str As String, ByVal form As Form)
        Dim com As String() = str.Split(",")
        For i As Integer = 0 To com.Length - 1
            Try
                Dim co As ComboBox = form.Controls(com(i))
                co.Enabled = False
            Catch ex As Exception

            End Try

        Next
    End Sub
    Private Sub tex(ByVal str As String, ByVal form As Form)
        Dim tex As String() = str.Split(",")
        For i As Integer = 0 To tex.Length - 1
            Try
                Dim co As TextBox = form.Controls(tex(i))
                co.ReadOnly = True
            Catch ex As Exception
                Dim co As DateTimePicker = form.Controls(tex(i))
                co.Enabled = False
            End Try

        Next
    End Sub


    Private Sub btcheck(ByVal o As Object)
        tb2.Checked = False
        tb3.Checked = False
        tb4.Checked = False
        tb5.Checked = False
        tb6.Checked = False
        tbf.Checked = False
        dd1.Checked = False
        o.checked = True
    End Sub
#End Region
    Public Sub xxsj(ByVal str As String)
        GS_FaceSearch(ComboBox3, "tb_dd", 1) '筛选
        GS_FaceSearch(ComboBox2, "tb_dd", 2)

        Dim sql2 As String = "select " : Dim pd As Boolean = False
        '‘订单归属月份显示格式特殊（只显示年月），所以此出用了cast函数，为了使其表头正常显示，将列明改为
        '改为tb_dd_ddgsyf
        Select Case str
            Case tb2.Text '订单缺货查询
                sql2 &= " tb_dd_ID,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf ,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,'' as '库存满足','' as '缺货量','' as 'QA待定',tb_dd_yfh,'' as '未发货量', tb_dd_jfwc,tb_dd_bz,tb_dd_jdrq,tb_dd_sjdhrq  from tb_dd where tb_dd_fhtjdh is null order by tb_dd_jfwc,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddrq"
                pd = True
                Button7.Visible = False
            Case tb3.Text '订单输入与审核
                sql2 &= " tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jdrq,tb_dd_jfwc,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf  from tb_dd where tb_dd_bz1 is null and tb_dd_sfsh='否'"
                Button7.Visible = True
            Case tb4.Text '未发货
                sql2 &= " tb_dd_id,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs, cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf,tb_dd_ddsrshgh  from tb_dd where tb_dd_bz1='1'  and tb_dd_bz2 is null"
                Button7.Visible = False
            Case tbf.Text '计划明细
                sql2 &= " tb_dd_id,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,  tb_dd_fhl,tb_dd_cfs,tb_dd_sjph,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf ,tb_dd_ddsrshgh from tb_dd where tb_dd_bz1='2'  and  tb_dd_bz2 is not null and tb_dd_bz3 is null and tb_dd_fhtjdh is not null"
                Button7.Visible = False
            Case tb5.Text '已发货
                sql2 &= " tb_dd_id,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cys,tb_dd_ysfs,  tb_dd_fhl,tb_dd_sjfhrq,tb_dd_sjph,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf,tb_dd_ddsrshgh,tb_dd_bfb,tb_dd_kdlk,tb_dd_storagewzlk,tb_dd_storagemslk,tb_dd_returnsl,tb_dd_returnrq from tb_dd where tb_dd_bz1='2'  and tb_dd_bz3 is not null and tb_dd_bz4 is null"
                Button7.Visible = False
            Case tb6.Text '已签收
                sql2 &= " tb_dd_id,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf,tb_dd_jfwc,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_ddrq,tb_dd_fhl,tb_dd_sjfhrq,tb_dd_sjdhrq,tb_dd_sjph,tb_dd_cys,tb_dd_ysfs, tb_dd_yc,tb_dd_fhycms,tb_dd_jdrq,tb_dd_ddsrshgh,tb_dd_fhssczrgh,tb_dd_bfb,tb_dd_kdlk,tb_dd_storagewzlk,tb_dd_storagemslk,tb_dd_returnsl,tb_dd_returnrq from tb_dd where tb_dd_bz1='2'  and  tb_dd_bz4 is not null"
                Button7.Visible = False
        End Select

        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)

        dtjs(dt2, pd)
        GS_DataGridViewbyDb(show1, dt2, 0, True, True)
        GroupBox3.Text = str & "显示" & show1.Rows.Count & "条记录"
        guangbiao(show1)
        ddgsyf() '将订单归属月份的显示格式变为yyyy-MM(即2011-4)
    End Sub
   
    Private Sub ddgsyf() '将订单归属月份的显示格式变为yyyy-MM(即2011-4)
        For i As Integer = 0 To show1.RowCount - 1
            Try
                show1.Rows(i).Cells("tb_dd_ddgsyf").Value = Format(CDate(show1.Rows(i).Cells("tb_dd_ddgsyf").Value), "yyyy-MM")
            Catch ex As Exception
            End Try

        Next
    End Sub

    Private Function dtjs(ByVal dt As DataTable, ByVal pd As String) As DataTable '用于即时表的显示
        If pd = "False" Then '如果不是即时表则部进行构建
            Return dt
        End If
        '显示所有库存
        Try
       
            Dim sqlkc As String = "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_ckcl) from tb_x832pkc where tb_x832pkc_ckcl>0 and  tb_x832pkc_qaspjg ='合格' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm"
            sqlkc &= " union all "
            sqlkc &= " select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_ckcl)  from tb_h195zkc where tb_h195zkc_ckcl>0 and  tb_h195zkc_qaspjg ='合格' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm  "
            sqlkc &= " union all "
            sqlkc &= " select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_ckcl ) from tb_x825pkc where tb_x825pkc_ckcl>0 and  tb_x825pkc_qaspjg ='合格' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm "
            Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqlkc)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sqlkc2 As String = "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_ckcl) from tb_x832pkc where tb_x832pkc_ckcl>0 and  tb_x832pkc_qaspjg ='待定' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm"
            sqlkc2 &= " union all "
            sqlkc2 &= " select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_ckcl)  from tb_h195zkc where tb_h195zkc_ckcl>0 and  tb_h195zkc_qaspjg ='待定' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm  "
            sqlkc2 &= " union all "
            sqlkc2 &= " select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_ckcl ) from tb_x825pkc where tb_x825pkc_ckcl>0 and  tb_x825pkc_qaspjg ='待定' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm "
            Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqlkc2) '
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            '此处的dt1 是以tb_x832p 的列为架构的
            ''''''''''''''''''''‘
            For i As Integer = 0 To dt.Rows.Count - 1
                Try
                    If dt.Rows(i)("tb_dd_jfwc") <> "完成" Then

                        Dim sql As String = "tb_x832pkc_cplb='" & dt.Rows(i)("tb_dd_cplx") & "' and tb_x832pkc_mingc='" & dt.Rows(i)("tb_dd_cpdm") & "' and tb_x832pkc_jiagdm='" & dt.Rows(i)("tb_dd_jgdm") & "'"
                        Dim ckcl0 As DataRow() = dt1.Select(sql)
                        dt.Rows(i)("未发货量") = dt.Rows(i)("tb_dd_ddl") - DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) '订单量-已发货

                        If ckcl0.Length = 0 Then
                            dt.Rows(i)("库存满足") = 0
                            dt.Rows(i)("缺货量") = 0 - dt.Rows(i)("tb_dd_ddl")
                            If dt.Rows(i)("缺货量") < 0 Then ''如果缺货 则QA待定量为该代码qa待定的仓库存量
                                Dim ckcl2 As DataRow() = dt2.Select(sql)
                                If ckcl2.Length = 0 Then
                                    dt.Rows(i)("QA待定") = 0
                                Else
                                    dt.Rows(i)("QA待定") = ckcl2(0)(3)
                                End If
                            End If
                        Else
                            Dim kc As Double = ckcl0(0)(3) '库存
                            If kc < dt.Rows(i)("未发货量") Then
                                dt.Rows(i)("库存满足") = kc
                            Else
                                dt.Rows(i)("库存满足") = dt.Rows(i)("未发货量")
                            End If
                            If dt.Rows(i)("库存满足") + DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) - dt.Rows(i)("tb_dd_ddl") < 0 Then '缺货量=库存满足+已发货-订单量=库存满足-未发货
                                dt.Rows(i)("缺货量") = dt.Rows(i)("库存满足") + DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) - dt.Rows(i)("tb_dd_ddl") '库存满足+已发货-订单量
                                If dt.Rows(i)("缺货量") < 0 Then ''如果缺货 则QA待定量为该代码qa待定的仓库存量
                                    Dim ckcl2 As DataRow() = dt2.Select(sql)
                                    If ckcl2.Length = 0 Then
                                        dt.Rows(i)("QA待定") = 0
                                    Else
                                        dt.Rows(i)("QA待定") = ckcl2(0)(3)
                                    End If
                                End If
                            Else
                                dt.Rows(i)("缺货量") = 0
                            End If

                            ckcl0(0)(3) = kc - dt.Rows(i)("库存满足")
                        End If

                    End If
                Catch ex As Exception
 
                End Try

            Next
        Catch ex As Exception

        End Try


        Return dt
    End Function
    '签收
    Private Sub tb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb2.Click, tb3.Click, tb4.Click, tbf.Click, tb5.Click, tb6.Click '显示
        smbdj = sender.text
        btcheck(sender)
        xxsj(sender.text)
    
    End Sub

    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        If GF_storelog1("订单添加修改") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        Select Case smbdj
            
            Case tb3.Text '订单输入与审核
                Dim nform As New Frddadd
                nform.id = show1.SelectedRows(0).Cells(0).Value
                Me.AddOwnedForm(nform)
                nform.jm = tb3.Text
                nform.ddhpd = show1.SelectedRows(0).Cells(0).Value
                GS_tofalse("tb_dd_jhfhrq,ComboBox1,tb_dd_ysfs,tb_dd_cys,Label16,Label14,Label23,Label12,Label15,Label11,Label10,tb_dd_jhl,tb_dd_ph,tb_dd_jhfhzl,Button8,tb_dd_fhycms,Label24,Label19,Label18,Button7,tb_dd_sjdhrq,tb_dd_yc,Label31,tb_dd_jfwc", False, nform)
                GS_tofalse("Button5,Button3,Button4", False, nform) '隐藏控件
                GS_tofalse("label27,label28,label25,label21,tb_dd_sjfhrq,tb_dd_sjph,tb_dd_fhl,tb_dd_cw", False, nform) ''实际发货日期，实际批号，实际发货量
                Gs_showsj("tb_dd", nform, nform.id)
                nform.tb_dd_jdrq.Size = New System.Drawing.Point(0, 0)
                nform.Label32.Visible = False
                nform.Size = New System.Drawing.Size(884, 280)
                If Null2String(show1.SelectedRows(0).Cells("tb_dd_ddrq").Value) = "" Then '如果此时该字段为空那么在弹出界面时 tb_dd_ddrq控件显示为空
                    nform.tb_dd_ddrq.Format = DateTimePickerFormat.Custom
                    nform.tb_dd_ddrq.CustomFormat = " "
                Else
                    nform.tb_dd_ddrq.Format = DateTimePickerFormat.Short
                    nform.tb_dd_ddrq.Checked = True
                End If

                nform.ShowDialog()

            Case tb4.Text '未发货
                Dim nform As New Frddadd
                nform.id = show1.SelectedRows(0).Cells("tb_dd_id").Value
                Me.AddOwnedForm(nform)
                Dim v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
                Dim sql As String = "select tb_ddcys_mc from tb_ddcys  where tb_ddcys_fl='承运商'"
                Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                For i As Integer = 0 To dt.Rows.Count - 1
                    nform.tb_dd_cys.Items.Add(dt.Rows(i)(0))
                    v.Add(dt.Rows(i)(0))
                    nform.tb_dd_kh.AutoCompleteCustomSource = v
                Next
                nform.Size = New System.Drawing.Size(884, 400)
                nform.Button1.Visible = False
                nform.Button2.Visible = False
                nform.jm = tb4.Text
                GS_tofalse("Label17,tb_dd_fhtjdh,Button1,Button6,Button2,Label22", False, nform)
                GS_tofalse("Button8,tb_dd_fhycms,Label24,Label19,Label18,Button7,tb_dd_sjdhrq,tb_dd_yc,Label31,tb_dd_jfwc", False, nform) ''''''''''''''''''隐藏控件
                GS_tofalse("label27,label28,label25,tb_dd_sjfhrq,tb_dd_sjph,tb_dd_fhl,Label35,Label36,tb_dd_returnsl,tb_dd_returnrq", False, nform) ''实际发货日期，实际批号，实际发货量
                nform.ComboBox1.Text = "否"
                nform.tb_dd_kh.Enabled = False
                'tex("tb_dd_ddrq,tb_dd_bz,tb_dd_ddl,tb_dd_ddh,tb_dd_pm,tb_dd_khqc,tb_dd_ddgsyf", nform)
                tex("tb_dd_bz,tb_dd_ddl,tb_dd_ddh,tb_dd_pm,tb_dd_khqc", nform)
                nform.tb_dd_jdrq.Size = New System.Drawing.Point(0, 0)
                nform.Label32.Visible = False
                nform.tb_dd_ddrq.Format = DateTimePickerFormat.Short
                nform.tb_dd_ddrq.Checked = True
                nform.ShowDialog()

            Case tbf.Text

            Case tb5.Text '已发货
                Dim nform As New Frddadd
                nform.id = show1.SelectedRows(0).Cells(0).Value
                Me.AddOwnedForm(nform)
                nform.jm = tb5.Text
                nform.Size = New System.Drawing.Size(884, 581)
                GS_tofalse("Label17,tb_dd_fhtjdh,Button1,Button6,Button2,Button5,Button3,Button4,Label22,Label35,Label36,tb_dd_returnsl,tb_dd_returnrq", False, nform) ''''''''''''''''''隐藏控件
                nform.ComboBox1.Text = "是"
                Gs_showsj("tb_dd", nform, nform.id)
                nform.ComboBox1.Text = "否"
                tex("tb_dd_ddrq,tb_dd_bz,tb_dd_ddl,tb_dd_ddh,tb_dd_jhfhrq,tb_dd_jhl,tb_dd_ph,tb_dd_jhfhzl,tb_dd_pm,tb_dd_khqc,tb_dd_ddgsyf", nform)
                comb("tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_sfsh,tb_dd_kh,ComboBox1,tb_dd_ysfs,tb_dd_cys,tb_dd_cfs,tb_dd_cplx", nform)
                nform.tb_dd_yc.Text = "无"
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''用于批量修改进入下一步
                Dim dtt As DataTable = show1.DataSource
                Dim dt As DataTable = GF_czmctb(dtt.Copy, "tb_dd_fhtjdh='" & nform.tb_dd_fhtjdh.Text & "'")
                For i As Integer = 0 To dt.Rows.Count - 1
                    nform.fhtjdid &= dt.Rows(i)(0) & ","
                Next
                nform.fhtjdid = GF_removedh(nform.fhtjdid)
                nform.tb_dd_jdrq.Size = New System.Drawing.Point(0, 0)
                nform.Label32.Visible = False
                '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
                nform.tb_dd_ddrq.Format = DateTimePickerFormat.Short
                nform.tb_dd_ddrq.Checked = True
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                nform.tb_dd_sjdhrq.Format = DateTimePickerFormat.Custom '实际到货日期默认为空
                nform.tb_dd_sjdhrq.CustomFormat = ""
                nform.ShowDialog()
            Case tb6.Text '已签收

                Dim nform As New Frddadd
                nform.id = show1.SelectedRows(0).Cells(0).Value
                Me.AddOwnedForm(nform)
                nform.jm = tb6.Text
                nform.Size = New System.Drawing.Size(984, 681)
                GS_tofalse("Label17,tb_dd_fhtjdh,Button1,Button6,Button2,Button5,Button3,Button4,Label22", False, nform) ''''''''''''''''''隐藏控件
                GS_tofalse("Label33,Label32,tb_dd_ddsrshgh,Label34,tb_dd_fhssczrgh,Label29,tb_dd_khqc,Label31,tb_dd_ddgh,Label13,Label17,tb_dd_jfwc,tb_dd_fhtjdh", True, nform)
                nform.ComboBox1.Text = "是"
                Gs_showsj("tb_dd", nform, nform.id)
                tex("tb_dd_ddrq,tb_dd_bz,tb_dd_ddl,tb_dd_ddh,tb_dd_jhfhrq,tb_dd_jhl,tb_dd_ph,tb_dd_jhfhzl,tb_dd_pm,tb_dd_khqc,tb_dd_ddgsyf,tb_dd_sjdhrq", nform)
                comb("tb_dd_pm,tb_dd_cpdm,tb_dd_jgdm,tb_dd_sfsh,tb_dd_kh,ComboBox1,tb_dd_ysfs,tb_dd_cys,tb_dd_cfs,tb_dd_cplx,tb_dd_jfwc", nform)
                nform.tb_dd_jdrq.Size = New System.Drawing.Point(0, 0)
                nform.Label32.Visible = False
                nform.Button9.Visible = True
                nform.Button10.Visible = True
                nform.tb_dd_ddrq.Format = DateTimePickerFormat.Short
                nform.tb_dd_ddrq.Checked = True
                nform.ShowDialog()

        End Select

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click ''''''''''''''''''订单添加
        If GF_storelog1("订单添加修改") = False Then
            Exit Sub
        End If ' 判断是否有权限
        Dim nform As New Frddadd
        Me.AddOwnedForm(nform)
        Dim v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        Dim sql As String = "select tb_khyqqkyrb_khmc from tb_khyqqkyrb where tb_khyqqkyrb_khmc='有效' group by tb_khyqqkyrb_khmc "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            nform.tb_dd_kh.Items.Add(dt.Rows(i)(0))
            v.Add(Null2String(dt.Rows(i)(0)))
            nform.tb_dd_kh.AutoCompleteCustomSource = v
        Next
        nform.tb_dd_kh.Items.Add("小客户")
        nform.jm = tb2.Text
        GS_tofalse("tb_dd_sfsh,Label9,Button6,Label22,label21,tb_dd_cw", False, nform)
        GS_tofalse("tb_dd_jhfhrq,ComboBox1,tb_dd_ysfs,tb_dd_cys,Label16,Label14,Label23,Label12,Label15,Label11,Label10,tb_dd_jhl,tb_dd_ph,tb_dd_jhfhzl,Button8,tb_dd_fhycms,Label24,Label19,Label18,Button7,tb_dd_sjdhrq,tb_dd_yc,Label31,tb_dd_jfwc", False, nform)
        GS_tofalse("Button5,Button3,Button4", False, nform) '''''''''''''''''''''''''隐藏控件
        GS_tofalse("label27,label28,label25,tb_dd_sjfhrq,tb_dd_sjph,tb_dd_fhl", False, nform) ''实际发货日期，实际批号，实际发货量
        nform.Size = New System.Drawing.Size(970, 300)
        nform.tb_dd_ddrq.Format = DateTimePickerFormat.Custom
        nform.tb_dd_ddrq.CustomFormat = " "
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nform As New Frddadd
        Me.AddOwnedForm(nform)
        Dim v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        Dim sql As String = "select tb_ddcys_mc from tb_ddcys "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            nform.tb_dd_cys.Items.Add(dt.Rows(i)(0))
            v.Add(dt.Rows(i)(0))
            nform.tb_dd_kh.AutoCompleteCustomSource = v
        Next
        nform.Size = New System.Drawing.Size(972, 443)
        GS_tofalse("Label17,tb_dd_fhtjdh,Button1,Button6,Button2", False, nform)
        nform.xg = True
        nform.jm = tb4.Text
        nform.ShowDialog()
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim aa As New Frddadd
        aa.Show()
    End Sub
    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dd1.Click '打印
        Dim nform As New Frdddy
        Me.AddOwnedForm(nform)
        btcheck(sender)
        Dim sql1 As String = ""
        sql1 = "tb_dd_bz1='1' and tb_dd_bz2='2' "

        nform.bs = sender.text
        nform.sql = "select tb_dd_fhtjdh from tb_dd where " & sql1
        nform.sql &= " group by tb_dd_fhtjdh"
        nform.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker3.Text)
        tt2 = GF_gettrqsj(DateTimePicker4.Text)
        Dim sqlbdssep As String = GF_FaceSearchBQS(ComboBox3, TextBox2) '筛选要求

        Dim sql1 As String = GF_sxrq(ComboBox2, tt1, tt2)
        sqlbdssep &= sql1

        Dim sql2 As String = "select " : Dim pd As Boolean = False

        If tb2.Checked = True Then
            sql2 &= " tb_dd_ID,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf ,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,'' as '库存满足','' as '缺货量','' as 'QA待定',tb_dd_yfh,'' as '未发货量', tb_dd_jfwc  from tb_dd where tb_dd_fhtjdh is null "
            pd = True
        ElseIf tb3.Checked = True Then
            sql2 &= " tb_dd_ID,tb_dd_ddh,tb_dd_kh,tb_dd_pm,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_cw,tb_dd_ddrq,tb_dd_bz,tb_dd_sfsh,tb_dd_sjfhrq,tb_dd_jfwc,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf  from tb_dd where tb_dd_bz1 is null and tb_dd_sfsh='否' "

        ElseIf tb4.Checked = True Then
            sql2 &= " tb_dd_id,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cw,tb_dd_cys,tb_dd_ysfs, cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf   from tb_dd where tb_dd_bz1='1'  and tb_dd_bz2 is null "

        ElseIf tbf.Checked = True Then
            sql2 &= " tb_dd_id,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cw,tb_dd_cys,tb_dd_ysfs,  tb_dd_fhl,tb_dd_cfs,tb_dd_sjph,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf from tb_dd where tb_dd_bz1='2'  and  tb_dd_bz2 is not null and tb_dd_bz3 is null and tb_dd_fhtjdh is not null "
        ElseIf tb5.Checked = True Then
            sql2 &= " tb_dd_id,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_jhfhrq,tb_dd_jhfhzl,tb_dd_ph,tb_dd_jhl,tb_dd_cw,tb_dd_cys,tb_dd_ysfs,  tb_dd_fhl,tb_dd_sjfhrq,tb_dd_sjph,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf from tb_dd where tb_dd_bz1='2'  and tb_dd_bz3 is not null and tb_dd_bz4 is null "

        ElseIf tb6.Checked = True Then
            sql2 &= " tb_dd_id,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf,tb_dd_jfwc,tb_dd_ddh,tb_dd_ddl,tb_dd_cpdm,tb_dd_jgdm,tb_dd_fhtjdh,tb_dd_kh,tb_dd_ddrq,tb_dd_fhl,tb_dd_sjfhrq,tb_dd_sjdhrq,tb_dd_sjph,tb_dd_cw,tb_dd_cys,tb_dd_ysfs, tb_dd_yc,tb_dd_fhycms,tb_dd_yfh,tb_dd_cfs,tb_dd_cplx,tb_dd_khqc"
            sql2 &= " ,tb_dd_shdy,tb_dd_zzfhrq,tb_dd_ddgh,tb_dd_ddsrshgh,tb_dd_fhssczrgh,tb_dd_bfb,tb_dd_kdlk,tb_dd_storagewzlk,tb_dd_storagemslk,tb_dd_returnsl,tb_dd_returnrq from tb_dd where tb_dd_bz1='2'  and  tb_dd_bz4 is not null "

        End If

        sql2 &= sqlbdssep

        If tb2.Checked = True Then
            sql2 &= "order by tb_dd_jfwc,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddrq"
        End If

        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        dtjs(dt2, pd)
        GS_DataGridViewbyDb(show1, dt2, 0, True, True)
        GroupBox3.Text = "显示" & show1.Rows.Count & "条记录"
        ddgsyf() '将订单归属月份的显示格式变为yyyy-MM(即2011-4)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If tb2.Checked = True Then
            xxsj(tb2.Text)
        ElseIf tb3.Checked = True Then
            xxsj(tb3.Text)
        ElseIf tb4.Checked = True Then
            xxsj(tb4.Text)
        ElseIf tbf.Checked = True Then
            xxsj(tbf.Text)
      
        ElseIf tb5.Checked = True Then
            xxsj(tb5.Text)
        ElseIf tb6.Checked = True Then
            xxsj(tb6.Text)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        GS_toexcel(show1, "", Me)
    End Sub
    '时间筛选语句
    Private Function GF_sxrq(ByVal ComboBoxName As ComboBox, ByVal tt1 As String, ByVal tt2 As String) As String
        Dim zdzw As String = ComboBoxName.Text
        If zdzw = "" Then
            Return ""
        End If
        Dim db As DataTable = CType(ComboBoxName.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "]  between '" & tt1 & "' and '" & tt2 & "'"
        Return sql
    End Function
    'sql 非时间后缀条件
    Public Function GF_FaceSearchBQS(ByVal ComboBoxName As ComboBox, ByVal TextboxName As TextBox) As String
        Dim cxkr As String = TextboxName.Text.Trim
        If cxkr = "" Then
            Return ""
        End If
        cxkr = Replace(cxkr, "‘", "'")
        Dim zdzw As String = ComboBoxName.Text
        If zdzw = "" Then
            Return ""
        End If
        Dim db As DataTable = CType(ComboBoxName.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like  '%" & cxkr & "%' "
        Return sql
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nf As New Frddqhjf
        nf.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nf As New Frddjfyb2
        nf.Show()
    End Sub

End Class