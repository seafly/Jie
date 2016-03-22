Module Md_Yw3
    '验证返工油、粉的输入
    Public Function GF_yzfglr(ByVal STR1 As String, ByVal STR2 As String) As Boolean
        If IsNumeric(STR2) = True Then
            If STR1 = "" And CInt(STR2) = 0 Then
                GF_yzfglr = True : Exit Function
            End If
        End If
        If (STR1 <> "" And STR2 = "") Or (STR2 <> "" And STR1 = "") Then
            MsgBox("请确定您的填写正确") : GF_yzfglr = False : Exit Function
        End If
        If STR1 <> "" And IsNumeric(STR2) = False Then
            MsgBox("请正确填写返工重量") : GF_yzfglr = False : Exit Function
        End If
        If STR1 = "" Then
            GF_yzfglr = True : Exit Function
        End If
        STR1 = Replace(STR1, "，", ",") '防止输入中文逗号
        Dim sz() As String = STR1.Split(",")
        For i As Integer = 0 To UBound(sz)
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_jch where tb_jch_yt='返工(混入新批中)' and tb_jch_num='" & sz(i) & "'")
            If dt.Rows.Count = 0 Then
                MsgBox("批号" & sz(i) & "在出货表中用途不是返工") : GF_yzfglr = False : Exit Function
            End If
        Next
        GF_yzfglr = True
    End Function

    'str1为表名，str2为ID序列

    Public Sub GS_showmx(ByVal str1 As String, ByVal str2 As String)
        If str2 = "" Then
            MsgBox("查询无结果！")
            Exit Sub
        End If
        Dim gxsqa As String = ""
        Select Case str1
            Case "tb_p525h"
                gxsqa &= "select * from " & str1 & " where " & str1 & "_num2 in (" & str2 & ")"
            Case "tb_x832p"
                gxsqa &= "select tb_x832p_num,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_sbtb,tb_x832p_sbid,tb_x832p_xbtb,tb_x832p_glid,tb_x832p_czrgh,tb_x832p_bz,tb_x832p_qaczrgh,tb_x832p_qcrq,tb_x832p_cplb,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_n422f,tb_x832p_s624k,tb_x832p_s644l,tb_x832p_c995u,tb_x832p_s613k,tb_x832p_m381e,tb_x832p_j284b,tb_x832p_c12u,tb_x832p_f119x,tb_x832p_s626k,tb_x832p_e106x,tb_x832p_n446f,tb_x832p_h199z,tb_x832p_o468g,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_k308c,tb_x832p_r599j,tb_x832p_d39v,tb_x832p_qcczrgh,tb_x832p_yg,tb_x832p_bzxs,tb_x832p_cfdd,tb_x832p_rkts,tb_x832p_rkbz,tb_x832p_jgrq,tb_x832p_qcsh,tb_x832p_lzlt,tb_x832p_ltzl,tb_x832p_a920s,tb_x832p_z886r,tb_x832p_kdlk,tb_x832p_ybdph,tb_x832p_ybdzl,tb_x832p_ybdpht,tb_x832p_ypybdph,tb_x832p_ypybdzl,tb_x832p_ypybdpht,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_th,tb_x832p_wjbgrq,tb_x832p_yjlbdph,tb_x832p_yjlbdzl,tb_x832p_yjlbdpht from vw_x832p where " & str1 & "_id in (" & str2 & ")"
            Case "tb_n441f"
                gxsqa &= "select * from " & str1 & " where " & str1 & "_id in (" & str2 & ")"
        End Select

        Dim nform As New Frzdybb
        nform.bbname.Text = "明细"
        nform.bbsql.Text = gxsqa
        nform.ShowDialog()

    End Sub

    '变批号列底色
    Public Sub GS_setbackcolor(ByVal list As ListView, ByVal color As Color, ByVal col As Integer)
        For j As Integer = 0 To list.Items.Count - 1
            list.Items(j).UseItemStyleForSubItems = False
            list.Items(j).SubItems(col).BackColor = color
        Next
    End Sub
    '变批号列底色
    Public Sub GS_setbackcolor2(ByVal list As DataGridView, ByVal color As Color, ByVal col As Integer)
        For j As Integer = 0 To list.Rows.Count - 1
            'list.Items(j).UseItemStyleForSubItems = False
            list.Rows(j).Cells(col).Style.BackColor = color
        Next
    End Sub
    '返回某一组原料批号序列str1中id最靠前的一个
    Public Function GF_max(ByVal str1 As String) As String
        Dim a() As String
        a = Split(str1, ",")
        Dim b As Integer = 0
        Dim dt, dt1 As DataTable
        dt = GF_CreateDataSource(G_cnnstr, "select tb_i259b_id from tb_i259b where tb_i259b_num='" & a(0) & "'")
        b = dt.Rows(0)(0)
        For i As Integer = 1 To a.Length - 1
            dt1 = GF_CreateDataSource(G_cnnstr, "select tb_i259b_id from tb_i259b where tb_i259b_num='" & a(i) & "'")
            If dt1.Rows(0)(0) < b Then
                b = dt1.Rows(0)(0)
            End If
        Next
        dt = GF_CreateDataSource(G_cnnstr, "select tb_i259b_num from tb_i259b where tb_i259b_id=" & b & "")
        Return dt.Rows(0)(0)
    End Function
    '返回某一组原料批号序列str1中id最靠前的一个,针对混批/返工计划tb_x832p
    Public Function GF_max2(ByVal str1 As String) As String
        Dim a() As String
        a = Split(str1, ",")
        Dim b As Integer = 0
        Dim dt, dt1 As DataTable
        dt = GF_CreateDataSource(G_cnnstr, "select tb_x832p_id from vw_x832p where tb_x832p_num='" & a(0) & "'")
        b = dt.Rows(0)(0)
        For i As Integer = 1 To a.Length - 1
            dt1 = GF_CreateDataSource(G_cnnstr, "select tb_x832p_id from vw_x832p where tb_x832p_num='" & a(i) & "'")
            If dt1.Rows(0)(0) < b Then
                b = dt1.Rows(0)(0)
            End If
        Next
        dt = GF_CreateDataSource(G_cnnstr, "select tb_x832p_num from vw_x832p where tb_x832p_id=" & b & "")
        Return dt.Rows(0)(0)
    End Function
    '返回某一组原料批号序列str1中id最靠前的一个,针对成品粉零头tb_cpflt
    Public Function GF_max3(ByVal str1 As String) As String
        Dim a() As String
        a = Split(str1, ",")
        Dim b As Integer = 0
        Dim dt, dt1 As DataTable
        dt = GF_CreateDataSource(G_cnnstr, "select tb_cpflt_id from tb_cpflt where tb_cpflt_num='" & a(0) & "'")
        b = dt.Rows(0)(0)
        For i As Integer = 1 To a.Length - 1
            dt1 = GF_CreateDataSource(G_cnnstr, "select tb_cpflt_id from tb_cpflt where tb_cpflt_num='" & a(i) & "'")
            If dt1.Rows(0)(0) < b Then
                b = dt1.Rows(0)(0)
            End If
        Next
        dt = GF_CreateDataSource(G_cnnstr, "select tb_cpflt_num from tb_cpflt where tb_cpflt_id=" & b & "")
        Return dt.Rows(0)(0)
    End Function
End Module
