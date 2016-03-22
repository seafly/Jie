﻿Public Class Frddyxkc2
    Public dt As DataTable = Nothing

    Private Sub Frddyxkc2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Height = Me.Height * 3.5 / 4
    End Sub

    Private Sub Frddyxkc2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '''''''''''''''''''''''''''''''''''''''''''''''‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘得到qa为合格和待定的库存，以tb_x832pkc开头的为列名
        Dim sqlkc As String = "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_ckcl) from tb_x832pkc where tb_x832pkc_ckcl>0 and  tb_x832pkc_qaspjg ='合格' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm"
        sqlkc &= " union all "
        sqlkc &= " select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_ckcl)  from tb_h195zkc where tb_h195zkc_ckcl>0 and  tb_h195zkc_qaspjg ='合格' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm  "
        sqlkc &= " union all "
        sqlkc &= " select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_ckcl) from tb_x825pkc where tb_x825pkc_ckcl>0 and  tb_x825pkc_qaspjg ='合格' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm "
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqlkc)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sqlkc2 As String = "select tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm,sum(tb_x832pkc_ckcl) from tb_x832pkc where tb_x832pkc_ckcl>0 and  tb_x832pkc_qaspjg ='待定' group by tb_x832pkc_cplb,tb_x832pkc_mingc,tb_x832pkc_jiagdm"
        sqlkc2 &= " union all "
        sqlkc2 &= " select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,sum(tb_h195zkc_ckcl)  from tb_h195zkc where tb_h195zkc_ckcl>0 and  tb_h195zkc_qaspjg ='待定' group by tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm  "
        sqlkc2 &= " union all "
        sqlkc2 &= " select tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm,sum(tb_x825pkc_ckcl ) from tb_x825pkc where tb_x825pkc_ckcl>0 and  tb_x825pkc_qaspjg ='待定' group by tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm "
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqlkc2) '



        '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
        For i As Integer = 0 To dt.Rows.Count - 1
            Try
                Dim sql As String = "tb_x832pkc_cplb='" & dt.Rows(i)(0) & "' and tb_x832pkc_mingc='" & dt.Rows(i)(1) & "' and tb_x832pkc_jiagdm='" & dt.Rows(i)(2) & "'"
                Dim ckcl0 As DataRow() = dt1.Select(sql)
                If ckcl0.Length = 0 Then
                    dt.Rows(i)("有效库存") = 0 - dt.Rows(i)("未发货")
                Else
                    dt.Rows(i)("有效库存") = ckcl0(0)(3) - dt.Rows(i)("未发货")
                End If
                Dim ckcl2 As DataRow() = dt2.Select(sql)
                If ckcl2.Length = 0 Then
                    dt.Rows(i)("QA待定") = 0
                Else
                    dt.Rows(i)("QA待定") = ckcl2(0)(3)

                End If

            Catch ex As Exception
                'dt.Rows(i)("库存满足") = 0
                'dt.Rows(i)("缺货量") = dt.Rows(i)("tb_dd_jhl")
            End Try

        Next
        If Me.Text = "今日有效库存" And ToolStripLabel1.Text <> "" Then '如果是订单交付月报
            dt.Merge(dtsx(dt1, dt, dt2)) '合并没有订单代码的那些产品库存
        End If
        'show1.DataSource = dt
        If Me.Text = "今日有效库存" And ToolStripLabel1.Text = "" Then '如果是客户月发货统计 则不计算合计
            show1.DataSource = dt
        Else
            show1.DataSource = hj(dt, 0, 4, dt.Columns.Count - 1)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''变色
            For hhh As Integer = 0 To show1.RowCount - 1
                If show1.Rows(hhh).Cells(1).Value = "合计" Then
                    show1.Rows(hhh).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
        End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’隐藏
        For k As Integer = 0 To 3
            If k = 2 Or k = 1 Then
                Continue For
            End If
            show1.Columns(k).Visible = False
        Next
        GroupBox1.Text = "显示" & show1.RowCount & "条记录"
    End Sub
    Private Function hj(ByVal dt As DataTable, ByVal fzl As Integer, ByVal begincolums As Integer, ByVal endcoloums As Integer) As DataTable '按fzl列的datatable进行分组并插计算相应列的合计值
        Dim index As String = ""
        For i As Integer = 1 To dt.Rows.Count - 1
            If dt.Rows(i)(fzl) <> dt.Rows(i - 1)(fzl) Then
                index &= i.ToString & ","
            End If
        Next
        index &= dt.Rows.Count  '最后一行后面应该有一个合计行
        index = "0," & index
        Dim indexs As String() = index.Split(",")
        For j As Integer = 1 To indexs.Length - 1
            Dim beginrow As Integer
            Dim endrow As Integer
            'If j <> indexs.Length - 1 Then
            beginrow = indexs(j - 1) + j - 1
            endrow = indexs(j) + j - 2 '每插入一行 则索引行加1 行


            Dim dr As DataRow = dt.NewRow
            For k As Integer = begincolums To endcoloums '''''''''''''''''合计
                Dim hjz As Double = 0
                For hh As Integer = beginrow To endrow
                    hjz += CDbl(Null2zero2(dt.Rows(hh)(k)))
                Next
                dr(k) = hjz
            Next
            For kbl As Integer = 1 To begincolums - 1
                dr(kbl) = DBNull.Value
            Next
            dr(1) = "合计"
            If j <> indexs.Length - 1 Then
                dt.Rows.InsertAt(dr, indexs(j) + j - 1)
            Else
                dt.Rows.Add(dr)
            End If


        Next
        Return dt
    End Function

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, "今日有效库存", Me)
    End Sub
    Private Function dtsx(ByVal dt1 As DataTable, ByVal dt2 As DataTable, ByVal dt3 As DataTable) As DataTable
        dtsx = dt2.Clone
        For i As Int16 = 0 To dt1.Rows.Count - 1
            Dim sql As String = "产品类型='" & dt1.Rows(i)(0) & "' and 产品代码='" & dt1.Rows(i)(1) & "' and  加工代码='" & dt1.Rows(i)(2) & "'"
            Dim dtr As DataRow() = dt2.Select(sql)
            If dtr.Length = 0 Then
                Dim dtr1 As DataRow = dtsx.NewRow
                dtr1("产品类型") = dt1.Rows(i)(0) : dtr1("产品代码") = dt1.Rows(i)(1) : dtr1("加工代码") = dt1.Rows(i)(2) : dtr1("未发货") = 0
                dtr1("有效库存") = dt1.Rows(i)(3) : dtr1("QA待定") = Null2zero2(GF_cnwithen(dt3, sql, 3))
                dtsx.Rows.Add(dtr1)
            End If
        Next
        Return dtsx
    End Function

    Private Sub BtnDelLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelLock.Click
        Me.Close()
    End Sub
End Class