<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frfg_ss
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
        Me.Button5 = New System.Windows.Forms.Button
        Me.Chentextzs1 = New chencontrol.chentextzs
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ListView4 = New System.Windows.Forms.ListView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ListView3 = New System.Windows.Forms.ListView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.ListView6 = New System.Windows.Forms.ListView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Chentextzs2 = New chencontrol.chentextzs
        Me.gs3 = New chencontrol.chentextzs
        Me.Chentextzs3 = New chencontrol.chentextzs
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Chentextzs4 = New chencontrol.chentextzs
        Me.Label2 = New System.Windows.Forms.Label
        Me.Chentextzs5 = New chencontrol.chentextzs
        Me.Label3 = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"直接选取", "零头混配", "高低混配"})
        Me.ComboBox1.Location = New System.Drawing.Point(548, 9)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(95, 20)
        Me.ComboBox1.TabIndex = 90
        '
        'Button5
        '
        Me.Button5.AutoSize = True
        Me.Button5.Location = New System.Drawing.Point(696, 7)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 82
        Me.Button5.Text = "混合到配料"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Chentextzs1
        '
        Me.Chentextzs1.Location = New System.Drawing.Point(71, 7)
        Me.Chentextzs1.Name = "Chentextzs1"
        Me.Chentextzs1.Size = New System.Drawing.Size(38, 21)
        Me.Chentextzs1.TabIndex = 88
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(649, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(41, 23)
        Me.Button4.TabIndex = 86
        Me.Button4.Text = "查询"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "毛油重量"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.ListView4)
        Me.GroupBox4.Location = New System.Drawing.Point(425, 269)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(423, 104)
        Me.GroupBox4.TabIndex = 93
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "中间值2"
        '
        'ListView4
        '
        Me.ListView4.CheckBoxes = True
        Me.ListView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView4.FullRowSelect = True
        Me.ListView4.GridLines = True
        Me.ListView4.Location = New System.Drawing.Point(3, 17)
        Me.ListView4.MultiSelect = False
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(417, 84)
        Me.ListView4.TabIndex = 37
        Me.ListView4.UseCompatibleStateImageBehavior = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ListView3)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 269)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(410, 104)
        Me.GroupBox3.TabIndex = 94
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "中间值1"
        '
        'ListView3
        '
        Me.ListView3.CheckBoxes = True
        Me.ListView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(3, 17)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(404, 84)
        Me.ListView3.TabIndex = 37
        Me.ListView3.UseCompatibleStateImageBehavior = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView2)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(839, 107)
        Me.GroupBox2.TabIndex = 91
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "高于含量设定值"
        '
        'ListView2
        '
        Me.ListView2.CheckBoxes = True
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(833, 87)
        Me.ListView2.TabIndex = 37
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(836, 106)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "低于含量设定值"
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(830, 86)
        Me.ListView1.TabIndex = 37
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.ListView6)
        Me.GroupBox6.Location = New System.Drawing.Point(9, 403)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(839, 227)
        Me.GroupBox6.TabIndex = 95
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "组合"
        '
        'ListView6
        '
        Me.ListView6.CheckBoxes = True
        Me.ListView6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView6.FullRowSelect = True
        Me.ListView6.GridLines = True
        Me.ListView6.Location = New System.Drawing.Point(3, 17)
        Me.ListView6.MultiSelect = False
        Me.ListView6.Name = "ListView6"
        Me.ListView6.Size = New System.Drawing.Size(833, 207)
        Me.ListView6.TabIndex = 37
        Me.ListView6.UseCompatibleStateImageBehavior = False
        Me.ListView6.View = System.Windows.Forms.View.Details
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(115, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "至"
        '
        'Chentextzs2
        '
        Me.Chentextzs2.Location = New System.Drawing.Point(138, 7)
        Me.Chentextzs2.Name = "Chentextzs2"
        Me.Chentextzs2.Size = New System.Drawing.Size(38, 21)
        Me.Chentextzs2.TabIndex = 89
        '
        'gs3
        '
        Me.gs3.Location = New System.Drawing.Point(277, 7)
        Me.gs3.Name = "gs3"
        Me.gs3.Size = New System.Drawing.Size(31, 21)
        Me.gs3.TabIndex = 98
        '
        'Chentextzs3
        '
        Me.Chentextzs3.Location = New System.Drawing.Point(217, 7)
        Me.Chentextzs3.Name = "Chentextzs3"
        Me.Chentextzs3.Size = New System.Drawing.Size(31, 21)
        Me.Chentextzs3.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(182, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "含量"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(254, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "至"
        Me.Label7.Visible = False
        '
        'Chentextzs4
        '
        Me.Chentextzs4.Location = New System.Drawing.Point(373, 7)
        Me.Chentextzs4.Name = "Chentextzs4"
        Me.Chentextzs4.Size = New System.Drawing.Size(57, 21)
        Me.Chentextzs4.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(314, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "参考含量"
        '
        'Chentextzs5
        '
        Me.Chentextzs5.Location = New System.Drawing.Point(495, 7)
        Me.Chentextzs5.Name = "Chentextzs5"
        Me.Chentextzs5.Size = New System.Drawing.Size(38, 21)
        Me.Chentextzs5.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(436, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "参考重量"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(782, 7)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(63, 23)
        Me.SSSQX.TabIndex = 104
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'Frfg_ss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 642)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.Chentextzs5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chentextzs4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gs3)
        Me.Controls.Add(Me.Chentextzs3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Chentextzs2)
        Me.Controls.Add(Me.Chentextzs1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frfg_ss"
        Me.Text = "毛油混配"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Chentextzs1 As chencontrol.chentextzs
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView4 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView6 As System.Windows.Forms.ListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Chentextzs2 As chencontrol.chentextzs
    Friend WithEvents gs3 As chencontrol.chentextzs
    Friend WithEvents Chentextzs3 As chencontrol.chentextzs
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Chentextzs4 As chencontrol.chentextzs
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Chentextzs5 As chencontrol.chentextzs
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
End Class
