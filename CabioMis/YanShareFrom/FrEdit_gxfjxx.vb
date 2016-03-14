Public Class FrEdit_gxfjxx

    Private m_point As Point
    Private Sub FrEdit_gxfjxx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb_gxfjxx_isbx.Text = "否"
        Label1.Width = 180
        m_point.X = Label1.Location.X
        m_point.Y = Label1.Location.Y + 25

        AddHandler tb_gxfjxx_lx.SelectedIndexChanged, Sub(send As ComboBox, ev As EventArgs)
                                                          removeCol()
                                                          Select Case send.Text
                                                              Case en_fjxxLx.数字.ToString
                                                                  setNumer(m_point)
                                                              Case en_fjxxLx.文本.ToString
                                                                  setText(m_point)
                                                              Case en_fjxxLx.选择.ToString
                                                                  setXz(m_point)
                                                              Case en_fjxxLx.批号.ToString
                                                                  setPh(m_point)
                                                          End Select
                                                      End Sub
        tb_gxfjxx_lx.DataSource = GetType(en_fjxxLx).YanEnToTb.YanDtToStr("name").Split(",")

        Dim frOpen As FrgxAdd = CType(Application.OpenForms.Item("FrgxAdd"), FrgxAdd)
        Dim sourceDt As DataTable = Nothing       '使用的数据
        If rowBs.Text <> "" Then
            sourceDt = CType(frOpen.showFjxx.DataSource, DataTable).Select("rowBs='" & rowBs.Text & "'").YanArrDrToDb
        End If
        If sourceDt IsNot Nothing Then
            tb_gxfjxx_lx.Text = sourceDt.YanDtValue2("tb_gxfjxx_lx")
            _D.Gs_showsj(Me, sourceDt)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckControlNull(Me) = False Then
            Return
        End If
        Me.DialogResult = DialogResult.OK
    End Sub
    '清除加上的
    Private Sub removeCol()
        MyBase.Controls.Remove(MyBase.Controls("lable2"))
        MyBase.Controls.Remove(MyBase.Controls("lable3"))
        MyBase.Controls.Remove(MyBase.Controls("tb_gxfjxx_vamin"))
        MyBase.Controls.Remove(MyBase.Controls("tb_gxfjxx_vamax"))
        MyBase.Controls.Remove(MyBase.Controls("tb_gxfjxx_vadef"))
        MyBase.Controls.Remove(MyBase.Controls("tb_gxfjxx_dxz"))
    End Sub
    '数字
    Private Sub setNumer(pPoint As Point)
        Dim objPoint As Point = pPoint
        '先加文本
        Dim objLabel As New Label
        objLabel.Text = "值范围"
        objLabel.Name = "lable2"
        objLabel.Height = 23 + 18 * (Int(objLabel.Text.Length / 5))
        objLabel.Width = 180
        objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width + 18
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New yanTextBox
        objCol.Name = "tb_gxfjxx_vamin"
        objCol.Tag = "tb_gxfjxx_vamin"
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
        objCol.Name = "tb_gxfjxx_vamax"
        objCol.Tag = "tb_gxfjxx_vamax"
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
        objLabel.Width = 180
        objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width + 18
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New TextBox
        objCol.Name = "tb_gxfjxx_vadef"
        objCol.Tag = "tb_gxfjxx_vadef"
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
        objLabel.Width = 180
        objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width + 18
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New TextBox
        objCol.Multiline = True
        objCol.Height = 75
        objCol.Name = "tb_gxfjxx_dxz"
        objCol.Tag = "tb_gxfjxx_dxz"
        'objCol.Width = 50
        objCol.Location = objPoint
        objPoint.X += objCol.Width
        MyBase.Controls.Add(objCol)
    End Sub

    '批号
    Private Sub setPh(pPoint As Point)
        Dim objPoint As Point = pPoint
        '先加文本
        Dim objLabel As New Label
        objLabel.Name = "lable2"
        objLabel.Text = "批号"
        objLabel.Height = 23 + 18 * (Int(objLabel.Text.Length / 5))
        objLabel.Width = 180
        objLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        objLabel.Location = objPoint
        objPoint.X += objLabel.Width + 18
        MyBase.Controls.Add(objLabel)

        Dim objCol As TextBox = New TextBox
        'objCol.Multiline = True
        'objCol.Height = 75
        objCol.Name = "tb_gxfjxx_dxz"
        objCol.Tag = "tb_gxfjxx_dxz"
        objCol.ReadOnly=True
        objCol.Width = 200
        objCol.Location = objPoint
        objPoint.X += objCol.Width
        MyBase.Controls.Add(objCol)
        AddHandler objCol.DoubleClick, Sub(send As TextBox, ev As EventArgs)
                                           Dim f As New Frph_List
                                           f.m_strType = en_fjxxLx.选择.ToString
                                           If f.ShowDialog() = DialogResult.OK Then
                                               Dim s As String = ""
                                               For i As Integer = 0 To f.show1.Rows.Count - 1
                                                   If f.show1.Rows(i).Cells("选择").Value = 1 Then
                                                       s &= f.show1.Rows(i).Cells("tb_bcbm_bmmc").Value & ","
                                                   End If
                                               Next
                                               s = s.YanRemovedh
                                               send.Text = s
                                           End If
                                       End Sub
    End Sub
End Class