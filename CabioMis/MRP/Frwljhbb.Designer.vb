<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frwljhbb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frwljhbb))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.show1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripclose = New System.Windows.Forms.ToolStripButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(472, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "月请购计划"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.show1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(830, 383)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
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
        Me.show1.Size = New System.Drawing.Size(824, 363)
        Me.show1.TabIndex = 33
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripclose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(854, 39)
        Me.ToolStrip1.TabIndex = 35
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(104, 36)
        Me.ToolStripButton6.Text = "导出EXCEL"
        '
        'ToolStripclose
        '
        Me.ToolStripclose.Image = CType(resources.GetObject("ToolStripclose.Image"), System.Drawing.Image)
        Me.ToolStripclose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripclose.Name = "ToolStripclose"
        Me.ToolStripclose.Size = New System.Drawing.Size(68, 36)
        Me.ToolStripclose.Text = "关闭"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(243, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(114, 21)
        Me.TextBox1.TabIndex = 41
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(97, 50)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(120, 20)
        Me.ComboBox2.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(36, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "文本"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(379, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 27)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "筛选"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(583, 49)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(78, 28)
        Me.Button3.TabIndex = 42
        Me.Button3.Text = "周齐料计划"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(830, 89)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "物料计划表保存与查询"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(652, 53)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(139, 30)
        Me.Button7.TabIndex = 68
        Me.Button7.Text = "成品/半成品计划查询"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(561, 53)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 30)
        Me.Button6.TabIndex = 67
        Me.Button6.Text = "删除"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(63, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "筛选时间"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(482, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "计划时间"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(262, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "保存/筛选表名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(21, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "保存/筛选表类别"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(688, 15)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 27)
        Me.Button5.TabIndex = 62
        Me.Button5.Text = "保存"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(364, 14)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(102, 20)
        Me.ComboBox3.TabIndex = 61
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(541, 15)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(123, 21)
        Me.DateTimePicker3.TabIndex = 60
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"月请购", "周齐料"})
        Me.ComboBox1.Location = New System.Drawing.Point(145, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(99, 20)
        Me.ComboBox1.TabIndex = 59
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(460, 53)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 30)
        Me.Button4.TabIndex = 58
        Me.Button4.Text = "查询"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(276, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "至"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(308, 53)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker2.TabIndex = 56
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(145, 52)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(123, 21)
        Me.DateTimePicker1.TabIndex = 55
        '
        'Frwljhbb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 527)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Frwljhbb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MRP"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripclose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button7 As System.Windows.Forms.Button
End Class
