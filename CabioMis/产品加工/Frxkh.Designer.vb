<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frxkh
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
        Me.tb_ddcys_mc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.tb_ddcys_fl = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_ddcys_khqc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'tb_ddcys_mc
        '
        Me.tb_ddcys_mc.Location = New System.Drawing.Point(170, 25)
        Me.tb_ddcys_mc.Name = "tb_ddcys_mc"
        Me.tb_ddcys_mc.Size = New System.Drawing.Size(234, 21)
        Me.tb_ddcys_mc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(76, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "名称"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(147, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(315, 137)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tb_ddcys_fl
        '
        Me.tb_ddcys_fl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_ddcys_fl.FormattingEnabled = True
        Me.tb_ddcys_fl.Items.AddRange(New Object() {"小客户", "承运商"})
        Me.tb_ddcys_fl.Location = New System.Drawing.Point(170, 63)
        Me.tb_ddcys_fl.Name = "tb_ddcys_fl"
        Me.tb_ddcys_fl.Size = New System.Drawing.Size(121, 20)
        Me.tb_ddcys_fl.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(76, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "分类"
        '
        'tb_ddcys_khqc
        '
        Me.tb_ddcys_khqc.Location = New System.Drawing.Point(170, 100)
        Me.tb_ddcys_khqc.Name = "tb_ddcys_khqc"
        Me.tb_ddcys_khqc.Size = New System.Drawing.Size(234, 21)
        Me.tb_ddcys_khqc.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(76, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "全称"
        '
        'Frxkh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 186)
        Me.Controls.Add(Me.tb_ddcys_fl)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_ddcys_khqc)
        Me.Controls.Add(Me.tb_ddcys_mc)
        Me.Name = "Frxkh"
        Me.Text = "Frxkh"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_ddcys_mc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tb_ddcys_fl As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_ddcys_khqc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
