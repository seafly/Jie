﻿Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frcgtj
    Public id As String = ""
    Private v As AutoCompleteStringCollection = New AutoCompleteStringCollection()
    Dim dgzl As String = Nothing
    Dim TB_SQL As String = Nothing
    Public gysdt As DataTable = Nothing
    Private Sub Frcgtj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_cg_fqcs.SelectedIndex = 0
        tb_cg_qyfy.Text = 0
        tb_cg_fzr.SelectedIndex = 0
        tb_cg_yszq1.Text = 3
        tb_cg_yszq2.Text = 3
        tb_cg_yszq3.Text = 3
     
        For i As Integer = 0 To gysdt.Rows.Count - 1
            tb_cg_gysmc.Items.Add(gysdt.Rows(i)(0))
            v.Add(gysdt.Rows(i)(0))
            tb_cg_gysmc.AutoCompleteCustomSource = v
        Next
     
    End Sub
    Private Sub tb_cg_fqcs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cg_fqcs.SelectedIndexChanged
        cf()
    End Sub
    Private Sub cf()
        '不同拆分批次  日期数量的不同显示
        Select Case tb_cg_fqcs.SelectedIndex
            Case 0
                tb_cg_yjdhrq1.Enabled = True
                tb_cg_yjdhl1.Enabled = True
                tb_cg_yjdhrq2.Enabled = False
                tb_cg_yjdhl2.Enabled = False
                tb_cg_yjdhrq3.Enabled = False
                tb_cg_yjdhl3.Enabled = False
                tb_cg_yszq1.Enabled = True
                tb_cg_yszq2.Enabled = False
                tb_cg_yszq3.Enabled = False

            Case 1
                tb_cg_yjdhrq1.Enabled = True
                tb_cg_yjdhl1.Enabled = True
                tb_cg_yjdhrq2.Enabled = True
                tb_cg_yjdhl2.Enabled = True

                tb_cg_yjdhrq3.Enabled = False
                tb_cg_yjdhl3.Enabled = False
                tb_cg_yszq1.Enabled = True
                tb_cg_yszq2.Enabled = True
                tb_cg_yszq3.Enabled = False

            Case 2
                tb_cg_yjdhrq1.Enabled = True
                tb_cg_yjdhl1.Enabled = True
                tb_cg_yjdhrq2.Enabled = True
                tb_cg_yjdhl2.Enabled = True
                tb_cg_yjdhrq3.Enabled = True
                tb_cg_yjdhl3.Enabled = True
                tb_cg_yszq1.Enabled = True
                tb_cg_yszq2.Enabled = True
                tb_cg_yszq3.Enabled = True

        End Select

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定" & tb_cg_fqcs.Text, 1, "提示") <> 1 Then
            Exit Sub
        End If
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If


        If CDbl(tb_cg_dgzl.Text) * 1 = 0 Then
            Dim dResult As DialogResult = MessageBox.Show("如果订购总量为0，则请购数量也同时为0,您确定完成此操作吗？", "系统提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            Dim bz As String = ""
            If dResult <> Windows.Forms.DialogResult.Yes Then
                tb_cg_dgzl.Text = dgzl
                Exit Sub
            Else
                bz = InputBox("请输入原因！", "系统提示：")
                If bz = "" Then
                    MsgBox("请填写备注！")
                    tb_cg_dgzl.Text = dgzl
                    Exit Sub
                Else
                    tb_cg_qgsl.Text = "0"
                End If
            End If
            tb_cg_cgbz.Text = bz & vbCrLf & tb_cg_cgbz.Text
        End If


        If GF_YZSJ(Me, "tb_xx_sql,tb_cg_ggxh,tb_cg_yjdhl2,tb_cg_yjdhl3,tb_cg_yjdhrq2,tb_cg_yjdhrq3,tb_cg_yszq2,tb_cg_yszq3,tb_cg_dhdh,tb_cg_sfbh,tb_cg_wpbz,tb_cg_qgbz,tb_cg_cgbz") = False Then '验证控件
            Exit Sub
        End If

        Dim g As String = tb_cg_gysmc.Text
        Dim h As String = tb_cg_wpfl.Text
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_gys_gys from tb_gys where 1=1 and  tb_gys_gys='" & g & "' and tb_gys_fl='" & h & "'")

        If dt.Rows.Count = 0 Then
            'GS_upztxx(G_cnnstr, "insert into tb_gys(tb_gys_gys,tb_gys_fl) values ('" & g & "','" & h & "')")
            TB_SQL = "insert into tb_gys(tb_gys_gys,tb_gys_fl) values ('" & g & "','" & h & "')"
        End If
        dhgz(TB_SQL)
      
        
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim f As Fcglist = Me.Owner
        Dim dtgr As DataGridView = f.show1
        Dim dtx As DataTable = dtgr.DataSource
        'Dim dtgr2 As DataGridView = f.show2
        'Dim dt2 As DataTable = dtgr2.DataSource
        'Dim dr As DataRow = DeepCode.DeepDoDataTable.GetRowByKey(dtgr.SelectedRows(0).Cells(0).Value, dtx)
        'Dim m As Object = dr.ItemArray
        'ChangeAddData(Me, dt2, dtgr.SelectedRows(0).Cells(0).Value, m) '添加数据
      
        DelRow(dtx, dtgr.SelectedRows(0).Cells(0).Value) '数据变化，少显示一行
     
        '''''''''''''''''''''''''''''''''''''
        Me.Close()

    End Sub
    Private Function dhdh(ByVal i As Integer) As String '单号尾数判断
        Dim h As String = ""
        Select Case i
            Case 1
                Dim dth As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cg_ID from tb_cg where tb_cg_cgdh ='" & tb_cg_cgdh.Text & "' and tb_cg_dm='" & tb_cg_dm.Text & "'")

                Select Case dth.Rows.Count + 1
                    Case 1
                        h = "-Ⅰ"
                    Case 2
                        h = "-Ⅱ"
                    Case 3
                        h = "-Ⅲ"
                    Case 4
                        h = "-Ⅳ"
                    Case 5
                        h = "-Ⅴ"
                    Case 6
                        h = "-Ⅵ"
                End Select

            Case 2
                h = "-Ⅱ"
            Case 3
                h = "-Ⅲ"
        End Select
        dhdh = h
    End Function
    Private Sub dhgz(ByVal str As String)

        If tb_cg_fqcs.SelectedIndex = 0 Then '一批拆分
            Dim sql1 As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz)"
            sql1 &= " values ('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & GF_gettrqsj(tb_cg_yjdhrq1.Text) & "'," & tb_cg_yjdhl1.Text & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & tb_cg_yszq1.Text & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "','" & tb_cg_cgbz.Text & "')"
            'Dim idstring As String = GF_upztxx2(G_cnnstr, sql1, "tb_cg")
            sql1 &= vbCrLf & "update tb_qgcg set tb_qgcg_xbid= ( SELECT @@IDENTITY) where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'" '更新请购下部表

            '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
            tb_xx_sql.Text = str & vbCrLf & sql1
            Dim f As Fcglist = Me.Owner
            Dim dtgr As DataGridView = f.show1
            Dim dtx As DataTable = dtgr.DataSource
            Dim dtgr2 As DataGridView = f.show2
            Dim dt As DataTable = dtgr2.DataSource
            Dim dr As DataRow = DeepCode.DeepDoDataTable.GetRowByKey(dtgr.SelectedRows(0).Cells(0).Value, dtx)
            Dim m As Object = dr.ItemArray
            ChangeAddData(Me, dt, dtgr.SelectedRows(0).Cells(0).Value, m) '添加数据

        Else

            '多批拆分
            '*****************************************************************************************
            '多批拆分规则：只有在拆分n批后在下面的表中存入n 条数据 但是显示的那条数据中只有最后存入的一条记录的 tb_xx_sql  列和  上表的datarow集合 列中有值
            '最后存入的记录中存有完整的sql语句和datarow集合
            '下表双击删除时 删除相同主键的信息
            '*****************************************************************************************
            Dim sql1 As String = ""
            Dim f As Fcglist = Me.Owner
            Dim dtgr As DataGridView = f.show1
            Dim dtx As DataTable = dtgr.DataSource
            Dim dtgr2 As DataGridView = f.show2
            Dim dt As DataTable = dtgr2.DataSource
            For i As Integer = 1 To tb_cg_fqcs.SelectedIndex + 1
                Dim q() As String = {GF_gettrqsj(tb_cg_yjdhrq1.Text), GF_gettrqsj(tb_cg_yjdhrq2.Text), GF_gettrqsj(tb_cg_yjdhrq3.Text)}

                Dim l() As String = {tb_cg_yjdhl1.Text, tb_cg_yjdhl2.Text, tb_cg_yjdhl3.Text}

                Dim zq() As String = {tb_cg_yszq1.Text, tb_cg_yszq2.Text, tb_cg_yszq3.Text}
                sql1 &= "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz)"
                sql1 &= "values('" & tb_cg_qgbm.Text & "','" & tb_cg_qgr.Text & "','" & tb_cg_cgdh.Text & "','" & tb_cg_cgdh.Text & dhdh(i) & "','" & tb_cg_gsmc.Text & "','" & tb_cg_dm.Text & "','" & tb_cg_pm.Text & "','" & tb_cg_ggxh.Text & "','" & tb_cg_dw.Text & "','" & tb_cg_wllb.Text & "','" & q(i - 1) & "'," & l(i - 1) & "," & tb_cg_qgsl.Text & ",'" & tb_cg_yqyt.Text & "'," & tb_cg_ysje.Text & ",'" & GF_gettrqsj(tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(tb_cg_yqdhrq.Text) & "','" & tb_cg_fzr.Text & "','" & GF_gettrqsj(tb_cg_rq.Text) & "','" & tb_cg_gysmc.Text & "'," & tb_cg_dgzl.Text & "," & tb_cg_dj.Text & "," & tb_cg_qyfy.Text & "," & tb_cg_zj.Text & ",'" & tb_cg_fqcs.Text & "','" & tb_cg_ysbm.Text & "','" & tb_cg_sfbh.Text & "','" & zq(i - 1) & "','" & tb_cg_qgbz.Text & "','" & tb_cg_wpbz.Text & "','" & tb_cg_qgrq.Text & "','" & tb_cg_qgzt.Text & "','" & tb_cg_qgdsfsx.Text & "','" & tb_cg_wpfl.Text & "','" & tb_cg_sbid.Text & "','" & tb_cg_jhdh.Text & "','" & tb_cg_cgbz.Text & "')"
                If i = 1 Then
                    sql1 &= vbCrLf & " declare @id as varchar(8000)"
                    sql1 &= vbCrLf & "set @id =cast( @@IDENTITY  as varchar(8000))"
                Else
                    sql1 &= vbCrLf & " set @id =@id + ','+cast( @@IDENTITY  as varchar(8000))"
                End If
                If i = tb_cg_fqcs.SelectedIndex + 1 Then
                    sql1 &= vbCrLf & "update tb_qgcg set tb_qgcg_xbid= @id where tb_qgcg_ID= '" & tb_cg_sbid.Text & "'" '更新上部表id
                    tb_xx_sql.Text = str & vbCrLf & sql1
                    Dim zj As String = dtgr.SelectedRows(0).Cells(0).Value
                    Dim dr As DataRow = DeepCode.DeepDoDataTable.GetRowByKey(zj, dtx)
                    Dim m As Object = dr.ItemArray
                    ChangeAddData(Me, dt, dtgr.SelectedRows(0).Cells(0).Value, m) '添加数据

                Else
                    Frjh.ChangeAddData(Me, dt, dtgr.SelectedRows(0).Cells(0).Value) '添加数据
                End If

            Next

            '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘

        End If


    End Sub

    Private Sub jszj(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cg_qyfy.TextChanged, tb_cg_dj.TextChanged, tb_cg_dgzl.TextChanged, tb_cg_yszq3.TextChanged, tb_cg_yszq2.TextChanged, tb_cg_yszq1.TextChanged
        Try
            Dim sz1 As String = tb_cg_qyfy.Text
            If sz1 = "" Then
                sz1 = 0
            End If
            Dim sz2 As String = tb_cg_dgzl.Text
            If sz2 = "" Then
                sz2 = 1
            End If
            Dim f As Double = tb_cg_dj.Text * sz2 + sz1
            tb_cg_zj.Text = f '单价*数量+其余费用
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChangeAddData(ByVal formname As Control, ByVal dt As DataTable, ByVal idstring As String, ByVal datarow As Object) '添加数据
        Dim nd As DataRow = dt.NewRow
        With formname
            For j As Integer = 0 To .Controls.Count - 1
                Dim zdsz As String = .Controls(j).Name '得到控件名

                If Microsoft.VisualBasic.Left(zdsz, 3) = "tb_" Then '如果得到需要字段的控件
                    If dt.Columns.IndexOf(zdsz) <> -1 Then
                        If .Controls(j).GetType.Name = "DateTimePicker" Then
                            Dim nn As DateTimePicker = .Controls(j)
                            If nn.Checked = True Then
                                nd(zdsz) = GF_gettrqsj(nn.Text)
                            Else
                                nd(zdsz) = DBNull.Value
                            End If
                        Else
                            If Trim(.Controls(j).Text) <> "" Then
                                nd(zdsz) = DeepCode.DeepDoStr.GF_ToDBC(Trim(.Controls(j).Text))
                            Else
                                nd(zdsz) = DBNull.Value
                            End If
                        End If
                    End If

                End If
            Next
            '''''
        End With
        nd(0) = idstring
        nd("上表的datarow集合") = datarow
        '’‘’‘’
        dt.Rows.Add(nd)

        '’‘’‘’‘’‘’‘’‘’‘


    End Sub
    Private Sub DelRow(ByRef dt As DataTable, ByVal idstring As String)
        Dim dn As DataRow = Nothing
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)(0) = idstring Then '如果找到了需要修改的那一行记录
                dn = dt.Rows(i)
                Exit For
            End If
        Next
        dt.Rows.Remove(dn)
    End Sub
End Class