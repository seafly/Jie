<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_jg
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
        Me.tb_jg_num = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_jg_rq = New chencontrol.chendatepick
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tb_jg_pht = New System.Windows.Forms.TextBox
        Me.zl = New System.Windows.Forms.Label
        Me.ph = New System.Windows.Forms.Label
        Me.Labeltb = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.Labelid = New System.Windows.Forms.Label
        Me.tb_jg_zl = New System.Windows.Forms.TextBox
        Me.tb_jg_ph = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tb_jg_yw = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "碱罐批号"
        '
        'tb_jg_num
        '
        Me.tb_jg_num.Location = New System.Drawing.Point(98, 23)
        Me.tb_jg_num.Name = "tb_jg_num"
        Me.tb_jg_num.Size = New System.Drawing.Size(145, 21)
        Me.tb_jg_num.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(330, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "配料时间"
        '
        'tb_jg_rq
        '
        Me.tb_jg_rq.BackColor = System.Drawing.Color.White
        Me.tb_jg_rq.Location = New System.Drawing.Point(387, 23)
        Me.tb_jg_rq.Name = "tb_jg_rq"
        Me.tb_jg_rq.Size = New System.Drawing.Size(136, 21)
        Me.tb_jg_rq.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "氢氧化钠批号"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(282, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "氢氧化钠重量序列"
        '
        'tb_jg_pht
        '
        Me.tb_jg_pht.Location = New System.Drawing.Point(390, 77)
        Me.tb_jg_pht.Name = "tb_jg_pht"
        Me.tb_jg_pht.ReadOnly = True
        Me.tb_jg_pht.Size = New System.Drawing.Size(133, 21)
        Me.tb_jg_pht.TabIndex = 7
        '
        'zl
        '
        Me.zl.AutoSize = True
        Me.zl.Location = New System.Drawing.Point(185, 198)
        Me.zl.Name = "zl"
        Me.zl.Size = New System.Drawing.Size(17, 12)
        Me.zl.TabIndex = 132
        Me.zl.Text = "zl"
        Me.zl.Visible = False
        '
        'ph
        '
        Me.ph.AutoSize = True
        Me.ph.Location = New System.Drawing.Point(156, 195)
        Me.ph.Name = "ph"
        Me.ph.Size = New System.Drawing.Size(17, 12)
        Me.ph.TabIndex = 131
        Me.ph.Text = "ph"
        Me.ph.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(84, 197)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 130
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(391, 186)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 129
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(215, 186)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 128
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(40, 198)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(23, 12)
        Me.Labelid.TabIndex = 134
        Me.Labelid.Text = " id"
        Me.Labelid.Visible = False
        '
        'tb_jg_zl
        '
        Me.tb_jg_zl.Location = New System.Drawing.Point(484, 186)
        Me.tb_jg_zl.Name = "tb_jg_zl"
        Me.tb_jg_zl.Size = New System.Drawing.Size(100, 21)
        Me.tb_jg_zl.TabIndex = 135
        Me.tb_jg_zl.Visible = False
        '
        'tb_jg_ph
        '
        Me.tb_jg_ph.Location = New System.Drawing.Point(98, 77)
        Me.tb_jg_ph.Name = "tb_jg_ph"
        Me.tb_jg_ph.ReadOnly = True
        Me.tb_jg_ph.Size = New System.Drawing.Size(145, 21)
        Me.tb_jg_ph.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(27, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "是否用完"
        '
        'tb_jg_yw
        '
        Me.tb_jg_yw.FormattingEnabled = True
        Me.tb_jg_yw.Items.AddRange(New Object() {"是", "否"})
        Me.tb_jg_yw.Location = New System.Drawing.Point(98, 128)
        Me.tb_jg_yw.Name = "tb_jg_yw"
        Me.tb_jg_yw.Size = New System.Drawing.Size(75, 20)
        Me.tb_jg_yw.TabIndex = 138
        '
        'Frtb_jg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 240)
        Me.Controls.Add(Me.tb_jg_yw)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_jg_rq)
        Me.Controls.Add(Me.tb_jg_ph)
        Me.Controls.Add(Me.tb_jg_zl)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.zl)
        Me.Controls.Add(Me.ph)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_jg_num)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_jg_pht)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_jg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "碱罐"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_jg_num As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_jg_rq As chencontrol.chendatepick
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_jg_pht As System.Windows.Forms.TextBox
    Friend WithEvents zl As System.Windows.Forms.Label
    Friend WithEvents ph As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents tb_jg_zl As System.Windows.Forms.TextBox
    Friend WithEvents tb_jg_ph As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_jg_yw As System.Windows.Forms.ComboBox
End Class
