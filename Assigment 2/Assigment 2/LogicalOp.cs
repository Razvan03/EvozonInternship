using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assigment_1
{
    internal class LogicalOp
    {
        public int CheckBiggerNumber(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public string CompareWithFastTrackIT(string input)
        {
            if (input.Equals("FastTrackIT", StringComparison.OrdinalIgnoreCase)) //StringComparison.OrdinalIgnoreCase = ignore key sensitivity
            {
                return "Learning text comparison";
            }
            else
            {
                return "Got to try some more";
            }
        }

        public string CheckStringAndNumber(string text, int number)
        {
            if (text.Equals("FastTrackIT", StringComparison.OrdinalIgnoreCase) && number <= 3)
            {
                return $"{text} {number}";
            }
            else if (!text.Equals("FastTrackIT", StringComparison.OrdinalIgnoreCase) && number >= 4)
            {
                return $"{number} {text}";
            }
            return "";
        }

        public string CheckSnowAmount(int number)
        {
            if (number > 8 || number == 6)
            {
                return $"The amount of snow this winter was(cm): {number}";
            }
            else
            {
                return $"The forecast snow is(cm): {number}";
            }
        }

        public string CheckNumber(int number)
        {
            if (number > 3 && number != 4)
            {
                return "The number is greater than 3 and not equal to 4";
            }
            else if (number == 4)
            {
                return "The number is equal to 4";
            }
            else if (number < 3)
            {
                return "The number is lower than 3";
            }
            return "";
        }

        public void DisplayNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("The number is: 1!");
                    break;
                case 2:
                    Console.WriteLine("The number is: 2!");
                    break;
                case 3:
                    Console.WriteLine("The number is: 3!");
                    break;
                case 4:
                    Console.WriteLine("The number is: 4!");
                    break;
                case 5:
                    Console.WriteLine("The number is: 5!");
                    break;
                case 6:
                    Console.WriteLine("The number is: 6!");
                    break;
                case 7:
                    Console.WriteLine("The number is: 7!");
                    break;
                case 8:
                    Console.WriteLine("The number is: 8!");
                    break;
                case 9:
                    Console.WriteLine("The number is 9!");
                    break;
                case 10:
                    Console.WriteLine("The number is 10!");
                    break;
                default:
                    Console.WriteLine("The number is not recognized!");
                    break;
            }
        }
        
        public bool IsNumberEven(int number)
        {
            return number % 2 == 0;
        }

        public bool IsEligibleToVote(int age)
        {
            return age >= 18;
        }

        public int GetMaxNumber(int num1, int num2, int num3)
        {
            if (num1 >= num2 && num1 >= num3)
            {
                return num1;
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                return num2;
            }
            else
            {
                return num3;
            }
        }

        //Assigment for

        public void CountToHundredFrom(int number)
        {
            for (int i = number; i <= 100; i++)
            {
                Console.WriteLine(i);
            }
        }
        public void CountToNegativeHundredFrom(int number)
        {
            for (int i = number; i >= -100; i--)
            {
                Console.WriteLine(i);
            }
        }

        public void CountFromTo(int number1, int number2)
        {
            for (int i = number1; i <= number2; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void CountFromSmallerToBigger(int number1, int number2)
        {
            int min = Math.Min(number1, number2);
            int max = Math.Max(number1, number2);

            for (int i = min; i <= max; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void PrintEvenNumbers()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public void PrintOddNumbers()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public int SumFromToHundred(int number)
        {
            int sum = 0;

            for (int i = number; i <= 100; i++)
            {
                sum += i;
            }

            return sum;
        }

        public double AverageFromToHundred(int number)
        {
            int sum = 0;
            int count = 0;

            for (int i = number; i <= 100; i++)
            {
                sum += i;
                count++;
            }

            return (double)sum / count;
        }

        public void PrintPattern()
        {
            for (int i = 7; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        //Assigment While
        public void CountToHundredFromWhile(int number)
        {
            while (number <= 100)
            {
                Console.WriteLine(number);
                number++;
            }
        }

        public void CountToNegativeHundredFromWhile(int number)
        {
            while (number >= -100)
            {
                Console.WriteLine(number);
                number--;
            }
        }

        public void CountFromToWhile(int number1, int number2)
        {
            while (number1 <= number2)
            {
                Console.WriteLine(number1);
                number1++;
            }
        }

        public void CountFromSmallerToBiggerWhile(int number1, int number2)
        {
            int min = Math.Min(number1, number2);
            int max = Math.Max(number1, number2);

            while (min <= max)
            {
                Console.WriteLine(min);
                min++;
            }
        }
        public void PrintEvenNumbersWhile()
        {
            int i = 1;
            while (i <= 100)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }
        public void PrintOddNumbersWhile()
        {
            int i = 1;
            while (i <= 100)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }

        public void SumAndAverage()
        {
            int sum = 0;
            int count = 0;
            int i = 111;

            while (i <= 8899)
            {
                sum += i;
                count++;
                i++;
            }

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + (double)sum / count);
        }

        public double AverageOfDivisibleBySeven(int number1, int number2)
        {
            int sum = 0;
            int count = 0;

            while (number1 <= number2)
            {
                if (number1 % 7 == 0)
                {
                    sum += number1;
                    count++;
                }
                number1++;
            }

            return (double)sum / count;
        }

        public void PrintFibonacciNumbers()
        {
            int num1 = 0;
            int num2 = 1;
            int counter = 0;

            while (counter < 20)
            {
                Console.WriteLine(num1);
                int num3 = num2 + num1;
                num1 = num2;
                num2 = num3;
                counter++;
            }
        }

        public void CozaLozaWoza()
        {
            int number = 1;
            int counter = 0;

            while (number <= 110)
            {
                bool printNumber = true;

                if (number % 3 == 0)
                {
                    Console.Write("Coza");
                    printNumber = false;
                }
                if (number % 5 == 0)
                {
                    Console.Write("Loza");
                    printNumber = false;
                }
                if (number % 7 == 0)
                {
                    Console.Write("Woza");
                    printNumber = false;
                }

                if (printNumber)
                {
                    Console.Write(number);
                }

                Console.Write(" ");
                counter++;
                number++;

                if (counter % 11 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        //Assigment Arrays
        public int[] PopulateArray()
        {
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            return array;
        }

        public int[] PopulateArrayWithEvenNumbers()
        {
            int[] array = new int[50];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (i + 1) * 2;
            }
            return array;
        }

        public double CalculateAverage(int[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum / array.Length;
        }

        public bool DoesStringExist(string[] array, string value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public int FindPosition(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }
            return -1;  // return -1 if value does not exist in the array
        }

        public void DisplayGrid()
        {
            string[] grid = new string[10];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = "- - - - - - - - - -";
            }

            foreach (string line in grid)
            {
                Console.WriteLine(line);
            }
        }

        public int[] RemoveNumberFromArray(int[] array, int num)
        {
            return array.Where(x => x != num).ToArray();
        }

        public int SecondSmallestNumber(int[] array)
        {
            int min = array.Min();
            return array.Where(x => x != min).Min();
        }

        public int[] CopyArray(int[] sourceArray, int[] destinationArray)
        {
            destinationArray = new int[sourceArray.Length];
            for (int i = 0; i < sourceArray.Length; i++)
            {
                destinationArray[i] = sourceArray[i];
            }
            return destinationArray;
        }

        //Assigment 7 (Lists)
        public void DisplayList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void AddNumberToList(List<int> list, int num)
        {
            list.Add(num);
        }

        public void DisplayFromIndex(List<int> list, int index)
        {
            for (int i = index; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        public void DisplayListReverse(List<int> list)
        {
            list.Reverse();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void InsertStringAt(List<string> list, int index, string value)
        {
            list.Insert(index, value);
        }

        public void AddFirst(List<int> list, int num)
        {
            list.Insert(0, num);
        }

        public void DisplayValuesAndPositions(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"On position {i}, the value is {list[i]}");
            }
        }

        public int FindLargest(List<int> list)
        {
            return list.Max();
        }

        //Assigment 8 Try-Catch

        public void DisplayValueAtIndex(int[] array, int index)
        {
            try
            {
                Console.WriteLine(array[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Inside catch, number too large");
            }
        }

        public void Wait(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Assigment 9 (Arrays Optional)

        public int SecondSmallest(int[] array)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (var number in array)
            {
                if (number < first)
                {
                    second = first;
                    first = number;
                }
                else if (number < second && number != first)
                {
                    second = number;
                }
            }
            return second;
        }

        public int[] InsertElement(int[] array, int position, int element)
        {
            int[] newArray = new int[array.Length + 1];

            for (int i = 0; i < position; i++)
                newArray[i] = array[i];

            newArray[position] = element;

            for (int i = position + 1; i < newArray.Length; i++)
                newArray[i] = array[i - 1];

            return newArray;
        }

        public Tuple<int, int> MinAndMax(int[] array)
        {
            int min = array.Min();
            int max = array.Max();

            return Tuple.Create(min, max);
        }

        public int[] ReverseArray(int[] array)
        {
            Array.Reverse(array);
            return array;
        }

        public List<int> FindDuplicates(int[] array)
        {
            return array.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key)
                        .ToList();
        }

        public List<string> CommonElements(string[] array1, string[] array2)
        {
            return array1.Intersect(array2).ToList();
        }

        public int[] SortArray(int[] array)
        {
            Array.Sort(array);
            return array;
        }

        //Assigment 10 List optional

        public List<int> SwapElements(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            return list;
        }

        public List<int> GetEvenNumbers(List<int> list)
        {
            return list.Where(x => x % 2 == 0).ToList();
        }

        public List<int> SortList(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        // Swap
                        int temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }

    }
}
