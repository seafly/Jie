<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frryAdd
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
        Me.tb_yg_v753n = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.tb_yg_n430f = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_yg_w779o = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tb_yg_bmgd = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tb_yg_m381e = New System.Windows.Forms.ComboBox
        Me.tb_yg_zt = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'tb_yg_v753n
        '
        Me.tb_yg_v753n.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yg_v753n.FormattingEnabled = True
        Me.tb_yg_v753n.Location = New System.Drawing.Point(207, 64)
        Me.tb_yg_v753n.Name = "tb_yg_v753n"
        Me.tb_yg_v753n.Size = New System.Drawing.Size(100, 20)
        Me.tb_yg_v753n.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(172, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "部门"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(266, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "关闭"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(141, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_yg_n430f
        '
        Me.tb_yg_n430f.Location = New System.Drawing.Point(54, 63)
        Me.tb_yg_n430f.Name = "tb_yg_n430f"
        Me.tb_yg_n430f.Size = New System.Drawing.Size(86, 21)
        Me.tb_yg_n430f.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(24, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "工号"
        '
        'tb_yg_w779o
        '
        Me.tb_yg_w779o.Location = New System.Drawing.Point(54, 27)
        Me.tb_yg_w779o.Name = "tb_yg_w779o"
        Me.tb_yg_w779o.Size = New System.Drawing.Size(86, 21)
        Me.tb_yg_w779o.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(24, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "姓名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(331, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "工段"
        '
        'tb_yg_bmgd
        '
        Me.tb_yg_bmgd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yg_bmgd.FormattingEnabled = True
        Me.tb_yg_bmgd.Location = New System.Drawing.Point(363, 64)
        Me.tb_yg_bmgd.Name = "tb_yg_bmgd"
        Me.tb_yg_bmgd.Size = New System.Drawing.Size(104, 20)
        Me.tb_yg_bmgd.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(175, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "性别"
        '
        'tb_yg_m381e
        '
        Me.tb_yg_m381e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yg_m381e.FormattingEnabled = True
        Me.tb_yg_m381e.Items.AddRange(New Object() {"男", "女"})
        Me.tb_yg_m381e.Location = New System.Drawing.Point(207, 27)
        Me.tb_yg_m381e.Name = "tb_yg_m381e"
        Me.tb_yg_m381e.Size = New System.Drawing.Size(46, 20)
        Me.tb_yg_m381e.TabIndex = 11
        '
        'tb_yg_zt
        '
        Me.tb_yg_zt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_yg_zt.FormattingEnabled = True
        Me.tb_yg_zt.Items.AddRange(New Object() {"正常", "注销"})
        Me.tb_yg_zt.Location = New System.Drawing.Point(366, 28)
        Me.tb_yg_zt.Name = "tb_yg_zt"
        Me.tb_yg_zt.Size = New System.Drawing.Size(101, 20)
        Me.tb_yg_zt.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(328, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "状态"
        '
        'frryAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(527, 171)
        Me.Controls.Add(Me.tb_yg_zt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_yg_m381e)
        Me.Controls.Add(Me.tb_yg_bmgd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_yg_v753n)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_yg_w779o)
        Me.Controls.Add(Me.tb_yg_n430f)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "frryAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设定人员"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_yg_n430f As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_yg_w779o As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_yg_v753n As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_yg_bmgd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_yg_m381e As System.Windows.Forms.ComboBox
    Friend WithEvents tb_yg_zt As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
