using NUnit.Framework;
using ProductivityCoach.Data.ADORepository;
using ProductivityCoach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Tests
{
    [TestFixture]
    public class ProgressTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection("Server=localhost;Database=ProductivityCoach;User Id=sa; Password=sqlserver"))
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
        public void CanUpdateTotalTime()
        {
            MyTaskRepo repo = new MyTaskRepo();
            MyTask task = repo.GetTask(3);

            ProgressRepo progress = new ProgressRepo();
            TimeSpan increase = new TimeSpan(1, 0, 0);
            TimeSpan? total = increase + task.TotalTime; 

            progress.UpdateTotalTime(task.TaskId, total);

            task = repo.GetTask(3);

            Assert.AreEqual(new TimeSpan(4,27,54), task.TotalTime);
           
        }
    }
}
