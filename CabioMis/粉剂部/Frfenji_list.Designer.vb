<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frfenji_list
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frfenji_list))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItemSGFJTP = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuTP1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTP2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripSplitButton()
        Me.TA1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dsc1MenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripSplitButton()
        Me.TA34 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dsc34MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.TA5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.小批扣油明细ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox()
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton6, Me.ToolStripSplitButton1, Me.ToolStripButton3, Me.ToolStripButton5, Me.ToolStripButton8, Me.ToolStripButton1, Me.ToolStripButton7, Me.ToolHelp})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(974, 39)
        Me.tsMenu.TabIndex = 44
        Me.tsMenu.Text = "tsMenu"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSGFJTP, Me.ToolStripMenuTP1, Me.ToolStripMenuItemTP2, Me.ToolStripMenuItem1})
        Me.ToolStripButton2.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.MergeIndex = 0
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(113, 36)
        Me.ToolStripButton2.Text = "粉剂工艺单"
        '
        'ToolStripMenuItemSGFJTP
        '
        Me.ToolStripMenuItemSGFJTP.Name = "ToolStripMenuItemSGFJTP"
        Me.ToolStripMenuItemSGFJTP.Size = New System.Drawing.Size(208, 22)
        Me.ToolStripMenuItemSGFJTP.Text = "粉剂配料手工调配"
        '
        'ToolStripMenuTP1
        '
        Me.ToolStripMenuTP1.Name = "ToolStripMenuTP1"
        Me.ToolStripMenuTP1.Size = New System.Drawing.Size(208, 22)
        Me.ToolStripMenuTP1.Text = "粉剂配料自动调配(1号塔)"
        '
        'ToolStripMenuItemTP2
        '
        Me.ToolStripMenuItemTP2.Name = "ToolStripMenuItemTP2"
        Me.ToolStripMenuItemTP2.Size = New System.Drawing.Size(208, 22)
        Me.ToolStripMenuItemTP2.Text = "粉剂配料自动调配(普粉)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(208, 22)
        Me.ToolStripMenuItem1.Text = "粉剂配料自动调配(优粉)"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TA1, Me.dsc1MenuItem1})
        Me.ToolStripButton4.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.MergeIndex = 0
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripButton4.Text = "一号塔"
        '
        'TA1
        '
        Me.TA1.Name = "TA1"
        Me.TA1.Size = New System.Drawing.Size(106, 22)
        Me.TA1.Text = "配料批"
        '
        'dsc1MenuItem1
        '
        Me.dsc1MenuItem1.Name = "dsc1MenuItem1"
        Me.dsc1MenuItem1.Size = New System.Drawing.Size(106, 22)
        Me.dsc1MenuItem1.Text = "包装"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TA34, Me.dsc34MenuItem})
        Me.ToolStripButton6.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.MergeIndex = 0
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(77, 36)
        Me.ToolStripButton6.Text = "普粉"
        '
        'TA34
        '
        Me.TA34.Name = "TA34"
        Me.TA34.Size = New System.Drawing.Size(106, 22)
        Me.TA34.Text = "配料批"
        '
        'dsc34MenuItem
        '
        Me.dsc34MenuItem.Name = "dsc34MenuItem"
        Me.dsc34MenuItem.Size = New System.Drawing.Size(106, 22)
        Me.dsc34MenuItem.Text = "包装"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TA5, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.小批扣油明细ToolStripMenuItem})
        Me.ToolStripSplitButton1.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.MergeIndex = 0
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(77, 36)
        Me.ToolStripSplitButton1.Text = "优粉"
        '
        'TA5
        '
        Me.TA5.Name = "TA5"
        Me.TA5.Size = New System.Drawing.Size(142, 22)
        Me.TA5.Text = "配料批"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(142, 22)
        Me.ToolStripMenuItem2.Text = "喷雾"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(142, 22)
        Me.ToolStripMenuItem3.Text = "包装"
        '
        '小批扣油明细ToolStripMenuItem
        '
        Me.小批扣油明细ToolStripMenuItem.Name = "小批扣油明细ToolStripMenuItem"
        Me.小批扣油明细ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.小批扣油明细ToolStripMenuItem.Text = "小批扣油明细"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton3.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.MergeIndex = 0
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(155, 36)
        Me.ToolStripButton3.Text = "成品粉混批计划/返工"
        Me.ToolStripButton3.Visible = False
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(116, 36)
        Me.ToolStripButton5.Text = "配料计划查询"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(128, 36)
        Me.ToolStripButton8.Text = "修改粉剂铝箔袋"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.MergeIndex = 0
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(125, 36)
        Me.ToolStripButton1.Text = "原辅料车间库存"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(116, 36)
        Me.ToolStripButton7.Text = "个人培训档案"
        Me.ToolStripButton7.ToolTipText = "个人培训档案"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(68, 36)
        Me.ToolHelp.Text = "帮助"
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
        Me.ListView2.Size = New System.Drawing.Size(706, 207)
        Me.ListView2.TabIndex = 37
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ListView2)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(712, 227)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "列表"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(113, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "至"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(453, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(688, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "生成大批"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(101, 21)
        Me.DateTimePicker1.TabIndex = 57
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(136, 20)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(97, 21)
        Me.DateTimePicker2.TabIndex = 58
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(595, 20)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(87, 23)
        Me.ToExcel.TabIndex = 60
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(514, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 61
        Me.Button3.Text = "成品粉查询"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(272, 23)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(94, 20)
        Me.ComboBoxserchtext.TabIndex = 62
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(372, 23)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(75, 21)
        Me.TextBoxserchtext.TabIndex = 63
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.Location = New System.Drawing.Point(237, 29)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 64
        Me.Labelserch.Text = "文本"
        '
        'ListView1
        '
        Me.ListView1.AllowUserToAddRows = False
        Me.ListView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ListView1.Location = New System.Drawing.Point(6, 47)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ReadOnly = True
        Me.ListView1.RowHeadersVisible = False
        Me.ListView1.RowTemplate.Height = 23
        Me.ListView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListView1.Size = New System.Drawing.Size(845, 111)
        Me.ListView1.TabIndex = 69
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Controls.Add(Me.Labelserch)
        Me.GroupBox1.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(858, 164)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'Frfenji_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 465)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "Frfenji_list"
        Me.Text = "粉剂生产部"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents dsc1MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dsc34MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItemSGFJTP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TA1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TA34 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TA5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuTP1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTP2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents 小批扣油明细ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
