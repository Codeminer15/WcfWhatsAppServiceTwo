using System;
using System.IO;
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
               BodyStyle = WebMessageBodyStyle.Wrapped)] 
        string SendTemplateMessage(string phoneNumber, string token, string templateId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "SendTemplateBillingMessage",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string SendTemplateBillingMessage(string phoneNumber, string customerName, string fileNamePdf, string fileNameXml);

        // Método para verificar el webhook (GET)
        [OperationContract]
        [WebGet(UriTemplate = "webhook?hub.mode={hub_mode}&hub.verify_token={hub_verify_token}&hub.challenge={hub_challenge}", ResponseFormat = WebMessageFormat.Json)]
        Stream VerifyWebhook(string hub_mode, string hub_verify_token, string hub_challenge);

        // Método para recibir notificaciones (POST)
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "webhook", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ReceiveNotification(string payload);
    }
}
