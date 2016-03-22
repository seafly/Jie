<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frprintweb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frprintweb))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripButton
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton5, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(747, 39)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton5
        '
        Me.ToolStripDropDownButton5.Image = CType(resources.GetObject("ToolStripDropDownButton5.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton5.Name = "ToolStripDropDownButton5"
        Me.ToolStripDropDownButton5.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripDropDownButton5.Text = "打印预览"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripButton1.Text = "页面设置"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(65, 36)
        Me.ToolStripDropDownButton2.Text = "打印"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 39)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(747, 391)
        Me.WebBrowser1.TabIndex = 7
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(65, 36)
        Me.ToolStripButton2.Text = "关闭"
        '
        'Frprintweb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 430)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Frprintweb"
        Me.Text = "Frprintweb"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
