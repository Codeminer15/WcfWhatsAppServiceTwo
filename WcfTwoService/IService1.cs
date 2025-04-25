using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTwoService
{
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
    }
}
