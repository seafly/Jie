<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrgxAdd
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_gxsz_mc = New System.Windows.Forms.TextBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_gxsz_dm = New yangNetCl.yanTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_gxsz_isMod = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_gxsz_ID = New System.Windows.Forms.TextBox()
        Me.tb_gxsz_isqc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_gxsz_px = New yangNetCl.yanTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.showWpxx = New yangNetCl.yanDaTaGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.showFjxx = New yangNetCl.yanDaTaGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_gxsz_isBf = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.showWpxx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.showFjxx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工艺名称"
        '
        'tb_gxsz_mc
        '
        Me.tb_gxsz_mc.BackColor = System.Drawing.Color.Wheat
        Me.tb_gxsz_mc.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxsz_mc.Location = New System.Drawing.Point(74, 20)
        Me.tb_gxsz_mc.Name = "tb_gxsz_mc"
        Me.tb_gxsz_mc.Size = New System.Drawing.Size(80, 21)
        Me.tb_gxsz_mc.TabIndex = 1
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(490, 471)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 4
        Me.button1.Text = "确定"
        Me.button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(160, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "工艺代码"
        '
        'tb_gxsz_dm
        '
        Me.tb_gxsz_dm.BackColor = System.Drawing.Color.Wheat
        Me.tb_gxsz_dm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxsz_dm.Location = New System.Drawing.Point(219, 20)
        Me.tb_gxsz_dm.Name = "tb_gxsz_dm"
        Me.tb_gxsz_dm.Size = New System.Drawing.Size(60, 21)
        Me.tb_gxsz_dm.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(534, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "允许修改"
        '
        'tb_gxsz_isMod
        '
        Me.tb_gxsz_isMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_gxsz_isMod.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxsz_isMod.FormattingEnabled = True
        Me.tb_gxsz_isMod.Items.AddRange(New Object() {"是", "否"})
        Me.tb_gxsz_isMod.Location = New System.Drawing.Point(593, 20)
        Me.tb_gxsz_isMod.Name = "tb_gxsz_isMod"
        Me.tb_gxsz_isMod.Size = New System.Drawing.Size(60, 20)
        Me.tb_gxsz_isMod.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_ID)
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_isqc)
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_isBf)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_isMod)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_mc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_px)
        Me.GroupBox1.Controls.Add(Me.tb_gxsz_dm)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(34, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1009, 57)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "工艺基本信息"
        '
        'tb_gxsz_ID
        '
        Me.tb_gxsz_ID.Location = New System.Drawing.Point(963, 30)
        Me.tb_gxsz_ID.Name = "tb_gxsz_ID"
        Me.tb_gxsz_ID.Size = New System.Drawing.Size(40, 21)
        Me.tb_gxsz_ID.TabIndex = 6
        Me.tb_gxsz_ID.Visible = False
        '
        'tb_gxsz_isqc
        '
        Me.tb_gxsz_isqc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_gxsz_isqc.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxsz_isqc.FormattingEnabled = True
        Me.tb_gxsz_isqc.Items.AddRange(New Object() {"是", "否"})
        Me.tb_gxsz_isqc.Location = New System.Drawing.Point(457, 20)
        Me.tb_gxsz_isqc.Name = "tb_gxsz_isqc"
        Me.tb_gxsz_isqc.Size = New System.Drawing.Size(60, 20)
        Me.tb_gxsz_isqc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(927, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "主键"
        Me.Label2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(410, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "是否QC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(285, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "工艺顺序"
        '
        'tb_gxsz_px
        '
        Me.tb_gxsz_px.BackColor = System.Drawing.Color.Wheat
        Me.tb_gxsz_px.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxsz_px.Location = New System.Drawing.Point(344, 20)
        Me.tb_gxsz_px.Name = "tb_gxsz_px"
        Me.tb_gxsz_px.Size = New System.Drawing.Size(60, 21)
        Me.tb_gxsz_px.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.showWpxx)
        Me.GroupBox2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(34, 316)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1012, 138)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "产出物品信息"
        '
        'showWpxx
        '
        Me.showWpxx.AllowUserToAddRows = False
        Me.showWpxx.BackgroundColor = System.Drawing.SystemColors.Window
        Me.showWpxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showWpxx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showWpxx.Location = New System.Drawing.Point(3, 17)
        Me.showWpxx.Name = "showWpxx"
        Me.showWpxx.ReadOnly = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.showWpxx.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.showWpxx.RowTemplate.Height = 23
        Me.showWpxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showWpxx.Size = New System.Drawing.Size(1006, 118)
        Me.showWpxx.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.showFjxx)
        Me.GroupBox3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(34, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1012, 235)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "工艺附加信息"
        '
        'showFjxx
        '
        Me.showFjxx.AllowUserToAddRows = False
        Me.showFjxx.BackgroundColor = System.Drawing.SystemColors.Window
        Me.showFjxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showFjxx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showFjxx.Location = New System.Drawing.Point(3, 17)
        Me.showFjxx.Name = "showFjxx"
        Me.showFjxx.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.showFjxx.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.showFjxx.RowTemplate.Height = 23
        Me.showFjxx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showFjxx.Size = New System.Drawing.Size(1006, 215)
        Me.showFjxx.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(660, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "允许报废"
        '
        'tb_gxsz_isBf
        '
        Me.tb_gxsz_isBf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_gxsz_isBf.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxsz_isBf.FormattingEnabled = True
        Me.tb_gxsz_isBf.Items.AddRange(New Object() {"是", "否"})
        Me.tb_gxsz_isBf.Location = New System.Drawing.Point(719, 20)
        Me.tb_gxsz_isBf.Name = "tb_gxsz_isBf"
        Me.tb_gxsz_isBf.Size = New System.Drawing.Size(60, 20)
        Me.tb_gxsz_isBf.TabIndex = 2
        '
        'FrgxAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 506)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrgxAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frgxsz"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.showWpxx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.showFjxx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_gxsz_mc As System.Windows.Forms.TextBox
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_gxsz_dm As yangNetCl.yanTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_gxsz_isMod As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents showWpxx As yangNetCl.yanDaTaGridView
    Friend WithEvents tb_gxsz_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents showFjxx As yangNetCl.yanDaTaGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_gxsz_px As yangNetCl.yanTextBox
    Friend WithEvents tb_gxsz_isqc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_gxsz_isBf As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
