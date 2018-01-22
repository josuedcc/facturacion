Public Class clFechaletra

    Public Function mesaletras(ByVal mes As Integer)
        Dim mesaletra As String = ""
        Select Case mes
            Case 1
                mesaletra = "Enero"
            Case 2
                mesaletra = "Febrero"
            Case 3
                mesaletra = "Marzo"
            Case 4
                mesaletra = "Abril"
            Case 5
                mesaletra = "Mayo"
            Case 6
                mesaletra = "Junio"
            Case 7
                mesaletra = "Julio"
            Case 8
                mesaletra = "Agosto"
            Case 9
                mesaletra = "Septiembre"
            Case 10
                mesaletra = "Octubre"
            Case 11
                mesaletra = "Noviembre"
            Case 12
                mesaletra = "Diciembre"
            Case Else
                mesaletra = ""
        End Select
        Return mesaletra
    End Function
End Class
