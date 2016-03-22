<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frygpx
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
        Me.SSSQX = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.yue2 = New System.Windows.Forms.ComboBox
        Me.yue1 = New System.Windows.Forms.ComboBox
        Me.nian2 = New System.Windows.Forms.ComboBox
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.SSSQX)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.yue2)
        Me.GroupBox1.Controls.Add(Me.yue1)
        Me.GroupBox1.Controls.Add(Me.nian2)
        Me.GroupBox1.Controls.Add(Me.nian1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 80)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(482, 50)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(64, 23)
        Me.Button3.TabIndex = 218
        Me.Button3.Text = "筛选"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(751, 17)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 214
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(392, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(84, 21)
        Me.TextBox1.TabIndex = 217
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(657, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "确定审核"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"地点", "讲师", "课程", "培训类别"})
        Me.ComboBox1.Location = New System.Drawing.Point(315, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(71, 20)
        Me.ComboBox1.TabIndex = 216
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(722, 51)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 9
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Location = New System.Drawing.Point(6, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(245, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "双击下面表格中的项目，即可查看详细情况。"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(255, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 215
        Me.Label8.Text = "结果筛选"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(573, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "请选择统计日期时段："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label5.Location = New System.Drawing.Point(331, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "至"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(537, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "月"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(295, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "月"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(456, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "年"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(214, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "年"
        '
        'yue2
        '
        Me.yue2.DropDownHeight = 150
        Me.yue2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.yue2.FormattingEnabled = True
        Me.yue2.IntegralHeight = False
        Me.yue2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.yue2.Location = New System.Drawing.Point(479, 19)
        Me.yue2.Name = "yue2"
        Me.yue2.Size = New System.Drawing.Size(52, 20)
        Me.yue2.TabIndex = 0
        '
        'yue1
        '
        Me.yue1.DropDownHeight = 150
        Me.yue1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.yue1.FormattingEnabled = True
        Me.yue1.IntegralHeight = False
        Me.yue1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.yue1.Location = New System.Drawing.Point(237, 19)
        Me.yue1.Name = "yue1"
        Me.yue1.Size = New System.Drawing.Size(52, 20)
        Me.yue1.TabIndex = 0
        '
        'nian2
        '
        Me.nian2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian2.FormattingEnabled = True
        Me.nian2.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian2.Location = New System.Drawing.Point(377, 19)
        Me.nian2.Name = "nian2"
        Me.nian2.Size = New System.Drawing.Size(72, 20)
        Me.nian2.TabIndex = 0
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian1.Location = New System.Drawing.Point(135, 19)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(72, 20)
        Me.nian1.TabIndex = 0
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(-3, 98)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(902, 374)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(552, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 12)
        Me.Label9.TabIndex = 219
        Me.Label9.Text = "(共0条记录)"
        '
        'frygpx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 472)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frygpx"
        Me.Text = "员工培训统计"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents yue2 As System.Windows.Forms.ComboBox
    Friend WithEvents yue1 As System.Windows.Forms.ComboBox
    Friend WithEvents nian2 As System.Windows.Forms.ComboBox
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
