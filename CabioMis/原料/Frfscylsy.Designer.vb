<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frfscylsy
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Labelserch = New System.Windows.Forms.Label()
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox()
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox()
        Me.showl = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.SSSQD = New System.Windows.Forms.Button()
        Me.tb_jch_sl = New chencontrol.chentextzs()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_jch_bz = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_jch_rq = New chencontrol.chendatepick()
        Me.tb_jch_num = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_jch_cz = New System.Windows.Forms.ComboBox()
        Me.tb_jch_cplb = New System.Windows.Forms.TextBox()
        Me.tb_jch_yfcllygd = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.showl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Labelserch)
        Me.GroupBox1.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.showl)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 133)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 352)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.Location = New System.Drawing.Point(237, 26)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 142
        Me.Labelserch.Text = "文本"
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(367, 18)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(76, 21)
        Me.TextBoxserchtext.TabIndex = 141
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(272, 19)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(87, 20)
        Me.ComboBoxserchtext.TabIndex = 140
        '
        'showl
        '
        Me.showl.AllowUserToAddRows = False
        Me.showl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.showl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.showl.Location = New System.Drawing.Point(6, 47)
        Me.showl.MultiSelect = False
        Me.showl.Name = "showl"
        Me.showl.ReadOnly = True
        Me.showl.RowHeadersVisible = False
        Me.showl.RowTemplate.Height = 23
        Me.showl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showl.Size = New System.Drawing.Size(647, 293)
        Me.showl.TabIndex = 139
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(606, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 23)
        Me.Button2.TabIndex = 138
        Me.Button2.Text = "删除"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(513, 19)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(87, 23)
        Me.ToExcel.TabIndex = 60
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(136, 21)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(92, 21)
        Me.DateTimePicker2.TabIndex = 58
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 21)
        Me.DateTimePicker1.TabIndex = 57
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(449, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(113, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "至"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(530, 75)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 138
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(449, 75)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 137
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'tb_jch_sl
        '
        Me.tb_jch_sl.Location = New System.Drawing.Point(71, 80)
        Me.tb_jch_sl.Name = "tb_jch_sl"
        Me.tb_jch_sl.Size = New System.Drawing.Size(59, 21)
        Me.tb_jch_sl.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(36, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "数量"
        '
        'tb_jch_bz
        '
        Me.tb_jch_bz.Location = New System.Drawing.Point(220, 75)
        Me.tb_jch_bz.Name = "tb_jch_bz"
        Me.tb_jch_bz.Size = New System.Drawing.Size(223, 21)
        Me.tb_jch_bz.TabIndex = 134
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(177, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "备注"
        '
        'tb_jch_rq
        '
        Me.tb_jch_rq.BackColor = System.Drawing.Color.White
        Me.tb_jch_rq.Location = New System.Drawing.Point(212, 20)
        Me.tb_jch_rq.Name = "tb_jch_rq"
        Me.tb_jch_rq.Size = New System.Drawing.Size(158, 21)
        Me.tb_jch_rq.TabIndex = 131
        '
        'tb_jch_num
        '
        Me.tb_jch_num.Location = New System.Drawing.Point(71, 20)
        Me.tb_jch_num.Name = "tb_jch_num"
        Me.tb_jch_num.ReadOnly = True
        Me.tb_jch_num.Size = New System.Drawing.Size(100, 21)
        Me.tb_jch_num.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(376, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "操作"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(177, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "时间"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "原料批号"
        '
        'tb_jch_cz
        '
        Me.tb_jch_cz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_jch_cz.FormattingEnabled = True
        Me.tb_jch_cz.Items.AddRange(New Object() {"设备清洗", "设备润滑", "生产", "包装", "取样", "实验", "其它", "转厂"})
        Me.tb_jch_cz.Location = New System.Drawing.Point(411, 20)
        Me.tb_jch_cz.Name = "tb_jch_cz"
        Me.tb_jch_cz.Size = New System.Drawing.Size(87, 20)
        Me.tb_jch_cz.TabIndex = 139
        '
        'tb_jch_cplb
        '
        Me.tb_jch_cplb.Location = New System.Drawing.Point(239, 102)
        Me.tb_jch_cplb.Name = "tb_jch_cplb"
        Me.tb_jch_cplb.Size = New System.Drawing.Size(100, 21)
        Me.tb_jch_cplb.TabIndex = 165
        Me.tb_jch_cplb.Visible = False
        '
        'tb_jch_yfcllygd
        '
        Me.tb_jch_yfcllygd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_jch_yfcllygd.FormattingEnabled = True
        Me.tb_jch_yfcllygd.Items.AddRange(New Object() {"发酵", "浸出", "粉剂", "精炼", "QC", "技术", "其它", "湖北工厂", "武汉工厂", "DHA"})
        Me.tb_jch_yfcllygd.Location = New System.Drawing.Point(563, 20)
        Me.tb_jch_yfcllygd.Name = "tb_jch_yfcllygd"
        Me.tb_jch_yfcllygd.Size = New System.Drawing.Size(87, 20)
        Me.tb_jch_yfcllygd.TabIndex = 167
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(504, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "领用工段"
        '
        'Frfscylsy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 485)
        Me.Controls.Add(Me.tb_jch_yfcllygd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_jch_cplb)
        Me.Controls.Add(Me.tb_jch_cz)
        Me.Controls.Add(Me.tb_jch_rq)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.tb_jch_sl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_jch_num)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tb_jch_bz)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frfscylsy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "原辅料车间库存"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.showl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents tb_jch_sl As chencontrol.chentextzs
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_jch_bz As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_jch_rq As chencontrol.chendatepick
    Friend WithEvents tb_jch_num As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tb_jch_cz As System.Windows.Forms.ComboBox
    Friend WithEvents tb_jch_cplb As System.Windows.Forms.TextBox
    Friend WithEvents tb_jch_yfcllygd As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents showl As System.Windows.Forms.DataGridView
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
End Class
