<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_one
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
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Chentextzs2 = New chencontrol.chentextzs()
        Me.Chentextzs1 = New chencontrol.chentextzs()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Chentextzs3 = New chencontrol.chentextzs()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_x823p_mingc = New System.Windows.Forms.ComboBox()
        Me.tb_x823p_jiagdm = New System.Windows.Forms.ComboBox()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(145, 22)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(61, 20)
        Me.ComboBox2.TabIndex = 71
        '
        'Button5
        '
        Me.Button5.AutoSize = True
        Me.Button5.Location = New System.Drawing.Point(896, 23)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 59
        Me.Button5.Text = "混合到配料"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Chentextzs2
        '
        Me.Chentextzs2.Location = New System.Drawing.Point(212, 23)
        Me.Chentextzs2.Name = "Chentextzs2"
        Me.Chentextzs2.Size = New System.Drawing.Size(57, 21)
        Me.Chentextzs2.TabIndex = 69
        '
        'Chentextzs1
        '
        Me.Chentextzs1.Location = New System.Drawing.Point(89, 22)
        Me.Chentextzs1.Name = "Chentextzs1"
        Me.Chentextzs1.Size = New System.Drawing.Size(50, 21)
        Me.Chentextzs1.TabIndex = 66
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(849, 23)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(41, 23)
        Me.Button4.TabIndex = 65
        Me.Button4.Text = "查询"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "成品油ARA含量"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ListView2)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(899, 416)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "成品油库存"
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
        Me.ListView2.Size = New System.Drawing.Size(893, 396)
        Me.ListView2.TabIndex = 37
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Chentextzs3
        '
        Me.Chentextzs3.Location = New System.Drawing.Point(786, 25)
        Me.Chentextzs3.Name = "Chentextzs3"
        Me.Chentextzs3.Size = New System.Drawing.Size(57, 21)
        Me.Chentextzs3.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(661, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 12)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "配料要求ARA/DHA总量"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(334, 23)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(52, 20)
        Me.ComboBox1.TabIndex = 141
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(275, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 140
        Me.Label8.Text = "产品类型"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(516, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 217
        Me.Label11.Text = "加工代码"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(392, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 216
        Me.Label12.Text = "产品代码"
        '
        'tb_x823p_mingc
        '
        Me.tb_x823p_mingc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_x823p_mingc.FormattingEnabled = True
        Me.tb_x823p_mingc.Location = New System.Drawing.Point(451, 24)
        Me.tb_x823p_mingc.Name = "tb_x823p_mingc"
        Me.tb_x823p_mingc.Size = New System.Drawing.Size(59, 20)
        Me.tb_x823p_mingc.TabIndex = 214
        '
        'tb_x823p_jiagdm
        '
        Me.tb_x823p_jiagdm.FormattingEnabled = True
        Me.tb_x823p_jiagdm.Location = New System.Drawing.Point(575, 26)
        Me.tb_x823p_jiagdm.Name = "tb_x823p_jiagdm"
        Me.tb_x823p_jiagdm.Size = New System.Drawing.Size(76, 20)
        Me.tb_x823p_jiagdm.TabIndex = 218
        '
        'Frtb_one
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 483)
        Me.Controls.Add(Me.tb_x823p_jiagdm)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tb_x823p_mingc)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Chentextzs3)
        Me.Controls.Add(Me.Chentextzs2)
        Me.Controls.Add(Me.Chentextzs1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frtb_one"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "预进1号塔"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Chentextzs2 As chencontrol.chentextzs
    Friend WithEvents Chentextzs1 As chencontrol.chentextzs
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Chentextzs3 As chencontrol.chentextzs
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tb_x823p_mingc As System.Windows.Forms.ComboBox
    Friend WithEvents tb_x823p_jiagdm As System.Windows.Forms.ComboBox
End Class
