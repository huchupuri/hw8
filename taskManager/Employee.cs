using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taskManager
{
    internal class Employee
    {
        public string Name { get; }
        public List<TaskEmp> EmpTasks { get; private set; }
        public Employee(string Name) { this.Name = Name; EmpTasks = new List<TaskEmp>(); }


        /// <summary>
        /// добавление задачи
        /// </summary>
        public void AddTask(Project project, TaskEmp task)
        {
            if (project.TeamLead.Equals(this) && project.Status == ProjectStatus.project)
            {
                project.AddTask(task);
                task.Executor.TakeTask(task);
                Console.WriteLine("задача взята");
            }
            else
            {
                Console.WriteLine($"{this.Name} не тимлид");
            }
        }

        /// <summary>
        /// взятие задачи в работу
        /// </summary>
        public void TakeTask(TaskEmp task)
        {
            EmpTasks.Add(task);
            task.ChangeStatus(TaskStatus.proccesing);
        }

        /// <summary>
        /// делигировать задачу
        /// </summary>
        public void DelegerenTask(TaskEmp task, Employee Receiver)
        {
            if (this.EmpTasks.Contains(task))
            {
                task.ChangeExecutor(Receiver);
                this.EmpTasks.Remove(task);
                task.ChangeStatus(TaskStatus.assigned);
            }
        }

        /// <summary>
        /// отказ от задачи 
        /// </summary>
        public void TaskRejected(TaskEmp task) 
        {
            try
            {
                task.Executor = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка: {ex}");
            }
        }

        
        /// <summary>
        /// удадение задачи
        /// </summary>
        public void RemoveTask(Project project, TaskEmp task) 
        {
            if (project.TeamLead.Equals(this) && task.Executor == null)
            {
                project.TaskRemover(task);
                Console.WriteLine("задача удалена");
                if (project.Tasks.Count() == 0)
                {
                    project.Finish();
                    Console.WriteLine("проект завершен");
                }
                //сюда проверку
            }
            else
            {
                Console.WriteLine($"{this.Name} не тимлид");
            }
        }

        /// <summary>
        /// проверка отчета
        /// </summary>
        public bool CheckReport(Project project, TaskEmp task) 
        {
            if (task.Report.Executor == task.Executor)
            {
                Console.WriteLine("задача закрыта");
                task.ChangeStatus(TaskStatus.complete);
                project.TaskRemover(task);
                if (project.Tasks.Count() == 0) 
                {
                    project.Finish();
                    Console.WriteLine("проект завершен");
                }
                return true;
            }
            else
            {
                Console.WriteLine("неправильный отчет");
                return false;
            }
        }
        public void PrintInfo()
        {
            Console.Write($"имя: {Name}, задачи: ");
            foreach (TaskEmp task in EmpTasks)
            {
                Console.Write($"{task.Discribtion} ");
            }
            Console.WriteLine();
        }

    }
}
