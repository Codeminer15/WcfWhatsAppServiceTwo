Imports System.IO
Imports System.Net
Imports System.ServiceModel
Imports System.Text
Imports MainForm.ServiceWhatsAppCloudApi


Public Class WhasAppForm
    ' Constante para TLS 1.2 (no disponible directamente en .NET 3.5)
    Private Const Tls12 As SecurityProtocolType = CType(&HC00, SecurityProtocolType)
    Private ReadOnly logPath As String = "C:\Logs\WhatsAppService.log" 'Crear Carpeta si no se ha creado
    Private rutaLocalGit As String = "D:\Projects\Facturas_Prueba" ' Ruta donde está el repo
    Private urlGitHub As String = "https://github.com/codeminer15/Facturas_Prueba/"

    ' Endpoints disponibles para probar - Solo Test
    Private ReadOnly endpoints As New List(Of String) From {
        "http://localhost/svcWebService/Service1.svc",
        "https://localhost:50721/svcWebService/Service1.svc"
    }
    Public Sub New(nombre As String, telefono As String, xml As String, pdf As String, state As String)
        InitializeComponent()
        ApplyStyles() ' Aplicar estilos desde la clase helper
        ' Asignar los valores a los controles del formulario
        txtName.Text = nombre
        txtPhoneNumber.Text = telefono
        lblPdf.Text = xml
        lblXml.Text = pdf
        lblState.Text = state
    End Sub

    Private Sub ApplyStyles()
        ' Aplicar estilos del formulario
        UIHelpers.ApplyFormStyles(Me)

        ' Aplicar estilos a controles específicos
        UIHelpers.StyleTextBox(txtName)
        UIHelpers.StyleTextBox(txtPhoneNumber)

        UIHelpers.StyleButton(btnSendWhatsApp, Color.FromArgb(0, 122, 204))
        UIHelpers.StyleButton(btnTestConnection, Color.FromArgb(16, 110, 190))
        UIHelpers.StyleButton(btnViewLogs, Color.FromArgb(100, 100, 100))
        UIHelpers.StyleButton(BtnCancel, Color.FromArgb(220, 53, 69))

        ' Agregar tooltips
        UIHelpers.AddToolTip(btnTestConnection, "Verificar conexión con el servicio")
        UIHelpers.AddToolTip(btnViewLogs, "Ver registro de actividades")
        UIHelpers.AddToolTip(BtnCancel, "Cancelar y cerrar")
        UIHelpers.AddToolTip(btnSendWhatsApp, "Enviar mensaje por WhatsApp")
    End Sub

    Private Sub BtnSendWhatsApp_Click(sender As Object, e As EventArgs) Handles btnSendWhatsApp.Click

        ' Validar datos básicos primero
        If String.IsNullOrEmpty(txtPhoneNumber.Text) OrElse String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Por favor ingrese el número y nombre del cliente", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Normalizar el número eliminando espacio y caracteres no númericos
        Dim phonenumber As String = New String(txtPhoneNumber.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        'Validar longitud del número
        If phonenumber.Length <> 12 Then
            MessageBox.Show("El número de teléfono debe tener 12 dígitos.", "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Obtener rutas originales de los archivos
        Dim rutaXML As String = lblXml.Text
        Dim rutaPDF As String = lblPdf.Text

        ' Verificar que los archivos existen localmente
        If Not File.Exists(rutaXML) Or Not File.Exists(rutaPDF) Then
            MessageBox.Show("No se encontraron los archivos en las rutas especificadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Obtener solo los nombres de los archivos
        Dim nombreXML As String = Path.GetFileName(rutaXML)
        Dim nombrePDF As String = Path.GetFileName(rutaPDF)

        ' Verificar si los archivos ya están en GitHub
        Dim archivosEnGitHub As Boolean = VerificarArchivosEnGitHub(nombreXML, nombrePDF)

        If Not archivosEnGitHub Then
            ' Si no están en GitHub, subirlos
            If Not SubirArchivosAGitHub(rutaXML, rutaPDF) Then
                MessageBox.Show("No se pudieron subir los archivos a GitHub", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' Desmarcar los checkboxes si hay error
                CheckBoxPdf.Checked = False
                CheckBoxXml.Checked = False
                Return
            End If
        End If

        ' Marcar los checkboxes como verificados
        CheckBoxPdf.Checked = True
        CheckBoxXml.Checked = True

        ' Validar que ambos checkboxes estén marcados
        If Not CheckBoxPdf.Checked Or Not CheckBoxXml.Checked Then
            MessageBox.Show("Por favor, verifique que ambos documentos han sido subidos a GitHub marcando las casillas correspondientes.",
                       "Documentos no verificados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Actualizar las etiquetas con las URLs de GitHub
        lblXGH.Text = urlGitHub & nombreXML
        lblPGH.Text = urlGitHub & nombrePDF

        ' Enviar el mensaje por WhatsApp
        EnviarMensajeWhatsApp(txtPhoneNumber.Text.Trim(), txtName.Text.Trim(), nombrePDF, nombreXML)


    End Sub
    Private Function VerificarArchivosEnGitHub(nombreXML As String, nombrePDF As String) As Boolean
        Try
            ' Verificar si los archivos existen en el repositorio local (que debería estar sincronizado con GitHub)
            Dim rutaCompletaXML As String = Path.Combine(rutaLocalGit, nombreXML)
            Dim rutaCompletaPDF As String = Path.Combine(rutaLocalGit, nombrePDF)

            Return File.Exists(rutaCompletaXML) AndAlso File.Exists(rutaCompletaPDF)
        Catch ex As Exception
            ' Si hay algún error, asumimos que no están en GitHub
            Return False
        End Try
    End Function

    Private Function SubirArchivosAGitHub(rutaXML As String, rutaPDF As String) As Boolean
        Try
            Dim nombreXML As String = Path.GetFileName(rutaXML)
            Dim nombrePDF As String = Path.GetFileName(rutaPDF)

            ' Copiar archivos al repositorio local
            File.Copy(rutaXML, Path.Combine(rutaLocalGit, nombreXML), True)
            File.Copy(rutaPDF, Path.Combine(rutaLocalGit, nombrePDF), True)

            ' Sincronizar con GitHub
            EjecutarComandoGit("git pull --rebase")
            EjecutarComandoGit("git add .")
            EjecutarComandoGit($"git commit -m ""Subida automática de factura {nombrePDF}""")
            EjecutarComandoGit("git push origin main")

            Return True
        Catch ex As Exception
            MessageBox.Show($"Error al subir archivos a GitHub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub EjecutarComandoGit(comando As String)
        Dim proceso As New Process()
        proceso.StartInfo.FileName = "cmd.exe"
        proceso.StartInfo.WorkingDirectory = rutaLocalGit
        proceso.StartInfo.Arguments = "/c " & comando
        proceso.StartInfo.RedirectStandardOutput = True
        proceso.StartInfo.UseShellExecute = False
        proceso.StartInfo.CreateNoWindow = True
        proceso.Start()
        proceso.WaitForExit()
    End Sub

    Private Sub EnviarMensajeWhatsApp(phoneNumber As String, customerName As String, fileNamePdf As String, fileNameXml As String)

        Try
            ' Configurar el proxy para Fiddler
            Dim proxy As New WebProxy("127.0.0.1", 8888)

            ' Configurar la solicitud HTTP - Crea una solicitud HTTP manual
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://localhost/svcWebService/Service1.svc/SendTemplateBillingMessage"), HttpWebRequest)
            request.Proxy = proxy

            ' Configura método Post y headers
            request.Method = "POST"
            request.ContentType = "application/json"

            ' Configurar TLS si es necesario
            ServicePointManager.SecurityProtocol = CType(48 Or 192 Or 768 Or 3072, SecurityProtocolType)
            ServicePointManager.ServerCertificateValidationCallback =
        Function(sender, certificate, chain, sslPolicyErrors) True

            ' Crear el JSON manualmente y serealizar
            Dim jsonPayload As String = String.Format(
        "{{""phoneNumber"":""{0}"",""customerName"":""{1}"",""fileNamePdf"":""{2}"",""fileNameXml"":""{3}""}}",
        phoneNumber, customerName, fileNamePdf, fileNameXml)

            ' Convertir a bytes
            Dim data As Byte() = Encoding.UTF8.GetBytes(jsonPayload)
            request.ContentLength = data.Length

            'Enviar datos
            Using stream As Stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using

            ' Obtener respuesta
            Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim responseText As String = reader.ReadToEnd()
                    MessageBox.Show("Mensaje enviado: " & responseText, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using

        Catch ex As WebException
            Dim errorMessage As String = "Error al enviar mensaje: "
            If ex.Response IsNot Nothing Then
                Using reader As New StreamReader(ex.Response.GetResponseStream())
                    errorMessage &= reader.ReadToEnd()
                End Using
            Else
                errorMessage &= ex.Message
            End If
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error general: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Pruebas de llamadas al servicio a través de la url donde se aloja
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        ' Lista de endpoints a probar
        Dim endpoints As New List(Of String) From {
            "http://localhost/svcWebService/Service1.svc",
            "https://localhost:50721/svcWebService/Service1.svc"
        }

        lblServiceStatus.Text = "Probando conexión..."
        Application.DoEvents() ' Actualiza la UI inmediatamente

        Dim serviceAvailable As Boolean = False
        Dim activeEndpoint As String = ""

        For Each endpoint In endpoints
            If TestServiceConnection(endpoint) Then
                serviceAvailable = True
                activeEndpoint = endpoint
                Exit For
            End If
        Next

        If serviceAvailable Then
            lblServiceStatus.Text = $"Conectado a: {activeEndpoint}"
            lblServiceStatus.ForeColor = Color.Green
        Else
            lblServiceStatus.Text = "Servicio no disponible"
            lblServiceStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Function TestServiceConnection(endpointAddress As String) As Boolean
        Dim binding As BasicHttpBinding = Nothing

        Try
            ' Configurar el binding según el protocolo
            If endpointAddress.StartsWith("https") Then
                binding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
                ' Configuración TLS para .NET 3.5
                ServicePointManager.SecurityProtocol = CType(&H30 Or &HC0 Or &H300 Or &HC00, SecurityProtocolType)
                ServicePointManager.ServerCertificateValidationCallback =
                    Function(sender, certificate, chain, sslPolicyErrors) True
            Else
                binding = New BasicHttpBinding(BasicHttpSecurityMode.None)
            End If

            ' Configurar timeouts cortos para la prueba
            binding.OpenTimeout = TimeSpan.FromSeconds(5)
            binding.ReceiveTimeout = TimeSpan.FromSeconds(5)
            binding.SendTimeout = TimeSpan.FromSeconds(5)

            ' Crear cliente de prueba
            Using client As New Service1Client(binding, New EndpointAddress(endpointAddress))
                client.Open()
                Return client.State = CommunicationState.Opened
            End Using

        Catch ex As Exception
            Debug.WriteLine($"Error probando conexión a {endpointAddress}: {ex.Message}")
            Return False
        End Try
    End Function

    ' Método para escribir en el log
    Private Sub WriteLog(message As String)
        Try
            Dim logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}"
            File.AppendAllText(logPath, logMessage)
        Catch ex As Exception
            ' Si falla el logging, no hacer nada para no interrumpir el flujo
        End Try
    End Sub

    ' Método mejorado para probar conexiones
    Private Function TestServiceConnectionDetailed(endpoint As String) As Boolean
        Dim binding As BasicHttpBinding = Nothing

        Try
            WriteLog($"Iniciando prueba de conexión a {endpoint}")

            If endpoint.StartsWith("https") Then
                binding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
                ServicePointManager.SecurityProtocol = CType(&H30 Or &HC0 Or &H300 Or &HC00, SecurityProtocolType)
                ServicePointManager.ServerCertificateValidationCallback =
                    Function(sender, certificate, chain, sslPolicyErrors) True
                WriteLog("Configurado para HTTPS con TLS")
            Else
                binding = New BasicHttpBinding(BasicHttpSecurityMode.None)
                WriteLog("Configurado para HTTP")
            End If

            binding.OpenTimeout = TimeSpan.FromSeconds(5)
            binding.SendTimeout = TimeSpan.FromSeconds(5)

            Using client As New Service1Client(binding, New EndpointAddress(endpoint))
                WriteLog("Creando cliente WCF...")
                client.Open()

                If client.State = CommunicationState.Opened Then
                    WriteLog("Conexión exitosa")
                    Return True
                Else
                    WriteLog($"Estado inesperado: {client.State}")
                    Return False
                End If
            End Using
        Catch ex As Exception
            WriteLog($"ERROR en conexión: {ex.ToString()}")
            Return False
        End Try
    End Function

    Private Sub btnViewLogs_Click(sender As Object, e As EventArgs) Handles btnViewLogs.Click
        Try
            If File.Exists(logPath) Then
                Process.Start("notepad.exe", logPath)
            Else
                MessageBox.Show("El archivo de log no existe aún", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al abrir logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class