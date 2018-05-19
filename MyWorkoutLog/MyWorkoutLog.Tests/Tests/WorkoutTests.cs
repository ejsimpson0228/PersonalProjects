using MyWorkoutLog.Data;
using MyWorkoutLog.Data.Factories;
using MyWorkoutLog.Models.Models;
using MyWorkoutLog.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Tests.Tests
{
    [TestFixture]
    public class WorkoutTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanGetCurrentWorkoutForUser()
        {
            var workoutRepo = WorkoutRepositoryFactory.GetWorkoutRepo();
            Workout workout = workoutRepo.GetCurrentWorkoutForUser("8f4b02ca-4134-451c-ab5e-bd73c6a723b2");

            Assert.AreEqual(2, workout.WorkoutId);
            Assert.AreEqual("Cardio Madhouse", workout.WorkoutName);
            Assert.AreEqual(3, workout.DaysPerWeek);
            Assert.AreEqual(new DateTime(2018, 3, 25), workout.StartDate);
            Assert.IsTrue(workout.IsCurrent);
            Assert.AreEqual("8f4b02ca-4134-451c-ab5e-bd73c6a723b2", workout.UserId);
            
        }

        [Test]
        public void CanGetExercisesForWorkout()
        {
            var workoutRepo = WorkoutRepositoryFactory.GetWorkoutRepo();
            Workout workout = workoutRepo.GetCurrentWorkoutForUser("8f4b02ca-4134-451c-ab5e-bd73c6a723b2");
            workout.Exercises = workoutRepo.GetExercisesForWorkout(workout.WorkoutId).ToList();

            Assert.AreEqual(3, workout.Exercises.Count);
            Assert.AreEqual(5, workout.Exercises[0].ExerciseId);
            Assert.AreEqual("Jogging", workout.Exercises[0].ExerciseName);
            Assert.AreEqual(false, workout.Exercises[0].TracksSets);
            Assert.AreEqual(false, workout.Exercises[0].TracksReps);
            Assert.AreEqual(true, workout.Exercises[0].TracksTime);
            Assert.AreEqual(true, workout.Exercises[0].TracksDistance);
            Assert.AreEqual(false, workout.Exercises[0].TracksWeight);
            Assert.AreEqual("8f4b02ca-4134-451c-ab5e-bd73c6a723b2", workout.Exercises[0].UserId);
            Assert.AreEqual(1, workout.Exercises[0].Day);
        }

        [Test]
        public void CanGetLastWorkoutForUser()
        {
            var workoutRepo = WorkoutRepositoryFactory.GetWorkoutRepo();
            Workout workout = workoutRepo.GetLastWorkoutForUser("8f4b02ca-4134-451c-ab5e-bd73c6a723b2");
            //workout.Exercises = workoutRepo.GetExercisesForWorkout(workout.WorkoutId).ToList();

            Assert.AreEqual(1, workout.WorkoutId);
            Assert.AreEqual("Beast Destroyer", workout.WorkoutName);
            Assert.AreEqual(4, workout.DaysPerWeek);
            Assert.AreEqual(new DateTime(2018,03,18), workout.StartDate);
            Assert.AreEqual(false, workout.IsCurrent);
            Assert.AreEqual("8f4b02ca-4134-451c-ab5e-bd73c6a723b2", workout.UserId);
        }

        [Test]
        public void CanGetWorkoutDatesForUser()
        {
            var workoutRepo = WorkoutRepositoryFactory.GetWorkoutRepo();
            Dictionary<int, DateTime> workoutDates = workoutRepo.GetWorkoutDatesForUser("8f4b02ca-4134-451c-ab5e-bd73c6a723b2");

            Assert.AreEqual(3, workoutDates.Count);
            Assert.AreEqual(new DateTime(2018, 03, 25), workoutDates[2]);
        }



    }
}
