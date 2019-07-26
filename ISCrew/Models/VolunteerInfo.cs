using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISCrew.Models
{
    public class VolunteerInfo
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string passsword { get; set; }
        public string[] centers { get; set; }
        public string[] skills { get; set; }
        public string[] interests { get; set; }
        public DateTime[] availablity { get; set; }
        //^work on a sensible way to do this
        public string address { get; set; }
        public string edubackground { get; set; }
        public string phone { get; set;}
        public string licenses { get; set; }
        public string emgname { get; set; }
        public string emgphone { get; set; }
        public string email { get; set; }
        public string emgaddress { get; set; }
        public bool? licensecopy { get; set; }
        public bool? sscopy { get; set; }
        public bool? approvalstatus { get; set; }

    }
}
