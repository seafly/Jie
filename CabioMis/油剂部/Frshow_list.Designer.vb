<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frshow_list
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frshow_list))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListView3 = New System.Windows.Forms.DataGridView()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox()
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.wsButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tgMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dygMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.xpjgMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.jgMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MRYTP = New System.Windows.Forms.ToolStripMenuItem()
        Me.VRYTP = New System.Windows.Forms.ToolStripMenuItem()
        Me.fscylsy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemGRPXDA = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.TSB_mj = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TSB_TUOXIU = New System.Windows.Forms.ToolStripButton()
        Me.TSB_CPY = New System.Windows.Forms.ToolStripButton()
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton()
        Me.TSB_DH = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ListView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ListView2)
        Me.GroupBox3.Location = New System.Drawing.Point(245, 40)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(560, 320)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "发酵中"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(554, 300)
        Me.ListView2.TabIndex = 37
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(233, 320)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "批号"
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
        Me.ListView1.Size = New System.Drawing.Size(227, 300)
        Me.ListView1.TabIndex = 40
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(155, 20)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker2.TabIndex = 58
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView3)
        Me.GroupBox1.Controls.Add(Me.Labelserch)
        Me.GroupBox1.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 369)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 203)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'ListView3
        '
        Me.ListView3.AllowUserToAddRows = False
        Me.ListView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListView3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.ListView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ListView3.Location = New System.Drawing.Point(6, 46)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.ReadOnly = True
        Me.ListView3.RowHeadersVisible = False
        Me.ListView3.RowTemplate.Height = 23
        Me.ListView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListView3.Size = New System.Drawing.Size(775, 143)
        Me.ListView3.TabIndex = 68
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(682, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 23)
        Me.Button2.TabIndex = 60
        Me.Button2.Text = "返工油生产"
        Me.Button2.UseVisualStyleBackColor = True
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
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker1.TabIndex = 57
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(80, 36)
        Me.ToolStripButton2.Text = "一级罐"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(80, 36)
        Me.ToolStripButton3.Text = "二级罐"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(80, 36)
        Me.ToolStripButton4.Text = "发酵罐"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton5.Text = "毛油生产"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(68, 36)
        Me.ToolStripButton7.Text = "精炼"
        '
        'wsButton3
        '
        Me.wsButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMenuItem, Me.pMenuItem, Me.tgMenuItem, Me.dygMenuItem, Me.xpjgMenuItem, Me.jgMenuItem, Me.MRYTP, Me.VRYTP, Me.fscylsy, Me.ToolStripMenuItemGRPXDA})
        Me.wsButton3.Image = CType(resources.GetObject("wsButton3.Image"), System.Drawing.Image)
        Me.wsButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.wsButton3.Name = "wsButton3"
        Me.wsButton3.Size = New System.Drawing.Size(77, 36)
        Me.wsButton3.Text = "输入"
        Me.wsButton3.ToolTipText = "测试"
        '
        'SMenuItem
        '
        Me.SMenuItem.Name = "SMenuItem"
        Me.SMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.SMenuItem.Text = "5S检查"
        '
        'pMenuItem
        '
        Me.pMenuItem.Name = "pMenuItem"
        Me.pMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.pMenuItem.Text = "现场检查发现项跟踪系统"
        '
        'tgMenuItem
        '
        Me.tgMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.tgMenuItem.Name = "tgMenuItem"
        Me.tgMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.tgMenuItem.Text = "糖罐配料"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem2.Text = "802"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem3.Text = "803"
        '
        'dygMenuItem
        '
        Me.dygMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.dygMenuItem.Name = "dygMenuItem"
        Me.dygMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.dygMenuItem.Text = "氮源罐配料"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem4.Text = "401"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem5.Text = "402"
        '
        'xpjgMenuItem
        '
        Me.xpjgMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8})
        Me.xpjgMenuItem.Name = "xpjgMenuItem"
        Me.xpjgMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.xpjgMenuItem.Text = "消泡剂罐配料"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem6.Text = "604"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem7.Text = "605"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem8.Text = "606"
        '
        'jgMenuItem
        '
        Me.jgMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem9, Me.ToolStripMenuItem10})
        Me.jgMenuItem.Name = "jgMenuItem"
        Me.jgMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.jgMenuItem.Text = "酸罐配料"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem9.Text = "701"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItem10.Text = "702"
        '
        'MRYTP
        '
        Me.MRYTP.Name = "MRYTP"
        Me.MRYTP.Size = New System.Drawing.Size(208, 22)
        Me.MRYTP.Text = "M溶液"
        '
        'VRYTP
        '
        Me.VRYTP.Name = "VRYTP"
        Me.VRYTP.Size = New System.Drawing.Size(208, 22)
        Me.VRYTP.Text = "V溶液"
        '
        'fscylsy
        '
        Me.fscylsy.Name = "fscylsy"
        Me.fscylsy.Size = New System.Drawing.Size(208, 22)
        Me.fscylsy.Text = "原辅料车间库存"
        '
        'ToolStripMenuItemGRPXDA
        '
        Me.ToolStripMenuItemGRPXDA.Name = "ToolStripMenuItemGRPXDA"
        Me.ToolStripMenuItemGRPXDA.Size = New System.Drawing.Size(208, 22)
        Me.ToolStripMenuItemGRPXDA.Text = "个人培训档案"
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.TSB_mj, Me.ToolStripButton5, Me.ToolStripDropDownButton1, Me.ToolStripButton1, Me.ToolStripButton7, Me.TSB_DH, Me.TSB_TUOXIU, Me.TSB_CPY, Me.wsButton3, Me.ToolHelp})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1028, 39)
        Me.tsMenu.TabIndex = 1
        Me.tsMenu.Text = "tsMenu"
        '
        'TSB_mj
        '
        Me.TSB_mj.BackColor = System.Drawing.Color.Transparent
        Me.TSB_mj.Image = CType(resources.GetObject("TSB_mj.Image"), System.Drawing.Image)
        Me.TSB_mj.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_mj.Name = "TSB_mj"
        Me.TSB_mj.Size = New System.Drawing.Size(68, 36)
        Me.TSB_mj.Text = "酶解"
        Me.TSB_mj.ToolTipText = "酶解"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mToolStripMenuItem, Me.CutToolStripMenuItem, Me.cToolStripMenuItem})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.MergeIndex = 0
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripDropDownButton1.Text = "毛油混配"
        Me.ToolStripDropDownButton1.Visible = False
        '
        'mToolStripMenuItem
        '
        Me.mToolStripMenuItem.Name = "mToolStripMenuItem"
        Me.mToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.mToolStripMenuItem.Text = "毛油混配"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.CutToolStripMenuItem.Text = "手工毛油调配"
        '
        'cToolStripMenuItem
        '
        Me.cToolStripMenuItem.Name = "cToolStripMenuItem"
        Me.cToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.cToolStripMenuItem.Text = "混配查询"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.MergeIndex = 0
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton1.Text = "精炼计划"
        '
        'TSB_TUOXIU
        '
        Me.TSB_TUOXIU.Image = CType(resources.GetObject("TSB_TUOXIU.Image"), System.Drawing.Image)
        Me.TSB_TUOXIU.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_TUOXIU.Name = "TSB_TUOXIU"
        Me.TSB_TUOXIU.Size = New System.Drawing.Size(68, 36)
        Me.TSB_TUOXIU.Text = "脱臭"
        '
        'TSB_CPY
        '
        Me.TSB_CPY.Image = CType(resources.GetObject("TSB_CPY.Image"), System.Drawing.Image)
        Me.TSB_CPY.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_CPY.Name = "TSB_CPY"
        Me.TSB_CPY.Size = New System.Drawing.Size(80, 36)
        Me.TSB_CPY.Text = "成品油"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(68, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'TSB_DH
        '
        Me.TSB_DH.Image = CType(resources.GetObject("TSB_DH.Image"), System.Drawing.Image)
        Me.TSB_DH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_DH.Name = "TSB_DH"
        Me.TSB_DH.Size = New System.Drawing.Size(68, 36)
        Me.TSB_DH.Text = "冬化"
        '
        'Frshow_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 584)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "Frshow_list"
        Me.Text = "油剂生产部"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ListView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents wsButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tgMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents jgMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fscylsy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuItemGRPXDA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView3 As System.Windows.Forms.DataGridView
    Friend WithEvents dygMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents xpjgMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MRYTP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VRYTP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSB_mj As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_TUOXIU As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TSB_CPY As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_DH As System.Windows.Forms.ToolStripButton
End Class
