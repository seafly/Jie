Public Class Frtb_reservedAdd
    Public id As Integer = 0
    Private Sub Frtb_reservedAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        If id <> 0 Then
            Gs_showsj("tb_reserved", Me, id)
        End If
        tb_reserved_wllb.SelectedIndex = 0
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If id = 0 Then

            Dim jj As String = GF_addsj("tb_reserved", Me, G_cnnstr)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_storelog3("对品名:" & tb_reserved_pm.Text & "批号:" & tb_reserved_num.Text & "添加留样管理信息 ", "样品留言管理") '储存到日志
        Else

            If GF_modsj("tb_reserved", Me, id, G_cnnstr) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_storelog3("对品名:" & tb_reserved_pm.Text & "批号:" & tb_reserved_num.Text & "修改留样管理信息 ", "样品留言管理") '储存到日志
        End If
        MessageBox.Show("更新成功！")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    '得到某表的所有字段，除外ExcludeFields(多个用逗号分割)，这构建有效率的查询语句来说很好
    Private Function GF_TableFields(ByVal strcnn As String, ByVal TableName As String, ByVal ExcludeFields As String) As String '得到某表的所有字段，除外ExcludeFields(多个用逗号分割)，这构建有效率的查询语句来说很好
        ExcludeFields = DeepCode.DeepDoStr.GF_zhzfccx(ExcludeFields)
        Dim sql As String = "select tb_biaozdinf_mc from tb_biaozdinf where tb_biaozdinf_biao='" & TableName & "' and tb_biaozdinf_mc not in (" & ExcludeFields & ")"
        Dim zfc As String = DeepCode.DeepDoDataTable.GF_getstringsql(strcnn, sql, "")
        Return zfc
    End Function

  
    Private Sub tb_reserved_wllb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_reserved_wllb.SelectedIndexChanged

        Select Case tb_reserved_wllb.Text
            Case "原料"
                Label10.Visible = False : tb_reserved_nybh.Visible = False '留样编号
                Label2.Visible = False : tb_reserved_qyrq.Visible = False '取样时间
                Label3.Visible = False : tb_reserved_qysl.Visible = False '取样量
                Label11.Visible = False : tb_reserved_kc.Visible = False '库存
                Label7.Visible = True : tb_reserved_yplx.Visible = True '样品流向
                Label8.Visible = True : tb_reserved_nyrq.Visible = True '留样日期
                Label6.Visible = True : tb_reserved_source.Visible = True '来源
                VS()

            Case "成品粉"
                Label7.Visible = False : tb_reserved_yplx.Visible = False '样品流向
                Label8.Visible = False : tb_reserved_nyrq.Visible = False '留样日期
                Label6.Visible = False : tb_reserved_source.Visible = False '来源
                Label10.Visible = True : tb_reserved_nybh.Visible = True '留样编号
                Label3.Visible = True : tb_reserved_qysl.Visible = True '取样量
                Label11.Visible = True : tb_reserved_kc.Visible = True '库存
                Label8.Visible = True : tb_reserved_nyrq.Visible = True '留样日期
                VS()

            Case "成品油"
                Label6.Visible = False : tb_reserved_source.Visible = False '来源
                Label3.Visible = False : tb_reserved_qysl.Visible = False '取样量
                Label2.Visible = False : tb_reserved_qyrq.Visible = False '取样时间
                Label7.Visible = True : tb_reserved_yplx.Visible = True '样品流向
                Label8.Visible = True : tb_reserved_nyrq.Visible = True '留样日期
                Label10.Visible = True : tb_reserved_nybh.Visible = True '留样编号
                Label11.Visible = True : tb_reserved_kc.Visible = True '库存
                VS()
        End Select


    End Sub
    Private Sub VS()
        Label1.Visible = True : tb_reserved_pm.Visible = True '品名
        Label5.Visible = True : tb_reserved_num.Visible = True '批号
        Label9.Visible = True : tb_reserved_nysl.Visible = True '留样量
        Label12.Visible = True : tb_reserved_savedays.Visible = True '已保存时间
    End Sub


    Private Sub tb_reserved_nyrq_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_reserved_nyrq.ValueChanged
        tb_reserved_savedays.Text = DateAndTime.DateDiff(DateInterval.Day, CDate(tb_reserved_nyrq.Text), Now.Date())
    End Sub
End Class