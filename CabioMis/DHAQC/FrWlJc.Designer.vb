<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrWlJc
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_QcJc_sfwc = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_i259b_c24u = New System.Windows.Forms.Label()
        Me.tb_i259b_i231a = New System.Windows.Forms.Label()
        Me.tb_QcJc_ftime = New chencontrol.chendatepick()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.button2 = New System.Windows.Forms.Button()
        Me.tb_QcJc_qjtime = New chencontrol.chendatepick()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_QcJc_qjbh = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_QcJc_sfsh = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.labPname = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.show1 = New CabioMis.yanDaTaGridView()
        Me.GroupBox2.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(453, 527)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 530)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "是否完成"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_QcJc_sfwc
        '
        Me.tb_QcJc_sfwc.FormattingEnabled = True
        Me.tb_QcJc_sfwc.Items.AddRange(New Object() {"否", "是"})
        Me.tb_QcJc_sfwc.Location = New System.Drawing.Point(81, 527)
        Me.tb_QcJc_sfwc.Name = "tb_QcJc_sfwc"
        Me.tb_QcJc_sfwc.Size = New System.Drawing.Size(74, 20)
        Me.tb_QcJc_sfwc.TabIndex = 137
        Me.tb_QcJc_sfwc.Text = "否"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "检测项目："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "检测名称:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_i259b_c24u
        '
        Me.tb_i259b_c24u.AutoSize = True
        Me.tb_i259b_c24u.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_i259b_c24u.ForeColor = System.Drawing.Color.Black
        Me.tb_i259b_c24u.Location = New System.Drawing.Point(216, 12)
        Me.tb_i259b_c24u.Name = "tb_i259b_c24u"
        Me.tb_i259b_c24u.Size = New System.Drawing.Size(69, 19)
        Me.tb_i259b_c24u.TabIndex = 136
        Me.tb_i259b_c24u.Text = "原料名称:"
        Me.tb_i259b_c24u.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_i259b_i231a
        '
        Me.tb_i259b_i231a.AutoSize = True
        Me.tb_i259b_i231a.Enabled = False
        Me.tb_i259b_i231a.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_i259b_i231a.ForeColor = System.Drawing.Color.Black
        Me.tb_i259b_i231a.Location = New System.Drawing.Point(73, 13)
        Me.tb_i259b_i231a.Name = "tb_i259b_i231a"
        Me.tb_i259b_i231a.Size = New System.Drawing.Size(65, 19)
        Me.tb_i259b_i231a.TabIndex = 136
        Me.tb_i259b_i231a.Text = "原料代码"
        Me.tb_i259b_i231a.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_QcJc_ftime
        '
        Me.tb_QcJc_ftime.BackColor = System.Drawing.Color.White
        Me.tb_QcJc_ftime.Location = New System.Drawing.Point(510, 146)
        Me.tb_QcJc_ftime.Name = "tb_QcJc_ftime"
        Me.tb_QcJc_ftime.Size = New System.Drawing.Size(122, 21)
        Me.tb_QcJc_ftime.TabIndex = 141
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(451, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "检测时间"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(897, 13)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 143
        Me.button2.Text = "新建请检单"
        Me.button2.UseVisualStyleBackColor = True
        '
        'tb_QcJc_qjtime
        '
        Me.tb_QcJc_qjtime.BackColor = System.Drawing.Color.White
        Me.tb_QcJc_qjtime.Location = New System.Drawing.Point(291, 146)
        Me.tb_QcJc_qjtime.Name = "tb_QcJc_qjtime"
        Me.tb_QcJc_qjtime.Size = New System.Drawing.Size(122, 21)
        Me.tb_QcJc_qjtime.TabIndex = 145
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(232, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "请检时间"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "请检单号"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_QcJc_qjbh
        '
        Me.tb_QcJc_qjbh.ForeColor = System.Drawing.Color.DarkGray
        Me.tb_QcJc_qjbh.Location = New System.Drawing.Point(83, 146)
        Me.tb_QcJc_qjbh.Name = "tb_QcJc_qjbh"
        Me.tb_QcJc_qjbh.Size = New System.Drawing.Size(133, 21)
        Me.tb_QcJc_qjbh.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.show1)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(956, 105)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "检测记录"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(303, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "批号:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(362, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "原料名称:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_QcJc_sfsh
        '
        Me.tb_QcJc_sfsh.FormattingEnabled = True
        Me.tb_QcJc_sfsh.Items.AddRange(New Object() {"否", "是"})
        Me.tb_QcJc_sfsh.Location = New System.Drawing.Point(248, 527)
        Me.tb_QcJc_sfsh.Name = "tb_QcJc_sfsh"
        Me.tb_QcJc_sfsh.Size = New System.Drawing.Size(74, 20)
        Me.tb_QcJc_sfsh.TabIndex = 148
        Me.tb_QcJc_sfsh.Text = "否"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(12, 175)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(957, 346)
        Me.Panel1.TabIndex = 149
        '
        'labPname
        '
        Me.labPname.AutoSize = True
        Me.labPname.Location = New System.Drawing.Point(895, 151)
        Me.labPname.Name = "labPname"
        Me.labPname.Size = New System.Drawing.Size(53, 12)
        Me.labPname.TabIndex = 150
        Me.labPname.Text = "检测项目"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(184, 530)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 147
        Me.Label9.Text = "是否审核"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.show1.Location = New System.Drawing.Point(3, 17)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(950, 85)
        Me.show1.TabIndex = 0
        '
        'FrWlJc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.labPname)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tb_QcJc_sfsh)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tb_QcJc_qjbh)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tb_QcJc_qjtime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tb_QcJc_ftime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_QcJc_sfwc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_i259b_c24u)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_i259b_i231a)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.Name = "FrWlJc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrWlJc-FrWlJc"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_QcJc_sfwc As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_i259b_c24u As System.Windows.Forms.Label
    Friend WithEvents tb_i259b_i231a As System.Windows.Forms.Label
    Friend WithEvents tb_QcJc_ftime As chencontrol.chendatepick
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents tb_QcJc_qjtime As chencontrol.chendatepick
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_QcJc_qjbh As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents show1 As CabioMis.yanDaTaGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_QcJc_sfsh As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents labPname As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
