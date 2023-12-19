using AVL_Derevo;

Derevo tree = new Derevo();

tree.Insert(50);
tree.Insert(30);
tree.Insert(35);
Console.WriteLine(tree.Root.Height);
tree.Insert(40);
tree.Insert(70);
Console.WriteLine(tree.Root.Height);
tree.Insert(60);
tree.Insert(15);
Console.WriteLine(tree.Root.Height);

Console.WriteLine("Инфиксный:");
tree.InorderTraversal();
Console.WriteLine("\nПрефиксный:");
tree.PreorderTraversal();
Console.WriteLine("\nПостфиксный:");
tree.PostorderTraversal();

Console.WriteLine("\nПоиск 30: " + tree.Find(30));
Console.WriteLine("Поиск 45: " + tree.Find(45));

tree.Delete(50);
Console.WriteLine(tree.Root.Height);
Console.WriteLine("\nИнфиксный после удаления 50:");
tree.InorderTraversal();

tree.Balance();
Console.WriteLine(tree.Root.Height);
Console.WriteLine("\nИнфиксный после баланса:");
tree.InorderTraversal();
Console.WriteLine("\nПрефиксный после баланса:");
tree.PreorderTraversal();
Console.WriteLine("\nПостфиксный после баланса:");
tree.PostorderTraversal();


Derevo tree3 = new Derevo();
Console.WriteLine();
tree3 = tree + 2;
tree.PostorderTraversal();
Console.WriteLine();
tree3.PostorderTraversal();

Derevo tree300 = new Derevo();
Derevo tree400 = new Derevo();

tree300.Insert(50);
tree300.Insert(30);
tree300.Insert(35);
tree300.Insert(40);
tree300.Insert(70);
tree300.Insert(60);
tree300.Insert(15);

tree400.Insert(50);
tree400.Insert(30);
tree400.Insert(45);
tree400.Insert(40);
tree400.Insert(70);
tree400.Insert(20);
tree400.Insert(15);
tree400.Insert(1);


Derevo tree500 = new Derevo();

tree500 = tree300 + tree400;
tree500.Balance();
Console.WriteLine("\nСложение");
Console.WriteLine();
tree500.PreorderTraversal();
Console.WriteLine();
tree500.InorderTraversal();
Console.WriteLine();
tree500.PostorderTraversal();
Console.WriteLine();

Console.WriteLine("/nСложение2");

Derevo tree600 = new Derevo();
tree600.Insert(1);
tree600.Insert(2);
tree600.Insert(6);
tree600.Insert(7);
tree600.Insert(5);

Derevo tree700 = new Derevo();
tree700.Insert(11);
tree700.Insert(12);
tree700.Insert(8);
tree700.Insert(9);
tree700.Insert(10);

Derevo a = tree600 + tree700;
Console.WriteLine();
a.PreorderTraversal();

