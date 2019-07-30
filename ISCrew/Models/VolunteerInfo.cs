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

        //The following are the skills
        public Boolean cooking { get; set; }
        public Boolean building { get; set; }
        public Boolean arithmetic { get; set; }
        public Boolean painting { get; set; }
        public Boolean metalwork { get; set; }
        public Boolean driving { get; set; }
        public Boolean medical { get; set; }
        public Boolean computing { get; set; }
        public Boolean campaigning { get; set; }
        public Boolean sewing { get; set; }
        //end the list of skills

        //The following are the list of centers
        public Boolean habitatforhumanity { get; set; }
        public Boolean goodwill { get; set; }
        public Boolean humanesociety { get; set; }
        public Boolean redcross { get; set; }
        public Boolean hospice { get; set; }
        public Boolean volunteersofamerica { get; set; }
        public Boolean angelsforalison { get; set; }
        public Boolean cityrescuemission { get; set; }
        public Boolean agingtruth { get; set; }
        public Boolean ronaldmcdonaldhouse { get; set; }
        //end the list of centers

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
