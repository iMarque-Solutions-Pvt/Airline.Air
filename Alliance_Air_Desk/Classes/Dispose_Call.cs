using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Alliance_Air_Desk.Classes
{
    [Serializable]
    public class Dispose_Call
    {
        public delegate void DisposeAsync1(string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string sessionId, string phone, string dispositionCode, string dispositionAttr, string process);

        public void DialerDisposition(string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string sessionId, string phone, string dispositionCode, string dispositionAttr, string process)
        {
            DisposeAsync1 AsyncDisp = new DisposeAsync1(this.TagToDialer);
            AsyncDisp.Invoke(campaignId, crtObjectId, userCrtObjectId, customerId, sessionId, phone, dispositionCode, dispositionAttr, process);
        }

        public void TagToDialer(string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string sessionId, string phone, string dispositionCode, string dispositionAttr, string process)
        {
            try
            {
                WebClient client = new WebClient();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                string baseURL = "http://10.1.10.20:8888/dacx/dispose?phone=" + phone + "&campaignId=" + campaignId + "&crtObjectId=" + crtObjectId + "&userCrtObjectId=" + userCrtObjectId + "&customerId=" + customerId + "&dispositionCode=" + dispositionCode + "&dispositionAttr=local-" + dispositionAttr + "&sessionId=" + sessionId + "&selfCallback=true";
                client.OpenRead(baseURL);
                string jsonResponse = client.DownloadString(baseURL);

                Classes.CreateLogFiles log = new Classes.CreateLogFiles();
                log.WriteToFile(phone + " : " + baseURL + " : " + DateTime.Now.ToString(), process);


            }
            catch (WebException ex)
            {
                Classes.CreateLogFiles log = new Classes.CreateLogFiles();
                log.WriteToFile(dispositionCode + " : " + ex.Message.ToString() + " : " + DateTime.Now.ToString(), process);
            }
        }
    }
}