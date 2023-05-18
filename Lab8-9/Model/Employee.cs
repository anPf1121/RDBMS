using System;

namespace Model
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string BirthDate { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string HireDate { get; set; } = default!;

    }
}