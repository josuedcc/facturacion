Imports MetroFramework
Imports MySql.Data.MySqlClient
Imports Publicidadimpresa.variables
Imports Publicidadimpresa.frmAdd
Imports System.Globalization
Imports System.Threading
Imports Publicidadimpresa.soloNumeros

Public Class Form1
    Dim con As New Conexion
    Dim cmdNuevoCliente As MySqlCommand
    Dim cmdVerCliente As MySqlCommand
    Dim readerCliente As MySqlDataReader
    Dim readerCliente2 As MySqlDataReader
    Dim qrNuevoCliente As String
    Dim count As Integer = 0
    Dim idClinete As Integer
    Dim tabla As DataTable
    Dim tablatlfs As DataTable
    Dim tablaemails As DataTable
    Dim adpClientes As MySqlDataAdapter

    Dim diaFiltroAct As Int32
    Dim mesFiltroAct As Int32
    Dim anioFiltroAct As Int32

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result As DialogResult
        result = MessageBox.Show("Se saldrá de la aplicación, ¿Desea continuar?", "Publicidad Impresa", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
            Login.Close()
        ElseIf result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridAlmacen.DataSource = manAlmacen.llenaGridAlmacenFull
        gridSalidas.DataSource = manAlmacen.llenaGridPrestamos
        'Console.WriteLine(variables.IdUsuario)
        'Console.WriteLine(variables.Usuario)
        cboFiltroArticulo.DataSource = manAlmacen.llenaTipoArticulo2
        cbofiltroMedida.DataSource = manAlmacen.llenaMedida2
        cboFiltroGramaje.DataSource = manAlmacen.llenaGramajes2
        cboFiltroMarca.DataSource = manAlmacen.llenaMarcas2


        'cboretiroArticulo.DataSource = manAlmacen.llenaTipoArticulo2
        'cboretiroMedida.DataSource = manAlmacen.llenaMedida2
        'cboretiroGramaje.DataSource = manAlmacen.llenaGramajes2
        'cboretiroMarca.DataSource = manAlmacen.llenaMarcas2
        'cboretiroColor.DataSource = manAlmacen.llenaColorPeriodico2
        'cboretiroTipo.DataSource = manAlmacen.llenaTipoArticulo2

        hideTipoArticulo()
        llenaTipoArticulo()
        llenaMarca()
        llenaGramaje()
        llenaMedida()
        llenaTipoPapel()
        llenacolor()
        MetroTabControl3.SelectedIndex = 0
        lnkUsuario.Text = "Usuario : " & Usuario
        MetroTabControl1.SelectedIndex = 0
        disablevehiculo()
        txtTransportistaNombre.Enabled = False
        txtComprobanteNumero.Visible = False
        cboNumComprobantes.Visible = True

        cboMoneda.SelectedIndex = 1
        MetroRadioButton1.Checked = True
        Dim fech As String

        'fech = Date.Now.Year

        fech = (Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day)

        'MetroTile5.Text = "Bienvenido : " & variables.Usuario

        mtFechaFacturar.Value = fech

        dateEmision.Value = fech
        dateIniTraslado.Value = fech
        diaFiltroAct = dateFin.Value.Day
        mesFiltroAct = dateFin.Value.Month
        anioFiltroAct = dateFin.Value.Year
        '(anioFiltrofin & "-" & mesFiltrofin & "-" & diaFiltrofin)
        fechafin = (anioFiltroAct & "-" & mesFiltroAct & "-" & diaFiltroAct)

        dateInicio.Value = fech
        dateFin.Value = fech

        loadTabla()
        'loadTabla()

        'loadRucs()

        lnkIGV.Text = "IGV: % " & verIGV()
        'lblTotal.Text = "% " & verIGV()
        mskNumeracion.Text = verUltimoCodigo() + 1
        '        llenaCboSeries2()
        llenaCboSeries()
        cboMoneda.SelectedIndex = 1

        Console.WriteLine(cboSerie.Text)

        llenaDepartamentos()

        'llenacomprobante()

        cboNumComprobantes.DataSource = clManGuia.llenaCboCodsFactura

        llenaRazontraslado()

    End Sub

    Private Sub llenaDepartamentos()
        frmAdd.checkCone()
        qr = "SELECT departamento FROM publicidadimpresa.ubdepartamento;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        cboPatidaDep.Items.Add("Seleccionar")
        cboLlegadaDep.Items.Add("Seleccionar")
        While rdrs.Read
            cboPatidaDep.Items.Add(rdrs.Item("departamento"))
            cboLlegadaDep.Items.Add(rdrs.Item("departamento"))
        End While
        cboPatidaDep.SelectedIndex = 0
        cboLlegadaDep.SelectedIndex = 0
    End Sub



    Private Sub llenaCboSeries()
        frmAdd.checkCone()
        qr = "SELECT idseries, idserie FROM publicidadimpresa.series where habilitado =1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        'Console.WriteLine(rdrs.FieldCount)
        Dim contador As Int16 = 0
        Dim contador2 As Int16 = 0
        While rdrs.Read
            cboSerie.Items.Add(rdrs.Item("idserie"))
            'contador = contador + 1
            'series(contador2, 0) = rdrs.Item("idseries")
            'series(contador2, 1) = rdrs.Item("idserie")
            'contador2 = contador2 + 1
            'Console.WriteLine("holaaaa" & series(0, 0))
        End While
        cboSerie.Items.Add("Agregar")
        cboSerie.Items.Add("Eliminar")
        cboSerie.SelectedIndex = 0
        'ReDim series(contador, 2)
        'While rdrs.Read
        '    'contador = contador + 1
        '    'ReDim series(contador, 2)
        '    series(contador2, 0) = rdrs.Item("idseries")
        '    series(contador2, 1) = rdrs.Item("idserie")
        '    contador2 = contador2 + 1
        '    Console.WriteLine("holaaaa" & series(0, 0))
        'End While

        'While rdrs

        cone.MysqlConexion.Close()
    End Sub

    Private Sub llenaCboSeriesFiltro()
        cboSerieFiltro.Items.Clear()
        frmAdd.checkCone()
        qr = "SELECT idseries, idserie FROM publicidadimpresa.series where habilitado =1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        'Console.WriteLine(rdrs.FieldCount)
        Dim contador As Int16 = 0
        Dim contador2 As Int16 = 0
        While rdrs.Read
            cboSerieFiltro.Items.Add(rdrs.Item("idserie"))
        End While
        'cboSerieFiltro.SelectedIndex = 0
        cone.MysqlConexion.Close()
    End Sub

    Public Function provincias(ByVal departamento As String) As ArrayList
        Dim provs As New ArrayList

        frmAdd.checkCone()
        qr = "SELECT provincia FROM publicidadimpresa.view_provincias where departamento='" & departamento & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            provs.Add(rdrs.Item("provincia"))
        End While
        cone.MysqlConexion.Close()

        Return provs

    End Function

    Public Function distritos(ByVal provincia As String) As ArrayList
        Dim dists As New ArrayList
        frmAdd.checkCone()
        qr = "SELECT distrito FROM publicidadimpresa.view_distritos where provincia = '" & provincia & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            dists.Add(rdrs.Item("distrito"))
        End While

        cone.MysqlConexion.Close()
        Return dists
    End Function

    'Private Sub llenacomprobante()
    '    cbocomprobantepago.Items.Add("Seleccionar")
    '    frmAdd.checkCone()
    '    qr = "SELECT nombrecomprobante FROM publicidadimpresa.tipocomprobante;"
    '    cmds = New MySqlCommand(qr, cone.MysqlConexion)
    '    rdrs = cmds.ExecuteReader
    '    While rdrs.Read
    '        cbocomprobantepago.Items.Add(rdrs.Item("nombrecomprobante"))
    '    End While
    '    cone.MysqlConexion.Close()
    '    cbocomprobantepago.SelectedIndex = 0
    'End Sub


    Private Sub llenaRazontraslado()
        frmAdd.checkCone()
        cboRazontraslado.Items.Add("Seleccionar")
        qr = "SELECT nombremotivo FROM publicidadimpresa.motivotraslado;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            cboRazontraslado.Items.Add(rdrs.Item("nombremotivo"))
        End While
        cone.MysqlConexion.Close()
        cboRazontraslado.SelectedIndex = 0
    End Sub

    'Private Sub llenaCboSeries2()
    '    llenaCboSeries()
    '    frmAdd.checkCone()
    '    qr = "SELECT idseries, idserie FROM publicidadimpresa.series where habilitado =1;"
    '    cmds = New MySqlCommand(qr, cone.MysqlConexion)
    '    rdrs = cmds.ExecuteReader
    '    'Console.WriteLine(rdrs.FieldCount)
    '    Dim contador2 As Int16 = 0
    '    While rdrs.Read
    '        'contador = contador + 1
    '        'ReDim series(contador, 2)
    '        series(contador2, 0) = rdrs.Item("idseries")
    '        series(contador2, 1) = rdrs.Item("idserie")
    '        'Console.WriteLine("holaaaa" & series(contador2, 0))
    '        contador2 = contador2 + 1
    '    End While
    '    'While rdrs
    '    cone.MysqlConexion.Close()

    '    For j As Int16 = 0 To contador2 - 1
    '        cboSerie.Items.Add("00" & series(j, 1))
    '    Next

    '    cboSerie.SelectedIndex = 0
    '    'cboSerie.DataSource = series
    'End Sub

    Private Sub MetroButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MetroButton1.Click
        'Console.WriteLine(variables.IdUsuario)
        'Console.WriteLine(variables.Usuario)
        Dim rucCliente As String
        'Dim rucClienteContador As String
        Dim numKeysRuc As Int16
        Dim nomCliente As String
        Dim direcCliente As String
        Dim telfCliente As String
        Dim emailCliente As String

        If txtRuc.Text = "" Then
            MetroMessageBox.Show(Me, "Comprobar RUC", "RUC Vacio")
            ErrorRuc.SetError(Me.txtRuc, "Campo del RUC está vacio")
            Exit Sub
        ElseIf txtRuc.Text.Count > 11 Then
            MetroMessageBox.Show(Me, "Compruebe el ruc")
            ErrorRuc.SetError(Me.txtRuc, "Compruebe el ruc")
            Exit Sub
        ElseIf txtRuc.Text.Count < 11 Then
            MetroMessageBox.Show(Me, "Compruebe el ruc")
            ErrorRuc.SetError(Me.txtRuc, "Compruebe el ruc")
            Exit Sub
        ElseIf txtRuc.ToString.Count Then
            rucCliente = txtRuc.Text
        End If

        'Dim emailCli As String
        'emailCli = txtEmail.Text

        'If ValidaEmail(emailCli) = False Then
        '    MetroMessageBox.Show(Me, "Error Email", "Email icorrector, ejemplo de Emial: diseno@publicidadimpresa.pe")
        'End If

        'If TxtTelfCliente.Text = "" Then
        'ErrorTelf.SetError(Me.TxtTelfCliente,"Campo de tel")
        '    'MetroMessageBox.Show(Me, "Error telefono vacio", "Teléfono vacio")
        'End If

        If txtNomCliente.Text = "" Then
            MetroMessageBox.Show(Me, "Comprobar razón social", "Campo de Razón social esta vacío")
            ErrorNomCliente.SetError(Me.txtNomCliente, "Campo de Razón social esta vacío")
            Exit Sub
        Else
            nomCliente = txtNomCliente.Text
        End If

        If TxtDirecCliente.Text = "" Then
            MetroMessageBox.Show(Me, "Comprobar dirección", "Campo de dirección esta vacío")
            ErrorDireccion.SetError(Me.TxtDirecCliente, "Campo de dirección esta vacío")
            Exit Sub
        Else
            direcCliente = TxtDirecCliente.Text
        End If

        If TxtTelfCliente.Text = "" Then
            telfCliente = "nulo"
        Else
            telfCliente = TxtTelfCliente.Text
        End If

        If txtEmail.Text = "" Then
            emailCliente = "nulo"
        Else
            If ValidaEmail(txtEmail.Text) = False Then
                MetroMessageBox.Show(Me, "Error Email", "Email icorrector, ejemplo de Emial: diseno@publicidadimpresa.pe")
            Else
                emailCliente = txtEmail.Text
            End If
        End If

        ' consultar existe

        con.MysqlConexion.Open()
        qrNuevoCliente = "SELECT idcliente,razonsocial FROM publicidadimpresa.clientes where RUCcliente='" & rucCliente & "' LIMIT 1;"
        cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)
        readerCliente = cmdNuevoCliente.ExecuteReader

        While readerCliente.Read
            count = count + 1

        End While

        If count <> 1 Then
            count = 0
            Console.WriteLine("No existe")
            con.MysqlConexion.Close()

            ' insertar cliente

            con.MysqlConexion.Open()

            qrNuevoCliente = "INSERT INTO `publicidadimpresa`.`clientes` (`RUCcliente`, `razonsocial`, `direcioncliente`) VALUES (@RucCliente, @NomCliente, @DirecCliente);"
            cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)
            cmdNuevoCliente.Parameters.AddWithValue("@RucCliente", rucCliente)
            cmdNuevoCliente.Parameters.AddWithValue("@NomCliente", nomCliente)
            cmdNuevoCliente.Parameters.AddWithValue("@DirecCliente", direcCliente)

            cmdNuevoCliente.ExecuteNonQuery()
            con.MysqlConexion.Close()
            'fin insertar cliente

            'Comprobar existe

            If checkExists(rucCliente) <> 0 Then
                idClinete = checkExists(rucCliente)
                Console.WriteLine("Love You")
                Console.WriteLine(idClinete)
            End If

            'Fin comprobar existe

            ' insertar telefonos

            If telfCliente <> "nulo" Then

                Console.WriteLine("Entro 2")

                con.MysqlConexion.Open()

                qrNuevoCliente = "INSERT INTO `publicidadimpresa`.`telefonoscliente` (`numTelf`, `nombreContactotelf`, `clientes_idcliente`) VALUES (@telfCli, @nomContactoCli, @idCliente);"
                cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)
                cmdNuevoCliente.Parameters.AddWithValue("@telfCli", telfCliente)
                cmdNuevoCliente.Parameters.AddWithValue("@nomContactoCli", nomCliente)
                cmdNuevoCliente.Parameters.AddWithValue("@idCliente", idClinete)
                cmdNuevoCliente.ExecuteNonQuery()

                con.MysqlConexion.Close()

            End If

            ' fin insertar telefonos

            ' insertar email

            If emailCliente <> "nulo" Then

                con.MysqlConexion.Open()
                qrNuevoCliente = "INSERT INTO `publicidadimpresa`.`emailscliente` (`email`, `nombreContacto`, `clientes_idcliente`) VALUES (@emailCli, @nomCliente, @idCliente);"
                cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)
                cmdNuevoCliente.Parameters.AddWithValue("@emailCli", emailCliente)
                cmdNuevoCliente.Parameters.AddWithValue("@nomCliente", nomCliente)
                cmdNuevoCliente.Parameters.AddWithValue("@idCliente", idClinete)
                cmdNuevoCliente.ExecuteNonQuery()
                con.MysqlConexion.Close()
            End If
            ' fin insertar email

        ElseIf count = 1 Then
            count = 0
            MetroMessageBox.Show(Me, "Lo sentimos, pero este RUC ya se encuentra registrado", "RUC Duplicado")
            Console.WriteLine("Si existe")

            con.MysqlConexion.Close()
        End If

        loadTabla()

    End Sub

    Public Sub UpdateCliente(ByVal razon As String, ByVal direccion As String, ByVal ruc As String)
        con.MysqlConexion.Open()
        qrNuevoCliente = "UPDATE `publicidadimpresa`.`clientes` SET `razonsocial`='" & razon & "', `direcioncliente`='" & direccion & "' WHERE `RUCcliente`='" & ruc & "';"
        cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)
        cmdNuevoCliente.ExecuteNonQuery()
        con.MysqlConexion.Close()
        loadTabla()
        'UPDATE `publicidadimpresa`.`clientes` SET `razonsocial`='Josue1', `direcioncliente`='Lima1' WHERE `RUCcliente`='22222222222';
    End Sub



    Private Sub txtRuc_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtRuc.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtTelfCliente_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TxtTelfCliente.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Public Function ValidaEmail(ByVal email As String) As Boolean
        Dim emailReg As New System.Text.RegularExpressions.Regex(
            "^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailReg.Match(email)
        Return emailMatch.Success
    End Function

    Function checkIDFactura(ByVal id As Int16) As Int16
        Dim idF As Int16
        frmAdd.checkCone()
        qr = "SELECT idfactura,numeroFactura FROM publicidadimpresa.facturas where numeroFactura='" & id & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        'Dim contador As Int16 = 0
        While rdrs.Read
            'contador = contador + 1
            idF = rdrs.Item("idfactura")
        End While
        Return idF
    End Function

    Function checkExists(ByVal ruc As String) As Integer
        'Comprobar existe
        Dim idc As Integer
        con.MysqlConexion.Open()
        qrNuevoCliente = "SELECT idcliente,razonsocial FROM publicidadimpresa.clientes where RUCcliente='" & ruc & "' LIMIT 1;"
        cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)


        readerCliente2 = cmdNuevoCliente.ExecuteReader

        Dim contador As Integer = 0

        While readerCliente2.Read
            contador = contador + 1
        End While
        If contador = 1 Then
            idc = readerCliente2.Item("idcliente")
        Else
            idc = 0
        End If
        con.MysqlConexion.Close()
        Return idc
        'Fin comprobar si existe
    End Function


    'comprueba ID de SERIE
    Function checkIdSerie(ByVal id As Int32) As Int32
        Dim idserie As Int32 = 0
        frmAdd.checkCone()
        qr = "SELECT idseries FROM publicidadimpresa.series where idserie='" & id & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader

        While rdrs.Read
            idserie = rdrs.Item("idseries")
        End While
        Return idserie
    End Function

    Function checkHabilitado(ByVal id As Int32) As Int32
        Dim habilitado As Int32 = 0
        frmAdd.checkCone()
        qr = "SELECT habilitado FROM publicidadimpresa.series where idserie='" & id & "' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader

        While rdrs.Read
            habilitado = rdrs.Item("habilitado")
        End While
        Return habilitado
    End Function

    Function verIGV() As Integer
        Dim igv As Int16 = 0
        frmAdd.checkCone()
        qr = "SELECT cantIGV FROM publicidadimpresa.igv limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            igv = rdrs.Item("cantIGV")
        End While
        cone.MysqlConexion.Close()
        Return igv
    End Function

    Public Sub ingresarIGV(ByVal igv As Int32)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`igv` (`cantIGV`) VALUES (@igv);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@igv", igv)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Function verUltimoCodigo() As Integer
        Dim cod As Integer
        frmAdd.checkCone()
        qr = "SELECT numeroFactura FROM publicidadimpresa.facturas ORDER BY numeroFactura DESC LIMIT 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        While rdrs.Read
            cod = rdrs.Item("numeroFactura")
        End While
        cone.MysqlConexion.Close()
        Return cod
    End Function

    Function actualizarIGV(ByVal igv As Int16, ByVal igvEx As Int16) As Int16
        Dim Uigv As Int16
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`igv` SET `cantIGV`='" & igv & "' WHERE `cantIGV`='" & igvEx & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
        Return Uigv
    End Function

    Public Sub actualizarcodigo(ByVal codigo As Integer)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`ultimocodigo` SET `codigo`='" & codigo & "' WHERE `idultimocodigo`='1';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub loadTabla()
        frmAdd.checkCone()
        tabla = New DataTable
        adpClientes = New MySqlDataAdapter("SELECT RUCcliente AS 'RUC',razonsocial AS 'RAZON SOCIAL' FROM publicidadimpresa.clientes where habilitadoCliente='1';", cone.MysqlConexion)
        adpClientes.Fill(tabla)
        Me.mtGridClientes.DataSource = tabla

        Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cone.MysqlConexion.Close()
        'Console.WriteLine(Me.mtGridClientes.ColumnCount)
    End Sub

    Public Sub llenaFacturas()
        'Me.gridFacturas.Refresh()
        Dim idia As String
        Dim imes As String
        Dim ianio As String

        idia = dateInicio.Value.Day
        imes = dateInicio.Value.Month
        ianio = dateInicio.Value.Year
        Dim finicio As String
        finicio = (ianio & "-" & imes & "-" & idia)

        Dim fdia As String
        Dim fmes As String
        Dim fanio As String

        fdia = dateFin.Value.Day
        fmes = dateFin.Value.Month
        fanio = dateFin.Value.Year
        Dim ffin As String
        ffin = (fanio & "-" & fmes & "-" & fdia)

        'fechainicio = (anioFiltroini & "-" & mesFiltroini & "-" & diaFiltroini)

        Dim table As DataTable
        table = New DataTable
        frmAdd.checkCone()
        adp = New MySqlDataAdapter("SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas where habilitado=1 and fech_factura between '" & finicio & "' and '" & ffin & "';", cone.MysqlConexion)
        adp.Fill(table)
        Me.gridFacturas.DataSource = table
        Me.gridFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        cone.MysqlConexion.Close()
    End Sub

    Public Sub llenaFacturasAnulada()
        Dim idia As String
        Dim imes As String
        Dim ianio As String

        idia = dateInicio.Value.Day
        imes = dateInicio.Value.Month
        ianio = dateInicio.Value.Year
        Dim finicio As String
        finicio = (ianio & "-" & imes & "-" & idia)

        Dim fdia As String
        Dim fmes As String
        Dim fanio As String

        fdia = dateFin.Value.Day
        fmes = dateFin.Value.Month
        fanio = dateFin.Value.Year
        Dim ffin As String
        ffin = (fanio & "-" & fmes & "-" & fdia)
        frmAdd.checkCone()
        Dim table As DataTable
        table = New DataTable
        adp = New MySqlDataAdapter("SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas where habilitado=0 and fech_factura between '" & finicio & "' and '" & ffin & "';", cone.MysqlConexion)
        adp.Fill(table)
        Me.gridFacturas.DataSource = table
        Me.gridFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        cone.MysqlConexion.Close()
    End Sub

    Public Sub llenaFacturasTodo()
        frmAdd.checkCone()
        Dim table As DataTable
        table = New DataTable
        adp = New MySqlDataAdapter("SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas;", cone.MysqlConexion)
        adp.Fill(table)
        Me.gridFacturas.DataSource = table
        Me.gridFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        cone.MysqlConexion.Close()
    End Sub

    Public Sub llenaFacturasSerie(ByVal s As Int16)
        frmAdd.checkCone()
        Dim table As DataTable
        table = New DataTable
        adp = New MySqlDataAdapter("SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas where SERIE='" & s & "';", cone.MysqlConexion)
        adp.Fill(table)
        Me.gridFacturas.DataSource = table
        Me.gridFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        cone.MysqlConexion.Close()
    End Sub

    Public Sub loadTablafind(ByVal keyFind As String)
        frmAdd.checkCone()
        tabla = New DataTable
        adpClientes = New MySqlDataAdapter("SELECT RUCcliente AS 'RUC',razonsocial AS 'RAZON SOCIAL' FROM publicidadimpresa.clientes where RUCcliente like '" & keyFind & "%' and habilitadoCliente=1 or razonsocial like '" & keyFind & "%' and habilitadoCliente=1;", cone.MysqlConexion)
        adpClientes.Fill(tabla)
        Me.mtGridClientes.DataSource = tabla
        cone.MysqlConexion.Close()
        'Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub



    Public Sub loadTablaFacturasFind(ByVal keyFind As String)

        frmAdd.checkCone()
        tabla = New DataTable
        qr = "SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA' FROM publicidadimpresa.view_facturas where RUCcliente like '" & keyFind & "%' and habilitado=1 or razonsocial like '" & keyFind & "%' and habilitado=1 or numeroFactura='" & keyFind & "%'  and habilitado=1;"
        adp = New MySqlDataAdapter(qr, cone.MysqlConexion)
        adp.Fill(tabla)
        Me.gridFacturas.DataSource = tabla
        cone.MysqlConexion.Close()
        'Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Sub loadTablaFacturasFindAnulado(ByVal keyFind As String)
        frmAdd.checkCone()
        tabla = New DataTable
        adp = New MySqlDataAdapter("SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA' FROM publicidadimpresa.view_facturas where RUCcliente like '" & keyFind & "%' and habilitado=0 or razonsocial like '" & keyFind & "%' and habilitado=0 or numeroFactura='" & keyFind & "%'  and habilitado=0;", cone.MysqlConexion)
        adp.Fill(tabla)
        Me.gridFacturas.DataSource = tabla
        cone.MysqlConexion.Close()
        'Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Sub loadTablaFacturasFindTodos(ByVal keyFind As String)
        frmAdd.checkCone()
        tabla = New DataTable
        adp = New MySqlDataAdapter("SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA' FROM publicidadimpresa.view_facturas where RUCcliente like '" & keyFind & "%' or razonsocial like '" & keyFind & "%' or numeroFactura='" & keyFind & "%';", cone.MysqlConexion)
        adp.Fill(tabla)
        Me.gridFacturas.DataSource = tabla
        cone.MysqlConexion.Close()
        'Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Sub loadTablaTlfs(ByVal ruc As String)
        frmAdd.checkCone()
        tablatlfs = New DataTable
        adpClientes = New MySqlDataAdapter("SELECT tlfCli.nombreContactotelf as 'NOMBRE DE CONTACTO', tlfCli.numTelf as 'NUMERO DE TELEFONO' FROM publicidadimpresa.telefonoscliente as tlfCli inner join clientes as cli on tlfCli.clientes_idcliente = cli.idcliente where cli.RUCcliente='" & ruc & "';", cone.MysqlConexion)
        adpClientes.Fill(tablatlfs)
        Me.mtGrudTlfs.DataSource = tablatlfs
        cone.MysqlConexion.Close()
        'Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Sub loadTablaEmails(ByVal ruc As String)
        frmAdd.checkCone()
        tablaemails = New DataTable
        adpClientes = New MySqlDataAdapter("SELECT emailsCli.nombreContacto as 'NOMBRE DE CONTACTO', emailsCli.email as 'E-Mail' FROM publicidadimpresa.emailscliente as emailsCli inner join clientes as cli on emailsCli.clientes_idcliente = cli.idcliente where cli.RUCcliente='" & ruc & "';", cone.MysqlConexion)
        adpClientes.Fill(tablaemails)
        Me.mtGridEmails.DataSource = tablaemails
        cone.MysqlConexion.Close()
        'Me.mtGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel1.Paint

    End Sub



    Private Sub mtGridClientes_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mtGridClientes.CellClick

        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            MetroPanel4.Visible = False
            PictureBox1.Visible = False
            MetroTabControl2.Visible = True
            Dim RucClick As String
            Dim num As Integer = 0
            RucClick = mtGridClientes.Rows(e.RowIndex).Cells(0).Value

            con.MysqlConexion.Open()
            Dim qrVerDetalleCliente As String

            qrVerDetalleCliente = "SELECT RUCcliente,razonsocial,direcioncliente FROM publicidadimpresa.clientes where RUCcliente='" & RucClick & "';"
            cmdVerCliente = New MySqlCommand(qrVerDetalleCliente, con.MysqlConexion)
            readerCliente = cmdVerCliente.ExecuteReader

            disabletxtBoxs()

            With readerCliente.Read
                num = num + 1
            End With

            If num = 1 Then
                txtRucEmpresa.Text = readerCliente.Item("RUCcliente")
                txtNomEmpresa.Text = readerCliente.Item("razonsocial")
                txtDireccionEmpresa.Text = readerCliente.Item("direcioncliente")
            End If

            con.MysqlConexion.Close()

            loadTablaTlfs(RucClick)
            loadTablaEmails(RucClick)

            menuCheck()
            'Console.WriteLine(mtGridClientes.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub



    Public Sub menuCheck()
        If mtGrudTlfs.RowCount > 0 Then
            MenuActualizar.Visible = True
            MenuEliminar.Visible = True
        Else
            MenuActualizar.Visible = False
            MenuEliminar.Visible = False
        End If
    End Sub

    Public Sub menuCheckEmail()
        If mtGridEmails.RowCount > 0 Then
            MenuActualizarEmail.Visible = True
            MenuEliminarEmail.Visible = True
        Else
            MenuActualizarEmail.Visible = False
            MenuEliminarEmail.Visible = False
        End If
    End Sub

    Private Sub mtTxtFind_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mtTxtFind.TextChanged
        Dim keyFind As String

        If mtTxtFind.Text = "" Then
            keyFind = ""
            loadTabla()
        Else
            keyFind = mtTxtFind.Text
            loadTablafind(keyFind)
        End If
    End Sub


    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = False
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub MetroPanel4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MetroPanel4.Paint

    End Sub

    Private Sub tileUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tileUpdate.Click

        If tileUpdate.Text = "Actualizar" Then
            enabletxtBoxs()
        ElseIf tileUpdate.Text = "Guardar" Then

            UpdateCliente(txtNomEmpresa.Text, txtDireccionEmpresa.Text, txtRucEmpresa.Text)

            disabletxtBoxs()

        End If


    End Sub

    'UPDATE `publicidadimpresa`.`clientes` SET `razonsocial`='Josue' WHERE `idcliente`='15';

    Public Sub enabletxtBoxs()
        txtNomEmpresa.Enabled = True
        txtNomEmpresa.ReadOnly = False
        txtNomEmpresa.Style = MetroColorStyle.Red
        tileUpdate.TileImage = My.Resources.icon_save

        txtRucEmpresa.Enabled = True
        txtRucEmpresa.ReadOnly = True
        txtRucEmpresa.Style = MetroColorStyle.Blue


        txtDireccionEmpresa.Enabled = True
        txtDireccionEmpresa.ReadOnly = False
        txtDireccionEmpresa.Style = MetroColorStyle.Red

        txtDireccionEmpresa.Focus()
        txtRucEmpresa.Focus()
        txtNomEmpresa.Focus()
        tileUpdate.Text = "Guardar"
        tileUpdate.BackColor = Color.Green
    End Sub


    Public Sub disabletxtBoxs()
        txtNomEmpresa.Enabled = False
        txtNomEmpresa.ReadOnly = True
        txtNomEmpresa.Style = MetroColorStyle.Red
        tileUpdate.TileImage = My.Resources.icon_update


        txtRucEmpresa.Enabled = False
        txtRucEmpresa.ReadOnly = True
        txtRucEmpresa.Style = MetroColorStyle.Blue


        txtDireccionEmpresa.Enabled = False
        txtDireccionEmpresa.ReadOnly = True
        txtDireccionEmpresa.Style = MetroColorStyle.Red

        txtDireccionEmpresa.Focus()
        txtRucEmpresa.Focus()
        txtNomEmpresa.Focus()
        tileUpdate.Text = "Actualizar"
        tileUpdate.BackColor = MetroColors.Blue
    End Sub


    Private Sub MenuActualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuActualizar.Click
        'Console.WriteLine(mtGrudTlfs.CurrentCell.Value)
        'Console.WriteLine(mtGrudTlfs.CurrentCell.RowIndex)
        Console.WriteLine(mtGrudTlfs.RowCount)
        Console.WriteLine(mtGrudTlfs.Rows(mtGrudTlfs.CurrentCell.RowIndex).Cells(1).Value)
        If txtRucEmpresa.Text <> "" Then
            'Console.WriteLine(checkExists(txtRucEmpresa.Text))
            variables.currentRuc = txtRucEmpresa.Text
            variables.currentidEmpresa = checkExists(txtRucEmpresa.Text)
            variables.currentNomEmpresa = txtNomEmpresa.Text
            variables.currentSelectContact = mtGrudTlfs.Rows(mtGrudTlfs.CurrentCell.RowIndex).Cells(0).Value
            variables.currentSelectNumContact = mtGrudTlfs.Rows(mtGrudTlfs.CurrentCell.RowIndex).Cells(1).Value
            frmUpdateTelf.Show()
        End If

        'Console.WriteLine(mtGrudTlfs.CurrentCell.RowIndex)
        'RucClick = mtGridClientes.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub MenuTelefono_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MenuTelefono.Opening
        'MenuTelefono.BackColor = MetroColors.Magenta
    End Sub

    Private Sub MenuAgregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuAgregar.Click

        If txtRucEmpresa.Text <> "" Then
            'Console.WriteLine(checkExists(txtRucEmpresa.Text))
            variables.currentRuc = txtRucEmpresa.Text
            variables.currentidEmpresa = checkExists(txtRucEmpresa.Text)
            frmAdd.Show()

        End If

    End Sub

    Private Sub MenuEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuEliminar.Click
        If txtRucEmpresa.Text <> "" Then
            'Console.WriteLine(checkExists(txtRucEmpresa.Text))
            currentRuc = txtRucEmpresa.Text
            currentidEmpresa = checkExists(txtRucEmpresa.Text)
            currentSelectNumContact = mtGrudTlfs.Rows(mtGrudTlfs.CurrentCell.RowIndex).Cells(1).Value
            'cone.MysqlConexion.Open()
            frmAdd.checkCone()
            qr = "DELETE FROM `publicidadimpresa`.`telefonoscliente` WHERE `numTelf`='" & currentSelectNumContact & "' and `clientes_idcliente`='" & currentidEmpresa & "';"
            cmds = New MySqlCommand(qr, cone.MysqlConexion)
            cmds.ExecuteNonQuery()
            loadTablaTlfs(currentRuc)
            menuCheck()
        End If
    End Sub

    Private Sub MenuEmails_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MenuEmails.Opening
        menuCheckEmail()
    End Sub

    Private Sub MenuAgregarEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuAgregarEmail.Click
        If txtRucEmpresa.Text <> "" Then
            'Console.WriteLine(checkExists(txtRucEmpresa.Text))
            variables.currentRuc = txtRucEmpresa.Text
            variables.currentidEmpresa = checkExists(txtRucEmpresa.Text)
            frmAddEmail.Show()
        End If
    End Sub

    Private Sub MenuActualizarEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuActualizarEmail.Click
        If txtRucEmpresa.Text <> "" Then
            'Console.WriteLine(checkExists(txtRucEmpresa.Text))
            variables.currentRuc = txtRucEmpresa.Text
            variables.currentidEmpresa = checkExists(txtRucEmpresa.Text)
            variables.currentNomEmpresa = txtNomEmpresa.Text
            variables.currentSelectContact = mtGridEmails.Rows(mtGridEmails.CurrentCell.RowIndex).Cells(0).Value
            variables.currentSelectEmailContact = mtGridEmails.Rows(mtGridEmails.CurrentCell.RowIndex).Cells(1).Value
            frmUpdateEmail.Show()
        End If
    End Sub

    Private Sub MetroTabPage2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MetroTabPage2.Click

    End Sub

    Private Sub MetroLabel9_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub tileDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tileDelete.Click
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`clientes` SET `habilitadoCliente`='0' WHERE `RUCcliente`='" & txtRucEmpresa.Text & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()



        If mtTxtFind.Text = "" Then
            loadTabla()
        Else
            loadTablafind(mtTxtFind.Text)
        End If
        MetroPanel4.Visible = True
        PictureBox1.Visible = True
        MetroTabControl2.Visible = False

        'UPDATE `publicidadimpresa`.`clientes` SET `habilitadoCliente`='0' WHERE `RUCcliente`='11111111111';
    End Sub

    Private Sub MostrarReporteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MostrarReporteToolStripMenuItem.Click

        Dim dsverfacts As New dsRpFacturas
        Dim dtverFacturas As New dsRpFacturas.facturasDataTable
        Dim rpverfacturas As New crVerFacturas

        'Dim RpDatos As New CrystalDecisions.Shared.ParameterValues
        'Dim DsFecha As New CrystalDecisions.Shared.ParameterDiscreteValue

        'DsFecha.Value = dateInicio.Value

        'RpDatos.Add(DsFecha)
        'rpverfacturas.DataDefinition.ParameterFields("fecha").ApplyCurrentValues(RpDatos)
        'RpDatos.Clear()

        'Dim dtdatosfiltro As New dsRpFacturas.filtroRow

        Dim filas As Integer = gridFacturas.Rows.Count
        Dim i As Integer = 0

        For i = 0 To filas - 1
            dtverFacturas.Rows.Add(
                Me.gridFacturas.Rows(i).Cells(0).Value,
                Me.gridFacturas.Rows(i).Cells(1).Value,
                Me.gridFacturas.Rows(i).Cells(2).Value,
                Me.gridFacturas.Rows(i).Cells(3).Value,
                Me.gridFacturas.Rows(i).Cells(4).Value,
                Me.gridFacturas.Rows(i).Cells(5).Value)
        Next (i)

        'dtdatosfiltro.Rows.Add(dateInicio.Value, dateInicio.Value, dateFin.Value, 0, 0, 0, 0)



        dsverfacts.Tables(0).Merge(dtverFacturas)
        'dsverfacts.Tables("filtro").Merge(dtdatosfiltro)
        rpverfacturas.SetDataSource(dsverfacts)

        rpverfacturas.SetParameterValue("fInicio", dateInicio.Value)
        rpverfacturas.SetParameterValue("fFin", dateFin.Value)
        rpverfacturas.SetParameterValue("serie", cboSerieFiltro.Text)
        rpverfacturas.SetParameterValue("noAnulados", "si")
        rpverfacturas.SetParameterValue("anulados", "si")
        rpverfacturas.SetParameterValue("vertodos", "si")

        reporteFacturas.CrystalReportViewer1.ReportSource = rpverfacturas
        reporteFacturas.Show()

        'Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptDoc = New CrystalReportFacturas

        'reporteFacturas.CrystalReportViewer1.ReportSource = rptDoc
        'reporteFacturas.ShowDialog()
        'reporteFacturas.Dispose()

    End Sub

    Private Sub MetroTile1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles MetroTile1.Click
        Dim year As Int16
        Dim mes As Int16
        Dim dia As Int16
        Dim fechaFactura As String = ""
        Dim rucFactura As String = ""
        Dim razonFactura As String = ""
        Dim direcFactura As String = ""
        Dim codOrdenCompraFactura As String = ""
        Dim cantFilas As Int16
        Dim serie As Int16
        Dim habilitadoGuia As Integer
        Dim resp As String = MessageBox.Show("Se creará la factura", "Facturar", MessageBoxButtons.YesNo)
        If resp = DialogResult.No Then
            Exit Sub
        End If

        year = mtFechaFacturar.Value.Date.Year
        mes = mtFechaFacturar.Value.Date.Month
        dia = mtFechaFacturar.Value.Date.Day
        'Console.WriteLine(year & "-" & mes & "-" & dia)

        fechaFactura = (year & "-" & mes & "-" & dia)


        If txtRucFactura.Text <> "" And txtRucFactura.Text.Count = 11 Then
            rucFactura = txtRucFactura.Text
        Else
            ErrorRucFactura.SetError(Me.mtTileFind, "Error en el RUC ingresado")
            Exit Sub
        End If

        If txtRazonFactura.Text <> "" Then
            razonFactura = txtRazonFactura.Text
        Else
            ErrorRazonFactura.SetError(Me.txtRazonFactura, "Error en el nombre de la razón social ingresada")
            Exit Sub
        End If

        If txtDirecFactura.Text <> "" Then
            direcFactura = txtDirecFactura.Text
        Else
            ErrorDireccion.SetError(Me.txtDirecFactura, "Error en la dirección ingresada")
            Exit Sub
        End If

        If txtGuiaFactura.Text <> "" Then
            codGuiaFactura = txtGuiaFactura.Text
            habilitadoGuia = 1
        Else
            codGuiaFactura = ""
            habilitadoGuia = 0
        End If

        If txtOrdenCompraFactura.Text <> "" Then
            codOrdenCompraFactura = txtOrdenCompraFactura.Text
        Else
            codOrdenCompraFactura = ""
        End If

        If cboSerie.Text <> "Agregar" And cboSerie.Text <> "Eliminar" Then
            serie = cboSerie.Text
        Else
            Exit Sub
        End If

        Dim cantrowsdetalle As Int16
        cantrowsdetalle = mtGridDetallesFactura.RowCount
        Console.WriteLine("Contador de filas" & mtGridDetallesFactura.RowCount)

        Dim idFactura As Int16
        Dim nombreDetalle As String
        Dim cant As Int32
        Dim pUnitario As Double
        Dim pTotal As Double


        Dim idEmpres As Int16

        If cantrowsdetalle > 0 Then
            If checkExists(rucFactura) <> 0 Then
                'Console.WriteLine("Existe")
                'Console.WriteLine("Existe" & checkExists(rucFactura))
                'Console.WriteLine("Existe" & IdUsuario)
                Console.WriteLine("Contador de filas 2" & mtGridDetallesFactura.RowCount)
                Console.WriteLine("Entro 1")
                idEmpres = checkExists(rucFactura)
                insertFactura(fechaFactura, idEmpres, IdUsuario, mskNumeracion.Text, txtSubTotalF.Text, txtIGVF.Text, txtTotalF.Text, totalletras, checkIdSerie(serie), habilitadoGuia, codGuiaFactura, codOrdenCompraFactura)

                For i2 As Int16 = 0 To cantrowsdetalle - 1
                    'mtGridDetallesFactura.Rows.Add()
                    idFactura = checkIDFactura(mskNumeracion.Text)
                    cant = mtGridDetallesFactura.Rows(i2).Cells(0).Value
                    nombreDetalle = mtGridDetallesFactura.Rows(i2).Cells(1).Value
                    pUnitario = mtGridDetallesFactura.Rows(i2).Cells(2).Value
                    pTotal = mtGridDetallesFactura.Rows(i2).Cells(3).Value
                    insertarDetalles(nombreDetalle, cant, pUnitario, pTotal, idFactura)
                Next
                mskNumeracion.Text = verUltimoCodigo() + 1
            Else
                insertCliente(rucFactura, razonFactura, direcFactura)
                idEmpres = checkExists(rucFactura)
                insertFactura(fechaFactura, idEmpres, IdUsuario, mskNumeracion.Text, txtSubTotalF.Text, txtIGVF.Text, txtTotalF.Text, totalletras, checkIdSerie(serie), habilitadoGuia, codGuiaFactura, codOrdenCompraFactura)
                For i2 As Int16 = 0 To cantrowsdetalle - 1
                    'mtGridDetallesFactura.Rows.Add()
                    idFactura = checkIDFactura(mskNumeracion.Text)
                    cant = mtGridDetallesFactura.Rows(i2).Cells(0).Value
                    nombreDetalle = mtGridDetallesFactura.Rows(i2).Cells(1).Value
                    pUnitario = mtGridDetallesFactura.Rows(i2).Cells(2).Value
                    pTotal = mtGridDetallesFactura.Rows(i2).Cells(3).Value
                    insertarDetalles(nombreDetalle, cant, pUnitario, pTotal, idFactura)
                Next
                mskNumeracion.Text = verUltimoCodigo() + 1
                txtRucFactura.AutoCompleteCustomSource.Clear()
                loadRucs()
            End If
            'gridFacturas.Rows.Clear()
            llenaFacturas()

            'llenar reporte de facturas
            Dim dsFactura As New dsFactura
            Dim dtFactura As New dsFactura.facturaDataTable
            Dim rpverfacturas As New crFactura
            Dim clfech As New clFechaletra


            Dim filas As Integer = mtGridDetallesFactura.Rows.Count

            Dim i As Integer = 0

            For i = 0 To filas - 1
                dtFactura.Rows.Add(
                    i + 1,
                    Me.mtGridDetallesFactura.Rows(i).Cells(0).Value,
                    Me.mtGridDetallesFactura.Rows(i).Cells(1).Value,
                    Me.mtGridDetallesFactura.Rows(i).Cells(2).Value,
                    Me.mtGridDetallesFactura.Rows(i).Cells(3).Value,
                    simbolomoneda
                    )
            Next (i)

            dsFactura.Tables(0).Merge(dtFactura)
            rpverfacturas.SetDataSource(dsFactura)


            rpverfacturas.SetParameterValue("pfdia", mtFechaFacturar.Value.Day)
            mes = mtFechaFacturar.Value.Month

            leta.MascaraSalidaDecimal = tipomoneda
            leta.ApocoparUnoParteDecimal = True
            totalletras = leta.ToCustomCardinal(totalfactura)
            totalletras = UCase(Mid(totalletras, 1, 1)) + Mid(totalletras, 2, Len(totalletras))

            Console.WriteLine(tipomoneda)
            Console.WriteLine(totalletras)
            rpverfacturas.SetParameterValue("pfmes", clfech.mesaletras(mes))
            rpverfacturas.SetParameterValue("pfanio", mtFechaFacturar.Value.Year)
            rpverfacturas.SetParameterValue("prazon", razonFactura)
            rpverfacturas.SetParameterValue("pruc", rucFactura)
            rpverfacturas.SetParameterValue("pdireccion", direcFactura)
            rpverfacturas.SetParameterValue("pguia", codGuiaFactura)
            rpverfacturas.SetParameterValue("pocompra", codOrdenCompraFactura)
            rpverfacturas.SetParameterValue("ptotalletra", totalletras)
            rpverfacturas.SetParameterValue("psubtotal", subtotalfactura)
            rpverfacturas.SetParameterValue("pigv", igvfactura)
            rpverfacturas.SetParameterValue("ptotal", totalfactura)
            rpverfacturas.SetParameterValue("psimbolomoneda", simbolomoneda)


            Dim dr As New DialogResult
            PrintDialog1.Document = PrintDocument1
            dr = PrintDialog1.ShowDialog()

            Dim ncopy As Integer
            Dim spage As Integer
            Dim epage As Integer
            Dim PrinterNam As String
            If dr = DialogResult.OK Then
                ncopy = PrintDocument1.PrinterSettings.Copies
                spage = PrintDocument1.PrinterSettings.FromPage
                epage = PrintDocument1.PrinterSettings.ToPage
                PrinterNam = PrintDocument1.PrinterSettings.PrinterName
            End If

            rpverfacturas.PrintOptions.PrinterName = PrinterNam



            rpverfacturas.PrintToPrinter(ncopy, False, spage, epage)
            'MessageBox.Show("Report finished printing!")
            frmtest.CrystalReportViewer1.ReportSource = rpverfacturas

            If codGuiaFactura <> "" Then
                cboNumComprobantes.DataSource = clManGuia.llenaCboCodsFactura
            End If

            'frmtest.Show()

            limpiaTexboxFactura()

        Else
            MetroMessageBox.Show(Me, "Por favor ingresar detalles")
        End If
    End Sub

    Public Sub limpiaTexboxFactura()
        txtRucFactura.Text = ""
        txtRazonFactura.Text = ""
        txtDirecFactura.Text = ""
        txtGuiaFactura.Text = ""
        txtOrdenCompraFactura.Text = ""
        txtSubTotalF.Text = ""
        txtIGVF.Text = ""
        txtTotalF.Text = ""
        mtGridDetallesFactura.Rows.Clear()
        n = 0
        preciorow = 0
        totalfactura = 0
        igvfactura = 0
        subtotalfactura = 0
        totalletras = ""
        totales.Clear()
        Console.WriteLine(totales.Count)
    End Sub

    'INSERT INTO `publicidadimpresa`.`detallefacturas` 
    '(`nomproducto`, `cantidad`, `preciounitario`, `preciototal`, `facturas_idfactura`)
    ' VALUES ('diuhuh ', '2', '1.5', '3', '1');
    Public Sub insertarDetalles(ByVal nompreProducto As String, ByVal cantidad As Int16, ByVal punitario As Double, ByVal ptotal As Double, ByVal idfactura As Int16)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`detallefacturas` (`nomproducto`, `cantidad`, `preciounitario`, `preciototal`, `facturas_idfactura`) VALUES (@nompreProducto, @cantidad, @punitario, @ptotal, @idfactura);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@nompreProducto", nompreProducto)
        cmds.Parameters.AddWithValue("@cantidad", cantidad)
        cmds.Parameters.AddWithValue("@punitario", punitario)
        cmds.Parameters.AddWithValue("@ptotal", ptotal)
        cmds.Parameters.AddWithValue("@idfactura", idfactura)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertCliente(ByVal ruc As String, ByVal cliente As String, ByVal direccion As String)

        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`clientes` (`RUCcliente`, `razonsocial`, `direcioncliente`) VALUES (@RucCliente, @NomCliente, @DirecCliente);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@RucCliente", ruc)
        cmds.Parameters.AddWithValue("@NomCliente", cliente)
        cmds.Parameters.AddWithValue("@DirecCliente", direccion)

        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
    End Sub

    Public Sub insertFactura(ByVal fecha As String, ByVal idCliente As String, ByVal idusu As String, ByVal numFact As Int32, ByVal subTotal As Double, ByVal igvTotal As Double, ByVal total As Double, ByVal totalletra As String, ByVal idserie As Int16, ByVal habilitadoGuia As Integer, ByVal codGuia As String, ByVal codOCompra As String)
        frmAdd.checkCone()
        'INSERT INTO `publicidadimpresa`.`facturas` (`fech_factura`, `clientes_idcliente`, `usuarios_idusuarios`, `numeroFactura`) VALUES ('2016-01-01', '22', '2', '45');
        qr = "INSERT INTO `publicidadimpresa`.`facturas` (`fech_factura`, `clientes_idcliente`, `usuarios_idusuarios`, `numeroFactura`, `subTotalFactura`, `igvFactura`, `totalFactura`, `totalFacturaLetra`, `series_idseries`, `habilitadoGuia`, `codGuia`, `codOrdencompra`) VALUES (@date, @idcli, @idusu, @numeroFactura, @subTotal, @igvTotal, @total, @totalFacturaLetra, @idserie, @habilitadoGuia, @codGuia, @codOCompra);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@date", fecha)
        cmds.Parameters.AddWithValue("@idcli", idCliente)
        cmds.Parameters.AddWithValue("@idusu", idusu)
        cmds.Parameters.AddWithValue("@numeroFactura", numFact)
        cmds.Parameters.AddWithValue("@subTotal", subTotal)
        cmds.Parameters.AddWithValue("@igvTotal", igvTotal)
        cmds.Parameters.AddWithValue("@total", total)
        cmds.Parameters.AddWithValue("@totalFacturaLetra", totalletra)
        cmds.Parameters.AddWithValue("@idserie", idserie)
        cmds.Parameters.AddWithValue("@habilitadoGuia", habilitadoGuia)
        cmds.Parameters.AddWithValue("@codGuia", codGuia)
        cmds.Parameters.AddWithValue("@codOCompra", codOCompra)
        cmds.ExecuteNonQuery()
        cone.MysqlConexion.Close()
        'cmdNuevoCliente = New MySqlCommand(qrNuevoCliente, con.MysqlConexion)
        'cmdNuevoCliente.Parameters.AddWithValue("@RucCliente", rucCliente)

    End Sub

    Private Sub MetroLabel15_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub



    Private Sub mtGridDetallesFactura_GotFocus(ByVal sender As Object, ByVal e As EventArgs)


    End Sub

    Private Sub MetroTextBox4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txtGuiaFactura.Click

    End Sub

    Public Sub loadRucs()
        Console.WriteLine("Hola ruc")
        frmAdd.checkCone()
        qr = "SELECT Ruccliente FROM publicidadimpresa.clientes where habilitadoCliente=1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        Dim contado As Int16 = 0

        While rdrs.Read
            contado = contado + 1
            Me.txtRucFactura.AutoCompleteCustomSource.Add(rdrs.Item("RUCcliente"))
        End While
        Console.WriteLine(contado)
    End Sub

    Public Sub catchDats(ByVal ruc As String)
        frmAdd.checkCone()
        qr = "SELECT razonsocial,direcioncliente FROM publicidadimpresa.clientes where RUCcliente='" & ruc & "' and habilitadoCliente='1' limit 1;"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        rdrs = cmds.ExecuteReader
        Dim contado As Int16 = 0
        While rdrs.Read
            contado = contado + 1
            txtDirecFactura.Text = rdrs.Item("direcioncliente")
            txtRazonFactura.Text = rdrs.Item("razonsocial")
        End While

    End Sub

    Private Sub txtRucFactura_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txtRucFactura.Click

    End Sub

    Private Sub MetroTile3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mtTileFind.Click
        Dim ruckcatch As String = ""

        If txtRucFactura.Text <> "" Then
            ruckcatch = txtRucFactura.Text
            catchDats(ruckcatch)
        Else
            ErrorRucFactura.SetError(Me.txtRucFactura, "Error en el RUC ingresado")
            Exit Sub
        End If

    End Sub

    Private Sub mtTileFind_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mtTileFind.MouseDown
        mtTileFind.Style = MetroColorStyle.Black
    End Sub

    Private Sub mtTileFind_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mtTileFind.MouseUp
        mtTileFind.Style = MetroColorStyle.Blue
    End Sub

    Private Sub mtTileFind_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles mtTileFind.MouseLeave
        mtTileFind.Style = MetroColorStyle.Blue
    End Sub

    Private Sub mtTileFind_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mtTileFind.MouseMove
        mtTileFind.Style = MetroColorStyle.Silver
    End Sub

    Private Sub mtGridClientes_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As Object, ByVal e As MaskInputRejectedEventArgs)

    End Sub

    'Private Sub MetroTile3_Click_1(sender As Object, e As EventArgs)
    '    If mskNumeracion.Enabled = False Then
    '        mskNumeracion.Enabled = True
    '    Else
    '        mskNumeracion.Enabled = False
    '    End If
    'End Sub



    Private Sub txtRuc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txtRuc.Click

    End Sub

    Private Sub MetroTile3_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles MetroTile3.Click
        frmAddDetalle.Show()
    End Sub

    Private Sub lnkIGV_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lnkIGV.LinkClicked

        'InputBox("Ingresar cantidad IGV")
        Dim nuevoIGV As Object
        Dim checknumero As Boolean = False
        nuevoIGV = InputBox("Ingresar cantidad IGV")
        Console.WriteLine("Hola IGV" & nuevoIGV)

        If nuevoIGV = "" Then
            Console.WriteLine("Se cancelo")
            Exit Sub
        Else
            Console.WriteLine("Entró")
            While checknumero = IsNumeric(nuevoIGV)
                nuevoIGV = InputBox("Ingresar cantidad IGV (Solo se acepta números)")
                If nuevoIGV = "" Then
                    Exit Sub
                End If
            End While
        End If

        If verIGV() = 0 Then
            ingresarIGV(nuevoIGV)
        Else
            actualizarIGV(nuevoIGV, verIGV())
        End If

        'lnkIGV.Text = "% " & nuevoIGV

        lnkIGV.Text = "% " & verIGV()

        'Console.WriteLine(InputBox("Hola").ToString)
    End Sub
    Dim n As Integer = 0
    Dim preciorow As Double
    Dim totalfactura As Double
    Dim igvfactura As Double
    Dim subtotalfactura As Double
    Dim totalletras As String
    Private Sub mtGridDetallesFactura_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles mtGridDetallesFactura.RowsAdded
        Console.WriteLine(mtGridDetallesFactura.RowCount)

        If mtGridDetallesFactura.RowCount - 1 > 0 Then
            n = mtGridDetallesFactura.Rows.Count - 1
        Else
            n = 0
        End If
        'Console.WriteLine(mtGridDetallesFactura.Rows(0).Cells(3).Value)
        preciorow = mtGridDetallesFactura.Rows(n).Cells(3).Value
        totales.Add(preciorow)
        'Console.WriteLine("Add")
        'Console.WriteLine(totales(n))
        subtotalfactura = totales.Cast(Of Double).Sum()
        igvfactura = subtotalfactura * verIGV() / 100
        totalfactura = subtotalfactura + igvfactura

        txtSubTotalF.Text = subtotalfactura
        txtIGVF.Text = igvfactura
        txtTotalF.Text = totalfactura


        Console.WriteLine(totales.Cast(Of Double).Sum())
        Console.WriteLine(subtotalfactura)
        Console.WriteLine(igvfactura)
        Console.WriteLine(totalfactura)

        'Dim leta As Numalet
        'leta = New Numalet()

        leta.MascaraSalidaDecimal = tipomoneda
        'leta.SeparadorDecimalSalida = "con soles"

        leta.ApocoparUnoParteDecimal = True
        totalletras = leta.ToCustomCardinal(totalfactura)
        totalletras = UCase(Mid(totalletras, 1, 1)) + Mid(totalletras, 2, Len(totalletras))

        Console.WriteLine(leta.ToCustomCardinal(totalfactura))
        'Console.WriteLine(Numalet.ToCardinal(totalfactura))

        'n = n + 1


    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        'Console.WriteLine(cboMoneda.Text)
        Select Case cboMoneda.SelectedIndex
            Case 0

                tipomoneda = "00/100 dolares"
                simbolomoneda = "$"

                'leta.MascaraSalidaDecimal = tipomoneda
                'mtGridDetallesFactura.Columns("Total").DefaultCellStyle.Format = "c"
                'costuni = costuni.ToString("C", New CultureInfo(variables.tipomoneda))
            Case 1
                simbolomoneda = "S/."
                tipomoneda = "00/100 nuevos soles"
        End Select

    End Sub

    Private Sub MetroTile4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MetroTile4.Click
        If mskNumeracion.Enabled = False Then
            mskNumeracion.Enabled = True
        Else
            mskNumeracion.Enabled = False
            actualizarcodigo(mskNumeracion.Text)
        End If
    End Sub

    Dim numerocombo As Int32
    Private Sub MetroComboBox1_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cboSerie.SelectedIndexChanged
        Console.WriteLine(cboSerie.Items.Count)
        numerocombo = cboSerie.Items.Count
        Select Case cboSerie.SelectedIndex
            Case numerocombo - 2
                Dim nuevaserie As Int32 = 0
                Dim seristring As String
                seristring = InputBox("Inigresar número de serie (Sin ceros)")
                If seristring = "" Then
                    MessageBox.Show("no se ingreso nada")
                    Exit Sub
                Else
                    Console.WriteLine(seristring)
                    nuevaserie = seristring
                    If checkIdSerie(nuevaserie) > 0 Then
                        Console.WriteLine("Ya existe serie")
                        If checkHabilitado(nuevaserie) = 0 Then
                            Dim resp As String = MessageBox.Show("Esta serie se encuentra en uso, ¿Desea volver a usarla?", "Serie deshablitada", MessageBoxButtons.YesNo)
                            If resp = DialogResult.No Then
                                Exit Sub
                            ElseIf resp = DialogResult.Yes Then
                                activaerserie(nuevaserie)
                                cboSerie.Items.Clear()
                                llenaCboSeries()
                            End If
                        ElseIf checkHabilitado(nuevaserie = 1) Then
                            Console.WriteLine("habilitado")
                            MessageBox.Show("Esta serie se encuentra en uso")
                        End If

                    Else
                        addSerie(nuevaserie)
                    End If

                End If
                cboSerie.Items.Clear()
                llenaCboSeries()
            Case numerocombo - 1
                Dim serieEliminar As Int32 = 0
                Dim seristring As String
                seristring = InputBox("Inigresar número de serie a eliminar (Sin ceros)")
                If seristring = "" Then
                    MessageBox.Show("no se ingreso nada")
                    Exit Sub
                Else
                    'Console.WriteLine(seristring)
                    serieEliminar = seristring

                    If checkIdSerie(serieEliminar) = 0 Then
                        MessageBox.Show("Serie no encontrada")
                        Exit Sub
                    End If

                    eliminarseries(serieEliminar)
                End If
                cboSerie.Items.Clear()
                llenaCboSeries()

        End Select
    End Sub

    Public Sub addSerie(ByVal ids As Int32)
        frmAdd.checkCone()
        qr = "INSERT INTO `publicidadimpresa`.`series` (`idserie`) VALUES (@id);"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.Parameters.AddWithValue("@id", ids)
        cmds.ExecuteNonQuery()
    End Sub


    Public Sub eliminarseries(ByVal idsE As Int32)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`series` SET `habilitado`='0' WHERE `idserie`='" & idsE & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
    End Sub

    Public Sub activaerserie(ByVal idsE As Int32)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`series` SET `habilitado`='1' WHERE `idserie`='" & idsE & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
    End Sub

    Private Sub mtFechaFacturar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mtFechaFacturar.ValueChanged

    End Sub
    'Selecciona Pestaña
    Private Sub MetroTabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MetroTabControl1.SelectedIndexChanged


        Select Case Me.MetroTabControl1.SelectedIndex
            Case 0
                loadTabla()
            Case 1
                loadRucs()
                llenaFacturas()
                llenaCboSeriesFiltro()
            Case 2
                Console.WriteLine("You typed 3")
        End Select

    End Sub

    Private Sub mtGridDetallesFactura_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub mtTxtFind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mtTxtFind.Click

    End Sub

    Private Sub mtGridClientes_CellContentClick_1(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mtGridClientes.CellContentClick

    End Sub


    Dim precioreodena As Double
    Dim leta As Numalet = New Numalet()
    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EliminarToolStripMenuItem.Click
        'currentRuc = txtRucEmpresa.Text
        'currentidEmpresa = checkExists(txtRucEmpresa.Text)
        'currentSelectNumContact = mtGrudTlfs.Rows(mtGrudTlfs.CurrentCell.RowIndex).Cells(1).Value
        ''cone.MysqlConexion.Open()
        'frmAdd.checkCone()
        'qr = "DELETE FROM `publicidadimpresa`.`telefonoscliente` WHERE `numTelf`='" & currentSelectNumContact & "' and `clientes_idcliente`='" & currentidEmpresa & "';"
        'cmds = New MySqlCommand(qr, cone.MysqlConexion)
        'cmds.ExecuteNonQuery()
        'loadTablaTlfs(currentRuc)
        'menuCheck()

        Dim currentItem As Integer
        currentItem = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentRow.Index).Index

        Console.WriteLine(currentItem)
        mtGridDetallesFactura.Rows.Remove(mtGridDetallesFactura.Rows(currentItem))
        mtGridDetallesFactura.Refresh()
        totales.Clear()

        Console.WriteLine(mtGridDetallesFactura.Rows.Count)

        For i As Int32 = 0 To mtGridDetallesFactura.Rows.Count - 1
            'preciorow = mtGridDetallesFactura.Rows(n).Cells(3).Value
            precioreodena = mtGridDetallesFactura.Rows(i).Cells(3).Value
            totales.Add(precioreodena)
        Next

        subtotalfactura = totales.Cast(Of Double).Sum()
        igvfactura = subtotalfactura * verIGV() / 100
        totalfactura = subtotalfactura + igvfactura

        txtSubTotalF.Text = subtotalfactura
        txtIGVF.Text = igvfactura
        txtTotalF.Text = totalfactura

        Console.WriteLine("JyN")
        Console.WriteLine(totales.Cast(Of Double).Sum())
        Console.WriteLine(subtotalfactura)
        Console.WriteLine(igvfactura)
        Console.WriteLine(totalfactura)



        leta.MascaraSalidaDecimal = tipomoneda
        'leta.SeparadorDecimalSalida = "con soles"

        leta.ApocoparUnoParteDecimal = True
        totalletras = leta.ToCustomCardinal(totalfactura)
        totalletras = UCase(Mid(totalletras, 1, 1)) + Mid(totalletras, 2, Len(totalletras))

        Console.WriteLine(leta.ToCustomCardinal(totalfactura))

    End Sub

    Private Sub MenuEliminarEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuEliminarEmail.Click

    End Sub

    Private Sub mtGridDetallesFactura_RowsRemoved(ByVal sender As Object, ByVal e As DataGridViewRowsRemovedEventArgs) Handles mtGridDetallesFactura.RowsRemoved
        n = mtGridDetallesFactura.RowCount - 1
        'Remover
        'mtGridDetallesFactura.Refresh()

        'subtotalfactura = totales.Cast(Of Double).Sum()
        'igvfactura = subtotalfactura * verIGV() / 100
        'totalfactura = subtotalfactura + igvfactura

        'txtSubTotalF.Text = subtotalfactura
        'txtIGVF.Text = igvfactura
        'txtTotalF.Text = totalfactura

        'Console.WriteLine("JyN")
        'Console.WriteLine(totales.Cast(Of Double).Sum())
        'Console.WriteLine(subtotalfactura)
        'Console.WriteLine(igvfactura)
        'Console.WriteLine(totalfactura)

        'Dim leta As Numalet
        'leta = New Numalet()

        'leta.MascaraSalidaDecimal = tipomoneda
        ''leta.SeparadorDecimalSalida = "con soles"

        'leta.ApocoparUnoParteDecimal = True
        'totalletras = leta.ToCustomCardinal(totalfactura)
        'totalletras = UCase(Mid(totalletras, 1, 1)) + Mid(totalletras, 2, Len(totalletras))

        'Console.WriteLine(leta.ToCustomCardinal(totalfactura))


    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ActualizarToolStripMenuItem.Click

        filaR = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentRow.Index).Index

        cantidadDetalle = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentCell.RowIndex).Cells(0).Value
        detDetalle = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentCell.RowIndex).Cells(1).Value
        pUnitdetalle = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentCell.RowIndex).Cells(2).Value
        viejoCostoTotalFila = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentCell.RowIndex).Cells(3).Value
        viejoCostoTotal = txtSubTotalF.Text
        frmUpdateDetails.Show()
        'variables.currentRuc = txtRucEmpresa.Text
        'variables.currentidEmpresa = checkExists(txtRucEmpresa.Text)
        'variables.currentNomEmpresa = txtNomEmpresa.Text
        'variables.currentSelectContact = mtGridEmails.Rows(mtGridEmails.CurrentCell.RowIndex).Cells(0).Value
        'variables.currentSelectEmailContact = mtGridEmails.Rows(mtGridEmails.CurrentCell.RowIndex).Cells(1).Value
    End Sub

    Private Sub mtGridDetallesFactura_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mtGridDetallesFactura.TextChanged
        Console.WriteLine("Modi")
    End Sub

    Private Sub MetroRadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MetroRadioButton1.CheckedChanged
        Console.WriteLine(dateInicio.Value.Date)
        roundselect = 1
        VolverAprobarToolStripMenuItem.Visible = False
        AnularToolStripMenuItem.Visible = True
        llenaFacturas()
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MetroRadioButton2.CheckedChanged
        roundselect = 2
        AnularToolStripMenuItem.Visible = False
        VolverAprobarToolStripMenuItem.Visible = True
        llenaFacturasAnulada()
    End Sub

    Private Sub MetroRadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MetroRadioButton3.CheckedChanged
        roundselect = 3
        llenaFacturasTodo()
    End Sub

    Private Sub mtTxtVerFactura_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mtTxtVerFactura.TextChanged
        Dim key
        If mtTxtVerFactura.Text = "" Then
            key = ""
            llenaFacturas()
        Else
            key = mtTxtVerFactura.Text

            'loadTablaFacturasFind(key)

            Select Case roundselect
                Case 1
                    loadTablaFacturasFind(key)
                Case 2
                    loadTablaFacturasFindAnulado(key)
                Case 3
                    loadTablaFacturasFindTodos(key)
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub mtTxtVerFactura_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mtTxtVerFactura.Click

    End Sub

    Private Sub AnularToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AnularToolStripMenuItem.Click
        Dim selecFac As Int32
        selecFac = gridFacturas.Rows(gridFacturas.CurrentRow.Index).Cells(4).Value
        anularfactura(selecFac)
        llenaFacturas()
    End Sub

    Public Sub anularfactura(ByVal codfactura As String)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`facturas` SET `habilitado`='0' WHERE `numeroFactura`='" & codfactura & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
    End Sub

    Private Sub VolverAprobarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VolverAprobarToolStripMenuItem.Click
        Dim selecFac As Int32
        selecFac = gridFacturas.Rows(gridFacturas.CurrentRow.Index).Cells(4).Value
        VolverAprobarfactura(selecFac)
        llenaFacturas()
        MetroRadioButton1.Checked = True
    End Sub

    Public Sub VolverAprobarfactura(ByVal codfactura As String)
        frmAdd.checkCone()
        qr = "UPDATE `publicidadimpresa`.`facturas` SET `habilitado`='1' WHERE `numeroFactura`='" & codfactura & "';"
        cmds = New MySqlCommand(qr, cone.MysqlConexion)
        cmds.ExecuteNonQuery()
    End Sub

    Dim diaFiltrofin As Int32
    Dim mesFiltrofin As Int32
    Dim anioFiltrofin As Int32
    Private Sub MetroDateTime2_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dateFin.ValueChanged
        diaFiltrofin = dateFin.Value.Day
        mesFiltrofin = dateFin.Value.Month
        anioFiltrofin = dateFin.Value.Year
        fechafin = (anioFiltrofin & "-" & mesFiltrofin & "-" & diaFiltrofin)
        filtrofechainicio(fechainicio, fechafin)
    End Sub

    Dim diaFiltroini As Int32
    Dim mesFiltroini As Int32
    Dim anioFiltroini As Int32

    Private Sub dateInicio_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dateInicio.ValueChanged
        diaFiltroini = dateInicio.Value.Day
        mesFiltroini = dateInicio.Value.Month
        anioFiltroini = dateInicio.Value.Year
        fechainicio = (anioFiltroini & "-" & mesFiltroini & "-" & diaFiltroini)

        filtrofechainicio(fechainicio, fechafin)

    End Sub

    Public Sub filtrofechainicio(ByVal fechainicio As String, ByVal fechafin As String)
        frmAdd.checkCone()

        Select Case roundselect
            Case 1
                qr = "SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas where fech_factura between '" & fechainicio & "' and '" & fechafin & "' and habilitado=1;"
            Case 2
                qr = "SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas where fech_factura between '" & fechainicio & "' and '" & fechafin & "' and habilitado=0;"
            Case 3
                qr = "SELECT RUCcliente as 'RUC',razonsocial AS 'RAZON SOCIAL' , totalFactura AS 'TOTAL FACTURA', fech_factura AS 'FECHA', numeroFactura AS 'N FACTURA', SERIE FROM publicidadimpresa.view_facturas where fech_factura between '" & fechainicio & "' and '" & fechafin & "';"
            Case Else
                Exit Sub
        End Select
        tabla = New DataTable
        adp = New MySqlDataAdapter(qr, cone.MysqlConexion)
        adp.Fill(tabla)
        Me.gridFacturas.DataSource = tabla
        Me.gridFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub cboSerieFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboSerieFiltro.SelectedIndexChanged
        llenaFacturasSerie(cboSerieFiltro.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmtest.Show()
    End Sub

    Private Sub MetroTextBox4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartidaZona.Click

    End Sub

    Private Sub MetroLabel30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLabel30.Click

    End Sub

    Private Sub MetroTextBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartidaInterior.Click

    End Sub

    Private Sub MetroLabel29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLabel29.Click

    End Sub

    Private Sub MetroTextBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartidaNumero.Click

    End Sub

    Private Sub MetroLabel28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLabel28.Click

    End Sub

    Private Sub MetroPanel16_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MetroPanel16.Paint

    End Sub

    Private Sub MetroPanel28_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub MetroLabel53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroLabel53.Click

    End Sub

    Private Sub MetroPanel35_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MetroPanel35.Paint

    End Sub

    Private Sub cboPatidaDep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatidaDep.SelectedIndexChanged
        cboPartidaProv.DataSource = provincias(cboPatidaDep.Text)
        ErrorDepaPartida.SetError(Me.cboPatidaDep, "")
    End Sub

    Private Sub cboPartidaProv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartidaProv.SelectedIndexChanged
        cboPartidaDist.DataSource = distritos(cboPartidaProv.Text)
    End Sub

    Private Sub cboLlegadaDep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLlegadaDep.SelectedIndexChanged
        cboLlegadaProv.DataSource = provincias(cboLlegadaDep.Text)
        ErrorDepaLlegada.SetError(Me.cboLlegadaDep, "")
    End Sub

    Private Sub cboLlegadaProv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLlegadaProv.SelectedIndexChanged
        cboLlegadaDist.DataSource = distritos(cboLlegadaProv.Text)
    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub MetroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAddGuia.Show()
    End Sub



    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Dim direcPartida As String = ""
    Dim NumPartida As Integer
    Dim InteriorPartida As String = ""
    Dim ZonaPartida As String = ""
    Dim DistritoPartida As String = ""
    Dim ProvinciaPartida As String = ""
    Dim DepartamentoPartida As String = ""

    Dim direcLlegada As String = ""
    Dim NumLlegada As Integer
    Dim InteriorLlegada As String = ""
    Dim ZonaLlegada As String = ""
    Dim DistritoLlegada As String = ""
    Dim ProvinciaLlegada As String = ""
    Dim DepartamentoLlegada As String = ""

    Dim RazonDestinatario As String = ""
    Dim RUCDestinatario As String = ""

    Dim Marcavehiculo As String = ""
    Dim PlacaVehiculo As String = ""
    Dim certificadoInscripvehiculo As String = ""
    Dim LicCondicirvehiculo As String = ""

    Dim nombreTransportista As String = ""
    Dim rucTransportista As String = ""

    Dim tipoComprobante As String = ""
    Dim numComprobante As Integer

    Dim motivoTraslado As String = ""

    Dim fechEmision As Date
    Dim fechInicioTraslado As Date

    Dim numeroFilasGuia As Integer

    Dim clManGuia As New clManageGuia

    Private Sub mtCrearGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtCrearGuia.Click

        If txtPartidaDirec.Text <> "" Then
            direcPartida = txtPartidaDirec.Text
            ErrorDirecPartida.SetError(Me.txtPartidaDirec, "")
        Else
            ErrorDirecPartida.SetError(Me.txtPartidaDirec, "La dirección de partida no puede estar vacía")
            Exit Sub
        End If

        If txtPartidaNumero.Text <> "" Then
            NumPartida = txtPartidaNumero.Text
        End If

        If txtPartidaInterior.Text <> "" Then
            InteriorPartida = txtPartidaInterior.Text
        End If

        If txtPartidaZona.Text <> "" Then
            ZonaPartida = txtPartidaZona.Text
        End If

        If cboPatidaDep.Text <> "Seleccionar" Then
            DepartamentoPartida = cboPatidaDep.Text
            ErrorDepaPartida.SetError(Me.cboPatidaDep, "")
        Else
            ErrorDepaPartida.SetError(Me.cboPatidaDep, "Especifíque el departamento")
            Exit Sub
        End If

        If cboPartidaProv.Text <> "" Then
            ProvinciaPartida = cboPartidaProv.Text
        End If

        If cboPartidaDist.Text <> "" Then
            DistritoPartida = cboPartidaDist.Text
        End If

        'Llegada 

        If txtLlegadaDirec.Text <> "" Then
            direcLlegada = txtLlegadaDirec.Text
            ErrorDirecLlegada.SetError(Me.txtLlegadaDirec, "")
        Else
            ErrorDirecLlegada.SetError(Me.txtLlegadaDirec, "La dirección de partida no puede estar vacía")
            Exit Sub
        End If

        If txtLlegadaNum.Text <> "" Then
            NumLlegada = txtLlegadaNum.Text
        End If

        If txtLlegadaInterior.Text <> "" Then
            InteriorLlegada = txtLlegadaInterior.Text
        End If

        If txtLlegadaZona.Text <> "" Then
            ZonaLlegada = txtLlegadaZona.Text
        End If

        If cboLlegadaDep.Text <> "Seleccionar" Then
            DepartamentoLlegada = cboLlegadaDep.Text
            ErrorDepaLlegada.SetError(Me.cboLlegadaDep, "")
        Else
            ErrorDepaLlegada.SetError(Me.cboLlegadaDep, "Especifíque el departamento")
            Exit Sub
        End If

        If cboLlegadaProv.Text <> "" Then
            ProvinciaLlegada = cboLlegadaProv.Text
        End If

        If cboLlegadaDist.Text <> "" Then
            DistritoLlegada = cboLlegadaDist.Text
        End If

        'Destinatario

        If txtDestinatarioRazo.Text <> "" Then
            RazonDestinatario = txtDestinatarioRazo.Text
            ErrorDestinatario.SetError(Me.txtDestinatarioRazo, "")
        Else
            ErrorDestinatario.SetError(Me.txtDestinatarioRazo, "Se requiere razón social de destinatario")
            Exit Sub
        End If

        If txtDestinatarioRUC.Text <> "" Then
            RUCDestinatario = txtDestinatarioRUC.Text
            ErrorDestinatario.SetError(Me.txtDestinatarioRUC, "")
        Else
            ErrorDestinatario.SetError(Me.txtDestinatarioRUC, "Se rquiere RUC")
            Exit Sub
        End If

        Dim idUtransporte As String = "1"
        Dim idTransportista As String = "1"

        If txtVehiculomarca.Text <> "" Then
            Marcavehiculo = txtVehiculomarca.Text
            Console.WriteLine("Entro a vehiculo")
            If txtVehiculoPlaca.Text <> "" Then
                PlacaVehiculo = txtVehiculoPlaca.Text
            Else
                ErrorPlaca.SetError(Me.txtVehiculoPlaca, "Se requiere la placa del vehículo")
                Exit Sub
            End If

            If txtCertificado.Text <> "" Then
                certificadoInscripvehiculo = txtCertificado.Text
            Else
                ErrorCerti.SetError(Me.txtCertificado, "Se requiere el certificado del vehículo")
                Exit Sub
            End If

            If txtVehiculoLic.Text <> "" Then
                LicCondicirvehiculo = txtVehiculoPlaca.Text
            Else
                ErrorLic.SetError(Me.txtVehiculoLic, "Se requiere la licencia")
                Exit Sub
            End If

            If LicCondicirvehiculo <> "" Then
                clManGuia.insertVehiculo(Marcavehiculo, PlacaVehiculo, certificadoInscripvehiculo, LicCondicirvehiculo, codigogenerado)
                idUtransporte = clManGuia.checkidVehiculo(codigogenerado)
            Else
                idUtransporte = "1"
            End If

            

        End If

        'If txtVehiculomarca.Text = "" Or txtCertificado.Text = "" Or txtVehiculoLic.Text = "" Or txtVehiculoPlaca.Text = "" Then
        '    MetroMessageBox.Show(Me, "Se necesita la placa del vehículo, la licencia y el certificado de inscripción", "Error en los campos de Vehículo")

        'Else

        'End If



        If txtTransportistaRUC.Text <> "" Then
            rucTransportista = txtTransportistaRUC.Text

            If txtTransportistaNombre.Text <> "" Then
                nombreTransportista = txtTransportistaNombre.Text
                clManGuia.insertTransportista(nombreTransportista, rucTransportista)
                idTransportista = clManGuia.checkidTransportista(rucTransportista)
            Else
                ErrorNombreTranspor.SetError(Me.txtTransportistaNombre, "Se requiere el nombre del transportista")
                Exit Sub
            End If
        End If

        'If txtTransportistaRUC.Text <> "" Then

        'Else
        '    MetroMessageBox.Show(Me, "Se necesita los datos del conductor", "Error en los campos de conductor")
        'End If

        'If cbocomprobantepago.Text <> "Seleccionar" Then
        '    tipoComprobante = cbocomprobantepago.Text
        '    ErrorCboComprobante.SetError(Me.cbocomprobantepago, "")
        'Else
        '    ErrorCboComprobante.SetError(Me.cbocomprobantepago, "Seleccione el comprobante")
        '    Exit Sub
        'End If

        If txtComprobanteNumero.Text <> "" Then
            numComprobante = txtComprobanteNumero.Text
            ErrorNumComprobante.SetError(Me.txtComprobanteNumero, "")
        Else
            ErrorNumComprobante.SetError(Me.txtComprobanteNumero, "Se requiere ún numero de comprobante")
            Exit Sub
        End If

        If cboRazontraslado.Text <> "Seleccionar" Then
            motivoTraslado = cboRazontraslado.Text
            ErrorRazonTraslado.SetError(Me.cboRazontraslado, "")
        Else
            ErrorRazonTraslado.SetError(Me.cboRazontraslado, "Seleccione la razón del traslado")
            Exit Sub
        End If

        numeroFilasGuia = mtGridDetalleGuia.RowCount

        If numeroFilasGuia <= 0 Then
            MetroMessageBox.Show(Me, "La guia debe de contener por lo menos un detalle", "Hola")
            Exit Sub
        End If

        Dim datehoy As Date = Date.Now

        codigogenerado = clManGuia.GeneraCod(datehoy)


        clManGuia.insertPartida(direcPartida, NumPartida, InteriorPartida, ZonaPartida, DepartamentoPartida, ProvinciaPartida, DistritoPartida, codigogenerado)

        clManGuia.insertLlegada(direcLlegada, NumLlegada, InteriorLlegada, ZonaLlegada, DepartamentoLlegada, ProvinciaLlegada, DistritoLlegada, codigogenerado)

        'clManGuia.insertComprobante(clManGuia.verIdComprobante(cbocomprobantepago.Text), numComprobante)

        ''Ver Id motivo traslado
        Dim idrazontraslado As Integer
        idrazontraslado = clManGuia.verIdRazontraslado(cboRazontraslado.Text)

        Dim dateemi As Date
        Dim dateTralado As Date

        dateemi = dateEmision.Value.Date
        dateTralado = dateIniTraslado.Value.Date

        Dim idFacturaGuia As Integer
        idFacturaGuia = clManGuia.verIdFactura(numComprobante)


        Dim idpartida As String
        idpartida = clManGuia.checkidPartida(codigogenerado)

        Dim idllegada As String
        idllegada = clManGuia.checkidLlegada(codigogenerado)



        Dim idcliente As String
        idcliente = checkExists(RUCDestinatario)


        clManGuia.insertGuia(dateemi, dateTralado, codGuia, idpartida, idllegada, idUtransporte, idTransportista, idrazontraslado, IdUsuario, idcliente, idFacturaGuia)

        Dim insdetalleCant As Double
        Dim insdetalleDescp As String
        Dim insdetalleTotal As Double
        Dim insdetalleidguia As Integer
        insdetalleidguia = clManGuia.veridDeGuia(codGuia)
        For i As Int32 = 0 To numeroFilasGuia - 1
            insdetalleCant = mtGridDetalleGuia.Rows(i).Cells(0).Value
            insdetalleDescp = mtGridDetalleGuia.Rows(i).Cells(1).Value
            insdetalleTotal = mtGridDetalleGuia.Rows(i).Cells(2).Value
            'insdetalleidguia = mtGridDetalleGuia.Rows(i).Cells(3).Value
            clManGuia.insertDetGuia(insdetalleCant, insdetalleDescp, insdetalleTotal, insdetalleidguia)
        Next

        clManGuia.actEstadoFactGuia(idFacturaGuia)

        cboNumComprobantes.DataSource = clManGuia.llenaCboCodsFactura

        'llena guia

        Dim dsDetalleGuia As New dsDetalleGuia
        Dim dtDetalleGuia As New dsDetalleGuia.tDetalleguiaDataTable
        Dim rpGuia As New crGuia

        Dim filas As Integer = mtGridDetalleGuia.Rows.Count

        Dim ij As Integer = 0

        For ij = 0 To filas - 1
            dtDetalleGuia.Rows.Add(
                Me.mtGridDetalleGuia.Rows(ij).Cells(0).Value,
                Me.mtGridDetalleGuia.Rows(ij).Cells(1).Value,
                Me.mtGridDetalleGuia.Rows(ij).Cells(2).Value)
        Next (ij)

        dsDetalleGuia.Tables(0).Merge(dtDetalleGuia)
        rpGuia.SetDataSource(dsDetalleGuia)


        rpGuia.SetParameterValue("fEmision", dateemi)
        rpGuia.SetParameterValue("fTraslado", dateTralado)

        rpGuia.SetParameterValue("domiPartida", direcPartida)
        rpGuia.SetParameterValue("partidaNum", NumPartida)
        rpGuia.SetParameterValue("partidaInte", InteriorPartida)
        rpGuia.SetParameterValue("partidaZona", ZonaPartida)
        rpGuia.SetParameterValue("partidaDist", DistritoPartida)
        rpGuia.SetParameterValue("partidaProv", ProvinciaPartida)
        rpGuia.SetParameterValue("partidaDep", DepartamentoPartida)

        rpGuia.SetParameterValue("llegadaDomi", direcLlegada)
        rpGuia.SetParameterValue("llegadaNum", NumLlegada)
        rpGuia.SetParameterValue("llegadaInte", InteriorLlegada)
        rpGuia.SetParameterValue("llegadaZona", ZonaLlegada)
        rpGuia.SetParameterValue("llegadaDist", DistritoLlegada)
        rpGuia.SetParameterValue("llegadaProv", ProvinciaLlegada)
        rpGuia.SetParameterValue("llegadaDep", DepartamentoLlegada)

        rpGuia.SetParameterValue("destinatarioRazon", RazonDestinatario)
        rpGuia.SetParameterValue("destinatarioRUC", RUCDestinatario)

        rpGuia.SetParameterValue("uniMarca", Marcavehiculo)
        rpGuia.SetParameterValue("uniPlaca", PlacaVehiculo)
        rpGuia.SetParameterValue("uniCertificado", certificadoInscripvehiculo)
        rpGuia.SetParameterValue("uniLicencia", LicCondicirvehiculo)

        rpGuia.SetParameterValue("transportistaNombre", nombreTransportista)
        rpGuia.SetParameterValue("transportistaRUC", rucTransportista)

        rpGuia.SetParameterValue("comprobanteTipo", MetroLabel60.Text)
        rpGuia.SetParameterValue("comprobanteNum", numComprobante)

        Dim motivoTraslado1 As String = ""
        Dim motivoTraslado2 As String = ""
        Dim motivoTraslado3 As String = ""
        Dim motivoTraslado4 As String = ""
        Dim motivoTraslado5 As String = ""
        Dim motivoTraslado6 As String = ""
        Dim motivoTraslado7 As String = ""
        Dim motivoTraslado8 As String = ""
        Dim motivoTraslado9 As String = ""
        Dim motivoTraslado10 As String = ""
        Dim motivoTraslado11 As String = ""
        Dim motivoTraslado12 As String = ""
        Dim motivoTraslado13 As String = ""

        Select Case idrazontraslado
            Case 1
                motivoTraslado1 = "X"
            Case 2
                motivoTraslado2 = "X"
            Case 3
                motivoTraslado3 = "X"
            Case 4
                motivoTraslado4 = "X"
            Case 5
                motivoTraslado5 = "X"
            Case 6
                motivoTraslado6 = "X"
            Case 7
                motivoTraslado7 = "X"
            Case 8
                motivoTraslado8 = "X"
            Case 9
                motivoTraslado9 = "X"
            Case 10
                motivoTraslado10 = "X"
            Case 11
                motivoTraslado11 = "X"
            Case 12
                motivoTraslado12 = "X"
            Case 13
                motivoTraslado13 = otroRazon
        End Select

        rpGuia.SetParameterValue("motivo1", motivoTraslado1)
        rpGuia.SetParameterValue("motivo2", motivoTraslado2)
        rpGuia.SetParameterValue("motivo3", motivoTraslado3)
        rpGuia.SetParameterValue("motivo4", motivoTraslado4)
        rpGuia.SetParameterValue("motivo5", motivoTraslado5)
        rpGuia.SetParameterValue("motivo6", motivoTraslado6)
        rpGuia.SetParameterValue("motivo7", motivoTraslado7)
        rpGuia.SetParameterValue("motivo8", motivoTraslado8)
        rpGuia.SetParameterValue("motivo9", motivoTraslado9)
        rpGuia.SetParameterValue("motivo10", motivoTraslado10)
        rpGuia.SetParameterValue("motivo11", motivoTraslado11)
        rpGuia.SetParameterValue("motivo12", motivoTraslado12)
        rpGuia.SetParameterValue("motivo13", motivoTraslado13)

        Dim dr As New DialogResult
        PrintDialog1.Document = PrintDocument1
        dr = PrintDialog1.ShowDialog()

        Dim ncopy As Integer
        Dim spage As Integer
        Dim epage As Integer
        Dim PrinterNam As String
        If dr = DialogResult.OK Then
            ncopy = PrintDocument1.PrinterSettings.Copies
            spage = PrintDocument1.PrinterSettings.FromPage
            epage = PrintDocument1.PrinterSettings.ToPage
            PrinterNam = PrintDocument1.PrinterSettings.PrinterName
        End If

        rpGuia.PrintOptions.PrinterName = PrinterNam

        rpGuia.PrintToPrinter(ncopy, False, spage, epage)

        frmtest.CrystalReportViewer1.ReportSource = rpGuia
        'frmtest.CrystalReportViewer1
        frmtest.Show()

        limpiarGuia()

    End Sub

    Private Sub MetroButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        codFact = txtComprobanteNumero.Text

        'idFact = clManGuia.verIdFactura(codFact)

        frmAddGuia.Dispose()
        frmAddGuia.Show()
    End Sub

    Private Sub txtPartidaDirec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartidaDirec.TextChanged
        ErrorDirecPartida.SetError(Me.txtPartidaDirec, "")
    End Sub

    Private Sub txtLlegadaDirec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLlegadaDirec.TextChanged
        ErrorDirecLlegada.SetError(Me.txtLlegadaDirec, "")
    End Sub

    Private Sub txtDestinatarioRUC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ErrorDetinatarioRUC.SetError(Me.txtDestinatarioRUC, "")
    End Sub

    Private Sub txtDestinatarioRazo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestinatarioRazo.Click
        ErrorDestinatario.SetError(Me.txtDestinatarioRazo, "")
    End Sub

    'Private Sub cbocomprobantepago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocomprobantepago.SelectedIndexChanged
    '    ErrorCboComprobante.SetError(Me.cbocomprobantepago, "")
    '    If cbocomprobantepago.Text = "Factura" Then
    '        cboNumComprobantes.Visible = True
    '        txtComprobanteNumero.Visible = False
    '        cboNumComprobantes.DataSource = clManGuia.llenaCboCodsFactura
    '    Else
    '        cboNumComprobantes.Visible = False
    '        txtComprobanteNumero.Visible = True
    '    End If

    'End Sub

    Private Sub cboRazontraslado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRazontraslado.SelectedIndexChanged
        ErrorRazonTraslado.SetError(Me.cboRazontraslado, "")

        If cboRazontraslado.SelectedIndex = 13 Then
            If txtComprobanteNumero.Text <> "" Then
                txtComprobanteNumero.Text = cboNumComprobantes.Text

                Dim codGuiaOtro As String
                codGuiaOtro = clManGuia.verCodGuia(txtComprobanteNumero.Text)



                otroRazon = InputBox("Ingresar el motivo de traslado")
                Console.WriteLine("Hola IGV" & otroRazon)

                If otroRazon = "" Then
                    Console.WriteLine("Se cancelo")
                    Exit Sub
                Else
                    Console.WriteLine("Entró")
                    clManGuia.insertarotromotivo(otroRazon, codGuiaOtro)
                End If
            Else
                MetroMessageBox.Show(Me, "Codigo de guia no existe", "Codigo de guia no existe")
                Exit Sub
            End If
        End If
    End Sub

    'Private Sub txtDestinatarioRUC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDestinatarioRUC.Click
    '    txtDestinatarioRazo.Text = clManGuia.llenaCompletaDestinatario(txtDestinatarioRUC.Text)
    'End Sub

    Private Sub txtDestinatarioRUC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDestinatarioRUC.Enter
        txtDestinatarioRazo.Text = clManGuia.llenaCompletaDestinatario(txtDestinatarioRUC.Text)
    End Sub

    'Private Sub txtDestinatarioRUC_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDestinatarioRUC.MouseClick
    '    txtDestinatarioRazo.Text = clManGuia.llenaCompletaDestinatario(txtDestinatarioRUC.Text)
    'End Sub

    Private Sub txtDestinatarioRUC_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestinatarioRUC.TextChanged
        If txtDestinatarioRUC.TextLength >= 4 Then
            For Each r As String In clManGuia.llenaDestinatarios(txtDestinatarioRUC.Text)
                txtDestinatarioRUC.AutoCompleteCustomSource.Add(r)
            Next
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem1.Click
        Dim currentRowSlct As Integer
        'currentItem = mtGridDetallesFactura.Rows(mtGridDetallesFactura.CurrentRow.Index).Index
        currentRowSlct = mtGridDetalleGuia.Rows(mtGridDetalleGuia.CurrentRow.Index).Index
        mtGridDetalleGuia.Rows.Remove(mtGridDetalleGuia.Rows(currentRowSlct))
        Console.WriteLine(currentRowSlct)
    End Sub

    Private Sub ActualizarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarToolStripMenuItem1.Click
        currentActGuia = mtGridDetalleGuia.Rows(mtGridDetalleGuia.CurrentRow.Index).Index
        cantidadGuia = Me.mtGridDetalleGuia.Rows(currentActGuia).Cells(0).Value
        DescripGuia = Me.mtGridDetalleGuia.Rows(currentActGuia).Cells(1).Value
        totalGuia = Me.mtGridDetalleGuia.Rows(currentActGuia).Cells(2).Value
        frmActDetalle.Show()
    End Sub



    Dim codGuia As Integer
    Private Sub cboNumComprobantes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNumComprobantes.SelectedIndexChanged
        txtComprobanteNumero.Text = cboNumComprobantes.Text
        codGuia = clManGuia.verCodGuia(txtComprobanteNumero.Text)
        Console.WriteLine(codGuia.ToString)
    End Sub

    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        limpiaTexboxFactura()
    End Sub

    Private Sub mtGridDetallesFactura_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mtGridDetallesFactura.CellContentClick

    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile6.Click
        limpiarGuia()
    End Sub

    Public Sub limpiarGuia()
        txtPartidaDirec.Text = ""
        txtPartidaNumero.Text = ""
        txtPartidaInterior.Text = ""
        txtPartidaZona.Text = ""

        txtLlegadaDirec.Text = ""
        txtLlegadaNum.Text = ""
        txtLlegadaInterior.Text = ""
        txtLlegadaZona.Text = ""

        txtDestinatarioRUC.Text = ""
        txtDestinatarioRazo.Text = ""

        txtVehiculomarca.Text = ""
        txtVehiculoPlaca.Text = ""
        txtCertificado.Text = ""
        txtVehiculoLic.Text = ""

        txtTransportistaNombre.Text = ""
        txtTransportistaRUC.Text = ""
        txtComprobanteNumero.Text = ""

        mtGridDetalleGuia.Rows.Clear()
    End Sub

    Private Sub txtVehiculomarca_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVehiculomarca.TextChanged
        enablevehiculo()
        ErrorPlaca.SetError(Me.txtVehiculoPlaca, "")
        ErrorCerti.SetError(Me.txtCertificado, "")
        ErrorLic.SetError(Me.txtVehiculoLic, "")

        If txtVehiculomarca.Text = "" Then
            txtVehiculoPlaca.Text = ""
            txtCertificado.Text = ""
            txtVehiculoLic.Text = ""
            disablevehiculo()
        End If

    End Sub

    Private Sub txtTransportistaRUC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransportistaRUC.TextChanged
        txtTransportistaNombre.Enabled = True
        ErrorNombreTranspor.SetError(Me.txtTransportistaNombre, "")

        If txtTransportistaRUC.Text = "" Then
            txtTransportistaNombre.Text = ""
            txtTransportistaNombre.Enabled = False
        End If

    End Sub

    Private Sub lnkUsuario_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUsuario.LinkClicked
        Dim nuevopass As String
        Dim passMD5 As String
        nuevopass = InputBox("Ingresar nueva contraseña")
        If nuevopass = vbNullString Then
            'MessageBox.Show("Se calceló")
            Exit Sub
        Else
            passMD5 = clManGuia.GeneraMD5(nuevopass)
            clManGuia.upPassUsuario(passMD5, Usuario)
        End If
    End Sub

    Private Sub dtGuiaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtGuiaIni.ValueChanged
        Dim idia As String
        Dim imes As String
        Dim ianio As String

        idia = dtGuiaIni.Value.Day
        imes = dtGuiaIni.Value.Month
        ianio = dtGuiaIni.Value.Year
        Dim finicio As String
        finicio = (ianio & "-" & imes & "-" & idia)

        Dim fdia As String
        Dim fmes As String
        Dim fanio As String

        fdia = dtGuiaFin.Value.Day
        fmes = dtGuiaFin.Value.Month
        fanio = dtGuiaFin.Value.Year
        Dim ffin As String
        ffin = (fanio & "-" & fmes & "-" & fdia)

        llenaGuiasHis(finicio, ffin)

    End Sub

    Public Sub llenaGuiasHis(ByVal ini As String, ByVal fin As String)
        

        'fechainicio = (anioFiltroini & "-" & mesFiltroini & "-" & diaFiltroini)

        Dim table As DataTable
        table = New DataTable
        frmAdd.checkCone()
        Dim qr2 As String
        qr2 = "SELECT CODIGO, 'RAZON SOCIAL',RUC FROM publicidadimpresa.view_guiafiltro where fechaemicion between '" & ini & "' and '" & fin & "';"
        adp = New MySqlDataAdapter(qr2, cone.MysqlConexion)
        adp.Fill(table)
        Me.gridGuias.DataSource = table
        Me.gridGuias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        cone.MysqlConexion.Close()
    End Sub

    Private Sub dtGuiaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtGuiaFin.ValueChanged
        Dim idia As String
        Dim imes As String
        Dim ianio As String

        idia = dtGuiaIni.Value.Day
        imes = dtGuiaIni.Value.Month
        ianio = dtGuiaIni.Value.Year
        Dim finicio As String
        finicio = (ianio & "-" & imes & "-" & idia)

        Dim fdia As String
        Dim fmes As String
        Dim fanio As String

        fdia = dtGuiaFin.Value.Day
        fmes = dtGuiaFin.Value.Month
        fanio = dtGuiaFin.Value.Year
        Dim ffin As String
        ffin = (fanio & "-" & fmes & "-" & fdia)

        llenaGuiasHis(finicio, ffin)
    End Sub

    Private Sub cboTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoArticulo.SelectedIndexChanged

        Select Case cboTipoArticulo.Text
            Case "* Otro"
                Dim resultArti As String
                resultArti = InputBox("Ingrese el nombre del tipo de artículo")
                If resultArti <> vbNullString Then
                    If manAlmacen.verExisteTipoArticulo(resultArti) = False Then
                        manAlmacen.ingresarTipoArticulo(resultArti)
                        llenaTipoArticulo()
                    Else
                        MetroMessageBox.Show(Me, "El tipo de artículo ya existe", "ERROR!")
                    End If
                Else
                    MetroMessageBox.Show(Me, "Por favor ingrese el nombre del artículo, ejemplo: Autocopiativo", "Nombre Vacío")
                    cboTipoArticulo.SelectedIndex = 0
                    Exit Sub
                End If
            Case "Autocopiativo"
                hideTipoTipoMaterial()
            Case "Periodico"
                hideTipoPeriodico()
            Case Else
                hideTipoArticulo()
        End Select

    End Sub

    Dim manAlmacen As New clAlmacen

    Private Sub cboMarcaArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarcaArticulo.SelectedIndexChanged
        If cboMarcaArticulo.Text = "* Otro" Then
            Dim resultArti As String
            resultArti = InputBox("Ingrese el nombre de la marca del material")
            If resultArti <> vbNullString Then
                Console.WriteLine(manAlmacen.verExisteMarca(resultArti))
                If manAlmacen.verExisteMarca(resultArti) = False Then
                    manAlmacen.ingresarMarca(resultArti)
                    llenaMarca()
                Else
                    MetroMessageBox.Show(Me, "Esta marca ya se encuentra registrada", "Existe")
                    Exit Sub
                End If
            Else
                MetroMessageBox.Show(Me, "Por favor ingrese el nombre de la marca del material, ejemplo: MultiCopy", "Marca Vacía")
                'cboMarcaArticulo.SelectedIndex = 0
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cboGramajeArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGramajeArticulo.SelectedIndexChanged
        If cboGramajeArticulo.Text = "* Otro" Then
            Dim resultArti As String
            resultArti = InputBox("Ingrese el gramaje del material")
            If resultArti <> vbNullString And IsNumeric(resultArti) Then
                If manAlmacen.verExisteGramaje(resultArti) = False Then
                    manAlmacen.ingresarGramaje(resultArti)
                    llenaGramaje()
                Else
                    MetroMessageBox.Show(Me, "Este gramaje ya existe", "Existe")
                    Exit Sub
                End If
            Else
                MetroMessageBox.Show(Me, "Por favor ingrese el gramaje del material, ejemplo: 55; Nota: Solo se aceptan números", "Gramaje Vacío")
                'cboGramajeArticulo.SelectedIndex = 0
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cboMedidaArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedidaArticulo.SelectedIndexChanged
        If cboMedidaArticulo.Text = "* Otro" Then
            Dim resultArti As String
            resultArti = InputBox("Ingrese la medida del material. ejemplo: A4, 61X86")
            If resultArti <> vbNullString Then
                If manAlmacen.verExisteMedida(resultArti) = False Then
                    manAlmacen.ingresarMedida(resultArti)
                    llenaMedida()
                Else
                    MetroMessageBox.Show(Me, "Esta medida ya existe", "Existe")
                    Exit Sub
                End If
            Else
                MetroMessageBox.Show(Me, "Por favor ingrese la media del material, ejemplo: A4, 61X86", "ERROR!")
                'cboMedidaArticulo.SelectedIndex = 0
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cboTipoPapel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPapel.SelectedIndexChanged
        If cboTipoPapel.Text = "* Otro" Then
            Dim resultArti As String
            resultArti = InputBox("Ingrese la medida el tipo de papel. ejemplo: CFB Amarillo")
            If resultArti <> vbNullString Then
                If manAlmacen.verExisteTipoPapel(resultArti) = False Then
                    manAlmacen.ingresarTipoPapel(resultArti)
                    llenaTipoPapel()
                Else
                    MetroMessageBox.Show(Me, "Este tipo de papel ya esta registrado CFB Amarillo", "ERROR!")
                End If
            Else
                MetroMessageBox.Show(Me, "Por favor ingrese el tipo de papel, ejemplo: CFB Amarillo", "ERROR!")
                cboTipoPapel.SelectedIndex = 0
                Exit Sub
            End If
        End If
    End Sub

    Dim fgSoloNum As New soloNumeros

    Private Sub txtCantidadArticulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = fgSoloNum.Fg_SoloNumeros(e.KeyChar, txtCantidadArticulo.Text & CChar(e.KeyChar))
    End Sub

    Public Sub disablevehiculo()
        txtVehiculoPlaca.Enabled = False
        txtVehiculoLic.Enabled = False
        txtCertificado.Enabled = False
    End Sub

    Public Sub enablevehiculo()
        txtVehiculoPlaca.Enabled = True
        txtVehiculoLic.Enabled = True
        txtCertificado.Enabled = True
    End Sub

    Public Sub llenaTipoArticulo()
        manAlmacen.llenaTipoArticulo()
        cboTipoArticulo.DataSource = manAlmacen.llenaTipoArticulo
    End Sub

    Public Sub llenaMarca()
        manAlmacen.llenaMarcas()
        cboMarcaArticulo.DataSource = manAlmacen.llenaMarcas

    End Sub

    Public Sub llenaGramaje()
        manAlmacen.llenaGramajes()
        cboGramajeArticulo.DataSource = manAlmacen.llenaGramajes

    End Sub

    Public Sub llenaMedida()
        'cboMedidaArticulo.Items.Add("* Otro")
        manAlmacen.llenaMedida()
        cboMedidaArticulo.DataSource = manAlmacen.llenaMedida
    End Sub

    Public Sub llenaTipoPapel()
        manAlmacen.llenaTipoPapel()
        cboTipoPapel.DataSource = manAlmacen.llenaTipoPapel
    End Sub

    Public Sub llenacolor()
        manAlmacen.llenaColorPeriodico()
        cboColores.DataSource = manAlmacen.llenaColorPeriodico
    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Console.WriteLine(manAlmacen.checkcod)
        'Exit Sub
        If lblColorArticulo.Visible = False And lblTipoArticulo.Visible = False Then
            Console.WriteLine("1")
            Console.WriteLine(manAlmacen.checkcod())
            validaArtisincod()
            Dim cod As String = manAlmacen.checkcod
            Dim cant As Integer = txtCantidadArticulo.Text
            Dim idtipo As Integer = manAlmacen.verIdTipoArticulo(cboTipoArticulo.Text)
            Dim idmarca As Integer = manAlmacen.verIdMarca(cboMarcaArticulo.Text)
            Dim idmedida As Integer = manAlmacen.verIdMedida(cboMedidaArticulo.Text)
            Dim idgramaje As Integer = manAlmacen.verIdGramaje(cboGramajeArticulo.Text)

            manAlmacen.insertarArticulo(cod, cant, idtipo, idmarca, idmedida, idgramaje)

            '(@codigo, @cantidad, @tipo, @marca, @medida, @gramaje)

        ElseIf lblColorArticulo.Visible = False And lblTipoArticulo.Visible = True Then
            Console.WriteLine("2")
            Console.WriteLine(manAlmacen.checkcod())
            validaTipoPapel()

            Dim cod As String = manAlmacen.checkcod
            Dim cant As Integer = txtCantidadArticulo.Text
            Dim idtipo As Integer = manAlmacen.verIdTipoArticulo(cboTipoArticulo.Text)
            Dim idmarca As Integer = manAlmacen.verIdMarca(cboMarcaArticulo.Text)
            Dim idmedida As Integer = manAlmacen.verIdMedida(cboMedidaArticulo.Text)
            Dim idtipopapel As Integer = manAlmacen.verIdTipoPapel(cboTipoPapel.Text)
            Dim idgramaje As Integer = manAlmacen.verIdGramaje(cboGramajeArticulo.Text)

            manAlmacen.insertarArticulo2(cod, cant, idtipo, idmarca, idmedida, idtipopapel, idgramaje)

        ElseIf lblColorArticulo.Visible = True And lblTipoArticulo.Visible = False Then
            Console.WriteLine("3")
            Console.WriteLine(manAlmacen.checkcod())
            validaColor()

            Dim cod As String = manAlmacen.checkcod
            Dim cant As Integer = txtCantidadArticulo.Text
            Dim idtipo As Integer = manAlmacen.verIdTipoArticulo(cboTipoArticulo.Text)
            Dim idmarca As Integer = manAlmacen.verIdMarca(cboMarcaArticulo.Text)
            Dim idmedida As Integer = manAlmacen.verIdMedida(cboMedidaArticulo.Text)
            Dim idgramaje As Integer = manAlmacen.verIdGramaje(cboGramajeArticulo.Text)
            Dim idcolor As Integer = manAlmacen.verIdColorPeriodico(cboColores.Text)
            manAlmacen.insertarArticulo3(cod, cant, idtipo, idmarca, idmedida, idgramaje, idcolor)

        End If

    End Sub

    Public Sub hideTipoArticulo()
        lblColorArticulo.Visible = False
        lblTipoArticulo.Visible = False
        cboTipoPapel.Visible = False
        cboColores.Visible = False
    End Sub

    Public Sub hideTipoPeriodico()
        lblColorArticulo.Visible = True
        lblTipoArticulo.Visible = False
        cboTipoPapel.Visible = False
        cboColores.Visible = True
    End Sub

    Public Sub hideTipoTipoMaterial()
        lblColorArticulo.Visible = False
        lblTipoArticulo.Visible = True
        cboTipoPapel.Visible = True
        cboColores.Visible = False
    End Sub

    Public Sub validaArtisincod()
        If cboTipoArticulo.Text = "* Otro" Or cboMarcaArticulo.Text = "* Otro" Or cboMedidaArticulo.Text = "* Otro" Or cboGramajeArticulo.Text = "* Otro" Or txtCantidadArticulo.Text = "" Then
            MetroMessageBox.Show(Me, "Revise que los campos de material estén correctos", "Error de ingreso de material")
            Exit Sub
        End If
    End Sub

    Public Sub validaTipoPapel()
        If cboTipoArticulo.Text = "* Otro" Or cboMarcaArticulo.Text = "* Otro" Or cboMedidaArticulo.Text = "* Otro" Or cboGramajeArticulo.Text = "* Otro" Or cboTipoPapel.Text = "* Otro" Or txtCantidadArticulo.Text = "" Then
            MetroMessageBox.Show(Me, "Revise que los campos de material estén correctos", "Error de ingreso de material")
            Exit Sub
        End If
    End Sub

    Public Sub validaColor()
        If cboTipoArticulo.Text = "* Otro" Or cboMarcaArticulo.Text = "* Otro" Or cboMedidaArticulo.Text = "* Otro" Or cboGramajeArticulo.Text = "* Otro" Or cboColores.Text = "* Otro" Or txtCantidadArticulo.Text = "" Then
            MetroMessageBox.Show(Me, "Revise que los campos de material estén correctos", "Error de ingreso de material")
            Exit Sub
        End If
    End Sub

    Private Sub cboColores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColores.SelectedIndexChanged
        If cboColores.Text = "* Otro" Then
            Dim resultArti As String
            resultArti = InputBox("Ingrese el color de papel periodico. ejemplo: Amarillo")
            If resultArti <> vbNullString Then
                If manAlmacen.verExisteColorPeriodico(resultArti) = False Then
                    manAlmacen.ingresarColorPeriodico(resultArti)
                    llenacolor()
                Else
                    MetroMessageBox.Show(Me, "Este color de papel ya esta registrado", "ERROR!")
                End If
            Else
                MetroMessageBox.Show(Me, "Por favor ingrese el color de papel, ejemplo: Amarillo", "ERROR!")
                cboTipoPapel.SelectedIndex = 0
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        gridAlmacen.DataSource = manAlmacen.llenagrillaalmacen(cboFiltroArticulo.Text, cboFiltroMarca.Text, cboFiltroGramaje.Text, cbofiltroMedida.Text)
    End Sub

    Private Sub btnRetiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ActualizarMaterialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim cantidad As String
        Dim codigo As String
        Dim codigoInsertarDevolucion As String
        Dim fechaact As String
        Dim id As Integer
        Dim cantBDArticulo As Integer
        Dim nuevacantidad As Integer
        cantidad = InputBox("Ingrese la cantidad que desea retirar")
        codigo = gridAlmacen.Rows(gridAlmacen.CurrentCell.RowIndex).Cells(0).Value
        If cantidad <> vbNullString Then
            While Not IsNumeric(cantidad)
                cantidad = InputBox("Ingrese la cantidad que desea retirar, Solo se admiten números")
                If cantidad = vbNullString Then
                    MetroMessageBox.Show(Me, "La cantidad es nula", "Nulo")
                    Exit Sub
                End If
            End While
            'Console.WriteLine(gridAlmacen.Rows(gridAlmacen.CurrentCell.RowIndex).Cells(0).Value)
            cantBDArticulo = manAlmacen.checkCantidad(codigo)

            If cantidad <= 0 Then
                MetroMessageBox.Show(Me, "la cantidad ingresada es menor a cero, se cancela la operación.", "Error de petición")
                Exit Sub
            Else
                codigoInsertarDevolucion = manAlmacen.checkcodAlmacenDevolucion
                id = manAlmacen.idarticulo(codigo)
                fechaact = manAlmacen.fechaactual
                manAlmacen.devolverarticulo(codigo, cantidad, cantBDArticulo)
                manAlmacen.insertardevolucion(codigoInsertarDevolucion, id, fechaact, cantidad)
                gridAlmacen.DataSource = manAlmacen.llenaGridAlmacenFull()
            End If

        Else
            MetroMessageBox.Show(Me, "La cantidad es nula", "Nulo")
            Exit Sub
        End If

    End Sub

    Private Sub RetirarMaterialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetirarMaterialToolStripMenuItem.Click
        Dim cantidad As String
        Dim codigo As String
        Dim codigoInsertarRetiro As String
        Dim fechaact As String
        Dim id As Integer
        Dim cantBDArticulo As Integer
        Dim nuevacantidad As Integer
        cantidad = InputBox("Ingrese la cantidad que desea retirar")
        codigo = gridAlmacen.Rows(gridAlmacen.CurrentCell.RowIndex).Cells(0).Value
        If cantidad <> vbNullString Then
            While Not IsNumeric(cantidad)
                cantidad = InputBox("Ingrese la cantidad que desea retirar, Solo se admiten números")
                If cantidad = vbNullString Then
                    MetroMessageBox.Show(Me, "La cantidad es nula", "Nulo")
                    Exit Sub
                End If
            End While
            'Console.WriteLine(gridAlmacen.Rows(gridAlmacen.CurrentCell.RowIndex).Cells(0).Value)
            cantBDArticulo = manAlmacen.checkCantidad(codigo)
            If cantidad > cantBDArticulo Then
                MetroMessageBox.Show(Me, "No hay stock para la cantidad solicitada", "Stock superado")
                Exit Sub
            ElseIf cantidad <= 0 Then
                MetroMessageBox.Show(Me, "la cantidad ingresada es menor a cero, se cancela la operación.", "Error de petición")
                Exit Sub
            ElseIf cantidad = cantBDArticulo Then
                Dim resp As DialogResult

                resp = MessageBox.Show("Las cantidades son iguales, se quedará sin stock, ¿desea continuar?", "sin stock", MessageBoxButtons.YesNo)
                If resp = vbYes Then
                    codigoInsertarRetiro = manAlmacen.checkcodAlmacenRetiro
                    fechaact = manAlmacen.fechaactual
                    id = manAlmacen.idarticulo(codigo)
                    nuevacantidad = cantBDArticulo - cantidad
                    manAlmacen.actulizastock(id, nuevacantidad)
                    manAlmacen.insertarretiro(codigoInsertarRetiro, id, fechaact, cantidad)
                    gridAlmacen.DataSource = manAlmacen.llenaGridAlmacenFull()
                Else
                    Exit Sub
                End If
            Else
                codigoInsertarRetiro = manAlmacen.checkcodAlmacenRetiro
                fechaact = manAlmacen.fechaactual
                id = manAlmacen.idarticulo(codigo)
                nuevacantidad = cantBDArticulo - cantidad
                manAlmacen.actulizastock(id, nuevacantidad)
                manAlmacen.insertarretiro(codigoInsertarRetiro, id, fechaact, cantidad)
                gridAlmacen.DataSource = manAlmacen.llenaGridAlmacenFull()
                gridSalidas.DataSource = manAlmacen.llenaGridPrestamos()
            End If

        Else
            MetroMessageBox.Show(Me, "La cantidad es nula", "Nulo")
            Exit Sub
        End If
    End Sub

    Private Sub EliminarMaterialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarMaterialToolStripMenuItem.Click

        Dim resp As New DialogResult
        Dim codigo As String
        codigo = gridAlmacen.Rows(gridAlmacen.CurrentCell.RowIndex).Cells(0).Value
        resp = MessageBox.Show("Se eliminará el producto con el código: " & codigo & ". ¿Desea continuar?", "Eliminar artículo", MessageBoxButtons.YesNo)
        If resp = vbYes Then
            manAlmacen.deshabilitararticulo(codigo)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub MetroTile8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile8.Click
        frmSunat.Show()
    End Sub

    Private Sub gridSalidas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridSalidas.CellContentClick

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim cantidad As String
        Dim codigo As String
        Dim codigoInsertarDevolucion As String
        Dim fechaact As String
        Dim id As Integer
        Dim cantBDArticulo As Integer
        Dim nuevacantidad As Integer
        cantidad = InputBox("Ingrese la cantidad que desea retirar")
        codigo = gridSalidas.Rows(gridSalidas.CurrentCell.RowIndex).Cells(0).Value
        If cantidad <> vbNullString Then
            While Not IsNumeric(cantidad)
                cantidad = InputBox("Ingrese la cantidad que desea retirar, Solo se admiten números")
                If cantidad = vbNullString Then
                    MetroMessageBox.Show(Me, "La cantidad es nula", "Nulo")
                    Exit Sub
                End If
            End While
            'Console.WriteLine(gridAlmacen.Rows(gridAlmacen.CurrentCell.RowIndex).Cells(0).Value)
            cantBDArticulo = manAlmacen.checkCantidad2(codigo)

            If cantidad <= 0 Then
                MetroMessageBox.Show(Me, "la cantidad ingresada es menor a cero, se cancela la operación.", "Error de petición")
                Exit Sub
            Else
                Dim checkCant As Integer = manAlmacen.checkCantPrestamo(codigo)
                If checkCant < cantidad Then
                    MetroMessageBox.Show(Me, "la cantidad ingresada es mayor a la salida de material, se cancela la operación.", "Error de petición")
                    Exit Sub
                Else
                    manAlmacen.actualizaPrestamoMaterial(codigo, cantidad, checkCant)
                    id = manAlmacen.idArticulo2(codigo)
                    manAlmacen.sumaDevolucion(cantidad, id)

                    'codigoInsertarDevolucion = manAlmacen.checkcodAlmacenDevolucion
                    'id = manAlmacen.idarticulo(codigo)
                    'fechaact = manAlmacen.fechaactual
                    'manAlmacen.devolverarticulo(codigo, cantidad, cantBDArticulo)
                    'manAlmacen.insertardevolucion(codigoInsertarDevolucion, id, fechaact, cantidad)
                End If
                gridSalidas.DataSource = manAlmacen.llenaGridPrestamos()
                gridAlmacen.DataSource = manAlmacen.llenaGridAlmacenFull()
            End If

        Else
            MetroMessageBox.Show(Me, "La cantidad es nula", "Nulo")
            Exit Sub
        End If
    End Sub

    
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

        Dim codigo As String
        codigo = gridSalidas.Rows(gridSalidas.CurrentCell.RowIndex).Cells(0).Value
        Dim resp As DialogResult
        resp = MessageBox.Show("Se revisará la entrega de material, ¿desea continuar?", "sin stock", MessageBoxButtons.YesNo)
        If resp = vbYes Then
            manAlmacen.revisarRetiroMaterial(codigo)
            gridSalidas.DataSource = manAlmacen.llenaGridPrestamos()
            gridAlmacen.DataSource = manAlmacen.llenaGridAlmacenFull()
        Else
            Exit Sub
        End If

    End Sub

    Function comprobarTextBox_letras(ByVal texto As String) As Boolean
        Dim result As Boolean
        If texto = vbNullString Then
            result = False
        Else
            If IsNumeric(texto) Then
                result = False
            Else
                result = True
            End If
        End If
        Return result
    End Function

    Function comprobarTextBox_numeros(ByVal texto As String) As Boolean
        Dim result As Boolean
        If texto = vbNullString Then
            result = False
        Else
            If IsNumeric(texto) Then
                result = True
            Else
                result = False
            End If
        End If
        Return result
    End Function

    'Private Sub cboTipoArticulo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoArticulo.SelectedIndexChanged
    '    If cboTipoArticulo.Text = "* Otro" Then
    '        Dim texto As String
    '        texto = InputBox("Ingrese nombre del artículo nuevo")

    '        If comprobarTextBox_letras(texto) = True Then

    '        Else
    '            MetroMessageBox.Show(Me, "No se pudo completar la operación", "Error")
    '            Exit Sub
    '        End If

    '    End If
    'End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim dsverAlmacen As New dsAlmacen
        Dim dtverAlmacen As New dsAlmacen.AlmacenDataTable
        Dim rpverAlmacen As New crVerAlmacen

        Dim filas As Integer = gridAlmacen.Rows.Count
        Dim i As Integer = 0

        For i = 0 To filas - 1
            dtverAlmacen.Rows.Add(
                Me.gridAlmacen.Rows(i).Cells(0).Value,
                Me.gridAlmacen.Rows(i).Cells(1).Value,
                Me.gridAlmacen.Rows(i).Cells(2).Value,
                Me.gridAlmacen.Rows(i).Cells(3).Value,
                Me.gridAlmacen.Rows(i).Cells(4).Value,
                Me.gridAlmacen.Rows(i).Cells(5).Value)
        Next (i)


        dsverAlmacen.Tables(0).Merge(dtverAlmacen)
        'dsverfacts.Tables("filtro").Merge(dtdatosfiltro)
        rpverAlmacen.SetDataSource(dsverAlmacen)
        frmImprimirAlmacen.CrystalReportViewer1.ReportSource = rpverAlmacen
        'reporteFacturas.CrystalReportViewer1.ReportSource = rpverAlmacen
        frmImprimirAlmacen.Show()

        'Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptDoc = New CrystalReportFacturas

        'reporteFacturas.CrystalReportViewer1.ReportSource = rptDoc
        'reporteFacturas.ShowDialog()
        'reporteFacturas.Dispose()
    End Sub
End Class