Imports System.Data.SqlClient

Public Class Form1
    Private Sub BtnSendMessageWindow_Click(sender As Object, e As EventArgs) Handles BtnSendMessageWindow.Click

        Dim idCliente As Integer

        ' Obtener el ID del cliente ingresado en el TextBox
        If Not Integer.TryParse(txtIdCliente.Text, idCliente) Then
            MessageBox.Show("Ingrese un ID de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Consultar la base de datos para obtener los datos del cliente y la factura
        Dim nombreCliente As String = ""
        Dim telefono As String = ""
        Dim rutaXML As String = ""
        Dim rutaPDF As String = ""
        Dim state As String = ""

        Using conexion As SqlConnection = GetConnection()
            Try
                conexion.Open()
                Dim query As String = "SELECT c.Nombre, c.Telefono, f.RutaXML, f.RutaPDF " &
                                      "FROM Clientes c INNER JOIN Factura f ON c.Id = f.IdCliente " &
                                      "WHERE c.Id = @IdCliente"

                Using cmd As New SqlCommand(query, conexion)
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            nombreCliente = reader("Nombre").ToString()
                            telefono = reader("Telefono").ToString()
                            rutaXML = reader("RutaXML").ToString()
                            rutaPDF = reader("RutaPDF").ToString()
                        Else
                            MessageBox.Show("No se encontraron datos para este cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al obtener los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End Using

        ' Verificar si los archivos existen en la ruta
        Dim xmlExiste As Boolean = System.IO.File.Exists(rutaXML)
        Dim pdfExiste As Boolean = System.IO.File.Exists(rutaPDF)

        ' Mostrar estado de los archivos en un Label
        If xmlExiste AndAlso pdfExiste Then
            state = "Estado: Archivos disponibles"
        Else
            state = "Estado: Archivos no encontrados"
        End If

        ' Abrir el formulario whatsappForm y pasar los datos
        Dim whatsAppForm As New WhasAppForm(nombreCliente, telefono, rutaXML, rutaPDF, state)
        whatsAppForm.ShowDialog()

    End Sub

    Private Sub BtnSetting_Click(sender As Object, e As EventArgs) Handles BtnSetting.Click
        Dim whatsAppConfig As New WhatsAppConfig()

        whatsAppConfig.ShowDialog()

    End Sub
End Class
