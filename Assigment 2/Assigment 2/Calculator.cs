using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_1
{
    internal class Calculator
    {
        public int sum(int a, int b)
        {
            return a + b;
        }

        public int sum(int a, int b, int c)
        {
            return a + b + c;
        }

        public float sum(float a, float b, float c, float d)
        {
            return a + b + c + d;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public double Subtract(double a, double b, double c)
        {
            return a - b - c;
        }

        public double Subtract(double a, double b, double c, double d)
        {
            return a - b - c - d;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Multiply(double a, double b, double c)
        {
            return a * b * c;
        }

        public int Multiply(int a, int b, int c, int d)
        {
            return a * b * c * d;
        }

        public double Divide(double a, double b)
        {
            if (b != 0)
                return a / b;
            else
                throw new DivideByZeroException();
        }

        public long Divide(long a, long b, long c)
        {
            if (b != 0 && c !=0)
                return a / b / c;
            else
                throw new DivideByZeroException();
        }

        public double Divide(double a, double b, double c, double d)
        {
            if (b != 0 && c!=0 && d!= 0)
                return a / b / c / d;
            else
                throw new DivideByZeroException();
        }
    }
}
