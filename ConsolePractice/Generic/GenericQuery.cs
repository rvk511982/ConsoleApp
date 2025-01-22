namespace ConsolePractice
{

    public class GenericQueries<T>
    {
        public static bool AreEqual(T input1, T input2)
        {
            return input1.Equals(input2);
        }
    }
}