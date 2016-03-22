<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frqalist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frqalist))
        Me.Buttsearch = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListView3 = New System.Windows.Forms.DataGridView()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox()
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ylMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bcMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bcDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.INSERT1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.INSERT2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.wsButton3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerComplaintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemWJQD = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemKHTSJL = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemGYSSHTZ = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemFSQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemWBSHQK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton()
        Me.tb_x832p_qaspjg = New System.Windows.Forms.ComboBox()
        Me.lb_tb_x832p_qaspjg = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ListView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Buttsearch
        '
        Me.Buttsearch.Location = New System.Drawing.Point(550, 21)
        Me.Buttsearch.Name = "Buttsearch"
        Me.Buttsearch.Size = New System.Drawing.Size(75, 23)
        Me.Buttsearch.TabIndex = 46
        Me.Buttsearch.Text = "查询"
        Me.Buttsearch.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(794, 262)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "QA待检测"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(788, 242)
        Me.ListView2.TabIndex = 37
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ListView3)
        Me.GroupBox3.Controls.Add(Me.Labelserch)
        Me.GroupBox3.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox3.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox3.Controls.Add(Me.ToExcel)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Buttsearch)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 339)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(794, 212)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "QA审批记录"
        '
        'ListView3
        '
        Me.ListView3.AllowUserToAddRows = False
        Me.ListView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ListView3.Location = New System.Drawing.Point(6, 46)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.ReadOnly = True
        Me.ListView3.RowHeadersVisible = False
        Me.ListView3.RowTemplate.Height = 23
        Me.ListView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListView3.Size = New System.Drawing.Size(782, 160)
        Me.ListView3.TabIndex = 69
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.Location = New System.Drawing.Point(275, 29)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 59
        Me.Labelserch.Text = "文本"
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(444, 23)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxserchtext.TabIndex = 58
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(317, 23)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxserchtext.TabIndex = 57
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(643, 21)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 52
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(151, 22)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker2.TabIndex = 51
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 21)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker1.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "至"
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.bcDropDown, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripDropDownButton2, Me.ToolStripButton2, Me.ToolHelp})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(879, 39)
        Me.tsMenu.TabIndex = 50
        Me.tsMenu.Text = "tsMenu"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ylMenuItem, Me.bcMenuItem})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(95, 36)
        Me.ToolStripButton1.Text = "原料QA"
        '
        'ylMenuItem
        '
        Me.ylMenuItem.Name = "ylMenuItem"
        Me.ylMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ylMenuItem.Text = "原料QA"
        '
        'bcMenuItem
        '
        Me.bcMenuItem.Name = "bcMenuItem"
        Me.bcMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.bcMenuItem.Text = "包材QA"
        '
        'bcDropDown
        '
        Me.bcDropDown.Image = CType(resources.GetObject("bcDropDown.Image"), System.Drawing.Image)
        Me.bcDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bcDropDown.Name = "bcDropDown"
        Me.bcDropDown.Size = New System.Drawing.Size(69, 36)
        Me.bcDropDown.Text = "BC"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(86, 36)
        Me.ToolStripButton5.Text = "毛油QA"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton6.Text = "成品油QA"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(104, 36)
        Me.ToolStripButton3.Text = "成品粉小批"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(80, 36)
        Me.ToolStripButton4.Text = "成品粉"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INSERT1, Me.INSERT2, Me.wsButton3, Me.CustomerComplaintsToolStripMenuItem, Me.MenuItemWJQD, Me.MenuItemKHTSJL, Me.MenuItemGYSSHTZ, Me.MenuItemFSQ, Me.MenuItemWBSHQK})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(77, 36)
        Me.ToolStripDropDownButton2.Text = "输入"
        '
        'INSERT1
        '
        Me.INSERT1.Name = "INSERT1"
        Me.INSERT1.Size = New System.Drawing.Size(208, 22)
        Me.INSERT1.Text = "MOC台账"
        '
        'INSERT2
        '
        Me.INSERT2.Name = "INSERT2"
        Me.INSERT2.Size = New System.Drawing.Size(208, 22)
        Me.INSERT2.Text = "偏差台账"
        '
        'wsButton3
        '
        Me.wsButton3.Name = "wsButton3"
        Me.wsButton3.Size = New System.Drawing.Size(208, 22)
        Me.wsButton3.Text = "现场检查发现项跟踪系统"
        '
        'CustomerComplaintsToolStripMenuItem
        '
        Me.CustomerComplaintsToolStripMenuItem.Name = "CustomerComplaintsToolStripMenuItem"
        Me.CustomerComplaintsToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.CustomerComplaintsToolStripMenuItem.Text = "Customer complaints"
        '
        'MenuItemWJQD
        '
        Me.MenuItemWJQD.Name = "MenuItemWJQD"
        Me.MenuItemWJQD.Size = New System.Drawing.Size(208, 22)
        Me.MenuItemWJQD.Text = "文件清单"
        '
        'MenuItemKHTSJL
        '
        Me.MenuItemKHTSJL.Name = "MenuItemKHTSJL"
        Me.MenuItemKHTSJL.Size = New System.Drawing.Size(208, 22)
        Me.MenuItemKHTSJL.Text = "客户投诉记录"
        '
        'MenuItemGYSSHTZ
        '
        Me.MenuItemGYSSHTZ.Name = "MenuItemGYSSHTZ"
        Me.MenuItemGYSSHTZ.Size = New System.Drawing.Size(208, 22)
        Me.MenuItemGYSSHTZ.Text = "供应商现场审核台账"
        '
        'MenuItemFSQ
        '
        Me.MenuItemFSQ.Name = "MenuItemFSQ"
        Me.MenuItemFSQ.Size = New System.Drawing.Size(208, 22)
        Me.MenuItemFSQ.Text = "FSQ内审"
        '
        'MenuItemWBSHQK
        '
        Me.MenuItemWBSHQK.Name = "MenuItemWBSHQK"
        Me.MenuItemWBSHQK.Size = New System.Drawing.Size(208, 22)
        Me.MenuItemWBSHQK.Text = "外部审核情况"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(116, 36)
        Me.ToolStripButton2.Text = "个人培训档案"
        Me.ToolStripButton2.ToolTipText = "个人培训档案"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(68, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'tb_x832p_qaspjg
        '
        Me.tb_x832p_qaspjg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_x832p_qaspjg.FormattingEnabled = True
        Me.tb_x832p_qaspjg.Location = New System.Drawing.Point(59, 45)
        Me.tb_x832p_qaspjg.Name = "tb_x832p_qaspjg"
        Me.tb_x832p_qaspjg.Size = New System.Drawing.Size(56, 20)
        Me.tb_x832p_qaspjg.TabIndex = 51
        '
        'lb_tb_x832p_qaspjg
        '
        Me.lb_tb_x832p_qaspjg.AutoSize = True
        Me.lb_tb_x832p_qaspjg.BackColor = System.Drawing.Color.Transparent
        Me.lb_tb_x832p_qaspjg.Location = New System.Drawing.Point(12, 48)
        Me.lb_tb_x832p_qaspjg.Name = "lb_tb_x832p_qaspjg"
        Me.lb_tb_x832p_qaspjg.Size = New System.Drawing.Size(41, 12)
        Me.lb_tb_x832p_qaspjg.TabIndex = 52
        Me.lb_tb_x832p_qaspjg.Text = "QA结果"
        '
        'Frqalist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 558)
        Me.Controls.Add(Me.lb_tb_x832p_qaspjg)
        Me.Controls.Add(Me.tb_x832p_qaspjg)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Frqalist"
        Me.Text = "QA部门"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ListView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Buttsearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents INSERT1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INSERT2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents wsButton3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ylMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bcMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerComplaintsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuItemWJQD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemKHTSJL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemGYSSHTZ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView3 As System.Windows.Forms.DataGridView
    Friend WithEvents MenuItemFSQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemWBSHQK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tb_x832p_qaspjg As System.Windows.Forms.ComboBox
    Friend WithEvents lb_tb_x832p_qaspjg As System.Windows.Forms.Label
    Friend WithEvents bcDropDown As System.Windows.Forms.ToolStripDropDownButton
End Class
