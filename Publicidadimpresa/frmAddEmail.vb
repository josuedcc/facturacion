Imports Publicidadimpresa.Form1
Imports Publicidadimpresa.frmAdd
Imports Publicidadimpresa.variables
Imports MySql.Data.MySqlClient
Imports MetroFramework
Public Class frmAddEmail
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim emailContacto As String = ""
        Dim nomContacto As String = ""

        If txtNomContacto.Text = "" Then
            MetroMessageBox.Show(Me, "Se debe de asignar un nombre de contacto", "Error Nombre de contacto")
            Exit Sub

        Else
            nomContacto = txtNomContacto.Text
        End If

        If txtEmailContacto.Text = "" Then
            MetroMessageBox.Show(Me, "Error Email", "Email icorrector, ejemplo de Emial: diseno@publicidadimpresa.pe")
            Exit Sub
        Else
            If Form1.ValidaEmail(txtEmailContacto.Text) = False Then
                MetroMessageBox.Show(Me, "Error Email", "Email icorrector, ejemplo de Emial: diseno@publicidadimpresa.pe")
                Exit Sub
            Else
                emailContacto = txtEmailContacto.Text
            End If
        End If

        If checkExistsEmail(emailContacto, currentidEmpresa) = True Then
            MetroMessageBox.Show(Me, "El correo " & emailContacto & " ya existe para este cliente.", "Email duplicado")
            Exit Sub
        End If

        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`emailscliente` (`email`, `nombreContacto`, `clientes_idcliente`) VALUES (@emailCli, @nomCliente, @idCliente);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@emailCli", emailContacto)
        cmds.Parameters.AddWithValue("@nomCliente", nomContacto)
        cmds.Parameters.AddWithValue("@idCliente", currentidEmpresa)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()

        Form1.loadTablaEmails(currentRuc)
        Me.Close()

    End Sub

    Function checkExistsEmail(ByVal email As String, id As String) As Boolean

        frmAdd.checkCone()
        qr = "SELECT * FROM publicidadimpresa.emailscliente where email='" & email & "'  and clientes_idcliente='" & id & "';"
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

    Function checkId(ByVal email As String) As Integer
        'Comprobar existe
        Dim idc As Integer
        frmAdd.checkCone()
        qr = "SELECT * FROM publicidadimpresa.emailscliente where email='" & email & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)


        rdrs = cmds.ExecuteReader

        Dim contador As Integer = 0

        While rdrs.Read
            contador = contador + 1
        End While
        If contador = 1 Then
            idc = rdrs.Item("idemailscliente")
        Else
            idc = 0
        End If
        cone.MysqlConexion.Close()
        Return idc
        'Fin comprobar si existe
    End Function
End Class