<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fryxyb
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
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.nian = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 73)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(909, 434)
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.nian)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(851, 61)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(274, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "查询"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(410, 22)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 10
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(529, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "关闭"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(22, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "请选择统计日期时段："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(230, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "年"
        '
        'nian
        '
        Me.nian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian.FormattingEnabled = True
        Me.nian.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian.Location = New System.Drawing.Point(151, 22)
        Me.nian.Name = "nian"
        Me.nian.Size = New System.Drawing.Size(72, 20)
        Me.nian.TabIndex = 0
        '
        'fryxyb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 507)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "fryxyb"
        Me.Text = "工厂运行月报"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nian As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
