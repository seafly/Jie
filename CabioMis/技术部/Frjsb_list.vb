Public Class Frjsb_list
    Private namepp As String
    '����Ĺر�
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '����Ĺر�
    End Sub
    Private Sub Frjsb_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("����������") = False Then
            Me.Close() : Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        GF_OpenFaceList2(tsMenu) '�л��˵���رղ˵��ļ���
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        '  Me.namepp = "���"
        '    Me.Text = "�ۼ�" & Me.namepp

        ' showsj()
    End Sub

  


 
    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("������")
    End Sub

 
    'Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
    '    Dim sql As String = "select tb_h195z_ID,tb_h195z_num,tb_h195z_s621k from oil  "
    '    Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        Dim sql1 As String = "update tb_h195z set tb_h195z_s621k=" & dt.Rows(i)(2) & " where tb_h195z_ID=" & dt.Rows(i)(0) & " and tb_h195z_num='" & dt.Rows(i)(1) & "'"
    '        Call GS_upztxx(G_cnnstr, sql1)
    '    Next
    '    MsgBox("wanceng")
    'End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    '�з���Ŀ����
    Private Sub MenuBtYFXMGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBtYFXMGL.Click
        If GF_storelog1("�鿴�з���Ŀ����") = False Then
            Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        Dim nform As New Frjsb_YFXMGL
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Dim aa As New Frcpdmhz
        aa.ShowDialog()
    End Sub
End Class