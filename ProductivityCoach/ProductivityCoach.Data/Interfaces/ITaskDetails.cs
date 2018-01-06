using ProductivityCoach.Models.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Data.Interfaces
{
    public interface ITaskDetails
    {
        IEnumerable<ProductivityCoach.Models.Details.Type> GetTaskTypes();
        IEnumerable<Duration> GetDurationsUnits();
        IEnumerable<Time> GetTimeUnits();
    }
}
