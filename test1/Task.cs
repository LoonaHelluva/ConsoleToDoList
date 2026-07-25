using System;

public class Task
{
    public int id;
    public string name;
    public bool isCompleted;

    public Task(string name)
    {
        this.name = name;
        this.isCompleted = false;
    }

    public bool Rename(string newName)
    {
        try
        {
            this.name = newName;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Complete()
    {
        this.isCompleted = true;
    }

    public static string GetName()
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

    public static int GetId()
    {
        Console.Write("Enter task id: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            System.Console.WriteLine("Task id can't be empty, or letter, it have to be number");
            Console.Write("Which task to rename?: ");
        }

        return id;
    }
}