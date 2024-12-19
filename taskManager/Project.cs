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
        public List<Task> Tasks { get; private set; }
        public ProjectStatus Status { get; private set; }

        public Project(string discribtion, DateTime deadLine, Employee client, Employee teamLead)
        {
            Discribtion = discribtion;
            Client = client;
            Deadline = deadLine;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = ProjectStatus.project;
        }
        public void Start()
        {
            Status = ProjectStatus.execution;
        }
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
        public void EcecutionStage() 
        {
            Status = ProjectStatus.execution;
        }
    }
}
