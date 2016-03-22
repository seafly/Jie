''' <summary>
''' 暂时没用
''' </summary>
Public Class Frgn_list

    Private Sub Frgn_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' 设置头部菜单
    ''' </summary>
    Public Sub setMenu()
        tsMenu.Items.Clear()
        '添加BC工艺菜单
        Dim dt As DataTable = GetType(en_kcyt).YanEnToTb
        Dim m As ToolStripButton
        For i As Integer = 0 To dt.Rows.Count - 1
            m = New ToolStripButton
            m.Image = Frshow_list.ToolStripButton2.Image
            m.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            m.Text = dt.YanDtValue2("name", i)
            m.Tag = dt.Rows(i).YanDrToDb
            AddHandler m.Click, Sub(s As System.Object, ev As System.EventArgs)

                                End Sub
            tsMenu.Items.Add(m)
        Next
        '关闭菜单的加载
        m = New ToolStripButton
        m.Image = frwjmenu.ToolStripDropDownButton2.Image
        m.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        m.Text = "关闭"
        AddHandler m.Click, Sub()
                                Me.Close()
                            End Sub
        tsMenu.Items.Add(m)
    End Sub
End Class