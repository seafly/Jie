<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frtjmenu
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frtjmenu))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.SysReport = New System.Windows.Forms.ToolStripDropDownButton
        Me.AllReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MonthReport = New System.Windows.Forms.ToolStripMenuItem
        Me.WeekReport = New System.Windows.Forms.ToolStripMenuItem
        Me.ElseReport = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomReport = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ModPass = New System.Windows.Forms.ToolStripButton
        Me.upfilebutton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripButton
        Me.changeface1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.changeface11 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface12 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface13 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface14 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface15 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface16 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface17 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface18 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface19 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface20 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface21 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface22 = New System.Windows.Forms.ToolStripMenuItem
        Me.changeface110 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.downfile = New System.Windows.Forms.ToolStripMenuItem
        Me.deletefile = New System.Windows.Forms.ToolStripMenuItem
        Me.editqx = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.DateReport = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SysReport, Me.ToolStripButton3, Me.ToolStripButton7, Me.ToolStripButton4, Me.ModPass, Me.upfilebutton, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.changeface1, Me.ToolHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(965, 39)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SysReport
        '
        Me.SysReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllReport, Me.MonthReport, Me.WeekReport, Me.DateReport, Me.ElseReport, Me.CustomReport})
        Me.SysReport.Image = CType(resources.GetObject("SysReport.Image"), System.Drawing.Image)
        Me.SysReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SysReport.Name = "SysReport"
        Me.SysReport.Size = New System.Drawing.Size(74, 36)
        Me.SysReport.Text = "报表"
        '
        'AllReport
        '
        Me.AllReport.Name = "AllReport"
        Me.AllReport.Size = New System.Drawing.Size(152, 22)
        Me.AllReport.Text = "所有报表"
        '
        'MonthReport
        '
        Me.MonthReport.Name = "MonthReport"
        Me.MonthReport.Size = New System.Drawing.Size(152, 22)
        Me.MonthReport.Text = "月报表"
        '
        'WeekReport
        '
        Me.WeekReport.Name = "WeekReport"
        Me.WeekReport.Size = New System.Drawing.Size(152, 22)
        Me.WeekReport.Text = "周报表"
        '
        'ElseReport
        '
        Me.ElseReport.Name = "ElseReport"
        Me.ElseReport.Size = New System.Drawing.Size(152, 22)
        Me.ElseReport.Text = "其它报表"
        '
        'CustomReport
        '
        Me.CustomReport.Name = "CustomReport"
        Me.CustomReport.Size = New System.Drawing.Size(152, 22)
        Me.CustomReport.Text = "自定义报表"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripButton3.Text = "综合查询"
        Me.ToolStripButton3.ToolTipText = "测试"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripButton7.Text = "组合查询"
        Me.ToolStripButton7.ToolTipText = "测试"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(101, 36)
        Me.ToolStripButton4.Text = "自定义查询"
        Me.ToolStripButton4.ToolTipText = "测试"
        '
        'ModPass
        '
        Me.ModPass.Image = CType(resources.GetObject("ModPass.Image"), System.Drawing.Image)
        Me.ModPass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ModPass.Name = "ModPass"
        Me.ModPass.Size = New System.Drawing.Size(89, 36)
        Me.ModPass.Text = "修改密码"
        '
        'upfilebutton
        '
        Me.upfilebutton.Image = CType(resources.GetObject("upfilebutton.Image"), System.Drawing.Image)
        Me.upfilebutton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.upfilebutton.Name = "upfilebutton"
        Me.upfilebutton.Size = New System.Drawing.Size(89, 36)
        Me.upfilebutton.Text = "上传文件"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(65, 36)
        Me.ToolStripButton1.Text = "备注"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(65, 36)
        Me.ToolStripDropDownButton2.Text = "关闭"
        '
        'changeface1
        '
        Me.changeface1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.changeface11, Me.changeface12, Me.changeface13, Me.changeface14, Me.changeface15, Me.changeface16, Me.changeface17, Me.changeface18, Me.changeface19, Me.changeface20, Me.changeface21, Me.changeface22, Me.changeface110})
        Me.changeface1.Image = CType(resources.GetObject("changeface1.Image"), System.Drawing.Image)
        Me.changeface1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.changeface1.Name = "changeface1"
        Me.changeface1.Size = New System.Drawing.Size(74, 36)
        Me.changeface1.Text = "切换"
        '
        'changeface11
        '
        Me.changeface11.Name = "changeface11"
        Me.changeface11.Size = New System.Drawing.Size(130, 22)
        Me.changeface11.Text = "油剂部"
        '
        'changeface12
        '
        Me.changeface12.Name = "changeface12"
        Me.changeface12.Size = New System.Drawing.Size(130, 22)
        Me.changeface12.Text = "粉剂部"
        '
        'changeface13
        '
        Me.changeface13.Name = "changeface13"
        Me.changeface13.Size = New System.Drawing.Size(130, 22)
        Me.changeface13.Text = "技术部"
        '
        'changeface14
        '
        Me.changeface14.Name = "changeface14"
        Me.changeface14.Size = New System.Drawing.Size(130, 22)
        Me.changeface14.Text = "QA"
        '
        'changeface15
        '
        Me.changeface15.Name = "changeface15"
        Me.changeface15.Size = New System.Drawing.Size(130, 22)
        Me.changeface15.Text = "QC"
        '
        'changeface16
        '
        Me.changeface16.Name = "changeface16"
        Me.changeface16.Size = New System.Drawing.Size(130, 22)
        Me.changeface16.Text = "EHS"
        '
        'changeface17
        '
        Me.changeface17.Name = "changeface17"
        Me.changeface17.Size = New System.Drawing.Size(130, 22)
        Me.changeface17.Text = "设备动力部"
        '
        'changeface18
        '
        Me.changeface18.Name = "changeface18"
        Me.changeface18.Size = New System.Drawing.Size(130, 22)
        Me.changeface18.Text = "运行部"
        '
        'changeface19
        '
        Me.changeface19.Name = "changeface19"
        Me.changeface19.Size = New System.Drawing.Size(130, 22)
        Me.changeface19.Text = "采购部"
        '
        'changeface20
        '
        Me.changeface20.Name = "changeface20"
        Me.changeface20.Size = New System.Drawing.Size(130, 22)
        Me.changeface20.Text = "人力资源部"
        '
        'changeface21
        '
        Me.changeface21.Name = "changeface21"
        Me.changeface21.Size = New System.Drawing.Size(130, 22)
        Me.changeface21.Text = "报表"
        '
        'changeface22
        '
        Me.changeface22.Name = "changeface22"
        Me.changeface22.Size = New System.Drawing.Size(130, 22)
        Me.changeface22.Text = "全局"
        '
        'changeface110
        '
        Me.changeface110.Name = "changeface110"
        Me.changeface110.Size = New System.Drawing.Size(130, 22)
        Me.changeface110.Text = "系统管理"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(65, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'ListView1
        '
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 39)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(965, 363)
        Me.ListView1.TabIndex = 13
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.downfile, Me.deletefile, Me.editqx})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(119, 70)
        '
        'downfile
        '
        Me.downfile.Name = "downfile"
        Me.downfile.Size = New System.Drawing.Size(118, 22)
        Me.downfile.Text = "打开"
        '
        'deletefile
        '
        Me.deletefile.Name = "deletefile"
        Me.deletefile.Size = New System.Drawing.Size(118, 22)
        Me.deletefile.Text = "删除"
        '
        'editqx
        '
        Me.editqx.Name = "editqx"
        Me.editqx.Size = New System.Drawing.Size(118, 22)
        Me.editqx.Text = "编辑权限"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "png-1101.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 408)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(965, 100)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "共享文档"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(959, 80)
        Me.ListView2.TabIndex = 16
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'DateReport
        '
        Me.DateReport.Name = "DateReport"
        Me.DateReport.Size = New System.Drawing.Size(152, 22)
        Me.DateReport.Text = "日报表"
        '
        'frtjmenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 508)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frtjmenu"
        Me.Text = "报表"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents changeface1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents changeface11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface18 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents changeface110 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents downfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents deletefile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents upfilebutton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SysReport As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AllReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeekReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElseReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModPass As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents editqx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateReport As System.Windows.Forms.ToolStripMenuItem
End Class
