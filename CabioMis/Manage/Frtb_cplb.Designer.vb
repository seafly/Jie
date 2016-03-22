<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_cplb
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.YanDaTaGridView1 = New yangNetCl.yanDaTaGridView()
        Me.tb_cplb_p512h = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tb_cplb_isShow = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.YanDaTaGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.YanDaTaGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 376)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "列表（双击删除）"
        '
        'YanDaTaGridView1
        '
        Me.YanDaTaGridView1.AllowUserToAddRows = False
        Me.YanDaTaGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.YanDaTaGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.YanDaTaGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tb_cplb_p512h, Me.tb_cplb_isShow})
        Me.YanDaTaGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YanDaTaGridView1.Location = New System.Drawing.Point(3, 17)
        Me.YanDaTaGridView1.Name = "YanDaTaGridView1"
        Me.YanDaTaGridView1.ReadOnly = True
        Me.YanDaTaGridView1.RowTemplate.Height = 23
        Me.YanDaTaGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.YanDaTaGridView1.Size = New System.Drawing.Size(481, 356)
        Me.YanDaTaGridView1.TabIndex = 0
        '
        'tb_cplb_p512h
        '
        Me.tb_cplb_p512h.HeaderText = "产品类别"
        Me.tb_cplb_p512h.Name = "tb_cplb_p512h"
        Me.tb_cplb_p512h.ReadOnly = True
        Me.tb_cplb_p512h.Width = 200
        '
        'tb_cplb_isShow
        '
        Me.tb_cplb_isShow.HeaderText = "是否显示"
        Me.tb_cplb_isShow.Name = "tb_cplb_isShow"
        Me.tb_cplb_isShow.ReadOnly = True
        Me.tb_cplb_isShow.Width = 200
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(254, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(173, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "添加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(57, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(22, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "名称"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(424, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "保存"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Frtb_cplb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 448)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_cplb"
        Me.Text = "产品类别-Frtb_cplb"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.YanDaTaGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents YanDaTaGridView1 As yangNetCl.yanDaTaGridView
    Friend WithEvents tb_cplb_p512h As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tb_cplb_isShow As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
