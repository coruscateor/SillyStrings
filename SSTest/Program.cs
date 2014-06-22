using System;
using System.Collections.Generic;
using System.Dynamic;
using SillyStrings;

namespace SSTest
{

    class Program
    {

        static void Main(string[] args)
        {

            dynamic x = new StringWriter();

            x("a", "b", "c", 1, 2, 3);

            Console.WriteLine(x);

            Console.WriteLine();

            x = new StringWriter();

            x.lets.test.now();

            Console.WriteLine(x);

            Console.WriteLine();

            x = new StringWriter();

            x.two.plus.two("is").four();

            Console.WriteLine(x);

            Console.WriteLine();

            x = new StringWriter();

            x("something");

            Console.WriteLine(x);

            Console.WriteLine();

            x = new ConsoleWriter();

            x.a.e.i.o.u();

            Console.WriteLine();

            Console.WriteLine();

            x(1)(2)(3)(4)(5);

            Console.WriteLine();

            Console.WriteLine();

            x = x + 6;

            Console.WriteLine();

            Console.WriteLine();

            x += 7;

            Console.WriteLine();

            Console.WriteLine();

            x.a("+").b("=").c();

            Console.WriteLine();

            Console.WriteLine();

            x.select("*").from.table.where.id("=")(5);

            Console.WriteLine();

            Console.WriteLine();

            Console.ReadLine();

        }

    }

}
