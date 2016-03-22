<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frygpx2
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
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ToExcel = New System.Windows.Forms.Button
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 40)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(685, 330)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(265, 11)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 10
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(398, 11)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 214
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'frygpx2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 370)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.ListView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frygpx2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "培训结果查看"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents SSSQX As System.Windows.Forms.Button
End Class
