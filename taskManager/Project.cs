using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManager
{
    internal class Project
    {
        public string Discribtion {get; }
        public DateTime Deadline { get; private set; }
        public Employee Client { get; }
        public Employee TeamLead { get; }
        public List<TaskEmp> Tasks { get; private set; }
        public ProjectStatus Status { get; private set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Project(string discribtion, DateTime deadLine, Employee client, Employee teamLead)
        {
            Discribtion = discribtion;
            Client = client;
            Deadline = deadLine;
            TeamLead = teamLead;
            Tasks = new List<TaskEmp>();
            Status = ProjectStatus.project;
        }

        /// <summary>
        /// начало проекта
        /// </summary>
        public void Start()
        {
            Status = ProjectStatus.execution;
        }

        /// <summary>
        /// окончание проекта
        /// </summary>
        public void Finish()
        {
            Status = ProjectStatus.closed;
        }
        /// <summary>
        /// добавление задачи
        /// </summary>
        public void AddTask(TaskEmp task)
        {
            Tasks.Add(task);
        }
        /// <summary>
        /// удаление задачи
        /// </summary>
        public void TaskRemover(TaskEmp task) 
        {
            Tasks.Remove(task);
        }
        public void PrintInfo() => Console.WriteLine($"описание: {Discribtion}, тимлид: {TeamLead.Name}, статус: {Status}");
        public void PrintTasks() 
        {
            foreach (TaskEmp task in Tasks)
            {
                task.PrintInfo();
            }
        }
    }
}
