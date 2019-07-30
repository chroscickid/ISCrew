using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISCrew.Models
{
    public class FakeRepository : VolunteerRepository
    {
        public IEnumerable<VolunteerInfo> VolunteerInformation => new List<VolunteerInfo>
        {
            new VolunteerInfo { firstname = "David" , lastname = "Chroscicki" , address = "UNF"}
        };
    }
}
