namespace ConsolePractice.GeneralQuery
{
    /// <summary>
    /// This class demonstrates the comparison of string variables and the behavior of reference types in C#.
    /// </summary>
    public static class StringTest
    {
        /// <summary>
        /// Compares two string variables and demonstrates the behavior of reference types.
        /// </summary>
        public static void CompareTwoVariables()
        {
            var emp1 = new Employee { Name = "John" };
            var emp2 = new Employee { Name = "John" };
            var emp3 = emp1;

            Console.WriteLine(emp1 == emp2); // False, because they are different instances
            Console.WriteLine(emp1.Equals(emp2)); // False, because the default Equals method compares references

            Console.WriteLine(emp1.Name == emp3.Name); // True, because emp3 is a reference to emp1
            Console.WriteLine(emp1.Equals(emp3)); // True, because emp3 is a reference to emp1

            Console.WriteLine(emp1.Name.CompareTo(emp2.Name));

            Console.WriteLine(emp1 == emp2); // False, because they are different instances
            Console.WriteLine(emp1.Equals(emp2)); // False, because the default Equals method compares references

            Console.WriteLine(emp1.Equals(emp3)); // True, because emp3 is a reference to emp1
            Console.WriteLine(emp1 == emp3); // True, because emp3 is a reference to emp1
        }
    }

    /// <summary>
    /// Represents an employee with a name.
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
    }
}
