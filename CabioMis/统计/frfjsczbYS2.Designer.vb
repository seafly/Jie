<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frfjsczbYS2
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
        Me.ToExcel = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(412, 20)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 10
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 73)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(909, 374)
        Me.ListView1.TabIndex = 9
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(305, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(68, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "请选择统计期"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nian1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(933, 61)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(654, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "成品粉明细"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(550, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "保存锁定"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian1.Location = New System.Drawing.Point(151, 22)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(72, 20)
        Me.nian1.TabIndex = 0
        '
        'frfjsczbYS2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 459)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frfjsczbYS2"
        Me.Text = "粉剂报表"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
