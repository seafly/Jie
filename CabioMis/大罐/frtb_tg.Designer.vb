<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frtb_tg
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_tg_num = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_tg_ph = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_tg_pht = New System.Windows.Forms.TextBox()
        Me.tb_tg_rq = New chencontrol.chendatepick()
        Me.tb_tg_zl = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.zl = New System.Windows.Forms.Label()
        Me.ph = New System.Windows.Forms.Label()
        Me.Labeltb = New System.Windows.Forms.Label()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.SSSQD = New System.Windows.Forms.Button()
        Me.listview1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTN_EXCEL = New System.Windows.Forms.Button()
        Me.BTN_SEARCH = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_tg_yldm = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_tg_tj = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_tg_hsgx = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_tg_gh = New System.Windows.Forms.TextBox()
        Me.tb_tg_gmc = New System.Windows.Forms.TextBox()
        CType(Me.listview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(34, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "批号"
        '
        'tb_tg_num
        '
        Me.tb_tg_num.Location = New System.Drawing.Point(93, 17)
        Me.tb_tg_num.Name = "tb_tg_num"
        Me.tb_tg_num.Size = New System.Drawing.Size(130, 21)
        Me.tb_tg_num.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(342, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "配料时间"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(10, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "批号序列"
        '
        'tb_tg_ph
        '
        Me.tb_tg_ph.Location = New System.Drawing.Point(93, 61)
        Me.tb_tg_ph.Name = "tb_tg_ph"
        Me.tb_tg_ph.ReadOnly = True
        Me.tb_tg_ph.Size = New System.Drawing.Size(130, 21)
        Me.tb_tg_ph.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(342, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "重量序列"
        '
        'tb_tg_pht
        '
        Me.tb_tg_pht.Location = New System.Drawing.Point(401, 61)
        Me.tb_tg_pht.Name = "tb_tg_pht"
        Me.tb_tg_pht.ReadOnly = True
        Me.tb_tg_pht.Size = New System.Drawing.Size(130, 21)
        Me.tb_tg_pht.TabIndex = 7
        '
        'tb_tg_rq
        '
        Me.tb_tg_rq.BackColor = System.Drawing.Color.White
        Me.tb_tg_rq.Location = New System.Drawing.Point(401, 17)
        Me.tb_tg_rq.Name = "tb_tg_rq"
        Me.tb_tg_rq.Size = New System.Drawing.Size(130, 21)
        Me.tb_tg_rq.TabIndex = 10
        '
        'tb_tg_zl
        '
        Me.tb_tg_zl.Location = New System.Drawing.Point(228, 113)
        Me.tb_tg_zl.Name = "tb_tg_zl"
        Me.tb_tg_zl.ReadOnly = True
        Me.tb_tg_zl.Size = New System.Drawing.Size(57, 21)
        Me.tb_tg_zl.TabIndex = 11
        Me.tb_tg_zl.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "总重量"
        Me.Label6.Visible = False
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(553, 153)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(23, 12)
        Me.Labelid.TabIndex = 140
        Me.Labelid.Text = " id"
        Me.Labelid.Visible = False
        '
        'zl
        '
        Me.zl.AutoSize = True
        Me.zl.Location = New System.Drawing.Point(714, 153)
        Me.zl.Name = "zl"
        Me.zl.Size = New System.Drawing.Size(17, 12)
        Me.zl.TabIndex = 139
        Me.zl.Text = "zl"
        Me.zl.Visible = False
        '
        'ph
        '
        Me.ph.AutoSize = True
        Me.ph.Location = New System.Drawing.Point(673, 153)
        Me.ph.Name = "ph"
        Me.ph.Size = New System.Drawing.Size(17, 12)
        Me.ph.TabIndex = 138
        Me.ph.Text = "ph"
        Me.ph.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(604, 153)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(35, 12)
        Me.Labeltb.TabIndex = 137
        Me.Labeltb.Text = "tb_tg"
        Me.Labeltb.Visible = False
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(597, 101)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 33)
        Me.SSSQX.TabIndex = 136
        Me.SSSQX.Text = "退出"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(501, 101)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 33)
        Me.SSSQD.TabIndex = 135
        Me.SSSQD.Text = "添加"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'listview1
        '
        Me.listview1.AllowUserToAddRows = False
        Me.listview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.listview1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.listview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.listview1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.listview1.Location = New System.Drawing.Point(6, 67)
        Me.listview1.MultiSelect = False
        Me.listview1.Name = "listview1"
        Me.listview1.ReadOnly = True
        Me.listview1.RowHeadersVisible = False
        Me.listview1.RowTemplate.Height = 23
        Me.listview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.listview1.Size = New System.Drawing.Size(790, 257)
        Me.listview1.TabIndex = 143
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BTN_EXCEL)
        Me.GroupBox1.Controls.Add(Me.BTN_SEARCH)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.listview1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 168)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 330)
        Me.GroupBox1.TabIndex = 144
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "数据"
        '
        'BTN_EXCEL
        '
        Me.BTN_EXCEL.Location = New System.Drawing.Point(369, 16)
        Me.BTN_EXCEL.Name = "BTN_EXCEL"
        Me.BTN_EXCEL.Size = New System.Drawing.Size(75, 33)
        Me.BTN_EXCEL.TabIndex = 148
        Me.BTN_EXCEL.Text = "生成文件"
        Me.BTN_EXCEL.UseVisualStyleBackColor = True
        '
        'BTN_SEARCH
        '
        Me.BTN_SEARCH.Location = New System.Drawing.Point(276, 16)
        Me.BTN_SEARCH.Name = "BTN_SEARCH"
        Me.BTN_SEARCH.Size = New System.Drawing.Size(75, 33)
        Me.BTN_SEARCH.TabIndex = 147
        Me.BTN_SEARCH.Text = "查询"
        Me.BTN_SEARCH.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(157, 20)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(95, 21)
        Me.DateTimePicker2.TabIndex = 146
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(95, 21)
        Me.DateTimePicker1.TabIndex = 145
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(121, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "至"
        '
        'tb_tg_yldm
        '
        Me.tb_tg_yldm.Location = New System.Drawing.Point(93, 113)
        Me.tb_tg_yldm.Name = "tb_tg_yldm"
        Me.tb_tg_yldm.Size = New System.Drawing.Size(57, 21)
        Me.tb_tg_yldm.TabIndex = 145
        Me.tb_tg_yldm.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "原料代码"
        Me.Label5.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(566, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "体积"
        '
        'tb_tg_tj
        '
        Me.tb_tg_tj.Location = New System.Drawing.Point(606, 60)
        Me.tb_tg_tj.Name = "tb_tg_tj"
        Me.tb_tg_tj.Size = New System.Drawing.Size(62, 21)
        Me.tb_tg_tj.TabIndex = 148
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "体积换算关系"
        Me.Label9.Visible = False
        '
        'tb_tg_hsgx
        '
        Me.tb_tg_hsgx.Location = New System.Drawing.Point(419, 113)
        Me.tb_tg_hsgx.Name = "tb_tg_hsgx"
        Me.tb_tg_hsgx.ReadOnly = True
        Me.tb_tg_hsgx.Size = New System.Drawing.Size(57, 21)
        Me.tb_tg_hsgx.TabIndex = 149
        Me.tb_tg_hsgx.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(566, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "罐号"
        Me.Label10.Visible = False
        '
        'tb_tg_gh
        '
        Me.tb_tg_gh.Location = New System.Drawing.Point(606, 20)
        Me.tb_tg_gh.Name = "tb_tg_gh"
        Me.tb_tg_gh.Size = New System.Drawing.Size(100, 21)
        Me.tb_tg_gh.TabIndex = 151
        Me.tb_tg_gh.Visible = False
        '
        'tb_tg_gmc
        '
        Me.tb_tg_gmc.Location = New System.Drawing.Point(755, 108)
        Me.tb_tg_gmc.Name = "tb_tg_gmc"
        Me.tb_tg_gmc.Size = New System.Drawing.Size(53, 21)
        Me.tb_tg_gmc.TabIndex = 152
        Me.tb_tg_gmc.Text = "罐名"
        Me.tb_tg_gmc.Visible = False
        '
        'Frtb_tg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 498)
        Me.Controls.Add(Me.tb_tg_gmc)
        Me.Controls.Add(Me.tb_tg_gh)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tb_tg_hsgx)
        Me.Controls.Add(Me.tb_tg_tj)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_tg_yldm)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.zl)
        Me.Controls.Add(Me.ph)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tb_tg_zl)
        Me.Controls.Add(Me.tb_tg_rq)
        Me.Controls.Add(Me.tb_tg_pht)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_tg_ph)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tb_tg_num)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frtb_tg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "糖罐"
        CType(Me.listview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_tg_num As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_tg_ph As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_tg_pht As System.Windows.Forms.TextBox
    Friend WithEvents tb_tg_rq As chencontrol.chendatepick
    Friend WithEvents tb_tg_zl As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents zl As System.Windows.Forms.Label
    Friend WithEvents ph As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents listview1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_SEARCH As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BTN_EXCEL As System.Windows.Forms.Button
    Friend WithEvents tb_tg_yldm As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_tg_tj As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_tg_hsgx As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_tg_gh As System.Windows.Forms.TextBox
    Friend WithEvents tb_tg_gmc As System.Windows.Forms.TextBox
End Class
