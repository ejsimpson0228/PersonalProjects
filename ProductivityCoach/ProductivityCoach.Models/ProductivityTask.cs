using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Models
{
    public class ProductivityTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int? CompleteEveryNumber { get; set; }
        public int? CompleteEveryId { get; set; }
        public string CompleteEveryTimeUnit { get; set; }
        public int? DurationNumber { get; set; }
        public int? DurationTimeUnitId { get; set; }
        public string DurationTimeUnit { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? TotalTime { get; set; }
        public List<DateTime> DatesComplete { get; set; }
        public string UserId { get; set; }


    }
}
