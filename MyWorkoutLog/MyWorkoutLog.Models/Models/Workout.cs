using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Models.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public int DaysPerWeek { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCurrent { get; set; }
        public string UserId { get; set; }
    }
}
