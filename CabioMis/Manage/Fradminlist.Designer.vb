<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fradminlist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fradminlist))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.RoleManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.HumenManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Bumen = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gongduan = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CustsSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.流程信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.生产情况统计ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripButton1, Me.ToolStripButton8, Me.ToolStripButton5, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton10, Me.ToolHelp, Me.ToolStripDropDownButton1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1062, 39)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RoleManage, Me.HumenManage})
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(137, 36)
        Me.ToolStripButton6.Text = "人员、角色设定"
        '
        'RoleManage
        '
        Me.RoleManage.Name = "RoleManage"
        Me.RoleManage.Size = New System.Drawing.Size(124, 22)
        Me.RoleManage.Text = "角色设定"
        '
        'HumenManage
        '
        Me.HumenManage.Name = "HumenManage"
        Me.HumenManage.Size = New System.Drawing.Size(124, 22)
        Me.HumenManage.Text = "人员设定"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Bumen, Me.Gongduan})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(137, 36)
        Me.ToolStripButton1.Text = "部门及工段设定"
        '
        'Bumen
        '
        Me.Bumen.Name = "Bumen"
        Me.Bumen.Size = New System.Drawing.Size(124, 22)
        Me.Bumen.Text = "部门设定"
        '
        'Gongduan
        '
        Me.Gongduan.Name = "Gongduan"
        Me.Gongduan.Size = New System.Drawing.Size(124, 22)
        Me.Gongduan.Text = "工段设定"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustsSelect, Me.ReportManage})
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(137, 36)
        Me.ToolStripButton5.Text = "查询及报表权限"
        Me.ToolStripButton5.ToolTipText = "测试"
        '
        'CustsSelect
        '
        Me.CustsSelect.Name = "CustsSelect"
        Me.CustsSelect.Size = New System.Drawing.Size(148, 22)
        Me.CustsSelect.Text = "自定义查询表"
        '
        'ReportManage
        '
        Me.ReportManage.Name = "ReportManage"
        Me.ReportManage.Size = New System.Drawing.Size(148, 22)
        Me.ReportManage.Text = "报表权限"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton2.Text = "批号设定"
        Me.ToolStripButton2.ToolTipText = "测试"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(140, 36)
        Me.ToolStripButton4.Text = "生产流程时间控制"
        Me.ToolStripButton4.ToolTipText = "测试"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton10.Text = "查看日志"
        Me.ToolStripButton10.ToolTipText = "测试"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(68, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.流程信息ToolStripMenuItem, Me.生产情况统计ToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(101, 36)
        Me.ToolStripDropDownButton1.Text = "参数设定"
        Me.ToolStripDropDownButton1.ToolTipText = "参数设定"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem1.Text = "物品信息管理"
        '
        '流程信息ToolStripMenuItem
        '
        Me.流程信息ToolStripMenuItem.Name = "流程信息ToolStripMenuItem"
        Me.流程信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.流程信息ToolStripMenuItem.Text = "原料使用统计"
        '
        '生产情况统计ToolStripMenuItem
        '
        Me.生产情况统计ToolStripMenuItem.Name = "生产情况统计ToolStripMenuItem"
        Me.生产情况统计ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.生产情况统计ToolStripMenuItem.Text = "生产情况统计"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(116, 36)
        Me.ToolStripButton8.Text = "产品类别设定"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'Fradminlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1062, 419)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Fradminlist"
        Me.Text = "系统管理-Fradminlist"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CustsSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Bumen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Gongduan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents RoleManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HumenManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 流程信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 生产情况统计ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
End Class
