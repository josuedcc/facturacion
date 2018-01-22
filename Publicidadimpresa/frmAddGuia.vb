Imports Publicidadimpresa.variables
Imports Publicidadimpresa.Form1
Public Class frmAddGuia

    Dim cantidad As Integer
    Dim descrip As String
    Dim total As Double
    Dim numero As Integer = 1

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

        Form1.mtGridDetalleGuia.Rows.Add(cantidad, descrip, total)

        Me.Hide()

        txtCantidad.Text = ""
        txtCosto.Text = ""
        txtDetalle.Text = ""

        numero = numero + 1
        Me.Show()

        Me.Text = "Agregar detalle guia " & numero

    End Sub

    Private Sub btnEndDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndDetalle.Click
        Me.Close()
    End Sub

    Dim clManGuia As New clManageGuia

    Private Sub frmAddGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Agregar detalle guia 1"
        Console.WriteLine("ID FAC" & idFact)
        'clManGuia.verIdFactura(clManGuia.idfact)

    End Sub
End Class