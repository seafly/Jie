<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_wsjcjl
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
        Me.tb_wsjcjl_rq = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.Labeltb = New System.Windows.Forms.Label()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SSSQD = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_yplx = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_phz = New chencontrol.chentextintz()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_cod = New chencontrol.chentextintz()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_ad = New chencontrol.chentextintz()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_zl = New chencontrol.chentextintz()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_cz = New System.Windows.Forms.TextBox()
        Me.tb_wsjcjl_cod2 = New chencontrol.chentextintz()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_xfgt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_wsjcjl_bz = New chencontrol.chentextintz()
        Me.SuspendLayout()
        '
        'tb_wsjcjl_rq
        '
        Me.tb_wsjcjl_rq.Location = New System.Drawing.Point(83, 13)
        Me.tb_wsjcjl_rq.Name = "tb_wsjcjl_rq"
        Me.tb_wsjcjl_rq.Size = New System.Drawing.Size(137, 21)
        Me.tb_wsjcjl_rq.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(22, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "取样时间"
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(189, 139)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 32
        Me.Labelid.Text = "Labelid"
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(120, 139)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 31
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(434, 134)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 32)
        Me.SSSQX.TabIndex = 30
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(341, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 32)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "删除"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(257, 134)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 32)
        Me.SSSQD.TabIndex = 29
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(232, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "样品类别"
        '
        'tb_wsjcjl_yplx
        '
        Me.tb_wsjcjl_yplx.Location = New System.Drawing.Point(291, 13)
        Me.tb_wsjcjl_yplx.Name = "tb_wsjcjl_yplx"
        Me.tb_wsjcjl_yplx.Size = New System.Drawing.Size(115, 21)
        Me.tb_wsjcjl_yplx.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(417, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "PH值"
        '
        'tb_wsjcjl_phz
        '
        Me.tb_wsjcjl_phz.Location = New System.Drawing.Point(452, 13)
        Me.tb_wsjcjl_phz.Name = "tb_wsjcjl_phz"
        Me.tb_wsjcjl_phz.Size = New System.Drawing.Size(58, 21)
        Me.tb_wsjcjl_phz.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(22, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "COD(1)"
        '
        'tb_wsjcjl_cod
        '
        Me.tb_wsjcjl_cod.Location = New System.Drawing.Point(83, 54)
        Me.tb_wsjcjl_cod.Name = "tb_wsjcjl_cod"
        Me.tb_wsjcjl_cod.Size = New System.Drawing.Size(137, 21)
        Me.tb_wsjcjl_cod.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(245, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "氨氮"
        '
        'tb_wsjcjl_ad
        '
        Me.tb_wsjcjl_ad.Location = New System.Drawing.Point(291, 54)
        Me.tb_wsjcjl_ad.Name = "tb_wsjcjl_ad"
        Me.tb_wsjcjl_ad.Size = New System.Drawing.Size(115, 21)
        Me.tb_wsjcjl_ad.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(417, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "总磷"
        '
        'tb_wsjcjl_zl
        '
        Me.tb_wsjcjl_zl.Location = New System.Drawing.Point(452, 54)
        Me.tb_wsjcjl_zl.Name = "tb_wsjcjl_zl"
        Me.tb_wsjcjl_zl.Size = New System.Drawing.Size(58, 21)
        Me.tb_wsjcjl_zl.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(516, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "悬浮固体"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(526, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "操作"
        '
        'tb_wsjcjl_cz
        '
        Me.tb_wsjcjl_cz.Location = New System.Drawing.Point(575, 49)
        Me.tb_wsjcjl_cz.Name = "tb_wsjcjl_cz"
        Me.tb_wsjcjl_cz.Size = New System.Drawing.Size(103, 21)
        Me.tb_wsjcjl_cz.TabIndex = 33
        '
        'tb_wsjcjl_cod2
        '
        Me.tb_wsjcjl_cod2.Location = New System.Drawing.Point(83, 85)
        Me.tb_wsjcjl_cod2.Name = "tb_wsjcjl_cod2"
        Me.tb_wsjcjl_cod2.Size = New System.Drawing.Size(137, 21)
        Me.tb_wsjcjl_cod2.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(22, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "COD(2)"
        '
        'tb_wsjcjl_xfgt
        '
        Me.tb_wsjcjl_xfgt.Location = New System.Drawing.Point(575, 16)
        Me.tb_wsjcjl_xfgt.Name = "tb_wsjcjl_xfgt"
        Me.tb_wsjcjl_xfgt.Size = New System.Drawing.Size(103, 21)
        Me.tb_wsjcjl_xfgt.TabIndex = 38
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(245, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "备注"
        '
        'tb_wsjcjl_bz
        '
        Me.tb_wsjcjl_bz.Location = New System.Drawing.Point(291, 89)
        Me.tb_wsjcjl_bz.Name = "tb_wsjcjl_bz"
        Me.tb_wsjcjl_bz.Size = New System.Drawing.Size(316, 21)
        Me.tb_wsjcjl_bz.TabIndex = 40
        '
        'Frtb_wsjcjl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 183)
        Me.Controls.Add(Me.tb_wsjcjl_bz)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tb_wsjcjl_xfgt)
        Me.Controls.Add(Me.tb_wsjcjl_cod2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tb_wsjcjl_ad)
        Me.Controls.Add(Me.tb_wsjcjl_cod)
        Me.Controls.Add(Me.tb_wsjcjl_zl)
        Me.Controls.Add(Me.tb_wsjcjl_phz)
        Me.Controls.Add(Me.tb_wsjcjl_cz)
        Me.Controls.Add(Me.tb_wsjcjl_yplx)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_wsjcjl_rq)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_wsjcjl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "污水检测记录"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_wsjcjl_rq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_yplx As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_phz As chencontrol.chentextintz
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_cod As chencontrol.chentextintz
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_ad As chencontrol.chentextintz
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_zl As chencontrol.chentextintz
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_cz As System.Windows.Forms.TextBox
    Friend WithEvents tb_wsjcjl_cod2 As chencontrol.chentextintz
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_xfgt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_wsjcjl_bz As chencontrol.chentextintz
End Class
