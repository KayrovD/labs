using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Circle cic = new Model.Circle(1.0, 2.0, 2.0);
            Model.Rectangle rec = new Model.Rectangle(-1.0, -1.0, -3.0, 0);
            Model.Properties prop_rec = rec;

            System.Console.WriteLine(cic.GetType());
            System.Console.WriteLine("Площадь: " + cic.get_area());
            System.Console.WriteLine("Количество углов: " + cic.number_of_corners);
            System.Console.WriteLine();

            System.Console.WriteLine(rec.GetType());
            System.Console.WriteLine("Площадь: " + rec.get_area());
            System.Console.WriteLine("Количество углов: " + rec.number_of_corners);
            System.Console.WriteLine();

            System.Console.WriteLine(prop_rec.GetType());
            System.Console.WriteLine("Площадь: " + prop_rec.get_area());
            System.Console.WriteLine("Количество углов: " + prop_rec.number_of_corners);
            System.Console.WriteLine("Периметр: " + prop_rec.get_perimeter());

            Model.Testing.Circle();
            System.Console.WriteLine();
            Model.Testing.Rectangle();

            System.Console.Read();
        }
    }
}
