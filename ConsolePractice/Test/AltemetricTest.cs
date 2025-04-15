namespace ConsolePractice.Test
{
    public static class AltemetricTest
    {
        // storing the employee details in a list for further processing
        //var employeeList = new List<string>
        //{
        //    "rakesh, IT, 3000",
        //    "mahesh, sales,4000",
        //    "sohan,IT,5000",
        //    "sanjay,sales,1000"
        //};

        //GetDepartWiseSpentMoney();

        /// <summary>
        /// This method calculates the total money spent by each department
        /// </summary>
        public static void GetDepartWiseSpentMoney()
        {
            var employeeList = new List<DepartExpenses>()
            {
                new DepartExpenses { EmpName = "rakesh", Department = "IT", MoneySpent = 3000 },
                new DepartExpenses { EmpName = "mahesh", Department = "sales", MoneySpent = 4000 },
                new DepartExpenses { EmpName = "sohan", Department = "IT", MoneySpent = 5000 },
                new DepartExpenses { EmpName = "sanjay", Department = "sales", MoneySpent = 1000 }
            };

            // Dictionary to store the total money spent by each department
            var departExpenses = new Dictionary<string, int>();

            foreach (var emp in employeeList)
            {

                if (departExpenses.ContainsKey(emp.Department))
                {
                    departExpenses[emp.Department] += emp.MoneySpent;
                }
                else
                {
                    departExpenses[emp.Department] = emp.MoneySpent;
                }
            }

            // To show the total money spent by each department
            foreach (var depart in departExpenses)
            {
                Console.WriteLine($"Using Dictionary ==>> Department: {depart.Key}, Total Money Spent: {depart.Value}");
            }

            // To show the employee details along with the department and money spent
            foreach (var depart in employeeList)
            {
                Console.WriteLine($"Department: {depart.Department}, Employee: {depart.EmpName}, Money Spent: {depart.MoneySpent}");
            }
        }

        /// <summary>
        /// This method calculates the total money spent by each department using LINQ
        /// </summary>
        public static void GetDepartWiseSpentMoney_LINQ()
        {
            var employeeList = new List<DepartExpenses>()
            {
                new DepartExpenses { EmpName = "rakesh", Department = "IT", MoneySpent = 3000 },
                new DepartExpenses { EmpName = "mahesh", Department = "sales", MoneySpent = 4000 },
                new DepartExpenses { EmpName = "sohan", Department = "IT", MoneySpent = 5000 },
                new DepartExpenses { EmpName = "sanjay", Department = "sales", MoneySpent = 1000 }
            };

            var departmentTotals = employeeList
            .Select(emp =>
            {
                return new
                {
                    Department = emp.Department,
                    Salary = emp.MoneySpent
                };
            })
            .GroupBy(e => e.Department)
            .Select(g => new
            {
                Department = g.Key.ToUpper(),
                TotalSalary = g.Sum(e => e.Salary)
            });

            foreach (var depart in departmentTotals)
            {
                Console.WriteLine($"Using LINQ ==>> Department: {depart.Department}, Total Money Spent: {depart.TotalSalary}");
            }
        }
    }

    /// <summary>
    /// This class represents the employee details including name, department, and money spent
    /// </summary>
    public class DepartExpenses
    {
        public string EmpName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int MoneySpent { get; set; }
    }
}
