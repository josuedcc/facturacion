Imports MySql.Data.MySqlClient
Imports Publicidadimpresa.variables
Imports Publicidadimpresa.Form1
Imports Publicidadimpresa.frmAdd
Imports MetroFramework

Public Class frmUpdateTelf
    Dim con As New Conexion
    Dim lastNomContacto As String
    Dim lastNumContacto As String
    Dim okNomContacto As String
    Dim okNumContacto As String
    Private Sub frmUpdateTelf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNomEmpresa.Text = currentNomEmpresa
        txtNomContacto.Text = currentSelectContact
        txtNumContacto.Text = currentSelectNumContact

        lastNomContacto = txtNomContacto.Text
        lastNumContacto = txtNumContacto.Text

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNumContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumContacto.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'UPDATE `publicidadimpresa`.`telefonoscliente` SET `numTelf`='931572333', `nombreContactotelf`='DevJoa' WHERE `clientes_idcliente`='17';
        'con.MysqlConexion.Open()
        'cone.MysqlConexion.Open()

        ''

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

        ''


        If lastNomContacto <> nomContacto Then
            okNomContacto = nomContacto
        Else
            okNomContacto = lastNomContacto
        End If

        If lastNumContacto <> numContacto Then
            If frmAdd.checkExiststlf(numContacto, currentRuc, currentidEmpresa) = True Then
                MetroMessageBox.Show(Me, "Este número de teléfono " & numContacto & " ya existe", "Teléfono duplicado")
                Exit Sub
            Else
                okNumContacto = numContacto
            End If

        Else
            okNumContacto = lastNumContacto
        End If


        Dim idt As Integer

        idt = checkId(currentSelectNumContact, currentidEmpresa)

        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`telefonoscliente` SET `numTelf`='" & okNumContacto & "', `nombreContactotelf`='" & okNomContacto & "' WHERE `idtelefonosCliente`='" & idt & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
        Form1.loadTablaTlfs(currentRuc)
        Form1.menuCheck()
        Me.Close()
    End Sub

    Function checkId(ByVal numero As String, ByVal currentId As String) As Integer
        'Comprobar existe
        Dim idc As Integer
        frmAdd.checkCone()
        qr = "SELECT * FROM publicidadimpresa.telefonoscliente where numTelf='" & numero & "' and clientes_idcliente='" & currentId & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)


        rdrs = cmds.ExecuteReader

        Dim contador As Integer = 0

        While rdrs.Read
            contador = contador + 1
        End While
        If contador = 1 Then
            idc = rdrs.Item("idtelefonosCliente")
        Else
            idc = 0
        End If
        cone.MysqlConexion.Close()
        Return idc
        'Fin comprobar si existe
    End Function

End Class