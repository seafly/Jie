<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frjsb_YFXMGL_ADD
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
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.tb_jyfxm_mc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tb_jyfxm_rq = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(301, 217)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 73
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(136, 217)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 72
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'tb_jyfxm_mc
        '
        Me.tb_jyfxm_mc.Location = New System.Drawing.Point(215, 36)
        Me.tb_jyfxm_mc.Name = "tb_jyfxm_mc"
        Me.tb_jyfxm_mc.Size = New System.Drawing.Size(154, 21)
        Me.tb_jyfxm_mc.TabIndex = 75
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(134, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "创建时间"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(134, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "项目名称"
        '
        'tb_jyfxm_rq
        '
        Me.tb_jyfxm_rq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tb_jyfxm_rq.Location = New System.Drawing.Point(215, 115)
        Me.tb_jyfxm_rq.Name = "tb_jyfxm_rq"
        Me.tb_jyfxm_rq.Size = New System.Drawing.Size(154, 21)
        Me.tb_jyfxm_rq.TabIndex = 109
        '
        'Frjsb_YFXMGL_ADD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 266)
        Me.Controls.Add(Me.tb_jyfxm_rq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_jyfxm_mc)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frjsb_YFXMGL_ADD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "增加新项目"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents tb_jyfxm_mc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_jyfxm_rq As System.Windows.Forms.DateTimePicker
End Class
