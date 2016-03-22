<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrQcXmsz
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.show1 = New System.Windows.Forms.DataGridView()
        Me.selBt = New System.Windows.Forms.Button()
        Me.selTb = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.show1)
        Me.GroupBox1.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 463)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "原料与包材"
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
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
        Me.show1.Size = New System.Drawing.Size(267, 443)
        Me.show1.TabIndex = 71
        '
        'selBt
        '
        Me.selBt.Location = New System.Drawing.Point(127, 4)
        Me.selBt.Name = "selBt"
        Me.selBt.Size = New System.Drawing.Size(75, 23)
        Me.selBt.TabIndex = 76
        Me.selBt.Text = "添加"
        Me.selBt.UseVisualStyleBackColor = True
        '
        'selTb
        '
        Me.selTb.Location = New System.Drawing.Point(21, 4)
        Me.selTb.Name = "selTb"
        Me.selTb.Size = New System.Drawing.Size(100, 21)
        Me.selTb.TabIndex = 75
        '
        'FrQcXmsz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 493)
        Me.Controls.Add(Me.selBt)
        Me.Controls.Add(Me.selTb)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrQcXmsz"
        Me.Text = "FrQcXmsz"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents selBt As System.Windows.Forms.Button
    Friend WithEvents selTb As System.Windows.Forms.TextBox
End Class
