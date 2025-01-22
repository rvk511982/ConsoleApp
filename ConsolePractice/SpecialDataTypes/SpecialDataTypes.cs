namespace ConsolePractice.SpecialDataTypes
{
    public static class SpecialDataTypes
    {
        /// <summary>
        /// Tuples
        /// </summary>
        public static void TupleExample()
        {
            var tuple = (1, "Hello", true);
            Console.WriteLine(tuple.Item1); // Outputs: 1
            Console.WriteLine(tuple.Item2); // Outputs: Hello
            Console.WriteLine(tuple.Item3); // Outputs: True
        }

        public record Person(string FirstName, string LastName);

        /// <summary>
        /// Records
        /// </summary>
        public static void RecordsExample()
        {
            var person1 = new Person("John", "Doe");
            var person2 = new Person("John", "Doe");

            Console.WriteLine(person1 == person2); // Outputs: True
        }

        /// <summary>
        /// Nullable Types
        /// </summary>
        public static void NullableExample()
        {
            int? nullableInt = null;
            if (nullableInt.HasValue)
            {
                Console.WriteLine(nullableInt.Value);
            }
            else
            {
                Console.WriteLine("No value");
            }
        }

        /// <summary>
        /// Dynamic Type
        /// </summary>
        public static void DynamicExample()
        {
            dynamic dyn = "Hello";
            Console.WriteLine(dyn.Length); // Outputs: 5

            dyn = 123;
            Console.WriteLine(dyn + 10); // Outputs: 133
        }

        /// <summary>
        /// Anonymous Types
        /// </summary>
        public static void AnonymousExample()
        {
            var anon = new { Name = "John", Age = 30 };
            Console.WriteLine(anon.Name); // Outputs: John
            Console.WriteLine(anon.Age);  // Outputs: 30
        }

        /// <summary>
        /// Span<T> and Memory<T>
        /// </summary>
        public static void SpanMemoryTExample()
        {
            Span<int> numbers = stackalloc int[3] { 1, 2, 3 };
            foreach (var number in numbers)
            {
                Console.WriteLine(number); // Outputs: 1 2 3
            }
        }
    }
}
