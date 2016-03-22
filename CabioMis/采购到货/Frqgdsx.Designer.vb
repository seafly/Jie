<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frqgdsx
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
        Me.tb_qgcg_qgdsxrq = New System.Windows.Forms.TextBox()
        Me.tb_qgcg_qgdsfsx = New System.Windows.Forms.ComboBox()
        Me.rq = New System.Windows.Forms.DateTimePicker()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tb_qgcg_ysbm = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_qgcg_tdbz = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_qgcg_qgzt = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tb_qgcg_qgdsxrq
        '
        Me.tb_qgcg_qgdsxrq.Location = New System.Drawing.Point(214, 306)
        Me.tb_qgcg_qgdsxrq.Name = "tb_qgcg_qgdsxrq"
        Me.tb_qgcg_qgdsxrq.Size = New System.Drawing.Size(51, 21)
        Me.tb_qgcg_qgdsxrq.TabIndex = 174
        Me.tb_qgcg_qgdsxrq.Visible = False
        '
        'tb_qgcg_qgdsfsx
        '
        Me.tb_qgcg_qgdsfsx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_qgcg_qgdsfsx.FormattingEnabled = True
        Me.tb_qgcg_qgdsfsx.Items.AddRange(New Object() {"否", "是", "退单"})
        Me.tb_qgcg_qgdsfsx.Location = New System.Drawing.Point(140, 34)
        Me.tb_qgcg_qgdsfsx.Name = "tb_qgcg_qgdsfsx"
        Me.tb_qgcg_qgdsfsx.Size = New System.Drawing.Size(111, 20)
        Me.tb_qgcg_qgdsfsx.TabIndex = 173
        '
        'rq
        '
        Me.rq.Location = New System.Drawing.Point(140, 75)
        Me.rq.Name = "rq"
        Me.rq.Size = New System.Drawing.Size(111, 21)
        Me.rq.TabIndex = 171
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(34, 38)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(89, 12)
        Me.Label29.TabIndex = 179
        Me.Label29.Text = "请购单是否生效"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(34, 79)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(89, 12)
        Me.Label30.TabIndex = 178
        Me.Label30.Text = "请购单生效日期"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(119, 274)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 180
        Me.Button1.Text = "取消"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(38, 274)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 180
        Me.Button2.Text = "确定"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tb_qgcg_ysbm
        '
        Me.tb_qgcg_ysbm.FormattingEnabled = True
        Me.tb_qgcg_ysbm.Location = New System.Drawing.Point(140, 118)
        Me.tb_qgcg_ysbm.Name = "tb_qgcg_ysbm"
        Me.tb_qgcg_ysbm.Size = New System.Drawing.Size(111, 20)
        Me.tb_qgcg_ysbm.TabIndex = 181
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(70, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "验收部门"
        '
        'tb_qgcg_tdbz
        '
        Me.tb_qgcg_tdbz.Location = New System.Drawing.Point(140, 189)
        Me.tb_qgcg_tdbz.Multiline = True
        Me.tb_qgcg_tdbz.Name = "tb_qgcg_tdbz"
        Me.tb_qgcg_tdbz.ReadOnly = True
        Me.tb_qgcg_tdbz.Size = New System.Drawing.Size(111, 63)
        Me.tb_qgcg_tdbz.TabIndex = 182
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(70, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "退单备注"
        '
        'tb_qgcg_qgzt
        '
        Me.tb_qgcg_qgzt.FormattingEnabled = True
        Me.tb_qgcg_qgzt.Location = New System.Drawing.Point(141, 155)
        Me.tb_qgcg_qgzt.Name = "tb_qgcg_qgzt"
        Me.tb_qgcg_qgzt.Size = New System.Drawing.Size(111, 20)
        Me.tb_qgcg_qgzt.TabIndex = 197
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(70, 156)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 196
        Me.Label14.Text = "请购状态"
        '
        'Frqgdsx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 330)
        Me.Controls.Add(Me.tb_qgcg_qgzt)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tb_qgcg_tdbz)
        Me.Controls.Add(Me.tb_qgcg_ysbm)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.tb_qgcg_qgdsxrq)
        Me.Controls.Add(Me.tb_qgcg_qgdsfsx)
        Me.Controls.Add(Me.rq)
        Me.Name = "Frqgdsx"
        Me.Text = "请购单"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_qgcg_qgdsxrq As System.Windows.Forms.TextBox
    Friend WithEvents tb_qgcg_qgdsfsx As System.Windows.Forms.ComboBox
    Friend WithEvents rq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tb_qgcg_ysbm As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_qgcg_tdbz As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_qgcg_qgzt As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
