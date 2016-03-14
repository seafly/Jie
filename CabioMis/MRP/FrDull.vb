Public Class FrDull

    Private Sub FrDull_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        With ComboBox4
            .Items.Add("等于") : .Items.Add("不等于")
            .Items.Add("大于") : .Items.Add("大于等于")
            .Items.Add("小于") : .Items.Add("小于等于")
            .Items.Add("之间")
            .SelectedIndex = 0
        End With
        showsj()
    End Sub
    '组合字符串组合IN查询字符串
    Private Function GF_zhzfccx(ByVal str As String) As String
        str = Replace(str, ",", "','")
        GF_zhzfccx = "'" & str & "'"
    End Function

    Private Sub FrDull_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - GroupBox1.Top - 50
    End Sub


    Private Sub showsj()
        Dim lastid As String = ""
        Dim sql0 As String = "select  tb_yljch_dm, tb_yljch_num  from tb_yljch  where tb_yljch_cz='出'  group by tb_yljch_dm, tb_yljch_num   "
        Dim dt0 As DataTable = GF_CreateDataSource(G_cnnstr, sql0)
        With dt0
            If .Rows.Count > 0 Then

                For i As Integer = 0 To .Rows.Count - 1

                    Dim sql1 As String = "select tb_yljch_id,DATEDIFF(day,tb_yljch_rq,getdate()) as mm  from tb_yljch where  tb_yljch_dm ='" & .Rows(i)("tb_yljch_dm") & "'  "
                    sql1 &= " and   tb_yljch_num ='" & .Rows(i)("tb_yljch_num") & "'   and  tb_yljch_cz='出'  order by mm   "
                    Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
                    If dt1.Rows.Count > 0 Then
                        lastid = lastid & dt1.Rows(0)("tb_yljch_id") & "," '得到物料代码出货的最终时间的ID
                    End If


                Next
            End If
        End With
        lastid = GF_zhzfccx(GF_removedh(lastid))
        Dim sql3 As String = "select a.tb_i259b_id, a.tb_i259b_r596j,a.tb_i259b_i231a,a.tb_i259b_c24u,a.tb_i259b_h200z,a.tb_i259b_num"
        sql3 &= " ,a.tb_i259b_ckcl,a.tb_i259b_q546i,a.tb_i259b_y840q,b.tb_yljch_rq  最后异动时间  "
        sql3 &= ", b.mm 呆滞天数 ,b.tb_yljch_bz,a.tb_i259b_qajgsm,a.tb_i259b_qaspjg,b.tb_yljch_zhbzq from  tb_i259b  a "
        sql3 &= " Left Join "
        sql3 &= " (select  tb_yljch_num ,tb_yljch_ckcl,tb_yljch_rq "
        sql3 &= " , DATEDIFF(day,tb_yljch_rq,getdate()) as mm ,tb_yljch_bz,tb_yljch_zhbzq  tb_yljch_yt,tb_yljch_zhbzq"
        sql3 &= " from tb_yljch where tb_yljch_id in(" & lastid & ") )  b "
        sql3 &= " on a.tb_i259b_num= b.tb_yljch_num where a.tb_i259b_ckcl>0  "
        Dim dt3 As DataTable = GF_CreateDataSource(G_cnnstr, sql3)
        With dt3
            For ii As Integer = 0 To .Rows.Count - 1
                If .Rows(ii)("最后异动时间").ToString = "" Then

                    Dim sql4 As String = "select  tb_i259b_rkrq from tb_i259b where  tb_i259b_id ='" & .Rows(ii)(0) & "' "
                    Dim dt4 As DataTable = GF_CreateDataSource(G_cnnstr, sql4) '入库时间
                    If IsDate(dt4.Rows(0)("tb_i259b_rkrq")) = True Then
                        .Rows(ii)("最后异动时间") = dt4.Rows(0)("tb_i259b_rkrq")
                        Dim dzdays As Integer = DateAndTime.DateDiff(DateInterval.Day, .Rows(ii)(9), CType(Now.Date, Date))
                        .Rows(ii)("呆滞天数") = dzdays
                    End If

                End If
            Next
           End With
        GroupBox1.Text = "有" & dt3.Rows.Count & "条数据"
        GS_DataGridViewbyDb(show1, dt3, True, True)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub
    'Private Function DistinctionDay(ByVal ts As Integer) As Boolean
    '    Dim dt As New DataTable
    '    dt = DeepCode.DeepDoGridView.ToDataTable(show1)
    '    Dim bds As String = "1=1"
    '    bds &= " and [呆滞天数] >=" & ts & " "
    '    '查询并得到结果DB
    '    Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt, bds)
    '    GS_DataGridViewbyDb(show1, dt2, True, True)
    '    Return True
    'End Function
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    DistinctionDay(180)
    'End Sub
    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    DistinctionDay(360)
    'End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        showsj()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        dt = DeepCode.DeepDoGridView.ToDataTable(show1)
        Dim bds As String = Creatbds() '产生表达式
        '查询并得到结果DB
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt, bds)
        GS_DataGridViewbyDb(show1, dt2, True, True)
    End Sub
    '置换表达式
    Private Function zhbds(ByVal zd As String, ByVal bd As String, ByVal wb As String) As String
        Dim ss As String = ""
        Dim bds As String = ""
        Select Case bd
            Case "大于", "小于", "不等于", "等于", "大于等于", "小于等于"
                If IsNumeric(wb) = False Then
                    MsgBox("您输入了非数字") : Return ""
                End If
            Case "之间"
                If InStr(wb, ",") = 0 Then
                    MsgBox("之间表达式应该这样填写：50,78") : Return ""
                End If
        End Select
        Select Case bd
            Case "大于" : ss = ">" : bds = zd & ss & wb
            Case "小于" : ss = "<" : bds = zd & ss & wb
            Case "不等于" : ss = "<>" : bds = zd & ss & wb
            Case "等于" : ss = "=" : bds = zd & ss & wb
            Case "大于等于" : ss = ">=" : bds = zd & ss & wb
            Case "小于等于" : ss = "<=" : bds = zd & ss & wb
            Case "之间"
                Dim sz1, sz2 As Double
                sz1 = DeepCode.DeepDoStr.GF_searchchar(wb, ",", "left")
                sz2 = DeepCode.DeepDoStr.GF_searchchar(wb, ",", "right")
                bds = zd & ">=" & sz1 & " and " & zd & "<=" & sz2
        End Select
        Return bds
    End Function
    Private Function Creatbds() As String
        Dim bdss As String = "1=1"
        '数字字段
        Dim cxzd3 As String = "[呆滞天数]"
            Dim sz As String = TextBox2.Text.Trim
            sz = Replace(sz, "，", ",") '怕出现中文逗号
            Dim nnn As String = zhbds(cxzd3, ComboBox4.Text, sz)
            If nnn <> "" Then
                bdss &= " and  " & zhbds(cxzd3, ComboBox4.Text, sz)
            End If
        Return bdss
    End Function
End Class