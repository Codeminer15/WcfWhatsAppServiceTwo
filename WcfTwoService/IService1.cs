using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTwoService
{
	// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
	[ServiceContract]
	public interface IService1
	{

        [OperationContract]
        [WebInvoke(Method = "POST",
               UriTemplate = "SendTemplateMessage",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Wrapped)] // Añade esta línea
        string SendTemplateMessage(string phoneNumber, string token, string templateId);
    }
}
