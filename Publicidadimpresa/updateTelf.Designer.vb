<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdateTelf
    Inherits MetroFramework.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtNomContacto = New MetroFramework.Controls.MetroTextBox()
        Me.txtNumContacto = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.btnAdd = New MetroFramework.Controls.MetroTile()
        Me.btnCancel = New MetroFramework.Controls.MetroTile()
        Me.lblNomEmpresa = New MetroFramework.Controls.MetroLabel()
        Me.SuspendLayout()
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
        Me.txtNomContacto.Location = New System.Drawing.Point(24, 112)
        Me.txtNomContacto.MaxLength = 32767
        Me.txtNomContacto.Name = "txtNomContacto"
        Me.txtNomContacto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNomContacto.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNomContacto.SelectedText = ""
        Me.txtNomContacto.SelectionLength = 0
        Me.txtNomContacto.SelectionStart = 0
        Me.txtNomContacto.Size = New System.Drawing.Size(253, 30)
        Me.txtNomContacto.TabIndex = 0
        Me.txtNomContacto.UseSelectable = True
        Me.txtNomContacto.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNomContacto.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtNumContacto
        '
        '
        '
        '
        Me.txtNumContacto.CustomButton.Image = Nothing
        Me.txtNumContacto.CustomButton.Location = New System.Drawing.Point(225, 2)
        Me.txtNumContacto.CustomButton.Name = ""
        Me.txtNumContacto.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtNumContacto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNumContacto.CustomButton.TabIndex = 1
        Me.txtNumContacto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtNumContacto.CustomButton.UseSelectable = True
        Me.txtNumContacto.CustomButton.Visible = False
        Me.txtNumContacto.Lines = New String(-1) {}
        Me.txtNumContacto.Location = New System.Drawing.Point(24, 176)
        Me.txtNumContacto.MaxLength = 9
        Me.txtNumContacto.Name = "txtNumContacto"
        Me.txtNumContacto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNumContacto.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNumContacto.SelectedText = ""
        Me.txtNumContacto.SelectionLength = 0
        Me.txtNumContacto.SelectionStart = 0
        Me.txtNumContacto.Size = New System.Drawing.Size(253, 30)
        Me.txtNumContacto.TabIndex = 1
        Me.txtNumContacto.UseSelectable = True
        Me.txtNumContacto.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNumContacto.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(24, 90)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(135, 19)
        Me.MetroLabel1.TabIndex = 2
        Me.MetroLabel1.Text = "Nombre de contacto:"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(24, 154)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(132, 19)
        Me.MetroLabel2.TabIndex = 3
        Me.MetroLabel2.Text = "Número de teléfono:"
        '
        'btnAdd
        '
        Me.btnAdd.ActiveControl = Nothing
        Me.btnAdd.Location = New System.Drawing.Point(23, 225)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(118, 30)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Actualizar"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.UseSelectable = True
        Me.btnAdd.UseStyleColors = True
        '
        'btnCancel
        '
        Me.btnCancel.ActiveControl = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(159, 225)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 30)
        Me.btnCancel.Style = MetroFramework.MetroColorStyle.Red
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCancel.UseSelectable = True
        Me.btnCancel.UseStyleColors = True
        '
        'lblNomEmpresa
        '
        Me.lblNomEmpresa.AutoSize = True
        Me.lblNomEmpresa.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.lblNomEmpresa.Location = New System.Drawing.Point(24, 60)
        Me.lblNomEmpresa.Name = "lblNomEmpresa"
        Me.lblNomEmpresa.Size = New System.Drawing.Size(0, 0)
        Me.lblNomEmpresa.TabIndex = 6
        '
        'frmUpdateTelf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 300)
        Me.Controls.Add(Me.lblNomEmpresa)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.txtNumContacto)
        Me.Controls.Add(Me.txtNomContacto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateTelf"
        Me.Resizable = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Actualizar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNomContacto As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtNumContacto As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnAdd As MetroFramework.Controls.MetroTile
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroTile
    Friend WithEvents lblNomEmpresa As MetroFramework.Controls.MetroLabel
End Class
