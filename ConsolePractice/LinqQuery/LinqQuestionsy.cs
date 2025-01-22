namespace ConsolePractice
{
    public static class LinqQueries
    {
        public static void DistinctNumberFromList(List<int> lstInput)
        {
            var distinctNumbers = new List<int>();
            if (lstInput != null)
                distinctNumbers = lstInput.Distinct().ToList();
            else
                distinctNumbers = new List<int>();

            foreach (var item in distinctNumbers)
            {
                Console.WriteLine("distinct numbers :>>> " + item);
            }
        }

        public static void FindOddOrEven(List<int> lstInput, bool isEven)
        {
            var oddOrEvenNumbers = new List<int>();

            if (lstInput == null)
                oddOrEvenNumbers = new List<int>();
            else if (isEven)
            {
                oddOrEvenNumbers = lstInput.Distinct().Where(x => x % 2 == 0).ToList();
            }
            else
            {
                oddOrEvenNumbers = lstInput.Distinct().Where(x => x % 2 != 0).ToList();
            }

            foreach (var item in oddOrEvenNumbers)
            {
                var oddEven = isEven == true ? "Even" : "Odd";

                Console.WriteLine("" + oddEven + " numbers :>>> " + item);
            }
        }

        public static void FirstSingleDefault(string input)
        {
            Console.WriteLine("First Element in LINQ");
            var outputEement = input.ToCharArray();

            Console.WriteLine("First Element " + outputEement.First());
            Console.WriteLine("FirstOrDefault Element " + outputEement.FirstOrDefault());
            outputEement = outputEement.Take(1).ToArray();
            Console.WriteLine("Single Element " + outputEement.Single());
            Console.WriteLine("SingleOrDefault Element " + outputEement.SingleOrDefault());
        }

        public static void SecondHighestSalary()
        {
            var employee = new List<Employee>()
            {
                new Employee { Id = 1, Name = "John", Salary = 50000 },
                new Employee { Id = 2, Name = "Jane", Salary = 60000 },
                new Employee { Id = 3, Name = "Mark", Salary = 70000 },
                new Employee { Id = 4, Name = "Lucy", Salary = 80000 },
                new Employee { Id = 5, Name = "David", Salary = 90000 }
            };

            var secondSalary = employee.OrderByDescending(e => e.Salary)
                .Select(e => e.Salary).Distinct().Skip(1).FirstOrDefault();
            Console.WriteLine("Sedond highest salary ==>> " + secondSalary);
        }
    }



    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
}