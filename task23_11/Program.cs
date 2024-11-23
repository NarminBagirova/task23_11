using task23_11;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter your fullname: ");
        string fullname = Console.ReadLine();
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        User user = new User(fullname, email, password);

        Console.WriteLine("1. Show info\n2. Create new group");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            user.ShowInfo();
        }
        else if (choice == 2)
        {
            Console.Write("Enter GroupNo: ");
            string groupNo = Console.ReadLine();
            Console.Write("Enter StudentLimit: ");
            int studentLimit = Convert.ToInt32(Console.ReadLine());

            Group group = new Group(groupNo, studentLimit);

            if (group.CheckGroupNo(groupNo))
            {
                Console.WriteLine("Group created successfully.");

                Console.WriteLine("1. Show all students\n2. Get student by Id\n3. Add student\n0. Quit");
                bool showGroupMenu = true;
                while (showGroupMenu)
                {
                    int groupChoice = Convert.ToInt32(Console.ReadLine());

                    switch (groupChoice)
                    {
                        case 1:
                            foreach (var student in group.GetAllStudents())
                            {
                                if (student != null) student.StudentInfo();
                            }
                            break;
                        case 2:
                            Console.Write("Enter student Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Student studentById = group.GetStudent(id);
                            if (studentById != null)
                            {
                                studentById.StudentInfo();
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;
                        case 3:
                            Console.Write("Enter student's full name: ");
                            string studentName = Console.ReadLine();
                            Console.Write("Enter student's points: ");
                            int points = Convert.ToInt32(Console.ReadLine());

                            Student newStudent = new Student(studentName, points);
                            group.AddStudent(newStudent);
                            break;
                        case 0:
                            showGroupMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            }
            else
                Console.WriteLine("Invalid group number format.");

        }
    }
}