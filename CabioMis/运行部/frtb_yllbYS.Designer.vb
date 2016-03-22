<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frtb_yllbYS
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_yllb_lb = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_yllb_dm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_yllb_mc = New System.Windows.Forms.TextBox
        Me.butAction = New System.Windows.Forms.Button
        Me.cancel = New System.Windows.Forms.Button
        Me.tb_yllb_yxx = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tb_yllb_xh = New System.Windows.Forms.TextBox
        Me.tb_yllb_gg = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(42, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "原料类别"
        '
        'tb_yllb_lb
        '
        Me.tb_yllb_lb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yllb_lb.FormattingEnabled = True
        Me.tb_yllb_lb.Location = New System.Drawing.Point(101, 25)
        Me.tb_yllb_lb.Name = "tb_yllb_lb"
        Me.tb_yllb_lb.Size = New System.Drawing.Size(100, 20)
        Me.tb_yllb_lb.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(287, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "原料代码"
        '
        'tb_yllb_dm
        '
        Me.tb_yllb_dm.Location = New System.Drawing.Point(346, 24)
        Me.tb_yllb_dm.Name = "tb_yllb_dm"
        Me.tb_yllb_dm.Size = New System.Drawing.Size(100, 21)
        Me.tb_yllb_dm.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(42, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "原料名称"
        '
        'tb_yllb_mc
        '
        Me.tb_yllb_mc.Location = New System.Drawing.Point(101, 74)
        Me.tb_yllb_mc.Name = "tb_yllb_mc"
        Me.tb_yllb_mc.Size = New System.Drawing.Size(100, 21)
        Me.tb_yllb_mc.TabIndex = 5
        '
        'butAction
        '
        Me.butAction.Location = New System.Drawing.Point(285, 127)
        Me.butAction.Name = "butAction"
        Me.butAction.Size = New System.Drawing.Size(80, 24)
        Me.butAction.TabIndex = 6
        Me.butAction.Text = "Button1"
        Me.butAction.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(371, 127)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 7
        Me.cancel.Text = "取消"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'tb_yllb_yxx
        '
        Me.tb_yllb_yxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yllb_yxx.FormattingEnabled = True
        Me.tb_yllb_yxx.Location = New System.Drawing.Point(101, 127)
        Me.tb_yllb_yxx.Name = "tb_yllb_yxx"
        Me.tb_yllb_yxx.Size = New System.Drawing.Size(100, 20)
        Me.tb_yllb_yxx.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(54, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "有效性"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(222, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "单位"
        '
        'tb_yllb_xh
        '
        Me.tb_yllb_xh.Location = New System.Drawing.Point(265, 77)
        Me.tb_yllb_xh.Name = "tb_yllb_xh"
        Me.tb_yllb_xh.Size = New System.Drawing.Size(56, 21)
        Me.tb_yllb_xh.TabIndex = 11
        '
        'tb_yllb_gg
        '
        Me.tb_yllb_gg.Location = New System.Drawing.Point(379, 80)
        Me.tb_yllb_gg.Name = "tb_yllb_gg"
        Me.tb_yllb_gg.Size = New System.Drawing.Size(56, 21)
        Me.tb_yllb_gg.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(336, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "规格"
        '
        'frtb_yllbYS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 172)
        Me.Controls.Add(Me.tb_yllb_gg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tb_yllb_xh)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_yllb_yxx)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.butAction)
        Me.Controls.Add(Me.tb_yllb_mc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_yllb_dm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_yllb_lb)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frtb_yllbYS"
        Me.Text = "添加原料类别"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_lb As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_dm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_mc As System.Windows.Forms.TextBox
    Friend WithEvents butAction As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents tb_yllb_yxx As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_xh As System.Windows.Forms.TextBox
    Friend WithEvents tb_yllb_gg As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
