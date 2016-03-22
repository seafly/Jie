Public Class Frfg_ss2

    Private Sub Frfg_ss2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        If GF_YZSJ(Me, "tb_mypl_bz") = False Then '验证控件
            Exit Sub
        End If
        '''''''''''''''
        '''''''''''''''''''''''''''''
        If GF_storelog1("手工毛油调配") = False Then
            Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''
        'Me.tb_mypl_myhl.Visible = False
        Dim cfsl As Integer = tb_mypl_p532i.Text '拆分数量
        'Dim jhhl As Double = tb_mypl_myhl.Text  '计划含量
        Dim t1 As String = tb_mypl_num2.Text.Trim : t1 = Replace(t1, "，", ",")
        Dim myphxl() As String = Split(t1, ",") '毛油批号
        Dim t2 As String = tb_mypl_p524h.Text.Trim : t2 = Replace(t2, "，", ",")
        Dim myphxl2() As String = Split(t2, ",") '扣除对应毛油重量
        If UBound(myphxl) <> UBound(myphxl2) Then
            MsgBox("批号与对应扣除重量不符") : Exit Sub
        End If
        Dim t3 As String = tb_mypl_e95w.Text.Trim : t3 = Replace(t3, "，", ",")
        Dim dpzlxl() As String = Split(t3, ",") '精炼单批重量序列
        Dim t4 As String = tb_mypl_q569j.Text.Trim : t4 = Replace(t4, "＃", "#")

        Dim jlpmx() As String = Split(t4, "#") '精炼批明细序列

        If UBound(dpzlxl) + 1 <> cfsl Or UBound(jlpmx) + 1 <> cfsl Then
            MsgBox("拆分数量不符") : Exit Sub
        End If
        Dim ph As String = GF_getnewpath2() '配料批号
        Dim sqltemp As String = Nothing
        Dim hjzl As Double = 0 '合计重量
        Dim idall As String = "" '原来的ID
        For i As Integer = 0 To UBound(myphxl)
            Dim dmymx As String = myphxl(i) '批号
            Dim dkczl As String = myphxl2(i) '对应扣除重量
            Dim sql As String = "select tb_x825p_sykczl,tb_x825p_id from tb_x825p  where tb_x825p_sykczl>=" & dkczl & " and tb_x825p_num='" & dmymx & "'"
            Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            sql = "select tb_x825p_qaspjg from tb_x825p  where tb_x825p_qaspjg='合格' or tb_x825p_qaspjg='待定' and tb_x825p_num='" & dmymx & "'"
            Dim dttemp2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dttemp.Rows.Count = 0 Then
                MsgBox("不存在该批号:" & dmymx & "或者该批号剩余库存小于对应扣除的重量:" & dkczl) : Exit Sub
            ElseIf dttemp2.Rows.Count = 0 Then
                MsgBox("毛油批号QA审批结果不是合格或者待定！") : Exit Sub
            Else

                hjzl = hjzl + dkczl
                idall &= dttemp.Rows(0)(1) & ","
                '更新库存
                sql = "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & dkczl & "  where  tb_x825p_num='" & dmymx & "'" & vbCrLf
                sqltemp = sqltemp & sql
            End If
        Next
        '  Try
        '插入记录到配料
        idall = GF_removedh(idall)
        Dim tsql As String = sqltemp & vbCrLf & "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_q569j,tb_mypl_czrgh,tb_mypl_sbtb,tb_mypl_sbid,tb_mypl_bz) values"
        tsql = tsql & "('" & tb_mypl_a953t.Text & "','" & ph & "','" & ph & "','" & t1 & "','" & t2 & "'," & hjzl & ",'" & t3 & "'," & cfsl & ",'" & t4 & "','" & G_dlrgh & "','tb_x825p','" & idall & "','" & tb_mypl_bz.Text & "')"
        Dim newid As String = GF_upztxx2(G_cnnstr, tsql, "tb_mypl") '得到毛油配料的ID
        '下面依次更新毛油表的下步ID字段
        Dim newidsz() As String = idall.Split(",")
        For i As Integer = 0 To UBound(newidsz)
            GS_gengsb("tb_x825p", newidsz(i), "tb_mypl", newid) '更新上步ID
        Next
        GS_storelog3("手工毛油调配：" & ph, "手工毛油调配") '储存到日志
        MsgBox("手工毛油调配成功！") : Me.Close()
        '   Catch ex As Exception
        '    MsgBox("数据插入出现错误，请检查数据") : Exit Sub
        'End Try

    End Sub
End Class