using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityCoach.Data.Interfaces
{
    public interface IProgressRepo
    {
        void UpdateTotalTime(int taskId, TimeSpan? totalTime);
    }
}
