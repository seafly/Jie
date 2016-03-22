Public Class Fr_fiveqq
    Public xpph As String '小批批号
    Private Sub Fr_fiveqq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''''朱露帆于2012年1月4日开发
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        Dim StrSbid As String = sbid.Text
        Dim aa() As String = StrSbid.Split(",")
        Dim cc As String = ""
        For Each bb As String In aa
            Dim sql As String = "select tb_h195zkc_sykczl from  tb_h195zkc where tb_h195zkc_id= '" & bb & "'"
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            cc &= dt.Rows(0)("tb_h195zkc_sykczl") & ","
        Next
        TextBox4.Text = GF_removedh(cc) 'AA剩余库存显示

        Dim sql2 As String = "select tb_x823p_Reference from  tb_x823p where tb_x823p_id= '" & Label11.Text & "'"
        Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
        If dt2.Rows.Count > 0 Then
            TextBox6.Text = Null2String(dt2.Rows(0)(0)) '参考重量显示
        Else
            TextBox6.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''
        If GF_storelog2("完成小批喷雾：" & xpph, "小批喷雾") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        'If tb_p525h_rtph.Text = "" Or tb_p525h_rtpht.Text = "" Then
        '    MsgBox("您没有输入有关乳糖的信息")
        '    Exit Sub
        'End If
        Dim srWeight() As String = kczl.Text.Split(",")
        Dim zzWeight() As String = TextBox4.Text.Split(",")
        Try
            For i As Integer = 0 To srWeight.Length - 1
                If (Convert.ToDecimal(zzWeight(i)) < Convert.ToDecimal(srWeight(i)) Or Convert.ToDecimal(srWeight(i)) < 0) Then
                    MsgBox("小批手动扣油量大于参考重量或者小于0")
                    Exit Sub
                End If
            Next
            
        Catch ex As Exception
            MsgBox("小批手动扣油量输入有误，请检查！")
            Exit Sub
        End Try


        If jckmx(aaph.Text, kczl.Text, ph1.Text, sbid.Text) = False Then
            Exit Sub
        End If

        Dim sql As String
        sql = "update tb_p525h set tb_p525h_czrgh='" & G_dlrgh & "' where tb_p525h_ID in(" & Label2.Text & ")"
        GS_upztxx(G_cnnstr, sql)
        ''''''''''''''
        Dim ylstr As String = Gf_pdylkc(tb_p525h_rtph, Me)

        If ylstr <> "" Then
            MsgBox(ylstr)
            Exit Sub
        End If
        ''''''''''''''''''''合计汇总,
        GS_hjkcylkc(tb_p525h_rtph, tb_p525h_rtzl, Me)
        GS_hjkcylkc(tb_p525h_llz, tb_p525h_llzm, Me)
        GS_hjkcylkc(tb_p525h_rqdbf, tb_p525h_rqdbfm, Me)



        '’‘’‘’‘’‘’‘’‘’‘’
        Dim idall() As String = Label2.Text.Split(",")
        For ids As Integer = 0 To idall.Length - 1
            If GF_modsj("tb_p525h", Me, idall(ids)) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
        Next

        '''''''''''''''''''''''''更新原料库存
        GS_kcylkc(tb_p525h_rtph, Me)
        GS_kcylkc(tb_p525h_llz, Me)
        GS_kcylkc(tb_p525h_rqdbf, Me)
        MsgBox("更新成功！")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    '油批号，油重量，配料单号，粉剂配料的上步ID
    Private Function jckmx(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String, ByVal str4 As String) As Boolean
        Dim sql As String
        Dim sbid() As String = Split(str4, ",") ' 成品油库存表 AA油ID
        Dim ph1() As String = Split(str1, ",") '  AA油批号
        Dim zl1() As String = Split(str2, ",") '  粉剂小批表 手动扣油重量
        Dim ArrayCkzl() As String = Split(TextBox1.Text, ",") '粉剂配料表 AA油扣油明细
        Dim oil() As String = Split(TextBox6.Text, ",") '粉剂配料表 AA油参考重量
        Dim Ckzl As String = ""
        Dim StrOil As String = ""


        If ArrayCkzl.Length <> zl1.Length Then
            MsgBox("手动扣油输入的格式输入错误")
            Return False
        End If
        Dim Hj As Double = 0
        Dim Hja As Double = 0
        Dim Hjb As Double = 0
        For i As Integer = 0 To UBound(sbid)


            sql = "select tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm ,tb_h195zkc_sykczl from tb_h195zkc where tb_h195zkc_id= '" & sbid(i) & "'"

            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Dim cplb As String = Null2String(dt.Rows(0)(0)) '产品类别
            Dim cpdm As String = Null2String(dt.Rows(0)(1)) '产品代码
            Dim jgdm As String = Null2String(dt.Rows(0)(2)) '加工代码
            Dim sykczl As String = Null2zero(dt.Rows(0)("tb_h195zkc_sykczl")) '剩余库存重量
            Dim AAph As String = ph1(i) '配料单号

            ''''''小批表
            Dim AAWeight As Double = Cl_StrMag.YanFormatNum(zl1(i))  '小批手动扣油
            Hj += AAWeight '小批手动扣油合计
            '''''''''

            Dim AAckzl As Double = ArrayCkzl(i) '原粉剂配料 实际扣油重量
            Dim AAckzloil As Double = oil(i) '原粉剂配料 参考重量

            Dim aa As Double = AAckzl + AAWeight '新粉剂配料  实际扣油重量
            Dim bb As Double = AAckzloil - AAWeight '新粉剂配料  参考重量

            If aa < 0 Then
                MessageBox.Show("AA油扣除重量不能为负值")
                Exit Function
            End If

            If sykczl - AAWeight < 0 Then
                'Dim a As Windows.Forms.DialogResult = MessageBox.Show("参考重量为负数，确定执行？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                'If a = DialogResult.No Then
                '    Exit Function
                'End If
                MsgBox("参考重量为负数,请重新选择！")
                Return False
            End If

            StrOil &= bb & "," '新粉剂配料  实际扣油重量明细
            Ckzl &= aa & "," '新粉剂配料  参考重量明细
            ''''''''''''''''
            Hja += aa  '新粉剂配料  实际扣油重量明细合计

            If sykczl < 0 Then
                MsgBox("该AA油批号为'" & AAph & "'已经没有剩余库存可以扣了!")
                Return False
            End If

            '成品油库存表 - 小批手动扣油
            sql = "update tb_h195zkc set tb_h195zkc_sykczl= tb_h195zkc_sykczl-" & AAWeight & " where tb_h195zkc_id= '" & sbid(i) & "'"
            GS_upztxx(G_cnnstr, sql)


            ''成品进出货表 + 小批手动扣的油
            sql = "select * from tb_jch where tb_jch_cplb='" & cplb & "'and tb_jch_mingc='" & cpdm & "' and tb_jch_jiagdm='" & jgdm & "' and tb_jch_num='" & AAph & "'and tb_jch_pldh='" & str3 & "' "
            Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            If dt2.Rows.Count > 0 Then
                sql = "update tb_jch set tb_jch_sl = tb_jch_sl + " & AAWeight & ", tb_jch_rq=getdate() where tb_jch_cplb='" & cplb & "'and tb_jch_mingc='" & cpdm & "' and tb_jch_jiagdm='" & jgdm & "' and tb_jch_num='" & AAph & "'and tb_jch_pldh='" & str3 & "' "
                GS_upztxx(G_cnnstr, sql)
            Else
                sql = "insert into tb_jch(tb_jch_cplb,tb_jch_mingc,tb_jch_jiagdm,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh,tb_jch_pldh) values"
                sql &= "('" & cplb & "','" & cpdm & "','" & jgdm & "','" & AAph & "','出'," & AAWeight & ",getdate(),'生产','5号塔扣油','" & G_dlrgh & "','" & str3 & "')"
                GS_upztxx(G_cnnstr, sql)
            End If

            '5号塔小批扣油明细表
            sql = "insert into tb_FiveBuckleOil (tb_FiveBuckleOil_pldh,tb_FiveBuckleOil_num,tb_FiveBuckleOil_oilweight,tb_FiveBuckleOil_oilnum,tb_FiveBuckleOil_oilcplb,tb_FiveBuckleOil_oilmingc,tb_FiveBuckleOil_oiljiagdm) values"
            sql &= "('" & str3 & "','" & TextBox3.Text & "'," & AAWeight & ",'" & AAph & "','" & cplb & "','" & cpdm & "','" & jgdm & "')"
            GS_upztxx(G_cnnstr, sql)
        Next


        '更新粉剂配料表  新参考重量明细 新实际扣油明细合计   新实际扣油明细
        Dim sql2 As String = "update tb_x823p set tb_x823p_kczl='" & GF_removedh(Ckzl) & "',tb_x823p_t678l=" & Hja & ",tb_x823p_Reference='" & GF_removedh(StrOil) & "' where tb_x823p_id= '" & Label11.Text & "'"
        sql2 &= vbCrLf & "update tb_p525h set tb_p525h_ky='" & str2 & "',tb_p525h_pldh ='" & str3 & "',tb_p525h_aaph='" & str1 & "',tb_p525h_kytj=" & Hj & " where tb_p525h_id= '" & Label13.Text & "'"
        GS_upztxx(G_cnnstr, sql2)

        Return True
    End Function
    Private Sub tb_p525h_rtph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_p525h_rtph.DoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.014'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "乳糖")
    End Sub
    Private Sub tb_p525h_rqdbf_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_p525h_rqdbf.MouseDoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.021' or tb_i259b_i231a='2.04.015' or tb_i259b_i231a='2.04.013'  or tb_i259b_i231a='2.04.022'  or tb_i259b_i231a='2.04.023'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "乳清蛋白粉")
    End Sub

    Private Sub tb_p525h_llz_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tb_p525h_llz.MouseDoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.042'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "卵磷脂")
    End Sub
End Class