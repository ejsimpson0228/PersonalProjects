using ProductivityCoach.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Data.ADORepository
{
    public class ProgressRepo : IProgressRepo
    {
        public void UpdateTotalTime(int taskId, TimeSpan? totalTime)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateTotalTime", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskId", taskId);
                cmd.Parameters.AddWithValue("@TotalTime", totalTime);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
