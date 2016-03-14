Public Class Frfscylsy2
    Public frname As String = ""
    Private Sub Frfscylsy2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '剩余库存大于0，QA审核合格，类别为2.05.009氢氧化钠2.06.002柠檬酸'2.06.004正己烷、2.06.008正丁烷3.06.005/3.06.006/3.01.03铝瓶3.08.006方胶袋2.05.003消泡剂2.05.005葵瓜子油的有效原料
        Dim sql As String = ""
        Dim dt As DataTable = Nothing
        Select Case frname
            Case "精炼生产部"
                sql &= "select tb_i259b_ID,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_p518h,tb_i259b_gg,tb_i259b_num2 from tb_i259b where  (tb_i259b_r596j= '精炼原料' or  tb_i259b_r596j= '通用原料' or tb_i259b_r596j= '油剂包材'or tb_i259b_r596j= '通用包材') and tb_i259b_p518h >0 "
                dt = GF_CreateDataSource(G_cnnstr, sql)
            Case "发酵生产部"
                sql &= "select tb_i259b_ID,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_p518h,tb_i259b_gg,tb_i259b_num2 from tb_i259b where tb_i259b_r596j in ('发酵原料','油剂原料','合成原料','油剂包材','发酵包材') and  tb_i259b_p518h >0"
                dt = GF_CreateDataSource(G_cnnstr, sql)
                '将罐加入这个DATATABLE
                sql = "select '罐' as tb_i259b_i231a," &
                    "tb_tg_gmc as tb_i259b_c24u," &
                    "'' as tb_i259b_h200z," &
                    "tb_tg_num as tb_i259b_num," &
                    "tb_tg_zl as tb_i259b_p518h," &
                    "'' as tb_i259b_gg," &
                    "'' as tb_i259b_num2 from tb_tg where tb_tg_yw='否' and tb_tg_zl>0 and tb_tg_tj>0"
                Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                For Each dr As DataRow In dt2.Rows
                    dt.ImportRow(dr)
                Next
            Case ("粉剂生产部")
                sql &= "select tb_i259b_ID,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_p518h,tb_i259b_gg,tb_i259b_num2 from tb_i259b where (tb_i259b_r596j= '通用原料' or  tb_i259b_r596j= '粉剂原料' or tb_i259b_r596j= '粉剂包材'or tb_i259b_r596j= '通用包材') and tb_i259b_p518h >0"
                sql &= " UNION select tb_i259b_ID,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_p518h,tb_i259b_gg,tb_i259b_num2 from tb_i259b where tb_i259b_i231a='3.08.020' and tb_i259b_p518h >0"
                dt = GF_CreateDataSource(G_cnnstr, sql)
            Case Else

        End Select
        'Dim bds As String = ""
        'Select Case G_js
        '    Case "油剂录入"
        '        bds = " and (tb_i259b_c24u in ('铝瓶(5kg)','铝瓶(20kg)','己烷','柠檬酸','氢氧化钠','消泡剂','IBC桶') or tb_i259b_c24u like '%铝箔袋%')"
        '    Case "发酵录入"
        '        bds = " and (tb_i259b_c24u in ('葵花籽油','氢氧化钠','丁烷') or tb_i259b_c24u like '%铝箔袋%')"
        '    Case "粉剂录入"
        '        bds = " and (tb_i259b_c24u in ('方胶袋','氢氧化钠','柠檬酸') or tb_i259b_c24u like '%铝箔袋%')"
        '    Case "仓库录入", "管理员"
        '        bds = ""
        '    Case Else
        '        MsgBox("这里只有油剂录入,发酵录入,粉剂录入角色才有权利输入数据")
        '        Return
        'End Select
        'Dim sql As String = "select tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_p518h,tb_i259b_gg,tb_i259b_num2 from tb_i259b"
        ''sql &= " where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' and tb_i259b_i231a in ('2.05.009','2.06.002','2.06.004','2.06.008','3.06.005','3.06.006','3.01.03','3.08.006','2.05.003','2.05.005')" '库存大于0
        'sql &= " where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        'sql &= bds & " order by tb_i259b_i231a"
        If dt IsNot Nothing Then
            GS_useviewbydb2(ListView1, dt, 0, 100)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        xz()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub xz()
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("未选择")
        End If
        Me.Owner.Controls("tb_jch_num").Text = ListView1.SelectedItems(0).SubItems(4).Text
        CType(Me.Owner, Frfscylsy).m_strWldm = ListView1.SelectedItems(0).SubItems(1).Text
        CType(Me.Owner, Frfscylsy).m_wlbs = ListView1.SelectedItems(0).SubItems(0).Text
        Me.Close()
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        xz()
    End Sub

End Class