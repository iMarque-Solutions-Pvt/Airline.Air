using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Classes
{
    [Serializable]
    public class UserDetails
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public int privilege { get; set; }
        public string designation { get; set; }
        public int region { get; set; }        
        public bool isMobileDevice { get; set; }
        public string sessionID { get; set; }
    }
}