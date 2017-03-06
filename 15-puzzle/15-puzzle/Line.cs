using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    static class Line
    {
        public static void Check(int[] line)
        {
            if (Math.Pow(Math.Sqrt(line.Length), 2) != line.Length || line.Length == 1)
                throw new ArgumentException("Wrong number of knuckles");

            for (int i = 0; i < line.Length; i++)
            {
                if (!line.Contains(i))
                    throw new ArgumentException("Wrong nuckles");
            }
        }
    }
}
