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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.lblPdf = New System.Windows.Forms.Label()
        Me.lblXml = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.btnGitHub = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPGH = New System.Windows.Forms.Label()
        Me.lblXGH = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(580, 354)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "btnEnviar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(114, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre del Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Numero de Teléfono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Documentos:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(251, 90)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
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
        Me.txtPhoneNumber.Location = New System.Drawing.Point(251, 134)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtPhoneNumber.TabIndex = 6
        '
        'lblPdf
        '
        Me.lblPdf.AutoSize = True
        Me.lblPdf.Location = New System.Drawing.Point(210, 194)
        Me.lblPdf.Name = "lblPdf"
        Me.lblPdf.Size = New System.Drawing.Size(23, 13)
        Me.lblPdf.TabIndex = 7
        Me.lblPdf.Text = "Pdf"
        '
        'lblXml
        '
        Me.lblXml.AutoSize = True
        Me.lblXml.Location = New System.Drawing.Point(210, 221)
        Me.lblXml.Name = "lblXml"
        Me.lblXml.Size = New System.Drawing.Size(24, 13)
        Me.lblXml.TabIndex = 8
        Me.lblXml.Text = "Xml"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(102, 405)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(52, 13)
        Me.lblState.TabIndex = 9
        Me.lblState.Text = "Estado: --"
        '
        'btnGitHub
        '
        Me.btnGitHub.Location = New System.Drawing.Point(120, 331)
        Me.btnGitHub.Name = "btnGitHub"
        Me.btnGitHub.Size = New System.Drawing.Size(75, 23)
        Me.btnGitHub.TabIndex = 10
        Me.btnGitHub.Text = "GitHub"
        Me.btnGitHub.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 268)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Ruta en GitHub:"
        '
        'lblPGH
        '
        Me.lblPGH.AutoSize = True
        Me.lblPGH.Location = New System.Drawing.Point(235, 259)
        Me.lblPGH.Name = "lblPGH"
        Me.lblPGH.Size = New System.Drawing.Size(23, 13)
        Me.lblPGH.TabIndex = 12
        Me.lblPGH.Text = "Pdf"
        '
        'lblXGH
        '
        Me.lblXGH.AutoSize = True
        Me.lblXGH.Location = New System.Drawing.Point(235, 284)
        Me.lblXGH.Name = "lblXGH"
        Me.lblXGH.Size = New System.Drawing.Size(24, 13)
        Me.lblXGH.TabIndex = 13
        Me.lblXGH.Text = "Xml"
        '
        'WhasAppForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblXGH)
        Me.Controls.Add(Me.lblPGH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnGitHub)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.lblXml)
        Me.Controls.Add(Me.lblPdf)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "WhasAppForm"
        Me.Text = "WhasAppForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents lblPdf As Label
    Friend WithEvents lblXml As Label
    Friend WithEvents lblState As Label
    Friend WithEvents btnGitHub As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPGH As Label
    Friend WithEvents lblXGH As Label
End Class
