<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frnhYearJG
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.sui = New chencontrol.chentextzs
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dian = New chencontrol.chentextzs
        Me.qi = New chencontrol.chentextzs
        Me.caiyou = New chencontrol.chentextzs
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.trq = New chencontrol.chentextzs
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(51, 271)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(43, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "请选择年份："
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian1.Location = New System.Drawing.Point(133, 13)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(72, 20)
        Me.nian1.TabIndex = 5
        '
        'sui
        '
        Me.sui.Location = New System.Drawing.Point(133, 51)
        Me.sui.Name = "sui"
        Me.sui.Size = New System.Drawing.Size(105, 21)
        Me.sui.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(49, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Water(mt)："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(49, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Electricity" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Kwh)："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(49, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Steam(mt)："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(49, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Diesel(L)："
        '
        'dian
        '
        Me.dian.Location = New System.Drawing.Point(133, 99)
        Me.dian.Name = "dian"
        Me.dian.Size = New System.Drawing.Size(105, 21)
        Me.dian.TabIndex = 11
        '
        'qi
        '
        Me.qi.Location = New System.Drawing.Point(133, 141)
        Me.qi.Name = "qi"
        Me.qi.Size = New System.Drawing.Size(105, 21)
        Me.qi.TabIndex = 11
        '
        'caiyou
        '
        Me.caiyou.Location = New System.Drawing.Point(133, 180)
        Me.caiyou.Name = "caiyou"
        Me.caiyou.Size = New System.Drawing.Size(105, 21)
        Me.caiyou.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(157, 271)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "关闭"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(19, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Natural gas (M3)："
        '
        'trq
        '
        Me.trq.Location = New System.Drawing.Point(133, 223)
        Me.trq.Name = "trq"
        Me.trq.Size = New System.Drawing.Size(105, 21)
        Me.trq.TabIndex = 13
        '
        'frnhYearJG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 325)
        Me.Controls.Add(Me.trq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.caiyou)
        Me.Controls.Add(Me.qi)
        Me.Controls.Add(Me.dian)
        Me.Controls.Add(Me.sui)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nian1)
        Me.MaximizeBox = False
        Me.Name = "frnhYearJG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "单价"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Friend WithEvents sui As chencontrol.chentextzs
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dian As chencontrol.chentextzs
    Friend WithEvents qi As chencontrol.chentextzs
    Friend WithEvents caiyou As chencontrol.chentextzs
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents trq As chencontrol.chentextzs
End Class
