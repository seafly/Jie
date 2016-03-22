<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frkc_List
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
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboQa = New System.Windows.Forms.ComboBox()
        Me.ComboQc = New System.Windows.Forms.ComboBox()
        Me.storagewzlk = New System.Windows.Forms.CheckBox()
        Me.storagemslk = New System.Windows.Forms.CheckBox()
        Me.kdlk = New System.Windows.Forms.CheckBox()
        Me.bfb = New System.Windows.Forms.CheckBox()
        Me.cjcl = New System.Windows.Forms.CheckBox()
        Me.show1 = New yangNetCl.yanDaTaGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.show3 = New yangNetCl.yanDaTaGridView()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox()
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.show3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1058, 25)
        Me.tsMenu.TabIndex = 47
        Me.tsMenu.Text = "tsMenu"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboQa)
        Me.GroupBox1.Controls.Add(Me.ComboQc)
        Me.GroupBox1.Controls.Add(Me.storagewzlk)
        Me.GroupBox1.Controls.Add(Me.storagemslk)
        Me.GroupBox1.Controls.Add(Me.kdlk)
        Me.GroupBox1.Controls.Add(Me.bfb)
        Me.GroupBox1.Controls.Add(Me.cjcl)
        Me.GroupBox1.Controls.Add(Me.show1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1058, 301)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "库存情况"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(474, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "QA结果"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "QC审核"
        '
        'ComboQa
        '
        Me.ComboQa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboQa.FormattingEnabled = True
        Me.ComboQa.Items.AddRange(New Object() {"", "待定", "合格", "不合格"})
        Me.ComboQa.Location = New System.Drawing.Point(521, 18)
        Me.ComboQa.Name = "ComboQa"
        Me.ComboQa.Size = New System.Drawing.Size(62, 20)
        Me.ComboQa.TabIndex = 2
        '
        'ComboQc
        '
        Me.ComboQc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboQc.FormattingEnabled = True
        Me.ComboQc.Items.AddRange(New Object() {"", "是", "否"})
        Me.ComboQc.Location = New System.Drawing.Point(415, 17)
        Me.ComboQc.Name = "ComboQc"
        Me.ComboQc.Size = New System.Drawing.Size(53, 20)
        Me.ComboQc.TabIndex = 2
        '
        'storagewzlk
        '
        Me.storagewzlk.AutoSize = True
        Me.storagewzlk.Checked = True
        Me.storagewzlk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.storagewzlk.Cursor = System.Windows.Forms.Cursors.Default
        Me.storagewzlk.Location = New System.Drawing.Point(290, 21)
        Me.storagewzlk.Name = "storagewzlk"
        Me.storagewzlk.Size = New System.Drawing.Size(72, 16)
        Me.storagewzlk.TabIndex = 1
        Me.storagewzlk.Text = "外租冷库"
        Me.storagewzlk.UseVisualStyleBackColor = True
        '
        'storagemslk
        '
        Me.storagemslk.AutoSize = True
        Me.storagemslk.Checked = True
        Me.storagemslk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.storagemslk.Location = New System.Drawing.Point(212, 21)
        Me.storagemslk.Name = "storagemslk"
        Me.storagemslk.Size = New System.Drawing.Size(72, 16)
        Me.storagemslk.TabIndex = 1
        Me.storagemslk.Text = "庙山冷库"
        Me.storagemslk.UseVisualStyleBackColor = True
        '
        'kdlk
        '
        Me.kdlk.AutoSize = True
        Me.kdlk.Checked = True
        Me.kdlk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.kdlk.Location = New System.Drawing.Point(134, 21)
        Me.kdlk.Name = "kdlk"
        Me.kdlk.Size = New System.Drawing.Size(72, 16)
        Me.kdlk.TabIndex = 1
        Me.kdlk.Text = "葛店冷库"
        Me.kdlk.UseVisualStyleBackColor = True
        '
        'bfb
        '
        Me.bfb.AutoSize = True
        Me.bfb.Checked = True
        Me.bfb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.bfb.Location = New System.Drawing.Point(67, 21)
        Me.bfb.Name = "bfb"
        Me.bfb.Size = New System.Drawing.Size(60, 16)
        Me.bfb.TabIndex = 1
        Me.bfb.Text = "北方办"
        Me.bfb.UseVisualStyleBackColor = True
        '
        'cjcl
        '
        Me.cjcl.AutoSize = True
        Me.cjcl.Location = New System.Drawing.Point(13, 21)
        Me.cjcl.Name = "cjcl"
        Me.cjcl.Size = New System.Drawing.Size(48, 16)
        Me.cjcl.TabIndex = 1
        Me.cjcl.Text = "车间"
        Me.cjcl.UseVisualStyleBackColor = True
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.show1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Location = New System.Drawing.Point(6, 47)
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(1046, 248)
        Me.show1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.show3)
        Me.GroupBox3.Controls.Add(Me.Labelserch)
        Me.GroupBox3.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox3.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.ToExcel)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 347)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1046, 86)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "进出货查询"
        '
        'show3
        '
        Me.show3.AllowUserToAddRows = False
        Me.show3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.show3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.show3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show3.Location = New System.Drawing.Point(6, 47)
        Me.show3.Name = "show3"
        Me.show3.ReadOnly = True
        Me.show3.RowTemplate.Height = 23
        Me.show3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show3.Size = New System.Drawing.Size(1034, 33)
        Me.show3.TabIndex = 0
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.Location = New System.Drawing.Point(255, 23)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 132
        Me.Labelserch.Text = "文本"
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(399, 20)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(75, 21)
        Me.TextBoxserchtext.TabIndex = 131
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(290, 20)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(94, 20)
        Me.ComboBoxserchtext.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(111, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "至"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(134, 17)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(95, 21)
        Me.DateTimePicker2.TabIndex = 126
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 15)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(99, 21)
        Me.DateTimePicker1.TabIndex = 125
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(565, 20)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(82, 22)
        Me.ToExcel.TabIndex = 122
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(502, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 22)
        Me.Button1.TabIndex = 119
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Frkc_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 445)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "Frkc_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frkc_List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.show3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents show3 As yangNetCl.yanDaTaGridView
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents show1 As yangNetCl.yanDaTaGridView
    Friend WithEvents bfb As System.Windows.Forms.CheckBox
    Friend WithEvents cjcl As System.Windows.Forms.CheckBox
    Friend WithEvents storagewzlk As System.Windows.Forms.CheckBox
    Friend WithEvents storagemslk As System.Windows.Forms.CheckBox
    Friend WithEvents kdlk As System.Windows.Forms.CheckBox
    Friend WithEvents ComboQa As System.Windows.Forms.ComboBox
    Friend WithEvents ComboQc As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
