using System;
using Model;
using MySql.Data.MySqlClient;

class EmployeeNoComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return x.EmpNo.CompareTo(y.EmpNo);
    }
}

namespace Management
{
    public class EmployeeManager
    {
        static List<Employee> employees = ReadDataFromMySqlToList();
        public static List<Employee> ReadDataFromMySqlToList()
        {
            List<Employee> employeesList = new List<Employee>();
            string connectionString = "server=localhost;uid=root;pwd=An281102@@;database=employees";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string insertQuery = "SELECT * FROM employees";
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpNo = reader.GetInt32("emp_no");
                employee.FirstName = reader.GetString("first_name");
                employee.LastName = reader.GetString("last_name");
                employee.BirthDate = reader.GetString("birth_date");
                employee.Gender = reader.GetString("gender");
                employee.HireDate = reader.GetString("hire_date");

                employeesList.Add(employee);
            }
            return employeesList;
        }
        public static void AddEmployee()
        {
            Employee employee = ConsoleUtils.Cnsole.GetEmployee();
            employees.Add(employee);
            string connectionString = "server=localhost;uid=root;pwd=An281102@@;database=employees";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO employees (emp_no, first_name, last_name, birth_date, gender, hire_date) VALUES (@No, @FirstName, @LastName, @BirthDate, @Gender, @HireDate)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@No", employee.EmpNo);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static void SearchByEmployeeName(string? name)
        {
            foreach (Employee item in employees)
            {
                if (item.FirstName == name || item.LastName == name)
                {
                    Console.WriteLine($"{item.EmpNo} | {item.FirstName} | {item.LastName} | {item.BirthDate} | {item.Gender} | {item.HireDate}");
                }
            }
        }
        public static void SortByEmployeeId()
        {
            employees.Sort(new EmployeeNoComparer());
        }
        public static void DisplayAllEmployees()
        {
            foreach (Employee item in employees)
            {
                Console.WriteLine($"{item.EmpNo} | {item.FirstName} | {item.LastName} | {item.BirthDate} | {item.Gender} | {item.HireDate}");
            }
        }
        public static int UpdateEmployeeByNo(int empNo)
        {
            string connectionString = "server=localhost;uid=root;pwd=An281102@@;database=employees";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string? firstName = "", lastName = "", birthDate = "", gender = "", hireDate = "";
                foreach (Employee item in employees)
                {
                    if (item.EmpNo == empNo)
                    {
                        firstName = item.FirstName;
                        lastName = item.LastName;
                        birthDate = item.BirthDate;
                        gender = item.Gender;
                        hireDate = item.HireDate;
                        switch (ConsoleUtils.Cnsole.GetFieldToUpdate())
                        {
                            case "First Name":
                                firstName = ConsoleUtils.Cnsole.GetFieldsValue("First Name");
                                string insertQuery = "UPDATE employees SET first_name = @FirstName WHERE emp_no like @No";
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@No", empNo);
                                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                item.FirstName = firstName;
                                break;
                            case "Last Name":
                                lastName = ConsoleUtils.Cnsole.GetFieldsValue("Last Name");
                                string insertQuery2 = "UPDATE employees SET last_name = @LastName WHERE emp_no like @No";
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery2, conn))
                                {
                                    cmd.Parameters.AddWithValue("@No", empNo);
                                    cmd.Parameters.AddWithValue("@LastName", lastName);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                item.LastName = lastName;
                                break;
                            case "Birth Date":
                                birthDate = ConsoleUtils.Cnsole.GetFieldsValue("Birth Date");
                                string insertQuery3 = "UPDATE employees SET birth_date = @BirthDate WHERE emp_no like @No";
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery3, conn))
                                {
                                    cmd.Parameters.AddWithValue("@No", empNo);
                                    cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                item.BirthDate = birthDate;
                                break;
                            case "Gender":
                                gender = ConsoleUtils.Cnsole.GetFieldsValue("Gender");
                                string insertQuery4 = "UPDATE employees SET gender = @Gender WHERE emp_no like @No";
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery4, conn))
                                {
                                    cmd.Parameters.AddWithValue("@No", empNo);
                                    cmd.Parameters.AddWithValue("@Gender", gender);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                item.Gender = gender;
                                break;
                            case "Hire Date":
                                hireDate = ConsoleUtils.Cnsole.GetFieldsValue("Hire Date");
                                string insertQuery5 = "UPDATE employees SET hire_date = @HireDate WHERE emp_no like @No";
                                using (MySqlCommand cmd = new MySqlCommand(insertQuery5, conn))
                                {
                                    cmd.Parameters.AddWithValue("@No", empNo);
                                    cmd.Parameters.AddWithValue("@HireDate", hireDate);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                item.HireDate = hireDate;
                                break;
                            case "Invalid Choice":
                                return -1;
                        }
                    }
                }
            }
            return 0;
        }
    }
}