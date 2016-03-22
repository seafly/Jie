Imports System.Windows.Forms
Imports System.Drawing
Public Class DeepDoGridView
    '添加复选框,参数2是是否选中，参数3是复选框的标题
    Public Shared Sub AddCheckBox(ByVal dv As DataGridView, ByVal IsChecked As Boolean, ByVal Title As String)
        dv.ReadOnly = False
        '’‘’‘’‘’‘’‘’‘’使单元格只读
        For i As Integer = 0 To dv.Columns.Count - 1
            Dim col As DataGridViewColumn = dv.Columns(i)
            col.ReadOnly = True
        Next
        '添加复选框，并全选复选框
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
    '隐藏某些列，多个用逗号隔开
    Public Shared Sub HideSomeCol(ByVal dv As DataGridView, ByVal Cells As String)
        Dim sk() As String = Cells.Split(",")
        For i As Integer = 0 To UBound(sk)
            Dim n1 As Integer = sk(i)
            dv.Columns(n1).Visible = False
        Next
    End Sub
    '选中才转化
    '转化为DataTable,注意如果被转化的DataGridView的AllowUserToAddRows属性，免得被转化DB时候多一行
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
    '如果DataTable有复选框，那么复选框必须在第1列，且只有选中才转化
    '转化为DataTable,注意如果被转化的DataGridView的AllowUserToAddRows属性，免得被转化DB时候多一行
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
    '将起行索引和止行索引之间转化为DataTable
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
    '计算DataGridView中某一列所有数字的合计值
    Public Shared Function GF_jsColumnTotal(ByVal Db As DataGridView, ByVal ColIndex As Integer, ByVal RowBegin As Integer, ByVal RowEnd As Integer) As Double
        Dim jsTotal As Double = 0
        Try
            For i As Integer = RowBegin To RowEnd
                jsTotal += CDbl(Db.Rows(i).Cells(ColIndex).Value)
            Next
        Catch ex As Exception
            MsgBox("非数字")
            Return 0
        End Try
        Return jsTotal
    End Function
    '计算DataGridView中某一行所有数字的合计值
    Public Shared Function GF_jsRowTotal(ByVal Db As DataGridView, ByVal RowIndex As Integer, ByVal ColBegin As Integer, ByVal ColEnd As Integer) As Double
        Dim jsTotal As Double = 0
        For i As Integer = ColBegin To ColEnd
            Try
                jsTotal += CDbl(Db.Rows(RowIndex).Cells(i).Value)
            Catch ex As Exception
                MsgBox("非数字")
                Return 0
            End Try
        Next
        Return jsTotal
    End Function
End Class
