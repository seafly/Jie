<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frdmbg
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ph = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Textbox4 = New System.Windows.Forms.ComboBox
        Me.Textbox2 = New System.Windows.Forms.ComboBox
        Me.Textbox3 = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"毛油", "成品油", "成品粉"})
        Me.ComboBox1.Location = New System.Drawing.Point(59, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 169
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(12, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 170
        Me.Label10.Text = "产品"
        '
        'ph
        '
        Me.ph.Location = New System.Drawing.Point(238, 24)
        Me.ph.Name = "ph"
        Me.ph.Size = New System.Drawing.Size(100, 21)
        Me.ph.TabIndex = 174
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(352, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 173
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(194, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "批号"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(105, 204)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 181
        Me.Button2.Text = "确定"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(284, 204)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 182
        Me.Button3.Text = "关闭"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(236, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = "用途"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(0, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 198
        Me.Label3.Text = "加工代码"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(220, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "产品代码"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(47, 173)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(368, 21)
        Me.TextBox5.TabIndex = 201
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 202
        Me.Label1.Text = "备注"
        '
        'Textbox4
        '
        Me.Textbox4.FormattingEnabled = True
        Me.Textbox4.Location = New System.Drawing.Point(284, 133)
        Me.Textbox4.Name = "Textbox4"
        Me.Textbox4.Size = New System.Drawing.Size(121, 20)
        Me.Textbox4.TabIndex = 203
        '
        'Textbox2
        '
        Me.Textbox2.FormattingEnabled = True
        Me.Textbox2.Location = New System.Drawing.Point(279, 80)
        Me.Textbox2.Name = "Textbox2"
        Me.Textbox2.Size = New System.Drawing.Size(126, 20)
        Me.Textbox2.TabIndex = 204
        '
        'Textbox3
        '
        Me.Textbox3.FormattingEnabled = True
        Me.Textbox3.Location = New System.Drawing.Point(61, 131)
        Me.Textbox3.Name = "Textbox3"
        Me.Textbox3.Size = New System.Drawing.Size(121, 20)
        Me.Textbox3.TabIndex = 205
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(61, 79)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(123, 21)
        Me.TextBox1.TabIndex = 206
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(0, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "产品类型"
        '
        'Frdmbg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 260)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Textbox3)
        Me.Controls.Add(Me.Textbox2)
        Me.Controls.Add(Me.Textbox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ph)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ComboBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frdmbg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "代码转换"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ph As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Textbox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Textbox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Textbox3 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
