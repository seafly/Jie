Public Class frShowyllbYS

    Private Sub frShowyllbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_yllb_lb from tb_yllb group by tb_yllb_lb")
        GS_wlbktlr2(Me.tb_yllb_lb, dt, 0, "")
        Me.tb_yllb_yxx.Items.Add("ȫ��")
        Me.tb_yllb_yxx.Items.Add("��Ч")
        Me.tb_yllb_yxx.Items.Add("��Ч")
        showListview("select * from tb_yllb order by tb_yllb_dm")
        tb_yllb_yxx.SelectedIndex = 1
    End Sub

    Public Sub showListview(ByVal sqlStr As String)
        Dim dt As Data.DataTable = GF_CreateDataSource(G_cnnstr, sqlStr)
        'GS_useviewbydb2(Me.ListView1, dt, 0, 0)
        GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nform As New frtb_yllbYS
        nform.actionType = 0
        nform.ShowDialog()
        showListview("select * from tb_yllb order by tb_yllb_dm")
    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    If Me.ListView1.SelectedItems.Count < 1 Then
    '        MessageBox.Show("��ѡ��Ҫ�޸ĵļ�¼��")
    '        Exit Sub
    '    End If
    '    Dim rid As Integer = Integer.Parse(ListView1.SelectedItems(0).SubItems(0).Text)
    '    Dim nform As New frtb_yllbYS
    '    nform.actionType = 1
    '    nform.recordId = rid
    '    nform.ShowDialog()
    '    showListview("select * from tb_yllb")
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    If Me.ListView1.SelectedItems.Count < 1 Then
    '        MessageBox.Show("��ѡ��Ҫ�޸ĵļ�¼��")
    '        Exit Sub
    '    End If
    '    Dim rid As Integer = Integer.Parse(ListView1.SelectedItems(0).SubItems(0).Text)
    '    If MsgBox("ȷ��Ҫɾ���������ݣ�", , MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
    '        GS_upztxx(G_cnnstr, "delete  from tb_yllb where tb_yllb_id=" & rid)
    '    End If
    '    showListview("select * from tb_yllb")
    'End Sub

    Private Sub tb_yllb_lb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_yllb_lb.SelectedIndexChanged
        If Me.tb_yllb_lb.Text = "ȫ��" Then
            If Me.tb_yllb_yxx.Text = "ȫ��" Then
                showListview("select * from tb_yllb order by tb_yllb_dm ")
            Else
                showListview("select * from tb_yllb where tb_yllb_yxx='" & tb_yllb_yxx.Text & "' order by tb_yllb_dm")
            End If

        Else
            If Me.tb_yllb_yxx.Text = "ȫ��" Then
                showListview("select * from tb_yllb where tb_yllb_lb='" & Me.tb_yllb_lb.Text & "' order by tb_yllb_dm")
            Else
                showListview("select * from tb_yllb where tb_yllb_yxx='" & tb_yllb_yxx.Text & "' and tb_yllb_lb='" & Me.tb_yllb_lb.Text & "' order by tb_yllb_dm")
            End If

        End If

    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, Me.Text, Me)
    End Sub

    Private Sub tb_yllb_yxx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_yllb_yxx.SelectedIndexChanged
        If Me.tb_yllb_lb.Text = "ȫ��" Then
            If Me.tb_yllb_yxx.Text = "ȫ��" Then
                showListview("select * from tb_yllb order by tb_yllb_dm")
            Else
                showListview("select * from tb_yllb where tb_yllb_yxx='" & tb_yllb_yxx.Text & "' order by tb_yllb_dm")
            End If

        Else
            If Me.tb_yllb_yxx.Text = "ȫ��" Then
                showListview("select * from tb_yllb where tb_yllb_lb='" & Me.tb_yllb_lb.Text & "' order by tb_yllb_dm")
            Else
                showListview("select * from tb_yllb where tb_yllb_yxx='" & tb_yllb_yxx.Text & "' and tb_yllb_lb='" & Me.tb_yllb_lb.Text & "' order by tb_yllb_dm")
            End If

        End If
    End Sub

 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ListView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If GF_storelog1("��Чԭ�����") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        Dim yldm As String = ListView1.SelectedRows(0).Cells(2).Value
        Dim xzindex As Integer = ListView1.SelectedRows(0).Index
        If MsgBox("ȷʵҪʹ" & yldm & "��Ч��", 1, "����") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''
        Call GS_modczsj("tb_yllb", "tb_yllb_yxx", ListView1.SelectedRows(0).Cells(0).Value, "��Ч")
        ListView1.Rows.RemoveAt(xzindex)
        GS_storelog3("��Чԭ�����" & yldm, "��Чԭ�����") '���浽��־
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.ListView1.SelectedRows.Count < 1 Then
            MessageBox.Show("��ѡ��Ҫ�޸ĵļ�¼��")
            Exit Sub
        End If
        Dim rid As Integer = Integer.Parse(ListView1.SelectedRows(0).Cells(0).Value)
        If MsgBox("ȷ��Ҫɾ���������ݣ�", , MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            GS_upztxx(G_cnnstr, "delete  from tb_yllb where tb_yllb_id=" & rid)
        End If
        showListview("select * from tb_yllb")
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Me.ListView1.SelectedRows.Count < 1 Then
            MessageBox.Show("��ѡ��Ҫ�޸ĵļ�¼��")
            Exit Sub
        End If
        Dim rid As Integer = Integer.Parse(ListView1.SelectedRows(0).Cells(0).Value)
        Dim nform As New frtb_yllbYS
        nform.Controls.Remove(nform.tb_yllb_yxx)
        nform.Controls.Remove(nform.Label4)
        nform.tb_yllb_dm.ReadOnly = True
        nform.tb_yllb_mc.ReadOnly = True
        nform.actionType = 1
        nform.recordId = rid
        nform.ShowDialog()
        showListview("select * from tb_yllb")
    End Sub
End Class