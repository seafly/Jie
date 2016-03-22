<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frfjxp_qa
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
        Me.Labelid = New System.Windows.Forms.Label
        Me.Labeltb = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(734, 466)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(35, 0)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(11, 12)
        Me.Labelid.TabIndex = 1
        Me.Labelid.Text = " "
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(88, 0)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 1
        Me.Labeltb.Text = "Labelid"
        Me.Labeltb.Visible = False
        '
        'Frfjxp_qa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 466)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "Frfjxp_qa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QA小批"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
End Class
