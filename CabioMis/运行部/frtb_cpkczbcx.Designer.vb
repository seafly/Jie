<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frtb_cpkczbcx
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.yue1 = New System.Windows.Forms.ComboBox
        Me.nian1 = New System.Windows.Forms.ComboBox
        Me.Buttsearch = New System.Windows.Forms.Button
        Me.Buttonunload = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.showl = New System.Windows.Forms.DataGridView
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.ToChartImg = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.showl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ToChartImg)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.yue1)
        Me.GroupBox1.Controls.Add(Me.nian1)
        Me.GroupBox1.Controls.Add(Me.Buttsearch)
        Me.GroupBox1.Controls.Add(Me.Buttonunload)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 58)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(388, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 61
        Me.Button3.Text = "删除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(178, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "月"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(97, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "年"
        '
        'yue1
        '
        Me.yue1.DropDownHeight = 150
        Me.yue1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.yue1.FormattingEnabled = True
        Me.yue1.IntegralHeight = False
        Me.yue1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.yue1.Location = New System.Drawing.Point(120, 12)
        Me.yue1.Name = "yue1"
        Me.yue1.Size = New System.Drawing.Size(52, 20)
        Me.yue1.TabIndex = 55
        '
        'nian1
        '
        Me.nian1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nian1.FormattingEnabled = True
        Me.nian1.Items.AddRange(New Object() {"2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018"})
        Me.nian1.Location = New System.Drawing.Point(21, 13)
        Me.nian1.Name = "nian1"
        Me.nian1.Size = New System.Drawing.Size(72, 20)
        Me.nian1.TabIndex = 54
        '
        'Buttsearch
        '
        Me.Buttsearch.Location = New System.Drawing.Point(205, 10)
        Me.Buttsearch.Name = "Buttsearch"
        Me.Buttsearch.Size = New System.Drawing.Size(75, 23)
        Me.Buttsearch.TabIndex = 52
        Me.Buttsearch.Text = "查询"
        Me.Buttsearch.UseVisualStyleBackColor = True
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(682, 13)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(72, 23)
        Me.Buttonunload.TabIndex = 39
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(478, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 23)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "生成文件"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "添加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'showl
        '
        Me.showl.AllowUserToAddRows = False
        Me.showl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.showl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.showl.Location = New System.Drawing.Point(12, 64)
        Me.showl.MultiSelect = False
        Me.showl.Name = "showl"
        Me.showl.ReadOnly = True
        Me.showl.RowHeadersVisible = False
        Me.showl.RowTemplate.Height = 23
        Me.showl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.showl.Size = New System.Drawing.Size(767, 290)
        Me.showl.TabIndex = 61
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
        Me.Chart1.Location = New System.Drawing.Point(21, 360)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(758, 290)
        Me.Chart1.TabIndex = 66
        '
        'ToChartImg
        '
        Me.ToChartImg.Location = New System.Drawing.Point(559, 12)
        Me.ToChartImg.Name = "ToChartImg"
        Me.ToChartImg.Size = New System.Drawing.Size(104, 23)
        Me.ToChartImg.TabIndex = 73
        Me.ToChartImg.Text = "导出图形"
        Me.ToChartImg.UseVisualStyleBackColor = True
        '
        'frtb_cpkczbcx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 662)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.showl)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frtb_cpkczbcx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "成品库存周报"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.showl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Buttsearch As System.Windows.Forms.Button
    Friend WithEvents Buttonunload As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents nian1 As System.Windows.Forms.ComboBox
    Friend WithEvents yue1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents showl As System.Windows.Forms.DataGridView
    Private WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ToChartImg As System.Windows.Forms.Button
End Class
