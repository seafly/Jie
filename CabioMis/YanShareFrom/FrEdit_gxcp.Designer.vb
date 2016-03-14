<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrEdit_gxcp
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_wp_pm = New System.Windows.Forms.TextBox()
        Me.tb_wp_dm = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_gxcccp_ccps = New yangNetCl.yanTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_gxcccp_isdp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tb_wp_ID = New yangNetCl.yanTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_gxcccp_ID = New yangNetCl.yanTextBox()
        Me.lableRowbs = New System.Windows.Forms.Label()
        Me.rowBs = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(73, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "产出物品代码"
        '
        'tb_wp_pm
        '
        Me.tb_wp_pm.BackColor = System.Drawing.Color.Wheat
        Me.tb_wp_pm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_wp_pm.Location = New System.Drawing.Point(154, 69)
        Me.tb_wp_pm.Name = "tb_wp_pm"
        Me.tb_wp_pm.ReadOnly = True
        Me.tb_wp_pm.Size = New System.Drawing.Size(100, 21)
        Me.tb_wp_pm.TabIndex = 4
        '
        'tb_wp_dm
        '
        Me.tb_wp_dm.BackColor = System.Drawing.Color.Wheat
        Me.tb_wp_dm.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_wp_dm.Location = New System.Drawing.Point(154, 30)
        Me.tb_wp_dm.Name = "tb_wp_dm"
        Me.tb_wp_dm.ReadOnly = True
        Me.tb_wp_dm.Size = New System.Drawing.Size(100, 21)
        Me.tb_wp_dm.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(95, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "产品名称"
        '
        'tb_gxcccp_ccps
        '
        Me.tb_gxcccp_ccps.BackColor = System.Drawing.Color.Wheat
        Me.tb_gxcccp_ccps.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxcccp_ccps.Location = New System.Drawing.Point(154, 140)
        Me.tb_gxcccp_ccps.Name = "tb_gxcccp_ccps"
        Me.tb_gxcccp_ccps.Size = New System.Drawing.Size(100, 21)
        Me.tb_gxcccp_ccps.TabIndex = 9
        Me.tb_gxcccp_ccps.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(71, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "默认产出批数"
        '
        'tb_gxcccp_isdp
        '
        Me.tb_gxcccp_isdp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_gxcccp_isdp.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxcccp_isdp.FormattingEnabled = True
        Me.tb_gxcccp_isdp.Items.AddRange(New Object() {"是", "否"})
        Me.tb_gxcccp_isdp.Location = New System.Drawing.Point(154, 101)
        Me.tb_gxcccp_isdp.Name = "tb_gxcccp_isdp"
        Me.tb_gxcccp_isdp.Size = New System.Drawing.Size(100, 20)
        Me.tb_gxcccp_isdp.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "是否允许多批"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button2.Location = New System.Drawing.Point(138, 194)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "确定"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tb_wp_ID
        '
        Me.tb_wp_ID.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_wp_ID.Location = New System.Drawing.Point(73, 194)
        Me.tb_wp_ID.Name = "tb_wp_ID"
        Me.tb_wp_ID.Size = New System.Drawing.Size(50, 21)
        Me.tb_wp_ID.TabIndex = 9
        Me.tb_wp_ID.Text = "0"
        Me.tb_wp_ID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "物品标识"
        Me.Label1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(249, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "标识"
        Me.Label5.Visible = False
        '
        'tb_gxcccp_ID
        '
        Me.tb_gxcccp_ID.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_gxcccp_ID.Location = New System.Drawing.Point(284, 194)
        Me.tb_gxcccp_ID.Name = "tb_gxcccp_ID"
        Me.tb_gxcccp_ID.Size = New System.Drawing.Size(50, 21)
        Me.tb_gxcccp_ID.TabIndex = 9
        Me.tb_gxcccp_ID.Text = "0"
        Me.tb_gxcccp_ID.Visible = False
        '
        'lableRowbs
        '
        Me.lableRowbs.AutoSize = True
        Me.lableRowbs.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lableRowbs.Location = New System.Drawing.Point(237, 176)
        Me.lableRowbs.Name = "lableRowbs"
        Me.lableRowbs.Size = New System.Drawing.Size(41, 12)
        Me.lableRowbs.TabIndex = 7
        Me.lableRowbs.Text = "行标识"
        Me.lableRowbs.Visible = False
        '
        'rowBs
        '
        Me.rowBs.Location = New System.Drawing.Point(285, 166)
        Me.rowBs.Name = "rowBs"
        Me.rowBs.Size = New System.Drawing.Size(49, 21)
        Me.rowBs.TabIndex = 11
        Me.rowBs.Visible = False
        '
        'FrEdit_gxcp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 233)
        Me.Controls.Add(Me.rowBs)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tb_gxcccp_ID)
        Me.Controls.Add(Me.tb_wp_ID)
        Me.Controls.Add(Me.tb_gxcccp_ccps)
        Me.Controls.Add(Me.lableRowbs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_gxcccp_isdp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_wp_pm)
        Me.Controls.Add(Me.tb_wp_dm)
        Me.Controls.Add(Me.Label8)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrEdit_gxcp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工艺产出物品编辑"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_wp_pm As System.Windows.Forms.TextBox
    Friend WithEvents tb_wp_dm As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_gxcccp_ccps As yangNetCl.yanTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_gxcccp_isdp As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tb_wp_ID As yangNetCl.yanTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_gxcccp_ID As yangNetCl.yanTextBox
    Friend WithEvents lableRowbs As System.Windows.Forms.Label
    Friend WithEvents rowBs As System.Windows.Forms.TextBox
End Class
