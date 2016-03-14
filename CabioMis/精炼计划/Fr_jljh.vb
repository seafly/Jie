Imports DeepCode.DeepDoDataTable
Public Class Fr_jljh
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''精炼计划下一步为执行计划
    Dim slbz As Boolean = False

    '查询
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        slbz = True
        showsj()
    End Sub

    Private Sub showsj()
        Dim sql As String
        Dim dt As DataTable
        sql = "select tb_x825pkc_ID,tb_x825pkc_num2,tb_x825pkc_num,tb_x825pkc_jgrq,tb_x825pkc_sykczl,tb_x825pkc_m387e,tb_x825pkc_cplb,tb_x825pkc_mingc,tb_x825pkc_jiagdm from tb_x825pkc where tb_x825pkc_sykczl>0  and tb_x825pkc_jiagdm='S0600'  "
        If slbz = True Then
            sql = sql & " and tb_x825pkc_m387e>" & Chentextzs1.Text & " and tb_x825pkc_m387e<" & Chentextzs2.Text
        End If

        dt = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView2, dt, 0, 0)

        With ListView1
            .Clear() : .Visible = True : .HideSelection = False
            .CausesValidation = False
            .View = View.Details
            .BeginUpdate()
            .Columns.Add("主键", 150, HorizontalAlignment.Center)
            .Columns.Add("产品类型", 150, HorizontalAlignment.Center)
            .Columns.Add("产品代码", 150, HorizontalAlignment.Center)
            .Columns.Add("加工码", 150, HorizontalAlignment.Center)
            .Columns.Add("毛油批号", 150, HorizontalAlignment.Center)
            .Columns.Add("毛油投入量", 150, HorizontalAlignment.Center)

            .EndUpdate()
        End With

    End Sub

    Private Sub Fr_jljh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.Text = "精炼计划"
        showsj()
    End Sub

    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        If ListView2.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim cc As Double
        Try
            cc = InputBox("请输入毛油投入重量", "提示", Me.ListView2.SelectedItems(0).SubItems(4).Text)
        Catch ex As Exception
            MsgBox("请输入数字!") : Exit Sub
        End Try
        Dim dmymx As String = Me.ListView2.SelectedItems(0).SubItems(2).Text '批号
        Dim dkczl As String = cc  '对应扣除重量
        Dim lx As String = ListView2.SelectedItems(0).SubItems(6).Text   '产品类型 
        Dim cpdm As String = ListView2.SelectedItems(0).SubItems(7).Text '产品代码
        Dim jgdm As String = ListView2.SelectedItems(0).SubItems(8).Text '加工码

        Dim sql As String = "select tb_x825pkc_sykczl,tb_x825pkc_id from tb_x825pkc  where tb_x825pkc_sykczl>=" & dkczl & " and tb_x825pkc_id='" & Me.ListView2.SelectedItems(0).SubItems(0).Text & "' "
        Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dttemp.Rows.Count = 0 Then
            MsgBox("该批号剩余库存小于对应扣除的重量:" & dkczl) : Exit Sub
        End If
        Dim n As ListViewItem = ListView1.Items.Add(Me.ListView2.SelectedItems(0).SubItems(0).Text)
        n.SubItems.Add(lx)
        n.SubItems.Add(cpdm)
        n.SubItems.Add(jgdm)
        n.SubItems.Add(dmymx)
        n.SubItems.Add(dkczl)

        Me.ListView2.Items.Remove(Me.ListView2.SelectedItems(0))

    End Sub


    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Me.ListView1.Items.Remove(Me.ListView1.SelectedItems(0))

    End Sub
    '生产精炼计划
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("没有选择毛油！", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim nform As New Frcpydmtx
        Me.tb_mypl_a953t.Text = nform.tb_mypl_a953t.Text
        Me.tb_mypl_bz.Text = nform.tb_mypl_bz.Text
        Me.AddOwnedForm(nform)
        nform.ShowDialog()
    End Sub
End Class