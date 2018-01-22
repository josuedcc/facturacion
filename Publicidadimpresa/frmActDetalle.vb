Imports Publicidadimpresa.variables
Public Class frmActDetalle

    Dim cantidad As Integer
    Dim descrip As String
    Dim total As Double

    Private Sub frmActDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCantidad.Text = cantidadGuia
        txtDetalle.Text = DescripGuia
        txtCosto.Text = totalGuia
    End Sub

    Private Sub btnNextDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextDetalle.Click
        If txtCantidad.Text <> "" Then
            cantidad = txtCantidad.Text
            ErrorCantidadGuia.SetError(Me.txtCantidad, "")
        Else
            ErrorCantidadGuia.SetError(Me.txtCantidad, "Se requiere de cantidad")
            Exit Sub
        End If

        If txtDetalle.Text <> "" Then
            descrip = txtDetalle.Text
            ErrorDescripGuia.SetError(Me.txtDetalle, "")
        Else
            ErrorDescripGuia.SetError(Me.txtDetalle, "Se requiere de los detalles")
            Exit Sub
        End If

        If txtCosto.Text <> "" Then
            total = txtCosto.Text
            ErrorTotalGuia.SetError(Me.txtCosto, "")
        Else
            ErrorTotalGuia.SetError(Me.txtCosto, "Se requiere del total")
            Exit Sub
        End If

        Form1.mtGridDetalleGuia.Rows(currentActGuia).Cells(0).Value = cantidad
        Form1.mtGridDetalleGuia.Rows(currentActGuia).Cells(1).Value = descrip
        Form1.mtGridDetalleGuia.Rows(currentActGuia).Cells(2).Value = total
        'Form1.mtGridDetallesFactura.Rows(filaR).Cells(0).Value = proviNuevocantidad

        Me.Close()
    End Sub
End Class