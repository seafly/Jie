<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_beizhu
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
        Me.Labelid = New System.Windows.Forms.Label
        Me.labeltb = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_beizhu_rq = New System.Windows.Forms.DateTimePicker
        Me.tb_beizhu_biaoti = New System.Windows.Forms.TextBox
        Me.tb_beizhu_xxsm = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(41, 182)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(0, 12)
        Me.Labelid.TabIndex = 0
        Me.Labelid.Visible = False
        '
        'labeltb
        '
        Me.labeltb.AutoSize = True
        Me.labeltb.Location = New System.Drawing.Point(41, 215)
        Me.labeltb.Name = "labeltb"
        Me.labeltb.Size = New System.Drawing.Size(41, 12)
        Me.labeltb.TabIndex = 1
        Me.labeltb.Text = "Label2"
        Me.labeltb.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(53, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "日期："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(53, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "标题："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(41, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "详细说明："
        '
        'tb_beizhu_rq
        '
        Me.tb_beizhu_rq.Location = New System.Drawing.Point(116, 18)
        Me.tb_beizhu_rq.Name = "tb_beizhu_rq"
        Me.tb_beizhu_rq.Size = New System.Drawing.Size(175, 21)
        Me.tb_beizhu_rq.TabIndex = 5
        '
        'tb_beizhu_biaoti
        '
        Me.tb_beizhu_biaoti.Location = New System.Drawing.Point(116, 50)
        Me.tb_beizhu_biaoti.Name = "tb_beizhu_biaoti"
        Me.tb_beizhu_biaoti.Size = New System.Drawing.Size(358, 21)
        Me.tb_beizhu_biaoti.TabIndex = 6
        '
        'tb_beizhu_xxsm
        '
        Me.tb_beizhu_xxsm.Location = New System.Drawing.Point(116, 89)
        Me.tb_beizhu_xxsm.Multiline = True
        Me.tb_beizhu_xxsm.Name = "tb_beizhu_xxsm"
        Me.tb_beizhu_xxsm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_beizhu_xxsm.Size = New System.Drawing.Size(528, 239)
        Me.tb_beizhu_xxsm.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(203, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(347, 347)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Frtb_beizhu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 406)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tb_beizhu_xxsm)
        Me.Controls.Add(Me.tb_beizhu_biaoti)
        Me.Controls.Add(Me.tb_beizhu_rq)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.labeltb)
        Me.Controls.Add(Me.Labelid)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_beizhu"
        Me.Text = "每月重要说明"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents labeltb As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_beizhu_rq As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_beizhu_biaoti As System.Windows.Forms.TextBox
    Friend WithEvents tb_beizhu_xxsm As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
