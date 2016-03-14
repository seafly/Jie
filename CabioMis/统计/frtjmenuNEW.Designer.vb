<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frtjmenuNEW
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frtjmenuNEW))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HR")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EHS")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("5S")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("采购")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("技术")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("其它报表", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("发酵")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("油剂")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("粉剂")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("运行")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("设备")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("QC")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("日报表", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("油剂")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("粉剂")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("运行")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("设备")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("QC")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("QA")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("月报表", New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("油剂")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("粉剂")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("运行")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("设备")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("周报表", New System.Windows.Forms.TreeNode() {TreeNode21, TreeNode22, TreeNode23, TreeNode24})
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("指标图表")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("自定义报表")
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ModPass = New System.Windows.Forms.ToolStripButton()
        Me.upfilebutton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolHelp = New System.Windows.Forms.ToolStripButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.editqx = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.deletefile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListViewNDP1 = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ListViewNDP2 = New System.Windows.Forms.ListView()
        Me.ListViewNDP3 = New System.Windows.Forms.ListView()
        Me.ListViewNDP4 = New System.Windows.Forms.ListView()
        Me.ListViewNDP5 = New System.Windows.Forms.ListView()
        Me.ListViewNDP6 = New System.Windows.Forms.ListView()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripButton7, Me.ToolStripButton4, Me.ModPass, Me.upfilebutton, Me.ToolStripButton1, Me.ToolHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(871, 39)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton2.Text = "统计报表"
        Me.ToolStripButton2.ToolTipText = "测试"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton3.Text = "综合查询"
        Me.ToolStripButton3.ToolTipText = "测试"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton7.Text = "组合查询"
        Me.ToolStripButton7.ToolTipText = "测试"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(104, 36)
        Me.ToolStripButton4.Text = "自定义查询"
        Me.ToolStripButton4.ToolTipText = "测试"
        '
        'ModPass
        '
        Me.ModPass.Image = CType(resources.GetObject("ModPass.Image"), System.Drawing.Image)
        Me.ModPass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ModPass.Name = "ModPass"
        Me.ModPass.Size = New System.Drawing.Size(92, 36)
        Me.ModPass.Text = "修改密码"
        '
        'upfilebutton
        '
        Me.upfilebutton.Image = CType(resources.GetObject("upfilebutton.Image"), System.Drawing.Image)
        Me.upfilebutton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.upfilebutton.Name = "upfilebutton"
        Me.upfilebutton.Size = New System.Drawing.Size(92, 36)
        Me.upfilebutton.Text = "上传文件"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(68, 36)
        Me.ToolStripButton1.Text = "备注"
        '
        'ToolHelp
        '
        Me.ToolHelp.Image = CType(resources.GetObject("ToolHelp.Image"), System.Drawing.Image)
        Me.ToolHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolHelp.Name = "ToolHelp"
        Me.ToolHelp.Size = New System.Drawing.Size(68, 36)
        Me.ToolHelp.Text = "帮助"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "png-1101.png")
        '
        'editqx
        '
        Me.editqx.Name = "editqx"
        Me.editqx.Size = New System.Drawing.Size(124, 22)
        Me.editqx.Text = "编辑权限"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ListView2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 598)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(871, 100)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "共享文档"
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(3, 17)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(865, 80)
        Me.ListView2.TabIndex = 16
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'deletefile
        '
        Me.deletefile.Name = "deletefile"
        Me.deletefile.Size = New System.Drawing.Size(124, 22)
        Me.deletefile.Text = "删除"
        '
        'ListViewNDP1
        '
        Me.ListViewNDP1.HideSelection = False
        Me.ListViewNDP1.Location = New System.Drawing.Point(169, 42)
        Me.ListViewNDP1.Name = "ListViewNDP1"
        Me.ListViewNDP1.Size = New System.Drawing.Size(699, 123)
        Me.ListViewNDP1.TabIndex = 16
        Me.ListViewNDP1.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.deletefile, Me.editqx})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 48)
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Book.ico")
        Me.ImageList2.Images.SetKeyName(1, "Book2.ico")
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList2
        Me.TreeView1.Location = New System.Drawing.Point(0, 39)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "节点6"
        TreeNode1.Text = "HR"
        TreeNode2.Name = "节点7"
        TreeNode2.Text = "EHS"
        TreeNode3.Name = "节点8"
        TreeNode3.Text = "5S"
        TreeNode4.Name = "节点0"
        TreeNode4.Text = "采购"
        TreeNode5.Name = "节点1"
        TreeNode5.Text = "技术"
        TreeNode6.Name = "NDP1"
        TreeNode6.Text = "其它报表"
        TreeNode7.Name = "节点11"
        TreeNode7.Text = "发酵"
        TreeNode8.Name = "节点12"
        TreeNode8.Text = "油剂"
        TreeNode9.Name = "节点13"
        TreeNode9.Text = "粉剂"
        TreeNode10.Name = "节点14"
        TreeNode10.Text = "运行"
        TreeNode11.Name = "节点15"
        TreeNode11.Text = "设备"
        TreeNode12.Name = "节点16"
        TreeNode12.Text = "QC"
        TreeNode13.Name = "NDP2"
        TreeNode13.Text = "日报表"
        TreeNode14.Name = "节点17"
        TreeNode14.Text = "油剂"
        TreeNode15.Name = "节点18"
        TreeNode15.Text = "粉剂"
        TreeNode16.Name = "节点19"
        TreeNode16.Text = "运行"
        TreeNode17.Name = "节点20"
        TreeNode17.Text = "设备"
        TreeNode18.Name = "节点21"
        TreeNode18.Text = "QC"
        TreeNode19.Name = "节点22"
        TreeNode19.Text = "QA"
        TreeNode20.Name = "NDP3"
        TreeNode20.Text = "月报表"
        TreeNode21.Name = "节点23"
        TreeNode21.Text = "油剂"
        TreeNode22.Name = "节点24"
        TreeNode22.Text = "粉剂"
        TreeNode23.Name = "节点25"
        TreeNode23.Text = "运行"
        TreeNode24.Name = "节点26"
        TreeNode24.Text = "设备"
        TreeNode25.Name = "NDP4"
        TreeNode25.Text = "周报表"
        TreeNode26.Name = "NDP5"
        TreeNode26.Text = "指标图表"
        TreeNode27.Name = "NDP6"
        TreeNode27.Text = "自定义报表"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode13, TreeNode20, TreeNode25, TreeNode26, TreeNode27})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(163, 559)
        Me.TreeView1.TabIndex = 18
        '
        'ListViewNDP2
        '
        Me.ListViewNDP2.HideSelection = False
        Me.ListViewNDP2.Location = New System.Drawing.Point(169, 171)
        Me.ListViewNDP2.Name = "ListViewNDP2"
        Me.ListViewNDP2.Size = New System.Drawing.Size(699, 123)
        Me.ListViewNDP2.TabIndex = 19
        Me.ListViewNDP2.UseCompatibleStateImageBehavior = False
        '
        'ListViewNDP3
        '
        Me.ListViewNDP3.HideSelection = False
        Me.ListViewNDP3.Location = New System.Drawing.Point(169, 300)
        Me.ListViewNDP3.Name = "ListViewNDP3"
        Me.ListViewNDP3.Size = New System.Drawing.Size(699, 123)
        Me.ListViewNDP3.TabIndex = 20
        Me.ListViewNDP3.UseCompatibleStateImageBehavior = False
        '
        'ListViewNDP4
        '
        Me.ListViewNDP4.HideSelection = False
        Me.ListViewNDP4.Location = New System.Drawing.Point(169, 429)
        Me.ListViewNDP4.Name = "ListViewNDP4"
        Me.ListViewNDP4.Size = New System.Drawing.Size(699, 123)
        Me.ListViewNDP4.TabIndex = 21
        Me.ListViewNDP4.UseCompatibleStateImageBehavior = False
        '
        'ListViewNDP5
        '
        Me.ListViewNDP5.HideSelection = False
        Me.ListViewNDP5.Location = New System.Drawing.Point(169, 558)
        Me.ListViewNDP5.Name = "ListViewNDP5"
        Me.ListViewNDP5.Size = New System.Drawing.Size(699, 123)
        Me.ListViewNDP5.TabIndex = 22
        Me.ListViewNDP5.UseCompatibleStateImageBehavior = False
        '
        'ListViewNDP6
        '
        Me.ListViewNDP6.HideSelection = False
        Me.ListViewNDP6.Location = New System.Drawing.Point(169, 687)
        Me.ListViewNDP6.Name = "ListViewNDP6"
        Me.ListViewNDP6.Size = New System.Drawing.Size(699, 123)
        Me.ListViewNDP6.TabIndex = 23
        Me.ListViewNDP6.UseCompatibleStateImageBehavior = False
        '
        'frtjmenuNEW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 698)
        Me.Controls.Add(Me.ListViewNDP6)
        Me.Controls.Add(Me.ListViewNDP5)
        Me.Controls.Add(Me.ListViewNDP4)
        Me.Controls.Add(Me.ListViewNDP3)
        Me.Controls.Add(Me.ListViewNDP2)
        Me.Controls.Add(Me.ListViewNDP1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frtjmenuNEW"
        Me.Text = "报表"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ModPass As System.Windows.Forms.ToolStripButton
    Friend WithEvents upfilebutton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents editqx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents deletefile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewNDP1 As System.Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ListViewNDP2 As System.Windows.Forms.ListView
    Friend WithEvents ListViewNDP3 As System.Windows.Forms.ListView
    Friend WithEvents ListViewNDP4 As System.Windows.Forms.ListView
    Friend WithEvents ListViewNDP5 As System.Windows.Forms.ListView
    Friend WithEvents ListViewNDP6 As System.Windows.Forms.ListView
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
