Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frdhgz
    Public id As String = ""

    Private Sub Frdhgz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        If id <> "" Then
            Gs_showsj("tb_dhgz", Me, id) '传值
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If id <> "" Then
            If GF_modsj("tb_dhgz", Me, id) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            Dim f As Frjh = Me.Owner
            Dim dtgrid As DataGridView = f.show2
            Dim dt As DataTable = dtgrid.DataSource
            Frjh.ChangeData(Me, dt, id)
        Else
            Dim jj As String = GF_addsj("tb_dhgz", Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_upztxx(G_cnnstr, "update tb_cg set tb_cg_xbid='" & jj & "'where tb_cg_ID= '" & tb_dhgz_sbid.Text & "'") '修改上步表的id
            Dim f As Frjh = Me.Owner
            Dim dtgrid2 As DataGridView = f.show2
            Dim dtgrid1 As DataGridView = f.show1
            Dim dt1 As DataTable = dtgrid1.DataSource
            Dim dt2 As DataTable = dtgrid2.DataSource
            Frjh.ChangeAddData(Me, dt2, jj)
            Frjh.DelRow(dt1, dtgrid1.SelectedRows(0).Cells(0).Value)
        End If

        Me.Close()
    End Sub
    '到货时效 = 到货日期 -  预计到货日期
    Private Sub tb_dhgz_dhrq_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim d1 As DateTime = tb_dhgz_yjdhrq.Text '预计到货日期
            Dim d2 As DateTime = GF_gettrqsj(tb_dhgz_dhrq.Text) '到货日期
            Dim days As Integer = DateDiff(DateInterval.Day, d1, d2)
            tb_dhgz_dhrqpc.Text = days


            Dim yszq As Integer = tb_dhgz_yszq.Text
            Dim tt As DateTime = DateAdd(DateInterval.Day, yszq, d2)
            tb_dhgz_yssx2.Text = tt

        Catch ex As Exception

        End Try


    End Sub

    Private Sub tb_dhgz_dhsl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_dhgz_dhsl.TextChanged
        Try
            Dim l As Double = tb_dhgz_dhsl.Text - tb_dhgz_yjdhl.Text
            tb_dhgz_dhslpc.Text = l
            tb_dhgz_yssl.Text = tb_dhgz_dhsl.Text
        Catch ex As Exception

        End Try

    End Sub
End Class