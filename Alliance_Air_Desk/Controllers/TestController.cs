using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //string GET_ORG_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=data&action=get_org");

            //dynamic data = JObject.Parse(GET_ORG_JSONresponse);
            ////string err = data.err_code;
            ////var origin1 = data.origin;
            //string err_code = data["err_code"].Value;            
            //var values = data["origin"];

            //List<SelectListItem> orgin_list = new List<SelectListItem>();
            //for (int i = 0; i < values.Count; i++)
            //{
            //    orgin_list.Add(new SelectListItem()
            //    {
            //        Text = values[i][1].Value,
            //        Value = values[i][0].Value
            //    });
            //}           
            //ViewBag.Orgin = orgin_list.ToList();

            /////////////////////////////////GET_DES///////////////////////////////////


            //string GET_DES_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=data&action=get_des");

            //dynamic data_dest = JObject.Parse(GET_DES_JSONresponse);
            //string dest_err_code = data_dest["err_code"].Value;
            //var dest_values = data_dest["destination"];

            //List<SelectListItem> destination_list = new List<SelectListItem>();
            //for (int i = 0; i < dest_values.Count; i++)
            //{
            //    destination_list.Add(new SelectListItem()
            //    {
            //        Text = dest_values[i][1].Value,
            //        Value = dest_values[i][0].Value
            //    });
            //}
            //ViewBag.Destination = destination_list.ToList();


            ////////////////////////////////////////////////////////////////////////////


            //string GET_DES_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=information&action=get_all_book_info_2&book_code=SP8VWX");
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(GET_DES_JSONresponse); 


            //dynamic data_dest = JObject.Parse(GET_DES_JSONresponse);
            //string dest_err_code = data_dest["err_code"].Value;
            //var dest_values = data_dest["destination"];

            //List<SelectListItem> destination_list = new List<SelectListItem>();
            //for (int i = 0; i < dest_values.Count; i++)
            //{
            //    destination_list.Add(new SelectListItem()
            //    {
            //        Text = dest_values[i][1].Value,
            //        Value = dest_values[i][0].Value
            //    });
            //}
            //ViewBag.Destination = destination_list.ToList();

            //string GET_DES_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=information&action=get_book_price_detail_info_2&book_code=SP8VWX");
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(GET_DES_JSONresponse); 

            //string GET_DES_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=data&action=get_org_des");
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(GET_DES_JSONresponse); 

            //string GET_DES_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=information&action=get_fare_v2_new&org=CGK&des=HKG&flight_no=Q1367&flight_date=20200717&return_flight=1&ret_flight_date=20200724&ret_flight_no=Q1368");
            //GET_FARE_V2_NEW myDeserializedClass = JsonConvert.DeserializeObject<GET_FARE_V2_NEW>(GET_DES_JSONresponse); 

            string GET_DES_JSONresponse = CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=data&action=get_nationality");
            GET_NATIONALITY myDeserializedClass = JsonConvert.DeserializeObject<GET_NATIONALITY>(GET_DES_JSONresponse);

            List<SelectListItem> nationality_list = new List<SelectListItem>();
            for (int i = 0; i < myDeserializedClass.nationality.Count; i++)
            {
                var group1 = new SelectListGroup() { Name = myDeserializedClass.nationality[i][0].Substring(0,1)};

                nationality_list.Add(new SelectListItem()
                {
                    
                    Text = myDeserializedClass.nationality[i][1],
                    Value = myDeserializedClass.nationality[i][0],
                    Group= group1

                });
            }


            ViewBag.Origin = nationality_list;
            return View();
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class GET_NATIONALITY
        {
            public string err_code { get; set; }
            public List<List<string>> nationality { get; set; }
        }


        public class GET_FARE_V2_NEW
        {
            public string err_code { get; set; }
            public string flight_date { get; set; }
            public string flight_no { get; set; }
            public int return_flight { get; set; }
            public string ret_flight_date { get; set; }
            public string ret_flight_no { get; set; }
            public string ret_org { get; set; }
            public string ret_des { get; set; }
            public List<List<object>> ret_fare_info { get; set; }
            public string org { get; set; }
            public string des { get; set; }
            public List<List<object>> fare_info { get; set; }
        }



        //public class Root
        //{
        //    public string err_code { get; set; }
        //    public List<List<object>> origin_destination { get; set; }
        //}

        //public class Root
        //{
        //    public string err_code { get; set; }
        //    public string book_code { get; set; }
        //    public string book_balance { get; set; }
        //    public string normal_sales { get; set; }
        //    public List<List<object>> detail_price { get; set; }
        //}

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

        private List<object> ConvertArrayToList(object[] array)
        {
            List<object> list = new List<object>();

            foreach (object obj in array)
                list.Add(obj);

            return list;
        }

        /// <summary>
        /// ///////////////////
        /// GET_ALL_BOOK_INFO_2
        /// // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        //public class Root
        //{
        //    public string err_code { get; set; }
        //    public string book_code { get; set; }
        //    public long num_code { get; set; }
        //    public string caller { get; set; }
        //    public int normal_sales { get; set; }
        //    public int book_balance { get; set; }
        //    public List<List<string>> pax_list { get; set; }
        //    public List<List<string>> route_info { get; set; }
        //    public List<List<string>> route_detail { get; set; }
        //    public List<List<string>> ssr_detail { get; set; }
        //    public List<List<object>> book_ancillary_fee { get; set; }
        //    public List<object> payment_history { get; set; }
        //    public string contact { get; set; }
        //    public string contact2 { get; set; }
        //    public string contact_email { get; set; }
        //    public string book_by { get; set; }
        //    public string book_office_by { get; set; }
        //    public string book_ccy { get; set; }
        //    public string org_des { get; set; }
        //    public string pay_limit { get; set; }
        //    public string create_time { get; set; }
        //}
        /// 
        /// 
        /// </summary>



        //////////////////////GET_FARE_V2_NEW//////////////////////


        public class get_fare
        {
            public string err_code { get; set; }
            public string flight_date { get; set; }
            public string flight_no { get; set; }
            public int return_flight { get; set; }
            public string ret_flight_date { get; set; }
            public string ret_flight_no { get; set; }
            public string ret_org { get; set; }
            public string ret_des { get; set; }
            public List<List<object>> ret_fare_info { get; set; }
            public string org { get; set; }
            public string des { get; set; }
            public List<List<object>> fare_info { get; set; }

        }


        public class ret_fare_info
        {
            public List<List<object>> MyArray { get; set; }
        }

        public class fare_info
        {
            public List<List<object>> MyArray { get; set; }
        }

        /////////////////////////////////////////////////////////////








        //string trimmedResponse = JSONresponse.Replace("[\"", "{\"").Replace("\"]", "\"}");

        //List<orgin> rows =
        //JsonConvert.DeserializeObject<List<orgin>>(JSONresponse)



        // string[,] famousCouples = new string[,]
        //{
        //  { "Adam", "Eve" },
        //  { "Bonnie", "Clyde" },
        //  { "Donald", "Daisy" },
        //  { "Han", "Leia" }
        //};

        //  string json = JsonConvert.SerializeObject(famousCouples, Formatting.Indented);
        //          // [
        //          //   ["Adam", "Eve"],
        //          //   ["Bonnie", "Clyde"],
        //          //   ["Donald", "Daisy"],
        //          //   ["Han", "Leia"]
        //          // ]

        //          string[,] deserialized = JsonConvert.DeserializeObject<string[,]>(json);

        //          Console.WriteLine(deserialized[3, 0] + ", " + deserialized[3, 1]);

        //          List<orgin> AuthorList = new List<orgin>();
























    }
}