Public Class Frtb_pljh
    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 1, tb_pljh_cplb)
        'GS_wlbktlr2(tb_pljh_cplb, dt, 1, "")
    End Sub
    Private Sub tb_x832p_cplb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pljh_cplb.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, tb_pljh_mingc)
        'GS_wlbktlr2(tb_pljh_mingc, dt, 2, "")
    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pljh_mingc.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & tb_pljh_cplb.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_pljh_jiagdm)
    End Sub
    Private Sub kczl(ByVal str As String) '扣除零头重量,并关联到进出货表，参数是计划批次的ID
        Dim phxl() As String = id.Text.Split(",") '序列
        Dim phzl() As String = tb_pljh_phzl.Text.Split(",") '重量序列
        Dim sql As String = ""
        For i As Integer = 0 To UBound(phxl)
            sql &= "update tb_x832pkc set tb_x832pkc_sykczl=tb_x832pkc_sykczl-" & phzl(i) & " where tb_x832pkc_id='" & phxl(i) & "' " & vbCrLf
            sql &= "insert into tb_jch(tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_pljhid,tb_jch_czrgh,tb_jch_mingc,tb_jch_jiagdm)values"
            sql &= "('" & tb_pljh_cplb.Text & "','" & phxl(i) & "','出'," & phzl(i) & ",getdate(),'生产','成品粉混批计划'," & str & "," & G_dlrgh & ",'" & tb_pljh_mingc.Text & "','" & tb_pljh_jiagdm.Text & "')" & vbCrLf
        Next
        GS_upztxx(G_cnnstr, sql)
    End Sub
    Private Sub hyzl(ByVal str As String) '还原零头重量,并关联删除进出货表记录，参数是计划批次的ID
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_pljh_ph,tb_pljh_phzl from tb_pljh where tb_pljh_ID=" & Labelid.Text)
        Dim phxl() As String = dt.Rows(0)(0).Split(",") '批号序列
        Dim phzl() As String = dt.Rows(0)(1).Split(",") '重量序列
        Dim sql As String = ""
        For i As Integer = 0 To UBound(phxl)
            sql = sql & "update tb_x832pkc set tb_x832pkc_sykczl=tb_x832pkc_sykczl+" & phzl(i) & " where tb_x832pkc_num='" & phxl(i) & "' " & vbCrLf
        Next
        sql &= "delete from tb_jch where tb_jch_pljhid=" & str
        GS_upztxx(G_cnnstr, sql)
    End Sub
    Private Sub Frtb_pljh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        'Dim cplb As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_bhlb_mc from tb_bhlb")
        ''Call GS_wlbktlr2(tb_pljh_scdm, cplb, 0, "")
        'cplb = GF_CreateDataSource(G_cnnstr, "select tb_cplb_p512h from tb_cplb")
        'Call GS_wlbktlr2(tb_pljh_cplb, cplb, 0, "")
        Dim czid As String = Labelid.Text
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        Else
            '设定批号
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("成品粉混批计划", "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            tb_pljh_num.Text = qztemp
        End If
    End Sub
    Private Sub ltcsh33(ByVal db1 As DataTable, ByVal frlv1 As ListView, ByVal str0 As String, ByVal str1 As Integer, ByVal str2 As Integer, ByVal str3 As String, ByVal str4 As String)
        Dim strph() As String = Split(str3, ",")
        Dim strzl() As String = Split(str4, ",")
        With frlv1
            .Clear() : .Visible = True : .CausesValidation = False : .View = View.Details : .LabelEdit = True
            .BeginUpdate()
            .Columns.Add("提取数", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("大批批次", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("零头", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("ID", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            For i As Integer = 0 To db1.Rows.Count - 1
                .Items.Add(0)
                .Items(i).SubItems.Add(db1.Rows(i)(str1))
                .Items(i).SubItems.Add(db1.Rows(i)(str2))
                .Items(i).SubItems.Add(db1.Rows(i)(2))
            Next
            .EndUpdate()

            For i As Integer = 0 To strph.Length - 1
                For j As Integer = 0 To .Items.Count - 1
                    If .Items(j).SubItems(1).Text = strph(i) Then
                        .Items(j).SubItems(0).Text = strzl(i)
                        GoTo XXX
                    End If
                Next
XXX:
            Next
        End With
    End Sub

    Private Sub tb_pljh_ph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_pljh_ph.DoubleClick
        Dim aa As New Frphzl2 : Me.AddOwnedForm(aa)
        '条件是剩余库存大于0，用途为生产，QA为合格
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_x832pkc_num,tb_x832pkc_sykczl,tb_x832pkc_id from tb_x832pkc where (tb_x832pkc_qaspjg='合格' or tb_x832pkc_qaspjg='返工') and tb_x832pkc_sykczl>0 and tb_x832pkc_yg='生产' ")
        Call ltcsh33(dt1, aa.ListView1, "", 0, 1, tb_pljh_ph.Text, tb_pljh_phzl.Text)
        aa.ShowDialog()
        tb_pljh_ph.Text = ph.Text : tb_pljh_phzl.Text = zl.Text
        ph.Text = "" : zl.Text = ""
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If GF_YZSJ(Me, "tb_pljh_bz") = False Then '验证控件
            Exit Sub
        End If
        ''''''''''''''''''''''''、

        If Labelid.Text <> "" Then
            ''''''''''''''''''''日志
            If GF_storelog1("修改成品粉混批计划") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                MsgBox("请检查输入项目及数据")
                Exit Sub
            Else
                hyzl(Labelid.Text) '还原零头重量,并关联删除进出货表记录
                kczl(Labelid.Text) '扣除零头重量,并关联到进出货表
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                GS_storelog3("修改成品粉混批计划：" & tb_pljh_num.Text.Trim, "修改成品粉混批计划") '储存到日志
            End If
        Else
            ''''''''''''''''''''日志
            If GF_storelog1("添加成品粉混批计划") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            Else
                kczl(jj) '扣除零头重量,并关联到进出货表
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
                ClassPhgn.ClassPhgn_SetDqz2("成品粉混批计划") '使当前批号+1
                GS_storelog3("添加成品粉混批计划：" & tb_pljh_num.Text.Trim, "添加成品粉混批计划") '储存到日志
            End If
        End If
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
End Class