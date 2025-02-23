namespace StudentManagementSystem
{
    class Student
    {
        public string Name { get; set; }
        public int IdNumber { get; set; }
        public int Grade { get; set; }

        public Student(string name, int idNumber, int grade)
        {
            Name = name;
            IdNumber = idNumber;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"Name: {Name}, ID Number: {IdNumber}, Grade: {Grade}";
        }

        public string ToCsv()
        {
            return $"{Name},{IdNumber},{Grade}";
        }

        public static Student FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new Student(values[0], int.Parse(values[1]), int.Parse(values[2]));
        }
    }

    class Program
    {
        static string dataFilePath = "students.txt";
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            LoadStudentsFromFile();

            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add new student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Search student by theyr id");
                Console.WriteLine("4. Update student grade");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewAllStudents();
                        break;
                    case "3":
                        SearchStudent();
                        break;
                    case "4":
                        UpdateGrade();
                        break;
                    case "5":
                        SaveStudentsToFile();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void LoadStudentsFromFile()
        {
            if (File.Exists(dataFilePath))
            {
                try
                {
                    students = File.ReadAllLines(dataFilePath)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(Student.FromCsv)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading students from file: {ex.Message}");
                }
            }
        }

        static void SaveStudentsToFile()
        {
            try
            {
                File.WriteAllLines(dataFilePath, students.Select(s => s.ToCsv()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving students to file: {ex.Message}");
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            int idNumber;
            while (true)
            {
                Console.Write("Enter ID number: ");
                if (int.TryParse(Console.ReadLine(), out idNumber))
                {
                    break;
                }
                Console.WriteLine("Invalid ID number. Please enter a number.");
            }

            int grade;
            while (true)
            {
                Console.Write("Enter grade (1-10): ");
                if (int.TryParse(Console.ReadLine(), out grade) && grade >= 1 && grade <= 10)
                {
                    break;
                }
                Console.WriteLine("Invalid grade. Please enter a number between 1 and 10.");
            }

            students.Add(new Student(name, idNumber, grade));
            Console.WriteLine("Student added successfully.");
        }

        static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\nStudent Details:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter ID number to search: ");
            if (int.TryParse(Console.ReadLine(), out int idNumber))
            {
                Student foundStudent = students.Find(student => student.IdNumber == idNumber);
                if (foundStudent != null)
                {
                    Console.WriteLine("\nStudent Details:");
                    Console.WriteLine(foundStudent);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID number.");
            }
        }

        static void UpdateGrade()
        {
            Console.Write("Enter ID number to update grade: ");
            if (int.TryParse(Console.ReadLine(), out int idNumber))
            {
                Student foundStudent = students.Find(student => student.IdNumber == idNumber);
                if (foundStudent != null)
                {
                    int newGrade;
                    while (true)
                    {
                        Console.Write("Enter new grade (1-10): ");
                        if (int.TryParse(Console.ReadLine(), out newGrade) && newGrade >= 1 && newGrade <= 10)
                        {
                            foundStudent.Grade = newGrade;
                            Console.WriteLine("Grade updated successfully.");
                            break;
                        }
                        Console.WriteLine("Invalid grade. Please enter a number between 1 and 10.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID number.");
            }
        }
    }
}