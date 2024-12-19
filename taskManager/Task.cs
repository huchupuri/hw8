using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taskManager
{
    internal class TaskEmp
    {
        public string Discribtion { get; }
        public DateTime Deadline { get; }
        public Employee Originator { get; }
        public Employee Executor { get; set; }
        public TaskStatus TaskStatus { get; private set; }
        public Report Report { get; set; }


        /// <summary>
        /// конструктор задачи
        /// </summary>
        public TaskEmp(string discribtion, DateTime deadline, Employee originator, Employee executor)
        {
            Discribtion = discribtion;
            Deadline = deadline;
            Originator = originator;
            Executor = executor;
            TaskStatus = TaskStatus.assigned;
        }

        /// <summary>
        /// делегирование задачи
        /// </summary>
        public void ChangeExecutor(Employee receiver)
        {
            Executor = receiver;
            receiver.TakeTask(this);
        }

        /// <summary>
        /// ищменение статуса
        /// </summary>
        /// <param name="taskStatus"></param>
        public void ChangeStatus(TaskStatus taskStatus)
        {
            TaskStatus = taskStatus;
        }

        /// <summary>
        /// отчет о задаче
        /// </summary>
        public void TaskReport(Project project, Report report) 
        {
            Report = report;
            TaskStatus = TaskStatus.checking;
            project.TeamLead.CheckReport(project, this);
        }
        public void PrintInfo() 
        {
            string name = Executor != null ? Executor.Name : "нет";
            Console.WriteLine($"описание: {Discribtion}, исполнитель: {name}, статус: {TaskStatus}");
        }

    }
}
