<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_hjwswbz
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Labelid = New System.Windows.Forms.Label
        Me.Labeltb = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.ButtonDel = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_hjwswbz_cj = New System.Windows.Forms.ComboBox
        Me.tb_hjwswbz_dd = New System.Windows.Forms.TextBox
        Me.tb_hjwswbz_jcmb = New System.Windows.Forms.TextBox
        Me.tb_hjwswbz_jcdx = New System.Windows.Forms.TextBox
        Me.tb_hjwswbz_biaozun = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_hjwswbz_rq = New System.Windows.Forms.DateTimePicker
        Me.tb_hjwswbz_bz = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(22, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "参照标准"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(269, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 12)
        Me.Label18.TabIndex = 115
        Me.Label18.Text = "地点"
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(64, 229)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 114
        Me.Labelid.Text = "Labelid"
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(64, 206)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 113
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(307, 218)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 112
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'ButtonDel
        '
        Me.ButtonDel.Location = New System.Drawing.Point(226, 218)
        Me.ButtonDel.Name = "ButtonDel"
        Me.ButtonDel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDel.TabIndex = 110
        Me.ButtonDel.Text = "删除"
        Me.ButtonDel.UseVisualStyleBackColor = True
        Me.ButtonDel.Visible = False
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(142, 218)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 111
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(245, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "检测对象"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(22, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "检测目标"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(46, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "车间"
        '
        'tb_hjwswbz_cj
        '
        Me.tb_hjwswbz_cj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_hjwswbz_cj.FormattingEnabled = True
        Me.tb_hjwswbz_cj.Items.AddRange(New Object() {"粉剂一", "粉剂二", "其它"})
        Me.tb_hjwswbz_cj.Location = New System.Drawing.Point(81, 13)
        Me.tb_hjwswbz_cj.Name = "tb_hjwswbz_cj"
        Me.tb_hjwswbz_cj.Size = New System.Drawing.Size(160, 20)
        Me.tb_hjwswbz_cj.TabIndex = 117
        '
        'tb_hjwswbz_dd
        '
        Me.tb_hjwswbz_dd.Location = New System.Drawing.Point(304, 13)
        Me.tb_hjwswbz_dd.Name = "tb_hjwswbz_dd"
        Me.tb_hjwswbz_dd.Size = New System.Drawing.Size(159, 21)
        Me.tb_hjwswbz_dd.TabIndex = 118
        '
        'tb_hjwswbz_jcmb
        '
        Me.tb_hjwswbz_jcmb.Location = New System.Drawing.Point(82, 54)
        Me.tb_hjwswbz_jcmb.Name = "tb_hjwswbz_jcmb"
        Me.tb_hjwswbz_jcmb.Size = New System.Drawing.Size(159, 21)
        Me.tb_hjwswbz_jcmb.TabIndex = 119
        '
        'tb_hjwswbz_jcdx
        '
        Me.tb_hjwswbz_jcdx.Location = New System.Drawing.Point(304, 54)
        Me.tb_hjwswbz_jcdx.Name = "tb_hjwswbz_jcdx"
        Me.tb_hjwswbz_jcdx.Size = New System.Drawing.Size(159, 21)
        Me.tb_hjwswbz_jcdx.TabIndex = 120
        '
        'tb_hjwswbz_biaozun
        '
        Me.tb_hjwswbz_biaozun.Location = New System.Drawing.Point(82, 97)
        Me.tb_hjwswbz_biaozun.Name = "tb_hjwswbz_biaozun"
        Me.tb_hjwswbz_biaozun.Size = New System.Drawing.Size(159, 21)
        Me.tb_hjwswbz_biaozun.TabIndex = 121
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(247, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "设定时间"
        '
        'tb_hjwswbz_rq
        '
        Me.tb_hjwswbz_rq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tb_hjwswbz_rq.Location = New System.Drawing.Point(306, 97)
        Me.tb_hjwswbz_rq.Name = "tb_hjwswbz_rq"
        Me.tb_hjwswbz_rq.Size = New System.Drawing.Size(155, 21)
        Me.tb_hjwswbz_rq.TabIndex = 124
        '
        'tb_hjwswbz_bz
        '
        Me.tb_hjwswbz_bz.Location = New System.Drawing.Point(81, 134)
        Me.tb_hjwswbz_bz.Multiline = True
        Me.tb_hjwswbz_bz.Name = "tb_hjwswbz_bz"
        Me.tb_hjwswbz_bz.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tb_hjwswbz_bz.Size = New System.Drawing.Size(382, 44)
        Me.tb_hjwswbz_bz.TabIndex = 126
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(41, 139)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 12)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "备注"
        '
        'Frtb_hjwswbz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 266)
        Me.Controls.Add(Me.tb_hjwswbz_bz)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.tb_hjwswbz_rq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_hjwswbz_biaozun)
        Me.Controls.Add(Me.tb_hjwswbz_jcdx)
        Me.Controls.Add(Me.tb_hjwswbz_jcmb)
        Me.Controls.Add(Me.tb_hjwswbz_dd)
        Me.Controls.Add(Me.tb_hjwswbz_cj)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.ButtonDel)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_hjwswbz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "环境微生物标准"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents ButtonDel As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_hjwswbz_cj As System.Windows.Forms.ComboBox
    Friend WithEvents tb_hjwswbz_dd As System.Windows.Forms.TextBox
    Friend WithEvents tb_hjwswbz_jcmb As System.Windows.Forms.TextBox
    Friend WithEvents tb_hjwswbz_jcdx As System.Windows.Forms.TextBox
    Friend WithEvents tb_hjwswbz_biaozun As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_hjwswbz_rq As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_hjwswbz_bz As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
