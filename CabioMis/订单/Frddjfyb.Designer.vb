<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frddjfyb
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.show1 = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.ToExcel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(267, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "月"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(133, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "年"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(156, 30)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox2.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(24, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox1.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(594, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(294, 30)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox3.TabIndex = 4
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(426, 30)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox4.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(403, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "年"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(540, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "月"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.show1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(946, 455)
        Me.GroupBox1.TabIndex = 131
        Me.GroupBox1.TabStop = False
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
        Me.show1.Size = New System.Drawing.Size(940, 435)
        Me.show1.TabIndex = 71
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(682, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 23)
        Me.Button2.TabIndex = 132
        Me.Button2.Text = "今日有效库存"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(777, 27)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(89, 23)
        Me.ToExcel.TabIndex = 133
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Frddjfyb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 514)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Frddjfyb"
        Me.Text = "订单交付月报"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToExcel As System.Windows.Forms.Button
End Class
