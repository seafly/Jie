Public Class Frshowadd
    '本界面的添加必须有有一个_rq表示日期的字段
    Private Sub weizhi()
        GroupBox1.Width = Me.Width - GroupBox1.Left - 5
        listview1.Width = GroupBox1.Width - 40
        listview1.Height = Me.Height - listview1.Top - 40
    End Sub

    Private Sub Frshowadd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        If TextBox1.Text = "tb_wsjcjl" Then
            Button2.Enabled = False
        End If
        weizhi()
        ''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, TextBox1.Text, 1) '文本查询函数：关联表的文本字段的显示
        '''''''''''''''''''''''''''
    End Sub
    Private Sub showsj(ByVal str1 As String, ByVal str2 As String)
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        ''''''''''''''''''''''

        Dim sql As String = "select * from " & TextBox1.Text & " where  " & TextBox1.Text & "_rq between '" & str1 & "' and '" & str2 & "' "
        If TextBox1.Text = "tb_wjxmjl" Then
            sql = "select tb_wjxmjl_id,tb_wjxmjl_rq,tb_wjxmjl_cplb,tb_wjxmjl_cpph,tb_wjxmjl_sjrq,tb_wjxmjl_syl,tb_wjxmjl_wjbgzt,tb_wjxmjl_sjcdw,tb_wjxmjl_p514h,tb_wjxmjl_wjzq,tb_wjxmjl_bz,tb_wjxmjl_w777o,tb_wjxmjl_smsj25,tb_wjxmjl_smsj100,tb_wjxmjl_shen,tb_wjxmjl_zjs,tb_wjxmjl_gong,tb_wjxmjl_qian,tb_wjxmjl_jhsptqj,tb_wjxmjl_dcaxsj10,tb_wjxmjl_lstj,tb_wjxmjl_lyybgj,tb_wjxmjl_dcaxsj,tb_wjxmjl_srjby,tb_wjxmjl_sjr,tb_wjxmjl_ylzfshl,tb_wjxmjl_zzfshl,tb_wjxmjl_fszfshl,tb_wjxmjl_chxsj,tb_wjxmjl_wsse,tb_wjxmjl_dllbhl,tb_wjxmjl_ge,tb_wjxmjl_lv,tb_wjxmjl_dbz,tb_wjxmjl_ylshyj,tb_wjxmjl_cqxmsj,tb_wjxmjl_hqmdsb1,tb_wjxmjl_czrgh from " & TextBox1.Text & " where " & TextBox1.Text & "_rq between '" & str1 & "' and '" & str2 & "'"
        ElseIf TextBox1.Text = "tb_b962t" Then '修改于2010.4.28
            sql = "select tb_b962t_ID,tb_b962t_qcsh,tb_b962t_rq,tb_b962t_d38v,tb_b962t_c12u,tb_b962t_o493h,tb_b962t_k339d,tb_b962t_b977t,tb_b962t_e90w,tb_b962t_h198z,tb_b962t_y852q,tb_b962t_p506h,tb_b962t_b981t,tb_b962t_z889r,tb_b962t_k315c,tb_b962t_Solid_waste,tb_b962t_u701m,tb_b962t_q555i,tb_b962t_m399e,tb_b962t_s611k,tb_b962t_x839q,tb_b962t_g156y,tb_b962t_e92w,tb_b962t_czrgh,tb_b962t_remark  from " & TextBox1.Text & " where " & TextBox1.Text & "_rq between '" & str1 & "' and '" & str2 & "'"
        End If
        '''''''''''''''''''''''''''''''''
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext) '文本查询函数：挂接到查询文本
        sql &= sqlbdssep & " order by " & TextBox1.Text & "_rq desc"
        ''''''''''''''''''''''''''''''''''''''''''''

        Dim aa1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(listview1, aa1, "0", True, True)
        Label1.Visible = True
        Label1.Text = "查询结果：" & GF_getListViewsz(listview1) & "条记录"
        '''''''''''''''''''''''''''''''''''''''
        If TextBox1.Text = "tb_2009nwbshqktj" Then
            Dim fxx, wcx, qdx As Integer, wcn As String
            fxx = DeepCode.DeepDoDataTable.GF_jsColumnTotal(aa1, 9, 0, aa1.Rows.Count - 1) '发现项
            qdx = DeepCode.DeepDoDataTable.GF_jsColumnTotal(aa1, 10, 0, aa1.Rows.Count - 1) '确定项
            wcx = DeepCode.DeepDoDataTable.GF_jsColumnTotal(aa1, 11, 0, aa1.Rows.Count - 1) '完成项
            Try
                wcn = FormatPercent(wcx / fxx, 2)
            Catch ex As Exception
                wcn = 0
            End Try
            Label3.Visible = True
            Label3.Text = "累计统计：发现项" & fxx & ",确定项" & qdx & ",完成项" & wcx & ",完成率" & wcn
        End If '
        '''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub
    Private Sub Frshowadd_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(listview1, Me.Text, Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dkxck(TextBox1.Text, "")

        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        showsj(tt1, tt2)
    End Sub
    Private Sub dkxck(ByVal str As String, ByVal str2 As String)
        '必须是 命名空间+点+窗体类名 
        Dim ctclass As String = My.Application.Info.AssemblyName & "." & "Fr" & str
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(ctclass), Form)
        frm2.Controls("labeltb").Text = str
        frm2.Controls("labelid").Text = str2
        frm2.ShowDialog()
        frm2.Dispose()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If listview1.SelectedRows.Count = 0 Then
            MsgBox("请选择要删除的数据!")
            Exit Sub
        End If
        If MsgBox("确定删除吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''
            If GF_storelog2("删除" & Me.Text, "删除" & Me.Text) = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim tbid As String = TextBox1.Text & "_id"
            Dim sql As String = "delete  from " & TextBox1.Text & " where " & tbid & " in( " & GF_GetSelectedValue(Me.listview1, 0) & ")"
            GS_upztxx(G_cnnstr, sql)
            Dim tt1, tt2 As String
            tt1 = DateTimePicker1.Text
            tt2 = DateTimePicker2.Text
            tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
            showsj(tt1, tt2)
        End If
    End Sub

    Private Sub Buttsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttsearch.Click

        Dim tt1, tt2 As String
        tt1 = DateTimePicker1.Text
        tt2 = DateTimePicker2.Text
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        showsj(tt1, tt2)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If listview1.SelectedRows.Count = 0 < 1 Then
            MsgBox("请选择要删除的数据!")
            Exit Sub
        End If
        If MsgBox("确定删除吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            '''''''''''''''''''''
            Dim tbid As String = TextBox1.Text & "_id"
            Dim sql As String = "delete  from " & TextBox1.Text & " where " & tbid & " in( " & GF_GetSelectedValue(Me.listview1, 0) & ")"
            GS_upztxx(G_cnnstr, sql)
            Dim tt1, tt2 As String
            tt1 = GF_gettrqsj(DateTimePicker1.Text)
            tt2 = GF_gettrqsj(DateTimePicker2.Text)
            tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
            showsj(tt1, tt2)
        End If
    End Sub

    Private Sub listview1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listview1.MouseDoubleClick
        If listview1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        For i As Integer = 0 To listview1.Columns.Count - 1
            Dim zd As String = listview1.Columns(i).HeaderText
            If zd = "是否审核" Then
                Dim lr As String = listview1.SelectedRows(0).Cells(i).Value
                If lr = "是" Then
                    MsgBox("已经完成审核，不能修改") : Exit Sub
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If zd = "执行情况" Then
                Dim lr As String = listview1.SelectedRows(0).Cells(i).Value
                If lr = "完成" Then
                    MsgBox("已经完成，不能修改") : Exit Sub
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Next
        Dim czid As String = listview1.SelectedRows(0).Cells(0).Value
        If GF_MakeIsSD(TextBox1.Text, czid) = True Then '判断该记录是否已经被锁定
            dkxck(TextBox1.Text, czid)
            Dim tt1, tt2 As String
            tt1 = GF_gettrqsj(DateTimePicker1.Text)
            tt2 = GF_gettrqsj(DateTimePicker2.Text)
            tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
            showsj(tt1, tt2)
        Else
            Exit Sub
        End If
    End Sub
End Class