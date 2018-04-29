using MyWorkoutLog.Data.Interfaces;
using MyWorkoutLog.Models.Models;
using MyWorkoutLog.Models.ViewModels;
using MyWorkoutLog.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWorkoutLog.UI;

namespace MyWorkoutLog.Data.Repos
{
    public class WorkoutRepoADO : IWorkoutRepo
    {
        public Workout GetCurrentWorkoutForUser(string userId)
        {
            Workout workout = new Workout();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spGetCurrentWeeklyWorkoutForUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        workout.WorkoutId = (int)dr["WorkoutId"];
                        workout.WorkoutName = dr["WorkoutName"].ToString();
                        workout.StartDate = (DateTime)dr["StartDate"];
                        workout.IsCurrent = (bool)dr["IsCurrent"];
                        workout.UserId = dr["UserId"].ToString();
                    }
                }
            }

            return workout;
        }

        public WorkoutExercisesViewModel GetExercisesForWorkout(int workoutId)
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
