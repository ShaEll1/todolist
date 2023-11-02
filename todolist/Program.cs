

     List<Task> tasksList = new List<Task>();


tasksList.Add(new Task("Assignment1", new DateTime(2023, 12, 2), "School", false));
tasksList.Add(new Task("Final Project", new DateTime(2024,4,4), "School", false));
tasksList.Add(new Task("Plant Garlic", new DateTime(2023, 11, 11), "Gardening", false));
tasksList.Add(new Task("Paint Windows", new DateTime(2024, 5, 4), "Renovation", false));
tasksList.Add(new Task("Mow the Lawn", new DateTime(2023, 10, 11), "Gardening", false));
tasksList.Add(new Task("Fix the fence", new DateTime(2024,3, 4), "Renovation", false));




Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome To Do List");
        Console.ResetColor();
        

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You Have {tasksList.Count} tasks to do and {tasksList.Count(task => task.IsDone)} are done!");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Pick an option:");
            Console.WriteLine("1. Show task list (by date or project)");
            Console.WriteLine("2. Add new task");
            Console.WriteLine("3. Edit task (Edit, Mark as done, Delete)");
            Console.WriteLine("4. Save and quit");
            Console.ResetColor();

    string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // showing task list
                    Console.WriteLine("Choose display option:");
                    Console.WriteLine("a. By date");
                    Console.WriteLine("b. By project");
                    string displayOption = Console.ReadLine();

                    if (displayOption.ToLower() == "a")
                    {
                        DisplayTasksByDate();
                    }
                    else if (displayOption.ToLower() == "b")
                    {
                        DisplayTasksByProject();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid display option. Please try again.");
                        Console.ResetColor();
                    }
                    break;

                case "2":
                    AddNewTask(); // Call the method for adding a new task
                    break;

                case "3": //  for editing, marking as done, or removing tasks
                Console.WriteLine("Choose Option:");
                Console.WriteLine("c. To Mark As Done");
                Console.WriteLine("d. To Delete");
                Console.WriteLine("e. To Edit");
                
                
                string editOption = Console.ReadLine();

                switch (editOption.ToLower())
                {
                    case "e":
                    EditTask();
                    break;

                     case "d":
                    DeleteTask();
                    break;

                     case "c":
                    MarkAsDone();
                    break;

                     default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ResetColor();
                    break;
                }
                 break;

                     

                case "4":
                 Environment.Exit(0);
                 break;

                   default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    

    void DisplayTasksByDate()
    {
        var sortedTasks = tasksList.OrderBy(t => t.DueDate);
        DisplayTasks(sortedTasks);
    }

    void DisplayTasksByProject()
    {
        var sortedTasks = tasksList.OrderBy(t => t.Project);
        DisplayTasks(sortedTasks);
    }

    
    
void DisplayTasks(IEnumerable<Task> taskList)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Title".PadRight(20) + "Due Date".PadRight(20) + "Project".PadRight(15) + "Status");
    Console.ResetColor();
    {
        foreach (var task in taskList)
        {
            Console.WriteLine($" {task.Title.PadRight(20)} {task.DueDate.ToString("yyyy-MM-dd").PadRight(15)} {task.Project.PadRight(15)} {(task.IsDone ? "Done" : "Pending")}");
        }

        Console.WriteLine("---------------------------------------------------------------------------");
    }

}

    void AddNewTask()  // method for adding a new task
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter Task Title: ");
            Console.ResetColor();
            string title = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter Due Date (YYYY-MM-DD): ");
            Console.ResetColor();

            if (DateTime.TryParse(Console.ReadLine(), out DateTime duedate))
            {
                if (duedate < DateTime.Now) // check past dates
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Due date cannot be in the past. Please enter a valid due date.");
                    Console.ResetColor();
                    continue; // Restart the loop to allow the user to enter a valid due date
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter project: ");
                Console.ResetColor();
                string project = Console.ReadLine();

                // Create a new Task instance
                Task newTask = new Task(title, duedate, project, false); // Assuming 'false' for IsDone initially

                // Add the new task to the list
                tasksList.Add(newTask);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task Added to The List! ");
                Console.ResetColor();
                Console.WriteLine();

                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please try again.");
                Console.ResetColor();
            }
        }
    }

void EditTask()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Enter the title of the task to edit: ");
    Console.ResetColor();
    string taskTitleToEdit = Console.ReadLine();

    Task taskToEdit = tasksList.FirstOrDefault(task => task.Title == taskTitleToEdit);

    if (taskToEdit != null)
    {
        Console.Write("Enter new title: ");
        string newTitle = Console.ReadLine();

        Console.Write("Enter new due date (YYYY-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDueDate))
        {
            Console.Write("Enter new project: ");
            string newProject = Console.ReadLine();

            // Update the task
            taskToEdit.Title = newTitle;
            taskToEdit.DueDate = newDueDate;
            taskToEdit.Project = newProject;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task updated successfully!");
            Console.ResetColor();
            Console.WriteLine();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid date format. Task update failed.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task not found. Edit failed.");
        Console.ResetColor();
    }
}
void DeleteTask()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Enter the title of the task to delete: ");
    Console.ResetColor();

            
    string taskTitleToDelete = Console.ReadLine();

    Task taskToDelete = tasksList.FirstOrDefault(task => task.Title == taskTitleToDelete);

    if (taskToDelete != null)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You Are About To Delete a Task, Are You Sure? Y/ N");
        Console.ResetColor();

        string confirmation=Console.ReadLine().ToLower().ToLower();

        if (confirmation=="y")

        {
            tasksList.Remove(taskToDelete);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task deleted successfully!");
            Console.ResetColor();
            Console.WriteLine();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Canceled by user.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task not found.");
        Console.ResetColor();
    }
}

void MarkAsDone()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Enter the title of the task to mark as done: ");
    Console.ResetColor();
    string taskTitleToMarkAsDone = Console.ReadLine();

    Task taskToMarkAsDone = tasksList.FirstOrDefault(task => task.Title == taskTitleToMarkAsDone);

    if (taskToMarkAsDone != null)
    {
        taskToMarkAsDone.IsDone = true;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task marked as done successfully!");
        Console.ResetColor();
        Console.WriteLine();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Task not found. Marking as done failed.");
        Console.ResetColor();
    }
}



class Task
{
    public Task(string title, DateTime dueDate, string project, bool isDone)
    {
        Title = title;
        DueDate = dueDate;
        Project = project;
        IsDone = isDone;
    }

    public string Title { get; set; }
    public DateTime DueDate { get; set; }

    public string Project { get; set; }
    public bool IsDone { get; set; }
}
