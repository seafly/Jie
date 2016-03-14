
Public Class DeepDoExcel
'Excel.Selection.NumberFormatLocal   =   "@"     �������ı���   
'Excel.Selection.NumberFormatLocal   =   "0.00%"�ٷֱ�   
'Excel.Selection.NumberFormatLocal   =   "yyyy-m-d"����   
'Excel.Selection.NumberFormatLocal   =   "h:mm;@"ʱ��   
'Excel.Selection.NumberFormatLocal   =   "0.00_   "��ֵ
'Excel.Selection.NumberFormatLocal   =   "G/ͨ�ø�ʽ"   
    Dim xlApp, xlbook, xlsheet As Object, lpath As String
    Dim isTem As Boolean '�Ƿ�ʹ��ģ��
    '���������Ƿ���ʾ������ļ������·��
    Sub New(ByVal ShowUI As Boolean, ByVal SavePath As String)
        lpath = SavePath
        isTem = False
        xlApp = CreateObject("Excel.Application")
        xlApp.DisplayAlerts = False '��ʾ����
        xlApp.Application.Visible = ShowUI '��ʾ����
        xlApp.WorkBooks.add()
        xlbook = xlApp.ActiveWorkBook
        xlsheet = xlbook.Sheets(1)
    End Sub
    '���������Ƿ���ʾ������ļ������·��
    Sub New(ByVal ShowUI As Boolean, ByVal SavePath As String, ByVal PanlePath As String)
        System.IO.File.Copy(PanlePath, SavePath, True)
        lpath = SavePath
        isTem = True
        xlApp = CreateObject("Excel.Application")
        xlApp.DisplayAlerts = False '��ʾ����
        xlApp.Application.Visible = ShowUI '��ʾ����
        xlbook = xlApp.Workbooks.Open(lpath)
        xlsheet = xlbook.Sheets(1)
    End Sub
    'ʹ��DataTable���EXCEL����0���������꣬1���������,1��������ֵ
    Public Sub FillAt(ByVal SXY As DataTable) '����EXCEL�����ϲ���Ԫ���
        With SXY
            For I As Integer = 0 To .Rows.Count - 1
                Dim range1 As Object = Nothing
                range1 = xlsheet.Range(.Rows(I)(0), .Rows(I)(0))
                range1.Select()
                range1.value2 = .Rows(I)(1)
            Next
        End With
    End Sub
    'ʹ��DataTable����EXCEL��������EXCEL�δ�д��һ��Stitle�����һ���Ƿ�ϲ���Ԫ�񣨼���һ�е����ݣ������Ϊ���򲻺ϲ�,���ֵΪEXCEL������Ϻ�ù�������һ�еĿ�ʼ�к�
    Public Function CreateByDataTable(ByVal str As DataTable, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '����EXCEL�����ϲ���Ԫ���
        Try
            Dim i, j, m As Integer
            m = str.Columns.Count
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            If STitle = "" Then
                StartHere = StartHere - 1
            Else
                range1 = xlsheet.Range("A" & StartHere.ToString, lbc)
                range1.Select()
                range1.Merge(False)
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.RowHeight = 37.5 '�߶�
                range1.HorizontalAlignment = 3        'ˮƽ����
                range1.VerticalAlignment = 2 '��ֱ����2,��ֱ�ײ�����3����ֱ���˶��룱
                range1.value2 = STitle
            End If
            m = 0
            For j = 0 To str.Columns.Count - 1

                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).Caption

                m = m + 1

            Next

            '''''''''''
            '''''''''''
            range1 = xlsheet.Range("A" & (str.Rows.Count + StartHere + 1), lbc)
            range1.Select()
            If isTem = False Then 'ʹ�÷�ģ�崴��ʱ��ʹ�ø�ʽ
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.ColumnWidth = SWidth  '���
                range1.WrapText = True '�Զ�����
            End If

            ''''''''''''''
            For i = 0 To str.Rows.Count - 1
                m = 0
                For j = 0 To str.Columns.Count - 1
                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j))
                    m = m + 1
                Next
            Next
            CreateByDataTable = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByDataTable = 0
        End Try

    End Function
    'ʹ��DataTable����EXCEL��������EXCEL�δ�д��һ��,�������Ͱ���DataTable����
    Public Function CreateByDataTable2(ByVal str As DataTable, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '����EXCEL�����ϲ���Ԫ���
        Try
            Dim i, j, m As Integer
            m = str.Columns.Count
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            If STitle = "" Then
                StartHere = StartHere - 1
            Else
                range1 = xlsheet.Range("A" & StartHere.ToString, lbc)
                range1.Select()
                range1.Merge(False)
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.RowHeight = 37.5 '�߶�
                range1.HorizontalAlignment = 3        'ˮƽ����
                range1.VerticalAlignment = 2 '��ֱ����2,��ֱ�ײ�����3����ֱ���˶��룱
                range1.value2 = STitle
            End If
            m = 0
            For j = 0 To str.Columns.Count - 1
                '�����������������������������������������������ֶ�
                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).Caption
                '����������������������������������������������������������������������
                Dim lb2 As String = getabc(m + 1) & (StartHere + 2)
                Dim lb3 As String = getabc(m + 1) & (str.Rows.Count + StartHere + 1)
                Dim range11 As Object = Nothing
                range11 = xlsheet.Range(lb3, lb2)
                range11.Select()
                If isTem = False Then 'ʹ�÷�ģ�崴��ʱ��ʹ�ø�ʽ
                    range11.ColumnWidth = SWidth  '���

                    'Debug.WriteLine(str.Columns(j).DataType.ToString & " :" & lb3 & "-" & lb2)
                    Select Case str.Columns(j).DataType.ToString
                        Case "System.Int16", "System.Int32", "System.Int64"
                            range11.NumberFormatLocal = "0" '
                        Case "System.Decimal", "System.Double", "System.Single" '����������2λС��
                            range11.NumberFormatLocal = "0.00_   " '
                        Case "System.DateTime" '����������2λС��
                            range11.NumberFormatLocal = "yyyy-m-d h:mm;@" '����
                        Case Else
                            range11.NumberFormatLocal = "@" '�ı�ģʽ
                            range11.WrapText = True '�Զ�����
                    End Select
                End If
                '������������������������������������������������������������
                m = m + 1

            Next

            ''''''''''''''
            For i = 0 To str.Rows.Count - 1 '���
                m = 0
                For j = 0 To str.Columns.Count - 1
                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j))
                    m = m + 1
                Next
            Next
            CreateByDataTable2 = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByDataTable2 = 0
        End Try

    End Function
    'ʹ��DataGridView����EXCEL��������EXCEL�δ�д��һ��,�������Ͱ���DataGridView����
    Public Function CreateByDataGridView(ByVal str As System.Windows.Forms.DataGridView, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '����EXCEL�����ϲ���Ԫ���
        Try
            Dim l1 As Integer = 0
            Dim i, j, m As Integer
            m = str.Columns.Count
            If str.Columns(0).GetType.ToString = "System.Windows.Forms.DataGridViewCheckBoxColumn" Then
                l1 = 1 : m = m - 1
            End If


            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            If STitle = "" Then
                StartHere = StartHere - 1
            Else
                range1 = xlsheet.Range("A" & StartHere.ToString, lbc)
                range1.Select()
                range1.Merge(False)
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.RowHeight = 37.5 '�߶�
                range1.HorizontalAlignment = 3        'ˮƽ����
                range1.VerticalAlignment = 2 '��ֱ����2,��ֱ�ײ�����3����ֱ���˶��룱
                range1.value2 = STitle
            End If
            m = 0
            For j = l1 To str.Columns.Count - 1
                '�����������������������������������������������ֶ�
                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).HeaderText
                '����������������������������������������������������������������������
                Dim lb2 As String = getabc(m + 1) & (StartHere + 2)
                Dim lb3 As String = getabc(m + 1) & (str.Rows.Count + StartHere + 1)
                Dim range11 As Object = Nothing
                range11 = xlsheet.Range(lb3, lb2)
                range11.Select()
                If isTem = False Then 'ʹ�÷�ģ�崴��ʱ��ʹ�ø�ʽ
                    range11.ColumnWidth = SWidth  '���
                    'MsgBox(str.Columns(j).ValueType.ToString)
                    'Debug.WriteLine(str.Columns(j).ValueType.ToString & " :" & lb3 & "-" & lb2)
                    Select Case str.Columns(j).ValueType.ToString
                        Case "System.Int16", "System.Int32", "System.Int64"
                            range11.NumberFormatLocal = "0" '
                        Case "System.Decimal", "System.Double", "System.Single" '����������2λС��
                            range11.NumberFormatLocal = "0.00_   " '
                        Case "System.DateTime" '����������2λС��
                            range11.NumberFormatLocal = "yyyy-m-d h:mm;@" '����
                        Case Else
                            range11.NumberFormatLocal = "@" '�ı�ģʽ
                            range11.WrapText = True '�Զ�����
                    End Select
                End If

                '������������������������������������������������������������
                m = m + 1

            Next

            ''''''''''''''
            If l1 = 1 Then '�������и�ѡ���'
                Dim z As Integer = 0
                For i = 0 To str.Rows.Count - 1 '���

                    m = 0
                    Dim k As Windows.Forms.DataGridViewCheckBoxCell = str.Rows(i).Cells(0)
                    If k.Value.ToString = "True" Then
                        For j = l1 To str.Columns.Count - 1
                            Dim lb As String = getabc(m + 1) & (z + StartHere + 2).ToString
                            range1 = xlsheet.Range(lb)

                            range1.value2 = Null2String(str.Rows(i).Cells(j).Value)
                            m = m + 1

                        Next
                        z += 1
                    End If

                Next
                range1 = Nothing
                Return z + StartHere + 2

            Else
                For i = 0 To str.Rows.Count - 1 '���
                    m = 0
                    For j = l1 To str.Columns.Count - 1
                        Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                        range1 = xlsheet.Range(lb)

                        range1.value2 = Null2String(str.Rows(i).Cells(j).Value)
                        m = m + 1
                    Next
                Next
                range1 = Nothing
                Return i + StartHere + 2

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try

    End Function
    '��DBNullֵת��Ϊ""
    Private Function Null2String(ByVal str) As String
        If str Is DBNull.Value Then
            Null2String = ""
        Else
            Null2String = str
        End If
    End Function
    'ʹ��ģ��ʹ��DataTable����EXCEL,StartHere������ʾ��ģ��ĺδ�д��һ��
    Public Function DoWithPanel(ByVal str As DataTable, ByVal StartHere As Integer) As Integer
        Try
            Dim i, j, m As Integer
            m = 0
            For j = 0 To str.Columns.Count - 1
                m = m + 1
            Next
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            StartHere = StartHere - 1
            m = 0

            For j = 0 To str.Columns.Count - 1
                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).Caption
                m = m + 1
            Next

            '''''''''''
            range1 = xlsheet.Range("A" & (str.Rows.Count + StartHere + 1), lbc)
            range1.Select()
            range1.NumberFormatLocal = "@" '�ı�ģʽ

            range1.WrapText = True '�Զ�����
            ''''''''''''''
            For i = 0 To str.Rows.Count - 1
                m = 0
                For j = 0 To str.Columns.Count - 1

                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j))
                    m = m + 1
                Next
            Next
            DoWithPanel = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            DoWithPanel = 0
        End Try
    End Function
    '���溯����Ϊ�˼���EXCEL���б�
    Private Function getabc(ByVal str As Integer) As String
        Dim n1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim BB As String = ""
        If str <= 26 Then
            BB = Mid(n1, str, 1)
        Else
            Dim BS As Integer = Int(str / 26)
            Dim YS As Integer = str Mod 26
            If YS > 0 Then
                BB = Mid(n1, BS, 1)
                BB = BB & Mid(n1, YS, 1)
            Else
                BB = Mid(n1, BS - 1, 1)
                BB = BB & "Z"
            End If
        End If
        getabc = BB
    End Function
    'ʹ��LISTVIEW����EXCEL��������EXCEL�δ�д��һ��,���Ϊ0�Ĳ���ʾ������ѡ���ֻ����ʾѡ�е���
    Public Function CreateByListview(ByVal str As Windows.Forms.ListView, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '����EXCEL�����ϲ���Ԫ���
        Try
            Dim i, j, m As Integer
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    m = m + 1
                End If
            Next
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            If STitle = "" Then
                StartHere = StartHere - 1
            Else

                range1 = xlsheet.Range("A" & StartHere.ToString, lbc)
                range1.Select()
                range1.Merge(False)
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.RowHeight = 37.5 '�߶�
                range1.HorizontalAlignment = 3        'ˮƽ����
                range1.VerticalAlignment = 2 '��ֱ����2,��ֱ�ײ�����3����ֱ���˶��룱
                range1.value2 = STitle
            End If
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    Dim lb As String = getabc(m + 1) & (StartHere + 1)
                    range1 = xlsheet.Range(lb)
                    'range1.NumberFormatLocal = "@"
                    'range1.ColumnWidth = SWidth
                    range1.value2 = str.Columns(j).Text

                    m = m + 1
                End If
            Next
            If str.CheckBoxes = True Then '������и�ѡ���
                '''''''''''
                range1 = xlsheet.Range("A" & (str.Items.Count + StartHere + 1), lbc)
                range1.Select()
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.ColumnWidth = SWidth  '���
                range1.WrapText = True '�Զ�����
                ''''''''''''''
                For i = 0 To str.CheckedItems.Count - 1
                    m = 0
                    For j = 0 To str.Columns.Count - 1
                        If str.Columns(j).Width > 0 Then
                            Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                            range1 = xlsheet.Range(lb)
                            'range1.NumberFormatLocal = "@" '�ı�ģʽ
                            'range1.ColumnWidth = SWidth '���
                            '' range1.RowHeight = 37.5 '�߶�
                            '' range1.VerticalAlignment = 2 '��ֱ����
                            'range1.WrapText = True '�Զ�����
                            range1.value2 = str.CheckedItems(i).SubItems(j).Text
                            m = m + 1
                        End If
                    Next
                Next
            Else '������޸�ѡ�����ʾȫ������
                '''''''''''
                range1 = xlsheet.Range("A" & (str.Items.Count + StartHere + 1), lbc)
                range1.Select()
                range1.NumberFormatLocal = "@" '�ı�ģʽ
                range1.ColumnWidth = SWidth  '���
                range1.WrapText = True '�Զ�����
                ''''''''''''''
                For i = 0 To str.Items.Count - 1
                    m = 0
                    For j = 0 To str.Columns.Count - 1
                        If str.Columns(j).Width > 0 Then
                            Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                            range1 = xlsheet.Range(lb)
                            'range1.NumberFormatLocal = "@" '�ı�ģʽ
                            'range1.ColumnWidth = SWidth '���
                            '' range1.RowHeight = 37.5 '�߶�
                            ''  range1.VerticalAlignment = 2 '��ֱ����
                            'range1.WrapText = True '�Զ�����
                            range1.value2 = str.Items(i).SubItems(j).Text
                            m = m + 1
                        End If
                    Next
                Next
            End If
            CreateByListview = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByListview = 0
        End Try

    End Function
    
    Protected Overrides Sub Finalize()
        xlsheet.SaveAs(lpath)
        xlsheet = Nothing : xlbook = Nothing : xlApp.quit()
        Dim jcdh As Integer = System.GC.GetGeneration(xlApp)
        xlApp = Nothing

        System.GC.Collect(jcdh)
        MyBase.Finalize()
    End Sub
End Class
