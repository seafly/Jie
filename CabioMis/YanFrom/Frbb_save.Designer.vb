<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frbb_save
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
        Me.tb_xtszNr_dm = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_xtszNr_mc = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(370, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "报表名称："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_xtszNr_dm
        '
        Me.tb_xtszNr_dm.Location = New System.Drawing.Point(264, 12)
        Me.tb_xtszNr_dm.Name = "tb_xtszNr_dm"
        Me.tb_xtszNr_dm.Size = New System.Drawing.Size(100, 21)
        Me.tb_xtszNr_dm.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "报表编号："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_xtszNr_mc
        '
        Me.tb_xtszNr_mc.FormattingEnabled = True
        Me.tb_xtszNr_mc.Location = New System.Drawing.Point(76, 12)
        Me.tb_xtszNr_mc.Name = "tb_xtszNr_mc"
        Me.tb_xtszNr_mc.Size = New System.Drawing.Size(111, 20)
        Me.tb_xtszNr_mc.TabIndex = 3
        '
        'Frbb_save
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 51)
        Me.Controls.Add(Me.tb_xtszNr_mc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tb_xtszNr_dm)
        Me.Name = "Frbb_save"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "保存报表"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_xtszNr_dm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_xtszNr_mc As System.Windows.Forms.ComboBox
End Class
