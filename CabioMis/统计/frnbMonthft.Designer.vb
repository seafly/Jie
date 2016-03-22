<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frnbMonthft
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.yue1 = New System.Windows.Forms.ComboBox
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.tb_nhft_PTdays = New chencontrol.chentextint
        Me.tb_nhft_POdays = New chencontrol.chentextint
        Me.tb_nhft_Odays = New chencontrol.chentextint
        Me.tb_nhft_Fdays = New chencontrol.chentextint
        Me.tb_nhft_PTcl = New chencontrol.chentextzs
        Me.tb_nhft_POcl = New chencontrol.chentextzs
        Me.tb_nhft_Ocl = New chencontrol.chentextzs
        Me.tb_nhft_Fcl = New chencontrol.chentextzs
        Me.tb_nhft_ID = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(83, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(53, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "请选择日期时段："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(320, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "月"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(239, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "年"
        '
        'yue1
        '
        Me.yue1.DropDownHeight = 150
        Me.yue1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.yue1.FormattingEnabled = True
        Me.yue1.IntegralHeight = False
        Me.yue1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.yue1.Location = New System.Drawing.Point(262, 29)
        Me.yue1.Name = "yue1"
        Me.yue1.Size = New System.Drawing.Size(52, 20)
        Me.yue1.TabIndex = 5
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian1.Location = New System.Drawing.Point(160, 29)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(72, 20)
        Me.nian1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(56, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fermentation："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(110, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Oil："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(74, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Powder Ⅰ："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(74, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Powder Ⅱ："
        '
        'tb_nhft_PTdays
        '
        Me.tb_nhft_PTdays.Location = New System.Drawing.Point(171, 223)
        Me.tb_nhft_PTdays.Name = "tb_nhft_PTdays"
        Me.tb_nhft_PTdays.Size = New System.Drawing.Size(41, 21)
        Me.tb_nhft_PTdays.TabIndex = 0
        '
        'tb_nhft_POdays
        '
        Me.tb_nhft_POdays.Location = New System.Drawing.Point(171, 183)
        Me.tb_nhft_POdays.Name = "tb_nhft_POdays"
        Me.tb_nhft_POdays.Size = New System.Drawing.Size(41, 21)
        Me.tb_nhft_POdays.TabIndex = 0
        '
        'tb_nhft_Odays
        '
        Me.tb_nhft_Odays.Location = New System.Drawing.Point(171, 143)
        Me.tb_nhft_Odays.Name = "tb_nhft_Odays"
        Me.tb_nhft_Odays.Size = New System.Drawing.Size(41, 21)
        Me.tb_nhft_Odays.TabIndex = 0
        '
        'tb_nhft_Fdays
        '
        Me.tb_nhft_Fdays.Location = New System.Drawing.Point(171, 103)
        Me.tb_nhft_Fdays.Name = "tb_nhft_Fdays"
        Me.tb_nhft_Fdays.Size = New System.Drawing.Size(41, 21)
        Me.tb_nhft_Fdays.TabIndex = 0
        '
        'tb_nhft_PTcl
        '
        Me.tb_nhft_PTcl.Location = New System.Drawing.Point(232, 223)
        Me.tb_nhft_PTcl.Name = "tb_nhft_PTcl"
        Me.tb_nhft_PTcl.Size = New System.Drawing.Size(105, 21)
        Me.tb_nhft_PTcl.TabIndex = 12
        '
        'tb_nhft_POcl
        '
        Me.tb_nhft_POcl.Location = New System.Drawing.Point(232, 183)
        Me.tb_nhft_POcl.Name = "tb_nhft_POcl"
        Me.tb_nhft_POcl.Size = New System.Drawing.Size(105, 21)
        Me.tb_nhft_POcl.TabIndex = 12
        '
        'tb_nhft_Ocl
        '
        Me.tb_nhft_Ocl.Location = New System.Drawing.Point(232, 143)
        Me.tb_nhft_Ocl.Name = "tb_nhft_Ocl"
        Me.tb_nhft_Ocl.Size = New System.Drawing.Size(105, 21)
        Me.tb_nhft_Ocl.TabIndex = 12
        '
        'tb_nhft_Fcl
        '
        Me.tb_nhft_Fcl.Location = New System.Drawing.Point(232, 103)
        Me.tb_nhft_Fcl.Name = "tb_nhft_Fcl"
        Me.tb_nhft_Fcl.Size = New System.Drawing.Size(105, 21)
        Me.tb_nhft_Fcl.TabIndex = 12
        '
        'tb_nhft_ID
        '
        Me.tb_nhft_ID.Location = New System.Drawing.Point(275, 272)
        Me.tb_nhft_ID.Name = "tb_nhft_ID"
        Me.tb_nhft_ID.Size = New System.Drawing.Size(51, 21)
        Me.tb_nhft_ID.TabIndex = 12
        Me.tb_nhft_ID.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label8.Location = New System.Drawing.Point(82, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "工 段"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label9.Location = New System.Drawing.Point(157, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "生产天数"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(260, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "产 量"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(194, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "关闭"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frnbMonthft
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 336)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tb_nhft_PTcl)
        Me.Controls.Add(Me.tb_nhft_PTdays)
        Me.Controls.Add(Me.tb_nhft_POcl)
        Me.Controls.Add(Me.tb_nhft_POdays)
        Me.Controls.Add(Me.tb_nhft_Ocl)
        Me.Controls.Add(Me.tb_nhft_Fcl)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tb_nhft_Odays)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_nhft_Fdays)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_nhft_ID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.yue1)
        Me.Controls.Add(Me.nian1)
        Me.MaximizeBox = False
        Me.Name = "frnbMonthft"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "能耗分摊"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents yue1 As System.Windows.Forms.ComboBox
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_nhft_PTdays As chencontrol.chentextint
    Friend WithEvents tb_nhft_POdays As chencontrol.chentextint
    Friend WithEvents tb_nhft_Odays As chencontrol.chentextint
    Friend WithEvents tb_nhft_Fdays As chencontrol.chentextint
    Friend WithEvents tb_nhft_PTcl As chencontrol.chentextzs
    Friend WithEvents tb_nhft_POcl As chencontrol.chentextzs
    Friend WithEvents tb_nhft_Ocl As chencontrol.chentextzs
    Friend WithEvents tb_nhft_Fcl As chencontrol.chentextzs
    Friend WithEvents tb_nhft_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
