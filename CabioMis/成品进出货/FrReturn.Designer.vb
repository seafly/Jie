<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrReturn
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonTwo = New System.Windows.Forms.Button()
        Me.StorageTwo = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TkTwo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button3.Location = New System.Drawing.Point(242, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 29)
        Me.Button3.TabIndex = 475
        Me.Button3.Text = "执 行"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonTwo
        '
        Me.ButtonTwo.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonTwo.Location = New System.Drawing.Point(178, 4)
        Me.ButtonTwo.Name = "ButtonTwo"
        Me.ButtonTwo.Size = New System.Drawing.Size(55, 29)
        Me.ButtonTwo.TabIndex = 474
        Me.ButtonTwo.Text = "仓 库"
        Me.ButtonTwo.UseVisualStyleBackColor = True
        '
        'StorageTwo
        '
        Me.StorageTwo.Location = New System.Drawing.Point(137, 8)
        Me.StorageTwo.Name = "StorageTwo"
        Me.StorageTwo.Size = New System.Drawing.Size(35, 21)
        Me.StorageTwo.TabIndex = 476
        Me.StorageTwo.Visible = False
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 19)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(844, 193)
        Me.ListView1.TabIndex = 477
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TkTwo
        '
        Me.TkTwo.Location = New System.Drawing.Point(83, 8)
        Me.TkTwo.Name = "TkTwo"
        Me.TkTwo.Size = New System.Drawing.Size(48, 21)
        Me.TkTwo.TabIndex = 479
        Me.TkTwo.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 478
        Me.Label2.Text = "退换货数"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 215)
        Me.GroupBox2.TabIndex = 475
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "订单退货"
        '
        'SSSQX
        '
        Me.SSSQX.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SSSQX.Location = New System.Drawing.Point(317, 4)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(53, 29)
        Me.SSSQX.TabIndex = 480
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(83, 260)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(630, 47)
        Me.RichTextBox1.TabIndex = 489
        Me.RichTextBox1.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 14)
        Me.Label4.TabIndex = 488
        Me.Label4.Text = "备注"
        '
        'FrReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 324)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.ButtonTwo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TkTwo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StorageTwo)
        Me.Controls.Add(Me.Button3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "订单退换货"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ButtonTwo As System.Windows.Forms.Button
    Friend WithEvents StorageTwo As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TkTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
