<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frddzxjh
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frddzxjh))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.ToolStripclose = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(929, 395)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(923, 375)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripclose})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(929, 39)
        Me.tsMenu.TabIndex = 47
        Me.tsMenu.Text = "tsMenu"
        '
        'ToolStripclose
        '
        Me.ToolStripclose.Image = CType(resources.GetObject("ToolStripclose.Image"), System.Drawing.Image)
        Me.ToolStripclose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripclose.Name = "ToolStripclose"
        Me.ToolStripclose.Size = New System.Drawing.Size(68, 36)
        Me.ToolStripclose.Text = "关闭"
        '
        'Frddzxjh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 434)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "Frddzxjh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "发货计划"
        Me.GroupBox1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripclose As System.Windows.Forms.ToolStripButton
End Class
