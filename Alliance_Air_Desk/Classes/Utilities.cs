using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Alliance_Air_Desk.Classes
{
    public class Utilities
    {
        public string CallWebService(string URL)
        {
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(URL);
            objRequest.Method = "GET";
            objRequest.KeepAlive = false;

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            string result = "";
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
        }
        public DateRange Get_Date_Range(string searchType, string stDate, string endDate)
        {
            DateRange _cls = new DateRange();

            if (searchType == null)
            {
                _cls.fromDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                _cls.toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
            }
            else if (searchType == "Today")
            {
                _cls.fromDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                _cls.toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
            }

            else if (searchType == "One Week")
            {
                _cls.fromDate = DateTime.Today.AddDays(-7).ToString("dd/MM/yyyy");
                _cls.toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
            }
            else if (searchType == "One Month")
            {
                _cls.fromDate = DateTime.Today.AddDays(-30).ToString("dd/MM/yyyy");
                _cls.toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
            }
            else if (searchType == "Three Months")
            {
                _cls.fromDate = DateTime.Today.AddDays(-90).ToString("dd/MM/yyyy");
                _cls.toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
            }
            else if (searchType == "Six Months")
            {
                _cls.fromDate = DateTime.Today.AddDays(-180).ToString("dd/MM/yyyy");
                _cls.toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
            }
            else if (searchType == "Custom")
            {

                _cls.fromDate = Convert.ToDateTime(stDate).ToString("dd/MM/yyyy");
                _cls.toDate = Convert.ToDateTime(endDate).ToString("dd/MM/yyyy");
            }
            return _cls;
        }
    }
}