<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fryjzbYS
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToChartImg = New System.Windows.Forms.Button
        Me.ToChartImg2 = New System.Windows.Forms.Button
        Me.Buttonunload = New System.Windows.Forms.Button
        Me.ToExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.yue1 = New System.Windows.Forms.ComboBox
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.ListView1 = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ToChartImg)
        Me.GroupBox1.Controls.Add(Me.ToChartImg2)
        Me.GroupBox1.Controls.Add(Me.Buttonunload)
        Me.GroupBox1.Controls.Add(Me.ToExcel)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.yue1)
        Me.GroupBox1.Controls.Add(Me.nian1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(867, 61)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'ToChartImg
        '
        Me.ToChartImg.Location = New System.Drawing.Point(551, 22)
        Me.ToChartImg.Name = "ToChartImg"
        Me.ToChartImg.Size = New System.Drawing.Size(71, 23)
        Me.ToChartImg.TabIndex = 89
        Me.ToChartImg.Text = "导出图1"
        Me.ToChartImg.UseVisualStyleBackColor = True
        '
        'ToChartImg2
        '
        Me.ToChartImg2.Location = New System.Drawing.Point(639, 22)
        Me.ToChartImg2.Name = "ToChartImg2"
        Me.ToChartImg2.Size = New System.Drawing.Size(71, 23)
        Me.ToChartImg2.TabIndex = 90
        Me.ToChartImg2.Text = "导出图2"
        Me.ToChartImg2.UseVisualStyleBackColor = True
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(728, 22)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(72, 23)
        Me.Buttonunload.TabIndex = 85
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(428, 22)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(104, 23)
        Me.ToExcel.TabIndex = 10
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(334, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(22, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "请选择统计日期时段："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(311, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "月"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(230, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "年"
        '
        'yue1
        '
        Me.yue1.DropDownHeight = 150
        Me.yue1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.yue1.FormattingEnabled = True
        Me.yue1.IntegralHeight = False
        Me.yue1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.yue1.Location = New System.Drawing.Point(253, 22)
        Me.yue1.Name = "yue1"
        Me.yue1.Size = New System.Drawing.Size(52, 20)
        Me.yue1.TabIndex = 0
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian1.Location = New System.Drawing.Point(151, 22)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(72, 20)
        Me.nian1.TabIndex = 0
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
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Enabled = False
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(424, 403)
        Me.Chart1.TabIndex = 68
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart2.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart2.BorderlineWidth = 2
        Me.Chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea2.Area3DStyle.Inclination = 40
        ChartArea2.Area3DStyle.IsClustered = True
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea2.Area3DStyle.Perspective = 9
        ChartArea2.Area3DStyle.Rotation = 25
        ChartArea2.Area3DStyle.WallWidth = 3
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.BackColor = System.Drawing.Color.OldLace
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BackSecondaryColor = System.Drawing.Color.White
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.Name = "Default"
        ChartArea2.ShadowColor = System.Drawing.Color.Transparent
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Enabled = False
        Legend2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Default"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(0, 0)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Size = New System.Drawing.Size(412, 403)
        Me.Chart2.TabIndex = 69
        '
        'ListView1
        '
        Me.ListView1.AllowUserToAddRows = False
        Me.ListView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ListView1.Location = New System.Drawing.Point(12, 67)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ReadOnly = True
        Me.ListView1.RowHeadersVisible = False
        Me.ListView1.RowTemplate.Height = 23
        Me.ListView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListView1.Size = New System.Drawing.Size(843, 311)
        Me.ListView1.TabIndex = 70
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Location = New System.Drawing.Point(12, 384)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 403)
        Me.Panel1.TabIndex = 71
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Chart2)
        Me.Panel2.Location = New System.Drawing.Point(443, 384)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(412, 403)
        Me.Panel2.TabIndex = 72
        '
        'fryjzbYS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 799)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "fryjzbYS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "油剂生产周报"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents yue1 As System.Windows.Forms.ComboBox
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Private WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Buttonunload As System.Windows.Forms.Button
    Private WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ListView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToChartImg As System.Windows.Forms.Button
    Friend WithEvents ToChartImg2 As System.Windows.Forms.Button
End Class
