<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fraqjczgqk
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.nian = New System.Windows.Forms.ComboBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ToExcel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(43, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "请选择统计年："
        '
        'nian
        '
        Me.nian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian.FormattingEnabled = True
        Me.nian.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian.Location = New System.Drawing.Point(138, 16)
        Me.nian.Name = "nian"
        Me.nian.Size = New System.Drawing.Size(72, 20)
        Me.nian.TabIndex = 4
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 56)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(756, 449)
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(257, 14)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 7
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'fraqjczgqk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 504)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nian)
        Me.Name = "fraqjczgqk"
        Me.Text = "EHS整改情况统计"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nian As System.Windows.Forms.ComboBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ToExcel As System.Windows.Forms.Button
End Class
