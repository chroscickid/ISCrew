using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISCrew.Models
{
   public interface VolunteerRepository
    {
        IEnumerable<VolunteerInfo> VolunteerInformation { get; }
    }
}
