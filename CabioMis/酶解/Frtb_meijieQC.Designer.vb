<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_meijieQC
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
        Me.tb_meijie_qcbz = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_meijie_qcsh = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_meijie_num = New System.Windows.Forms.TextBox()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.Labeltb = New System.Windows.Forms.Label()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.SSSQD = New System.Windows.Forms.Button()
        Me.tb_meijie_qcrq = New chencontrol.chendatepick()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_meijie_zy = New chencontrol.chentextzs()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tb_meijie_sf = New chencontrol.chentextzs()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_meijie_jj = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_meijie_jtzy = New chencontrol.chentextzs()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_meijie_jtsf = New chencontrol.chentextzs()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tb_meijie_qcbz
        '
        Me.tb_meijie_qcbz.Location = New System.Drawing.Point(128, 175)
        Me.tb_meijie_qcbz.Name = "tb_meijie_qcbz"
        Me.tb_meijie_qcbz.Size = New System.Drawing.Size(603, 21)
        Me.tb_meijie_qcbz.TabIndex = 115
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(54, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "备注"
        '
        'tb_meijie_qcsh
        '
        Me.tb_meijie_qcsh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_meijie_qcsh.FormattingEnabled = True
        Me.tb_meijie_qcsh.Items.AddRange(New Object() {"是", "否"})
        Me.tb_meijie_qcsh.Location = New System.Drawing.Point(128, 136)
        Me.tb_meijie_qcsh.Name = "tb_meijie_qcsh"
        Me.tb_meijie_qcsh.Size = New System.Drawing.Size(126, 20)
        Me.tb_meijie_qcsh.TabIndex = 113
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(30, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "QC审核"
        '
        'tb_meijie_num
        '
        Me.tb_meijie_num.Location = New System.Drawing.Point(664, 219)
        Me.tb_meijie_num.Name = "tb_meijie_num"
        Me.tb_meijie_num.Size = New System.Drawing.Size(39, 21)
        Me.tb_meijie_num.TabIndex = 111
        Me.tb_meijie_num.Visible = False
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(598, 223)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(41, 12)
        Me.Labelid.TabIndex = 109
        Me.Labelid.Text = "本表id"
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(527, 223)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(29, 12)
        Me.Labeltb.TabIndex = 108
        Me.Labeltb.Text = "本表"
        Me.Labeltb.Visible = False
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(446, 208)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 43)
        Me.SSSQX.TabIndex = 107
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(197, 208)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 43)
        Me.SSSQD.TabIndex = 106
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'tb_meijie_qcrq
        '
        Me.tb_meijie_qcrq.BackColor = System.Drawing.Color.White
        Me.tb_meijie_qcrq.Location = New System.Drawing.Point(128, 12)
        Me.tb_meijie_qcrq.Name = "tb_meijie_qcrq"
        Me.tb_meijie_qcrq.Size = New System.Drawing.Size(126, 21)
        Me.tb_meijie_qcrq.TabIndex = 117
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(42, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 116
        Me.Label16.Text = "取样时间"
        '
        'tb_meijie_zy
        '
        Me.tb_meijie_zy.Location = New System.Drawing.Point(128, 50)
        Me.tb_meijie_zy.Name = "tb_meijie_zy"
        Me.tb_meijie_zy.Size = New System.Drawing.Size(126, 21)
        Me.tb_meijie_zy.TabIndex = 158
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(66, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 157
        Me.Label14.Text = "总油"
        '
        'tb_meijie_sf
        '
        Me.tb_meijie_sf.Location = New System.Drawing.Point(356, 50)
        Me.tb_meijie_sf.Name = "tb_meijie_sf"
        Me.tb_meijie_sf.Size = New System.Drawing.Size(99, 21)
        Me.tb_meijie_sf.TabIndex = 156
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(321, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "水分"
        '
        'tb_meijie_jj
        '
        Me.tb_meijie_jj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_meijie_jj.FormattingEnabled = True
        Me.tb_meijie_jj.Items.AddRange(New Object() {"不破壁", "破壁"})
        Me.tb_meijie_jj.Location = New System.Drawing.Point(538, 50)
        Me.tb_meijie_jj.Name = "tb_meijie_jj"
        Me.tb_meijie_jj.Size = New System.Drawing.Size(126, 20)
        Me.tb_meijie_jj.TabIndex = 160
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(480, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "镜检"
        '
        'tb_meijie_jtzy
        '
        Me.tb_meijie_jtzy.Location = New System.Drawing.Point(119, 257)
        Me.tb_meijie_jtzy.Name = "tb_meijie_jtzy"
        Me.tb_meijie_jtzy.Size = New System.Drawing.Size(126, 21)
        Me.tb_meijie_jtzy.TabIndex = 158
        Me.tb_meijie_jtzy.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(45, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "浓缩菌体水分"
        '
        'tb_meijie_jtsf
        '
        Me.tb_meijie_jtsf.Location = New System.Drawing.Point(128, 86)
        Me.tb_meijie_jtsf.Name = "tb_meijie_jtsf"
        Me.tb_meijie_jtsf.Size = New System.Drawing.Size(99, 21)
        Me.tb_meijie_jtsf.TabIndex = 156
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(21, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "浓缩菌体总油"
        Me.Label6.Visible = False
        '
        'Frtb_meijieQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 274)
        Me.Controls.Add(Me.tb_meijie_qcrq)
        Me.Controls.Add(Me.tb_meijie_jj)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tb_meijie_jtsf)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_meijie_sf)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tb_meijie_qcbz)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_meijie_qcsh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_meijie_num)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.tb_meijie_jtzy)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.tb_meijie_zy)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_meijieQC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "酶解QC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_meijie_qcbz As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_qcsh As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_num As System.Windows.Forms.TextBox
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents tb_meijie_qcrq As chencontrol.chendatepick
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_zy As chencontrol.chentextzs
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_sf As chencontrol.chentextzs
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_jj As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_jtzy As chencontrol.chentextzs
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_meijie_jtsf As chencontrol.chentextzs
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
