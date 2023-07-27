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
            double result = a / b;
            return result;
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
    }
}

