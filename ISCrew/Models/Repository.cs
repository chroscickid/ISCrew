using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISCrew.Models
{
    public static class Repository
    {
        private static List<VolunteerInfo> forminfo = new List<VolunteerInfo>();
        public static IEnumerable<VolunteerInfo> FormInfo
        {
            get
            {
                return forminfo;
            }
        }
        public static void AddInfo(VolunteerInfo info)
        {
            forminfo.Add(info);
        }
    }
}
