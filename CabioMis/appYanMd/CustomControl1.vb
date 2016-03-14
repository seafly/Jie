Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization

''' <summary>
''' 只能输入数字的textbox
''' </summary>
Partial Public Class yanTextBox
    Inherits TextBox

    '数字最大值
    Public m_vaMax = 0
    '数字最小值
    Public m_vaMin = 0
    '数字不在范围内是否变色
    Public m_blVapd As Boolean = False

    '原来的颜色
    Private m_color As Color = Nothing

    Private Sub checkNum(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim arrI As Integer() = New Integer() {22, 3, 8, 46}
        '排除例外键
        If Not IsNumeric(e.KeyChar) Then
            For Each iNum As Integer In arrI
                If iNum = Asc(e.KeyChar) Then
                    'e.Handled = True
                    Return
                End If
            Next
        Else
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub checkChange(ByVal sender As Object, e As System.EventArgs) Handles MyBase.TextChanged
        Dim objText As TextBox = sender
        '不为数字直接退出
        If Not IsNumeric(objText.Text) Then
            objText.Text = ""
        End If
        If m_blVapd Then
            Try
                If m_color = Nothing Then
                    m_color = objText.ForeColor
                End If
                If CType(_S.YanFormatNum3(objText.Text), Double) > m_vaMax Or CType(_S.YanFormatNum3(objText.Text), Double) < m_vaMin Then
                    objText.ForeColor = Color.Red
                Else
                    objText.ForeColor = m_color
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class

Partial Public Class yanDaTaGridView
    Inherits DataGridView

    Private Sub _dataGridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles MyBase.RowPostPaint
        SetDataGridViewRowXh(e, sender)
    End Sub
    Private Sub SetDataGridViewRowXh(e As DataGridViewRowPostPaintEventArgs, objDv As DataGridView)
        Dim solidBrush As New SolidBrush(objDv.RowHeadersDefaultCellStyle.ForeColor)
        Dim xh As Integer = e.RowIndex + 1
        If e.RowIndex = objDv.Rows.Count - 1 And objDv.Tag = "showHj" Then
            '显示合计
            e.Graphics.DrawString("合计".ToString(CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        Else
            e.Graphics.DrawString(xh.ToString(CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End If
    End Sub
End Class



