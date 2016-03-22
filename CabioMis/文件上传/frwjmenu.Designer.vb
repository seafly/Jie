<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frwjmenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frwjmenu))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.downfile = New System.Windows.Forms.ToolStripMenuItem
        Me.deletefile = New System.Windows.Forms.ToolStripMenuItem
        Me.sharefile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "txt.png")
        '
        'ListView1
        '
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(309, 410)
        Me.ListView1.TabIndex = 15
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.downfile, Me.deletefile, Me.sharefile})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(119, 70)
        '
        'downfile
        '
        Me.downfile.Name = "downfile"
        Me.downfile.Size = New System.Drawing.Size(118, 22)
        Me.downfile.Text = "下载"
        '
        'deletefile
        '
        Me.deletefile.Name = "deletefile"
        Me.deletefile.Size = New System.Drawing.Size(118, 22)
        Me.deletefile.Text = "删除"
        '
        'sharefile
        '
        Me.sharefile.Name = "sharefile"
        Me.sharefile.Size = New System.Drawing.Size(118, 22)
        Me.sharefile.Text = "设置共享"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripDropDownButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(724, 39)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripButton6.Text = "上传文件"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(65, 36)
        Me.ToolStripDropDownButton2.Text = "关闭"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 430)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "个人文档"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView2)
        Me.GroupBox2.Location = New System.Drawing.Point(321, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(391, 430)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "共享文档"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(385, 410)
        Me.ListView2.TabIndex = 15
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'frwjmenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 473)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frwjmenu"
        Me.Text = "文件中心"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents deletefile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents downfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents sharefile As System.Windows.Forms.ToolStripMenuItem
End Class
