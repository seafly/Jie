Public Class Frqjface

    Private Sub Frqjface_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon

        Me.BackgroundImage = Image.FromFile(Application.StartupPath() & "\image\sub1.jpg")
    End Sub
    Private Sub changefacego(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, PictureBox10.Click,
        PictureBox11.Click, PictureBox12.Click, PictureBox2.Click, PictureBox3.Click, PictureBox4.Click, PictureBox5.Click,
        PictureBox6.Click, PictureBox7.Click, PictureBox8.Click, PictureBox9.Click, PictureBox13.Click
        Dim nform As New Form
        Select Case CType(sender, Control).Name
            Case "PictureBox4" : nform = New Frshow_list '油剂部界面
            Case "PictureBox7" : nform = New Frfenji_list '粉剂部界面
            Case "PictureBox1" : nform = New Frjsb_list '技术部界面
            Case "PictureBox8" : nform = New Frqalist 'QA界面
            Case "PictureBox2" : nform = New Frqc_list 'QC界面
            Case "PictureBox6" : nform = New Frsbdllist 'EHS界面
            Case "PictureBox9" : nform = New Frehslist '设备动力部界面
            Case "PictureBox5" : nform = New Fryllist '运行部界面
            Case "PictureBox3" : nform = New Frcgrzlist '采购部界面
            Case "PictureBox12" : nform = New Frrlzy '人力资源部界面
            Case "PictureBox10" : nform = New frtjmenuNEW '报表界面
            Case "PictureBox22" : nform = New Frqjface '全局界面
            Case "PictureBox11" : nform = New Fradminlist '系统管理界面
            Case "PictureBox13" : nform = New FrbcList 'BC
        End Select
        nform.Show() : Me.Close()
    End Sub
End Class