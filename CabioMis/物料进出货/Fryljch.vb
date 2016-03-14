Imports DeepCode.DeepDoDataTable
Imports DeepCode.DeepDoStr
Public Class Fryljch
    Public id As String = "" '原料表的id值
    Public id2 As String = "" '为原料进出货表的id值
    Public qa As String = ""
    Public qc As String = ""
    Public ckcl As Double '仓库存量
    Public sykcl As Double '剩余库存量
    Public m_cjcl As Double '车间存量
    Dim sl As String = Nothing '原来输入的数量
    Dim yt As String = Nothing

    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Dim sql As String = "select tb_bm_p512h from tb_bm" '所有部门表
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dt.Rows.Count - 1
            tb_yljch_bm.Items.Add(dt.Rows(i)(0))
        Next
    End Sub
    Private Sub Fryljch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg


        If id2 <> "" Then ''''进出货显示
            Gs_showsj("tb_yljch", Me, id2)
            sl = tb_yljch_sl.Text
            yt = tb_yljch_yt.Text
        End If
    End Sub
    '物料出货

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If

        If tb_yljch_bm.Text = "" Or tb_yljch_yt.Text = "" Then
            MessageBox.Show("部门和用途必填")
            Exit Sub
        End If

        If tb_yljch_sl.Text = "" Then
            MsgBox("数量不能为空") : Return
        End If

        If tb_yljch_yt.Text = "车间退库" And m_cjcl < tb_yljch_sl.Text Then
            MsgBox("车间退库时，数量不应大于车间存量！")
            Return
        End If

        If id2 = "" Then '添加

            If ChuKu() = False Then
                Exit Sub
            End If
            '扣库存

            Dim jj As String = GF_addsj("tb_yljch", Me, G_cnnstr)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If

            GS_storelog3("添加物料代码" & tb_yljch_dm.Text, "物料进出货添加操作") '储存到日志
            ''''''''''''''''''''''''''''''''''
        Else

            '修改
            If tb_yljch_xgsm.Text.Trim = "" Then
                MsgBox("必须填写修改说明") : Exit Sub
            End If

            Call xgkc(id) '还原库存

            If ChuKu() = False Then
                Exit Sub
            End If

            If GF_modsj("tb_yljch", Me, id2) = False Then ''修改进出货表
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If

            GS_storelog3("修改物料代码" & tb_yljch_dm.Text, "物料进出货修改操作") '储存到日志
        End If
        MessageBox.Show("更新成功！")
        Me.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    '物料出库

    Private Function ChuKu() As Boolean
        'TODO : 冻结的任何操作不能做
        If qa.Equals("冻结") Then
            MessageBox.Show("PA判定冻结，无法做该操作！")
            Return False
        End If
        Select Case tb_yljch_yt.Text

            Case "返厂补货"
                If qa = "合格" Then : MsgBox("QA必须为不合格才能进行返厂补货") : Return False : End If
                Call showqg(id) '传到请购添加界面
                If qa <> "合格" Then : Call yljch2() : End If

            Case "返厂不补货"
                If qa = "合格" Then : MsgBox("QA必须为不合格才能进行返厂不补货") : Return False : End If
                If qa <> "合格" Then : Call yljch2() : End If


            Case "其他出库"
                Call yljch2()


            Case "生产领料"
                If ckcl < CDbl(tb_yljch_sl.Text) Then : MsgBox("仓库存量或剩余库存量小于输入数量") : Return False : End If
                If qa <> "合格" Then
                    MsgBox("QA必须为合格才能用做生产领料") : Return False
                Else
                    Call scll2()
                End If

            Case "车间退库"
                tk2()
            Case "实验退库"
                tk3()
            Case "湖北工厂"
                If qa = "不合格" Then : MsgBox("qa不合格,无法转库！") : Return False : End If
                If tb_yljch_sl.Text.Trim = "" Then : MsgBox("请输入数量") : Return False : End If
                ck2()

            Case "生产"
                If qa <> "合格" Then : MsgBox("QA审核必须为合格才能出货") : Return False : End If
                sc()
        End Select
        Return True
    End Function

    '出货用途为 ：生产

    Private Sub sc()
        Dim sql0 As String = "select tb_i259b_p518h ,tb_i259b_ckcl from tb_i259b where tb_i259b_id='" & id & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql0)
        If dt.Rows(0)("tb_i259b_p518h") = 0 Then
            MsgBox("车间存量为0时不能出货") : Return
        End If
        ''''''''
        If _S.YanFormatNum3(dt.YanDtValue2("tb_i259b_p518h")) < Null2zero(tb_yljch_sl.Text) Then
            MsgBox("数量输入错误！") : Return
        End If

        Dim sql As String = "update tb_i259b set tb_i259b_p518h= tb_i259b_p518h - " & Null2zero(tb_yljch_sl.Text) & " where tb_i259b_id='" & id & "' "
        GS_upztxx(G_cnnstr, sql)

    End Sub

    '出货用途为 ： 返厂补货, 返厂不补货,其他出货

    Private Sub yljch2()
        Dim sql0 As String = "select tb_i259b_ckcl from tb_i259b where tb_i259b_id='" & id & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql0)
        If dt.Rows(0)("tb_i259b_ckcl") = 0 Then
            MsgBox("仓库存量为0时不能出货") : Return
        End If
        If _S.YanFormatNum3(dt.YanDtValue2("tb_i259b_ckcl")) < Null2zero(tb_yljch_sl.Text) Then
            MsgBox("数量输入错误！") : Return
        End If
       
        Dim sql As String = "update tb_i259b set  tb_i259b_ckcl= tb_i259b_ckcl - " & Null2zero(tb_yljch_sl.Text) & "  where tb_i259b_id='" & id & "' "
        GS_upztxx(G_cnnstr, sql)
    
    End Sub

    '出货用途为 ：生产领料

    Private Sub scll2()
        Dim sykczl As Double = tb_yljch_sl.Text
        If tb_yljch_dm.Text = "2.01.007" Then '湖葵花籽油原料请购输入时的单位为KG，在原料入库的时候 把剩余库存转换单位改成L，转换公式为200kg=190L。
            sykczl = tb_yljch_sl.Text / 190 * 200
        End If

        Dim sql0 As String = "select tb_i259b_p518h ,tb_i259b_ckcl from tb_i259b where tb_i259b_id='" & id & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql0)
        If dt.Rows(0)("tb_i259b_ckcl") = 0 Then
            MsgBox("仓库存量为0时不能出货") : Return
        End If
        If _S.YanFormatNum3(dt.YanDtValue2("tb_i259b_ckcl")) < Null2zero(tb_yljch_sl.Text) Then
            MsgBox("数量输入错误！") : Return
        End If

        If tb_yljch_yllb.Text = "包材" And phpd(tb_yljch_dm.Text) = True Then
            Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl - " & Null2zero(tb_yljch_sl.Text) & ",tb_i259b_p518h= tb_i259b_p518h + " & sykczl & " where tb_i259b_id='" & id & "' "
            GS_upztxx(G_cnnstr, sql)
        ElseIf tb_yljch_yllb.Text = "包材" And phpd(tb_yljch_dm.Text) = False Then
            Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl - " & Null2zero(tb_yljch_sl.Text) & ",tb_i259b_p518h= tb_i259b_p518h + " & sykczl & " where tb_i259b_id='" & id & "' "
            GS_upztxx(G_cnnstr, sql)
        Else
            Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl - " & Null2zero(tb_yljch_sl.Text) & ",tb_i259b_p518h= tb_i259b_p518h + " & sykczl & " where tb_i259b_id='" & id & "' "
            GS_upztxx(G_cnnstr, sql)
        End If

    End Sub

    '出货用途为 ： 转库到武汉

    Private Sub ck2()
        '''''湖北操作
        'TODO 
        Dim str As String = "select tb_ylzk_id from tb_ylzk where tb_ylzk_yldm2='" & tb_yljch_dm.Text & "' and tb_ylzk_num ='" & tb_yljch_num.Text & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstrWH, str)
        If _S.YanFormatNum3(dt.YanDtValue2("tb_i259b_ckcl")) < Null2zero(tb_yljch_sl.Text) Then
            MsgBox("数量输入错误！") : Return
        End If
        If dt.Rows.Count > 0 Then
            If MsgBox("该批号和物料代码已向湖北转过库，是否继续？", 1, "提示") <> 1 Then
                Exit Sub
            End If
            Dim sql As String = "update tb_ylzk set tb_ylzk_rkl=tb_ylzk_rkl+ " & tb_yljch_sl.Text & " where  tb_ylzk_yldm2='" & tb_yljch_dm.Text & "' and tb_ylzk_num ='" & tb_yljch_num.Text & "'"
            GS_upztxx(G_cnnstrWH, sql)
        Else
            '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘存入武汉原料表
            Dim yhm, mm, sjk, fwq As String
            Using sr As System.IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
                yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = DeepCode.DeepDoStr.SimpleDecode(sr.ReadLine()) : fwq = sr.ReadLine() : sr.Close()
            End Using

            Dim sql As String
            Dim liccnnts As String = "Data Source=" & fwq & ";User ID=" & yhm & ";Password=" & mm & ""
            sql = "Insert into tb_ylzk (tb_ylzk_lb,tb_ylzk_ylmc,tb_ylzk_yldm2,tb_ylzk_rkl,tb_ylzk_num) values"
            sql &= "(  '" & tb_yljch_yllb.Text & "','" & tb_yljch_mc.Text & "','" & tb_yljch_dm.Text & "'," & tb_yljch_sl.Text & ",'" & tb_yljch_num.Text & "' )"
            GS_upztxx(G_cnnstrWH, sql)
        End If

        '''''武汉操作

        Dim sql0 As String = "update tb_i259b set tb_i259b_ckcl=tb_i259b_ckcl-" & tb_yljch_sl.Text & ""
        sql0 &= "where tb_i259b_id='" & id & "'"
        GS_upztxx(G_cnnstr, sql0)

    End Sub

    ' 出货用途为 ：车间退库
    Private Sub tk2()
        Dim sql0 As String = "select tb_i259b_p518h ,tb_i259b_ckcl from tb_i259b where tb_i259b_id='" & id & "'"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql0)
        If dt.Rows(0)("tb_i259b_p518h") = 0 Then
            MsgBox("车间存量为0时不能出货") : Return
        End If

        Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl + " & Null2zero(tb_yljch_sl.Text) & ",tb_i259b_p518h=tb_i259b_p518h- " & tb_yljch_sl.Text & " where tb_i259b_id='" & id & "' "
        GS_upztxx(G_cnnstr, sql)

    End Sub
    '出库用途为：实验退库
    Private Sub tk3()
        Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl + " & Null2zero(tb_yljch_sl.Text) & " where tb_i259b_id='" & id & "' "
        GS_upztxx(G_cnnstr, sql)
    End Sub

    '如果包材出库涉及下面包材批号时，双击出库 仓库存量和剩余库存同时减.,true为存在该批号，false为不存在

    Public Function phpd(ByVal ph As String) As Boolean
        Dim phxl As String = "3.08.001,3.08.002,3.08.003,,3.08.020,3.08.022"
        phxl = Replace(phxl, ",", "','")
        phxl = "'" & phxl & "'"
        ph = "'" & ph & "'"
        If InStr(phxl, ph) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    '还原库存

    Private Sub xgkc(ByVal id As String)

   
        Dim sl As Double = tb_yljch_sl.Tag '出库原始数量

        Select Case ReductionUse.Text

            Case "返厂补货"

                MsgBox("返工补货修改请直接联系管理员") : Exit Sub

            Case "返厂不补货"
                Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl + " & sl & "  where tb_i259b_id='" & id & "'"
                GS_upztxx(G_cnnstr, sql)

            Case "生产领料"


                If tb_yljch_yllb.Text = "包材" And phpd(tb_yljch_dm.Text) = True Then
                    Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl + " & sl & ",tb_i259b_p518h= tb_i259b_p518h - " & sl & " where tb_i259b_id='" & id & "' "
                    GS_upztxx(G_cnnstr, sql)

                ElseIf tb_yljch_yllb.Text = "包材" And phpd(tb_yljch_dm.Text) = False Then
                    Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl + " & sl & ",tb_i259b_p518h= tb_i259b_p518h - " & sl & " where tb_i259b_id='" & id & "' "
                    GS_upztxx(G_cnnstr, sql)

                Else
                    Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl + " & sl & ",tb_i259b_p518h= tb_i259b_p518h - " & sl & " where tb_i259b_id='" & id & "' "
                    GS_upztxx(G_cnnstr, sql)
                End If


            Case "退库"
                Dim sql As String = "update tb_i259b set tb_i259b_ckcl= tb_i259b_ckcl - " & sl & ",tb_i259b_p518h=tb_i259b_p518h+ " & sl & " where tb_i259b_id='" & id & "'"
                GS_upztxx(G_cnnstr, sql)

            Case "其他出库"

                Dim sql As String = "update tb_i259b set  tb_i259b_ckcl= tb_i259b_ckcl + " & sl & "  where tb_i259b_id='" & id & "'"
                GS_upztxx(G_cnnstr, sql)

            Case "湖北工厂"
                'TODO
                Dim nform As New frzk2
                '更新湖北库存

                Dim sql As String
                sql = "select tb_ylzk_ID from tb_ylzk where tb_ylzk_yldm2='" & tb_yljch_dm.Text & "' and tb_ylzk_num ='" & tb_yljch_num.Text & "'"
                Dim dt As DataTable = GF_CreateDataSource(G_cnnstrWH, sql)
                sql = "update tb_ylzk set tb_ylzk_rkl=tb_ylzk_rkl- " & sl & "  where tb_ylzk_id='" & dt.Rows(0)(0) & "'"
                GS_upztxx(G_cnnstrWH, sql)

                ' 更新武汉

                sql = "update tb_i259b set  tb_i259b_ckcl= tb_i259b_ckcl + " & sl & " where tb_i259b_id='" & id & "' "
                GS_upztxx(G_cnnstr, sql)

            Case "生产"

                Dim sql As String = "update tb_i259b set tb_i259b_p518h= tb_i259b_p518h + " & sl & " where tb_i259b_id='" & id & "' "
                GS_upztxx(G_cnnstr, sql)
        End Select

        MsgBox("更新成功！")

    End Sub
 
 
#Region ""
    '    Private Sub ck() ''''''''''''''''''出库到武汉


    '        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’存入武汉
    '        Dim str As String = "select tb_i259b_id from tb_i259b where tb_i259b_i231a='" & tb_yljch_dm.Text & "' and tb_i259b_num ='" & tb_yljch_num.Text & "'"
    '        Dim dt As DataTable = GF_CreateDataSource(G_cnnstrWH, str)
    '        If dt.Rows.Count > 0 Then
    '            If MsgBox("数据库中存在相同批号和代码的信息，是否继续？", 1, "提示") <> 1 Then
    '                Exit Sub
    '            End If
    '            Dim sql As String = "update tb_i259b set tb_i259b_rkl=tb_i259b_rkl + " & tb_yljch_sl.Text & ",tb_i259b_ckcl=tb_i259b_ckcl+" & tb_yljch_sl.Text & ""
    '            sql &= "where tb_i259b_i231a='" & tb_yljch_dm.Text & "' and tb_i259b_num ='" & tb_yljch_num.Text & "'"
    '            GS_upztxx(G_cnnstrWH, sql)
    '        Else
    '            '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘存入武汉原料表
    '            Dim yhm, mm, sjk, fwq As String
    '            Using sr As System.IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
    '                yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = DeepCode.DeepDoStr.SimpleDecode(sr.ReadLine()) : fwq = sr.ReadLine() : sr.Close()
    '            End Using
    '            Dim sql As String
    '            Dim liccnnts As String = "Data Source=" & fwq & ";User ID=" & yhm & ";Password=" & mm & ""
    '            sql = "Insert into tb_i259b(tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_q546i,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_bz,tb_i259b_qcrq,tb_i259b_czrgh,tb_i259b_qajgsm,tb_i259b_qaspjg,tb_i259b_qarq,tb_i259b_yxx,tb_i259b_qaczrgh,tb_i259b_gg,tb_i259b_num2,tb_i259b_bf,tb_i259b_bfmx,tb_i259b_cpbzrq,tb_i259b_jhdh,tb_i259b_cgdh,tb_i259b_sbid,tb_i259b_sfqj,tb_i259b_zhbzq,tb_i259b_qjrq,tb_i259b_rkrq,tb_i259b_rkl) "
    '            sql &= "              select  tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_q546i,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_bz,tb_i259b_qcrq,tb_i259b_czrgh,tb_i259b_qajgsm,tb_i259b_qaspjg,tb_i259b_qarq,tb_i259b_yxx,tb_i259b_qaczrgh,tb_i259b_gg,tb_i259b_num2,tb_i259b_bf,tb_i259b_bfmx,tb_i259b_cpbzrq,tb_i259b_jhdh,tb_i259b_cgdh,tb_i259b_sbid,tb_i259b_sfqj,tb_i259b_zhbzq,tb_i259b_qjrq,tb_i259b_rkrq," & tb_yljch_sl.Text & " "
    '            sql &= " from OPENDATASOURCE( 'SQLOLEDB','" & liccnnts & "').hbcabiodb.dbo.tb_i259b where tb_i259b_ID='" & id & "'"

    '            GS_upztxx(G_cnnstrWH, sql)
    '        End If


    '        Dim Sqlyljch As String = "Insert into tb_yljch(tb_yljch_yllb,tb_yljch_mc,tb_yljch_cz,tb_yljch_sl,tb_yljch_bz,tb_yljch_czrgh,tb_yljch_rq,tb_yljch_dw,tb_yljch_jhdh,tb_yljch_num,tb_yljch_dm) values('" & tb_yljch_yllb.Text & "','" & tb_yljch_mc.Text & "','进'," & tb_yljch_sl.Text & ",'" & tb_yljch_bz.Text & "','" & G_dlrgh & "','" & tb_yljch_rq.Text & "','" & tb_yljch_dw.Text & "','" & tb_yljch_jhdh.Text & "','" & tb_yljch_num.Text & "','" & tb_yljch_dm.Text & "')"
    '        GS_upztxx(G_cnnstrWH, Sqlyljch) ''存入武汉的原料进出货

    '        Dim jj As String = GF_addsj("tb_yljch", Me, G_cnnstr) ''''''''''''存入湖北原料进出货
    '        If jj = "" Then
    '            MsgBox("请检查输入项目及数据") : Exit Sub
    '        End If
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''扣除原料表
    '        Dim sql0 As String = "update tb_i259b set tb_i259b_kczl=tb_i259b_kczl-" & tb_yljch_sl.Text & ",tb_i259b_ckcl=tb_i259b_ckcl-" & tb_yljch_sl.Text & ",tb_i259b_p518h=tb_i259b_p518h- " & tb_yljch_sl.Text & ""
    '        sql0 &= "where tb_i259b_id='" & id & "'"
    '        GS_upztxx(G_cnnstr, sql0)
    '    End Sub
#End Region '返厂补货传到请购添加界面

    Private Sub showqg(ByVal id As String)
        Try
            If MsgBox("是否选择补货？", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim nform As New Frcg
            '‘’‘’‘’‘’
            Dim sql As String = "select tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_p518h, tb_i259b_h200z ,tb_i259b_q546i,tb_i259b_gg ,tb_i259b_jhdh,tb_i259b_cgdh from tb_i259b  where tb_i259b_id='" & id & "' "
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            nform.tb_cg_dm.Text = Null2String(dt.Rows(0)("tb_i259b_i231a")) '原料代码
            nform.tb_cg_pm.Text = Null2String(dt.Rows(0)("tb_i259b_c24u")) '原料名称
            nform.tb_cg_wllb.Text = Null2String(dt.Rows(0)("tb_i259b_r596j")) '原料类别
            nform.tb_cg_dw.Text = Null2String(dt.Rows(0)(4)) '原料单位
            nform.tb_cg_gsmc.Text = Null2String(dt.Rows(0)(5)) '公司名称
            nform.tb_cg_ggxh.Text = Null2String(dt.Rows(0)("tb_i259b_gg")) '规格
            nform.tb_cg_jhdh.Text = Null2String(dt.Rows(0)("tb_i259b_jhdh")) '计划单号
            nform.tb_cg_cgdh.Text = Null2String(dt.Rows(0)("tb_i259b_cgdh")) '采购单号
            '’‘’‘’‘’‘’
            Dim sql1 As String = "select tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_yqdhrq,tb_cg_qgdsxrq,tb_cg_gysmc,tb_cg_qgbz,tb_cg_wpbz ,tb_cg_yszq1,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_dj,tb_cg_gysmc,tb_cg_dgzl,tb_cg_qyfy ,tb_cg_zj ,tb_cg_fzr,tb_cg_yjdhl1, tb_cg_yjdhrq1,tb_cg_wpfl,tb_cg_qgbm,tb_cg_qgr ,tb_cg_ysbm,tb_cg_scs from tb_cg where tb_cg_cgdh ='" & dt.Rows(0)("tb_i259b_cgdh") & "'  and tb_cg_dm='" & dt.Rows(0)("tb_i259b_i231a") & "'  and  tb_cg_jhdh='" & dt.Rows(0)("tb_i259b_jhdh") & "'"
            Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
            nform.tb_cg_ysbm.Text = Null2String(dt1.Rows(0)("tb_cg_ysbm"))
            nform.tb_cg_qgbm.Text = dt1.Rows(0)("tb_cg_qgbm")
            nform.tb_cg_qgr.Text = dt1.Rows(0)("tb_cg_qgr")
            nform.tb_cg_qgsl.Text = dt1.Rows(0)("tb_cg_qgsl")
            nform.tb_cg_ysje.Text = dt1.Rows(0)("tb_cg_ysje")
            nform.tb_cg_yqyt.Text = dt1.Rows(0)("tb_cg_yqyt")
            nform.tb_cg_yqdhrq.Text = dt1.Rows(0)("tb_cg_yqdhrq")
            nform.tb_cg_qgdsxrq.Text = dt1.Rows(0)("tb_cg_qgdsxrq")
            nform.tb_cg_gysmc.Text = Null2String(dt1.Rows(0)("tb_cg_gysmc"))
            nform.tb_cg_wpbz.Text = Null2String(dt1.Rows(0)("tb_cg_wpbz"))
            nform.tb_cg_qgbz.Text = Null2String(dt1.Rows(0)("tb_cg_qgbz"))
            nform.tb_cg_yszq1.Text = Null2String(dt1.Rows(0)("tb_cg_yszq1"))
            nform.tb_cg_qgrq.Text = dt1.Rows(0)("tb_cg_qgrq")
            nform.tb_cg_qgzt.Text = dt1.Rows(0)("tb_cg_qgzt")
            nform.tb_cg_qgdsfsx.Text = dt1.Rows(0)("tb_cg_qgdsfsx")
            nform.tb_cg_dj.Text = dt1.Rows(0)("tb_cg_dj")
            nform.tb_cg_gysmc.Text = dt1.Rows(0)("tb_cg_gysmc")
            nform.tb_cg_dgzl.Text = dt1.Rows(0)("tb_cg_dgzl")
            nform.tb_cg_qyfy.Text = dt1.Rows(0)("tb_cg_qyfy")
            nform.tb_cg_zj.Text = dt1.Rows(0)("tb_cg_zj")
            nform.tb_cg_fzr.Text = dt1.Rows(0)("tb_cg_fzr")
            nform.tb_cg_yjdhl1.Text = dt1.Rows(0)("tb_cg_yjdhl1")
            nform.tb_cg_yjdhrq1.Value = dt1.Rows(0)("tb_cg_yjdhrq1")
            nform.tb_cg_wpfl.Text = Null2String(dt1.Rows(0)("tb_cg_wpfl"))
            nform.tb_cg_scs.Text = Null2String(dt1.Rows(0)("tb_cg_scs"))
            nform.tb_cg_rq.Value = Now.Date
            '’‘’‘’‘’‘’‘’‘’‘
            nform.tb_cg_rq.Enabled = False
            nform.tb_cg_dgzl.ReadOnly = True
            nform.tb_cg_zj.ReadOnly = True
            nform.tb_cg_fzr.Enabled = False
            nform.tb_cg_yszq1.ReadOnly = True
            nform.tb_cg_yjdhrq1.Visible = True
            nform.tb_cg_yjdhl1.Visible = True
            nform.tb_cg_yjdhrq2.Visible = False
            nform.tb_cg_yjdhl2.Visible = False
            nform.tb_cg_yjdhrq3.Visible = False
            nform.tb_cg_yjdhl3.Visible = False
            nform.tb_cg_yszq1.Visible = True
            nform.tb_cg_yszq2.Visible = False
            nform.tb_cg_yszq3.Visible = False
            nform.Label13.Visible = True
            nform.Label14.Visible = False
            nform.Label16.Visible = True
            nform.Label17.Visible = False
            nform.Label15.Visible = False
            nform.Label18.Visible = False
            nform.Label33.Visible = False
            nform.Label32.Visible = True
            nform.Label34.Visible = False
            nform.Button2.Enabled = False
            nform.tb_cg_cgdh.ReadOnly = True

            nform.tb_cg_fqcs.Enabled = False
            nform.tb_cg_sfbh.Text = "补货"

            nform.id = ""
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' '
            nform.tb_cg_fqcs.SelectedIndex = 0
            nform.tb_cg_qyfy.Text = 0
            nform.tb_cg_fzr.SelectedIndex = 0
            nform.tb_cg_yszq1.Text = 3
            nform.tb_cg_yszq2.Text = 3
            nform.tb_cg_yszq3.Text = 3

            Dim h As String = ""
            Dim dth As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cg_ID from tb_cg where tb_cg_cgdh ='" & nform.tb_cg_cgdh.Text & "' and tb_cg_dm='" & nform.tb_cg_dm.Text & "'")
            Select Case dth.Rows.Count + 1
                Case 1
                    h = "-Ⅰ"
                Case 2
                    h = "-Ⅱ"
                Case 3
                    h = "-Ⅲ"
                Case 4
                    h = "-Ⅳ"
                Case 5
                    h = "-Ⅴ"
                Case 6
                    h = "-Ⅵ"
            End Select
            Dim sqlq As String = "insert into tb_cg(tb_cg_qgbm,tb_cg_qgr,tb_cg_cgdh,tb_cg_dhdh,tb_cg_gsmc,tb_cg_dm,tb_cg_pm,tb_cg_ggxh,tb_cg_dw,tb_cg_wllb,tb_cg_yjdhrq1,tb_cg_yjdhl1,tb_cg_qgsl,tb_cg_yqyt,tb_cg_ysje,tb_cg_qgdsxrq,tb_cg_yqdhrq,tb_cg_fzr,tb_cg_rq,tb_cg_gysmc,tb_cg_dgzl,tb_cg_dj,tb_cg_qyfy,tb_cg_zj,tb_cg_fqcs,tb_cg_ysbm,tb_cg_sfbh,tb_cg_yszq1,tb_cg_qgbz,tb_cg_wpbz,tb_cg_qgrq,tb_cg_qgzt,tb_cg_qgdsfsx,tb_cg_wpfl,tb_cg_sbid,tb_cg_jhdh,tb_cg_cgbz)"
            sqlq &= "values('" & nform.tb_cg_qgbm.Text & "','" & nform.tb_cg_qgr.Text & "','" & nform.tb_cg_cgdh.Text & "','" & nform.tb_cg_cgdh.Text & h & "','" & nform.tb_cg_gsmc.Text & "','" & nform.tb_cg_dm.Text & "','" & nform.tb_cg_pm.Text & "','" & nform.tb_cg_ggxh.Text & "','" & nform.tb_cg_dw.Text & "','" & nform.tb_cg_wllb.Text & "','" & GF_gettrqsj(nform.tb_cg_yjdhrq1.Value) & "'," & nform.tb_cg_yjdhl1.Text & "," & nform.tb_cg_qgsl.Text & ",'" & nform.tb_cg_yqyt.Text & "'," & nform.tb_cg_ysje.Text & ",'" & GF_gettrqsj(nform.tb_cg_qgdsxrq.Text) & "','" & GF_gettrqsj(nform.tb_cg_yqdhrq.Text) & "','" & nform.tb_cg_fzr.Text & "','" & GF_gettrqsj(nform.tb_cg_rq.Value) & "','" & nform.tb_cg_gysmc.Text & "'," & nform.tb_cg_dgzl.Text & "," & nform.tb_cg_dj.Text & "," & nform.tb_cg_qyfy.Text & "," & nform.tb_cg_zj.Text & ",'" & nform.tb_cg_fqcs.Text & "','" & nform.tb_cg_ysbm.Text & "','" & nform.tb_cg_sfbh.Text & "','" & nform.tb_cg_yszq1.Text & "','" & nform.tb_cg_qgbz.Text & "','" & nform.tb_cg_wpbz.Text & "','" & nform.tb_cg_qgrq.Text & "','" & nform.tb_cg_qgzt.Text & "','" & nform.tb_cg_qgdsfsx.Text & "','" & nform.tb_cg_wpfl.Text & "','" & nform.tb_cg_sbid.Text & "','" & nform.tb_cg_jhdh.Text & "','" & nform.tb_cg_cgbz.Text & "')"
            Dim idstring As String = GF_upztxx2(G_cnnstr, sqlq, "tb_cg")
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub


End Class