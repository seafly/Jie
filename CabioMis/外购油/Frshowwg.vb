Public Class Frshowwg
    Public tbname '表名称
    Private Sub weizhi()
        GroupBox1.Width = Me.Width - GroupBox1.Left - 5
        listview1.Width = GroupBox1.Width
        listview1.Height = Me.Height - listview1.Top - 40
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(listview1, Me.Text, Me)
    End Sub
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub
    Private Sub Frshowwg_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Private Sub Frshowadd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
        ''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, tbname, 1) '文本查询函数：关联表的文本字段的显示
        '''''''''''''''''''''''''''
    End Sub
    Private Sub Buttsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttsearch.Click
        showsj()
    End Sub
    Private Sub showsj()
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        Dim str1, str2 As String
        str1 = GF_gettrqsj(DateTimePicker1.Text)
        str2 = GF_gettrqsj(DateTimePicker2.Text)
        str1 = str1 & " 00:00:00" : str2 = str2 & " 23:59:59"
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        '以是否有外购来源批号为判断外购条件
        Dim sql As String = ""
        '''''''''''''''''''''''''''''''''
        Select Case tbname
            Case "tb_x825p"
                sql = "select tb_x825p_ID,tb_x825p_wgbh,tb_x825p_num,tb_x825p_jgrq,tb_x825p_r583j,tb_x825p_gjtzy,tb_x825p_d68w,tb_x825p_s640k,tb_x825p_sn,tb_x825p_mynetaa,tb_x825p_qcrq,tb_x825p_r602j,tb_x825p_m387e,tb_x825p_q547i,tb_x825p_u699m,tb_x825p_r600j,tb_x825p_o479g,tb_x825p_b959t,tb_x825p_t686m,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_bz,tb_x825p_ckcl from " & tbname & " where  " & tbname & "_wgbh is not null and " & tbname & "_jgrq between '" & str1 & "' and '" & str2 & "' "
            Case Else
                sql = "select * from " & tbname & " where  " & tbname & "_wgbh is not null and " & tbname & "_jgrq between '" & str1 & "' and '" & str2 & "' "
        End Select
                Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext) '文本查询函数：挂接到查询文本
        sql &= sqlbdssep & " order by " & tbname & "_jgrq desc"
        ''''''''''''''''''''''''''''''''''''''''''''
        Dim aa1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        Select Case tbname
            Case "tb_h195z" '外购成品油
                GS_DataGridViewbyDb(listview1, aa1, "0", True, True)
            Case "tb_x825p" '外购毛油的发酵周期、放罐体积、放罐NETAA不显示
                GS_DataGridViewbyDb(listview1, aa1, "0", True, True)
        End Select

        Label1.Visible = True
        Label1.Text = "查询结果：" & GF_getListViewsz(listview1) & "条记录"
        '''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub



    Private Sub listview1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listview1.MouseDoubleClick
        If listview1.SelectedRows.Count = 0 Then
            Return
        End If
        Dim chioseid As String = listview1.SelectedRows(0).Cells(0).Value
        '验证锁定
        If GF_MakeIsSD(tbname, chioseid) = False Then
            Exit Sub
        End If
        Select Case tbname
            Case "tb_h195z" '外购成品油的添加
                Dim aa As New Frwgcpy
                aa.Labelid.Text = chioseid
                aa.ShowDialog()
            Case "tb_x825p" '外购毛油的添加
                Dim aa As New Frwgmy
                aa.Labelid.Text = chioseid
                aa.ShowDialog()
        End Select
        showsj()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case tbname
            Case "tb_h195z" '外购成品油的添加
                Dim aa As New Frwgcpy
                aa.ShowDialog()
            Case "tb_x825p" '外购毛油的添加
                Dim aa As New Frwgmy
                aa.ShowDialog()
        End Select
        showsj()
    End Sub

  
End Class