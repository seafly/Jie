Imports System.Globalization

Public Class Frzdybb_mx

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub

    Private Sub Frzdybb_mx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub

    Private Sub _dataGridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles showl.RowPostPaint
        SetDataGridViewRowXh(e, showl)
    End Sub
    Private Sub SetDataGridViewRowXh(e As DataGridViewRowPostPaintEventArgs, dataGridView As DataGridView)
        Dim solidBrush As New SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor)
        'Dim customColor As Color = Color.FromArgb(50, Color.Gray)
        'Dim solidBrush As New SolidBrush(customColor)
        Dim xh As Integer = e.RowIndex + 1
        e.Graphics.DrawString(xh.ToString(CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4)
    End Sub

End Class