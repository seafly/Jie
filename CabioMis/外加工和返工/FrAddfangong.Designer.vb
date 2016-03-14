<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAddfangong
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tb_fangong_bs2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_fangong_bs2t = New System.Windows.Forms.TextBox()
        Me.tb_fangong_tbname = New System.Windows.Forms.TextBox()
        Me.tb_fangong_syzl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_fangong_bz = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(174, 193)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_fangong_bs2
        '
        Me.tb_fangong_bs2.Location = New System.Drawing.Point(97, 25)
        Me.tb_fangong_bs2.Name = "tb_fangong_bs2"
        Me.tb_fangong_bs2.ReadOnly = True
        Me.tb_fangong_bs2.Size = New System.Drawing.Size(100, 21)
        Me.tb_fangong_bs2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "成品标识"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "对应重量"
        '
        'tb_fangong_bs2t
        '
        Me.tb_fangong_bs2t.Location = New System.Drawing.Point(281, 25)
        Me.tb_fangong_bs2t.Name = "tb_fangong_bs2t"
        Me.tb_fangong_bs2t.ReadOnly = True
        Me.tb_fangong_bs2t.Size = New System.Drawing.Size(100, 21)
        Me.tb_fangong_bs2t.TabIndex = 3
        '
        'tb_fangong_tbname
        '
        Me.tb_fangong_tbname.Location = New System.Drawing.Point(2, 201)
        Me.tb_fangong_tbname.Name = "tb_fangong_tbname"
        Me.tb_fangong_tbname.Size = New System.Drawing.Size(49, 21)
        Me.tb_fangong_tbname.TabIndex = 9
        Me.tb_fangong_tbname.Text = "提取表"
        Me.tb_fangong_tbname.Visible = False
        '
        'tb_fangong_syzl
        '
        Me.tb_fangong_syzl.Location = New System.Drawing.Point(57, 201)
        Me.tb_fangong_syzl.Name = "tb_fangong_syzl"
        Me.tb_fangong_syzl.Size = New System.Drawing.Size(54, 21)
        Me.tb_fangong_syzl.TabIndex = 9
        Me.tb_fangong_syzl.Text = "剩余重量"
        Me.tb_fangong_syzl.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "备注"
        '
        'tb_fangong_bz
        '
        Me.tb_fangong_bz.Location = New System.Drawing.Point(97, 113)
        Me.tb_fangong_bz.Multiline = True
        Me.tb_fangong_bz.Name = "tb_fangong_bz"
        Me.tb_fangong_bz.Size = New System.Drawing.Size(284, 54)
        Me.tb_fangong_bz.TabIndex = 5
        '
        'FrAddfangong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 228)
        Me.Controls.Add(Me.tb_fangong_syzl)
        Me.Controls.Add(Me.tb_fangong_tbname)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_fangong_bz)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_fangong_bs2t)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_fangong_bs2)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrAddfangong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrAddfangong"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_fangong_bs2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_fangong_bs2t As System.Windows.Forms.TextBox
    Friend WithEvents tb_fangong_tbname As System.Windows.Forms.TextBox
    Friend WithEvents tb_fangong_syzl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_fangong_bz As System.Windows.Forms.TextBox
End Class
