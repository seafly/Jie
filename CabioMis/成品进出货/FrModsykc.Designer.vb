<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrModsykc
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
        Me.ph = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBoxbfmx = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Textbfs = New chencontrol.chentextzs
        Me.sykc = New chencontrol.chentextzs
        Me.Label2 = New System.Windows.Forms.Label
        Me.ckcl = New chencontrol.chentextzs
        Me.SuspendLayout()
        '
        'ph
        '
        Me.ph.Location = New System.Drawing.Point(273, 16)
        Me.ph.Name = "ph"
        Me.ph.Size = New System.Drawing.Size(100, 21)
        Me.ph.TabIndex = 176
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"毛油", "成品油", "成品粉", "原料"})
        Me.ComboBox1.Location = New System.Drawing.Point(72, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 175
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(404, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 174
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(31, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 173
        Me.Label10.Text = "产品"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(237, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "批号"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(19, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 12)
        Me.Label12.TabIndex = 177
        Me.Label12.Text = "当前剩余库存"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(298, 210)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 34)
        Me.SSSQX.TabIndex = 180
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Enabled = False
        Me.SSSQD.Location = New System.Drawing.Point(149, 210)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 34)
        Me.SSSQD.TabIndex = 179
        Me.SSSQD.Text = "修改"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(102, 122)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(401, 21)
        Me.TextBox1.TabIndex = 181
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(43, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "修改说明"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(147, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 186
        Me.Label13.Text = "报废明细"
        '
        'TextBoxbfmx
        '
        Me.TextBoxbfmx.Location = New System.Drawing.Point(206, 162)
        Me.TextBoxbfmx.Name = "TextBoxbfmx"
        Me.TextBoxbfmx.Size = New System.Drawing.Size(297, 21)
        Me.TextBoxbfmx.TabIndex = 185
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(17, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "报废数"
        '
        'Textbfs
        '
        Me.Textbfs.Location = New System.Drawing.Point(64, 162)
        Me.Textbfs.Name = "Textbfs"
        Me.Textbfs.Size = New System.Drawing.Size(76, 21)
        Me.Textbfs.TabIndex = 187
        '
        'sykc
        '
        Me.sykc.Location = New System.Drawing.Point(102, 69)
        Me.sykc.Name = "sykc"
        Me.sykc.Size = New System.Drawing.Size(91, 21)
        Me.sykc.TabIndex = 187
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(239, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "当前仓库存量"
        '
        'ckcl
        '
        Me.ckcl.Location = New System.Drawing.Point(332, 69)
        Me.ckcl.Name = "ckcl"
        Me.ckcl.Size = New System.Drawing.Size(91, 21)
        Me.ckcl.TabIndex = 189
        '
        'FrModsykc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 268)
        Me.Controls.Add(Me.ckcl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.sykc)
        Me.Controls.Add(Me.Textbfs)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBoxbfmx)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ph)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrModsykc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修改剩余库存"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ph As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxbfmx As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Textbfs As chencontrol.chentextzs
    Friend WithEvents sykc As chencontrol.chentextzs
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckcl As chencontrol.chentextzs
End Class
