<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrWpAdd
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tb_sc_ftime = New chencontrol.chendatepick()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBoxFjxx = New System.Windows.Forms.GroupBox()
        Me.tb_sc_etime = New chencontrol.chendatepick()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_sc_isEnd = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_sc_dh = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_sc_bz = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(12, 119)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 193)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "投入原料"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(444, 588)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 150
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_sc_ftime
        '
        Me.tb_sc_ftime.BackColor = System.Drawing.Color.Wheat
        Me.tb_sc_ftime.Location = New System.Drawing.Point(261, 12)
        Me.tb_sc_ftime.Name = "tb_sc_ftime"
        Me.tb_sc_ftime.Size = New System.Drawing.Size(122, 21)
        Me.tb_sc_ftime.TabIndex = 152
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 151
        Me.Label3.Text = "开始时间"
        '
        'GroupBoxFjxx
        '
        Me.GroupBoxFjxx.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFjxx.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxFjxx.Location = New System.Drawing.Point(15, 39)
        Me.GroupBoxFjxx.Name = "GroupBoxFjxx"
        Me.GroupBoxFjxx.Size = New System.Drawing.Size(960, 74)
        Me.GroupBoxFjxx.TabIndex = 1
        Me.GroupBoxFjxx.TabStop = False
        Me.GroupBoxFjxx.Text = "附加信息"
        '
        'tb_sc_etime
        '
        Me.tb_sc_etime.BackColor = System.Drawing.Color.Wheat
        Me.tb_sc_etime.Location = New System.Drawing.Point(101, 591)
        Me.tb_sc_etime.Name = "tb_sc_etime"
        Me.tb_sc_etime.Size = New System.Drawing.Size(122, 21)
        Me.tb_sc_etime.TabIndex = 154
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 595)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "产出时间"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 595)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "完成状态"
        '
        'tb_sc_isEnd
        '
        Me.tb_sc_isEnd.AutoCompleteCustomSource.AddRange(New String() {"待机", "完成"})
        Me.tb_sc_isEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_sc_isEnd.FormattingEnabled = True
        Me.tb_sc_isEnd.Items.AddRange(New Object() {"待定", "完成"})
        Me.tb_sc_isEnd.Location = New System.Drawing.Point(292, 591)
        Me.tb_sc_isEnd.Name = "tb_sc_isEnd"
        Me.tb_sc_isEnd.Size = New System.Drawing.Size(71, 20)
        Me.tb_sc_isEnd.TabIndex = 148
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "生产单号"
        '
        'tb_sc_dh
        '
        Me.tb_sc_dh.BackColor = System.Drawing.Color.Wheat
        Me.tb_sc_dh.Location = New System.Drawing.Point(74, 13)
        Me.tb_sc_dh.Name = "tb_sc_dh"
        Me.tb_sc_dh.Size = New System.Drawing.Size(100, 21)
        Me.tb_sc_dh.TabIndex = 155
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(544, 588)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 150
        Me.Button2.Text = "报废"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 565)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "备注"
        '
        'tb_sc_bz
        '
        Me.tb_sc_bz.Location = New System.Drawing.Point(101, 562)
        Me.tb_sc_bz.Name = "tb_sc_bz"
        Me.tb_sc_bz.Size = New System.Drawing.Size(518, 21)
        Me.tb_sc_bz.TabIndex = 156
        '
        'FrWpAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 626)
        Me.Controls.Add(Me.tb_sc_bz)
        Me.Controls.Add(Me.tb_sc_dh)
        Me.Controls.Add(Me.tb_sc_etime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBoxFjxx)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_sc_ftime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tb_sc_isEnd)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrWpAdd"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrWpAdd"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_sc_ftime As chencontrol.chendatepick
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxFjxx As System.Windows.Forms.GroupBox
    Friend WithEvents tb_sc_etime As chencontrol.chendatepick
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_sc_isEnd As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_sc_dh As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_sc_bz As System.Windows.Forms.TextBox
End Class
