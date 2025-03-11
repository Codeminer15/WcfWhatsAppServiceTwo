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
