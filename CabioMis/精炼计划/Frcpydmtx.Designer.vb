<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frcpydmtx
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
        Me.tb_mypl_bz = New System.Windows.Forms.TextBox()
        Me.tb_mypl_a953t = New chencontrol.chendatepick()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.jiagdm = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cpdm = New System.Windows.Forms.ComboBox()
        Me.cplx = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'tb_mypl_bz
        '
        Me.tb_mypl_bz.Location = New System.Drawing.Point(151, 160)
        Me.tb_mypl_bz.Name = "tb_mypl_bz"
        Me.tb_mypl_bz.Size = New System.Drawing.Size(28, 21)
        Me.tb_mypl_bz.TabIndex = 266
        Me.tb_mypl_bz.Visible = False
        '
        'tb_mypl_a953t
        '
        Me.tb_mypl_a953t.BackColor = System.Drawing.Color.White
        Me.tb_mypl_a953t.Location = New System.Drawing.Point(12, 160)
        Me.tb_mypl_a953t.Name = "tb_mypl_a953t"
        Me.tb_mypl_a953t.Size = New System.Drawing.Size(133, 21)
        Me.tb_mypl_a953t.TabIndex = 265
        Me.tb_mypl_a953t.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(140, 123)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 31)
        Me.Button2.TabIndex = 263
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 122)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 264
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'jiagdm
        '
        Me.jiagdm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.jiagdm.FormattingEnabled = True
        Me.jiagdm.Location = New System.Drawing.Point(140, 90)
        Me.jiagdm.Name = "jiagdm"
        Me.jiagdm.Size = New System.Drawing.Size(110, 20)
        Me.jiagdm.TabIndex = 262
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.Location = New System.Drawing.Point(27, 90)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(92, 17)
        Me.Label24.TabIndex = 261
        Me.Label24.Text = "成品油加工代码"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.Location = New System.Drawing.Point(27, 59)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(92, 17)
        Me.Label25.TabIndex = 260
        Me.Label25.Text = "成品油产品代码"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label26.Location = New System.Drawing.Point(27, 22)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 17)
        Me.Label26.TabIndex = 259
        Me.Label26.Text = "成品油产品类型"
        '
        'cpdm
        '
        Me.cpdm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cpdm.FormattingEnabled = True
        Me.cpdm.Location = New System.Drawing.Point(139, 59)
        Me.cpdm.Name = "cpdm"
        Me.cpdm.Size = New System.Drawing.Size(110, 20)
        Me.cpdm.TabIndex = 258
        '
        'cplx
        '
        Me.cplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cplx.FormattingEnabled = True
        Me.cplx.Location = New System.Drawing.Point(139, 19)
        Me.cplx.Name = "cplx"
        Me.cplx.Size = New System.Drawing.Size(110, 20)
        Me.cplx.TabIndex = 257
        '
        'Frcpydmtx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 193)
        Me.Controls.Add(Me.tb_mypl_bz)
        Me.Controls.Add(Me.tb_mypl_a953t)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.jiagdm)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cpdm)
        Me.Controls.Add(Me.cplx)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frcpydmtx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "提示"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_mypl_bz As System.Windows.Forms.TextBox
    Friend WithEvents tb_mypl_a953t As chencontrol.chendatepick
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents jiagdm As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cpdm As System.Windows.Forms.ComboBox
    Friend WithEvents cplx As System.Windows.Forms.ComboBox
End Class
