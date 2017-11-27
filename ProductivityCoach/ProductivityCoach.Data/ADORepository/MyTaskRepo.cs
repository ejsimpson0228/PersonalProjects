using ProductivityCoach.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityCoach.Models;
using System.Data.SqlClient;
using System.Data;
using ProductivityCoach.Models.ViewModels;

namespace ProductivityCoach.Data.ADORepository
{
    public class MyTaskRepo : IProductivityTaskRepo
    {
        public void AddTask(MyTask task)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddTask", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TaskId", SqlDbType.Int); 
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", task.UserId);
                cmd.Parameters.AddWithValue("@TypeName", task.TypeName);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@CompleteEveryNumber", task.CompleteEveryNumber);
                cmd.Parameters.AddWithValue("@CompleteEveryTimeUnit", task.CompleteEveryTimeUnit);
                cmd.Parameters.AddWithValue("@DurationNumber", task.DurationNumber);
                cmd.Parameters.AddWithValue("@DurationUnit", task.DurationUnit);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate);

                cn.Open();

                cmd.ExecuteNonQuery();

                task.TaskId = (int)param.Value;
            }
        }

        public void DeleteTask(int taskId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteTask", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskId", taskId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void EditTask(int taskId, MyTask task)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditTask", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskId", taskId);
                cmd.Parameters.AddWithValue("@TypeName", task.TypeName);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@CompleteEveryNumber", task.CompleteEveryNumber);
                cmd.Parameters.AddWithValue("@CompleteEveryTimeUnit", task.CompleteEveryTimeUnit);
                cmd.Parameters.AddWithValue("@DurationNumber", task.DurationNumber);
                cmd.Parameters.AddWithValue("@DurationUnit", task.DurationUnit);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public MyTask GetTask(int taskId)
        {
            MyTask task = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetTask", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskId", taskId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        task = new MyTask();
                        task.TaskId = (int)dr["TaskId"];
                        task.TaskName = dr["TaskName"].ToString();
                        task.TypeName = dr["TypeName"].ToString();
                        if (dr["CompleteEveryNumber"] != DBNull.Value)
                            task.CompleteEveryNumber = (int)dr["CompleteEveryNumber"];
                        else
                            task.CompleteEveryNumber = null;
                        if (dr["CompleteEveryTimeUnit"] != DBNull.Value)
                            task.CompleteEveryTimeUnit = dr["CompleteEveryTimeUnit"].ToString();
                        else
                            task.CompleteEveryTimeUnit = null;
                        if (dr["DurationNumber"] != DBNull.Value)
                            task.DurationNumber = (int)dr["DurationNumber"];
                        else
                            task.DurationNumber = null;
                        if (dr["DurationUnit"] != DBNull.Value)
                            task.DurationUnit = dr["DurationUnit"].ToString();
                        else
                            task.DurationUnit = null;
                        if (dr["DueDate"] != DBNull.Value)
                            task.DueDate = (DateTime)dr["DueDate"];
                        else
                            task.DueDate = null;
                        if (dr["TotalTime"] != DBNull.Value)
                            task.TotalTime = (TimeSpan)dr["TotalTime"];
                        else
                            task.TotalTime = null;
                        task.UserId = dr["UserId"].ToString();
                    }
                }
            }

            return task;
        }

        public IEnumerable<MyTask> GetTasksForUser(string UserId)
        {
            List<MyTask> tasks = new List<MyTask>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetTasksForUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", UserId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MyTask task = new MyTask();
                        task.TaskId = (int)dr["TaskId"];
                        task.TaskName = dr["TaskName"].ToString();
                        task.TypeName = dr["TypeName"].ToString();
                        if (dr["CompleteEveryNumber"] != DBNull.Value)
                            task.CompleteEveryNumber = (int)dr["CompleteEveryNumber"];
                        else
                            task.CompleteEveryNumber = null;
                        if (dr["CompleteEveryTimeUnit"] != DBNull.Value)
                            task.CompleteEveryTimeUnit = dr["CompleteEveryTimeUnit"].ToString();
                        else
                            task.CompleteEveryTimeUnit = null;
                        if (dr["DurationNumber"] != DBNull.Value)
                            task.DurationNumber = (int)dr["DurationNumber"];
                        else
                            task.DurationNumber = null;
                        if (dr["DurationUnit"] != DBNull.Value)
                            task.DurationUnit = dr["DurationUnit"].ToString();
                        else
                            task.DurationUnit = null;
                        if (dr["DueDate"] != DBNull.Value)
                            task.DueDate = (DateTime)dr["DueDate"];
                        else
                            task.DueDate = null;
                        if (dr["TotalTime"] != DBNull.Value)
                            task.TotalTime = (TimeSpan)dr["TotalTime"];
                        else
                            task.TotalTime = null;
                        task.UserId = dr["UserId"].ToString();

                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }
    }
    
}
