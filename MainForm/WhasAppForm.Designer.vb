<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WhasAppForm
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
        Me.btnSendWhatsApp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.lblPdf = New System.Windows.Forms.Label()
        Me.lblXml = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPGH = New System.Windows.Forms.Label()
        Me.lblXGH = New System.Windows.Forms.Label()
        Me.lblServiceStatus = New System.Windows.Forms.Label()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.btnViewLogs = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.CheckBoxPdf = New System.Windows.Forms.CheckBox()
        Me.CheckBoxXml = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSendWhatsApp
        '
        Me.btnSendWhatsApp.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSendWhatsApp.Location = New System.Drawing.Point(639, 351)
        Me.btnSendWhatsApp.Name = "btnSendWhatsApp"
        Me.btnSendWhatsApp.Size = New System.Drawing.Size(109, 40)
        Me.btnSendWhatsApp.TabIndex = 0
        Me.btnSendWhatsApp.Text = "Enviar"
        Me.btnSendWhatsApp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(27, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre del Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Número de Teléfono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(79, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 21)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Documentos:"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(196, 67)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(207, 29)
        Me.txtName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(622, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Archivos  a Enviar"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhoneNumber.Location = New System.Drawing.Point(196, 110)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(207, 29)
        Me.txtPhoneNumber.TabIndex = 6
        '
        'lblPdf
        '
        Me.lblPdf.AutoSize = True
        Me.lblPdf.Location = New System.Drawing.Point(206, 182)
        Me.lblPdf.Name = "lblPdf"
        Me.lblPdf.Size = New System.Drawing.Size(23, 13)
        Me.lblPdf.TabIndex = 7
        Me.lblPdf.Text = "Pdf"
        '
        'lblXml
        '
        Me.lblXml.AutoSize = True
        Me.lblXml.Location = New System.Drawing.Point(206, 209)
        Me.lblXml.Name = "lblXml"
        Me.lblXml.Size = New System.Drawing.Size(24, 13)
        Me.lblXml.TabIndex = 8
        Me.lblXml.Text = "Xml"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(117, 367)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(111, 13)
        Me.lblState.TabIndex = 9
        Me.lblState.Text = "Estado de Archivos: --"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(60, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 21)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Ruta en GitHub:"
        '
        'lblPGH
        '
        Me.lblPGH.AutoSize = True
        Me.lblPGH.Location = New System.Drawing.Point(206, 235)
        Me.lblPGH.Name = "lblPGH"
        Me.lblPGH.Size = New System.Drawing.Size(23, 13)
        Me.lblPGH.TabIndex = 12
        Me.lblPGH.Text = "Pdf"
        '
        'lblXGH
        '
        Me.lblXGH.AutoSize = True
        Me.lblXGH.Location = New System.Drawing.Point(206, 260)
        Me.lblXGH.Name = "lblXGH"
        Me.lblXGH.Size = New System.Drawing.Size(24, 13)
        Me.lblXGH.TabIndex = 13
        Me.lblXGH.Text = "Xml"
        '
        'lblServiceStatus
        '
        Me.lblServiceStatus.AutoSize = True
        Me.lblServiceStatus.Location = New System.Drawing.Point(206, 300)
        Me.lblServiceStatus.Name = "lblServiceStatus"
        Me.lblServiceStatus.Size = New System.Drawing.Size(46, 13)
        Me.lblServiceStatus.TabIndex = 14
        Me.lblServiceStatus.Text = "Estado--"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(125, 295)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(75, 23)
        Me.btnTestConnection.TabIndex = 15
        Me.btnTestConnection.Text = "Conexion"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'btnViewLogs
        '
        Me.btnViewLogs.Location = New System.Drawing.Point(396, 362)
        Me.btnViewLogs.Name = "btnViewLogs"
        Me.btnViewLogs.Size = New System.Drawing.Size(75, 23)
        Me.btnViewLogs.TabIndex = 16
        Me.btnViewLogs.Text = "Abrir Logs"
        Me.btnViewLogs.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCancel.Location = New System.Drawing.Point(508, 351)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(109, 40)
        Me.BtnCancel.TabIndex = 17
        Me.BtnCancel.Text = "Cancelar"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'CheckBoxPdf
        '
        Me.CheckBoxPdf.AutoSize = True
        Me.CheckBoxPdf.Enabled = False
        Me.CheckBoxPdf.Location = New System.Drawing.Point(561, 56)
        Me.CheckBoxPdf.Name = "CheckBoxPdf"
        Me.CheckBoxPdf.Size = New System.Drawing.Size(47, 17)
        Me.CheckBoxPdf.TabIndex = 18
        Me.CheckBoxPdf.Text = "PDF"
        Me.CheckBoxPdf.UseVisualStyleBackColor = True
        '
        'CheckBoxXml
        '
        Me.CheckBoxXml.AutoSize = True
        Me.CheckBoxXml.Enabled = False
        Me.CheckBoxXml.Location = New System.Drawing.Point(561, 81)
        Me.CheckBoxXml.Name = "CheckBoxXml"
        Me.CheckBoxXml.Size = New System.Drawing.Size(48, 17)
        Me.CheckBoxXml.TabIndex = 19
        Me.CheckBoxXml.Text = "XML"
        Me.CheckBoxXml.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label6.Location = New System.Drawing.Point(193, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(424, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Debe incluir lada y la cadena de 10 dígitos, evitando símbolos (ejemplo: 52123456" &
    "7890)"
        '
        'WhasAppForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckBoxXml)
        Me.Controls.Add(Me.CheckBoxPdf)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.btnViewLogs)
        Me.Controls.Add(Me.btnTestConnection)
        Me.Controls.Add(Me.lblServiceStatus)
        Me.Controls.Add(Me.lblXGH)
        Me.Controls.Add(Me.lblPGH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.lblXml)
        Me.Controls.Add(Me.lblPdf)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSendWhatsApp)
        Me.Name = "WhasAppForm"
        Me.Text = "Envío de Factura - WhatsApp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSendWhatsApp As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents lblPdf As Label
    Friend WithEvents lblXml As Label
    Friend WithEvents lblState As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPGH As Label
    Friend WithEvents lblXGH As Label
    Friend WithEvents lblServiceStatus As Label
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents btnViewLogs As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents CheckBoxPdf As CheckBox
    Friend WithEvents CheckBoxXml As CheckBox
    Friend WithEvents Label6 As Label
End Class
