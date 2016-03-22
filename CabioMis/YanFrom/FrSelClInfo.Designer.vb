<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSelClInfo
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.iszp = New System.Windows.Forms.CheckBox()
        Me.isfg = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(109, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'iszp
        '
        Me.iszp.AutoSize = True
        Me.iszp.Checked = True
        Me.iszp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.iszp.Location = New System.Drawing.Point(79, 69)
        Me.iszp.Name = "iszp"
        Me.iszp.Size = New System.Drawing.Size(48, 16)
        Me.iszp.TabIndex = 2
        Me.iszp.Text = "正品"
        Me.iszp.UseVisualStyleBackColor = True
        '
        'isfg
        '
        Me.isfg.AutoSize = True
        Me.isfg.Location = New System.Drawing.Point(151, 69)
        Me.isfg.Name = "isfg"
        Me.isfg.Size = New System.Drawing.Size(60, 16)
        Me.isfg.TabIndex = 3
        Me.isfg.Text = "返工品"
        Me.isfg.UseVisualStyleBackColor = True
        '
        'FrSelClInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 211)
        Me.Controls.Add(Me.isfg)
        Me.Controls.Add(Me.iszp)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrSelClInfo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "原料设置"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents iszp As System.Windows.Forms.CheckBox
    Friend WithEvents isfg As System.Windows.Forms.CheckBox
End Class
