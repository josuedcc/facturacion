<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddEmail))
        Me.lblNomEmpresa = New MetroFramework.Controls.MetroLabel()
        Me.btnCancel = New MetroFramework.Controls.MetroTile()
        Me.btnAdd = New MetroFramework.Controls.MetroTile()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.txtEmailContacto = New MetroFramework.Controls.MetroTextBox()
        Me.txtNomContacto = New MetroFramework.Controls.MetroTextBox()
        Me.SuspendLayout()
        '
        'lblNomEmpresa
        '
        Me.lblNomEmpresa.AutoSize = True
        Me.lblNomEmpresa.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.lblNomEmpresa.Location = New System.Drawing.Point(24, 53)
        Me.lblNomEmpresa.Name = "lblNomEmpresa"
        Me.lblNomEmpresa.Size = New System.Drawing.Size(0, 0)
        Me.lblNomEmpresa.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.ActiveControl = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(159, 218)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 30)
        Me.btnCancel.Style = MetroFramework.MetroColorStyle.Red
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCancel.UseSelectable = True
        Me.btnCancel.UseStyleColors = True
        '
        'btnAdd
        '
        Me.btnAdd.ActiveControl = Nothing
        Me.btnAdd.Location = New System.Drawing.Point(23, 218)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(118, 30)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "Agregar Email"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.UseSelectable = True
        Me.btnAdd.UseStyleColors = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(24, 147)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(44, 19)
        Me.MetroLabel2.TabIndex = 10
        Me.MetroLabel2.Text = "Email:"
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(24, 83)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(135, 19)
        Me.MetroLabel1.TabIndex = 9
        Me.MetroLabel1.Text = "Nombre de contacto:"
        '
        'txtEmailContacto
        '
        '
        '
        '
        Me.txtEmailContacto.CustomButton.Image = Nothing
        Me.txtEmailContacto.CustomButton.Location = New System.Drawing.Point(225, 2)
        Me.txtEmailContacto.CustomButton.Name = ""
        Me.txtEmailContacto.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtEmailContacto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtEmailContacto.CustomButton.TabIndex = 1
        Me.txtEmailContacto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtEmailContacto.CustomButton.UseSelectable = True
        Me.txtEmailContacto.CustomButton.Visible = False
        Me.txtEmailContacto.Lines = New String(-1) {}
        Me.txtEmailContacto.Location = New System.Drawing.Point(24, 169)
        Me.txtEmailContacto.MaxLength = 50
        Me.txtEmailContacto.Name = "txtEmailContacto"
        Me.txtEmailContacto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmailContacto.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtEmailContacto.SelectedText = ""
        Me.txtEmailContacto.SelectionLength = 0
        Me.txtEmailContacto.SelectionStart = 0
        Me.txtEmailContacto.Size = New System.Drawing.Size(253, 30)
        Me.txtEmailContacto.TabIndex = 8
        Me.txtEmailContacto.UseSelectable = True
        Me.txtEmailContacto.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtEmailContacto.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtNomContacto
        '
        '
        '
        '
        Me.txtNomContacto.CustomButton.Image = Nothing
        Me.txtNomContacto.CustomButton.Location = New System.Drawing.Point(225, 2)
        Me.txtNomContacto.CustomButton.Name = ""
        Me.txtNomContacto.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtNomContacto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNomContacto.CustomButton.TabIndex = 1
        Me.txtNomContacto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtNomContacto.CustomButton.UseSelectable = True
        Me.txtNomContacto.CustomButton.Visible = False
        Me.txtNomContacto.Lines = New String(-1) {}
        Me.txtNomContacto.Location = New System.Drawing.Point(24, 105)
        Me.txtNomContacto.MaxLength = 32767
        Me.txtNomContacto.Name = "txtNomContacto"
        Me.txtNomContacto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNomContacto.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNomContacto.SelectedText = ""
        Me.txtNomContacto.SelectionLength = 0
        Me.txtNomContacto.SelectionStart = 0
        Me.txtNomContacto.Size = New System.Drawing.Size(253, 30)
        Me.txtNomContacto.TabIndex = 7
        Me.txtNomContacto.UseSelectable = True
        Me.txtNomContacto.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNomContacto.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'frmAddEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 300)
        Me.Controls.Add(Me.lblNomEmpresa)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.txtEmailContacto)
        Me.Controls.Add(Me.txtNomContacto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddEmail"
        Me.Text = "Agregar Email"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNomEmpresa As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroTile
    Friend WithEvents btnAdd As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtEmailContacto As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtNomContacto As MetroFramework.Controls.MetroTextBox
End Class
