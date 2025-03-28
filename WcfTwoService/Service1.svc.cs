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

namespace WcfTwoService
{
	// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
	// NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
	public class Service1 : IService1
	{
        public Service1()
        {
            // Habilita TLS 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2
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

// Clases para serialización JSON
[DataContract]
public class WhatsAppMessage
{
    [DataMember(Name = "messaging_product")]
    public string Messaging_product { get; set; }

    [DataMember(Name = "to")]
    public string To { get; set; }

    [DataMember(Name = "template")]
    public Template Template { get; set; }
}

[DataContract]
public class Template
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "language")]
    public Language Language { get; set; }
}

[DataContract]
public class Language
{
    [DataMember(Name = "code")]
    public string Code { get; set; }
}
