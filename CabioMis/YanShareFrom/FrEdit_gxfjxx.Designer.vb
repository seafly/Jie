<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrEdit_gxfjxx
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_gxfjxx_lx = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_gxfjxx_mc = New System.Windows.Forms.TextBox()
        Me.tb_gxfjxx_ID = New System.Windows.Forms.TextBox()
        Me.lbGybs = New System.Windows.Forms.Label()
        Me.tb_gxfjxx_isbx = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rowBs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(199, 298)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "类型"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_gxfjxx_lx
        '
        Me.tb_gxfjxx_lx.BackColor = System.Drawing.Color.Wheat
        Me.tb_gxfjxx_lx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_gxfjxx_lx.FormattingEnabled = True
        Me.tb_gxfjxx_lx.Location = New System.Drawing.Point(205, 103)
        Me.tb_gxfjxx_lx.Name = "tb_gxfjxx_lx"
        Me.tb_gxfjxx_lx.Size = New System.Drawing.Size(121, 20)
        Me.tb_gxfjxx_lx.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(119, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "名称"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_gxfjxx_mc
        '
        Me.tb_gxfjxx_mc.BackColor = System.Drawing.Color.Wheat
        Me.tb_gxfjxx_mc.Location = New System.Drawing.Point(205, 21)
        Me.tb_gxfjxx_mc.Name = "tb_gxfjxx_mc"
        Me.tb_gxfjxx_mc.Size = New System.Drawing.Size(121, 21)
        Me.tb_gxfjxx_mc.TabIndex = 6
        '
        'tb_gxfjxx_ID
        '
        Me.tb_gxfjxx_ID.Location = New System.Drawing.Point(38, 310)
        Me.tb_gxfjxx_ID.Name = "tb_gxfjxx_ID"
        Me.tb_gxfjxx_ID.Size = New System.Drawing.Size(46, 21)
        Me.tb_gxfjxx_ID.TabIndex = 7
        Me.tb_gxfjxx_ID.Text = "0"
        Me.tb_gxfjxx_ID.Visible = False
        '
        'lbGybs
        '
        Me.lbGybs.AutoSize = True
        Me.lbGybs.Location = New System.Drawing.Point(6, 313)
        Me.lbGybs.Name = "lbGybs"
        Me.lbGybs.Size = New System.Drawing.Size(29, 12)
        Me.lbGybs.TabIndex = 8
        Me.lbGybs.Text = "标识"
        Me.lbGybs.Visible = False
        '
        'tb_gxfjxx_isbx
        '
        Me.tb_gxfjxx_isbx.BackColor = System.Drawing.SystemColors.Window
        Me.tb_gxfjxx_isbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_gxfjxx_isbx.FormattingEnabled = True
        Me.tb_gxfjxx_isbx.Items.AddRange(New Object() {"是", "否"})
        Me.tb_gxfjxx_isbx.Location = New System.Drawing.Point(205, 61)
        Me.tb_gxfjxx_isbx.Name = "tb_gxfjxx_isbx"
        Me.tb_gxfjxx_isbx.Size = New System.Drawing.Size(121, 20)
        Me.tb_gxfjxx_isbx.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(119, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "是否必须"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rowBs
        '
        Me.rowBs.Location = New System.Drawing.Point(426, 304)
        Me.rowBs.Name = "rowBs"
        Me.rowBs.Size = New System.Drawing.Size(46, 21)
        Me.rowBs.TabIndex = 7
        Me.rowBs.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(394, 307)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "行标识"
        Me.Label4.Visible = False
        '
        'FrEdit_gxfjxx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 333)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbGybs)
        Me.Controls.Add(Me.rowBs)
        Me.Controls.Add(Me.tb_gxfjxx_ID)
        Me.Controls.Add(Me.tb_gxfjxx_mc)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_gxfjxx_isbx)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_gxfjxx_lx)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrEdit_gxfjxx"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "数据编辑"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_gxfjxx_lx As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_gxfjxx_mc As System.Windows.Forms.TextBox
    Friend WithEvents tb_gxfjxx_ID As System.Windows.Forms.TextBox
    Friend WithEvents lbGybs As System.Windows.Forms.Label
    Friend WithEvents tb_gxfjxx_isbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rowBs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
