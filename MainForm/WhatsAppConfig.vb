
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
                        SET UserAccessToken = @token, Version = @version, PhoneNumberId = @phone
                    ELSE
                        INSERT INTO UrlConfig (UserAccessToken, Version, PhoneNumberId)
                        VALUES (@token, @version, @phone);
                 "
                Using cmdSave As New SqlCommand(querySave, conexion)
                    cmdSave.Parameters.AddWithValue("@token", txtUserAccessToken.Text)
                    cmdSave.Parameters.AddWithValue("@version", cmbVersion.SelectedItem.ToString())
                    cmdSave.Parameters.AddWithValue("@phone", txtPhoneNumberId.Text)

                    cmdSave.ExecuteNonQuery()
                End Using
            End Using

            LblMsg.Text = "Estado: Guardado con éxito"
            LblMsg.ForeColor = Color.Green
        Catch ex As Exception
            LblMsg.Text = "Estado: Error - " & ex.Message
            LblMsg.ForeColor = Color.Red
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
End Class