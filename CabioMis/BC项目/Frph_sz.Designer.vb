<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frph_sz
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
        Me.tb_bcbm_lx = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lableCxjs = New System.Windows.Forms.Label()
        Me.tb_bcbm_zdbz = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_bcbm_tb = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_bcbm_bs = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_bcbm_va2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tb_bcbm_bmmc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_bcbm_va = New yangNetCl.yanTextBox()
        Me.YanDaTaGridView1 = New yangNetCl.yanDaTaGridView()
        Me.phEx = New System.Windows.Forms.ComboBox()
        CType(Me.YanDaTaGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(490, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "添加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_bcbm_lx
        '
        Me.tb_bcbm_lx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_bcbm_lx.FormattingEnabled = True
        Me.tb_bcbm_lx.Items.AddRange(New Object() {"文本", "当前年", "当前年(2位)", "当前月", "当前日", "随机数", "累加数"})
        Me.tb_bcbm_lx.Location = New System.Drawing.Point(87, 49)
        Me.tb_bcbm_lx.Name = "tb_bcbm_lx"
        Me.tb_bcbm_lx.Size = New System.Drawing.Size(81, 20)
        Me.tb_bcbm_lx.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(301, 379)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "保存"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "类型"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "值"
        '
        'lableCxjs
        '
        Me.lableCxjs.AutoSize = True
        Me.lableCxjs.Location = New System.Drawing.Point(324, 52)
        Me.lableCxjs.Name = "lableCxjs"
        Me.lableCxjs.Size = New System.Drawing.Size(53, 12)
        Me.lableCxjs.TabIndex = 5
        Me.lableCxjs.Text = "重新计数"
        '
        'tb_bcbm_zdbz
        '
        Me.tb_bcbm_zdbz.AutoCompleteCustomSource.AddRange(New String() {"", "年", "月", "日"})
        Me.tb_bcbm_zdbz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_bcbm_zdbz.FormattingEnabled = True
        Me.tb_bcbm_zdbz.Items.AddRange(New Object() {"", "年", "月", "日"})
        Me.tb_bcbm_zdbz.Location = New System.Drawing.Point(381, 49)
        Me.tb_bcbm_zdbz.Name = "tb_bcbm_zdbz"
        Me.tb_bcbm_zdbz.Size = New System.Drawing.Size(81, 20)
        Me.tb_bcbm_zdbz.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-9, 384)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "表"
        Me.Label4.Visible = False
        '
        'tb_bcbm_tb
        '
        Me.tb_bcbm_tb.Location = New System.Drawing.Point(14, 381)
        Me.tb_bcbm_tb.Name = "tb_bcbm_tb"
        Me.tb_bcbm_tb.Size = New System.Drawing.Size(52, 21)
        Me.tb_bcbm_tb.TabIndex = 6
        Me.tb_bcbm_tb.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 387)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "标识"
        Me.Label5.Visible = False
        '
        'tb_bcbm_bs
        '
        Me.tb_bcbm_bs.Location = New System.Drawing.Point(100, 384)
        Me.tb_bcbm_bs.Name = "tb_bcbm_bs"
        Me.tb_bcbm_bs.Size = New System.Drawing.Size(52, 21)
        Me.tb_bcbm_bs.TabIndex = 6
        Me.tb_bcbm_bs.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(170, 384)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "原始值"
        Me.Label3.Visible = False
        '
        'tb_bcbm_va2
        '
        Me.tb_bcbm_va2.Location = New System.Drawing.Point(215, 381)
        Me.tb_bcbm_va2.Name = "tb_bcbm_va2"
        Me.tb_bcbm_va2.Size = New System.Drawing.Size(39, 21)
        Me.tb_bcbm_va2.TabIndex = 6
        Me.tb_bcbm_va2.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "完整编码"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(87, 112)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(206, 21)
        Me.TextBox1.TabIndex = 9
        '
        'tb_bcbm_bmmc
        '
        Me.tb_bcbm_bmmc.BackColor = System.Drawing.Color.Wheat
        Me.tb_bcbm_bmmc.Location = New System.Drawing.Point(85, 12)
        Me.tb_bcbm_bmmc.Name = "tb_bcbm_bmmc"
        Me.tb_bcbm_bmmc.Size = New System.Drawing.Size(81, 21)
        Me.tb_bcbm_bmmc.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "名称"
        '
        'tb_bcbm_va
        '
        Me.tb_bcbm_va.BackColor = System.Drawing.Color.Wheat
        Me.tb_bcbm_va.isOnlyNum = False
        Me.tb_bcbm_va.Location = New System.Drawing.Point(220, 49)
        Me.tb_bcbm_va.Name = "tb_bcbm_va"
        Me.tb_bcbm_va.Size = New System.Drawing.Size(74, 21)
        Me.tb_bcbm_va.TabIndex = 7
        '
        'YanDaTaGridView1
        '
        Me.YanDaTaGridView1.AllowUserToAddRows = False
        Me.YanDaTaGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.YanDaTaGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.YanDaTaGridView1.Location = New System.Drawing.Point(19, 139)
        Me.YanDaTaGridView1.Name = "YanDaTaGridView1"
        Me.YanDaTaGridView1.ReadOnly = True
        Me.YanDaTaGridView1.RowTemplate.Height = 23
        Me.YanDaTaGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.YanDaTaGridView1.Size = New System.Drawing.Size(671, 227)
        Me.YanDaTaGridView1.TabIndex = 0
        '
        'phEx
        '
        Me.phEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.phEx.FormattingEnabled = True
        Me.phEx.Location = New System.Drawing.Point(87, 75)
        Me.phEx.Name = "phEx"
        Me.phEx.Size = New System.Drawing.Size(81, 20)
        Me.phEx.TabIndex = 2
        '
        'Frph_sz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 417)
        Me.Controls.Add(Me.tb_bcbm_bmmc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_bcbm_va)
        Me.Controls.Add(Me.tb_bcbm_va2)
        Me.Controls.Add(Me.tb_bcbm_bs)
        Me.Controls.Add(Me.tb_bcbm_tb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lableCxjs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tb_bcbm_zdbz)
        Me.Controls.Add(Me.phEx)
        Me.Controls.Add(Me.tb_bcbm_lx)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.YanDaTaGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frph_sz"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批号设置"
        CType(Me.YanDaTaGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents YanDaTaGridView1 As yangNetCl.yanDaTaGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_bcbm_lx As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lableCxjs As System.Windows.Forms.Label
    Friend WithEvents tb_bcbm_zdbz As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_bcbm_tb As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_bcbm_bs As System.Windows.Forms.TextBox
    Friend WithEvents tb_bcbm_va As yangNetCl.yanTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_bcbm_va2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_bcbm_bmmc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents phEx As System.Windows.Forms.ComboBox
End Class
