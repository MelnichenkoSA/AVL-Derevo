using AVL_Derevo;

Derevo tree = new Derevo();

tree.Insert(50);
tree.Insert(30);
tree.Insert(20);
tree.Insert(40);
tree.Insert(70);
tree.Insert(60);
tree.Insert(80);

Console.WriteLine("Инфиксный:");
tree.InorderTraversal();
Console.WriteLine("\n Префиксный:");
tree.PreorderTraversal();
Console.WriteLine("\n Постфиксный:");
tree.PostorderTraversal();

Console.WriteLine("\nSearching for 30: " + tree.Find(30));
Console.WriteLine("Searching for 45: " + tree.Find(45));

tree.Delete(50);
Console.WriteLine("\nInorder traversal after deleting 30:");
tree.InorderTraversal();