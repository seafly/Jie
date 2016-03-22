Public Class ResourceHolder
    Private Shared resourceHolder As ResourceHolder

    Private Sub New()
        
    End Sub

    Public Shared Function getInstance() As ResourceHolder
        If resourceHolder Is Nothing Then
            resourceHolder = New ResourceHolder()
        End If
        Return resourceHolder
    End Function
End Class
