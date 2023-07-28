using Assigment_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Assigment 1: \n");
            //Assigment 1

            Console.WriteLine("Hello");
            Console.WriteLine("Razvan");
            
            Console.WriteLine("5 + 3 = " + (5 + 3));
            
            Console.WriteLine("10 / 3 = " + ((double)10 / 3));

            Console.WriteLine("-5 + 8 * 6 = " + (-5 + 8 * 6));

            Console.WriteLine("(55 + 9)%9 = " + ((55 + 9) % 9));

            Console.WriteLine("20 + -3 * 5 / 8 = " + (20 + (double)-3 * 5 / 8));

            Console.WriteLine("5 + 15 / 3 * 2 - 8 % 3 = " + (5 + (double)15 / 3 * 2 - 8 % 3));
            Console.ReadKey();

            Console.WriteLine("\n Assigment 2: \n");
            //Assigment 2

            //Task 1 && 2
            Console.WriteLine("The result of addition is: " + Add(2, 3));
            Console.WriteLine("The result of subtraction is: " + Subtract(5, 3));
            Console.WriteLine("The result of multiplication is: " + Multiply(2, 3));
            Console.WriteLine("The result of division is: " + Divide(10, 2));
            // Task 3:
            DisplayModel();

            // Task 4:
            double average = CalculateAverage(10, 20, 30);
            Console.WriteLine($"Average: {average}");

            // Task 5:
            int remainder = CalculateRemainder(17, 5);
            Console.WriteLine($"Remainder: {remainder}");

            // Task 6:
            double celsiusTemperature = FahrenheitToCelsius(68);
            Console.WriteLine($"Temperature in Celsius: {celsiusTemperature}°C");

            // Task 7:
            double metersDistance = InchesToMeters(50);
            Console.WriteLine($"Distance in meters: {metersDistance} m");

            // Task 8:
            DisplaySpeed(1000, 1, 30, 45);

            // Task 9:
            printCircleInfo(5.0);
            Console.ReadKey();

            Console.WriteLine("\n Assigment 3: \n");

            //Assigment 3
            Calculator calc = new Calculator();
            Console.WriteLine("The result of addition is: " + calc.Add(2, 3));
            Console.WriteLine("The result of subtraction is: " + calc.Subtract(5, 3));
            Console.WriteLine("The result of multiplication is: " + calc.Multiply(2, 3));
            Console.WriteLine("The result of division is: " + calc.Divide(10, 2));

            LogicalOp op = new LogicalOp();

            Console.WriteLine("The bigger number is: " + op.CheckBiggerNumber(2, 3)); // The bigger number is: 3"

            Console.WriteLine(op.CompareWithFastTrackIT("FastTrackIT")); // "Learning text comparison"
            Console.WriteLine(op.CompareWithFastTrackIT("SomethingElse")); // "Got to try some more"

            Console.WriteLine(op.CheckStringAndNumber("FastTrackIT", 2)); // FastTrackIT 2"
            Console.WriteLine(op.CheckStringAndNumber("SomethingElse", 4)); // "4 SomethingElse"

            Console.WriteLine(op.CheckSnowAmount(9)); // "The amount of snow this winter was(cm): 9"
            Console.WriteLine(op.CheckSnowAmount(5)); // "The forecast snow is(cm): 5"

            Console.WriteLine(op.CheckNumber(5)); // "The number is greater than 3 and not equal to 4"
            Console.WriteLine(op.CheckNumber(4)); // "The number is equal to 4"
            Console.WriteLine(op.CheckNumber(2)); // "The number is lower than 3"

            op.DisplayNumber(1); // "The number is: 1!"
            op.DisplayNumber(2); // "The number is: 2!"
            op.DisplayNumber(11); // "The number is not recognized!"

            Console.WriteLine(op.IsNumberEven(2)); // True
            Console.WriteLine(op.IsNumberEven(3)); // False

            Console.WriteLine(op.IsEligibleToVote(18)); // True
            Console.WriteLine(op.IsEligibleToVote(16)); // False

            Console.WriteLine(op.GetMaxNumber(1, 2, 3)); // 3
            Console.ReadKey();

            //Assigment 4

            Console.WriteLine("\nAssigment 4 \n");

            op.CountToHundredFrom(90);
            op.CountToNegativeHundredFrom(10);
            op.CountFromTo(5, 10);
            op.CountFromSmallerToBigger(10, 5);
            op.PrintEvenNumbers();
            op.PrintOddNumbers();
            Console.WriteLine(op.SumFromToHundred(90));
            Console.WriteLine(op.AverageFromToHundred(90));
            op.PrintPattern();

            Console.ReadKey();

            //Assigment 5
            Console.WriteLine("\nAssigment 5 \n");

            op.CountToHundredFromWhile(90);
            op.CountToNegativeHundredFromWhile(10);
            op.CountFromToWhile(5, 10);
            op.CountFromSmallerToBiggerWhile(10, 5);
            op.PrintEvenNumbersWhile();
            op.PrintOddNumbersWhile();
            op.SumAndAverage();
            Console.WriteLine(op.AverageOfDivisibleBySeven(1, 100));
            op.PrintFibonacciNumbers();
            op.CozaLozaWoza();

            Console.ReadKey();

            //Assigment 6

            Console.WriteLine("\nAssigment 6 \n");

            Calculator calculator = new Calculator();

            // Usage of Sum
            Console.WriteLine("Sum of 3 and 5 is: " + calculator.sum(3, 5));
            Console.WriteLine("Sum of 3, 5 and 2 is: " + calculator.sum(3, 5, 2));
            Console.WriteLine("Sum of 3.5, 5.2, 2.1 and 4.3 is: " + calculator.sum(3.5f, 5.2f, 2.1f, 4.3f));

            // Usage of Subtract
            Console.WriteLine("Subtraction of 5 from 3 is: " + calculator.Subtract(3, 5));
            Console.WriteLine("Subtraction of 5 and 2 from 3 is: " + calculator.Subtract(3, 5, 2));
            Console.WriteLine("Subtraction of 5.2, 2.1 and 4.3 from 3.5 is: " + calculator.Subtract(3.5, 5.2, 2.1, 4.3));

            // Usage of Multiply
            Console.WriteLine("Multiplication of 3 and 5 is: " + calculator.Multiply(3, 5));
            Console.WriteLine("Multiplication of 3, 5 and 2 is: " + calculator.Multiply(3.0, 5.0, 2.0));
            Console.WriteLine("Multiplication of 3, 5, 2 and 4 is: " + calculator.Multiply(3, 5, 2, 4));

            // Usage of Divide
            Console.WriteLine("Division of 3 by 5 is: " + calculator.Divide(3.0, 5.0));
            Console.WriteLine("Division of 3 by 5 and 2 is: " + calculator.Divide(3, 5, 2));
            Console.WriteLine("Division of 3.5 by 5.2, 2.1 and 4.3 is: " + calculator.Divide(3.5, 5.2, 2.1, 4.3));

            //Task 2
            int[] myArray = op.PopulateArray();
            Console.WriteLine("Populated Array: " + string.Join(", ", myArray));

            //Task 3
            int[] evenArray = op.PopulateArrayWithEvenNumbers();
            Console.WriteLine("Populated Array with Even Numbers: " + string.Join(", ", evenArray));

            //Task 4
            double average2 = op.CalculateAverage(myArray);
            Console.WriteLine("Average of Array: " + average2);

            //Task 5
            string[] stringArray = { "Hello", "World", "Test" };
            bool doesExist = op.DoesStringExist(stringArray, "Test");
            Console.WriteLine("Does 'Test' exist in string array? " + doesExist);

            //Task 6
            int position = op.FindPosition(myArray, 50);
            Console.WriteLine("Position of 50 in Array: " + position);

            //Task 7
            Console.WriteLine("Displaying Grid:");
            op.DisplayGrid();

            //Task 8
            int[] newArray = op.RemoveNumberFromArray(myArray, 50);
            Console.WriteLine("Array after removing 50: " + string.Join(", ", newArray));

            //Task 9
            int secondSmallest = op.SecondSmallestNumber(myArray);
            Console.WriteLine("Second smallest number in Array: " + secondSmallest);

            //Task 9
            int[] destinationArray = new int[10];
            int[] copiedArray = op.CopyArray(myArray, destinationArray);
            Console.WriteLine("Copied Array: " + string.Join(", ", copiedArray));

            Console.ReadKey();

            //Assigment 7
            Console.WriteLine("\nAssigment 7 \n");

            // Task 1
            List<int> myList = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Task 1: Display list values:");
            op.DisplayList(myList);

            // Task 2
            Console.WriteLine("\nTask 2: Add a number to the list:");
            op.AddNumberToList(myList, 6);
            op.DisplayList(myList);

            // Task 3
            Console.WriteLine("\nTask 3: Display list values from index 2:");
            op.DisplayFromIndex(myList, 2);

            // Task 4
            Console.WriteLine("\nTask 4: Display list values in reverse:");
            op.DisplayListReverse(myList);

            // Task 5
            Console.WriteLine("\nTask 5: Insert a string at a given index:");
            List<string> myListStr = new List<string> { "one", "two", "three" };
            op.InsertStringAt(myListStr, 1, "inserted");
            foreach (var item in myListStr)
            {
                Console.WriteLine(item);
            }

            // Task 6
            Console.WriteLine("\nTask 6: Add value to the beginning of the list:");
            op.AddFirst(myList, 0);
            op.DisplayList(myList);

            // Task 7
            Console.WriteLine("\nTask 7: Display list values and positions:");
            op.DisplayValuesAndPositions(myList);

            // Task 8
            Console.WriteLine("\nTask 8: The largest number in the list is:");
            Console.WriteLine(op.FindLargest(myList));

            Console.ReadKey();

            //Assigment 8 Try-Catch

            Console.WriteLine("\nAssigment 8 \n");

            Read read = new Read();

            //Task 1
            Console.WriteLine("Enter an integer:");
            int inputInt = read.GetInt();
            Console.WriteLine($"You entered: {inputInt}");

            //Task 2
            Console.WriteLine("Enter a float:");
            float inputFloat = read.GetFloat();
            Console.WriteLine($"You entered: {inputFloat}");

            Console.WriteLine("Enter a double:");
            double inputDouble = read.GetDouble();
            Console.WriteLine($"You entered: {inputDouble}");

            Console.WriteLine("Enter a long:");
            long inputLong = read.GetLong();
            Console.WriteLine($"You entered: {inputLong}");

            //Task 3
            Console.WriteLine("Enter array length:");
            int length = read.GetInt();
            Console.WriteLine("Enter array elements:");
            int[] array = read.GetIntArray(length);
            Console.WriteLine("Array elements are:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

            //Task 4
            Console.WriteLine("Enter list elements (non-integer to stop):");
            List<int> list = read.GetIntList();
            Console.WriteLine("List elements are:");
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            //Task 5
            Console.WriteLine("Enter an index:");
            int index = read.GetInt();
            op.DisplayValueAtIndex(array, index);

            //Task 6
            Console.WriteLine("Enter wait time in seconds:");
            int seconds = read.GetInt();
            op.Wait(seconds);
            Console.WriteLine("Wait time has elapsed");

            Console.ReadKey();

            //Assigment 9 Arrays Optional

            Console.WriteLine("\nAssigment 9 Arrays Optional \n");

            int[] arrray = { 1, 2, 3, 4, 2, 3, 5, 6, 1 };
            int[] arrayToInsert = { 1, 2, 3, 4, 5 };
            string[] array1 = { "apple", "banana", "cherry" };
            string[] array2 = { "banana", "cherry", "date", "elderberry" };

            // Task 1
            Console.WriteLine("The second smallest number is: " + op.SecondSmallest(arrray));

            // Task 2
            arrayToInsert = op.InsertElement(arrayToInsert, 2, 99);
            Console.WriteLine("After inserting 99 at position 2: " + string.Join(", ", arrayToInsert));

            // Task 3
            var result = op.MinAndMax(arrray);
            Console.WriteLine("The smallest number is: " + result.Item1);
            Console.WriteLine("The largest number is: " + result.Item2);

            // Task 4
            array = op.ReverseArray(arrray);
            Console.WriteLine("After reversing: " + string.Join(", ", arrray));

            // Task 5
            var duplicates = op.FindDuplicates(arrray);
            Console.WriteLine("Duplicates are: " + string.Join(", ", duplicates));

            // Task 6
            var commonElements = op.CommonElements(array1, array2);
            Console.WriteLine("Common elements are: " + string.Join(", ", commonElements));

            // Task 7
            array = op.SortArray(arrray);
            Console.WriteLine("After sorting: " + string.Join(", ", arrray));

            Console.ReadKey();

            //Assigment 10 Lists Optional

            Console.WriteLine("\nAssigment 10 Lists Optional \n");

            //Task 1

            List<int> myList2 = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original list:");
            foreach (int i in myList2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            myList2 = op.SwapElements(myList2, 0, 2);

            Console.WriteLine("List after swapping:");
            foreach (int i in myList2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Task 2
            List<int> evenNumbers = op.GetEvenNumbers(myList2);
            Console.WriteLine("Even numbers in the list:");
            foreach (int i in evenNumbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Task 3
            List<int> unsortedList = new List<int> { 5, 3, 1, 4, 2 };
            Console.WriteLine("Unsorted list:");
            foreach (int i in unsortedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            List<int> sortedList = op.SortList(unsortedList);
            Console.WriteLine("Sorted list:");
            foreach (int i in sortedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        public static int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public static int Subtract(int a, int b)
        {
            int result = a - b;
            return result;
        }

        public static int Multiply(int a, int b)
        {
            int result = a * b;
            return result;
        }

        public static double Divide(double a, double b)
        {
            if (b != 0)
        {
            return a / b;
        }
        else
        {
            throw new DivideByZeroException();
        }
        }
        public static void DisplayModel()
        {
            Console.WriteLine("  CCC          /          /");
            Console.WriteLine("C          ---/----------/---");
            Console.WriteLine("C            /          /");
            Console.WriteLine("C           /          /");
            Console.WriteLine("C       ---/----------/---");
            Console.WriteLine("  CCC     /          /");
        }

        public static double CalculateAverage(double num1, double num2, double num3)
        {
            return (num1 + num2 + num3) / 3.0;
        }

        public static int CalculateRemainder(int dividend, int divisor)
        {
            return dividend % divisor;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (5.0 / 9.0) * (fahrenheit - 32);
        }

        public static double InchesToMeters(double inches)
        {
            return inches * 0.0254;
        }

        public static void DisplaySpeed(double distanceMeters, int hours, int minutes, int seconds)
        {
            double totalSeconds = hours * 3600 + minutes * 60 + seconds;
            double metersPerSecond = distanceMeters / totalSeconds;
            double kilometersPerHour = (distanceMeters / 1000.0) / (totalSeconds / 3600.0);
            double milesPerHour = (distanceMeters / 1609.0) / (totalSeconds / 3600.0);

            Console.WriteLine($"Speed: {metersPerSecond} m/s");
            Console.WriteLine($"Speed: {kilometersPerHour} km/h");
            Console.WriteLine($"Speed: {milesPerHour} mph");
        }
        public static void printCircleInfo(double radius)
        {
            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine("Perimeter: " + perimeter);
            Console.WriteLine("Area: " + area);
        }
        //test
    }
}

