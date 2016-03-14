<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_jg2
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
        Me.tb_jg2_rq = New chencontrol.chendatepick
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_jg2_ph = New System.Windows.Forms.TextBox
        Me.tb_jg2_pht = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tb_jg2_zl = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Labelid = New System.Windows.Forms.Label
        Me.zl = New System.Windows.Forms.Label
        Me.ph = New System.Windows.Forms.Label
        Me.Labeltb = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'tb_jg2_rq
        '
        Me.tb_jg2_rq.BackColor = System.Drawing.Color.White
        Me.tb_jg2_rq.Location = New System.Drawing.Point(119, 24)
        Me.tb_jg2_rq.Name = "tb_jg2_rq"
        Me.tb_jg2_rq.Size = New System.Drawing.Size(140, 21)
        Me.tb_jg2_rq.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(60, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "配料时间"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(279, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "氢氧化钠批号"
        '
        'tb_jg2_ph
        '
        Me.tb_jg2_ph.Location = New System.Drawing.Point(362, 24)
        Me.tb_jg2_ph.Name = "tb_jg2_ph"
        Me.tb_jg2_ph.ReadOnly = True
        Me.tb_jg2_ph.Size = New System.Drawing.Size(140, 21)
        Me.tb_jg2_ph.TabIndex = 3
        '
        'tb_jg2_pht
        '
        Me.tb_jg2_pht.Location = New System.Drawing.Point(119, 81)
        Me.tb_jg2_pht.Name = "tb_jg2_pht"
        Me.tb_jg2_pht.ReadOnly = True
        Me.tb_jg2_pht.Size = New System.Drawing.Size(140, 21)
        Me.tb_jg2_pht.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "氢氧化钠重量序列"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "总重量"
        Me.Label4.Visible = False
        '
        'tb_jg2_zl
        '
        Me.tb_jg2_zl.Location = New System.Drawing.Point(81, 108)
        Me.tb_jg2_zl.Name = "tb_jg2_zl"
        Me.tb_jg2_zl.Size = New System.Drawing.Size(110, 21)
        Me.tb_jg2_zl.TabIndex = 7
        Me.tb_jg2_zl.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(347, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(428, 79)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(337, 114)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(23, 12)
        Me.Labelid.TabIndex = 138
        Me.Labelid.Text = " id"
        Me.Labelid.Visible = False
        '
        'zl
        '
        Me.zl.AutoSize = True
        Me.zl.Location = New System.Drawing.Point(482, 114)
        Me.zl.Name = "zl"
        Me.zl.Size = New System.Drawing.Size(17, 12)
        Me.zl.TabIndex = 137
        Me.zl.Text = "zl"
        Me.zl.Visible = False
        '
        'ph
        '
        Me.ph.AutoSize = True
        Me.ph.Location = New System.Drawing.Point(453, 111)
        Me.ph.Name = "ph"
        Me.ph.Size = New System.Drawing.Size(17, 12)
        Me.ph.TabIndex = 136
        Me.ph.Text = "ph"
        Me.ph.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(388, 114)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 135
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        'Frtb_jg2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 138)
        Me.Controls.Add(Me.tb_jg2_rq)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.zl)
        Me.Controls.Add(Me.ph)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tb_jg2_zl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_jg2_ph)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_jg2_pht)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_jg2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CIP碱罐"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_jg2_rq As chencontrol.chendatepick
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_jg2_ph As System.Windows.Forms.TextBox
    Friend WithEvents tb_jg2_pht As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_jg2_zl As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents zl As System.Windows.Forms.Label
    Friend WithEvents ph As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
End Class
