Public Class Frpljhcx

    Private Sub Frpljhcx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
    End Sub
    Private Sub wz()
        GroupBox1.Width = Me.Width - 10
        GroupBox1.Height = Me.Height - GroupBox1.Top - 25
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        'tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If

        showjsj(tt1, tt2)
    End Sub
    Private Sub showjsj(ByVal str1 As String, ByVal str2 As String)
        Dim sql As String = ""
        Select Case ComboBox1.Text
            Case "毛油配料计划"
                sql = "select tb_mypl_ID,tb_mypl_a953t,tb_mypl_i225a,tb_mypl_cplb,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_ckdb,tb_mypl_myhl,tb_mypl_q569j,tb_mypl_bz from tb_mypl where tb_mypl_ckdb='" & ComboBox2.Text & "' and tb_mypl_a953t between '" & str1 & "' and '" & str2 & "'"
            Case "粉剂配料计划"
                sql = "select tb_x823p_ID,tb_x823p_jgrq,tb_x823p_cplb,tb_x823p_jiagdm,tb_x823p_mingc,tb_x823p_num,tb_x823p_num2,tb_x823p_kczl,tb_x823p_t678l,tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_ckdb,tb_x823p_jhhl,tb_x823p_wcyp,tb_x823p_bz,tb_x823p_fgfzl,tb_x823p_myhj,tb_x823p_lssg,tb_x823p_ldbsn,tb_x823p_bxdf,tb_x823p_ysjj,tb_x823p_pwgc,tb_x823p_myhj2,tb_x823p_nmsn,tb_x823p_vcna,tb_x823p_fgfph,tb_x823p_dpmx,tb_x823p_Reference,tb_x823p_ReferenceHj from tb_x823p where tb_x823p_ckdb='" & ComboBox2.Text & "' and tb_x823p_jgrq between '" & str1 & "' and '" & str2 & "'"
        End Select
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        sql = sql & sqlbdssep '文本查询函数：挂接到查询文本
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        'GS_useviewbydb2(listview1, dt, 0, 100)
        GS_DataGridViewbyDb(listview1, dt, "0", True, True)
        GroupBox1.Text = DateTimePicker1.Text & "至" & DateTimePicker2.Text & ComboBox1.Text & ComboBox2.Text & "：" & GF_getListViewsz(ListView1) & "条记录"
    End Sub

    Private Sub toexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toexcel.Click
        GS_toexcel(ListView1, GroupBox1.Text, Me)
    End Sub

    Private Sub Frpljhcx_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub


    Private Sub listview1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listview1.MouseDoubleClick
        If ComboBox1.Text = "粉剂配料计划" Then
            Dim cxid As String = Me.listview1.SelectedRows(0).Cells(0).Value
            Dim sql As String = "select tb_x823p_ckdb from tb_x823p where  tb_x823p_ckdb='未完成' and tb_x823p_ID=" & cxid
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count = 0 Then
                MsgBox("仓库调拨只有是【未完成】状态才能修改")
                Return
            End If
            Dim nform As New Fraddfjpl
            nform.Labeltb.Text = "tb_x823p"
            nform.Labelid.Text = cxid
            nform.ShowDialog()
        Else
            Exit Sub
        End If

        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        showjsj(tt1, tt2)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim b As String = ""
        Select Case ComboBox1.Text
            Case "毛油配料计划"
                b = "tb_mypl"
            Case "粉剂配料计划"
                b = "tb_x823p"
               End Select
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, b, 1) '文本查询函数：关联表的文本字段的显示
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
End Class