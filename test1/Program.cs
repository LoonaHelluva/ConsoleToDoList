using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
class Program
{
    public static List<Task> tasks = FileService.GetTasks();
    static void Main()
    {
        while (true)
        {
            Refresh();
            Console.WriteLine("Actions: [A]dd, [R]ename, [C]omplete, [D]elete, [Q]uit");
            string? input = Console.ReadLine()?.ToUpper();

            if (input != "Q")
            {
                switch (input)
                {
                    case "A":
                        Task task = new Task(GetName());
                        tasks.Add(task);
                        FileService.Save(tasks);
                        break;

                    case "R":
                        if (tasks.Count != 0)
                        {
                            tasks[GetId()].Name = GetName();
                            FileService.Save(tasks);
                        }
                        else
                        {
                            System.Console.WriteLine("List is empty, add tasks first (press any button to continue)");
                            Console.ReadKey();
                        }
                        break;

                    case "C":
                        if (tasks.Count != 0)
                        {
                            int id = GetId();
                            tasks[id].IsCompleted = !tasks[id].IsCompleted;
                            FileService.Save(tasks);
                        }
                        else
                        {
                            System.Console.WriteLine("List is empty, add tasks first (press any button to continue)");
                            Console.ReadKey();
                        }                     
                        break;

                    case "D":
                        if (tasks.Count != 0)
                        {
                            tasks.RemoveAt(GetId());
                            FileService.Save(tasks);
                        }
                        else
                        {
                            System.Console.WriteLine("List is empty, add tasks first (press any button to continue)");
                            Console.ReadKey();
                        }                       
                        break;
                }
            }
            else
            {
                break;
            }
        }

        //Last Call
        Refresh();
    }

    static void Refresh()
    {
        tasks = FileService.GetTasks();
        Console.Clear();
        foreach (var task in tasks)
        {
            string isDone = task.IsCompleted ? "[V]" : "[ ]";
            int id = tasks.IndexOf(task);
            Console.WriteLine($"{id} {isDone} {task.Name}");
        }
    }

    static string GetName()
    {
        Console.Write("Enter task's name: ");
        string? name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Task's name can't be empty.");
            Console.Write("Enter task's name: ");
            name = Console.ReadLine();
        }
        return name;
    }

    static int GetId()
    {
        int id = StrToNum();
        //checking if id is not out of range of tasks

        while (id < 0 || id > tasks.Count - 1)
        {
            Console.WriteLine("There is no such task");
            id = StrToNum();
        }

        return id;
    }

    static int StrToNum()
    {
        //getting number fron user input
        Console.Write("Enter task id: ");
        int num;
        while (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Task id can't be empty, or letter, it have to be number");
            Console.Write("Wich task to choose: ");
        }
        return num;
    }
}