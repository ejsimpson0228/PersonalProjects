using MyWorkoutLog.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Data.Interfaces
{
    public interface IExerciseRepo
    {
        IEnumerable<Exercise> GetUserExercises(string userId);
        void AddExerciseToWorkout(int exerciseId, int workoutId);
        void InputExerciseNumbers(int exerciseId, int? sets = null, int? reps = null,  DateTime? time = null, decimal? distance = null, int? weight = null);
        void AddExerciseToUserList(string userId, string exerciseName, bool tracksSets, bool tracksReps, bool tracksTime, bool tracksDistance, bool tracksWeight);
        void RemoveExerciseFromUserList(string userId, int exerciseId);
    }
}
