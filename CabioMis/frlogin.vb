Imports System.Xml
Imports System.Net
Public Class frlogin

    Private Sub frlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim holder As ResourceHolder = ResourceHolder.getInstance()
#If Not Debug Then
    Version.Text = checkUpdate()
#End If
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        'Me.SkinEngine1.SkinFile = Application.StartupPath & "\Skin\" & My.Settings.skin
        '图标、背景，房间图形
        Me.BackgroundImage = Image.FromFile(Application.StartupPath() & "\image\ndl.jpg")
        'G_backimg = Image.FromFile(Application.StartupPath() & "\image\111.jpg")
        G_backimg = Nothing
        G_icon = Drawing.Icon.ExtractAssociatedIcon(Application.StartupPath() & "\image\gohome.ico")
        G_bumen = "部门一" '上传文件时候调用
        G_DriverNum = GF_ShowDriveInfo("C:") '磁盘卷标
        Dim yhm, mm, sjk, fwq As String
        Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
            yhm = sr.ReadLine()
            sjk = sr.ReadLine()
            Dim xx = DeepCode.DeepDoStr.SimpleEncode("20*,+,")

#If DEBUG Then
            mm = sr.ReadLine()
#Else
            mm = DeepCode.DeepDoStr.SimpleDecode(sr.ReadLine())
#End If
            fwq = sr.ReadLine()
            sr.Close()
        End Using
        'Dim mmm As New Cabio.Model.Crafts.tb_gxsz()
        'Dim gg = New Cabio.BLL.Crafts.CraftsSettingService().Insert(mmm)
        'MessageBox.Show(mmm.tb_gxsz_ID.ToString())
        G_cnnstr = "Provider=sqloledb; User ID=" & yhm & "; Password=" & mm & "; Initial Catalog=" & sjk & "; Data Source=" & fwq & ";"
        G_cnnstrWH = "Provider=sqloledb; User ID=" & yhm & "; Password=" & mm & "; Initial Catalog=hb" & sjk & "; Data Source=" & fwq & ";"
        '***********************
        _D.ConnStr = G_cnnstr
        _S.m_MynumWs = -2
        _D.m_callbackErr = Function(pEx As Exception)
                               MsgBox(pEx.Message, MsgBoxStyle.Exclamation)
                               Return True
                           End Function
        '******************************
        Try
            Dim conn As New OleDb.OleDbConnection(G_cnnstr & "Connect Timeout=2;providerName=System.Data.SqlClient;")
            conn.Open()
        Catch ex As Exception
            G_FR_SPLASHSCREEN.Close()
            MsgBox(ex.Message & ":" & G_cnnstr, MsgBoxStyle.Exclamation)
            'MsgBox("数据库连接错误，请检查配置文件，或查看网络是否异常！", MsgBoxStyle.Exclamation)
            End
        End Try

        _D.G_zdinf = _D.GF_CreateDataSource("select * from tb_biaozdinf") '所有字段表
        _D.G_biaoinf = _D.GF_CreateDataSource("select * from tb_biaoinf order by tb_biaoinf_id") '所有表
        G_yg = GF_CreateDataSource(G_cnnstr, "select * from tb_yg order by tb_yg_w779o") '员工表

        'If My.Computer.FileSystem.FileExists(Application.StartupPath() & "\G_zdinf.xml") Then
        '    G_zdinf = DeepCode.DeepDoZipFile.DeSerializeFromFile(Of DataTable)(Application.StartupPath() & "\G_zdinf.xml")
        'Else
        '    G_zdinf = _D.GF_CreateDataSource("select * from tb_biaozdinf") '所有字段表
        '    DeepCode.DeepDoZipFile.SerializetoFile(Application.StartupPath() & "\G_zdinf.xml", G_zdinf)
        'End If
        'If My.Computer.FileSystem.FileExists(Application.StartupPath() & "\G_biaoinf.xml") Then
        '    G_biaoinf = DeepCode.DeepDoZipFile.DeSerializeFromFile(Of DataTable)(Application.StartupPath() & "\G_biaoinf.xml")
        'Else
        '    G_biaoinf = GF_CreateDataSource(G_cnnstr, "select * from tb_biaoinf order by tb_biaoinf_id") '所有表
        '    DeepCode.DeepDoZipFile.SerializetoFile(Application.StartupPath() & "\G_biaoinf.xml", G_biaoinf)
        'End If
        'If My.Computer.FileSystem.FileExists(Application.StartupPath() & "\G_yg.xml") Then
        '    G_yg = DeepCode.DeepDoZipFile.DeSerializeFromFile(Of DataTable)(Application.StartupPath() & "\G_yg.xml")
        'Else
        '    G_yg = GF_CreateDataSource(G_cnnstr, "select * from tb_yg order by tb_yg_w779o") '员工表
        '    DeepCode.DeepDoZipFile.SerializetoFile(Application.StartupPath() & "\G_yg.xml", G_yg)
        'End If

        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'") '所有产品代码基础表

        G_face = GF_CreateDataSource(G_cnnstr, "select * from tb_face") '界面表
        G_bm = GF_CreateDataSource(G_cnnstr, "select * from tb_bm ") '部门表
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_sjkz")
        G_xdz = _S.YanFormatNum(dt.YanDtValue2("tb_sjkz_xdz"))
        G_zdd = _S.YanFormatNum(dt.YanDtValue2("tb_sjkz_zdd"))
        G_ddf = _S.YanFormatNum(dt.YanDtValue2("tb_sjkz_ddf")) '小大中，中到大，大到放的时间

        '*******************************
        Dim gf As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_yg, "tb_yg_yx='有效' and tb_yg_zt='正常'", "tb_yg_w779o asc")

        '****************************************

        Try
            yhm = GF_readwrite(Application.StartupPath() & "\Person.ini", "READ")
        Catch ex As Exception
        End Try
        GS_wlbktlr22(TextBox1, gf, yhm) '读取默认人员
        TextBox2.Focus()

        ''''''''''''''生产武汉登陆的默认路径
        GF_readwrite("c:\cabioexe.ini", Application.StartupPath() & "\")
        '''''''''''''''''''
    End Sub
    '手动登入
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '验证用户名密码并赋予权限 begin
        Dim uid As String = GF_searchchar(Me.TextBox1.Text, "|", "left")
        Dim psw As String = GF_MD5(Me.TextBox2.Text, 16)
        Dim uName As String = GF_searchchar(Me.TextBox1.Text, "|", "right")
        login(uid, psw, uName)
    End Sub
    Private Sub [login](Uid As String, Psw As String, uName As String)
        Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & Uid & "' and tb_yg_pass='" & Psw & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        G_dlrmm = Psw '登录人密码
        G_dlr = uName '姓名
        G_dlrgh = Uid '工号

        JCDL() '检测登陆判断

        Dim smText As String = ""
        If dt.Rows.Count > 0 Then
            Try
                G_dlqx = dt.Rows(0)(8) '登陆人权限
            Catch ex As Exception
                G_dlqx = ""
            End Try
            Try
                G_bumen = dt.Rows(0)(1) '登录人部门
            Catch ex As Exception
                G_bumen = ""
            End Try
            Try
                G_qx1 = _S.YanFormatStr(dt.Rows(0)(12)) '查看权限
            Catch ex As Exception
                G_qx1 = ""
            End Try
            Try
                G_qx2 = _S.YanFormatStr(dt.Rows(0)(13)) '修改权限
            Catch ex As Exception
                G_qx2 = ""
            End Try
            Try
                G_qx3 = _S.YanFormatStr(dt.Rows(0)(14)) '删除权限
            Catch ex As Exception
                G_qx3 = ""
            End Try
            Try
                G_js = dt.Rows(0)(9) '角色
            Catch ex As Exception
                G_js = ""
            End Try

            smText = uName & "从" & G_IPAdress & "成功登陆！"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & Uid & "','" & uName & "','" & smText & "','登陆成功')"
            GS_upztxx(G_cnnstr, sql)

            '储存默认人员
            GF_readwrite(Application.StartupPath() & "\Person.ini", TextBox1.Text)

            '打开界面
            Dim jm As String = dt.Rows(0)("tb_yg_dl")
            dkxck(jm) '打开该人的登陆界面

            Me.Close()

        Else
            smText = uName & "企图从" & G_IPAdress & "登陆失败！"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & Uid & "','" & uName & "','" & smText & "','登陆失败')"
            GS_upztxx(G_cnnstr, sql)

            MsgBox("登陆失败，请检查用户名及密码")
            TextBox2.Text = ""
            TextBox2.Focus()
            Exit Sub
        End If
    End Sub
    '自动登入
    Private Sub frlogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
#If DEBUG Then
        login("8888", "77804d2ba1922c33", "软件公司")
        Return
#End If
        drjm() '切换 
    End Sub
    '自动刷新
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Dim fileExists1 As Boolean
        fileExists1 = My.Computer.FileSystem.FileExists("c:\cabioexe.ini")
        If fileExists1 = False Then
            MsgBox("没有初始化武汉路径,请先手动登入武汉系统")
            Return
        End If
        Dim lnk As String = GF_readwrite("c:\cabioexe.ini", "READ")

        With My.Computer.FileSystem
            .DeleteFile(lnk & "G_yg.xml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            .DeleteFile(lnk & "G_zdinf.xml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            .DeleteFile(lnk & "G_biaoinf.xml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End With
        System.Diagnostics.Process.Start(lnk & "CabioMis.exe")

    End Sub
    '关闭
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub dkxck(ByVal str As String)    '必须是 命名空间+点+窗体类名 
        Dim jm As String = GF_cnwithen(G_face, "tb_face_mc='" & str & "'", 2)
        Dim ctclass As String = My.Application.Info.AssemblyName & "." & jm
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(ctclass), Form)
        frm2.Show()
        bf()
    End Sub
    Private Sub zdbf() '每日备份良品不良品库

        Dim i() As String = {"h195zkc", "x825pkc", "x832pkc", "x832pkc", "x832pkc"}
        Dim lb() As String = {"AOG40", "AOGC", "APG10", "APG15", "APGK"}
        For j As Integer = 0 To UBound(i)
            Dim sql As String = "select sum(tb_" & i(j) & "_ckcl),sum(tb_" & i(j) & "_sykczl),(select sum(tb_" & i(j) & "_ckcl) from tb_" & i(j) & "  where tb_" & i(j) & "_qaspjg='待定'and tb_" & i(j) & "_yg='生产'),"
            sql &= "(select sum(tb_" & i(j) & "_ckcl) from tb_" & i(j) & "  where  tb_" & i(j) & "_yg='销售'),(select sum(tb_" & i(j) & "_ckcl) from tb_" & i(j) & "  where tb_" & i(j) & "_qaspjg='合格'and tb_" & i(j) & "_yg='生产')"
            sql &= ",getdate() as 'mm' from tb_" & i(j) & "  where tb_" & i(j) & "_ckcl>0 and tb_" & i(j) & "_sykczl>0"
            If i(j) = "x832pkc" Then
                sql &= "and tb_x832pkc_cplb='" & lb(j) & "'"
            End If
            Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
            Dim tjq As DateTime = DateAdd(DateInterval.Day, -1, dt.Rows(0)("mm"))
            tjq = FormatDateTime(tjq, DateFormat.ShortDate)
            Dim sql1 As String = "insert into tb_sjbf (tb_sjbf_rq,tb_sjbf_sykc,tb_sjbf_ckcl,tb_sjbf_hggsc,tb_sjbf_ddgsc,tb_sjbf_xs,tb_sjbf_bz)"
            sql1 &= "values ('" & tjq & "'," & Null2zero2(dt.Rows(0)(0)) & "," & Null2zero2(dt.Rows(0)(1)) & "," & Null2zero2(dt.Rows(0)(2)) & "," & Null2zero2(dt.Rows(0)(3)) & "," & Null2zero2(dt.Rows(0)(4)) & ", '" & lb(j) & "')"
            GS_upztxx(G_cnnstr, sql1)
        Next


    End Sub
    Private Sub bf() '判定，如第一个人登陆者已经备份，则不需再备份，如此人为当日第一个登陆者，则备份每日备份良品不良品库,统计期为当日—1
        Dim sql As String = "select tb_sjbf_rq,getdate() from tb_sjbf where DATEDIFF(day,tb_sjbf_rq, getdate())=1"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            zdbf()
        End If
    End Sub
    Private Sub drjm() '自动登入函数

        Dim fileExists1 As Boolean
        fileExists1 = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\Herson.ini")
        If fileExists1 = False Then
            Exit Sub
        End If

        Dim uid, psw As String
        Using cc As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\Herson.ini")
            uid = cc.ReadLine() : psw = cc.ReadLine() : cc.Close()
        End Using

        '验证用户名密码并赋予权限 begin
        G_dlrgh = uid '工号
        G_dlrmm = psw '登录人密码
        Dim smText As String = ""
        Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & G_dlrgh & "' and tb_yg_pass='" & G_dlrmm & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        G_dlr = dt.Rows(0)("tb_yg_w779o") '登录人姓名

        JCDL() '检测登入判断

        If dt.Rows.Count > 0 Then
            '''''''''''''''''''''''''''''''''''
            Try
                G_dlqx = dt.Rows(0)(8) '登陆人权限
            Catch ex As Exception
                G_dlqx = ""
            End Try
            Try
                G_bumen = dt.Rows(0)(1) '登陆人部门
            Catch ex As Exception
                G_bumen = ""
            End Try
            Try
                G_qx1 = dt.Rows(0)(12) '登陆人查看权限
            Catch ex As Exception
                G_qx1 = ""
            End Try
            Try
                G_qx2 = dt.Rows(0)(13) '登陆人修改权限
            Catch ex As Exception
                G_qx2 = ""
            End Try
            Try
                G_qx3 = dt.Rows(0)(14) '登陆人删除权限
            Catch ex As Exception
                G_qx3 = ""
            End Try
            Try
                G_js = dt.Rows(0)(9) '角色
            Catch ex As Exception
                G_js = ""
            End Try

            smText = G_dlr & "从" & G_IPAdress & "成功登陆！"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & G_dlrgh & "','" & G_dlr & "','" & smText & "','登陆成功')"
            GS_upztxx(G_cnnstr, sql)
            '储存默认人员
            GF_readwrite(Application.StartupPath() & "\Person.ini", TextBox1.Text)
            '打开界面
            Dim jm As String = dt.Rows(0)("tb_yg_dl")
            dkxck(jm) '打开该人的登陆界面

            ''''''''''  '删除Herson.ini操作
            My.Computer.FileSystem.DeleteFile(Application.StartupPath() & "\Herson.ini", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            ''''''''''
            Me.Close()
        Else
            smText = G_dlr & "企图从" & G_IPAdress & "登陆失败！"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & G_dlrgh & "','" & G_dlr & "','" & smText & "','登陆失败')"
            GS_upztxx(G_cnnstr, sql)

            MsgBox("登陆失败，请检查用户名及密码")
            TextBox2.Text = ""
            TextBox2.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub JCDL() '检测登陆判断
        ''''''''''''''''''''''''''''''''''''
        Dim sql As String = "select tb_inline_rq,getdate(),tb_inline_xm,tb_inline_IP,tb_inline_xlh from tb_inline where  tb_inline_gh='" & G_dlrgh & "'"
        Dim cg1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If cg1.Rows.Count = 0 Then '没有的情况下储存
            Call GS_upztxx(G_cnnstr, "insert into tb_inline(tb_inline_gh,tb_inline_xm,tb_inline_IP,tb_inline_rq,tb_inline_xlh)values('" & G_dlrgh & "','" & G_dlr & "','" & G_IPAdress & "',getdate(),'" & G_DriverNum & "')")
            Return
        End If
        Dim sj1 As DateTime = cg1.Rows(0)("tb_inline_rq") '得到最后一次操作时间
        Dim sj2 As DateTime = cg1.Rows(0)(1) '得到服务器时间
        Dim JB As String = cg1.Rows(0)("tb_inline_xlh") '磁盘卷标
        If JB = G_DriverNum Then '卷标相同，表明同一机器非正常退出程序，允许登陆
            GS_StoreLastDo()
            Return
        End If
        If DateAdd(DateInterval.Minute, G_TimeSession, sj1) < sj2 Then '这表明有人长时间未操作或者原登陆用户非正常终止程序或者网络中断
            Dim sql11 As String = "delete  from tb_inline where tb_inline_gh='" & G_dlrgh & "'"
            sql11 &= vbCrLf & "insert into tb_inline(tb_inline_gh,tb_inline_xm,tb_inline_IP,tb_inline_rq,tb_inline_xlh)values('" & G_dlrgh & "','" & G_dlr & "','" & G_IPAdress & "',getdate(),'" & G_DriverNum & "')"
            Call GS_upztxx(G_cnnstr, sql11)
            Return
        End If
#If DEBUG Then
        Return
#End If
        MsgBox(cg1.Rows(0)("tb_inline_xm") & "已在" & cg1.Rows(0)("tb_inline_IP") & "登陆,您目前不能登陆！")
        Application.Exit()

    End Sub
    Function checkUpdate() As String
        Try
            '判断是否需要升级
            Dim xmlPath As String = AppDomain.CurrentDomain.BaseDirectory & "UpdateSet.xml"
            Dim xmlDoc As New XmlDataDocument()
            xmlDoc.Load(xmlPath)
            Dim xmlContent As XmlElement = xmlDoc.DocumentElement
            Dim updateXmlPath As String = xmlContent.SelectSingleNode("UpdateURL").InnerText '获取更新的xml地址
            Dim strLocalVer As String = xmlContent.SelectSingleNode("ver").InnerText '本地版本
            Dim updateName As String = xmlContent.SelectSingleNode("updateName").InnerText '更新程序名
            'Dim updateInfo As String = xmlContent.SelectSingleNode("updateInfo").InnerText '更新说明
            'If updateInfo <> "" Then
            '    xmlContent.SelectSingleNode("updateInfo").InnerText =""
            '    MsgBox(updateInfo, MsgBoxStyle.Information, "更新提示")
            'End If
            'xmlDoc.Save(xmlPath)
            xmlContent = Nothing
            xmlDoc = Nothing

            '升级文件自身升级
            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\" & updateName & ".exetemp")
            If fileExists = True Then
                System.IO.File.Delete(Application.StartupPath() & "\" & updateName & ".exe")
                System.IO.File.Move(Application.StartupPath() & "\" & updateName & ".exetemp", Application.StartupPath() & "\" & updateName & ".exe")
            End If

            xmlDoc = New XmlDataDocument()
            xmlDoc.LoadXml(New WebClient().DownloadString(updateXmlPath))
            xmlContent = xmlDoc.DocumentElement
            Dim strServerVer As String = xmlContent.SelectSingleNode("ver").InnerText '服务器版本
            '版本不一致，那么启动升级程序
            If strLocalVer <> strServerVer Then
                openApp(updateName & ".exe")
                End
            End If
            Return strLocalVer
        Catch ex As Exception
            MsgBox("升级文件异常，可能是您的配置文件错误，或者是网络异常！", MsgBoxStyle.Exclamation)
            Return ""
        End Try
    End Function
    '打开某个程序
    Sub openApp(pAppName As String, Optional IsClose As Boolean = True)
        If IsClose Then
            Dim ps As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcesses()
            For Each p As System.Diagnostics.Process In ps
                If p.ProcessName.ToUpper() = pAppName.ToUpper() Then
                    p.Kill()
                    'break;//防止存在多个进程,即主程序打开了多次
                End If
            Next
        End If
        System.Diagnostics.Process.Start(pAppName)
    End Sub
End Class