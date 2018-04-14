using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Models.Models
{
    public class ExerciseDetails
    {
        public int ExerciseDetailsId { get; set; }
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public DateTime Time { get; set; }
        public decimal Distance { get; set; }
        public string DistanceUnit { get; set; }
        public int Weight { get; set; }
    }
}
