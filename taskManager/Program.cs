using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using taskManager;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Igor = new Employee("Игорь");
            Employee Alexey = new Employee("Алексей");
            Employee Gerwant = new Employee("Гервант");
            Employee Siegmeyer = new Employee("Сигмайер");
            Employee Mikhail = new Employee("Михаил");
            Employee Anna = new Employee("Анна");
            Employee Evgeniy = new Employee("Евгений");
            Employee Ivan = new Employee("Иван");
            Employee Vika = new Employee("Вика");
            Employee Denis = new Employee("Денис");
            Employee Alexandr = new Employee("Алексанр");
            Employee Bogdan = new Employee("Богдан");

            Project game = new Project("создание игры", DateTime.Now.AddDays(100), Igor, Alexey);

            TaskEmp task1 = new TaskEmp("выбрать движок", DateTime.Now.AddDays(10), game.TeamLead, Gerwant);
            TaskEmp task2 = new TaskEmp("создать модели", DateTime.Now.AddDays(19), game.TeamLead, Siegmeyer);
            TaskEmp task3 = new TaskEmp("переписать гвинт", DateTime.Now.AddDays(32), game.TeamLead, Mikhail);
            TaskEmp task4 = new TaskEmp("сидеть на зп", DateTime.Now.AddDays(90), game.TeamLead, Evgeniy);
            TaskEmp task5 = new TaskEmp("написать логику", DateTime.Now.AddDays(40), game.TeamLead, Ivan);
            TaskEmp task6 = new TaskEmp("настроить сервера", DateTime.Now.AddDays(50), game.TeamLead, Ivan);
            TaskEmp task7 = new TaskEmp("много думать", DateTime.Now.AddDays(19), game.TeamLead, Vika);
            TaskEmp task8 = new TaskEmp("подать кофе", DateTime.Now.AddDays(32), game.TeamLead, Denis);
            TaskEmp task9 = new TaskEmp("помыть пол", DateTime.Now.AddDays(90), game.TeamLead, Alexandr);
            TaskEmp task10 = new TaskEmp("ничего не ломать", DateTime.Now.AddDays(40), game.TeamLead, Anna);
            TaskEmp task11 = new TaskEmp("что-нить сделать", DateTime.Now.AddDays(50), game.TeamLead, Bogdan);
            task11.PrintInfo();

            Alexey.AddTask(game, task1);
            Alexey.AddTask(game, task2);
            Alexey.AddTask(game, task3);
            Alexey.AddTask(game, task4);
            Alexey.AddTask(game, task5);
            Alexey.AddTask(game, task6);
            Alexey.AddTask(game, task7);
            Alexey.AddTask(game, task8);
            Alexey.AddTask(game, task9);
            Alexey.AddTask(game, task10);
            Alexey.AddTask(game, task11);

            //первый вщгляд
            Ivan.PrintInfo();
            task11.PrintInfo();

            game.Start();
            
            //как изменяется при делегации другому работнику
            Ivan.DelegerenTask(task5, Vika);
            Ivan.PrintInfo();
            task5.PrintInfo();
            Vika.TaskRejected(task5);
            task5.PrintInfo();
            Alexey.RemoveTask(game, task5);
            game.PrintTasks();

            //выполнение задач
            task1.TaskReport(game, new Report("выполнена", Gerwant));
            task2.TaskReport(game, new Report("выполнена", Siegmeyer));
            task3.TaskReport(game, new Report("выполнена", Mikhail));
            task4.TaskReport(game, new Report("выполнена", Evgeniy));
            task6.TaskReport(game, new Report("выполнена", Ivan));
            task7.TaskReport(game, new Report("выполнена", Vika));
            task8.TaskReport(game, new Report("выполнена", Denis));
            task9.TaskReport(game, new Report("выполнена", Alexandr));
            task10.TaskReport(game, new Report("выполнена", Anna));
            task11.TaskReport(game, new Report("выполнена", Anna));
            task11.TaskReport(game, new Report("выполнена", Bogdan));




        }
    }
}