using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_1
{
    internal class Read
    {
        public int GetInt()
        {
            return Int32.Parse(Console.ReadLine());
        }

        public float GetFloat()
        {
            return float.Parse(Console.ReadLine());
        }

        public double GetDouble()
        {
            return double.Parse(Console.ReadLine());
        }

        public long GetLong()
        {
            return long.Parse(Console.ReadLine());
        }

        public int[] GetIntArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = GetInt();
            }
            return array;
        }

        public List<int> GetIntList()
        {
            List<int> list = new List<int>();
            while (true)
            {
                try
                {
                    list.Add(GetInt());
                }
                catch
                {
                    break;
                }
            }
            return list;
        }
    }
}
