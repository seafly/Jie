<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frzx
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
        Me.Button7 = New System.Windows.Forms.Button
        Me.tb_yg_js = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_yg_n430f = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(119, 199)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(60, 23)
        Me.Button7.TabIndex = 55
        Me.Button7.Text = "确定"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'tb_yg_js
        '
        Me.tb_yg_js.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yg_js.FormattingEnabled = True
        Me.tb_yg_js.Location = New System.Drawing.Point(119, 92)
        Me.tb_yg_js.Name = "tb_yg_js"
        Me.tb_yg_js.Size = New System.Drawing.Size(101, 20)
        Me.tb_yg_js.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(72, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "角色"
        '
        'tb_yg_n430f
        '
        Me.tb_yg_n430f.Location = New System.Drawing.Point(119, 44)
        Me.tb_yg_n430f.Name = "tb_yg_n430f"
        Me.tb_yg_n430f.Size = New System.Drawing.Size(86, 21)
        Me.tb_yg_n430f.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(72, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "工号"
        '
        'Frzx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.tb_yg_js)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_yg_n430f)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frzx"
        Me.Text = "角色管理"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents tb_yg_js As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_yg_n430f As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
