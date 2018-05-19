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
                        workout.DaysPerWeek = (int)dr["DaysPerWeek"];
                        workout.StartDate = (DateTime)dr["StartDate"];
                        workout.IsCurrent = (bool)dr["IsCurrent"];
                        workout.UserId = dr["UserId"].ToString();
                    }
                }
            }

            return workout;
        }

        public IEnumerable<Exercise> GetExercisesForWorkout(int workoutId)
        {
            List<Exercise> exercises = new List<Exercise>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spGetExercisesForWorkout", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WorkoutId", workoutId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Exercise exercise = new Exercise();
                        exercise.ExerciseId = (int)dr["ExerciseId"];
                        exercise.ExerciseName = dr["ExerciseName"].ToString();
                        exercise.TracksSets = (bool)dr["TracksSets"];
                        exercise.TracksReps = (bool)dr["TracksReps"];
                        exercise.TracksTime = (bool)dr["TracksTime"];
                        exercise.TracksDistance = (bool)dr["TracksDistance"];
                        exercise.TracksWeight = (bool)dr["TracksWeight"];
                        exercise.UserId = dr["UserId"].ToString();
                        exercise.Day = (int)dr["Day"];

                        exercises.Add(exercise);
                    }
                }
            }
            return exercises;
        }

        public Workout GetHistoricalWorkout(DateTime dateOfWorkout)
        {
            throw new NotImplementedException();
        }

        public Workout GetLastWorkoutForUser(string userId)
        {
            Workout workout = new Workout();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spGetLastWeeksWorkoutForUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        workout.WorkoutId = (int)dr["WorkoutId"];
                        workout.WorkoutName = dr["WorkoutName"].ToString();
                        workout.DaysPerWeek = (int)dr["DaysPerWeek"];
                        workout.StartDate = (DateTime)dr["StartDate"];
                        workout.IsCurrent = (bool)dr["IsCurrent"];
                        workout.UserId = dr["UserId"].ToString();
                    }
                }
                return workout;
            }
        }

        public Dictionary<int,DateTime> GetWorkoutDatesForUser(string userId)
        {
            Dictionary<int, DateTime> WorkoutDates = new Dictionary<int, DateTime>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spGetWorkoutDatesForUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int workoutId = (int)dr["WorkoutId"];
                        DateTime workoutDate = (DateTime)dr["StartDate"];

                        WorkoutDates.Add(workoutId, workoutDate);
                    }
                }
                return WorkoutDates;
            }
        }

        public void MakeWorkoutCurrent(int workoutId, string userId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spMakeWorkoutActive", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
