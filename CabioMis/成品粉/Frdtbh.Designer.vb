<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frdtbh
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Buttonunload = New System.Windows.Forms.Button
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 54)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(339, 364)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(241, 12)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(72, 23)
        Me.Buttonunload.TabIndex = 56
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(116, 13)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 55
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(350, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 24)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "说明：北方办包含在剩余库存中；显示条件是QA结果不是报废" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "且剩余库存大于等于20的批次；""-""表示金粉"
        '
        'Frdtbh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 430)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Buttonunload)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Frdtbh"
        Me.Text = "成品粉备货情况即时表"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Buttonunload As System.Windows.Forms.Button
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
