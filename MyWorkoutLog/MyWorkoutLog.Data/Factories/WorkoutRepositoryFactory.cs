using MyWorkoutLog.Data.Interfaces;
using MyWorkoutLog.Data.Repos;
using MyWorkoutLog.Models.Models;
using MyWorkoutLog.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkoutLog.Data.Factories
{
    public class WorkoutRepositoryFactory
    {
        public static IWorkoutRepo GetWorkoutRepo()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new WorkoutRepoADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");


            }
        }
    }
}
