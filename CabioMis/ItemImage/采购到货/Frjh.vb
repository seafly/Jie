Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frjh
    Private bm As String
    Private bm1 As String

    Private biao As String '上表名
    Private biao1 As String  '下表名
    Private smbdj As String '临时交换变量
    Private Sub Frjh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        'GS_FaceSearch(ComboBox3, "tb_wp", 1)
        'GS_FaceSearch(ComboBox1, "tb_wp", 1)
        smbdj = "基础表"
        bm = "基础表所有信息，可修改"
        bm1 = "基础表所有有效信息"
        biao = "tb_wp"
        biao1 = "tb_wp"
        Button4.Enabled = True

        'xssj() '显示数据

        weizhi()
    End Sub


    Private Sub showsj(ByVal dt As DataTable)
        GS_DataGridViewbyDb(show1, dt, True, True)
        guangbiao(show1)
    End Sub
    Private Sub showsj2(ByVal dt As DataTable)
        GS_DataGridViewbyDb(show2, dt, True, True)
        guangbiao(show2)
    End Sub



    Private Sub weizhi()
        GroupBox3.Width = Me.Width - GroupBox1.Left - 20
        GroupBox1.Top = GroupBox3.Bottom + 10
        GroupBox1.Height = Me.Height - GroupBox1.Top - 40
        GroupBox1.Width = Me.Width - GroupBox1.Left - 20
        show2.Width = GroupBox1.Width - 10
        show2.Height = GroupBox1.Height - 65

    End Sub

    Private Sub Frjh_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub
    Public Sub xssj() '显示数据
        GS_FaceSearch(ComboBox3, biao, 1) '筛选
        GS_FaceSearch(ComboBox1, biao1, 1)
        GS_FaceSearch(ComboBox2, biao, 2)
        GS_FaceSearch(ComboBox4, biao1, 2)
        Dim sql1 As String = ""
        Dim sql2 As String = ""

        Select Case smbdj
            Case "基础表"
                bm = "基础表所有信息，可修改"
                bm1 = "基础表所有有效信息"
                sql1 = "select tb_wp_ID,tb_wp_wpfl,tb_wp_gsmc,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm from tb_wp order by tb_wp_dm"
                sql2 = "select tb_wp_ID,tb_wp_wpfl,tb_wp_gsmc,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl,tb_wp_sybm from tb_wp where tb_wp_sfyx='是' order by tb_wp_dm"
                Button7.Visible = True
            Case "请购表"
                sql1 = "select tb_wp_ID,tb_wp_wpfl,tb_wp_gsmc,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl from tb_wp where tb_wp_sfyx='是'  order by tb_wp_dm"
                sql2 = "select  tb_qgcg_ID,tb_qgcg_wpfl,tb_qgcg_qgrq,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_qgdsfsx ,tb_qgcg_qgdsxrq,tb_qgcg_yqdhrq,tb_qgcg_dw,tb_qgcg_qgzt,tb_qgcg_wllb,tb_qgcg_qgsl,tb_qgcg_ysje,tb_qgcg_yqyt,tb_qgcg_bz,tb_qgcg_wpbz,tb_qgcg_ysbm,tb_qgcg_tdbz,tb_qgcg_gsmc,tb_qgcg_jhdh  from tb_qgcg  where tb_qgcg_qgdsfsx<>'是'and tb_qgcg_xbid is null order by tb_qgcg_qgdsfsx,tb_qgcg_dm"
                Button7.Visible = False
            Case "采购表"
                Button7.Visible = False
                sql1 = "select tb_qgcg_ID,tb_qgcg_wpfl,tb_qgcg_qgrq,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_gsmc,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_dw,tb_qgcg_wllb,tb_qgcg_wpbz,tb_qgcg_qgzt,tb_qgcg_qgsl,tb_qgcg_ysje,tb_qgcg_yqyt,tb_qgcg_bz,tb_qgcg_qgdsxrq,tb_qgcg_yqdhrq,tb_qgcg_qgdsfsx ,tb_qgcg_ysbm, tb_qgcg_jhdh  from tb_qgcg where tb_qgcg_qgdsfsx='是' and tb_qgcg_xbid is null order by tb_qgcg_pm,tb_qgcg_qgr"
                sql2 = "select tb_cg_ID,tb_cg_wpfl,tb_cg_cgdh,tb_cg_qgbm,tb_cg_qgr,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_qgsl,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_dhdh,tb_cg_yjdhrq1,tb_cg_yjdhl1 ,tb_cg_dw,tb_cg_wllb,tb_cg_wpbz,tb_cg_ysje,tb_cg_yqyt,tb_cg_qgbz,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_yszq1,tb_cg_ysbm ,tb_cg_sfbh,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_gsmc,tb_cg_jhdh from tb_cg where tb_cg_xbid is null order by tb_cg_yqdhrq asc"
            Case "到货跟踪"
                Button7.Visible = False
                sql1 = "select tb_cg_ID,tb_cg_wpfl,tb_cg_cgdh,tb_cg_qgbm,tb_cg_qgr,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_qgsl,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_dhdh,tb_cg_yjdhrq1,tb_cg_yjdhl1 ,tb_cg_dw,tb_cg_wllb,tb_cg_wpbz,tb_cg_ysje,tb_cg_yqyt,tb_cg_qgbz  ,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_yszq1,tb_cg_ysbm ,tb_cg_sfbh,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_gsmc,tb_cg_jhdh from tb_cg where tb_cg_xbid is null order by  tb_cg_yqdhrq asc"
                sql2 = "select tb_dhgz_ID,tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_dhdh,tb_dhgz_cgdh,tb_dhgz_gsmc,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_ysbm,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_qgsl,tb_dhgz_jsr ,tb_dhgz_rq,tb_dhgz_dw,tb_dhgz_wllb,tb_dhgz_wpbz,tb_dhgz_qgbz,tb_dhgz_yjdhrq,tb_dhgz_yjdhl,tb_dhgz_yssl,tb_dhgz_yszq , tb_dhgz_dhrqpc,tb_dhgz_dhslpc,tb_dhgz_yssx2,tb_dhgz_sfbh,tb_dhgz_qgrq,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_fqcs,tb_dhgz_ysr,tb_dhgz_jhdh from tb_dhgz where tb_dhgz_sfys is null"
            Case "验收"
                sql1 = "select tb_dhgz_ID,tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_dhdh,tb_dhgz_cgdh,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_wllb,tb_dhgz_yjdhrq,tb_dhgz_yjdhl,tb_dhgz_ysbm,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_jsr ,tb_dhgz_yssl,tb_dhgz_yszq , tb_dhgz_dhrqpc,tb_dhgz_dhslpc,tb_dhgz_yssx2,tb_dhgz_sfbh,tb_dhgz_qgrq,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_yqyt,tb_dhgz_wpbz,tb_dhgz_qgbz,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_fqcs,tb_dhgz_gsmc,tb_dhgz_jhdh from tb_dhgz where tb_dhgz_sfys is null"
                sql2 = "select tb_dhgz_ID,tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_dhdh,tb_dhgz_cgdh,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_ysbm,tb_dhgz_yjdhrq,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_jsr ,tb_dhgz_ysr,tb_dhgz_yssl,tb_dhgz_yszq,tb_dhgz_dw,tb_dhgz_wllb,tb_dhgz_wpbz,tb_dhgz_qgbz,tb_dhgz_yjdhl,tb_dhgz_pccl,tb_dhgz_yshgl,tb_dhgz_bhgl,tb_dhgz_dhrqpc,tb_dhgz_dhslpc,tb_dhgz_yssx,tb_dhgz_ysrq,tb_dhgz_yssx2,tb_dhgz_sfbh,tb_dhgz_qgrq,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_gsmc,tb_dhgz_jhdh,tb_dhgz_dj from tb_dhgz where tb_dhgz_sfys ='是'"
        End Select
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        showsj(dt1)
        showsj2(dt2)
        GroupBox3.Text = bm & dt1.Rows.Count & "条记录"
        GroupBox1.Text = bm1 & dt2.Rows.Count & "条记录"
        bs()



    End Sub

    Private Sub bs()
        Try
            For i As Integer = 0 To show2.Rows.Count - 1
                If Null2String(show2.Rows(i).Cells("tb_cg_sfbh").Value) = "补货" Then
                    show2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next
        Catch ex As Exception

        End Try

        Try
            For i As Integer = 0 To show1.Rows.Count - 1
                If Null2String(show1.Rows(i).Cells("tb_cg_sfbh").Value) = "补货" Then
                    show1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next
        Catch ex As Exception

        End Try

        Try
            For i As Integer = 0 To show1.Rows.Count - 1
                If Null2String(show1.Rows(i).Cells("tb_dhgz_sfbh").Value) = "补货" Then
                    show1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next
        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To show2.Rows.Count - 1
                If Null2String(show2.Rows(i).Cells("tb_dhgz_sfbh").Value) = "补货" Then
                    show2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next
        Catch ex As Exception

        End Try
        'Try
        '    For i As Integer = 0 To show2.Rows.Count - 1
        '        If show2.Rows(i).Cells("tb_dhgz_sfbh").Value = "补货" And show2.Rows(i).Cells("tb_dhgz_ysr").Value.ToString = "" Then
        '            show2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
        '        End If

        '    Next
        'Catch ex As Exception

        'End Try

        Try

            For i As Integer = 0 To show2.Rows.Count - 1
                If show2.Rows(i).Cells("tb_qgcg_qgdsfsx").Value = "退单" Then
                    show2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If

            Next

        Catch ex As Exception

        End Try


        Try
            For i As Integer = 0 To show2.Rows.Count - 1
                Dim zq As DateTime = show2.Rows(i).Cells("tb_cg_yjdhrq1").Value

                Dim n As DateTime = Now().Date
                Dim days As Integer = DateDiff(DateInterval.Day, zq, n)
                If days > 0 Then
                    show2.Rows(i).Cells("tb_cg_yjdhrq1").Style.BackColor = Color.Red
                End If
            Next
        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To show1.Rows.Count - 1
                Dim zq As DateTime = show1.Rows(i).Cells("tb_cg_yjdhrq1").Value

                Dim n As DateTime = Now().Date
                Dim days As Integer = DateDiff(DateInterval.Day, zq, n)
                If days > 0 Then
                    show1.Rows(i).Cells("tb_cg_yjdhrq1").Style.BackColor = Color.Red
                End If
            Next
        Catch ex As Exception
        End Try


        Try
            For i As Integer = 0 To show2.Rows.Count - 1
                If show2.Rows(i).Cells("tb_dhgz_dhrqpc").Value > 0 Then
                    show2.Rows(i).Cells("tb_dhgz_dhrqpc").Style.BackColor = Color.Red
                End If

            Next

        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To show1.Rows.Count - 1
                If show1.Rows(i).Cells("tb_dhgz_dhrqpc").Value > 0 Then
                    show1.Rows(i).Cells("tb_dhgz_dhrqpc").Style.BackColor = Color.Red
                End If

            Next
        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To show1.Rows.Count - 1
                Dim tt As DateTime = show1.Rows(i).Cells("tb_dhgz_yssx2").Value
                If tt < Now().Date Then
                    show1.Rows(i).Cells("tb_dhgz_yssx2").Style.BackColor = Color.Red
                End If

            Next
        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To show2.Rows.Count - 1
                If show2.Rows(i).Cells("tb_dhgz_yssx").Value > 0 Then
                    show2.Rows(i).Cells("tb_dhgz_yssx").Style.BackColor = Color.Red
                End If

                If show2.Rows(i).Cells("tb_dhgz_dhrqpc").Value > 0 Then
                    show2.Rows(i).Cells("tb_dhgz_dhrqpc").Style.BackColor = Color.Red
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.ToolStripLabel1.Text = "【数据读取中，请稍后......】"
        smbdj = "基础表"
        bm = "基础表所有信息，可修改"
        bm1 = "基础表所有有效信息"
        biao = "tb_wp"
        biao1 = "tb_wp"
        ToolStripButton2.Checked = True
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
        ToolStripButtonFG.Checked = False
        ToolStripButton5.Checked = False
        Button4.Enabled = True
        ToolStripButton1.Visible = False
        xssj()
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
        Me.ToolStripLabel1.Text = ""
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.ToolStripLabel1.Text = "【数据读取中，请稍后......】"
        smbdj = "请购表"
        bm = " 基础表"
        bm1 = "请购表"
        biao = "tb_wp"
        biao1 = "tb_qgcg"
        ToolStripButton2.Checked = False
        ToolStripButton3.Checked = True
        ToolStripButton4.Checked = False
        ToolStripButtonFG.Checked = False
        ToolStripButton5.Checked = False
        Button4.Enabled = True
        ToolStripButton1.Visible = False
        xssj()
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
        Me.ToolStripLabel1.Text = ""
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.ToolStripLabel1.Text = "【数据读取中，请稍后......】"
        smbdj = "采购表"
        bm = "请购表"
        bm1 = "采购表"
        biao1 = "tb_cg"
        biao = "tb_qgcg"
        ToolStripButton4.Checked = True
        ToolStripButton2.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton1.Visible = False
        ToolStripButtonFG.Checked = False
        ToolStripButton5.Checked = False
        Button4.Enabled = False

        xssj()
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
        Me.ToolStripLabel1.Text = ""
    End Sub

    Private Sub ToolStripButtonFG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonFG.Click
        Me.ToolStripLabel1.Text = "【数据读取中，请稍后......】"
        smbdj = "到货跟踪"
        bm = "采购表"
        bm1 = "到货跟踪"
        biao = "tb_cg"
        biao1 = "tb_dhgz"
        ToolStripButtonFG.Checked = True
        ToolStripButton4.Checked = False
        ToolStripButton2.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton1.Visible = True
        ToolStripButton5.Checked = False
        Button4.Enabled = False

        xssj()
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
        Me.ToolStripLabel1.Text = ""
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.ToolStripLabel1.Text = "【数据读取中，请稍后......】"
        smbdj = "验收"
        bm = "到货跟踪"
        bm1 = "验收"
        biao = "tb_dhgz"
        biao1 = "tb_dhgz"
        ToolStripButton5.Checked = True
        ToolStripButton4.Checked = False
        ToolStripButton2.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton1.Visible = False

        ToolStripButtonFG.Checked = False
        Button4.Enabled = False

        xssj()
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
        Me.ToolStripLabel1.Text = ""
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub


    Private Sub show1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show1.DoubleClick '添加
        If show1.SelectedRows.Count = 0 Then
            Return
        End If
        Select Case smbdj
            Case "基础表"
                Dim nform As New Frtjxg
                Me.AddOwnedForm(nform)
                Dim i As Integer = show1.SelectedRows(0).Cells(0).Value
                nform.id = i
                'nform.tb_wp_sybm.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_sybm").Value)
                nform.tb_wp_pm.ReadOnly = True
                nform.tb_wp_dm.ReadOnly = True
                nform.ShowDialog()
                bs()
            Case "请购表"
                Dim nform As New Frqg
                Me.AddOwnedForm(nform)
                Dim i As String = show1.SelectedRows(0).Cells(0).Value
                nform.id = i
                nform.tb_qgcg_gsmc.Text = show1.SelectedRows(0).Cells("tb_wp_gsmc").Value
                nform.tb_qgcg_dm.Text = show1.SelectedRows(0).Cells("tb_wp_dm").Value
                nform.tb_qgcg_pm.Text = show1.SelectedRows(0).Cells("tb_wp_pm").Value
                nform.tb_qgcg_ggxh.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_ggxh").Value)
                nform.tb_qgcg_dw.Text = show1.SelectedRows(0).Cells("tb_wp_dw").Value
                nform.tb_qgcg_wllb.Text = show1.SelectedRows(0).Cells("tb_wp_wllb").Value
                nform.tb_qgcg_wpbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_bz").Value)
                nform.tb_qgcg_wpfl.Text = Null2String(show1.SelectedRows(0).Cells("tb_wp_wpfl").Value)
                nform.Label29.Visible = False
                nform.Label30.Visible = False
                nform.Label15.Visible = False
            nform.tb_qgcg_qgdsfsx.Visible = False
                nform.tb_qgcg_qgdsxrq.Visible = False
                nform.tb_qgcg_ysbm.Visible = False
                nform.Label18.Visible = False
                nform.tb_qgcg_tdbz.Visible = False
                nform.Label14.Visible = False
                nform.tb_qgcg_qgzt.Visible = False
                nform.id = ""
                nform.tb_qgcg_qgzt.Visible = False
                nform.Label14.Visible = False
                nform.ShowDialog()

                bs()
            Case "采购表"
                Dim nform As New Frcg
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
                nform.Label31.Visible = False
                nform.tb_cg_sfbh.Visible = False
                nform.tb_cg_cgdh.ReadOnly = True
                nform.tb_cg_sbid.Text = i
                nform.id = ""
                Dim qztemp As String = ClassPhgn.ClassPhgn_Get("采购单号", "-") '得到当前批号+1的批号
                If qztemp = "" Then
                    MsgBox("批号设定不正确") : Exit Sub
                End If
                nform.tb_cg_cgdh.Text = qztemp
                nform.ShowDialog()
                bs()
            Case "到货跟踪"
                Dim nform As New Frdhgz
                Me.AddOwnedForm(nform)
                Dim i As String = show1.SelectedRows(0).Cells(0).Value
                nform.id = i
                nform.tb_dhgz_sbid.Text = i
                nform.tb_dhgz_jhdh.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_jhdh").Value) '计划单号
                nform.tb_dhgz_wpfl.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_wpfl").Value)
                nform.tb_dhgz_cgdh.Text = show1.SelectedRows(0).Cells("tb_cg_cgdh").Value
                nform.tb_dhgz_dhdh.Text = show1.SelectedRows(0).Cells("tb_cg_dhdh").Value
                nform.tb_dhgz_qgbm.Text = show1.SelectedRows(0).Cells("tb_cg_qgbm").Value
                nform.tb_dhgz_qgr.Text = show1.SelectedRows(0).Cells("tb_cg_qgr").Value
                nform.tb_dhgz_gsmc.Text = show1.SelectedRows(0).Cells("tb_cg_gsmc").Value
                nform.tb_dhgz_dm.Text = show1.SelectedRows(0).Cells("tb_cg_dm").Value
                nform.tb_dhgz_pm.Text = show1.SelectedRows(0).Cells("tb_cg_pm").Value
                nform.tb_dhgz_dw.Text = show1.SelectedRows(0).Cells("tb_cg_dw").Value
                nform.tb_dhgz_wllb.Text = show1.SelectedRows(0).Cells("tb_cg_wllb").Value
                nform.tb_dhgz_ggxh.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_ggxh").Value)
                nform.tb_dhgz_yjdhrq.Text = show1.SelectedRows(0).Cells("tb_cg_yjdhrq1").Value
                nform.tb_dhgz_yjdhl.Text = show1.SelectedRows(0).Cells("tb_cg_yjdhl1").Value
                nform.tb_dhgz_ysbm.Text = show1.SelectedRows(0).Cells("tb_cg_ysbm").Value
                nform.tb_dhgz_yszq.Text = show1.SelectedRows(0).Cells("tb_cg_yszq1").Value
                nform.tb_dhgz_qgbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_qgbz").Value)
                nform.tb_dhgz_wpbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_wpbz").Value)
                nform.tb_dhgz_qgrq.Text = show1.SelectedRows(0).Cells("tb_cg_qgrq").Value
                nform.tb_dhgz_qgzt.Text = show1.SelectedRows(0).Cells("tb_cg_qgzt").Value
                nform.tb_dhgz_qgdsfsx.Text = show1.SelectedRows(0).Cells("tb_cg_qgdsfsx").Value
                nform.tb_dhgz_qgsl.Text = show1.SelectedRows(0).Cells("tb_cg_qgsl").Value
                nform.tb_dhgz_yqyt.Text = show1.SelectedRows(0).Cells("tb_cg_yqyt").Value
                nform.tb_dhgz_rq.Text = show1.SelectedRows(0).Cells("tb_cg_rq").Value
                nform.tb_dhgz_fzr.Text = show1.SelectedRows(0).Cells("tb_cg_fzr").Value
                nform.tb_dhgz_dgzl.Text = show1.SelectedRows(0).Cells("tb_cg_dgzl").Value
                nform.tb_dhgz_fqcs.Text = show1.SelectedRows(0).Cells("tb_cg_fqcs").Value
                nform.tb_dhgz_sfbh.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_sfbh").Value)
                nform.tb_dhgz_dj.Text = show1.SelectedRows(0).Cells("tb_cg_dj").Value
                nform.tb_dhgz_yqdhrq.Text = Null2String(show1.SelectedRows(0).Cells("tb_cg_yqdhrq").Value)
                nform.tb_dhgz_sbid.Text = i
                nform.id = ""
                nform.ShowDialog()
                bs()
            Case "验收"
                Dim str As String = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_wpfl").Value)
                ''''''''''''''''''''''''''''''判定物品类别是原料包材还是备品备件 如果是原料包材则传原料界面 备品备件则传验收界面
                If str = "原料" Or str = "包材" Then
                    Dim nform As New Fryl
                    nform.tb_i259b_i231a.Items.Clear()
                    'nform.tb_i259b_q546i.Items.Clear()
                    nform.tb_i259b_r596j.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_wpfl").Value)
                    nform.tb_i259b_i231a.Items.Add(show1.SelectedRows(0).Cells("tb_dhgz_dm").Value)
                    nform.tb_i259b_i231a.SelectedIndex = 0
                    'nform.tb_i259b_c24u.Text = show1.SelectedRows(0).Cells("tb_dhgz_pm").Value
                    nform.tb_i259b_jhdh.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_jhdh").Value) '计划单号
                    nform.tb_i259b_h200z.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_dw").Value)
                    nform.tb_i259b_gg.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_ggxh").Value)
                    nform.tb_i259b_y840q.Text = GF_gettrqsj(Now)
                    nform.tb_i259b_sbid.Text = show1.SelectedRows(0).Cells(0).Value
                    'nform.tb_i259b_q546i.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_gsmc").Value)
                    nform.tb_i259b_cgdh.Text = show1.SelectedRows(0).Cells("tb_dhgz_cgdh").Value
                    nform.tb_i259b_p518h.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhsl").Value
                    nform.tb_i259b_y840q.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhrq").Value

                    If str = "原料" Then
                        nform.Labeltb.Text = "tb_t676l"
                        nform.tb_i259b_r596j.DropDownStyle = ComboBoxStyle.DropDownList
                        nform.tb_i259b_r596j.Enabled = True
                        nform.tb_i259b_r596j.Items.Clear()
                        nform.tb_i259b_r596j.Items.Add("锅炉原料")
                        nform.tb_i259b_r596j.Items.Add("发酵原料")
                        nform.tb_i259b_r596j.Items.Add("油剂原料")
                        nform.tb_i259b_r596j.Items.Add("粉剂原料")
                    ElseIf str = "包材" Then
                        nform.Labeltb.Text = "tb_bcQC"
                    End If
                    '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                    nform.ShowDialog()
                    xssj()
                Else
                    Dim nform As New Frys
                    Me.AddOwnedForm(nform)
                    Dim i As String = show1.SelectedRows(0).Cells(0).Value
                    nform.id = i
                    nform.tb_dhgz_jhdh.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_jhdh").Value) '计划单号
                    nform.tb_dhgz_cgdh.Text = show1.SelectedRows(0).Cells("tb_dhgz_cgdh").Value
                    nform.tb_dhgz_dhdh.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhdh").Value
                    nform.tb_dhgz_qgbm.Text = show1.SelectedRows(0).Cells("tb_dhgz_qgbm").Value
                    nform.tb_dhgz_qgr.Text = show1.SelectedRows(0).Cells("tb_dhgz_qgr").Value
                    nform.tb_dhgz_gsmc.Text = show1.SelectedRows(0).Cells("tb_dhgz_gsmc").Value
                    nform.tb_dhgz_dm.Text = show1.SelectedRows(0).Cells("tb_dhgz_dm").Value
                    nform.tb_dhgz_pm.Text = show1.SelectedRows(0).Cells("tb_dhgz_pm").Value
                    nform.tb_dhgz_dw.Text = show1.SelectedRows(0).Cells("tb_dhgz_dw").Value
                    nform.tb_dhgz_wllb.Text = show1.SelectedRows(0).Cells("tb_dhgz_wllb").Value
                    nform.tb_dhgz_ggxh.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_ggxh").Value)
                    nform.tb_dhgz_yjdhrq.Text = show1.SelectedRows(0).Cells("tb_dhgz_yjdhrq").Value
                    nform.tb_dhgz_yjdhl.Text = show1.SelectedRows(0).Cells("tb_dhgz_yjdhl").Value
                    nform.tb_dhgz_ysbm.Text = show1.SelectedRows(0).Cells("tb_dhgz_ysbm").Value
                    nform.tb_dhgz_jsr.Text = show1.SelectedRows(0).Cells("tb_dhgz_jsr").Value
                    nform.tb_dhgz_dhrq.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhrq").Value
                    nform.tb_dhgz_dhsl.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhsl").Value
                    nform.tb_dhgz_dhslpc.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhslpc").Value
                    nform.tb_dhgz_dhrqpc.Text = show1.SelectedRows(0).Cells("tb_dhgz_dhrqpc").Value
                    nform.tb_dhgz_yszq.Text = show1.SelectedRows(0).Cells("tb_dhgz_yszq").Value
                    nform.tb_dhgz_qgbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_qgbz").Value)
                    nform.tb_dhgz_wpbz.Text = Null2String(show1.SelectedRows(0).Cells("tb_dhgz_wpbz").Value)
                    nform.tb_dhgz_yssx2.Text = show1.SelectedRows(0).Cells("tb_dhgz_yssx2").Value
                    nform.tb_dhgz_yshgl.Text = nform.tb_dhgz_dhsl.Text
                    Dim cz As String = "select  top 1 tb_dhgz_ysrq from tb_dhgz" '验收日期  默认上次id输入
                    Dim dtcz As DataTable = GF_CreateDataSource(G_cnnstr, cz)
                    nform.tb_dhgz_ysrq.Text = dtcz.Rows(0)(0)
                    nform.tb_dhgz_sfbh.Text = "不补货"
                    nform.Label16.Visible = False
                    nform.tb_dhgz_pccl.Visible = False
                    nform.ShowDialog()
                End If
                bs()
                'xssj()

        End Select
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click '上表筛选

        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker3.Text)
        tt2 = GF_gettrqsj(DateTimePicker4.Text)

        'Dim sql As String = "select * from " & biao & " where 1=1 " & pd
        Dim sql As String = ""
        Select Case smbdj
            Case "基础表"
                sql = "select tb_wp_ID,tb_wp_wpfl,tb_wp_gsmc,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl from tb_wp where 1=1 "

            Case "请购表"
                sql = "select tb_wp_ID,tb_wp_wpfl,tb_wp_gsmc,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl from tb_wp where 1=1 and tb_wp_sfyx='是'"
            Case "采购表"
                sql = "select tb_qgcg_ID,tb_qgcg_wpfl,tb_qgcg_qgrq,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_gsmc,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_dw,tb_qgcg_wllb,tb_qgcg_wpbz,tb_qgcg_qgzt,tb_qgcg_qgsl,tb_qgcg_ysje,tb_qgcg_yqyt,tb_qgcg_bz,tb_qgcg_qgdsxrq,tb_qgcg_yqdhrq,tb_qgcg_qgdsfsx ,tb_qgcg_ysbm ,tb_qgcg_jhdh  from tb_qgcg where tb_qgcg_qgdsfsx='是' and tb_qgcg_xbid is null"

            Case "到货跟踪"
                sql = "select tb_cg_ID,tb_cg_wpfl,tb_cg_cgdh,tb_cg_qgbm,tb_cg_qgr,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_qgsl,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_dhdh,tb_cg_yjdhrq1,tb_cg_yjdhl1 ,tb_cg_dw,tb_cg_wllb,tb_cg_wpbz,tb_cg_ysje,tb_cg_yqyt,tb_cg_qgbz  ,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_yszq1,tb_cg_ysbm ,tb_cg_sfbh,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_gsmc,tb_cg_jhdh from tb_cg where tb_cg_xbid is null "
            Case "验收"
                sql = "select tb_dhgz_ID,tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_dhdh,tb_dhgz_cgdh,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_dw,tb_dhgz_wllb,tb_dhgz_yjdhrq,tb_dhgz_yjdhl,tb_dhgz_ysbm,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_jsr ,tb_dhgz_yssl,tb_dhgz_yszq , tb_dhgz_dhrqpc,tb_dhgz_dhslpc,tb_dhgz_yssx2,tb_dhgz_sfbh,tb_dhgz_qgrq,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_yqyt,tb_dhgz_wpbz,tb_dhgz_qgbz,tb_dhgz_rq,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_fqcs,tb_dhgz_gsmc,tb_dhgz_jhdh from tb_dhgz where tb_dhgz_sfys is null"
        End Select

        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBox3, TextBox2) '筛选要求
        Dim sql1 As String = GF_sxrq(ComboBox2, tt1, tt2)
        sql &= sqlbdssep & sql1

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        showsj(dt)
        GroupBox3.Text = bm & dt.Rows.Count & "条记录"
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim nform As New Frtjxg ' 物品表添加
        Me.AddOwnedForm(nform)
        nform.ShowDialog()

    End Sub
    Private Function GF_sxrq(ByVal ComboBoxName As ComboBox, ByVal tt1 As String, ByVal tt2 As String) As String '时间筛选语句
        'Dim cxkr As String = TextboxName.Text.Trim
        'If cxkr = "" Then
        '    Return ""
        'End If
        'cxkr = Replace(cxkr, "‘", "'")
        Dim zdzw As String = ComboBoxName.Text
        If zdzw = "" Then
            Return ""
        End If
        Dim db As DataTable = CType(ComboBoxName.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] between '" & tt1 & "' and '" & tt2 & "'"
        Return sql
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click '下表筛选
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        Dim pd As String = ""

        'Dim sql As String = "select * from " & biao1 & " where 1=1" & pd
        Dim sql As String = ""
        Select Case smbdj
            Case "基础表"
                sql = "select tb_wp_ID,tb_wp_wpfl,tb_wp_gsmc,tb_wp_dm,tb_wp_pm,tb_wp_ggxh,tb_wp_dw,tb_wp_wllb,tb_wp_bz,tb_wp_sfyx,tb_wp_aqkc,tb_wp_zdkc,tb_wp_cgzq,tb_wp_jjcgl from tb_wp where 1=1 and tb_wp_sfyx='是'"

            Case "请购表"
                sql = "select  tb_qgcg_ID,tb_qgcg_wpfl,tb_qgcg_qgrq,tb_qgcg_qgbm,tb_qgcg_qgr,tb_qgcg_dm,tb_qgcg_pm,tb_qgcg_ggxh,tb_qgcg_qgdsfsx ,tb_qgcg_qgdsxrq,tb_qgcg_yqdhrq,tb_qgcg_dw,tb_qgcg_qgzt,tb_qgcg_wllb,tb_qgcg_qgsl,tb_qgcg_ysje,tb_qgcg_yqyt,tb_qgcg_bz,tb_qgcg_wpbz,tb_qgcg_ysbm,tb_qgcg_tdbz,tb_qgcg_gsmc,tb_qgcg_jhdh from tb_qgcg  where tb_qgcg_qgdsfsx<>'是'and tb_qgcg_xbid is null"
            Case "采购表"
                sql = "select tb_cg_ID,tb_cg_wpfl,tb_cg_cgdh,tb_cg_qgbm,tb_cg_qgr,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_qgsl,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_dhdh,tb_cg_yjdhrq1,tb_cg_yjdhl1 ,tb_cg_dw,tb_cg_wllb,tb_cg_wpbz,tb_cg_ysje,tb_cg_yqyt,tb_cg_qgbz  ,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_yszq1,tb_cg_ysbm ,tb_cg_sfbh,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_gsmc,tb_cg_jhdh from tb_cg where tb_cg_xbid is null "
            Case "到货跟踪"
                sql = "select tb_dhgz_ID,tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_dhdh,tb_dhgz_cgdh,tb_dhgz_gsmc,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_ysbm,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_qgsl,tb_dhgz_jsr ,tb_dhgz_rq,tb_dhgz_dw,tb_dhgz_wllb,tb_dhgz_wpbz,tb_dhgz_qgbz,tb_dhgz_yjdhrq,tb_dhgz_yjdhl,tb_dhgz_yssl,tb_dhgz_yszq , tb_dhgz_dhrqpc,tb_dhgz_dhslpc,tb_dhgz_yssx2,tb_dhgz_sfbh,tb_dhgz_qgrq,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_qgsl,tb_dhgz_yqyt,tb_dhgz_fzr,tb_dhgz_dgzl,tb_dhgz_fqcs,tb_dhgz_ysr,tb_dhgz_jhdh from tb_dhgz where tb_dhgz_sfys is null"
            Case "验收"
                sql = "select tb_dhgz_ID,tb_dhgz_wpfl,tb_dhgz_qgbm,tb_dhgz_qgr,tb_dhgz_dhdh,tb_dhgz_cgdh,tb_dhgz_dm,tb_dhgz_pm,tb_dhgz_ggxh,tb_dhgz_ysbm,tb_dhgz_yjdhrq,tb_dhgz_dhrq,tb_dhgz_dhsl,tb_dhgz_jsr ,tb_dhgz_ysr,tb_dhgz_yssl,tb_dhgz_yszq,tb_dhgz_dw,tb_dhgz_wllb,tb_dhgz_wpbz,tb_dhgz_qgbz,tb_dhgz_yjdhl,tb_dhgz_pccl,tb_dhgz_yshgl,tb_dhgz_bhgl,tb_dhgz_dhrqpc,tb_dhgz_dhslpc,tb_dhgz_yssx,tb_dhgz_ysrq,tb_dhgz_yssx2,tb_dhgz_sfbh,tb_dhgz_qgrq,tb_dhgz_qgzt,tb_dhgz_qgdsfsx,tb_dhgz_gsmc, tb_dhgz_jhdh from tb_dhgz where tb_dhgz_sfys ='是'"
        End Select

        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBox1, TextBox1)
        Dim sql1 As String = GF_sxrq(ComboBox4, tt1, tt2)
        sql &= sqlbdssep & sql1

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        showsj2(dt)
        GroupBox1.Text = bm1 & dt.Rows.Count & "条记录"
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
    End Sub

    Private Sub show2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles show2.DoubleClick '修改
        If show2.SelectedRows.Count = 0 Then
            Return
        End If
        Select Case smbdj
            Case "基础表"

                MsgBox("请在基础表所有信息表中修改")
                bs()

            Case "请购表"
                Dim nform As New Frqg
                Me.AddOwnedForm(nform)
                If show2.SelectedRows(0).Cells("tb_qgcg_qgdsfsx").Value = "退单" Then
                    MsgBox("已退单")
                    Exit Sub
                End If
                nform.id = show2.SelectedRows(0).Cells(0).Value
                nform.ShowDialog()
                bs()
            Case "采购表"
                Dim nform As New Frcg
                Me.AddOwnedForm(nform)
                nform.id = show2.SelectedRows(0).Cells(0).Value
                nform.tb_cg_yjdhrq1.Visible = True
                nform.tb_cg_yjdhl1.Visible = True
                nform.tb_cg_yjdhrq2.Visible = False
                nform.tb_cg_yjdhl2.Visible = False
                nform.tb_cg_yjdhrq3.Visible = False
                nform.tb_cg_yjdhl3.Visible = False
                nform.tb_cg_yszq1.Visible = True
                nform.tb_cg_yszq2.Visible = False
                nform.tb_cg_yszq3.Visible = False
                nform.tb_cg_fqcs.Enabled = False
                nform.Label13.Visible = True
                nform.Label14.Visible = False
                nform.Label16.Visible = True
                nform.Label17.Visible = False
                nform.Label15.Visible = False
                nform.Label18.Visible = False
                nform.Label33.Visible = False
                nform.Label32.Visible = True
                nform.Label34.Visible = False
                nform.ShowDialog()
                nform.tb_cg_fqcs.Enabled = False
                bs()
            Case "到货跟踪"
                Dim nform As New Frdhgz
                Me.AddOwnedForm(nform)
                nform.id = show2.SelectedRows(0).Cells(0).Value
                nform.ShowDialog()
                bs()
            Case "验收"
                'Dim str As String = Null2String(show2.SelectedRows(0).Cells("tb_dhgz_wpfl").Value)
                'If str = "原料" Or str = "包材" Then
                '    MsgBox("此处只允许修改备品备件！") : Exit Sub
                'Else
                '    Dim nform As New Frys
                '    Me.AddOwnedForm(nform)
                '    nform.id = show2.SelectedRows(0).Cells(0).Value
                '    nform.ShowDialog()
                'End If
                bs()



        End Select
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        GS_toexcel(show2, GroupBox1.Text, Me)
    End Sub
#Region ""  'Public Sub sc(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim kk As DataGridView = sender.SourceControl

    '        If MsgBox("确定删除该条数据吗？", 1, "提示") <> 1 Then
    '            Exit Sub
    '        Else
    '            Dim sql1 As String = ""
    '            Dim sql As String = "DELETE FROM tb_qgcg WHERE tb_qgcg_id = " & kk.SelectedRows(0).Cells("tb_qgcg_id").Value & ""
    '            GS_upztxx(G_cnnstr, sql)
    '            xssj()


    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Private Sub sc1()

    '    With show2
    '        If .SelectedRows.Count > 0 Then
    '            Dim menu1 As New ContextMenuStrip
    '            menu1.Items.Add("删除")
    '            AddHandler menu1.Click, AddressOf sc
    '            .ContextMenuStrip = menu1

    '            menu1.Close()
    '        End If
    '    End With
    'End Sub
#End Region
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If GF_storelog1("删除基础表") = False Then
            Exit Sub
        End If ' 判断是否有权限
        If show2.SelectedRows.Count = 0 Then
            Return
        End If
        If MsgBox("确定删除该条数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        Dim i As String = show2.SelectedRows(0).Cells(0).Value
        'Dim sql As String = "select tb_qgcg_qgdsfsx from tb_qgcg where tb_qgcg_ID = '" & i & "'"
        Dim dt As DataTable = DeepCode.DeepDoGridView.ToDataTable(show2)
        Try '请购删除判定
            Dim dt0 As DataTable = GF_czmctb(dt, "tb_qgcg_ID='" & i & "'")
            If dt0.Rows(0)("tb_qgcg_qgdsfsx") = "否" Then
                Dim sql As String = "DELETE FROM tb_qgcg WHERE tb_qgcg_id = " & i & ""
                GS_upztxx(G_cnnstr, sql)
                xssj()
            ElseIf dt0.Rows(0)("tb_qgcg_qgdsfsx") <> "否" Then
                MsgBox("此条信息不可删除！")
            End If
        Catch ex As Exception

        End Try
        Try '物品表删除判定
            Dim ss As String = "select * from tb_qgcg where tb_qgcg_dm='" & show2.SelectedRows(0).Cells("tb_wp_dm").Value & "' and tb_qgcg_pm='" & show1.SelectedRows(0).Cells("tb_wp_pm").Value & "'"
            Dim ds As DataTable = GF_CreateDataSource(G_cnnstr, ss)
            If ds.Rows.Count = 0 Then
                Dim sqlss As String = "DELETE FROM tb_wp WHERE tb_wp_id = " & i & ""
                GS_upztxx(G_cnnstr, sqlss)
                xssj()
            ElseIf ds.Rows.Count > 0 Then
                MsgBox("该物品被使用，所以不可删除！")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If ToolStripButton2.Checked = True Then
            smbdj = "基础表"
            bm = "基础表所有信息，可修改"
            bm1 = "基础表所有有效信息"
            biao = "tb_wp"
            biao1 = "tb_wp"
            Button4.Enabled = False

        ElseIf ToolStripButton3.Checked = True Then
            smbdj = "请购表"
            bm = " 基础表"
            bm1 = "请购表"
            biao = "tb_wp"
            biao1 = "tb_qgcg"
            Button4.Enabled = True

        ElseIf ToolStripButton4.Checked = True Then
            smbdj = "采购表"
            bm = "请购表"
            bm1 = "采购表"
            biao1 = "tb_cg"
            biao = "tb_qgcg"
            Button4.Enabled = False

        ElseIf ToolStripButtonFG.Checked = True Then
            smbdj = "到货跟踪"
            bm = "采购表"
            bm1 = "到货跟踪"
            biao = "tb_cg"
            biao1 = "tb_dhgz"
            Button4.Enabled = False

        ElseIf ToolStripButton5.Checked = True Then
            smbdj = "验收"
            bm = "到货跟踪"
            bm1 = "验收"
            biao = "tb_dhgz"
            biao1 = "tb_dhgz"

            Button4.Enabled = False

        End If
        xssj()
        ComboBox3.Text = "物料代码"
        ComboBox1.Text = "物料代码"
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        GS_toexcel(show1, GroupBox3.Text, Me)
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        Dim nform As New Frbz
        nform.Show()
    End Sub
#Region "免查询的修改添加更新操作"
    Public Sub DelRow(ByVal dt As DataTable, ByVal idstring As String)
        Dim dn As DataRow = Nothing
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)(0) = idstring Then '如果找到了需要修改的那一行记录
                dn = dt.Rows(i)
                Exit For
            End If
        Next
        dt.Rows.Remove(dn)
    End Sub
    Public Sub ChangeAddData(ByVal formname As Control, ByVal dt As DataTable, ByVal idstring As String) '添加数据
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
        '’‘’‘’
        dt.Rows.Add(nd)

        '’‘’‘’‘’‘’‘’‘’‘


    End Sub
    Public Sub ChangeData(ByVal formname As Control, ByVal dt As DataTable, ByVal idstring As String) '修改数据
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)(0) = idstring Then '如果找到了需要修改的那一行记录
                '’‘’‘’
                With formname
                    For j As Integer = 0 To .Controls.Count - 1
                        Dim zdsz As String = .Controls(j).Name '得到控件名

                        If Microsoft.VisualBasic.Left(zdsz, 3) = "tb_" Then '如果得到需要字段的控件
                            If dt.Columns.IndexOf(zdsz) <> -1 Then
                                If .Controls(j).GetType.Name = "DateTimePicker" Then
                                    Dim nn As DateTimePicker = .Controls(j)
                                    If nn.Checked = True Then
                                        dt.Rows(i)(zdsz) = GF_gettrqsj(nn.Text)
                                    Else
                                        dt.Rows(i)(zdsz) = DBNull.Value
                                    End If
                                Else
                                    If Trim(.Controls(j).Text) <> "" Then
                                        dt.Rows(i)(zdsz) = DeepCode.DeepDoStr.GF_ToDBC(Trim(.Controls(j).Text))
                                    Else
                                        dt.Rows(i)(zdsz) = DBNull.Value
                                    End If
                                End If
                            End If

                        End If
                    Next
                    '''''
                End With

                '’‘’‘’‘’‘’‘’‘’‘
            End If
        Next
    End Sub
#End Region

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'ddh 订单号；pm货物名称；gg货物规格； jhdhsl；计划到货数量；jhdhrq计划到货日期；dls代理商；scs生产商； gdpdrq 规定判断时间； dj单价
        With show1.SelectedRows(0)
            Dim ddh, pm, gg, jhdhsl, jhdhrq, dls, scs, gdpdrq, dj, path As String
            ddh = .Cells("tb_cg_cgdh").Value
            pm = .Cells("tb_cg_pm").Value
            gg = Null2String(.Cells("tb_cg_ggxh").Value)
            jhdhsl = .Cells("tb_cg_yjdhl1").Value
            jhdhrq = .Cells("tb_cg_yjdhrq1").Value
            dls = ""
            Dim sql As String = "select top 1 tb_cg_gysmc from tb_cg where tb_cg_cgdh='" & .Cells("tb_cg_cgdh").Value & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt.Rows.Count <= 0 Then
                scs = 0
            Else
                scs = dt.Rows(0)(0)
            End If
            Dim sql1 As String = "select tb_i259b_f122x from tb_i259b where tb_i259b_sbid=" & .Cells("tb_cg_ID").Value & ""
            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
            If dt1.Rows.Count <= 0 Then
                gdpdrq = ""
            Else
                gdpdrq = dt1.Rows(0)(0)
            End If
            dj = .Cells("tb_cg_dj").Value
            path = Application.StartupPath() & "\shjl.doc"
            CL_Word.GS_dhgzword(ddh, pm, gg, jhdhsl, jhdhrq, dls, scs, gdpdrq, dj, path)
        End With
    End Sub
    Private Sub guangbiao(ByVal DataGridviewName As DataGridView)
        Dim aa As Integer = 0
        Try
            With DataGridviewName
                If .Rows.Count >= 0 Then

                    Dim id As Integer = .SelectedRows(0).Cells(0).Value
                    For i As Integer = 0 To .Rows.Count - 1
                        If .Rows(i).Cells(0).Value = id Then
                            aa = i
                        End If
                    Next
                    .Rows(aa).Selected = True
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class