Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Fcglist
    '*********************************************************************************************************************
    ' 此模块为采购的添加主界面，由计划界面点击采购添加进入该界面，上表为请购表信息 ，下表为选择的采购信息，下表的最后两列记录sql语句用于储存记录和上表选中的记录的datarow
    '使用方法： 填写文本框中信息，点击确定，然后上表会显示请购信息，双击弹出采购的每条信息的添加界面确定后显示到下表，最后点提交，则完成全部采购添加过程
    '*********************************************************************************************************************
    Dim dt As DataTable '用于重置上表
    Dim dt2 As DataTable '用于改变计划的下面表
    Dim gys As DataTable = Nothing

    Private Sub wz()
        GroupBox3.Width = Me.Width - GroupBox1.Left - 20
        GroupBox1.Top = GroupBox3.Bottom + 10
        GroupBox1.Height = Me.Height - GroupBox1.Top - 40
        GroupBox1.Width = Me.Width - GroupBox1.Left - 20
        show2.Width = GroupBox1.Width - 10

    End Sub
    Private Sub Fcglist_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub Fcglist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        Select Case ComboBox1.Text
            Case "备品备件"
                Dim sql As String
                Dim dt As DataTable
                sql = "select top 1  tb_cg_cgdh from tb_cg where tb_cg_wpfl='备品备件' order by tb_cg_id desc"
                dt = GF_CreateDataSource(G_cnnstr, sql)
                If dt.Rows.Count = 0 Then
                    tb_cg_cgdh.Text = ""
                Else
                    tb_cg_cgdh.Text = dt.Rows(0)(0)
                End If

            Case Else

                Dim qztemp As String = ClassPhgn.ClassPhgn_Get("采购单号", "-") '得到当前批号+1的批号
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                tb_cg_cgdh.Text = qztemp

        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tb_cg_cgdh.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("请选择物品分类！") : Exit Sub
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''上表的显示
        Dim nform As Frjh = Me.Owner
        Dim dtgrid1 As DataGridView = nform.show1
        dt = dtgrid1.DataSource.copy
        If ComboBox1.Text = "备品备件" Then
            dt = DeepCode.DeepDoDataTable.GF_czmctb(dt, "tb_qgcg_wpfl='备品备件'")
        Else
            dt = DeepCode.DeepDoDataTable.GF_czmctb(dt, "tb_qgcg_wpfl<>'备品备件'")
        End If
        DeepCode.DeepDoDataTable.AddPrimaryKey(0, dt) '设置主键
        GS_DataGridViewbyDb(show1, dt, True, True)

        GroupBox3.Text = "共" & show1.RowCount & "条记录"
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''下表显示
        dtgrid1 = nform.show2
        dt2 = dtgrid1.DataSource
        Dim dt22 As DataTable = dt2.Clone '得到表架构
        dt22.Columns.Add("tb_xx_sql")
        dt22.Columns.Add("上表的datarow集合", GetType(Object))

        GS_DataGridViewbyDb(show2, dt22, True, True)

        For i As Integer = show2.Columns.Count - 2 To show2.Columns.Count - 1
            show2.Columns(i).Visible = False '隐藏最后两列（sql语句，上表的datarow集合）
        Next

        GroupBox1.Text = "共" & show2.RowCount & "条记录"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''筛选框的填充
        ComboBox3.Items.Clear()
        For i As Integer = 1 To dt.Columns.Count - 1 ' 0是主键
            If dt.Columns(i).DataType.ToString = "System.String" Then

                ComboBox3.Items.Add(show1.Columns(i).HeaderText)
            End If
        Next
        '''''''''''''''''''''''''''''''''商填充
        Dim sql As String = ""
        If ComboBox1.Text = "备品备件" Then
            sql = "select tb_gys_gys from tb_gys where tb_gys_fl='备品备件'"
        Else
            sql = "select tb_gys_gys from tb_gys where tb_gys_fl<>'备品备件'"
        End If
        gys = GF_CreateDataSource(G_cnnstr, sql)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ComboBox1.Enabled = False : tb_cg_cgdh.ReadOnly = True
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cxzd As String = ""
        For i As Integer = 1 To show1.Columns.Count - 1
            If show1.Columns(i).HeaderText = ComboBox3.Text Then
                cxzd = show1.Columns(i).Name
                Exit For
            End If
        Next
        Dim cxzfc As String = "1=1 "
        cxzfc &= "and " & cxzd & " like '%" & TextBox2.Text.Trim & "%'"
        Dim dtsx As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt, cxzfc)
        GS_DataGridViewbyDb(show1, dtsx, True, True)
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        show1.DataSource = dt
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
    End Sub

    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick
        Dim nform As New Frcgtj
        Me.AddOwnedForm(nform)
        Dim i As String = show1.SelectedRows(0).Cells(0).Value
        nform.id = i
        nform.tb_cg_sbid.Text = i
        nform.tb_cg_jhdh.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_jhdh").Value) '计划单号

        nform.tb_cg_qgbm.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgbm").Value
        nform.tb_cg_qgr.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgr").Value
        nform.tb_cg_gsmc.Text = show1.SelectedRows(0).Cells("tb_qgcg_gsmc").Value
        nform.tb_cg_dm.Text = show1.SelectedRows(0).Cells("tb_qgcg_dm").Value
        nform.tb_cg_pm.Text = show1.SelectedRows(0).Cells("tb_qgcg_pm").Value
        nform.tb_cg_ggxh.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_ggxh").Value)
        nform.tb_cg_dw.Text = show1.SelectedRows(0).Cells("tb_qgcg_dw").Value
        nform.tb_cg_wllb.Text = show1.SelectedRows(0).Cells("tb_qgcg_wllb").Value
        nform.tb_cg_qgsl.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgsl").Value
        nform.tb_cg_ysje.Text = show1.SelectedRows(0).Cells("tb_qgcg_ysje").Value
        nform.tb_cg_yqyt.Text = show1.SelectedRows(0).Cells("tb_qgcg_yqyt").Value
        nform.tb_cg_qgdsxrq.Text = DeepCode.DeepDoStr.Null2String(show1.SelectedRows(0).Cells("tb_qgcg_qgdsxrq").Value)
        nform.tb_cg_yqdhrq.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_yqdhrq").Value)
        nform.tb_cg_ysbm.Text = show1.SelectedRows(0).Cells("tb_qgcg_ysbm").Value
        nform.tb_cg_qgbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_bz").Value)
        nform.tb_cg_wpbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_wpbz").Value)
        nform.tb_cg_qgrq.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgrq").Value
        nform.tb_cg_qgzt.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgzt").Value
        nform.tb_cg_qgdsfsx.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgdsfsx").Value
        nform.tb_cg_dgzl.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgsl").Value
        nform.tb_cg_yjdhl1.Text = show1.SelectedRows(0).Cells("tb_qgcg_qgsl").Value
        nform.tb_cg_wpfl.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_wpfl").Value)
        nform.tb_cg_cgbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_qgcg_cgbz").Value)
        nform.tb_cg_cgdh.Text = tb_cg_cgdh.Text
        nform.gysdt = gys
        Try
            nform.tb_cg_dj.Text = Null2String(show2.Rows(show2.RowCount - 1).Cells("tb_cg_dj").Value)
            nform.tb_cg_rq.Text = Null2String(show2.Rows(show2.RowCount - 1).Cells("tb_cg_rq").Value)
            nform.tb_cg_gysmc.Text = Null2String(show2.Rows(show2.RowCount - 1).Cells("tb_cg_gysmc").Value)
            nform.tb_cg_qyfy.Text = Null2String(show2.Rows(show2.RowCount - 1).Cells("tb_cg_qyfy").Value)
            nform.tb_cg_zj.Text = Null2String(show2.Rows(show2.RowCount - 1).Cells("tb_cg_zj").Value)
            nform.tb_cg_fzr.Text = Null2String(show2.Rows(show2.RowCount - 1).Cells("tb_cg_fzr").Value)

        Catch ex As Exception
            Dim sql1 As String = "select top 1 tb_cg_dj,tb_cg_rq,tb_cg_gysmc,tb_cg_qyfy,tb_cg_zj,tb_cg_fzr from tb_cg order by tb_cg_id desc"
            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
            If dt1.Rows.Count <> 0 Then
                nform.tb_cg_dj.Text = dt1.Rows(0)(0)
                nform.tb_cg_rq.Text = dt1.Rows(0)(1)
                nform.tb_cg_gysmc.Text = dt1.Rows(0)(2)
                'tb_cg_dgzl.Text = dt1.Rows(0)(3)
                nform.tb_cg_qyfy.Text = dt1.Rows(0)(3)
                nform.tb_cg_zj.Text = dt1.Rows(0)(4)
                nform.tb_cg_fzr.Text = dt1.Rows(0)(5)
            End If
        End Try
        'nform.Label31.Visible = False
        'nform.tb_cg_sfbh.Visible = False
        'nform.tb_cg_cgdh.ReadOnly = True
        nform.tb_cg_sbid.Text = i
        nform.id = ""
        nform.ShowDialog()
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If show2.RowCount = 0 Then
            Return
        End If
        Dim f As Frjh = Me.Owner
        Dim dtgr As DataGridView = f.show1
        Dim dtx As DataTable = dtgr.DataSource
        Dim dtgr2 As DataGridView = f.show2
        'Dim dtx2 As DataTable = dtgr2.DataSource
        'dtx2 = dtshow(dtx2, show2.DataSource)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''更新
        Dim sql2 As String
        sql2 = "select tb_cg_ID,tb_cg_wpfl,tb_cg_cgdh,tb_cg_qgbm,tb_cg_qgr,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_qgsl,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_dhdh,tb_cg_yjdhrq1,tb_cg_yjdhl1 ,tb_cg_dw,tb_cg_wllb,tb_cg_wpbz,tb_cg_ysje,tb_cg_yqyt,tb_cg_qgbz,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_yszq1,tb_cg_ysbm ,tb_cg_sfbh,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_gsmc,tb_cg_jhdh,tb_cg_cgbz from tb_cg where tb_cg_xbid is null order by tb_cg_yqdhrq asc"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        dtgr2.DataSource = dt '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For i As Integer = 0 To show2.Rows.Count - 1
            Dim sql As String = Null2String(show2.Rows(i).Cells("tb_xx_sql").Value)
            If sql <> "" Then
                GS_upztxx(G_cnnstr, sql)
                Frjh.DelRow(dtx, show2.Rows(i).Cells(0).Value) '数据变化，少显示一行
            End If

        Next
        If ComboBox1.Text <> "备品备件" Then
            ClassPhgn.ClassPhgn_SetDqz2("采购单号") '使当前批号+1
        End If
      
        Me.Close()
    End Sub

    Private Sub show2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show2.DoubleClick
        Dim sy As String = show2.SelectedRows(0).Cells(0).Value
        Dim dtx1 As DataTable = show2.DataSource
        'Dim zhl As Integer '记录拆分的最后存入信息，因为该条记录存了sql语句和上表的行集合
        Dim syl As String = ""
        For j As Integer = 0 To dtx1.Rows.Count - 1
            If dtx1.Rows(j)(0) = sy Then
                syl &= j & ","
                'If Null2String(dtx1.Rows(j)("tb_xx_sql")) <> "" Then '
                '    zhl = j
                'End If
            End If
        Next
        syl = GF_removedh(syl) '‘’‘’‘得到相同主键的记录行
        Dim sysz As String() = syl.Split(",")
        For k As Integer = sysz.Length - 1 To 0 Step -1 '倒着删除行 无视索引变化
            'If sysz(k) = zhl Then '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’如果是拆分信息的最后输入的信息则还原上面表消失的记录
            Try
                Dim o As Object = show2.Rows(k).Cells("上表的datarow集合").Value

                'Dim f As Fcglist = Me.Owner
                'Dim dtgr As DataGridView = f.show1
                Dim dtx As DataTable = show1.DataSource
                Dim m As DataRow = dtx.NewRow
                For i As Integer = 0 To o.length - 1
                    m(i) = o(i)
                Next
                'Dim m As Object = CType(o, DataRow)
                dtx.Rows.Add(m)
            Catch ex As Exception

            End Try

            'End If
            dtx1.Rows(sysz(k)).Delete()

        Next
        dt.AcceptChanges()

      
        GroupBox3.Text = "共" & show1.RowCount & "条记录"
        GroupBox1.Text = "共" & show2.RowCount & "条记录"
    End Sub
    Private Function dtshow(ByVal dt As DataTable, ByVal dt2 As DataTable) As DataTable 'dt为主的datable， dt2要被和并到dt的datable
        Dim dr As DataRow
        For j As Integer = 0 To dt2.Rows.Count - 1
            dr = dt.NewRow() '一行一行循环填充
            For i As Integer = 0 To dt.Columns.Count - 1
                dr(i) = dt2.Rows(j)(i)
            Next
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function
End Class