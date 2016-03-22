<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frShowyllbYS
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.tb_yllb_yxx = New System.Windows.Forms.ComboBox
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.tb_yllb_lb = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ListView1 = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.tb_yllb_yxx)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tb_yllb_lb)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 59)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "操作"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(344, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(62, 23)
        Me.Button3.TabIndex = 69
        Me.Button3.Text = "使无效"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'tb_yllb_yxx
        '
        Me.tb_yllb_yxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yllb_yxx.FormattingEnabled = True
        Me.tb_yllb_yxx.Location = New System.Drawing.Point(157, 23)
        Me.tb_yllb_yxx.Name = "tb_yllb_yxx"
        Me.tb_yllb_yxx.Size = New System.Drawing.Size(121, 20)
        Me.tb_yllb_yxx.TabIndex = 54
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(480, 21)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(82, 23)
        Me.ToExcel.TabIndex = 53
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "添加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_yllb_lb
        '
        Me.tb_yllb_lb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yllb_lb.FormattingEnabled = True
        Me.tb_yllb_lb.Location = New System.Drawing.Point(23, 23)
        Me.tb_yllb_lb.Name = "tb_yllb_lb"
        Me.tb_yllb_lb.Size = New System.Drawing.Size(127, 20)
        Me.tb_yllb_lb.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 475)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "显示"
        '
        'ListView1
        '
        Me.ListView1.AllowUserToAddRows = False
        Me.ListView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ReadOnly = True
        Me.ListView1.RowHeadersVisible = False
        Me.ListView1.RowTemplate.Height = 23
        Me.ListView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListView1.Size = New System.Drawing.Size(562, 455)
        Me.ListView1.TabIndex = 69
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(412, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 71
        Me.Button2.Text = "删除"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frShowyllbYS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 562)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frShowyllbYS"
        Me.Text = "原料类别"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_yllb_lb As System.Windows.Forms.ComboBox
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents tb_yllb_yxx As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
