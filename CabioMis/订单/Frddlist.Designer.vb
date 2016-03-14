<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frddlist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frddlist))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tb2 = New System.Windows.Forms.ToolStripButton()
        Me.tb3 = New System.Windows.Forms.ToolStripButton()
        Me.tb4 = New System.Windows.Forms.ToolStripButton()
        Me.tbf = New System.Windows.Forms.ToolStripButton()
        Me.dd1 = New System.Windows.Forms.ToolStripButton()
        Me.tb5 = New System.Windows.Forms.ToolStripButton()
        Me.tb6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripclose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.show1 = New System.Windows.Forms.DataGridView()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tb2, Me.tb3, Me.tb4, Me.tbf, Me.dd1, Me.tb5, Me.tb6, Me.ToolStripclose, Me.ToolStripLabel1})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(960, 39)
        Me.tsMenu.TabIndex = 83
        Me.tsMenu.Text = "tsMenu"
        '
        'tb2
        '
        Me.tb2.BackColor = System.Drawing.Color.Transparent
        Me.tb2.Image = CType(resources.GetObject("tb2.Image"), System.Drawing.Image)
        Me.tb2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(116, 36)
        Me.tb2.Text = "订单缺货查询"
        '
        'tb3
        '
        Me.tb3.BackColor = System.Drawing.Color.Transparent
        Me.tb3.Image = CType(resources.GetObject("tb3.Image"), System.Drawing.Image)
        Me.tb3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb3.Name = "tb3"
        Me.tb3.Size = New System.Drawing.Size(128, 36)
        Me.tb3.Text = "订单输入与审核"
        '
        'tb4
        '
        Me.tb4.BackColor = System.Drawing.Color.Transparent
        Me.tb4.Image = CType(resources.GetObject("tb4.Image"), System.Drawing.Image)
        Me.tb4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb4.Name = "tb4"
        Me.tb4.Size = New System.Drawing.Size(80, 36)
        Me.tb4.Text = "未发货"
        '
        'tbf
        '
        Me.tbf.BackColor = System.Drawing.Color.Transparent
        Me.tbf.Image = CType(resources.GetObject("tbf.Image"), System.Drawing.Image)
        Me.tbf.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbf.Name = "tbf"
        Me.tbf.Size = New System.Drawing.Size(92, 36)
        Me.tbf.Text = "计划明细"
        '
        'dd1
        '
        Me.dd1.BackColor = System.Drawing.Color.Transparent
        Me.dd1.Image = CType(resources.GetObject("dd1.Image"), System.Drawing.Image)
        Me.dd1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.dd1.Name = "dd1"
        Me.dd1.Size = New System.Drawing.Size(92, 36)
        Me.dd1.Text = "计划打印"
        '
        'tb5
        '
        Me.tb5.BackColor = System.Drawing.Color.Transparent
        Me.tb5.Image = CType(resources.GetObject("tb5.Image"), System.Drawing.Image)
        Me.tb5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb5.Name = "tb5"
        Me.tb5.Size = New System.Drawing.Size(80, 36)
        Me.tb5.Text = "已发货"
        '
        'tb6
        '
        Me.tb6.BackColor = System.Drawing.Color.Transparent
        Me.tb6.Image = CType(resources.GetObject("tb6.Image"), System.Drawing.Image)
        Me.tb6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb6.Name = "tb6"
        Me.tb6.Size = New System.Drawing.Size(80, 36)
        Me.tb6.Text = "已签收"
        '
        'ToolStripclose
        '
        Me.ToolStripclose.Image = CType(resources.GetObject("ToolStripclose.Image"), System.Drawing.Image)
        Me.ToolStripclose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripclose.Name = "ToolStripclose"
        Me.ToolStripclose.Size = New System.Drawing.Size(68, 36)
        Me.ToolStripclose.Text = "关闭"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Red
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 36)
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Button9)
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker4)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.ComboBox3)
        Me.GroupBox3.Controls.Add(Me.Labelserch)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.show1)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(908, 508)
        Me.GroupBox3.TabIndex = 81
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "列表"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(780, 19)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(46, 23)
        Me.Button9.TabIndex = 93
        Me.Button9.Text = "导出"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(720, 19)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(54, 26)
        Me.Button8.TabIndex = 90
        Me.Button8.Text = "重置"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Location = New System.Drawing.Point(267, 24)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(109, 21)
        Me.DateTimePicker4.TabIndex = 89
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(832, 18)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 23)
        Me.Button7.TabIndex = 86
        Me.Button7.Text = "添加"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(129, 24)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(109, 21)
        Me.DateTimePicker3.TabIndex = 88
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(562, 21)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(84, 21)
        Me.TextBox2.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "至"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(6, 23)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(117, 20)
        Me.ComboBox2.TabIndex = 84
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(431, 21)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(117, 20)
        Me.ComboBox3.TabIndex = 84
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.BackColor = System.Drawing.Color.Transparent
        Me.Labelserch.Location = New System.Drawing.Point(396, 26)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 81
        Me.Labelserch.Text = "文本"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(652, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 26)
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
        Me.show1.Location = New System.Drawing.Point(3, 65)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowHeadersVisible = False
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(902, 440)
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
        'Frddlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 596)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Frddlist"
        Me.Text = "订单"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tb2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tb3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tb4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbf As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripclose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents tb5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tb6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dd1 As System.Windows.Forms.ToolStripButton
End Class
