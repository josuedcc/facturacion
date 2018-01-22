Imports Publicidadimpresa.variables
Imports Publicidadimpresa.Form1
Public Class frmUpdateDetails
    Dim nuevoCanttidad As Int64
    Dim nuevodetalle As String
    Dim nuevopunitario As Double
    Dim proviNuevocantidad As Int64
    Dim provinuevoDetalle As String
    Dim provinuevoPunitario As Double
    Dim costototal As Double

    Private Sub frmUpdateDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCantidad.Text = cantidadDetalle
        txtCosto.Text = pUnitdetalle
        txtDetalle.Text = detDetalle
    End Sub

    Private Sub lnkcalPUnitario_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkcalPUnitario.LinkClicked
        proviNuevocantidad = txtCantidad.Text
        provinuevoDetalle = txtDetalle.Text
        provinuevoPunitario = txtDetalle.Text

        costototal = InputBox("Ingresar precio total")


        provinuevoPunitario = costototal / proviNuevocantidad

        txtCosto.Text = provinuevoPunitario

    End Sub

    Private Sub btnNextDetalle_Click(sender As Object, e As EventArgs) Handles btnNextDetalle.Click
        If txtCantidad.Text <> "" Then
            proviNuevocantidad = txtCantidad.Text
        Else
            ErrorCantidadDetalle.SetError(Me.txtCantidad, "Se requiere la cantidad")
            Exit Sub
        End If

        If txtDetalle.Text <> "" Then
            provinuevoDetalle = txtDetalle.Text
        Else
            ErrorDetalle.SetError(Me.txtDetalle, "Se requiere detalle")
            Exit Sub
        End If

        If txtCosto.Text <> "" Then
            provinuevoPunitario = txtCosto.Text
            'costuni = costuni.ToString("C", New CultureInfo(variables.tipomoneda))
        Else
            ErrorCosto.SetError(Me.txtCosto, "Se requiere costo")
            Exit Sub
        End If

        costototal = proviNuevocantidad * provinuevoPunitario

        Form1.mtGridDetallesFactura.Rows(filaR).Cells(0).Value = proviNuevocantidad
        Form1.mtGridDetallesFactura.Rows(filaR).Cells(1).Value = provinuevoDetalle
        Form1.mtGridDetallesFactura.Rows(filaR).Cells(2).Value = provinuevoPunitario
        Form1.mtGridDetallesFactura.Rows(filaR).Cells(3).Value = costototal

        Dim numActualizar As Int32

        numActualizar = Form1.mtGridDetallesFactura.RowCount
        totales.Clear()

        For ij As Int32 = 0 To numActualizar - 1
            totales.Add(Form1.mtGridDetallesFactura.Rows(ij).Cells(3).Value)
        Next


        Console.WriteLine(Form1.mtGridDetallesFactura.RowCount)

        Dim nuevoSubTotal As Double
        Dim nuevoigv As Double
        Dim nuevoCostoTotal As Double

        nuevoSubTotal = totales.Cast(Of Double).Sum()
        nuevoigv = nuevoSubTotal * Form1.verIGV() / 100

        nuevoCostoTotal = nuevoSubTotal + nuevoigv

        'NuevoCostoTotal = viejoCostoTotal - viejoCostoTotalFila
        'NuevoCostoTotal = NuevoCostoTotal + costototal

        'Dim igvnuevo As Double
        'Dim totalOk As Double
        'igvnuevo = NuevoCostoTotal * 0.19

        'totalOk = NuevoCostoTotal + igvnuevo


        Form1.txtSubTotalF.Text = nuevoSubTotal
        Form1.txtIGVF.Text = nuevoigv
        Form1.txtTotalF.Text = nuevoCostoTotal
        Me.Close()

    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class