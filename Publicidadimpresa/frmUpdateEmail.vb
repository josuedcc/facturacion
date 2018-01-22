Imports MetroFramework
Imports Publicidadimpresa.variables
Imports Publicidadimpresa.frmAddEmail
Imports Publicidadimpresa.Form1
Imports MySql.Data.MySqlClient
Public Class frmUpdateEmail
    Dim lastNomContacto As String
    Dim lastEmailContacto As String
    Dim okNomContacto As String
    Dim okEmailContacto As String
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



        Dim idE As Integer
        idE = frmAddEmail.checkId(currentSelectEmailContact)

        If lastNomContacto <> nomContacto Then
            okNomContacto = nomContacto
        Else
            okNomContacto = lastNomContacto
        End If

        If lastEmailContacto <> emailContacto Then
            If frmAddEmail.checkExistsEmail(emailContacto, currentidEmpresa) = True Then
                MetroMessageBox.Show(Me, "El correo " & emailContacto & " ya existe para este cliente.", "Email duplicado")
                Exit Sub
            Else
                okEmailContacto = emailContacto
            End If

        Else
            okEmailContacto = lastEmailContacto
        End If

        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`emailscliente` SET `email`='" & okEmailContacto & "', `nombreContacto`='" & okNomContacto & "' WHERE `idemailscliente`='" & idE & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
        Form1.loadTablaEmails(currentRuc)
        Form1.menuCheck()
        Me.Close()

    End Sub

    Private Sub frmUpdateEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNomContacto.Text = currentSelectContact
        txtEmailContacto.Text = currentSelectEmailContact

        lastNomContacto = txtNomContacto.Text
        lastEmailContacto = txtEmailContacto.Text

    End Sub



End Class