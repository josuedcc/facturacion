﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSunat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSunat))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(20, 60)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(630, 420)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("http://www.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp", System.UriKind.Absolute)
        '
        'frmSunat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 500)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSunat"
        Me.Text = "SUNAT"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
End Class
