using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManager
{
    internal class Report
    {
        public string Text { get; }
        public Employee Executor { get; }
        public DateTime ExecutionDate { get; }

        // Конструктор
        public Report(string text, Employee Executor)
        {
            this.Text = Text;
            this.Executor = Executor;
            this.ExecutionDate = DateTime.Now;
        }
    }
}
