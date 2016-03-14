
Public Class Frmodkc
    Private bm As String '查询的表名
    Public cwzd As String = "''"
    Public qtzd As String = ""
    Public m_dt As DataTable
    Private Sub Frmodkc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        ComboBox1.SelectedIndex = 0

        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_ckyt")
        Call GS_wlbktlr2(tb_x825p_yg, kk, 1, "")
        Textbfs.Text = "0"

        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''''''''''''
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''
        Dim sykcsm As String = ""
        If sykc.Tag = sykc.Text Then
            sykcsm = ""
        Else
            sykcsm = sykc.Tag
        End If
        ''''''''''''''''''
        If bm = "" Then
            Exit Sub
        End If
        If GF_storelog1("修改入库信息") = False Then
            Exit Sub
        End If ' 判断是否有权限
        '更新毛油或者成品油表
        Dim fn As String = bm
        '''''''''''''''''
        Dim cwzd As String = "" '仓位字段
        If cw.Text = "" Then cw.Text = 0


        'If bm <> "tb_x825pkc" Then
        cwzd = "," & bm & "_cw='" & cw.Text & "'"
        cwzd &= "," & bm & "_mscw='" & mscw.Text & "'"
        cwzd &= "," & bm & "_wzcw='" & wzcw.Text & "'"
        cwzd &= "," & bm & "_bfcw='" & bfcw.Text & "' "
        'End If
        Dim kcc, sykcc, ckclz As Double
        Try
            kcc = kc.Text : sykcc = sykc.Text : ckclz = ckcl.Text
        Catch ex As Exception
            MsgBox("请正确填写数字") : Exit Sub
        End Try
        Try
            '''''''''''''''''
            Dim sql As String = ""
            '***************新加的**************
            '查找是否有相同批号，加工代码，生产代码的记录
            sql = "select * from " & fn & " where " & fn & "_ID not in (" & Cl_DataMag.YanDttoStr(m_dt, fn & "_ID") & ") and " & fn & "_num='" & ph.Text.Trim & "'and " & bm & "_mingc='" & ComboBox2.Tag & "'and " & bm & "_jiagdm='" & ComboBox3.Tag & "'" & _
            " order by " & bm & "_id desc"
            If Cl_DataMag.GF_CreateDataSource(sql).Rows.Count > 0 Then
                '如果想相同的那么更新最新那条数据的数量
                MsgBox("已有相同的记录！")
                Return
            Else
                sql = "update " & fn & " set " & fn & "_bzxs='" & tb_x825p_bzxs.Text & "'," & fn & "_mingc='" & ComboBox2.Text & "'," & fn & "_jiagdm='" & ComboBox3.Text & "'," & fn & "_sykcsm='" & sykcsm & "'," & fn & "_rkts=" & tb_x825p_rkts.Text & "," & fn & "_rkbz='" & tb_x825p_rkbz.Text & "'," & fn & "_kczl=" & kcc & "," & fn & "_yg='" & tb_x825p_yg.Text & "'," & fn & "_sykczl=" & sykcc & " ," & fn & "_ckcl=" & ckclz & "," & fn & "_bf=" & fn & "_bf+" & Textbfs.Text & "," & fn & "_bfmx='" & TextBoxbfmx.Text & "'," & fn & "_wjbgrq='" & wjbgrq.Text & "'" & cwzd & " where " & fn & "_num='" & ph.Text.Trim & "'and " & bm & "_mingc='" & ComboBox2.Tag & "'and " & bm & "_jiagdm='" & ComboBox3.Tag & "'"
            End If
            '***************新加的**************
            'If bm = "tb_x832pkc" Or bm = "tb_h195zkc" Then
            '    sql = "update " & fn & " set " & fn & "_bzxs='" & tb_x825p_bzxs.Text & "'," & fn & "_mingc='" & ComboBox2.Text & "'," & fn & "_jiagdm='" & ComboBox3.Text & "'," & fn & "_sykcsm='" & sykcsm & "'," & fn & "_rkts=" & tb_x825p_rkts.Text & "," & fn & "_rkbz='" & tb_x825p_rkbz.Text & "'," & fn & "_kczl=" & kcc & "," & fn & "_yg='" & tb_x825p_yg.Text & "'," & fn & "_sykczl=" & sykcc & " ," & fn & "_ckcl=" & ckclz & "," & fn & "_bf=" & fn & "_bf+" & Textbfs.Text & "," & fn & "_bfmx='" & TextBoxbfmx.Text & "'," & fn & "_wjbgrq='" & wjbgrq.Text & "'" & cwzd & " where " & fn & "_num='" & ph.Text.Trim & "'and " & bm & "_mingc='" & ComboBox2.Tag & "'and " & bm & "_jiagdm='" & ComboBox3.Tag & "'"
            'Else
            '    sql = "update " & fn & " set " & fn & "_bzxs='" & tb_x825p_bzxs.Text & "', " & fn & "_mingc='" & ComboBox2.Text & "'," & fn & "_jiagdm='" & ComboBox3.Text & "'," & fn & "_sykcsm='" & sykcsm & "'," & fn & "_rkts=" & tb_x825p_rkts.Text & "," & fn & "_rkbz='" & tb_x825p_rkbz.Text & "'," & fn & "_kczl=" & kcc & "," & fn & "_yg='" & tb_x825p_yg.Text & "'," & fn & "_sykczl=" & sykcc & "," & fn & "_ckcl=" & ckclz & "," & fn & "_bf=" & fn & "_bf+" & Textbfs.Text & "," & fn & "_bfmx='" & TextBoxbfmx.Text & "'," & fn & "_wjbgrq='" & wjbgrq.Text & "' " & cwzd & " where " & fn & "_num='" & ph.Text.Trim & "'and " & bm & "_mingc='" & ComboBox2.Tag & "'and " & bm & "_jiagdm='" & ComboBox3.Tag & "'"
            'End If

            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("修改入库信息：" & ComboBox1.Text & ph.Text, "修改入库信息") '储存到日志
            MsgBox("更新成功！") : Me.Close()
        Catch ex As Exception
            MsgBox("请正确填写项目") : Exit Sub
        End Try
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim ph1 As String = ph.Text.Trim
        If ph1 = "" Then
            Exit Sub
        End If

        Dim sql As String = "select " & bm & "_qaspjg," & bm & "_qajgsm," & bm & "_bzxs," & bm & "_cfdd," & bm & "_rkts," & bm & "_rkbz," & bm & "_kczl," & bm & "_sykczl," & bm & "_yg," & bm & "_bf," & bm & "_bfmx," & bm & "_ckcl," & cwzd & qtzd & "," & bm & "_wjbgrq ," & bm & "_mingc," & bm & "_jiagdm," & bm & "_bfb," & bm & "_kdlk," & bm & "_ID," & bm & "_mscw," & bm & "_wzcw," & bm & "_bfcw from " & bm & " where " & bm & "_num='" & ph1 & "'and " & bm & "_mingc='" & ComboBox2.Text & "'and " & bm & "_jiagdm='" & ComboBox3.Text & "'"
        Dim kk As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If kk.Rows.Count = 0 Then
            MsgBox("查无此批号") : Exit Sub
        End If
        m_dt = kk

        ph.Enabled = False : ComboBox1.Enabled = False : Button1.Enabled = False
        Label9.Text = "QA结果:" & kk.Rows(0)(0)
        Label8.Text = "QA结果说明:" & Null2String(kk.Rows(0)(1))
        tb_x825p_bzxs.Text = Null2String(kk.Rows(0)(2))
        tb_x825p_rkts.Text = Null2String(kk.Rows(0)(4))
        tb_x825p_rkbz.Text = Null2String(kk.Rows(0)(5))
        kc.Text = Null2zero(kk.Rows(0)(6))
        sykc.Text = Null2zero(kk.Rows(0)(7))
        sykc.Tag = Null2zero(kk.Rows(0)(7)) '修改前剩余库存量
        tb_x825p_yg.Text = Null2String(kk.Rows(0)(8))
        TextBoxbfmx.Text = Null2String(kk.Rows(0)(10))
        ckcl.Text = Null2zero(kk.Rows(0)(11)) '仓库存量
        cw.Text = Null2String(kk.Rows(0)(12)) '葛店仓位
        mscw.Text = Null2String(kk.Rows(0)(bm & "_mscw")) '庙山仓位
        wzcw.Text = Null2String(kk.Rows(0)(bm & "_wzcw")) '外租仓位
        bfcw.Text = Null2String(kk.Rows(0)(bm & "_bfcw")) '北方办仓位
        wjbgrq.Text = Null2String(kk.Rows(0)(bm & "_wjbgrq")) '外检报告日期
        ComboBox2.Tag = Null2String(kk.Rows(0)(bm & "_mingc")) '产品代码
        ComboBox3.Tag = Null2String(kk.Rows(0)(bm & "_jiagdm")) '加工代码
        Label23.Visible = True
        Label22.Visible = True
        ComboBox4.Visible = True
        ComboBox5.Visible = True
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        SSSQD.Enabled = True



    End Sub
    '把值转换为0
    Private Function zzero(ByVal str As String) As Integer
        If str = "" Then
            Return 0
        Else
            Return str
        End If
    End Function

    Private Sub Textbfs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textbfs.Leave
        Try
            sykc.Text = sykc.Text - Textbfs.Text
            ckcl.Text = ckcl.Text - Textbfs.Text
            Textbfs.Enabled = False
            kc.Enabled = False
        Catch ex As Exception
            MsgBox("数字输入错误！")
        End Try

    End Sub

    Private Sub ph_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ph.LostFocus
        Try
            Dim sql As String = "select " & bm & "_mingc from " & bm & " where " & bm & "_num= '" & ph.Text.Trim & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_bcfbd(dt, 0, ComboBox2)

            ''''''''''''转代码
            Dim sql2 As String = "select tb_cpdmhz_cpdm from tb_cpdmhz where tb_cpdmhz_cpxz= '" & ComboBox1.Text & "' "
            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
            GS_bcfbd(dt1, 0, ComboBox5)
            ''     

            ComboBox2.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            Dim sql As String = "select " & bm & "_jiagdm from " & bm & " where " & bm & "_mingc= '" & sender.Text & "' "
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_bcfbd(dt, 0, ComboBox3)
            ComboBox3.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "毛油" : bm = "tb_x825pkc"

            Case "成品油" : bm = "tb_h195zkc"
                cwzd = bm & "_cw"

            Case "成品粉" : bm = "tb_x832pkc"
                cwzd = bm & "_cw"
                qtzd = ",tb_x832pkc_kdlk,tb_x832pkc_bfb"

        End Select
    End Sub





    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Try
            Dim sql As String = "select tb_cpdmhz_jgdm from tb_cpdmhz where tb_cpdmhz_cpxz= '" & ComboBox1.Text & "' and  tb_cpdmhz_cpdm ='" & sender.Text & "' "
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            GS_bcfbd(dt, 0, ComboBox4)
            ComboBox2.Text = ComboBox5.Text
        Catch ex As Exception
        End Try
    End Sub


    Private Sub ComboBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.TextChanged
        ComboBox3.Text = ComboBox4.Text
    End Sub

    Private Sub ph_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ph.MouseLeave
        ph.Text = UCase(ph.Text)
    End Sub


    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub
End Class