Public Class frdzxf2

    Private Sub frdzxf2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim cc As ListView = Me.Owner.Controls("listview2")
        Dim zdlx As String = cc.SelectedItems(0).SubItems(3).Text
        If zdlx = "smalldatetime" Or zdlx = "datetime" Then
            TextBox1.ReadOnly = True
        End If
        Dim tj As String = cc.SelectedItems(0).SubItems(4).Text '条件
        Dim px As String = cc.SelectedItems(0).SubItems(5).Text '排序
        Dim loic As String = cc.SelectedItems(0).SubItems(6).Text '逻辑
        With ComboBox1()
            .Items.Add("无")
            Select Case zdlx
                Case "varchar(8000)"
                    .Items.Add("等于") : .Items.Add("不等于")
                    .Items.Add("包含") : .Items.Add("不包含") : .Items.Add("模糊")
                Case "smalldatetime", "datetime"
                    .Items.Add("大于")
                    .Items.Add("小于")
                    .Items.Add("之间")
                Case Else
                    .Items.Add("等于") : .Items.Add("不等于")
                    .Items.Add("大于") : .Items.Add("大于等于")
                    .Items.Add("小于") : .Items.Add("小于等于")
                    .Items.Add("之间")
            End Select
        End With
        Dim tj1 As String = GF_searchchar(tj, "：", "left")
        Dim tj2 As String = GF_searchchar(tj, "：", "right")
        If tj1 = "notexsit" Then
            tj1 = "无" : tj2 = ""
        End If

        TextBox1.Text = tj2
        ComboBox1.Text = tj1
        ComboBox2.Text = px

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "无" Then
            TextBox1.Text = ""
        End If

        Dim cc As ListView = Me.Owner.Controls("listview2")
        Dim zdlx As String = cc.SelectedItems(0).SubItems(3).Text

        '''''''''''''''
        Dim jj As String = ComboBox1.Text & "：" & TextBox1.Text
        'MsgBox(jj & vbCrLf & cc.SelectedItems(0).SubItems(4).Text)
        If jj = cc.SelectedItems(0).SubItems(4).Text Then
            Exit Sub
        End If
        'If (zdlx = "smalldatetime" Or zdlx = "datetime") And isdatejz = True Then
        '    Exit Sub
        'End If
        '''''''''''
        If (zdlx = "smalldatetime" Or zdlx = "datetime") And ComboBox1.Text <> "无" Then
            Dim bb As New Frdxxfdate
            Me.AddOwnedForm(bb)
            bb.ShowDialog()
        End If

    End Sub
  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "无" And TextBox1.Text.Trim = "" Then
            MsgBox("条件内容不能为空！") : Exit Sub
        ElseIf ComboBox1.Text = "无" And TextBox1.Text.Trim <> "" Then
            MsgBox("条件内容必须为空！") : Exit Sub
        End If
        Dim cc As ListView = Me.Owner.Controls("listview2")
        Dim cxlr As String = TextBox1.Text.Trim
        cxlr = Replace(cxlr, "，", ",") '防止中文逗号的出现
        If ComboBox1.Text = "无" Then
            cc.SelectedItems(0).SubItems(4).Text = "无"
        Else
            cc.SelectedItems(0).SubItems(4).Text = ComboBox1.Text & "：" & TextBox1.Text.Trim
        End If
        cc.SelectedItems(0).SubItems(5).Text = ComboBox2.Text
        cc.SelectedItems(0).SubItems(6).Text = ComboBox3.Text
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cc As ListView = Me.Owner.Controls("listview2")
        Dim ylsy As Integer = cc.SelectedItems(0).Index
        cc.Items.RemoveAt(ylsy)
        Me.Close()
    End Sub


End Class