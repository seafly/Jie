<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frfhwc
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
        Me.Label20 = New System.Windows.Forms.Label
        Me.tb_dd_jfwc = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(255, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 12)
        Me.Label20.TabIndex = 240
        Me.Label20.Text = "交付完成"
        '
        'tb_dd_jfwc
        '
        Me.tb_dd_jfwc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_dd_jfwc.FormattingEnabled = True
        Me.tb_dd_jfwc.Items.AddRange(New Object() {"完成", "否"})
        Me.tb_dd_jfwc.Location = New System.Drawing.Point(331, 48)
        Me.tb_dd_jfwc.Name = "tb_dd_jfwc"
        Me.tb_dd_jfwc.Size = New System.Drawing.Size(124, 20)
        Me.tb_dd_jfwc.TabIndex = 239
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(209, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 245
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(398, 116)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 245
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Frfhwc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 195)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.tb_dd_jfwc)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frfhwc"
        Me.Text = "发货完成"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tb_dd_jfwc As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
