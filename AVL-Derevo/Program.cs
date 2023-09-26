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
