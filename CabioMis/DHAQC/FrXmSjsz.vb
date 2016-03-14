Public Class FrXmSjsz
    Public m_Id As Integer = 0
    Public m_objMyDataCl As New myDataCl  '窗体数据操作对象
    Private m_dataRow As DataRow        '使用的数据行
    Private m_point As Point

    Private Sub FrXmSjsz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_objMyDataCl.setDataTb("tb_QcXm", m_Id)
        m_dataRow = m_objMyDataCl.sorTable.Tables("tb_QcXm").Rows(0)

        Label1.Width = 70
        m_point.X = Label1.Location.X
        m_point.Y = Label1.Location.Y + 25

        Select Case m_dataRow("tb_QcXm_lx").ToString
            Case "数字"
                setNumer(m_point)
            Case "文本"
                setText(m_point)
            Case "选择"
                setXz(m_point)
        End Select

        _D.Gs_showsj(Me, m_objMyDataCl.sorTable.Tables("tb_QcXm"))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim tRow As DataRow = m_objMyDataCl.m_Ds.Tables("tb_QcXm_xmmc").Rows(0)  '记录物料的数据
        _D.Gs_updasj(Me, m_objMyDataCl.m_Ds.Tables("tb_QcXm"), True)

        MyBase.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tb_QcXm_lx.SelectedIndexChanged
        removeCol()
        Select Case CType(sender, ComboBox).Text
            Case "数字"
                setNumer(m_point)
            Case "文本"
                setText(m_point)
            Case "选择"
                setXz(m_point)
        End Select
    End Sub
    '清除加上的
    Private Sub removeCol()
        MyBase.Controls.Remove(MyBase.Controls("lable2"))
        MyBase.Controls.Remove(MyBase.Controls("lable3"))
        MyBase.Controls.Remove(MyBase.Controls("tb_QcXm_vaMin"))
        MyBase.Controls.Remove(MyBase.Controls("tb_QcXm_vaMax"))
        MyBase.Controls.Remove(MyBase.Controls("tb_QcXm_vaDef"))
        MyBase.Controls.Remove(MyBase.Controls("tb_QcXm_dxz"))
    End Sub
    '数字
    Private Sub setNumer(pPoint As Point)
        Dim objPoint As Point = pPoint
        '先加文本
        Dim objLabel As New Label
        objLabel.Text = "值范围"
        objLabel.Name = "lable2"
        objLabel.Height = 23 + 18 * (Int(objLabel.Text.Length / 5))
        objLabel.Width = 70
        objLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New yanTextBox
        objCol.Name = "tb_QcXm_vaMin"
        objCol.Tag = "tb_QcXm_vaMin"
        objCol.Width = 50
        objCol.Location = objPoint
        objPoint.X += objCol.Width
        MyBase.Controls.Add(objCol)

        objLabel = New Label
        objLabel.Name = "lable3"
        objLabel.Text = "-"
        objLabel.Height = 23 + 18 * (Int(objLabel.Text.Length / 5))
        objLabel.Width = 10
        objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width
        MyBase.Controls.Add(objLabel)

        objCol = New yanTextBox
        objCol.Name = "tb_QcXm_vaMax"
        objCol.Tag = "tb_QcXm_vaMax"
        objCol.Width = 50
        objCol.Location = objPoint
        MyBase.Controls.Add(objCol)
    End Sub

    '文本
    Private Sub setText(pPoint As Point)
        Dim objPoint As Point = pPoint
        '先加文本
        Dim objLabel As New Label
        objLabel.Name = "lable2"
        objLabel.Text = "默认值"
        objLabel.Height = 23 + 18 * (Int(objLabel.Text.Length / 5))
        objLabel.Width = 70
        objLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New TextBox
        objCol.Name = "tb_QcXm_vaDef"
        objCol.Tag = "tb_QcXm_vaDef"
        'objCol.Width = 50
        objCol.Location = objPoint
        objPoint.X += objCol.Width
        MyBase.Controls.Add(objCol)
    End Sub
    '选择
    Private Sub setXz(pPoint As Point)
        Dim objPoint As Point = pPoint
        '先加文本
        Dim objLabel As New Label
        objLabel.Name = "lable2"
        objLabel.Text = "项目(一行一个)"
        objLabel.Height = 23 + 18 * (Int(objLabel.Text.Length / 5))
        objLabel.Width = 70
        objLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New TextBox
        objCol.Multiline = True
        objCol.Height = 75
        objCol.Name = "tb_QcXm_dxz"
        objCol.Tag = "tb_QcXm_dxz"
        'objCol.Width = 50
        objCol.Location = objPoint
        objPoint.X += objCol.Width
        MyBase.Controls.Add(objCol)
    End Sub
End Class