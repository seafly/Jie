<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrXmSjsz
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
        Me.tb_QcXm_lx = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb_QcXm_lx
        '
        Me.tb_QcXm_lx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_QcXm_lx.FormattingEnabled = True
        Me.tb_QcXm_lx.Items.AddRange(New Object() {"数字", "文本", "选择"})
        Me.tb_QcXm_lx.Location = New System.Drawing.Point(104, 45)
        Me.tb_QcXm_lx.Name = "tb_QcXm_lx"
        Me.tb_QcXm_lx.Size = New System.Drawing.Size(121, 20)
        Me.tb_QcXm_lx.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(34, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "类型"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(104, 229)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrXmSjsz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 275)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_QcXm_lx)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrXmSjsz"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrXmSjsz-FrXmSjsz"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tb_QcXm_lx As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
