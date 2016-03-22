<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frchaph
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
        Me.gongxu = New System.Windows.Forms.ComboBox
        Me.cxph = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBoxdcxz = New System.Windows.Forms.CheckedListBox
        Me.pp = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'gongxu
        '
        Me.gongxu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.gongxu.FormattingEnabled = True
        Me.gongxu.Items.AddRange(New Object() {"预制种子罐罐", "一级罐", "二级罐", "发酵罐", "放罐烘干", "毛油", "毛油配料", "精炼", "成品油", "粉剂配料", "配料批", "粉剂小批", "成品粉", "成品粉零头"})
        Me.gongxu.Location = New System.Drawing.Point(50, 7)
        Me.gongxu.Name = "gongxu"
        Me.gongxu.Size = New System.Drawing.Size(100, 20)
        Me.gongxu.TabIndex = 0
        '
        'cxph
        '
        Me.cxph.Location = New System.Drawing.Point(221, 6)
        Me.cxph.Name = "cxph"
        Me.cxph.Size = New System.Drawing.Size(139, 21)
        Me.cxph.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(376, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "工序："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(174, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "批号："
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(475, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "原料综合查询"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(606, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "混批成品粉查询"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(244, 61)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 36
        Me.Button6.Text = "生成文件"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "导出选择"
        '
        'ComboBoxdcxz
        '
        Me.ComboBoxdcxz.FormattingEnabled = True
        Me.ComboBoxdcxz.Location = New System.Drawing.Point(89, 37)
        Me.ComboBoxdcxz.Name = "ComboBoxdcxz"
        Me.ComboBoxdcxz.Size = New System.Drawing.Size(139, 68)
        Me.ComboBoxdcxz.TabIndex = 49
        '
        'pp
        '
        Me.pp.AutoScroll = True
        Me.pp.BackColor = System.Drawing.Color.Transparent
        Me.pp.Location = New System.Drawing.Point(5, 120)
        Me.pp.Name = "pp"
        Me.pp.Size = New System.Drawing.Size(866, 358)
        Me.pp.TabIndex = 50
        '
        'frchaph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(883, 490)
        Me.Controls.Add(Me.pp)
        Me.Controls.Add(Me.ComboBoxdcxz)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cxph)
        Me.Controls.Add(Me.gongxu)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frchaph"
        Me.Text = "查询"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gongxu As System.Windows.Forms.ComboBox
    Friend WithEvents cxph As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxdcxz As System.Windows.Forms.CheckedListBox
    Friend WithEvents pp As System.Windows.Forms.Panel
End Class
