Imports DeepCode.DeepDoDataTable
Public Class frzchuo
    Dim fn As String '���ࣺë��tb_x825p����Ʒ��tb_h195z
    Dim fnkc As String
    Dim m_strLb As String   '���ֲ�Ʒ�����������ʽ
    Dim m_strLbKc As String '�����������ʽ
    Dim sfjchcx As Boolean = False '������������ѯ��Խ��������޸Ĳ���
    Dim leftdb, rightdb As DataTable '�������б�����б�Ϊ����EXCEL����Ӱ��ԭ��������׼��
    Private Sub frzchuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Call weizhi()
        fn = "tb_x825p" 'ë��
        fnkc = "tb_x825pkc"
        Call csh()
        ToolStripLabel1.Text = getallheji()
        Label3.Text = getallhejibf()
        Dim sz1 As String() = {"��������ѯ", "��ӹ��Ͳ�ѯ", "��ӹ��۲�ѯ"}
        GS_wlbktlr3(ComboBox1, sz1, "")
    End Sub
    '����Ĺر�
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '����Ĺر�
    End Sub
    Private Sub weizhi()
        GroupBox1.Width = Me.Width / 2 - 350
        GroupBox2.Left = GroupBox1.Width + GroupBox1.Left
        GroupBox2.Width = Me.Width - GroupBox2.Left - 20
        GroupBox3.Width = Me.Width - GroupBox3.Left
        GroupBox3.Height = Me.Height - GroupBox3.Top
        ListView3.Width = GroupBox3.Width - ListView3.Left - 30
        ListView3.Height = GroupBox3.Height - ListView3.Top - 40
    End Sub
    Private Sub csh()
        Dim sql As String = Nothing
        Dim db1 As DataTable
        Dim arazd As String = "" 'ARA�����ֶ�
        Dim cpdmzd As String = "" '���������ֶ�
        'listview1
        Select Case fn
            Case "tb_x825p" 'ë��
                'sql = "select " & fn & "_id," & fn & "_mingc," & fn & "_jiagdm," & fn & "_num," & fn & "_jgrq," & fn & "_hblsrkzl," & fn & "_hblsrkzl," & fn & "_bz ," &
                '    fn & "_cw," & fn & "_fhxz from " & fn & " where (" & fn & "_glid is null  or " & fn & "_glid='') "  '�²�ID
                sql = "select " & fn & "_id," & fn & "_mingc," & fn & "_jiagdm," & fn & "_num," & fn & "_jgrq,tb_x825p_s640k," & fn & "_hblsrkzl," & fn & "_bz ," &
                    fn & "_cw," & fn & "_fhxz from " & fn & " where (" & fn & "_glid is null  or " & fn & "_glid='') "  '����ë���������²�ID
                arazd = "tb_x825pkc_m387e"
            Case "tb_h195z" '��Ʒ��
                'sql = "select " & fn & "_id," & fn & "_mingc," & fn & "_jiagdm," & fn & "_num," & fn & "_jgrq," & fn & "_hblsrkzl," & fn & "_bz," & fn & "_cw," &
                '    fn & "_fhxz from " & fn & " where " & fn & "_hblsrkzl>0 "   '�����������
                sql = "select " & fn & "_id," & fn & "_mingc," & fn & "_jiagdm," & fn & "_num," & fn & "_jgrq,tb_h195z_m408e," & fn & "_bz," & fn & "_cw," &
                    fn & "_fhxz from " & fn & " where (" & fn & "_glid is null  or " & fn & "_glid='') and not (tb_h195z_hblsrkzl=0 and tb_h195z_bz='���¹������') and tb_h195z_m408e>0"   '��Ʒ�������������޸�Ϊ�²�ID
                arazd = "tb_h195zkc_c6u"
                'arazd = "[DHA����/(w/%)]"
            Case "tb_x832p" '��Ʒ��
                sql = "select " & fn & "_id," & fn & "_mingc," & fn & "_jiagdm," & fn & "_num," & fn & "_jgrq," & fn & "_i232a," & fn & "_bz," & fn & "_cw," &
                    fn & "_fhxz from " & fn & " where  " & fn & "_i232a>0 and  (" & fn & "_xbtb is  null or " & fn & "_xbtb='')"  '��Ʒ�������²���
                arazd = "tb_x832pkc_d65v"
                cpdmzd = ",tb_x832pkc_scdm"
        End Select
        sql &= m_strLb
        db1 = GF_CreateDataSource(G_cnnstr, sql)

        Call GS_useviewbydb2(ListView1, db1, -1, 97)
        '''''''''''''''''''''''''''
        leftdb = GF_TranEtoC2(db1)
        '''''''''''''''''''''''''''''''''''
        'listview2
        Select Case fn
            Case "tb_x825p"
                sql = "select " & fnkc & "_id," & fnkc & "_cplb," & fnkc & "_mingc," & fnkc & "_jiagdm," & fnkc & "_num," & fnkc & "_yg," & fnkc & "_sykczl," &
                    fnkc & "_ckcl," & fnkc & "_qaspjg," & fnkc & "_qajgsm, " & fnkc & "_rkbz," & fnkc & "_jgrq, " & arazd & "" & cpdmzd & " ," & fnkc & "_cw," &
                    fnkc & "_bzxs," & fnkc & "_rkts," & fnkc & "_kczl," & fnkc & "_bf , " & fnkc & "_bfmx," & fnkc & "_wjbgrq , " & fnkc & "_sykcsm," & fnkc & "_rkrq," &
                    fnkc & "_kdlk," & fnkc & "_bfb," & fnkc & "_storagemslk," & fnkc & "_storagewzlk," & fnkc & "_remind," & fnkc & "_fhxz," & fnkc & "_mscw," & fnkc &
                    "_wzcw," & fnkc & "_bfcw " &
                    "from " & fnkc & " where (" & fnkc & "_sykczl>0 or " & fnkc & "_bf>0 or " & fnkc & "_ckcl>0) "
            Case "tb_h195z" '��������Ʒ���䷽�ֶ�
                sql = "select " & fnkc & "_id," & fnkc & "_cplb," & fnkc & "_mingc," & fnkc & "_jiagdm," & fnkc & "_num," & fnkc & "_yg," & fnkc & "_sykczl," & fnkc &
                    "_ckcl, " & fnkc & "_qaspjg," & fnkc & "_qaytjy," & fnkc & "_qajgsm, " & fnkc & "_rkbz," & fnkc & "_jgrq, " & arazd & "" & cpdmzd &
                    " ," & fnkc & "_bzxs," & fnkc & "_rkts," & fnkc & "_kczl," & fnkc & "_bf , " & fnkc & "_bfmx," & fnkc & "_cw," & fnkc & "_num2," & fnkc & "_wjbgrq ," &
                    fnkc & "_sykcsm," & fnkc & "_rkrq," & fnkc & "_kdlk," & fnkc & "_bfb," & fnkc & "_storagemslk," & fnkc & "_storagewzlk," & fnkc & "_remind," & fnkc &
                    "_fhxz," & fnkc & "_mscw," & fnkc & "_wzcw," & fnkc & "_bfcw  from " & fnkc & " where (" & fnkc & "_sykczl>0 or " & fnkc & "_bf>0 or " & fnkc & "_ckcl>0) "
            Case "tb_x832p" '�����Ʒ�ۼ���Ƶ����ͱ������ֶ�
                sql = "select " & fnkc & "_id," & fnkc & "_cplb," & fnkc & "_mingc," & fnkc & "_jiagdm," & fnkc & "_num," & fnkc & "_yg," & fnkc & "_sykczl," & fnkc & "_ckcl," & fnkc & "_qaspjg," & fnkc & "_qajgsm," & fnkc & "_qaytjy, " & fnkc & "_rkbz," & fnkc & "_jgrq, " & arazd & "" & cpdmzd & " ," & fnkc & "_bzxs,tb_x832pkc_cw," & fnkc & "_rkts," & fnkc & "_kczl," & fnkc & "_bf , " & fnkc & "_bfmx," & fnkc & "_wjbgrq ," & fnkc & "_sykcsm," & fnkc & "_rkrq,tb_x832pkc_kdlk," & fnkc & "_bfb," & fnkc & "_storagemslk," & fnkc & "_storagewzlk," & fnkc & "_remind," & fnkc & "_fhxz," & fnkc & "_mscw," & fnkc & "_wzcw," & fnkc & "_bfcw   from " & fnkc & " where (" & fnkc & "_sykczl>0 or " & fnkc & "_bf>0 or " & fnkc & "_ckcl>0)  "
        End Select
        sql &= m_strLbKc

        db1 = GF_CreateDataSource(G_cnnstr, sql)
        db1 = EarlyWarning(db1)
        Call GS_useviewbydb2(ListView2, db1, -1, 97)
        '''''''''''''''''''''''''''''''
        rightdb = GF_TranEtoC2(db1)
        ''''''''''''''''''''''''''''''''

        ''''''''''''''''����涨������ɫ������ʾ(lili)'''''''''''''''
        ''''''''''''''''��Ʒ���Ϊ"APG10", "APG15", "AOGC"�뵱ǰ���ڼ��>=60Ϊ�Ȼ�ɫԤ��,>=90Ϊ��ɫ����
        ''''''''''''''''��Ʒ���Ϊ"AOG40", "APGK"�뵱ǰ���ڼ��>=150Ϊ�Ȼ�ɫԤ��,>=180Ϊ��ɫ����
        'For i As Integer = 0 To db1.Rows.Count - 1
        '    Dim days As Integer '���������
        '    Dim data1 As Date = Now().Date '��ǰ����
        '    Dim data2 As Date '��Ʒ��������

        '    Try '��ֹ����Ϊ�ճ����쳣
        '        data2 = "#" & db1.Rows(i)(fnkc & "_jgrq") & "#"
        '    Catch ex As Exception
        '        data2 = Now()
        '    End Try

        '    days = DateDiff(DateInterval.Day, data2, data1)
        '    Select Case Null2String(db1.Rows(i)(1))
        '        Case "APG10", "APG15", "AOGC", "APGT", "APGE"
        '            If days >= 60 And days < 90 Then
        '                ListView2.Items(i).BackColor = Color.DarkOrange
        '            ElseIf days >= 90 Then
        '                ListView2.Items(i).BackColor = Color.Red
        '            End If
        '        Case "AOG40", "APGK", "AOGF"
        '            If days >= 150 And days < 180 Then
        '                ListView2.Items(i).BackColor = Color.DarkOrange
        '            ElseIf days >= 180 Then
        '                ListView2.Items(i).BackColor = Color.Red
        '            End If
        '    End Select
        'Next

        '''''''''''''''''''''''''''''''''''

    End Sub

    'Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
    '    fn = "tb_x825p" 'ë��
    '    fnkc = "tb_x825pkc"
    '    Call csh()
    'End Sub


    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Close()
    End Sub
    '���������
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
       Dim aa As New Frtb_x824p
        aa.Labelid.Text = GF_GetListText(ListView1, fn & "_id", 0, 2)
        aa.Labeltb.Text = fn
        aa.ph.Text = GF_GetListText(ListView1, fn & "_num", 0, 2)
        aa.KcOne.Text = ListView1.SelectedItems(0).SubItems(5).Text
        aa.KcOne.Tag = ListView1.SelectedItems(0).SubItems(5).Text
        aa.CwOne.Text = Null2String(GF_GetListText(ListView1, fn & "_cw", 0, 2))
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
        Call csh()
        ToolStripLabel1.Text = getallheji() '��ʾ��ʱ��� 
 
    End Sub
    '������
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        If ListView2.SelectedItems.Count = 0 Then
            Exit Sub
        End If
      
        Dim aa As New frchuhuo
        aa.Labelid.Text = GF_GetListText(ListView2, fnkc & "_id", 0, 2)  'id
        aa.Labeltb.Text = fnkc '�л���Ʒ�ۿ��
        aa.ph.Text = GF_GetListText(ListView2, fnkc & "_num", 0, 2) 'id'����
        Dim cwzdsy As Integer = GF_GetListIndexByText(ListView2, "��λ")
        If cwzdsy <> -1 Then
            aa.cw.Text = ListView2.SelectedItems(0).SubItems(cwzdsy).Text '��λ
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If

        Me.AddOwnedForm(aa)
        aa.ShowDialog()
        Call csh()
        ToolStripLabel1.Text = getallheji() '��ʾ��ʱ���

      
    End Sub


    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    '    fn = "tb_h195z" '��Ʒ��
    '    fnkc = "tb_h195zkc" '��Ʒ��
    '    Call csh()
    'End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView3, GroupBox3.Text, Me)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
   
    End Sub
    '��Ʒ��
    'Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
    '    fn = "tb_x832p"
    '    fnkc = "tb_x832pkc"
    '    Call csh()
    'End Sub
    '��ѯ
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim kssj, jssj As DateTime
        kssj = ks.Text : jssj = CType(js.Text & " 23:59:00", DateTime)
        If GF_qdsjdx(kssj, jssj) = False Then
            Return
        End If
        Dim sql As String = ""
        Select Case ComboBox1.Text
            Case "��������ѯ"
                sql = "select tb_jch_ID,tb_jch_cplb,tb_jch_jiagdm,tb_jch_mingc,tb_jch_num,tb_jch_pldh,tb_jch_cz,tb_jch_sl,tb_jch_rq,tb_jch_yt,tb_jch_bz,tb_jch_czrgh,tb_jch_chts,tb_jch_fgyph,tb_jch_yfcllygd,tb_jch_xgsm,tb_jch_pljhid ,tb_jch_jiagdmsm,tb_jch_bfb,tb_jch_storagemslk,tb_jch_kdlk,tb_jch_storagewzlk from tb_jch where tb_jch_rq between '" & kssj & "' and  '" & jssj & "'  "
                sfjchcx = True
            Case "��ӹ��Ͳ�ѯ"
                sql = "select * from tb_fgyf where tb_fgyf_rq between '" & kssj & "' and '" & jssj & "' "
                sfjchcx = False
            Case "��ӹ��۲�ѯ"
                sql = "select tb_x832p_jgrq,tb_x832p_num,tb_x832p_cplb,tb_x832p_i232a,tb_x832p_bz from vw_x832p where tb_x832p_jgrq between '" & kssj & "' and '" & jssj & "' and tb_x832p_bz like'%����ӹ���%' "
                sfjchcx = False
        End Select
        '''''''''''''''''''''''''''''''''''''''''''''''
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext) '�ı���ѯ�������ҽӵ���ѯ�ı�
        sql &= sqlbdssep
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(ListView3, db1, True, True)
        DeepCode.DeepDoGridView.HideSomeCol(ListView3, 0)
        GroupBox3.Text = "��ѯ�����" & GF_getListViewsz(ListView3) & "����¼"
    End Sub


    Public Function getallheji() As String
        Dim t As String = ""
        Dim sql As String = "DECLARE @my money, @cpy money" & vbCrLf
        sql &= "select @my=sum(tb_x825pkc_sykczl) from tb_x825pkc where tb_x825pkc_sykczl>0" & vbCrLf
        sql &= "select @cpy=sum(tb_h195zkc_sykczl) from tb_h195zkc where (tb_h195zkc_cplb='AOG40' or tb_h195zkc_cplb='AOG40 HB' or tb_h195zkc_cplb='AOGF')  and tb_h195zkc_sykczl>0" & vbCrLf
        sql &= "select @my,@cpy" & vbCrLf
        Dim dtemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        t = "��ǰʣ����>>ë�ͣ�" & dtemp.Rows(0)(0) & " ��Ʒ�ͣ�" & dtemp.Rows(0)(1) & "��Ʒ��:"
        sql = "SELECT tb_x832pkc_cplb,sum(tb_x832pkc_sykczl) from tb_x832pkc where tb_x832pkc_sykczl>0 group by tb_x832pkc_cplb"
        dtemp = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dtemp.Rows.Count - 1
            t &= dtemp.Rows(i)(0) & "��" & dtemp.Rows(i)(1) & ","
        Next
        t = GF_removedh(t) & "  ;"
        getallheji = t
    End Function

    Public Function getallhejibf() As String
        Dim t As String = ""
        Dim sql As String = "DECLARE @my money, @cpy money" & vbCrLf
        sql &= "select @my=sum(tb_x825pkc_bf) from tb_x825pkc where tb_x825pkc_bf>0 " & vbCrLf
        sql &= "select @cpy=sum(tb_h195zkc_bf) from tb_h195zkc where tb_h195zkc_bf>0" & vbCrLf
        sql &= "select @my,@cpy" & vbCrLf
        Dim dtemp As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        t = "����Ʒ���>>ë�ͣ�" & dtemp.Rows(0)(0) & " ��Ʒ�ͣ�" & dtemp.Rows(0)(1) & "��Ʒ��:"
        sql = "SELECT tb_x832pkc_cplb,sum(tb_x832pkc_bf) from tb_x832pkc where tb_x832pkc_bf>0 group by tb_x832pkc_cplb"
        dtemp = GF_CreateDataSource(G_cnnstr, sql)
        For i As Integer = 0 To dtemp.Rows.Count - 1
            t &= dtemp.Rows(i)(0) & "��" & dtemp.Rows(i)(1) & ","
        Next
        t = GF_removedh(t)
        getallhejibf = t
    End Function

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        GS_dbtoexcel(leftdb, GroupBox1.Text, Me)
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        GS_dbtoexcel(rightdb, GroupBox2.Text, Me)
    End Sub


    Private Sub frzchuo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim bm As String = ""
        Select Case ComboBox1.Text
            Case "��������ѯ"
                bm = "tb_jch"
            Case "��ӹ��Ͳ�ѯ"
                bm = "tb_fgyf"
            Case "��ӹ��۲�ѯ"
                bm = "tb_x832p"
        End Select
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, bm, 1) '�ı���ѯ��������������ı��ֶε���ʾ
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


    Private Sub ToolStripButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim aa As New Frmodkc
        aa.ShowDialog()
        ToolStripLabel1.Text = getallheji() '��ʾ��ʱ���
    End Sub
    '�����ƻ�
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim aa As New Frddzxjh
        aa.ShowDialog()
    End Sub
    '�����˻���
    Private Sub ToolStripButton9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        Dim aa As New FrReturn
        aa.ShowDialog()
    End Sub
    '�ڲ�ת��
    Private Sub ToolStripButton8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Dim aa As New FrInternal
        aa.ShowDialog()
    End Sub
    '��Ʒ�˿�
    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Dim aa As New FrChenReturn
        aa.ShowDialog()
    End Sub
    'Ԥ��ʱ��
    '��������+Ԥ��ʱ��<="ϵͳʱ��" ��ʾԤ��
    Private Function EarlyWarning(ByVal dt As DataTable) As DataTable
        Dim sql As String = ""
        With dt
            For Each DR As DataRow In .Rows
                sql = "select  tb_warning_rq  from  tb_warning where tb_warning_dm='" & DR(fnkc & "_cplb") & "' "
                Dim DtWarn As DataTable = GF_CreateDataSource(G_cnnstr, sql)
                If DtWarn.Rows.Count > 0 Then
                    Try
                        Dim DateTotal As Date = DateAndTime.DateAdd(DateInterval.Day, DtWarn.Rows(0)("tb_warning_rq"), DR(fnkc & "_jgrq"))
                        If DateTotal <= Now.Date Then
                            DR(fnkc & "_remind") = "Ԥ��"
                        End If
                    Catch
                    End Try
                End If
            Next
        End With
        Return dt
    End Function

    Private Sub ToolStripButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.ButtonClick
        fn = "tb_h195z" '��Ʒ��
        fnkc = "tb_h195zkc" '��Ʒ��
        m_strLb = ""
        m_strLbKc = ""
        Call csh()
    End Sub

    Private Sub ARA��Ʒ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARA��Ʒ��ToolStripMenuItem.Click
        fn = "tb_h195z" '��Ʒ��
        fnkc = "tb_h195zkc" '��Ʒ��
        m_strLb = " and (tb_h195z_cplb='AOG40' or tb_h195z_cplb='AOGF')"
        m_strLbKc = " and (tb_h195zkc_cplb='AOG40' or tb_h195zkc_cplb='AOGF')"
        Call csh()
    End Sub

    Private Sub DHA��Ʒ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DHA��Ʒ��ToolStripMenuItem.Click
        fn = "tb_h195z" '��Ʒ��
        fnkc = "tb_h195zkc" '��Ʒ��
        m_strLb = " and tb_h195z_cplb='DOGF'"
        m_strLbKc = " and tb_h195zkc_cplb='DOGF'"
        Call csh()
    End Sub

    Private Sub ToolStripButton5_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.ButtonClick
        fn = "tb_x825p" 'ë��
        fnkc = "tb_x825pkc"
        m_strLb = ""
        m_strLbKc = ""
        Call csh()
    End Sub

    Private Sub ARAë��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARAë��ToolStripMenuItem.Click
        fn = "tb_x825p" 'ë��
        fnkc = "tb_x825pkc"
        m_strLb = " and tb_x825p_cplb='AOGC'"
        m_strLbKc = " and tb_x825pkc_cplb='AOGC'"
        Call csh()
    End Sub

    Private Sub DHAë��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DHAë��ToolStripMenuItem.Click
        fn = "tb_x825p" 'ë��
        fnkc = "tb_x825pkc"
        m_strLb = " and tb_x825p_cplb='DOGC'"
        m_strLbKc = " and tb_x825pkc_cplb='DOGC'"
        Call csh()
    End Sub

    Private Sub ToolStripButton6_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.ButtonClick
        fn = "tb_x832p"
        fnkc = "tb_x832pkc"
        m_strLb = ""
        m_strLbKc = ""
        Call csh()
    End Sub

    Private Sub ARA��Ʒ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARA��Ʒ��ToolStripMenuItem.Click
        fn = "tb_x832p"
        fnkc = "tb_x832pkc"
        m_strLb = " and (tb_x832p_cplb='APGE' or tb_x832p_cplb='APGK' or tb_x832p_cplb='APGT')"
        m_strLbKc = " and (tb_x832pkc_cplb='APGE' or tb_x832pkc_cplb='APGK' or tb_x832pkc_cplb='APGT')"
        Call csh()
    End Sub

    Private Sub DHA��Ʒ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DHA��Ʒ��ToolStripMenuItem.Click
        fn = "tb_x832p"
        fnkc = "tb_x832pkc"
        m_strLb = " and tb_x832p_cplb='DPGE'"
        m_strLbKc = " and tb_x832pkc_cplb='DPGE'"
        Call csh()
    End Sub
End Class

