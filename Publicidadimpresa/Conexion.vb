Imports MySql.Data.MySqlClient
Public Class Conexion


    Private MysqlCommand As New MySqlCommand
    Dim MysqlConnString As String = "server=localhost; user id=root; password='A1PubliImpresaA1'; database=publicidadimpresa; Convert Zero Datetime=True;"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)

    Public Sub ProbarConexion()
        Try
            MysqlConexion.Open()
            'MsgBox("Conexion exitosa")
            MysqlConexion.Close()
        Catch ex As Exception
            'MetroFramework.MetroMessageBox.Show(Me, "Your message here.", "Title Here", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand)
            'MsgBox("No hay conexión con la base de datos")
        End Try
    End Sub

End Class
