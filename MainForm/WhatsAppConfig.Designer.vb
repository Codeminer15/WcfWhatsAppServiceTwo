<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WhatsAppConfig
    Inherits System.Windows.Forms.Form

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUserAccessToken = New System.Windows.Forms.TextBox()
        Me.txtPhoneNumberId = New System.Windows.Forms.TextBox()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Token de Acceso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(129, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID de Número de Teléfono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(164, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Versión:"
        '
        'txtUserAccessToken
        '
        Me.txtUserAccessToken.Location = New System.Drawing.Point(268, 101)
        Me.txtUserAccessToken.Name = "txtUserAccessToken"
        Me.txtUserAccessToken.Size = New System.Drawing.Size(100, 20)
        Me.txtUserAccessToken.TabIndex = 3
        '
        'txtPhoneNumberId
        '
        Me.txtPhoneNumberId.Location = New System.Drawing.Point(268, 142)
        Me.txtPhoneNumberId.Name = "txtPhoneNumberId"
        Me.txtPhoneNumberId.Size = New System.Drawing.Size(100, 20)
        Me.txtPhoneNumberId.TabIndex = 4
        '
        'cmbVersion
        '
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.Location = New System.Drawing.Point(268, 197)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(121, 21)
        Me.cmbVersion.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(580, 326)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Location = New System.Drawing.Point(154, 331)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(55, 13)
        Me.LblMsg.TabIndex = 7
        Me.LblMsg.Text = "Estado: ---"
        '
        'WhatsAppConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbVersion)
        Me.Controls.Add(Me.txtPhoneNumberId)
        Me.Controls.Add(Me.txtUserAccessToken)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "WhatsAppConfig"
        Me.Text = "WhatsAppConfig"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUserAccessToken As TextBox
    Friend WithEvents txtPhoneNumberId As TextBox
    Friend WithEvents cmbVersion As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents LblMsg As Label
End Class
