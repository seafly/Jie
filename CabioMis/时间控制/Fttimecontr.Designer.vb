<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fttimecontr
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.CheckBox1_1 = New chencontrol.chentextintz
        Me.CheckBox2_1 = New chencontrol.chentextintz
        Me.CheckBox3_1 = New chencontrol.chentextintz
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Location = New System.Drawing.Point(69, 36)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(132, 16)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "启用小罐至中罐时间"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(355, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "小时"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(355, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "小时"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Location = New System.Drawing.Point(69, 87)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(132, 16)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "启用中罐至大罐时间"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(355, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "小时"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.Location = New System.Drawing.Point(69, 135)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(132, 16)
        Me.CheckBox3.TabIndex = 6
        Me.CheckBox3.Text = "启用大罐至放罐时间"
        Me.CheckBox3.UseVisualStyleBackColor = False
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(240, 193)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(72, 23)
        Me.SSSQX.TabIndex = 96
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(116, 193)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(72, 23)
        Me.SSSQD.TabIndex = 95
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'CheckBox1_1
        '
        Me.CheckBox1_1.Location = New System.Drawing.Point(208, 37)
        Me.CheckBox1_1.Name = "CheckBox1_1"
        Me.CheckBox1_1.Size = New System.Drawing.Size(120, 21)
        Me.CheckBox1_1.TabIndex = 97
        '
        'CheckBox2_1
        '
        Me.CheckBox2_1.Location = New System.Drawing.Point(207, 82)
        Me.CheckBox2_1.Name = "CheckBox2_1"
        Me.CheckBox2_1.Size = New System.Drawing.Size(120, 21)
        Me.CheckBox2_1.TabIndex = 97
        '
        'CheckBox3_1
        '
        Me.CheckBox3_1.Location = New System.Drawing.Point(208, 127)
        Me.CheckBox3_1.Name = "CheckBox3_1"
        Me.CheckBox3_1.Size = New System.Drawing.Size(120, 21)
        Me.CheckBox3_1.TabIndex = 97
        '
        'Fttimecontr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 253)
        Me.Controls.Add(Me.CheckBox3_1)
        Me.Controls.Add(Me.CheckBox2_1)
        Me.Controls.Add(Me.CheckBox1_1)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fttimecontr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生产流程时间控制"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents CheckBox1_1 As chencontrol.chentextintz
    Friend WithEvents CheckBox2_1 As chencontrol.chentextintz
    Friend WithEvents CheckBox3_1 As chencontrol.chentextintz
End Class
