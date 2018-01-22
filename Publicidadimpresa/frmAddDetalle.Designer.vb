<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddDetalle
    Inherits MetroFramework.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddDetalle))
        Me.btnNextDetalle = New MetroFramework.Controls.MetroButton()
        Me.btnEndDetalle = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.txtCantidad = New MetroFramework.Controls.MetroTextBox()
        Me.txtCosto = New MetroFramework.Controls.MetroTextBox()
        Me.txtDetalle = New MetroFramework.Controls.MetroTextBox()
        Me.ErrorCantidadDetalle = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorDetalle = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorCosto = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lnkcalPUnitario = New System.Windows.Forms.LinkLabel()
        CType(Me.ErrorCantidadDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNextDetalle
        '
        Me.btnNextDetalle.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnNextDetalle.Location = New System.Drawing.Point(23, 257)
        Me.btnNextDetalle.Name = "btnNextDetalle"
        Me.btnNextDetalle.Size = New System.Drawing.Size(106, 32)
        Me.btnNextDetalle.Style = MetroFramework.MetroColorStyle.Blue
        Me.btnNextDetalle.TabIndex = 9
        Me.btnNextDetalle.Text = "&Agregar"
        Me.btnNextDetalle.UseSelectable = True
        Me.btnNextDetalle.UseStyleColors = True
        '
        'btnEndDetalle
        '
        Me.btnEndDetalle.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnEndDetalle.Location = New System.Drawing.Point(151, 257)
        Me.btnEndDetalle.Name = "btnEndDetalle"
        Me.btnEndDetalle.Size = New System.Drawing.Size(126, 32)
        Me.btnEndDetalle.Style = MetroFramework.MetroColorStyle.Red
        Me.btnEndDetalle.TabIndex = 10
        Me.btnEndDetalle.Text = "&Finalizar"
        Me.btnEndDetalle.UseSelectable = True
        Me.btnEndDetalle.UseStyleColors = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(24, 74)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(62, 19)
        Me.MetroLabel1.TabIndex = 2
        Me.MetroLabel1.Text = "Cantidad"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(23, 102)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(49, 19)
        Me.MetroLabel2.TabIndex = 3
        Me.MetroLabel2.Text = "Detalle"
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(24, 210)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(95, 19)
        Me.MetroLabel3.TabIndex = 4
        Me.MetroLabel3.Text = "Costo  unitario"
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.CustomButton.Image = Nothing
        Me.txtCantidad.CustomButton.Location = New System.Drawing.Point(130, 1)
        Me.txtCantidad.CustomButton.Name = ""
        Me.txtCantidad.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtCantidad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCantidad.CustomButton.TabIndex = 1
        Me.txtCantidad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCantidad.CustomButton.UseSelectable = True
        Me.txtCantidad.CustomButton.Visible = False
        Me.txtCantidad.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtCantidad.Lines = New String(-1) {}
        Me.txtCantidad.Location = New System.Drawing.Point(125, 70)
        Me.txtCantidad.MaxLength = 32767
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCantidad.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCantidad.SelectedText = ""
        Me.txtCantidad.SelectionLength = 0
        Me.txtCantidad.SelectionStart = 0
        Me.txtCantidad.Size = New System.Drawing.Size(152, 23)
        Me.txtCantidad.TabIndex = 5
        Me.txtCantidad.UseSelectable = True
        Me.txtCantidad.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCantidad.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtCosto
        '
        '
        '
        '
        Me.txtCosto.CustomButton.Image = Nothing
        Me.txtCosto.CustomButton.Location = New System.Drawing.Point(130, 1)
        Me.txtCosto.CustomButton.Name = ""
        Me.txtCosto.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtCosto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCosto.CustomButton.TabIndex = 1
        Me.txtCosto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCosto.CustomButton.UseSelectable = True
        Me.txtCosto.CustomButton.Visible = False
        Me.txtCosto.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtCosto.Lines = New String(-1) {}
        Me.txtCosto.Location = New System.Drawing.Point(125, 205)
        Me.txtCosto.MaxLength = 32767
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCosto.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCosto.SelectedText = ""
        Me.txtCosto.SelectionLength = 0
        Me.txtCosto.SelectionStart = 0
        Me.txtCosto.Size = New System.Drawing.Size(152, 23)
        Me.txtCosto.TabIndex = 8
        Me.txtCosto.UseSelectable = True
        Me.txtCosto.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCosto.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtDetalle
        '
        '
        '
        '
        Me.txtDetalle.CustomButton.Image = Nothing
        Me.txtDetalle.CustomButton.Location = New System.Drawing.Point(179, 1)
        Me.txtDetalle.CustomButton.Name = ""
        Me.txtDetalle.CustomButton.Size = New System.Drawing.Size(73, 73)
        Me.txtDetalle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtDetalle.CustomButton.TabIndex = 1
        Me.txtDetalle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtDetalle.CustomButton.UseSelectable = True
        Me.txtDetalle.CustomButton.Visible = False
        Me.txtDetalle.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtDetalle.Lines = New String(-1) {}
        Me.txtDetalle.Location = New System.Drawing.Point(24, 124)
        Me.txtDetalle.MaxLength = 32767
        Me.txtDetalle.Multiline = True
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDetalle.SelectedText = ""
        Me.txtDetalle.SelectionLength = 0
        Me.txtDetalle.SelectionStart = 0
        Me.txtDetalle.Size = New System.Drawing.Size(253, 75)
        Me.txtDetalle.TabIndex = 6
        Me.txtDetalle.UseSelectable = True
        Me.txtDetalle.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtDetalle.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'ErrorCantidadDetalle
        '
        Me.ErrorCantidadDetalle.ContainerControl = Me
        '
        'ErrorDetalle
        '
        Me.ErrorDetalle.ContainerControl = Me
        '
        'ErrorCosto
        '
        Me.ErrorCosto.ContainerControl = Me
        '
        'lnkcalPUnitario
        '
        Me.lnkcalPUnitario.AutoSize = True
        Me.lnkcalPUnitario.Location = New System.Drawing.Point(149, 236)
        Me.lnkcalPUnitario.Name = "lnkcalPUnitario"
        Me.lnkcalPUnitario.Size = New System.Drawing.Size(128, 13)
        Me.lnkcalPUnitario.TabIndex = 11
        Me.lnkcalPUnitario.TabStop = True
        Me.lnkcalPUnitario.Text = "Calcular el precio unitario:"
        '
        'frmAddDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 300)
        Me.Controls.Add(Me.lnkcalPUnitario)
        Me.Controls.Add(Me.txtDetalle)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.btnEndDetalle)
        Me.Controls.Add(Me.btnNextDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddDetalle"
        Me.Style = MetroFramework.MetroColorStyle.Purple
        Me.Text = "Agregar detalle 1"
        CType(Me.ErrorCantidadDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNextDetalle As MetroFramework.Controls.MetroButton
    Friend WithEvents btnEndDetalle As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtCantidad As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCosto As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtDetalle As MetroFramework.Controls.MetroTextBox
    Friend WithEvents ErrorCantidadDetalle As ErrorProvider
    Friend WithEvents ErrorDetalle As ErrorProvider
    Friend WithEvents ErrorCosto As ErrorProvider
    Friend WithEvents lnkcalPUnitario As LinkLabel
End Class
