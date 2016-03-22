<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrVb
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
        Me.showl = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.showl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'showl
        '
        Me.showl.AllowUserToAddRows = False
        Me.showl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.showl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.showl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal
        Me.showl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.showl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.showl.Location = New System.Drawing.Point(30, 58)
        Me.showl.MultiSelect = False
        Me.showl.Name = "showl"
        Me.showl.ReadOnly = True
        Me.showl.RowHeadersVisible = False
        Me.showl.RowTemplate.Height = 23
        Me.showl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect
        Me.showl.Size = New System.Drawing.Size(529, 226)
        Me.showl.TabIndex = 47
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(142, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 49
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrVb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 306)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.showl)
        Me.Name = "FrVb"
        Me.Text = "FrVb"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        CType(Me.showl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents showl As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
