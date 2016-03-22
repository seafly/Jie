<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frMOCss
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
        Me.nian = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToExcel = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'nian
        '
        Me.nian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian.FormattingEnabled = True
        Me.nian.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian.Location = New System.Drawing.Point(130, 23)
        Me.nian.Name = "nian"
        Me.nian.Size = New System.Drawing.Size(72, 20)
        Me.nian.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(35, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "请选择统计年："
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(245, 23)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 8
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 58)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(714, 395)
        Me.ListView1.TabIndex = 9
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'frMOCss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 453)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nian)
        Me.Name = "frMOCss"
        Me.Text = "MOC实施统计"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nian As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
End Class
