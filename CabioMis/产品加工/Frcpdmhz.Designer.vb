<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frcpdmhz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frcpdmhz))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.show1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Button1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.gf1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.gf2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button5 = New System.Windows.Forms.ToolStripSplitButton()
        Me.添加修改BOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查询BOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.ToolStripSplitButton()
        Me.添加修改产能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X产能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnLock = New System.Windows.Forms.ToolStripSplitButton()
        Me.锁定该项ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部锁定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDelLock = New System.Windows.Forms.ToolStripSplitButton()
        Me.解锁该项ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部解锁ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.小客户修改ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DHABOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.show1)
        Me.GroupBox2.Location = New System.Drawing.Point(-1, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1142, 451)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "查询结果"
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.show1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show1.Location = New System.Drawing.Point(3, 17)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowHeadersVisible = False
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.ShowEditingIcon = False
        Me.show1.Size = New System.Drawing.Size(1136, 431)
        Me.show1.TabIndex = 24
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Button1, Me.ToolStripButton1, Me.Button5, Me.Button2, Me.BtnLock, Me.BtnDelLock, Me.ToExcel, Me.ToolStripButton2, Me.ToolStripSplitButton1, Me.ToolHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1152, 39)
        Me.ToolStrip1.TabIndex = 82
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 36)
        Me.Button1.Text = "添加产品代码"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.gf1, Me.gf2})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(101, 36)
        Me.ToolStripButton1.Text = "产品规范"
        '
        'gf1
        '
        Me.gf1.Name = "gf1"
        Me.gf1.Size = New System.Drawing.Size(177, 22)
        Me.gf1.Text = "添加/修改产品规范"
        '
        'gf2
        '
        Me.gf2.Name = "gf2"
        Me.gf2.Size = New System.Drawing.Size(177, 22)
        Me.gf2.Text = "查询产品规范"
        '
        'Button5
        '
        Me.Button5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.添加修改BOMToolStripMenuItem, Me.查询BOMToolStripMenuItem, Me.DHABOMToolStripMenuItem})
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 36)
        Me.Button5.Text = "BOM"
        '
        '添加修改BOMToolStripMenuItem
        '
        Me.添加修改BOMToolStripMenuItem.Name = "添加修改BOMToolStripMenuItem"
        Me.添加修改BOMToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.添加修改BOMToolStripMenuItem.Text = "添加/修改BOM"
        '
        '查询BOMToolStripMenuItem
        '
        Me.查询BOMToolStripMenuItem.Name = "查询BOMToolStripMenuItem"
        Me.查询BOMToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.查询BOMToolStripMenuItem.Text = "查询BOM"
        '
        'Button2
        '
        Me.Button2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.添加修改产能ToolStripMenuItem, Me.X产能ToolStripMenuItem})
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 36)
        Me.Button2.Text = "产能"
        '
        '添加修改产能ToolStripMenuItem
        '
        Me.添加修改产能ToolStripMenuItem.Name = "添加修改产能ToolStripMenuItem"
        Me.添加修改产能ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.添加修改产能ToolStripMenuItem.Text = "添加/修改产能"
        '
        'X产能ToolStripMenuItem
        '
        Me.X产能ToolStripMenuItem.Name = "X产能ToolStripMenuItem"
        Me.X产能ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.X产能ToolStripMenuItem.Text = "查询产能"
        '
        'BtnLock
        '
        Me.BtnLock.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.锁定该项ToolStripMenuItem, Me.全部锁定ToolStripMenuItem})
        Me.BtnLock.Image = CType(resources.GetObject("BtnLock.Image"), System.Drawing.Image)
        Me.BtnLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLock.Name = "BtnLock"
        Me.BtnLock.Size = New System.Drawing.Size(80, 36)
        Me.BtnLock.Text = "锁定"
        '
        '锁定该项ToolStripMenuItem
        '
        Me.锁定该项ToolStripMenuItem.Name = "锁定该项ToolStripMenuItem"
        Me.锁定该项ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.锁定该项ToolStripMenuItem.Text = "锁定该项"
        '
        '全部锁定ToolStripMenuItem
        '
        Me.全部锁定ToolStripMenuItem.Name = "全部锁定ToolStripMenuItem"
        Me.全部锁定ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.全部锁定ToolStripMenuItem.Text = "全部锁定"
        '
        'BtnDelLock
        '
        Me.BtnDelLock.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.解锁该项ToolStripMenuItem, Me.全部解锁ToolStripMenuItem})
        Me.BtnDelLock.Image = CType(resources.GetObject("BtnDelLock.Image"), System.Drawing.Image)
        Me.BtnDelLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelLock.Name = "BtnDelLock"
        Me.BtnDelLock.Size = New System.Drawing.Size(104, 36)
        Me.BtnDelLock.Text = "解除锁定"
        '
        '解锁该项ToolStripMenuItem
        '
        Me.解锁该项ToolStripMenuItem.Name = "解锁该项ToolStripMenuItem"
        Me.解锁该项ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.解锁该项ToolStripMenuItem.Text = "解锁该项"
        '
        '全部解锁ToolStripMenuItem
        '
        Me.全部解锁ToolStripMenuItem.Name = "全部解锁ToolStripMenuItem"
        Me.全部解锁ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.全部解锁ToolStripMenuItem.Text = "全部解锁"
        '
        'ToExcel
        '
        Me.ToExcel.Image = CType(resources.GetObject("ToExcel.Image"), System.Drawing.Image)
        Me.ToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(109, 36)
        Me.ToExcel.Text = "导出为Excel"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(140, 36)
        Me.ToolStripButton2.Text = "客户需求一览表"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem.Text = "客户需求一览表添加"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem1.Text = "客户需求一览表查询"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.小客户修改ToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(140, 36)
        Me.ToolStripSplitButton1.Text = "小客户与承运商"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem2.Text = "小客户与承运商查询"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem3.Text = "小客户与承运商添加"
        '
        '小客户修改ToolStripMenuItem
        '
        Me.小客户修改ToolStripMenuItem.Name = "小客户修改ToolStripMenuItem"
        Me.小客户修改ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.小客户修改ToolStripMenuItem.Text = "小客户与承运商修改"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(68, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 493)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 12)
        Me.Label1.TabIndex = 83
        '
        'DHABOMToolStripMenuItem
        '
        Me.DHABOMToolStripMenuItem.Name = "DHABOMToolStripMenuItem"
        Me.DHABOMToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DHABOMToolStripMenuItem.Text = "DHABOM"
        '
        'Frcpdmhz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 710)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frcpdmhz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "产品代码&产能&BOM汇总"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Button1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents gf1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gf2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnLock As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 锁定该项ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全部锁定ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDelLock As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 解锁该项ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全部解锁ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button5 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 添加修改BOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查询BOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 添加修改产能ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents X产能ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 小客户修改ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents DHABOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
