using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public static class FileService
{
    private static string path = "tasks.json";
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };

    static FileService()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
    }
    public static void Save(List<Task> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(path, json);
    }

    public static List<Task> GetTasks()
    {
        if (!File.Exists(path))
        {
            return new List<Task>();
        }

        string json = File.ReadAllText(path);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Task>();
        }

        try
        {
            List<Task>? tasks = JsonSerializer.Deserialize<List<Task>>(json, options);
            return tasks ?? new List<Task>();
        }
        catch (JsonException)
        {
            // If file contains invalid JSON, ignore and return empty list.
            // Optionally we could back up the file here for inspection.
            return new List<Task>();
        }
    }
}