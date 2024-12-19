using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManager
{
    internal class Task
    {
        public string Discribtion { get; }
        public DateTime Deadline { get; }
        public Employee Originator { get; }
        public Employee Executor { get; }
        public TaskStatus taskStatus { get; private set; }
    }
}
