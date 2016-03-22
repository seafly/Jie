<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSelHcCz
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.show2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.show1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        CType(Me.show2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.show2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(350, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(334, 462)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "原料与包材"
        '
        'show2
        '
        Me.show2.AllowUserToAddRows = False
        Me.show2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.show2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show2.Cursor = System.Windows.Forms.Cursors.Default
        Me.show2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.show2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show2.Location = New System.Drawing.Point(3, 17)
        Me.show2.MultiSelect = False
        Me.show2.Name = "show2"
        Me.show2.ReadOnly = True
        Me.show2.RowHeadersVisible = False
        Me.show2.RowTemplate.Height = 23
        Me.show2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show2.Size = New System.Drawing.Size(328, 442)
        Me.show2.TabIndex = 71
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.show1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 462)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "原料与包材"
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Cursor = System.Windows.Forms.Cursors.Default
        Me.show1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.show1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show1.Location = New System.Drawing.Point(3, 17)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowHeadersVisible = False
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(344, 442)
        Me.show1.TabIndex = 71
        '
        'FrSelHcCz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 462)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrSelHcCz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "物品合成操作"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.show2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents show2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
End Class
