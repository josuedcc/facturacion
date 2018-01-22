Imports Publicidadimpresa.Form1
Imports System.Globalization
Imports System.Threading
Public Class frmAddDetalle

    Dim contador As Int16
    Dim cantidad As Int32
    Dim Detalle As String
    Dim costuni As Double
    Dim rowadd As Int16
    Dim totalfactura As Double = 0
    Dim totalunitario As Double

    Public Sub frmAddDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        contador = Form1.mtGridDetallesFactura.RowCount + 1
        Me.Text = "Agregar detalle " & contador
        rowadd = Form1.mtGridDetallesFactura.RowCount
    End Sub

    Public Sub btnNextDetalle_Click(sender As Object, e As EventArgs) Handles btnNextDetalle.Click


        If txtCantidad.Text <> "" Then
            cantidad = txtCantidad.Text
        Else
            ErrorCantidadDetalle.SetError(Me.txtCantidad, "Se requiere la cantidad")
            Exit Sub
        End If

        If txtDetalle.Text <> "" Then
            Detalle = txtDetalle.Text
        Else
            ErrorDetalle.SetError(Me.txtDetalle, "Se requiere detalle")
            Exit Sub
        End If

        If txtCosto.Text <> "" Then
            costuni = txtCosto.Text
            'costuni = costuni.ToString("C", New CultureInfo(variables.tipomoneda))
        Else
            ErrorCosto.SetError(Me.txtCosto, "Se requiere costo")
            Exit Sub
        End If



        totalunitario = cantidad * costuni
        'totalunitario = totalunitario.ToString("C", New CultureInfo(variables.tipomoneda))

        Form1.mtGridDetallesFactura.Rows.Add(cantidad, Detalle, costuni, totalunitario)
        'Form1.mtGridDetallesFactura.Rows(rowadd).Cells(0).Value = cantidad
        'Form1.mtGridDetallesFactura.Rows(rowadd).Cells(1).Value = Detalle
        'Form1.mtGridDetallesFactura.Rows(rowadd).Cells(2).Value = costuni
        'Form1.mtGridDetallesFactura.Rows(rowadd).Cells(3).Value = totalunitario

        'Form1.lblTotal.Text = "Total : " & totalfactura * (igvC / 100)
        'Console.WriteLine(Form1.mtGridDetallesFactura.Rows.Count)

        'Console.WriteLine(totalfactura)
        Me.Hide()
        rowadd = rowadd + 1
        txtCosto.Text = ""
        txtDetalle.Text = ""
        txtCantidad.Text = ""

        contador = contador + 1
        Me.Show()
        Me.Text = "Agregar detalle " & contador
        'Form1.mtGridDetallesFactura.Rows(1).Cells(0).Value = "2"
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub lnkcalPUnitario_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkcalPUnitario.LinkClicked
        totalunitario = InputBox("Ingresar el precio total")
        Dim proviCant As Int16
        Dim proviCostounidad As Double
        proviCant = txtCantidad.Text

        proviCostounidad = totalunitario / proviCant

        txtCosto.Text = proviCostounidad

    End Sub
End Class