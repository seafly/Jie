Public Class Frddqhjf
    Dim dtall As DataTable = Nothing
    Dim qx As String = qxpd()
    Dim dtshow As DataTable = Nothing
    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub Frddqhjf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim sql2 As String = "select  tb_dd_ID,cast( tb_dd_ddgsyf as varchar ) as  tb_dd_ddgsyf ,tb_dd_ddh,tb_dd_pm,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddl,tb_dd_ddrq,tb_dd_bz,'' as '库存满足','' as '缺货量','' as 'QA待定',tb_dd_yfh,'' as '未发货量', tb_dd_jfwc,tb_dd_jdrq,tb_dd_sjdhrq  from tb_dd where (tb_dd_fhtjdh is null or tb_dd_fhtjdh='') " & qx & " order by tb_dd_jfwc,tb_dd_cplx,tb_dd_cpdm,tb_dd_jgdm,tb_dd_ddrq"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        dtall = dtjs(dt)
        dtall.DefaultView.Sort = "tb_dd_jfwc,tb_dd_ddgsyf,tb_dd_ddh"
        Dim dttemp As DataTable = Nothing

        If dtall.Rows.Count <= 30 Then
            tsl.Text = " （共有" & dtall.Rows.Count & "条记录）"
            dttemp = dtall.Copy '****************************下面负责把数据拷贝到临时表中来显示
        Else
            '****************************下面负责把数据的最近30条拷贝到临时表中来显示
            tsl.Text = " （共有" & dtall.Rows.Count & "条记录,只显示最近30条，你可以使用筛选功能筛选所有记录）"
            dttemp = dtall.Clone
            Dim p As DataRow
            For i As Integer = 0 To 29
                p = dttemp.NewRow
                For kk As Integer = 0 To dtall.Columns.Count - 1
                    p(kk) = dtall.Rows(i)(kk)
                Next
                dttemp.Rows.Add(p)
            Next
        End If
         GS_DataGridViewbyDb(show1, dttemp, True, True)

        show1.Columns("tb_dd_cplx").Visible = False
        ddgsyf()
        GroupBox1.Text = "共有" & show1.RowCount & "条记录"
        ComboBox2.Items.Clear() : ComboBox1.Items.Clear()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            'Dim zwmz As String = DeepCode.DeepDoDataTable.GF_cnwithen(G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4)
            'Dim bm As String = frdzxf.ddbm(dt.Columns(i).Caption) '得到表名
            'Dim bm As String = ddbm(dt.Columns(i).Caption) '得到表名
            Dim bmcn As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mc='" & dt.Columns(i).Caption & "'", 4) '得到表中文名称
            If bmcn = "" Then
                bmcn = dt.Columns(i).Caption
            End If
            'zwmz = bmcn & ":" & zwmz
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(bmcn)
                Case "System.DateTime" : ComboBox1.Items.Add(bmcn)

            End Select
        Next

    End Sub
    Private Function ddbm(ByVal str As String) As String '得到表名
        str = Replace(str, "tb_", "")
        str = GF_searchchar(str, "_", "left")
        ddbm = "tb_" & str
    End Function
    Private Sub wz()
        GroupBox1.Height = Me.Height - 180
        GroupBox1.Top = 180
    End Sub

    Private Sub Frddqhjf_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub TB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.Click
        GS_toexcel(show1, "订单缺货/交付查询", Me)
    End Sub
    Private Function dtjs(ByVal dt As DataTable) As DataTable '用于即时表的显示

        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’显示所有库存
        Try
            'Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_sykczl) from tb_x832pkc where tb_x832pkc_sykczl>0 and  tb_x832pkc_qaspjg ='合格' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm")

            'Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_sykczl)  from tb_h195zkc where tb_h195zkc_sykczl>0 and  tb_h195zkc_qaspjg ='合格' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm ") '‘’‘’‘’‘’‘’‘’成品油
            'dt1 = Frcgdhbb.dtshow(dt1, dt2)
            'dt2 = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_sykczl ) from tb_x825pkc where tb_x825pkc_sykczl>0 and  tb_x825pkc_qaspjg ='合格' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm ")
            'dt1 = Frcgdhbb.dtshow(dt1, dt2)

            Dim sqlkc As String = "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_ckcl) from tb_x832pkc where tb_x832pkc_ckcl>0 and  tb_x832pkc_qaspjg ='合格' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm"
            sqlkc &= " union all "
            sqlkc &= " select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_ckcl)  from tb_h195zkc where tb_h195zkc_ckcl>0 and  tb_h195zkc_qaspjg ='合格' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm  "
            sqlkc &= " union all "
            sqlkc &= " select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_ckcl ) from tb_x825pkc where tb_x825pkc_ckcl>0 and  tb_x825pkc_qaspjg ='合格' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm "
            Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqlkc)
            dtshow = dt1
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sqlkc2 As String = "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_ckcl) from tb_x832pkc where tb_x832pkc_ckcl>0 and  tb_x832pkc_qaspjg ='待定' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm"
            sqlkc2 &= " union all "
            sqlkc2 &= " select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_ckcl)  from tb_h195zkc where tb_h195zkc_ckcl>0 and  tb_h195zkc_qaspjg ='待定' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm  "
            sqlkc2 &= " union all "
            sqlkc2 &= " select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_ckcl ) from tb_x825pkc where tb_x825pkc_ckcl>0 and  tb_x825pkc_qaspjg ='待定' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm "
            Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqlkc2) '
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            '此处的dt1 是以tb_x832p 的列为架构的
            ''''''''''''''''''''‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
            For i As Integer = 0 To dt.Rows.Count - 1
                Try
                    If dt.Rows(i)("tb_dd_jfwc") <> "完成" Then
                        'Dim ckcl As Double = CDbl(DeepCode.DeepDoDataTable.GF_cnwithen(dt1, "tb_x832p_cplb='" & dt.Rows(i)("tb_dd_pm") & "',tb_x832p_mingc='" & dt.Rows(i)("tb_dd_cpdm") & "',tb_x832p_jiagdm='" & dt.Rows(i)("tb_dd_jgdm") & "'", 3))
                        Dim sql As String = "tb_x832pkc_cplb='" & dt.Rows(i)("tb_dd_cplx") & "' and tb_x832pkc_mingc='" & dt.Rows(i)("tb_dd_cpdm") & "' and tb_x832pkc_jiagdm='" & dt.Rows(i)("tb_dd_jgdm") & "'"
                        Dim ckcl0 As DataRow() = dt1.Select(sql)
                        dt.Rows(i)("未发货量") = dt.Rows(i)("tb_dd_ddl") - DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) '订单量-已发货

                        If ckcl0.Length = 0 Then
                            dt.Rows(i)("库存满足") = 0
                            dt.Rows(i)("缺货量") = 0 + DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) - dt.Rows(i)("tb_dd_ddl") '库存满足+已发货-订单量
                            If dt.Rows(i)("缺货量") < 0 Then ''如果缺货 则QA待定量为该代码qa待定的仓库存量
                                Dim ckcl2 As DataRow() = dt2.Select(sql)
                                If ckcl2.Length = 0 Then
                                    dt.Rows(i)("QA待定") = 0
                                Else
                                    dt.Rows(i)("QA待定") = ckcl2(0)(3)
                                End If


                            End If
                        Else
                            Dim kc As Double = ckcl0(0)(3) '库存
                            If kc < dt.Rows(i)("未发货量") Then
                                dt.Rows(i)("库存满足") = kc
                            Else
                                dt.Rows(i)("库存满足") = dt.Rows(i)("未发货量")
                            End If
                            If dt.Rows(i)("库存满足") + DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) - dt.Rows(i)("tb_dd_ddl") < 0 Then '缺货量=库存满足+已发货-订单量=库存满足-未发货
                                dt.Rows(i)("缺货量") = dt.Rows(i)("库存满足") + DeepCode.DeepDoStr.Null2zero(dt.Rows(i)("tb_dd_yfh")) - dt.Rows(i)("tb_dd_ddl") '库存满足+已发货-订单量
                                If dt.Rows(i)("缺货量") < 0 Then ''如果缺货 则QA待定量为该代码qa待定的仓库存量
                                    Dim ckcl2 As DataRow() = dt2.Select(sql)
                                    If ckcl2.Length = 0 Then
                                        dt.Rows(i)("QA待定") = 0
                                    Else
                                        dt.Rows(i)("QA待定") = ckcl2(0)(3)
                                    End If
                                End If
                            Else
                                dt.Rows(i)("缺货量") = 0
                            End If



                            ckcl0(0)(3) = kc - dt.Rows(i)("库存满足")
                        End If

                    End If
                Catch ex As Exception
                    'dt.Rows(i)("库存满足") = 0
                    'dt.Rows(i)("缺货量") = dt.Rows(i)("tb_dd_jhl")
                End Try

            Next
        Catch ex As Exception

        End Try


        Return dt
    End Function
    Private Sub ddgsyf() '将订单归属月份的显示格式变为yyyy-MM(即2011-4)
        For i As Integer = 0 To show1.RowCount - 1
            Try
                show1.Rows(i).Cells("tb_dd_ddgsyf").Value = Format(CDate(show1.Rows(i).Cells("tb_dd_ddgsyf").Value), "yyyy-MM")
            Catch ex As Exception
            End Try

        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt1 As DataTable = dtall.Copy
            'If kk <> "" And dt1.Rows.Count > 0 Then '求和的情况下少转化一行
            '    dt1.Rows.RemoveAt(dt1.Rows.Count - 1)
            'End If
            Dim bds As String = Creatbds() '产生表达式
            Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB
            show1.Columns.Clear() '避免头部消失
            show1.DataSource = dt2
           
            GS_TranEtoC(show1) '将DataGridView列字段翻译成为中文描叙
            show1.Columns("tb_dd_cplx").Visible = False
            ddgsyf()
            tsl.Text = " （共有" & dtall.Rows.Count & "条记录）"

        Catch ex As Exception

        End Try
        GroupBox1.Text = "共有" & show1.RowCount & "条记录"
    End Sub
    Private Function Creatbds() As String

        Dim bdss As String = "1=1"
        Dim cxzd1 As String = gettruezdm(ComboBox2.Text) '
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bdss &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim cxzd2 As String = gettruezdm(ComboBox1.Text) '
        If cxzd2 <> "" Then
            Dim tt1, tt2 As DateTime
            tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
           
            bdss &= " and  [" & cxzd2 & "] >='" & tt1 & "' and [" & cxzd2 & "] <='" & tt2 & "' "
        End If
       
        Return bdss

    End Function
    Private Function gettruezdm(ByVal str As String) As String
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_biao='tb_dd' and  tb_biaozdinf_mx='" & str & "'", 1) '得到英文字段名称
        If zd = "" Then
            zd = str
        End If
        Return zd
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        show1.DataSource = dtall
        GroupBox1.Text = "共有" & show1.RowCount & "条记录"
        tsl.Text = ""
    End Sub
    Private Function qxpd() As String
        Dim sql As String = "select tb_khyqqkyrb_ddgh from tb_khyqqkyrb group by tb_khyqqkyrb_ddgh"
        sql = GF_getstringsql(G_cnnstr, sql, ",")
        sql = "'" & Replace(sql, ",", "','") & "'"
        If InStr(sql, "'" & G_dlr & "|" & G_dlrgh & "'") <> 0 Then
            Return " and tb_dd_ddgh='" & G_dlr & "|" & G_dlrgh & "' "
        Else
            Return " and  (1=1) "
        End If

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim nfrom As New Frddyxkc2
        Dim nfrom As New Fryxkc
        nfrom.Text = "有效库存ATP"
        'Dim dtatp As DataTable = dtshow.copy
        'dtatp.Columns(0).ColumnName = "产品类型" : dtatp.Columns(1).ColumnName = "产品代码" : dtatp.Columns(2).ColumnName = "加工代码"
        'DeepCode.DeepDoDataTable.DelDataColAtIndex(dtatp, "3")
        'dtatp.Columns.Add("未发货") '此处为了节省代码，该列信息就是‘订单量-已发货量’
        'dtatp.Columns.Add("有效库存") : dtatp.Columns.Add("QA待定")
        'nfrom.dt = dtt(dtatp, show1.DataSource)
        nfrom.ToolStripLabel1.Text = ""
        Me.AddOwnedForm(nfrom)

        nfrom.Show()
    End Sub
    '''' <summary>
    ''''通过dtzh的值传到指定dtjg中 返回所需的datatable
    '''' </summary>
    '''' <param name="dtjg">需要的datatable的架构</param>
    '''' <param name="dtzh">拥有需要值的datatable</param>
    '''' <returns> 得到满足要求传递的datatable</returns>
    '''' <remarks></remarks>
    'Private Function dtt(ByVal dtjg As DataTable, ByVal dtzh As DataTable) As DataTable
    '    For k As Integer = 0 To dtjg.Rows.Count - 1
    '        Dim sl1 As Double = 0 : Dim sl2 As Double = 0
    '        Dim sql As String = "tb_dd_jfwc<>'完成'  and  tb_dd_cplx='" & dtjg.Rows(k)("产品类型") & "' and  tb_dd_cpdm ='" & dtjg.Rows(k)("产品代码") & "' and tb_dd_jgdm='" & dtjg.Rows(k)("加工代码") & "'"
    '        Dim dt As DataTable = GF_czmctb(dtzh, sql)
    '        For j As Integer = 0 To dt.Rows.Count - 1
    '            For i As Integer = 0 To dt.Columns.Count - 1
    '                If InStr(dt.Columns(i).ColumnName, "tb_dd_ddl") <> 0 Then
    '                    sl1 += dt.Rows(j)(i) '得到订单量之和
    '                End If
    '                If InStr(dt.Columns(i).ColumnName, "tb_dd_yfh") <> 0 Then
    '                    sl2 += dt.Rows(j)(i) '得到已发货数量之和
    '                End If
    '            Next
    '        Next
    '        dtjg.Rows(k)("未发货") = (sl1 - sl2).ToString
    '    Next
    '    Return dtjg
    'End Function
End Class