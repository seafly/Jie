Public Class Frmodyl
    Public id As Integer = 0
    Public qaspjg As String = Nothing
    Public r596j As String = String.Empty
    Private Sub Frmodyl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        If id <> 0 Then
            Gs_showsj("tb_i259b", Me, id.ToString())
        End If
        If qaspjg = "待定" Then
            tb_i259b_num.Visible = True
            Label3.Visible = True
        Else
            tb_i259b_num.Visible = False
            Label3.Visible = False
        End If
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        Dim sql As String = ""

        ' 修改物料库存表批号 
        If GF_modsj("tb_i259b", Me, id.ToString(), G_cnnstr) = True Then
        Else
            MsgBox("请检查输入项目是否正确") : Exit Sub
        End If


        Dim SqlExit = String.Empty
        Dim DtExit As DataTable = Nothing

        '修改物料基础表批号
        If r596j.Contains("包材") = True Then
            SqlExit = "select tb_bcQC_id from tb_bcQC where tb_bcQC_num=  '" & tb_i259b_num.Tag & "' "
            DtExit = GF_CreateDataSource(G_cnnstr, SqlExit.ToString())
            If DtExit.Rows.Count > 0 Then
                sql &= "update tb_bcQC set  tb_bcQC_num='" & tb_i259b_num.Text & "' where tb_bcQC_num= '" & tb_i259b_num.Tag & "'"
            Else
                MessageBox.Show("包材QC没有批号:" & tb_i259b_num.Tag & "无法更新！")
            End If
        Else
            SqlExit = "select tb_t676l_id from tb_t676l where tb_t676l_num=  '" & tb_i259b_num.Tag & "' "
            DtExit = GF_CreateDataSource(G_cnnstr, SqlExit)
            If DtExit.Rows.Count > 0 Then
                sql &= "update tb_t676l set tb_t676l_num='" & tb_i259b_num.Text & "' where tb_t676l_num= '" & tb_i259b_num.Tag & "'"
            Else
                MessageBox.Show("原料QC没有批号:" & tb_i259b_num.Tag & ",无法更新！")
            End If
        End If

        '修改进出货表批号
        SqlExit = "select tb_yljch_id from tb_yljch where tb_yljch_num=  '" & tb_i259b_num.Tag & "' "
        DtExit = GF_CreateDataSource(G_cnnstr, SqlExit)
        If DtExit.Rows.Count > 0 Then
            sql &= "update tb_yljch set tb_yljch_num = '" & tb_i259b_num.Text & "' where tb_yljch_num= '" & tb_i259b_num.Tag & "' "
            GS_upztxx(G_cnnstr, sql)
        Else
            MessageBox.Show("物料进出货没有批号:" & tb_i259b_num.Tag & "！无法更新！")
        End If
        ''储存到日志
        GS_storelog3("修改批号为" & tb_i259b_num.Text & "物料库存信息", "物料进出货")
        MsgBox("更新成功！")
        Me.Close()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub


End Class