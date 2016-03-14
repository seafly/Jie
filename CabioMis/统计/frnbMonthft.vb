Public Class frnbMonthft

    Private Sub frnbMonthft_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '显示上月的月份
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sj As Date
        If nian1.Text = "" Or yue1.Text = "" Then
            Exit Sub
        End If
        sj = nian1.Text & "-" & yue1.Text & "-25" '时间
        '检查数据是否填写完全
        With Me
            For j As Integer = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And .Controls(j).Name <> "tb_nhft_ID" Then
                    If Trim(.Controls(j).Text) = "" Then
                        MsgBox("请完整填写数据！")
                        Exit Sub
                    End If
                End If
            Next
        End With
        '以下计算总天数
        Dim zts As Integer
        zts = CInt(tb_nhft_Fdays.Text) + CInt(tb_nhft_Odays.Text) + CInt(tb_nhft_POdays.Text) + CInt(tb_nhft_PTdays.Text)
        '’‘’‘’‘’‘’‘’‘’‘日志与权限判断
        If GF_storelog2("设定能耗分摊：" & sj, "设定能耗分摊") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        If tb_nhft_ID.Text <> "" Then '修改
            Dim sql As String = "select * from tb_nhft where tb_nhft_id=" & tb_nhft_ID.Text
            RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            Dim j As Integer
            With Me
                For j = 0 To .Controls.Count - 1
                    RS("tb_nhft_rq").value = sj
                    RS("tb_nhft_Fft").value = CInt(tb_nhft_Fdays.Text) / zts '计算分摊系数
                    RS("tb_nhft_Oft").value = CInt(tb_nhft_Odays.Text) / zts
                    RS("tb_nhft_POft").value = CInt(tb_nhft_POdays.Text) / zts
                    RS("tb_nhft_PTft").value = CInt(tb_nhft_PTdays.Text) / zts
                    If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And .Controls(j).Name <> "tb_nhft_ID" Then
                        Dim zdsz As String = .Controls(j).Name
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).value = Trim(.Controls(j).Text)
                        End If
                    End If
                Next
            End With
            RS.update()
        Else '添加
            RS.open("tb_nhft", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            RS.addnew()
            Dim j As Integer
            With Me
                For j = 0 To .Controls.Count - 1
                    RS("tb_nhft_rq").value = sj
                    RS("tb_nhft_Fft").value = CInt(tb_nhft_Fdays.Text) / zts '计算分摊系数
                    RS("tb_nhft_Oft").value = CInt(tb_nhft_Odays.Text) / zts
                    RS("tb_nhft_POft").value = CInt(tb_nhft_POdays.Text) / zts
                    RS("tb_nhft_PTft").value = CInt(tb_nhft_PTdays.Text) / zts
                    If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" And .Controls(j).Name <> "tb_nhft_ID" Then
                        Dim zdsz As String = .Controls(j).Name
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).value = Trim(.Controls(j).Text)
                        End If
                    End If
                Next
            End With
            RS.update()
            ' GF_addsj = RS(Str() & "_id").value
        End If
        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
        MsgBox("操作成功！")
        Me.Close()
    End Sub

    Private Sub nian1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian1.SelectedValueChanged, yue1.SelectedValueChanged
        Dim sj As Date
        If nian1.Text = "" Or yue1.Text = "" Then
            Exit Sub
        End If
        sj = nian1.Text & "-" & yue1.Text & "-25" '时间
        Dim sql As String = "select * from tb_nhft where tb_nhft_rq='" & sj & "'"
        Dim nhb As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If nhb.Rows.Count > 0 Then
            tb_nhft_ID.Text = nhb.Rows(0)(0) '隐藏的id字段
            tb_nhft_Fdays.Text = nhb.Rows(0)(2)
            tb_nhft_Fcl.Text = nhb.Rows(0)(3)
            tb_nhft_Odays.Text = nhb.Rows(0)(5)
            tb_nhft_Ocl.Text = nhb.Rows(0)(6)
            tb_nhft_POdays.Text = nhb.Rows(0)(8)
            tb_nhft_POcl.Text = nhb.Rows(0)(9)
            tb_nhft_PTdays.Text = nhb.Rows(0)(11)
            tb_nhft_PTcl.Text = nhb.Rows(0)(12)
        Else
            tb_nhft_ID.Text = ""
            tb_nhft_Fdays.Text = "0"
            tb_nhft_Fcl.Text = "0"
            tb_nhft_Odays.Text = "0"
            tb_nhft_Ocl.Text = "0"
            tb_nhft_POdays.Text = "0"
            tb_nhft_POcl.Text = "0"
            tb_nhft_PTdays.Text = "0"
            tb_nhft_PTcl.Text = "0"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class