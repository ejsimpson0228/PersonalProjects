using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Models.ViewModels
{
    public class MyTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TypeName { get; set; }
        public int? CompleteEveryNumber { get; set; }
        public string CompleteEveryTimeUnit { get; set; }
        public int? DurationNumber { get; set; }
        public string DurationUnit { get; set; }
        public DateTime? DueDate { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string UserId { get; set; }
        public bool IsComplete { get; set; }
    }
}
