using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface Properties
    {
        int number_of_corners
        {
            get;
        }
        double get_perimeter();
        double get_area();
        string get_type();
    }

    public class Point
    {
        private double x, y;
        public Point(double a, double b)
        {
            x = a;
            y = b;
        }

        public double getX()
        {
            return x;
        }
        public double getY()
        {
            return y;
        }
    }


    public class Circle : Properties
    {
        private string type = "Circle";
        private const int nc = 0;
        private Point O;
        private double R;

        public Circle(double o_x, double o_y, double rad)
        {
            if (rad <= 0)
            {
                System.Console.WriteLine("Радиус должен быть больше нуля!");
                throw new ArgumentException();
            }
            O = new Point(o_x, o_y);
            R = rad;
        }
        public int number_of_corners
        {
            get
            {
                return nc;
            }
        }
        public double get_area()
        {
            return Math.PI * Math.Pow(R, 2.0);
        }
        public double get_perimeter()
        {
            return Math.PI * R * 2;
        }
        public string get_type()
        {
            return type;
        }
    }


    public class Rectangle : Properties
    {
        private string type = "Rectangle";
        private const int nc = 4;
        private double width;
        private double height;
        private Point A;
        private Point B;
        private Point C;
        private Point D;

        public Rectangle(double a_x, double a_y, double c_x, double c_y)
        {
            A = new Point(a_x, a_y);
            C = new Point(c_x, c_y);
            if(a_x < c_x && a_y < c_y)
            {
                B = new Point(a_x, c_y);
                D = new Point(c_x, a_y);
                width = Math.Abs(c_x - a_x);//!!!!
                height = Math.Abs(c_y - a_y);
            }
            if (a_x < c_x && a_y > c_y)
            {
                B = new Point(c_x, a_y);
                D = new Point(a_x, c_y);
                width = Math.Abs(c_x - a_x);
                height = Math.Abs(a_y - c_y);
            }
            if (a_x > c_x && a_y > c_y)
            {
                B = new Point(a_x, c_y);
                D = new Point(c_x, a_y);
                width = Math.Abs(a_x - c_x);
                height = Math.Abs(a_y - c_y);
            }
            if (a_x > c_x && a_y < c_y)
            {
                B = new Point(c_x, a_y);
                D = new Point(a_x, c_y);
                width = Math.Abs(a_x - c_x);
                height = Math.Abs(c_y - a_y);
            }
            if(a_x == c_x || a_y == c_y)
            {
                System.Console.WriteLine("Невозможно построить прямоугольник в плоскости с нулевой площадью,\n" +
                    "стороны которого параллельны координатным осям");
                throw new ArgumentException();
            }
        }

        public int number_of_corners
        {
            get
            {
                return nc;
            }
        }
        public double get_area()
        {
            return width*height;
        }
        public double get_perimeter()
        {
            return width * 2 + height * 2;
        }
        public string get_type()
        {
            return type;
        }
    }


    public static class Testing
    {
        public static void Circle()
        {
            double o_x=0, o_y=0, r=0;
            
            string str;
            bool cond;

            cond = false;
            while (!cond)
            {
                System.Console.WriteLine("Введите координату центра окружности X:");
                str = System.Console.ReadLine();
                try
                {
                    o_x = Double.Parse(str);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                cond = true;
            }

            cond = false;
            while(!cond)
            {
                System.Console.WriteLine("Введите координату центра окружности Y:");
                str = System.Console.ReadLine();
                try
                {
                    o_y = Double.Parse(str);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                cond = true;
            }

            cond = false;
            while (!cond)
            {
                System.Console.WriteLine("Введите радиус окружности R:");
                str = System.Console.ReadLine();
                try
                {
                    r = Double.Parse(str);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                if (r <= 0)
                {
                    System.Console.WriteLine("Радиус должен быть больше нуля!");
                    continue;
                }
                cond = true;
            }

            cond = false;
            while (!cond)
            {
                try {
                    Circle cic = new Circle(o_x, o_y, r);
                    System.Console.WriteLine();
                    System.Console.WriteLine(cic.GetType());
                    System.Console.WriteLine("Фигура: " + cic.get_type());
                    System.Console.WriteLine("Площадь: " + cic.get_area());
                    System.Console.WriteLine("количество углов: " + cic.number_of_corners);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    return;
                }
                cond = true;
            }
        }

        public static void Rectangle()
        {
            double a_x = 0, a_y = 0, c_x = 0, c_y = 0;

            string str;
            bool cond;

            System.Console.WriteLine("Построение прямоугольника в плоскости,\n" +
                "в соответствии с заданными координатами точек диагонали.\n" +
                "Стороны прямоугольника параллельны координатным осям.");
            cond = false;
            while (!cond)
            {
                System.Console.WriteLine("Введите координату X первой точки (A) диагонали:");
                str = System.Console.ReadLine();
                try
                {
                    a_x = Double.Parse(str);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                cond = true;
            }

            cond = false;
            while (!cond)
            {
                System.Console.WriteLine("Введите координату Y первой точки (A) диагонали:");
                str = System.Console.ReadLine();
                try
                {
                    a_y = Double.Parse(str);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                cond = true;
            }

            cond = false;
            while (!cond)
            {
                System.Console.WriteLine("Введите координату X второй точки (C) диагонали:");
                str = System.Console.ReadLine();
                try
                {
                    c_x = Double.Parse(str);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                cond = true;
            }

            cond = false;
            while (!cond)
            {
                System.Console.WriteLine("Введите координату Y второй точки (C) диагонали:");
                str = System.Console.ReadLine();
                try
                {
                    c_y = Double.Parse(str);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
                cond = true;
            }

            if(a_x == c_x || a_y == c_y)
            {
                System.Console.WriteLine("ОШИБКА! Невозможно построить прямоугольник с нулевой площадью!");
                Rectangle();
                return;
            }

            cond = false;
            while (!cond)
            {
                try
                {
                    Rectangle rec = new Rectangle(a_x, a_y, c_x, c_y);
                    System.Console.WriteLine();
                    System.Console.WriteLine(rec.GetType());
                    System.Console.WriteLine("Фигура: " + rec.get_type());
                    System.Console.WriteLine("Площадь: " + rec.get_area());
                    System.Console.WriteLine("количество углов: " + rec.number_of_corners);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    return;
                }
                cond = true;
            }
        }
    }
}
