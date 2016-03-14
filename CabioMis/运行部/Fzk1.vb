Public Class Fzk1

    Private Sub Fzk1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '''''''''''''''''''''''''''''''''''上面显示
        showsb()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''下面显示
        showsearch()
    End Sub
    '转库入库
    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        Dim nform As New frzk2
        nform.id = ""
        nform.num = show1.SelectedRows(0).Cells("tb_ylzk_num").Value
        nform.dm = show1.SelectedRows(0).Cells("tb_ylzk_yldm2").Value
        '根据批号和代码在另一个工厂的数据库中的原料表中寻找相应信息
        showsj(G_cnnstrWH, "tb_i259b", nform, show1.SelectedRows(0).Cells("tb_ylzk_num").Value, show1.SelectedRows(0).Cells("tb_ylzk_yldm2").Value)
        nform.tb_i259b_p518h.Text = show1.SelectedRows(0).Cells("tb_ylzk_rkl").Value
        nform.ShowDialog()
        showsb()
        showsearch()
    End Sub
    Private Sub showsj(ByVal cnnstr As String, ByVal str As String, ByVal str2 As Form, ByVal str3 As String, ByVal str4 As String)
        '分别代表表名。窗体名，ID值

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = cnnstr
        cnn.Open()
        Dim sql As String = "select * from " & str & " where " & str & "_num='" & str3 & "' and  " & str & "_i231a= '" & str4 & "' "
        Dim RS = cnn.execute(sql)
        If RS.eof Or RS.bof Then
            Return
        End If
        Dim j As Integer, nn As DateTimePicker
        With str2
            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
                    Dim zdsz As String = .Controls(j).Name
                    Dim sj As String = ""
                    If IsDBNull(RS(zdsz).value) = False Then
                        sj = RS(zdsz).value
                    End If
                    If .Controls(j).GetType.Name = "DateTimePicker" Then
                        nn = .Controls(j)
                        If sj <> "" Then
                            nn.Text = sj
                            If nn.ShowCheckBox = True Then
                                nn.Checked = True
                            End If
                        Else
                            If nn.ShowCheckBox = True Then
                                nn.Checked = False
                            End If
                        End If
                    End If
                    .Controls(j).Text = sj
                End If
            Next
        End With
        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        showsearch()
    End Sub
    Private Sub wz()

        GroupBox2.Top = GroupBox1.Bottom + 50
        GroupBox2.Height = Me.Height - GroupBox2.Top - 40
        GroupBox2.Width = Me.Width - GroupBox2.Left - 20
        GroupBox1.Width = GroupBox2.Width
    End Sub

    Private Sub Fzk1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub


    Private Sub showsearch()
        Dim sql As String
        Dim dt As DataTable
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker4.Text : tt2 = DateTimePicker3.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If

        Sql = "select tb_yljch.tb_yljch_ID,tb_yljch.tb_yljch_yllb,tb_yljch.tb_yljch_dm,tb_yljch.tb_yljch_mc,tb_yljch.tb_yljch_jhdh,tb_yljch.tb_yljch_num,tb_yljch.tb_yljch_sl,tb_yljch.tb_yljch_rq,tb_yljch.tb_yljch_gg,tb_yljch.tb_yljch_dw,tb_yljch.tb_yljch_yt,tb_yljch.tb_yljch_bz,tb_yljch.tb_yljch_czrgh,tb_yljch.tb_yljch_xgsm,tb_yljch.tb_yljch_cz from tb_yljch ,tb_ylzk  "
        Sql &= "where tb_yljch_rq between  '" & tt1 & "' and '" & tt2 & "' and tb_ylzk.tb_ylzk_yldm = tb_yljch.tb_yljch_dm And tb_yljch.tb_yljch_num = tb_ylzk.tb_ylzk_num and tb_yljch.tb_yljch_cz='进' "
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBox1, TextBox1) '文本查询函数：挂接到查询文本
        Sql &= sqlbdssep
        dt = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, Sql)
        GS_DataGridViewbyDb(DataGridView1, dt, True, True)
        GroupBox2.Text = "武汉物料进出货：" & dt.Rows.Count & "条记录"
        GS_FaceSearch(ComboBox1, "tb_yljch", 1) '添加原料进出货下拉框
    End Sub
    Private Sub showsb()
        Dim sql As String = "select * from tb_ylzk where tb_ylzk_rkl>0 "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(show1, dt, True, True)
    End Sub

    Private Sub BtnDelLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelLock.Click
        Me.Close()
    End Sub
End Class