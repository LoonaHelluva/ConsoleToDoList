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
                        Task task = new Task(Task.GetName());
                        tasks.Add(task);
                        FileService.Save(tasks);
                        break;

                    case "R":
                        tasks[Task.GetId()].name = Task.GetName();
                        FileService.Save(tasks);
                        break;

                    case "C":
                        int id = Task.GetId();
                        tasks[id].isCompleted = tasks[id].isCompleted ? false : true;
                        FileService.Save(tasks);
                        break;

                    case "D":
                        Task t = tasks[Task.GetId()];
                        tasks.Remove(t);
                        FileService.Save(tasks);
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
            string isDone = task.isCompleted ? "[V]" : "[ ]";
            int id = tasks.IndexOf(task);
            Console.WriteLine($"{id} {isDone} {task.name}");
        }
    }
}