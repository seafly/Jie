<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frjsb_list
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frjsb_list))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.MenuBtYFXMGL = New System.Windows.Forms.ToolStripButton
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ToolStripButton4, Me.MenuBtYFXMGL, Me.ToolStripButton10, Me.ToolHelp})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(916, 39)
        Me.tsMenu.TabIndex = 56
        Me.tsMenu.Text = "tsMenu"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(123, 36)
        Me.ToolStripButton4.Text = "个人培训档案"
        Me.ToolStripButton4.ToolTipText = "个人培训档案"
        '
        'MenuBtYFXMGL
        '
        Me.MenuBtYFXMGL.Image = CType(resources.GetObject("MenuBtYFXMGL.Image"), System.Drawing.Image)
        Me.MenuBtYFXMGL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuBtYFXMGL.Name = "MenuBtYFXMGL"
        Me.MenuBtYFXMGL.Size = New System.Drawing.Size(123, 36)
        Me.MenuBtYFXMGL.Text = "研发项目管理"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(71, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(97, 36)
        Me.ToolStripButton10.Text = "产品加工"
        Me.ToolStripButton10.ToolTipText = "测试"
        '
        'Frjsb_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 462)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "Frjsb_list"
        Me.Text = "技术部"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuBtYFXMGL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
End Class
