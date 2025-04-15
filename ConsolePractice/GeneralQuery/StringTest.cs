using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.GeneralQuery
{
    public static class StringTest
    {

        public static void CompareTwoVariables()
        {
            var emp1 = new Employee { Name = "John" };
            var emp2 = new Employee { Name = "John" };
            var emp3 = emp1;
           
            Console.WriteLine(emp1.Name.CompareTo(emp2.Name));

            Console.WriteLine(emp1.Name.CompareTo(emp2.Name));

            Console.WriteLine(emp1 == emp2); // False, because they are different instances
            Console.WriteLine(emp1.Equals(emp2)); // False, because the default Equals method compares references

            Console.WriteLine(emp1.Equals(emp3));
            Console.WriteLine(emp1 == emp3);
        }

    }

    public class Employee
    {
        public string Name { get; set; }
    }
}
