Public Class Frcpgf
    Public id As String = ""
    Private Sub Frcpgf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        If id <> 0 Then
            Gs_showsj("tb_cpdmhz", Me, id)
        End If
      
        Dim sj As String = GF_getstringsql(G_cnnstr, "select  DATEPART(year, GETDATE()) , DATEPART(month, GETDATE()) , DATEPART(day, GETDATE()) ", "-")
        sj = GF_gettrqsj(sj) '得到操作时间
        tb_cpdmhz_cpgfrq.Text = sj
        tb_cpdmhz_cpgfczr.Text = G_dlr & "|" & G_dlrgh
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GF_modsj("tb_cpdmhz", Me, id, G_cnnstrWH) = True And GF_modsj("tb_cpdmhz", Me, id, G_cnnstr) = True Then
            MsgBox("添加成功！")
            GS_storelog3("修改产品名称：" & tb_cpdmhz_cpdm.Text.Trim & "产品类型：" & tb_cpdmhz_cplx.Text & "加工代码：" & tb_cpdmhz_jgdm.Text, "产品规范") '储存到日志
        Else
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''产品代码&产能&BOM汇总 界面中只负责产品规范的输入，但是规范不在该界面显示

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class