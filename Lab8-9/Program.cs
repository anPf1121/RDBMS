using System;
using Model;

class EmployeesManagementSystem
{
    public static void Main()
    {
        Employee emp = new Employee();
        int choice = 0, empNo = 0;
        string? employeeName = "";
        string[] menuItems = { "Add Employee", "Search By Employee Name", "Sort Employee By Employee ID", "Display All Employees", "Update Employee Information", "Exit" };
        do
        {
            choice = ConsoleUtils.Cnsole.Menu("Employees Management System", menuItems);
            switch (choice)
            {
                case 1:
                    ConsoleUtils.Cnsole.Title("Add Employee");
                    Management.EmployeeManager.AddEmployee();
                    ConsoleUtils.Cnsole.Notification("Successfully Added Employee");
                    break;
                case 2:
                    ConsoleUtils.Cnsole.Title("Search By Employee Name");
                    employeeName = ConsoleUtils.Cnsole.GetFieldsValue("Employee Name");
                    Management.EmployeeManager.SearchByEmployeeName(employeeName);
                    ConsoleUtils.Cnsole.PressEnterToContinue();
                    break;
                case 3:
                    Management.EmployeeManager.SortByEmployeeId();
                    ConsoleUtils.Cnsole.Notification("Successfully Sorted Employees");
                    break;
                case 4:
                    ConsoleUtils.Cnsole.Title("Employees List");
                    Management.EmployeeManager.DisplayAllEmployees();
                    ConsoleUtils.Cnsole.PressEnterToContinue();
                    break;
                case 5:
                    ConsoleUtils.Cnsole.Title("Update Employees Infomation");
                    empNo = ConsoleUtils.Cnsole.GetEmployeeNo();
                    Management.EmployeeManager.UpdateEmployeeByNo(empNo);
                    ConsoleUtils.Cnsole.PressEnterToContinue();
                    break;
                case 6:
                    ConsoleUtils.Cnsole.Notification("Exiting..");
                    break;
                default:
                    break;
            }
        } while (choice != 6);
    }
}