Public Class Fr_qq
    Public xpph As String '小批批号
    Private Sub Fr_qq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

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
        Dim sql As String
        sql = "update tb_p525h set tb_p525h_czrgh='" & G_dlrgh & "'where tb_p525h_ID in(" & Label2.Text & ")"

        GS_upztxx(G_cnnstr, sql)
        ''''''''''''''
        Dim ylstr As String = Gf_pdylkc(tb_p525h_rtph, Me)

        If ylstr <> "" Then
            MsgBox(ylstr)
            Exit Sub
        End If
        ''''''''''''''''''''合计汇总,
        GS_hjkcylkc(tb_p525h_rtph, tb_p525h_rtzl, Me)

        '’‘’‘’‘’‘’‘’‘’‘’
        Dim idall() As String = Label2.Text.Split(",")
        For ids As Integer = 0 To idall.Length - 1
            If GF_modsj("tb_p525h", Me, idall(ids)) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
        Next

        '''''''''''''''''''''''''更新原料库存
        GS_kcylkc(tb_p525h_rtph, Me)


        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

 
    Private Sub tb_p525h_rtph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_p525h_rtph.DoubleClick
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.04.014'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "乳糖")
    End Sub
End Class