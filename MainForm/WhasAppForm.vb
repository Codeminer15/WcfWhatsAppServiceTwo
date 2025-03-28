Imports System.IO

Public Class WhasAppForm

    Private rutaLocalGit As String = "D:\Projects\Facturas_Prueba" ' Ruta donde está el repo
    Private urlGitHub As String = "https://github.com/codeminer15/Facturas_Prueba/"
    Public Sub New(nombre As String, telefono As String, xml As String, pdf As String, state As String)
        InitializeComponent()

        ' Asignar los valores a los controles del formulario
        txtName.Text = nombre
        txtPhoneNumber.Text = telefono
        lblPdf.Text = xml
        lblXml.Text = pdf
        lblState.Text = state
    End Sub

    Private Sub btnGitHub_Click(sender As Object, e As EventArgs) Handles btnGitHub.Click
        ' Obtener rutas locales
        Dim rutaXML As String = lblXml.Text
        Dim rutaPDF As String = lblPdf.Text

        ' Verificar que los archivos existen antes de subirlos
        If Not File.Exists(rutaXML) Or Not File.Exists(rutaPDF) Then
            MessageBox.Show("No se encontraron los archivos en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Copiar los archivos al repositorio local de GitHub
        Try
            File.Copy(rutaXML, Path.Combine(rutaLocalGit, Path.GetFileName(rutaXML)), True)
            File.Copy(rutaPDF, Path.Combine(rutaLocalGit, Path.GetFileName(rutaPDF)), True)

            ' Ejecutar git pull para traer los cambios más recientes
            EjecutarComandoGit("git pull --rebase")

            ' Ejecutar comandos Git para agregar, confirmar y subir archivos
            EjecutarComandoGit("git add .")
            EjecutarComandoGit("git commit -m ""Subida de factura desde VB.NET""")
            EjecutarComandoGit("git push origin main")

            ' Mostrar mensaje de éxito
            MessageBox.Show("Archivos subidos correctamente a GitHub.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Mostrar la URL pública de los archivos en etiquetas
            lblXGH.Text = urlGitHub & Path.GetFileName(rutaXML)
            lblPGH.Text = urlGitHub & Path.GetFileName(rutaPDF)

        Catch ex As Exception
            MessageBox.Show("Error al subir los archivos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Función para ejecutar comandos Git
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
End Class