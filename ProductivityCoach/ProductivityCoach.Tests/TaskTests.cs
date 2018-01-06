using NUnit.Framework;
using ProductivityCoach.Data.ADORepository;
using ProductivityCoach.Models;
using ProductivityCoach.Models.Details;
using ProductivityCoach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductivityCoach.Tests
{
    [TestFixture]
    public class TaskTests
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
        public void CanSelectTaskById()
        {
            MyTask task = new MyTask();
            var repo = new MyTaskRepo();

            task = repo.GetTask(1);

            Assert.AreEqual(1, task.TaskId);
            Assert.AreEqual("Put the kids to bed", task.TaskName);
            Assert.AreEqual("Checklist", task.TypeName);
            Assert.AreEqual(1, task.CompleteEveryNumber);
            Assert.AreEqual("Day", task.CompleteEveryTimeUnit);
            Assert.AreEqual(null, task.DurationNumber);
            Assert.AreEqual(null, task.DurationUnit);
            Assert.AreEqual(null, task.DueDate);
            Assert.AreEqual(null, task.TotalTime);
            Assert.AreEqual("983101f5-9f5b-4d2d-b1dd-f73ad3e16d08", task.UserId);
        }

        [Test]
        public void CanGetTasksForUser()
        {
            var repo = new MyTaskRepo();
            List<MyTask> tasks = repo.GetTasksForUser("983101f5-9f5b-4d2d-b1dd-f73ad3e16d08").ToList();

            Assert.AreEqual(4, tasks.Count());

            Assert.AreEqual(1, tasks[3].TaskId);
            Assert.AreEqual("Put the kids to bed", tasks[3].TaskName);
            Assert.AreEqual("Checklist", tasks[3].TypeName);
            Assert.AreEqual(1, tasks[3].CompleteEveryNumber);
            Assert.AreEqual("Day", tasks[3].CompleteEveryTimeUnit);
            Assert.AreEqual(null, tasks[3].DurationNumber);
            Assert.AreEqual(null, tasks[3].DurationUnit);
            Assert.AreEqual(null, tasks[3].DueDate);
            Assert.AreEqual(null, tasks[3].TotalTime);
            Assert.AreEqual("983101f5-9f5b-4d2d-b1dd-f73ad3e16d08", tasks[3].UserId);
        }

        [Test]
        public void CanAddTask()
        {
            MyTask taskToAdd = new MyTask()
            {
                TaskName = "Finish Unit Testing",
                TypeName = "CompleteBy",
                DueDate = new DateTime(2017, 11, 25),
                UserId = "983101f5-9f5b-4d2d-b1dd-f73ad3e16d08"
            };

            var repo = new MyTaskRepo();

            repo.AddTask(taskToAdd);

            Assert.AreEqual(5, taskToAdd.TaskId);
        }

        [Test]
        public void CanEditTask()
        {
            var repo = new MyTaskRepo();
            MyTask editedTask = new MyTask()
            {
                TaskName = "Get the kids out of bed",
                TypeName = "Checklist",
                CompleteEveryNumber = 2,
                CompleteEveryTimeUnit = "Week"
            };

            repo.EditTask(1, editedTask);

            MyTask task = repo.GetTask(1);

            Assert.AreEqual(1, task.TaskId);
            Assert.AreEqual("Get the kids out of bed", task.TaskName);
            Assert.AreEqual(2, task.CompleteEveryNumber);
            Assert.AreEqual("Week", task.CompleteEveryTimeUnit);
        }

        [Test]
        public void CanDeleteTask()
        {
            MyTask taskToAdd = new MyTask()
            {
                TaskName = "Finish Unit Testing",
                TypeName = "CompleteBy",
                DueDate = new DateTime(2017, 11, 25),
                UserId = "983101f5-9f5b-4d2d-b1dd-f73ad3e16d08"
            };

            var repo = new MyTaskRepo();

            repo.AddTask(taskToAdd);

            Assert.AreEqual(5, taskToAdd.TaskId);

            repo.DeleteTask(5);

            List<MyTask> tasks = repo.GetTasksForUser("983101f5-9f5b-4d2d-b1dd-f73ad3e16d08").ToList();

            Assert.AreEqual(4, tasks.Count());
        }

        [Test]
        public void CanLoadTaskTypes()
        {
            TaskDetails details = new TaskDetails();
            List<Models.Details.Type> TaskTypes = details.GetTaskTypes().ToList();

            Assert.AreEqual(4, TaskTypes.Count());
        }

        [Test]
        public void CanLoadDurationUnits()
        {
            TaskDetails details = new TaskDetails();
            List<Duration> DurationUnits = details.GetDurationsUnits().ToList();

            Assert.AreEqual(3, DurationUnits.Count());
        }

        [Test]
        public void CanLoadTimeUnits()
        {
            TaskDetails details = new TaskDetails();
            List<Time> TimeUnits = details.GetTimeUnits().ToList();

            Assert.AreEqual(4, TimeUnits.Count());
        }

    }

    
}
