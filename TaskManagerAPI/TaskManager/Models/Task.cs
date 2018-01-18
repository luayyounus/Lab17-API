using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
