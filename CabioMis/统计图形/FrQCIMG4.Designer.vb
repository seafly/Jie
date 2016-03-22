<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrQCIMG4
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.showl = New System.Windows.Forms.DataGridView()
        Me.ToExcel = New System.Windows.Forms.Button()
        Me.Buttonunload = New System.Windows.Forms.Button()
        Me.ToChartImg = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
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
        Me.GroupBox1.Location = New System.Drawing.Point(11, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(893, 226)
        Me.GroupBox1.TabIndex = 109
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
        Me.showl.Size = New System.Drawing.Size(887, 206)
        Me.showl.TabIndex = 66
        '
        'ToExcel
        '
        Me.ToExcel.Location = New System.Drawing.Point(655, 8)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(91, 23)
        Me.ToExcel.TabIndex = 107
        Me.ToExcel.Text = "导出为Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'Buttonunload
        '
        Me.Buttonunload.Location = New System.Drawing.Point(829, 9)
        Me.Buttonunload.Name = "Buttonunload"
        Me.Buttonunload.Size = New System.Drawing.Size(72, 23)
        Me.Buttonunload.TabIndex = 106
        Me.Buttonunload.Text = "关闭"
        Me.Buttonunload.UseVisualStyleBackColor = True
        '
        'ToChartImg
        '
        Me.ToChartImg.Location = New System.Drawing.Point(752, 9)
        Me.ToChartImg.Name = "ToChartImg"
        Me.ToChartImg.Size = New System.Drawing.Size(71, 23)
        Me.ToChartImg.TabIndex = 108
        Me.ToChartImg.Text = "导出图"
        Me.ToChartImg.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(543, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 23)
        Me.Button2.TabIndex = 105
        Me.Button2.Text = "按生产代码查询"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(327, 10)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(90, 20)
        Me.ComboBox1.TabIndex = 104
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(181, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "至"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(204, 10)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(117, 21)
        Me.DateTimePicker2.TabIndex = 102
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(57, 10)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(114, 21)
        Me.DateTimePicker1.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "时间"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"含量", "表面油", "过氧化值", "水分", "灰份", "色泽L", "色泽a", "色泽b", "粒度%（20目）", "粒度%（40目）"})
        Me.ComboBox2.Location = New System.Drawing.Point(423, 10)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(110, 20)
        Me.ComboBox2.TabIndex = 110
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(211, 52)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(90, 20)
        Me.ComboBox3.TabIndex = 111
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(307, 52)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(110, 20)
        Me.ComboBox4.TabIndex = 112
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(543, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 113
        Me.Button1.Text = "按产品代码查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"表面油", "含量", "过氧化值(ARA≤5.0%,DHA≤2.0%meq/Kg)", "水分", "灰份", "焦粒子(≤C级)", "色泽L", "色泽a", "色泽b", "粒度%（20目）", "粒度%（40目）", "菌落总数(ARA/DHA≤1000cfu/g,)", "大肠菌群(ARA/DHA<0.3MPN/g)", "EB(ARA/DHA≤2/5*10g)", "ES(不得检出)", "霉菌(ARA/DHA≤25cfu/g)", "酵母(ARA/DHA≤25cfu/g)", "三聚氰胺", "抗生素", "β-内酰胺酶", "黄曲霉素M1", "含油率"})
        Me.ComboBox5.Location = New System.Drawing.Point(423, 50)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(110, 20)
        Me.ComboBox5.TabIndex = 110
        '
        'FrQCIMG4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 573)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.Buttonunload)
        Me.Controls.Add(Me.ToChartImg)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "FrQCIMG4"
        Me.Text = "QC图形四"
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
    Friend WithEvents ToChartImg As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
End Class
