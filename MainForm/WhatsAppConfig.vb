
Imports System.Data.SqlClient

Public Class WhatsAppConfig
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using conexion As SqlConnection = GetConnection()
                conexion.Open()

                'Verificar Si la tabla existe y si no, crearla
                Dim queryCreate As String = "
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UrlConfig')
                    BEGIN
                        CREATE TABLE UrlConfig(
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        UserAccessToken NVARCHAR(500) NOT NULL,
                        Version NVARCHAR(10) NOT NULL,
                        PhoneNumberId NVARCHAR (50) NOT NULL,
                        ApiUrl NVARCHAR(255) DEFAULT 'https://graph.facebook.com',
                        LastUpdate DATETIME DEFAULT GETDATE()
                        );
                    END
                "
                Using cmdCreate As New SqlCommand(queryCreate, conexion)
                    cmdCreate.ExecuteNonQuery()
                End Using

                'Insertar la configuración o actualizarla
                Dim querySave As String = "
                    IF EXISTS (SELECT 1 FROM UrlConfig)                         
                        UPDATE  UrlConfig
                        SET UserAccessToken = @token, Version = @version, PhoneNumberId = @phone, ApiUrl = @url
                    ELSE
                        INSERT INTO UrlConfig (UserAccessToken, Version, PhoneNumberId, ApiUrl)
                        VALUES (@token, @version, @phone, @url);
                 "
                Using cmdSave As New SqlCommand(querySave, conexion)
                    cmdSave.Parameters.AddWithValue("@token", txtUserAccessToken.Text)
                    cmdSave.Parameters.AddWithValue("@version", cmbVersion.SelectedItem.ToString())
                    cmdSave.Parameters.AddWithValue("@phone", txtPhoneNumberId.Text)
                    cmdSave.Parameters.AddWithValue("@url", TextUrl.Text)

                    cmdSave.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Guardado con éxito", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error, Verificar la conexión con la Base de datos", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Agregar versiones disponibles en el ComboBox
        cmbVersion.Items.Add("v22.0")
        cmbVersion.Items.Add("v21.0")
        cmbVersion.Items.Add("v20.0")
        cmbVersion.Items.Add("v19.0")
        cmbVersion.Items.Add("v18.0")

        ' Seleccionar por defecto la primera versión
        cmbVersion.SelectedIndex = 0
    End Sub

    Private Sub txtUserAccessToken_TextChanged_1(sender As Object, e As EventArgs) Handles txtUserAccessToken.TextChanged
        txtUserAccessToken.Multiline = True
        txtUserAccessToken.ScrollBars = ScrollBars.Vertical ' o ScrollBars.Both
        txtUserAccessToken.WordWrap = True ' Para evitar saltos de línea automáticos
        txtUserAccessToken.AcceptsReturn = False ' Para no permitir retornos de carro   
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class

