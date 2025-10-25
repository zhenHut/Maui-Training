using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03_TaskList.Models
{
    //public enum Priorities
    //{
    //    Gering,
    //    Mittel,
    //    Schwer
    //}

    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public string Priority { get; set; }= "Mittel";

        public DateTime Created { get; set; }= DateTime.Now;
    }
}
