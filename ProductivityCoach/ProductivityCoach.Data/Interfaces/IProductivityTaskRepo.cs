using ProductivityCoach.Models;
using ProductivityCoach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Data.Interfaces
{
    public interface IProductivityTaskRepo
    {
        MyTask GetTask(int taskId);
        IEnumerable<MyTask> GetTasksForUser(string UserId);
        void AddTask(MyTask task);
        void EditTask(int taskId, MyTask task);
        void DeleteTask(int taskId);

    }
}
