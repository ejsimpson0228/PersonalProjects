using ProductivityCoach.Data.Interfaces;
using ProductivityCoach.Models.Details;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Data.ADORepository
{
    public class TaskDetails : ITaskDetails
    {
        public IEnumerable<Duration> GetDurationsUnits()
        {
            List<Duration> durationUnits = new List<Duration>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDurationUnits", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Duration duration = new Duration();
                        duration.DurationUnitId = (int)dr["DurationUnitId"];
                        duration.DurationUnit = dr["DurationUnit"].ToString();

                        durationUnits.Add(duration);
                    }
                }
            }

            return durationUnits;
        }

        public IEnumerable<ProductivityCoach.Models.Details.Type> GetTaskTypes()
        {
            List<Models.Details.Type> taskTypes = new List<Models.Details.Type>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetTaskTypes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Models.Details.Type type = new Models.Details.Type();
                        type.TypeId = (int)dr["TypeId"];
                        type.TypeName = dr["TypeName"].ToString();

                        taskTypes.Add(type);
                    }
                }
            }

            return taskTypes;
        }

        public IEnumerable<Time> GetTimeUnits()
        {
            List<Time> timeUnits = new List<Time>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetTimeUnits", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Time time = new Time();
                        time.CompleteEveryId = (int)dr["CompleteEveryId"];
                        time.CompleteEveryTimeUnit = dr["CompleteEveryTimeUnit"].ToString();

                        timeUnits.Add(time);
                    }
                }
            }

            return timeUnits;
        }
    }
}
