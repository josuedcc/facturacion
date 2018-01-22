Imports MySql.Data.MySqlClient
Imports Publicidadimpresa.variables
Imports Publicidadimpresa.Form1
Imports MetroFramework
Public Class frmAdd
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNumContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumContacto.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'cone.MysqlConexion.Close()
        'Console.WriteLine(cone.MysqlConexion.State)

        Console.WriteLine(checkExiststlf(txtNumContacto.Text, currentRuc, currentidEmpresa))

        Dim numContacto As String = ""
        Dim nomContacto As String = ""

        If txtNomContacto.Text = "" Then
            MetroMessageBox.Show(Me, "Se debe de asignar un nombre de contacto", "Error Nombre de contacto")
            Exit Sub

        Else
            nomContacto = txtNomContacto.Text
        End If

        If txtNumContacto.Text = "" Then
            MetroMessageBox.Show(Me, "Se debe de asignar un número", "Error Número")
            Exit Sub
        Else
            numContacto = txtNumContacto.Text
        End If

        If checkExiststlf(txtNumContacto.Text, currentRuc, currentidEmpresa) = True Then
            MetroMessageBox.Show(Me, "Este número de teléfono ya existe", "Teléfono duplicado")
            Exit Sub
        End If
        checkCone()

        'cone.MysqlConexion.Open()
        'Console.WriteLine(cone.MysqlConexion.State)
        'Exit Sub
        'Console.WriteLine(cone.MysqlConexion.State.Open = True)
        qr = "INSERT INTO `publicidadimpresa`.`telefonoscliente` (`numTelf`, `nombreContactotelf`, `clientes_idcliente`) VALUES (@Numero, @Nombre, @id)"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@Numero", numContacto)
        cmds.Parameters.AddWithValue("@Nombre", nomContacto)
        cmds.Parameters.AddWithValue("@id", currentidEmpresa)
        cmds.ExecuteNonQuery()

        cone.MysqlConexion.Close()
        Form1.loadTablaTlfs(currentRuc)
        Form1.menuCheck()
        Me.Close()
    End Sub

    Public Sub checkCone()
        If cone.MysqlConexion.State = 1 Then
            'Console.WriteLine("Esta conectado")
            cone.MysqlConexion.Close()
            cone.MysqlConexion.Open()
            'Exit Sub
        Else
            'Console.WriteLine("No Esta conectado")
            cone.MysqlConexion.Open()
            'Exit Sub
        End If
    End Sub

    Function checkExiststlf(ByVal tlf As String, ByVal ruc As String, id As String) As Boolean

        checkCone()
        qr = "SELECT idtelefonosCliente FROM publicidadimpresa.telefonoscliente where numTelf='" & tlf & "'  and clientes_idcliente='" & id & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        Dim contador As Integer = 0
        While rdrs.Read
            contador = contador + 1
        End While
        cone.MysqlConexion.Close()

        If contador > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub frmAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class