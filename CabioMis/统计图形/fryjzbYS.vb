'************************************************************************************************
'*�������ƣ�fryjzbYS
'*��    �ܣ��ͼ������ܱ�
'*�� д �ߣ�yangshuai
'*��д����
'*��    �䣺shuaigoplay@yahoo.com.cn
'*��    �룺
'*��    ����excel�ļ�
'*�� �� �ߣ�
'*�޸����ڣ�
'*��    ע��
'************************************************************************************************
Public Class fryjzbYS
    Private ylbdb As DataTable '��ѯ�����ͼ��ʹ��
    Private Sub fryjzbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        wz()
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '��ʾ���µ��·�
    End Sub

    '********************************************************************************************
    '*�������ƣ�getYJSCZBdatatable
    '*��    �ܣ������ͼ������ܱ����ݵ�datatable
    '*�� д �ߣ�yangshuai
    '*��д����
    '*��    �䣺shuaigoplay@yahoo.com.cn
    '*��    �룺monthStr as string :�·��ַ������ɶ���·����ÿ���·��ԡ�,������
    '*��    �����ͼ������ܱ����ݵ�datatable
    '*�� �� �ߣ�
    '*�޸����ڣ�
    '*��    ע��
    '********************************************************************************************
    Public Function getYJSCZBdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        Dim monthArr() As String  '�ֽ��·��ַ���������
        Dim tmpMonthLow As String '��ʱ��λ����
        Dim tmpMonthhigh As String '��ʱ��λ����
        Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
        Dim myread As New Data.OleDb.OleDbCommand()
        Dim rs As Data.OleDb.OleDbDataReader
        '���datatable�п�ʼ
        dt.Columns.Add("ʱ����", GetType(String))
        dt.Columns.Add("ʱ��ֹ", GetType(String))
        dt.Columns.Add("�Ź�ֹ�޺�", GetType(String)) '�Ź�ֹ�޺�Ϊ��ʱ����ڣ����һ��ʱ��ķŹ޵�����,ע�������ԷŹ�ʱ��Ϊ����
        dt.Columns.Add("Harvest", GetType(String)) '�Ź�������,ע�������ԷŹ�ʱ��Ϊ����
        dt.Columns.Add("Contaminate", GetType(String)) ''QC�Ź�ΪȾ��������,ע�������Դ��QCʱ��Ϊ����
        dt.Columns.Add("Harvest Net AA", GetType(String)) ''��Ϊ���ϵ�ë������NETAAƽ��ֵ����ƽ��0ֵ,ע�������ԷŹ�ʱ��Ϊ����
        'dt.Columns.Add("Contaminate rate", Type.GetType("System.String"))
        dt.Columns.Add("ë��ֹ����", GetType(String)) 'ë��ֹ�޺�Ϊ��ʱ����ڣ����һ��ʱ���ë�͵�����,ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("ë�ͽ�������", GetType(Integer)) 'ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("Crude oil", GetType(Double)) 'ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("����ë��", GetType(Double)) '��QA�����������Ϊ��ʶ��ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("Batch yield", GetType(String)) '����ë�Ͳ���,��Ϊ���ϵ�ë�������Բ�Ϊ���ϵ�������ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("ë��ARA����", GetType(Double)) '��ARA����ƽ��ֵ����ƽ��0ֵ��ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("Extraction yield rate%", GetType(Double)) '�������ʣ�ע��������ë�Ͳ���ʱ��Ϊ����
        dt.Columns.Add("��Ʒ��ֹ����", GetType(String)) '��Ʒ��ֹ�޺�Ϊ��ʱ����ڣ����һ��ʱ��ĳ�Ʒ�͵����ţ�ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("��Ʒ�Ͳ�������", GetType(Integer)) '��Ʒ�Ͳ�������Ϊ��ʱ����ڣ������ϼƣ�ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("Input Crude oil", GetType(String)) '��Ʒ����������ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("Finished  Oil", GetType(String)) '��Ʒ�Ͳ�����ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("���ϳ�Ʒ��", GetType(String)) '��QA�����������Ϊ��ʶ����ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("��Ʒ��ARA����", GetType(Double)) ''��Ʒ��ARA������ARA����ƽ��ֵ����ƽ��0ֵ��ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("Oil Yield(weight)rate%", GetType(String)) '��������,'��Ʒ������ƽ��ֵ����ƽ��0ֵ��ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("Yield(AA) rate%", GetType(String)) '��Ʒ��AA����ƽ��ֵ����ƽ��0ֵ��ע�������Գ�Ʒ��������Ϊ����
        dt.Columns.Add("������Ʒ�Ͳ���", GetType(Double)) '��Ϊ���ϵĳ�Ʒ�������Բ�Ϊ���ϵ�������ע�������Գ�Ʒ��������Ϊ����
        '���datatable�н���
        cnn.Open()
        myread.Connection = cnn
        monthArr = Split(monthStr, ",")
        For i As Integer = 2 To monthArr.Length Step 2
            Dim dataRow As Data.DataRow
            Dim index As Integer = 0
            dataRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            dataRow(0) = tmpMonthLow
            dataRow(1) = tmpMonthhigh
            tmpMonthhigh &= " 23:59:59"
            '''''''''''''''''''''''''''''''''''''''''''''''''''�Ź�ֹ�޺�Ϊ��ʱ����ڣ����һ��ʱ��ķŹ޵�����
            myread.CommandText = "select top 1  tb_x825p_num3 from tb_x825p where tb_x825p_jgrq2 between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' order by tb_x825p_jgrq2 desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("�Ź�ֹ�޺�") = rs(0)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''�Ź�������
            myread.CommandText = "select count(*) from tb_x825p where tb_x825p_jgrq2 between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Harvest") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''QC�Ź�ΪȾ��������
            myread.CommandText = "select count(*) from tb_q546i where tb_q546i_qcrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and  tb_q546i_a941s='Ⱦ��' and tb_q546i_t651l='�Ź�'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Contaminate") = rs(0) ' 'Ⱦ����
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��Ϊ���ϵ�ë������NETAAƽ��ֵ����ƽ��0ֵ,ע�������ԷŹ�ʱ��Ϊ����
            myread.CommandText = "select  avg(tb_x825p_k317c) from tb_x825p where tb_x825p_jgrq2 between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_x825p_qaspjg<>'����' and tb_x825p_k317c>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Harvest Net AA") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''ë��ֹ����
            myread.CommandText = "select top 1  tb_x825p_num from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' order by tb_x825p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("ë��ֹ����") = rs(0)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''ë����������������
            myread.CommandText = "select count(*), sum(tb_x825p_s640k) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("ë�ͽ�������") = rs(0)
                dataRow("Crude oil") = rs(1)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''����ë��
            myread.CommandText = "select  sum(tb_x825p_s640k) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_x825p_qaspjg='����'"
            rs = myread.ExecuteReader
            If rs.Read Then
          
                dataRow("����ë��") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��Ϊ���ϵ�ë�������Բ�Ϊ���ϵ�����
            myread.CommandText = "select  count(*), sum(tb_x825p_s640k) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_x825p_qaspjg<>'����'"
            rs = myread.ExecuteReader
            If rs.Read Then
                Try
                    dataRow("Batch yield") = FormatNumber(rs(1) / rs(0), 2)
                Catch ex As Exception
                    dataRow("Batch yield") = 0
                End Try

            End If
            rs.Close()
            '����������������������������������������������������ARA����ƽ��ֵ����ƽ��0ֵ

            myread.CommandText = "select avg(tb_x825p_m387e) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_x825p_m387e>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("ë��ARA����") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()

            ''''''''''''''''''''''''''''''''''''''''ë������ƽ��ֵ����ƽ��0ֵ
            myread.CommandText = "select avg(tb_x825p_sn) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_x825p_sn>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Extraction yield rate%") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
    
            '''''''''''''''''''''''''''''''''''''''''''''''''''��Ʒ�ͳ�Ʒ��ֹ����
            myread.CommandText = "select top 1  tb_h195z_num from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' order by tb_h195z_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("��Ʒ��ֹ����") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select sum(tb_h195z_n426f),sum(tb_h195z_m408e),count(*) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Input Crude oil") = DeepCode.DeepDoStr.Null2zero(rs(0)) 'ë��Ͷ����/ÿ��Ʒ����Kg��
                dataRow("Finished  Oil") = DeepCode.DeepDoStr.Null2zero(rs(1)) '��Ʒ�Ͳ���
                dataRow("��Ʒ�Ͳ�������") = DeepCode.DeepDoStr.Null2zero(rs(2))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''���ϳ�Ʒ��
            myread.CommandText = "select sum(tb_h195z_m408e) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_h195z_qaspjg='����'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("���ϳ�Ʒ��") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''��Ʒ��ARA������ARA����ƽ��ֵ����ƽ��0ֵ
            myread.CommandText = "select avg(tb_h195z_c6u) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_h195z_c6u>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("��Ʒ��ARA����") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''��Ʒ������ƽ��ֵ����ƽ��0ֵ
            myread.CommandText = "select avg(tb_h195z_u704m) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_h195z_u704m>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Oil Yield(weight)rate%") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''��Ʒ��AA��������ƽ��ֵ����ƽ��0ֵ
            myread.CommandText = "select avg(tb_h195z_q554i) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_h195z_q554i>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Yield(AA) rate%") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��Ϊ���ϵĳ�Ʒ�������Բ�Ϊ���ϵ�����
            myread.CommandText = "select   count(*), sum(tb_h195z_m408e) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_h195z_qaspjg<>'����'"
            rs = myread.ExecuteReader
            If rs.Read Then
                Try
                    dataRow("������Ʒ�Ͳ���") = FormatNumber(rs(1) / rs(0), 2)
                Catch ex As Exception
                    dataRow("������Ʒ�Ͳ���") = 0
                End Try

            End If
            rs.Close()
            '������������
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim j1 As Double = Null2zero(dataRow(2))

            'Try
            '    If j1 = 0 Then
            '        dataRow("Contaminate rate") = 0
            '    Else
            '        dataRow("Contaminate rate") = Format(dataRow("Contaminate") / dataRow("Harvest"), "0.00%")
            '    End If

            'Catch ex As Exception
            '    dataRow("Contaminate rate") = 0
            'End Try

            '''''''''''''''''''''''''
  
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dt.Rows.Add(dataRow)
        Next
        'ylbdb = dt
        Dim aaRow As DataRow = dt.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 3 To dt.Columns.Count - 1
            Dim m As Double = 0
            Try
                m = FormatNumber(GF_jsColumnTotal(dt, i, 0, dt.Rows.Count - 1), 2)
            Catch ex As Exception

            End Try
            aaRow(i) = m

        Next
        dt.Rows.Add(aaRow)
        'Monthly Plan
        'aaRow = dt.NewRow()
        'aaRow(0) = "Monthly Plan"
        'aaRow(2) = "Monthly Plan"
        'dt.Rows.Add(aaRow)

        getYJSCZBdatatable = dt
    End Function
    Private Sub ShowLine(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking, ByVal colorC() As Color, ByVal SeriesBegin As Integer)
        If DataTableName.Columns.Count < 2 Then
            MsgBox("����Ӧ����2��") : Return
        End If
        With MsChartName
            .Series.Clear() : .Titles.Clear()
            .DataSource = DataTableName 'ָ������Դ
            .ChartAreas(0).Area3DStyle.Enable3D = Show3D '��ʾ����3DЧ��
            .ChartAreas(0).AxisX.Interval = 1
            If DataTableName.Rows.Count > 60 Then
                .ChartAreas(0).AxisX.Interval = 6
            End If
            .Titles.Add(ChartTitle) '��������
            ' XY������ķŴ�
            .ChartAreas(0).CursorX.IsUserEnabled = True
            .ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            .ChartAreas(0).AxisX.ScaleView.Zoomable = True
            .ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True
            .ChartAreas(0).CursorY.IsUserEnabled = True
            .ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            .ChartAreas(0).AxisY.ScaleView.Zoomable = True
            .ChartAreas(0).AxisY.ScrollBar.IsPositionedInside = True
        End With

        With MsChartName.Legends(0)
            .Enabled = True 'ȷ����ʾ����
            .Alignment = StringAlignment.Center '�������ͼ�ķ�ʽ
            .TitleForeColor = Color.Black '��ɫ
            .TitleAlignment = StringAlignment.Center '���ֶ��뷽ʽ
            .TitleSeparator = DataVisualization.Charting.LegendSeparatorStyle.Line '�ָ���ʽ
            .TitleSeparatorColor = Color.Black
            .Docking = ChartTitleDock '���ͼ��ͣ����ʽ
        End With

        For i As Integer = SeriesBegin To DataTableName.Columns.Count - 1
            MsChartName.Series.Add(DataTableName.Columns(i).Caption)
            With MsChartName.Series(i - SeriesBegin)
                .ChartType = DataVisualization.Charting.SeriesChartType.Line '����ͼ
                .BorderWidth = 3 '�ߴ�ϸ
                .ShadowOffset = 2 '��Ӱ
                .Color = colorC(i - SeriesBegin)
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle '�����״
                .MarkerSize = 5 '���С
                .MarkerColor = Color.Gold '�����ɫ
                .IsValueShownAsLabel = True '��ʾ���ֵ
                .XValueMember = DataTableName.Columns(0).Caption 'ָ���������ֶ�
                .XValueType = DataVisualization.Charting.ChartValueType.Auto 'ָ����������
                .YValueMembers = DataTableName.Columns(i).Caption 'ָ���������ֶ�
            End With
        Next
        MsChartName.Update() '��仰����Ҫ��������ʾ�����tooltip
        '��ʾ����ĸ������tooltipΪDataTableName0�е�ֵ
        For i As Integer = 0 To MsChartName.Series.Count - 1
            For j As Integer = 0 To MsChartName.Series(i).Points.Count - 1
                MsChartName.Series(i).Points(j).ToolTip = DataTableName.Rows(j)(0)
            Next
        Next

    End Sub
    Private Sub wz()

        ListView1.Width = Me.Width - ListView1.Left - 10
        Dim kd As Integer = Int(Me.Width / 2)
        Panel1.Width = kd
        Panel1.Height = Me.Height - Panel1.Top - 30
        'MsgBox(Chart1.Height)
        Panel2.Left = Panel1.Width + Panel1.Left
        Panel2.Width = Me.Width - Panel2.Left
        Panel2.Height = Panel1.Height
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim monthStr As String = GF_Time2Week(CDate(nian1.Text & "-" & yue1.Text))
        Dim dt As Data.DataTable = getYJSCZBdatatable(monthStr)
        ylbdb = dt.Copy()
        GS_DataGridViewbyDb(ListView1, dt, True, True)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ys(4) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Pink : ys(3) = Color.Gold : ys(4) = Color.Blue
        '��������������������������������������������
        ylbdb.Columns.RemoveAt(0)
        ylbdb.Columns.RemoveAt(ylbdb.Columns.Count - 1)
        ShowLine(Chart2, False, ylbdb, "��Ʒ��ƽ��ָ��(��)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 3)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DeepDoDataTable.DelDataColAtIndex(ylbdb, "1,2,5,6,7,8,12,13,14,15,16,17,18,19")
        ShowLine(Chart1, False, ylbdb, "ë��ƽ��ָ��(��)", DataVisualization.Charting.Docking.Top, ys, 1)
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        'GS_dbtoexcel(ylbdb, GroupBox1.Text, Me)
        GS_toexcel(ListView1, GroupBox1.Text, Me)
    End Sub
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub fryjzbYS_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub ToChartImg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg2.Click
        ClassDeepChart.GS_SaveChartImg(Chart2)
    End Sub

    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
End Class