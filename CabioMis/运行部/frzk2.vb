Imports DeepCode.DeepDoDataTable
Public Class frzk2
    Public num As String
    Public dm As String
    Public id As String '原料进出货id
    Public sl As String ''原来输入的数量
    Private Sub frzk2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_i259b_rkrq.Text = Now
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("类别代码是否更改", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If id = "" Then ''''''添加
            '***'在本数据库查找是否有相同代码的信息
            Dim sql As String = "select * from tb_wp where tb_wp_dm='" & tb_i259b_i231a.Text & "'"
            Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            '允许出库的最终日期（系统计算）=最后保质日期+预警时间
            Dim CpEndRq As DateTime = EndRq(tb_i259b_zhbzq.Text)

            If dt.Rows.Count > 0 Then '在武汉有相同的物品代码，才允许入库
                '查找是否有相同批号
                sql = "select * from tb_i259b where tb_i259b_i231a='" & tb_i259b_i231a.Text & "' and tb_i259b_num='" & tb_i259b_num.Text & "'"
                Dim drs As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
                If drs.Rows.Count > 0 Then
                    '根据批号累加武汉数据库
                    sql = " update tb_i259b  set tb_i259b_ckcl = tb_i259b_ckcl + " & tb_i259b_p518h.Text & ",tb_i259b_r596j='" & tb_i259b_r596j.Text & "',tb_i259b_i231a='" & tb_i259b_i231a.Text & "'"
                    sql &= ",tb_i259b_rkrq='" & tb_i259b_rkrq.Text & "',tb_i259b_cpbzrq='" & tb_i259b_cpbzrq.Text & "',tb_i259b_c24u='" & tb_i259b_c24u.Text & "',tb_i259b_zhbzq='" & tb_i259b_zhbzq.Text & "',tb_i259b_y840q='" & tb_i259b_y840q.Text & "',tb_i259b_f122x='" & tb_i259b_f122x.Text & "',tb_i259b_q546i='" & tb_i259b_q546i.Text & "',tb_i259b_bz='" & tb_i259b_bz.Text & "' where tb_i259b_id in(" & drs.Rows(0)("tb_i259b_id") & ")"
                    GS_upztxx(G_cnnstr, sql)
                Else
                    sql = "Insert into tb_i259b(tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_qcrq,tb_i259b_czrgh,tb_i259b_qajgsm,tb_i259b_qaspjg,tb_i259b_qarq,tb_i259b_yxx,tb_i259b_qaczrgh,tb_i259b_gg,tb_i259b_num2,tb_i259b_bf,tb_i259b_bfmx,tb_i259b_jhdh,tb_i259b_cgdh,tb_i259b_sbid,tb_i259b_sfqj,tb_i259b_qjrq,tb_i259b_kczl,tb_i259b_p518h,tb_i259b_ckcl,tb_i259b_r596j,tb_i259b_i231a,tb_i259b_rkrq,tb_i259b_cpbzrq,tb_i259b_zhbzq,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_q546i,tb_i259b_bz,tb_i259b_endrq,tb_i259b_scs,tb_i259b_scrq) "
                    sql &= " select  '" & tb_i259b_c24u.Text & "',tb_i259b_h200z,tb_i259b_num,tb_i259b_qcrq,tb_i259b_czrgh,tb_i259b_qajgsm,tb_i259b_qaspjg,tb_i259b_qarq,tb_i259b_yxx,tb_i259b_qaczrgh,tb_i259b_gg,tb_i259b_num2,tb_i259b_bf,tb_i259b_bfmx,tb_i259b_jhdh,tb_i259b_cgdh,tb_i259b_sbid,tb_i259b_sfqj,tb_i259b_qjrq,tb_i259b_kczl,0 ," & tb_i259b_p518h.Text & " ,'" & tb_i259b_r596j.Text & "','" & tb_i259b_i231a.Text & "' ,'" & tb_i259b_rkrq.Text & "',CONVERT(datetime, CONVERT(varchar(20),tb_i259b_cpbzrq,112) ,112),tb_i259b_zhbzq "
                    sql &= " ,'" & tb_i259b_y840q.Text & "','" & tb_i259b_f122x.Text & "','" & tb_i259b_q546i.Text & "',tb_i259b_bz,tb_i259b_endrq ,tb_i259b_scs,CONVERT(datetime, CONVERT(varchar(20),tb_i259b_scrq,112) ,112)"
                    sql &= " from hbcabiodb.dbo.tb_i259b where  tb_i259b_id=" & tb_i259b_id.Text & ""
                    GS_upztxx(G_cnnstr, sql)
                End If
            Else
                MessageBox.Show("入库物料代码须保持与物料基础表库存代码一致!")
                Return
            End If
            ''********************   
            Dim sql1 As String = "update tb_ylzk set tb_ylzk_rkl=tb_ylzk_rkl-" & tb_i259b_p518h.Text & ",tb_ylzk_yldm='" & tb_i259b_i231a.Text & "',tb_ylzk_lb='" & tb_i259b_r596j.Text & "' where tb_ylzk_yldm2='" & dm & "' and tb_ylzk_num='" & num & "'"
            GS_upztxx(G_cnnstr, sql1)

            ''物料进出货表
            Dim Sqlyljch As String = "Insert into tb_yljch(tb_yljch_yllb,tb_yljch_mc,tb_yljch_cz,tb_yljch_sl,tb_yljch_bz,tb_yljch_czrgh,tb_yljch_rq,tb_yljch_dw,tb_yljch_jhdh,tb_yljch_num,tb_yljch_dm) values('" & tb_i259b_r596j.Text & "','" & tb_i259b_c24u.Text & "','进'," & tb_i259b_p518h.Text & ",'" & "转库  " & tb_i259b_bz.Text & "','" & G_dlrgh & "','" & tb_i259b_rkrq.Text & "','" & tb_i259b_h200z.Text & "','" & tb_i259b_jhdh.Text & "','" & tb_i259b_num.Text & "','" & tb_i259b_i231a.Text & "')"
            Dim strId As String = GF_upztxx2(G_cnnstr, Sqlyljch) '导入原料进出货

            GS_storelog3("添加代码" & tb_i259b_i231a.Text, "湖北物料入库武汉") '储存到日志

            '更新最后保值期为空
            GS_upztxx(G_cnnstr, "update tb_yljch set tb_yljch_zhbzq='' where tb_yljch_ID=" & strId)

        Else  '修改
            ''物料库存表
            sl = CType(sl, Double)
            Dim sql As String = "update tb_i259b set tb_i259b_kczl=tb_i259b_kczl-" & sl & "+" & tb_i259b_p518h.Text & ",tb_i259b_ckcl=tb_i259b_ckcl-" & sl & "+" & tb_i259b_p518h.Text & ",tb_i259b_p518h=tb_i259b_p518h-" & sl & "+ " & tb_i259b_p518h.Text & ""
            sql &= "where tb_i259b_id='" & tb_i259b_id.Text & "'"
            GS_upztxx(G_cnnstr, sql)
            ''物料进出货表
            sql = "update tb_yljch set tb_yljch_yllb= '" & tb_i259b_r596j.Text & "',tb_yljch_mc= '" & tb_i259b_c24u.Text & "',tb_yljch_cz='进',tb_yljch_sl=" & tb_i259b_p518h.Text & ",tb_yljch_bz='" & tb_i259b_bz.Text & "',tb_yljch_czrgh='" & G_dlrgh & "',tb_yljch_rq='" & tb_i259b_rkrq.Text & "',tb_yljch_dw='" & tb_i259b_h200z.Text & "',tb_yljch_jhdh='" & tb_i259b_jhdh.Text & "',tb_yljch_num='" & tb_i259b_num.Text & "',tb_yljch_dm='" & tb_i259b_i231a.Text & "'"
            sql &= " where tb_yljch_id=" & id & ""
            GS_upztxx(G_cnnstr, sql)
            '转库表
            sql = "update tb_ylzk set tb_ylzk_rkl=tb_ylzk_rkl+" & sl & "-" & tb_i259b_p518h.Text & ",tb_ylzk_yldm='" & tb_i259b_i231a.Text & "',tb_ylzk_lb='" & tb_i259b_r596j.Text & "'  where tb_ylzk_yldm2='" & dm & "' and tb_ylzk_num='" & num & "'"
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("修改代码" & tb_i259b_i231a.Text, "湖北物料入库武汉") '储存到日志
            '更新最后保值期为空
            GS_upztxx(G_cnnstr, "update tb_yljch set tb_yljch_zhbzq='' where tb_yljch_ID=" & id)
        End If
        MsgBox("更新成功！")
        Me.Close()
    End Sub

    '变更代码名称

    Private Sub tb_i259b_i231a_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i259b_i231a.LostFocus
        Dim sql As String = "select tb_wp_pm from tb_wp where tb_wp_dm='" & tb_i259b_i231a.Text & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            tb_i259b_c24u.Text = dt.Rows(0)("tb_wp_pm")
        End If
        GS_storelog3("将代码:" & tb_i259b_i231a.Text & "名称变更为" & tb_i259b_c24u.Text, "湖北入库武汉变更代码名称") '储存到日志
    End Sub

    '允许出库的最终日期
    Private Function EndRq(ByVal strdate As Date) As Date
        Dim sql As String = " select tb_warning_rq from tb_warning where tb_warning_dm ='" & tb_i259b_i231a.Text & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim zhbzq As Date = DateAndTime.DateAdd(DateInterval.Day, dt.Rows(0)("tb_warning_rq"), strdate)
            EndRq = zhbzq
        Else
            EndRq = Now.Date
        End If
    End Function
End Class