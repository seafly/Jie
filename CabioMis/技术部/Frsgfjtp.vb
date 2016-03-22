Public Class Frsgfjtp
    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' ")
        GS_bcfbd(dt, 1, tb_x823p_cplb)
    End Sub

    Private Sub tb_x825p_cplb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x823p_cplb.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "' ")
        GS_bcfbd(dt, 2, tb_x823p_mingc)

    End Sub
    Private Sub tb_x825p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x823p_mingc.SelectedIndexChanged

        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & tb_x823p_cplb.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_x823p_jiagdm)

    End Sub
    Private Sub Frsgfjtp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")
        tb_x823p_th.Text = "普粉配料单"
        showsj()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
       
        If MsgBox("请确认生产代码和加工代码是否正确？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
     
        '''''''''''''''''''''''''''''
        If GF_storelog1("手工粉剂调配") = False Then
            Exit Sub
        End If ' 判断是否有权限         

        '成品油库存批号
        Dim t1 As String = TextBox1.Text.Trim
        t1 = Replace(t1, "，", ",")
        t1 = GF_removedh(t1)
        Dim myphxl() As String = Split(t1, ",")
        '''''''''''''''

        ''''''成品油库存扣除对应批号重量
        Dim t2 As String = TextBox2.Text.Trim
        t2 = Replace(t2, "，", ",")
        If Microsoft.VisualBasic.Right(t2, 1) <> "," Then
            MsgBox("是否末尾加了逗号如 a,或者a,b,")
            Return
        End If
        t2 = GF_removedh(t2)
        Dim myphxl2() As String = Split(t2, ",")

        '成品油库存ID
        Dim t3 As String = TextBox3.Text.Trim
        t3 = Replace(t3, "，", ",")
        t3 = GF_removedh(t3)
        Dim newidsz() As String = t3.Split(",")

        ''''''''' '成品油库存ID数组
        If UBound(myphxl) <> UBound(myphxl2) Or UBound(myphxl2) <> UBound(newidsz) Or UBound(myphxl) <> UBound(newidsz) Then
            MsgBox("ID,批号，扣除重量不是一一对应关系") : Exit Sub
            Return
        End If



        '设定塔配料批号
        Dim qztemp As String = ClassPhgn.ClassPhgn_Get(tb_x823p_th.Text, "-") '得到当前批号+1的批号
        Dim strTh As String = ""   '塔号
        Select Case Microsoft.VisualBasic.Left(tb_x823p_th.Text, 1)
            Case "普"
                If tb_x823p_cplb.Text = "DPGE" Then
                    qztemp = ClassPhgn.ClassPhgn_Get("34号DHA配料单", "-") '得到当前批号+1的批号
                Else
                    qztemp = ClassPhgn.ClassPhgn_Get("34号塔配料单", "-") '得到当前批号+1的批号
                End If
                strTh = "34号塔"
            Case "优"
                If tb_x823p_cplb.Text = "DPGE" Then
                    qztemp = ClassPhgn.ClassPhgn_Get("5号DHA配料单", "-") '得到当前批号+1的批号
                Else
                    qztemp = ClassPhgn.ClassPhgn_Get("5号塔配料单", "-") '得到当前批号+1的批号
                End If
                strTh = "5号塔"
            Case Else
        End Select
        If qztemp = "" Then
            MsgBox("批号设定不正确") : Exit Sub
        End If
        Dim ph As String = qztemp
        If MsgBox("将生成新的配料批号：" & ph, 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''

        Dim hjzl As Double = 0 '合计重量
        Dim sqltemp As String = Nothing
        Try
            For i As Integer = 0 To UBound(newidsz)
                Dim sbid As String = newidsz(i) '上步ID
                Dim dmymx As String = myphxl(i) '批号
                Dim dkczl As Double = CType(myphxl2(i), Double) '对应扣除重量

                '判断成品油库存

                Dim sql As String = "select tb_h195zkc_sykczl,tb_h195zkc_num from tb_h195zkc  where tb_h195zkc_sykczl>=" & dkczl & " and tb_h195zkc_id ='" & sbid & "'"
                Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                If dttemp.Rows.Count = 0 Then
                    MsgBox("不存在该批号:" & dmymx & "或者该批号剩余库存小于对应扣除的重量:" & dkczl) : Exit Sub

                Else

                    '更新库存
                    If tb_x823p_th.Text = "1号塔配料单" Or tb_x823p_th.Text = "普粉配料单" Then
                        hjzl = hjzl + dkczl '实际扣除重量

                        sql = "update tb_h195zkc set tb_h195zkc_sykczl=tb_h195zkc_sykczl-" & dkczl & "  where  tb_h195zkc_id ='" & sbid & "'" & vbCrLf
                        sqltemp = sqltemp & sql
                    Else
                        sqltemp = Nothing
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

        '插入记录到粉剂配料

        Dim tsql As String = sqltemp & vbCrLf & "Insert into tb_x823p(tb_x823p_dpzl,tb_x823p_cfsl,tb_x823p_th,tb_x823p_t678l,tb_x823p_num2,tb_x823p_jgrq,tb_x823p_num,tb_x823p_kczl,tb_x823p_cplb,tb_x823p_jhhl,tb_x823p_czrgh,tb_x823p_sbtb,tb_x823p_sbid,tb_x823p_mingc,tb_x823p_jiagdm,tb_x823p_dpmx) values"
        tsql &= "(" & Chentextintz2.Text & "," & Chentextintz1.Text & ",'" & strTh & "'," & hjzl & ",'" & t1 & "','" & tb_x823p_jgrq.Text & "','" & ph & "','" & t2 & "','" & tb_x823p_cplb.Text & "'," & tb_x823p_jhhl.Text & ",'" & G_dlrgh & "','tb_h195zkc','" & t3 & "','" & tb_x823p_mingc.Text & "','" & tb_x823p_jiagdm.Text & "','" & tb_x823p_dpmx.Text & "')"


        '更新成品油库存下步ID
        Try

            Dim newid As String = GF_upztxx2(G_cnnstr, tsql, "tb_x823p") '更新'得到配料的ID

            For i As Integer = 0 To UBound(newidsz)
                GS_gengsb("tb_h195zkc", newidsz(i), "tb_x823p", newid) '更新上步ID
            Next

            Select Case Microsoft.VisualBasic.Left(tb_x823p_th.Text, 1)
                Case "普"
                    If tb_x823p_cplb.Text = "DPGE" Then
                        ClassPhgn.ClassPhgn_SetDqz2("34号DHA配料单") '使当前批号+1
                    Else
                        ClassPhgn.ClassPhgn_SetDqz2("34号塔配料单") '使当前批号+1
                    End If
                Case "优"
                    If tb_x823p_cplb.Text = "DPGE" Then
                        ClassPhgn.ClassPhgn_SetDqz2("5号DHA配料单") '使当前批号+1
                    Else
                        ClassPhgn.ClassPhgn_SetDqz2("5号塔配料单") '使当前批号+1
                    End If
                Case Else
            End Select
            GS_storelog3("手工粉剂调配：" & ph, "手工粉剂调配") '储存到日志
            MsgBox("手工粉剂调配成功！") : addpljhsj() : Me.Close()
        Catch ex As Exception
            MsgBox("数据插入出现错误，请检查数据",MsgBoxStyle.Exclamation) : Exit Sub
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub addpljhsj()
        Dim inid As Integer
        Dim dtx As DataTable = GF_CreateDataSource(G_cnnstr, "select top 1 tb_x823p_id from tb_x823p  order by  tb_x823p_id DESC ")
        inid = dtx.Rows(0)(0)
        If tb_x823p_th.Text = "5号塔配料" Then
            Dim nform1 As New Faddfjpl5
            nform1.Labeltb.Text = "tb_x823p"
            nform1.Labelid.Text = inid
            nform1.ShowDialog()
        Else
            Dim nform As New Fraddfjpl
            nform.Labeltb.Text = "tb_x823p"
            nform.Labelid.Text = inid
            nform.ShowDialog()
        End If
    End Sub

    Private Sub Chentextintz1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chentextintz1.Leave
        '创建于2010.4.28
        Try
            Dim strZl As String = ""
            strZl = Me.TextBox2.Text.Trim
            If Microsoft.VisualBasic.Right(strZl, 1) = "," Then
                strZl = Microsoft.VisualBasic.Left(strZl, strZl.Length - 1)
            End If

            If InStr(strZl, ",") > 0 Then
                Dim a() As String = Split(strZl, ",")
                Dim mx As String = ""
                Dim sum As Double = 0

                For i As Integer = 0 To a.Length - 1
                    sum = sum + a(i)
                    mx &= a(i) / Chentextintz1.Text & ","
                Next
                Chentextintz2.Text = sum / Chentextintz1.Text
                mx = GF_removedh(mx)
                tb_x823p_dpmx.Text = mx
            Else
                Chentextintz2.Text = Me.TextBox2.Text / Chentextintz1.Text
                tb_x823p_dpmx.Text = Me.TextBox2.Text / Chentextintz1.Text
            End If
        Catch ex As Exception
            Chentextintz2.Text = 0
        End Try
    End Sub
    Private Sub showsj()
        'Dim sql As String = "select tb_h195zkc_id,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,tb_h195zkc_c6u,tb_h195zkc_ckcl from tb_h195zkc where tb_h195zkc_sykczl>0 and tb_h195zkc_yg='生产'"
        'Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        'GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
        'GroupBox1.Text = "成品油库存：" & dt.Rows.Count & "条记录"
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        TextBox1.Text &= ListView1.SelectedRows(0).Cells(1).Value & "," '成品油批号
        TextBox3.Text &= ListView1.SelectedRows(0).Cells(0).Value & "," '成品油ID序列
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql As String = "select tb_h195zkc_id,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,[DHA含量/(w/%)],tb_h195zkc_ckcl,tb_h195zkc_kdlk,tb_h195zkc_cw,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk from tb_h195zkc  as a left join dbo.vw_CpyAndQcData as b on (a.tb_h195zkc_num=b.tb_h195z_num  And a.tb_h195zkc_cplb = b.tb_h195z_cplb and a.tb_h195zkc_mingc=b.tb_h195z_mingc and tb_h195zkc_jiagdm=b.tb_h195z_jiagdm) where tb_h195zkc_sykczl>0 and tb_h195zkc_yg='生产' and tb_h195zkc_qaspjg='合格' and tb_h195zkc_cplb='DOGF'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
        GroupBox1.Text = "DHA成品油库存：" & dt.Rows.Count & "条记录"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sql As String = "select tb_h195zkc_id,tb_h195zkc_num,tb_h195zkc_sykczl,tb_h195zkc_cplb,tb_h195zkc_mingc,tb_h195zkc_jiagdm,tb_h195zkc_c6u,tb_h195zkc_ckcl,tb_h195zkc_kdlk,tb_h195zkc_cw,tb_h195zkc_storagemslk,tb_h195zkc_storagewzlk from tb_h195zkc where tb_h195zkc_sykczl>0 and tb_h195zkc_yg='生产' and tb_h195zkc_qaspjg='合格' and tb_h195zkc_cplb<>'DOGF'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(ListView1, dt, "0", True, True)
        GroupBox1.Text = "ARA成品油库存：" & dt.Rows.Count & "条记录"
    End Sub
End Class