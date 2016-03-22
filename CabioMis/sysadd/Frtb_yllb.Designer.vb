<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_yllb
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_yllb_dm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_yllb_mc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.Labeltb = New System.Windows.Forms.Label
        Me.Labelid = New System.Windows.Forms.Label
        Me.tb_yllb_lb = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(38, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "原料类别"
        '
        'tb_yllb_dm
        '
        Me.tb_yllb_dm.Location = New System.Drawing.Point(99, 74)
        Me.tb_yllb_dm.Name = "tb_yllb_dm"
        Me.tb_yllb_dm.Size = New System.Drawing.Size(100, 21)
        Me.tb_yllb_dm.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(38, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "原料代码"
        '
        'tb_yllb_mc
        '
        Me.tb_yllb_mc.Location = New System.Drawing.Point(99, 129)
        Me.tb_yllb_mc.Name = "tb_yllb_mc"
        Me.tb_yllb_mc.Size = New System.Drawing.Size(100, 21)
        Me.tb_yllb_mc.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(38, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "原料名称"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(146, 171)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 71
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(40, 171)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 70
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(206, 52)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 90
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(109, 104)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 91
        Me.Labelid.Text = "Labelid"
        Me.Labelid.Visible = False
        '
        'tb_yllb_lb
        '
        Me.tb_yllb_lb.FormattingEnabled = True
        Me.tb_yllb_lb.Items.AddRange(New Object() {"发酵原料", "油剂原料", "粉剂原料", "包材"})
        Me.tb_yllb_lb.Location = New System.Drawing.Point(97, 32)
        Me.tb_yllb_lb.Name = "tb_yllb_lb"
        Me.tb_yllb_lb.Size = New System.Drawing.Size(103, 20)
        Me.tb_yllb_lb.TabIndex = 92
        '
        'Frtb_yllb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 220)
        Me.Controls.Add(Me.tb_yllb_lb)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.tb_yllb_mc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_yllb_dm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_yllb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "原料类别"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_dm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_mc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents tb_yllb_lb As System.Windows.Forms.ComboBox
End Class
