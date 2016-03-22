<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrbcList
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.show1 = New yangNetCl.yanDaTaGridView()
        Me.addPh = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.show2 = New yangNetCl.yanDaTaGridView()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox()
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.showFjxx = New yangNetCl.yanDaTaGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.showTlxx = New yangNetCl.yanDaTaGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.showCcxx = New yangNetCl.yanDaTaGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.showQcxx = New yangNetCl.yanDaTaGridView()
        Me.GroupBox3.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.show2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.showFjxx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.showTlxx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.showCcxx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.showQcxx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(975, 25)
        Me.tsMenu.TabIndex = 46
        Me.tsMenu.Text = "tsMenu"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.show1)
        Me.GroupBox3.Controls.Add(Me.addPh)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 35)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(827, 284)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "发酵中"
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.show1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Location = New System.Drawing.Point(9, 53)
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(812, 225)
        Me.show1.TabIndex = 0
        '
        'addPh
        '
        Me.addPh.Location = New System.Drawing.Point(9, 24)
        Me.addPh.Name = "addPh"
        Me.addPh.Size = New System.Drawing.Size(53, 23)
        Me.addPh.TabIndex = 59
        Me.addPh.Text = "生产"
        Me.addPh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.show2)
        Me.GroupBox1.Controls.Add(Me.Labelserch)
        Me.GroupBox1.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 325)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(830, 216)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'show2
        '
        Me.show2.AllowUserToAddRows = False
        Me.show2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.show2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.show2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show2.Location = New System.Drawing.Point(6, 46)
        Me.show2.Name = "show2"
        Me.show2.ReadOnly = True
        Me.show2.RowTemplate.Height = 23
        Me.show2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show2.Size = New System.Drawing.Size(815, 170)
        Me.show2.TabIndex = 68
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.Location = New System.Drawing.Point(280, 26)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 67
        Me.Labelserch.Text = "文本"
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(415, 20)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(75, 21)
        Me.TextBoxserchtext.TabIndex = 66
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(315, 20)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(94, 20)
        Me.ComboBoxserchtext.TabIndex = 65
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(572, 18)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 59
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(155, 20)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker2.TabIndex = 58
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker1.TabIndex = 57
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(496, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "至"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.showFjxx)
        Me.GroupBox2.Location = New System.Drawing.Point(833, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 131)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "附加信息"
        '
        'showFjxx
        '
        Me.showFjxx.AllowUserToAddRows = False
        Me.showFjxx.BackgroundColor = System.Drawing.SystemColors.Window
        Me.showFjxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showFjxx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showFjxx.Location = New System.Drawing.Point(3, 17)
        Me.showFjxx.Name = "showFjxx"
        Me.showFjxx.ReadOnly = True
        Me.showFjxx.RowTemplate.Height = 23
        Me.showFjxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showFjxx.Size = New System.Drawing.Size(136, 111)
        Me.showFjxx.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.showTlxx)
        Me.GroupBox4.Location = New System.Drawing.Point(833, 169)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(142, 144)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "投料信息"
        '
        'showTlxx
        '
        Me.showTlxx.AllowUserToAddRows = False
        Me.showTlxx.BackgroundColor = System.Drawing.SystemColors.Window
        Me.showTlxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showTlxx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showTlxx.Location = New System.Drawing.Point(3, 17)
        Me.showTlxx.Name = "showTlxx"
        Me.showTlxx.ReadOnly = True
        Me.showTlxx.RowTemplate.Height = 23
        Me.showTlxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showTlxx.Size = New System.Drawing.Size(136, 124)
        Me.showTlxx.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.showCcxx)
        Me.GroupBox5.Location = New System.Drawing.Point(833, 319)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(145, 158)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "产出信息"
        '
        'showCcxx
        '
        Me.showCcxx.AllowUserToAddRows = False
        Me.showCcxx.BackgroundColor = System.Drawing.SystemColors.Window
        Me.showCcxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showCcxx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showCcxx.Location = New System.Drawing.Point(3, 17)
        Me.showCcxx.Name = "showCcxx"
        Me.showCcxx.ReadOnly = True
        Me.showCcxx.RowTemplate.Height = 23
        Me.showCcxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showCcxx.Size = New System.Drawing.Size(139, 138)
        Me.showCcxx.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.showQcxx)
        Me.GroupBox6.Location = New System.Drawing.Point(833, 483)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(142, 64)
        Me.GroupBox6.TabIndex = 49
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "QC信息"
        '
        'showQcxx
        '
        Me.showQcxx.AllowUserToAddRows = False
        Me.showQcxx.BackgroundColor = System.Drawing.SystemColors.Window
        Me.showQcxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showQcxx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showQcxx.Location = New System.Drawing.Point(3, 17)
        Me.showQcxx.Name = "showQcxx"
        Me.showQcxx.ReadOnly = True
        Me.showQcxx.RowTemplate.Height = 23
        Me.showQcxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showQcxx.Size = New System.Drawing.Size(136, 44)
        Me.showQcxx.TabIndex = 0
        '
        'FrbcList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 553)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "FrbcList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrbcList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.show2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.showFjxx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.showTlxx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.showCcxx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.showQcxx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show2 As yangNetCl.yanDaTaGridView
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents addPh As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents showFjxx As yangNetCl.yanDaTaGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents showTlxx As yangNetCl.yanDaTaGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents showCcxx As yangNetCl.yanDaTaGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents showQcxx As yangNetCl.yanDaTaGridView
    Friend WithEvents show1 As yangNetCl.yanDaTaGridView
End Class
