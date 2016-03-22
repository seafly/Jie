<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_jljh
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
        Me.tb_mypl_bz = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_mypl_a953t = New chencontrol.chendatepick()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Chentextzs2 = New chencontrol.chentextzs()
        Me.Chentextzs1 = New chencontrol.chentextzs()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.tb_mypl_bz)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tb_mypl_a953t)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Chentextzs2)
        Me.GroupBox1.Controls.Add(Me.Chentextzs1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1034, 77)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'tb_mypl_bz
        '
        Me.tb_mypl_bz.Location = New System.Drawing.Point(572, 50)
        Me.tb_mypl_bz.Name = "tb_mypl_bz"
        Me.tb_mypl_bz.Size = New System.Drawing.Size(126, 21)
        Me.tb_mypl_bz.TabIndex = 112
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(513, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "备注"
        '
        'tb_mypl_a953t
        '
        Me.tb_mypl_a953t.BackColor = System.Drawing.Color.White
        Me.tb_mypl_a953t.Location = New System.Drawing.Point(572, 20)
        Me.tb_mypl_a953t.Name = "tb_mypl_a953t"
        Me.tb_mypl_a953t.Size = New System.Drawing.Size(126, 21)
        Me.tb_mypl_a953t.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(489, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "计划生成日期"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(194, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "至"
        '
        'Button5
        '
        Me.Button5.AutoSize = True
        Me.Button5.Location = New System.Drawing.Point(760, 29)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 23)
        Me.Button5.TabIndex = 76
        Me.Button5.Text = "生成精炼计划"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(345, 30)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(76, 23)
        Me.Button4.TabIndex = 77
        Me.Button4.Text = "查询"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Chentextzs2
        '
        Me.Chentextzs2.Location = New System.Drawing.Point(233, 31)
        Me.Chentextzs2.Name = "Chentextzs2"
        Me.Chentextzs2.Size = New System.Drawing.Size(57, 21)
        Me.Chentextzs2.TabIndex = 74
        '
        'Chentextzs1
        '
        Me.Chentextzs1.Location = New System.Drawing.Point(122, 32)
        Me.Chentextzs1.Name = "Chentextzs1"
        Me.Chentextzs1.Size = New System.Drawing.Size(50, 21)
        Me.Chentextzs1.TabIndex = 73
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(21, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 12)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "毛油ARA/DHA含量"
        '
        'ListView2
        '
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(0, 83)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1031, 235)
        Me.ListView2.TabIndex = 39
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 324)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1031, 242)
        Me.ListView1.TabIndex = 40
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Fr_jljh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 578)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_jljh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "精炼计划"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_mypl_bz As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_mypl_a953t As chencontrol.chendatepick
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Chentextzs2 As chencontrol.chentextzs
    Friend WithEvents Chentextzs1 As chencontrol.chentextzs
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
End Class
