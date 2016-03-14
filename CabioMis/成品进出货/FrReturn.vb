Public Class FrReturn
    Public bm As String
    Public strid As String
  
    Private Sub FrReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub

    '订单退货提取仓库信息
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTwo.Click

        If TkTwo.Text = "" Then
            MessageBox.Show("没有输入退库数！")
            Exit Sub
        End If
        If StorageTwo.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的仓库信息，需要重新输入么？", "仓库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If

        With ListView1
            If .CheckedItems.Count = 0 Then
                MessageBox.Show("请先勾选，谢谢！")
                Exit Sub
            End If
            If .CheckedItems.Count > 1 Then
                MessageBox.Show("只能选取一条记录！")
                Exit Sub
            End If
            Dim idbs As String = ListView1.CheckedItems(0).SubItems(0).Text
            Dim bmtwo As String = GF_GetListText(ListView1, "tb_returns_bm", 0, 1)
            Dim idtwo As String = GF_GetListText(ListView1, "tb_returns_kcid", 0, 1)
            GS_Storage(Me, ButtonTwo.Name.Substring(6), TkTwo, bmtwo.Trim, idtwo, True)
            Button3.Tag = idbs '备份选择的ID
        End With

    End Sub
   
    '订单退货执行
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If StorageTwo.Text = "" Then
            MessageBox.Show("没有输入相关的仓库信息!", "仓库输入")
            Exit Sub
        End If
 
        Dim idbs As String = ListView1.CheckedItems(0).SubItems(0).Text.Trim
        Dim bmtwo As String = GF_GetListText(ListView1, "tb_returns_bm", 0, 1).ToString.Trim
        Dim idtwo As String = GF_GetListText(ListView1, "tb_returns_kcid", 0, 1).ToString.Trim
        If idbs <> Button3.Tag Then
            MessageBox.Show("您最开始选择的是主键为：" & Button3.Tag & " 这条记录！")
            Exit Sub
        End If
        Dim kc As Double = Double.Parse(TkTwo.Text.Trim)
        '订单退货操作
        returnkc(idtwo, bmtwo, kc, StorageTwo, "订单退换货")
        ''''''
        Dim sql As String = " update tb_returns set tb_returns_status='已退' where  tb_returns_id='" & Button3.Tag & "'  "
        GS_upztxx(G_cnnstr, sql)
        GS_storelog3("对批号" & GF_GetListText(ListView1, "tb_returns_num", 0, 1) & "进行退换货", "订单退换库") '储存到日志
        MessageBox.Show("更新成功！")
        showsj()
        Me.Close()
    End Sub
 
    Private Sub returnkc(ByVal strid As String, ByVal bm As String, ByVal kc As Double, ByVal storage As Control, ByVal sm As String)
        ''''''''''''''''''''''''''更新库存冷库信息
        Dim b As String = Gf_ZdNew(bm, "tb_jch", storage) '新表字段
        Dim a As String = GF_ZlNew(storage) '转为负数

        If ReturnTbname(strid, bm, a, storage.Tag) = False Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''

        Dim sqlkc As String = ""
        Dim aa As String = ""


        aa = GF_GetListText(ListView1, "tb_returns_ddh", 0, 1)
        sqlkc = " update  " & bm & " set " & bm & "_ckcl= " & bm & "_ckcl+" & kc & " "
        sqlkc &= " ," & bm & "_sykczl= " & bm & "_sykczl+" & kc & " where " & bm & "_id='" & strid & "'  "
        GS_upztxx(G_cnnstr, sqlkc)



        Dim sql As String = ""
        '更新进出货冷库信息
        sql = " insert into tb_jch (tb_jch_cplb,tb_jch_num,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_czrgh,tb_jch_mingc,tb_jch_jiagdm,tb_jch_pldh,tb_jch_bz)"
        sql &= " select " & bm & "_cplb," & bm & "_num,'出'," & kc * -1 & ",getdate(),'" & sm & "','" & G_dlrgh & "'," & bm & "_mingc," & bm & "_jiagdm,'" & aa & "','" & RichTextBox1.Text & "'   from "
        sql &= " " & bm & "  where " & bm & "_id='" & strid & "'"
        Dim id As String = GF_upztxx2(G_cnnstr, sql, "tb_jch")
        UpdateTbname(id, "tb_jch", a, b)



    End Sub
    Private Sub showsj()
        Dim sql As String = " select  tb_returns_ID,tb_returns_ddh,tb_returns_returnsl,tb_returns_returnrq,tb_returns_num,tb_returns_cplb,tb_returns_mingc,tb_returns_jiagdm,tb_returns_kczl,tb_returns_ckcl,tb_returns_sykczl,tb_returns_status,tb_returns_bm,tb_returns_kcid from tb_returns where tb_returns_status ='未退'  "
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt, -1, 0)
    End Sub

    Private Sub SSSQX_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Try
            If ListView1.CheckedItems.Count > 1 Then
                MessageBox.Show("只能勾选一条记录！")
                showsj()
            End If
            TkTwo.Text = GF_GetListText(ListView1, "tb_returns_returnsl", 0, 1)
        Catch ex As Exception
        End Try
    End Sub


 
End Class