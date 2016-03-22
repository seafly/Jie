<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrQCIMG3
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.showl = New System.Windows.Forms.DataGridView
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Buttonunload = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ToChartImg = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.showl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart1.BorderlineWidth = 2
        Me.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.Area3DStyle.Inclination = 40
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.Area3DStyle.Perspective = 9
        ChartArea1.Area3DStyle.Rotation = 25
        ChartArea1.Area3DStyle.WallWidth = 3
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.BackColor = System.Drawing.Color.OldLace
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "Default"
        ChartArea1.ShadowColor = System.Drawing.Color.Transparent
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Enabled = False
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(4, 314)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(823, 320)
        Me.Chart1.TabIndex = 99
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.showl)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(823, 254)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询结果"
        '
        'showl
        '
        Me.showl.AllowUserToAddRows = False
        Me.showl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.showl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.showl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.showl.Location = New System.Drawing.Point(3, 17)
        Me.showl.MultiSelect = False
        Me.showl.Name = "showl"
        Me.showl.RowHeadersVisible = False
        Me.showl.RowTemplate.Height = 23
        Me.showl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showl.Size = New System.Drawing.Size(817, 234)
        Me.showl.TabIndex = 78
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(355, 14)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(91, 23)
        Me.ToExcel.TabIndex = 96
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(538, 15)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(72, 23)
        Me.Buttonunload.TabIndex = 95
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(289, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 23)
        Me.Button1.TabIndex = 94
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 15)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(90, 20)
        Me.ComboBox1.TabIndex = 93
        '
        'ToChartImg
        '
        Me.ToChartImg.Location = New System.Drawing.Point(452, 15)
        Me.ToChartImg.Name = "ToChartImg"
        Me.ToChartImg.Size = New System.Drawing.Size(71, 23)
        Me.ToChartImg.TabIndex = 97
        Me.ToChartImg.Text = "导出图"
        Me.ToChartImg.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(168, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(121, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "批号"
        '
        'FrQCIMG3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 634)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.Buttonunload)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ToChartImg)
        Me.Name = "FrQCIMG3"
        Me.Text = "发酵罐过程跟踪图"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.showl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents showl As System.Windows.Forms.DataGridView
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Buttonunload As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ToChartImg As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
