<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frqg0
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.show2 = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Labelserch = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.show1 = New System.Windows.Forms.DataGridView
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.tb_qgcg_jhdh = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.tb_qgcg_qgr = New System.Windows.Forms.ComboBox
        Me.tb_qgcg_qgbm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.tb_qgcg_qgrq = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.show2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.show2)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 347)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(908, 237)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'show2
        '
        Me.show2.AllowUserToAddRows = False
        Me.show2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.show2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.show2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show2.Location = New System.Drawing.Point(3, 17)
        Me.show2.MultiSelect = False
        Me.show2.Name = "show2"
        Me.show2.ReadOnly = True
        Me.show2.RowHeadersVisible = False
        Me.show2.RowTemplate.Height = 23
        Me.show2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show2.Size = New System.Drawing.Size(902, 217)
        Me.show2.TabIndex = 69
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.ComboBox3)
        Me.GroupBox3.Controls.Add(Me.Labelserch)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.show1)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 98)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(908, 221)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "列表"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(424, 20)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(54, 23)
        Me.Button8.TabIndex = 90
        Me.Button8.Text = "重置"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(191, 24)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(115, 21)
        Me.TextBox2.TabIndex = 85
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(52, 23)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(133, 20)
        Me.ComboBox3.TabIndex = 84
        '
        'Labelserch
        '
        Me.Labelserch.AutoSize = True
        Me.Labelserch.BackColor = System.Drawing.Color.Transparent
        Me.Labelserch.Location = New System.Drawing.Point(26, 26)
        Me.Labelserch.Name = "Labelserch"
        Me.Labelserch.Size = New System.Drawing.Size(29, 12)
        Me.Labelserch.TabIndex = 81
        Me.Labelserch.Text = "文本"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(336, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 23)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "筛选"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'show1
        '
        Me.show1.AllowUserToAddRows = False
        Me.show1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.show1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.show1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.show1.Location = New System.Drawing.Point(3, 51)
        Me.show1.MultiSelect = False
        Me.show1.Name = "show1"
        Me.show1.ReadOnly = True
        Me.show1.RowHeadersVisible = False
        Me.show1.RowTemplate.Height = 23
        Me.show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.show1.Size = New System.Drawing.Size(902, 167)
        Me.show1.TabIndex = 70
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(22, -528)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 61
        Me.Button6.Text = "修改"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(192, -256)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 61
        Me.Button5.Text = "修改"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(227, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(257, 12)
        Me.Label20.TabIndex = 207
        Me.Label20.Text = "备品备件和原料包材的上一个请购单号分别为："
        '
        'tb_qgcg_jhdh
        '
        Me.tb_qgcg_jhdh.Location = New System.Drawing.Point(91, 52)
        Me.tb_qgcg_jhdh.Name = "tb_qgcg_jhdh"
        Me.tb_qgcg_jhdh.ReadOnly = True
        Me.tb_qgcg_jhdh.Size = New System.Drawing.Size(105, 21)
        Me.tb_qgcg_jhdh.TabIndex = 206
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(19, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 205
        Me.Label19.Text = "请购单号"
        '
        'tb_qgcg_qgr
        '
        Me.tb_qgcg_qgr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tb_qgcg_qgr.FormattingEnabled = True
        Me.tb_qgcg_qgr.Location = New System.Drawing.Point(287, 51)
        Me.tb_qgcg_qgr.Name = "tb_qgcg_qgr"
        Me.tb_qgcg_qgr.Size = New System.Drawing.Size(108, 21)
        Me.tb_qgcg_qgr.TabIndex = 204
        '
        'tb_qgcg_qgbm
        '
        Me.tb_qgcg_qgbm.FormattingEnabled = True
        Me.tb_qgcg_qgbm.Location = New System.Drawing.Point(483, 50)
        Me.tb_qgcg_qgbm.Name = "tb_qgcg_qgbm"
        Me.tb_qgcg_qgbm.Size = New System.Drawing.Size(105, 20)
        Me.tb_qgcg_qgbm.TabIndex = 203
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(227, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "请购人"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(411, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "请购部门"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(810, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 21)
        Me.Button1.TabIndex = 208
        Me.Button1.Text = "确认"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(894, 49)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 21)
        Me.Button3.TabIndex = 209
        Me.Button3.Text = "提交"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'tb_qgcg_qgrq
        '
        Me.tb_qgcg_qgrq.Location = New System.Drawing.Point(679, 50)
        Me.tb_qgcg_qgrq.Name = "tb_qgcg_qgrq"
        Me.tb_qgcg_qgrq.Size = New System.Drawing.Size(112, 21)
        Me.tb_qgcg_qgrq.TabIndex = 211
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(607, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "请购日期"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(19, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "物品分类"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"备品备件", "原料包材"})
        Me.ComboBox1.Location = New System.Drawing.Point(91, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(105, 20)
        Me.ComboBox1.TabIndex = 203
        '
        'Frqg0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 596)
        Me.Controls.Add(Me.tb_qgcg_qgrq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.tb_qgcg_jhdh)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.tb_qgcg_qgr)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.tb_qgcg_qgbm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Frqg0"
        Me.Text = "请购输入"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.show2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.show1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents show2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Labelserch As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents show1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tb_qgcg_jhdh As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tb_qgcg_qgr As System.Windows.Forms.ComboBox
    Friend WithEvents tb_qgcg_qgbm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents tb_qgcg_qgrq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
