using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManager
{
    internal class Employee
    {
        public string Name { get; }
        public Task Task { get; private set; }
        public Employee(string Name) { this.Name = Name; }

        public void AddTask(Task task, Project project)
        {
            if (project.TeamLead.Equals(this) && project.Status == ProjectStatus.project)
            {
                project.AddTask(task);
                task.Executor.TakeTask(task);
                Console.WriteLine("задача добавлена");
            }
            else
            {
                Console.WriteLine($"{this.Name} не тимлид");
            }
        }
        public void TakeTask(Task task)
        {
            Task = task;
        }
        public void RemoveTask(Task task) 
        {

        }

    }
}
