using System;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string name)
    {
        Name = name;
        IsCompleted = false;
    }

    public bool Rename(string newName)
    {
        try
        {
            Name = newName;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Complete()
    {
        IsCompleted = true;
    }
}