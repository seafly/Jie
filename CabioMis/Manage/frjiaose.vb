Public Class frjiaose

    Private Sub frjiaose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call cshfr()
    End Sub
    '����Ĺر�
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '����Ĺر�
    End Sub

    Private Sub cshfr()
        ListView2.Visible = False : ComboBox1.Visible = False : Label1.Visible = False : Button1.Visible = False
        'ListView1
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_js")
        Call GS_useviewbydb2(ListView1, db1, -1, 0)
        ListView1.Columns(0).Width = 0
        ListView1.Columns(1).Width = ListView1.Width - 5
        ListView1.Columns(2).Width = 0
        ListView1.Columns(3).Width = 0
        '
        Dim qx1() As String = Split(G_qx1, ",")
        Dim qx2() As String = Split(G_qx2, ",")
        Dim qx3() As String = Split(G_qx3, ",")
        Dim zs As Integer = qx1.Length + qx2.Length + qx3.Length
        Dim qx(zs - 1, 1) As String
        Dim i, j, k As Integer
        For i = 0 To qx1.Length - 1
            qx(i, 0) = qx1(i) : qx(i, 1) = "��Ŀ1"
        Next
        For j = i To i + qx2.Length - 1
            qx(j, 0) = qx2(j - i) : qx(j, 1) = "��Ŀ2"
        Next
        For k = j To j + qx3.Length - 1
            qx(k, 0) = qx3(k - j) : qx(k, 1) = "��Ŀ3"
        Next
        '
        ComboBox1.Items.Add("��Ŀ1")
        ComboBox1.Items.Add("��Ŀ2")
        ComboBox1.Items.Add("��Ŀ3")
        '
        Call showliebiao(ListView2, ImageList1, qx)
    End Sub
    Private Sub showliebiao(ByVal LV1 As ListView, ByVal IL1 As ImageList, ByVal db(,) As String)
        With LV1      'listview��������
            .Items.Clear() : .Groups.Clear() : .MultiSelect = False
            .View = View.LargeIcon '������ʾ��ʽ
            .LargeImageList = IL1 : .ShowItemToolTips = False : .CheckBoxes = True
            '������
            Dim i As Integer
            For i = 0 To db.GetLength(0) - 1
                Dim lvg As ListViewGroup
                lvg = New ListViewGroup(db(i, 1).ToString, HorizontalAlignment.Left)
                .Groups.Add(lvg.ToString, lvg.ToString)
            Next
            '����ImageList
            For m As Integer = 0 To db.GetLength(0) - 1
                .Items.Add(New ListViewItem(db(m, 0).ToString, 0, .Groups(db(m, 1).ToString)))
            Next
        End With
        'SendMessage(LV1.Handle, &H1035, 0, &H10000 * 50 + 50)
    End Sub
    '����Ȩ������
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("����Ȩ������ʧ�ܣ���û��ѡ���ɫ") : Exit Sub
        End If
        Dim jsqx As String = ""
        With ListView2
            For i As Integer = 0 To .Items.Count - 1
                If .Items(i).Checked = True Then
                    jsqx = jsqx & .Items(i).Text & ","
                End If
            Next
        End With
        jsqx = GF_removedh(jsqx)
        Call GS_upztxx(G_cnnstr, "update tb_js set tb_js_qx='" & jsqx & "',tb_js_jm='" & ComboBox1.Text & "'  where tb_js_id =" & ListView1.SelectedItems(0).SubItems(0).Text)
        MsgBox("Ȩ�����óɹ���")
        Call cshfr()
    End Sub

    Private Sub xzsz() 'ѡ����ʾ�༭״̬
        If ListView1.SelectedItems.Count > 0 Then
            ListView2.Visible = True : ComboBox1.Visible = True : Label1.Visible = True : Button1.Visible = True
        Else
            ListView2.Visible = False : ComboBox1.Visible = False : Label1.Visible = False : Button1.Visible = False
            Exit Sub
        End If
        Dim qxzfc As String = ListView1.SelectedItems(0).SubItems(2).Text 'Ȩ���ַ���
        ComboBox1.Text = ListView1.SelectedItems(0).SubItems(3).Text '��½����
        With ListView2
            For i As Integer = 0 To .Items.Count - 1
                If InStr(qxzfc, .Items(i).Text) > 0 Then
                    .Items(i).Checked = True
                Else
                    .Items(i).Checked = False
                End If
            Next
        End With
    End Sub
    '�½���ɫ
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim x As String = InputBox("�������½���ɫ���ƣ�", )
        If x <> "" Then
            '���ҽ�ɫ�����Ƿ��Ѿ�����
            Dim ghh As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_js_mc from tb_js where tb_js_mc='" & x & "'")
            If ghh.Rows.Count > 0 Then
                MsgBox("ʧ�ܣ��ý�ɫ�����Ѵ��������ݿ��У������������ɫ���ƣ�") : Exit Sub
            End If
            '������ɫ
            Dim Sql As String = "Insert into tb_js(tb_js_mc) values('" & x & "')"
            Call GS_upztxx(G_cnnstr, Sql)
            MsgBox("" & x & " ��ɫ�Ѿ��ɹ���������������Ȩ�ޣ�")
            Call cshfr()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub ȫѡ��ĿһToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ȫѡ��ĿһToolStripMenuItem.Click
        With ListView2
            For i As Integer = 0 To .Items.Count - 1
                If InStr(G_qx1, .Items(i).Text) > 0 Then
                    If ȫѡ��ĿһToolStripMenuItem.Text = "ȫѡ��Ŀһ" Then
                        .Items(i).Checked = True
                    Else
                        .Items(i).Checked = False
                    End If
                End If
            Next
            If ȫѡ��ĿһToolStripMenuItem.Text = "ȫѡ��Ŀһ" Then
                ȫѡ��ĿһToolStripMenuItem.Text = "ȡ��ȫѡ��Ŀһ"
            Else
                ȫѡ��ĿһToolStripMenuItem.Text = "ȫѡ��Ŀһ"
            End If
        End With

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Call xzsz()
    End Sub
    'ɾ��
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
      
        Dim xh As String = ListView1.SelectedItems(0).SubItems(0).Text
        Dim r As Integer = MsgBox("ȷ��Ҫɾ��" & ListView1.SelectedItems(0).SubItems(1).Text & "��?", 1, "ȷ��Ҫɾ����?")
        If r = 1 Then
        
            Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
            cnn.Open()
            Dim myread As New Data.OleDb.OleDbCommand
            myread.Connection = cnn
            Dim Sql As String = "delete from tb_js where tb_js_id='" & xh & "'"
            myread.CommandText = Sql : myread.ExecuteNonQuery()
            myread = Nothing : cnn.Close() : cnn = Nothing
            MsgBox("ɾ���ɹ���", MsgBoxStyle.OkOnly)
            Call cshfr()
        End If
    End Sub
End Class