Imports System.Xml
Imports System.Net
Public Class frlogin

    Private Sub frlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim holder As ResourceHolder = ResourceHolder.getInstance()
#If Not Debug Then
    Version.Text = checkUpdate()
#End If
        '��������������������������������������������������������
        'Me.SkinEngine1.SkinFile = Application.StartupPath & "\Skin\" & My.Settings.skin
        'ͼ�ꡢ����������ͼ��
        Me.BackgroundImage = Image.FromFile(Application.StartupPath() & "\image\ndl.jpg")
        'G_backimg = Image.FromFile(Application.StartupPath() & "\image\111.jpg")
        G_backimg = Nothing
        G_icon = Drawing.Icon.ExtractAssociatedIcon(Application.StartupPath() & "\image\gohome.ico")
        G_bumen = "����һ" '�ϴ��ļ�ʱ�����
        G_DriverNum = GF_ShowDriveInfo("C:") '���̾��
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
            'MsgBox("���ݿ����Ӵ������������ļ�����鿴�����Ƿ��쳣��", MsgBoxStyle.Exclamation)
            End
        End Try

        _D.G_zdinf = _D.GF_CreateDataSource("select * from tb_biaozdinf") '�����ֶα�
        _D.G_biaoinf = _D.GF_CreateDataSource("select * from tb_biaoinf order by tb_biaoinf_id") '���б�
        G_yg = GF_CreateDataSource(G_cnnstr, "select * from tb_yg order by tb_yg_w779o") 'Ա����

        'If My.Computer.FileSystem.FileExists(Application.StartupPath() & "\G_zdinf.xml") Then
        '    G_zdinf = DeepCode.DeepDoZipFile.DeSerializeFromFile(Of DataTable)(Application.StartupPath() & "\G_zdinf.xml")
        'Else
        '    G_zdinf = _D.GF_CreateDataSource("select * from tb_biaozdinf") '�����ֶα�
        '    DeepCode.DeepDoZipFile.SerializetoFile(Application.StartupPath() & "\G_zdinf.xml", G_zdinf)
        'End If
        'If My.Computer.FileSystem.FileExists(Application.StartupPath() & "\G_biaoinf.xml") Then
        '    G_biaoinf = DeepCode.DeepDoZipFile.DeSerializeFromFile(Of DataTable)(Application.StartupPath() & "\G_biaoinf.xml")
        'Else
        '    G_biaoinf = GF_CreateDataSource(G_cnnstr, "select * from tb_biaoinf order by tb_biaoinf_id") '���б�
        '    DeepCode.DeepDoZipFile.SerializetoFile(Application.StartupPath() & "\G_biaoinf.xml", G_biaoinf)
        'End If
        'If My.Computer.FileSystem.FileExists(Application.StartupPath() & "\G_yg.xml") Then
        '    G_yg = DeepCode.DeepDoZipFile.DeSerializeFromFile(Of DataTable)(Application.StartupPath() & "\G_yg.xml")
        'Else
        '    G_yg = GF_CreateDataSource(G_cnnstr, "select * from tb_yg order by tb_yg_w779o") 'Ա����
        '    DeepCode.DeepDoZipFile.SerializetoFile(Application.StartupPath() & "\G_yg.xml", G_yg)
        'End If

        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='��Ч'") '���в�Ʒ���������

        G_face = GF_CreateDataSource(G_cnnstr, "select * from tb_face") '�����
        G_bm = GF_CreateDataSource(G_cnnstr, "select * from tb_bm ") '���ű�
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_sjkz")
        G_xdz = _S.YanFormatNum(dt.YanDtValue2("tb_sjkz_xdz"))
        G_zdd = _S.YanFormatNum(dt.YanDtValue2("tb_sjkz_zdd"))
        G_ddf = _S.YanFormatNum(dt.YanDtValue2("tb_sjkz_ddf")) 'С���У��е��󣬴󵽷ŵ�ʱ��

        '*******************************
        Dim gf As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_yg, "tb_yg_yx='��Ч' and tb_yg_zt='����'", "tb_yg_w779o asc")

        '****************************************

        Try
            yhm = GF_readwrite(Application.StartupPath() & "\Person.ini", "READ")
        Catch ex As Exception
        End Try
        GS_wlbktlr22(TextBox1, gf, yhm) '��ȡĬ����Ա
        TextBox2.Focus()

        ''''''''''''''�����人��½��Ĭ��·��
        GF_readwrite("c:\cabioexe.ini", Application.StartupPath() & "\")
        '''''''''''''''''''
    End Sub
    '�ֶ�����
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '��֤�û������벢����Ȩ�� begin
        Dim uid As String = GF_searchchar(Me.TextBox1.Text, "|", "left")
        Dim psw As String = GF_MD5(Me.TextBox2.Text, 16)
        Dim uName As String = GF_searchchar(Me.TextBox1.Text, "|", "right")
        login(uid, psw, uName)
    End Sub
    Private Sub [login](Uid As String, Psw As String, uName As String)
        Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & Uid & "' and tb_yg_pass='" & Psw & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        G_dlrmm = Psw '��¼������
        G_dlr = uName '����
        G_dlrgh = Uid '����

        JCDL() '����½�ж�

        Dim smText As String = ""
        If dt.Rows.Count > 0 Then
            Try
                G_dlqx = dt.Rows(0)(8) '��½��Ȩ��
            Catch ex As Exception
                G_dlqx = ""
            End Try
            Try
                G_bumen = dt.Rows(0)(1) '��¼�˲���
            Catch ex As Exception
                G_bumen = ""
            End Try
            Try
                G_qx1 = _S.YanFormatStr(dt.Rows(0)(12)) '�鿴Ȩ��
            Catch ex As Exception
                G_qx1 = ""
            End Try
            Try
                G_qx2 = _S.YanFormatStr(dt.Rows(0)(13)) '�޸�Ȩ��
            Catch ex As Exception
                G_qx2 = ""
            End Try
            Try
                G_qx3 = _S.YanFormatStr(dt.Rows(0)(14)) 'ɾ��Ȩ��
            Catch ex As Exception
                G_qx3 = ""
            End Try
            Try
                G_js = dt.Rows(0)(9) '��ɫ
            Catch ex As Exception
                G_js = ""
            End Try

            smText = uName & "��" & G_IPAdress & "�ɹ���½��"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & Uid & "','" & uName & "','" & smText & "','��½�ɹ�')"
            GS_upztxx(G_cnnstr, sql)

            '����Ĭ����Ա
            GF_readwrite(Application.StartupPath() & "\Person.ini", TextBox1.Text)

            '�򿪽���
            Dim jm As String = dt.Rows(0)("tb_yg_dl")
            dkxck(jm) '�򿪸��˵ĵ�½����

            Me.Close()

        Else
            smText = uName & "��ͼ��" & G_IPAdress & "��½ʧ�ܣ�"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & Uid & "','" & uName & "','" & smText & "','��½ʧ��')"
            GS_upztxx(G_cnnstr, sql)

            MsgBox("��½ʧ�ܣ������û���������")
            TextBox2.Text = ""
            TextBox2.Focus()
            Exit Sub
        End If
    End Sub
    '�Զ�����
    Private Sub frlogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
#If DEBUG Then
        login("8888", "77804d2ba1922c33", "�����˾")
        Return
#End If
        drjm() '�л� 
    End Sub
    '�Զ�ˢ��
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Dim fileExists1 As Boolean
        fileExists1 = My.Computer.FileSystem.FileExists("c:\cabioexe.ini")
        If fileExists1 = False Then
            MsgBox("û�г�ʼ���人·��,�����ֶ������人ϵͳ")
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
    '�ر�
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub dkxck(ByVal str As String)    '������ �����ռ�+��+�������� 
        Dim jm As String = GF_cnwithen(G_face, "tb_face_mc='" & str & "'", 2)
        Dim ctclass As String = My.Application.Info.AssemblyName & "." & jm
        Dim tempAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim frm2 As Form = CType(tempAssembly.CreateInstance(ctclass), Form)
        frm2.Show()
        bf()
    End Sub
    Private Sub zdbf() 'ÿ�ձ�����Ʒ����Ʒ��

        Dim i() As String = {"h195zkc", "x825pkc", "x832pkc", "x832pkc", "x832pkc"}
        Dim lb() As String = {"AOG40", "AOGC", "APG10", "APG15", "APGK"}
        For j As Integer = 0 To UBound(i)
            Dim sql As String = "select sum(tb_" & i(j) & "_ckcl),sum(tb_" & i(j) & "_sykczl),(select sum(tb_" & i(j) & "_ckcl) from tb_" & i(j) & "  where tb_" & i(j) & "_qaspjg='����'and tb_" & i(j) & "_yg='����'),"
            sql &= "(select sum(tb_" & i(j) & "_ckcl) from tb_" & i(j) & "  where  tb_" & i(j) & "_yg='����'),(select sum(tb_" & i(j) & "_ckcl) from tb_" & i(j) & "  where tb_" & i(j) & "_qaspjg='�ϸ�'and tb_" & i(j) & "_yg='����')"
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
    Private Sub bf() '�ж������һ���˵�½���Ѿ����ݣ������ٱ��ݣ������Ϊ���յ�һ����½�ߣ��򱸷�ÿ�ձ�����Ʒ����Ʒ��,ͳ����Ϊ���ա�1
        Dim sql As String = "select tb_sjbf_rq,getdate() from tb_sjbf where DATEDIFF(day,tb_sjbf_rq, getdate())=1"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count = 0 Then
            zdbf()
        End If
    End Sub
    Private Sub drjm() '�Զ����뺯��

        Dim fileExists1 As Boolean
        fileExists1 = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\Herson.ini")
        If fileExists1 = False Then
            Exit Sub
        End If

        Dim uid, psw As String
        Using cc As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\Herson.ini")
            uid = cc.ReadLine() : psw = cc.ReadLine() : cc.Close()
        End Using

        '��֤�û������벢����Ȩ�� begin
        G_dlrgh = uid '����
        G_dlrmm = psw '��¼������
        Dim smText As String = ""
        Dim sql As String = "select * from tb_yg where tb_yg_n430f='" & G_dlrgh & "' and tb_yg_pass='" & G_dlrmm & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        G_dlr = dt.Rows(0)("tb_yg_w779o") '��¼������

        JCDL() '�������ж�

        If dt.Rows.Count > 0 Then
            '''''''''''''''''''''''''''''''''''
            Try
                G_dlqx = dt.Rows(0)(8) '��½��Ȩ��
            Catch ex As Exception
                G_dlqx = ""
            End Try
            Try
                G_bumen = dt.Rows(0)(1) '��½�˲���
            Catch ex As Exception
                G_bumen = ""
            End Try
            Try
                G_qx1 = dt.Rows(0)(12) '��½�˲鿴Ȩ��
            Catch ex As Exception
                G_qx1 = ""
            End Try
            Try
                G_qx2 = dt.Rows(0)(13) '��½���޸�Ȩ��
            Catch ex As Exception
                G_qx2 = ""
            End Try
            Try
                G_qx3 = dt.Rows(0)(14) '��½��ɾ��Ȩ��
            Catch ex As Exception
                G_qx3 = ""
            End Try
            Try
                G_js = dt.Rows(0)(9) '��ɫ
            Catch ex As Exception
                G_js = ""
            End Try

            smText = G_dlr & "��" & G_IPAdress & "�ɹ���½��"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & G_dlrgh & "','" & G_dlr & "','" & smText & "','��½�ɹ�')"
            GS_upztxx(G_cnnstr, sql)
            '����Ĭ����Ա
            GF_readwrite(Application.StartupPath() & "\Person.ini", TextBox1.Text)
            '�򿪽���
            Dim jm As String = dt.Rows(0)("tb_yg_dl")
            dkxck(jm) '�򿪸��˵ĵ�½����

            ''''''''''  'ɾ��Herson.ini����
            My.Computer.FileSystem.DeleteFile(Application.StartupPath() & "\Herson.ini", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            ''''''''''
            Me.Close()
        Else
            smText = G_dlr & "��ͼ��" & G_IPAdress & "��½ʧ�ܣ�"
            sql = "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx) values ('" & G_dlrgh & "','" & G_dlr & "','" & smText & "','��½ʧ��')"
            GS_upztxx(G_cnnstr, sql)

            MsgBox("��½ʧ�ܣ������û���������")
            TextBox2.Text = ""
            TextBox2.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub JCDL() '����½�ж�
        ''''''''''''''''''''''''''''''''''''
        Dim sql As String = "select tb_inline_rq,getdate(),tb_inline_xm,tb_inline_IP,tb_inline_xlh from tb_inline where  tb_inline_gh='" & G_dlrgh & "'"
        Dim cg1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If cg1.Rows.Count = 0 Then 'û�е�����´���
            Call GS_upztxx(G_cnnstr, "insert into tb_inline(tb_inline_gh,tb_inline_xm,tb_inline_IP,tb_inline_rq,tb_inline_xlh)values('" & G_dlrgh & "','" & G_dlr & "','" & G_IPAdress & "',getdate(),'" & G_DriverNum & "')")
            Return
        End If
        Dim sj1 As DateTime = cg1.Rows(0)("tb_inline_rq") '�õ����һ�β���ʱ��
        Dim sj2 As DateTime = cg1.Rows(0)(1) '�õ�������ʱ��
        Dim JB As String = cg1.Rows(0)("tb_inline_xlh") '���̾��
        If JB = G_DriverNum Then '�����ͬ������ͬһ�����������˳����������½
            GS_StoreLastDo()
            Return
        End If
        If DateAdd(DateInterval.Minute, G_TimeSession, sj1) < sj2 Then '��������˳�ʱ��δ��������ԭ��½�û���������ֹ������������ж�
            Dim sql11 As String = "delete  from tb_inline where tb_inline_gh='" & G_dlrgh & "'"
            sql11 &= vbCrLf & "insert into tb_inline(tb_inline_gh,tb_inline_xm,tb_inline_IP,tb_inline_rq,tb_inline_xlh)values('" & G_dlrgh & "','" & G_dlr & "','" & G_IPAdress & "',getdate(),'" & G_DriverNum & "')"
            Call GS_upztxx(G_cnnstr, sql11)
            Return
        End If
#If DEBUG Then
        Return
#End If
        MsgBox(cg1.Rows(0)("tb_inline_xm") & "����" & cg1.Rows(0)("tb_inline_IP") & "��½,��Ŀǰ���ܵ�½��")
        Application.Exit()

    End Sub
    Function checkUpdate() As String
        Try
            '�ж��Ƿ���Ҫ����
            Dim xmlPath As String = AppDomain.CurrentDomain.BaseDirectory & "UpdateSet.xml"
            Dim xmlDoc As New XmlDataDocument()
            xmlDoc.Load(xmlPath)
            Dim xmlContent As XmlElement = xmlDoc.DocumentElement
            Dim updateXmlPath As String = xmlContent.SelectSingleNode("UpdateURL").InnerText '��ȡ���µ�xml��ַ
            Dim strLocalVer As String = xmlContent.SelectSingleNode("ver").InnerText '���ذ汾
            Dim updateName As String = xmlContent.SelectSingleNode("updateName").InnerText '���³�����
            'Dim updateInfo As String = xmlContent.SelectSingleNode("updateInfo").InnerText '����˵��
            'If updateInfo <> "" Then
            '    xmlContent.SelectSingleNode("updateInfo").InnerText =""
            '    MsgBox(updateInfo, MsgBoxStyle.Information, "������ʾ")
            'End If
            'xmlDoc.Save(xmlPath)
            xmlContent = Nothing
            xmlDoc = Nothing

            '�����ļ���������
            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\" & updateName & ".exetemp")
            If fileExists = True Then
                System.IO.File.Delete(Application.StartupPath() & "\" & updateName & ".exe")
                System.IO.File.Move(Application.StartupPath() & "\" & updateName & ".exetemp", Application.StartupPath() & "\" & updateName & ".exe")
            End If

            xmlDoc = New XmlDataDocument()
            xmlDoc.LoadXml(New WebClient().DownloadString(updateXmlPath))
            xmlContent = xmlDoc.DocumentElement
            Dim strServerVer As String = xmlContent.SelectSingleNode("ver").InnerText '�������汾
            '�汾��һ�£���ô������������
            If strLocalVer <> strServerVer Then
                openApp(updateName & ".exe")
                End
            End If
            Return strLocalVer
        Catch ex As Exception
            MsgBox("�����ļ��쳣�����������������ļ����󣬻����������쳣��", MsgBoxStyle.Exclamation)
            Return ""
        End Try
    End Function
    '��ĳ������
    Sub openApp(pAppName As String, Optional IsClose As Boolean = True)
        If IsClose Then
            Dim ps As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcesses()
            For Each p As System.Diagnostics.Process In ps
                If p.ProcessName.ToUpper() = pAppName.ToUpper() Then
                    p.Kill()
                    'break;//��ֹ���ڶ������,����������˶��
                End If
            Next
        End If
        System.Diagnostics.Process.Start(pAppName)
    End Sub
End Class