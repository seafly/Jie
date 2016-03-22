Imports _S = CabioMis.Cl_StrMag
Imports _D = CabioMis.Cl_DataMag
Imports _E = CabioMis.EnumDescription

''' <summary>
''' 根据传来的物料代码显示该物料在所有流程中的使用情况
''' </summary>
Public Class FrListYl_slqk
    Public m_Dt As DataTable
    Private m_DtSel As DataTable

    Private Sub FrListYl_slqk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t1.Value = DateAdd(DateInterval.Month, -1, DateTime.Now)

        If m_Dt.TableName = "使用情况" Then
            t1.Enabled = True
            t2.Enabled = True
            GroupBox2.Text = "使用情况列表"
        Else
            t1.Enabled = False
            t2.Enabled = False
            GroupBox2.Text = "批号列表"
        End If
        showTb(m_Dt)
    End Sub

    Private Sub showTb(pDt As DataTable)
        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq
        menu1.Items.Add("查看使用情况")
        AddHandler menu1.Items(1).Click, AddressOf showSyQk

        AddHandler menu1.Paint, AddressOf checkCd

        GS_DataGridViewbyDb(show1, pDt, True, True, menu1)

        If pDt.TableName = "使用情况" Then
            Dim iSySl As Double = 0
            For Each dr As DataRow In pDt.Rows
                iSySl += dr(en_Tjzd.使用量)
            Next
            Label1.Text = "共有记录" & pDt.Rows.Count & "条，使用量共计" & iSySl
        Else
            Label1.Text = ""
        End If

    End Sub

    Private Sub checkCd(ByVal sender As ContextMenuStrip, ByVal e As System.EventArgs)
        Try
            If m_Dt.TableName = "使用情况" Then
                sender.Items(1).Enabled = False
            Else
                sender.Items(1).Enabled = True
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub showSyQk(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aa As New FrListYl_slqk
        If m_Dt.TableName = "使用情况" Then
            aa.m_Dt = cl_theCl.getShowDtWltj(en_Tjzd.物料代码, en_Tjzd.原料批号)
        Else
            aa.m_Dt = cl_theCl.getShowDtWltj(show1.SelectedRows(0).Cells("tb_i259b_i231a").Value, show1.SelectedRows(0).Cells("tb_i259b_num").Value)
            aa.m_Dt.TableName = "使用情况"
        End If

        aa.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If m_Dt.TableName = "使用情况" Then
            m_DtSel = GF_czmctb(m_Dt, System.Enum.GetName(GetType(en_Tjzd), en_Tjzd.操作时间) & ">#" & GF_gettrqsj(t1.Text) & " 00:00:00# and " & _
                                System.Enum.GetName(GetType(en_Tjzd), en_Tjzd.操作时间) & "<#" & GF_gettrqsj(t2.Text) & " 23:59:59#", "")
            showTb(m_DtSel)
        End If
    End Sub
End Class