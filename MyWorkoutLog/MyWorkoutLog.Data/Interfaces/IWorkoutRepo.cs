using MyWorkoutLog.Models.Models;
using MyWorkoutLog.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Data.Interfaces
{
    public interface IWorkoutRepo
    {
        Workout GetCurrentWorkoutForUser(string userId);
        IEnumerable<Exercise> GetExercisesForWorkout(int workoutId);
        Workout GetLastWorkoutForUser(string userId);
        Dictionary<int, DateTime> GetWorkoutDatesForUser(string userId);
        Workout GetHistoricalWorkout(DateTime dateOfWorkout);
        void MakeWorkoutCurrent(int workoutId, string userId);
    }
}
