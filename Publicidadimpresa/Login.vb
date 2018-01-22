Imports MySql.Data.MySqlClient
Public Class Login
    Dim con As New Conexion
    Dim cmdLogin As MySqlCommand
    Dim clman As New clManageGuia
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click

        login()

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim s As New Conexion
        Console.WriteLine(variables.IdUsuario)
        Console.WriteLine(variables.Usuario)
        's.ProbarConexion()

        'MetroFramework.MetroMessageBox.Show(Me, "Your message here.", "Title Here", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand)
    End Sub

    Public Sub login()
        If txtUser.Text <> vbNullString And txtPass.Text <> vbNullString Then
            Dim readerLogin As MySqlDataReader
            Dim qrlogin As String

            con.MysqlConexion.Open()

            Dim pass As String
            Dim passMd5 As String
            pass = txtPass.Text

            passMd5 = clman.GeneraMD5(pass)

            qrlogin = "SELECT * FROM publicidadimpresa.usuarios where nombreusuario = '" & txtUser.Text & "' and passusuario='" & passMd5 & "';"
            cmdLogin = New MySqlCommand(qrlogin, con.MysqlConexion)

            readerLogin = cmdLogin.ExecuteReader

            Dim count As Integer = 0

            While readerLogin.Read
                count = count + 1
            End While

            'Console.WriteLine(count)
            'MessageBox.Show(count)
            If count = 1 Then
                'MessageBox.Show("Correcto")

                Dim NumLogin As Int16
                Dim UsuarioLogin As String

                NumLogin = readerLogin.Item("idusuarios")
                UsuarioLogin = readerLogin.Item("nombreusuario")

                variables.IdUsuario = NumLogin
                variables.Usuario = UsuarioLogin

                con.MysqlConexion.Close()

                con.MysqlConexion.Open()

                qrlogin = "INSERT INTO `publicidadimpresa`.`logeos` (`usuarios_idusuarios`) VALUES (@usuarios_idusuarios);"

                cmdLogin = New MySqlCommand(qrlogin, con.MysqlConexion)

                cmdLogin.Parameters.AddWithValue("@usuarios_idusuarios", NumLogin)

                cmdLogin.ExecuteNonQuery()

                Console.WriteLine(NumLogin)
                con.MysqlConexion.Close()

                Me.Hide()

                Form1.Show()

            ElseIf count > 1 Then
                MessageBox.Show("Duplicado")
                con.MysqlConexion.Close()
            Else
                MessageBox.Show("Incorrecto")
                con.MysqlConexion.Close()
            End If
        Else
            Exit Sub
        End If
        
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            login()
        End If
    End Sub
End Class