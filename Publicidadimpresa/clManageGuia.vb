Imports Publicidadimpresa.frmAdd
Imports Publicidadimpresa.Conexion
Imports Publicidadimpresa.variables
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Public Class clManageGuia

    Public Sub insertPartida(ByVal dir As String, ByVal num As String, ByVal interior As String, ByVal zona As String, ByVal depa As String, ByVal prov As String, ByVal dis As String, ByVal codpar As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`domiciliopartida` (`direccion`, `numero`, `interior`, `zona`, `distrito`, `provincia`, `departamento`, `codPartida`) VALUES (@direc, @num, @inte, @zona, @depa, @prov, @dist, @codpar);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@direc", dir)
        cmds.Parameters.AddWithValue("@num", num)
        cmds.Parameters.AddWithValue("@inte", interior)
        cmds.Parameters.AddWithValue("@zona", zona)
        cmds.Parameters.AddWithValue("@depa", depa)
        cmds.Parameters.AddWithValue("@prov", prov)
        cmds.Parameters.AddWithValue("@dist", dis)
        cmds.Parameters.AddWithValue("@codpar", codpar)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertLlegada(ByVal dir As String, ByVal num As String, ByVal interior As String, ByVal zona As String, ByVal depa As String, ByVal prov As String, ByVal dis As String, ByVal codLlega As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`domiciliollegada` (`direccion`, `numero`, `interior`, `zona`, `distrito`, `provincia`, `departamento`, `codLllegada`) VALUES (@direc, @num, @inte, @zona, @depa, @prov, @dist, @codLlega);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@direc", dir)
        cmds.Parameters.AddWithValue("@num", num)
        cmds.Parameters.AddWithValue("@inte", interior)
        cmds.Parameters.AddWithValue("@zona", zona)
        cmds.Parameters.AddWithValue("@depa", depa)
        cmds.Parameters.AddWithValue("@prov", prov)
        cmds.Parameters.AddWithValue("@dist", dis)
        cmds.Parameters.AddWithValue("@codLlega", codLlega)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaDestinatarios(ByVal RUC As String) As ArrayList
        Dim RUCs As New ArrayList

        frmAdd.checkCone()
        qr = "SELECT RUCcliente FROM publicidadimpresa.clientes where habilitadoCliente=1 and RUCcliente like '" & RUC & "%' limit 10;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader

        While rdrs.Read
            RUCs.Add(rdrs.Item("RUCcliente"))
        End While
        Return RUCs
    End Function


    Function llenaCompletaDestinatario(ByVal RUC As String) As String
        Dim razon As String = ""

        frmAdd.checkCone()
        qr = "SELECT razonsocial FROM publicidadimpresa.clientes where habilitadoCliente=1 and RUCcliente='" & RUC & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader

        While rdrs.Read
            razon = rdrs.Item("razonsocial")
        End While
        Return razon
    End Function

    Function llenaCboCodsFactura() As ArrayList
        Dim cods As New ArrayList

        frmAdd.checkCone()
        qr = "SELECT numeroFactura FROM publicidadimpresa.facturas where habilitadoGuia='1' and codGuia IS NOT NULL;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader

        While rdrs.Read
            cods.Add(rdrs.Item("numeroFactura"))
        End While

        cone.MysqlConexion.Close()

        Return cods
    End Function

    Public Sub insertVehiculo(ByVal marca As String, ByVal placa As String, ByVal certificado As String, ByVal licencia As String, ByVal codgen As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`unidadtransporte` (`marcavehiculo`, `placavehiculo`, `certificadoinscripcion`, `licenciadeconducir`, `codGenerado`) VALUES (@marca, @placa, @certi, @lic, @codgen);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@marca", marca)
        cmds.Parameters.AddWithValue("@placa", placa)
        cmds.Parameters.AddWithValue("@certi", certificado)
        cmds.Parameters.AddWithValue("@lic", licencia)
        cmds.Parameters.AddWithValue("@codgen", codgen)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertTransportista(ByVal nombre As String, ByVal ruc As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`transportista` (`nmbretransportista`, `ructransportista`) VALUES (@nombre, @ruc);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.Parameters.AddWithValue("@ruc", ruc)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function verIdComprobante(ByVal tipo As String) As Integer
        Dim id As Integer

        frmAdd.checkCone()
        qr = "SELECT idtipocomprobante FROM publicidadimpresa.tipocomprobante where nombrecomprobante='" & tipo & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            id = rdrs.Item("idtipocomprobante")
        End While
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub insertComprobante(ByVal id As Integer, ByVal cod As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`comprobantepago` (`tipocomprobante_idtipocomprobante`, `CodComprobante`) VALUES (@id, @cod);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@id", id)
        cmds.Parameters.AddWithValue("@cod", cod)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    
    Public Shared idfact As Integer
    Function verIdFactura(ByVal codFact As Integer) As Integer
        Dim cod As Integer = 0
        frmAdd.checkCone()
        qr = "SELECT idfactura FROM publicidadimpresa.facturas where numeroFactura = '" & codFact & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            cod = rdrs.Item("idfactura")
        End While
        cone.MysqlConexion.Close()
        Return cod
    End Function

    Public Sub insertDetGuia(ByVal cant As Integer, ByVal descrip As String, ByVal total As Double, ByVal idguia As Integer)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`detalleguia` (`cantidadguia`, `descripcionguia`, `totalguia`, `idGuia`) VALUES (@cant, @descrip, @total, @idguia);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@cant", cant)
        cmds.Parameters.AddWithValue("@descrip", descrip)
        cmds.Parameters.AddWithValue("@total", total)
        cmds.Parameters.AddWithValue("@idguia", idguia)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function verIdRazontraslado(ByVal razon As String) As Integer
        Dim idRazon As Int16
        frmAdd.checkCone()
        qr = "SELECT idmotivotraslado FROM publicidadimpresa.motivotraslado where nombremotivo ='" & razon & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            idRazon = rdrs.Item("idmotivotraslado")
        End With
        Return idRazon
    End Function

    Function GeneraCod(ByVal datehoy As Date) As String
        Dim varcodeCrypt As String = ""
        Dim varCodeStr As String
        varCodeStr = datehoy.Year & datehoy.Month & datehoy.Day & datehoy.Minute & datehoy.Second
        Dim md5 As New MD5CryptoServiceProvider
        Dim byValue() As Byte
        Dim byHash() As Byte
        Dim i As Integer
        byValue = System.Text.Encoding.UTF8.GetBytes(varCodeStr)
        byHash = md5.ComputeHash(byValue)
        md5.Clear()
        For i = 0 To byHash.Length - 1
            varcodeCrypt &= byHash(i).ToString("x").PadLeft(2, "0")
        Next
        Return varcodeCrypt
    End Function

    Function GeneraMD5(ByVal passletra As String) As String
        Dim varcodeCrypt As String = ""
        Dim varCodeStr As String
        varCodeStr = passletra
        Dim md5 As New MD5CryptoServiceProvider
        Dim byValue() As Byte
        Dim byHash() As Byte
        Dim i As Integer
        byValue = System.Text.Encoding.UTF8.GetBytes(varCodeStr)
        byHash = md5.ComputeHash(byValue)
        md5.Clear()
        For i = 0 To byHash.Length - 1
            varcodeCrypt &= byHash(i).ToString("x").PadLeft(2, "0")
        Next
        Return varcodeCrypt
    End Function

    Function checkidPartida(ByVal codigo As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT iddomicilioPartida FROM publicidadimpresa.domiciliopartida where codPartida = '" & codigo & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("iddomicilioPartida")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Function checkidLlegada(ByVal codigo As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT iddomicilioLlegada FROM publicidadimpresa.domiciliollegada where codLllegada='" & codigo & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("iddomicilioLlegada")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Function checkidVehiculo(ByVal codigo As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idunidadtransporte FROM publicidadimpresa.unidadtransporte where codGenerado = '" & codigo & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idunidadtransporte")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Function checkidTransportista(ByVal ruc As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idtransportista FROM publicidadimpresa.transportista where ructransportista ='" & ruc & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idtransportista")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Function checkidComprobante(ByVal cod As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idcomprobantepago FROM publicidadimpresa.comprobantepago where CodComprobante='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idcomprobantepago")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub insertGuia(ByVal fEmision As Date, ByVal fTraslado As Date, ByVal numGuia As Integer, ByVal dPartida As String, ByVal dLlegada As String,
                          ByVal uTransporte As String, ByVal Transportista As String, ByVal mTraslado As Integer, ByVal idUsuario As Integer,
                          ByVal idcliente As Integer, ByVal idfactura As Integer)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`guias` (`fechaemicion`, `fechainiciotraslado`, `numeracionguia`, `domicilioPartida_iddomicilioPartida`,`domicilioLlegada_iddomicilioLlegada`, `unidadtransporte_idunidadtransporte`, `transportista_idtransportista`, `motivotraslado_idmotivotraslado`, `usuarios_idusuarios`, `clientes_idcliente`, `idFactura`) VALUES (@fEmision, @fTraslado, @numGuia, @dPartida, @dLlegada, @uTransporte, @Transportista, @mTraslado, @idUsuario, @idcliente, @idfactura);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@fEmision", fEmision)
        cmds.Parameters.AddWithValue("@fTraslado", fTraslado)
        cmds.Parameters.AddWithValue("@numGuia", numGuia)
        cmds.Parameters.AddWithValue("@dPartida", dPartida)
        cmds.Parameters.AddWithValue("@dLlegada", dLlegada)
        cmds.Parameters.AddWithValue("@uTransporte", uTransporte)
        cmds.Parameters.AddWithValue("@Transportista", Transportista)
        cmds.Parameters.AddWithValue("@mTraslado", mTraslado)
        cmds.Parameters.AddWithValue("@idUsuario", idUsuario)
        cmds.Parameters.AddWithValue("@idcliente", idcliente)
        cmds.Parameters.AddWithValue("@idfactura", idfactura)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertarotromotivo(ByVal razon As String, ByVal numguia As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`otrosmotivos` (`nombreotrosmotivos`, `numGuia`) VALUES (@razon, @numguia);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@razon", razon)
        cmds.Parameters.AddWithValue("@numguia", numguia)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function verIdGuia(ByVal codGuia As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idfactura FROM publicidadimpresa.facturas where codGuia ='" & codGuia & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idfactura")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function


    Function veridFacturaGuia(ByVal codGuia As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idfactura FROM publicidadimpresa.facturas where codGuia ='" & codGuia & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idfactura")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function


    Function verCodGuia(ByVal idFact As String) As Integer
        Dim id As String
        frmAdd.checkCone()
        qr = "SELECT codGuia FROM publicidadimpresa.facturas where numeroFactura ='" & idFact & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("codGuia")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Function veridDeGuia(ByVal codGuia As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idguias FROM publicidadimpresa.guias where numeracionguia ='" & codGuia & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idguias")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub actEstadoFactGuia(ByVal idfact As String)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`facturas` SET `habilitadoGuia`='0' WHERE `idfactura`='" & idfact & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub upPassUsuario(ByVal pass As String, ByVal user As String)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`usuarios` SET `passusuario`='" & pass & "' WHERE `nombreusuario`='" & user & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

End Class
