<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frdrk3kc
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(684, 259)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "毛油库存(双击导入)"
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(678, 239)
        Me.ListView1.TabIndex = 38
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 277)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(684, 259)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "成品油库存(双击导入)"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(678, 239)
        Me.ListView2.TabIndex = 38
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Frdrk3kc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 542)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frdrk3kc"
        Me.Text = "导库存"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
End Class
