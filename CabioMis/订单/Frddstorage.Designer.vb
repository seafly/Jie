<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frddstorage
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.num = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cplb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mingc = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.kc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.jiagdm = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.TextBox()
        Me.StorageOne = New System.Windows.Forms.TextBox()
        Me.ButtonOne = New System.Windows.Forms.Button()
        Me.tbname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_x825p_rkbz = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.sykczl = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(12, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "批号"
        '
        'num
        '
        Me.num.Location = New System.Drawing.Point(43, 58)
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Size = New System.Drawing.Size(66, 21)
        Me.num.TabIndex = 128
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(127, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "产品类型"
        '
        'cplb
        '
        Me.cplb.Location = New System.Drawing.Point(186, 58)
        Me.cplb.Name = "cplb"
        Me.cplb.ReadOnly = True
        Me.cplb.Size = New System.Drawing.Size(71, 21)
        Me.cplb.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(263, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "产品代码"
        '
        'mingc
        '
        Me.mingc.Location = New System.Drawing.Point(322, 58)
        Me.mingc.Name = "mingc"
        Me.mingc.ReadOnly = True
        Me.mingc.Size = New System.Drawing.Size(80, 21)
        Me.mingc.TabIndex = 132
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(398, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 26)
        Me.Button1.TabIndex = 234
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'kc
        '
        Me.kc.Location = New System.Drawing.Point(206, 15)
        Me.kc.Name = "kc"
        Me.kc.Size = New System.Drawing.Size(56, 21)
        Me.kc.TabIndex = 236
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(408, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = "加工代码"
        '
        'jiagdm
        '
        Me.jiagdm.Location = New System.Drawing.Point(467, 58)
        Me.jiagdm.Name = "jiagdm"
        Me.jiagdm.ReadOnly = True
        Me.jiagdm.Size = New System.Drawing.Size(76, 21)
        Me.jiagdm.TabIndex = 237
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(159, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "出库数"
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(467, 137)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(34, 21)
        Me.id.TabIndex = 241
        Me.id.Visible = False
        '
        'StorageOne
        '
        Me.StorageOne.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StorageOne.Location = New System.Drawing.Point(341, 14)
        Me.StorageOne.Name = "StorageOne"
        Me.StorageOne.Size = New System.Drawing.Size(35, 23)
        Me.StorageOne.TabIndex = 470
        Me.StorageOne.Visible = False
        '
        'ButtonOne
        '
        Me.ButtonOne.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonOne.Location = New System.Drawing.Point(277, 10)
        Me.ButtonOne.Name = "ButtonOne"
        Me.ButtonOne.Size = New System.Drawing.Size(58, 26)
        Me.ButtonOne.TabIndex = 469
        Me.ButtonOne.Text = "仓库 "
        Me.ButtonOne.UseVisualStyleBackColor = True
        '
        'tbname
        '
        Me.tbname.Location = New System.Drawing.Point(467, 98)
        Me.tbname.Name = "tbname"
        Me.tbname.Size = New System.Drawing.Size(34, 21)
        Me.tbname.TabIndex = 471
        Me.tbname.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(10, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 473
        Me.Label5.Text = "备注"
        '
        'tb_x825p_rkbz
        '
        Me.tb_x825p_rkbz.Location = New System.Drawing.Point(45, 98)
        Me.tb_x825p_rkbz.Name = "tb_x825p_rkbz"
        Me.tb_x825p_rkbz.Size = New System.Drawing.Size(416, 70)
        Me.tb_x825p_rkbz.TabIndex = 474
        Me.tb_x825p_rkbz.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 12)
        Me.Label6.TabIndex = 476
        '
        'sykczl
        '
        Me.sykczl.Location = New System.Drawing.Point(95, 14)
        Me.sykczl.Name = "sykczl"
        Me.sykczl.ReadOnly = True
        Me.sykczl.Size = New System.Drawing.Size(56, 21)
        Me.sykczl.TabIndex = 475
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(12, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 477
        Me.Label7.Text = "剩余库存重量"
        '
        'Frddstorage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 207)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.sykczl)
        Me.Controls.Add(Me.tb_x825p_rkbz)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbname)
        Me.Controls.Add(Me.StorageOne)
        Me.Controls.Add(Me.ButtonOne)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.jiagdm)
        Me.Controls.Add(Me.kc)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.mingc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cplb)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.num)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frddstorage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "订单提取仓库信息"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents num As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cplb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mingc As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents kc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents jiagdm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.TextBox
    Friend WithEvents StorageOne As System.Windows.Forms.TextBox
    Friend WithEvents ButtonOne As System.Windows.Forms.Button
    Friend WithEvents tbname As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_x825p_rkbz As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents sykczl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
