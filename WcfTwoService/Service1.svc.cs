using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WcfTwoService
{
	public class Service1 : IService1
	{
        public Service1()
        {
            // Habilitar TLS 1.2 para mejorar la seguridad
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            
            try
            {
                // Inicializa la configuración cargando los parámetros desde la BD
                WhatsAppConfig.EnsureInitialized();
                
                // Test de conexión a BD al iniciar
                using (SqlConnection conn = new SqlConnection(WhatsAppConfig.ConnectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en constructor Service1: " + ex.ToString());
            }
        }
        /// Envía un mensaje de facturación utilizando una plantilla predefinida en WhatsApp.
        public string SendTemplateBillingMessage(string phoneNumber, string customerName, string fileNamePdf, string fileNameXml)
        {
            try
            {   // Asegura que la configuración está cargada
                WhatsAppConfig.EnsureInitialized(); 
                
                if (string.IsNullOrEmpty(WhatsAppConfig.AccessToken))
                {
                    throw new ApplicationException("No se pudo obtener el token de acceso");
                }
                // Valores por defecto
                return SendMessage(
                    WhatsAppConfig.AccessToken,
                    phoneNumber,
                    "efact_test",
                    customerName,
                    fileNamePdf,
                    fileNameXml
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Error en SendTemplateMessage: " + ex.ToString());
            }
        }

        /// Realiza la petición HTTP a la API de WhatsApp para enviar un mensaje usando la plantilla efact_test
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

            // Configuración de la solicitud HTTP
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Bearer " + accessToken;

            // Conversión del JSON a bytes para enviarlo en la petición
            byte[] data = Encoding.UTF8.GetBytes(jsonPayload);
            request.ContentLength = data.Length;

            // Envío de los datos en el cuerpo de la petición
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try // Captura la respuesta de la API de WhatsApp
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd(); // Devuelve la respuesta como cadena de texto
                }
            }
            catch (WebException webEx) // Captura errores en la respuesta HTTP
            {
                using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                    LogError($"Error WhatsApp API: {errorResponse}");
                    throw new ApplicationException($"Error al enviar mensaje: {errorResponse}");
                }
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

        /// Registra errores en un archivo de log
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
    }
}

