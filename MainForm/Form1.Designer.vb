<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.BtnSendMessageWindow = New System.Windows.Forms.Button()
        Me.BtnSetting = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnSendMessageWindow
        '
        Me.BtnSendMessageWindow.BackColor = System.Drawing.Color.LimeGreen
        Me.BtnSendMessageWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSendMessageWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSendMessageWindow.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnSendMessageWindow.Location = New System.Drawing.Point(319, 200)
        Me.BtnSendMessageWindow.Name = "BtnSendMessageWindow"
        Me.BtnSendMessageWindow.Size = New System.Drawing.Size(115, 47)
        Me.BtnSendMessageWindow.TabIndex = 0
        Me.BtnSendMessageWindow.Text = "WhatsApp"
        Me.BtnSendMessageWindow.UseVisualStyleBackColor = False
        '
        'BtnSetting
        '
        Me.BtnSetting.BackColor = System.Drawing.Color.RoyalBlue
        Me.BtnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnSetting.Location = New System.Drawing.Point(319, 125)
        Me.BtnSetting.Name = "BtnSetting"
        Me.BtnSetting.Size = New System.Drawing.Size(115, 47)
        Me.BtnSetting.TabIndex = 1
        Me.BtnSetting.Text = "Configuración"
        Me.BtnSetting.UseVisualStyleBackColor = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(357, 68)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCliente.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Id Cliente"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.BtnSetting)
        Me.Controls.Add(Me.BtnSendMessageWindow)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSendMessageWindow As Button
    Friend WithEvents BtnSetting As Button
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents Label1 As Label
End Class
