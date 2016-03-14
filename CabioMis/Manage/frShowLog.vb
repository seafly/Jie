Public Class frShowLog

 
    Private Sub frShowLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        weizhi()
        Me.DateTimePicker1.Text = DateAdd(DateInterval.Day, -1, Date.Now)
        Me.DateTimePicker2.Text = DateAdd(DateInterval.Day, 1, Date.Now)
        showListview()
    End Sub
    Private Sub weizhi()
    
        GroupBox1.Width = Me.Width - GroupBox1.Left - 10
        GroupBox2.Width = GroupBox1.Width
        GroupBox2.Height = Me.Height - GroupBox2.Top - 30
    End Sub
    Public Sub showListview()
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Dim sql As String = "select * from tb_zclog where 1=1  and tb_zclog_rq between '" & tt1 & "' and '" & tt2 & "' "
        If Me.TextBox2.Text.Trim <> "" Then '工号关键字
            sql = sql & " and tb_zclog_gh like '%" & Me.TextBox2.Text.Trim & "%' "
        End If

        If Me.TextBox3.Text.Trim <> "" Then '姓名关键字
            sql = sql & " and tb_zclog_xm like '%" & Me.TextBox3.Text.Trim & "%' "
        End If
        If Me.TextBox1.Text.Trim <> "" Then '说明关键字
            sql = sql & " and tb_zclog_sm like '%" & Me.TextBox1.Text.Trim & "%' "
        End If
        If Me.TextBox4.Text.Trim <> "" Then '类型关键字
            sql = sql & " and tb_zclog_lx like '%" & Me.TextBox4.Text.Trim & "%' "
        End If
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt, 0, 0)
        GroupBox2.Text = DateTimePicker1.Text & "至" & DateTimePicker2.Text & "查询结果：" & ListView1.Items.Count & "条记录"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call showListview()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(ListView1, GroupBox2.Text, Me)
    End Sub

    Private Sub frShowLog_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub
End Class