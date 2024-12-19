using hw8;
using System;

namespace tumak 
{
    class Program
    {
        static void Main(string[] args) 
        {
            Task1();
            Task2();
            Task3();
            Song mySong = new Song();
            Task4();
        }

//        Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
//методы заполнения полей.Вместо этих методов создать конструкторы. Переопределить
//конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
//для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
//банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
//счета.
        static void Task1()
        {
            Console.WriteLine("\nзадание 1\n");
            List<BankAccount> accounts = new List<BankAccount>()
            {
                new BankAccount(1000),
                new BankAccount(2000, AccountType.debit),
                new BankAccount(AccountType.debit)
            };
            foreach (BankAccount account in accounts)
            {
                account.PrintAccountInfo();
            }
        }
//        Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
//о всех банковских операциях.При изменении баланса счета создается новый объект класса
//BankTransaction, который содержит текущую дату и время, добавленную или снятую со
//счета сумму.Поля класса должны быть только для чтения(readonly). Конструктору класса
//передается один параметр – сумма.В классе банковский счет добавить закрытое поле типа
//System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
//данного банковского счета; изменить методы снятия со счета и добавления на счет так,
//чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
//переменную типа System.Collections.Queue.
        static void Task2()
        {
            Console.WriteLine("заданеи 2");
            List<BankAccount> accounts = new List<BankAccount>()
            {
                new BankAccount(1000),
                new BankAccount(2000, AccountType.debit),
                new BankAccount(23432, AccountType.debit)
            };
            foreach (BankAccount account in accounts)
            {
                account.Deposit(1000);
                account.WithdrawCash(1000);
                account.PrintAccountInfo();
            }

        }

//        Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
//проводках из очереди запишет в файл.Не забудьте внутри метода Dispose вызвать метод
//GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
//завершения для указанного объекта.
        static void Task3()
        {
            Console.WriteLine("задание 3");
            using (BankAccount account = new BankAccount(AccountType.debit))
            {
                account.Deposit(10000);
                account.WithdrawCash(5000);
                account.PrintAccountInfo();
                account.Dispose();
            }
        }

        static void Task4()
        {
            Console.WriteLine("задание 4");
            List<Song> songs = new List<Song>
            {
                new Song ( "я устал", "1.Klas$" ),
                new Song ( "Much better", "Dainty" ),
                new Song ( "Cirilla.Gif", "Love God Beer Trap" )
            };

            songs.Add(new Song("Imagine", "John Lennon", songs[1]));

            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].SetPrev(songs[i - 1]);
            }

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }

            if (songs[1].Equals(songs[0].prev))
            {
                Console.WriteLine("Первая и вторая песни одинаковые.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }
        }
    }
}