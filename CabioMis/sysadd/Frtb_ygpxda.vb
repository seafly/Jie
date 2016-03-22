Public Class Frtb_ygpxda
    'Dim G_cnnstr_K3 As String
    Private Sub Frtb_ygpxda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_wlbktlr3(tb_ygpxda_pxlb, G_PXLB, "") '构建培训类别下拉
        Dim czid As String = Labelid.Text
        tb_ygpxda_pxcj.Text = "----"
        tb_ygpxda_pxcj.Enabled = False
        If czid <> "" Then
            showsj(Labeltb.Text, Labelid.Text)
            Button1.Visible = True
            Me.CheckBox1.Visible = True
        End If
     
        tb_ygpxda_czrgh.Text = G_dlrgh
        GS_qhjd(Me) '回车键切换焦点，备注除外
        ''K3
        'Dim yhm, mm, sjk, fwq As String
        'Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\K3connet.ini")
        '    yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = sr.ReadLine() : fwq = sr.ReadLine() : sr.Close()
        'End Using
        'G_cnnstr_K3 = "Provider=sqloledb; User ID=" & yhm & "; Password=" & mm & "; Initial Catalog=" & sjk & "; Data Source=" & fwq
    End Sub

    Private Sub showsj(ByVal str As String, ByVal str3 As String)
        '分别代表表名。窗体名，ID值

        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        cnn.ConnectionString = G_cnnstr
        cnn.Open()
        Dim sql As String = "select * from " & str & " where " & str & "_id=" & str3
        Dim RS = cnn.execute(sql)
        Dim j As Integer, nn As DateTimePicker
        With Me
            TextBox1.Text = RS("tb_ygpxda_xm").value '姓名
            TextBox2.Text = RS("tb_ygpxda_bumen").value '部门
            TextBox3.Text = RS("tb_ygpxda_xingbie").value '性别
            If RS("tb_ygpxda_sfkh").value = "未考核" Then
                tb_ygpxda_sfkh.Checked = False
                tb_ygpxda_pxcj.Text = "----"
                tb_ygpxda_pxcj.Enabled = False
            ElseIf RS("tb_ygpxda_sfkh").value = "考核" Then
                tb_ygpxda_sfkh.Checked = True
                tb_ygpxda_pxcj.Text = ""
                tb_ygpxda_pxcj.Enabled = True
            End If

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

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If tb_ygpxda_pxcj.Text = "" And tb_ygpxda_sfkh.Checked = True Then
            MsgBox("请填写考核成绩") : Exit Sub

        End If
        If tb_ygpxda_rq.Text = "" Or tb_ygpxda_jssj.Text = "" Then
            MsgBox("请填写培训开始、结束时间") : Exit Sub

        End If
        If tb_ygpxda_dd.Text = "" Or tb_ygpxda_kc.Text = "" Or tb_ygpxda_kd.Text = "" Or tb_ygpxda_js.Text = "" Or TextBox1.Text = "" Then
            MsgBox("请填写地点、讲师、课程、课时、姓名") : Exit Sub

        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim cnn2 = CreateObject("ADODB.Connection") : Dim RS2 = CreateObject("ADODB.Recordset")
        'Try
        '    cnn2.ConnectionString = G_cnnstr_K3 : cnn2.ConnectionTimeout = 8 : cnn2.Open()
        'Catch ex As Exception
        '    MsgBox("K3数据库设置错误，请检查") : Exit Sub
        'End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改CABIO员工培训档案") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            'If GF_modsj_k3(Labeltb.Text, Me, Labelid.Text) = False Then
            '    MsgBox("请检查输入项目及数据和K3数据库设置") : Exit Sub
            'End If
            If G_js <> "人事培训" Then
                If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                    Exit Sub
                End If ' 判断是否有权限
            End If

            GS_modczsj2(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号

            Try
                If Me.CheckBox1.Checked = True Then
                    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_ygpxda_ID from tb_ygpxda where tb_ygpxda_rq=(select tb_ygpxda_rq from tb_ygpxda where tb_ygpxda_id=" & Labelid.Text & ")")
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim sql As String = "update  tb_ygpxda set "
                        sql = sql & " tb_ygpxda_rq='" & tb_ygpxda_rq.Text & "',"
                        sql = sql & " tb_ygpxda_jssj='" & tb_ygpxda_jssj.Text & "',"
                        sql = sql & " tb_ygpxda_pxsj='" & tb_ygpxda_pxsj.Text & "',"
                        sql = sql & " tb_ygpxda_dd='" & tb_ygpxda_dd.Text & "',"
                        sql = sql & " tb_ygpxda_js='" & tb_ygpxda_js.Text & "',"
                        sql = sql & " tb_ygpxda_kc='" & tb_ygpxda_kc.Text & "',"
                        sql = sql & " tb_ygpxda_kd=" & tb_ygpxda_kd.Text & ","
                        sql = sql & " tb_ygpxda_bz='" & tb_ygpxda_bz.Text & "',"
                        sql = sql & " tb_ygpxda_czrgh='" & G_dlrgh & "',"
                        sql = sql & " tb_ygpxda_pxlb='" & tb_ygpxda_pxlb.Text & "' "
                        sql = sql & " where tb_ygpxda_id=" & dt.Rows(i)(0)
                        GS_upztxx(G_cnnstr, sql)
                    Next
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If


            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改CABIO员工培训档案：" & TextBox1.Text, "修改CABIO员工培训档案") '储存到日志
        Else

            '''''''''''''''''''''''''''''
            'If GF_storelog1("添加CABIO员工培训档案") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim ry(), bm(), xb(), gd() As String
            ry = Split(TextBox1.Text, ",") : bm = Split(TextBox2.Text, ",")
            xb = Split(TextBox3.Text, ",") : gd = Split(TextBox4.Text, ",")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection) : Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
            cnn.ConnectionString = G_cnnstr : cnn.Open()
            ''''''''''''''''''''''
            For m As Integer = 0 To UBound(ry)
                tb_ygpxda_xm.Text = ry(m) : tb_ygpxda_bumen.Text = bm(m)
                tb_ygpxda_xingbie.Text = xb(m) : tb_ygpxda_gd.Text = gd(m)
                RS.open("tb_ygpxda", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                RS.addnew()
                'RS2.open("tb_ygpxda", cnn2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                'RS2.addnew()
                For j As Integer = 0 To Controls.Count - 1
                    If Microsoft.VisualBasic.Left(Controls(j).Name, 10) = "tb_ygpxda_" Then
                        Dim zdsz As String = Controls(j).Name
                        If Trim(Controls(j).Text) <> "" Then
                            RS(zdsz).value = Trim(Controls(j).Text)
                            'RS2(zdsz).value = Trim(Controls(j).Text)
                        End If
                    End If
                Next
                RS.Update()
                Dim czid As String = RS(0).value : RS.close()
                ''''''''''''''''''''''''''''''''''''''''''''''
                'RS2("tb_ygpxda_czid").value = czid '将Mis数据库中id存入K3
                'RS2.Update() : RS2.close()
                ''''''''''''''''''''''''''''''''''''''
            Next
            RS = Nothing : cnn = Nothing
            '''''''''''''''''''''''''''''''''''''
            'RS2 = Nothing : cnn2 = Nothing
            '''''''''''''''''''''''''''''''''''''''''''''''''''

            ''以下更新K3数据库
            'cnn = CreateObject("ADODB.Connection")
            'cnn.ConnectionString = G_cnnstr_K3
            'cnn.Open()
            'RS = CreateObject("ADODB.Recordset")
            'RS.open("tb_ygpxda", cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            'RS.addnew()
            'For j As Integer = 0 To Controls.Count - 1
            '    If Microsoft.VisualBasic.Left(Controls(j).Name, 10) = "tb_ygpxda_" Then
            '        Dim zdsz As String = Controls(j).Name
            '        If Trim(Controls(j).Text) <> "" Then
            '            RS(zdsz).value = Trim(Controls(j).Text)
            '        End If
            '    End If
            '   
            'Next

            'RS.Update()
            'RS.close()

        End If
        GS_storelog3("添加CABIO员工培训档案：" & TextBox1.Text, "添加CABIO员工培训档案") '储存到日志
        MsgBox("操作成功")
        Me.Close()

    End Sub
    '更新操作记录的某个字段数据,str表，str2字段，str3表示ID，str4表示更新内容
    Public Sub GS_modczsj2(ByVal strtb As String, ByVal strzd As String, ByVal strid As String, ByVal str4 As String)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim cnn2 = CreateObject("ADODB.Connection") : Dim RS2 = CreateObject("ADODB.Recordset")
        'Try
        '    cnn2.ConnectionString = G_cnnstr_K3 : cnn2.ConnectionTimeout = 8 : cnn2.Open()
        'Catch ex As Exception
        '    MsgBox("K3数据库设置错误，请检查") : Exit Sub
        'End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
        'cnn.ConnectionString = G_cnnstr_K3 : cnn.ConnectionTimeout = 8
        'cnn.Open()
        'Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)

        'Dim sql As String = "select * from " & strtb & " where " & strtb & "_id=" & strid
        'RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        ''RS2.open(sql, cnn2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        'RS(strzd).value = GF_ToDBC(str4)
        ''RS2(strzd).value = GF_ToDBC(str4)
        'RS.update() : RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
        'RS2.update() : RS2.close() : RS2 = Nothing : cnn2.close() : cnn2 = Nothing
    End Sub
    'Public Function GF_modsj_k3(ByVal str As String, ByVal str2 As Form, ByVal str3 As String) As Boolean
    '    '分别代表表名。窗体名，ID值
    '    Try
    '        Dim cnn As ADODB.Connection = CType(CreateObject("ADODB.Connection"), ADODB.Connection)
    '        cnn.ConnectionString = G_cnnstr_K3 : cnn.ConnectionTimeout = 8
    '        cnn.Open()
    '        Dim RS As ADODB.Recordset = CType(CreateObject("ADODB.Recordset"), ADODB.Recordset)
    '        Dim sql As String = "select * from " & str & " where " & str & "_id=" & str3

    '        RS.open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
    '        Dim j As Integer, nn As DateTimePicker
    '        With str2
    '            For j = 0 To .Controls.Count - 1
    '                If Microsoft.VisualBasic.Left(.Controls(j).Name, 3) = "tb_" Then
    '                    Dim zdsz As String = .Controls(j).Name
    '                    If .Controls(j).GetType.Name = "DateTimePicker" Then
    '                        nn = .Controls(j)
    '                        If nn.Checked = True Then
    '                            RS(zdsz).value = GF_gettrqsj(nn.Text)
    '                        Else
    '                            RS(zdsz).value = Nothing
    '                        End If
    '                    Else
    '                        If Trim(.Controls(j).Text) <> "" Then
    '                            RS(zdsz).value = GF_ToDBC(Trim(.Controls(j).Text))
    '                        Else
    '                            RS(zdsz).value = Nothing
    '                        End If
    '                    End If
    '                End If
    '            Next
    '        End With

    '        RS.update() : RS.close() : RS = Nothing : cnn.close() : cnn = Nothing
    '        GF_modsj_k3 = True
    '    Catch ex As Exception
    '        GF_modsj_k3 = False
    '    End Try
    'End Function
    Private Sub tb_ygpxda_sfkh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_ygpxda_sfkh.CheckedChanged
        If tb_ygpxda_sfkh.Checked = False Then
            tb_ygpxda_sfkh.Text = "未考核"
            tb_ygpxda_pxcj.Text = "----"
            tb_ygpxda_pxcj.Enabled = False
        Else
            tb_ygpxda_sfkh.Text = "考核"
            tb_ygpxda_pxcj.Text = ""
            tb_ygpxda_pxcj.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        ''''''''''''''''''''日志权限判断
        If GF_storelog1("删除CABIO员工培训档案") = False Then
            Exit Sub
        End If ' 判断是否有权限
        '''''''''''''''''''''
        'Try
        'Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_czid=" & Labelid.Text
        'GS_upztxx(G_cnnstr_K3, sql)
        Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("删除CABIO员工培训档案：" & TextBox1.Text, "删除CABIO员工培训档案") '储存到日志
        MsgBox("操作成功") : Me.Close()
        'Catch ex As Exception
        '    MsgBox("数据库设置出错")
        'End Try


    End Sub
    '修改数据库设置
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    FrK3connect.ShowDialog()
    '    Me.Close()
    'End Sub

    Private Sub TextBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.DoubleClick
        Dim aa As New Frtb_ygpxda2
        Me.AddOwnedForm(aa)
        aa.Label1.Text = TextBox1.Text
        aa.ShowDialog()
    End Sub

    
End Class