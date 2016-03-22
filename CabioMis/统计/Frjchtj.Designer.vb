<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frjchtj
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Buttonunload = New System.Windows.Forms.Button
        Me.showl = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.showl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(21, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "开始日期"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(91, 64)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(135, 21)
        Me.DateTimePicker1.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(232, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "至"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(255, 64)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(135, 21)
        Me.DateTimePicker2.TabIndex = 47
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(408, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(503, 64)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 49
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(503, 12)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(104, 23)
        Me.Buttonunload.TabIndex = 50
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'showl
        '
        Me.showl.AllowUserToAddRows = False
        Me.showl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.showl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.showl.Location = New System.Drawing.Point(14, 122)
        Me.showl.MultiSelect = False
        Me.showl.Name = "showl"
        Me.showl.ReadOnly = True
        Me.showl.RowHeadersVisible = False
        Me.showl.RowTemplate.Height = 23
        Me.showl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showl.Size = New System.Drawing.Size(609, 492)
        Me.showl.TabIndex = 51
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(8, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "请选择统计期"
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Location = New System.Drawing.Point(91, 14)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(135, 20)
        Me.nian1.TabIndex = 52
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(255, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 23)
        Me.Button2.TabIndex = 54
        Me.Button2.Text = "查询"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(408, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 55
        Me.Button3.Text = "保存"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Frjchtj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 649)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nian1)
        Me.Controls.Add(Me.showl)
        Me.Controls.Add(Me.Buttonunload)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frjchtj"
        Me.Text = "成品出入库统计"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.showl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Buttonunload As System.Windows.Forms.Button
    Friend WithEvents showl As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
