''' <summary>
''' 返工油和粉的混合操作
''' </summary>
''' <remarks></remarks>
Public Class Frfangong
    Private Sub Frfangong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon
        Me.BackgroundImage = G_backimg

        ComboBox1.Items.Add("返工油")
        ComboBox1.Items.Add("返工粉")
        ComboBox1.Text = "返工粉"
        AddHandler ComboBox1.SelectedIndexChanged,AddressOf showList

        showList
    End Sub

    Sub showList()
        'Dim sql As String = "select * from tb_fangong where tb_fangong_tbname='" & IIf(ComboBox1.Text = "返工粉", "tb_x832pkc", "tb_h195zkc") & "'"
        Dim fnkc As String = IIf(ComboBox1.Text = "返工粉", "tb_x832pkc", "tb_h195zkc")
        Dim sql As String = "select " & fnkc & "_id," & fnkc & "_num," & fnkc & "_cjcl," & fnkc & "_cplb," & fnkc & "_mingc," & fnkc & "_jiagdm," & fnkc & "_yg," &
            fnkc & "_sykczl," & fnkc & "_ckcl," & fnkc & "_qaspjg," & fnkc & "_qajgsm, " & fnkc & "_rkbz," & fnkc & "_jgrq," &
            fnkc & "_bzxs," & fnkc & "_rkts," & fnkc & "_kczl," & fnkc & "_bf , " & fnkc & "_bfmx," & fnkc & "_cw," & fnkc & "_num2," &
            fnkc & "_wjbgrq ," & fnkc & "_sykcsm," & fnkc & "_rkrq," & fnkc & "_kdlk," & fnkc & "_bfb," & fnkc & "_storagemslk," &
            fnkc & "_storagewzlk," & fnkc & "_remind," & fnkc & "_fhxz," & fnkc & "_mscw," & fnkc & "_wzcw," & fnkc & "_bfcw " &
            "from " & fnkc & " where " & fnkc & "_cjcl>0 and " & fnkc & "_qaytjy='返工'"
        Dim db1 As DataTable = _D.GF_CreateDataSource(Sql)
        GS_useviewbydb2(ListView1, db1, -1, 90)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tFr As New FrAddfangong
        tFr.tb_fangong_tbname.Text = IIf(ComboBox1.Text = "返工粉", "tb_x832pkc", "tb_h195zkc")
        tFr.Text = "添加" & ComboBox1.Text
        If tFr.ShowDialog = DialogResult.OK Then
            showList()
        End If
    End Sub
End Class