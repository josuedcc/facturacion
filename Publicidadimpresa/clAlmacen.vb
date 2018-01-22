Imports Publicidadimpresa.Conexion
Imports Publicidadimpresa.variables
Imports Publicidadimpresa.frmAdd
Imports MySql.Data.MySqlClient
Public Class clAlmacen

    'Tipo Articulo
    Function verExisteTipoArticulo(ByVal nombre As String) As Boolean
        Dim existe As Boolean = False
        frmAdd.checkCone()
        qr = "SELECT nombre_articulo FROM publicidadimpresa.tipodearticulo where nombre_articulo='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        If rdrs.Read Then
            existe = True
        End If
        cone.MysqlConexion.Close()
        Return existe
    End Function

    Function verIdTipoArticulo(ByVal nombre As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idtipodearticulo FROM publicidadimpresa.tipodearticulo where nombre_articulo='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idtipodearticulo")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub ingresarTipoArticulo(ByVal nombre As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`tipodearticulo` (`nombre_articulo`) VALUES (@nombre);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaTipoArticulo() As ArrayList
        Dim TipoArticulos As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT nombre_articulo FROM publicidadimpresa.tipodearticulo order by nombre_articulo DESC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            TipoArticulos.Add(rdrs.Item("nombre_articulo"))
        End While
        cone.MysqlConexion.Close()
        Return TipoArticulos
    End Function

    Function llenaTipoArticulo2() As ArrayList
        Dim TipoArticulos As New ArrayList
        Dim letra As String
        frmAdd.checkCone()
        qr = "SELECT nombre_articulo FROM publicidadimpresa.tipodearticulo order by nombre_articulo ASC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            letra = rdrs.Item("nombre_articulo")
            If letra = "* Otro" Then
                letra = "* Seleccionar"
            End If
            TipoArticulos.Add(letra)
        End While
        cone.MysqlConexion.Close()
        Return TipoArticulos
    End Function

    'Marcas
    Function verExisteMarca(ByVal nombre As String) As Boolean
        Dim existe As Boolean = False
        frmAdd.checkCone()
        qr = "SELECT nombremarca FROM publicidadimpresa.marca where nombremarca='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        If rdrs.Read Then
            existe = True
        End If
        cone.MysqlConexion.Close()
        Return existe
    End Function

    Function verIdMarca(ByVal nombre As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idmarca FROM publicidadimpresa.marca where nombremarca='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idmarca")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub ingresarMarca(ByVal nombre As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`marca` (`nombremarca`) VALUES (@nombre);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaMarcas() As ArrayList
        Dim marcas As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT nombremarca FROM publicidadimpresa.marca order BY nombremarca DESC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            marcas.Add(rdrs.Item("nombremarca"))
        End While
        cone.MysqlConexion.Close()
        Return marcas
    End Function

    Function llenaMarcas2() As ArrayList
        Dim marcas As New ArrayList
        Dim letra As String
        frmAdd.checkCone()

        qr = "SELECT nombremarca FROM publicidadimpresa.marca order BY nombremarca asc;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            letra = rdrs.Item("nombremarca")
            If letra = "* Otro" Then
                letra = "* Seleccionar"
            End If
            marcas.Add(letra)
        End While
        cone.MysqlConexion.Close()
        Return marcas
    End Function

    'Gramaje
    Function verExisteGramaje(ByVal nombre As String) As Boolean
        Dim existe As Boolean = False
        frmAdd.checkCone()
        qr = "SELECT nombregramaje FROM publicidadimpresa.gramaje where nombregramaje='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        If rdrs.Read Then
            existe = True
        End If
        cone.MysqlConexion.Close()
        Return existe
    End Function

    Function verIdGramaje(ByVal nombre As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idgramaje FROM publicidadimpresa.gramaje where nombregramaje='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idgramaje")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub ingresarGramaje(ByVal nombre As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`gramaje` (`nombregramaje`) VALUES (@nombre);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaGramajes() As ArrayList
        Dim Gramajes As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT nombregramaje FROM publicidadimpresa.gramaje order by nombregramaje desc;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            Gramajes.Add(rdrs.Item("nombregramaje"))
        End While
        cone.MysqlConexion.Close()
        Return Gramajes
    End Function

    Function llenaGramajes2() As ArrayList
        Dim Gramajes As New ArrayList
        Dim letrareemplazo As String
        frmAdd.checkCone()
        qr = "SELECT nombregramaje FROM publicidadimpresa.gramaje order by nombregramaje asc;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            letrareemplazo = rdrs.Item("nombregramaje")
            If letrareemplazo = "* Otro" Then
                letrareemplazo = " * Seleccionar"
            End If
            Gramajes.Add(letrareemplazo)
        End While
        cone.MysqlConexion.Close()
        Return Gramajes
    End Function

    'Medidas
    Function verExisteMedida(ByVal nombre As String) As Boolean
        Dim existe As Boolean = False
        frmAdd.checkCone()
        qr = "SELECT nombremedida FROM publicidadimpresa.medidadearticulo WHERE nombremedida='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        If rdrs.Read Then
            existe = True
        End If
        cone.MysqlConexion.Close()
        Return existe
    End Function

    Function verIdMedida(ByVal nombre As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idmedidadearticulo FROM publicidadimpresa.medidadearticulo WHERE nombremedida='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idmedidadearticulo")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub ingresarMedida(ByVal nombre As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`medidadearticulo` (`nombremedida`) VALUES (@nombre);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaMedida() As ArrayList
        Dim Medidas As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT nombremedida FROM publicidadimpresa.medidadearticulo order BY nombremedida DESC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            Medidas.Add(rdrs.Item("nombremedida"))
        End While
        cone.MysqlConexion.Close()
        Return Medidas
    End Function

    Function llenaMedida2() As ArrayList
        Dim Medidas As New ArrayList
        Dim letrareemplazo As String
        frmAdd.checkCone()
        qr = "SELECT nombremedida FROM publicidadimpresa.medidadearticulo order BY nombremedida ASC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            letrareemplazo = rdrs.Item("nombremedida")
            If letrareemplazo = "* Otro" Then
                letrareemplazo = "* Seleccionar"
            End If
            Medidas.Add(letrareemplazo)
        End While
        cone.MysqlConexion.Close()
        Return Medidas
    End Function

    'Tipo papel
    Function verExisteTipoPapel(ByVal nombre As String) As Boolean
        Dim existe As Boolean = False
        frmAdd.checkCone()
        qr = "SELECT nombretipo FROM publicidadimpresa.tipodematerial where nombretipo='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        If rdrs.Read Then
            existe = True
        End If
        cone.MysqlConexion.Close()
        Return existe
    End Function

    Function verIdTipoPapel(ByVal nombre As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idtipodematerial FROM publicidadimpresa.tipodematerial where nombretipo='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idtipodematerial")
        End With

        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub ingresarTipoPapel(ByVal nombre As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`tipodematerial` (`nombretipo`) VALUES (@nombre);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaTipoPapel() As ArrayList
        Dim TipoPapel As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT nombretipo FROM publicidadimpresa.tipodematerial order BY nombretipo DESC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            TipoPapel.Add(rdrs.Item("nombretipo"))
        End While
        cone.MysqlConexion.Close()
        Return TipoPapel
    End Function

    Function llenaTipoPapel2() As ArrayList
        Dim TipoPapel As New ArrayList
        Dim letra As String
        frmAdd.checkCone()
        qr = "SELECT nombretipo FROM publicidadimpresa.tipodematerial order BY nombretipo ASC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            letra = rdrs.Item("nombretipo")
            TipoPapel.Add(letra)
        End While
        cone.MysqlConexion.Close()
        Return TipoPapel
    End Function

    'Tipo Color
    Function verExisteColorPeriodico(ByVal nombre As String) As Boolean
        Dim existe As Boolean = False
        frmAdd.checkCone()
        qr = "SELECT nombrecolor FROM publicidadimpresa.colorperiodico where nombrecolor='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        If rdrs.Read Then
            existe = True
        End If
        cone.MysqlConexion.Close()
        Return existe
    End Function

    Function verIdColorPeriodico(ByVal nombre As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idcolorPeriodico FROM publicidadimpresa.colorperiodico where nombrecolor='" & nombre & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idcolorPeriodico")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub ingresarColorPeriodico(ByVal nombre As String)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`colorperiodico` (`nombrecolor`) VALUES (@nombre);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nombre", nombre)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenaColorPeriodico() As ArrayList
        Dim colores As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT nombrecolor FROM publicidadimpresa.colorperiodico order BY nombrecolor DESC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            colores.Add(rdrs.Item("nombrecolor"))
        End While
        cone.MysqlConexion.Close()
        Return colores
    End Function

    Function llenaColorPeriodico2() As ArrayList
        Dim colores As New ArrayList
        Dim letra As String
        frmAdd.checkCone()
        qr = "SELECT nombrecolor FROM publicidadimpresa.colorperiodico order BY nombrecolor ASC;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            letra = rdrs.Item("nombrecolor")
            If letra = "* Otro" Then
                letra = "* Seleccionar"
            End If
            colores.Add(letra)
        End While
        cone.MysqlConexion.Close()
        Return colores
    End Function

    Function genereacod() As String
        Dim cod As String
        Dim data As New Date
        data = Date.Now
        Dim dia As Integer = data.Date.Day
        Dim mes As Integer = data.Date.Month
        Dim anio As Integer = data.Date.Year
        cod = dia & mes & anio
        Return cod
    End Function

    Function checkcod() As String

        Dim cod As String = genereacod()
        Dim cant As Integer = 1
        Dim newcod As String

        frmAdd.checkCone()
        qr = "SELECT codigo FROM publicidadimpresa.articulo where codigo like '" & cod & "%';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            cant = cant + 1
        End While
        cone.MysqlConexion.Close()
        Console.WriteLine(cant)
        If cant = 0 Then
            newcod = cod & "-" & cant
        Else
            newcod = cod & "-" & cant
        End If
        Return newcod
    End Function

    Public Sub insertarArticulo(ByVal codigo As String, ByVal cantidad As Integer, ByVal idtipoarticulo As Integer, ByVal idmarca As Integer, ByVal idmedida As Integer, ByVal idgramaje As Integer)

        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`articulo` (`codigo`, `cantidad`, `tipodearticulo_idtipodearticulo`,`marca_idmarca`, `medidadearticulo_idmedidadearticulo`, `gramaje_idgramaje`) VALUES (@codigo, @cantidad, @tipo, @marca, @medida, @gramaje);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@codigo", codigo)
        cmds.Parameters.AddWithValue("@cantidad", cantidad)
        '`codigo`, `cantidad`, `tipodearticulo_idtipodearticulo`,
        '`marca_idmarca`, `medidadearticulo_idmedidadearticulo`, `gramaje_idgramaje`
        '(@codigo, @cantidad, @tipo, @marca, @medida, @gramaje)
        cmds.Parameters.AddWithValue("@tipo", idtipoarticulo)
        cmds.Parameters.AddWithValue("@marca", idmarca)
        cmds.Parameters.AddWithValue("@medida", idmedida)
        cmds.Parameters.AddWithValue("@gramaje", idgramaje)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertarArticulo2(ByVal codigo As String, ByVal cantidad As Integer, ByVal idtipoarticulo As Integer, ByVal idmarca As Integer, ByVal idmedida As Integer, ByVal idtipomaterial As Integer, ByVal idgramaje As Integer)

        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`articulo` (`codigo`, `cantidad`, `tipodearticulo_idtipodearticulo`,`marca_idmarca`, `medidadearticulo_idmedidadearticulo`, `tipodematerial_idtipodematerial`, `gramaje_idgramaje`) VALUES (@codigo, @cantidad, @tipo, @marca, @medida, @idmaterial, @gramaje);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@codigo", codigo)
        cmds.Parameters.AddWithValue("@cantidad", cantidad)
        '`codigo`, `cantidad`, `tipodearticulo_idtipodearticulo`,
        '`marca_idmarca`, `medidadearticulo_idmedidadearticulo`, `gramaje_idgramaje`
        '(@codigo, @cantidad, @tipo, @marca, @medida, @gramaje)
        cmds.Parameters.AddWithValue("@tipo", idtipoarticulo)
        cmds.Parameters.AddWithValue("@marca", idmarca)
        cmds.Parameters.AddWithValue("@medida", idmedida)
        cmds.Parameters.AddWithValue("@idmaterial", idtipomaterial)
        cmds.Parameters.AddWithValue("@gramaje", idgramaje)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertarArticulo3(ByVal codigo As String, ByVal cantidad As Integer, ByVal idtipoarticulo As Integer, ByVal idmarca As Integer, ByVal idmedida As Integer, ByVal idgramaje As Integer, ByVal idcolor As Integer)

        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`articulo` (`codigo`, `cantidad`, `tipodearticulo_idtipodearticulo`, `marca_idmarca`, `medidadearticulo_idmedidadearticulo`, `gramaje_idgramaje`, `color_idcolor`) VALUES (@codigo, @cantidad, @tipo, @marca, @medida, @gramaje, @color);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@codigo", codigo)
        cmds.Parameters.AddWithValue("@cantidad", cantidad)
        '`codigo`, `cantidad`, `tipodearticulo_idtipodearticulo`,
        '`marca_idmarca`, `medidadearticulo_idmedidadearticulo`, `gramaje_idgramaje`
        '(@codigo, @cantidad, @tipo, @marca, @medida, @gramaje)
        cmds.Parameters.AddWithValue("@tipo", idtipoarticulo)
        cmds.Parameters.AddWithValue("@marca", idmarca)
        cmds.Parameters.AddWithValue("@medida", idmedida)
        cmds.Parameters.AddWithValue("@gramaje", idgramaje)
        cmds.Parameters.AddWithValue("@color", idcolor)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function llenagrillaalmacen(ByVal articulo As String, ByVal marca As String, ByVal gramaje As String, ByVal medida As String) As DataTable
        Dim tabla As New DataTable
        frmAdd.checkCone()
        qr = "SELECT codigo AS 'CODIGO',nombre_articulo AS 'ARTICULO',nombremarca AS 'MARCA',nombremedida AS 'MEDIDA',nombregramaje AS 'GRAMAJE',cantidad AS 'CANTIDAD' FROM publicidadimpresa.view_almacen WHERE nombre_articulo='" & articulo & "' AND nombremarca='" & marca & "' AND nombremedida='" & medida & "' AND nombregramaje='" & gramaje & "' and habilitado='1';"
        adp = New MySqlDataAdapter(qr, cone.MysqlConexion)
        adp.Fill(tabla)
        cone.MysqlConexion.Close()
        Return tabla
    End Function

    Function llenaGridAlmacenFull() As DataTable
        Dim tabla As New DataTable
        frmAdd.checkCone()
        qr = "SELECT codigo AS 'CODIGO',nombre_articulo AS 'ARTICULO',nombremarca AS 'MARCA',nombremedida AS 'MEDIDA',nombregramaje AS 'GRAMAJE',cantidad AS 'CANTIDAD' FROM publicidadimpresa.view_almacen where habilitado='1';"
        adp = New MySqlDataAdapter(qr, cone.MysqlConexion)
        adp.Fill(tabla)
        cone.MysqlConexion.Close()
        Return tabla
    End Function

    Function llenaGridPrestamos() As DataTable
        Dim tabla As New DataTable
        frmAdd.checkCone()
        qr = "SELECT * FROM publicidadimpresa.view_prestamos where revisado = '1';"
        adp = New MySqlDataAdapter(qr, cone.MysqlConexion)
        adp.Fill(tabla)
        cone.MysqlConexion.Close()
        Return tabla
    End Function

    Function checkCantidad(ByVal codMaterial As String) As Integer
        Dim cantidad As Integer
        frmAdd.checkCone()
        qr = "SELECT cantidad FROM publicidadimpresa.view_almacen where codigo='" & codMaterial & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            cantidad = rdrs.Item("cantidad")
        End With
        cone.MysqlConexion.Close()
        Return cantidad
    End Function

    Function checkCantidad2(ByVal codMaterial As String) As Integer
        Dim cantidad As Integer
        frmAdd.checkCone()
        qr = "SELECT cantidad FROM publicidadimpresa.view_prestamos WHERE CODIGO='" & codMaterial & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            cantidad = rdrs.Item("cantidad")
        End With
        cone.MysqlConexion.Close()
        Return cantidad
    End Function

    Function idarticulo(ByVal codMaterial As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT * FROM publicidadimpresa.articulo where codigo='" & codMaterial & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idarticulo")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function


    Function idArticulo2(ByVal cod As String) As Integer
        Dim id As Integer
        frmAdd.checkCone()
        qr = "SELECT idmaterial FROM publicidadimpresa.retiromaterial where codigo_retiro='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            id = rdrs.Item("idmaterial")
        End With
        cone.MysqlConexion.Close()
        Return id
    End Function

    Public Sub actualizaPrestamoMaterial(ByVal cod As String, ByVal cant As Integer, ByVal cantPrestado As Integer)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`retiromaterial` SET `cantidad`='" & cantPrestado - cant & "' WHERE `codigo_retiro`='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub revisarRetiroMaterial(ByVal cod As String)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`retiromaterial` SET `revisado`='0' WHERE codigo_retiro='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function checkCantPrestamo(ByVal cod As String) As Integer
        Dim cant As Integer
        frmAdd.checkCone()
        qr = "SELECT cantidad FROM publicidadimpresa.retiromaterial where codigo_retiro='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        With rdrs.Read
            cant = rdrs.Item("cantidad")
        End With
        cone.MysqlConexion.Close()
        Return cant
    End Function

    Public Sub sumaDevolucion(ByVal cant As Integer, ByVal id As Integer)
        frmAdd.checkCone()
        qr = "call procedure_suma_devolucion(" & id & "," & cant & ");"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub actulizastock(ByVal idarticulo As Integer, ByVal cantidad As Integer)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`articulo` SET `cantidad`='" & cantidad & "' WHERE `idarticulo`='" & idarticulo & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function fechaactual() As String
        Dim fecha As String
        Dim data As New Date
        data = Date.Now
        Dim dia As Integer = data.Date.Day
        Dim mes As Integer = data.Date.Month
        Dim anio As Integer = data.Date.Year
        fecha = anio & "-" & mes & "-" & dia
        Return fecha
    End Function

    Function checkcodAlmacenRetiro() As String

        Dim cod As String = genereacod()
        Dim cant As Integer = 1
        Dim newcod As String

        frmAdd.checkCone()
        qr = "SELECT codigo_retiro FROM publicidadimpresa.retiromaterial where codigo_retiro like '" & cod & "%';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            cant = cant + 1
        End While
        cone.MysqlConexion.Close()
        Console.WriteLine(cant)
        If cant = 0 Then
            newcod = cod & "-" & cant
        Else
            newcod = cod & "-" & cant
        End If
        Return newcod
    End Function

    Function checkcodAlmacenDevolucion() As String

        Dim cod As String = genereacod()
        Dim cant As Integer = 1
        Dim newcod As String

        frmAdd.checkCone()
        qr = "SELECT codigo_devolucion FROM publicidadimpresa.devolucionmaterial where codigo_devolucion like '" & cod & "%';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            cant = cant + 1
        End While
        cone.MysqlConexion.Close()
        Console.WriteLine(cant)
        If cant = 0 Then
            newcod = cod & "-" & cant
        Else
            newcod = cod & "-" & cant
        End If
        Return newcod
    End Function

    Public Sub insertarretiro(ByVal cod As String, ByVal id As Integer, ByVal fecha As String, ByVal cant As Integer)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`retiromaterial` (`codigo_retiro`, `idmaterial`, `fecha_retiro`, `cantidad`) VALUES (@cod, @id, @fecha, @cant);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@cod", cod)
        cmds.Parameters.AddWithValue("@id", id)
        cmds.Parameters.AddWithValue("@fecha", fecha)
        cmds.Parameters.AddWithValue("@cant", cant)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub deshabilitararticulo(ByVal cod As String)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`articulo` SET `habilitado`='0' WHERE `codigo`='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub devolverarticulo(ByVal cod As String, ByVal cantidad As Integer, ByVal cantidadanterior As Integer)
        frmAdd.checkCone()
        Dim nuevacantidad As Integer
        nuevacantidad = cantidad + cantidadanterior
        qr = "UPDATE `publicidadimpresa`.`articulo` SET `cantidad`='" & nuevacantidad & "' WHERE `codigo`='" & cod & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertardevolucion(ByVal cod As String, ByVal id As Integer, ByVal fecha As String, ByVal cant As Integer)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`devolucionmaterial` (`codigo_devolucion`, `idmaterial`, `fechadevolucion`, `cantidad`) VALUES (@cod, @id, @fecha, @cant);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@cod", cod)
        cmds.Parameters.AddWithValue("@id", id)
        cmds.Parameters.AddWithValue("@fecha", fecha)
        cmds.Parameters.AddWithValue("@cant", cant)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function comprobarExistenciaArticulo(ByVal nombre As String) As Boolean
        Dim resp As Boolean



        Return resp
    End Function

End Class
