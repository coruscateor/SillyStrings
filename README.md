Ever wanted to build strings using dynamic invocation?

Well with SillyStrings you can:

	dynamic x = new StringWriter();

	x("a", "b", "c", 1, 2, 3);

	Console.WriteLine(x);


outputs:

a b c 1 2 3 


	x.two.plus.two("is").four();

	Console.WriteLine(x);

	
outputs:

two plus two is four


You can also write directly to the console:


	x = new ConsoleWriter();

	x.a.e.i.o.u();


a e i o u 


	x(1)(2)(3)(4)(5);


1 2 3 4 5


	x.a("+").b("=").c();


a + b = c


	x.select("*").from.table.where.id("=")(5);


select * from table where id = 5


You get the idea