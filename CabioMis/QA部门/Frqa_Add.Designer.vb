<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frqa_Add
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
        Me.qaytjy = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.qczd = New System.Windows.Forms.TextBox()
        Me.qcph = New System.Windows.Forms.TextBox()
        Me.tb_x825p_fhxz = New System.Windows.Forms.TextBox()
        Me.qcbiao = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Buttdel = New System.Windows.Forms.Button()
        Me.t2 = New System.Windows.Forms.ComboBox()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.Labeltb = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.DateTimePicker()
        Me.t3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SSSQX = New System.Windows.Forms.Button()
        Me.SSSQD = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'qaytjy
        '
        Me.qaytjy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.qaytjy.FormattingEnabled = True
        Me.qaytjy.Location = New System.Drawing.Point(412, 4)
        Me.qaytjy.Name = "qaytjy"
        Me.qaytjy.Size = New System.Drawing.Size(77, 20)
        Me.qaytjy.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("宋体", 8.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(487, -14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(232, 11)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "(若此单批对应的成品批整批报废，则此处填0)"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(494, -31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "单批报废重量" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label9.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(586, -39)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 38
        Me.TextBox2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.ListView2)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 318)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(719, 258)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "QC记录"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(713, 238)
        Me.ListView2.TabIndex = 0
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(341, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "QA用途建议"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(528, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "发货限制"
        '
        'qczd
        '
        Me.qczd.Location = New System.Drawing.Point(618, 161)
        Me.qczd.Name = "qczd"
        Me.qczd.Size = New System.Drawing.Size(100, 21)
        Me.qczd.TabIndex = 59
        Me.qczd.Visible = False
        '
        'qcph
        '
        Me.qcph.Location = New System.Drawing.Point(618, 124)
        Me.qcph.Name = "qcph"
        Me.qcph.Size = New System.Drawing.Size(100, 21)
        Me.qcph.TabIndex = 58
        Me.qcph.Visible = False
        '
        'tb_x825p_fhxz
        '
        Me.tb_x825p_fhxz.Location = New System.Drawing.Point(618, 4)
        Me.tb_x825p_fhxz.Name = "tb_x825p_fhxz"
        Me.tb_x825p_fhxz.Size = New System.Drawing.Size(100, 21)
        Me.tb_x825p_fhxz.TabIndex = 57
        '
        'qcbiao
        '
        Me.qcbiao.Location = New System.Drawing.Point(618, 92)
        Me.qcbiao.Name = "qcbiao"
        Me.qcbiao.Size = New System.Drawing.Size(100, 21)
        Me.qcbiao.TabIndex = 56
        Me.qcbiao.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("宋体", 8.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(487, -14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(232, 11)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "(若此单批对应的成品批整批报废，则此处填0)"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(494, -31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "单批报废重量" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label4.Visible = False
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(713, 94)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(586, -39)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 38
        Me.TextBox1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 198)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 114)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "产品数据"
        '
        'Buttdel
        '
        Me.Buttdel.Location = New System.Drawing.Point(530, 124)
        Me.Buttdel.Name = "Buttdel"
        Me.Buttdel.Size = New System.Drawing.Size(82, 23)
        Me.Buttdel.TabIndex = 54
        Me.Buttdel.Text = "删除QA数据"
        Me.Buttdel.UseVisualStyleBackColor = True
        '
        't2
        '
        Me.t2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.t2.FormattingEnabled = True
        Me.t2.Location = New System.Drawing.Point(250, 4)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(77, 20)
        Me.t2.TabIndex = 53
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Location = New System.Drawing.Point(18, 172)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(47, 12)
        Me.Labelid.TabIndex = 52
        Me.Labelid.Text = "Labelid"
        Me.Labelid.Visible = False
        '
        'Labeltb
        '
        Me.Labeltb.AutoSize = True
        Me.Labeltb.Location = New System.Drawing.Point(18, 135)
        Me.Labeltb.Name = "Labeltb"
        Me.Labeltb.Size = New System.Drawing.Size(47, 12)
        Me.Labeltb.TabIndex = 51
        Me.Labeltb.Text = "Label13"
        Me.Labeltb.Visible = False
        '
        't1
        '
        Me.t1.Location = New System.Drawing.Point(74, 5)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(123, 21)
        Me.t1.TabIndex = 50
        '
        't3
        '
        Me.t3.Location = New System.Drawing.Point(74, 42)
        Me.t3.Multiline = True
        Me.t3.Name = "t3"
        Me.t3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.t3.Size = New System.Drawing.Size(415, 142)
        Me.t3.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "结果说明"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(203, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "QA结果"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "QA日期"
        '
        'SSSQX
        '
        Me.SSSQX.Location = New System.Drawing.Point(530, 159)
        Me.SSSQX.Name = "SSSQX"
        Me.SSSQX.Size = New System.Drawing.Size(82, 23)
        Me.SSSQX.TabIndex = 45
        Me.SSSQX.Text = "取消"
        Me.SSSQX.UseVisualStyleBackColor = True
        '
        'SSSQD
        '
        Me.SSSQD.Location = New System.Drawing.Point(530, 90)
        Me.SSSQD.Name = "SSSQD"
        Me.SSSQD.Size = New System.Drawing.Size(82, 23)
        Me.SSSQD.TabIndex = 44
        Me.SSSQD.Text = "确定"
        Me.SSSQD.UseVisualStyleBackColor = True
        '
        'Frqa_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 600)
        Me.Controls.Add(Me.qaytjy)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.qczd)
        Me.Controls.Add(Me.qcph)
        Me.Controls.Add(Me.tb_x825p_fhxz)
        Me.Controls.Add(Me.qcbiao)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Name = "Frqa_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frqa_Add"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents qaytjy As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents qczd As System.Windows.Forms.TextBox
    Friend WithEvents qcph As System.Windows.Forms.TextBox
    Friend WithEvents tb_x825p_fhxz As System.Windows.Forms.TextBox
    Friend WithEvents qcbiao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
End Class
