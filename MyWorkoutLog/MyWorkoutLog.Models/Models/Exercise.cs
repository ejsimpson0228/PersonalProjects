using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Models.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public bool TracksSets { get; set; }
        public bool TracksReps { get; set; }
        public bool TracksTime { get; set; }
        public bool TracksDistance { get; set; }
        public bool TracksWeight { get; set; }
        public string UserId { get; set; }
        public int Day { get; set; }
    }
}
