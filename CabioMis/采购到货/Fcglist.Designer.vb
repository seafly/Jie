<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fcglist
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
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.tb_cg_cgdh = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.show2 = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Labelserch = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.show1 = New System.Windows.Forms.DataGridView
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.show2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(614, 35)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 21)
        Me.Button3.TabIndex = 224
        Me.Button3.Text = "提交"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(530, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 21)
        Me.Button1.TabIndex = 223
        Me.Button1.Text = "确认"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_cg_cgdh
        '
        Me.tb_cg_cgdh.Location = New System.Drawing.Point(347, 35)
        Me.tb_cg_cgdh.Name = "tb_cg_cgdh"
        Me.tb_cg_cgdh.Size = New System.Drawing.Size(105, 21)
        Me.tb_cg_cgdh.TabIndex = 221
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(275, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 220
        Me.Label19.Text = "采购单号"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"备品备件", "原料包材"})
        Me.ComboBox1.Location = New System.Drawing.Point(113, 35)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(105, 20)
        Me.ComboBox1.TabIndex = 217
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(41, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = "物品分类"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.show2)
        Me.GroupBox1.Location = New System.Drawing.Point(42, 343)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(908, 237)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'show2
        '
        Me.show2.AllowUserToAddRows = False
        Me.show2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.show2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.show2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show2.Location = New System.Drawing.Point(3, 17)
        Me.show2.MultiSelect = False
        Me.show2.Name = "show2"
        Me.show2.ReadOnly = True
        Me.show2.RowHeadersVisible = False
        Me.show2.RowTemplate.Height = 23
        Me.show2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show2.Size = New System.Drawing.Size(902, 217)
        Me.show2.TabIndex = 69
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.ComboBox3)
        Me.GroupBox3.Controls.Add(Me.Labelserch)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.show1)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(42, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(908, 221)
        Me.GroupBox3.TabIndex = 212
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "列表"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(424, 20)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(54, 23)
        Me.Button8.TabIndex = 90
        Me.Button8.Text = "重置"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(191, 24)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(115, 21)
        Me.TextBox2.TabIndex = 85
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(52, 21)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(133, 20)
        Me.ComboBox3.TabIndex = 84
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.BackColor = System.Drawing.Color.Transparent
        Me.Labelserch.Location = New System.Drawing.Point(26, 26)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 81
        Me.Labelserch.Text = "文本"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(336, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 23)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "筛选"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.show1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show1.Location = New System.Drawing.Point(3, 51)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowHeadersVisible = False
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(902, 167)
        Me.show1.TabIndex = 70
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(22, -528)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 61
        Me.Button6.Text = "修改"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(192, -256)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 61
        Me.Button5.Text = "修改"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Fcglist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 596)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tb_cg_cgdh)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Fcglist"
        Me.Text = "采购输入"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.show2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_cg_cgdh As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
