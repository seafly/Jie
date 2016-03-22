<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSelSz
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.selBt = New System.Windows.Forms.Button()
        Me.selTb = New System.Windows.Forms.TextBox()
        Me.selCb = New System.Windows.Forms.ComboBox()
        Me.show1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.show2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.show2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.selBt)
        Me.GroupBox1.Controls.Add(Me.selTb)
        Me.GroupBox1.Controls.Add(Me.selCb)
        Me.GroupBox1.Controls.Add(Me.show1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(628, 400)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "物品列表"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(254, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "物品分类"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(310, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 112
        '
        'selBt
        '
        Me.selBt.Location = New System.Drawing.Point(437, 19)
        Me.selBt.Name = "selBt"
        Me.selBt.Size = New System.Drawing.Size(75, 23)
        Me.selBt.TabIndex = 74
        Me.selBt.Text = "查询"
        Me.selBt.UseVisualStyleBackColor = True
        '
        'selTb
        '
        Me.selTb.Location = New System.Drawing.Point(140, 20)
        Me.selTb.Name = "selTb"
        Me.selTb.Size = New System.Drawing.Size(100, 21)
        Me.selTb.TabIndex = 73
        '
        'selCb
        '
        Me.selCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selCb.FormattingEnabled = True
        Me.selCb.Location = New System.Drawing.Point(13, 21)
        Me.selCb.Name = "selCb"
        Me.selCb.Size = New System.Drawing.Size(121, 20)
        Me.selCb.TabIndex = 72
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Cursor = System.Windows.Forms.Cursors.Default
        Me.show1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show1.Location = New System.Drawing.Point(3, 50)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowHeadersVisible = False
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(625, 347)
        Me.show1.TabIndex = 71
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.show2)
        Me.GroupBox2.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(634, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(238, 385)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "原料与包材"
        '
        'show2
        '
        Me.show2.AllowUserToAddRows = False
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
        Me.show2.Size = New System.Drawing.Size(232, 365)
        Me.show2.TabIndex = 71
        '
        'FrSelSz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 400)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrSelSz"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "选择设置"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.show2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents show2 As System.Windows.Forms.DataGridView
    Friend WithEvents selBt As System.Windows.Forms.Button
    Friend WithEvents selTb As System.Windows.Forms.TextBox
    Friend WithEvents selCb As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
