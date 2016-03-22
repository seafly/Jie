Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr

Public Class Frhzcp
    Public id As Integer = 0
    Public m_type As string=""
    Private Sub Frcp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        tb_cpdmhz_yxx.Text = tb_cpdmhz_yxx.Items(0).ToString()
        tb_cpdmhz_cpxz.Text = tb_cpdmhz_cpxz.Items(0).ToString()
        tb_cpdmhz_bcpxz.Text = tb_cpdmhz_bcpxz.Items(0).ToString()
        If id <> 0 Then
            Gs_showsj("tb_cpdmhz", Me, id.ToString())
        End If
        Dim sj As String = GF_getstringsql(G_cnnstr, "select  DATEPART(year, GETDATE()) , DATEPART(month, GETDATE()) , DATEPART(day, GETDATE()) ", "-")
        sj = GF_gettrqsj(sj) '得到操作时间
        tb_cpdmhz_bomrq.Text = sj
        tb_cpdmhz_bomczr.Text = G_dlr & "|" & G_dlrgh
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GF_IsLock("tb_cpdmhz", id) = True Then
            MsgBox("该记录已被锁定，不能操作")
            Return
        End If

        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_jgdm ='" & tb_cpdmhz_jgdm.Text & "'and tb_cpdmhz_cpdm ='" & tb_cpdmhz_cpdm.Text & "'and tb_cpdmhz_id<>'" & id & "'")
            If dt1.Rows.Count > 0 Then
                MsgBox("此加工代码存在，请换一个") : Return
            End If

        If GF_modsj("tb_cpdmhz", Me, id.ToString(), G_cnnstrWH) = True And GF_modsj("tb_cpdmhz", Me, id.ToString(), G_cnnstr) = True Then
            MsgBox("修改资料成功！")
            GS_storelog3("修改产品名称：" & tb_cpdmhz_cpdm.Text.Trim & "产品类型：" & tb_cpdmhz_cplx.Text & "加工代码：" & tb_cpdmhz_jgdm.Text, "BOM") '储存到日志
        Else
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If


        Dim aa As Frcpdmhz = CType(Me.Owner, Frcpdmhz)
        'aa.showsj()

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    '原材料标准用量
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If m_type = "DHA" Then
            Return
        End If

        If GF_IsLock("tb_cpdmhz", id) = True Then
            MsgBox("该记录已被锁定，不能操作")
            Return
        End If

        Try
            Dim aa As New Frhzycl
            aa.id = id
            aa.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '包材标准用量
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If m_type = "DHA" Then
            Return
        End If

        If GF_IsLock("tb_cpdmhz", id) = True Then
            MsgBox("该记录已被锁定，不能操作")
            Return
        End If


        Dim aa As New Frhzbc
        aa.id = id
        aa.Show()


    End Sub



    
    Private Sub tb_cpdmhz_bcpxz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cpdmhz_bcpxz.SelectedIndexChanged
        Select Case tb_cpdmhz_bcpxz.Text
            Case "成品油"
                Label5.Visible = True
                tb_cpdmhz_cpy.Visible = True
                Label4.Visible = False
                tb_cpdmhz_my.Visible = False
                Label10.Visible = False
                tb_cpdmhz_gjt.Visible = False
            Case "毛油"
                Label5.Visible = False
                tb_cpdmhz_cpy.Visible = False
                Label4.Visible = True
                tb_cpdmhz_my.Visible = True
                Label10.Visible = False
                tb_cpdmhz_gjt.Visible = False
            Case "干菌体"
                Label5.Visible = False
                tb_cpdmhz_cpy.Visible = False
                Label4.Visible = False
                tb_cpdmhz_my.Visible = False
                Label10.Visible = True
                tb_cpdmhz_gjt.Visible = True
        End Select
    End Sub
End Class