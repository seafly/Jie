<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrQA2
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
        Me.Buttdel = New System.Windows.Forms.Button
        Me.t2 = New System.Windows.Forms.ComboBox
        Me.Labelid = New System.Windows.Forms.Label
        Me.Labeltb = New System.Windows.Forms.Label
        Me.t1 = New System.Windows.Forms.DateTimePicker
        Me.t3 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SSSQX = New System.Windows.Forms.Button
        Me.SSSQD = New System.Windows.Forms.Button
        Me.tb_pljh_num = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Buttdel
        '
        Me.Buttdel.Location = New System.Drawing.Point(504, 81)
        Me.Buttdel.Name = "Buttdel"
        Me.Buttdel.Size = New System.Drawing.Size(82, 23)
        Me.Buttdel.TabIndex = 44
        Me.Buttdel.Text = "删除QA数据"
        Me.Buttdel.UseVisualStyleBackColor = True
        '
        't2
        '
        Me.t2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.t2.FormattingEnabled = True
        Me.t2.Location = New System.Drawing.Point(339, 17)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(121, 20)
        Me.t2.TabIndex = 43
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(31, 184)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 42
        Me.Labelid.Text = "Labelid"
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(31, 147)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 41
        Me.Labeltb.Text = "tb_pljh"
        Me.Labeltb.Visible = False
        '
        't1
        '
        Me.t1.Location = New System.Drawing.Point(87, 17)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(138, 21)
        Me.t1.TabIndex = 40
        '
        't3
        '
        Me.t3.Location = New System.Drawing.Point(87, 54)
        Me.t3.Multiline = True
        Me.t3.Name = "t3"
        Me.t3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.t3.Size = New System.Drawing.Size(373, 142)
        Me.t3.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(25, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "结果说明"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(233, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "生产原料审批结果"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(37, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "QA日期"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(504, 147)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(75, 23)
        Me.SSSQX.TabIndex = 35
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(504, 32)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(75, 23)
        Me.SSSQD.TabIndex = 34
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'tb_pljh_num
        '
        Me.tb_pljh_num.Location = New System.Drawing.Point(275, 226)
        Me.tb_pljh_num.Name = "tb_pljh_num"
        Me.tb_pljh_num.Size = New System.Drawing.Size(100, 21)
        Me.tb_pljh_num.TabIndex = 45
        Me.tb_pljh_num.Visible = False
        '
        'FrQA2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 266)
        Me.Controls.Add(Me.tb_pljh_num)
        Me.Controls.Add(Me.Buttdel)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.Labelid)
        Me.Controls.Add(Me.Labeltb)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.t3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SSSQX)
        Me.Controls.Add(Me.SSSQD)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrQA2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "成品粉混批计划QA"
#If DEBUG Then
        Me.Text = Me.Text & "-" & Me.Name
#End If
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Buttdel As System.Windows.Forms.Button
    Friend WithEvents t2 As System.Windows.Forms.ComboBox
    Friend WithEvents Labelid As System.Windows.Forms.Label
    Friend WithEvents Labeltb As System.Windows.Forms.Label
    Friend WithEvents t1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents t3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SSSQX As System.Windows.Forms.Button
    Friend WithEvents SSSQD As System.Windows.Forms.Button
    Friend WithEvents tb_pljh_num As System.Windows.Forms.TextBox
End Class
