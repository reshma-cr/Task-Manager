using System.ComponentModel;
using System.Runtime.CompilerServices;
using static TaskService;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== TASK MANAGER ===");
            Console.WriteLine("1. Add Task \n2. View Tasks \n3. View Completed Tasks \n4. Delete Task \n5. Toggle Complete \n6. Exit");
            Console.Write("Enter your choice: ");
            if(int.TryParse(Console.ReadLine(), out int choice)){
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the Title and Description of the Task you want to add");
                    Console.Write($"Title: ");
                    string title = Console.ReadLine() ?? "";
                    Console.Write($"Description: ");
                    string description = Console.ReadLine() ?? "";
                    TaskService.CreateTask(title, description);
                    break;

                case 2:
                    TaskService.ViewTasks();
                    break;

                case 3:
                    TaskService.ViewCompletedTasks();
                    break;

                case 4:
                    Console.WriteLine("Please enter the Id of the task to be deleted.");
                    if(!Guid.TryParse(Console.ReadLine(), out Guid taskId))
                    {
                        Console.WriteLine("Invalid Id format");
                        break;
                    }
                    TaskService.DeleteTask(taskId);
                    break;

                case 5:
                    System.Console.WriteLine("Please enter the Id of the task to be toggeled.");
                    if(!Guid.TryParse(Console.ReadLine(), out Guid Id))
                    {
                        Console.WriteLine("Invalid Id format");
                        break;
                    }
                    TaskService.ToggleTask(Id);
                    break;

                case 6: return;
            }
            
        }
    }

}