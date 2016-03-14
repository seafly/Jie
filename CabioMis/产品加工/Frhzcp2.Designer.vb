<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frhzcp2
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
        Me.tb_cpdmhz_yxx = New System.Windows.Forms.ComboBox()
        Me.tb_cpdmhz_cpxz = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_cpdmhz_cpdm = New System.Windows.Forms.TextBox()
        Me.tb_cpdmhz_cplx = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_cpdmhz_jgdm = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tb_cpdmhz_cpdmrq = New System.Windows.Forms.TextBox()
        Me.tb_cpdmhz_cpdmczr = New System.Windows.Forms.TextBox()
        Me.tb_cpdmhz_cplb = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tb_cpdmhz_yxx
        '
        Me.tb_cpdmhz_yxx.FormattingEnabled = True
        Me.tb_cpdmhz_yxx.Items.AddRange(New Object() {"有效", "无效"})
        Me.tb_cpdmhz_yxx.Location = New System.Drawing.Point(122, 87)
        Me.tb_cpdmhz_yxx.Name = "tb_cpdmhz_yxx"
        Me.tb_cpdmhz_yxx.Size = New System.Drawing.Size(100, 20)
        Me.tb_cpdmhz_yxx.TabIndex = 58
        '
        'tb_cpdmhz_cpxz
        '
        Me.tb_cpdmhz_cpxz.FormattingEnabled = True
        Me.tb_cpdmhz_cpxz.Items.AddRange(New Object() {"毛油", "成品油", "成品粉", "过程品", "干菌体", "BC成品"})
        Me.tb_cpdmhz_cpxz.Location = New System.Drawing.Point(328, 87)
        Me.tb_cpdmhz_cpxz.Name = "tb_cpdmhz_cpxz"
        Me.tb_cpdmhz_cpxz.Size = New System.Drawing.Size(100, 20)
        Me.tb_cpdmhz_cpxz.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(43, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "有效性"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(246, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "产品性质"
        '
        'tb_cpdmhz_cpdm
        '
        Me.tb_cpdmhz_cpdm.Location = New System.Drawing.Point(122, 31)
        Me.tb_cpdmhz_cpdm.Name = "tb_cpdmhz_cpdm"
        Me.tb_cpdmhz_cpdm.Size = New System.Drawing.Size(100, 21)
        Me.tb_cpdmhz_cpdm.TabIndex = 54
        '
        'tb_cpdmhz_cplx
        '
        Me.tb_cpdmhz_cplx.Location = New System.Drawing.Point(337, 34)
        Me.tb_cpdmhz_cplx.Name = "tb_cpdmhz_cplx"
        Me.tb_cpdmhz_cplx.Size = New System.Drawing.Size(100, 21)
        Me.tb_cpdmhz_cplx.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(31, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "产品代码"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(236, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 12)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "产品/过程品类型"
        '
        'tb_cpdmhz_jgdm
        '
        Me.tb_cpdmhz_jgdm.Location = New System.Drawing.Point(525, 34)
        Me.tb_cpdmhz_jgdm.Name = "tb_cpdmhz_jgdm"
        Me.tb_cpdmhz_jgdm.Size = New System.Drawing.Size(100, 21)
        Me.tb_cpdmhz_jgdm.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(452, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "加工代码"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(337, 138)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 62
        Me.Button2.Text = "关闭"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(175, 138)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 61
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_cpdmhz_cpdmrq
        '
        Me.tb_cpdmhz_cpdmrq.Location = New System.Drawing.Point(539, 121)
        Me.tb_cpdmhz_cpdmrq.Name = "tb_cpdmhz_cpdmrq"
        Me.tb_cpdmhz_cpdmrq.Size = New System.Drawing.Size(73, 21)
        Me.tb_cpdmhz_cpdmrq.TabIndex = 86
        Me.tb_cpdmhz_cpdmrq.Visible = False
        '
        'tb_cpdmhz_cpdmczr
        '
        Me.tb_cpdmhz_cpdmczr.Location = New System.Drawing.Point(433, 121)
        Me.tb_cpdmhz_cpdmczr.Name = "tb_cpdmhz_cpdmczr"
        Me.tb_cpdmhz_cpdmczr.Size = New System.Drawing.Size(73, 21)
        Me.tb_cpdmhz_cpdmczr.TabIndex = 85
        Me.tb_cpdmhz_cpdmczr.Visible = False
        '
        'tb_cpdmhz_cplb
        '
        Me.tb_cpdmhz_cplb.FormattingEnabled = True
        Me.tb_cpdmhz_cplb.Location = New System.Drawing.Point(525, 87)
        Me.tb_cpdmhz_cplb.Name = "tb_cpdmhz_cplb"
        Me.tb_cpdmhz_cplb.Size = New System.Drawing.Size(100, 20)
        Me.tb_cpdmhz_cplb.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(452, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "产品类别"
        '
        'Frhzcp2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 189)
        Me.Controls.Add(Me.tb_cpdmhz_cplb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_cpdmhz_cpdmrq)
        Me.Controls.Add(Me.tb_cpdmhz_cpdmczr)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tb_cpdmhz_jgdm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_cpdmhz_yxx)
        Me.Controls.Add(Me.tb_cpdmhz_cpxz)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_cpdmhz_cpdm)
        Me.Controls.Add(Me.tb_cpdmhz_cplx)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frhzcp2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "产品代码表"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_cpdmhz_yxx As System.Windows.Forms.ComboBox
    Friend WithEvents tb_cpdmhz_cpxz As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_cpdmhz_cpdm As System.Windows.Forms.TextBox
    Friend WithEvents tb_cpdmhz_cplx As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_cpdmhz_jgdm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_cpdmhz_cpdmrq As System.Windows.Forms.TextBox
    Friend WithEvents tb_cpdmhz_cpdmczr As System.Windows.Forms.TextBox
    Friend WithEvents tb_cpdmhz_cplb As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
