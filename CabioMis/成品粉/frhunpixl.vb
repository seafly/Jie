Public Class frhunpixl

    Private Sub frhunpixl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_x832p_sykczl as '������',tb_x832p_sykczl as 'ʣ������',tb_x832p_num,tb_x832p_cplb,tb_x832p_ID from vw_x832p where tb_x832p_sykczl>0")
        Call GS_useviewbydb2(ListView1, db1, 4, 90)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = "" : Dim zl As String = "" : Dim zzl As Double = 0 : Dim lb As String = "" : Dim id0 As String = ""
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            If ListView1.CheckedItems(i).SubItems(0).Text > 0 Then
                zzl = zzl + CDbl(ListView1.CheckedItems(i).SubItems(0).Text)
                zl = zl & ListView1.CheckedItems(i).SubItems(0).Text & ","
                ph = ph & ListView1.CheckedItems(i).SubItems(2).Text & ","
                lb = lb & ListView1.CheckedItems(i).SubItems(3).Text & ","
                id0 = id0 & ListView1.CheckedItems(i).SubItems(4).Text & ","
            End If
        Next
        zl = GF_removedh(zl) : ph = GF_removedh(ph)
        lb = GF_removedh(lb) : id0 = GF_removedh(id0)
        Me.Owner.Controls("TextBox1").Text = zl '����ϵ��
        Me.Owner.Controls("tb_x832p_z886r").Text = zzl '������
        Me.Owner.Controls("tb_x832p_num2").Text = ph '����ϵ��
        Me.Owner.Controls("tb_x832p_sbid").Text = id0
        Me.Owner.Controls("TextBox2").Text = lb '��Ʒ���ϵ��
        Me.Close()
    End Sub
    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        If e.Label = Nothing Then
            Exit Sub
        End If
        Dim zl As String = e.Label.ToString
        If IsNumeric(zl) = False Then
            MsgBox("Ӧ����д����") : e.CancelEdit = True : Exit Sub
        End If
        If zl < 0 Then
            MsgBox("Ӧ����д���ڵ���0�����֡�") : e.CancelEdit = True : Exit Sub
        End If
        Dim zsl As Double = ListView1.Items(e.Item).SubItems(1).Text
        If zl > zsl Then
            MsgBox("Ӧ����д��ȡ�������ܴ��ڱ���ʣ������" & zsl & "Kg��") : e.CancelEdit = True : Exit Sub
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class