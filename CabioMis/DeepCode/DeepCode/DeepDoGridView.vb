Imports System.Windows.Forms
Imports System.Drawing
Public Class DeepDoGridView
    '��Ӹ�ѡ��,����2���Ƿ�ѡ�У�����3�Ǹ�ѡ��ı���
    Public Shared Sub AddCheckBox(ByVal dv As DataGridView, ByVal IsChecked As Boolean, ByVal Title As String)
        dv.ReadOnly = False
        '��������������������������ʹ��Ԫ��ֻ��
        For i As Integer = 0 To dv.Columns.Count - 1
            Dim col As DataGridViewColumn = dv.Columns(i)
            col.ReadOnly = True
        Next
        '��Ӹ�ѡ�򣬲�ȫѡ��ѡ��
        Dim column As New DataGridViewCheckBoxColumn()
        With column
            .Name = Title
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With
        dv.Columns.Insert(0, column)
        If IsChecked = True Then
            For i As Integer = 0 To dv.Rows.Count - 1
                Dim cell As DataGridViewCell = dv.Rows(i).Cells(0)
                cell.Value = True
            Next
        End If
    End Sub
    '����ĳЩ�У�����ö��Ÿ���
    Public Shared Sub HideSomeCol(ByVal dv As DataGridView, ByVal Cells As String)
        Dim sk() As String = Cells.Split(",")
        For i As Integer = 0 To UBound(sk)
            Dim n1 As Integer = sk(i)
            dv.Columns(n1).Visible = False
        Next
    End Sub
    'ѡ�в�ת��
    'ת��ΪDataTable,ע�������ת����DataGridView��AllowUserToAddRows���ԣ���ñ�ת��DBʱ���һ��
    Public Shared Function SelectToDataTable(ByVal dv As DataGridView) As DataTable
        Dim dt As New DataTable
        With dv
            Dim zhqi As Integer = 0

            For i As Integer = zhqi To .Columns.Count - 1
                Dim bt As String = .Columns(i).Name
                If .Columns(i).Visible = True Then
                    dt.Columns.Add(bt, .Columns(i).ValueType)
                End If
            Next
            For j As Integer = 0 To .SelectedRows.Count - 1
                Dim k1 As DataRow = dt.NewRow
                Dim j1 As Integer = 0
                For i As Integer = zhqi To .Columns.Count - 1
                    If .Columns(i).Visible = True Then
                        k1(j1) = .SelectedRows(j).Cells(i).Value
                        j1 += 1
                    End If
                Next
                dt.Rows.Add(k1)
            Next
        End With
        Return dt
    End Function
    '���DataTable�и�ѡ����ô��ѡ������ڵ�1�У���ֻ��ѡ�в�ת��
    'ת��ΪDataTable,ע�������ת����DataGridView��AllowUserToAddRows���ԣ���ñ�ת��DBʱ���һ��
    Public Shared Function ToDataTable(ByVal dv As DataGridView) As DataTable
        Dim dt As New DataTable
        With dv
            Dim zhqi As Integer = 0
            If .Columns(0).CellType.FullName = "System.Windows.Form s.DataGridViewCheckBoxCell" Then
                zhqi = 1
            End If
            For i As Integer = zhqi To .Columns.Count - 1
                Dim bt As String = .Columns(i).Name
                If .Columns(i).Visible = True Then
                    dt.Columns.Add(bt, .Columns(i).ValueType)
                End If
            Next
            For j As Integer = 0 To .Rows.Count - 1
                If zhqi = 1 And .Rows(j).Cells(0).Value.ToString = "True" Then
                    Dim k1 As DataRow = dt.NewRow
                    Dim j1 As Integer = 0
                    For i As Integer = zhqi To .Columns.Count - 1
                        If .Columns(i).Visible = True Then
                            k1(j1) = .Rows(j).Cells(i).Value
                            j1 += 1
                        End If
                    Next
                    dt.Rows.Add(k1)
                ElseIf zhqi = 0 Then
                    Dim k1 As DataRow = dt.NewRow
                    Dim j1 As Integer = 0
                    For i As Integer = zhqi To .Columns.Count - 1
                        If .Columns(i).Visible = True Then
                            k1(j1) = .Rows(j).Cells(i).Value
                            j1 += 1
                        End If
                    Next
                    dt.Rows.Add(k1)
                End If
            Next
        End With
        Return dt
    End Function
    '������������ֹ������֮��ת��ΪDataTable
    Public Shared Function ToDataTable(ByVal dv As DataGridView, ByVal rowStart As Integer, ByVal rowEnd As Integer) As DataTable
        Dim dt As New DataTable
        With dv
            Dim zhqi As Integer = 0
            If .Columns(0).CellType.FullName = "System.Windows.Forms.DataGridViewCheckBoxCell" Then
                zhqi = 1
            End If
            For i As Integer = zhqi To .Columns.Count - 1
                Dim bt As String = .Columns(i).Name
                If .Columns(i).Visible = True Then
                    dt.Columns.Add(bt, .Columns(i).ValueType)
                End If
            Next
            For j As Integer = rowStart To rowEnd
                If zhqi = 1 And .Rows(j).Cells(0).Value.ToString = "True" Then
                    Dim k1 As DataRow = dt.NewRow
                    Dim j1 As Integer = 0
                    For i As Integer = zhqi To .Columns.Count - 1
                        If .Columns(i).Visible = True Then
                            k1(j1) = .Rows(j).Cells(i).Value
                            j1 += 1
                        End If
                    Next
                    dt.Rows.Add(k1)
                ElseIf zhqi = 0 Then
                    Dim k1 As DataRow = dt.NewRow
                    Dim j1 As Integer = 0
                    For i As Integer = zhqi To .Columns.Count - 1
                        If .Columns(i).Visible = True Then
                            k1(j1) = .Rows(j).Cells(i).Value
                            j1 += 1
                        End If
                    Next
                    dt.Rows.Add(k1)
                End If
            Next
        End With
        Return dt
    End Function
    '����DataGridView��ĳһ���������ֵĺϼ�ֵ
    Public Shared Function GF_jsColumnTotal(ByVal Db As DataGridView, ByVal ColIndex As Integer, ByVal RowBegin As Integer, ByVal RowEnd As Integer) As Double
        Dim jsTotal As Double = 0
        Try
            For i As Integer = RowBegin To RowEnd
                jsTotal += CDbl(Db.Rows(i).Cells(ColIndex).Value)
            Next
        Catch ex As Exception
            MsgBox("������")
            Return 0
        End Try
        Return jsTotal
    End Function
    '����DataGridView��ĳһ���������ֵĺϼ�ֵ
    Public Shared Function GF_jsRowTotal(ByVal Db As DataGridView, ByVal RowIndex As Integer, ByVal ColBegin As Integer, ByVal ColEnd As Integer) As Double
        Dim jsTotal As Double = 0
        For i As Integer = ColBegin To ColEnd
            Try
                jsTotal += CDbl(Db.Rows(RowIndex).Cells(i).Value)
            Catch ex As Exception
                MsgBox("������")
                Return 0
            End Try
        Next
        Return jsTotal
    End Function
End Class
