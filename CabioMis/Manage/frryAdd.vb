Public Class frryAdd
    'Public ryid As String = ""
    Public gh As String = ""
    Private Sub frryAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        Call GS_wlbktlr2(tb_yg_v753n, G_bm, 1, "")
        Call GS_wlbktlr2(tb_yg_bmgd, GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd"), 1, "")

        tb_yg_m381e.SelectedIndex = 0
        If gh <> "" Then
            showsj(G_cnnstr, "tb_yg", Me, gh) : tb_yg_n430f.ReadOnly = True
        End If
    End Sub

    '添加
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tb_yg_w779o.Text.Trim = "" Or tb_yg_n430f.Text.Trim = "" Then
            MsgBox("人员姓名和工号不能空") : Exit Sub
        End If
        If gh = "" Then
            Dim sql As String = "select tb_yg_id from tb_yg where tb_yg_n430f='" & tb_yg_n430f.Text.Trim & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count > 0 Then
                MsgBox("数据库里面有该工号，不能添加！") : Exit Sub
            End If

            If GF_storelog2("添加人员，工号:" & tb_yg_n430f.Text.Trim, "人员管理") = False Then
                MsgBox("您的权限不够！") : Exit Sub
            End If   '生成日志
            Dim jj As String = addsj(G_cnnstrWH, "tb_yg", Me)
            Dim jj2 As String = addsj(G_cnnstr, "tb_yg", Me)
            If jj = "" Or jj2 = "" Then
                MsgBox("添加数据出错") : Exit Sub
            End If
            'gxqx(jj)
        Else
            If GF_storelog2("修改人员，工号:" & tb_yg_n430f.Text.Trim, "人员管理") = False Then
                MsgBox("您的权限不够！") : Exit Sub
            End If   '生成日志

            If modsj(G_cnnstrWH, "tb_yg", Me, gh) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            If modsj(G_cnnstr, "tb_yg", Me, gh) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            'gxqx(ryid)
        End If
        Me.Close()
    End Sub
    '''''下面更新权限与登陆界面
    'Private Sub gxqx(ByVal str1 As String)
    '    Dim dljm, qx As String
    '    Dim sql As String = "select tb_js_qx,tb_js_jm from tb_js where tb_js_mc='" & tb_yg_js.Text & "' "
    '    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    '    dljm = dt.Rows(0)(1) : qx = dt.Rows(0)(0)
    '    GS_upztxx(G_cnnstr, "update tb_yg set tb_yg_dl='" & dljm & "',tb_yg_quan='" & qx & "' where tb_yg_id='" & str1 & "'")
    'End Sub
    '关闭
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

#Region "添加修改删除"
    Private Function addsj(ByVal cnnstr As String, ByVal str As String, ByVal str2 As Form) As String
        ' 分别代表表名。窗体名
        'Try
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        RS.open(str, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        RS.addnew()
        Dim j As Integer, nn As DateTimePicker
        With str2
            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
                    Dim zdsz As String = .Controls(j).Name
                    If .Controls(j).GetType.Name = "DateTimePicker" Then

                        nn = .Controls(j)
                        If nn.Checked = True Then
                            RS(zdsz).value = GF_gettrqsj(nn.Text)
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).value = GF_ToDBC(Trim(.Controls(j).Text))
                        End If
                    End If
                End If
            Next
        End With
        RS.update()
        addsj = RS(str & "_id").value
        RS.close() : RS = Nothing : cnn.close() : cnn = Nothing

    End Function
    Private Function modsj(ByVal cnnstr As String, ByVal str As String, ByVal str2 As Form, ByVal str3 As String) As Boolean
        '分别代表表名。窗体名，ID值
        'Try
        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = cnnstr
        cnn.Open()
        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
        Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & str3 & "'"
        RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim j As Integer, nn As DateTimePicker
        With str2
            For j = 0 To .Controls.Count - 1
                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
                    Dim zdsz As String = .Controls(j).Name
                    If .Controls(j).GetType.Name = "DateTimePicker" Then
                        nn = .Controls(j)
                        If nn.Checked = True Then
                            RS(zdsz).value = GF_gettrqsj(nn.Text)
                        Else
                            RS(zdsz).value = Nothing
                        End If
                    Else
                        If Trim(.Controls(j).Text) <> "" Then
                            RS(zdsz).value = GF_ToDBC(Trim(.Controls(j).Text))
                        Else
                            RS(zdsz).value = Nothing
                        End If
                    End If
                End If
            Next
        End With

        RS.update() : RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
        modsj = True

    End Function
    Private Sub showsj(ByVal cnnstr As String, ByVal str As String, ByVal str2 As Form, ByVal str3 As String)
        '分别代表表名。窗体名，ID值

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = cnnstr
        cnn.Open()
        Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & str3 & "'"
        Dim RS = cnn.execute(sql)
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
#End Region
End Class