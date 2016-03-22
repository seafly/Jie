Public Class Form5
    Public idxl As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If checkText1() = False Or checkText2() = False Then
            MsgBox("输入数据错误") : Exit Sub
        End If
        Dim Sql As String = Nothing
        Dim xbid As String = Nothing
        Dim ph As String = GF_getnewpath2() '粉剂配料批号
        Dim t1 As String() = TextBox2.Text.Split(",")
        Dim zl As Integer = CDbl(t1(0)) + CDbl(t1(1))

        Sql = "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_sbtb,tb_mypl_sbid) values('" & DateTime.Now & "','" & ph & "','" & ph & "','" & Label2.Text & "','" & TextBox2.Text & "'," & zl & ",'" & TextBox1.Text & "'," & Label1.Text & ",'tb_x825p','" & idxl & "')"
        xbid = GF_upztxx2(G_cnnstr, Sql, "tb_mypl")


        Sql = "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & CDbl(t1(0)) & ",tb_x825p_xbtb='tb_mypl',tb_x825p_glid='" & xbid & "' where tb_x825p_num ='" & ph(0) & "'"
        Sql = Sql & vbCrLf & "update tb_x825p set tb_x825p_sykczl=tb_x825p_sykczl-" & CDbl(t1(1)) & ",tb_x825p_xbtb='tb_mypl',tb_x825p_glid='" & xbid & "' where tb_x825p_ID in(" & ph(1) & ")"
        GS_upztxx(G_cnnstr, Sql)
        Me.Close()
    End Sub

    Private Function checkText1() As Boolean
        Dim t1 As String() = TextBox1.Text.Split(",")
        Dim jj As Double
        If t1.Length > CDbl(Label1.Text) Then
            MsgBox("检测输入项")
            TextBox1.SelectAll()
            TextBox1.Focus()
            checkText1 = False
            Exit Function
        End If
        For i As Integer = 0 To t1.Length - 1

            Try
                jj = CDbl(t1(i))
            Catch
                MsgBox("检测输入项")
                TextBox1.SelectAll()
                TextBox1.Focus()
                checkText1 = False
                Exit Function
            End Try
            If jj <= 0 Then
                MsgBox("检测输入项")
                TextBox1.SelectAll()
                TextBox1.Focus()
                checkText1 = False
                Exit Function
            End If
        Next
        checkText1 = True
    End Function

    Private Function checkText2() As Boolean
        Dim t1 As String() = TextBox2.Text.Split(",")
        Dim jj As Double
        If t1.Length > Label2.Text.Split(",").Length Then
            MsgBox("检测输入项")
            TextBox1.SelectAll()
            TextBox1.Focus()
            checkText2 = False
            Exit Function
        End If
        For i As Integer = 0 To t1.Length - 1
            Try
                jj = CDbl(t1(i))
            Catch
                MsgBox("检测输入项")
                TextBox1.SelectAll()
                TextBox1.Focus()
                checkText2 = False
                Exit Function
            End Try
            If jj <= 0 Then
                MsgBox("检测输入项")
                TextBox1.SelectAll()
                TextBox1.Focus()
                checkText2 = False
                Exit Function
            End If
        Next

        If CDbl(t1(0)) > CDbl(k1.Text) Or CDbl(t1(1)) > CDbl(k2.Text) Then
            MsgBox("检测输入项")
            TextBox2.SelectAll()
            TextBox2.Focus()
            checkText2 = False
            Exit Function
        End If

        checkText2 = True
    End Function

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class