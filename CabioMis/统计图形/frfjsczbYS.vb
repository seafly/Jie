'************************************************************************************************
'*�������ƣ�frfjsczbYS
'*��    �ܣ��ۼ������ܱ�
'*�� д �ߣ�yangshuai
'*��д����
'*��    �䣺shuaigoplay@yahoo.com.cn
'*��    �룺
'*��    ����excel�ļ�
'*�� �� �ߣ�
'*�޸����ڣ�
'*��    ע��
'************************************************************************************************
Public Class frfjsczbYS
    Private ylbdb As DataTable '��ѯ�����ͼ��ʹ��
    Private Sub frfjsczbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Public Function getFJSCZBdatatable(ByVal monthStr As String) As Data.DataTable
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
        dt.Columns.Add("1#��ֹ����", GetType(String)) '��Ʒ��������������
        dt.Columns.Add("1#����Ʒ����", GetType(Integer)) '��Ʒ��������������
        dt.Columns.Add("1#����Ʒ����", GetType(Double)) '��Ʒ��������������
        dt.Columns.Add("1#��������", GetType(Double)) 'QA�ж�Ϊ���ϵĳ�Ʒ��(��Ʒ��������������)����+QA�ж����ϵ�С��(����ʼʱ������)������
        dt.Columns.Add("1#��ƽ��ARA����", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("1#��ƽ��������", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("1#��С��EB�������", GetType(Integer)) '����ʼʱ�����䣬С��EB���Ե��ڡ�0/1��50g���Ĳ�Ϊ�յ�����
        dt.Columns.Add("1#����ƷEB�������", GetType(Integer)) '��Ʒ��������������,��ƷEB���Բ����ڡ�0/5��10g���Ĳ�Ϊ�յ�����
        dt.Columns.Add("1#�������10����", GetType(Integer)) '��Ʒ��������������,�����������<10�Ͳ�Ϊ�յ�����
        dt.Columns.Add("1#������ƽ������", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("34#��ֹ����", GetType(String)) '��Ʒ��������������
        dt.Columns.Add("34#����Ʒ����", GetType(Integer)) '��Ʒ��������������
        dt.Columns.Add("34#����Ʒ����", GetType(Double)) '��Ʒ��������������
        dt.Columns.Add("34#��������", GetType(Double)) 'QA�ж�Ϊ���ϵĳ�Ʒ��(��Ʒ��������������)����+QA�ж����ϵ�С��(����ʼʱ������)������
        dt.Columns.Add("34#��ƽ��ARA����", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("34#��ƽ��������", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("34#��С��EB�������", GetType(Integer)) '����ʼʱ�����䣬С��EB���Ե��ڡ�0/1��50g���Ĳ�Ϊ�յ�����
        dt.Columns.Add("34#����ƷEB�������", GetType(Integer)) '��Ʒ��������������,��ƷEB���Բ����ڡ�0/5��10g���Ĳ�Ϊ�յ�����
        dt.Columns.Add("34#�������10����", GetType(Integer)) '��Ʒ��������������,�����������<10�Ͳ�Ϊ�յ�����
        dt.Columns.Add("34#������ƽ������", GetType(Double)) '��Ʒ��������������,��ƽ��0

        dt.Columns.Add("5#��ֹ����", GetType(String)) '��Ʒ��������������'
        dt.Columns.Add("5#����Ʒ����", GetType(Integer)) '��Ʒ��������������'
        dt.Columns.Add("5#����Ʒ����", GetType(Double)) '��Ʒ��������������'
        dt.Columns.Add("5#��������", GetType(Double)) 'QA�ж�Ϊ���ϵĳ�Ʒ��(��Ʒ��������������)����+QA�ж����ϵ�С��(����ʼʱ������)������
        dt.Columns.Add("5#��ƽ��ARA����", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("5#��ƽ��������", GetType(Double)) '��Ʒ��������������,��ƽ��0
        dt.Columns.Add("5#��С��EB�������", GetType(Integer)) '����ʼʱ�����䣬С��EB���Ե��ڡ�0/1��50g���Ĳ�Ϊ�յ�����'
        dt.Columns.Add("5#����ƷEB�������", GetType(Integer)) '��Ʒ��������������,��ƷEB���Բ����ڡ�0/5��10g���Ĳ�Ϊ�յ�����'
        dt.Columns.Add("5#�������10����", GetType(Integer)) '��Ʒ��������������,�����������<10�Ͳ�Ϊ�յ�����'
        dt.Columns.Add("5#������ƽ������", GetType(Double)) '��Ʒ��������������,��ƽ��0

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
            'MsgBox(tmpMonthLow)
            dataRow(0) = tmpMonthLow
            dataRow(1) = tmpMonthhigh
            tmpMonthhigh &= " 23:59:59"
            '''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select top 1  tb_x832p_num from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��' order by tb_x832p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#��ֹ����") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''1#����Ʒ����,1#����Ʒ����,
            myread.CommandText = "select count(*),sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#����Ʒ����") = DeepCode.DeepDoStr.Null2zero(rs(0))
                dataRow("1#����Ʒ����") = DeepCode.DeepDoStr.Null2zero(rs(1))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''�����������<10�Ͳ�Ϊ�յ�����
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��'   and tb_x832p_e106x<>'<10' and tb_x832p_e106x is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#�������10����") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��'   and tb_x832p_e106x<>'<10' and tb_x832p_e106x is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#�������10����") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��'   and tb_x832p_e106x<>'<10' and tb_x832p_e106x is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#�������10����") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''��ƷEB���Բ����ڡ�0/5��10g���Ĳ�Ϊ�յ�������
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��'   and tb_x832p_h199z<>'0/5��10g' and tb_x832p_h199z is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#����ƷEB�������") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��'   and tb_x832p_h199z<>'0/5��10g' and tb_x832p_h199z is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#����ƷEB�������") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��'   and tb_x832p_h199z<>'0/5��10g' and tb_x832p_h199z is not null"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#����ƷEB�������") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''����ʼʱ�����䣬С��EB���Ե��ڡ�0/1��50g���Ĳ�Ϊ�յ�������
            myread.CommandText = "select count(*)  from tb_p525h where (tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_p525h_th in ('1����')    and (tb_p525h_c17u<>'0/1��50g' and tb_p525h_c17u<>'-')"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#��С��EB�������") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from tb_p525h where (tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_p525h_th in ('3����','4����')   and tb_p525h_c17u<>'0/1��50g' and tb_p525h_c17u<>'-'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#��С��EB�������") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            myread.CommandText = "select count(*)  from tb_p525h where (tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_p525h_th in ('5����')   and tb_p525h_c17u<>'0/1��50g' and tb_p525h_c17u<>'-'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#��С��EB�������") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_d65v)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��'   and tb_x832p_d65v>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#��ƽ��ARA����") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_a948s)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��'   and tb_x832p_a948s>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#��ƽ��������") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_i232a)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='1������Ʒ��'   and tb_x832p_i232a>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("1#������ƽ������") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select top 1  tb_x832p_num from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��' order by tb_x832p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#��ֹ����") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''34#����Ʒ����,34#����Ʒ����
            myread.CommandText = "select count(*),sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#����Ʒ����") = DeepCode.DeepDoStr.Null2zero(rs(0))
                dataRow("34#����Ʒ����") = DeepCode.DeepDoStr.Null2zero(rs(1))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_d65v)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��'   and tb_x832p_d65v>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#��ƽ��ARA����") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_a948s)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��'   and tb_x832p_a948s>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#��ƽ��������") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_i232a)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='34������Ʒ��'   and tb_x832p_i232a>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("34#������ƽ������") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''QA�ж�Ϊ���ϵĳ�Ʒ������+QA�ж����ϵ�С��(����ʼʱ������)������
            myread.CommandText = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='1������Ʒ��' and tb_x832p_qaspjg='����'"
            rs = myread.ExecuteReader
            Dim t1, t2 As Double
            rs.Read()
            t1 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            myread.CommandText = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_p525h_th in ('1����') and tb_p525h_qaspjg='����'"
            rs = myread.ExecuteReader
            rs.Read()
            t2 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            dataRow("1#��������") = t1 + t2


            myread.CommandText = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='34������Ʒ��' and tb_x832p_qaspjg='����'"
            rs = myread.ExecuteReader
            Dim t11, t12 As Double
            rs.Read()
            t1 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            myread.CommandText = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_p525h_th in ('3����','4����') and tb_p525h_qaspjg='����'"
            rs = myread.ExecuteReader
            rs.Read()
            t2 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            dataRow("34#��������") = t11 + t12
            rs.Close()

            myread.CommandText = "select sum(tb_x832p_i232a) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='5������Ʒ��' and tb_x832p_qaspjg='����'"
            rs = myread.ExecuteReader
            Dim ttt1, ttt2 As Double
            rs.Read()
            ttt1 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            myread.CommandText = "select sum(tb_p525h_dpbfl) from tb_p525h where tb_p525h_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_p525h_th in ('5����') and tb_p525h_qaspjg='����'"
            rs = myread.ExecuteReader
            rs.Read()
            ttt2 = DeepCode.DeepDoStr.Null2zero(rs(0))
            rs.Close()
            dataRow("5#��������") = t1 + t2

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Try
            '    'dataRow(5) = Format((dataRow(5) + (dataRow(3) / dataRow(2))), "00.00%")
            'Catch ex As Exception
            '    dataRow(5) = 0
            'End Try

            'Try
            '    dataRow(4) = Format((dataRow(3) / dataRow(2)), "00.00%")
            'Catch ex As Exception
            '    dataRow(4) = 0
            'End Try


            'myread.CommandText = "select sum(tb_x832p_z886r),sum(tb_x832p_i232a),sum(tb_x832p_l349d)  from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='34������Ʒ��'"
            'rs = myread.ExecuteReader
            'If rs.Read Then
            '    'dataRow(5) = Null2Zero(rs(0))
            '    dataRow(5) = Null2zero(rs(1))
            '    'dataRow(10) = Null2Zero(rs(2))
            'End If
            'rs.Close()
            'myread.CommandText = "select sum(tb_x832p_z886r) from vw_x832p where tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_x832p_th='34������Ʒ��' and tb_x832p_qaspjg='����'"
            'rs = myread.ExecuteReader
            'If rs.Read Then
            '    dataRow(6) = Null2zero(rs(0))
            'End If
            'rs.Close()
            ''Try
            ''    dataRow(10) = Format((dataRow(10) + (dataRow(8) / dataRow(7))), "00.00%")
            ''Catch ex As Exception
            ''    dataRow(10) = 0
            ''End Try

            'Try
            '    dataRow(7) = Format((dataRow(6) / dataRow(5)), "00.00%")
            'Catch ex As Exception
            '    dataRow(7) = 0
            'End Try

            'dataRow(8) = dataRow(2) + dataRow(5)
            'dataRow(9) = dataRow(3) + dataRow(6)
            'dataRow(10) = Format((Format(dataRow(4), "00.00%") + Format(dataRow(7), "00.00%")), "00.00%")
            'Dim tmpint As Integer = 0
            'If dataRow(5) <> "00.00%" Then
            '    tmpint = tmpint + 1
            'End If
            'If dataRow(10) <> "00.00%" Then
            '    tmpint = tmpint + 1
            'End If
            ''Try
            '    dataRow(15) = Format((dataRow(5) + dataRow(10)) / tmpint, "00.00%")
            'Catch ex As Exception
            '    dataRow(15) = 0
            'End Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select top 1  tb_x832p_num from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��' order by tb_x832p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#��ֹ����") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''1#����Ʒ����,1#����Ʒ����,
            myread.CommandText = "select count(*),sum(tb_x832p_i232a) from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#����Ʒ����") = DeepCode.DeepDoStr.Null2zero(rs(0))
                dataRow("5#����Ʒ����") = DeepCode.DeepDoStr.Null2zero(rs(1))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select avg(tb_x832p_d65v)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��'   and tb_x832p_d65v>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#��ƽ��ARA����") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_a948s)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��'   and tb_x832p_a948s>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#��ƽ��������") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''��ƽ��0
            myread.CommandText = "select avg(tb_x832p_i232a)  from vw_x832p where (tb_x832p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "') and tb_x832p_th='5������Ʒ��'   and tb_x832p_i232a>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("5#������ƽ������") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            dt.Rows.Add(dataRow)
        Next
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
        getFJSCZBdatatable = dt
    End Function
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim monthStr As String = GF_Time2Week(CDate(nian1.Text & "-" & yue1.Text))
    '    Dim dt As Data.DataTable = getFJSCZBdatatable(monthStr)
    '    GS_DataGridViewbyDb(ListView1, dt, True, True)
    'End Sub 
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim monthStr As String = GF_Time2Week(CDate(nian1.Text & "-" & yue1.Text))
        Dim dt As Data.DataTable = getFJSCZBdatatable(monthStr)
        ylbdb = dt.Copy()
        GS_DataGridViewbyDb(ListView1, dt, True, True)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ys(4) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Pink : ys(3) = Color.Gold : ys(4) = Color.Blue
        '��������������������������������������������
        ylbdb.Columns.RemoveAt(0)
        ylbdb.Columns.RemoveAt(ylbdb.Columns.Count - 1)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ShowLine(Chart3, False, ylbdb, "�ۼ���ƽ��ָ��(��)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 5)
        '��������������������������������������������������������������������������������������
        DeepDoDataTable.DelDataColAtIndex(ylbdb, "20,21,22,23,24,25,26,27,28,29")
        ShowLine(Chart2, False, ylbdb, "�ۼ���ƽ��ָ��(��)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 5)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DeepDoDataTable.DelDataColAtIndex(ylbdb, "19,18,17,16,15,14,13,12,11,5,4,3,2,1")
        ShowLine(Chart1, False, ylbdb, "�ۼ�һƽ��ָ��(��)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 5)
   
    End Sub
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
        Dim kd As Integer = Int(Me.Width / 3)
        Panel1.Width = kd
        Panel1.Height = Me.Height - Panel1.Top - 30
        'MsgBox(Chart1.Height)
        Panel2.Left = Panel1.Width + Panel1.Left
        Panel2.Width = kd
        Panel2.Height = Panel1.Height
        Panel3.Left = Panel2.Left + Panel2.Width
        Panel3.Width = Me.Width - 2 * kd
        Panel3.Height = Panel1.Height
    End Sub
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
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

    Private Sub ToChartImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClassDeepChart.GS_SaveChartImg(Chart3)
    End Sub
End Class