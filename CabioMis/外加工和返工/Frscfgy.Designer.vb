<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frscfgy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frscfgy))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripclose = New System.Windows.Forms.ToolStripButton()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.rq = New chencontrol.chendatepick()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtJhjgq = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripclose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(747, 39)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton1.Text = "确定选择"
        '
        'ToolStripclose
        '
        Me.ToolStripclose.Image = CType(resources.GetObject("ToolStripclose.Image"), System.Drawing.Image)
        Me.ToolStripclose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripclose.Name = "ToolStripclose"
        Me.ToolStripclose.Size = New System.Drawing.Size(68, 36)
        Me.ToolStripclose.Text = "关闭"
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.LabelEdit = True
        Me.ListView1.Location = New System.Drawing.Point(0, 39)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(747, 328)
        Me.ListView1.TabIndex = 20
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'rq
        '
        Me.rq.BackColor = System.Drawing.Color.White
        Me.rq.Location = New System.Drawing.Point(291, 8)
        Me.rq.Name = "rq"
        Me.rq.Size = New System.Drawing.Size(119, 21)
        Me.rq.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(189, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "外加工油出库日期"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(437, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "计划加工期"
        '
        'txtJhjgq
        '
        Me.txtJhjgq.Location = New System.Drawing.Point(509, 8)
        Me.txtJhjgq.Name = "txtJhjgq"
        Me.txtJhjgq.Size = New System.Drawing.Size(226, 21)
        Me.txtJhjgq.TabIndex = 135
        '
        'Frscfgy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 367)
        Me.Controls.Add(Me.txtJhjgq)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rq)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Frscfgy"
        Me.Text = "外加工油发出"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripclose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents rq As chencontrol.chendatepick
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtJhjgq As System.Windows.Forms.TextBox
End Class
