<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_k3cpykc
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
        Me.Gold = New chencontrol.chentextzs
        Me.Power = New chencontrol.chentextzs
        Me.Finish = New chencontrol.chentextzs
        Me.Crude = New chencontrol.chentextzs
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Power1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.rq = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.zf = New chencontrol.chentextzs
        Me.Labelid = New System.Windows.Forms.Label
        Me.Labeltb = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Gold
        '
        Me.Gold.Location = New System.Drawing.Point(138, 201)
        Me.Gold.Name = "Gold"
        Me.Gold.Size = New System.Drawing.Size(105, 21)
        Me.Gold.TabIndex = 21
        '
        'Power
        '
        Me.Power.Location = New System.Drawing.Point(138, 150)
        Me.Power.Name = "Power"
        Me.Power.Size = New System.Drawing.Size(105, 21)
        Me.Power.TabIndex = 20
        '
        'Finish
        '
        Me.Finish.Location = New System.Drawing.Point(138, 106)
        Me.Finish.Name = "Finish"
        Me.Finish.Size = New System.Drawing.Size(105, 21)
        Me.Finish.TabIndex = 23
        '
        'Crude
        '
        Me.Crude.Location = New System.Drawing.Point(138, 67)
        Me.Crude.Name = "Crude"
        Me.Crude.Size = New System.Drawing.Size(105, 21)
        Me.Crude.TabIndex = 22
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(168, 283)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "关闭"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 283)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(54, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Gold AA(kg)："
        '
        'Power1
        '
        Me.Power1.AutoSize = True
        Me.Power1.BackColor = System.Drawing.Color.Transparent
        Me.Power1.Location = New System.Drawing.Point(54, 159)
        Me.Power1.Name = "Power1"
        Me.Power1.Size = New System.Drawing.Size(71, 12)
        Me.Power1.TabIndex = 13
        Me.Power1.Text = "Power(kg)："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(54, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Finish Oil："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(54, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Crude oil："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(54, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "选择时间："
        '
        'rq
        '
        Me.rq.Location = New System.Drawing.Point(138, 24)
        Me.rq.Name = "rq"
        Me.rq.Size = New System.Drawing.Size(176, 21)
        Me.rq.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(54, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "5S月度总分:"
        '
        'zf
        '
        Me.zf.Location = New System.Drawing.Point(138, 234)
        Me.zf.Name = "zf"
        Me.zf.Size = New System.Drawing.Size(105, 21)
        Me.zf.TabIndex = 26
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(313, 187)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 92
        Me.Labelid.Text = "Labelid"
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(313, 150)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 91
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        'Frtb_k3cpykc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 318)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.zf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rq)
        Me.Controls.Add(Me.Gold)
        Me.Controls.Add(Me.Power)
        Me.Controls.Add(Me.Finish)
        Me.Controls.Add(Me.Crude)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Power1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_k3cpykc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "K3 成品月库存及5S总分"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Gold As chencontrol.chentextzs
    Friend WithEvents Power As chencontrol.chentextzs
    Friend WithEvents Finish As chencontrol.chentextzs
    Friend WithEvents Crude As chencontrol.chentextzs
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Power1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents zf As chencontrol.chentextzs
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
End Class
