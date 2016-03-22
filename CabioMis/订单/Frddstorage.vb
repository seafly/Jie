Public Class Frddstorage

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim aa As Frkcxs = Me.Owner
        With aa

            Dim dt2 As DataTable = .show2.DataSource
            Dim dt1 As DataTable = .show1.DataSource
            Dim dtr As DataRow = dt2.NewRow
            For i As Integer = 0 To .show1.ColumnCount - 1
                dtr(i) = .show1.SelectedRows(0).Cells(i).Value
            Next

            Dim szsl() As String = StorageOne.Text.Split(",")
            Dim szzdm() As String = Convert.ToString(StorageOne.Tag).Split(",")
            dtr(5) = kc.Text
            For j As Integer = 0 To UBound(szsl)
                dtr(szzdm(j)) = szsl(j)
            Next

            dt2.Rows.Add(dtr)
            .GroupBox3.Text = "显示" & .show1.RowCount & "条记录"
            .GroupBox1.Text = "显示" & .show2.RowCount & "条记录"

        End With
        MessageBox.Show("更新成功！")
        Me.Close()

    End Sub

    Private Sub Frddstorage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        kc.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    '打开仓库界面
    Private Sub ButtonOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOne.Click
        If StorageOne.Text <> "" Then
            Dim a As Windows.Forms.DialogResult
            a = MessageBox.Show("已经输入相关的冷库信息，需要重新输入么？", "冷库输入", MessageBoxButtons.YesNo)
            If a = DialogResult.No Then
                Exit Sub
            End If
        End If
        GS_Storage(Me, ButtonOne.Name.Substring(6), kc, tbname.Text, id.Text)
    End Sub
End Class