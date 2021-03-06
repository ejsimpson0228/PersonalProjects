﻿using MyWorkoutLog.Data.Factories;
using MyWorkoutLog.Models.Models;
using MyWorkoutLog.UI;
using MyWorkoutLog.Data;
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
    public class WorkoutTests2
    {
        [TestFixture]
        public class WorkoutTests
        {
            [SetUp]
            public void Init()
            {
                using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
                Settings.GetRepositoryType();
                var workoutRepo = WorkoutRepositoryFactory.GetWorkout();
                Workout workout = workoutRepo.GetCurrentWorkoutForUser("8f4b02ca-4134-451c-ab5e-bd73c6a723b2");

                Assert.AreEqual(2, workout.WorkoutId);
            }


        }
    }
}

