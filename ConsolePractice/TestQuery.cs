using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class TestQuery
    {
        public string LexicoGraphicallyDescending(string input)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                result = string.Empty;
            }

            char[] charArray = input.ToCharArray();

            Array.Sort(charArray, (a, b) => b.CompareTo(a));
            result = new string(charArray);

            return result;
        }

        public string LexicoGraphicallyDescending_AnyLoop(string input)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                result = string.Empty;
            }

            char[] charArray = input.ToCharArray();

            // geeks

            //Array.Sort(charArray, (a, b) => b.CompareTo(a));
            //result = new string(charArray);

            char[] temp = new char[charArray.Length];
            for (int i = input.Length - 1; i >= 0; i--)
            {
                temp[i] = charArray[i];
                // check the assci value of each character and then store in temp data
                if(temp[i] > charArray[i])
                {

                }

            }

            return result;
        }
    }
}
