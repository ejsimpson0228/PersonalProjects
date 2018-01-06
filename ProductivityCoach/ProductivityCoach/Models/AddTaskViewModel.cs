using ProductivityCoach.Models.Details;
using ProductivityCoach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCoach.Models
{
    public class AddTaskViewModel 
    {
        public IEnumerable<SelectListItem> TypeNames { get; set; }
        public IEnumerable<SelectListItem> CompleteEveryTimeUnits { get; set; }
        public IEnumerable<SelectListItem> DurationUnits { get; set; }
        public MyTask myTask { get; set; }
    }
}