<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.Labelid = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"合格", "不合格"})
        Me.ComboBox1.Location = New System.Drawing.Point(127, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "更改小批QA"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(144, 47)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 90
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(63, 47)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 89
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(0, 0)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(41, 12)
        Me.Labelid.TabIndex = 91
        Me.Labelid.Text = "Label2"
        Me.Labelid.Visible = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 97)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "Form4"
        Me.Text = "更改小批QA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents Labelid As System.Windows.Forms.Label
End Class
