<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frshowwg
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Labelserch = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBoxserchtext = New System.Windows.Forms.TextBox
        Me.ComboBoxserchtext = New System.Windows.Forms.ComboBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Buttsearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Buttonunload = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.listview1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.listview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.Location = New System.Drawing.Point(282, 21)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 67
        Me.Labelserch.Text = "文本"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Labelserch)
        Me.GroupBox1.Controls.Add(Me.TextBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.ComboBoxserchtext)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Buttsearch)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Buttonunload)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 65)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        '
        'TextBoxserchtext
        '
        Me.TextBoxserchtext.Location = New System.Drawing.Point(417, 15)
        Me.TextBoxserchtext.Name = "TextBoxserchtext"
        Me.TextBoxserchtext.Size = New System.Drawing.Size(75, 21)
        Me.TextBoxserchtext.TabIndex = 66
        '
        'ComboBoxserchtext
        '
        Me.ComboBoxserchtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxserchtext.FormattingEnabled = True
        Me.ComboBoxserchtext.Location = New System.Drawing.Point(317, 15)
        Me.ComboBoxserchtext.Name = "ComboBoxserchtext"
        Me.ComboBoxserchtext.Size = New System.Drawing.Size(94, 20)
        Me.ComboBoxserchtext.TabIndex = 65
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(151, 13)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker2.TabIndex = 55
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker1.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(128, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "至"
        '
        'Buttsearch
        '
        Me.Buttsearch.Location = New System.Drawing.Point(421, 39)
        Me.Buttsearch.Name = "Buttsearch"
        Me.Buttsearch.Size = New System.Drawing.Size(75, 23)
        Me.Buttsearch.TabIndex = 52
        Me.Buttsearch.Text = "查询"
        Me.Buttsearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(17, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(682, 38)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(72, 23)
        Me.Buttonunload.TabIndex = 39
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(602, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 23)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "生成文件"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(511, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "添加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'listview1
        '
        Me.listview1.AllowUserToAddRows = False
        Me.listview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.listview1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.listview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.listview1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.listview1.Location = New System.Drawing.Point(9, 83)
        Me.listview1.MultiSelect = False
        Me.listview1.Name = "listview1"
        Me.listview1.ReadOnly = True
        Me.listview1.RowHeadersVisible = False
        Me.listview1.RowTemplate.Height = 23
        Me.listview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.listview1.Size = New System.Drawing.Size(838, 508)
        Me.listview1.TabIndex = 45
        '
        'Frshowwg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 603)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.listview1)
        Me.Name = "Frshowwg"
        Me.Text = "Frshowwg"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.listview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxserchtext As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxserchtext As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Buttsearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Buttonunload As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents listview1 As System.Windows.Forms.DataGridView
End Class
