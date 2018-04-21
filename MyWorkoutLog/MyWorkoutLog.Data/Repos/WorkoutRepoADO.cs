using MyWorkoutLog.Data.Interfaces;
using MyWorkoutLog.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Data.Repos
{
    public class WorkoutRepoADO : IWorkoutRepo
    {
        public Workout GetCurrentWorkoutForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Workout GetHistoricalWorkout(DateTime dateOfWorkout)
        {
            throw new NotImplementedException();
        }

        public Workout GetLastWorkoutForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> GetWorkoutDatesForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public void MakeWorkoutCurrent(int workoutId)
        {
            throw new NotImplementedException();
        }
    }
}
