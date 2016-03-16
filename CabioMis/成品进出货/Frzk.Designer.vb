<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frzk
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.zkzl = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cplb = New System.Windows.Forms.ComboBox()
        Me.jiagdm = New System.Windows.Forms.ComboBox()
        Me.mingc = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.storagewzlk = New yangNetCl.yanTextBox()
        Me.storagemslk = New yangNetCl.yanTextBox()
        Me.kdlk = New yangNetCl.yanTextBox()
        Me.bfb = New yangNetCl.yanTextBox()
        Me.YanDaTaGridView1 = New yangNetCl.yanDaTaGridView()
        CType(Me.YanDaTaGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(441, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "保存"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(200, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "转库重量"
        '
        'zkzl
        '
        Me.zkzl.Enabled = False
        Me.zkzl.Location = New System.Drawing.Point(263, 49)
        Me.zkzl.Name = "zkzl"
        Me.zkzl.Size = New System.Drawing.Size(100, 21)
        Me.zkzl.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(781, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 21)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "添加"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cplb
        '
        Me.cplb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cplb.Enabled = False
        Me.cplb.FormattingEnabled = True
        Me.cplb.Location = New System.Drawing.Point(85, 15)
        Me.cplb.Name = "cplb"
        Me.cplb.Size = New System.Drawing.Size(100, 20)
        Me.cplb.TabIndex = 60
        '
        'jiagdm
        '
        Me.jiagdm.FormattingEnabled = True
        Me.jiagdm.Location = New System.Drawing.Point(449, 12)
        Me.jiagdm.Name = "jiagdm"
        Me.jiagdm.Size = New System.Drawing.Size(100, 20)
        Me.jiagdm.TabIndex = 61
        '
        'mingc
        '
        Me.mingc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mingc.FormattingEnabled = True
        Me.mingc.Location = New System.Drawing.Point(263, 12)
        Me.mingc.Name = "mingc"
        Me.mingc.Size = New System.Drawing.Size(100, 20)
        Me.mingc.TabIndex = 62
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(27, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 12)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "产品类型"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(390, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "加工代码"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(204, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 12)
        Me.Label20.TabIndex = 59
        Me.Label20.Text = "产品代码"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(26, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(41, 12)
        Me.Label24.TabIndex = 51
        Me.Label24.Text = "北方办"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(204, 90)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 12)
        Me.Label23.TabIndex = 50
        Me.Label23.Text = "葛店冷库"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(390, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 12)
        Me.Label22.TabIndex = 49
        Me.Label22.Text = "庙山冷库"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(567, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "外租冷库"
        '
        'storagewzlk
        '
        Me.storagewzlk.Enabled = False
        Me.storagewzlk.Location = New System.Drawing.Point(626, 85)
        Me.storagewzlk.Name = "storagewzlk"
        Me.storagewzlk.Size = New System.Drawing.Size(100, 21)
        Me.storagewzlk.TabIndex = 52
        Me.storagewzlk.Text = "0"
        '
        'storagemslk
        '
        Me.storagemslk.Location = New System.Drawing.Point(449, 84)
        Me.storagemslk.Name = "storagemslk"
        Me.storagemslk.Size = New System.Drawing.Size(100, 21)
        Me.storagemslk.TabIndex = 53
        Me.storagemslk.Text = "0"
        '
        'kdlk
        '
        Me.kdlk.Enabled = False
        Me.kdlk.Location = New System.Drawing.Point(263, 85)
        Me.kdlk.Name = "kdlk"
        Me.kdlk.Size = New System.Drawing.Size(100, 21)
        Me.kdlk.TabIndex = 54
        Me.kdlk.Text = "0"
        '
        'bfb
        '
        Me.bfb.Location = New System.Drawing.Point(85, 85)
        Me.bfb.Name = "bfb"
        Me.bfb.Size = New System.Drawing.Size(100, 21)
        Me.bfb.TabIndex = 55
        Me.bfb.Text = "0"
        '
        'YanDaTaGridView1
        '
        Me.YanDaTaGridView1.AllowUserToAddRows = False
        Me.YanDaTaGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.YanDaTaGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.YanDaTaGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.YanDaTaGridView1.Location = New System.Drawing.Point(3, 124)
        Me.YanDaTaGridView1.Name = "YanDaTaGridView1"
        Me.YanDaTaGridView1.ReadOnly = True
        Me.YanDaTaGridView1.RowTemplate.Height = 23
        Me.YanDaTaGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.YanDaTaGridView1.Size = New System.Drawing.Size(858, 238)
        Me.YanDaTaGridView1.TabIndex = 0
        '
        'Frzk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 400)
        Me.Controls.Add(Me.cplb)
        Me.Controls.Add(Me.jiagdm)
        Me.Controls.Add(Me.mingc)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.storagewzlk)
        Me.Controls.Add(Me.storagemslk)
        Me.Controls.Add(Me.kdlk)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.bfb)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.zkzl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.YanDaTaGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frzk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "转库湖北"
        CType(Me.YanDaTaGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents YanDaTaGridView1 As yangNetCl.yanDaTaGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents zkzl As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cplb As System.Windows.Forms.ComboBox
    Friend WithEvents jiagdm As System.Windows.Forms.ComboBox
    Friend WithEvents mingc As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents storagewzlk As yangNetCl.yanTextBox
    Friend WithEvents storagemslk As yangNetCl.yanTextBox
    Friend WithEvents kdlk As yangNetCl.yanTextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents bfb As yangNetCl.yanTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
