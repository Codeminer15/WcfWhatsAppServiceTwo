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
        Me.txtPhoneNumberId = New System.Windows.Forms.TextBox()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextUrl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUserAccessToken = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(112, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Token de Acceso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(37, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID de Número de Teléfono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(172, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Versión:"
        '
        'txtPhoneNumberId
        '
        Me.txtPhoneNumberId.Location = New System.Drawing.Point(268, 167)
        Me.txtPhoneNumberId.Name = "txtPhoneNumberId"
        Me.txtPhoneNumberId.Size = New System.Drawing.Size(317, 20)
        Me.txtPhoneNumberId.TabIndex = 4
        Me.txtPhoneNumberId.Text = "410461155481036"
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
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.Location = New System.Drawing.Point(543, 340)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 40)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(178, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Label4"
        '
        'TextUrl
        '
        Me.TextUrl.Location = New System.Drawing.Point(268, 263)
        Me.TextUrl.Name = "TextUrl"
        Me.TextUrl.Size = New System.Drawing.Size(228, 20)
        Me.TextUrl.TabIndex = 9
        Me.TextUrl.Text = "https://graph.facebook.com"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(165, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 21)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "URL Meta:"
        '
        'txtUserAccessToken
        '
        Me.txtUserAccessToken.Location = New System.Drawing.Point(268, 101)
        Me.txtUserAccessToken.Multiline = True
        Me.txtUserAccessToken.Name = "txtUserAccessToken"
        Me.txtUserAccessToken.Size = New System.Drawing.Size(317, 60)
        Me.txtUserAccessToken.TabIndex = 3
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCancel.Location = New System.Drawing.Point(410, 340)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(109, 40)
        Me.BtnCancel.TabIndex = 18
        Me.BtnCancel.Text = "Cancelar"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'WhatsAppConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 450)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextUrl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbVersion)
        Me.Controls.Add(Me.txtPhoneNumberId)
        Me.Controls.Add(Me.txtUserAccessToken)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "WhatsAppConfig"
        Me.Text = "Configuración de API Cloud"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPhoneNumberId As TextBox
    Friend WithEvents cmbVersion As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents LblMsg As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextUrl As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUserAccessToken As TextBox
    Friend WithEvents BtnCancel As Button
End Class
