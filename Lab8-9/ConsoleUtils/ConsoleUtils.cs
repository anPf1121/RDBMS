using System;
using Model;

namespace ConsoleUtils
{
    public class Cnsole
    {
        public static int Menu(string title, string[] menuItems)
        {
            int i = 0, choice;
            Title(title);
            for (; i < menuItems.Count(); i++)
            {
                Console.WriteLine(i + 1 + ". " + menuItems[i]);
            }
            Console.WriteLine("==============================");
            do
            {
                Console.Write("Your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            } while (choice <= 0 || choice > menuItems.Count());
            return choice;
        }
        public static void Title(string title)
        {
            Console.WriteLine("==============================");
            Console.WriteLine(" " + title.ToUpper());
            Console.WriteLine("==============================");
        }
        public static void Notification(string notification)
        {
            Console.WriteLine(notification + "!");
            PressEnterToContinue();
        }
        public static void PressEnterToContinue()
        {
            Console.Write("Press Enter to continue...");
            Console.ReadKey();
        }
        public static string GetFieldsValue(string field)
        {
            Console.Write(field + ": ");
            string? value = Console.ReadLine();
            if (value == null)
                return "";
            return value;
        }
        public static Employee GetEmployee()
        {
            Employee employee = new Employee();
            int empNo;
            Console.Write("Employee No: ");
            int.TryParse(Console.ReadLine(), out empNo);
            employee.EmpNo = empNo;
            string? firstName = "", lastName = "", birthDate = "", gender = "", hireDate = "";
            firstName = GetFieldsValue("First Name");
            employee.FirstName = firstName;
            lastName = GetFieldsValue("Last Name");
            employee.LastName = lastName;
            birthDate = GetFieldsValue("BirthDate");
            employee.BirthDate = birthDate;
            gender = GetFieldsValue("Gender (M/F)");
            employee.Gender = gender;
            hireDate = GetFieldsValue("HireDate");
            employee.HireDate = hireDate;
            return employee;
        }
        public static int GetEmployeeNo()
        {
            int choice;
            Title("Update Employee Information");
            Console.Write("Enter Employee No: ");
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        public static string GetFieldToUpdate()
        {
            int choose;
            Title("Update Employee Information");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Birth Date");
            Console.WriteLine("4. Gender");
            Console.WriteLine("5. Hire Date");
            Console.Write("Choose To Update: ");
            int.TryParse(Console.ReadLine(), out choose);
            switch (choose)
            {
                case 1: 
                    return "First Name";
                case 2: 
                    return "Last Name";
                case 3: 
                    return "Birth Date";
                case 4: 
                    return "Gender";
                case 5: 
                    return "Hire Date";
                default:
                    return "Invalid Choice";
            }
        }
    }
}