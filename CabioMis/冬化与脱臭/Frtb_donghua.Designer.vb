<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_donghua
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
        Me.tb_donghua_jgrq = New chencontrol.chendatepick()
        Me.tb_donghua_num2 = New System.Windows.Forms.TextBox()
        Me.tb_donghua_num = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_donghua_bz = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.SSSQD = New System.Windows.Forms.Button()
        Me.Labeltb2 = New System.Windows.Forms.Label()
        Me.Labeltb = New System.Windows.Forms.Label()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.Labelid2 = New System.Windows.Forms.Label()
        Me.tb_donghua_sbid = New System.Windows.Forms.TextBox()
        Me.tb_donghua_sbtb = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_donghua_zl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_donghua_mytrl = New System.Windows.Forms.TextBox()
        Me.tb_tuoxiu_mytrl = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_donghua_fgfph = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_donghua_fgfpht = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_donghua_fgfbs = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'tb_donghua_jgrq
        '
        Me.tb_donghua_jgrq.BackColor = System.Drawing.Color.White
        Me.tb_donghua_jgrq.Location = New System.Drawing.Point(93, 124)
        Me.tb_donghua_jgrq.Name = "tb_donghua_jgrq"
        Me.tb_donghua_jgrq.Size = New System.Drawing.Size(118, 21)
        Me.tb_donghua_jgrq.TabIndex = 158
        '
        'tb_donghua_num2
        '
        Me.tb_donghua_num2.Location = New System.Drawing.Point(93, 19)
        Me.tb_donghua_num2.Name = "tb_donghua_num2"
        Me.tb_donghua_num2.ReadOnly = True
        Me.tb_donghua_num2.Size = New System.Drawing.Size(119, 21)
        Me.tb_donghua_num2.TabIndex = 157
        '
        'tb_donghua_num
        '
        Me.tb_donghua_num.Location = New System.Drawing.Point(93, 91)
        Me.tb_donghua_num.Name = "tb_donghua_num"
        Me.tb_donghua_num.Size = New System.Drawing.Size(118, 21)
        Me.tb_donghua_num.TabIndex = 156
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(22, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "产出日期"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(22, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "冬化批号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "上级批次"
        '
        'tb_donghua_bz
        '
        Me.tb_donghua_bz.Location = New System.Drawing.Point(93, 163)
        Me.tb_donghua_bz.Name = "tb_donghua_bz"
        Me.tb_donghua_bz.Size = New System.Drawing.Size(359, 21)
        Me.tb_donghua_bz.TabIndex = 164
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(26, 166)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 12)
        Me.Label18.TabIndex = 163
        Me.Label18.Text = "备注"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(265, 211)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 162
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(174, 211)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 161
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Labeltb2
        '
        Me.Labeltb2.AutoSize = True
        Me.Labeltb2.Location = New System.Drawing.Point(425, 257)
        Me.Labeltb2.Name = "Labeltb2"
        Me.Labeltb2.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb2.TabIndex = 166
        Me.Labeltb2.Text = " 上步表"
        Me.Labeltb2.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(331, 257)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(29, 12)
        Me.Labeltb.TabIndex = 165
        Me.Labeltb.Text = "本表"
        Me.Labeltb.Visible = False
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(278, 257)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 167
        Me.Labelid.Text = " 本表ID"
        Me.Labelid.Visible = False
        '
        'Labelid2
        '
        Me.Labelid2.AutoSize = True
        Me.Labelid2.Location = New System.Drawing.Point(363, 257)
        Me.Labelid2.Name = "Labelid2"
        Me.Labelid2.Size = New System.Drawing.Size(65, 12)
        Me.Labelid2.TabIndex = 168
        Me.Labelid2.Text = "  上步表ID"
        Me.Labelid2.Visible = False
        '
        'tb_donghua_sbid
        '
        Me.tb_donghua_sbid.Location = New System.Drawing.Point(80, 226)
        Me.tb_donghua_sbid.Name = "tb_donghua_sbid"
        Me.tb_donghua_sbid.Size = New System.Drawing.Size(59, 21)
        Me.tb_donghua_sbid.TabIndex = 170
        Me.tb_donghua_sbid.Text = "上部标识"
        Me.tb_donghua_sbid.Visible = False
        '
        'tb_donghua_sbtb
        '
        Me.tb_donghua_sbtb.Location = New System.Drawing.Point(12, 226)
        Me.tb_donghua_sbtb.Name = "tb_donghua_sbtb"
        Me.tb_donghua_sbtb.Size = New System.Drawing.Size(51, 21)
        Me.tb_donghua_sbtb.TabIndex = 169
        Me.tb_donghua_sbtb.Text = "上步表"
        Me.tb_donghua_sbtb.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"冬化", "脱臭"})
        Me.ComboBox1.Location = New System.Drawing.Point(333, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(119, 20)
        Me.ComboBox1.TabIndex = 171
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(263, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "操作类型"
        '
        'tb_donghua_zl
        '
        Me.tb_donghua_zl.Location = New System.Drawing.Point(333, 91)
        Me.tb_donghua_zl.Name = "tb_donghua_zl"
        Me.tb_donghua_zl.Size = New System.Drawing.Size(119, 21)
        Me.tb_donghua_zl.TabIndex = 174
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(263, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 173
        Me.Label5.Text = "产出重量"
        '
        'tb_donghua_mytrl
        '
        Me.tb_donghua_mytrl.Location = New System.Drawing.Point(12, 253)
        Me.tb_donghua_mytrl.Name = "tb_donghua_mytrl"
        Me.tb_donghua_mytrl.Size = New System.Drawing.Size(111, 21)
        Me.tb_donghua_mytrl.TabIndex = 175
        Me.tb_donghua_mytrl.Text = "毛油投入量(冬化)"
        Me.tb_donghua_mytrl.Visible = False
        '
        'tb_tuoxiu_mytrl
        '
        Me.tb_tuoxiu_mytrl.Location = New System.Drawing.Point(129, 253)
        Me.tb_tuoxiu_mytrl.Name = "tb_tuoxiu_mytrl"
        Me.tb_tuoxiu_mytrl.Size = New System.Drawing.Size(102, 21)
        Me.tb_tuoxiu_mytrl.TabIndex = 175
        Me.tb_tuoxiu_mytrl.Text = "毛油投入量(脱臭)"
        Me.tb_tuoxiu_mytrl.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(21, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "返工油批号"
        '
        'tb_donghua_fgfph
        '
        Me.tb_donghua_fgfph.Location = New System.Drawing.Point(93, 52)
        Me.tb_donghua_fgfph.Name = "tb_donghua_fgfph"
        Me.tb_donghua_fgfph.ReadOnly = True
        Me.tb_donghua_fgfph.Size = New System.Drawing.Size(119, 21)
        Me.tb_donghua_fgfph.TabIndex = 157
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(262, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 155
        Me.Label7.Text = "返工油批号"
        '
        'tb_donghua_fgfpht
        '
        Me.tb_donghua_fgfpht.Location = New System.Drawing.Point(333, 52)
        Me.tb_donghua_fgfpht.Name = "tb_donghua_fgfpht"
        Me.tb_donghua_fgfpht.ReadOnly = True
        Me.tb_donghua_fgfpht.Size = New System.Drawing.Size(119, 21)
        Me.tb_donghua_fgfpht.TabIndex = 157
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(304, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 155
        Me.Label8.Text = "返工油标识"
        Me.Label8.Visible = False
        '
        'tb_donghua_fgfbs
        '
        Me.tb_donghua_fgfbs.Location = New System.Drawing.Point(365, 127)
        Me.tb_donghua_fgfbs.Name = "tb_donghua_fgfbs"
        Me.tb_donghua_fgfbs.ReadOnly = True
        Me.tb_donghua_fgfbs.Size = New System.Drawing.Size(119, 21)
        Me.tb_donghua_fgfbs.TabIndex = 157
        Me.tb_donghua_fgfbs.Visible = False
        '
        'Frtb_donghua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 272)
        Me.Controls.Add(Me.tb_tuoxiu_mytrl)
        Me.Controls.Add(Me.tb_donghua_mytrl)
        Me.Controls.Add(Me.tb_donghua_zl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.tb_donghua_jgrq)
        Me.Controls.Add(Me.tb_donghua_sbid)
        Me.Controls.Add(Me.tb_donghua_sbtb)
        Me.Controls.Add(Me.Labelid2)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb2)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.tb_donghua_fgfpht)
        Me.Controls.Add(Me.tb_donghua_fgfbs)
        Me.Controls.Add(Me.tb_donghua_fgfph)
        Me.Controls.Add(Me.tb_donghua_num2)
        Me.Controls.Add(Me.tb_donghua_num)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_donghua_bz)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_donghua"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "冬化"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_donghua_jgrq As chencontrol.chendatepick
    Friend WithEvents tb_donghua_num2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_donghua_num As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_bz As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents Labeltb2 As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labelid2 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_sbid As System.Windows.Forms.TextBox
    Friend WithEvents tb_donghua_sbtb As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_zl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_mytrl As System.Windows.Forms.TextBox
    Friend WithEvents tb_tuoxiu_mytrl As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_fgfph As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_fgfpht As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_donghua_fgfbs As System.Windows.Forms.TextBox
End Class
