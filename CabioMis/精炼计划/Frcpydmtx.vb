Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Frcpydmtx
    Public ID As Integer = 0
    Private g_sycpdmb As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效' order by tb_cpdmhz_cplx,tb_cpdmhz_cpdm,tb_cpdmhz_jgdm asc ") '所有产品代码表
    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Dim cpdmb As DataTable = GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='成品油'")
        GS_bcfbd(cpdmb, 1, cplx)
        cplx.Text = "DOGF"
    End Sub
    Private Sub Frcpydmtx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
    End Sub
    Private Sub tb_h195z_cplb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cplx.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='成品油' and tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, cpdm)
    End Sub

    Private Sub tb_h195z_mingc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cpdm.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(g_sycpdmb, "tb_cpdmhz_cpxz='成品油' and tb_cpdmhz_cplx='" & cplx.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, jiagdm)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As Fr_jljh = Me.Owner
        Dim list As ListView = f.ListView1
        Dim idall As String = ""
        Dim phl As String = ""
        Dim zl As String = ""
        Dim jlmx As String = ""
        Dim hj As Double = 0

        If MsgBox("是否确定执行计划?", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.Yes Then
            For i As Integer = 0 To list.Items.Count - 1
                idall = idall & list.Items(i).SubItems(0).Text & ","
                phl = phl & list.Items(i).SubItems(4).Text & ","
                zl = zl & list.Items(i).SubItems(5).Text & ","
                jlmx = jlmx & list.Items(i).SubItems(4).Text & "/" & list.Items(i).SubItems(5).Text & "#"
                hj = hj + list.Items(i).SubItems(5).Text
                '更新库存
                Dim Sql As String = "update tb_x825pkc set tb_x825pkc_sykczl=tb_x825pkc_sykczl-" & list.Items(i).SubItems(5).Text & "  where  tb_x825pkc_id='" & list.Items(i).SubItems(0).Text & "'"

                DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, Sql)

            Next

            '插入记录到配料
            idall = GF_removedh(idall)

            phl = GF_removedh(phl)
            zl = GF_removedh(zl)
            jlmx = GF_removedh(jlmx)

            Dim ph As String = GF_getnewpath2() '配料批号
            Dim tsql As String = "Insert into tb_mypl(tb_mypl_a953t,tb_mypl_i225a,tb_mypl_num,tb_mypl_num2,tb_mypl_p524h,tb_mypl_v728n,tb_mypl_e95w,tb_mypl_p532i,tb_mypl_q569j,tb_mypl_czrgh,tb_mypl_sbtb,tb_mypl_sbid,tb_mypl_bz,tb_mypl_jiagdm,tb_mypl_mingc,tb_mypl_cplb) values"
            tsql = tsql & "('" & tb_mypl_a953t.Text & "','" & ph & "','" & ph & "','" & phl & "','" & zl & "'," & hj & ",'" & zl & "'," & list.Items.Count & ",'" & jlmx & "','" & G_dlrgh & "','tb_x825pkc','" & idall & "','" & tb_mypl_bz.Text & "','" & jiagdm.Text & "','" & cpdm.Text & "','" & cplx.Text & "')"

            Dim newid As String = GF_upztxx2(G_cnnstr, tsql, "tb_mypl") '得到毛油配料的ID

            '下面依次更新毛油表的下步ID字段
            Dim newidsz() As String = idall.Split(",")
            For i As Integer = 0 To UBound(newidsz)
                GS_gengsb("tb_x825pkc", newidsz(i), "tb_mypl", newid) '更新上步ID
            Next
            GS_storelog3("手工毛油调配：" & ph, "手工毛油调配") '储存到日志
            MsgBox("精炼毛油调配成功！") : Me.Close()
            list.Clear()
        Else
            Exit Sub
        End If
    End Sub
End Class