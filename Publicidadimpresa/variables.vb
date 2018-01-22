Imports MySql.Data.MySqlClient
Public Class variables
    Public Shared IdUsuario As String = ""
    Public Shared Usuario As String = ""
    Public Shared currentRuc As String = ""
    Public Shared currentNomEmpresa As String = ""
    Public Shared currentidEmpresa As String = ""
    Public Shared currentSelectContact As String = ""
    Public Shared currentSelectNumContact As String = ""
    Public Shared currentSelectEmailContact As String = ""
    Public Shared cone As New Conexion
    Public Shared cmds As MySqlCommand
    Public Shared rdrs As MySqlDataReader
    Public Shared qr As String = ""
    Public Shared adp As MySqlDataAdapter
    Public Shared series(1, 2) As Integer
    Public Shared tipomoneda As String = "00/100 nuevos soles"
    Public Shared simbolomoneda As String = "S/."
    Public Shared cantidadDetalle As Int32
    Public Shared detDetalle As String
    Public Shared pUnitdetalle As Double
    Public Shared filaR As Int32
    Public Shared viejoCostoTotalFila As Double
    Public Shared viejoCostoTotal As Double
    Public Shared NuevoCostoTotal As Double
    Public Shared totales As New ArrayList()
    Public Shared roundselect As Int16 = 1
    Public Shared fechainicio As String
    Public Shared fechafin As String
    Public Shared codFact As String
    Public Shared idFact As String

    Public Shared cantidadGuia As Integer
    Public Shared DescripGuia As String
    Public Shared totalGuia As Double

    Public Shared currentActGuia As Int32

    Public Shared codigogenerado As String

    Public Shared codGuiaFactura As String
    Public Shared otroRazon As String

End Class