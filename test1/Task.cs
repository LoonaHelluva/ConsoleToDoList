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
}