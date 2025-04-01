using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.UI;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.ServiceModel.Web;
using System.CodeDom;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace WcfTwoService
{
	// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
	// NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
	public class Service1 : IService1
	{
        
        public Service1()
        {
            // Habilitar TLS 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            // Inicializa la configuración (se carga automáticamente al primer acceso)
            try
            {
                WhatsAppConfig.EnsureInitialized();
                
                // Opcional: Test de conexión a BD al iniciar
                using (SqlConnection conn = new SqlConnection(WhatsAppConfig.ConnectionString))
                {
                    conn.Open();
                    // Si llega aquí, la conexión es exitosa
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en constructor Service1: " + ex.ToString());
            }
        }

         public string SendTemplateBillingMessage(string phoneNumber, string customerName, string fileNamePdf, string fileNameXml)
        {
            try
            {
                WhatsAppConfig.EnsureInitialized(); // Doble verificación por seguridad
                string accessToken = WhatsAppConfig.AccessToken;

                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new ApplicationException("No se pudo obtener el token de acceso");
                }
                // Valores por defecto (puedes parametrizarlos si es necesario)
                return SendMessage(
                    accessToken: accessToken,
                    templateName: "efact_test",
                    recipientName: customerName,
                    fileNamePdf: fileNamePdf,
                    fileNameXml: fileNameXml,
                    phoneNumber: phoneNumber);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en SendTemplateMessage: " + ex.ToString());
            }
        }

        private string SendMessage(string accessToken, string phoneNumber, string templateName, string recipientName, string fileNamePdf, string fileNameXml)
        {
            string apiUrl = $"{WhatsAppConfig.ApiUrl}/{WhatsAppConfig.Version}/{WhatsAppConfig.PhoneNumberId}/messages";

            var payload = new
            {
                messaging_product = "whatsapp",
                to = phoneNumber, // Considera hacer esto configurable
                type = "template",
                template = new
                {
                    name = templateName,
                    language = new { code = "es" },
                    components = new object[]
                    {
                        new
                        {
                            type = "body",
                            parameters = new object[]
                            {
                                new { type = "text", text = recipientName }
                            }
                        },
                        new
                        {
                            type = "button",
                            sub_type = "url",
                            index = "0",
                            parameters = new object[]
                            {
                                new { type = "text", text = fileNamePdf }
                            }
                        },
                        new
                        {
                            type = "button",
                            sub_type = "url",
                            index = "1",
                            parameters = new object[]
                            {
                                new { type = "text", text = fileNameXml }
                            }
                        }
                    }
                }
            };

            // Serialización con JavaScriptSerializer (nativo en .NET 3.5)
            string jsonPayload = new JavaScriptSerializer().Serialize(payload);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Bearer " + accessToken;

            byte[] data = Encoding.UTF8.GetBytes(jsonPayload);
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException webEx)
            {
                using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                    LogError($"Error WhatsApp API: {errorResponse}");
                    throw new ApplicationException($"Error al enviar mensaje: {errorResponse}");
                }
            }
        }
        private void LogError(string message)
        {
            try
            {
                string logPath = @"C:\Logs\WcfService_errors.txt";
                string logMessage = $"[{DateTime.Now}] {message}\n\n";
                File.AppendAllText(logPath, logMessage);
            }
            catch
            {
                // Si falla el logging, no hacer nada
            }
        }

        public string SendTemplateMessage(string phoneNumber, string token, string templateId)
        {
            try
            {
                // Construir la URL de la API
                string url = "https://graph.facebook.com/v22.0/410461155481036/messages";

                // Crear la solicitud HTTP
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json";

                // Crear el cuerpo del mensaje
                var message = new
                {
                    messaging_product = "whatsapp", // Campo obligatorio
                    to = phoneNumber,
                    type = "template", // Tipo de mensaje
                    template = new
                    {
                        name = templateId,
                        language = new { code = "en_US" } // Cambiar según el idioma de la plantilla
                    }
                };

                // Serializar el mensaje a JSON usando Newtonsoft.Json
                string json = JsonConvert.SerializeObject(message);

                // Escribir el JSON en el cuerpo de la solicitud
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(json);
                }

                // Enviar la solicitud y obtener la respuesta
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                // Manejar errores de la API
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        private const string VerifyToken = "JorgeMH"; // Token de verificación

        public Stream VerifyWebhook(string hub_mode, string hub_verify_token, string hub_challenge)
        {
            // Verifica que el token de verificación coincida
            if (hub_mode == "subscribe" && hub_verify_token == VerifyToken)
            {
                // Configura la respuesta como text/plain
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";

                // Devuelve el challenge como un Stream
                byte[] responseBytes = Encoding.UTF8.GetBytes(hub_challenge);
                return new MemoryStream(responseBytes);
            }

            // Si el token no coincide, devuelve un error 403
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Forbidden;
            return new MemoryStream(Encoding.UTF8.GetBytes("Token de verificacion no valido"));
        }

        public string ReceiveNotification(string payload)
        {
            // Procesa la notificación recibida
            Console.WriteLine("Notificación recibida: " + payload);

            // Aquí puedes agregar lógica para manejar la notificación

            // Devuelve una respuesta exitosa
            return "Notificación recibida correctamente";
        }
    }
}

