using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Models.ViewModels
{
    public class WorkoutExercisesViewModel
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime StartDate { get; set; }
        public int DaysPerWeek { get; set; }
        public int ExerciseDay { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public bool TracksDistance { get; set; }
        public bool TracksReps { get; set; }
        public bool TracksSets { get; set; }
        public bool TracksTime { get; set; }
        public bool TracksWeight { get; set; }
        public int ExerciseDetailsId { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Distance { get; set; }
        public string DistanceUnit { get; set; }
        public int? Weight { get; set; }
    }
}
