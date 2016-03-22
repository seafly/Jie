Module QCService
    Public Function GetQCDataFromSourceTable(sourceTable As DataTable, m_qclx As Integer, m_jcb As String, m_wlbs As Integer) As DataTable
        Dim returnTable As DataTable = New DataTable()
        Dim sql As String = ""
        Dim qcItemsTable As DataTable = Nothing

        Dim dt As DataTable
        Select Case m_qclx
            Case en_QcLX.物品
                sql = "select * from " & m_jcb & " where " & m_jcb & "_ID=" & m_wlbs
                dt = Cl_DataMag.GF_CreateDataSource(sql)
                qcItemsTable = GetQCItems(m_qclx, dt.Rows(0)("tb_i259b_i231a"))
            Case en_QcLX.成品
                qcItemsTable = GetQCItems(m_qclx, GetType(en_cpMc).YanGetEnT2N(m_jcb))
            Case en_QcLX.工序
                qcItemsTable = GetQCItems(m_qclx, GetType(en_LcTableName).YanGetEnT2N(m_jcb))
        End Select
        '使用键值集合
        Dim dataDic As Dictionary(Of String, String) = New Dictionary(Of String, String)()


        If (qcItemsTable IsNot Nothing) Then
            For Each qcItem As DataRow In qcItemsTable.Rows
                sourceTable.Columns.Add(qcItem("tb_QcXm_xmmc").ToString())
            Next
        End If
        



        Return Nothing
    End Function

    Public Function GetQCItems(qcType As String, sourceCode As String) As DataTable
        Dim dt As DataTable
        Dim sql = "select * from tb_QcXm where tb_QcXm_wldm = '" & sourceCode & "' and tb_QcXm_qclx='" & qcType & "' "
        dt = Cl_DataMag.GF_CreateDataSource(sql)
        Return dt
    End Function

End Module
