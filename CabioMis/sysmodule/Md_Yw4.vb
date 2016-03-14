Module Md_Yw4
    ''''''''''''''''''''''''''''''下面3个过程主要保证部门操作界面的文本查询
    Public Sub GS_FaceSearch(ByVal ComboBoxName As ComboBox, ByVal tbname As String, ByVal dowhat As Integer,Optional ByVal pDefaultText As string="")
        Dim db As DataTable = GF_GetFieldByTbName(tbname, dowhat)
        GS_wlbktlr2(ComboBoxName, db, 4, pDefaultText) '显示字段中文名
        ComboBoxName.Tag = db '绑定到这个属性上去
    End Sub
    '根据表名称得到相关类型的字段的DB
    Public Function GF_GetFieldByTbName(ByVal tbname As String, ByVal dowhat As Integer) As DataTable
        '得到它的所有字段\
        Dim sql As String = ""
        Select Case dowhat
            Case 0 '返回所有数字字段
                sql = " and tb_biaozdinf_lx in('tinyint','int','money','smallint')"
            Case 1 '返回所有文本字段
                sql = " and tb_biaozdinf_lx in('varchar(8000)')"
            Case 2 '返回所有日期时间字段
                sql = " and tb_biaozdinf_lx in('datetime','smalldatetime')"
            Case 3 '返回所有
            Case 4
            Case 2 '返回所有日期时间字段
                sql = " and tb_biaozdinf_lx in('tinyint','int','money','smallint','varchar(8000)')"
        End Select
        Dim db As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(_D.G_zdinf, "tb_biaozdinf_biao='" & tbname & "'" & sql)
        Return db
    End Function
    'Datatable 后缀条件
    Public Function GF_FaceSearchBDS(ByVal ComboBoxName As ComboBox, ByVal TextboxName As TextBox) As String
        Dim cxkr As String = TextboxName.Text.Trim
        If cxkr = "" Then
            Return ""
        End If
        cxkr = Replace(cxkr, "‘", "'")
        Dim zdzw As String = ComboBoxName.Text
        If zdzw = "" Then
            Return ""
        End If
        Dim db As DataTable = CType(ComboBoxName.Tag, DataTable)
        '得到英文字段名
        Dim jgzd As String = DeepCode.DeepDoDataTable.GF_cnwithen(db, "tb_biaozdinf_mx='" & zdzw & "'", 1)
        Dim sql As String = " and [" & jgzd & "] like '%" & cxkr & "%'"
        Return sql
    End Function
   
    '上面3个过程主要保证部门操作界面的文本查询
    Public Sub GS_ysgx(ByVal str As DataGridView) 'DataGridVie最后一行颜色更新

        With str
            Dim n As Integer = .Rows.Count
            If n > 0 Then
                For i As Integer = 0 To .Columns.Count - 1
                    .Rows(n - 1).Cells(i).Style.BackColor = Color.GreenYellow
                Next
            End If

        End With

    End Sub
    '确定时间段选择是否正确
    Public Function GF_qdsjdx(ByVal sj1 As String, ByVal sj2 As String) As Boolean
        Dim tt1, tt2 As DateTime
        tt1 = sj1 : tt2 = sj2
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return False
        Else
            Return True
        End If
    End Function
    '部分表的修改只有操作人和管理员有权限的判断
    Public Function GF_qdxgjsqx(ByVal sjid As String, ByVal sjbm As String, ByVal sjjs As String, ByVal sjgh As String) As Boolean
        If sjjs = "管理员" Then
            Return True
        Else
            Dim zd As String = sjbm & "_czrgh"
            Dim sql As String = "select " & zd & " from " & sjbm & " where " & sjbm & "_id=" & sjid '得到数据的工号
            Dim dttemp As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
            Dim cxgh As String = dttemp.Rows(0)(0)
            If cxgh <> sjgh Then
                MsgBox("你没有修改的权限") : Return False
            Else
                Return True
            End If
        End If

    End Function
End Module
