using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            ComplexNumber p1 = new ComplexNumber();
            ComplexNumber p2 = new ComplexNumber();

            p1.Input(0, 0);
            p2.Input(0, 0);
            Console.Write("First ");
            p1.Print(0, 0);
            Console.Write("Second ");
            p2.Print(0, 0);

            ComplexNumber p3 = p1 + p2;
            Console.Write("Sum ");
            p3.Print(0, 0);
            Console.Write("Difference ");
            ComplexNumber p4 = p1 - p2;
            p4.Print(0, 0);

            Console.WriteLine("First number = second number si " + (p1 == p2));
            Console.WriteLine("First number != second number si " + (p1 != p2));
            Console.WriteLine("First number < second number si " + (p1 < p2));
            Console.WriteLine("First number > second number si " + (p1 > p2));
                        
            Console.ReadKey();
        }
    }

    public class ComplexNumber
    {
        public int real;
        public int imaginary;

        public ComplexNumber()
        {
            real = 0;
            imaginary = 0;
        }

        public ComplexNumber(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public void Input(int real, int imaginary)
        {
            Console.WriteLine("Enter real path:");
            this.real = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter price:");
            this.imaginary = Convert.ToInt32(Console.ReadLine());
        }

        public void Print(int real, int imaginary)
        {
            Console.WriteLine("comlex number = " + this.real + " + i*"+ this.imaginary);
        }

        public static ComplexNumber operator +(ComplexNumber number1, ComplexNumber number2)
        {
            int newReal = number1.real + number2.real;
            int newImaginary = number1.imaginary + number2.imaginary;
            return new ComplexNumber(newReal, newImaginary);
        }

        public static ComplexNumber operator -(ComplexNumber number1, ComplexNumber number2)
        {
            int newReal = number1.real - number2.real;
            int newImaginary = number1.imaginary - number2.imaginary;
            return new ComplexNumber(newReal, newImaginary);
        }

        public static bool operator ==(ComplexNumber number1, ComplexNumber number2)
        {
            return (number1.real == number2.real && number1.imaginary == number2.imaginary) ? true : false;
        }

        public static bool operator !=(ComplexNumber number1, ComplexNumber number2)
        {
            return (number1.real == number2.real && number1.imaginary == number2.imaginary) ? false : true;
        }

        public static bool operator <(ComplexNumber number1, ComplexNumber number2)
        {
            if (number1.real < number2.real)
                return true;
            if (number1.imaginary < number2.imaginary)
                return true;
            return false;
        }

        public static bool operator >(ComplexNumber number1, ComplexNumber number2)
        {
            if (number1.real > number2.real)
                return true;
            if (number1.imaginary > number2.imaginary)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            ComplexNumber c1 = obj as ComplexNumber;
            if (real == c1.real && imaginary == c1.imaginary)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hashcode = real.GetHashCode();
            hashcode = hashcode + imaginary.GetHashCode();
            return hashcode;
        }

        public static explicit operator ComplexNumber(string Complex)
        {
            int a, b;
            string strA, strB;
            strA = Complex.Substring(0, Complex.IndexOf('+'));
            strB = Complex.Substring(Complex.IndexOf('+') + 1, Complex.Length - Complex.IndexOf('+') - 2);
            return int.TryParse(strA, out a) && int.TryParse(strB, out b) ? new ComplexNumber(a, b) : new ComplexNumber(0, 0);
        }

        public static implicit operator String(ComplexNumber ComplexString)
        {
            return ComplexString.ToString();
        }

        public override string ToString()
        {
            if (imaginary < 0)
                return String.Format($"{real}{imaginary}i");
            else if (real == 0 && imaginary == 0) return "0";
            return String.Format($"{real}+{imaginary}i");
        }        

        class ComplexSet : IEnumerable
        {
            ArrayList myMass = new ArrayList();

            public ComplexNumber this[int i]
            {
                get
                {
                    return (ComplexNumber)myMass[i];
                }
                set
                {
                    myMass.Insert(i, value);
                }
            }
            public ComplexNumber this[string str]
            {
                get
                {
                    foreach (ComplexNumber num in myMass)
                    {
                        if (num.ToString() == str)
                            return num;
                    }
                    return new ComplexNumber(0, 0);
                }
            }
            public IEnumerator GetEnumerator()
            {
                return myMass.GetEnumerator();
            }
        }
    }
}