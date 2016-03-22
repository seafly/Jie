<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frpxlb
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
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.showl = New System.Windows.Forms.DataGridView
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Labelserch = New System.Windows.Forms.Label
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.showl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(479, 52)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 23)
        Me.Button3.TabIndex = 40
        Me.Button3.Text = "关闭"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(321, 52)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "导出EXCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(254, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(108, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "至"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(131, 14)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(92, 21)
        Me.DateTimePicker2.TabIndex = 36
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(90, 21)
        Me.DateTimePicker1.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(230, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "学员"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(345, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "讲师"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(277, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(62, 21)
        Me.TextBox1.TabIndex = 43
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(392, 13)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(62, 21)
        Me.TextBox2.TabIndex = 44
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(410, 52)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(63, 23)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "添加"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'showl
        '
        Me.showl.AllowUserToAddRows = False
        Me.showl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.showl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.showl.Location = New System.Drawing.Point(3, 88)
        Me.showl.MultiSelect = False
        Me.showl.Name = "showl"
        Me.showl.ReadOnly = True
        Me.showl.RowHeadersVisible = False
        Me.showl.RowTemplate.Height = 23
        Me.showl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showl.Size = New System.Drawing.Size(860, 312)
        Me.showl.TabIndex = 46
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(507, 13)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(62, 21)
        Me.TextBox3.TabIndex = 48
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(460, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "课程"
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.BackColor = System.Drawing.Color.Transparent
        Me.Labelserch.Location = New System.Drawing.Point(12, 58)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 70
        Me.Labelserch.Text = "文本"
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(147, 52)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(75, 21)
        Me.TextBoxserchtext.TabIndex = 69
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(47, 52)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(94, 20)
        Me.ComboBoxserchtext.TabIndex = 68
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(561, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "查询结果"
        '
        'Frpxlb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 412)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Labelserch)
        Me.Controls.Add(Me.TextBoxserchtext)
        Me.Controls.Add(Me.ComboBoxserchtext)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.showl)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "Frpxlb"
        Me.Text = "个人培训档案"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        CType(Me.showl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents showl As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
